Public Class Form_ServidorTCP


    Delegate Sub SetItemsListView1()
    Delegate Sub DelegateMensajeNuevo(ByVal MSG As String, ByVal Nick As String)
    Delegate Sub DelegateMensaje(ByVal MSG As String)

    Dim Encriptador As New Class_Encriptar

#Region "Formulaio Minimizado y notificacion"

    Private Sub NotifyIcon1_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        If (Me.WindowState = FormWindowState.Minimized) Then
            Me.WindowState = FormWindowState.Normal
            Me.ShowInTaskbar = True
        End If

        ' Activate the form.
        Me.Activate()
    End Sub

    Private Sub ToolStripMenuItem_Abrir_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem_Abrir.Click
        If (Me.WindowState = FormWindowState.Minimized) Then Me.WindowState = FormWindowState.Normal
        Me.ShowInTaskbar = False
    End Sub

    Private Sub ToolStripMenuItem_Salir_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem_Salir.Click
        Me.Close()
    End Sub

 
    Private Sub Form_ChatTCP_SizeChanged(sender As Object, e As System.EventArgs) Handles Me.SizeChanged
        If (Me.WindowState = FormWindowState.Minimized) Then
            Me.ShowInTaskbar = False
        Else
            Me.ShowInTaskbar = True
        End If
    End Sub

#End Region

#Region "Configuracion"
    Dim Cuenta As Int16 = 0

    Private Sub Button_ObtenerIP_Click(sender As System.Object, e As System.EventArgs) Handles Button_ObtenerIP.Click
        Dim Revisiones As Int16 = 0
        Try
            Dim lipa As System.Net.IPHostEntry = System.Net.Dns.Resolve(My.Computer.Name)
            TextBox_IpLocal.Text = lipa.AddressList(Cuenta).ToString
            Cuenta = Cuenta + 1
        Catch ex As Exception
            Try
                Cuenta = 0
                Dim aaa As New System.Net.IPEndPoint(System.Net.IPAddress.Loopback, TextBox_PuertoTCP.Text)
                TextBox_IpLocal.Text = aaa.Address.ToString
            Catch ex2 As Exception
                RichTextBox_Log.AppendText(ex2.Message & vbCrLf)
                MsgBox(ex2.Message)
            End Try
        End Try
    End Sub

    Private Sub Button_Guardar_Click(sender As System.Object, e As System.EventArgs) Handles Button_Guardar.Click
        Try
            Dim Datos As New Class_XmlSocketServer.Archivo_Clientes
            Datos.IpLocalTCP = TextBox_IpLocal.Text
            Datos.IpDestinoTCP = TextBox_IpDestinoTCP.Text
            Datos.BufferTCP = TextBox_Buffer.Text.Trim
            Datos.PuertoTCP = TextBox_PuertoTCP.Text
            Datos.IpDestinoUDP = TextBox_IpDestinoUDP.Text
            Datos.PuertoUDP = TextBox_PuertoUDP.Text
            Datos.ConexionesMaximas = TextBox_ConexionesMax.Text.Trim
            Datos.Nick = TextBox_Nick.Text.Trim
            Class_XmlSocketServer.ModificarDatosServer(Datos)
        Catch ex As Exception
            RichTextBox_Log.AppendText(ex.Message & vbCrLf)
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

    Private Sub Form_ServidorTCP_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Try
            If ServidorTCP4.SocketTCP.Connected = True Then
                ServidorTCP4.Saliendo = True
                Try
                    Dim client0 As New System.Net.Sockets.TcpClient()
                    Dim serverEndPoint0 As New System.Net.IPEndPoint(System.Net.IPAddress.Parse(TextBox_IpLocal.Text), TextBox_PuertoTCP.Text)
                    client0.Connect(serverEndPoint0)
                    Dim clientStream0 As System.Net.Sockets.NetworkStream = client0.GetStream()
                    Dim buffer0() As Byte = Module_SocketTcp.Comvertir_StringToByte("Saliendo <EOF>")
                    clientStream0.Write(buffer0, 0, buffer0.Length)
                    clientStream0.Flush()
                Catch ex As Exception

                End Try
                Try
                    ServidorTCP4.broadcast(NET_Cavecera & NET_Desconexion & NET_FinCadena, "SERVER", True)
                Catch ex As Exception

                End Try



                System.Threading.Thread.Sleep(2000)

                For Each Operador In OperadoresRed_ListaTCP
                    Try
                        Operador.ClienteConectado = False
                        Operador.ctThread.Abort()
                    Catch ex As Exception
                        RichTextBox_Log.AppendText(ex.Message & vbCrLf)
                    End Try

                Next
                '  ServidorTCP4.DesConectar()
                ServidorTCP4.SocketTCP.Close()
                ServidorTCP4.ThreadListen.Join()
                ServidorTCP4.ThreadListen.Abort()

                Button_Conectar.Text = "Conectar"

            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Form_ChatServerTCP_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try

            AddHandler ServidorTCP4.OperadoresCambio, AddressOf CambiosListaOperadores
            AddHandler ServidorTCP4.MensajeNuevo, AddressOf MensajeNuevo
            AddHandler ServidorTCP4.Mensaje, AddressOf Mensaje

            With Class_XmlSocketServer.ObtenerDatosServer()
                TextBox_IpLocal.Text = .IpLocalTCP
                TextBox_IpDestinoTCP.Text = .IpDestinoTCP
                TextBox_Buffer.Text = .BufferTCP
                TextBox_PuertoTCP.Text = .PuertoTCP
                TextBox_IpDestinoUDP.Text = .IpDestinoUDP
                TextBox_PuertoUDP.Text = .PuertoUDP
                TextBox_ConexionesMax.Text = .ConexionesMaximas
                TextBox_Nick.Text = .Nick
            End With


            Dim imageListLarge As New ImageList()
            imageListLarge.ImageSize = New Size(16, 16)
            imageListLarge.Images.Add(Bitmap.FromFile(My.Application.Info.DirectoryPath & "\Datos\Ico\TagRed.ico"))
            imageListLarge.Images.Add(Bitmap.FromFile(My.Application.Info.DirectoryPath & "\Datos\Ico\TagYellow.ico"))
            imageListLarge.Images.Add(Bitmap.FromFile(My.Application.Info.DirectoryPath & "\Datos\Ico\TagBlack.ico"))
            imageListLarge.Images.Add(Bitmap.FromFile(My.Application.Info.DirectoryPath & "\Datos\Ico\TagGreen.ico"))
            'Icono = My.Application.Info.DirectoryPath & "\Dateado\Ico\TagRed.ico"
            'Icono = My.Application.Info.DirectoryPath & "\Dateado\Ico\TagYellow.ico"
            'Icono = My.Application.Info.DirectoryPath & "\Dateado\Ico\TagBlack.ico"
            'Icono = My.Application.Info.DirectoryPath & "\Dateado\Ico\TagGreen.ico"
            ListView1.LargeImageList = imageListLarge



        Catch ex As Exception
            RichTextBox_Log.AppendText(ex.Message & vbCrLf)
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button_Conectar_Click(sender As System.Object, e As System.EventArgs) Handles Button_Conectar.Click

        Try
            If Button_Conectar.Text = "Conectar" Then

                ServidorTCP4.Conectar()
                Button_Conectar.Text = "Desconectar"
            Else
                ServidorTCP4.Saliendo = True
                Try
                    Dim client0 As New System.Net.Sockets.TcpClient()
                    Dim serverEndPoint0 As New System.Net.IPEndPoint(System.Net.IPAddress.Parse(TextBox_IpLocal.Text), TextBox_PuertoTCP.Text)
                    client0.Connect(serverEndPoint0)
                    Dim clientStream0 As System.Net.Sockets.NetworkStream = client0.GetStream()
                    Dim buffer0() As Byte = Module_SocketTcp.Comvertir_StringToByte("Saliendo <EOF>")
                    clientStream0.Write(buffer0, 0, buffer0.Length)
                    clientStream0.Flush()
                Catch ex As Exception

                End Try
                Try
                    ServidorTCP4.broadcast(NET_Cavecera & NET_Desconexion & NET_FinCadena, "SERVER", True)
                Catch ex As Exception

                End Try



                System.Threading.Thread.Sleep(2000)

                For Each Operador In OperadoresRed_ListaTCP
                    Try
                        Operador.ClienteConectado = False
                        Operador.ctThread.Abort()
                    Catch ex As Exception
                        RichTextBox_Log.AppendText(ex.Message & vbCrLf)
                    End Try

                Next
                '  ServidorTCP4.DesConectar()
                ServidorTCP4.SocketTCP.Close()
                ServidorTCP4.ThreadListen.Join()
                ServidorTCP4.ThreadListen.Abort()

                Button_Conectar.Text = "Conectar"




            End If

        Catch ex As Exception
            RichTextBox_Log.AppendText(ex.Message & vbCrLf)
        End Try

    End Sub

    Private Sub Button_EnviarMensaje_Click(sender As System.Object, e As System.EventArgs) Handles Button_EnviarMensaje.Click
        Try

            If ListView1.SelectedItems.Count <= 0 Then
                '   Module_SocketTcp.ServidorTCP4.broadcast(NET_Cavecera & NET_Mensaje & Encriptador.desencriptar128BitRijndael(TextBox_Mensaje.Text.Trim, "w06Aay"), "Server", True)


                Module_SocketTcp.ServidorTCP4.broadcast(NET_Cavecera & NET_Mensaje & Class_Encriptar.encriptar128BitRijndael(TextBox_Mensaje.Text) & NET_FinCadena, "Server", True)
                RichTextBox_MensajesChat.AppendText("Server : " & TextBox_Mensaje.Text.Trim & vbCr)

            Else
                For indice As Integer = 0 To ListView1.SelectedItems.Count - 1
                    Dim operador As Class_OperadorRed_TCP = ServidorTCP4.ObtenerOperadorRed_IP(ListView1.SelectedItems.Item(indice).Name)
                    '    Module_SocketTcp.ServidorTCP4.EnviarMensaje1(NET_Cavecera & NET_Mensaje & Encriptador.desencriptar128BitRijndael(TextBox_Mensaje.Text.Trim, "w06Aay"), operador.SocketCliente)
                    Module_SocketTcp.ServidorTCP4.EnviarMensaje1(NET_Cavecera & NET_Mensaje & Class_Encriptar.encriptar128BitRijndael(TextBox_Mensaje.Text) & NET_FinCadena, operador.SocketCliente)
                    RichTextBox_MensajesChat.AppendText("Server : " & TextBox_Mensaje.Text.Trim & vbCr)
                Next

            End If

        Catch ex As Exception
            RichTextBox_Log.AppendText(ex.Message & vbCrLf)
        End Try
    End Sub

    Private Sub MensajeNuevo(MSG As String, Nick As String)
        Try
            If RichTextBox_MensajesChat.InvokeRequired Then
                ' callingThread = System.Threading.Thread.CurrentThread.ManagedThreadId()
                Dim d As New DelegateMensajeNuevo(AddressOf MensajeNuevo)
                '       Call RichTextBox_MensajesChat.Invoke(d)
                Call RichTextBox_MensajesChat.Invoke(d, New Object() {MSG, Nick})
            Else
                '  Encriptador.encriptar128BitRijndael(MSG, "w06Aay")

                '  RichTextBox_MensajesChat.AppendText(Nick & ": " & Encriptador.encriptar128BitRijndael(MSG, "w06Aay") & vbCr)
                '  RichTextBox_MensajesChat.AppendText(Nick & ": " & MSG & vbCrLf)
                RichTextBox_MensajesChat.AppendText(MSG & vbCrLf)
            End If
        Catch ex As Exception
            RichTextBox_Log.AppendText(ex.Message & vbCrLf)
        End Try

    End Sub


    Private Sub Mensaje(MSG As String)
        If RichTextBox_MensajesChat.InvokeRequired Then
            ' callingThread = System.Threading.Thread.CurrentThread.ManagedThreadId()
            Dim d As New DelegateMensaje(AddressOf Mensaje)
            '       Call RichTextBox_MensajesChat.Invoke(d)
            Call RichTextBox_MensajesChat.Invoke(d, New Object() {MSG})
        Else

            RichTextBox_MensajesChat.AppendText(MSG & vbCr)

            RichTextBox_MensajesChat.SelectionStart = RichTextBox_MensajesChat.Text.Length
            RichTextBox_MensajesChat.ScrollToCaret()
            '  RichTextBox_MensajesChat.AppendText(Encriptador.encriptar128BitRijndael(MSG, "w06Aay") & vbCr)
        End If
    End Sub

    Private Sub Button_ActulizaOperadores_Click(sender As Object, e As EventArgs) Handles Button_ActulizaOperadores.Click
        Try
            CambiosListaOperadores()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CambiosListaOperadores()
        Try
            If ListView1.InvokeRequired Then
                ' callingThread = System.Threading.Thread.CurrentThread.ManagedThreadId()
                Dim d As New SetItemsListView1(AddressOf CambiosListaOperadores)
                Call ListView1.Invoke(d)
            Else
                ListView1.Items.Clear()
                For Each Operadorer As Class_OperadorRed_TCP In OperadoresRed_ListaTCP


                    Dim Texto As String
                    'Dim Nombre As String
                    Dim Icono As String
                    Dim IconoNum As Integer
                    If Operadorer.Nick.Trim <> String.Empty Then
                        Texto = Operadorer.Nick
                    Else
                        Texto = Operadorer.DirecciónDestino.ToString
                    End If

                    If Operadorer.Baneado = True Then
                        Icono = My.Application.Info.DirectoryPath & "\Datos\Ico\TagRed.ico"
                        IconoNum = 0
                    ElseIf Operadorer.Acepatado = False Then
                        Icono = My.Application.Info.DirectoryPath & "\Datos\Ico\TagYellow.ico"
                        IconoNum = 1
                    ElseIf Operadorer.SocketCliente.Connected = False Then
                        Icono = My.Application.Info.DirectoryPath & "\Datos\Ico\TagBlack.ico"
                        IconoNum = 2
                    Else
                        Icono = My.Application.Info.DirectoryPath & "\Datos\Ico\TagGreen.ico"
                        IconoNum = 3
                    End If
                    Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(Texto, IconoNum) '("", "(ninguno)")
                    ListViewItem1.Name = Operadorer.DirecciónDestino.ToString
                    '   ListViewItem1.ImageKey = IconoNum

                    ' ListView2.Items.Add(ListViewItem1)

                    ListView1.Items.Add(ListViewItem1)

                Next
            End If
        Catch ex As Exception
            RichTextBox_Log.AppendText(ex.Message & vbCrLf)
        End Try
    End Sub


    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub AceptarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AceptarToolStripMenuItem.Click
        Try

            Dim operador As Class_OperadorRed_TCP = ServidorTCP4.ObtenerOperadorRed_IP(ListView1.SelectedItems.Item(0).Name)
            operador.Acepatado = True
            CambiosListaOperadores()
        Catch ex As Exception
            RichTextBox_Log.AppendText(ex.Message & vbCrLf)
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ExpulsarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExpulsarToolStripMenuItem.Click
        Try
            Dim operador As Class_OperadorRed_TCP = ServidorTCP4.ObtenerOperadorRed_IP(ListView1.SelectedItems.Item(0).Name)
            operador.Acepatado = False
            operador.ctThread.Abort()
            operador.SocketCliente.Close()
            CambiosListaOperadores()
        Catch ex As Exception
            RichTextBox_Log.AppendText(ex.Message)
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DesbanearToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DesbanearToolStripMenuItem.Click
        Try
            Dim operador As Class_OperadorRed_TCP = ServidorTCP4.ObtenerOperadorRed_Nick(ListView1.SelectedItems.Item(0).Text)
            operador.Baneado = False
            operador.ctThread.Abort()
            operador.SocketCliente.Close()
            CambiosListaOperadores()
        Catch ex As Exception
            RichTextBox_Log.AppendText(ex.Message)
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BanearToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BanearToolStripMenuItem.Click
        Try
            Dim operador As Class_OperadorRed_TCP = ServidorTCP4.ObtenerOperadorRed_Nick(ListView1.SelectedItems.Item(0).Text)
            operador.Baneado = True
            operador.ctThread.Abort()
            operador.SocketCliente.Close()
            CambiosListaOperadores()
        Catch ex As Exception
            RichTextBox_Log.AppendText(ex.Message)
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EliminarToolStripMenuItem.Click
        Try
            Dim operador As Class_OperadorRed_TCP = ServidorTCP4.ObtenerOperadorRed_Nick(ListView1.SelectedItems.Item(0).Text)
            operador.SocketCliente.Close()
            OperadoresRed_ListaTCP.Remove(operador)

            ListView1.Items.Clear()

            'For Each Operadorer As Class_OperadorRed_TCP In OperadoresRed_ListaTCP
            '    ListView1.Items.Add(Operadorer.DirecciónDestino.ToString)
            'Next
            CambiosListaOperadores()
        Catch ex As Exception
            RichTextBox_Log.AppendText(ex.Message)
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        Form_ClienteTCP.Show()
    End Sub

    Private Sub Button_Inicio_Click(sender As Object, e As EventArgs) Handles Button_Inicio.Click
        Try


            If FormularioInicio.Cargado = False Then
                FormularioInicio = New Form_Inicio
                FormularioInicio.CargaDatos()
                FormularioInicio.Show()
            Else
                FormularioInicio.CargaDatos()
                FormularioInicio.Show()
            End If
        Catch ex As Exception
            RichTextBox_Log.AppendText(ex.Message)
            MsgBox(ex.Message)
        End Try


    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button_ModInfoOperador.Click
        If ListView1.View = View.Details Then
            ListView1.View = View.LargeIcon
        ElseIf ListView1.View = View.LargeIcon Then
            ListView1.View = View.List
        ElseIf ListView1.View = View.List Then
            ListView1.View = View.SmallIcon
        ElseIf ListView1.View = View.SmallIcon Then
            ListView1.View = View.Tile
        ElseIf ListView1.View = View.Tile Then
            ListView1.View = View.Details
        Else
            ListView1.View = View.Details
        End If

    End Sub

    Private Sub Label_Buffer_Click(sender As Object, e As EventArgs) Handles Label_Buffer.Click
        Try
            Dim Buffer As Integer = TextBox_Buffer.Text
            If Buffer > 128 Then
                ServidorTCP4.BufferTamaño = Buffer
            Else
                MsgBox("El tamaño del buffer debe ser mayor a 128")
            End If

        Catch ex As Exception
            RichTextBox_Log.AppendText(ex.Message)
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button_VaciarMensajes_Click(sender As Object, e As EventArgs) Handles Button_VaciarMensajes.Click
        Try
            RichTextBox_MensajesChat.Text = String.Empty
        Catch ex As Exception
            RichTextBox_Log.AppendText(ex.Message)
        End Try
    End Sub



    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            TextBox_Mensaje.Text = Class_Encriptar.encriptar128BitRijndael(TextBox_Mensaje.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            TextBox_Mensaje.Text = Class_Encriptar.desencriptar128BitRijndael(TextBox_Mensaje.Text)
        Catch ex As Exception

        End Try
    End Sub

End Class