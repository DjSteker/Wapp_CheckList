<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_ExploradorWeb
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_ExploradorWeb))
        Me.Button_Nevegar = New System.Windows.Forms.Button()
        Me.CheckBox_Rellamar = New System.Windows.Forms.CheckBox()
        Me.TextBox_TiempoRefreco = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.TextBox_URL = New System.Windows.Forms.TextBox()
        Me.TextBox_DNS = New System.Windows.Forms.TextBox()
        Me.Label_DNS = New System.Windows.Forms.Label()
        Me.Label_Encriptacion = New System.Windows.Forms.Label()
        Me.ProgressBar_Web = New System.Windows.Forms.ProgressBar()
        Me.Label_Estado = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ComboBox_ListaIP = New System.Windows.Forms.ComboBox()
        Me.ComboBox_DestIp = New System.Windows.Forms.ComboBox()
        Me.TextBox_DestIp = New System.Windows.Forms.TextBox()
        Me.TextBox_DNSport = New System.Windows.Forms.TextBox()
        Me.TextBox_DNSip = New System.Windows.Forms.TextBox()
        Me.CheckBox_Descargas = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_Nevegar
        '
        Me.Button_Nevegar.Location = New System.Drawing.Point(3, 1)
        Me.Button_Nevegar.Name = "Button_Nevegar"
        Me.Button_Nevegar.Size = New System.Drawing.Size(75, 23)
        Me.Button_Nevegar.TabIndex = 0
        Me.Button_Nevegar.Text = "Nevegar"
        Me.Button_Nevegar.UseVisualStyleBackColor = True
        '
        'CheckBox_Rellamar
        '
        Me.CheckBox_Rellamar.AutoSize = True
        Me.CheckBox_Rellamar.Location = New System.Drawing.Point(600, 5)
        Me.CheckBox_Rellamar.Name = "CheckBox_Rellamar"
        Me.CheckBox_Rellamar.Size = New System.Drawing.Size(67, 17)
        Me.CheckBox_Rellamar.TabIndex = 1
        Me.CheckBox_Rellamar.Text = "Rellamar"
        Me.CheckBox_Rellamar.UseVisualStyleBackColor = True
        '
        'TextBox_TiempoRefreco
        '
        Me.TextBox_TiempoRefreco.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_TiempoRefreco.Location = New System.Drawing.Point(673, 3)
        Me.TextBox_TiempoRefreco.Name = "TextBox_TiempoRefreco"
        Me.TextBox_TiempoRefreco.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_TiempoRefreco.TabIndex = 2
        Me.TextBox_TiempoRefreco.Text = "1000"
        '
        'Timer1
        '
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser1.Location = New System.Drawing.Point(12, 54)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(776, 384)
        Me.WebBrowser1.TabIndex = 3
        '
        'TextBox_URL
        '
        Me.TextBox_URL.Location = New System.Drawing.Point(3, 26)
        Me.TextBox_URL.Name = "TextBox_URL"
        Me.TextBox_URL.Size = New System.Drawing.Size(770, 20)
        Me.TextBox_URL.TabIndex = 4
        Me.TextBox_URL.Text = "grep.geek"
        '
        'TextBox_DNS
        '
        Me.TextBox_DNS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_DNS.Location = New System.Drawing.Point(494, 4)
        Me.TextBox_DNS.Name = "TextBox_DNS"
        Me.TextBox_DNS.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_DNS.TabIndex = 5
        Me.TextBox_DNS.Text = "63.231.92.27"
        '
        'Label_DNS
        '
        Me.Label_DNS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_DNS.AutoSize = True
        Me.Label_DNS.Location = New System.Drawing.Point(458, 7)
        Me.Label_DNS.Name = "Label_DNS"
        Me.Label_DNS.Size = New System.Drawing.Size(30, 13)
        Me.Label_DNS.TabIndex = 6
        Me.Label_DNS.Text = "DNS"
        '
        'Label_Encriptacion
        '
        Me.Label_Encriptacion.AutoSize = True
        Me.Label_Encriptacion.Location = New System.Drawing.Point(84, 6)
        Me.Label_Encriptacion.Name = "Label_Encriptacion"
        Me.Label_Encriptacion.Size = New System.Drawing.Size(66, 13)
        Me.Label_Encriptacion.TabIndex = 7
        Me.Label_Encriptacion.Text = "Encriptación"
        '
        'ProgressBar_Web
        '
        Me.ProgressBar_Web.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar_Web.Location = New System.Drawing.Point(3, 1)
        Me.ProgressBar_Web.Name = "ProgressBar_Web"
        Me.ProgressBar_Web.Size = New System.Drawing.Size(100, 12)
        Me.ProgressBar_Web.TabIndex = 9
        '
        'Label_Estado
        '
        Me.Label_Estado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label_Estado.AutoSize = True
        Me.Label_Estado.BackColor = System.Drawing.Color.Transparent
        Me.Label_Estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Estado.Location = New System.Drawing.Point(109, 1)
        Me.Label_Estado.Name = "Label_Estado"
        Me.Label_Estado.Size = New System.Drawing.Size(61, 12)
        Me.Label_Estado.TabIndex = 8
        Me.Label_Estado.Text = "Label_Estado"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.ComboBox_ListaIP)
        Me.Panel1.Controls.Add(Me.ComboBox_DestIp)
        Me.Panel1.Controls.Add(Me.TextBox_DestIp)
        Me.Panel1.Controls.Add(Me.TextBox_DNSport)
        Me.Panel1.Controls.Add(Me.TextBox_DNSip)
        Me.Panel1.Controls.Add(Me.TextBox_URL)
        Me.Panel1.Controls.Add(Me.Button_Nevegar)
        Me.Panel1.Controls.Add(Me.CheckBox_Rellamar)
        Me.Panel1.Controls.Add(Me.Label_Encriptacion)
        Me.Panel1.Controls.Add(Me.TextBox_TiempoRefreco)
        Me.Panel1.Controls.Add(Me.Label_DNS)
        Me.Panel1.Controls.Add(Me.TextBox_DNS)
        Me.Panel1.Location = New System.Drawing.Point(12, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(776, 50)
        Me.Panel1.TabIndex = 10
        '
        'ComboBox_ListaIP
        '
        Me.ComboBox_ListaIP.FormattingEnabled = True
        Me.ComboBox_ListaIP.Location = New System.Drawing.Point(292, 4)
        Me.ComboBox_ListaIP.Name = "ComboBox_ListaIP"
        Me.ComboBox_ListaIP.Size = New System.Drawing.Size(77, 21)
        Me.ComboBox_ListaIP.TabIndex = 13
        '
        'ComboBox_DestIp
        '
        Me.ComboBox_DestIp.FormattingEnabled = True
        Me.ComboBox_DestIp.Location = New System.Drawing.Point(375, 4)
        Me.ComboBox_DestIp.Name = "ComboBox_DestIp"
        Me.ComboBox_DestIp.Size = New System.Drawing.Size(77, 21)
        Me.ComboBox_DestIp.TabIndex = 12
        '
        'TextBox_DestIp
        '
        Me.TextBox_DestIp.Location = New System.Drawing.Point(156, 4)
        Me.TextBox_DestIp.Name = "TextBox_DestIp"
        Me.TextBox_DestIp.Size = New System.Drawing.Size(37, 20)
        Me.TextBox_DestIp.TabIndex = 11
        '
        'TextBox_DNSport
        '
        Me.TextBox_DNSport.Location = New System.Drawing.Point(249, 4)
        Me.TextBox_DNSport.Name = "TextBox_DNSport"
        Me.TextBox_DNSport.Size = New System.Drawing.Size(37, 20)
        Me.TextBox_DNSport.TabIndex = 10
        '
        'TextBox_DNSip
        '
        Me.TextBox_DNSip.Location = New System.Drawing.Point(199, 4)
        Me.TextBox_DNSip.Name = "TextBox_DNSip"
        Me.TextBox_DNSip.Size = New System.Drawing.Size(37, 20)
        Me.TextBox_DNSip.TabIndex = 9
        '
        'CheckBox_Descargas
        '
        Me.CheckBox_Descargas.AutoSize = True
        Me.CheckBox_Descargas.Checked = True
        Me.CheckBox_Descargas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_Descargas.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_Descargas.Location = New System.Drawing.Point(712, 1)
        Me.CheckBox_Descargas.Name = "CheckBox_Descargas"
        Me.CheckBox_Descargas.Size = New System.Drawing.Size(61, 14)
        Me.CheckBox_Descargas.TabIndex = 8
        Me.CheckBox_Descargas.Text = "Descargas"
        Me.CheckBox_Descargas.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.ProgressBar_Web)
        Me.Panel2.Controls.Add(Me.Label_Estado)
        Me.Panel2.Controls.Add(Me.CheckBox_Descargas)
        Me.Panel2.Location = New System.Drawing.Point(12, 435)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(776, 15)
        Me.Panel2.TabIndex = 11
        '
        'Form_ExploradorWeb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_ExploradorWeb"
        Me.Text = "Navegador"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button_Nevegar As Button
    Friend WithEvents CheckBox_Rellamar As CheckBox
    Friend WithEvents TextBox_TiempoRefreco As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents TextBox_URL As TextBox
    Friend WithEvents TextBox_DNS As TextBox
    Friend WithEvents Label_DNS As Label
    Friend WithEvents Label_Encriptacion As Label
    Friend WithEvents ProgressBar_Web As ProgressBar
    Friend WithEvents Label_Estado As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents CheckBox_Descargas As CheckBox
    Friend WithEvents TextBox_DNSip As TextBox
    Friend WithEvents TextBox_DNSport As TextBox
    Friend WithEvents TextBox_DestIp As TextBox
    Friend WithEvents ComboBox_DestIp As ComboBox
    Friend WithEvents ComboBox_ListaIP As ComboBox
End Class
