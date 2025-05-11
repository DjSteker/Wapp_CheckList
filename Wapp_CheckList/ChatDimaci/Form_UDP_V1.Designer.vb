<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_UDP_V1
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
        Me.txtMensaje2 = New System.Windows.Forms.TextBox()
        Me.TextBox_MasivoPausa = New System.Windows.Forms.TextBox()
        Me.Label_EstadoForm = New System.Windows.Forms.Label()
        Me.Button_Masivo = New System.Windows.Forms.Button()
        Me.Button_BuscarServerCS16 = New System.Windows.Forms.Button()
        Me.Button_Desconectar = New System.Windows.Forms.Button()
        Me.Button_Conectar = New System.Windows.Forms.Button()
        Me.GroupBox_Local = New System.Windows.Forms.GroupBox()
        Me.ComboBox_ListaIP = New System.Windows.Forms.ComboBox()
        Me.TextBox_LocalIp = New System.Windows.Forms.TextBox()
        Me.Label_LocalPuerto = New System.Windows.Forms.Label()
        Me.TextBox_LocalPuerto = New System.Windows.Forms.TextBox()
        Me.Label_LocalIp = New System.Windows.Forms.Label()
        Me.GroupBox_Destino = New System.Windows.Forms.GroupBox()
        Me.TextBox_DNSport = New System.Windows.Forms.TextBox()
        Me.TextBox_DNSip = New System.Windows.Forms.TextBox()
        Me.Label_DNS = New System.Windows.Forms.Label()
        Me.ComboBox_DestIp = New System.Windows.Forms.ComboBox()
        Me.TextBox_Host = New System.Windows.Forms.TextBox()
        Me.Label_Host = New System.Windows.Forms.Label()
        Me.Button_Enviar4 = New System.Windows.Forms.Button()
        Me.Button_EnviarPrivado = New System.Windows.Forms.Button()
        Me.Button_Enviar3 = New System.Windows.Forms.Button()
        Me.TextBox_DestIp = New System.Windows.Forms.TextBox()
        Me.Label_DestPuerto = New System.Windows.Forms.Label()
        Me.TextBox_DestPuerto = New System.Windows.Forms.TextBox()
        Me.Label_DestIp = New System.Windows.Forms.Label()
        Me.fraDatosRecibidos = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtDatosRecibidos = New System.Windows.Forms.TextBox()
        Me.cmdEnviar = New System.Windows.Forms.Button()
        Me.txtMensaje = New System.Windows.Forms.TextBox()
        Me.lblFunción = New System.Windows.Forms.Label()
        Me.Button_BuscarConexionesLAN = New System.Windows.Forms.Button()
        Me.Button_SocketApi = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox_Local.SuspendLayout()
        Me.GroupBox_Destino.SuspendLayout()
        Me.fraDatosRecibidos.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtMensaje2
        '
        Me.txtMensaje2.Location = New System.Drawing.Point(52, 56)
        Me.txtMensaje2.Name = "txtMensaje2"
        Me.txtMensaje2.Size = New System.Drawing.Size(200, 20)
        Me.txtMensaje2.TabIndex = 29
        '
        'TextBox_MasivoPausa
        '
        Me.TextBox_MasivoPausa.Location = New System.Drawing.Point(258, 40)
        Me.TextBox_MasivoPausa.Name = "TextBox_MasivoPausa"
        Me.TextBox_MasivoPausa.Size = New System.Drawing.Size(36, 20)
        Me.TextBox_MasivoPausa.TabIndex = 28
        Me.TextBox_MasivoPausa.Text = "30"
        '
        'Label_EstadoForm
        '
        Me.Label_EstadoForm.AutoSize = True
        Me.Label_EstadoForm.Location = New System.Drawing.Point(16, 429)
        Me.Label_EstadoForm.Name = "Label_EstadoForm"
        Me.Label_EstadoForm.Size = New System.Drawing.Size(66, 13)
        Me.Label_EstadoForm.TabIndex = 27
        Me.Label_EstadoForm.Text = "Estado Form"
        '
        'Button_Masivo
        '
        Me.Button_Masivo.Location = New System.Drawing.Point(276, 11)
        Me.Button_Masivo.Name = "Button_Masivo"
        Me.Button_Masivo.Size = New System.Drawing.Size(16, 23)
        Me.Button_Masivo.TabIndex = 26
        Me.Button_Masivo.Text = "Masivo"
        Me.Button_Masivo.UseVisualStyleBackColor = True
        '
        'Button_BuscarServerCS16
        '
        Me.Button_BuscarServerCS16.Location = New System.Drawing.Point(306, 354)
        Me.Button_BuscarServerCS16.Name = "Button_BuscarServerCS16"
        Me.Button_BuscarServerCS16.Size = New System.Drawing.Size(167, 23)
        Me.Button_BuscarServerCS16.TabIndex = 25
        Me.Button_BuscarServerCS16.Text = "Buscar Server CS 1.6"
        Me.Button_BuscarServerCS16.UseVisualStyleBackColor = True
        '
        'Button_Desconectar
        '
        Me.Button_Desconectar.Location = New System.Drawing.Point(133, 389)
        Me.Button_Desconectar.Name = "Button_Desconectar"
        Me.Button_Desconectar.Size = New System.Drawing.Size(102, 29)
        Me.Button_Desconectar.TabIndex = 24
        Me.Button_Desconectar.Text = "Desconectar"
        '
        'Button_Conectar
        '
        Me.Button_Conectar.Location = New System.Drawing.Point(25, 389)
        Me.Button_Conectar.Name = "Button_Conectar"
        Me.Button_Conectar.Size = New System.Drawing.Size(102, 29)
        Me.Button_Conectar.TabIndex = 23
        Me.Button_Conectar.Text = "Conectar"
        '
        'GroupBox_Local
        '
        Me.GroupBox_Local.Controls.Add(Me.ComboBox_ListaIP)
        Me.GroupBox_Local.Controls.Add(Me.TextBox_LocalIp)
        Me.GroupBox_Local.Controls.Add(Me.Label_LocalPuerto)
        Me.GroupBox_Local.Controls.Add(Me.TextBox_LocalPuerto)
        Me.GroupBox_Local.Controls.Add(Me.Label_LocalIp)
        Me.GroupBox_Local.Location = New System.Drawing.Point(306, 8)
        Me.GroupBox_Local.Name = "GroupBox_Local"
        Me.GroupBox_Local.Size = New System.Drawing.Size(445, 100)
        Me.GroupBox_Local.TabIndex = 22
        Me.GroupBox_Local.TabStop = False
        Me.GroupBox_Local.Text = "Local"
        '
        'ComboBox_ListaIP
        '
        Me.ComboBox_ListaIP.FormattingEnabled = True
        Me.ComboBox_ListaIP.Location = New System.Drawing.Point(241, 28)
        Me.ComboBox_ListaIP.Name = "ComboBox_ListaIP"
        Me.ComboBox_ListaIP.Size = New System.Drawing.Size(170, 21)
        Me.ComboBox_ListaIP.TabIndex = 8
        '
        'TextBox_LocalIp
        '
        Me.TextBox_LocalIp.Location = New System.Drawing.Point(57, 29)
        Me.TextBox_LocalIp.Name = "TextBox_LocalIp"
        Me.TextBox_LocalIp.Size = New System.Drawing.Size(178, 20)
        Me.TextBox_LocalIp.TabIndex = 4
        '
        'Label_LocalPuerto
        '
        Me.Label_LocalPuerto.AutoSize = True
        Me.Label_LocalPuerto.Location = New System.Drawing.Point(13, 55)
        Me.Label_LocalPuerto.Name = "Label_LocalPuerto"
        Me.Label_LocalPuerto.Size = New System.Drawing.Size(38, 13)
        Me.Label_LocalPuerto.TabIndex = 7
        Me.Label_LocalPuerto.Text = "Puerto"
        '
        'TextBox_LocalPuerto
        '
        Me.TextBox_LocalPuerto.Location = New System.Drawing.Point(57, 52)
        Me.TextBox_LocalPuerto.Name = "TextBox_LocalPuerto"
        Me.TextBox_LocalPuerto.Size = New System.Drawing.Size(178, 20)
        Me.TextBox_LocalPuerto.TabIndex = 5
        Me.TextBox_LocalPuerto.Text = "27015"
        '
        'Label_LocalIp
        '
        Me.Label_LocalIp.AutoSize = True
        Me.Label_LocalIp.Location = New System.Drawing.Point(13, 32)
        Me.Label_LocalIp.Name = "Label_LocalIp"
        Me.Label_LocalIp.Size = New System.Drawing.Size(16, 13)
        Me.Label_LocalIp.TabIndex = 6
        Me.Label_LocalIp.Text = "Ip"
        '
        'GroupBox_Destino
        '
        Me.GroupBox_Destino.Controls.Add(Me.TextBox_DNSport)
        Me.GroupBox_Destino.Controls.Add(Me.TextBox_DNSip)
        Me.GroupBox_Destino.Controls.Add(Me.Label_DNS)
        Me.GroupBox_Destino.Controls.Add(Me.ComboBox_DestIp)
        Me.GroupBox_Destino.Controls.Add(Me.TextBox_Host)
        Me.GroupBox_Destino.Controls.Add(Me.Label_Host)
        Me.GroupBox_Destino.Controls.Add(Me.Button_Enviar4)
        Me.GroupBox_Destino.Controls.Add(Me.Button_EnviarPrivado)
        Me.GroupBox_Destino.Controls.Add(Me.Button_Enviar3)
        Me.GroupBox_Destino.Controls.Add(Me.TextBox_DestIp)
        Me.GroupBox_Destino.Controls.Add(Me.Label_DestPuerto)
        Me.GroupBox_Destino.Controls.Add(Me.TextBox_DestPuerto)
        Me.GroupBox_Destino.Controls.Add(Me.Label_DestIp)
        Me.GroupBox_Destino.Location = New System.Drawing.Point(306, 114)
        Me.GroupBox_Destino.Name = "GroupBox_Destino"
        Me.GroupBox_Destino.Size = New System.Drawing.Size(445, 234)
        Me.GroupBox_Destino.TabIndex = 21
        Me.GroupBox_Destino.TabStop = False
        Me.GroupBox_Destino.Text = "Destino"
        '
        'TextBox_DNSport
        '
        Me.TextBox_DNSport.Location = New System.Drawing.Point(161, 82)
        Me.TextBox_DNSport.Name = "TextBox_DNSport"
        Me.TextBox_DNSport.Size = New System.Drawing.Size(74, 20)
        Me.TextBox_DNSport.TabIndex = 15
        Me.TextBox_DNSport.Text = "53"
        '
        'TextBox_DNSip
        '
        Me.TextBox_DNSip.Location = New System.Drawing.Point(57, 82)
        Me.TextBox_DNSip.Name = "TextBox_DNSip"
        Me.TextBox_DNSip.Size = New System.Drawing.Size(98, 20)
        Me.TextBox_DNSip.TabIndex = 13
        Me.TextBox_DNSip.Text = "8.8.8.8"
        '
        'Label_DNS
        '
        Me.Label_DNS.AutoSize = True
        Me.Label_DNS.Location = New System.Drawing.Point(22, 85)
        Me.Label_DNS.Name = "Label_DNS"
        Me.Label_DNS.Size = New System.Drawing.Size(30, 13)
        Me.Label_DNS.TabIndex = 14
        Me.Label_DNS.Text = "DNS"
        '
        'ComboBox_DestIp
        '
        Me.ComboBox_DestIp.FormattingEnabled = True
        Me.ComboBox_DestIp.Location = New System.Drawing.Point(241, 133)
        Me.ComboBox_DestIp.Name = "ComboBox_DestIp"
        Me.ComboBox_DestIp.Size = New System.Drawing.Size(170, 21)
        Me.ComboBox_DestIp.TabIndex = 9
        '
        'TextBox_Host
        '
        Me.TextBox_Host.Location = New System.Drawing.Point(57, 108)
        Me.TextBox_Host.Name = "TextBox_Host"
        Me.TextBox_Host.Size = New System.Drawing.Size(178, 20)
        Me.TextBox_Host.TabIndex = 11
        Me.TextBox_Host.Text = "grep.geek"
        '
        'Label_Host
        '
        Me.Label_Host.AutoSize = True
        Me.Label_Host.Location = New System.Drawing.Point(22, 111)
        Me.Label_Host.Name = "Label_Host"
        Me.Label_Host.Size = New System.Drawing.Size(29, 13)
        Me.Label_Host.TabIndex = 12
        Me.Label_Host.Text = "Host"
        '
        'Button_Enviar4
        '
        Me.Button_Enviar4.Location = New System.Drawing.Point(6, 183)
        Me.Button_Enviar4.Name = "Button_Enviar4"
        Me.Button_Enviar4.Size = New System.Drawing.Size(96, 23)
        Me.Button_Enviar4.TabIndex = 10
        Me.Button_Enviar4.Text = "Enviar"
        Me.Button_Enviar4.UseVisualStyleBackColor = True
        '
        'Button_EnviarPrivado
        '
        Me.Button_EnviarPrivado.Location = New System.Drawing.Point(210, 183)
        Me.Button_EnviarPrivado.Name = "Button_EnviarPrivado"
        Me.Button_EnviarPrivado.Size = New System.Drawing.Size(96, 23)
        Me.Button_EnviarPrivado.TabIndex = 8
        Me.Button_EnviarPrivado.Text = "Enviar Privado"
        Me.Button_EnviarPrivado.UseVisualStyleBackColor = True
        '
        'Button_Enviar3
        '
        Me.Button_Enviar3.Location = New System.Drawing.Point(108, 183)
        Me.Button_Enviar3.Name = "Button_Enviar3"
        Me.Button_Enviar3.Size = New System.Drawing.Size(96, 23)
        Me.Button_Enviar3.TabIndex = 9
        Me.Button_Enviar3.Text = "Enviar"
        Me.Button_Enviar3.UseVisualStyleBackColor = True
        '
        'TextBox_DestIp
        '
        Me.TextBox_DestIp.Location = New System.Drawing.Point(57, 134)
        Me.TextBox_DestIp.Name = "TextBox_DestIp"
        Me.TextBox_DestIp.Size = New System.Drawing.Size(178, 20)
        Me.TextBox_DestIp.TabIndex = 4
        '
        'Label_DestPuerto
        '
        Me.Label_DestPuerto.AutoSize = True
        Me.Label_DestPuerto.Location = New System.Drawing.Point(13, 160)
        Me.Label_DestPuerto.Name = "Label_DestPuerto"
        Me.Label_DestPuerto.Size = New System.Drawing.Size(38, 13)
        Me.Label_DestPuerto.TabIndex = 7
        Me.Label_DestPuerto.Text = "Puerto"
        '
        'TextBox_DestPuerto
        '
        Me.TextBox_DestPuerto.Location = New System.Drawing.Point(57, 157)
        Me.TextBox_DestPuerto.Name = "TextBox_DestPuerto"
        Me.TextBox_DestPuerto.Size = New System.Drawing.Size(178, 20)
        Me.TextBox_DestPuerto.TabIndex = 5
        Me.TextBox_DestPuerto.Text = "57921"
        '
        'Label_DestIp
        '
        Me.Label_DestIp.AutoSize = True
        Me.Label_DestIp.Location = New System.Drawing.Point(35, 137)
        Me.Label_DestIp.Name = "Label_DestIp"
        Me.Label_DestIp.Size = New System.Drawing.Size(16, 13)
        Me.Label_DestIp.TabIndex = 6
        Me.Label_DestIp.Text = "Ip"
        '
        'fraDatosRecibidos
        '
        Me.fraDatosRecibidos.Controls.Add(Me.Button1)
        Me.fraDatosRecibidos.Controls.Add(Me.txtDatosRecibidos)
        Me.fraDatosRecibidos.Location = New System.Drawing.Point(25, 169)
        Me.fraDatosRecibidos.Name = "fraDatosRecibidos"
        Me.fraDatosRecibidos.Size = New System.Drawing.Size(249, 214)
        Me.fraDatosRecibidos.TabIndex = 20
        Me.fraDatosRecibidos.TabStop = False
        Me.fraDatosRecibidos.Text = "Datos recibidos"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(163, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Limpiar consola"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtDatosRecibidos
        '
        Me.txtDatosRecibidos.Location = New System.Drawing.Point(14, 29)
        Me.txtDatosRecibidos.Multiline = True
        Me.txtDatosRecibidos.Name = "txtDatosRecibidos"
        Me.txtDatosRecibidos.ReadOnly = True
        Me.txtDatosRecibidos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDatosRecibidos.Size = New System.Drawing.Size(224, 179)
        Me.txtDatosRecibidos.TabIndex = 0
        '
        'cmdEnviar
        '
        Me.cmdEnviar.Enabled = False
        Me.cmdEnviar.Location = New System.Drawing.Point(48, 91)
        Me.cmdEnviar.Name = "cmdEnviar"
        Me.cmdEnviar.Size = New System.Drawing.Size(204, 29)
        Me.cmdEnviar.TabIndex = 19
        Me.cmdEnviar.Text = "Enviar texto a toda la red"
        '
        'txtMensaje
        '
        Me.txtMensaje.Location = New System.Drawing.Point(48, 30)
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(200, 20)
        Me.txtMensaje.TabIndex = 18
        '
        'lblFunción
        '
        Me.lblFunción.AutoSize = True
        Me.lblFunción.Location = New System.Drawing.Point(36, 8)
        Me.lblFunción.Name = "lblFunción"
        Me.lblFunción.Size = New System.Drawing.Size(234, 13)
        Me.lblFunción.TabIndex = 17
        Me.lblFunción.Text = "Escribe el texto que deseas enviar a toda la red:"
        '
        'Button_BuscarConexionesLAN
        '
        Me.Button_BuscarConexionesLAN.Location = New System.Drawing.Point(306, 383)
        Me.Button_BuscarConexionesLAN.Name = "Button_BuscarConexionesLAN"
        Me.Button_BuscarConexionesLAN.Size = New System.Drawing.Size(167, 23)
        Me.Button_BuscarConexionesLAN.TabIndex = 30
        Me.Button_BuscarConexionesLAN.Text = "Buscar conexiones LAN"
        Me.Button_BuscarConexionesLAN.UseVisualStyleBackColor = True
        '
        'Button_SocketApi
        '
        Me.Button_SocketApi.Location = New System.Drawing.Point(547, 354)
        Me.Button_SocketApi.Name = "Button_SocketApi"
        Me.Button_SocketApi.Size = New System.Drawing.Size(75, 23)
        Me.Button_SocketApi.TabIndex = 31
        Me.Button_SocketApi.Text = "Socket_API"
        Me.Button_SocketApi.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(713, 419)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 32
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form_UDP_V1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button_SocketApi)
        Me.Controls.Add(Me.Button_BuscarConexionesLAN)
        Me.Controls.Add(Me.txtMensaje2)
        Me.Controls.Add(Me.TextBox_MasivoPausa)
        Me.Controls.Add(Me.Label_EstadoForm)
        Me.Controls.Add(Me.Button_Masivo)
        Me.Controls.Add(Me.Button_BuscarServerCS16)
        Me.Controls.Add(Me.Button_Desconectar)
        Me.Controls.Add(Me.Button_Conectar)
        Me.Controls.Add(Me.GroupBox_Local)
        Me.Controls.Add(Me.GroupBox_Destino)
        Me.Controls.Add(Me.fraDatosRecibidos)
        Me.Controls.Add(Me.cmdEnviar)
        Me.Controls.Add(Me.txtMensaje)
        Me.Controls.Add(Me.lblFunción)
        Me.Name = "Form_UDP_V1"
        Me.Text = "Form_UDP_V1"
        Me.GroupBox_Local.ResumeLayout(False)
        Me.GroupBox_Local.PerformLayout()
        Me.GroupBox_Destino.ResumeLayout(False)
        Me.GroupBox_Destino.PerformLayout()
        Me.fraDatosRecibidos.ResumeLayout(False)
        Me.fraDatosRecibidos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtMensaje2 As TextBox
    Friend WithEvents TextBox_MasivoPausa As TextBox
    Friend WithEvents Label_EstadoForm As Label
    Friend WithEvents Button_Masivo As Button
    Friend WithEvents Button_BuscarServerCS16 As Button
    Friend WithEvents Button_Desconectar As Button
    Friend WithEvents Button_Conectar As Button
    Friend WithEvents GroupBox_Local As GroupBox
    Friend WithEvents TextBox_LocalIp As TextBox
    Friend WithEvents Label_LocalPuerto As Label
    Friend WithEvents TextBox_LocalPuerto As TextBox
    Friend WithEvents Label_LocalIp As Label
    Friend WithEvents GroupBox_Destino As GroupBox
    Friend WithEvents Button_Enviar4 As Button
    Friend WithEvents Button_EnviarPrivado As Button
    Friend WithEvents Button_Enviar3 As Button
    Friend WithEvents TextBox_DestIp As TextBox
    Friend WithEvents Label_DestPuerto As Label
    Friend WithEvents TextBox_DestPuerto As TextBox
    Friend WithEvents Label_DestIp As Label
    Friend WithEvents fraDatosRecibidos As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents txtDatosRecibidos As TextBox
    Friend WithEvents cmdEnviar As Button
    Friend WithEvents txtMensaje As TextBox
    Friend WithEvents lblFunción As Label
    Friend WithEvents ComboBox_ListaIP As ComboBox
    Friend WithEvents TextBox_Host As TextBox
    Friend WithEvents Label_Host As Label
    Friend WithEvents ComboBox_DestIp As ComboBox
    Friend WithEvents TextBox_DNSip As TextBox
    Friend WithEvents Label_DNS As Label
    Friend WithEvents TextBox_DNSport As TextBox
    Friend WithEvents Button_BuscarConexionesLAN As Button
    Friend WithEvents Button_SocketApi As Button
    Friend WithEvents Button2 As Button
End Class
