'Public Class Class_SSTVCommand

'End Class


Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

Imports NAudio.Wave

Namespace SSTVDecoder
    Public Class SSTVCommand
        Private Shared examples_of_use As String = "
examples:
  Decode local SSTV audio file named 'audio.ogg' to 'result.png':
    $ sstv -d audio.ogg

  Decode SSTV audio file in /tmp to './image.jpg':
    $ sstv -d /tmp/signal.wav -o ./image.jpg

  Start decoding SSTV signal at 50.5 seconds into the audio
    $ sstv -d audio.ogg -s 50.50"

        Private _audio_file As FileStream = Nothing
        Private _output_file As String = Nothing

        Public Sub New(shell_args As String())
            Me.args = Me.parse_args(shell_args)
        End Sub

        Public Sub New()
            Me.args = Me.parse_args(Environment.GetCommandLineArgs().Skip(1).ToArray())
        End Sub

        Public Sub Dispose()
            Me.Close()
        End Sub

        Public Sub Close()
            If Me._audio_file IsNot Nothing Then
                Me._audio_file.Close()
            End If
        End Sub

        Private Function init_args() As CommandLineArgs
            Dim version As String = "sstv 0.1"

            Dim parser As New CommandLineArgs("sstv") With {
                .Formatter = New HelpFormatter(),
                .Epilog = examples_of_use
            }

            parser.AddOption("-d", "--decode", GetType(FileStream), "decode SSTV audio file", "audio_file")
            parser.AddOption("-o", "--output", GetType(String), "save output image to custom location", "result.png", "output_file")
            parser.AddOption("-s", "--skip", GetType(Double), "time in seconds to start decoding signal at", 0.0, "skip")
            parser.AddOption("-V", "--version", GetType(String), version)
            parser.AddOption("--list-modes", GetType(Boolean), "list supported SSTV modes")
            parser.AddOption("--list-audio-formats", GetType(Boolean), "list supported audio file formats")
            parser.AddOption("--list-image-formats", GetType(Boolean), "list supported image file formats")

            Return parser
        End Function

        Private Function parse_args(shell_args As String()) As CommandLineArgs
            Dim parser As CommandLineArgs = Me.init_args()
            Dim args As CommandLineArgs = parser.Parse(shell_args)

            Me._audio_file = args.GetValue(Of FileStream)("audio_file")
            Me._output_file = args.GetValue(Of String)("output_file")
            Me._skip = args.GetValue(Of Double)("skip")

            If args.GetValue(Of Boolean)("list_modes") Then
                Me.list_supported_modes()
                Environment.Exit(0)
            End If

            If args.GetValue(Of Boolean)("list_audio_formats") Then
                Me.list_supported_audio_formats()
                Environment.Exit(0)
            End If

            If args.GetValue(Of Boolean)("list_image_formats") Then
                Me.list_supported_image_formats()
                Environment.Exit(0)
            End If

            If Me._audio_file Is Nothing Then
                parser.PrintHelp()
                Environment.Exit(2)
            End If

            Return args
        End Function

        Public Sub Start()
            Using sstv As New SSTVDecoder(Me._audio_file)
                Dim img As Image = sstv.Decode(Me._skip)
                If img Is Nothing Then
                    Environment.Exit(2)
                End If

                Try
                    img.Save(Me._output_file)
                Catch ex As Exception
                    Console.WriteLine("Error saving file, saved to result.png instead")
                    img.Save("result.png")
                End Try
            End Using
        End Sub

        Public Sub ListSupportedModes()
            Dim modes As String = String.Join(", ", VIS_MAP.Values.Select(Function(fmt) fmt.NAME))
            Console.WriteLine("Supported modes: " & modes)
        End Sub

        Public Sub ListSupportedAudioFormats()
            Dim audio_formats As String = String.Join(", ", available_audio_formats().Keys)
            Console.WriteLine("Supported audio formats: " & audio_formats)
        End Sub

        Public Sub ListSupportedImageFormats()
            Image.Init()
            Dim image_formats As String = String.Join(", ", Image.Save.Keys)
            Console.WriteLine("Supported image formats: " & image_formats)
        End Sub
    End Class
End Namespace