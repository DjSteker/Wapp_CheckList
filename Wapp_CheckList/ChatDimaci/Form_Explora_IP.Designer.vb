<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Explora_IP
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
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label_EstadoApp = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ListView_a_IP = New System.Windows.Forms.ListView()
        Me.addressColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.addressTypeColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.Nombre_tipo = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ListView_ipSelect = New System.Windows.Forms.ListView()
        Me.ColumnHeader_1IPv6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader_2IPv6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader_3IPv6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.bytesReceivedTextLabel = New System.Windows.Forms.Label()
        Me.speedTextLabel = New System.Windows.Forms.Label()
        Me.speedLabel = New System.Windows.Forms.Label()
        Me.bytesReceivedLabel = New System.Windows.Forms.Label()
        Me.operationalStatusTextLabel = New System.Windows.Forms.Label()
        Me.operationalStatusLabel = New System.Windows.Forms.Label()
        Me.supportsMulticastTextLabel = New System.Windows.Forms.Label()
        Me.supportsMulticastLabel = New System.Windows.Forms.Label()
        Me.bytesSentTextLabel = New System.Windows.Forms.Label()
        Me.ComboBox_networkInterfaces = New System.Windows.Forms.ComboBox()
        Me.bytesSentLabel = New System.Windows.Forms.Label()
        Me.dnsSuffixTextLabel = New System.Windows.Forms.Label()
        Me.dnsSuffixLabel = New System.Windows.Forms.Label()
        Me.interfacesLabel = New System.Windows.Forms.Label()
        Me.networkAvailabilityTextLabel = New System.Windows.Forms.Label()
        Me.networkAvailabilityLabel = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label_IpPublica = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label_PakUniRecivido = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.updateInfoTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Button_EncendidoTimer = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.UC_GraficaV12 = New UC_GraficaV1()
        Me.UC_GraficaV11 = New UC_GraficaV1()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(314, 142)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(45, 13)
        Me.Label17.TabIndex = 66
        Me.Label17.Text = "Label17"
        '
        'Label_EstadoApp
        '
        Me.Label_EstadoApp.AutoSize = True
        Me.Label_EstadoApp.Location = New System.Drawing.Point(624, 357)
        Me.Label_EstadoApp.Name = "Label_EstadoApp"
        Me.Label_EstadoApp.Size = New System.Drawing.Size(40, 13)
        Me.Label_EstadoApp.TabIndex = 68
        Me.Label_EstadoApp.Text = "Estado"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(36, 166)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(842, 185)
        Me.TabControl1.TabIndex = 67
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ListView_a_IP)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(834, 159)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ListView_a_IP
        '
        Me.ListView_a_IP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView_a_IP.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.addressColumnHeader1, Me.addressTypeColumnHeader1, Me.Nombre_tipo})
        Me.ListView_a_IP.FullRowSelect = True
        Me.ListView_a_IP.GridLines = True
        Me.ListView_a_IP.Location = New System.Drawing.Point(2, 3)
        Me.ListView_a_IP.Name = "ListView_a_IP"
        Me.ListView_a_IP.Size = New System.Drawing.Size(829, 153)
        Me.ListView_a_IP.TabIndex = 41
        Me.ListView_a_IP.UseCompatibleStateImageBehavior = False
        Me.ListView_a_IP.View = System.Windows.Forms.View.Details
        '
        'addressColumnHeader1
        '
        Me.addressColumnHeader1.Text = "Address"
        Me.addressColumnHeader1.Width = 300
        '
        'addressTypeColumnHeader1
        '
        Me.addressTypeColumnHeader1.Text = "Type"
        Me.addressTypeColumnHeader1.Width = 250
        '
        'Nombre_tipo
        '
        Me.Nombre_tipo.Text = "tipo"
        Me.Nombre_tipo.Width = 240
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ListView_ipSelect)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(834, 159)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ListView_ipSelect
        '
        Me.ListView_ipSelect.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader_1IPv6, Me.ColumnHeader_2IPv6, Me.ColumnHeader_3IPv6})
        Me.ListView_ipSelect.Location = New System.Drawing.Point(6, 7)
        Me.ListView_ipSelect.Name = "ListView_ipSelect"
        Me.ListView_ipSelect.Size = New System.Drawing.Size(822, 146)
        Me.ListView_ipSelect.TabIndex = 0
        Me.ListView_ipSelect.UseCompatibleStateImageBehavior = False
        Me.ListView_ipSelect.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader_1IPv6
        '
        Me.ColumnHeader_1IPv6.Text = "Valor"
        Me.ColumnHeader_1IPv6.Width = 215
        '
        'ColumnHeader_2IPv6
        '
        Me.ColumnHeader_2IPv6.Text = "Typo"
        Me.ColumnHeader_2IPv6.Width = 186
        '
        'ColumnHeader_3IPv6
        '
        Me.ColumnHeader_3IPv6.Text = "Detalle"
        Me.ColumnHeader_3IPv6.Width = 323
        '
        'bytesReceivedTextLabel
        '
        Me.bytesReceivedTextLabel.Location = New System.Drawing.Point(136, 106)
        Me.bytesReceivedTextLabel.Name = "bytesReceivedTextLabel"
        Me.bytesReceivedTextLabel.Size = New System.Drawing.Size(158, 16)
        Me.bytesReceivedTextLabel.TabIndex = 59
        Me.bytesReceivedTextLabel.Text = "0"
        '
        'speedTextLabel
        '
        Me.speedTextLabel.Location = New System.Drawing.Point(425, 106)
        Me.speedTextLabel.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.speedTextLabel.Name = "speedTextLabel"
        Me.speedTextLabel.Size = New System.Drawing.Size(119, 22)
        Me.speedTextLabel.TabIndex = 61
        Me.speedTextLabel.Text = "100"
        '
        'speedLabel
        '
        Me.speedLabel.Location = New System.Drawing.Point(314, 106)
        Me.speedLabel.Name = "speedLabel"
        Me.speedLabel.Size = New System.Drawing.Size(88, 18)
        Me.speedLabel.TabIndex = 60
        Me.speedLabel.Text = "Speed:"
        '
        'bytesReceivedLabel
        '
        Me.bytesReceivedLabel.Location = New System.Drawing.Point(40, 106)
        Me.bytesReceivedLabel.Name = "bytesReceivedLabel"
        Me.bytesReceivedLabel.Size = New System.Drawing.Size(88, 17)
        Me.bytesReceivedLabel.TabIndex = 58
        Me.bytesReceivedLabel.Text = "Bytes Received:"
        '
        'operationalStatusTextLabel
        '
        Me.operationalStatusTextLabel.Location = New System.Drawing.Point(425, 88)
        Me.operationalStatusTextLabel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 3)
        Me.operationalStatusTextLabel.Name = "operationalStatusTextLabel"
        Me.operationalStatusTextLabel.Size = New System.Drawing.Size(113, 16)
        Me.operationalStatusTextLabel.TabIndex = 53
        Me.operationalStatusTextLabel.Text = "Up"
        '
        'operationalStatusLabel
        '
        Me.operationalStatusLabel.Location = New System.Drawing.Point(314, 88)
        Me.operationalStatusLabel.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.operationalStatusLabel.Name = "operationalStatusLabel"
        Me.operationalStatusLabel.Size = New System.Drawing.Size(104, 15)
        Me.operationalStatusLabel.TabIndex = 52
        Me.operationalStatusLabel.Text = "Operational Status:"
        '
        'supportsMulticastTextLabel
        '
        Me.supportsMulticastTextLabel.Location = New System.Drawing.Point(425, 69)
        Me.supportsMulticastTextLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.supportsMulticastTextLabel.Name = "supportsMulticastTextLabel"
        Me.supportsMulticastTextLabel.Size = New System.Drawing.Size(73, 20)
        Me.supportsMulticastTextLabel.TabIndex = 55
        Me.supportsMulticastTextLabel.Text = "Yes"
        '
        'supportsMulticastLabel
        '
        Me.supportsMulticastLabel.Location = New System.Drawing.Point(314, 69)
        Me.supportsMulticastLabel.Name = "supportsMulticastLabel"
        Me.supportsMulticastLabel.Size = New System.Drawing.Size(104, 21)
        Me.supportsMulticastLabel.TabIndex = 54
        Me.supportsMulticastLabel.Text = "Supports Multicast:"
        '
        'bytesSentTextLabel
        '
        Me.bytesSentTextLabel.Location = New System.Drawing.Point(136, 88)
        Me.bytesSentTextLabel.Name = "bytesSentTextLabel"
        Me.bytesSentTextLabel.Size = New System.Drawing.Size(144, 17)
        Me.bytesSentTextLabel.TabIndex = 57
        Me.bytesSentTextLabel.Text = "0"
        '
        'ComboBox_networkInterfaces
        '
        Me.ComboBox_networkInterfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_networkInterfaces.DropDownWidth = 431
        Me.ComboBox_networkInterfaces.FormattingEnabled = True
        Me.ComboBox_networkInterfaces.Location = New System.Drawing.Point(113, 42)
        Me.ComboBox_networkInterfaces.Margin = New System.Windows.Forms.Padding(1, 3, 3, 3)
        Me.ComboBox_networkInterfaces.Name = "ComboBox_networkInterfaces"
        Me.ComboBox_networkInterfaces.Size = New System.Drawing.Size(467, 21)
        Me.ComboBox_networkInterfaces.TabIndex = 48
        '
        'bytesSentLabel
        '
        Me.bytesSentLabel.Location = New System.Drawing.Point(39, 88)
        Me.bytesSentLabel.Name = "bytesSentLabel"
        Me.bytesSentLabel.Size = New System.Drawing.Size(89, 18)
        Me.bytesSentLabel.TabIndex = 56
        Me.bytesSentLabel.Text = "Bytes Sent:"
        '
        'dnsSuffixTextLabel
        '
        Me.dnsSuffixTextLabel.Location = New System.Drawing.Point(134, 69)
        Me.dnsSuffixTextLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.dnsSuffixTextLabel.Name = "dnsSuffixTextLabel"
        Me.dnsSuffixTextLabel.Size = New System.Drawing.Size(159, 23)
        Me.dnsSuffixTextLabel.TabIndex = 63
        Me.dnsSuffixTextLabel.Text = "n/a"
        '
        'dnsSuffixLabel
        '
        Me.dnsSuffixLabel.Location = New System.Drawing.Point(39, 69)
        Me.dnsSuffixLabel.Name = "dnsSuffixLabel"
        Me.dnsSuffixLabel.Size = New System.Drawing.Size(68, 18)
        Me.dnsSuffixLabel.TabIndex = 62
        Me.dnsSuffixLabel.Text = "DNS Suffix:"
        '
        'interfacesLabel
        '
        Me.interfacesLabel.Location = New System.Drawing.Point(39, 43)
        Me.interfacesLabel.Name = "interfacesLabel"
        Me.interfacesLabel.Size = New System.Drawing.Size(72, 20)
        Me.interfacesLabel.TabIndex = 49
        Me.interfacesLabel.Text = "Interfaces:"
        '
        'networkAvailabilityTextLabel
        '
        Me.networkAvailabilityTextLabel.Location = New System.Drawing.Point(150, 23)
        Me.networkAvailabilityTextLabel.Name = "networkAvailabilityTextLabel"
        Me.networkAvailabilityTextLabel.Size = New System.Drawing.Size(380, 20)
        Me.networkAvailabilityTextLabel.TabIndex = 51
        Me.networkAvailabilityTextLabel.Text = "At least one network interface is up"
        '
        'networkAvailabilityLabel
        '
        Me.networkAvailabilityLabel.Location = New System.Drawing.Point(39, 23)
        Me.networkAvailabilityLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.networkAvailabilityLabel.Name = "networkAvailabilityLabel"
        Me.networkAvailabilityLabel.Size = New System.Drawing.Size(106, 19)
        Me.networkAvailabilityLabel.TabIndex = 50
        Me.networkAvailabilityLabel.Text = "Network Availability:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label_IpPublica)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label_PakUniRecivido)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(585, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(293, 142)
        Me.Panel1.TabIndex = 47
        '
        'Label_IpPublica
        '
        Me.Label_IpPublica.AutoSize = True
        Me.Label_IpPublica.Location = New System.Drawing.Point(39, 124)
        Me.Label_IpPublica.Name = "Label_IpPublica"
        Me.Label_IpPublica.Size = New System.Drawing.Size(54, 13)
        Me.Label_IpPublica.TabIndex = 50
        Me.Label_IpPublica.Text = "IP publica"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(182, 101)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 13)
        Me.Label13.TabIndex = 49
        Me.Label13.Text = "Label13"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(182, 88)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 48
        Me.Label14.Text = "Label14"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(38, 88)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(138, 13)
        Me.Label15.TabIndex = 47
        Me.Label15.Text = "IncomingPacketsWithErrors"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(39, 101)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(137, 13)
        Me.Label16.TabIndex = 46
        Me.Label16.Text = "IncomingPacketsDiscarded"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(182, 76)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 13)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "Label12"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(182, 63)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 13)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "Label11"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(28, 63)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(148, 13)
        Me.Label10.TabIndex = 43
        Me.Label10.Text = "NonUnicastPacketsReceived"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(52, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(124, 13)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "NonUnicastPacketsSent"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(182, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Label7"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(72, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 13)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "OutputQueueLength"
        '
        'Label_PakUniRecivido
        '
        Me.Label_PakUniRecivido.AutoSize = True
        Me.Label_PakUniRecivido.Location = New System.Drawing.Point(182, 50)
        Me.Label_PakUniRecivido.Name = "Label_PakUniRecivido"
        Me.Label_PakUniRecivido.Size = New System.Drawing.Size(65, 13)
        Me.Label_PakUniRecivido.TabIndex = 39
        Me.Label_PakUniRecivido.Text = "UniRecivido"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(182, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Label5"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(182, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Label6"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(48, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "UnicastPacketsReceived"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(72, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 13)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "UnicastPacketsSent"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "IncomingUnknownProtocolPackets"
        '
        'updateInfoTimer
        '
        Me.updateInfoTimer.Enabled = True
        Me.updateInfoTimer.Interval = 1000
        '
        'Button_EncendidoTimer
        '
        Me.Button_EncendidoTimer.Location = New System.Drawing.Point(827, 489)
        Me.Button_EncendidoTimer.Name = "Button_EncendidoTimer"
        Me.Button_EncendidoTimer.Size = New System.Drawing.Size(75, 23)
        Me.Button_EncendidoTimer.TabIndex = 69
        Me.Button_EncendidoTimer.Text = "Parar"
        Me.Button_EncendidoTimer.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(410, 489)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(45, 13)
        Me.Label19.TabIndex = 70
        Me.Label19.Text = "Label19"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(24, 489)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 13)
        Me.Label18.TabIndex = 71
        Me.Label18.Text = "Label18"
        '
        'UC_GraficaV12
        '
        Me.UC_GraficaV12.Location = New System.Drawing.Point(88, 357)
        Me.UC_GraficaV12.Name = "UC_GraficaV12"
        Me.UC_GraficaV12.Size = New System.Drawing.Size(150, 150)
        Me.UC_GraficaV12.TabIndex = 64
        '
        'UC_GraficaV11
        '
        Me.UC_GraficaV11.Location = New System.Drawing.Point(461, 357)
        Me.UC_GraficaV11.Name = "UC_GraficaV11"
        Me.UC_GraficaV11.Size = New System.Drawing.Size(150, 150)
        Me.UC_GraficaV11.TabIndex = 65
        '
        'Form_Explora_IP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 524)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Button_EncendidoTimer)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label_EstadoApp)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.bytesReceivedTextLabel)
        Me.Controls.Add(Me.speedTextLabel)
        Me.Controls.Add(Me.speedLabel)
        Me.Controls.Add(Me.bytesReceivedLabel)
        Me.Controls.Add(Me.operationalStatusTextLabel)
        Me.Controls.Add(Me.operationalStatusLabel)
        Me.Controls.Add(Me.supportsMulticastTextLabel)
        Me.Controls.Add(Me.supportsMulticastLabel)
        Me.Controls.Add(Me.bytesSentTextLabel)
        Me.Controls.Add(Me.ComboBox_networkInterfaces)
        Me.Controls.Add(Me.bytesSentLabel)
        Me.Controls.Add(Me.dnsSuffixTextLabel)
        Me.Controls.Add(Me.dnsSuffixLabel)
        Me.Controls.Add(Me.interfacesLabel)
        Me.Controls.Add(Me.networkAvailabilityTextLabel)
        Me.Controls.Add(Me.networkAvailabilityLabel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.UC_GraficaV12)
        Me.Controls.Add(Me.UC_GraficaV11)
        Me.Name = "Form_Explora_IP"
        Me.Text = "Form_Explora_IP"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label_EstadoApp As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Public WithEvents ListView_a_IP As System.Windows.Forms.ListView
    Friend WithEvents addressColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents addressTypeColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Nombre_tipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents bytesReceivedTextLabel As System.Windows.Forms.Label
    Friend WithEvents speedTextLabel As System.Windows.Forms.Label
    Friend WithEvents speedLabel As System.Windows.Forms.Label
    Friend WithEvents bytesReceivedLabel As System.Windows.Forms.Label
    Friend WithEvents operationalStatusTextLabel As System.Windows.Forms.Label
    Friend WithEvents operationalStatusLabel As System.Windows.Forms.Label
    Friend WithEvents supportsMulticastTextLabel As System.Windows.Forms.Label
    Friend WithEvents supportsMulticastLabel As System.Windows.Forms.Label
    Friend WithEvents bytesSentTextLabel As System.Windows.Forms.Label
    Friend WithEvents ComboBox_networkInterfaces As System.Windows.Forms.ComboBox
    Friend WithEvents bytesSentLabel As System.Windows.Forms.Label
    Friend WithEvents dnsSuffixTextLabel As System.Windows.Forms.Label
    Friend WithEvents dnsSuffixLabel As System.Windows.Forms.Label
    Friend WithEvents interfacesLabel As System.Windows.Forms.Label
    Friend WithEvents networkAvailabilityTextLabel As System.Windows.Forms.Label
    Friend WithEvents networkAvailabilityLabel As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label_IpPublica As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label_PakUniRecivido As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UC_GraficaV12 As UC_GraficaV1
    Friend WithEvents UC_GraficaV11 As UC_GraficaV1
    Friend WithEvents updateInfoTimer As System.Windows.Forms.Timer
    Friend WithEvents Button_EncendidoTimer As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ListView_ipSelect As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader_1IPv6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader_2IPv6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader_3IPv6 As System.Windows.Forms.ColumnHeader
End Class
