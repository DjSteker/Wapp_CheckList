
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading


Public Class Form_UDP_V1

    Private Sub Form_UDP_V1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            'Dim ipHostInfo As IPHostEntry = Dns.Resolve(Dns.GetHostName())
            'TextBox_LocalIp.Text = ipHostInfo.HostName


            'Dim ipHostInfo2 As IPHostEntry = Dns.Resolve("host.contoso.com")
            'Dim ipAddress As IPAddress = ipHostInfo.AddressList(0)



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

#Region "Variables"
    'Variable de objeto que contiene el socket
    Shared SocketLocal1 As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
    'Variable que contiene al hilo encargado de recibir los datos
    Dim HiloRecibir As Thread

    Friend Class TramasEnvios
        Friend HiloEnvio As Thread
        Friend DirecciónDestino As IPEndPoint
        Friend Mensaje As String
        Event Boton_Ver(ByVal ModeloReferencia As String)


        'Private Sub funcionMassiva(SocketPoint As IPEndPoint)

        '    Try

        '        'For indicePuto As Integer = 0 To 10



        '        '    Dim DatosBytes As Byte() = Encoding.Default.GetBytes(txtMensaje.Text & Chr(0))
        '        '    Try
        '        '        'Envía los datos
        '        '        ElSocket.SendTo(DatosBytes, DatosBytes.Length, SocketFlags.None, SocketPoint) 'DirecciónDestino)
        '        '    Catch ex As Exception
        '        '        MsgBox(ex.Message)
        '        '    End Try

        '        '    Thread.Sleep(CInt(TextBox_MasivoPausa.Text))
        '        '    EstadoForm = "Enviados " & indicePuto & "/100"
        '        '    Label_EstadoForm.Invoke(New EventHandler(AddressOf ActualizarTextoLabelForm))

        '        'Next

        '        ' txtMensaje.Clear() 'Limpia txtMensaje
        '        '  txtMensaje.Focus() 'Mueve el foco hacia txtMensaje
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try
        'End Sub

    End Class

    Dim Tramas_str As New List(Of TramasEnvios)
    'Variable que indica si el programa se está cerrando
    Dim Saliendo As Boolean = False
    'Variables temporales para almacenar los datos recibidos
    Dim DireccIP As String, ContenidoMensaje As String
    Dim EstadoForm As String


#End Region

    Private Sub Button_Conectar_Click(sender As System.Object, e As System.EventArgs) Handles Button_Conectar.Click
        Dim lep As IPEndPoint
        Try
            If Button_Conectar.Text <> "Conectado" Then


                'TextBox_LocalIp.Text
                'TextBox_LocalPuerto.Text
                Dim Saliendo As Boolean = False
                If TextBox_LocalIp.Text.ToString.Trim <> "" Then
                    ' Dim broadcast As IPAddress = IPAddress.Parse(TextBox_LocalIp.Text.Trim)
                    Dim lipa As IPHostEntry = Dns.Resolve(TextBox_LocalIp.Text.Trim)
                    TextBox_LocalIp.Text = lipa.AddressList(0).ToString
                    lep = New IPEndPoint(lipa.AddressList(0), TextBox_LocalPuerto.Text)
                    SocketLocal1 = New Socket(lep.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp)
                Else
                    '  Dim lipa As IPHostEntry = AddressFamily.InterNetwork.ToString
                    lep = New IPEndPoint(IPAddress.Any, TextBox_LocalPuerto.Text)
                    SocketLocal1 = New Socket(lep.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp)
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            If Button_Conectar.Text <> "Conectado" Then
                '   If ElSocket.Poll(100, SelectMode.SelectRead) = False Then
                '  ElSocket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
                '      ElSocket = New Socket(AddressFamily.InterNetwork, SocketType.Unknown, ProtocolType.Udp)
                'End If

                'Separamos el puerto 200145 para usarlo en nuestra aplicación
                If TextBox_LocalIp.Text.ToString.Trim = "" Then
                    SocketLocal1.Bind(New IPEndPoint(IPAddress.Any, TextBox_LocalPuerto.Text.Trim))
                Else
                    SocketLocal1.Bind(New IPEndPoint(lep.Address.AddressFamily, TextBox_LocalPuerto.Text.Trim))
                End If

                'Habilitamos la opción Broadcast para el socket
                SocketLocal1.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, True)

                HiloRecibir = New Thread(AddressOf RecibirDatos) 'Crea el hilo
                HiloRecibir.Name = "LecturaSocket"
                SyncLock Me
                    HiloRecibir.Start() 'Inicia el hilo
                End SyncLock
            End If
            Button_Conectar.Text = "Conectado"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub RecibirDatos()
        'Mientras el inidicador de salida no sea verdadero
        Try


            Do Until Saliendo

                'Variable para obtener la IP de la máquína remitente
                Dim LaIPRemota As New IPEndPoint(IPAddress.Any, 0)

                'Variable para almacenar la IP temporalmente
                Dim IPRecibida As EndPoint = CType(LaIPRemota, EndPoint)

                'Dim RecibirBytes(255) As Byte 'Buffer
                Dim RecibirBytes(1415) As Byte
                Dim Datos As String = "" 'Texto a mostrar

                Try
                    'Recibe los datos
                    SocketLocal1.ReceiveFrom(RecibirBytes, RecibirBytes.Length, SocketFlags.None, IPRecibida)


                    'Los convierte y lo guarda en la variable Datos
                    '    Datos = Encoding.Default.GetString(RecibirBytes)
                    Datos = Encoding.Default.GetString(RecibirBytes)
                    'Dim ClienteIpPotr As String = ElSocket.RemoteEndPoint.ToString

                    ' Dim c_direccion As IPEndPoint = CType(IPRecibida, IPEndPoint)
                    LaIPRemota = CType(IPRecibida, IPEndPoint)




                    'Dim Hilo_Cliente As New TramasEnvios
                    'Hilo_Cliente.HiloEnvio = New Thread(AddressOf funcionMassiva)


                    ''  Dim DirecciónDestino As IPEndPoint
                    'If TextBox_DestIp.Text.ToString.Trim = "" Then
                    '    Hilo_Cliente.DirecciónDestino = New IPEndPoint(IPAddress.Broadcast, TextBox_DestPuerto.Text.Trim)
                    'Else
                    '    Hilo_Cliente.DirecciónDestino = New IPEndPoint(IPAddress.Parse(TextBox_DestIp.Text), TextBox_DestPuerto.Text.Trim)
                    'End If


                    'Tramas_str.Add(Hilo_Cliente)


                    'Hilo_Cliente.HiloEnvio.Start(Hilo_Cliente.DirecciónDestino) 'Inicia el hilo


                    Class_ProcesaLammadas.Procesa_Hola(RecibirBytes, LaIPRemota) 'LaIPRemota.Address.ToString, TextBox_LocalPuerto.Text.Trim)



                Catch ex As SocketException
                    If ex.ErrorCode = 10040 Then 'Datos muy largos
                        Datos &= "[truncado]" 'Añade la cadena "[truncado]" al texto recibido
                    Else
                        'Muestra el mensaje de error
                        MsgBox("Error '" & ex.ErrorCode.ToString & "' " & ex.Message, MsgBoxStyle.Critical, "Error al recibir datos")
                    End If
                End Try

                'Convierte el tipo EndPoint a IPEndPoint con sus respectivas variables
                LaIPRemota = CType(IPRecibida, IPEndPoint)
                'Guarda los datos en variables temporales
                DireccIP = LaIPRemota.Address.ToString & ":" & LaIPRemota.Port & vbCr
                ContenidoMensaje = Datos.ToString

                'Invoca al evento que mostrará los datos en txtDatosRecibidos
                txtDatosRecibidos.Invoke(New EventHandler(AddressOf ActualizarTextoMensaje))
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button_Desconectar_Click(sender As System.Object, e As System.EventArgs) Handles Button_Desconectar.Click
        Try
            SocketLocal1.Close()

            Dim Saliendo As Boolean = True

            For IndiceTramas As Integer = 0 To Tramas_str.Count - 1

                SyncLock Me
                    ' Call Tramas_str.Item(IndiceTramas).HiloEnvio.Join()
                    Call Tramas_str.Item(IndiceTramas).HiloEnvio.Abort()
                End SyncLock

            Next
            'ElSocket.Close()


            ' SyncLock Me
            ' Call HiloRecibir.Join()


            'Thread.ResetAbor(HiloRecibir)

            '   Try
            SyncLock Me
                ' Call HiloRecibir.Join()
                HiloRecibir.Abort()
            End SyncLock
            Thread.Sleep(100)
            HiloRecibir.Abort()


            'While HiloRecibir.IsAlive 'Or hilo2.IsAlive
            '    Thread.Sleep(10)
            'End While


            '   ElSocket.Close()
            Dim ContadorEspera As Int16 = 0
            While HiloRecibir.IsAlive
                Thread.Sleep(50)
                If ContadorEspera > 10 Then
                    ContadorEspera = ContadorEspera + 1
                Else
                    Exit While
                End If
            End While
            Button_Conectar.Text = "Conectar"


        Catch ex As ThreadInterruptedException
            MsgBox(ex.Message)
        Catch ex As ThreadAbortException
            MsgBox(ex.Message)
        Catch ex As ThreadStateException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtMensaje_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMensaje.TextChanged
        'Cuando txtMensaje esté vacío, deshabilitar el botón de envío.
        cmdEnviar.Enabled = (txtMensaje.TextLength > 0)
    End Sub

    Private Sub cmdEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnviar.Click

        Try



            'Contiene la dirección de Broadcast y el puerto utilizado
            Dim DirecciónDestino As IPEndPoint
            DirecciónDestino = New IPEndPoint(IPAddress.Broadcast, TextBox_DestPuerto.Text.Trim)
            'If TextBox_DestIp.Text.ToString.Trim = "" Then
            '    DirecciónDestino = New IPEndPoint(IPAddress.Broadcast, TextBox_DestPuerto.Text.Trim)
            'Else
            '    DirecciónDestino = New IPEndPoint(TextBox_DestIp.Text, TextBox_DestPuerto.Text.Trim)
            'End If

            'Buffer que guardará los datos hasta que se envíen
            Dim DatosBytes As Byte() = Encoding.Default.GetBytes(txtMensaje.Text & Chr(0))

            Try
                'Envía los datos
                SocketLocal1.SendTo(DatosBytes, DatosBytes.Length, SocketFlags.None, DirecciónDestino)


                Dim HiloMasivo_COM As New TramasEnvios
                HiloMasivo_COM.HiloEnvio = New Thread(AddressOf funcionEnvio)

                '  Dim DirecciónDestino As IPEndPoint
                If TextBox_DestIp.Text.ToString.Trim = "" Then
                    HiloMasivo_COM.DirecciónDestino = New IPEndPoint(IPAddress.Broadcast, TextBox_DestPuerto.Text.Trim)
                Else
                    HiloMasivo_COM.DirecciónDestino = New IPEndPoint(TextBox_DestIp.Text, TextBox_DestPuerto.Text.Trim)
                End If

                Tramas_str.Add(HiloMasivo_COM)

                HiloMasivo_COM.HiloEnvio.Start(HiloMasivo_COM.DirecciónDestino) 'Inicia el hilo


            Catch ex1 As ThreadStartException
                MsgBox(ex1.Message)
            Catch ex1 As ThreadAbortException
                MsgBox(ex1.Message)
            Catch ex1 As TimeoutException
                MsgBox(ex1.Message)

            End Try



            ' txtMensaje.Clear() 'Limpia txtMensaje
            '  txtMensaje.Focus() 'Mueve el foco hacia txtMensaje
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

#Region "Cerrar y liberar recursos"

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Saliendo = True 'Indica que se está saliendo del programa de lectura del SOCKET
            'ElSocket.Close() 'Cierra el socket
            ''  SyncLock Me
            'Thread.Sleep(100)
            'MsgBox(HiloRecibir.IsThreadPoolThread)
            'Call HiloRecibir.Join()
            'Call HiloRecibir.Abort() 'Termina el proceso del hilo
            ''  End SyncLock

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Form1_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Try

            Saliendo = True 'Indica que se está saliendo del programa

            Thread.Sleep(100)
            MsgBox(HiloRecibir.IsThreadPoolThread)

            For IndiceTramas As Integer = 0 To Tramas_str.Count - 1
                Try
                    SyncLock Me
                        ' Call Tramas_str.Item(IndiceTramas).HiloEnvio.Join()
                        Call Tramas_str.Item(IndiceTramas).HiloEnvio.Abort()
                    End SyncLock
                Catch ex As Exception
                    Label_EstadoForm.Text = ex.Message
                End Try
            Next



            SyncLock Me
                '  Call HiloRecibir.Join()
                Call HiloRecibir.Abort()
            End SyncLock

            SocketLocal1.Close()


            ' Button_Conectar.Text = "Conectar"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

    Private Sub txtDatosRecibidos_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDatosRecibidos.TextChanged
        'Mostrar siempre la última línea del TextBox.
        txtDatosRecibidos.SelectionStart = txtDatosRecibidos.TextLength
        txtDatosRecibidos.ScrollToCaret()
    End Sub

    Protected Sub ActualizarTextoMensaje(ByVal sender As Object, ByVal e As System.EventArgs)
        'Si txtDatosRecibidos está vacío:
        If txtDatosRecibidos.TextLength = 0 Then
            txtDatosRecibidos.Text = DireccIP & ">" & ContenidoMensaje
        Else
            'de lo contrario insertar primero un salto de línea y luego los datos.
            txtDatosRecibidos.Text &= vbCrLf & DireccIP & ">" & ContenidoMensaje
        End If
    End Sub

    Protected Sub ActualizarTextoLabelForm(ByVal sender As Object, ByVal e As System.EventArgs)
        'Si txtDatosRecibidos está vacío:
        Label_EstadoForm.Text = EstadoForm
    End Sub

#Region "Cosas Amigas"

    Friend Sub Enviar_Mensage(ByVal Mensage As String)
        Try
            'Contiene la dirección de Broadcast y el puerto utilizado
            Dim DirecciónDestino As IPEndPoint
            If TextBox_DestIp.Text.ToString.Trim = "" Then
                DirecciónDestino = New IPEndPoint(IPAddress.Broadcast, TextBox_DestPuerto.Text.Trim)
            Else
                DirecciónDestino = New IPEndPoint(TextBox_DestIp.Text, TextBox_DestPuerto.Text.Trim)
            End If

            'Buffer que guardará los datos hasta que se envíen
            Dim DatosBytes As Byte() = Encoding.Default.GetBytes(Mensage)
            Try
                'Envía los datos
                SocketLocal1.SendTo(DatosBytes, DatosBytes.Length, SocketFlags.None, DirecciónDestino)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            ' txtMensaje.Clear() 'Limpia txtMensaje
            '  txtMensaje.Focus() 'Mueve el foco hacia txtMensaje
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Shared Sub Enviar_Mensage2(ByVal Mensage As String, ByRef c_IPEndPoint As IPEndPoint) ', ByVal DestIp As String, ByVal DestPuerto As String)
        Try
            'Contiene la dirección de Broadcast y el puerto utilizado
            Dim DirecciónDestino As IPEndPoint = c_IPEndPoint
            'If DestIp = "" Then
            '    DirecciónDestino = New IPEndPoint(IPAddress.Any, DestPuerto)
            'Else
            '    DirecciónDestino = New IPEndPoint(DestIp, DestPuerto)
            'End If

            'Buffer que guardará los datos hasta que se envíen
            Dim DatosBytes As Byte() = Encoding.Default.GetBytes(Mensage)

            'Envía los datos
            SocketLocal1.SendTo(DatosBytes, DatosBytes.Length, SocketFlags.None, DirecciónDestino)
            '   aaaaaaaaaaaaaa()

            ' txtMensaje.Clear() 'Limpia txtMensaje
            '  txtMensaje.Focus() 'Mueve el foco hacia txtMensaje
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        'Try
        '    Dim HiloMasivo_COM As New TramasEnvios
        '    HiloMasivo_COM.HiloMasivo = New Thread(AddressOf funcionEnvio)

        '    '  Dim DirecciónDestino As IPEndPoint
        '    If TextBox_DestIp.Text.ToString.Trim = "" Then
        '        HiloMasivo_COM.DirecciónDestino = New IPEndPoint(IPAddress.Broadcast, TextBox_DestPuerto.Text.Trim)
        '    Else
        '        HiloMasivo_COM.DirecciónDestino = New IPEndPoint(TextBox_DestIp.Text, TextBox_DestPuerto.Text.Trim)
        '    End If

        '    Tramas_str.Add(HiloMasivo_COM)

        '    HiloMasivo_COM.HiloMasivo.Start(HiloMasivo_COM.DirecciónDestino) 'Inicia el hilo

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try


    End Sub

    Shared Sub Enviar_Mensage3(ByVal Mensaje As String, ByRef c_IPEndPoint As IPEndPoint) ', ByVal DestIp As String, ByVal DestPuerto As String)

        Try

            Dim s As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)

            Dim sendbuf As Byte() = Encoding.UTF8.GetBytes(Mensaje)

            s.SendTo(sendbuf, c_IPEndPoint)

            Console.WriteLine("Message enviado a address=" & c_IPEndPoint.Address.ToString & ":" & c_IPEndPoint.Port)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

#End Region

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        txtDatosRecibidos.Clear()
    End Sub

    Private Sub Button_BuscarServerCS16_Click(sender As System.Object, e As System.EventArgs) Handles Button_BuscarServerCS16.Click
        Try
            'Contiene la dirección de Broadcast y el puerto utilizado
            Dim DirecciónDestino As IPEndPoint

            DirecciónDestino = New IPEndPoint(IPAddress.Broadcast, TextBox_DestPuerto.Text.Trim)

            'Buffer que guardará los datos hasta que se envíen
            'Dim DatosBytes As Byte() = Encoding.Default.GetBytes("ÿÿÿÿTSource Engine Query" & Chr(0))
            Dim DatosBytes As Byte() = Encoding.Default.GetBytes("1234" & Chr(0))
            Try
                'Envía los datos
                SocketLocal1.SendTo(DatosBytes, DatosBytes.Length, SocketFlags.Peek, DirecciónDestino)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information)
            End Try


            ' txtMensaje.Clear() 'Limpia txtMensaje
            '  txtMensaje.Focus() 'Mueve el foco hacia txtMensaje
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button_BuscarConexionesLAN_Click(sender As Object, e As EventArgs) Handles Button_BuscarConexionesLAN.Click
        Try
            Dim udpClient As New UdpClient()
            udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, True)
            udpClient.Client.Bind(New IPEndPoint(IPAddress.Any, 0))
            udpClient.Ttl = 100
            udpClient.Client.ReceiveTimeout = 5000
            Dim endPoint As New IPEndPoint(IPAddress.Broadcast, 11000)

            Dim message As String = "Hello, world!"
            Dim data As Byte() = Encoding.ASCII.GetBytes(message)

            udpClient.Send(data, data.Length, endPoint)

            Dim receiveBytes As Byte() = New Byte() {} ' udpClient.Receive(endPoint)
            Try
                receiveBytes = udpClient.Receive(endPoint)
            Catch ex As Exception

            End Try
            Dim receiveMessage As String = Encoding.ASCII.GetString(receiveBytes)

            Console.WriteLine("Received: {0}", receiveMessage)


            Dim interfaces As System.Net.NetworkInformation.NetworkInterface() = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()

            For Each adapter As System.Net.NetworkInformation.NetworkInterface In interfaces
                Console.WriteLine("Name: {0}", adapter.Name)
                Console.WriteLine("Description: {0}", adapter.Description)
                Console.WriteLine("Status: {0}", adapter.OperationalStatus)
                Console.WriteLine("MAC Address: {0}", adapter.GetPhysicalAddress())
                Console.WriteLine()

                Dim properties As System.Net.NetworkInformation.IPInterfaceProperties = adapter.GetIPProperties()
                For Each address As System.Net.NetworkInformation.IPAddressInformation In properties.UnicastAddresses
                    Console.WriteLine("IP Address: {0}", address.Address)
                    Console.WriteLine("Subnet Mask: {0}", address.Address.ScopeId) 'address.IPv4Mask)
                    Console.WriteLine()
                Next
            Next


        Catch ex As Exception

        End Try
    End Sub



    Private Sub Button_EnviarPrivado_Click(sender As System.Object, e As System.EventArgs) Handles Button_EnviarPrivado.Click
        Try
            Dim HiloEnvio_COM As New TramasEnvios
            HiloEnvio_COM.HiloEnvio = New Thread(AddressOf funcionEnvio)

            '  Dim DirecciónDestino As IPEndPoint
            If TextBox_DestIp.Text.ToString.Trim = "" Then
                HiloEnvio_COM.DirecciónDestino = New IPEndPoint(IPAddress.Broadcast, TextBox_DestPuerto.Text.Trim)
            Else
                HiloEnvio_COM.DirecciónDestino = New IPEndPoint(TextBox_DestIp.Text, TextBox_DestPuerto.Text.Trim)
            End If

            Tramas_str.Add(HiloEnvio_COM)

            HiloEnvio_COM.HiloEnvio.Start(HiloEnvio_COM.DirecciónDestino) 'Inicia el hilo

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button_Masivo_Click(sender As System.Object, e As System.EventArgs) Handles Button_Masivo.Click
        '  Dim HiloMasivo_a = New Thread(AddressOf funcionMassiva) 'Crea el hilo
        Try
            Dim HiloMasivo_COM As New TramasEnvios
            HiloMasivo_COM.HiloEnvio = New Thread(AddressOf funcionMassiva)


            '  Dim DirecciónDestino As IPEndPoint
            If TextBox_DestIp.Text.ToString.Trim = "" Then
                HiloMasivo_COM.DirecciónDestino = New IPEndPoint(IPAddress.Broadcast, TextBox_DestPuerto.Text.Trim)
            Else
                HiloMasivo_COM.DirecciónDestino = New IPEndPoint(IPAddress.Parse(TextBox_DestIp.Text), TextBox_DestPuerto.Text.Trim)
            End If


            Tramas_str.Add(HiloMasivo_COM)


            HiloMasivo_COM.HiloEnvio.Start(HiloMasivo_COM.DirecciónDestino) 'Inicia el hilo
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

#Region "Envios "

    Friend Sub AbrirEnvio(ByVal Cliente As TramasEnvios)
        Try
            Dim HiloMasivo_COM As New TramasEnvios
            HiloMasivo_COM.HiloEnvio = New Thread(AddressOf funcionEnvioRespuesta)

            '  aaaa()
            '  Dim DirecciónDestino As IPEndPoint

            Cliente.HiloEnvio = New Thread(AddressOf funcionEnvioRespuesta)


            Tramas_str.Add(HiloMasivo_COM)


            HiloMasivo_COM.HiloEnvio.Start(Cliente) 'Inicia el hilo
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Friend Sub funcionEnvioRespuesta(ByVal Cliente As TramasEnvios)
        Try

            Dim SocketPrivado As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
            Dim sendbuf As Byte() = Encoding.UTF8.GetBytes(Cliente.Mensaje)
            SocketPrivado.SendTo(sendbuf, Cliente.DirecciónDestino)

            'Console.WriteLine("Message sent to the broadcast address")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub funcionEnvio(SocketPoint As IPEndPoint)

        Try



            'Contiene la dirección de Broadcast y el puerto utilizado
            'Dim DirecciónDestino As IPEndPoint
            'If TextBox_DestIp.Text.ToString.Trim = "" Then
            '    DirecciónDestino = New IPEndPoint(IPAddress.Broadcast, TextBox_DestPuerto.Text.Trim)
            'Else
            '    DirecciónDestino = New IPEndPoint(TextBox_DestIp.Text, TextBox_DestPuerto.Text.Trim)
            'End If

            'Buffer que guardará los datos hasta que se envíen
            Dim DatosBytes As Byte() = Encoding.UTF8.GetBytes(txtMensaje.Text & Chr(0))
            Try
                'Envía los datos
                ' ElSocket.SendTo(DatosBytes, DatosBytes.Length, SocketFlags.None, SocketPoint) 'DirecciónDestino)
                SocketLocal1.SendTo(DatosBytes, DatosBytes.Length, SocketFlags.None, SocketPoint) 'DirecciónDestino)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            '   Thread.Sleep(CInt(TextBox_MasivoPausa.Text))
            EstadoForm = "Enviados 1/1"
            Label_EstadoForm.Invoke(New EventHandler(AddressOf ActualizarTextoLabelForm))



            ' txtMensaje.Clear() 'Limpia txtMensaje
            '  txtMensaje.Focus() 'Mueve el foco hacia txtMensaje
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub funcionMassiva(SocketPoint As IPEndPoint)

        Try

            Dim SocketPrivado As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
            Dim sendbuf As Byte() = Encoding.UTF8.GetBytes(txtMensaje.Text & Chr(0))


            For indicePuto As Integer = 0 To 10


                'Contiene la dirección de Broadcast y el puerto utilizado
                'Dim DirecciónDestino As IPEndPoint
                'If TextBox_DestIp.Text.ToString.Trim = "" Then
                '    DirecciónDestino = New IPEndPoint(IPAddress.Broadcast, TextBox_DestPuerto.Text.Trim)
                'Else
                '    DirecciónDestino = New IPEndPoint(TextBox_DestIp.Text, TextBox_DestPuerto.Text.Trim)
                'End If

                'Buffer que guardará los datos hasta que se envíen






                'Dim DatosBytes As Byte() = Encoding.Default.GetBytes(txtMensaje.Text & Chr(0))
                'Try
                '    'Envía los datos
                '    ElSocket.SendTo(DatosBytes, DatosBytes.Length, SocketFlags.None, SocketPoint) 'DirecciónDestino)
                'Catch ex As Exception
                '    MsgBox(ex.Message)
                'End Try







                SocketPrivado.SendTo(sendbuf, SocketPoint)

                Thread.Sleep(CInt(TextBox_MasivoPausa.Text))
                EstadoForm = "Enviados " & indicePuto & "/10"
                Label_EstadoForm.Invoke(New EventHandler(AddressOf ActualizarTextoLabelForm))

            Next

            ' txtMensaje.Clear() 'Limpia txtMensaje
            '  txtMensaje.Focus() 'Mueve el foco hacia txtMensaje
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

    Private Sub Button_Enviar3_Click(sender As System.Object, e As System.EventArgs) Handles Button_Enviar3.Click
        Try
            Dim hostEntry As IPHostEntry = Dns.GetHostEntry(IPAddress.Parse(TextBox_DestIp.Text.Trim))
            Dim endPoint As New IPEndPoint(hostEntry.AddressList(0), TextBox_DestPuerto.Text.Trim)

            Dim s As New Socket(endPoint.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp)

            Dim msg As Byte() = Encoding.ASCII.GetBytes(txtMensaje.Text.Trim)
            Console.WriteLine("Sending data.")
            ' This call blocks. 
            s.SendTo(msg, SocketFlags.None, endPoint)
            s.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Label_LocalIp_Click(sender As Object, e As EventArgs) Handles Label_LocalIp.Click
        Try
            Dim nombrePC As String = Dns.GetHostName()
            Dim entradasIP As Net.IPHostEntry = Dns.GetHostEntry(nombrePC)
            'Dim Direcciones() As String = New String() {}
            'Dim Direcciones As Net.IPAddress
            'Direcciones = entradasIP.AddressList
            Dim direccionIP As String = entradasIP.AddressList(0).ToString()
            TextBox_LocalIp.Text = direccionIP

            ComboBox_ListaIP.Items.Clear()
            For index = 0 To entradasIP.AddressList.Length - 1
                ComboBox_ListaIP.Items.Add(entradasIP.AddressList(index).ToString())
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label_LocalPuerto_Click(sender As Object, e As EventArgs) Handles Label_LocalPuerto.Click

    End Sub

    Private Sub Label_DestIp_Click(sender As Object, e As EventArgs) Handles Label_DestIp.Click
        Try

            Dim endpoint As IPEndPoint = New IPEndPoint(System.Net.IPAddress.Parse(TextBox_DNSip.Text), CInt(TextBox_DNSport.Text))

            Dim lookup = Main_DNS()


            'Dim endpoint As var = New IPEndPoint(NameServer.GooglePublicDns)
            'Dim lookup As var = New LookupClient(endpoint)
            'Dim hostEntry As IPHostEntry = lookup.GetHostEntry(hostOrIp)
            'Console.WriteLine(hostEntry.HostName)
            'For Each ip In hostEntry.AddressList
            '    Console.WriteLine(ip)
            'Next
            'For Each alias In hostEntry.Aliases
            '    Console.WriteLine(alias)
            'Next



            Dim nombrePC As String = Dns.GetHostName()
            Dim entradasIP As Net.IPHostEntry = Dns.GetHostEntry(TextBox_Host.Text.ToString)
            'Dim Direcciones() As String = New String() {}
            'Dim Direcciones As Net.IPAddress
            'Direcciones = entradasIP.AddressList
            Dim direccionIP As String = entradasIP.AddressList(0).ToString()
            TextBox_DestIp.Text = direccionIP

            ComboBox_ListaIP.Items.Clear()
            For index = 0 To entradasIP.AddressList.Length - 1
                ComboBox_DestIp.Items.Add(entradasIP.AddressList(index).ToString())
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ObtenerIpDns()
        Try
            Dim domainName As String = "www.example.com"
            Dim ipAddresses As IPAddress() = Dns.GetHostAddresses(domainName)
            If ipAddresses.Length > 0 Then
                Dim ipAddress As IPAddress = ipAddresses(0)
                Console.WriteLine($"IP Address of {domainName}: {ipAddress}")
            Else
                Console.WriteLine($"No IP address found for {domainName}")
            End If
        Catch ex As Exception

        End Try
        Try
            Dim dnsServerAddress As IPAddress = IPAddress.Parse("8.8.8.8") ' Por ejemplo, utiliza el servidor DNS de Google
            Dim dnsServerPort As Integer = 53 ' Puerto estándar para DNS
            Dim dnsSocket As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
            dnsSocket.Connect(dnsServerAddress, dnsServerPort)
            ' Envía una consulta DNS al servidor y procesa la respuesta...

        Catch ex As Exception

        End Try
    End Sub



#Region "Consulta DNS"


    Friend Function OtenerDireccion()
        Dim domainName As String = TextBox_Host.Text
        Dim dnsServerAddress As IPAddress = IPAddress.Parse(TextBox_DNSip.Text) ' Por ejemplo, utiliza el servidor DNS de Google

        Try
            Dim dnsResult As IPHostEntry = Dns.GetHostEntry(domainName)

            ' Obtén las direcciones IP asociadas al nombre de dominio
            For Each ipAddress As IPAddress In dnsResult.AddressList
                Console.WriteLine($"Dirección IP para {domainName}: {ipAddress}")
            Next
        Catch ex As Exception
            Console.WriteLine($"Error al obtener registros A para {domainName}: {ex.Message}")
        End Try
        Return domainName
    End Function



    Structure DnsARecord
        Public Name As String
        Public IpAddress As IPAddress
    End Structure

    Friend Function Main_DNS()
        Dim domainName As String = TextBox_Host.Text
        Dim dnsServerAddress As IPAddress = IPAddress.Parse(TextBox_DNSip.Text) ' Por ejemplo, utiliza el servidor DNS de Google
        Dim dnsServerPort As Integer = 53 ' Puerto estándar para DNS

        ' Crea un socket UDP
        Dim dnsSocket As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)

        ' Construye la consulta DNS
        Dim queryBytes As Byte() = BuildDnsQuery(domainName)

        ' Envía la consulta al servidor DNS
        dnsSocket.SendTo(queryBytes, New IPEndPoint(dnsServerAddress, dnsServerPort))

        ' Recibe la respuesta del servidor DNS
        'Dim responseBuffer(1024) As Byte
        Dim responseBuffer(11) As Byte
        Dim bytesRead As Integer = dnsSocket.Receive(responseBuffer)
        'Dim ReadBytes As Byte() = dnsSocket.Receive(responseBuffer)

        ' Procesa la respuesta (analiza los registros DNS, etc.)
        ' Aquí deberías implementar la lógica para extraer la dirección IP del resultado








        ' Lista para almacenar los registros A
        Dim aRecords As New List(Of DnsARecord)()

        ' Analiza la respuesta DNS
        ' Aquí debes implementar la lógica para extraer los registros A
        ' Puedes usar BitConverter para leer los bytes y extraer la dirección IP
        Dim IPtexto As String = String.Empty
        Dim cuenta As Int16 = 0
        ' Ejemplo de extracción de registros A (simplificado)

        For Each rr In responseBuffer
            'If rr.Type = DnsRecordType.A Then
            Dim ipAddressBytes = rr ' Supongamos que aquí obtienes los bytes de la dirección IP
            '    Dim ipAddress = New IPAddress(ipAddressBytes)
            '    Dim aRecord As New DnsARecord With {.Name = rr.Name, .IpAddress = ipAddress}
            '    aRecords.Add(aRecord)
            'End If
            IPtexto &= rr
            cuenta += 1
            If cuenta > 3 Then
                cuenta = 0
                Dim nuevoRegistro As New DnsARecord()
                nuevoRegistro.Name = TextBox_Host.Text
                nuevoRegistro.IpAddress = IPAddress.Parse(IPtexto)
                aRecords.Add(nuevoRegistro)
                IPtexto = ""
            Else
                IPtexto &= "."
            End If
        Next

        TextBox_DestIp.Text = aRecords(0).IpAddress.ToString  '.Address.ToString


        ' Ahora tienes una lista de registros A con nombres de dominio e IP
        ' Puedes acceder a la dirección IP según tus necesidades
        For Each record In aRecords
            Console.WriteLine($"Nombre de dominio: {record.Name}, Dirección IP: {record.IpAddress}")
        Next














        ' Cierra el socket
        dnsSocket.Close()

        Return bytesRead
    End Function

    Private Function BuildDnsQuery(domainName As String) As Byte()
        ' Construye una consulta DNS de tipo A (IPv4)
        ' El formato general de una consulta DNS es el siguiente:
        '   - Cabecera (12 bytes)
        '   - Preguntas (variable)
        '   - Otras secciones (Respuestas, Autoridad, Adicional) (variable)

        ' Aquí se muestra una implementación simplificada:
        Dim queryBytes As New List(Of Byte)()

        ' ID de consulta (2 bytes, se puede generar aleatoriamente)
        queryBytes.AddRange(BitConverter.GetBytes(CUShort(1234)))

        ' Flags (2 bytes, por ejemplo, 0x0100 para una consulta estándar)
        queryBytes.AddRange(BitConverter.GetBytes(CUShort(&H100)))

        ' Conteo de preguntas (2 bytes, en este caso, 1 pregunta)
        queryBytes.AddRange(BitConverter.GetBytes(CUShort(1)))

        ' Conteo de respuestas, autoridad y adicional (2 bytes cada uno, todos 0 para una consulta)
        queryBytes.AddRange(BitConverter.GetBytes(CUShort(0)))
        queryBytes.AddRange(BitConverter.GetBytes(CUShort(0)))
        queryBytes.AddRange(BitConverter.GetBytes(CUShort(0)))

        ' Nombre de dominio (convertido a etiquetas y longitud)
        Dim domainParts As String() = domainName.Split("."c)
        For Each part In domainParts
            queryBytes.Add(CByte(part.Length))
            queryBytes.AddRange(Encoding.ASCII.GetBytes(part))
        Next

        ' Tipo de registro (2 bytes, 1 para A)
        queryBytes.AddRange(BitConverter.GetBytes(CUShort(1)))

        ' Clase (2 bytes, 1 para Internet)
        queryBytes.AddRange(BitConverter.GetBytes(CUShort(1)))

        ' Retorna los bytes de la consulta
        Return queryBytes.ToArray()
        'Return New Byte() {}
    End Function



#End Region

    Private Sub Label_Host_Click(sender As Object, e As EventArgs) Handles Label_Host.Click
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label_DestPuerto_Click(sender As Object, e As EventArgs) Handles Label_DestPuerto.Click
        Try
            TextBox_DestPuerto.Text = "7355"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox_ListaIP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_ListaIP.SelectedIndexChanged
        Try
            TextBox_LocalIp.Text = ComboBox_ListaIP.Text
        Catch ex As Exception

        End Try
    End Sub

    Dim DNSlistPos As Int16 = 0
    Private Sub Label_DNS_Click(sender As Object, e As EventArgs) Handles Label_DNS.Click
        Try
            '94.247.43.254 (ns8.he.de)
            '194.36.144.87 (ns29.de)
            '51.158.108.203 (ns1.fr)
            '94.247.43.254 (ns7.de)

            Select Case DNSlistPos
                Case 0
                    TextBox_DNSip.Text = "63.231.92.27"
                Case 1
                    TextBox_DNSip.Text = "94.247.43.254"
                Case 2
                    TextBox_DNSip.Text = "194.36.144.87"
                Case 3
                    TextBox_DNSip.Text = "51.158.108.203"
                Case 4
                    TextBox_DNSip.Text = "94.247.43.254"
                Case 5
                    TextBox_DNSip.Text = "103.1.206.179"
                Case 6
                    TextBox_DNSip.Text = "137.220.55.93"
                Case 7
                    TextBox_DNSip.Text = "94.247.43.254"
                Case 8
                    TextBox_DNSip.Text = "80.152.203.134"
                Case 9
                    TextBox_DNSip.Text = "65.21.1.106"
                Case 10
                    TextBox_DNSip.Text = "172.104.162.222"
                Case 11
                    TextBox_DNSip.Text = "63.231.92.27"
                Case 12
                    TextBox_DNSip.Text = "35.211.96.150"
                Case 13
                    TextBox_DNSip.Text = "162.243.19.47"
                Case Else
                    TextBox_DNSip.Text = ""
                    DNSlistPos = -1
            End Select

            DNSlistPos += 1

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_SocketApi_Click(sender As Object, e As EventArgs) Handles Button_SocketApi.Click

        Try

            Dim socket As New System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp)
            Dim entradasIP As Net.IPHostEntry = System.Net.Dns.GetHostEntry("google-translate1.p.rapidapi.com")
            Dim endPoint As New System.Net.IPEndPoint(System.Net.IPAddress.Parse(entradasIP.AddressList(0).ToString), 443)
            socket.Connect(endPoint)
            Dim encodedParams As New System.Collections.Specialized.NameValueCollection()
            encodedParams.Set("q", "Hola, mundo!")
            encodedParams.Set("target", "en")
            encodedParams.Set("source", "es")
            Dim requestBuilder As New System.Text.StringBuilder()
            requestBuilder.AppendLine("POST /language/translate/v2 HTTP/1.1")
            requestBuilder.AppendLine("Host: google-translate1.p.rapidapi.com")
            requestBuilder.AppendLine("Content-Type: application/x-www-form-urlencoded")
            requestBuilder.AppendLine("X-RapidAPI-Key: ec6d742f48msh8156a600cee8642p19d558jsn3486fdb6fbcc")
            requestBuilder.AppendLine("Content-Length: " & encodedParams.ToString().Length)
            requestBuilder.AppendLine()
            requestBuilder.Append(encodedParams.ToString())
            Dim requestBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(requestBuilder.ToString())
            socket.Send(requestBytes)
            Dim memoryStream As New System.IO.MemoryStream()
            Dim buffer(1024) As Byte
            While socket.Available > 0
                ' Leer los datos del socket y escribirlos en el MemoryStream
                Dim bytesRead As Integer = socket.Receive(buffer, 0, buffer.Length, System.Net.Sockets.SocketFlags.None)
                memoryStream.Write(buffer, 0, bytesRead)
            End While
            Dim responseBytes As Byte() = memoryStream.ToArray()

            Dim responseText As String = System.Text.Encoding.UTF8.GetString(responseBytes)

            socket.Close()
            memoryStream.Close()

            Console.WriteLine(responseText)
            MsgBox(responseText)

        Catch ex As Exception

        End Try

    End Sub



    Private Sub Button_Enviar4_Click(sender As System.Object, e As System.EventArgs) Handles Button_Enviar4.Click
        Try

            Dim s As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
            Dim broadcast As IPAddress = IPAddress.Parse(TextBox_DestIp.Text.Trim)
            Dim sendbuf As Byte() = Encoding.UTF8.GetBytes(txtMensaje.Text.Trim)
            Dim ep As New IPEndPoint(broadcast, TextBox_DestPuerto.Text.Trim)
            s.SendTo(sendbuf, ep)
            s.Close()
            Console.WriteLine("Message sent to the broadcast address")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

End Class