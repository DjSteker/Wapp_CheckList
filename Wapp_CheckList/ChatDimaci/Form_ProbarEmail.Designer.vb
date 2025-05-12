<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_ProbarEmail
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
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.RichTextBox_Mesaje = New System.Windows.Forms.RichTextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.TextBox_TiempoEspera = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.RichTextBox_Sucesos = New System.Windows.Forms.RichTextBox()
        Me.Button_EnviarPrueba = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox_Remitenete = New System.Windows.Forms.TextBox()
        Me.TextBox_Sujeto = New System.Windows.Forms.TextBox()
        Me.TextBox_PuertoAsta = New System.Windows.Forms.TextBox()
        Me.TextBox_CorreoDestino = New System.Windows.Forms.TextBox()
        Me.TextBox_HostSMTP = New System.Windows.Forms.TextBox()
        Me.TextBox_Mensaje = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox_Usuario = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CheckBox_Ssl = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox_Contraseña = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CheckBox_IsBodyHtml = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox_Puerto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ProbarPuertosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnviarEmailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ObtenerInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProbarPuertosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(8, 30)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(79, 20)
        Me.WebBrowser1.TabIndex = 82
        Me.WebBrowser1.Visible = False
        '
        'RichTextBox_Mesaje
        '
        Me.RichTextBox_Mesaje.Location = New System.Drawing.Point(121, 311)
        Me.RichTextBox_Mesaje.Name = "RichTextBox_Mesaje"
        Me.RichTextBox_Mesaje.Size = New System.Drawing.Size(241, 85)
        Me.RichTextBox_Mesaje.TabIndex = 81
        Me.RichTextBox_Mesaje.Text = ""
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(175, 27)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(186, 23)
        Me.ProgressBar1.TabIndex = 80
        '
        'TextBox_TiempoEspera
        '
        Me.TextBox_TiempoEspera.Location = New System.Drawing.Point(242, 188)
        Me.TextBox_TiempoEspera.Name = "TextBox_TiempoEspera"
        Me.TextBox_TiempoEspera.Size = New System.Drawing.Size(119, 20)
        Me.TextBox_TiempoEspera.TabIndex = 79
        Me.TextBox_TiempoEspera.Text = "25000"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(66, 191)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(170, 13)
        Me.Label10.TabIndex = 78
        Me.Label10.Text = "Tiempo de espera en milisegundos"
        '
        'RichTextBox_Sucesos
        '
        Me.RichTextBox_Sucesos.Location = New System.Drawing.Point(8, 402)
        Me.RichTextBox_Sucesos.Name = "RichTextBox_Sucesos"
        Me.RichTextBox_Sucesos.Size = New System.Drawing.Size(354, 104)
        Me.RichTextBox_Sucesos.TabIndex = 77
        Me.RichTextBox_Sucesos.Text = ""
        '
        'Button_EnviarPrueba
        '
        Me.Button_EnviarPrueba.Location = New System.Drawing.Point(94, 27)
        Me.Button_EnviarPrueba.Name = "Button_EnviarPrueba"
        Me.Button_EnviarPrueba.Size = New System.Drawing.Size(75, 23)
        Me.Button_EnviarPrueba.TabIndex = 56
        Me.Button_EnviarPrueba.Text = "Enviar"
        Me.Button_EnviarPrueba.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(218, 111)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 76
        Me.Label9.Text = "Asta"
        '
        'TextBox_Remitenete
        '
        Me.TextBox_Remitenete.Location = New System.Drawing.Point(95, 57)
        Me.TextBox_Remitenete.Name = "TextBox_Remitenete"
        Me.TextBox_Remitenete.Size = New System.Drawing.Size(266, 20)
        Me.TextBox_Remitenete.TabIndex = 57
        Me.TextBox_Remitenete.Text = "correo@gmail.com"
        '
        'TextBox_Sujeto
        '
        Me.TextBox_Sujeto.Location = New System.Drawing.Point(95, 258)
        Me.TextBox_Sujeto.Name = "TextBox_Sujeto"
        Me.TextBox_Sujeto.Size = New System.Drawing.Size(267, 20)
        Me.TextBox_Sujeto.TabIndex = 67
        Me.TextBox_Sujeto.Text = "Prueba Mail"
        '
        'TextBox_PuertoAsta
        '
        Me.TextBox_PuertoAsta.Location = New System.Drawing.Point(252, 108)
        Me.TextBox_PuertoAsta.Name = "TextBox_PuertoAsta"
        Me.TextBox_PuertoAsta.Size = New System.Drawing.Size(109, 20)
        Me.TextBox_PuertoAsta.TabIndex = 75
        Me.TextBox_PuertoAsta.Text = "587"
        '
        'TextBox_CorreoDestino
        '
        Me.TextBox_CorreoDestino.Location = New System.Drawing.Point(95, 232)
        Me.TextBox_CorreoDestino.Name = "TextBox_CorreoDestino"
        Me.TextBox_CorreoDestino.Size = New System.Drawing.Size(267, 20)
        Me.TextBox_CorreoDestino.TabIndex = 66
        Me.TextBox_CorreoDestino.Text = "@"
        '
        'TextBox_HostSMTP
        '
        Me.TextBox_HostSMTP.Location = New System.Drawing.Point(95, 83)
        Me.TextBox_HostSMTP.Name = "TextBox_HostSMTP"
        Me.TextBox_HostSMTP.Size = New System.Drawing.Size(266, 20)
        Me.TextBox_HostSMTP.TabIndex = 58
        Me.TextBox_HostSMTP.Text = "smtp.gmail.com"
        '
        'TextBox_Mensaje
        '
        Me.TextBox_Mensaje.Location = New System.Drawing.Point(95, 284)
        Me.TextBox_Mensaje.Name = "TextBox_Mensaje"
        Me.TextBox_Mensaje.Size = New System.Drawing.Size(267, 20)
        Me.TextBox_Mensaje.TabIndex = 68
        Me.TextBox_Mensaje.Text = "Hola "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 65
        Me.Label5.Text = "Contraseña"
        '
        'TextBox_Usuario
        '
        Me.TextBox_Usuario.Location = New System.Drawing.Point(95, 136)
        Me.TextBox_Usuario.Name = "TextBox_Usuario"
        Me.TextBox_Usuario.Size = New System.Drawing.Size(266, 20)
        Me.TextBox_Usuario.TabIndex = 59
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(52, 261)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "Sujeto"
        '
        'CheckBox_Ssl
        '
        Me.CheckBox_Ssl.AutoSize = True
        Me.CheckBox_Ssl.Checked = True
        Me.CheckBox_Ssl.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_Ssl.Location = New System.Drawing.Point(8, 335)
        Me.CheckBox_Ssl.Name = "CheckBox_Ssl"
        Me.CheckBox_Ssl.Size = New System.Drawing.Size(97, 17)
        Me.CheckBox_Ssl.TabIndex = 74
        Me.CheckBox_Ssl.Text = "Seguridad SSL"
        Me.CheckBox_Ssl.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(46, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "Usuario"
        '
        'TextBox_Contraseña
        '
        Me.TextBox_Contraseña.Location = New System.Drawing.Point(95, 162)
        Me.TextBox_Contraseña.Name = "TextBox_Contraseña"
        Me.TextBox_Contraseña.Size = New System.Drawing.Size(266, 20)
        Me.TextBox_Contraseña.TabIndex = 60
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(42, 287)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 70
        Me.Label7.Text = "Mensaje"
        '
        'CheckBox_IsBodyHtml
        '
        Me.CheckBox_IsBodyHtml.AutoSize = True
        Me.CheckBox_IsBodyHtml.Location = New System.Drawing.Point(8, 312)
        Me.CheckBox_IsBodyHtml.Name = "CheckBox_IsBodyHtml"
        Me.CheckBox_IsBodyHtml.Size = New System.Drawing.Size(79, 17)
        Me.CheckBox_IsBodyHtml.TabIndex = 73
        Me.CheckBox_IsBodyHtml.Text = "IsBodyHtml"
        Me.CheckBox_IsBodyHtml.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Host SMTP"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Correo remitente"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(51, 111)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "Puerto"
        '
        'TextBox_Puerto
        '
        Me.TextBox_Puerto.Location = New System.Drawing.Point(95, 108)
        Me.TextBox_Puerto.Name = "TextBox_Puerto"
        Me.TextBox_Puerto.Size = New System.Drawing.Size(97, 20)
        Me.TextBox_Puerto.TabIndex = 72
        Me.TextBox_Puerto.Text = "570"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 235)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "Correo destino"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProbarPuertosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(405, 24)
        Me.MenuStrip1.TabIndex = 83
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ProbarPuertosToolStripMenuItem
        '
        Me.ProbarPuertosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnviarEmailToolStripMenuItem, Me.ObtenerInfoToolStripMenuItem, Me.ProbarPuertosToolStripMenuItem1, Me.SalirToolStripMenuItem})
        Me.ProbarPuertosToolStripMenuItem.Name = "ProbarPuertosToolStripMenuItem"
        Me.ProbarPuertosToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.ProbarPuertosToolStripMenuItem.Text = "Menu"
        '
        'EnviarEmailToolStripMenuItem
        '
        Me.EnviarEmailToolStripMenuItem.Name = "EnviarEmailToolStripMenuItem"
        Me.EnviarEmailToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EnviarEmailToolStripMenuItem.Text = "Enviar Email"
        '
        'ObtenerInfoToolStripMenuItem
        '
        Me.ObtenerInfoToolStripMenuItem.Name = "ObtenerInfoToolStripMenuItem"
        Me.ObtenerInfoToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ObtenerInfoToolStripMenuItem.Text = "Obtener info"
        '
        'ProbarPuertosToolStripMenuItem1
        '
        Me.ProbarPuertosToolStripMenuItem1.Name = "ProbarPuertosToolStripMenuItem1"
        Me.ProbarPuertosToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ProbarPuertosToolStripMenuItem1.Text = "Probar puertos"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'Form_ProbarEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 518)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.RichTextBox_Mesaje)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.TextBox_TiempoEspera)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.RichTextBox_Sucesos)
        Me.Controls.Add(Me.Button_EnviarPrueba)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextBox_Remitenete)
        Me.Controls.Add(Me.TextBox_Sujeto)
        Me.Controls.Add(Me.TextBox_PuertoAsta)
        Me.Controls.Add(Me.TextBox_CorreoDestino)
        Me.Controls.Add(Me.TextBox_HostSMTP)
        Me.Controls.Add(Me.TextBox_Mensaje)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox_Usuario)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CheckBox_Ssl)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBox_Contraseña)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CheckBox_IsBodyHtml)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox_Puerto)
        Me.Controls.Add(Me.Label2)
        Me.Name = "Form_ProbarEmail"
        Me.Text = "Form_ProbarEmail"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents RichTextBox_Mesaje As RichTextBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents TextBox_TiempoEspera As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents RichTextBox_Sucesos As RichTextBox
    Friend WithEvents Button_EnviarPrueba As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBox_Remitenete As TextBox
    Friend WithEvents TextBox_Sujeto As TextBox
    Friend WithEvents TextBox_PuertoAsta As TextBox
    Friend WithEvents TextBox_CorreoDestino As TextBox
    Friend WithEvents TextBox_HostSMTP As TextBox
    Friend WithEvents TextBox_Mensaje As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox_Usuario As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents CheckBox_Ssl As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox_Contraseña As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents CheckBox_IsBodyHtml As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox_Puerto As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ProbarPuertosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EnviarEmailToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ObtenerInfoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProbarPuertosToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
End Class
