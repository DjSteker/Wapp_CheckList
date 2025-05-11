<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_InforedWAN
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button_InterfazRed_VB = New System.Windows.Forms.Button()
        Me.Button_netstat = New System.Windows.Forms.Button()
        Me.TextBox_URL = New System.Windows.Forms.TextBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Button_DNS = New System.Windows.Forms.Button()
        Me.Button_tracert = New System.Windows.Forms.Button()
        Me.Button_PropiedadesConexion = New System.Windows.Forms.Button()
        Me.Button_GetMAC = New System.Windows.Forms.Button()
        Me.TextBox_TamañoMTU = New System.Windows.Forms.TextBox()
        Me.TextBox_IP = New System.Windows.Forms.TextBox()
        Me.RichTextBox_Resultado = New System.Windows.Forms.RichTextBox()
        Me.Button_PingMTU = New System.Windows.Forms.Button()
        Me.Button_ARP = New System.Windows.Forms.Button()
        Me.Button_Lookup = New System.Windows.Forms.Button()
        Me.Button_netView = New System.Windows.Forms.Button()
        Me.Button_InterfazRed = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label_Gateway = New System.Windows.Forms.Label()
        Me.TextBox_Gateway = New System.Windows.Forms.TextBox()
        Me.Label_URL = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label_MTU = New System.Windows.Forms.Label()
        Me.Label_IP = New System.Windows.Forms.Label()
        Me.TextBox_MascaraRed = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button_Ipconfig = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_InterfazRed_VB
        '
        Me.Button_InterfazRed_VB.Location = New System.Drawing.Point(407, 8)
        Me.Button_InterfazRed_VB.Name = "Button_InterfazRed_VB"
        Me.Button_InterfazRed_VB.Size = New System.Drawing.Size(85, 70)
        Me.Button_InterfazRed_VB.TabIndex = 73
        Me.Button_InterfazRed_VB.Text = "interfaz de red"
        Me.Button_InterfazRed_VB.UseVisualStyleBackColor = True
        '
        'Button_netstat
        '
        Me.Button_netstat.Location = New System.Drawing.Point(606, 8)
        Me.Button_netstat.Name = "Button_netstat"
        Me.Button_netstat.Size = New System.Drawing.Size(85, 70)
        Me.Button_netstat.TabIndex = 72
        Me.Button_netstat.Text = "netstat"
        Me.Button_netstat.UseVisualStyleBackColor = True
        '
        'TextBox_URL
        '
        Me.TextBox_URL.Location = New System.Drawing.Point(55, 160)
        Me.TextBox_URL.Name = "TextBox_URL"
        Me.TextBox_URL.Size = New System.Drawing.Size(414, 20)
        Me.TextBox_URL.TabIndex = 71
        Me.TextBox_URL.Text = "google.com"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(830, 12)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(470, 186)
        Me.RichTextBox1.TabIndex = 70
        Me.RichTextBox1.Text = ""
        '
        'Button_DNS
        '
        Me.Button_DNS.Location = New System.Drawing.Point(191, 62)
        Me.Button_DNS.Name = "Button_DNS"
        Me.Button_DNS.Size = New System.Drawing.Size(85, 70)
        Me.Button_DNS.TabIndex = 69
        Me.Button_DNS.Text = "DNS"
        Me.Button_DNS.UseVisualStyleBackColor = True
        '
        'Button_tracert
        '
        Me.Button_tracert.Location = New System.Drawing.Point(882, 8)
        Me.Button_tracert.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button_tracert.Name = "Button_tracert"
        Me.Button_tracert.Size = New System.Drawing.Size(85, 70)
        Me.Button_tracert.TabIndex = 68
        Me.Button_tracert.Text = "tracert"
        Me.Button_tracert.UseVisualStyleBackColor = True
        '
        'Button_PropiedadesConexion
        '
        Me.Button_PropiedadesConexion.Location = New System.Drawing.Point(6, 6)
        Me.Button_PropiedadesConexion.Name = "Button_PropiedadesConexion"
        Me.Button_PropiedadesConexion.Size = New System.Drawing.Size(337, 50)
        Me.Button_PropiedadesConexion.TabIndex = 67
        Me.Button_PropiedadesConexion.Text = "Propiedades conexión"
        Me.Button_PropiedadesConexion.UseVisualStyleBackColor = True
        '
        'Button_GetMAC
        '
        Me.Button_GetMAC.Location = New System.Drawing.Point(7, 62)
        Me.Button_GetMAC.Name = "Button_GetMAC"
        Me.Button_GetMAC.Size = New System.Drawing.Size(85, 70)
        Me.Button_GetMAC.TabIndex = 66
        Me.Button_GetMAC.Text = "Get MAC"
        Me.Button_GetMAC.UseVisualStyleBackColor = True
        '
        'TextBox_TamañoMTU
        '
        Me.TextBox_TamañoMTU.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_TamañoMTU.Location = New System.Drawing.Point(55, 62)
        Me.TextBox_TamañoMTU.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox_TamañoMTU.Name = "TextBox_TamañoMTU"
        Me.TextBox_TamañoMTU.Size = New System.Drawing.Size(150, 26)
        Me.TextBox_TamañoMTU.TabIndex = 65
        Me.TextBox_TamañoMTU.Text = "1472"
        '
        'TextBox_IP
        '
        Me.TextBox_IP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_IP.Location = New System.Drawing.Point(55, 26)
        Me.TextBox_IP.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox_IP.Name = "TextBox_IP"
        Me.TextBox_IP.Size = New System.Drawing.Size(150, 26)
        Me.TextBox_IP.TabIndex = 64
        Me.TextBox_IP.Text = "8.8.8.8"
        '
        'RichTextBox_Resultado
        '
        Me.RichTextBox_Resultado.Location = New System.Drawing.Point(13, 379)
        Me.RichTextBox_Resultado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RichTextBox_Resultado.Name = "RichTextBox_Resultado"
        Me.RichTextBox_Resultado.Size = New System.Drawing.Size(1283, 423)
        Me.RichTextBox_Resultado.TabIndex = 63
        Me.RichTextBox_Resultado.Text = ""
        '
        'Button_PingMTU
        '
        Me.Button_PingMTU.Location = New System.Drawing.Point(1187, 8)
        Me.Button_PingMTU.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button_PingMTU.Name = "Button_PingMTU"
        Me.Button_PingMTU.Size = New System.Drawing.Size(85, 70)
        Me.Button_PingMTU.TabIndex = 62
        Me.Button_PingMTU.Text = "PING MTU"
        Me.Button_PingMTU.UseVisualStyleBackColor = True
        '
        'Button_ARP
        '
        Me.Button_ARP.Location = New System.Drawing.Point(974, 8)
        Me.Button_ARP.Name = "Button_ARP"
        Me.Button_ARP.Size = New System.Drawing.Size(85, 70)
        Me.Button_ARP.TabIndex = 74
        Me.Button_ARP.Text = "ARP"
        Me.Button_ARP.UseVisualStyleBackColor = True
        '
        'Button_Lookup
        '
        Me.Button_Lookup.Location = New System.Drawing.Point(99, 62)
        Me.Button_Lookup.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button_Lookup.Name = "Button_Lookup"
        Me.Button_Lookup.Size = New System.Drawing.Size(85, 70)
        Me.Button_Lookup.TabIndex = 75
        Me.Button_Lookup.Text = "Lookup"
        Me.Button_Lookup.UseVisualStyleBackColor = True
        '
        'Button_netView
        '
        Me.Button_netView.Location = New System.Drawing.Point(789, 8)
        Me.Button_netView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button_netView.Name = "Button_netView"
        Me.Button_netView.Size = New System.Drawing.Size(85, 70)
        Me.Button_netView.TabIndex = 76
        Me.Button_netView.Text = "net view"
        Me.Button_netView.UseVisualStyleBackColor = True
        '
        'Button_InterfazRed
        '
        Me.Button_InterfazRed.Location = New System.Drawing.Point(499, 8)
        Me.Button_InterfazRed.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button_InterfazRed.Name = "Button_InterfazRed"
        Me.Button_InterfazRed.Size = New System.Drawing.Size(85, 70)
        Me.Button_InterfazRed.TabIndex = 77
        Me.Button_InterfazRed.Text = "interfaz de red"
        Me.Button_InterfazRed.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label_Gateway)
        Me.GroupBox1.Controls.Add(Me.TextBox_Gateway)
        Me.GroupBox1.Controls.Add(Me.Label_URL)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label_MTU)
        Me.GroupBox1.Controls.Add(Me.Label_IP)
        Me.GroupBox1.Controls.Add(Me.TextBox_MascaraRed)
        Me.GroupBox1.Controls.Add(Me.TextBox_IP)
        Me.GroupBox1.Controls.Add(Me.TextBox_TamañoMTU)
        Me.GroupBox1.Controls.Add(Me.TextBox_URL)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(812, 186)
        Me.GroupBox1.TabIndex = 78
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'Label_Gateway
        '
        Me.Label_Gateway.AutoSize = True
        Me.Label_Gateway.Location = New System.Drawing.Point(263, 70)
        Me.Label_Gateway.Name = "Label_Gateway"
        Me.Label_Gateway.Size = New System.Drawing.Size(49, 13)
        Me.Label_Gateway.TabIndex = 78
        Me.Label_Gateway.Text = "Gateway"
        '
        'TextBox_Gateway
        '
        Me.TextBox_Gateway.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Gateway.Location = New System.Drawing.Point(319, 62)
        Me.TextBox_Gateway.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox_Gateway.Name = "TextBox_Gateway"
        Me.TextBox_Gateway.Size = New System.Drawing.Size(150, 26)
        Me.TextBox_Gateway.TabIndex = 77
        Me.TextBox_Gateway.Text = "192.168.1.1"
        '
        'Label_URL
        '
        Me.Label_URL.AutoSize = True
        Me.Label_URL.Location = New System.Drawing.Point(19, 163)
        Me.Label_URL.Name = "Label_URL"
        Me.Label_URL.Size = New System.Drawing.Size(29, 13)
        Me.Label_URL.TabIndex = 76
        Me.Label_URL.Text = "URL"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(246, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "Mascara red"
        '
        'Label_MTU
        '
        Me.Label_MTU.AutoSize = True
        Me.Label_MTU.Location = New System.Drawing.Point(17, 70)
        Me.Label_MTU.Name = "Label_MTU"
        Me.Label_MTU.Size = New System.Drawing.Size(31, 13)
        Me.Label_MTU.TabIndex = 74
        Me.Label_MTU.Text = "MTU"
        '
        'Label_IP
        '
        Me.Label_IP.AutoSize = True
        Me.Label_IP.Location = New System.Drawing.Point(31, 34)
        Me.Label_IP.Name = "Label_IP"
        Me.Label_IP.Size = New System.Drawing.Size(17, 13)
        Me.Label_IP.TabIndex = 73
        Me.Label_IP.Text = "IP"
        '
        'TextBox_MascaraRed
        '
        Me.TextBox_MascaraRed.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_MascaraRed.Location = New System.Drawing.Point(319, 26)
        Me.TextBox_MascaraRed.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox_MascaraRed.Name = "TextBox_MascaraRed"
        Me.TextBox_MascaraRed.Size = New System.Drawing.Size(150, 26)
        Me.TextBox_MascaraRed.TabIndex = 72
        Me.TextBox_MascaraRed.Text = "255.255.255.0"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(13, 204)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1287, 167)
        Me.TabControl1.TabIndex = 79
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button_Ipconfig)
        Me.TabPage1.Controls.Add(Me.Button_DNS)
        Me.TabPage1.Controls.Add(Me.Button_PropiedadesConexion)
        Me.TabPage1.Controls.Add(Me.Button_InterfazRed)
        Me.TabPage1.Controls.Add(Me.Button_netstat)
        Me.TabPage1.Controls.Add(Me.Button_netView)
        Me.TabPage1.Controls.Add(Me.Button_InterfazRed_VB)
        Me.TabPage1.Controls.Add(Me.Button_Lookup)
        Me.TabPage1.Controls.Add(Me.Button_ARP)
        Me.TabPage1.Controls.Add(Me.Button_PingMTU)
        Me.TabPage1.Controls.Add(Me.Button_tracert)
        Me.TabPage1.Controls.Add(Me.Button_GetMAC)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1279, 141)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button_Ipconfig
        '
        Me.Button_Ipconfig.Location = New System.Drawing.Point(1094, 8)
        Me.Button_Ipconfig.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button_Ipconfig.Name = "Button_Ipconfig"
        Me.Button_Ipconfig.Size = New System.Drawing.Size(85, 70)
        Me.Button_Ipconfig.TabIndex = 78
        Me.Button_Ipconfig.Text = "Ipconfig"
        Me.Button_Ipconfig.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1279, 141)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Form_InforedWAN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1312, 837)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.RichTextBox_Resultado)
        Me.Name = "Form_InforedWAN"
        Me.Text = "Form_InforedNAT"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button_InterfazRed_VB As Button
    Friend WithEvents Button_netstat As Button
    Friend WithEvents TextBox_URL As TextBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Button_DNS As Button
    Friend WithEvents Button_tracert As Button
    Friend WithEvents Button_PropiedadesConexion As Button
    Friend WithEvents Button_GetMAC As Button
    Friend WithEvents TextBox_TamañoMTU As TextBox
    Friend WithEvents TextBox_IP As TextBox
    Friend WithEvents RichTextBox_Resultado As RichTextBox
    Friend WithEvents Button_PingMTU As Button
    Friend WithEvents Button_ARP As Button
    Friend WithEvents Button_Lookup As Button
    Friend WithEvents Button_netView As Button
    Friend WithEvents Button_InterfazRed As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label_URL As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label_MTU As Label
    Friend WithEvents Label_IP As Label
    Friend WithEvents TextBox_MascaraRed As TextBox
    Friend WithEvents Label_Gateway As Label
    Friend WithEvents TextBox_Gateway As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Button_Ipconfig As Button
End Class
