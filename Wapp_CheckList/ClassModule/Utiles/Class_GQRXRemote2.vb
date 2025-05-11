Public Class Class_GQRXRemote2


    Friend TamañoBufferSalida As UInt32 = 1024
    Friend TamañoBufferEntrda As UInt32 = 1024

    Friend TramaEscucha As New System.Threading.Thread(AddressOf RecivirMensage)
    ' Definir el puerto y la dirección IP de GQRX
    Friend PORT As Integer = 7356
    Friend IP As String = "127.0.0.1"

    Dim IPServidor As System.Net.IPAddress

    ' Crear un objeto socket para la comunicación
    Friend socket_Cliente As System.Net.Sockets.Socket
    Dim DireccionServidor As System.Net.IPEndPoint '= New IPEndPoint(IPAddress.Parse(IP), PUERTO)
    Dim DireccionLocal As System.Net.IPEndPoint '= New IPEndPoint(IPAddress.Parse(IP), PUERTO)

    'Private m_Fifo As New FifoStream()
    Dim buffer As Byte() = New Byte(TamañoBufferSalida - 1) {}

    Friend Conectado As Boolean = False

    Friend TextBoxInstancia As RichTextBox
    Delegate Sub DelegateMensaje(ByVal TextBoxSelect As RichTextBox, ByVal MSG As String)
    Friend Sub TexBox_msg(ByVal TextBoxSelect As RichTextBox, ByVal Mensaje As String)
        If TextBoxSelect.InvokeRequired Then
            Dim d As New DelegateMensaje(AddressOf TexBox_msg)

            Call TextBoxInstancia.Invoke(d, New Object() {TextBoxSelect, Mensaje})
        Else
            Try
                'TextBoxSelect.Text &= Environment.NewLine & " " & Mensaje
                'TextBoxSelect.SelectionStart &= Mensaje
                TextBoxSelect.Text &= Mensaje
                TextBoxSelect.SelectionStart = TextBoxSelect.Text.Length
                TextBoxSelect.ScrollToCaret()
            Catch ex As Exception

            End Try


        End If
    End Sub



    ' Crear un constructor que se conecte a GQRX
    Public Sub New(ByRef TextBox_Instancia As RichTextBox)
        TextBoxInstancia = TextBox_Instancia
        'socket_Cliente = New System.Net.Sockets.Socket(IPServidor.AddressFamily, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp)
    End Sub

    ' Crear un constructor que se conecte a GQRX
    Public Sub Conection()
        'System.Net.IPAddress.Parse(IP).Address
        IPServidor = New Net.IPAddress(IP)

        ' Inicializar el socket con los parámetros adecuados 'socket_Cliente = New System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp)

        socket_Cliente = New System.Net.Sockets.Socket(IPServidor.AddressFamily, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp)
        socket_Cliente.SendBufferSize = TamañoBufferSalida
        socket_Cliente.ReceiveBufferSize = TamañoBufferEntrda
        'socket_Cliente.Connecte = System.Net.Sockets.ProtocolType.Tcp
        ' Conectarse a GQRX usando la dirección IP y el puerto

        DireccionServidor = New System.Net.IPEndPoint(System.Net.IPAddress.Parse(IP), PORT)
        socket_Cliente.Connect(DireccionServidor)
        DireccionLocal = socket_Cliente.LocalEndPoint ' New System.Net.IPEndPoint(System.Net.IPAddress.Parse(IP), PORT)


        ' Comprobar si la conexión fue exitosa
        If socket_Cliente.Connected Then
            DireccionLocal = socket_Cliente.LocalEndPoint
            TexBox_msg(TextBoxInstancia, "Conectado a GQRX" & vbCrLf)
            Console.WriteLine("Conectado a GQRX")
            Conectado = True
            TramaEscucha = New System.Threading.Thread(AddressOf RecivirMensage)
            TramaEscucha.Start()

        Else
            TexBox_msg(TextBoxInstancia, "No se pudo conectar a GQRX" & vbCrLf)
            Console.WriteLine("No se pudo conectar a GQRX")
        End If




    End Sub





    Friend Sub Desconectar()
        Try
            Conectado = False
            TramaEscucha.Abort()
        Catch ex As Exception

        End Try
        Try
            Close()
        Catch ex As Exception

        End Try


    End Sub


    ' Crear un método que envíe un comando a GQRX
    Public Sub SendCommand(command As String)
        ' Convertir el comando a un array de bytes
        Dim bytes As Byte() = System.Text.Encoding.ASCII.GetBytes(command)
        ' Enviar el comando al socket
        Dim bytesArray(TamañoBufferSalida - 1) As Byte
        If bytesArray.Length < bytes.Length Then
            ReDim bytesArray(bytes.Length - 1)
        End If

        For indice As UInteger = 0 To bytes.Length - 1
            bytesArray(indice) = bytes(indice)
        Next


        If socket_Cliente.Connected Then
            'socket_Cliente.Send(bytesArray)
            socket_Cliente.Send(bytes)
            ' Recibir la respuesta del socket
            Dim buffer As Byte() = New Byte(TamañoBufferSalida - 1) {}
            Dim received As Integer
            If socket_Cliente.Available Then
                received = socket_Cliente.Receive(buffer)
            End If

            ' Convertir la respuesta a una cadena
            Dim response As String = System.Text.Encoding.ASCII.GetString(buffer, 0, received)

            ' TextBox_Recive.
            ' Mostrar la respuesta en la consola
            TexBox_msg(TextBoxInstancia, response & vbCrLf)
            Console.WriteLine(response)
        Else
            Conectado = False

        End If

    End Sub

    ' Crear un método que cambie la frecuencia de GQRX
    Public Sub SetFrequency(frequency As Double)
        ' Crear el comando con el formato adecuado
        Dim command As String = "F " & frequency.ToString("0.000000")
        ' Enviar el comando a GQRX
        SendCommand(command)
    End Sub

    ' Crear un método que cierre la conexión con GQRX
    Public Sub Close()
        ' Enviar el comando de cierre a GQRX
        Conectado = False
        SendCommand("c")
        ' Cerrar el socket
        socket_Cliente.Close()
    End Sub



#Region ""


    Sub RecivirMensage() 'As String
        Dim response As String = ""
        Try
            Dim br As Byte() = New Byte(1024) {}
            'Dim PuntoExtremo As System.Net.IPEndPoint = New Net.IPEndPoint(System.Net.IPAddress.Parse(IP), PORT)
            'socket_Cliente.Bind(PuntoExtremo)
            'socket_Cliente.Receive()
            'socket_Cliente.Bind(New Net.IPEndPoint(Net.IPAddress.Any, PORT))

            While Conectado

                br = New Byte(TamañoBufferSalida - 1) {}
                Dim bytesRead As Integer = socket_Cliente.Receive(br)
                If bytesRead > 0 Then
                    response = System.Text.Encoding.ASCII.GetString(br, 0, buffer.Length)
                    TexBox_msg(TextBoxInstancia, response.Trim)
                End If

                If socket_Cliente.Available > 0 Then

                    ' buffer.Write(br, 0, br.Length)



                End If
                System.Threading.Thread.Sleep(50)
                If socket_Cliente.Connected = False Then
                    Conectado = False
                End If
                System.Threading.Thread.Sleep(50)
            End While

            'Dim buffer As Byte() = New Byte(TamañoBufferSalida - 1) {}
            'Dim received As Integer = socket.Receive(buffer)
            ' Convertir la respuesta a una cadena

        Catch ex As Exception

        End Try

        TexBox_msg(TextBoxInstancia, response)
    End Sub


#End Region



#Region ""

    Public Sub ReceiveFrom3()
        'Dim hostEntry As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
        'Dim endPoint As New System.Net.IPEndPoint(hostEntry.AddressList(0), 11000)
        Dim hostIP As System.Net.IPAddress = Net.IPAddress.Parse(IP)

        Dim endPoint As New System.Net.IPEndPoint(hostIP, PORT)

        Dim s As New System.Net.Sockets.Socket(endPoint.Address.AddressFamily, System.Net.Sockets.SocketType.Dgram, System.Net.Sockets.ProtocolType.Udp)
        s.SendBufferSize = TamañoBufferSalida
        s.ReceiveBufferSize = TamañoBufferEntrda

        ' Creates an IPEndPoint to capture the identity of the sending host.
        Dim sender As New System.Net.IPEndPoint(System.Net.IPAddress.Any, 0)
        Dim senderRemote As System.Net.EndPoint = CType(sender, System.Net.EndPoint)

        ' Binding is required with ReceiveFrom calls.
        s.Bind(endPoint)

        Dim msg() As Byte = New [Byte](255) {}
        Console.WriteLine("Waiting to receive datagrams from client...")
        ' This call blocks. 
        s.ReceiveFrom(msg, msg.Length, System.Net.Sockets.SocketFlags.None, senderRemote)
        s.Close()

    End Sub


    Private Sub Button1_Click()
        Try
            Dim clientSocket As New System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp)
            clientSocket.Connect("127.0.0.1", 7356)

            Dim serverResponse(1024) As Byte
            Dim received As Integer = clientSocket.Receive(serverResponse)
            Dim response As String = System.Text.Encoding.ASCII.GetString(serverResponse, 0, received)
            Console.WriteLine(response)

            While Conectado
                Dim message As String = Console.ReadLine()
                Dim data As Byte() = System.Text.Encoding.ASCII.GetBytes(message)
                clientSocket.Send(data)

                Dim serverResponse_1(1024) As Byte
                Dim received_1 As Integer = clientSocket.Receive(serverResponse_1)
                Dim response_1 As String = System.Text.Encoding.ASCII.GetString(serverResponse_1, 0, received_1)
                Console.WriteLine(response_1)

            End While
        Catch ex As Exception

        End Try
    End Sub
#End Region

End Class


'Friend TamañoBufferSalida As UInt32 = 1024
'Friend TramaEscucha As New System.Threading.Thread(AddressOf RecivirMensage)
'Friend PORT As Integer = 7356
'Friend IP As String = "127.0.0.1"
'Dim IPServidor As System.Net.IPAddress
'Friend socket_Cliente As System.Net.Sockets.Socket
'Dim buffer As Byte() = New Byte(TamañoBufferSalida - 1) {}
'Friend Conectado As Boolean = False
'Public Sub New(ByRef TextBox_Instancia As RichTextBox)
'    TextBoxInstancia = TextBox_Instancia
'End Sub
'Public Sub Conection()
'    IPServidor = New Net.IPAddress(IP)
'    socket_Cliente = New System.Net.Sockets.Socket(IPServidor.AddressFamily, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp)
'    socket_Cliente.Connect(System.Net.IPAddress.Parse(IP), PORT)
'    If socket_Cliente.Connected Then
'        TexBox_msg(TextBoxInstancia, "Conectado a GQRX" & vbCrLf)
'        Console.WriteLine("Conectado a GQRX")
'    Else
'        TexBox_msg(TextBoxInstancia, "No se pudo conectar a GQRX" & vbCrLf)
'        Console.WriteLine("No se pudo conectar a GQRX")
'    End If
'    Conectado = True
'    TramaEscucha.Start()
'End Sub
'Friend Sub Desconectar()
'    Try
'        Conectado = False
'        TramaEscucha.Abort()
'    Catch ex As Exception
'    End Try
'    Try
'        Close()
'    Catch ex As Exception
'    End Try
'End Sub
'Public Sub SendCommand(command As String)
'    Dim bytes As Byte() = System.Text.Encoding.ASCII.GetBytes(command & vbLf)
'    Dim bytesArray(TamañoBufferSalida - 1) As Byte
'    If bytesArray.Length < bytes.Length Then
'        ReDim bytesArray(bytes.Length - 1)
'    End If
'    For indice As UInteger = 0 To bytes.Length - 1
'        bytesArray(indice) = bytes(indice)
'    Next
'    socket_Cliente.Send(bytesArray)
'    Dim buffer As Byte() = New Byte(TamañoBufferSalida - 1) {}
'    Dim received As Integer = socket_Cliente.Receive(buffer)
'    Dim response As String = System.Text.Encoding.ASCII.GetString(buffer, 0, received)
'    TexBox_msg(TextBoxInstancia, response & vbCrLf)
'    Console.WriteLine(response)
'End Sub
'Public Sub Close()
'    ' Enviar el comando de cierre a GQRX
'    SendCommand("c")
'    ' Cerrar el socket
'    socket_Cliente.Close()
'End Sub
'#Region ""
'Function RecivirMensage() As String
'    Dim response As String = ""
'    Try
'        Dim br As Byte()
'        While Conectado
'            If socket_Cliente.Available > 0 Then
'                socket_Cliente.Receive(br)
'            End If
'            br = New Byte(TamañoBufferSalida - 1) {}
'            response = System.Text.Encoding.ASCII.GetString(br, 0, buffer.Length)
'            TexBox_msg(TextBoxInstancia, response.Trim)
'        End While
'    Catch ex As Exception
'    End Try
'    TexBox_msg(TextBoxInstancia, response)
'End Function
'#End Region






'Public Sub SendCommand(command As String)
'    Dim bytes As Byte() = System.Text.Encoding.ASCII.GetBytes(command)
'    Dim bytesArray(TamañoBufferSalida - 1) As Byte
'    If bytesArray.Length < bytes.Length Then
'        ReDim bytesArray(bytes.Length - 1)
'    End If
'    For indice As UInteger = 0 To bytes.Length - 1
'        bytesArray(indice) = bytes(indice)
'    Next
'    If socket_Cliente.Connected Then
'        socket_Cliente.Send(bytes)
'        Dim buffer As Byte() = New Byte(TamañoBufferSalida - 1) {}
'        Dim received As Integer
'        If socket_Cliente.Available Then
'            received = socket_Cliente.Receive(buffer)
'        End If
'        Dim response As String = System.Text.Encoding.ASCII.GetString(buffer, 0, received)
'        TexBox_msg(TextBoxInstancia, response & vbCrLf)
'        Console.WriteLine(response)
'    Else
'        Conectado = False

'    End If
'End Sub













'Public Sub Conection()
'    IPServidor = New Net.IPAddress(IP)
'    socket_Cliente = New System.Net.Sockets.Socket(IPServidor.AddressFamily, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp)
'    socket_Cliente.SendBufferSize = TamañoBufferSalida
'    socket_Cliente.ReceiveBufferSize = TamañoBufferEntrda
'    DireccionServidor = New System.Net.IPEndPoint(System.Net.IPAddress.Parse(IP), PORT)
'    socket_Cliente.Connect(DireccionServidor)
'    DireccionLocal = New System.Net.IPEndPoint(System.Net.IPAddress.Parse(IP), PORT)
'    If socket_Cliente.Connected Then
'        DireccionLocal = socket_Cliente.LocalEndPoint
'        TexBox_msg(TextBoxInstancia, "Conectado a GQRX" & vbCrLf)
'    Else
'        TexBox_msg(TextBoxInstancia, "No se pudo conectar a GQRX" & vbCrLf)
'    End If
'    Conectado = True
'    TramaEscucha.Start()
'End Sub

'Friend Sub Desconectar()
'    Try
'        Conectado = False
'        TramaEscucha.Abort()
'    Catch ex As Exception

'    End Try
'    Try
'        Close()
'    Catch ex As Exception

'    End Try
'End Sub

'Public Sub SendCommand(command As String)
'    Dim bytes As Byte() = System.Text.Encoding.ASCII.GetBytes(command & vbLf)
'    Dim bytesArray(TamañoBufferSalida - 1) As Byte
'    If bytesArray.Length < bytes.Length Then
'        ReDim bytesArray(bytes.Length - 1)
'    End If
'    For indice As UInteger = 0 To bytes.Length - 1
'        bytesArray(indice) = bytes(indice)
'    Next
'    If socket_Cliente.Connected Then
'        socket_Cliente.Send(bytesArray)
'        Dim buffer As Byte() = New Byte(TamañoBufferSalida - 1) {}
'        Dim received As Integer = socket_Cliente.Receive(buffer)
'        Dim response As String = System.Text.Encoding.ASCII.GetString(buffer, 0, received)
'        TexBox_msg(TextBoxInstancia, response & vbCrLf)
'    Else
'        Conectado = False
'    End If
'End Sub
'Public Sub Close()
'    ' Enviar el comando de cierre a GQRX
'    Conectado = False
'    SendCommand("c")
'    ' Cerrar el socket
'    socket_Cliente.Close()
'End Sub
'Function RecivirMensage() As String
'    Dim response As String = ""
'    Try
'        Dim br As Byte()
'        While Conectado
'            If socket_Cliente.Available > 0 Then
'                socket_Cliente.Receive(br)
'                br = New Byte(TamañoBufferSalida - 1) {}
'                response = System.Text.Encoding.ASCII.GetString(br, 0, Buffer.Length)
'                TexBox_msg(TextBoxInstancia, response.Trim)

'            End If
'            System.Threading.Thread.Sleep(50)
'        End While
'    Catch ex As Exception

'    End Try
'    TexBox_msg(TextBoxInstancia, response)
'End Function