
Imports System.Net.Sockets
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices

Public Class Form_CienteUDP


    Private Sub Form_CienteUDP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button_WakeOnLan_Click(sender As Object, e As EventArgs) Handles Button_WakeOnLan.Click
        Try
            Dim client As New UdpClient()
            Dim macAddress As Byte() = {&HFF, &HFF, &HFF, &HFF, &HFF, &HFF} ' dirección MAC de la computadora que deseas despertar
            Dim port As Integer = 9 ' puerto de Wake-on-LAN
            Dim packet As Byte() = New Byte(101) {} ' paquete mágico de Wake-on-LAN
            For i As Integer = 0 To 5
                packet(i) = &HFF
            Next
            For i As Integer = 6 To 101 Step 6
                Array.Copy(macAddress, 0, packet, i, 6)
            Next
            client.Send(packet, packet.Length, "255.255.255.255", port) ' envía el paquete a la dirección de broadcast
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_VideoConectar_Click(sender As Object, e As EventArgs) Handles Button_VideoConectar.Click

    End Sub

    Delegate Sub DelegateMensaje(ByVal MSG As String)
    Delegate Sub SetItemsForm1()

    Dim Conectado As Boolean

    Dim Encriptador As New Class_Encriptar

    Dim BufferTamaño As Integer

    Private Sub Button_Conectar_Click(sender As Object, e As EventArgs) Handles Button_Conectar.Click

    End Sub


    '    Friend ProcesaLlamadasCliente As New Class_ProcesaMensajeCliente
    '    Public Shared allDone As New Threading.ManualResetEvent(False)

    '    ' WithEvents EventosMensajes As Class_ProcesaMensajeCliente


    '    Private Sub Form_ClienteTCP_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
    '        Try
    '            '  Button_Conectar.Text = "Conectar"
    '            If clientSocket.Connected = True Then
    '                Conectado = False
    '                DesconectarMensaje()

    '                '  DesconectarLocal()
    '                Threading.Thread.Sleep(4100)
    '                ' Threading.Thread.Sleep(210000)
    '                'DesconectarMensaje()
    '                'Threading.Thread.Sleep(5100)
    '                serverStream.Close()
    '                clientSocket.Close()
    '            End If

    '        Catch ex As Exception

    '        End Try
    '        Try
    '            TransferAudio.Button_VozComunicacionParar()
    '        Catch ex As Exception

    '        End Try
    '    End Sub


    'Private Sub Form_TCP_Cliente_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    '    Try

    '        BufferTamaño = 10240


    '        With Class_XmlSocketServer.ObtenerDatosClient()
    '            TextBox_ConectarDestino_IP.Text = .IpDestinoTCP
    '            TextBox_ConectarDestino_Puerto.Text = .PuertoTCP
    '            TextBox_Buffer.Text = .BufferTCP
    '            'TextBox_IpDestinoUDP.Text = .IpDestinoUDP
    '            'TextBox_PuertoUDP.Text = .PuertoUDP
    '            'TextBox_ConexionesMax.Text = .ConexionesMaximas
    '            TextBox_Nick.Text = .Nick
    '        End With

    '        AddHandler ProcesaLlamadasCliente.Mensaje, AddressOf msg
    '        AddHandler ProcesaLlamadasCliente.OperadoresCambio, AddressOf OperadoresListaAñadir
    '        AddHandler ProcesaLlamadasCliente.NickCambio, AddressOf NickCambioSub
    '        Dim imageListLarge As New ImageList()
    '        imageListLarge.ImageSize = New Size(16, 16)
    '        imageListLarge.Images.Add(Bitmap.FromFile(My.Application.Info.DirectoryPath & "\Datos\Ico\TagRed.ico"))
    '        imageListLarge.Images.Add(Bitmap.FromFile(My.Application.Info.DirectoryPath & "\Datos\Ico\TagYellow.ico"))
    '        imageListLarge.Images.Add(Bitmap.FromFile(My.Application.Info.DirectoryPath & "\Datos\Ico\TagBlack.ico"))
    '        imageListLarge.Images.Add(Bitmap.FromFile(My.Application.Info.DirectoryPath & "\Datos\Ico\TagGreen.ico"))
    '        'Icono = My.Application.Info.DirectoryPath & "\Dateado\Ico\TagRed.ico"
    '        'Icono = My.Application.Info.DirectoryPath & "\Dateado\Ico\TagYellow.ico"
    '        'Icono = My.Application.Info.DirectoryPath & "\Dateado\Ico\TagBlack.ico"
    '        'Icono = My.Application.Info.DirectoryPath & "\Dateado\Ico\TagGreen.ico"
    '        ListView_Operadores.LargeImageList = imageListLarge
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        TrackBar_NarraRate.Value = Class_Narrador.Velocidad
    '        TrackBar_NarraVolumen.Value = Class_Narrador.Volumen
    '        ComboBox_NarradorVoces.Items.Clear()
    '        With Class_Narrador.VocesGet
    '            For indice As Integer = 0 To .Count - 1
    '                ComboBox_NarradorVoces.Items.Add(.Item(indice).ToString)
    '            Next
    '        End With
    '        ComboBox_NarradorVoces.Text = Class_Narrador.VozGet

    '        With Class_Narrador.AltavozesGet
    '            For indice As Integer = 0 To .Count - 1
    '                ComboBox_NarraAltavozes.Items.Add(.Item(indice).ToString)
    '            Next
    '        End With
    '        ComboBox_NarraAltavozes.Text = Class_Narrador.AltavozGet
    '        NarradorObtenerDatos()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    Try
    '        ACTUALIZAR_CONTACTOS()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    ActulizarListaServodores()

    'End Sub

    '    Friend Sub ActulizarListaServodores()
    '        Try
    '            With Class_XmlServidores.ObtenerAll

    '                For Indice As Long = 0 To .Count - 1
    '                    DataGridView_ListaServidores.Rows.Add(.Item(Indice).NombreServer, .Item(Indice).IpDestinoTCP, .Item(Indice).IdConexion)
    '                Next

    '            End With
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub


    '    Private Sub Button_GuardarCon_Click(sender As Object, e As EventArgs) Handles Button_GuardarCon.Click
    '        Try
    '            Dim Datos As New Class_XmlSocketServer.Archivo_Clientes
    '            'Datos.IpLocalTCP = TextBox_ConectarDestino_IP.Text
    '            Datos.IpDestinoTCP = TextBox_ConectarDestino_IP.Text
    '            Datos.BufferTCP = TextBox_Buffer.Text.Trim
    '            Datos.PuertoTCP = TextBox_ConectarDestino_Puerto.Text
    '            '  Datos.IpDestinoUDP = TextBox_IpDestinoUDP.Text
    '            '  Datos.PuertoUDP = TextBox_PuertoUDP.Text
    '            '  Datos.ConexionesMaximas = TextBox_ConexionesMax.Text.Trim
    '            Datos.Nick = TextBox_Nick.Text.Trim
    '            Class_XmlSocketServer.ModificarDatosClient(Datos)
    '        Catch ex As Exception
    '            '  RichTextBox_Log.AppendText(ex.Message & vbCrLf)
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub

    '    Private Sub Button_GuardarServer_Click(sender As Object, e As EventArgs) Handles Button_GuardarServer.Click
    '        Try
    '            Dim Colunas As New Class_XmlServidores.Archivo_Servidores
    '            Colunas.IpDestinoTCP = TextBox_ConectarDestino_IP.Text
    '            Colunas.PuertoTCP = TextBox_ConectarDestino_Puerto.Text
    '            Colunas.BufferTCP = TextBox_Buffer.Text
    '            Colunas.Nick = TextBox_Nick.Text
    '            Colunas.IpLocalTCP = ""
    '            Colunas.IpDestinoUDP = ""
    '            Colunas.NombreServer = ""
    '            Colunas.PuertoUDPVideo = ""
    '            Colunas.PuertoUDPAudio = ""
    '            Colunas.IdConexion = ""
    '            Class_XmlServidores.Agregar(Colunas)
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '        ActulizarListaServodores()
    '    End Sub

    '    Private Sub Button_EliminarCon_Click(sender As Object, e As EventArgs) Handles Button_EliminarCon.Click
    '        Try
    '            Dim Colunas As New Class_XmlServidores.Archivo_Servidores
    '            Colunas.IpDestinoTCP = TextBox_ConectarDestino_IP.Text
    '            Colunas.PuertoTCP = TextBox_ConectarDestino_Puerto.Text
    '            Colunas.BufferTCP = TextBox_Buffer.Text
    '            Colunas.Nick = TextBox_Nick.Text
    '            Class_XmlServidores.Eliminar(Colunas)
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '        ActulizarListaServodores()
    '    End Sub

    '    Private Sub DataGridView_ListaServidores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_ListaServidores.CellContentClick

    '    End Sub

    '    Private Sub DataGridView_Clientes_RowHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView_ListaServidores.RowHeaderMouseClick
    '        Try
    '            '  Me.DataGridView_Etiquetas.Rows(e.RowIndex).Selected = True


    '            TextBox_ConectarDestino_IP.Text = CStr(DataGridView_ListaServidores("Column_IP", e.RowIndex).Value).ToString
    '            ' Column_ID   Column_NombreServer
    '            'TextBox_Nick.Text = CStr(DataGridView_ListaServidores("C_Nombre", e.RowIndex).Value).ToString
    '            'TextBox_Destino.Text = CStr(DataGridView_ListaServidores("C_Destino", e.RowIndex).Value).ToString
    '            'TextBox_PuntoDescarga.Text = CStr(DataGridView_ListaServidores("C_PuntoDescarga", e.RowIndex).Value).ToString



    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub

    '    Dim clientSocket As New System.Net.Sockets.UdpClient()
    '    Dim serverStream As NetworkStream
    '    '  Dim readData As String
    '    Dim infiniteCounter As Integer
    '    Dim ctThread As Threading.Thread


    '    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '        Try
    '            Dim StreamOut As Byte() = Module_SocketTcp.Comvertir_StringToByte(NET_Cavecera & NET_Mensaje & Class_Encriptar.encriptar128BitRijndael(TextBox_Mensaje.Text) & NET_FinCadena)
    '            clientSocket.SendBufferSize = StreamOut.Length
    '            serverStream.Write(StreamOut, 0, StreamOut.Length)
    '            serverStream.Flush()
    '            Threading.Thread.Sleep(100) ' Modificar a la lactancia del ping 
    '            Dim StreamOutEnd As Byte() = Module_SocketTcp.Comvertir_StringToByte(NET_Cavecera & NET_MensajeFin)
    '            serverStream.Write(StreamOutEnd, 0, StreamOutEnd.Length)
    '            serverStream.Flush()
    '            TextBox_Mensaje.Text = ""
    '        Catch ex As Exception
    '            MsgBox("Error enviando" & vbCr & ex.Message)
    '        End Try
    '    End Sub

    '    Private Sub Button_EnviarMsj_Click_Intento(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_EnviarMsj.Click
    '        Try


    '            Dim Finalizado As Boolean = False
    '            Dim MensajeEncriptado As String = Class_Encriptar.encriptar128BitRijndael(TextBox_Mensaje.Text)
    '            Dim MensajeByteado As Byte() = Module_SocketTcp.Comvertir_StringToByte(MensajeEncriptado)
    '            Dim Cavecera As Byte() = Module_SocketTcp.Comvertir_StringToByte(NET_Cavecera & NET_Mensaje)
    '            Dim FinCadena As Byte() = Module_SocketTcp.Comvertir_StringToByte(NET_FinCadena)
    '            Dim FinMensaje As Byte() = Module_SocketTcp.Comvertir_StringToByte(NET_MensajeFin)
    '            Dim CaracteresCavecera As Integer = Cavecera.Length
    '            Dim CaracteresFin As Integer = FinCadena.Length
    '            Dim CaracteresMensaje As Long = MensajeByteado.Length

    '            Dim BuferTamaño As Integer = 512  'clientSocket.SendBufferSize / 8
    '            Dim BuferSpacio As Integer = (BuferTamaño - 1) - (FinCadena.Length - 1)
    '            Dim BufferEnvio(BuferTamaño - 1) As Byte

    '            Dim StreamOut000 As Byte() = Module_SocketTcp.Comvertir_StringToByte(NET_Cavecera & NET_Mensaje & Class_Encriptar.encriptar128BitRijndael(TextBox_Mensaje.Text) & NET_FinCadena)



    '            Dim CaracteresTotal As Long = (CaracteresMensaje + CaracteresCavecera + CaracteresFin)

    '            If BuferTamaño < StreamOut000.Length Then

    '                For IndicePreBuffesr As Integer = 0 To CaracteresCavecera - 1
    '                    Buffer.SetByte(BufferEnvio, IndicePreBuffesr, Cavecera.GetValue(IndicePreBuffesr))
    '                Next

    '                Dim PosicionMensaje As Long = 0

    '5000:
    '                'If CaracteresMensaje <= (BuferTamaño + PosicionMensaje) Then

    '                '    '    BuferTamaño = (CaracteresMensaje - PosicionMensaje) + CaracteresCavecera - 1

    '                '    For IndiceRelleno As Integer = (CaracteresCavecera - 2) + BuferTamaño To BufferEnvio.Length - 1
    '                '        Buffer.SetByte(BufferEnvio, IndiceRelleno, 0)

    '                '    Next
    '                'End If
    '                For IndiceRelleno As Integer = CaracteresCavecera To BuferTamaño - 1 ' Step 4
    '                    Buffer.SetByte(BufferEnvio, IndiceRelleno, 0)
    '                Next


    '                Dim IndiceRellenoA1 As Integer = 0
    '                For IndiceRelleno As Integer = CaracteresCavecera To BuferSpacio - 1 ' Step 4
    '                    If PosicionMensaje >= MensajeByteado.Length Then
    '                        Finalizado = True
    '                        Exit For
    '                    End If

    '                    Buffer.SetByte(BufferEnvio, IndiceRelleno, MensajeByteado.GetValue(PosicionMensaje))
    '                    PosicionMensaje += 1
    '                    'Buffer.SetByte(BufferEnvio, IndiceRelleno, MensajeByteado.GetValue(PosicionMensaje))
    '                    'PosicionMensaje += 1
    '                    'Buffer.SetByte(BufferEnvio, IndiceRelleno, MensajeByteado.GetValue(PosicionMensaje))
    '                    'PosicionMensaje += 1
    '                    'Buffer.SetByte(BufferEnvio, IndiceRelleno, MensajeByteado.GetValue(PosicionMensaje))
    '                    'PosicionMensaje += 1
    '                    IndiceRellenoA1 = IndiceRelleno
    '                Next

    '                Try
    '                    Dim IndiceFinA1 As Integer = 0
    '                    Dim residuo As Int16 = IndiceRellenoA1 Mod 2
    '                    For IndiceFin As Integer = (IndiceRellenoA1 + residuo) To (BuferTamaño - 1)
    '                        Buffer.SetByte(BufferEnvio, IndiceFin, FinCadena.GetValue(IndiceFinA1))
    '                        IndiceFinA1 += 1
    '                        If IndiceFinA1 >= FinCadena.Length Then
    '                            Exit For
    '                        End If
    '                    Next
    '                Catch ex As Exception
    '                    MsgBox(" C E " & vbCr & ex.Message, MsgBoxStyle.Exclamation)
    '                End Try

    '                Dim Stringinin As String = Module_SocketTcp.Comvertir_ByteToString(BufferEnvio)

    '                serverStream.Write(BufferEnvio, 0, BufferEnvio.Length) '.Length)
    '                serverStream.Flush()
    '                Threading.Thread.Sleep(10)
    '                If PosicionMensaje < CaracteresMensaje - 1 And Finalizado = False Then
    '                    GoTo 5000

    '                End If

    '            Else
    '                Dim StreamOut As Byte() = Module_SocketTcp.Comvertir_StringToByte(NET_Cavecera & NET_Mensaje & Class_Encriptar.encriptar128BitRijndael(TextBox_Mensaje.Text) & NET_FinCadena)

    '                serverStream.Write(StreamOut, 0, StreamOut.Length)
    '                serverStream.Flush()
    '            End If

    '            Threading.Thread.Sleep(100) ' Modificar a la lactancia del ping 
    '            Dim StreamOutEnd As Byte() = Module_SocketTcp.Comvertir_StringToByte(NET_Cavecera & NET_MensajeFin)
    '            Dim saaa As String = Module_SocketTcp.Comvertir_ByteToString(StreamOutEnd)
    '            serverStream.Write(StreamOutEnd, 0, StreamOutEnd.Length)
    '            serverStream.Flush()
    '            TextBox_Mensaje.Text = ""
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
    '        End Try

    '    End Sub

    '    Private Sub Button_EnviarMsj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles Button_EnviarMsj.Click
    '        Try

    '            Dim BuferTamaño As Integer = clientSocket.SendBufferSize

    '            Dim MensajeEncriptado As String = Class_Encriptar.encriptar128BitRijndael(TextBox_Mensaje.Text)
    '            Dim MensajeByteado As Byte() = Module_SocketTcp.Comvertir_StringToByte(MensajeEncriptado)
    '            Dim Cavecera As Byte() = Module_SocketTcp.Comvertir_StringToByte(NET_Cavecera & NET_Mensaje)
    '            Dim FinCadena As Byte() = Module_SocketTcp.Comvertir_StringToByte(NET_FinCadena)
    '            Dim FinMensaje As Byte() = Module_SocketTcp.Comvertir_StringToByte(NET_MensajeFin)
    '            Dim CaracteresCavecera As Integer = Cavecera.Length
    '            Dim CaracteresFin As Integer = FinCadena.Length
    '            Dim CaracteresMensaje As Long = MensajeByteado.Length


    '            Dim BufferEnvio(BuferTamaño - 1) As Byte

    '            Dim StreamOut000 As Byte() = Module_SocketTcp.Comvertir_StringToByte(NET_Cavecera & NET_Mensaje & Class_Encriptar.encriptar128BitRijndael(TextBox_Mensaje.Text) & NET_FinCadena)



    '            Dim CaracteresTotal As Long = (CaracteresMensaje + CaracteresCavecera + CaracteresFin)

    '            If BuferTamaño < StreamOut000.Length Then

    '                For IndicePreBuffesr As Integer = 0 To CaracteresCavecera - 1
    '                    Buffer.SetByte(BufferEnvio, IndicePreBuffesr, Cavecera.GetValue(IndicePreBuffesr))
    '                Next

    '                Dim PosicionMensaje As Long = 0

    '5000:
    '                If CaracteresMensaje <= (BuferTamaño + PosicionMensaje) Then

    '                    BuferTamaño = (CaracteresMensaje - PosicionMensaje) + CaracteresCavecera - 1

    '                    For IndiceRelleno As Integer = (CaracteresCavecera - 2) + BuferTamaño To BufferEnvio.Length - 1
    '                        Buffer.SetByte(BufferEnvio, IndiceRelleno, 0)

    '                    Next
    '                End If

    '                Dim IndiceRellenoA1 As Integer = 0
    '                For IndiceRelleno As Integer = CaracteresCavecera To (BuferTamaño - 1) - (FinCadena.Length - 1)
    '                    Buffer.SetByte(BufferEnvio, IndiceRelleno, MensajeByteado.GetValue(PosicionMensaje))
    '                    PosicionMensaje += 1
    '                    IndiceRellenoA1 = IndiceRelleno
    '                Next
    '                'Try
    '                '    Dim IndiceFinA1 As Integer = 0
    '                '    Dim residuo As Int16 = IndiceRellenoA1 Mod 4
    '                '    For IndiceFin As Integer = (IndiceRellenoA1 + residuo) To (BuferTamaño - 1)
    '                '        Buffer.SetByte(BufferEnvio, IndiceFin, FinCadena.GetValue(IndiceFinA1))
    '                '        IndiceFinA1 += 1
    '                '    Next
    '                'Catch ex As Exception
    '                '    MsgBox("C E " & vbCr & ex.Message, MsgBoxStyle.Exclamation)
    '                'End Try

    '                Dim Stringinin As String = Module_SocketTcp.Comvertir_ByteToString(BufferEnvio)

    '                serverStream.Write(BufferEnvio, 0, BufferEnvio.Length) '.Length)
    '                serverStream.Flush()

    '                If PosicionMensaje < CaracteresMensaje - 1 Then
    '                    GoTo 5000

    '                End If

    '            Else
    '                Dim StreamOut As Byte() = Module_SocketTcp.Comvertir_StringToByte(NET_Cavecera & NET_Mensaje & Class_Encriptar.encriptar128BitRijndael(TextBox_Mensaje.Text)) '& NET_FinCadena)

    '                serverStream.Write(StreamOut, 0, StreamOut.Length)
    '                serverStream.Flush()
    '            End If

    '            Threading.Thread.Sleep(100) ' Modificar a la lactancia del ping 
    '            Dim StreamOutEnd As Byte() = Module_SocketTcp.Comvertir_StringToByte(NET_Cavecera & NET_MensajeFin)
    '            Dim saaa As String = Module_SocketTcp.Comvertir_ByteToString(StreamOutEnd)
    '            serverStream.Write(StreamOutEnd, 0, StreamOutEnd.Length)
    '            serverStream.Flush()
    '            TextBox_Mensaje.Text = ""
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
    '        End Try

    '    End Sub


    '    Private Sub Button_Conectar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Conectar.Click
    '        Try
    '            If Button_Conectar.Text = "Conectar" Then
    '                Conectado = True

    '                clientSocket = New System.Net.Sockets.UdpClient()
    '                '  readData = "Conected to Chat Server ..."
    '                '  msg("Conectedo a el Chat  ...")


    '                Dim lipa As System.Net.IPAddress = System.Net.Dns.Resolve(TextBox_ConectarDestino_IP.Text).AddressList(0)

    '                Dim DirIP As String = lipa.Address.ToString
    '                Try
    '                    Dim aaa As System.Net.IPAddress = Net.IPAddress.Parse(TextBox_ConectarDestino_IP.Text)
    '                Catch ex As Exception

    '                End Try





    '                clientSocket.Connect(lipa, TextBox_ConectarDestino_Puerto.Text)
    '                'Label1.Text = "Client Socket Program - Server Connected ..."
    '                serverStream = clientSocket.GetStream()
    '                '   MsgBox("1")
    '                Dim outStream As Byte() = Module_SocketTcp.Comvertir_StringToByte(Module_SocketTcp.NET_Cavecera & Module_SocketTcp.NET_NuevaConexion & TextBox_Nick.Text & NET_FinCadena) 'System.Text.Encoding.UTF32.GetBytes(Module_SocketTcp.NET_Cavecera & Module_SocketTcp.NET_NuevaConexion & TextBox_Nick.Text & NET_FinCadena)
    '                serverStream.Write(outStream, 0, outStream.Length)
    '                serverStream.Flush()
    '                '     MsgBox("2")
    '                ctThread = New Threading.Thread(AddressOf getMessage)
    '                ctThread.Start()
    '                Threading.Thread.Sleep(1200)
    '                Button_Conectar.Text = "Desconectar"
    '                '       MsgBox("3")
    '                If CheckBox_NarraConexiones.Checked Then
    '                    Class_Narrador.Narra("Conectado")
    '                End If

    '            Else
    '                Button_Conectar.Text = "Conectar"
    '                Conectado = False
    '                DesconectarMensaje()

    '                '  DesconectarLocal()
    '                Threading.Thread.Sleep(4100)
    '                ' Threading.Thread.Sleep(210000)
    '                'DesconectarMensaje()
    '                'Threading.Thread.Sleep(5100)
    '                serverStream.Close()
    '                clientSocket.Close()
    '                If CheckBox_NarraConexiones.Checked Then
    '                    Class_Narrador.Narra("Desconectado")
    '                End If
    '            End If
    '        Catch ex As Exception
    '            MsgBox("Error al conectar" & vbCr & ex.Message)

    '        End Try

    '    End Sub

    '    Private Sub DesconectarMensaje()
    '        Try

    '            Dim outStream As Byte() = Module_SocketTcp.Comvertir_StringToByte(NET_Cavecera & Module_SocketTcp.NET_Desconexion & NET_FinCadena)
    '            serverStream.Write(outStream, 0, outStream.Length)
    '            serverStream.Flush()

    '        Catch ex As Exception
    '            MsgBox("Error  'DesconectarMensaje'" & vbCr & ex.Message)
    '        End Try
    '    End Sub
    '    Private Sub DesconectarLocal()
    '        Try

    '            ' Dim encoder As New System.Text.UTF32Encoding
    '            Dim client0 As New System.Net.Sockets.TcpClient()
    '            client0.SendTimeout = 2
    '            client0.ReceiveTimeout = 1
    '            'Dim serverEndPoint0 As New System.Net.IPEndPoint(System.Net.IPAddress.Parse(TextBox_ConectarDestino_IP.Text), TextBox_ConectarDestino_Puerto.Text)
    '            Dim serverEndPoint0 As System.Net.IPEndPoint = clientSocket.Client.LocalEndPoint
    '            client0.Connect(serverEndPoint0)
    '            Dim clientStream0 As System.Net.Sockets.NetworkStream = client0.GetStream()
    '            Dim buffer0 As Byte() = Module_SocketTcp.Comvertir_StringToByte(NET_Cavecera & NET_Desconexion & NET_FinCadena)
    '            clientStream0.Write(buffer0, 0, buffer0.Length)
    '            clientStream0.Flush()



    '        Catch ex As Exception
    '            MsgBox("Error  'DesconectarLocal'" & vbCr & ex.Message)
    '        End Try
    '    End Sub

    '    Private Sub getMessage()
    '        Try

    '            '  MsgBox("A1")
    '            '  For infiniteCounter = 1 To 2
    '            'infiniteCounter = 1
    '            While Conectado

    '                '  Dim Posicion As Long = serverStream.Position

    '                Dim returndata As String = String.Empty

    '                serverStream = clientSocket.GetStream()

    '                '  Dim inStream(clientSocket.ReceiveBufferSize) As Byte
    '                Dim inStream(511) As Byte
    '                '  inStream = clientSocket.ReceiveBufferSize
    '                serverStream.Read(inStream, 0, inStream.Length)
    '                returndata &= Module_SocketTcp.Comvertir_ByteToString(inStream)
    '                Dim bbbb As String = Module_SocketTcp.Comvertir_ByteToString(inStream)
    '                Dim aaasa As Long = returndata.Length
    '                'While serverStream.DataAvailable
    '                '    serverStream.Read(inStream, 0, inStream.Length)
    '                '    bbbb = Module_SocketTcp.Comvertir_ByteToString(inStream)
    '                '    returndata &= Module_SocketTcp.Comvertir_ByteToString(inStream)
    '                '    Dim aaaa As Long = returndata.Length
    '                'End While
    '                '    MsgBox("A2")
    '                ProcesaLlamadasCliente.Procesa_HolaCliente_T2(returndata)
    '                Dim aaaa111 = ProcesaLlamadasCliente.Lista_MensajesCliente
    '                returndata = String.Empty
    '                '    msg(ProcesaLlamadasCliente.Procesa_HolaCliente_T2(returndata))

    '                If serverStream.DataAvailable Then
    '                    Dim aaa = ""

    '                End If



    '            End While
    '        Catch ex As Exception
    '            If Conectado = True Then
    '                MsgBox("Error obteniendo mensaje" & vbCr & ex.Message)
    '            End If

    '            serverStream.Close()
    '            clientSocket.Close()
    '            Conectado = False

    '            BotonConectarSet()

    '        End Try

    '    End Sub


    '    Private Sub msg(ByVal Mensaje As String)
    '        If Me.RichTextBox_MensajesEntrada.InvokeRequired Then

    '            'Me.TextBox_MensajesBandeja.Invoke(New MethodInvoker(AddressOf msg))

    '            Dim d As New DelegateMensaje(AddressOf msg)
    '            'Call RichTextBox_MensajesChat.Invoke(d)
    '            '  Call RichTextBox_MensajesEntrada.Invoke(d, New Object() {Mensaje})
    '            Call RichTextBox_MensajesEntrada.Invoke(d, New Object() {Mensaje})
    '        Else
    '            RichTextBox_MensajesEntrada.Text &= Environment.NewLine & " >> " & Mensaje
    '            RichTextBox_MensajesEntrada.SelectionStart = RichTextBox_MensajesEntrada.Text.Length
    '            RichTextBox_MensajesEntrada.ScrollToCaret()
    '            If CheckBox_NarraMenasajes.Checked Then
    '                Dim PosicionNick As Integer = Mensaje.IndexOf(" : ")
    '                Dim Nick As String = String.Empty
    '                If PosicionNick > 1 Then
    '                    Nick = Mid(Mensaje, 1, PosicionNick)
    '                    If TextBox_Nick.Text.ToLower <> Nick.ToLower Then
    '                        Class_Narrador.Narra(Nick & " " & " Dice ")
    '                        Class_Narrador.Narra(Mid(Mensaje, PosicionNick, Mensaje.Length))
    '                    End If
    '                Else
    '                    Class_Narrador.Narra(Mensaje)
    '                End If


    '            End If
    '            '    RichTextBox_MensajesEntrada.AutoScrollOffset = RichTextBox_MensajesEntrada.ClientSize.Height
    '            ' RichTextBox_MensajesEntrada.AppendText(Environment.NewLine & " >> " & Mensaje)
    '            '   RichTextBox_MensajesEntrada.AppendText(Environment.NewLine & " >> " & Encriptador.desencriptar128BitRijndael(Mensaje, "w06Aay"))
    '        End If
    '    End Sub


    '    Friend Sub BotonConectarSet()
    '        If Button_Conectar.InvokeRequired Then
    '            Dim d As New SetItemsForm1(AddressOf BotonConectarSet)
    '            Call Button_Conectar.Invoke(d)
    '        Else
    '            Button_Conectar.Text = "Conectar"
    '        End If
    '    End Sub


    '    Private Sub Label_Buffer_Click(sender As Object, e As EventArgs) Handles Label_Buffer.Click
    '        Try
    '            Dim Buffer As Integer = TextBox_Buffer.Text
    '            If Buffer > 128 Then
    '                ServidorTCP4.BufferTamaño = Buffer
    '            Else
    '                MsgBox("El tamaño del buffer debe ser mayor a 128")
    '            End If

    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub

    '    Private Sub Button_Inicio_Click(sender As Object, e As EventArgs) Handles Button_Inicio.Click
    '        Try
    '            If FormularioInicio.Cargado = False Then
    '                FormularioInicio = New Form_Inicio
    '                FormularioInicio.CargaDatos()
    '                FormularioInicio.Show()
    '            Else
    '                FormularioInicio.CargaDatos()
    '                FormularioInicio.Show()
    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '        '    Dim FormNuevo As New Form_Inicio
    '        '  FormNuevo.CargaDatos()
    '        '  FormNuevo.Show()

    '    End Sub

    '    Friend Sub NickCambioSub(NickNuevo As String)
    '        '    Dim aaa As New Form_ClienteTCP
    '        If TextBox_Nick.InvokeRequired Then
    '            ' callingThread = System.Threading.Thread.CurrentThread.ManagedThreadId()
    '            Dim d As New DelegateMensaje(AddressOf NickCambioSub)
    '            '       Call RichTextBox_MensajesChat.Invoke(d)
    '            Call TextBox_Nick.Invoke(d, New Object() {NickNuevo})
    '        Else

    '            TextBox_Nick.Text = NickNuevo
    '            '  RichTextBox_MensajesChat.AppendText(Encriptador.encriptar128BitRijndael(MSG, "w06Aay") & vbCr)
    '        End If
    '    End Sub

    '    Friend Sub OperadoresListaLimpiar()
    '        '    Dim aaa As New Form_ClienteTCP
    '        If ListView_Operadores.InvokeRequired Then
    '            ' callingThread = System.Threading.Thread.CurrentThread.ManagedThreadId()
    '            Dim d As New DelegateMensaje(AddressOf NickCambioSub)
    '            '       Call RichTextBox_MensajesChat.Invoke(d)
    '            Call TextBox_Nick.Invoke(d, New Object() {})
    '        Else

    '            ListView_Operadores.Items.Clear()
    '            '  RichTextBox_MensajesChat.AppendText(Encriptador.encriptar128BitRijndael(MSG, "w06Aay") & vbCr)
    '        End If
    '    End Sub


    '    Friend Sub OperadoresListaAñadir(ListaMensaje As String)

    '        Try
    '            If ListView_Operadores.InvokeRequired Then
    '                Dim d As New DelegateMensaje(AddressOf OperadoresListaAñadir)
    '                Call ListView_Operadores.Invoke(d, New Object() {ListaMensaje})
    '            Else
    '                ListView_Operadores.Items.Clear()
    '                ' For Each Operadorer As Class_OperadorRed_TCP In OperadoresRed_ListaTCP
    '                Dim Comaparando As String = String.Empty
    '                Dim P_Nick As String = String.Empty
    '                Dim P_Baneado As Boolean = False
    '                Dim P_Aceptado As Boolean = False
    '                Dim P_Conectado As Boolean = False
    '                Dim IndiceComparaInicioOp As Integer
    '                Dim IndiceComparaNickOp As Integer
    '                Dim IndiceComparaBanOp As Integer
    '                Dim IndiceComparaAceOp As Integer
    '                Dim IndiceComparaConOp As Integer
    '                For indice As Integer = 1 To ListaMensaje.Length

    '                    'Next



    '                    For IndiceComparaInicioOp = indice To ListaMensaje.Length
    '                        Comaparando = Mid(ListaMensaje, IndiceComparaInicioOp, 2)
    '                        If Comaparando = "|€" Then
    '                            Exit For
    '                        End If
    '                    Next
    '                    indice = IndiceComparaInicioOp + 1
    '                    For IndiceComparaNickOp = indice To ListaMensaje.Length
    '                        Comaparando = Mid(ListaMensaje, IndiceComparaNickOp, 2)
    '                        If Comaparando = "||" Then
    '                            P_Nick = Mid(ListaMensaje, indice + 1, IndiceComparaNickOp - indice - 1)
    '                            Exit For
    '                        End If
    '                    Next
    '                    indice = IndiceComparaNickOp + 2

    '                    'Dim aaaa1 As String = Mid(ListaMensaje, indice, 5)
    '                    'Dim aaaa2 As String = Mid(ListaMensaje, indice + 7, 5)
    '                    'Dim aaaa3 As String = Mid(ListaMensaje, indice + 14, 5)

    '                    For IndiceComparaBanOp = indice To ListaMensaje.Length
    '                        Comaparando = Mid(ListaMensaje, IndiceComparaBanOp, 2)
    '                        If Comaparando = "||" Then
    '                            Dim aaa As String = Mid(ListaMensaje, indice, IndiceComparaBanOp - indice)
    '                            P_Baneado = CBool(aaa)
    '                            '  P_Baneado = Mid(ListaMensaje, indice, IndiceComparaBanOp)
    '                            Exit For
    '                        End If
    '                    Next
    '                    indice = IndiceComparaBanOp + 2
    '                    For IndiceComparaAceOp = indice To ListaMensaje.Length
    '                        Comaparando = Mid(ListaMensaje, IndiceComparaAceOp, 2)
    '                        If Comaparando = "||" Then
    '                            Dim aaa As String = Mid(ListaMensaje, indice, IndiceComparaAceOp - indice)
    '                            P_Aceptado = CBool(aaa)
    '                            Exit For
    '                        End If
    '                    Next
    '                    indice = IndiceComparaAceOp + 2
    '                    For IndiceComparaConOp = indice To ListaMensaje.Length
    '                        Comaparando = Mid(ListaMensaje, IndiceComparaConOp, 2)
    '                        If Comaparando = "|$" Then
    '                            Dim aaa As String = Mid(ListaMensaje, indice, IndiceComparaConOp - indice)
    '                            P_Conectado = CBool(aaa)
    '                            Exit For
    '                        End If
    '                    Next
    '                    indice = IndiceComparaConOp + 1


    '                    '  Dim Texto As String
    '                    'Dim Nombre As String
    '                    '     Dim Icono As String
    '                    Dim IconoNum As Integer
    '                    'If Operadorer.Nick.Trim <> String.Empty Then
    '                    '    Texto = Operadorer.Nick
    '                    'Else
    '                    '    Texto = Operadorer.DirecciónDestino.ToString
    '                    'End If

    '                    If P_Baneado = True Then
    '                        '  Icono = My.Application.Info.DirectoryPath & "\Datos\Ico\TagRed.ico"
    '                        IconoNum = 0
    '                    ElseIf P_Aceptado = False Then
    '                        '  Icono = My.Application.Info.DirectoryPath & "\Datos\Ico\TagYellow.ico"
    '                        IconoNum = 1
    '                    ElseIf P_Conectado = False Then
    '                        '  Icono = My.Application.Info.DirectoryPath & "\Datos\Ico\TagBlack.ico"
    '                        IconoNum = 2
    '                    Else
    '                        '  Icono = My.Application.Info.DirectoryPath & "\Datos\Ico\TagGreen.ico"
    '                        IconoNum = 3
    '                    End If
    '                    Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(P_Nick, IconoNum) '("", "(ninguno)")

    '                    ListViewItem1.Name = P_Nick
    '                    '   ListViewItem1.ImageKey = IconoNum

    '                    ' ListView2.Items.Add(ListViewItem1)
    '                    'MensajeOperadores &= OperadorEnLista.Nick & "||" & OperadorEnLista.Baneado & "||" & OperadorEnLista.Acepatado & "|$"
    '                    ListView_Operadores.Items.Add(ListViewItem1)

    '                Next
    '                '  RichTextBox_MensajesChat.AppendText(Encriptador.encriptar128BitRijndael(MSG, "w06Aay") & vbCr)
    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try

    '    End Sub




    '    Private Sub Button_ActulizaOperadores_Click(sender As Object, e As EventArgs) Handles Button_ActulizaOperadores.Click
    '        Try
    '            '  Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(NET_Cavecera & NET_Mensaje & Encriptador.encriptar128BitRijndael(TextBox_Mensaje.Text & "$", "w06Aay"))
    '            Dim outStream As Byte() = Module_SocketTcp.Comvertir_StringToByte(NET_Cavecera & NET_Operadores & NET_FinCadena) '(NET_Cavecera & NET_Mensaje & Class_Encriptar.encriptar128BitRijndael(TextBox_Mensaje.Text, "clave_ajpdsoft") & NET_FinCadena)
    '            serverStream.Write(outStream, 0, outStream.Length)
    '            serverStream.Flush()
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
    '        End Try
    '    End Sub

    '    Private Sub Button_ModInfoOperador_Click(sender As Object, e As EventArgs) Handles Button_ModInfoOperador.Click
    '        Try
    '            If ListView_Operadores.View = View.Details Then
    '                ListView_Operadores.View = View.LargeIcon
    '            ElseIf ListView_Operadores.View = View.LargeIcon Then
    '                ListView_Operadores.View = View.List
    '            ElseIf ListView_Operadores.View = View.List Then
    '                ListView_Operadores.View = View.SmallIcon
    '            ElseIf ListView_Operadores.View = View.SmallIcon Then
    '                ListView_Operadores.View = View.Tile
    '            ElseIf ListView_Operadores.View = View.Tile Then
    '                ListView_Operadores.View = View.Details
    '            Else
    '                ListView_Operadores.View = View.Tile
    '            End If
    '        Catch ex As Exception

    '        End Try

    '    End Sub

    '    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView_Operadores.SelectedIndexChanged
    '        Try

    '            '  Dim operador As Class_OperadorRed_TCP = ServidorTCP4.ObtenerOperadorRed_IP(ListView_Operadores.SelectedItems.Item(0).Name)
    '            '  operador.Acepatado = True
    '        Catch ex As Exception

    '        End Try
    '    End Sub

    '    Private Sub TextBox_Nick_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Nick.LostFocus
    '        Try
    '            'If InStr(1, "|$" & Chr(8)) = 0 Then
    '            '    MsgBox("Caracter o valido")
    '            'End If
    '            Dim Caracter As String = String.Empty

    '            For indice As Integer = 1 To TextBox_Nick.Text.Length
    '                Caracter = Mid(TextBox_Nick.Text.Trim, indice, 1)
    '                If Caracter = "|" Or Caracter = "$" Or Caracter = "€" Then
    '                    TextBox_Nick.Text = TextBox_Nick.Text.Remove(indice - 1, 1)
    '                End If
    '            Next
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub


    '    Private Sub Button_Ping_Click(sender As Object, e As EventArgs) Handles Button_Ping.Click
    '        Try
    '            Dim pingresult As String = My.Computer.Network.Ping(TextBox_ConectarDestino_IP.Text)
    '            If pingresult = "True" Then
    '                Label_Ping.Text = "Disponible"
    '                Label_Ping.ForeColor = Color.Green
    '            Else
    '                Label_Ping.Text = "Ausente"
    '                Label_Ping.ForeColor = Color.DarkRed
    '            End If
    '        Catch ex As Exception

    '        End Try
    '    End Sub
    '    Private Sub Label_Ping_Click(sender As Object, e As EventArgs) Handles Label_Ping.Click
    '        Label_Ping.ForeColor = Color.Black
    '    End Sub

    '    'Private Sub Button_NarradorVoces_Click(sender As Object, e As EventArgs) Handles Button_NarradorVoces.Click
    '    '    Try
    '    '        ComboBox_NarradorVoces.Items.Clear()
    '    '        With Class_Narrador.VocesGet
    '    '            For indice As Integer = 0 To .Count - 1
    '    '                ComboBox_NarradorVoces.Items.Add(.Item(indice).ToString)
    '    '            Next
    '    '        End With
    '    '    Catch ex As Exception
    '    '        MsgBox(ex.Message)
    '    '    End Try
    '    'End Sub
    '#Region "Narrador"

    '    Private Sub ComboBox_NarradorVoces_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_NarradorVoces.SelectedIndexChanged
    '        Try
    '            Class_Narrador.VocesSet = ComboBox_NarradorVoces.SelectedIndex
    '            '  NarradorGuardarDatos()
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub

    '    Private Sub TrackBar_NarraVolumen_Scroll(sender As Object, e As EventArgs) Handles TrackBar_NarraVolumen.Scroll
    '        Try
    '            Class_Narrador.Volumen = TrackBar_NarraVolumen.Value
    '            '  NarradorGuardarDatos()
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub

    '    Private Sub TrackBar_NarraRate_Scroll(sender As Object, e As EventArgs) Handles TrackBar_NarraRate.Scroll
    '        Try
    '            Class_Narrador.Velocidad = TrackBar_NarraRate.Value
    '            '   NarradorGuardarDatos()
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub

    '    Private Sub ComboBox_NarraAltavozes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_NarraAltavozes.SelectedIndexChanged
    '        Try
    '            Class_Narrador.AltavozSet = ComboBox_NarraAltavozes.SelectedIndex
    '            '  NarradorGuardarDatos()
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub

    '    Private Sub CheckBox_NarraConexiones_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_NarraConexiones.CheckedChanged
    '        Try
    '            '  NarradorGuardarDatos()
    '        Catch ex As Exception
    '            '  RichTextBox_Log.AppendText(ex.Message & vbCrLf)
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub

    '    Private Sub CheckBox_NarraMenasajes_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_NarraMenasajes.CheckedChanged
    '        Try
    '            ' NarradorGuardarDatos()
    '        Catch ex As Exception
    '            '  RichTextBox_Log.AppendText(ex.Message & vbCrLf)
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub

    '    Private Sub NarradorGuardarDatos()
    '        Try
    '            Dim Datos As New Class_XmlNarra.Archivo_Clientes
    '            Datos.NarraConexion = CheckBox_NarraConexiones.Checked
    '            Datos.NarraMensaje = CheckBox_NarraMenasajes.Checked
    '            Datos.Volumen = TrackBar_NarraVolumen.Value
    '            Datos.Velocidad = TrackBar_NarraRate.Value
    '            Datos.Voz = ComboBox_NarradorVoces.Text
    '            Datos.Salidas = ComboBox_NarraAltavozes.Text
    '            Class_XmlNarra.ModificarDatosClient(Datos)
    '        Catch ex As Exception
    '            '  RichTextBox_Log.AppendText(ex.Message & vbCrLf)
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub

    '    Private Sub NarradorObtenerDatos()
    '        Try
    '            With Class_XmlNarra.ObtenerDatosClient()
    '                CheckBox_NarraConexiones.Checked = .NarraConexion
    '                CheckBox_NarraMenasajes.Checked = .NarraMensaje
    '                TrackBar_NarraVolumen.Value = .Volumen
    '                TrackBar_NarraRate.Value = .Velocidad
    '                ComboBox_NarradorVoces.Text = .Voz
    '                ComboBox_NarraAltavozes.Text = .Salidas
    '            End With
    '            'Datos.NarraConexion = CheckBox_NarraConexiones.Checked
    '            'Datos.NarraMensaje = CheckBox_NarraMenasajes.Checked
    '            'Datos.Volumen = TrackBar_NarraVolumen.Value
    '            'Datos.Velocidad = TrackBar_NarraRate.Value
    '            'Datos.Voz = ComboBox_NarradorVoces.Text
    '            'Datos.Salidas = ComboBox_NarraAltavozes.Text
    '        Catch ex As Exception
    '            '  RichTextBox_Log.AppendText(ex.Message & vbCrLf)
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub

    '    Private Sub Button_NarraGuardar_Click(sender As Object, e As EventArgs) Handles Button_NarraGuardar.Click
    '        NarradorGuardarDatos()
    '    End Sub

    '    Private Sub Button_NarraProbar_Click(sender As Object, e As EventArgs) Handles Button_NarraProbar.Click
    '        Try
    '            Class_Narrador.Narra("Hola, estas escuchando el narrador de windows")
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub

    '#End Region



    '#Region "Voz"

    '    Dim TransferAudio As Class_AudioTransfer ' New Class_AudioTransfer
    '    Dim DICCIONARIO As New SortedDictionary(Of String, String)

    '    '  Dim TransferAudio As New Class_AudioTransfer000

    '    Private Sub Button_VozAgregar_Click(sender As Object, e As EventArgs) Handles Button_VozAgregar.Click
    '        Try
    '            Dim Existe As Boolean = False
    '            Dim ENUMERADOR As IDictionaryEnumerator
    '            ENUMERADOR = DICCIONARIO.GetEnumerator
    '            While ENUMERADOR.MoveNext
    '                If ENUMERADOR.Key = TextBox_Nombre.Text Then
    '                    Existe = True
    '                    'Label_VozIp.Text = ENUMERADOR.Value
    '                    'Label_VozPuerto.Text = ENUMERADOR.Key
    '                End If
    '            End While

    '            If Existe = False Then
    '                'CREA UN NUEVO CONTACTO Y ACTUALIZA EL FICHERO DATOS.txt Y EL LISTBOX
    '                Dim CONTACTO As String
    '                Dim IP As String
    '                CONTACTO = TextBox_Nombre.Text
    '                IP = TextBox_VozIp.Text
    '                My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Datos\BaseDatos\" & "CONTACTOS.txt", "$" & CONTACTO & "$" & IP & vbCrLf, True)
    '                '  MsgBox("SE HA CREADO EL USUARIO: " & CONTACTO & "  IP: " & IP)
    '                ACTUALIZAR_CONTACTOS()
    '                TextBox_Nombre.Text = ""
    '                TextBox_VozIp.Text = ""
    '            Else
    '                MsgBox("Ya existe un contacto con el mismo nombre.")
    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub

    '    Private Sub ListBox_Contactos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox_Contactos.SelectedIndexChanged
    '        Try
    '            Dim ENUMERADOR As IDictionaryEnumerator
    '            ENUMERADOR = DICCIONARIO.GetEnumerator
    '            While ENUMERADOR.MoveNext
    '                If ENUMERADOR.Key = ListBox_Contactos.SelectedItem Then
    '                    Label_VozIp.Text = ENUMERADOR.Value
    '                    Label_VozPuerto.Text = ENUMERADOR.Key
    '                End If
    '            End While
    '            ' Form1.RELOJWEBCAM.Enabled = True
    '            'Form1.RELOJMENSAJE.Enabled = True
    '            'Form1.RELOJRECIBEAUDIO.Enabled = True
    '            'Form1.SERVIDOR = New UDPListener(8050)
    '            'Form1.SERVIDOR.Start()
    '            'Close()
    '        Catch ex As Exception

    '        End Try


    '    End Sub

    '    Public Sub ACTUALIZAR_CONTACTOS()

    '        ' VACIAMOS EL LISTBOX Y EL ARRAY DICCIONARIO
    '        ListBox_Contactos.Items.Clear()
    '        DICCIONARIO.Clear()

    '        ' RECORREMOS EL FICHERO CONTACTOS.txt PARA LLENAR EL LISTBOX
    '        Dim filename As String = Application.StartupPath & "\Datos\BaseDatos\" & "CONTACTOS.txt"
    '        Dim fields As String()
    '        Dim delimiter As String = "$"
    '        Using parser As New Microsoft.VisualBasic.FileIO.TextFieldParser(filename)
    '            parser.SetDelimiters(delimiter)
    '            While Not parser.EndOfData
    '                ' Read in the fields for the current line
    '                fields = parser.ReadFields()
    '                ' Add code here to use data in fields variable.

    '                ListBox_Contactos.Items.Add(fields(1))

    '                ' CREAMOS UN ARRAY DE TIPO DICCIONARIO CON LOS VALORES QUE OBTENEMOS AL RECORRER EL ARCHIVO DE DATOS
    '                DICCIONARIO.Add(fields(1), fields(2))
    '            End While
    '        End Using
    '        'ORDENAMOS ALFABETICAMENTE EL LISTBOX
    '        ListBox_Contactos.Sorted = True
    '    End Sub


    '    Private Sub Button_VozPreparar_Click(sender As Object, e As EventArgs) Handles Button_VozPreparar.Click
    '        If TransferAudio Is Nothing Then
    '            TransferAudio = New Class_AudioTransfer
    '        End If
    '        TransferAudio.Form_Audio2_Load(TextBox_VozIp.Text.Trim, 9000)
    '    End Sub

    '    Private Sub Button_VozDesconectar_Click(sender As Object, e As EventArgs) Handles Button_VozDesconectar.Click
    '        TransferAudio.Button_VozComunicacionParar()
    '    End Sub

    '    Private Sub Button_VozConectar_Click(sender As Object, e As EventArgs) Handles Button_VozConectar.Click
    '        Try
    '            TransferAudio.Button_VozComunicacionIniciar()
    '        Catch ex As Exception

    '        End Try

    '    End Sub

    '    Private Sub Button_PausarEmision_Click(sender As Object, e As EventArgs) Handles Button_Emision.Click

    '    End Sub

    '    Private Sub Button_PausarEmision_MouseDown(sender As Object, e As EventArgs) Handles Button_Emision.MouseDown
    '        Try
    '            TransferAudio.Button_IniciarEmision_KeyPress()
    '        Catch ex As Exception

    '        End Try
    '    End Sub

    '    Private Sub Button_PausarEmision_MouseUp(sender As Object, e As EventArgs) Handles Button_Emision.MouseUp
    '        TransferAudio.Button_PausarEmision_KeyUp()
    '    End Sub

    '    Private Sub Button_VozEscuchar_Click(sender As Object, e As EventArgs) Handles Button_VozEscuchar.Click
    '        TransferAudio.ButtonEscucharIniciar_Click()
    '    End Sub

    '    Private Sub Button_VozNoEscuchar_Click(sender As Object, e As EventArgs) Handles Button_VozNoEscuchar.Click
    '        TransferAudio.ButtonEscucharParar_Click()
    '    End Sub

    '#End Region

    '#Region "Video"

    '    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++                VIDEO                 ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    '    Public Const WM_CAP As Short = &H400S
    '    Public Const WM_CAP_DLG_VIDEOFORMAT As Integer = WM_CAP + 41
    '    Public Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
    '    Public Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
    '    Public Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30
    '    Public Const WM_CAP_SEQUENCE As Integer = WM_CAP + 62
    '    Public Const WM_CAP_FILE_SAVEAS As Integer = WM_CAP + 23
    '    Public Const WM_CAP_SET_PREVIEW As Integer = WM_CAP + 50
    '    Public Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP + 52
    '    Public Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53
    '    Public Const WS_CHILD As Integer = &H40000000
    '    Public Const WS_VISIBLE As Integer = &H10000000
    '    Public Const SWP_NOMOVE As Short = &H2S
    '    Public Const SWP_NOSIZE As Short = 1
    '    Public Const SWP_NOZORDER As Short = &H4S
    '    Public Const HWND_BOTTOM As Short = 1
    '    Public Const WM_CAP_STOP As Integer = WM_CAP + 68

    '    Public iDevice As Integer = 0 ' Current device ID
    '    Public hHwnd As Integer ' Handle to preview window

    '    Public Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
    '        (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer,
    '        <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer

    '    Public Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer,
    '        ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer,
    '        ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

    '    Public Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean

    '    Public Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
    '        (ByVal lpszWindowName As String, ByVal dwStyle As Integer,
    '        ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer,
    '        ByVal nHeight As Short, ByVal hWndParent As Integer,
    '        ByVal nID As Integer) As Integer

    '    Public Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short,
    '        ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String,
    '        ByVal cbVer As Integer) As Boolean

    '    Dim DATOS As IDataObject
    '    Dim IMAGENCAMARA As Image
    '    Dim ENVIANTE As New UdpClient() 'WEBCAM
    '    Dim RECEPTOR As UdpClient 'New UdpClient(2001) 'WEBCAM

    '    'Open View
    '    Public Sub OpenPreviewWindow()
    '        If RECEPTOR Is Nothing Then
    '            RECEPTOR = New UdpClient(2001)
    '        End If
    '        ' Open Preview window in picturebox
    '        hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640,
    '           480, PictureboxVISOR.Handle.ToInt32, 0)

    '        ' Connect to device
    '        SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0)
    '        If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) Then
    '            'Set the preview scale
    '            SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)
    '            'Set the preview rate in milliseconds
    '            SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)
    '            'Start previewing the image from the camera
    '            SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)
    '            ' Resize window to fit in picturebox
    '            SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, PictureboxVISOR.Width, PictureboxVISOR.Height,
    '                    SWP_NOMOVE Or SWP_NOZORDER)
    '        Else
    '            ' Error connecting to device close window
    '            DestroyWindow(hHwnd)
    '        End If
    '    End Sub

    '    Private Sub Button_Iniciar_Click(sender As Object, e As EventArgs) Handles Button_VideoIniciar.Click
    '        RECEPTOR.Client.Blocking = False 'RECEPTOR NO BLOQUEADO
    '        Button_VideoIniciar.Enabled = False
    '        'Load And Capture Device
    '        OpenPreviewWindow()
    '    End Sub


    '    Private Sub RELOJWEBCAM_Tick(sender As System.Object, e As System.EventArgs) Handles TimerWEBCAM.Tick

    '        Try

    '            ' Copy image to clipboard
    '            SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)
    '            ' Get image from clipboard and convert it to a bitmap
    '            DATOS = Clipboard.GetDataObject()

    '            IMAGENCAMARA = CType(DATOS.GetData(GetType(System.Drawing.Bitmap)), Image)
    '            ENVIANTE.Connect(TextBox_VozIp.Text, 2001) 'SE CONECTA CON EL RECEPTOR
    '            Dim ARRAY As New MemoryStream()
    '            IMAGENCAMARA.Save(ARRAY, Imaging.ImageFormat.Jpeg)
    '            Dim IMAGEN_ARRAY As Byte() = ARRAY.ToArray
    '            ENVIANTE.Send(IMAGEN_ARRAY, IMAGEN_ARRAY.Length) 'ENVIA EL MENSAJE
    '        Catch ex As Exception

    '        End Try

    '        Try
    '            Dim IP As IPEndPoint = New IPEndPoint(IPAddress.Any, 0) 'RECIBIRA DESDE CUALQUIER IP, POR CUALQUIER PUERTO
    '            Dim RECIBEMENSAJE As Byte() = RECEPTOR.Receive(IP) 'RECIBE EL MENSAJE EN BYTES
    '            Dim IMAGEN As New MemoryStream(RECIBEMENSAJE)
    '            Dim IMAGENRECIBIDA As Image = Image.FromStream(IMAGEN)
    '            PictureBoxRECIBIR.Image = IMAGENRECIBIDA
    '        Catch ex As Exception

    '        End Try
    '    End Sub


    '    Private Sub Button_VideoConectar_Click(sender As Object, e As EventArgs) Handles Button_VideoConectar.Click
    '        TimerWEBCAM.Enabled = True
    '    End Sub

    '    Private Sub DESCONECTAR_Click(sender As Object, e As EventArgs) Handles Button_VideoDesconectar.Click
    '        TimerWEBCAM.Enabled = False
    '    End Sub

    '#End Region





End Class