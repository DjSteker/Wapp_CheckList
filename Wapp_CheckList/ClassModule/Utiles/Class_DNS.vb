Imports System.Net

Public Class Class_DNS

    Class RequestState
        Public host As IPHostEntry

        Public Sub New()
            host = Nothing
        End Sub
    End Class


    Dim Respuesta As String
    Dim URL As String

    Public Function mainDNS(ByVal ByVal_URL As String) As String

        URL = ByVal_URL
        GetRespuesta()

        Return Respuesta
    End Function


    Friend Sub GetRespuesta()

        Try
            ' Create an instance of the RequestState class.
            Dim myRequestState As New RequestState()

            ' Begin an asynchronous request for information such as the host name, IP addresses, 
            ' or aliases for the specified URI.
            Dim asyncResult As IAsyncResult = CType(Dns.BeginResolve(URL, AddressOf RespCallback, myRequestState), IAsyncResult)
            My.Application.DoEvents()
            ' Wait until asynchronous call completes.
            While asyncResult.IsCompleted <> True
                Threading.Thread.Sleep(100)
            End While

            Console.WriteLine(("Host name : " + myRequestState.host.HostName))
            Console.WriteLine(ControlChars.Cr + "IP address list : ")
            Respuesta = Respuesta & vbCrLf & "Host name : " & myRequestState.host.HostName
            Respuesta = Respuesta & vbCr & ControlChars.Cr + "IP address list : "

            Dim index As Integer
            For index = 0 To myRequestState.host.AddressList.Length - 1
                Console.WriteLine(myRequestState.host.AddressList(index))
                Respuesta = Respuesta & vbCrLf & myRequestState.host.AddressList(index).ToString
            Next index
            Console.WriteLine(ControlChars.Cr + "Aliases : ")
            Respuesta = Respuesta & vbCrLf & ControlChars.Cr + "Aliases : "
            For index = 0 To myRequestState.host.Aliases.Length - 1
                Console.WriteLine(myRequestState.host.Aliases(index))
                Respuesta = Respuesta & vbCrLf & myRequestState.host.Aliases(index)
            Next index
        Catch e As Exception
            Console.WriteLine("Exception caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
            Respuesta = Respuesta & vbCrLf & "Exception caught!!!"
            Respuesta = Respuesta & vbCrLf & "Source : " & e.Source
            Respuesta = Respuesta & vbCrLf & "Message : " & e.Message
        End Try

    End Sub


    Private Shared Sub RespCallback(ar As IAsyncResult)
        Try
            ' Convert the IAsyncResult object to a RequestState object.
            Dim tempRequestState As RequestState = CType(ar.AsyncState, RequestState)

            ' End the asynchronous request.
            tempRequestState.host = Dns.EndResolve(ar)
        Catch e As ArgumentNullException
            Console.WriteLine("ArgumentNullException caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
            'RichTextBox1.Text = RichTextBox1.Text & vbCrLf & "ArgumentNullException caught!!!"
            'RichTextBox1.Text = RichTextBox1.Text & vbCrLf & "Source : " & e.Source
            'RichTextBox1.Text = RichTextBox1.Text & vbCrLf & "Message : " & e.Message
        Catch e As Exception
            Console.WriteLine("Exception caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
            'RichTextBox1.Text = RichTextBox1.Text & vbCrLf & "Exception caught!!!"
            'RichTextBox1.Text = RichTextBox1.Text & vbCrLf & "Source : " & e.Source
            'RichTextBox1.Text = RichTextBox1.Text & vbCrLf & "Message : " & e.Message
        End Try
    End Sub

End Class
