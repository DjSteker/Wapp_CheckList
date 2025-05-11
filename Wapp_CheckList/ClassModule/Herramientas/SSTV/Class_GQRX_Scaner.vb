

Imports System
Imports System.Net
Imports System.Text
Imports System.Threading

Public Class Class_GQRX_Scaner
    Private host As String
    Private port As Integer
    Private squelch As Integer

    Public Sub New(Optional ByVal hostname As String = "127.0.0.1",
                   Optional ByVal port As Integer = 7356,
                   Optional ByVal squelch As Integer = -20)
        Me.host = hostname
        Me.port = port
        Me.squelch = squelch
    End Sub

    Private Function Request(ByVal message As String) As String
        Dim response As String = ""
        Try
            Dim client As New WebClient()
            Dim data As Byte() = Encoding.ASCII.GetBytes(message)
            Dim responseData As Byte() = client.UploadData(Me.host, "POST", data)
            response = Encoding.ASCII.GetString(responseData)
        Catch ex As Exception
            Console.WriteLine("Encountered: " & ex.Message)
        End Try
        Return response
    End Function

    Public Function SetFrequency(ByVal frequency As String) As String
        Return Me.Request("F " & frequency)
    End Function

    Public Function GetFrequency() As String
        Return Me.Request("f")
    End Function

    Public Function SetMode(ByVal mode As String) As String
        Return Me.Request("M " & mode)
    End Function

    Public Function GetMode() As String
        Return Me.Request("m")
    End Function

    Public Function GetLevel() As String
        Return Me.Request("l")
    End Function

    Public Function SetSquelch(ByVal squelch As Integer) As String
        Return Me.Request("L SQL " & squelch)
    End Function

    Public Sub Scan(ByVal minFrequency As Double, ByVal maxFrequency As Double, ByVal mode As String, Optional ByVal step1 As Integer = 50000)
        Dim minFreq As Integer = CInt((CDbl(minFrequency) * 100000.0).ToString().Replace(".", ""))
        Dim maxFreq As Integer = CInt((CDbl(maxFrequency) * 100000.0).ToString().Replace(".", ""))
        Dim currentFreq As Integer = minFreq
        Me.SetMode(mode)

        While True
            If currentFreq > maxFreq Then
                currentFreq = minFreq
            End If

            Me.SetFrequency(currentFreq.ToString())
            Me.SetSquelch(Me.squelch)
            Thread.Sleep(500)

            If CDbl(Me.GetLevel()) >= Me.squelch Then
                Console.WriteLine("Found: " & currentFreq)
                Thread.Sleep(3000)
            End If
            currentFreq += step1
        End While
    End Sub

    Public Sub PeakScan(ByVal minFrequency As Double, ByVal maxFrequency As Double, ByVal mode As String, Optional ByVal step As Integer = 50000)
        Dim minFreq As Integer = CInt((CDbl(minFrequency) * 100000.0).ToString().Replace(".", ""))
        Dim maxFreq As Integer = CInt((CDbl(maxFrequency) * 100000.0).ToString().Replace(".", ""))
        Dim currentFreq As Integer = minFreq
        Me.SetMode(mode)

        While True
            If currentFreq > maxFreq Then
                currentFreq = minFreq
            End If

            Dim peakFreq As Integer = currentFreq
            Dim currentSquelch As Integer = Me.squelch
            Dim customStep As Integer = step
            Me.SetFrequency(currentFreq.ToString())
            Me.SetSquelch(Me.squelch)
            Thread.Sleep(500)

            While CDbl(Me.GetLevel()) >= currentSquelch
                peakFreq = currentFreq
                currentSquelch += 5
                currentFreq += 10000
                Me.SetFrequency(currentFreq.ToString())
                Me.SetSquelch(currentSquelch)
                Thread.Sleep(500)
            End While

            If peakFreq <> currentFreq Then
                Console.WriteLine("Found: " & peakFreq)
                customStep += (peakFreq - currentFreq) * 1.15
            End If
            currentFreq += customStep
        End While
    End Sub
End Class

Module Program
    Sub Main(args As String())
        Dim scanner As New Class_GQRX_Scaner()
        scanner.PeakScan(88.0, 100.0, "WFM_ST")
    End Sub
End Module
