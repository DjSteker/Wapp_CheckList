Imports System.Net

Public Class Form_InforedWAN

    Private Sub Form_InforedNAT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'La opción /c en processInfo.Arguments = "/c ..." indica a cmd.exe que ejecute el comando especificado y luego se cierre. En otras palabras, /c le dice a cmd.exe que ejecute el comando y luego termine la sesión de la línea de comandos. Si no se usa la opción /c, cmd.exe seguirá ejecutando después de que se complete el comando.
        'En el código que proporcionó, processInfo.Arguments = "/c ipconfig" indica que cmd.exe debe ejecutar el comando ipconfig y luego cerrar la sesión de la línea de comandos.

        'La opción /y en Pross.StartInfo.Arguments = "/C instruccón /y" indica a cmd.exe que responda “Sí” a cualquier pregunta de confirmación que se le presente durante la ejecución del comando. Por ejemplo, si el comando instruccón intenta sobrescribir un archivo existente, cmd.exe preguntará si desea sobrescribir el archivo. Si se usa la opción /y, cmd.exe responderá “Sí” automáticamente y sobrescribirá el archivo sin preguntar.
        'En el código que proporcionó, Pross.StartInfo.Arguments = "/C instruccón /y" indica que cmd.exe debe ejecutar el comando instruccón y responder “Sí” a cualquier pregunta de confirmación que se le presente durante la ejecución del comando.

        '/c Ejecuta el comando especificado y luego cierra la sesión de la línea de comandos.
        '/k: Ejecuta el comando especificado y luego mantiene la sesión de la línea de comandos abierta.
        '/y: Responde “Sí” a cualquier pregunta de confirmación que se le presente durante la ejecución del comando.
        '/n: Desactiva la extensión de comandos de Windows.
        '/v: Habilita la extensión de variables de Windows.
        '/t: Establece el tiempo de espera para el comando en segundos.
        '/d: Establece el directorio de trabajo actual para el comando.
    End Sub



    Dim ctThread As Threading.Thread
    Event Event_Mensage(ByVal EventNumber As String)

    Delegate Sub DelegateMensaje(ByVal MSG As String)
    Private Sub msg(ByVal Mensaje As String)
        If Me.RichTextBox1.InvokeRequired Then
            Dim d As New DelegateMensaje(AddressOf msg)
            Call RichTextBox1.Invoke(d, New Object() {Mensaje})
        Else

            'RichTextBox1.Lines.Last
            'RichTextBox1.SelectedText = RichTextBox1.Lines.Last
            If RichTextBox1.TextLength > 250000 Then
                RichTextBox1.Text = String.Empty
            End If
            RichTextBox1.Text &= Environment.NewLine & Mensaje
            'RichTextBox1.Select(RichTextBox1.TextLength - 2, RichTextBox1.TextLength - 1)
            RichTextBox1.Select(RichTextBox1.TextLength - 1, RichTextBox1.TextLength)

            RichTextBox1.ScrollToCaret()
            'RichTextBox1.Height = 212

        End If
    End Sub

    Private Sub msgCLR()
        If Me.RichTextBox1.InvokeRequired Then
            Dim d As New DelegateMensaje(AddressOf msg)
            Call RichTextBox1.Invoke(d, New Object() {})
        Else
            RichTextBox1.Text = String.Empty
            RichTextBox1.ScrollToCaret()
        End If
    End Sub

    Delegate Sub DelegateMensajeConsola(ByVal MSG As String, ByVal LimparTexto As Boolean)
    Private Sub msg_Consola(ByVal Mensaje As String, ByVal LimparTexto As Boolean)
        If Me.RichTextBox_Resultado.InvokeRequired Then
            Dim d As New DelegateMensajeConsola(AddressOf msg_Consola)
            Call RichTextBox_Resultado.Invoke(d, New Object() {Mensaje, LimparTexto})
        Else

            If RichTextBox_Resultado.TextLength > 250000 Then
                RichTextBox_Resultado.Text = String.Empty
            End If
            RichTextBox_Resultado.Text &= Environment.NewLine & Mensaje
            'RichTextBox1.Select(RichTextBox1.TextLength - 2, RichTextBox1.TextLength - 1)
            RichTextBox_Resultado.Select(RichTextBox_Resultado.TextLength - 1, RichTextBox_Resultado.TextLength)

            RichTextBox_Resultado.ScrollToCaret()
            'RichTextBox1.Height = 212
        End If
    End Sub




    Private Sub Form_Red_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_PingMTU_Click(sender As Object, e As EventArgs) Handles Button_PingMTU.Click
        Try
            'RichTextBox_Resultado.AppendText(Shell("PING " & TextBox_Direccion.Text.Trim & "-f -1 " & TextBox_TamañoMTU.Text) & vbCrLf)
            Dim exitCode As Integer
            Dim Pross As Process = New Process
            Dim processInfo As New ProcessStartInfo
            'processInfo = New ProcessStartInfo("cmd.exe", "/c PING " & TextBox_Direccion.Text.Trim & " -f -l " & TextBox_TamañoMTU.Text & "")




            processInfo.FileName = "cmd.exe"
            processInfo.Arguments = "/c PING " & TextBox_IP.Text.Trim & " -f -l " & TextBox_TamañoMTU.Text

            processInfo.CreateNoWindow = True
            processInfo.UseShellExecute = False

            ' *** Redirect the output ***
            processInfo.RedirectStandardError = True
            processInfo.RedirectStandardOutput = True
            'Pross.StartInfo.FileName = "cmd.exe"
            ' Pross.StartInfo.Arguments = "/C instruccón /y"
            'Pross.StartInfo.Arguments = "/C PING " & TextBox_Direccion.Text.Trim & " -f -1 " & TextBox_TamañoMTU.Text & "/y"
            Pross.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            'Pross.Start()
            Pross = Process.Start(processInfo)
            Pross.WaitForExit(10000)
            Dim output As String = Pross.StandardOutput.ReadToEnd
            Dim error1 As String = Pross.StandardError.ReadToEnd.ToString
            exitCode = Pross.ExitCode
            Pross.Close()

            'RichTextBox_Resultado.AppendText(output & vbCrLf)
            'RichTextBox_Resultado.AppendText(String.IsNullOrEmpty(output) & vbCrLf)
            'RichTextBox_Resultado.AppendText(String.IsNullOrEmpty(error1) & vbCrLf)

            msg_Consola(output & vbCrLf, False)
            msg_Consola(String.IsNullOrEmpty(output) & vbCrLf, False)
            msg_Consola(String.IsNullOrEmpty(error1) & vbCrLf, False)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button_GetMAC_Click(sender As Object, e As EventArgs) Handles Button_GetMAC.Click
        Try
            'RichTextBox_Resultado.AppendText(Shell("PING " & TextBox_Direccion.Text.Trim & "-f -1 " & TextBox_TamañoMTU.Text) & vbCrLf)
            Dim exitCode As Integer
            Dim Pross As Process = New Process
            Dim processInfo As New ProcessStartInfo
            'processInfo = New ProcessStartInfo("cmd.exe", "/c PING " & TextBox_Direccion.Text.Trim & " -f -l " & TextBox_TamañoMTU.Text & "")

            processInfo.FileName = "cmd.exe"
            processInfo.Arguments = "/c getmac" '& TextBox_Direccion.Text.Trim & " -f -l " & TextBox_TamañoMTU.Text

            processInfo.CreateNoWindow = True
            processInfo.UseShellExecute = False

            ' *** Redirect the output ***
            processInfo.RedirectStandardError = True
            processInfo.RedirectStandardOutput = True
            'Pross.StartInfo.FileName = "cmd.exe"
            ' Pross.StartInfo.Arguments = "/C instruccón /y"
            'Pross.StartInfo.Arguments = "/C PING " & TextBox_Direccion.Text.Trim & " -f -1 " & TextBox_TamañoMTU.Text & "/y"
            Pross.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            'Pross.Start()
            Pross = Process.Start(processInfo)
            Pross.WaitForExit(10000)
            Dim output As String = Pross.StandardOutput.ReadToEnd
            Dim error1 As String = Pross.StandardError.ReadToEnd.ToString
            exitCode = Pross.ExitCode
            Pross.Close()

            'RichTextBox_Resultado.AppendText(output & vbCrLf)
            'RichTextBox_Resultado.AppendText(String.IsNullOrEmpty(output) & vbCrLf)
            'RichTextBox_Resultado.AppendText(String.IsNullOrEmpty(error1) & vbCrLf)

            msg_Consola(output & vbCrLf, False)
            msg_Consola(String.IsNullOrEmpty(output) & vbCrLf, False)
            msg_Consola(String.IsNullOrEmpty(error1) & vbCrLf, False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button_PropiedadesConexion_Click(sender As Object, e As EventArgs) Handles Button_PropiedadesConexion.Click
        Try
            'RichTextBox_Resultado.AppendText(Shell("PING " & TextBox_Direccion.Text.Trim & "-f -1 " & TextBox_TamañoMTU.Text) & vbCrLf)
            Dim exitCode As Integer
            Dim Pross As Process = New Process
            Dim processInfo As New ProcessStartInfo
            'processInfo = New ProcessStartInfo("cmd.exe", "/c PING " & TextBox_Direccion.Text.Trim & " -f -l " & TextBox_TamañoMTU.Text & "")

            processInfo.FileName = "cmd.exe"
            processInfo.Arguments = "/c netsh wlan show interfaces" '& TextBox_Direccion.Text.Trim & " -f -l " & TextBox_TamañoMTU.Text

            processInfo.CreateNoWindow = True
            processInfo.UseShellExecute = False

            ' *** Redirect the output ***
            processInfo.RedirectStandardError = True
            processInfo.RedirectStandardOutput = True
            'Pross.StartInfo.FileName = "cmd.exe"
            ' Pross.StartInfo.Arguments = "/C instruccón /y"
            'Pross.StartInfo.Arguments = "/C PING " & TextBox_Direccion.Text.Trim & " -f -1 " & TextBox_TamañoMTU.Text & "/y"
            Pross.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            'Pross.Start()
            Pross = Process.Start(processInfo)
            Pross.WaitForExit(10000)
            Dim output As String = Pross.StandardOutput.ReadToEnd
            Dim error1 As String = Pross.StandardError.ReadToEnd.ToString
            exitCode = Pross.ExitCode
            Pross.Close()

            'RichTextBox_Resultado.AppendText(output & vbCrLf)
            'RichTextBox_Resultado.AppendText(String.IsNullOrEmpty(output) & vbCrLf)
            'RichTextBox_Resultado.AppendText(String.IsNullOrEmpty(error1) & vbCrLf)

            msg_Consola(output & vbCrLf, False)
            msg_Consola(String.IsNullOrEmpty(output) & vbCrLf, False)
            msg_Consola(String.IsNullOrEmpty(error1) & vbCrLf, False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button_tracert.Click
        Try

            ctThread = New Threading.Thread(AddressOf tracert)
            AddHandler Event_Mensage, AddressOf msg
            ctThread.Start()
            Threading.Thread.Sleep(300)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Friend Sub tracert()

        Try

            msg("Inicia tracert ")
            Dim exitCode As Integer
            Dim Pross As Process = New Process
            Dim processInfo As New ProcessStartInfo
            processInfo.FileName = "cmd.exe"
            'processInfo.Arguments = "/k chcp 65001 & /c tracert " & TextBox_IP.Text.Trim
            processInfo.Arguments = "/c tracert " & TextBox_IP.Text.Trim
            processInfo.CreateNoWindow = True
            processInfo.UseShellExecute = False

            ' *** Redirect the output ***
            processInfo.RedirectStandardError = True
            processInfo.RedirectStandardOutput = True
            Pross.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            Pross = Process.Start(processInfo)
            Pross.WaitForExit(10000)

            Dim output As String = Pross.StandardOutput.ReadToEnd
            Dim error1 As String = Pross.StandardError.ReadToEnd.ToString
            exitCode = Pross.ExitCode
            Pross.Close()
            msg_Consola(output & vbCrLf, False)
            msg_Consola(String.IsNullOrEmpty(exitCode) & vbCrLf, False)
            msg_Consola(String.IsNullOrEmpty(error1) & vbCrLf, False)

        Catch ex As Exception
            'MsgBox(ex.Message)
            msg(ex.Message)
        End Try
        msg("Finaliza tracert ")

        Try
            'Dim exitCode As Integer
            'Dim Pross As Process = New Process
            'Dim processInfo As New ProcessStartInfo
            'processInfo.FileName = "cmd.exe"
            'processInfo.Arguments = "tracert " & TextBox_IP.Text.Trim & " /c"
            'processInfo.CreateNoWindow = True
            'processInfo.UseShellExecute = False
            '' *** Redirect the output ***
            'processInfo.RedirectStandardError = True
            'processInfo.RedirectStandardOutput = True

            'Pross.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            'Pross = Process.Start(processInfo)
            'Pross.WaitForExit(10000)

            'Dim outputReader As System.IO.StreamReader = Pross.StandardOutput
            'Dim line As String
            'While Not outputReader.EndOfStream
            '    line = outputReader.ReadLine()
            '    ' Procesar la línea aquí
            '    msg_Consola(line & vbCrLf, False)
            'End While

            'exitCode = Pross.ExitCode
            'Pross.Close()
        Catch ex As Exception
            msg(ex.Message)
        End Try

        Try
            'Dim processInfo As New ProcessStartInfo
            'processInfo.FileName = "cmd.exe"
            'processInfo.Arguments = "tracert " & TextBox_IP.Text.Trim & " /c"
            'processInfo.CreateNoWindow = True
            'processInfo.UseShellExecute = False

            '' *** Redirect the output ***
            'processInfo.RedirectStandardError = True
            'processInfo.RedirectStandardOutput = True

            'Dim process As New Process
            'process.StartInfo = processInfo
            'process.Start()
            'process.WaitForExit(10000)
            'Dim output As String = process.StandardOutput.ReadToEnd
            'Dim error1 As String = process.StandardError.ReadToEnd.ToString
            'Dim exitCode As Integer = process.ExitCode
            'process.Close()
            'msg_Consola(output & vbCrLf, False)
            'msg_Consola(String.IsNullOrEmpty(exitCode) & vbCrLf, False)
            'msg_Consola(String.IsNullOrEmpty(error1) & vbCrLf, False)

        Catch ex As Exception
            msg(ex.Message)
        End Try

        'Try
        '    Dim processInfo As New ProcessStartInfo
        '    processInfo.FileName = "cmd.exe"
        '    processInfo.Arguments = "/c tracert " & TextBox_IP.Text.Trim
        '    processInfo.CreateNoWindow = True
        '    processInfo.UseShellExecute = False

        '    ' *** Redirect the output ***
        '    processInfo.RedirectStandardError = True
        '    processInfo.RedirectStandardOutput = True

        '    Dim process As New Process
        '    process.StartInfo = processInfo
        '    process.Start()
        '    process.WaitForExit(10000)
        '    Dim output As String = process.StandardOutput.ReadToEnd
        '    Dim error1 As String = process.StandardError.ReadToEnd.ToString
        '    Dim exitCode As Integer = process.ExitCode
        '    process.Close()

        '    msg_Consola(output & vbCrLf, False)
        '    msg_Consola(error1 & vbCrLf, False)
        '    msg_Consola(exitCode & vbCrLf, False)

        'Catch ex As Exception
        '    msg(ex.Message)
        'End Try

        Try
            'Imports System.Diagnostics

            '' ...

            'Dim processInfo As New ProcessStartInfo
            'processInfo.FileName = "tracert"
            'processInfo.Arguments = "bing.com"
            'processInfo.UseShellExecute = False
            'processInfo.RedirectStandardOutput = True




            'Dim process As New Process
            'process.StartInfo = processInfo
            'process.Start()

            'Dim output As String = process.StandardOutput.ReadToEnd()

            ''Console.WriteLine(output)
            'msg_Consola(output & vbCrLf, False)


        Catch ex As Exception
            msg(ex.Message)
        End Try

        Try
            'Dim processInfo As New ProcessStartInfo
            'processInfo.FileName = "tracert"
            'processInfo.Arguments = "192.168.0.1" '"bing.com"
            'processInfo.UseShellExecute = False
            'processInfo.RedirectStandardOutput = True

            'Dim process As New Process
            'process.StartInfo = processInfo
            'process.Start()

            'Dim output As String = process.StandardOutput.ReadToEnd()
            'Console.WriteLine(output)
            'msg_Consola(output & vbCrLf, False)

        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub




    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button_DNS.Click
        Try
            RichTextBox1.Text = ""
            ctThread = New Threading.Thread(AddressOf GetDNS)
            AddHandler Event_Mensage, AddressOf msg
            ctThread.Start()
            Threading.Thread.Sleep(300)
            'GetDNS()
        Catch ex As Exception

        End Try
    End Sub

    Class RequestState
        Public host As IPHostEntry

        Public Sub New()
            host = Nothing
        End Sub
    End Class


    Friend Sub GetDNS()
        Try
            ' Create an instance of the RequestState class.
            Dim myRequestState As New RequestState()

            ' Begin an asynchronous request for information such as the host name, IP addresses, 
            ' or aliases for the specified URI.


            Dim Texto As String = TextBox_URL.Text.ToString

            Dim asyncResult As IAsyncResult = CType(Dns.BeginResolve(TextBox_URL.Text.ToString, AddressOf RespCallback, myRequestState), IAsyncResult)
            My.Application.DoEvents()
            ' Wait until asynchronous call completes.
            While asyncResult.IsCompleted <> True
                Threading.Thread.Sleep(100)
            End While

            'Console.WriteLine(("Host name : " + myRequestState.host.HostName))
            'Console.WriteLine(ControlChars.Cr + "IP address list : ")
            'RichTextBox1.Text = RichTextBox1.Text & vbCrLf & "Host name : " & myRequestState.host.HostName
            'RichTextBox1.Text = RichTextBox1.Text & vbCr & ControlChars.Cr + "IP address list : "

            Try

                msg_Consola(("Host name : " + myRequestState.host.HostName), False)
                msg_Consola(ControlChars.Cr + "IP address list : ", False)

            Catch ex As Exception
                msg(ex.Message)
            End Try



            Dim index As Integer
            For index = 0 To myRequestState.host.AddressList.Length - 1
                Console.WriteLine(myRequestState.host.AddressList(index))
                'RichTextBox1.Text = RichTextBox1.Text & vbCrLf & myRequestState.host.AddressList(index).ToString
                msg_Consola(myRequestState.host.AddressList(index).ToString & vbCr, False)
            Next index
            'Console.WriteLine(ControlChars.Cr + "Aliases : ")
            'RichTextBox1.Text = RichTextBox1.Text & vbCrLf & ControlChars.Cr + "Aliases : "
            msg_Consola(ControlChars.Cr + "Aliases : ", False)


            For index = 0 To myRequestState.host.Aliases.Length - 1
                'Console.WriteLine(myRequestState.host.Aliases(index))
                'RichTextBox1.Text = RichTextBox1.Text & vbCrLf & myRequestState.host.Aliases(index)
                msg_Consola(myRequestState.host.Aliases(index) & vbCr, False)

            Next index

        Catch e As Exception
            'Console.WriteLine("Exception caught!!!")
            'Console.WriteLine(("Source : " + e.Source))
            'Console.WriteLine(("Message : " + e.Message))
            'RichTextBox1.Text = RichTextBox1.Text & vbCrLf & "Exception caught!!!"
            'RichTextBox1.Text = RichTextBox1.Text & vbCrLf & "Source : " & e.Source
            'RichTextBox1.Text = RichTextBox1.Text & vbCrLf & "Message : " & e.Message
            msg("Exception caught!!!")
            msg(("Source : " + e.Source))
            msg(("Message : " + e.Message))

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

            'msg("ArgumentNullException caught!!!")
            'msg("Source : " + e.Source)
            'msg("Message : " + e.Message)

            'RichTextBox1.Text = RichTextBox1.Text & vbCrLf & "ArgumentNullException caught!!!"
            'RichTextBox1.Text = RichTextBox1.Text & vbCrLf & "Source : " & e.Source
            'RichTextBox1.Text = RichTextBox1.Text & vbCrLf & "Message : " & e.Message
        Catch e As Exception
            Console.WriteLine("Exception caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))


            'msg()
            'msg()
            'msg()
            'RichTextBox1.Text = RichTextBox1.Text & vbCrLf & "Exception caught!!!"
            'RichTextBox1.Text = RichTextBox1.Text & vbCrLf & "Source : " & e.Source
            'RichTextBox1.Text = RichTextBox1.Text & vbCrLf & "Message : " & e.Message
        End Try
    End Sub

    Private Sub Button_netstat_Click_1(sender As Object, e As EventArgs) Handles Button_netstat.Click
        'Try
        '    'RichTextBox_Resultado.AppendText(Shell("PING " & TextBox_Direccion.Text.Trim & "-f -1 " & TextBox_TamañoMTU.Text) & vbCrLf)
        '    Dim exitCode As Integer
        '    Dim Pross As Process = New Process
        '    Dim processInfo As New ProcessStartInfo
        '    'processInfo = New ProcessStartInfo("cmd.exe", "/c PING " & TextBox_Direccion.Text.Trim & " -f -l " & TextBox_TamañoMTU.Text & "")

        '    processInfo.FileName = "cmd.exe"
        '    'processInfo.Arguments = "/c NETSTAT 5 /y"
        '    processInfo.Arguments = "/c NETSTAT 5 "

        '    processInfo.CreateNoWindow = True
        '    processInfo.UseShellExecute = False

        '    ' *** Redirect the output ***
        '    processInfo.RedirectStandardError = True
        '    processInfo.RedirectStandardOutput = True
        '    'Pross.StartInfo.FileName = "cmd.exe"
        '    ' Pross.StartInfo.Arguments = "/C instruccón /y"
        '    'Pross.StartInfo.Arguments = "/C PING " & TextBox_Direccion.Text.Trim & " -f -1 " & TextBox_TamañoMTU.Text & "/y"
        '    Pross.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        '    'Pross.Start()
        '    Pross = Process.Start(processInfo)
        '    Pross.WaitForExit(10000)
        '    Dim output As String = Pross.StandardOutput.ReadToEnd
        '    Dim error1 As String = Pross.StandardError.ReadToEnd.ToString
        '    exitCode = Pross.ExitCode
        '    Pross.Close()

        '    'RichTextBox_Resultado.AppendText(output & vbCrLf)
        '    'RichTextBox_Resultado.AppendText(String.IsNullOrEmpty(output) & vbCrLf)
        '    'RichTextBox_Resultado.AppendText(String.IsNullOrEmpty(error1) & vbCrLf)

        '    msg_Consola(output & vbCrLf, False)
        '    msg_Consola(String.IsNullOrEmpty(output) & vbCrLf, False)
        '    msg_Consola(String.IsNullOrEmpty(error1) & vbCrLf, False)

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        Try
            RichTextBox1.Text = ""
            ctThread = New Threading.Thread(AddressOf netstat)
            AddHandler Event_Mensage, AddressOf msg
            ctThread.Start()
            Threading.Thread.Sleep(300)
            'GetDNS()
        Catch ex As Exception

        End Try
    End Sub

    Friend Sub netstat()

        Try
            'RichTextBox_Resultado.AppendText(Shell("PING " & TextBox_Direccion.Text.Trim & "-f -1 " & TextBox_TamañoMTU.Text) & vbCrLf)
            Dim exitCode As Integer
            Dim Pross As Process = New Process
            Dim processInfo As New ProcessStartInfo
            'processInfo = New ProcessStartInfo("cmd.exe", "/c PING " & TextBox_Direccion.Text.Trim & " -f -l " & TextBox_TamañoMTU.Text & "")

            processInfo.FileName = "cmd.exe"
            'processInfo.Arguments = "/c NETSTAT 5 /y"
            processInfo.Arguments = "/c NETSTAT -a"

            processInfo.CreateNoWindow = True
            processInfo.UseShellExecute = False

            ' *** Redirect the output ***
            processInfo.RedirectStandardError = True
            processInfo.RedirectStandardOutput = True
            'Pross.StartInfo.FileName = "cmd.exe"
            ' Pross.StartInfo.Arguments = "/C instruccón /y"
            'Pross.StartInfo.Arguments = "/C PING " & TextBox_Direccion.Text.Trim & " -f -1 " & TextBox_TamañoMTU.Text & "/y"
            Pross.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            'Pross.Start()
            Pross = Process.Start(processInfo)
            Pross.WaitForExit(10000)
            Dim output As String = Pross.StandardOutput.ReadToEnd
            Dim error1 As String = Pross.StandardError.ReadToEnd.ToString
            exitCode = Pross.ExitCode
            Pross.Close()

            'RichTextBox_Resultado.AppendText(output & vbCrLf)
            'RichTextBox_Resultado.AppendText(String.IsNullOrEmpty(output) & vbCrLf)
            'RichTextBox_Resultado.AppendText(String.IsNullOrEmpty(error1) & vbCrLf)

            msg_Consola(output & vbCrLf, False)
            msg_Consola(String.IsNullOrEmpty(output) & vbCrLf, False)
            msg_Consola(String.IsNullOrEmpty(error1) & vbCrLf, False)

        Catch ex As Exception
            msg(ex.Message)
        End Try

    End Sub


    Private Sub Button_ARP_Click(sender As Object, e As EventArgs) Handles Button_ARP.Click
        Try
            'RichTextBox_Resultado.AppendText(Shell("PING " & TextBox_Direccion.Text.Trim & "-f -1 " & TextBox_TamañoMTU.Text) & vbCrLf)
            Dim exitCode As Integer
            Dim Pross As Process = New Process
            Dim processInfo As New ProcessStartInfo
            'processInfo = New ProcessStartInfo("cmd.exe", "/c PING " & TextBox_Direccion.Text.Trim & " -f -l " & TextBox_TamañoMTU.Text & "")

            processInfo.FileName = "cmd.exe"
            'processInfo.Arguments = "/c arp -a /y"
            processInfo.Arguments = "/c arp -a"

            processInfo.CreateNoWindow = False
            processInfo.UseShellExecute = False

            ' *** Redirect the output ***
            processInfo.RedirectStandardError = True
            processInfo.RedirectStandardOutput = True
            'Pross.StartInfo.FileName = "cmd.exe"
            ' Pross.StartInfo.Arguments = "/C instruccón /y"
            'Pross.StartInfo.Arguments = "/C PING " & TextBox_Direccion.Text.Trim & " -f -1 " & TextBox_TamañoMTU.Text & "/y"
            Pross.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            'Pross.Start()
            Pross = Process.Start(processInfo)
            Pross.WaitForExit(10000)
            Dim output As String = Pross.StandardOutput.ReadToEnd
            Dim error1 As String = Pross.StandardError.ReadToEnd.ToString
            exitCode = Pross.ExitCode
            Pross.Close()

            'RichTextBox_Resultado.AppendText(output & vbCrLf)
            'RichTextBox_Resultado.AppendText(String.IsNullOrEmpty(output) & vbCrLf)
            'RichTextBox_Resultado.AppendText(String.IsNullOrEmpty(error1) & vbCrLf)


            msg_Consola(output & vbCrLf, False)
            msg_Consola(String.IsNullOrEmpty(output) & vbCrLf, False)
            msg_Consola(String.IsNullOrEmpty(error1) & vbCrLf, False)

            '            ARP -s inet_addr eth_addr [if_addr]
            'ARP -d inet_addr [if_addr]
            'ARP -a [inet_addr] [-N if_addr] [-v]

            '  -a            Pide los datos de protocolo actuales y muestra las
            '                entradas ARP actuales. Si se especifica inet_addr, solo se
            '                muestran las direcciones IP y física del equipo especificado.
            '                Si existe más de una interfaz de red que utilice ARP, se
            '                muestran las entradas de cada tabla ARP.
            '  -g            Igual que -a.
            '  -v            Muestra las entradas actuales de ARP en modo detallado.
            '                Se mostrarán todas las entradas no válidas y las entradas
            '                en la interfaz de bucle invertido.
            '  inet_addr     Especifica una dirección de Internet.
            '  -N if_addr    Muestra las entradas ARP para la interfaz de red especificada
            '                por if_addr.
            '  - d            Elimina el host especificado por inet_addr. inet_addr puede
            '                incluir el carácter comodín * (asterisco) para eliminar todos
            '                los host.
            '  - s            Agrega el host y asocia la dirección de Internet inet_addr
            '                con la dirección física eth_addr. La dirección física se
            '                indica como 6 bytes en formato hexadecimal, separados por
            '                guiones.La entrada es permanente.
            '  eth_addr      Especifica una dirección física.
            '  if_addr       Si está presente, especifica la dirección de Internet de la
            '                interfaz para la que se debe modificar la tabla de conversión
            '                de direcciones.Si no está presente, se utilizará la primera
            '                interfaz aplicable.
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button_Lookup_Click(sender As Object, e As EventArgs) Handles Button_Lookup.Click
        Try
            'RichTextBox_Resultado.AppendText(Shell("PING " & TextBox_Direccion.Text.Trim & "-f -1 " & TextBox_TamañoMTU.Text) & vbCrLf)
            Dim exitCode As Integer
            Dim Pross As Process = New Process
            Dim processInfo As New ProcessStartInfo
            'processInfo = New ProcessStartInfo("cmd.exe", "/c PING " & TextBox_Direccion.Text.Trim & " -f -l " & TextBox_TamañoMTU.Text & "")




            processInfo.FileName = "cmd.exe"
            processInfo.Arguments = "/c nslookup " & TextBox_URL.Text.Trim '& " -f -l " & TextBox_TamañoMTU.Text

            processInfo.CreateNoWindow = True
            processInfo.UseShellExecute = False

            ' *** Redirect the output ***
            processInfo.RedirectStandardError = True
            processInfo.RedirectStandardOutput = True
            'Pross.StartInfo.FileName = "cmd.exe"
            ' Pross.StartInfo.Arguments = "/C instruccón /y"
            'Pross.StartInfo.Arguments = "/C PING " & TextBox_Direccion.Text.Trim & " -f -1 " & TextBox_TamañoMTU.Text & "/y"
            Pross.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            'Pross.Start()
            Pross = Process.Start(processInfo)
            Pross.WaitForExit(10000)
            Dim output As String = Pross.StandardOutput.ReadToEnd
            Dim error1 As String = Pross.StandardError.ReadToEnd.ToString
            exitCode = Pross.ExitCode
            Pross.Close()

            'RichTextBox_Resultado.AppendText(output & vbCrLf)
            'RichTextBox_Resultado.AppendText(String.IsNullOrEmpty(output) & vbCrLf)
            'RichTextBox_Resultado.AppendText(String.IsNullOrEmpty(error1) & vbCrLf)

            msg_Consola(output & vbCrLf, False)
            msg_Consola(String.IsNullOrEmpty(output) & vbCrLf, False)
            msg_Consola(String.IsNullOrEmpty(error1) & vbCrLf, False)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button_netView_Click(sender As Object, e As EventArgs) Handles Button_netView.Click


        '        Net Accounts ->
        'Actualiza la base de datos y modifica las directivas de seguridad de contraseñas de los usuarios.

        'Es importante tener en cuenta dos cuestiones para la correcta ejecución de net accounts, son las siguientes.

        'Los requisitos de contraseña e inicio de sesión sólo se aplicarán si ya se se configuraron cuentas de usuario.
        'El servicio de Net Logon se debe ejecutar en todos los servidores del dominio que comprueben el inicio de sesión.
        'Net Logon se inicia automáticamente cuando Windows se inicia.

        'C:>net accounts
        'Ejecutando así se nos muestra la configuración actual de contraseñas, limitaciones de inicio de sesión e información de dominio.

        'net-accounts
        'net-accounts


        'C:>net accounts /forcelogoff:10
        'Si ejecutamos esto al llegar la hora en que un usuario puede iniciar sesión contará con 10 minutos antes de que esta se cierre obligadamente.

        'C:>net accounts /forcelogoff:no
        'Si ejecutamos este con la condición “no” no se forzará el cierre de sesión.

        'C:>net accounts /minpwlen:7
        'Establece la longitud mínima de contraseñas en 7 caracteres.

        'C:>net accounts /maxpwage:45
        'De esta forma obligamos a que como máximo cada 45 dias los usuarios se vean obligados a cambiar de contraseña ya que transcurrido este tiempo se les solicitará.

        'C:>net accounts /maxpwage:unlimited
        'Las contraseñas no caducarán nunca.

        'C:>net accounts /minpwage:10
        'Este establece el tiempo que ha de pasar como mínimo antes de que un usuario pueda cambiar su contraseña.

        'C:>net accounts /uniquepw:10
        'Esto guarda hasta las 10 últimas contraseñas utilizadas por el usuario impidiendo que repita la misma antes de realizar 10 cambios, como máximo se pueden almacenar 24

        'C:>net accounts /domain
        'Especifica que las operaciones que estamos realizando sean sobre un controlador de dominio
        'del dominio actual, necesario si trabajamos desde un cliente y muy importante.

        'cómo usar los comandos NET y su funcionalidad

        'Cómo usar los comandos net en Windows
        'Net Computer->
        'Agrega o quita equipos en una base de datos de dominios.
        'Nos va a permitir eliminar o añadir equipos al dominio
        'C:>net computer superpc /add
        'C:>net computer superpc /del

        'net-computer
        'net-computer
        'Net Config ->
        'Muestra lo servicios configurables que están en ejecución. También se pueden modificar

        'net-config
        'net-config
        'Nos muestra información bien de la estación de trabajo o del servidor

        'C:>net config workstation
        'Ejecutando este se muestra la de la estación de trabajo.

        'C:>net config server
        'Y con este la del servidor.

        'Net Config Server -> Muestra o cambia la configuración para el servicio servidor mientras este está en ejecución.
        'Net Config Workstation -> Muestra o cambia la configuración para el servicio local mientras este está en ejecución

        'Net Continue ->
        'Inicia de nuevo un servicio interrumpido.
        'Si estamos realizando tareas en el servidor puede que en algún momento pausemos un servicio de este para evitar problemas, la forma de volver a ponerlo en marcha es con net continue

        'C:>net continue fax
        'Volverá a poner en funcionamiento el servicio de fax

        'Net File -> Muestra los nombres de todos los archivos compartidos abiertos en un servidor.


        'Con este comando vemos los archivos abiertos en el servidor y además tiene una cosa que puede ser graciosa y es que podemos cerrar los archivos compartidos

        'C:>net file id /close

        'Net Group -> Agrega o elimina grupos globales en un dominio.


        'C:>net group
        'Nos muestra los grupos del servidor local

        'C:>net group nombregrupo /add
        'Añade un grupo al host local

        'C:>net group nombregrupo /add /domain
        'Añade un grupo a la base de datos el dominio

        'C:>net group nombregrupo usuario1 usuario2 usuario3 /add
        'Con esto conseguimos añadir a los usuarios “Usuario1″, “Usuario2″ y “Usuario3″ al grupo especificado en el host local

        'C:>net group nombregrupo usuario1 usuario2 usuario3 /add /domain
        'Con esto conseguimos añadir a los usuarios “Usuario1″, “Usuario2″ y “Usuario3″ al grupo especificado en la base de datos del dominio

        'C:>net group nombregrupo
        'Nos muestra a los usuarios que pertenecen al grupo

        'C:>net group nombregrupo /comment:”Comentarios del grupo”
        'Añade un comentario al grupo.

        'Net Help ->
        'Muestra la ayuda de un comando net.

        'El mejor de todos
        'C:>net help group
        'Nos mostrará la ayuda del comando solicitado

        'Net Helpmsg ->
        'Muestra la ayuda de un número de error.

        'Net Localgroup ->
        'Agrega o elimina grupos locales.

        'net-localgroup
        'net-localgroup
        'Net Name ->
        'Agrega o elimina un nombre para mensajes (alias).

        'Net Pause ->
        'Pause un servicio que se encuentra en ejecución.

        'C:>NET PAUSE servicio

        'Net Print ->
        'Muestra la cola de impresión.
        'C:>net print printservercola de impresion

        'Muestra el contenido de la cola de impresión en el printserver
        'C:>net print printserver #idtrabajo /hold

        'Pausa el trabajo
        'C:>net print printserver #idtrabajo /release

        'Reinicia el trabajo
        'C:>net print printserver #idtrabajo /delete

        'Elimina el trabajo
        'C:>net print printserver 12

        'Muestra información sobre el trabajo 12
        'C:>net print printserver 12 /hold

        'Pausa el trabajo 12
        'C:>net print printserver 12 /release

        'Reinicia el trabajo 12

        'Net Send ->
        'Envía mensajes de un ordenador a otro por red.

        'Net Session ->
        'Muestra una lista con las sesiones abiertas conectadas a un equipo local. También podemos cerrarlas.
        'C:>net session puesto1

        'Muestra la información de la sesión entre el host local y el puesto1
        'C:>net session puesto1 /delete

        'Termina la sesión con el puesto1
        'C:>net session /delete

        'Termin todas las sesiones iniciadas.

        'Net Share ->
        'Comparte carpetas o impresoras (recurso compartido) para ser utilizadas en red.
        'C:>net share

        'Nos muestra los recursos compartidos en el host local
        'C:>net share recurso_compartido

        'Net Start ->
        'Inicializa un servicio.
        'C:>net start

        'Lista todos los servicios en ejecución
        'C:>net start fax

        'Inicia el servicio de fax

        'Net Statistics ->
        'Muestra las estadísticas del servicio local o servidor.
        'C:>net statistics

        'Muestra los servicios con estadísticas disponibles
        'C:>net statistics workstation

        'Muestra las estadísticas del servicio de workstation (equipo local)
        'C:>net statistics server

        'Muestra las estadísticas para el server

        'Net Stop ->
        'Detiene un servicio que se encuentra en ejecución.
        'C:>net stop fax

        'Con esto detendremos el servicio de fax

        'Net Time -> Sincroniza el reloj de un equipo con el de otro equipo y/o servidor.

        'Cómo usar los comandos net en Windows
        'Net Use ->
        'Crea unidades de red conectando un recurso compartido en él.
        'C:>net use z: servidordocumentos

        'Conecta el recurso compartido documentos del servidor con la unidad Z:
        'C:>net use z: servidordocumentos /user:usuario@dominio.completo

        'Con esta ejecución conectaremos con el recurso compartido empleando un usuario distinto del que estamos usando. El nombre del dominio se especificará entero, por ejemplo si el dominio es empresa.local deberemos especificarlo así. Veamos otras variantes.
        'C:>net use z: servidordocumentos /user:dominiousuario
        'C:>net use z: servidordocumentos /user:dominio.completousuario

        'Estas dos últimas surtirán el mismo efecto que la citada anteriormente.
        'C:>net use z: servidordocumentos /smartcard

        'Para utilizar credenciales almacenados en una tarjeta inteligente
        'C:>net use z: servidordocumentos /savecred

        'Para indicar que deben guardarse el nombre de usuario y la contraseña. Si para realizar la conexión con el recurso compartido estos no se solicitan este se pasará por alto.
        'C:>net use z: servidordocumentos /delete

        'Cancela la conexión y elimina esta de la lista de conexiones persistentes
        'C:>net use z: servidordocumentos /persistent:yes

        'Guara las conexiones a medida que se establecen y las restaura en el siguiente inicio de sesión, esto si especificamos “yes” en caso de especificar “no” no se guardarán y en el siguiente inicio de sesión se restaurarán las existentes. Para eliminar una conexión de la lista deberemos utilizar el modificador /delete visto anteriormente.
        'Net User ->

        'Para la gestión de usuarios.
        'C:>net user

        'Muestra los usuarios del equipo local
        'C:>net user /domain

        'Muestra los usuarios del dominio
        'C:>net user Usuario1 password /add

        'Comando simple de recordar y que creará el Usuario1 y establecerá como contraseña password
        'C:>net user Usuario1 password /add /domain

        'Esta vez se creará al usuario Usuario1 con contraseña password en el dominio
        'C:>net user Usuario1 /delete

        'Este comando eliminará el usuario antes citado
        'C:>net user Usuario1 /delete /domain

        'Y con este se eliminará al usuario Usuario1 del dominio
        'C:>net user Usuario1 *

        'Solicita contraseña, la contraseña no se visualizara al escribirse
        'C:>net user Usuario1 /active:yes

        'Activa la cuenta de usuario Usuario1 y se le permite el inicio de sesión
        'C:>net user Usuario1 /active:yes /domain

        'Activa la cuenta de usuario Usuario1 en el dominio y se le permite el inicio de sesión
        'C:>net user Usuario1 /active:no

        'Desactiva la cuenta de usuario Usuario1 y se le deniega el inicio de sesión
        'C:>net user Usuario1 /active:no /domain

        'Desactiva la cuenta de usuario Usuario1 en el dominio y se le deniega el inicio de sesión
        'C:>net user Usuario1 /active:no

        'Desactiva la cuenta de usuario Usuario1 y se le deniega el inicio de sesión
        'C:>net user Usuario1 /comment:”Prueba de mensaje”

        'Añade una descripción al usuario
        'C:>net user Usuario1 /countrycode:850

        'usa el código de país o región del sistema operativo para usar los archivos de idioma especificados en la ayuda y mensajes de error para el usuario.
        'C:>net user Usuario1 /expires:01/02/08

        'Hará que la cuenta de Usuario1 expire el 2 de Enero de 2008 (ojito que va primero el mes…)
        'C:>net user Usuario1 /expires:never

        'Especifica que la cuenta de Usuario1 nunca expirará
        'C:>net user Usuario1 /fullname:”Usuario de sistemas”

        'Especifica el nombre completo para Usuario1 en Usuario de sistemas.
        'C:>net user Usuario1 /homedir:c:UsuariosUsuario1

        'Establece el directorio principal del usuario, la ruta debe existir y puede ser una ubicación de red. Recordemos que el usuario a de tener acceso a la ruta que especifiquemos aquí.
        'C:>net user Usuario1 /passwordchg:yes

        'Usuario1 puede cambiar su contraseña.
        'C:>net user Usuario1 /passwordchg:no

        'Usuario1 NO puede cambiar su contraseña.
        'C:>net user Usuario1 /passwordreq:yes

        'Especifica si la cuenta Usuario1 ha de tener contraseña, en este caso, si.
        'C:>net user Usuario1 /passwordreq:no

        'Especifica si la cuenta Usuario1 ha de tener contraseña, en este caso, no
        'C:>net user Usuario1 /logonpasswordchg:yes

        'Usuario1 tendrá que cambiar la contraseña en el siguiente inicio de sesión
        'C:>net user Usuario1 /logonpasswordchg:no

        'Usuario1 no tendrá que cambiar la contraseña en el siguiente inicio de sesión.
        'C:>net user Usuario1 /pprofilepath:rutadelperfil

        'Establece la ruta del perfil de inicio de sesión para Usuario1
        'C:>net user Usuario1 /scriptpath:rutadelscript

        'Establece la ruta del script que se ejecutará durante el inicio de sesión.
        'C:>net user Usuario1 /time:L-Mi,08:00-18:30;J-V,9am-6pm

        'Horas de inicio de sesión permitido para el Usuario1 que hemos establecido de la siguiente forma:
        'Podrá iniciar sesión…
        '…Lunes a Miércoles de 8 de la mañana a 18:30 de la tarde
        '…Jueves y Viernes de 9 de la mañana hasta las 6 de la tarde

        '   PUEDE QUE EN LUGAR DE /TIME: DEBA DEFINIRSE CON /TIMES: (CON “S”)
        'C:>net user Usuario1 /usercomment:”El Usuario1 es el empleado del mes de Enero”

        'Se añade un comentario a la descripción del Usuario1, entre comillas recordemos porque tiene espacios en blanco.
        'C:>net user Usuario1 /workstations:puesto1,puesto2

        'Establecemos los equipos en los que el Usuario1 puede iniciar sesión, si especificamos ” /workstations:* ” podrá iniciar la sesión en todos los equipos.
        'Net View ->
        'Muestra un listado de los recursos compartidos de un equipo.

        'C:>net view

        'Mostrará los equipos de la red
        'C:>net view puesto1

        'Muestra los recursos compartidos para el equipo “puesto1″
        'C:>net view /domain:dominio

        'Especifica que queremos listar los equipos contenidos en dominio, si no especificamos dominio se listarán los dominios
        'C:>net view /network:nw
        'Lista de servidores NetWare
        'C:>net view netwareserver /network:nw
        'Lista recursos en netwareserver
        'C:>net view /all
        'Muestra todos los recursos compartidos, incluso los $
        'C:>net view equipo1 /all
        'Muestra todos los recursos compartidos para equipo1, incluidos los $





        Try
            'RichTextBox_Resultado.AppendText(Shell("PING " & TextBox_Direccion.Text.Trim & "-f -1 " & TextBox_TamañoMTU.Text) & vbCrLf)
            Dim exitCode As Integer
            Dim Pross As Process = New Process
            Dim processInfo As New ProcessStartInfo
            'processInfo = New ProcessStartInfo("cmd.exe", "/c PING " & TextBox_Direccion.Text.Trim & " -f -l " & TextBox_TamañoMTU.Text & "")




            processInfo.FileName = "cmd.exe"
            processInfo.Arguments = "/c net view " & TextBox_URL.Text.Trim '& " -f -l " & TextBox_TamañoMTU.Text

            processInfo.CreateNoWindow = True
            processInfo.UseShellExecute = False

            ' *** Redirect the output ***
            processInfo.RedirectStandardError = True
            processInfo.RedirectStandardOutput = True
            'Pross.StartInfo.FileName = "cmd.exe"
            ' Pross.StartInfo.Arguments = "/C instruccón /y"
            'Pross.StartInfo.Arguments = "/C PING " & TextBox_Direccion.Text.Trim & " -f -1 " & TextBox_TamañoMTU.Text & "/y"
            Pross.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            'Pross.Start()
            Pross = Process.Start(processInfo)
            Pross.WaitForExit(10000)
            Dim output As String = Pross.StandardOutput.ReadToEnd
            Dim error1 As String = Pross.StandardError.ReadToEnd.ToString
            exitCode = Pross.ExitCode
            Pross.Close()

            'RichTextBox_Resultado.AppendText(output & vbCrLf)
            'RichTextBox_Resultado.AppendText(String.IsNullOrEmpty(output) & vbCrLf)
            'RichTextBox_Resultado.AppendText(String.IsNullOrEmpty(error1) & vbCrLf)

            msg_Consola(output & vbCrLf, False)
            msg_Consola(String.IsNullOrEmpty(output) & vbCrLf, False)
            msg_Consola(String.IsNullOrEmpty(error1) & vbCrLf, False)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Cleck()
        Dim adapters As System.Net.NetworkInformation.NetworkInterface() = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
        For Each adapter As System.Net.NetworkInformation.NetworkInterface In adapters
            Dim properties As System.Net.NetworkInformation.IPInterfaceProperties = adapter.GetIPProperties()
            If properties.GatewayAddresses.Count > 0 Then
                Dim ipv4Properties As System.Net.NetworkInformation.IPv4InterfaceProperties = properties.GetIPv4Properties()
                Dim newMetric As Integer = 10
                'ipv4Properties.Metric = newMetric
                'adapter.SetIPInterfaceProperties(properties)

            End If
        Next
    End Sub

    Private Sub Button_InterfazRed_Click(sender As Object, e As EventArgs) Handles Button_InterfazRed.Click
        Try

            Dim newIP As String = TextBox_IP.Text '"192.168.1.100"
            Dim newSubnetMask As String = TextBox_MascaraRed.Text '"255.255.255.0"
            Dim newGateway As String = TextBox_Gateway.Text '"192.168.1.1"

            'netsh interface ipv4 set address name="Ethernet" source=static address=<nueva dirección IP> mask=<máscara de subred> gateway=<puerta de enlace predeterminada>.
            'Asegúrate de reemplazar <nueva dirección IP>, <máscara de subred> y <puerta de enlace predeterminada> con los valores correspondientes.


            'RichTextBox_Resultado.AppendText(Shell("PING " & TextBox_Direccion.Text.Trim & "-f -1 " & TextBox_TamañoMTU.Text) & vbCrLf)
            Dim exitCode As Integer
            Dim Pross As Process = New Process
            Dim processInfo As New ProcessStartInfo
            'processInfo = New ProcessStartInfo("cmd.exe", "/c PING " & TextBox_Direccion.Text.Trim & " -f -l " & TextBox_TamañoMTU.Text & "")




            processInfo.FileName = "cmd.exe"
            processInfo.Arguments = "/c netsh interface ipv4 set address name=" & Chr(34) & "Ethernet" & Chr(34) & " source=static address=" & newIP & " mask=" & newSubnetMask & " gateway=" & newGateway & "" ' & TextBox_URL.Text.Trim '& " -f -l " & TextBox_TamañoMTU.Text

            processInfo.CreateNoWindow = False
            processInfo.UseShellExecute = False

            ' *** Redirect the output ***
            processInfo.RedirectStandardError = True
            processInfo.RedirectStandardOutput = True
            'Pross.StartInfo.FileName = "cmd.exe"
            ' Pross.StartInfo.Arguments = "/C instruccón /y"
            'Pross.StartInfo.Arguments = "/C PING " & TextBox_Direccion.Text.Trim & " -f -1 " & TextBox_TamañoMTU.Text & "/y"
            Pross.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            'Pross.Start()
            Pross = Process.Start(processInfo)
            Pross.WaitForExit(10000)
            Dim output As String = Pross.StandardOutput.ReadToEnd
            Dim error1 As String = Pross.StandardError.ReadToEnd.ToString
            exitCode = Pross.ExitCode
            Pross.Close()

            'RichTextBox_Resultado.AppendText(output & vbCrLf)
            'RichTextBox_Resultado.AppendText(String.IsNullOrEmpty(output) & vbCrLf)
            'RichTextBox_Resultado.AppendText(String.IsNullOrEmpty(error1) & vbCrLf)

            msg_Consola(output & vbCrLf, False)
            msg_Consola(String.IsNullOrEmpty(output) & vbCrLf, False)
            msg_Consola(String.IsNullOrEmpty(error1) & vbCrLf, False)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button_InterfazRed_VB.Click
        Try
            'Dim query As New System.Management.Instrumentation.SelectQuery("Win32_NetworkAdapterConfiguration")
            'Dim searcher As New System.Management.ManagementObjectSearcher(query)
            'Dim adapter As ManagementObject = Nothing

            'For Each obj As ManagementObject In searcher.Get()
            '    If obj("Caption").ToString().Contains("Ethernet") Then
            '        adapter = obj
            '        Exit For
            '    End If
            'Next

            'If adapter IsNot Nothing Then
            '    Dim newIP As String = "192.168.1.100"
            '    Dim newSubnetMask As String = "255.255.255.0"
            '    Dim newGateway As String = "192.168.1.1"

            '    Dim newIPArray As String() = {newIP}
            '    Dim newSubnetMaskArray As String() = {newSubnetMask}
            '    Dim newGatewayArray As String() = {newGateway}

            '    Dim inParams As ManagementBaseObject = adapter.GetMethodParameters("EnableStatic")
            '    inParams("IPAddress") = newIPArray
            '    inParams("SubnetMask") = newSubnetMaskArray

            '    Dim outParams As ManagementBaseObject = adapter.InvokeMethod("EnableStatic", inParams, Nothing)

            '    If CInt(outParams("ReturnValue")) = 0 Then
            '        MessageBox.Show("IP address changed successfully.")
            '    Else
            '        MessageBox.Show("Failed to change IP address.")
            '    End If
            'Else
            '    MessageBox.Show("Ethernet adapter not found.")
            'End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub Button_Ipconfig_Click(sender As Object, e As EventArgs) Handles Button_Ipconfig.Click
        Try

            msg("Inicia Ipconfig ")
            Dim exitCode As Integer
            Dim Pross As Process = New Process
            Dim processInfo As New ProcessStartInfo
            processInfo.FileName = "cmd.exe"
            processInfo.Arguments = "/c ipconfig" ' & TextBox_IP.Text.Trim
            processInfo.CreateNoWindow = False
            processInfo.UseShellExecute = False
            ' *** Redirect the output ***
            processInfo.RedirectStandardError = True
            processInfo.RedirectStandardOutput = True

            Pross.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            Pross = Process.Start(processInfo)
            Pross.WaitForExit(2000)
            Dim output As String = Pross.StandardOutput.ReadToEnd
            Dim error1 As String = Pross.StandardError.ReadToEnd.ToString
            exitCode = Pross.ExitCode
            Pross.Close()
            msg_Consola(output & vbCrLf, False)
            msg_Consola(String.IsNullOrEmpty(output) & vbCrLf, False)
            msg_Consola(String.IsNullOrEmpty(error1) & vbCrLf, False)
        Catch ex As Exception
            'MsgBox(ex.Message)
            msg(ex.Message)
        End Try
        msg("Finaliza tracert ")





        Try
            'Dim exitCode As Integer
            'Dim Pross As Process = New Process
            'Dim processInfo As New ProcessStartInfo
            'processInfo.FileName = "cmd.exe"
            'processInfo.Arguments = "/c ipconfig | find /c /v """""
            'processInfo.CreateNoWindow = True
            'processInfo.UseShellExecute = False
            'processInfo.RedirectStandardError = True
            'processInfo.RedirectStandardOutput = True

            ''Pross.StandardOutput.CurrentEncoding = System.Text.Encoding.UTF32

            'Pross.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            'Pross = Process.Start(processInfo)
            'Pross.WaitForExit(2000)

            'Dim output As String = String.Empty

            ''For indice As Integer = 0 To Pross.StandardOutput.Read - 1
            ''    output &= Pross.StandardOutput.ReadLine
            ''Next

            'output = Pross.StandardOutput.ReadToEnd
            ''Dim error1 As String = Pross.StandardError.EndOfStream
            'exitCode = Pross.ExitCode
            'Pross.Close()
            'msg_Consola(output & vbCrLf, False)
            ''    msg_Consola(String.IsNullOrEmpty(output) & vbCrLf, False)
            ''msg(String.IsNullOrEmpty(error1) & vbCrLf)

            'Dim lineCount As Integer = Integer.Parse(output.Trim())

            'For indice As Integer = 0 To Pross.StandardOutput.Read - 1
            '    'output &= Pross.StandardOutput.ReadLine
            '    msg(Pross.StandardOutput.ReadLine & vbCrLf)
            'Next

        Catch ex As Exception
            msg(ex.Message)
        End Try

        'Try
        '    Dim exitCode As Integer
        '    Dim Pross As Process = New Process
        '    Dim processInfo As New ProcessStartInfo
        '    processInfo.FileName = "cmd.exe"
        '    processInfo.Arguments = "/c ipconfig | find /c /v """""
        '    processInfo.CreateNoWindow = True
        '    processInfo.UseShellExecute = False
        '    processInfo.RedirectStandardError = True
        '    processInfo.RedirectStandardOutput = True

        '    Pross.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        '    Pross = Process.Start(processInfo)
        '    Pross.WaitForExit(2000)
        '    Dim output As String = Pross.StandardOutput.ReadToEnd
        '    Dim error1 As String = Pross.StandardError.ReadToEnd.ToString
        '    exitCode = Pross.ExitCode
        '    Pross.Close()

        '    msg_Consola(output & vbCrLf, False)

        '    Dim lineCount As Integer = Integer.Parse(output.Trim())
        'Catch ex As Exception
        '    msg(ex.Message)
        'End Try
    End Sub

    Private Sub Label_URL_Click(sender As Object, e As EventArgs) Handles Label_URL.Click

    End Sub

    Private Sub Label_IP_Click(sender As Object, e As EventArgs) Handles Label_IP.Click

    End Sub

    'Dim TramaObtenerConexiones As TramaObtenerConexiones
    'Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
    '    Try
    '        TramaObtenerConexiones = New System.Threading.Thread(AddressOf EscribirConexiones)
    '        TramaObtenerConexiones.Start()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Friend Sub EscribirConexiones()
    '    Try
    '        '          NETSTAT [-a] [-b] [-e] [-f] [-n] [-o] [-p proto] [-r] [-s] [-t] [-x] [-y] [interval]

    '        '-a            Muestra todas las conexiones y los puertos de escucha.
    '        '-b            Muestra el archivo ejecutable implicado en la creación de cada conexión o
    '        '              puerto de escucha. En algunos casos los archivos ejecutables conocidos hospedan
    '        '              varios componentes independientes y, en esos casos, se muestra la
    '        '              secuencia de componentes implicados en la creación de la conexión
    '        '              o el puerto de escucha. En este caso, el nombre del archivo ejecutable
    '        '              está entre corchetes ([]) en la parte inferior; en la parte superior se encuentra el componente al que se llamó,
    '        '              y así hasta que se llega al valor de TCP/IP. Ten en cuenta que esta opción
    '        '              puede llevar bastante tiempo; además, es posible que se produzca un error si no tienes suficientes
    '        '              permisos.
    '        '-e            Muestra las estadísticas de Ethernet. Este valor se puede combinar con la
    '        '              opción -s.
    '        '- f            Muestra los nombres de dominio completos (FQDN) de las direcciones
    '        '              externas.
    '        '-n            Muestra las direcciones y los números de puerto de forma numérica.
    '        '-o            Muestra el id. de cada proceso de propiedad asociado a la conexión.
    '        '-p proto      Muestra las conexiones del protocolo que especificó el valor proto; este valor proto
    '        '              puede ser: TCP, UDP, TCPv6 o UDPv6.  Si se usa con la opción -s
    '        '              para mostrar las estadísticas de cada protocolo, el valor proto será cualquiera de estos
    '        '              IP, IPv6, ICMP, ICMPv6, TCP, TCPv6, UDP o UDPv6.
    '        '-q            Muestra todas las conexiones, puertos de escucha y puertos
    '        '              TCP enlazados que no sean para la escucha. Estos últimos pueden (o no) asociarse
    '        '              a una conexión activa.
    '        '-r            Muestra la tabla de enrutamiento.
    '        '-s            Muestra las estadísticas por protocolo. De forma predeterminada, las estadísticas se muestran
    '        '              en función de los valores de IP, IPv6, ICMP, ICMPv6, TCP, TCPv6, UDP y UDPv6;
    '        '              la opción - p se puede usar para especificar un subconjunto del valor predeterminado.
    '        '-t            Muestra el estado de descarga de la conexión actual.
    '        '-x            Muestra conexiones, agentes de escucha y puntos de conexión compartidos de
    '        '               NetworkDirect.
    '        '-y            Muestra la plantilla de conexión TCP para todas las conexiones.
    '        '              No se puede combinar con otras opciones.
    '        'interval      Vuelve a mostrar las estadísticas seleccionadas y realiza pausas en intervalos de varios segundos
    '        '              entre cada visualización. Presiona CTRL+C para que dejen de mostrarse las
    '        '              estadísticas.Si omites esta opción, netstat imprimirá una sola vez
    '        '              la información de configuración.

    '        'RichTextBox_Resultado.AppendText(Shell("PING " & TextBox_Direccion.Text.Trim & "-f -1 " & TextBox_TamañoMTU.Text) & vbCrLf)
    '        Dim exitCode As Integer
    '        Dim Pross As Process = New Process
    '        Dim processInfo As New ProcessStartInfo
    '        'processInfo = New ProcessStartInfo("cmd.exe", "/c PING " & TextBox_Direccion.Text.Trim & " -f -l " & TextBox_TamañoMTU.Text & "")

    '        processInfo.FileName = "cmd.exe"
    '        processInfo.Arguments = "/c NETSTAT -n 2 /y"

    '        processInfo.CreateNoWindow = False
    '        processInfo.UseShellExecute = False

    '        ' *** Redirect the output ***
    '        processInfo.RedirectStandardError = True
    '        processInfo.RedirectStandardOutput = True
    '        'Pross.StartInfo.FileName = "cmd.exe"
    '        ' Pross.StartInfo.Arguments = "/C instruccón /y"
    '        'Pross.StartInfo.Arguments = "/C PING " & TextBox_Direccion.Text.Trim & " -f -1 " & TextBox_TamañoMTU.Text & "/y"
    '        Pross.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
    '        'Pross.Start()
    '        Pross = Process.Start(processInfo)
    '        Pross.WaitForExit(10000)
    '        Dim output As String = Pross.StandardOutput.ReadToEnd
    '        Dim error1 As String = Pross.StandardError.ReadToEnd.ToString
    '        exitCode = Pross.ExitCode
    '        Pross.Close()

    '        msg(output & vbCrLf)
    '        msg(String.IsNullOrEmpty(output) & vbCrLf)
    '        msg(String.IsNullOrEmpty(error1) & vbCrLf)
    '        'RichTextBox_Resultado.AppendText(output & vbCrLf)
    '        'RichTextBox_Resultado.AppendText(String.IsNullOrEmpty(output) & vbCrLf)
    '        'RichTextBox_Resultado.AppendText(String.IsNullOrEmpty(error1) & vbCrLf)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub






End Class


