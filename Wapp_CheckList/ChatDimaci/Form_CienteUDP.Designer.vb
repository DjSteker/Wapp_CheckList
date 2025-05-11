<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_CienteUDP
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
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ComboBox_NarraAltavozes = New System.Windows.Forms.ComboBox()
        Me.CheckBox_NarraMenasajes = New System.Windows.Forms.CheckBox()
        Me.ComboBox_NarradorVoces = New System.Windows.Forms.ComboBox()
        Me.CheckBox_NarraConexiones = New System.Windows.Forms.CheckBox()
        Me.TimerWEBCAM = New System.Windows.Forms.Timer(Me.components)
        Me.Button_Inicio = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button_Emision = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RichTextBox_MensajesEntrada = New System.Windows.Forms.RichTextBox()
        Me.Button_EnviarMsj = New System.Windows.Forms.Button()
        Me.TextBox_Mensaje = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button_WakeOnLan = New System.Windows.Forms.Button()
        Me.Label_Ping = New System.Windows.Forms.Label()
        Me.Button_Ping = New System.Windows.Forms.Button()
        Me.Button_GuardarServer = New System.Windows.Forms.Button()
        Me.Label_Nick = New System.Windows.Forms.Label()
        Me.Label_Buffer = New System.Windows.Forms.Label()
        Me.TextBox_Buffer = New System.Windows.Forms.TextBox()
        Me.Button_EliminarCon = New System.Windows.Forms.Button()
        Me.Button_GuardarCon = New System.Windows.Forms.Button()
        Me.DataGridView_ListaServidores = New System.Windows.Forms.DataGridView()
        Me.Column_NombreServer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_IP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button_Conectar = New System.Windows.Forms.Button()
        Me.TextBox_Nick = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox_ConectarDestino_IP = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox_ConectarDestino_Puerto = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Button_VozEscuchar = New System.Windows.Forms.Button()
        Me.Button_VozNoEscuchar = New System.Windows.Forms.Button()
        Me.Button_VozConectar = New System.Windows.Forms.Button()
        Me.Button_VozDesconectar = New System.Windows.Forms.Button()
        Me.Button_VozPreparar = New System.Windows.Forms.Button()
        Me.TextBox_VozIp = New System.Windows.Forms.TextBox()
        Me.TextBox_Nombre = New System.Windows.Forms.TextBox()
        Me.Button_VozAgregar = New System.Windows.Forms.Button()
        Me.ListBox_Contactos = New System.Windows.Forms.ListBox()
        Me.Label_VozPuerto = New System.Windows.Forms.Label()
        Me.Label_VozIp = New System.Windows.Forms.Label()
        Me.Button_ActulizaOperadores = New System.Windows.Forms.Button()
        Me.Button_ModInfoOperador = New System.Windows.Forms.Button()
        Me.ListView_Operadores = New System.Windows.Forms.ListView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupBox_Narrador = New System.Windows.Forms.GroupBox()
        Me.Button_NarraProbar = New System.Windows.Forms.Button()
        Me.Button_NarraGuardar = New System.Windows.Forms.Button()
        Me.Label_NarraSalidas = New System.Windows.Forms.Label()
        Me.Label_NarraVoces = New System.Windows.Forms.Label()
        Me.Label_NarraVelocidad = New System.Windows.Forms.Label()
        Me.Label_NarraVolumen = New System.Windows.Forms.Label()
        Me.TrackBar_NarraVolumen = New System.Windows.Forms.TrackBar()
        Me.TrackBar_NarraRate = New System.Windows.Forms.TrackBar()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.PictureBoxRECIBIR = New System.Windows.Forms.PictureBox()
        Me.Button_VideoIniciar = New System.Windows.Forms.Button()
        Me.Button_VideoDesconectar = New System.Windows.Forms.Button()
        Me.Button_VideoConectar = New System.Windows.Forms.Button()
        Me.PictureboxVISOR = New System.Windows.Forms.PictureBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView_ListaServidores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox_Narrador.SuspendLayout()
        CType(Me.TrackBar_NarraVolumen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar_NarraRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.PictureBoxRECIBIR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureboxVISOR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox_NarraAltavozes
        '
        Me.ComboBox_NarraAltavozes.FormattingEnabled = True
        Me.ComboBox_NarraAltavozes.Location = New System.Drawing.Point(9, 296)
        Me.ComboBox_NarraAltavozes.Name = "ComboBox_NarraAltavozes"
        Me.ComboBox_NarraAltavozes.Size = New System.Drawing.Size(184, 21)
        Me.ComboBox_NarraAltavozes.TabIndex = 31
        Me.ToolTip1.SetToolTip(Me.ComboBox_NarraAltavozes, "Seleccion de altavoz")
        '
        'CheckBox_NarraMenasajes
        '
        Me.CheckBox_NarraMenasajes.AutoSize = True
        Me.CheckBox_NarraMenasajes.Location = New System.Drawing.Point(7, 43)
        Me.CheckBox_NarraMenasajes.Name = "CheckBox_NarraMenasajes"
        Me.CheckBox_NarraMenasajes.Size = New System.Drawing.Size(77, 17)
        Me.CheckBox_NarraMenasajes.TabIndex = 22
        Me.CheckBox_NarraMenasajes.Text = "Menasajes"
        Me.ToolTip1.SetToolTip(Me.CheckBox_NarraMenasajes, "Narrar mensajes recividos")
        Me.CheckBox_NarraMenasajes.UseVisualStyleBackColor = True
        '
        'ComboBox_NarradorVoces
        '
        Me.ComboBox_NarradorVoces.FormattingEnabled = True
        Me.ComboBox_NarradorVoces.Location = New System.Drawing.Point(7, 244)
        Me.ComboBox_NarradorVoces.Name = "ComboBox_NarradorVoces"
        Me.ComboBox_NarradorVoces.Size = New System.Drawing.Size(187, 21)
        Me.ComboBox_NarradorVoces.TabIndex = 26
        Me.ToolTip1.SetToolTip(Me.ComboBox_NarradorVoces, "Seleccion de voz")
        '
        'CheckBox_NarraConexiones
        '
        Me.CheckBox_NarraConexiones.AutoSize = True
        Me.CheckBox_NarraConexiones.Location = New System.Drawing.Point(7, 20)
        Me.CheckBox_NarraConexiones.Name = "CheckBox_NarraConexiones"
        Me.CheckBox_NarraConexiones.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox_NarraConexiones.TabIndex = 21
        Me.CheckBox_NarraConexiones.Text = "Conexiones"
        Me.ToolTip1.SetToolTip(Me.CheckBox_NarraConexiones, "Narrar conexiones")
        Me.CheckBox_NarraConexiones.UseVisualStyleBackColor = True
        '
        'Button_Inicio
        '
        Me.Button_Inicio.Location = New System.Drawing.Point(384, 8)
        Me.Button_Inicio.Name = "Button_Inicio"
        Me.Button_Inicio.Size = New System.Drawing.Size(46, 20)
        Me.Button_Inicio.TabIndex = 32
        Me.Button_Inicio.Text = "Inicio"
        Me.Button_Inicio.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(430, 430)
        Me.TabControl1.TabIndex = 31
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button_Emision)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.RichTextBox_MensajesEntrada)
        Me.TabPage1.Controls.Add(Me.Button_EnviarMsj)
        Me.TabPage1.Controls.Add(Me.TextBox_Mensaje)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(422, 404)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "    Chat    "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button_Emision
        '
        Me.Button_Emision.Location = New System.Drawing.Point(383, 300)
        Me.Button_Emision.Name = "Button_Emision"
        Me.Button_Emision.Size = New System.Drawing.Size(31, 23)
        Me.Button_Emision.TabIndex = 6
        Me.Button_Emision.Text = "Audio"
        Me.Button_Emision.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(340, 300)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(31, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RichTextBox_MensajesEntrada
        '
        Me.RichTextBox_MensajesEntrada.Location = New System.Drawing.Point(6, 6)
        Me.RichTextBox_MensajesEntrada.Name = "RichTextBox_MensajesEntrada"
        Me.RichTextBox_MensajesEntrada.Size = New System.Drawing.Size(408, 275)
        Me.RichTextBox_MensajesEntrada.TabIndex = 5
        Me.RichTextBox_MensajesEntrada.Text = ""
        '
        'Button_EnviarMsj
        '
        Me.Button_EnviarMsj.Location = New System.Drawing.Point(339, 326)
        Me.Button_EnviarMsj.Name = "Button_EnviarMsj"
        Me.Button_EnviarMsj.Size = New System.Drawing.Size(75, 70)
        Me.Button_EnviarMsj.TabIndex = 2
        Me.Button_EnviarMsj.Text = "Enviar"
        Me.Button_EnviarMsj.UseVisualStyleBackColor = True
        '
        'TextBox_Mensaje
        '
        Me.TextBox_Mensaje.Location = New System.Drawing.Point(6, 300)
        Me.TextBox_Mensaje.Multiline = True
        Me.TextBox_Mensaje.Name = "TextBox_Mensaje"
        Me.TextBox_Mensaje.Size = New System.Drawing.Size(327, 96)
        Me.TextBox_Mensaje.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button_WakeOnLan)
        Me.TabPage2.Controls.Add(Me.Label_Ping)
        Me.TabPage2.Controls.Add(Me.Button_Ping)
        Me.TabPage2.Controls.Add(Me.Button_GuardarServer)
        Me.TabPage2.Controls.Add(Me.Label_Nick)
        Me.TabPage2.Controls.Add(Me.Label_Buffer)
        Me.TabPage2.Controls.Add(Me.TextBox_Buffer)
        Me.TabPage2.Controls.Add(Me.Button_EliminarCon)
        Me.TabPage2.Controls.Add(Me.Button_GuardarCon)
        Me.TabPage2.Controls.Add(Me.DataGridView_ListaServidores)
        Me.TabPage2.Controls.Add(Me.Button_Conectar)
        Me.TabPage2.Controls.Add(Me.TextBox_Nick)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.TextBox_ConectarDestino_IP)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.TextBox_ConectarDestino_Puerto)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(422, 404)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Conexiones"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button_WakeOnLan
        '
        Me.Button_WakeOnLan.Location = New System.Drawing.Point(309, 344)
        Me.Button_WakeOnLan.Name = "Button_WakeOnLan"
        Me.Button_WakeOnLan.Size = New System.Drawing.Size(88, 23)
        Me.Button_WakeOnLan.TabIndex = 23
        Me.Button_WakeOnLan.Text = "WakeOnLan"
        Me.Button_WakeOnLan.UseVisualStyleBackColor = True
        '
        'Label_Ping
        '
        Me.Label_Ping.AutoSize = True
        Me.Label_Ping.Location = New System.Drawing.Point(254, 370)
        Me.Label_Ping.Name = "Label_Ping"
        Me.Label_Ping.Size = New System.Drawing.Size(10, 13)
        Me.Label_Ping.TabIndex = 22
        Me.Label_Ping.Text = "-"
        '
        'Button_Ping
        '
        Me.Button_Ping.Location = New System.Drawing.Point(228, 344)
        Me.Button_Ping.Name = "Button_Ping"
        Me.Button_Ping.Size = New System.Drawing.Size(75, 23)
        Me.Button_Ping.TabIndex = 17
        Me.Button_Ping.Text = "Ping"
        Me.Button_Ping.UseVisualStyleBackColor = True
        '
        'Button_GuardarServer
        '
        Me.Button_GuardarServer.Location = New System.Drawing.Point(7, 344)
        Me.Button_GuardarServer.Name = "Button_GuardarServer"
        Me.Button_GuardarServer.Size = New System.Drawing.Size(75, 33)
        Me.Button_GuardarServer.TabIndex = 15
        Me.Button_GuardarServer.Text = "Guardar"
        Me.Button_GuardarServer.UseVisualStyleBackColor = True
        '
        'Label_Nick
        '
        Me.Label_Nick.AutoSize = True
        Me.Label_Nick.Location = New System.Drawing.Point(254, 11)
        Me.Label_Nick.Name = "Label_Nick"
        Me.Label_Nick.Size = New System.Drawing.Size(29, 13)
        Me.Label_Nick.TabIndex = 19
        Me.Label_Nick.Text = "Nick"
        '
        'Label_Buffer
        '
        Me.Label_Buffer.AutoSize = True
        Me.Label_Buffer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label_Buffer.Location = New System.Drawing.Point(24, 83)
        Me.Label_Buffer.Name = "Label_Buffer"
        Me.Label_Buffer.Size = New System.Drawing.Size(35, 13)
        Me.Label_Buffer.TabIndex = 18
        Me.Label_Buffer.Text = "Buffer"
        '
        'TextBox_Buffer
        '
        Me.TextBox_Buffer.Location = New System.Drawing.Point(74, 80)
        Me.TextBox_Buffer.Name = "TextBox_Buffer"
        Me.TextBox_Buffer.Size = New System.Drawing.Size(130, 20)
        Me.TextBox_Buffer.TabIndex = 10
        Me.TextBox_Buffer.Text = "10240"
        '
        'Button_EliminarCon
        '
        Me.Button_EliminarCon.Location = New System.Drawing.Point(88, 344)
        Me.Button_EliminarCon.Name = "Button_EliminarCon"
        Me.Button_EliminarCon.Size = New System.Drawing.Size(75, 33)
        Me.Button_EliminarCon.TabIndex = 16
        Me.Button_EliminarCon.Text = "Eliminar"
        Me.Button_EliminarCon.UseVisualStyleBackColor = True
        '
        'Button_GuardarCon
        '
        Me.Button_GuardarCon.Location = New System.Drawing.Point(338, 66)
        Me.Button_GuardarCon.Name = "Button_GuardarCon"
        Me.Button_GuardarCon.Size = New System.Drawing.Size(75, 34)
        Me.Button_GuardarCon.TabIndex = 13
        Me.Button_GuardarCon.Text = "Guardar"
        Me.Button_GuardarCon.UseVisualStyleBackColor = True
        '
        'DataGridView_ListaServidores
        '
        Me.DataGridView_ListaServidores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_ListaServidores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column_NombreServer, Me.Column_IP, Me.Column_ID})
        Me.DataGridView_ListaServidores.Location = New System.Drawing.Point(6, 107)
        Me.DataGridView_ListaServidores.Name = "DataGridView_ListaServidores"
        Me.DataGridView_ListaServidores.Size = New System.Drawing.Size(408, 230)
        Me.DataGridView_ListaServidores.TabIndex = 14
        '
        'Column_NombreServer
        '
        Me.Column_NombreServer.HeaderText = "Nombre Server"
        Me.Column_NombreServer.Name = "Column_NombreServer"
        Me.Column_NombreServer.Width = 180
        '
        'Column_IP
        '
        Me.Column_IP.HeaderText = "IP"
        Me.Column_IP.Name = "Column_IP"
        '
        'Column_ID
        '
        Me.Column_ID.HeaderText = "ID"
        Me.Column_ID.Name = "Column_ID"
        '
        'Button_Conectar
        '
        Me.Button_Conectar.Location = New System.Drawing.Point(228, 67)
        Me.Button_Conectar.Name = "Button_Conectar"
        Me.Button_Conectar.Size = New System.Drawing.Size(104, 34)
        Me.Button_Conectar.TabIndex = 12
        Me.Button_Conectar.Text = "Conectar"
        Me.Button_Conectar.UseVisualStyleBackColor = True
        '
        'TextBox_Nick
        '
        Me.TextBox_Nick.Location = New System.Drawing.Point(257, 27)
        Me.TextBox_Nick.Name = "TextBox_Nick"
        Me.TextBox_Nick.Size = New System.Drawing.Size(140, 20)
        Me.TextBox_Nick.TabIndex = 11
        Me.TextBox_Nick.Text = "Nick de cliente"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "IP destino"
        '
        'TextBox_ConectarDestino_IP
        '
        Me.TextBox_ConectarDestino_IP.Location = New System.Drawing.Point(74, 53)
        Me.TextBox_ConectarDestino_IP.Name = "TextBox_ConectarDestino_IP"
        Me.TextBox_ConectarDestino_IP.Size = New System.Drawing.Size(130, 20)
        Me.TextBox_ConectarDestino_IP.TabIndex = 9
        Me.TextBox_ConectarDestino_IP.Text = "192.168.1.100"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Puerto"
        '
        'TextBox_ConectarDestino_Puerto
        '
        Me.TextBox_ConectarDestino_Puerto.Location = New System.Drawing.Point(74, 27)
        Me.TextBox_ConectarDestino_Puerto.Name = "TextBox_ConectarDestino_Puerto"
        Me.TextBox_ConectarDestino_Puerto.Size = New System.Drawing.Size(130, 20)
        Me.TextBox_ConectarDestino_Puerto.TabIndex = 8
        Me.TextBox_ConectarDestino_Puerto.Text = "27033"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Button_VozEscuchar)
        Me.TabPage3.Controls.Add(Me.Button_VozNoEscuchar)
        Me.TabPage3.Controls.Add(Me.Button_VozConectar)
        Me.TabPage3.Controls.Add(Me.Button_VozDesconectar)
        Me.TabPage3.Controls.Add(Me.Button_VozPreparar)
        Me.TabPage3.Controls.Add(Me.TextBox_VozIp)
        Me.TabPage3.Controls.Add(Me.TextBox_Nombre)
        Me.TabPage3.Controls.Add(Me.Button_VozAgregar)
        Me.TabPage3.Controls.Add(Me.ListBox_Contactos)
        Me.TabPage3.Controls.Add(Me.Label_VozPuerto)
        Me.TabPage3.Controls.Add(Me.Label_VozIp)
        Me.TabPage3.Controls.Add(Me.Button_ActulizaOperadores)
        Me.TabPage3.Controls.Add(Me.Button_ModInfoOperador)
        Me.TabPage3.Controls.Add(Me.ListView_Operadores)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(422, 404)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Usuarios"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Button_VozEscuchar
        '
        Me.Button_VozEscuchar.Location = New System.Drawing.Point(270, 124)
        Me.Button_VozEscuchar.Name = "Button_VozEscuchar"
        Me.Button_VozEscuchar.Size = New System.Drawing.Size(48, 23)
        Me.Button_VozEscuchar.TabIndex = 31
        Me.Button_VozEscuchar.Text = "Escuchar"
        Me.Button_VozEscuchar.UseVisualStyleBackColor = True
        '
        'Button_VozNoEscuchar
        '
        Me.Button_VozNoEscuchar.Location = New System.Drawing.Point(324, 124)
        Me.Button_VozNoEscuchar.Name = "Button_VozNoEscuchar"
        Me.Button_VozNoEscuchar.Size = New System.Drawing.Size(48, 23)
        Me.Button_VozNoEscuchar.TabIndex = 30
        Me.Button_VozNoEscuchar.Text = "Desonectar"
        Me.Button_VozNoEscuchar.UseVisualStyleBackColor = True
        '
        'Button_VozConectar
        '
        Me.Button_VozConectar.Location = New System.Drawing.Point(270, 95)
        Me.Button_VozConectar.Name = "Button_VozConectar"
        Me.Button_VozConectar.Size = New System.Drawing.Size(48, 23)
        Me.Button_VozConectar.TabIndex = 29
        Me.Button_VozConectar.Text = "Conectar"
        Me.Button_VozConectar.UseVisualStyleBackColor = True
        '
        'Button_VozDesconectar
        '
        Me.Button_VozDesconectar.Location = New System.Drawing.Point(324, 95)
        Me.Button_VozDesconectar.Name = "Button_VozDesconectar"
        Me.Button_VozDesconectar.Size = New System.Drawing.Size(48, 23)
        Me.Button_VozDesconectar.TabIndex = 28
        Me.Button_VozDesconectar.Text = "Desonectar"
        Me.Button_VozDesconectar.UseVisualStyleBackColor = True
        '
        'Button_VozPreparar
        '
        Me.Button_VozPreparar.Location = New System.Drawing.Point(216, 95)
        Me.Button_VozPreparar.Name = "Button_VozPreparar"
        Me.Button_VozPreparar.Size = New System.Drawing.Size(48, 23)
        Me.Button_VozPreparar.TabIndex = 27
        Me.Button_VozPreparar.Text = "Preparar"
        Me.Button_VozPreparar.UseVisualStyleBackColor = True
        '
        'TextBox_VozIp
        '
        Me.TextBox_VozIp.Location = New System.Drawing.Point(212, 10)
        Me.TextBox_VozIp.Name = "TextBox_VozIp"
        Me.TextBox_VozIp.Size = New System.Drawing.Size(145, 20)
        Me.TextBox_VozIp.TabIndex = 26
        Me.TextBox_VozIp.Text = "127.0.0.1"
        '
        'TextBox_Nombre
        '
        Me.TextBox_Nombre.Location = New System.Drawing.Point(212, 32)
        Me.TextBox_Nombre.Name = "TextBox_Nombre"
        Me.TextBox_Nombre.Size = New System.Drawing.Size(145, 20)
        Me.TextBox_Nombre.TabIndex = 25
        Me.TextBox_Nombre.Text = "Nombre"
        '
        'Button_VozAgregar
        '
        Me.Button_VozAgregar.Location = New System.Drawing.Point(215, 58)
        Me.Button_VozAgregar.Name = "Button_VozAgregar"
        Me.Button_VozAgregar.Size = New System.Drawing.Size(75, 23)
        Me.Button_VozAgregar.TabIndex = 24
        Me.Button_VozAgregar.Text = "Agregar"
        Me.Button_VozAgregar.UseVisualStyleBackColor = True
        '
        'ListBox_Contactos
        '
        Me.ListBox_Contactos.FormattingEnabled = True
        Me.ListBox_Contactos.Location = New System.Drawing.Point(215, 176)
        Me.ListBox_Contactos.Name = "ListBox_Contactos"
        Me.ListBox_Contactos.Size = New System.Drawing.Size(199, 225)
        Me.ListBox_Contactos.TabIndex = 23
        '
        'Label_VozPuerto
        '
        Me.Label_VozPuerto.AutoSize = True
        Me.Label_VozPuerto.Location = New System.Drawing.Point(31, 32)
        Me.Label_VozPuerto.Name = "Label_VozPuerto"
        Me.Label_VozPuerto.Size = New System.Drawing.Size(39, 13)
        Me.Label_VozPuerto.TabIndex = 22
        Me.Label_VozPuerto.Text = "Label2"
        '
        'Label_VozIp
        '
        Me.Label_VozIp.AutoSize = True
        Me.Label_VozIp.Location = New System.Drawing.Point(31, 13)
        Me.Label_VozIp.Name = "Label_VozIp"
        Me.Label_VozIp.Size = New System.Drawing.Size(39, 13)
        Me.Label_VozIp.TabIndex = 21
        Me.Label_VozIp.Text = "Label1"
        '
        'Button_ActulizaOperadores
        '
        Me.Button_ActulizaOperadores.Location = New System.Drawing.Point(6, 55)
        Me.Button_ActulizaOperadores.Name = "Button_ActulizaOperadores"
        Me.Button_ActulizaOperadores.Size = New System.Drawing.Size(35, 23)
        Me.Button_ActulizaOperadores.TabIndex = 18
        Me.Button_ActulizaOperadores.Text = "Actuliza operadores"
        Me.Button_ActulizaOperadores.UseVisualStyleBackColor = True
        '
        'Button_ModInfoOperador
        '
        Me.Button_ModInfoOperador.Location = New System.Drawing.Point(47, 55)
        Me.Button_ModInfoOperador.Name = "Button_ModInfoOperador"
        Me.Button_ModInfoOperador.Size = New System.Drawing.Size(35, 23)
        Me.Button_ModInfoOperador.TabIndex = 19
        Me.Button_ModInfoOperador.Text = "Info operador"
        Me.Button_ModInfoOperador.UseVisualStyleBackColor = True
        '
        'ListView_Operadores
        '
        Me.ListView_Operadores.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView_Operadores.GridLines = True
        Me.ListView_Operadores.HideSelection = False
        Me.ListView_Operadores.HoverSelection = True
        Me.ListView_Operadores.Location = New System.Drawing.Point(6, 85)
        Me.ListView_Operadores.Name = "ListView_Operadores"
        Me.ListView_Operadores.Size = New System.Drawing.Size(200, 316)
        Me.ListView_Operadores.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListView_Operadores.TabIndex = 20
        Me.ListView_Operadores.UseCompatibleStateImageBehavior = False
        Me.ListView_Operadores.View = System.Windows.Forms.View.Tile
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox_Narrador)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(422, 404)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Opciones"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox_Narrador
        '
        Me.GroupBox_Narrador.Controls.Add(Me.Button_NarraProbar)
        Me.GroupBox_Narrador.Controls.Add(Me.Button_NarraGuardar)
        Me.GroupBox_Narrador.Controls.Add(Me.Label_NarraSalidas)
        Me.GroupBox_Narrador.Controls.Add(Me.Label_NarraVoces)
        Me.GroupBox_Narrador.Controls.Add(Me.ComboBox_NarraAltavozes)
        Me.GroupBox_Narrador.Controls.Add(Me.Label_NarraVelocidad)
        Me.GroupBox_Narrador.Controls.Add(Me.Label_NarraVolumen)
        Me.GroupBox_Narrador.Controls.Add(Me.TrackBar_NarraVolumen)
        Me.GroupBox_Narrador.Controls.Add(Me.TrackBar_NarraRate)
        Me.GroupBox_Narrador.Controls.Add(Me.CheckBox_NarraMenasajes)
        Me.GroupBox_Narrador.Controls.Add(Me.ComboBox_NarradorVoces)
        Me.GroupBox_Narrador.Controls.Add(Me.CheckBox_NarraConexiones)
        Me.GroupBox_Narrador.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox_Narrador.Name = "GroupBox_Narrador"
        Me.GroupBox_Narrador.Size = New System.Drawing.Size(200, 345)
        Me.GroupBox_Narrador.TabIndex = 0
        Me.GroupBox_Narrador.TabStop = False
        Me.GroupBox_Narrador.Text = "Narrador"
        '
        'Button_NarraProbar
        '
        Me.Button_NarraProbar.Location = New System.Drawing.Point(118, 39)
        Me.Button_NarraProbar.Name = "Button_NarraProbar"
        Me.Button_NarraProbar.Size = New System.Drawing.Size(75, 23)
        Me.Button_NarraProbar.TabIndex = 35
        Me.Button_NarraProbar.Text = "Probar"
        Me.Button_NarraProbar.UseVisualStyleBackColor = True
        '
        'Button_NarraGuardar
        '
        Me.Button_NarraGuardar.Location = New System.Drawing.Point(118, 14)
        Me.Button_NarraGuardar.Name = "Button_NarraGuardar"
        Me.Button_NarraGuardar.Size = New System.Drawing.Size(75, 23)
        Me.Button_NarraGuardar.TabIndex = 34
        Me.Button_NarraGuardar.Text = "Guardar"
        Me.Button_NarraGuardar.UseVisualStyleBackColor = True
        '
        'Label_NarraSalidas
        '
        Me.Label_NarraSalidas.AutoSize = True
        Me.Label_NarraSalidas.Location = New System.Drawing.Point(6, 280)
        Me.Label_NarraSalidas.Name = "Label_NarraSalidas"
        Me.Label_NarraSalidas.Size = New System.Drawing.Size(36, 13)
        Me.Label_NarraSalidas.TabIndex = 33
        Me.Label_NarraSalidas.Text = "Salida"
        '
        'Label_NarraVoces
        '
        Me.Label_NarraVoces.AutoSize = True
        Me.Label_NarraVoces.Location = New System.Drawing.Point(6, 228)
        Me.Label_NarraVoces.Name = "Label_NarraVoces"
        Me.Label_NarraVoces.Size = New System.Drawing.Size(37, 13)
        Me.Label_NarraVoces.TabIndex = 32
        Me.Label_NarraVoces.Text = "Voces"
        '
        'Label_NarraVelocidad
        '
        Me.Label_NarraVelocidad.AutoSize = True
        Me.Label_NarraVelocidad.Location = New System.Drawing.Point(6, 150)
        Me.Label_NarraVelocidad.Name = "Label_NarraVelocidad"
        Me.Label_NarraVelocidad.Size = New System.Drawing.Size(54, 13)
        Me.Label_NarraVelocidad.TabIndex = 29
        Me.Label_NarraVelocidad.Text = "Velocidad"
        '
        'Label_NarraVolumen
        '
        Me.Label_NarraVolumen.AutoSize = True
        Me.Label_NarraVolumen.Location = New System.Drawing.Point(6, 70)
        Me.Label_NarraVolumen.Name = "Label_NarraVolumen"
        Me.Label_NarraVolumen.Size = New System.Drawing.Size(48, 13)
        Me.Label_NarraVolumen.TabIndex = 28
        Me.Label_NarraVolumen.Text = "Volumen"
        '
        'TrackBar_NarraVolumen
        '
        Me.TrackBar_NarraVolumen.Location = New System.Drawing.Point(6, 90)
        Me.TrackBar_NarraVolumen.Maximum = 100
        Me.TrackBar_NarraVolumen.Name = "TrackBar_NarraVolumen"
        Me.TrackBar_NarraVolumen.Size = New System.Drawing.Size(187, 45)
        Me.TrackBar_NarraVolumen.TabIndex = 23
        Me.TrackBar_NarraVolumen.Value = 75
        '
        'TrackBar_NarraRate
        '
        Me.TrackBar_NarraRate.Location = New System.Drawing.Point(7, 170)
        Me.TrackBar_NarraRate.Minimum = -10
        Me.TrackBar_NarraRate.Name = "TrackBar_NarraRate"
        Me.TrackBar_NarraRate.Size = New System.Drawing.Size(187, 45)
        Me.TrackBar_NarraRate.TabIndex = 24
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.PictureBoxRECIBIR)
        Me.TabPage5.Controls.Add(Me.Button_VideoIniciar)
        Me.TabPage5.Controls.Add(Me.Button_VideoDesconectar)
        Me.TabPage5.Controls.Add(Me.Button_VideoConectar)
        Me.TabPage5.Controls.Add(Me.PictureboxVISOR)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(422, 404)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Video"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'PictureBoxRECIBIR
        '
        Me.PictureBoxRECIBIR.Location = New System.Drawing.Point(6, 93)
        Me.PictureBoxRECIBIR.Name = "PictureBoxRECIBIR"
        Me.PictureBoxRECIBIR.Size = New System.Drawing.Size(408, 305)
        Me.PictureBoxRECIBIR.TabIndex = 31
        Me.PictureBoxRECIBIR.TabStop = False
        '
        'Button_VideoIniciar
        '
        Me.Button_VideoIniciar.Location = New System.Drawing.Point(6, 6)
        Me.Button_VideoIniciar.Name = "Button_VideoIniciar"
        Me.Button_VideoIniciar.Size = New System.Drawing.Size(150, 23)
        Me.Button_VideoIniciar.TabIndex = 30
        Me.Button_VideoIniciar.Text = "Iniciar"
        Me.Button_VideoIniciar.UseVisualStyleBackColor = True
        '
        'Button_VideoDesconectar
        '
        Me.Button_VideoDesconectar.Location = New System.Drawing.Point(6, 64)
        Me.Button_VideoDesconectar.Name = "Button_VideoDesconectar"
        Me.Button_VideoDesconectar.Size = New System.Drawing.Size(150, 23)
        Me.Button_VideoDesconectar.TabIndex = 29
        Me.Button_VideoDesconectar.Text = "DESCONECTAR"
        Me.Button_VideoDesconectar.UseVisualStyleBackColor = True
        '
        'Button_VideoConectar
        '
        Me.Button_VideoConectar.Location = New System.Drawing.Point(6, 35)
        Me.Button_VideoConectar.Name = "Button_VideoConectar"
        Me.Button_VideoConectar.Size = New System.Drawing.Size(150, 23)
        Me.Button_VideoConectar.TabIndex = 28
        Me.Button_VideoConectar.Text = "CONECTAR"
        Me.Button_VideoConectar.UseVisualStyleBackColor = True
        '
        'PictureboxVISOR
        '
        Me.PictureboxVISOR.Location = New System.Drawing.Point(162, 6)
        Me.PictureboxVISOR.Name = "PictureboxVISOR"
        Me.PictureboxVISOR.Size = New System.Drawing.Size(77, 81)
        Me.PictureboxVISOR.TabIndex = 27
        Me.PictureboxVISOR.TabStop = False
        '
        'Form_CienteUDP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button_Inicio)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Form_CienteUDP"
        Me.Text = "Form_CienteUDP"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DataGridView_ListaServidores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox_Narrador.ResumeLayout(False)
        Me.GroupBox_Narrador.PerformLayout()
        CType(Me.TrackBar_NarraVolumen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar_NarraRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        CType(Me.PictureBoxRECIBIR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureboxVISOR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TimerWEBCAM As Timer
    Friend WithEvents Button_Inicio As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Button_Emision As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents RichTextBox_MensajesEntrada As RichTextBox
    Friend WithEvents Button_EnviarMsj As Button
    Friend WithEvents TextBox_Mensaje As TextBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label_Ping As Label
    Friend WithEvents Button_Ping As Button
    Friend WithEvents Button_GuardarServer As Button
    Friend WithEvents Label_Nick As Label
    Friend WithEvents Label_Buffer As Label
    Friend WithEvents TextBox_Buffer As TextBox
    Friend WithEvents Button_EliminarCon As Button
    Friend WithEvents Button_GuardarCon As Button
    Friend WithEvents DataGridView_ListaServidores As DataGridView
    Friend WithEvents Column_NombreServer As DataGridViewTextBoxColumn
    Friend WithEvents Column_IP As DataGridViewTextBoxColumn
    Friend WithEvents Column_ID As DataGridViewTextBoxColumn
    Friend WithEvents Button_Conectar As Button
    Friend WithEvents TextBox_Nick As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox_ConectarDestino_IP As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox_ConectarDestino_Puerto As TextBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Button_VozEscuchar As Button
    Friend WithEvents Button_VozNoEscuchar As Button
    Friend WithEvents Button_VozConectar As Button
    Friend WithEvents Button_VozDesconectar As Button
    Friend WithEvents Button_VozPreparar As Button
    Friend WithEvents TextBox_VozIp As TextBox
    Friend WithEvents TextBox_Nombre As TextBox
    Friend WithEvents Button_VozAgregar As Button
    Friend WithEvents ListBox_Contactos As ListBox
    Friend WithEvents Label_VozPuerto As Label
    Friend WithEvents Label_VozIp As Label
    Friend WithEvents Button_ActulizaOperadores As Button
    Friend WithEvents Button_ModInfoOperador As Button
    Friend WithEvents ListView_Operadores As ListView
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents GroupBox_Narrador As GroupBox
    Friend WithEvents Button_NarraProbar As Button
    Friend WithEvents Button_NarraGuardar As Button
    Friend WithEvents Label_NarraSalidas As Label
    Friend WithEvents Label_NarraVoces As Label
    Friend WithEvents ComboBox_NarraAltavozes As ComboBox
    Friend WithEvents Label_NarraVelocidad As Label
    Friend WithEvents Label_NarraVolumen As Label
    Friend WithEvents TrackBar_NarraVolumen As TrackBar
    Friend WithEvents TrackBar_NarraRate As TrackBar
    Friend WithEvents CheckBox_NarraMenasajes As CheckBox
    Friend WithEvents ComboBox_NarradorVoces As ComboBox
    Friend WithEvents CheckBox_NarraConexiones As CheckBox
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents PictureBoxRECIBIR As PictureBox
    Friend WithEvents Button_VideoIniciar As Button
    Friend WithEvents Button_VideoDesconectar As Button
    Friend WithEvents Button_VideoConectar As Button
    Friend WithEvents PictureboxVISOR As PictureBox
    Friend WithEvents Button_WakeOnLan As Button
End Class
