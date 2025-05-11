'Public Class Class_common

'End Class
Imports System
Imports System.IO

Class Class_common

    Sub Main()
        Dim cols As Integer = Console.WindowWidth

        Dim platform As String = Environment.OSVersion.Platform.ToString()

        Dim message As String = ""
        Dim show As Boolean = True
        Dim err As Boolean = False
        Dim recur As Boolean = False
        Dim prefix As Boolean = True

        log_message(message, show, err, recur, prefix, cols, platform)

        Dim progress As Integer = 50
        Dim complete As Integer = 100

        message = "Loading..."
        progress_bar(progress, complete, message, show, cols)

    End Sub

    Sub log_message(message As String, show As Boolean, err As Boolean, recur As Boolean, prefix As Boolean, cols As Integer, platform As String)
        If Not show Then
            Return
        End If

        Dim out As TextWriter = Console.Out
        If err Then
            out = Console.Error
        End If

        Dim endLine As String = Environment.NewLine
        If recur Then
            endLine = vbCr
            If platform = "Win32NT" Then
                message = vbCr & message
            End If

            If cols < message.Length Then
                message = message.Substring(0, cols)
            End If
        End If

        If prefix Then
            message = "[sstv] " & message
        End If

        out.Write(message & endLine)
    End Sub

    Sub progress_bar(progress As Integer, complete As Integer, message As String, show As Boolean, cols As Integer)
        If Not show Then
            Return
        End If

        Dim messageSize As Integer = message.Length + 7 ' prefix size
        Dim percentOn As Boolean = True
        Dim level As Double = progress / complete
        Dim barSize As Integer = Math.Min(cols - messageSize - 10, 100)
        Dim bar As String = ""

        If barSize > 5 Then
            Dim fillSize As Integer = Math.Round(barSize * level)
            bar = "[" & New String("#"c, fillSize) & New String("."c, barSize - fillSize) & "]"
        ElseIf barSize < -3 Then
            percentOn = False
        End If

        Dim percent As String = ""
        If percentOn Then
            percent = String.Format("{0,4}% ", CInt(level * 100))
        End If

        Dim align As Integer = cols - messageSize - percent.Length
        Dim notEnd As Boolean = Not progress = complete
        log_message(message & bar & percent.PadLeft(align), recur:=notEnd, cols:=cols)
    End Sub

End Class