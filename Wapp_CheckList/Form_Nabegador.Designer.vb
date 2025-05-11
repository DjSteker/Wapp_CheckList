<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Nabegador
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
        Me.ComboBox_ListaIP = New System.Windows.Forms.ComboBox()
        Me.ComboBox_DestIp = New System.Windows.Forms.ComboBox()
        Me.TextBox_DestIp = New System.Windows.Forms.TextBox()
        Me.TextBox_DNSport = New System.Windows.Forms.TextBox()
        Me.TextBox_DNSip = New System.Windows.Forms.TextBox()
        Me.Label_DNS = New System.Windows.Forms.Label()
        Me.TextBox_DNS = New System.Windows.Forms.TextBox()
        Me.Button_Parada = New System.Windows.Forms.Button()
        Me.TextBox_URL = New System.Windows.Forms.TextBox()
        Me.Button_Adelante = New System.Windows.Forms.Button()
        Me.Button_Navega = New System.Windows.Forms.Button()
        Me.CheckBox_Descargas = New System.Windows.Forms.CheckBox()
        Me.Button_Agregar = New System.Windows.Forms.Button()
        Me.Button_Atras = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel_Navegacion = New System.Windows.Forms.Panel()
        Me.ProgressBar_Web = New System.Windows.Forms.ProgressBar()
        Me.Label_Estado = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button_Borra = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Panel_Navegacion.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox_ListaIP
        '
        Me.ComboBox_ListaIP.FormattingEnabled = True
        Me.ComboBox_ListaIP.Location = New System.Drawing.Point(189, 34)
        Me.ComboBox_ListaIP.Name = "ComboBox_ListaIP"
        Me.ComboBox_ListaIP.Size = New System.Drawing.Size(92, 21)
        Me.ComboBox_ListaIP.TabIndex = 30
        '
        'ComboBox_DestIp
        '
        Me.ComboBox_DestIp.FormattingEnabled = True
        Me.ComboBox_DestIp.Location = New System.Drawing.Point(287, 34)
        Me.ComboBox_DestIp.Name = "ComboBox_DestIp"
        Me.ComboBox_DestIp.Size = New System.Drawing.Size(92, 21)
        Me.ComboBox_DestIp.TabIndex = 29
        '
        'TextBox_DestIp
        '
        Me.TextBox_DestIp.Location = New System.Drawing.Point(385, 34)
        Me.TextBox_DestIp.Name = "TextBox_DestIp"
        Me.TextBox_DestIp.Size = New System.Drawing.Size(37, 20)
        Me.TextBox_DestIp.TabIndex = 28
        '
        'TextBox_DNSport
        '
        Me.TextBox_DNSport.Location = New System.Drawing.Point(483, 34)
        Me.TextBox_DNSport.Name = "TextBox_DNSport"
        Me.TextBox_DNSport.Size = New System.Drawing.Size(37, 20)
        Me.TextBox_DNSport.TabIndex = 27
        '
        'TextBox_DNSip
        '
        Me.TextBox_DNSip.Location = New System.Drawing.Point(428, 34)
        Me.TextBox_DNSip.Name = "TextBox_DNSip"
        Me.TextBox_DNSip.Size = New System.Drawing.Size(37, 20)
        Me.TextBox_DNSip.TabIndex = 26
        '
        'Label_DNS
        '
        Me.Label_DNS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_DNS.AutoSize = True
        Me.Label_DNS.Location = New System.Drawing.Point(650, 37)
        Me.Label_DNS.Name = "Label_DNS"
        Me.Label_DNS.Size = New System.Drawing.Size(30, 13)
        Me.Label_DNS.TabIndex = 24
        Me.Label_DNS.Text = "DNS"
        '
        'TextBox_DNS
        '
        Me.TextBox_DNS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_DNS.Location = New System.Drawing.Point(686, 34)
        Me.TextBox_DNS.Name = "TextBox_DNS"
        Me.TextBox_DNS.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_DNS.TabIndex = 23
        Me.TextBox_DNS.Text = "63.231.92.27"
        '
        'Button_Parada
        '
        Me.Button_Parada.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Parada.BackColor = System.Drawing.Color.Transparent
        Me.Button_Parada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button_Parada.Location = New System.Drawing.Point(739, 2)
        Me.Button_Parada.Margin = New System.Windows.Forms.Padding(1)
        Me.Button_Parada.Name = "Button_Parada"
        Me.Button_Parada.Size = New System.Drawing.Size(25, 25)
        Me.Button_Parada.TabIndex = 4
        Me.Button_Parada.Text = "Parada"
        Me.Button_Parada.UseVisualStyleBackColor = False
        '
        'TextBox_URL
        '
        Me.TextBox_URL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_URL.Location = New System.Drawing.Point(75, 5)
        Me.TextBox_URL.Name = "TextBox_URL"
        Me.TextBox_URL.Size = New System.Drawing.Size(660, 20)
        Me.TextBox_URL.TabIndex = 3
        Me.TextBox_URL.Text = "https://www.google.es/"
        '
        'Button_Adelante
        '
        Me.Button_Adelante.Location = New System.Drawing.Point(39, 4)
        Me.Button_Adelante.Name = "Button_Adelante"
        Me.Button_Adelante.Size = New System.Drawing.Size(30, 20)
        Me.Button_Adelante.TabIndex = 2
        Me.Button_Adelante.Text = "Button3"
        Me.Button_Adelante.UseVisualStyleBackColor = True
        '
        'Button_Navega
        '
        Me.Button_Navega.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Navega.Location = New System.Drawing.Point(763, 2)
        Me.Button_Navega.Name = "Button_Navega"
        Me.Button_Navega.Size = New System.Drawing.Size(30, 25)
        Me.Button_Navega.TabIndex = 1
        Me.Button_Navega.Text = "navega"
        Me.Button_Navega.UseVisualStyleBackColor = True
        '
        'CheckBox_Descargas
        '
        Me.CheckBox_Descargas.AutoSize = True
        Me.CheckBox_Descargas.Checked = True
        Me.CheckBox_Descargas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_Descargas.Location = New System.Drawing.Point(567, 36)
        Me.CheckBox_Descargas.Name = "CheckBox_Descargas"
        Me.CheckBox_Descargas.Size = New System.Drawing.Size(77, 17)
        Me.CheckBox_Descargas.TabIndex = 25
        Me.CheckBox_Descargas.Text = "Descargas"
        Me.CheckBox_Descargas.UseVisualStyleBackColor = True
        '
        'Button_Agregar
        '
        Me.Button_Agregar.Location = New System.Drawing.Point(5, 32)
        Me.Button_Agregar.Name = "Button_Agregar"
        Me.Button_Agregar.Size = New System.Drawing.Size(33, 22)
        Me.Button_Agregar.TabIndex = 21
        Me.Button_Agregar.Text = "Agregar"
        Me.Button_Agregar.UseVisualStyleBackColor = True
        '
        'Button_Atras
        '
        Me.Button_Atras.Location = New System.Drawing.Point(3, 4)
        Me.Button_Atras.Name = "Button_Atras"
        Me.Button_Atras.Size = New System.Drawing.Size(30, 20)
        Me.Button_Atras.TabIndex = 0
        Me.Button_Atras.Text = "Atras"
        Me.Button_Atras.UseVisualStyleBackColor = True
        '
        'Panel_Navegacion
        '
        Me.Panel_Navegacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_Navegacion.Controls.Add(Me.Button_Parada)
        Me.Panel_Navegacion.Controls.Add(Me.TextBox_URL)
        Me.Panel_Navegacion.Controls.Add(Me.Button_Adelante)
        Me.Panel_Navegacion.Controls.Add(Me.Button_Navega)
        Me.Panel_Navegacion.Controls.Add(Me.Button_Atras)
        Me.Panel_Navegacion.Location = New System.Drawing.Point(2, 2)
        Me.Panel_Navegacion.Name = "Panel_Navegacion"
        Me.Panel_Navegacion.Size = New System.Drawing.Size(796, 30)
        Me.Panel_Navegacion.TabIndex = 20
        '
        'ProgressBar_Web
        '
        Me.ProgressBar_Web.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar_Web.Location = New System.Drawing.Point(2, 435)
        Me.ProgressBar_Web.Name = "ProgressBar_Web"
        Me.ProgressBar_Web.Size = New System.Drawing.Size(100, 13)
        Me.ProgressBar_Web.TabIndex = 19
        '
        'Label_Estado
        '
        Me.Label_Estado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label_Estado.AutoSize = True
        Me.Label_Estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Estado.Location = New System.Drawing.Point(108, 435)
        Me.Label_Estado.Name = "Label_Estado"
        Me.Label_Estado.Size = New System.Drawing.Size(61, 12)
        Me.Label_Estado.TabIndex = 18
        Me.Label_Estado.Text = "Label_Estado"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.WebBrowser1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 20)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(792, 356)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(3, 3)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(786, 350)
        Me.WebBrowser1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 20)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(792, 356)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button_Borra
        '
        Me.Button_Borra.Location = New System.Drawing.Point(45, 32)
        Me.Button_Borra.Name = "Button_Borra"
        Me.Button_Borra.Size = New System.Drawing.Size(31, 22)
        Me.Button_Borra.TabIndex = 22
        Me.Button_Borra.Text = "Quitar"
        Me.Button_Borra.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 54)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(1, 1)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(800, 380)
        Me.TabControl1.TabIndex = 17
        '
        'Form_Nabegador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ComboBox_ListaIP)
        Me.Controls.Add(Me.ComboBox_DestIp)
        Me.Controls.Add(Me.TextBox_DestIp)
        Me.Controls.Add(Me.TextBox_DNSport)
        Me.Controls.Add(Me.TextBox_DNSip)
        Me.Controls.Add(Me.Label_DNS)
        Me.Controls.Add(Me.TextBox_DNS)
        Me.Controls.Add(Me.CheckBox_Descargas)
        Me.Controls.Add(Me.Button_Agregar)
        Me.Controls.Add(Me.Panel_Navegacion)
        Me.Controls.Add(Me.ProgressBar_Web)
        Me.Controls.Add(Me.Label_Estado)
        Me.Controls.Add(Me.Button_Borra)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Form_Nabegador"
        Me.Text = "Form_Nabegador"
        Me.Panel_Navegacion.ResumeLayout(False)
        Me.Panel_Navegacion.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboBox_ListaIP As ComboBox
    Friend WithEvents ComboBox_DestIp As ComboBox
    Friend WithEvents TextBox_DestIp As TextBox
    Friend WithEvents TextBox_DNSport As TextBox
    Friend WithEvents TextBox_DNSip As TextBox
    Friend WithEvents Label_DNS As Label
    Friend WithEvents TextBox_DNS As TextBox
    Friend WithEvents Button_Parada As Button
    Friend WithEvents TextBox_URL As TextBox
    Friend WithEvents Button_Adelante As Button
    Friend WithEvents Button_Navega As Button
    Friend WithEvents CheckBox_Descargas As CheckBox
    Friend WithEvents Button_Agregar As Button
    Friend WithEvents Button_Atras As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Panel_Navegacion As Panel
    Friend WithEvents ProgressBar_Web As ProgressBar
    Friend WithEvents Label_Estado As Label
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Button_Borra As Button
    Friend WithEvents TabControl1 As TabControl
End Class
