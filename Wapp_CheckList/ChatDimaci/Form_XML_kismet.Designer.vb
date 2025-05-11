<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_XML_kismet
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.C_BSSID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_ESSID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_max_rate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_packets = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_beaconrate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_encryption1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_encryption2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_manuf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_channel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_freqmhz = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_maxseenrate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_carrier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_encoding = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_datasize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_client = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.C_client_mac = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_client_manuf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_channelClient = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_Cliente_maxseenrate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_Client_carrier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_Client_encoding = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.C_last_signal_dbm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_last_noise_dbm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_last_signal_rssi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_last_noise_rssi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_min_signal_dbm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_min_noise_dbm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_min_signal_rssi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_min_noise_rssi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_max_signal_dbm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_max_noise_dbm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_max_signal_rssi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_max_noise_rssi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView4 = New System.Windows.Forms.DataGridView()
        Me.C_LLC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_crypt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_fragments = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_retries = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(2, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.C_BSSID, Me.C_ESSID, Me.C_type, Me.C_max_rate, Me.C_packets, Me.C_beaconrate, Me.C_encryption1, Me.C_encryption2, Me.C_manuf, Me.C_channel, Me.C_freqmhz, Me.C_maxseenrate, Me.C_carrier, Me.C_encoding, Me.C_datasize, Me.C_client})
        Me.DataGridView1.Location = New System.Drawing.Point(2, 31)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1145, 275)
        Me.DataGridView1.TabIndex = 1
        '
        'C_BSSID
        '
        Me.C_BSSID.HeaderText = "BSSID"
        Me.C_BSSID.Name = "C_BSSID"
        '
        'C_ESSID
        '
        Me.C_ESSID.HeaderText = "ESSID"
        Me.C_ESSID.Name = "C_ESSID"
        '
        'C_type
        '
        Me.C_type.HeaderText = "type"
        Me.C_type.Name = "C_type"
        '
        'C_max_rate
        '
        Me.C_max_rate.HeaderText = "max-rate"
        Me.C_max_rate.Name = "C_max_rate"
        '
        'C_packets
        '
        Me.C_packets.HeaderText = "packets"
        Me.C_packets.Name = "C_packets"
        '
        'C_beaconrate
        '
        Me.C_beaconrate.HeaderText = "beaconrate"
        Me.C_beaconrate.Name = "C_beaconrate"
        '
        'C_encryption1
        '
        Me.C_encryption1.HeaderText = "encryption"
        Me.C_encryption1.Name = "C_encryption1"
        '
        'C_encryption2
        '
        Me.C_encryption2.HeaderText = "encryption"
        Me.C_encryption2.Name = "C_encryption2"
        '
        'C_manuf
        '
        Me.C_manuf.HeaderText = "manuf"
        Me.C_manuf.Name = "C_manuf"
        '
        'C_channel
        '
        Me.C_channel.HeaderText = "channel"
        Me.C_channel.Name = "C_channel"
        '
        'C_freqmhz
        '
        Me.C_freqmhz.HeaderText = "freqmhz"
        Me.C_freqmhz.Name = "C_freqmhz"
        '
        'C_maxseenrate
        '
        Me.C_maxseenrate.HeaderText = "maxseenrate"
        Me.C_maxseenrate.Name = "C_maxseenrate"
        '
        'C_carrier
        '
        Me.C_carrier.HeaderText = "carrier"
        Me.C_carrier.Name = "C_carrier"
        '
        'C_encoding
        '
        Me.C_encoding.HeaderText = "encoding"
        Me.C_encoding.Name = "C_encoding"
        '
        'C_datasize
        '
        Me.C_datasize.HeaderText = "datasize"
        Me.C_datasize.Name = "C_datasize"
        '
        'C_client
        '
        Me.C_client.HeaderText = "client"
        Me.C_client.Name = "C_client"
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.C_client_mac, Me.C_client_manuf, Me.C_channelClient, Me.C_Cliente_maxseenrate, Me.C_Client_carrier, Me.C_Client_encoding})
        Me.DataGridView2.Location = New System.Drawing.Point(2, 566)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(648, 150)
        Me.DataGridView2.TabIndex = 2
        '
        'C_client_mac
        '
        Me.C_client_mac.HeaderText = "client mac"
        Me.C_client_mac.Name = "C_client_mac"
        '
        'C_client_manuf
        '
        Me.C_client_manuf.HeaderText = "client-manuf"
        Me.C_client_manuf.Name = "C_client_manuf"
        '
        'C_channelClient
        '
        Me.C_channelClient.HeaderText = "channel"
        Me.C_channelClient.Name = "C_channelClient"
        '
        'C_Cliente_maxseenrate
        '
        Me.C_Cliente_maxseenrate.HeaderText = "maxseenrate"
        Me.C_Cliente_maxseenrate.Name = "C_Cliente_maxseenrate"
        '
        'C_Client_carrier
        '
        Me.C_Client_carrier.HeaderText = "carrier"
        Me.C_Client_carrier.Name = "C_Client_carrier"
        '
        'C_Client_encoding
        '
        Me.C_Client_encoding.HeaderText = "encoding"
        Me.C_Client_encoding.Name = "C_Client_encoding"
        '
        'DataGridView3
        '
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.C_last_signal_dbm, Me.C_last_noise_dbm, Me.C_last_signal_rssi, Me.C_last_noise_rssi, Me.C_min_signal_dbm, Me.C_min_noise_dbm, Me.C_min_signal_rssi, Me.C_min_noise_rssi, Me.C_max_signal_dbm, Me.C_max_noise_dbm, Me.C_max_signal_rssi, Me.C_max_noise_rssi})
        Me.DataGridView3.Location = New System.Drawing.Point(656, 566)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.Size = New System.Drawing.Size(568, 150)
        Me.DataGridView3.TabIndex = 3
        '
        'C_last_signal_dbm
        '
        Me.C_last_signal_dbm.HeaderText = "last_signal_dbm"
        Me.C_last_signal_dbm.Name = "C_last_signal_dbm"
        '
        'C_last_noise_dbm
        '
        Me.C_last_noise_dbm.HeaderText = "last_noise_dbm"
        Me.C_last_noise_dbm.Name = "C_last_noise_dbm"
        '
        'C_last_signal_rssi
        '
        Me.C_last_signal_rssi.HeaderText = "last_signal_rssi"
        Me.C_last_signal_rssi.Name = "C_last_signal_rssi"
        '
        'C_last_noise_rssi
        '
        Me.C_last_noise_rssi.HeaderText = "last_noise_rssi"
        Me.C_last_noise_rssi.Name = "C_last_noise_rssi"
        '
        'C_min_signal_dbm
        '
        Me.C_min_signal_dbm.HeaderText = "min_signal_dbm"
        Me.C_min_signal_dbm.Name = "C_min_signal_dbm"
        '
        'C_min_noise_dbm
        '
        Me.C_min_noise_dbm.HeaderText = "min_noise_dbm"
        Me.C_min_noise_dbm.Name = "C_min_noise_dbm"
        '
        'C_min_signal_rssi
        '
        Me.C_min_signal_rssi.HeaderText = "min_signal_rssi"
        Me.C_min_signal_rssi.Name = "C_min_signal_rssi"
        '
        'C_min_noise_rssi
        '
        Me.C_min_noise_rssi.HeaderText = "min_noise_rssi"
        Me.C_min_noise_rssi.Name = "C_min_noise_rssi"
        '
        'C_max_signal_dbm
        '
        Me.C_max_signal_dbm.HeaderText = "max_signal_dbm"
        Me.C_max_signal_dbm.Name = "C_max_signal_dbm"
        '
        'C_max_noise_dbm
        '
        Me.C_max_noise_dbm.HeaderText = "max_noise_dbm"
        Me.C_max_noise_dbm.Name = "C_max_noise_dbm"
        '
        'C_max_signal_rssi
        '
        Me.C_max_signal_rssi.HeaderText = "max_signal_rssi"
        Me.C_max_signal_rssi.Name = "C_max_signal_rssi"
        '
        'C_max_noise_rssi
        '
        Me.C_max_noise_rssi.HeaderText = "max_noise_rssi"
        Me.C_max_noise_rssi.Name = "C_max_noise_rssi"
        '
        'DataGridView4
        '
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView4.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.C_LLC, Me.C_data, Me.C_crypt, Me.C_total, Me.C_fragments, Me.C_retries})
        Me.DataGridView4.Location = New System.Drawing.Point(656, 410)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.Size = New System.Drawing.Size(568, 150)
        Me.DataGridView4.TabIndex = 4
        '
        'C_LLC
        '
        Me.C_LLC.HeaderText = "LLC"
        Me.C_LLC.Name = "C_LLC"
        '
        'C_data
        '
        Me.C_data.HeaderText = "data"
        Me.C_data.Name = "C_data"
        '
        'C_crypt
        '
        Me.C_crypt.HeaderText = "crypt"
        Me.C_crypt.Name = "C_crypt"
        '
        'C_total
        '
        Me.C_total.HeaderText = "total"
        Me.C_total.Name = "C_total"
        '
        'C_fragments
        '
        Me.C_fragments.HeaderText = "fragments"
        Me.C_fragments.Name = "C_fragments"
        '
        'C_retries
        '
        Me.C_retries.HeaderText = "retries"
        Me.C_retries.Name = "C_retries"
        '
        'Form_XML_kismet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1236, 728)
        Me.Controls.Add(Me.DataGridView4)
        Me.Controls.Add(Me.DataGridView3)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form_XML_kismet"
        Me.Text = "Form_XML_kismet"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents C_BSSID As DataGridViewTextBoxColumn
    Friend WithEvents C_ESSID As DataGridViewTextBoxColumn
    Friend WithEvents C_type As DataGridViewTextBoxColumn
    Friend WithEvents C_max_rate As DataGridViewTextBoxColumn
    Friend WithEvents C_packets As DataGridViewTextBoxColumn
    Friend WithEvents C_beaconrate As DataGridViewTextBoxColumn
    Friend WithEvents C_encryption1 As DataGridViewTextBoxColumn
    Friend WithEvents C_encryption2 As DataGridViewTextBoxColumn
    Friend WithEvents C_manuf As DataGridViewTextBoxColumn
    Friend WithEvents C_channel As DataGridViewTextBoxColumn
    Friend WithEvents C_freqmhz As DataGridViewTextBoxColumn
    Friend WithEvents C_maxseenrate As DataGridViewTextBoxColumn
    Friend WithEvents C_carrier As DataGridViewTextBoxColumn
    Friend WithEvents C_encoding As DataGridViewTextBoxColumn
    Friend WithEvents C_datasize As DataGridViewTextBoxColumn
    Friend WithEvents C_client As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents C_client_mac As DataGridViewTextBoxColumn
    Friend WithEvents C_client_manuf As DataGridViewTextBoxColumn
    Friend WithEvents C_channelClient As DataGridViewTextBoxColumn
    Friend WithEvents C_Cliente_maxseenrate As DataGridViewTextBoxColumn
    Friend WithEvents C_Client_carrier As DataGridViewTextBoxColumn
    Friend WithEvents C_Client_encoding As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents C_last_signal_dbm As DataGridViewTextBoxColumn
    Friend WithEvents C_last_noise_dbm As DataGridViewTextBoxColumn
    Friend WithEvents C_last_signal_rssi As DataGridViewTextBoxColumn
    Friend WithEvents C_last_noise_rssi As DataGridViewTextBoxColumn
    Friend WithEvents C_min_signal_dbm As DataGridViewTextBoxColumn
    Friend WithEvents C_min_noise_dbm As DataGridViewTextBoxColumn
    Friend WithEvents C_min_signal_rssi As DataGridViewTextBoxColumn
    Friend WithEvents C_min_noise_rssi As DataGridViewTextBoxColumn
    Friend WithEvents C_max_signal_dbm As DataGridViewTextBoxColumn
    Friend WithEvents C_max_noise_dbm As DataGridViewTextBoxColumn
    Friend WithEvents C_max_signal_rssi As DataGridViewTextBoxColumn
    Friend WithEvents C_max_noise_rssi As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView4 As DataGridView
    Friend WithEvents C_LLC As DataGridViewTextBoxColumn
    Friend WithEvents C_data As DataGridViewTextBoxColumn
    Friend WithEvents C_crypt As DataGridViewTextBoxColumn
    Friend WithEvents C_total As DataGridViewTextBoxColumn
    Friend WithEvents C_fragments As DataGridViewTextBoxColumn
    Friend WithEvents C_retries As DataGridViewTextBoxColumn
End Class
