<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_ServerHack
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("", "(ninguno)")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_ServerHack))
        Me.Button_Inicio = New System.Windows.Forms.Button()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button_Conectar = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button_ActulizaOperadores = New System.Windows.Forms.Button()
        Me.Button_VaciarMensajes = New System.Windows.Forms.Button()
        Me.Button_EnviarMensaje = New System.Windows.Forms.Button()
        Me.TextBox_Mensaje = New System.Windows.Forms.TextBox()
        Me.Label_UsuariosChat = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Label_MensajesChat = New System.Windows.Forms.Label()
        Me.Button_ModInfoOperador = New System.Windows.Forms.Button()
        Me.RichTextBox_MensajesChat = New System.Windows.Forms.RichTextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.RichTextBox_Log = New System.Windows.Forms.RichTextBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupBox_Informacion = New System.Windows.Forms.GroupBox()
        Me.Label_Buffer = New System.Windows.Forms.Label()
        Me.TextBox_Buffer = New System.Windows.Forms.TextBox()
        Me.TextBox_Nick = New System.Windows.Forms.TextBox()
        Me.Label_Nombre = New System.Windows.Forms.Label()
        Me.Button_Guardar = New System.Windows.Forms.Button()
        Me.GroupBox_UDP = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label_PuertoUDP = New System.Windows.Forms.Label()
        Me.TextBox_IpDestinoUDP = New System.Windows.Forms.TextBox()
        Me.TextBox_PuertoUDP = New System.Windows.Forms.TextBox()
        Me.GroupBox_TCP = New System.Windows.Forms.GroupBox()
        Me.Label_ConecsionesMax = New System.Windows.Forms.Label()
        Me.TextBox_ConexionesMax = New System.Windows.Forms.TextBox()
        Me.Button_ObtenerIP = New System.Windows.Forms.Button()
        Me.Label_IpLocal = New System.Windows.Forms.Label()
        Me.TextBox_IpLocal = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox_IpDestinoTCP = New System.Windows.Forms.TextBox()
        Me.Label_PuertoTCP = New System.Windows.Forms.Label()
        Me.TextBox_PuertoTCP = New System.Windows.Forms.TextBox()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip_NotifyIcon = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem_Abrir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Salir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip_Operadores = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AceptarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesbanearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BanearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExpulsarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox_Informacion.SuspendLayout()
        Me.GroupBox_UDP.SuspendLayout()
        Me.GroupBox_TCP.SuspendLayout()
        Me.ContextMenuStrip_NotifyIcon.SuspendLayout()
        Me.ContextMenuStrip_Operadores.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_Inicio
        '
        Me.Button_Inicio.Location = New System.Drawing.Point(186, 12)
        Me.Button_Inicio.Name = "Button_Inicio"
        Me.Button_Inicio.Size = New System.Drawing.Size(75, 23)
        Me.Button_Inicio.TabIndex = 31
        Me.Button_Inicio.Text = "Inicio"
        Me.Button_Inicio.UseVisualStyleBackColor = True
        '
        'ListView2
        '
        Me.ListView2.HideSelection = False
        ListViewItem2.Tag = "ddd"
        Me.ListView2.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem2})
        Me.ListView2.Location = New System.Drawing.Point(604, 90)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(121, 97)
        Me.ListView2.TabIndex = 30
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.SmallIcon
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(105, 12)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 29
        Me.Button7.Text = "Cliente"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button_Conectar
        '
        Me.Button_Conectar.Location = New System.Drawing.Point(12, 12)
        Me.Button_Conectar.Name = "Button_Conectar"
        Me.Button_Conectar.Size = New System.Drawing.Size(75, 23)
        Me.Button_Conectar.TabIndex = 28
        Me.Button_Conectar.Text = "Conectar"
        Me.Button_Conectar.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(6, 41)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(580, 396)
        Me.TabControl1.TabIndex = 27
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.Button_ActulizaOperadores)
        Me.TabPage1.Controls.Add(Me.Button_VaciarMensajes)
        Me.TabPage1.Controls.Add(Me.Button_EnviarMensaje)
        Me.TabPage1.Controls.Add(Me.TextBox_Mensaje)
        Me.TabPage1.Controls.Add(Me.Label_UsuariosChat)
        Me.TabPage1.Controls.Add(Me.ListView1)
        Me.TabPage1.Controls.Add(Me.Label_MensajesChat)
        Me.TabPage1.Controls.Add(Me.Button_ModInfoOperador)
        Me.TabPage1.Controls.Add(Me.RichTextBox_MensajesChat)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(572, 370)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Chat"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(309, 328)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 23
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(218, 328)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button_ActulizaOperadores
        '
        Me.Button_ActulizaOperadores.Location = New System.Drawing.Point(490, 11)
        Me.Button_ActulizaOperadores.Name = "Button_ActulizaOperadores"
        Me.Button_ActulizaOperadores.Size = New System.Drawing.Size(35, 23)
        Me.Button_ActulizaOperadores.TabIndex = 21
        Me.Button_ActulizaOperadores.Text = "Actuliza operadores"
        Me.Button_ActulizaOperadores.UseVisualStyleBackColor = True
        '
        'Button_VaciarMensajes
        '
        Me.Button_VaciarMensajes.Font = New System.Drawing.Font("Microsoft Sans Serif", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_VaciarMensajes.Location = New System.Drawing.Point(275, 16)
        Me.Button_VaciarMensajes.Name = "Button_VaciarMensajes"
        Me.Button_VaciarMensajes.Size = New System.Drawing.Size(27, 17)
        Me.Button_VaciarMensajes.TabIndex = 6
        Me.Button_VaciarMensajes.Text = "X"
        Me.Button_VaciarMensajes.UseVisualStyleBackColor = True
        '
        'Button_EnviarMensaje
        '
        Me.Button_EnviarMensaje.Location = New System.Drawing.Point(254, 241)
        Me.Button_EnviarMensaje.Name = "Button_EnviarMensaje"
        Me.Button_EnviarMensaje.Size = New System.Drawing.Size(49, 64)
        Me.Button_EnviarMensaje.TabIndex = 5
        Me.Button_EnviarMensaje.Text = "Enviar"
        Me.Button_EnviarMensaje.UseVisualStyleBackColor = True
        '
        'TextBox_Mensaje
        '
        Me.TextBox_Mensaje.Location = New System.Drawing.Point(6, 241)
        Me.TextBox_Mensaje.Multiline = True
        Me.TextBox_Mensaje.Name = "TextBox_Mensaje"
        Me.TextBox_Mensaje.Size = New System.Drawing.Size(242, 64)
        Me.TextBox_Mensaje.TabIndex = 4
        '
        'Label_UsuariosChat
        '
        Me.Label_UsuariosChat.AutoSize = True
        Me.Label_UsuariosChat.Location = New System.Drawing.Point(310, 16)
        Me.Label_UsuariosChat.Name = "Label_UsuariosChat"
        Me.Label_UsuariosChat.Size = New System.Drawing.Size(89, 13)
        Me.Label_UsuariosChat.TabIndex = 3
        Me.Label_UsuariosChat.Text = "Usuarios del chat"
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.HoverSelection = True
        Me.ListView1.Location = New System.Drawing.Point(309, 35)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(257, 270)
        Me.ListView1.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListView1.TabIndex = 2
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Tile
        '
        'Label_MensajesChat
        '
        Me.Label_MensajesChat.AutoSize = True
        Me.Label_MensajesChat.Location = New System.Drawing.Point(10, 16)
        Me.Label_MensajesChat.Name = "Label_MensajesChat"
        Me.Label_MensajesChat.Size = New System.Drawing.Size(76, 13)
        Me.Label_MensajesChat.TabIndex = 1
        Me.Label_MensajesChat.Text = "Mensajes chat"
        '
        'Button_ModInfoOperador
        '
        Me.Button_ModInfoOperador.Location = New System.Drawing.Point(531, 11)
        Me.Button_ModInfoOperador.Name = "Button_ModInfoOperador"
        Me.Button_ModInfoOperador.Size = New System.Drawing.Size(35, 23)
        Me.Button_ModInfoOperador.TabIndex = 20
        Me.Button_ModInfoOperador.Text = "Info operador"
        Me.Button_ModInfoOperador.UseVisualStyleBackColor = True
        '
        'RichTextBox_MensajesChat
        '
        Me.RichTextBox_MensajesChat.Location = New System.Drawing.Point(6, 35)
        Me.RichTextBox_MensajesChat.Name = "RichTextBox_MensajesChat"
        Me.RichTextBox_MensajesChat.Size = New System.Drawing.Size(296, 200)
        Me.RichTextBox_MensajesChat.TabIndex = 0
        Me.RichTextBox_MensajesChat.Text = ""
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(572, 370)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Conectar"
        Me.TabPage2.ToolTipText = "Conectar con servidor"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.RichTextBox_Log)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(572, 370)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Log"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'RichTextBox_Log
        '
        Me.RichTextBox_Log.Location = New System.Drawing.Point(33, 6)
        Me.RichTextBox_Log.Name = "RichTextBox_Log"
        Me.RichTextBox_Log.Size = New System.Drawing.Size(421, 299)
        Me.RichTextBox_Log.TabIndex = 0
        Me.RichTextBox_Log.Text = ""
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox_Informacion)
        Me.TabPage4.Controls.Add(Me.Button_Guardar)
        Me.TabPage4.Controls.Add(Me.GroupBox_UDP)
        Me.TabPage4.Controls.Add(Me.GroupBox_TCP)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(572, 370)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Configuraciones"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox_Informacion
        '
        Me.GroupBox_Informacion.Controls.Add(Me.Label_Buffer)
        Me.GroupBox_Informacion.Controls.Add(Me.TextBox_Buffer)
        Me.GroupBox_Informacion.Controls.Add(Me.TextBox_Nick)
        Me.GroupBox_Informacion.Controls.Add(Me.Label_Nombre)
        Me.GroupBox_Informacion.Location = New System.Drawing.Point(271, 141)
        Me.GroupBox_Informacion.Name = "GroupBox_Informacion"
        Me.GroupBox_Informacion.Size = New System.Drawing.Size(295, 129)
        Me.GroupBox_Informacion.TabIndex = 5
        Me.GroupBox_Informacion.TabStop = False
        Me.GroupBox_Informacion.Text = "Informacion"
        '
        'Label_Buffer
        '
        Me.Label_Buffer.AutoSize = True
        Me.Label_Buffer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label_Buffer.Location = New System.Drawing.Point(14, 52)
        Me.Label_Buffer.Name = "Label_Buffer"
        Me.Label_Buffer.Size = New System.Drawing.Size(35, 13)
        Me.Label_Buffer.TabIndex = 3
        Me.Label_Buffer.Text = "Buffer"
        '
        'TextBox_Buffer
        '
        Me.TextBox_Buffer.Location = New System.Drawing.Point(64, 49)
        Me.TextBox_Buffer.Name = "TextBox_Buffer"
        Me.TextBox_Buffer.Size = New System.Drawing.Size(192, 20)
        Me.TextBox_Buffer.TabIndex = 2
        Me.TextBox_Buffer.Text = "10240"
        '
        'TextBox_Nick
        '
        Me.TextBox_Nick.Location = New System.Drawing.Point(64, 22)
        Me.TextBox_Nick.Name = "TextBox_Nick"
        Me.TextBox_Nick.Size = New System.Drawing.Size(192, 20)
        Me.TextBox_Nick.TabIndex = 1
        '
        'Label_Nombre
        '
        Me.Label_Nombre.AutoSize = True
        Me.Label_Nombre.Location = New System.Drawing.Point(14, 25)
        Me.Label_Nombre.Name = "Label_Nombre"
        Me.Label_Nombre.Size = New System.Drawing.Size(44, 13)
        Me.Label_Nombre.TabIndex = 0
        Me.Label_Nombre.Text = "Nombre"
        '
        'Button_Guardar
        '
        Me.Button_Guardar.Location = New System.Drawing.Point(26, 341)
        Me.Button_Guardar.Name = "Button_Guardar"
        Me.Button_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Button_Guardar.TabIndex = 4
        Me.Button_Guardar.Text = "Guardar"
        Me.Button_Guardar.UseVisualStyleBackColor = True
        '
        'GroupBox_UDP
        '
        Me.GroupBox_UDP.Controls.Add(Me.Label2)
        Me.GroupBox_UDP.Controls.Add(Me.Label_PuertoUDP)
        Me.GroupBox_UDP.Controls.Add(Me.TextBox_IpDestinoUDP)
        Me.GroupBox_UDP.Controls.Add(Me.TextBox_PuertoUDP)
        Me.GroupBox_UDP.Location = New System.Drawing.Point(16, 141)
        Me.GroupBox_UDP.Name = "GroupBox_UDP"
        Me.GroupBox_UDP.Size = New System.Drawing.Size(249, 129)
        Me.GroupBox_UDP.TabIndex = 1
        Me.GroupBox_UDP.TabStop = False
        Me.GroupBox_UDP.Text = "Conexion UDP"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "IP destino"
        '
        'Label_PuertoUDP
        '
        Me.Label_PuertoUDP.AutoSize = True
        Me.Label_PuertoUDP.Location = New System.Drawing.Point(23, 48)
        Me.Label_PuertoUDP.Name = "Label_PuertoUDP"
        Me.Label_PuertoUDP.Size = New System.Drawing.Size(38, 13)
        Me.Label_PuertoUDP.TabIndex = 1
        Me.Label_PuertoUDP.Text = "Puerto"
        '
        'TextBox_IpDestinoUDP
        '
        Me.TextBox_IpDestinoUDP.Location = New System.Drawing.Point(77, 19)
        Me.TextBox_IpDestinoUDP.Name = "TextBox_IpDestinoUDP"
        Me.TextBox_IpDestinoUDP.Size = New System.Drawing.Size(148, 20)
        Me.TextBox_IpDestinoUDP.TabIndex = 4
        '
        'TextBox_PuertoUDP
        '
        Me.TextBox_PuertoUDP.Location = New System.Drawing.Point(77, 45)
        Me.TextBox_PuertoUDP.Name = "TextBox_PuertoUDP"
        Me.TextBox_PuertoUDP.Size = New System.Drawing.Size(148, 20)
        Me.TextBox_PuertoUDP.TabIndex = 0
        '
        'GroupBox_TCP
        '
        Me.GroupBox_TCP.Controls.Add(Me.Label_ConecsionesMax)
        Me.GroupBox_TCP.Controls.Add(Me.TextBox_ConexionesMax)
        Me.GroupBox_TCP.Controls.Add(Me.Button_ObtenerIP)
        Me.GroupBox_TCP.Controls.Add(Me.Label_IpLocal)
        Me.GroupBox_TCP.Controls.Add(Me.TextBox_IpLocal)
        Me.GroupBox_TCP.Controls.Add(Me.Label1)
        Me.GroupBox_TCP.Controls.Add(Me.TextBox_IpDestinoTCP)
        Me.GroupBox_TCP.Controls.Add(Me.Label_PuertoTCP)
        Me.GroupBox_TCP.Controls.Add(Me.TextBox_PuertoTCP)
        Me.GroupBox_TCP.Location = New System.Drawing.Point(16, 6)
        Me.GroupBox_TCP.Name = "GroupBox_TCP"
        Me.GroupBox_TCP.Size = New System.Drawing.Size(351, 129)
        Me.GroupBox_TCP.TabIndex = 0
        Me.GroupBox_TCP.TabStop = False
        Me.GroupBox_TCP.Text = "Conexion TCP"
        '
        'Label_ConecsionesMax
        '
        Me.Label_ConecsionesMax.AutoSize = True
        Me.Label_ConecsionesMax.Location = New System.Drawing.Point(7, 100)
        Me.Label_ConecsionesMax.Name = "Label_ConecsionesMax"
        Me.Label_ConecsionesMax.Size = New System.Drawing.Size(105, 13)
        Me.Label_ConecsionesMax.TabIndex = 8
        Me.Label_ConecsionesMax.Text = "Conexiones maximas"
        '
        'TextBox_ConexionesMax
        '
        Me.TextBox_ConexionesMax.Location = New System.Drawing.Point(120, 97)
        Me.TextBox_ConexionesMax.Name = "TextBox_ConexionesMax"
        Me.TextBox_ConexionesMax.Size = New System.Drawing.Size(148, 20)
        Me.TextBox_ConexionesMax.TabIndex = 7
        '
        'Button_ObtenerIP
        '
        Me.Button_ObtenerIP.Location = New System.Drawing.Point(269, 17)
        Me.Button_ObtenerIP.Name = "Button_ObtenerIP"
        Me.Button_ObtenerIP.Size = New System.Drawing.Size(17, 22)
        Me.Button_ObtenerIP.TabIndex = 6
        Me.Button_ObtenerIP.Text = " Obtener IP"
        Me.Button_ObtenerIP.UseVisualStyleBackColor = True
        '
        'Label_IpLocal
        '
        Me.Label_IpLocal.AutoSize = True
        Me.Label_IpLocal.Location = New System.Drawing.Point(70, 22)
        Me.Label_IpLocal.Name = "Label_IpLocal"
        Me.Label_IpLocal.Size = New System.Drawing.Size(41, 13)
        Me.Label_IpLocal.TabIndex = 5
        Me.Label_IpLocal.Text = "Ip local"
        '
        'TextBox_IpLocal
        '
        Me.TextBox_IpLocal.Location = New System.Drawing.Point(120, 19)
        Me.TextBox_IpLocal.Name = "TextBox_IpLocal"
        Me.TextBox_IpLocal.Size = New System.Drawing.Size(148, 20)
        Me.TextBox_IpLocal.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(60, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "IP destino"
        '
        'TextBox_IpDestinoTCP
        '
        Me.TextBox_IpDestinoTCP.Location = New System.Drawing.Point(120, 71)
        Me.TextBox_IpDestinoTCP.Name = "TextBox_IpDestinoTCP"
        Me.TextBox_IpDestinoTCP.Size = New System.Drawing.Size(148, 20)
        Me.TextBox_IpDestinoTCP.TabIndex = 2
        '
        'Label_PuertoTCP
        '
        Me.Label_PuertoTCP.AutoSize = True
        Me.Label_PuertoTCP.Location = New System.Drawing.Point(76, 48)
        Me.Label_PuertoTCP.Name = "Label_PuertoTCP"
        Me.Label_PuertoTCP.Size = New System.Drawing.Size(38, 13)
        Me.Label_PuertoTCP.TabIndex = 1
        Me.Label_PuertoTCP.Text = "Puerto"
        '
        'TextBox_PuertoTCP
        '
        Me.TextBox_PuertoTCP.Location = New System.Drawing.Point(120, 45)
        Me.TextBox_PuertoTCP.Name = "TextBox_PuertoTCP"
        Me.TextBox_PuertoTCP.Size = New System.Drawing.Size(148, 20)
        Me.TextBox_PuertoTCP.TabIndex = 0
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipTitle = "Chat server"
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip_NotifyIcon
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Chat server"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip_NotifyIcon
        '
        Me.ContextMenuStrip_NotifyIcon.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_Abrir, Me.ToolStripMenuItem_Salir})
        Me.ContextMenuStrip_NotifyIcon.Name = "ContextMenuStrip_NotifyIcon"
        Me.ContextMenuStrip_NotifyIcon.Size = New System.Drawing.Size(101, 48)
        '
        'ToolStripMenuItem_Abrir
        '
        Me.ToolStripMenuItem_Abrir.Name = "ToolStripMenuItem_Abrir"
        Me.ToolStripMenuItem_Abrir.Size = New System.Drawing.Size(100, 22)
        Me.ToolStripMenuItem_Abrir.Text = "Abrir"
        '
        'ToolStripMenuItem_Salir
        '
        Me.ToolStripMenuItem_Salir.Name = "ToolStripMenuItem_Salir"
        Me.ToolStripMenuItem_Salir.Size = New System.Drawing.Size(100, 22)
        Me.ToolStripMenuItem_Salir.Text = "Salir"
        '
        'ContextMenuStrip_Operadores
        '
        Me.ContextMenuStrip_Operadores.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AceptarToolStripMenuItem, Me.DesbanearToolStripMenuItem, Me.BanearToolStripMenuItem, Me.ExpulsarToolStripMenuItem, Me.EliminarToolStripMenuItem})
        Me.ContextMenuStrip_Operadores.Name = "ContextMenuStrip_Operadores"
        Me.ContextMenuStrip_Operadores.Size = New System.Drawing.Size(181, 136)
        '
        'AceptarToolStripMenuItem
        '
        Me.AceptarToolStripMenuItem.Name = "AceptarToolStripMenuItem"
        Me.AceptarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AceptarToolStripMenuItem.Text = "Aceptar"
        '
        'DesbanearToolStripMenuItem
        '
        Me.DesbanearToolStripMenuItem.Name = "DesbanearToolStripMenuItem"
        Me.DesbanearToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DesbanearToolStripMenuItem.Text = "Desbanear"
        '
        'BanearToolStripMenuItem
        '
        Me.BanearToolStripMenuItem.Name = "BanearToolStripMenuItem"
        Me.BanearToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.BanearToolStripMenuItem.Text = "Banear"
        '
        'ExpulsarToolStripMenuItem
        '
        Me.ExpulsarToolStripMenuItem.Name = "ExpulsarToolStripMenuItem"
        Me.ExpulsarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExpulsarToolStripMenuItem.Text = "Expulsar"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'Form_ServerHack
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button_Inicio)
        Me.Controls.Add(Me.ListView2)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button_Conectar)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Form_ServerHack"
        Me.Text = "Form_ServerHack"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox_Informacion.ResumeLayout(False)
        Me.GroupBox_Informacion.PerformLayout()
        Me.GroupBox_UDP.ResumeLayout(False)
        Me.GroupBox_UDP.PerformLayout()
        Me.GroupBox_TCP.ResumeLayout(False)
        Me.GroupBox_TCP.PerformLayout()
        Me.ContextMenuStrip_NotifyIcon.ResumeLayout(False)
        Me.ContextMenuStrip_Operadores.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button_Inicio As Button
    Friend WithEvents ListView2 As ListView
    Friend WithEvents Button7 As Button
    Friend WithEvents Button_Conectar As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button_ActulizaOperadores As Button
    Friend WithEvents Button_VaciarMensajes As Button
    Friend WithEvents Button_EnviarMensaje As Button
    Friend WithEvents TextBox_Mensaje As TextBox
    Friend WithEvents Label_UsuariosChat As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents Label_MensajesChat As Label
    Friend WithEvents Button_ModInfoOperador As Button
    Friend WithEvents RichTextBox_MensajesChat As RichTextBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents RichTextBox_Log As RichTextBox
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents GroupBox_Informacion As GroupBox
    Friend WithEvents Label_Buffer As Label
    Friend WithEvents TextBox_Buffer As TextBox
    Friend WithEvents TextBox_Nick As TextBox
    Friend WithEvents Label_Nombre As Label
    Friend WithEvents Button_Guardar As Button
    Friend WithEvents GroupBox_UDP As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label_PuertoUDP As Label
    Friend WithEvents TextBox_IpDestinoUDP As TextBox
    Friend WithEvents TextBox_PuertoUDP As TextBox
    Friend WithEvents GroupBox_TCP As GroupBox
    Friend WithEvents Label_ConecsionesMax As Label
    Friend WithEvents TextBox_ConexionesMax As TextBox
    Friend WithEvents Button_ObtenerIP As Button
    Friend WithEvents Label_IpLocal As Label
    Friend WithEvents TextBox_IpLocal As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox_IpDestinoTCP As TextBox
    Friend WithEvents Label_PuertoTCP As Label
    Friend WithEvents TextBox_PuertoTCP As TextBox
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents ContextMenuStrip_NotifyIcon As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem_Abrir As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Salir As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip_Operadores As ContextMenuStrip
    Friend WithEvents AceptarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DesbanearToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BanearToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExpulsarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
End Class
