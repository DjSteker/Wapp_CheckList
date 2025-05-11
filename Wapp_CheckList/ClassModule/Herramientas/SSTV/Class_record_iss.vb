'Public Class Class_record_iss

'End Class

Imports System
Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Threading
Imports System.Globalization
Imports System.Diagnostics
Imports System.Math
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates

Class Class_record_iss
    Dim LATITUDE As String = "52.219308"
    Dim LONGITUDE As String = "4.419926"
    Dim ALTITUDE As Integer = 20

    Dim MODE As String = "fm"
    Dim FREQ As String = "145.8M"
    Dim RATE As String = "48k"

    Dim FILE_FMT As String = "{0:yyyy_MM_dd-HH_mm_ss}.raw"

    Dim rtl_cmd As String() = {"rtl_fm", "-M", MODE, "-f", FREQ, "-s", RATE}

    Class tle_reader
        Private _tle_name As String
        Private _tle_file As String
        Private _tle_max_age As Integer
        Private _tle As Object
        Private _tle_age As Double

        Public Sub New(Optional ByVal tle_name As String = "ISS (ZARYA)",
                       Optional ByVal tle_file As String = "https://celestrak.com/NORAD/elements/stations.txt",
                       Optional ByVal tle_max_age As Integer = 3600)
            _tle_name = tle_name
            _tle_file = tle_file
            _tle_max_age = tle_max_age
            reload()
        End Sub

        Private Function build_index(tle_lines As String()) As Dictionary(Of String, Tuple(Of String, String))
            Dim index As New Dictionary(Of String, Tuple(Of String, String))
            For i As Integer = 0 To tle_lines.Length - 1 Step 3
                index(tle_lines(i).Trim()) = New Tuple(Of String, String)(tle_lines(i + 1), tle_lines(i + 2))
            Next
            Return index
        End Function

        Public Sub reload()
            Console.WriteLine("Loading: " & _tle_file)

            Try
                Dim ctx As New SslStream(New MemoryStream())
                ctx.CheckCertRevocationStatus = False
                ctx.CheckHostname = Function(s, cert, chain, errors) True
                ServicePointManager.ServerCertificateValidationCallback = Function(sender, certificate, chain, sslPolicyErrors) True
                Dim request As HttpWebRequest = WebRequest.Create(_tle_file)
                Dim response As HttpWebResponse = request.GetResponse()
                Dim reader As New StreamReader(response.GetResponseStream())
                Dim tle_lines As String() = reader.ReadToEnd().Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                Dim index As Dictionary(Of String, Tuple(Of String, String)) = build_index(tle_lines)
                Dim tle_data As Tuple(Of String, String) = index(_tle_name)
                _tle = New ephem.readtle(_tle_name, tle_data.Item1, tle_data.Item2)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

            _tle_age = DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalSeconds
        End Sub

        Public ReadOnly Property tle As Object
            Get
                Return _tle
            End Get
        End Property

        Public ReadOnly Property tle_expired As Boolean
            Get
                Return DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalSeconds - _tle_age > _tle_max_age
            End Get
        End Property
    End Class

    Sub Main()
        Dim iss As New tle_reader("ISS (ZARYA)", 5520)

        If iss.tle Is Nothing Then
            Environment.Exit(0)
        End If

        Dim myloc As New ephem.Observer()
        myloc.lon = LONGITUDE
        myloc.lat = LATITUDE
        myloc.elevation = ALTITUDE

        Dim running As Boolean = True

        While running
            myloc.[Date] = DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture)
            iss.tle.compute(myloc)
            Dim alt As Double = Math.Round(Math.Asin(iss.tle.alt) * 180 / Math.PI, 2)

            If alt > 0 Then
                Dim fn As String = String.Format(FILE_FMT, DateTime.UtcNow)
                Dim f As FileStream = File.Create(fn)
                Dim proc As Process = Process.Start(New ProcessStartInfo With {
                    .FileName = rtl_cmd(0),
                    .Arguments = String.Join(" ", rtl_cmd, 1, rtl_cmd.Length - 1),
                    .UseShellExecute = False,
                    .RedirectStandardOutput = True
                })
                While alt > 0
                    myloc.[Date] = DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture)
                    iss.tle.compute(myloc)
                    alt = Math.Round(Math.Asin(iss.tle.alt) * 180 / Math.PI, 2)
                    Thread.Sleep(10000)
                End While
                f.Flush()
                proc.Kill()
                proc.WaitForExit()
                f.Close()
            ElseIf iss.tle_expired Then
                iss.reload()
            Else
                Thread.Sleep(10000)
            End If
        End While
    End Sub
End Class

