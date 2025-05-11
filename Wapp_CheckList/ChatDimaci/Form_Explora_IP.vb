Public Class Form_Explora_IP


    'Imports System.Net
    'Imports System.Net.NetworkInformation
    'Imports System.Globalization


    '    Public Class Form_InfoRed


    Dim UC_GraficaV12_Ejecut As Boolean
    Dim UC_GraficaV11_Ejecut As Boolean
    Dim networkInterfaces() As System.Net.NetworkInformation.NetworkInterface
    Dim currentInterface As System.Net.NetworkInformation.NetworkInterface
    Dim ContadorSend As Integer
    Dim ContadorRecive As Integer

    Delegate Sub NetworkAddressChangedCallback()
    Delegate Sub NetworkAvailabilityCallback(ByVal isNetworkAvailable As Boolean)


    Private Sub NetworkInformation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Mainioso()
        UC_GraficaV11.ActulizaTamaño()
        UC_GraficaV12.ActulizaTamaño()
        UC_GraficaV12_Ejecut = True
        UC_GraficaV11_Ejecut = True
        ' Cable hasta el eventos NetworkAddressChanged  para que podamos obtener 
        ' when an address change occurs on	any	of the network interfaces.
        ' cuando se produce un 
        ' estado (arriba / abajo) o una 
        AddHandler System.Net.NetworkInformation.NetworkChange.NetworkAvailabilityChanged, AddressOf Me.networkChange_NetworkAvailabilityChanged
        AddHandler System.Net.NetworkInformation.NetworkChange.NetworkAddressChanged, AddressOf Me.networkChange_NetworkAddressChanged

        ' Populate the	global interfaces container with the list of all - network interfaces.
        ' Interfaces de poblar el mundo de contenedores con la lista de todos - las interfaces de red.
        networkInterfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces
        ' Determinar si la red está disponible en el 
        ' Determine if	the	network	is available at	startup.
        UpdateNetworkAvailability(System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
        'Actualizar la información de la red intefaces.
        ' Update the information for the network intefaces.
        UpdateNetworkInformation()
    End Sub

    Private Sub networkChange_NetworkAvailabilityChanged(ByVal sender As Object, ByVal e As System.Net.NetworkInformation.NetworkAvailabilityEventArgs)

        Me.Invoke(New NetworkAvailabilityCallback(AddressOf UpdateNetworkAvailability), New Object() {e.IsAvailable})

    End Sub

    Private Sub networkChange_NetworkAddressChanged(ByVal sender As Object, ByVal e As EventArgs)

        Me.Invoke(New NetworkAddressChangedCallback(AddressOf UpdateNetworkInformation))


    End Sub

    Private Sub UpdateNetworkInformation()
        networkInterfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
        ComboBox_networkInterfaces.Items.Clear()

        For Each nic As System.Net.NetworkInformation.NetworkInterface In networkInterfaces
            ComboBox_networkInterfaces.Items.Add(nic.Description)
        Next

        If networkInterfaces.Length = 0 Then
            ComboBox_networkInterfaces.Items.Add("No NICs found on the machine.")

        Else
            currentInterface = networkInterfaces(0)
            UpdateCurrentNicInformation()
        End If

        ComboBox_networkInterfaces.SelectedIndex = 0
    End Sub

    Private Sub UpdateCurrentNicInformation()
        ' Set the DNS suffix if any exists
        Dim ipProperties As System.Net.NetworkInformation.IPInterfaceProperties = currentInterface.GetIPProperties()

        dnsSuffixTextLabel.Text = ipProperties.DnsSuffix.ToString()

        ' Display the IP address information associated with this
        ' interface including anycast,	unicast, multicast,	DNS	servers,
        ' WINS	servers, DHCP servers, and the gateway
        ' DataGridView1.Items.Clear()
        ' ListView_ipSelect.Dispose()
        ListView_a_IP.Items.Clear()
        Dim anycastInfo As System.Net.NetworkInformation.IPAddressInformationCollection = ipProperties.AnycastAddresses

        For Each info As System.Net.NetworkInformation.IPAddressInformation In anycastInfo
            InsertAddress(info.Address, "Anycast", "Trasitorio=" & info.IsTransient)
        Next
        Dim unicastInfo As System.Net.NetworkInformation.UnicastIPAddressInformationCollection = ipProperties.UnicastAddresses

        For Each info As System.Net.NetworkInformation.UnicastIPAddressInformation In unicastInfo
            InsertAddress(info.Address, "Unicast", info.PrefixOrigin)
        Next
        Dim multicastInfo As System.Net.NetworkInformation.MulticastIPAddressInformationCollection = ipProperties.MulticastAddresses

        For Each info As System.Net.NetworkInformation.MulticastIPAddressInformation In multicastInfo
            InsertAddress(info.Address, "Multicast", "multi Difusion=" & info.SuffixOrigin & "multi Difusion=" & info.PrefixOrigin)
        Next
        Dim gatewayInfo As System.Net.NetworkInformation.GatewayIPAddressInformationCollection = ipProperties.GatewayAddresses

        For Each info As System.Net.NetworkInformation.GatewayIPAddressInformation In gatewayInfo
            InsertAddress(info.Address, "Gateway", info.ToString)
        Next


        Dim ipAddresses As System.Net.NetworkInformation.IPAddressCollection = ipProperties.WinsServersAddresses

        InsertAddresses(ipAddresses, "WINS Server")
        ipAddresses = ipProperties.DhcpServerAddresses
        InsertAddresses(ipAddresses, "DHCP Server")
        ipAddresses = ipProperties.DnsAddresses
        InsertAddresses(ipAddresses, "DNS Server")

    End Sub

    Private Sub InsertAddresses(ByVal ipAddresses As System.Net.NetworkInformation.IPAddressCollection, ByVal addressType As String)

        For Each address As System.Net.IPAddress In ipAddresses
            'InsertAddress(address, addressType, address.ScopeId.ToString)
            InsertAddress(address, addressType, "")
        Next
    End Sub
    'Private Sub InsertAddress(ByVal address As IPAddress, ByVal addressType As String, ByVal NombreTipo As String)
    '        Dim listViewInformation(2) As String
    '        listViewInformation(0) = address.ToString()
    '        listViewInformation(1) = addressType
    '        listViewInformation(2) = NombreTipo
    '        Dim item As ListViewItem = New ListViewItem(listViewInformation)
    '        addressListView.Items.Add(item)
    '    End Sub
    Private Sub InsertAddress(ByVal address As System.Net.IPAddress, ByVal addressType As String, ByVal NombreTipo As String)


        Dim listViewInformation(2) As String
        listViewInformation(0) = address.ToString()
        listViewInformation(1) = addressType
        listViewInformation(2) = NombreTipo

        Dim item As ListViewItem = New ListViewItem(listViewInformation)
        ListView_a_IP.Items.Add(item)

        Try

            'ListView_IP.Rows.Add(address.ToString, addressType, NombreTipo)
        Catch ex As Exception
            'MsgBox(ex.Message)
            Label_EstadoApp.Text = ex.Message
        End Try

    End Sub

    Private Sub UpdateNetworkAvailability(ByVal isNetworkAvailable As Boolean)
        If isNetworkAvailable Then
            networkAvailabilityTextLabel.Text = "At least one network interface is up."
        Else
            networkAvailabilityTextLabel.Text = "The network is not currently available."
        End If
    End Sub

    Private Sub networkInterfacesComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        currentInterface = networkInterfaces(ComboBox_networkInterfaces.SelectedIndex)
        UpdateCurrentNicInformation()
    End Sub

    Private Sub updateInfoTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles updateInfoTimer.Tick
        UpdateNicStats()
    End Sub

    Private Sub UpdateNicStats()
        ' Get the IPv4	statistics for the currently selected interface
        Try

            ' Dim ipStats2 As IPv4InterfaceStatistics = currentInterface.GetIPProperties()

            Dim ipStats As System.Net.NetworkInformation.IPv4InterfaceStatistics = currentInterface.GetIPv4Statistics()
            '     Dim ipStats7 As IPAddressInformationCollection = 
            'Dim ipStats7 As IPAddressCollection = 
            Dim PakUniReceivedInKB2 As Long = ipStats.UnicastPacketsReceived
            Dim PakUniSentInKB2 As Long = ipStats.UnicastPacketsSent
            Dim PakReceivedInKB3 As Long = ipStats.IncomingUnknownProtocolPackets
            Dim PakLongitug As Long = ipStats.OutputQueueLength
            Dim PakNonUniReceivedInKB2 As Long = ipStats.NonUnicastPacketsReceived
            Dim PakNonUniSentInKB2 As Long = ipStats.NonUnicastPacketsSent
            Dim PakReceivedDescartado As Long = ipStats.IncomingPacketsDiscarded
            Dim PakReceivedError As Long = ipStats.IncomingPacketsWithErrors
            Label_PakUniRecivido.Text = PakUniReceivedInKB2
            Label5.Text = PakUniSentInKB2
            Label6.Text = PakReceivedInKB3
            Label7.Text = PakLongitug
            Label11.Text = PakNonUniReceivedInKB2
            Label12.Text = PakNonUniSentInKB2
            Label13.Text = PakReceivedDescartado
            Label14.Text = PakReceivedError
            Dim numberFormat As System.Globalization.NumberFormatInfo = System.Globalization.NumberFormatInfo.CurrentInfo
            Dim bytesReceivedInKB As Long = ipStats.BytesReceived / 1024
            Dim bytesSentInKB As Long = ipStats.BytesSent / 1024
            If UC_GraficaV12_Ejecut = True Then
                Dim aa2_BReciv As Integer = bytesReceivedInKB - ContadorRecive
                Label19.Text = "Reciv " & aa2_BReciv
                UC_GraficaV12.PosicionValorLector(Math.Round(aa2_BReciv * 0.5) + 1, 0)
                UC_GraficaV12.Imprimir()
                ContadorRecive = bytesReceivedInKB
            End If
            If UC_GraficaV11_Ejecut = True Then
                Dim aa1_BEnvio As Integer = bytesSentInKB - ContadorSend
                Label18.Text = "Envio " & aa1_BEnvio
                UC_GraficaV11.PosicionValorLector(Math.Round(aa1_BEnvio * 0.5) + 1, 0)
                ContadorSend = bytesSentInKB
                UC_GraficaV11.Imprimir()
            End If
            speedTextLabel.Text = GetSpeedString(currentInterface.Speed)
            bytesReceivedTextLabel.Text = bytesReceivedInKB.ToString("N0", numberFormat) + " KB"
            bytesSentTextLabel.Text = bytesSentInKB.ToString("N0", numberFormat) + " KB"
            operationalStatusTextLabel.Text = currentInterface.OperationalStatus.ToString()
            supportsMulticastTextLabel.Text = currentInterface.SupportsMulticast.ToString()
        Catch ex As Exception

        End Try
    End Sub

    Private Shared Function GetSpeedString(ByVal speed As Long) As String
        'Select Case speed
        '    Case 10000000
        '        GetSpeedString = " 10 MB"
        '    Case 11000000
        '        GetSpeedString = " 11 MB"
        '    Case 54000000
        '        GetSpeedString = " 54 MB"
        '    Case 100000000
        '        GetSpeedString = "100 MB"
        '    Case 1000000000
        '        GetSpeedString = "  1 GB"
        '    Case Else
        '        GetSpeedString = speed.ToString(NumberFormatInfo.CurrentInfo)
        '  End Select

        Dim millares1 As Integer = speed.ToString(System.Globalization.NumberFormatInfo.CurrentInfo).Length
        If millares1 >= 4 And millares1 < 7 Then
            GetSpeedString = speed.ToString(System.Globalization.NumberFormatInfo.CurrentInfo) / 1000 & " KBbps"
        ElseIf millares1 >= 7 And millares1 < 13 Then
            GetSpeedString = speed.ToString(System.Globalization.NumberFormatInfo.CurrentInfo) / 1000000 & " MBbps"
        ElseIf millares1 >= 13 And millares1 < 16 Then
            GetSpeedString = speed.ToString(System.Globalization.NumberFormatInfo.CurrentInfo) / 1000000000 & " GBbps"
        ElseIf millares1 >= 16 And millares1 < 19 Then
            GetSpeedString = speed.ToString(System.Globalization.NumberFormatInfo.CurrentInfo) / 1000000000000000 & " TBbps"
        ElseIf millares1 >= 19 And millares1 < 22 Then
            GetSpeedString = speed.ToString(System.Globalization.NumberFormatInfo.CurrentInfo) / 1000000000000000000 & " EBbps"
            'ElseIf miles1 >= 22 And miles1 < 25 Then
            '    GetSpeedString = speed.ToString(NumberFormatInfo.CurrentInfo) / 1000000000000000000000 & " ZB"
            'ElseIf miles1 >= 25 And miles1 < 28 Then
            '    GetSpeedString = speed.ToString(NumberFormatInfo.CurrentInfo) / 1000000000000000000000000000 & " YB"
        Else
            GetSpeedString = speed.ToString(System.Globalization.NumberFormatInfo.CurrentInfo)
        End If

    End Function

    'Private Sub speedTextLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles speedTextLabel.Click

    'End Sub

    'Private Sub networkAvailabilityTextLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles networkAvailabilityTextLabel.Click

    'End Sub

    'Private Sub Process1_Exited(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Process1.Exited

    'End Sub
    Private Sub ObtenerDatos2()
        Dim nombreHost As String = System.Net.Dns.GetHostName
        Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)

        Label_IpPublica.Text = "El nombre de tu maquina es: " & hostInfo.HostName.ToString
        For Each ip As System.Net.IPAddress In hostInfo.AddressList
            Label_IpPublica.Text = "Tu direccion IP local es: " & ip.ToString

        Next
    End Sub


    Sub Mainioso()
        Dim PublicIP As String = String.Empty
        Try
            Dim IPUrl As String = My.Application.Info.DirectoryPath.Trim & "\Pajina_HTML.htm" '"http://automation.whatismyip.com/n09230945.asp"
            Dim peticion As System.Net.HttpWebRequest
            Dim respuesta As System.Net.HttpWebResponse
            Dim stream As IO.Stream

            Dim reader As IO.StreamReader
            peticion = System.Net.WebRequest.Create(IPUrl)
            respuesta = peticion.GetResponse()
            stream = respuesta.GetResponseStream()
            reader = New IO.StreamReader(stream)
            PublicIP = reader.ReadToEnd()
            reader.Dispose()
            stream.Dispose()
        Catch ex As Exception

        End Try
        Label_IpPublica.Text = "IP Publica " & PublicIP
        If Label_IpPublica.Text.Trim = "IP Publica" Then
            'ObtenerDatos()
        End If
        
    End Sub


    Private Sub Label17_Click(sender As System.Object, e As System.EventArgs) Handles Label_IpPublica.Click
        Mainioso()
    End Sub

    Private Sub UC_GraficaV11_Click(sender As System.Object, e As System.EventArgs) Handles UC_GraficaV11.Click, UC_GraficaV11.Click_Control
        If UC_GraficaV11_Ejecut Then
            UC_GraficaV11_Ejecut = False
        Else
            UC_GraficaV11_Ejecut = True
        End If
    End Sub

    Private Sub UC_GraficaV12_Click(sender As System.Object, e As System.EventArgs) Handles UC_GraficaV12.Click, UC_GraficaV12.Click_Control
        If UC_GraficaV12_Ejecut Then
            UC_GraficaV12_Ejecut = False
        Else
            UC_GraficaV12_Ejecut = True
        End If
    End Sub

    Sub Actuliza(ByVal Send As Integer, ByVal Reciv As Integer)
        UC_GraficaV12.ActulizaTamaño()
    End Sub

    Private Sub UC_GraficaV12_Load(sender As System.Object, e As System.EventArgs)
        UC_GraficaV12.ActulizaTamaño()
    End Sub

    Private Sub UC_GraficaV11_Load(sender As System.Object, e As System.EventArgs)
        UC_GraficaV11.ActulizaTamaño()
    End Sub

    Private Sub Form_InfoRed_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
        Mainioso()
        UC_GraficaV11.ActulizaTamaño()
        UC_GraficaV12.ActulizaTamaño()
        UC_GraficaV12_Ejecut = True
        UC_GraficaV11_Ejecut = True
        ' Cable hasta el eventos NetworkAddressChanged  para que podamos obtener 
        ' when an address change occurs on	any	of the network interfaces.
        ' cuando se produce un 
        ' estado (arriba / abajo) o una 
        AddHandler System.Net.NetworkInformation.NetworkChange.NetworkAvailabilityChanged, AddressOf Me.networkChange_NetworkAvailabilityChanged
        AddHandler System.Net.NetworkInformation.NetworkChange.NetworkAddressChanged, AddressOf Me.networkChange_NetworkAddressChanged

        ' Populate the	global interfaces container with the list of all - network interfaces.
        ' Interfaces de poblar el mundo de contenedores con la lista de todos - las interfaces de red.
        networkInterfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces
        ' Determinar si la red está disponible en el 
        ' Determine if	the	network	is available at	startup.
        UpdateNetworkAvailability(System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
        'Actualizar la información de la red intefaces.
        ' Update the information for the network intefaces.
        UpdateNetworkInformation()
    End Sub

    Private Sub Button_EncendidoTimer_Click(sender As System.Object, e As System.EventArgs) Handles Button_EncendidoTimer.Click

    End Sub

    Private Sub Label17_Click_1(sender As System.Object, e As System.EventArgs) Handles Label17.Click
        Dim Class_IPn As New Class_IP
        Label17.Text = Class_IPn.GetWanIP()
    End Sub



    Private Sub ComboBox_networkInterfaces_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_networkInterfaces.SelectedIndexChanged

        currentInterface = networkInterfaces(ComboBox_networkInterfaces.SelectedIndex)

        UpdateCurrentNicInformation()
    End Sub

    Private Sub ListView_ipSelect_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView_ipSelect.SelectedIndexChanged

    End Sub

End Class



'Imports System.Net
'Imports System.Net.NetworkInformation
'Imports System.Globalization


'Public Class NetworkInformation

'    Dim UC_GraficaV12_Ejecut As Boolean
'    Dim UC_GraficaV11_Ejecut As Boolean
'    Dim networkInterfaces() As NetworkInterface
'    Dim currentInterface As NetworkInterface
'    Dim ContadorSend As Integer
'    Dim ContadorRecive As Integer

'    Delegate Sub NetworkAddressChangedCallback()
'    Delegate Sub NetworkAvailabilityCallback(ByVal isNetworkAvailable As Boolean)


'    Private Sub NetworkInformation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) ' Handles Me.Load
'        Mainioso()
'        Me.UC_GraficaV11.ActulizaTamaño()
'        Me.UC_GraficaV12.ActulizaTamaño()

'        UC_GraficaV12_Ejecut = True
'        UC_GraficaV11_Ejecut = True
'        ' Cable hasta el eventos NetworkAddressChanged  para que podamos obtener 
'        ' when an address change occurs on	any	of the network interfaces.
'        ' cuando se produce un 
'        ' estado (arriba / abajo) o una 
'        AddHandler System.Net.NetworkInformation.NetworkChange.NetworkAvailabilityChanged, AddressOf Me.networkChange_NetworkAvailabilityChanged
'        AddHandler System.Net.NetworkInformation.NetworkChange.NetworkAddressChanged, AddressOf Me.networkChange_NetworkAddressChanged

'        ' Populate the	global interfaces container with the list of all - network interfaces.
'        ' Interfaces de poblar el mundo de contenedores con la lista de todos - las interfaces de red.
'        networkInterfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces
'        ' Determinar si la red está disponible en el 
'        ' Determine if	the	network	is available at	startup.
'        UpdateNetworkAvailability(System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
'        'Actualizar la información de la red intefaces.
'        ' Update the information for the network intefaces.
'        UpdateNetworkInformation()
'    End Sub

'    Private Sub networkChange_NetworkAvailabilityChanged(ByVal sender As Object, ByVal e As NetworkAvailabilityEventArgs)

'        Me.Invoke(New NetworkAvailabilityCallback(AddressOf UpdateNetworkAvailability), New Object() {e.IsAvailable})

'    End Sub

'    Private Sub networkChange_NetworkAddressChanged(ByVal sender As Object, ByVal e As EventArgs)

'        Me.Invoke(New NetworkAddressChangedCallback(AddressOf UpdateNetworkInformation))


'    End Sub

'    Private Sub UpdateNetworkInformation()
'        networkInterfaces = NetworkInterface.GetAllNetworkInterfaces()
'        networkInterfacesComboBox.Items.Clear()

'        For Each nic As NetworkInterface In networkInterfaces
'            networkInterfacesComboBox.Items.Add(nic.Description)
'        Next

'        If networkInterfaces.Length = 0 Then
'            networkInterfacesComboBox.Items.Add("No NICs found on the machine.")

'        Else
'            currentInterface = networkInterfaces(0)
'            UpdateCurrentNicInformation()
'        End If

'        networkInterfacesComboBox.SelectedIndex = 0
'    End Sub

'    Private Sub UpdateCurrentNicInformation()
'        ' Set the DNS suffix if any exists
'        Dim ipProperties As IPInterfaceProperties = currentInterface.GetIPProperties()

'        dnsSuffixTextLabel.Text = ipProperties.DnsSuffix.ToString()

'        ' Display the IP address information associated with this
'        ' interface including anycast,	unicast, multicast,	DNS	servers,
'        ' WINS	servers, DHCP servers, and the gateway
'        addressListView.Items.Clear()

'        Dim anycastInfo As IPAddressInformationCollection = ipProperties.AnycastAddresses

'        For Each info As IPAddressInformation In anycastInfo
'            InsertAddress(info.Address, "Anycast", "Trasitorio=" & info.IsTransient)
'        Next
'        Dim unicastInfo As UnicastIPAddressInformationCollection = ipProperties.UnicastAddresses

'        For Each info As UnicastIPAddressInformation In unicastInfo
'            InsertAddress(info.Address, "Unicast", info.PrefixOrigin)
'        Next
'        Dim multicastInfo As MulticastIPAddressInformationCollection = ipProperties.MulticastAddresses

'        For Each info As MulticastIPAddressInformation In multicastInfo
'            InsertAddress(info.Address, "Multicast", "multi Difusion=" & info.SuffixOrigin & "multi Difusion=" & info.PrefixOrigin)
'        Next
'        Dim gatewayInfo As GatewayIPAddressInformationCollection = ipProperties.GatewayAddresses

'        For Each info As GatewayIPAddressInformation In gatewayInfo
'            InsertAddress(info.Address, "Gateway", info.ToString)
'        Next

'        Dim ipAddresses As IPAddressCollection = ipProperties.WinsServersAddresses

'        InsertAddresses(ipAddresses, "WINS Server")
'        ipAddresses = ipProperties.DhcpServerAddresses
'        InsertAddresses(ipAddresses, "DHCP Server")
'        ipAddresses = ipProperties.DnsAddresses
'        InsertAddresses(ipAddresses, "DNS Server")

'    End Sub

'    Private Sub InsertAddresses( _
'        ByVal ipAddresses As IPAddressCollection, ByVal addressType As String)

'        For Each address As IPAddress In ipAddresses
'            'InsertAddress(address, addressType, address.ScopeId.ToString)
'            InsertAddress(address, addressType, "")
'        Next
'    End Sub

'    Private Sub InsertAddress(ByVal address As IPAddress, ByVal addressType As String, ByVal NombreTipo As String)


'        Dim listViewInformation(2) As String
'        listViewInformation(0) = address.ToString()
'        listViewInformation(1) = addressType
'        listViewInformation(2) = NombreTipo
'        Dim item As ListViewItem = New ListViewItem(listViewInformation)
'        addressListView.Items.Add(item)
'    End Sub

'    Private Sub UpdateNetworkAvailability(ByVal isNetworkAvailable As Boolean)

'        If isNetworkAvailable Then
'            networkAvailabilityTextLabel.Text = "At least one network interface is up."

'        Else
'            networkAvailabilityTextLabel.Text = "The network is not currently available."

'        End If
'    End Sub

'    Private Sub networkInterfacesComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles networkInterfacesComboBox.SelectedIndexChanged

'        currentInterface = networkInterfaces(networkInterfacesComboBox.SelectedIndex)

'        UpdateCurrentNicInformation()
'    End Sub

'    Private Sub updateInfoTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles updateInfoTimer.Tick

'        UpdateNicStats()
'    End Sub

'    Private Sub UpdateNicStats()
'        Dim ipStats As IPv4InterfaceStatistics = currentInterface.GetIPv4Statistics()

'        Dim PakUniReceivedInKB2 As Long = ipStats.UnicastPacketsReceived
'        Dim PakUniSentInKB2 As Long = ipStats.UnicastPacketsSent
'        Dim PakReceivedInKB3 As Long = ipStats.IncomingUnknownProtocolPackets
'        Dim PakLongitug As Long = ipStats.OutputQueueLength


'        Dim PakNonUniReceivedInKB2 As Long = ipStats.NonUnicastPacketsReceived
'        Dim PakNonUniSentInKB2 As Long = ipStats.NonUnicastPacketsSent

'        Dim PakReceivedDescartado As Long = ipStats.IncomingPacketsDiscarded
'        Dim PakReceivedError As Long = ipStats.IncomingPacketsWithErrors







'        Label4.Text = PakUniReceivedInKB2
'        Label5.Text = PakUniSentInKB2
'        Label6.Text = PakReceivedInKB3
'        Label7.Text = PakLongitug
'        Label11.Text = PakNonUniReceivedInKB2
'        Label12.Text = PakNonUniSentInKB2
'        Label13.Text = PakReceivedDescartado
'        Label14.Text = PakReceivedError



'        Dim numberFormat As NumberFormatInfo = NumberFormatInfo.CurrentInfo

'        Dim bytesReceivedInKB As Long = ipStats.BytesReceived / 1024
'        Dim bytesSentInKB As Long = ipStats.BytesSent / 1024
'        If UC_GraficaV12_Ejecut = True Then
'            Dim aa2_BReciv As Integer = bytesReceivedInKB - ContadorRecive
'            Label19.Text = "Reciv " & aa2_BReciv
'            UC_GraficaV12.PosicionValorLector(Math.Round(aa2_BReciv * 0.5) + 1, 0)
'            UC_GraficaV12.Imprimir()
'            ContadorRecive = bytesReceivedInKB
'        End If
'        If UC_GraficaV11_Ejecut = True Then
'            Dim aa1_BEnvio As Integer = bytesSentInKB - ContadorSend
'            Label18.Text = "Envio " & aa1_BEnvio
'            UC_GraficaV11.PosicionValorLector(Math.Round(aa1_BEnvio * 0.5) + 1, 0)
'            ContadorSend = bytesSentInKB
'            UC_GraficaV11.Imprimir()
'        End If


'        speedTextLabel.Text = GetSpeedString(currentInterface.Speed)
'        bytesReceivedTextLabel.Text = bytesReceivedInKB.ToString("N0", numberFormat) + " KB"

'        bytesSentTextLabel.Text = bytesSentInKB.ToString("N0", numberFormat) + " KB"


'        operationalStatusTextLabel.Text = currentInterface.OperationalStatus.ToString()
'        supportsMulticastTextLabel.Text = currentInterface.SupportsMulticast.ToString()

'    End Sub

'    Private Shared Function GetSpeedString(ByVal speed As Long) As String
'        Dim miles1 As Integer = speed.ToString(NumberFormatInfo.CurrentInfo).Length
'        If miles1 >= 4 And miles1 < 7 Then
'            GetSpeedString = speed.ToString(NumberFormatInfo.CurrentInfo) / 1000 & " KB"
'        ElseIf miles1 >= 7 And miles1 < 13 Then
'            GetSpeedString = speed.ToString(NumberFormatInfo.CurrentInfo) / 1000000 & " MB"
'        ElseIf miles1 >= 13 And miles1 < 16 Then
'            GetSpeedString = speed.ToString(NumberFormatInfo.CurrentInfo) / 1000000000 & " GB"
'        ElseIf miles1 >= 16 And miles1 < 19 Then
'            GetSpeedString = speed.ToString(NumberFormatInfo.CurrentInfo) / 1000000000000000 & " TB"
'        ElseIf miles1 >= 19 And miles1 < 22 Then
'            GetSpeedString = speed.ToString(NumberFormatInfo.CurrentInfo) / 1000000000000000000 & " EB"
'            'ElseIf miles1 >= 22 And miles1 < 25 Then
'            '    GetSpeedString = speed.ToString(NumberFormatInfo.CurrentInfo) / 1000000000000000000000 & " ZB"
'            'ElseIf miles1 >= 25 And miles1 < 28 Then
'            '    GetSpeedString = speed.ToString(NumberFormatInfo.CurrentInfo) / 1000000000000000000000000000 & " YB"
'        Else
'            GetSpeedString = speed.ToString(NumberFormatInfo.CurrentInfo)
'        End If

'    End Function

'    Sub Mainioso()
'        Dim PublicIP As String = String.Empty
'        Try
'            Dim IPUrl As String = "http://automation.whatismyip.com/n09230945.asp"
'            Dim peticion As HttpWebRequest
'            Dim respuesta As HttpWebResponse
'            Dim stream As IO.Stream

'            Dim reader As IO.StreamReader
'            peticion = WebRequest.Create(IPUrl)
'            respuesta = peticion.GetResponse()
'            stream = respuesta.GetResponseStream()
'            reader = New IO.StreamReader(stream)
'            PublicIP = reader.ReadToEnd()
'            reader.Dispose()
'            stream.Dispose()
'        Catch ex As Exception

'        End Try
'        Label17.Text = PublicIP

'    End Sub


'    Private Sub Label17_Click(sender As System.Object, e As System.EventArgs) Handles Label17.Click
'        Mainioso()
'    End Sub

'    Private Sub UC_GraficaV11_Load(sender As System.Object, e As System.EventArgs) Handles UC_GraficaV11.Click, UC_GraficaV11.Click_Control
'        If UC_GraficaV11_Ejecut Then
'            UC_GraficaV11_Ejecut = False
'        Else
'            UC_GraficaV11_Ejecut = True
'        End If
'    End Sub

'    Private Sub UC_GraficaV12_Load(sender As System.Object, e As System.EventArgs) Handles UC_GraficaV12.Click, UC_GraficaV12.Click_Control
'        If UC_GraficaV12_Ejecut Then
'            UC_GraficaV12_Ejecut = False
'        Else
'            UC_GraficaV12_Ejecut = True
'        End If
'    End Sub
'End Class
