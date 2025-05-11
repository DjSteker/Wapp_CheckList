

Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Globalization
Imports System.Management



Public Class Form_InfoRed


    Dim UC_GraficaV12_Ejecut As Boolean
    Dim UC_GraficaV11_Ejecut As Boolean
    Dim networkInterfaces() As NetworkInterface
    Dim currentInterface As NetworkInterface
    Dim currentInfoIPs As NetworkInformation.IPStatus
    Dim ContadorSend As Integer
    Dim ContadorRecive As Integer

    Delegate Sub NetworkAddressChangedCallback()
    Delegate Sub NetworkAvailabilityCallback(ByVal isNetworkAvailable As Boolean)


    Private Sub NetworkInformation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Mainioso()
        Catch ex As Exception

        End Try
        Try
            UC_GraficaV11.ActulizaTamaño()
            UC_GraficaV12.ActulizaTamaño()
            UC_GraficaV12_Ejecut = True
            UC_GraficaV11_Ejecut = True
        Catch ex As Exception

        End Try

        Try
            ' Cable hasta el eventos NetworkAddressChanged  para que podamos obtener 
            ' when an address change occurs on	any	of the network interfaces.
            ' cuando se produce un 
            ' estado (arriba / abajo) o una 
            AddHandler System.Net.NetworkInformation.NetworkChange.NetworkAvailabilityChanged, AddressOf Me.networkChange_NetworkAvailabilityChanged
            AddHandler System.Net.NetworkInformation.NetworkChange.NetworkAddressChanged, AddressOf Me.networkChange_NetworkAddressChanged

        Catch ex As Exception

        End Try
        Try
            ' Populate the	global interfaces container with the list of all - network interfaces.
            ' Interfaces de poblar el mundo de contenedores con la lista de todos - las interfaces de red.
            networkInterfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces
            ' Determinar si la red está disponible en el 
            ' Determine if	the	network	is available at	startup.
            UpdateNetworkAvailability(System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            'Actualizar la información de la red intefaces.
            ' Update the information for the network intefaces.
            UpdateNetworkInformation()
            ListView_ipSelect.Items.Clear()
            UpdateCurrentNicInformation_IPv_6()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub networkChange_NetworkAvailabilityChanged(ByVal sender As Object, ByVal e As NetworkAvailabilityEventArgs)

        Me.Invoke(New NetworkAvailabilityCallback(AddressOf UpdateNetworkAvailability), New Object() {e.IsAvailable})

    End Sub

    Private Sub networkChange_NetworkAddressChanged(ByVal sender As Object, ByVal e As EventArgs)

        Me.Invoke(New NetworkAddressChangedCallback(AddressOf UpdateNetworkInformation))


    End Sub

    Private Sub UpdateNetworkInformation()
        networkInterfaces = NetworkInterface.GetAllNetworkInterfaces()
        ComboBox_networkInterfaces.Items.Clear()

        For Each nic As NetworkInterface In networkInterfaces
            ComboBox_networkInterfaces.Items.Add(nic.Description)
        Next

        If networkInterfaces.Length = 0 Then
            ComboBox_networkInterfaces.Items.Add("No NICs found on the machine.")

        Else
            currentInterface = networkInterfaces(0)
            UpdateCurrentNicInformation()
            UpdateCurrentNicInformation_IPv_6()
        End If

        ComboBox_networkInterfaces.SelectedIndex = 0
    End Sub

    Private Sub UpdateCurrentNicInformation()
        ' Set the DNS suffix if any exists
        Dim ipProperties As IPInterfaceProperties = currentInterface.GetIPProperties()

        dnsSuffixTextLabel.Text = ipProperties.DnsSuffix.ToString()

        ' Display the IP address information associated with this
        ' interface including anycast,	unicast, multicast,	DNS	servers,
        ' WINS	servers, DHCP servers, and the gateway
        ' DataGridView1.Items.Clear()
        ListView_a_IP.Items.Clear()
        Dim anycastInfo As IPAddressInformationCollection = ipProperties.AnycastAddresses

        For Each info As IPAddressInformation In anycastInfo
            InsertAddress(info.Address, "Anycast", "Trasitorio=" & info.IsTransient)
        Next
        Dim unicastInfo As UnicastIPAddressInformationCollection = ipProperties.UnicastAddresses

        For Each info As UnicastIPAddressInformation In unicastInfo
            InsertAddress(info.Address, "Unicast", info.PrefixOrigin)
        Next
        Dim multicastInfo As MulticastIPAddressInformationCollection = ipProperties.MulticastAddresses

        For Each info As MulticastIPAddressInformation In multicastInfo
            InsertAddress(info.Address, "Multicast", "multi Difusion=" & info.SuffixOrigin & "multi Difusion=" & info.PrefixOrigin)
        Next
        Dim gatewayInfo As GatewayIPAddressInformationCollection = ipProperties.GatewayAddresses

        For Each info As GatewayIPAddressInformation In gatewayInfo
            InsertAddress(info.Address, "Gateway", info.ToString)
        Next


        Dim ipAddresses As IPAddressCollection = ipProperties.WinsServersAddresses

        InsertAddresses(ipAddresses, "WINS Server")
        ipAddresses = ipProperties.DhcpServerAddresses
        InsertAddresses(ipAddresses, "DHCP Server")
        ipAddresses = ipProperties.DnsAddresses
        InsertAddresses(ipAddresses, "DNS Server")

    End Sub
    Private Sub UpdateCurrentNicInformation_IPv_6()
        ' Set the DNS suffix if any exists
        Try

            Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
            '   Label_IpPublica.Text = Label_IpPublica.Text & (" IPv6 " & properties.NodeType & " : " & properties.DomainName)
            Try
                InsertAddress_IPv6(properties.NodeType, "NodeType", " ")
                InsertAddress_IPv6(properties.DomainName, "DomainName", " ")
                InsertAddress_IPv6(properties.DhcpScopeName, "DhcpScopeName", " ")
                InsertAddress_IPv6(properties.HostName, "HostName", " ")
                InsertAddress_IPv6(properties.IsWinsProxy, "IsWinsProxy", " ")
            Catch ex As Exception

            End Try
            Try
                Dim properties42 As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
                Dim statistics42 As IcmpV6Statistics = properties42.GetIcmpV6Statistics()

                InsertAddress_IPv6(statistics42.RouterAdvertisementsSent, statistics42.RouterAdvertisementsReceived, " ")
                InsertAddress_IPv6(statistics42.RouterSolicitsSent, statistics42.RouterSolicitsReceived, " ")
                'InsertAddress_IPv6(properties.GetIPv6GlobalStatistics.NumberOfRoutes, "UdpListenersIPv6", " ")
                'InsertAddress_IPv6(GetUdpIPv6Statistics.UdpListeners, "UdpListenersIPv6", " ")
            Catch ex As Exception

            End Try
            Try
                InsertAddress_IPv6(properties.GetIPv6GlobalStatistics.NumberOfRoutes, "NumberOfRoutes", " ")
                InsertAddress_IPv6(properties.GetIPv6GlobalStatistics.ForwardingEnabled, "ForwardingEnabled", " ")
            Catch ex As Exception

            End Try
            Try


                InsertAddress_IPv6(properties.GetUdpIPv4Statistics.UdpListeners, "UdpListenersIPv4", " ")


                InsertAddress_IPv6(properties.GetActiveTcpConnections.Rank, "ActiveTcpConnections", " ")
                InsertAddress_IPv6(properties.GetActiveTcpListeners.Rank, "TcpListeners", " ")
                InsertAddress_IPv6(properties.GetActiveUdpListeners.Rank, "UdpListeners", " ")
                '  InsertAddress_IPv6( properties. 
            Catch ex As Exception

            End Try


            Try

                Dim adapter2 = currentInterface
                Dim computerProperties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
                Dim nics2() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
                InsertAddress_IPv6("Interface information for", computerProperties.HostName, computerProperties.DomainName)
                If nics2 Is Nothing OrElse nics2.Length < 1 Then
                    'Console.WriteLine("  No network interfaces found.")
                    Return
                End If

                InsertAddress_IPv6("Number of interfaces", nics2.Length, " ")
                For Each adapter2 In nics2
                    Dim properties2 As IPInterfaceProperties = adapter2.GetIPProperties()
                    InsertAddress_IPv6(" ", " ", " ")
                    InsertAddress_IPv6(adapter2.Description, adapter2.Id, adapter2.Name)
                    Dim address As PhysicalAddress = adapter2.GetPhysicalAddress()
                    Dim bytes() As Byte = address.GetAddressBytes()
                    Dim DireccionPalabra As String = ""
                    For i = 0 To bytes.Length - 1
                        DireccionPalabra = DireccionPalabra & bytes(i).ToString("X2")

                        If i <> bytes.Length - 1 Then
                            InsertAddress_IPv6("-", "", "")
                        End If

                    Next i
                    InsertAddress_IPv6(DireccionPalabra, address.GetAddressBytes().Rank, adapter2.Id)
                    Console.WriteLine()
                Next adapter2



            Catch ex As Exception

            End Try
            'Try
            '    Dim GetIPv6GlobalStatistics() As IPGlobalStatistics

            '    Dim instance As IPGlobalProperties
            '    Dim returnValue As IPGlobalStatistics

            '    returnValue = instance.GetIPv6GlobalStatistics()

            '    With properties.GetUdpIPv6Statistics
            '        InsertAddress_IPv6(.UdpListeners, "UdpListeners", "")
            '        InsertAddress_IPv6(.IncomingDatagramsWithErrors, "IncomingDatagramsWithErrors", "")
            '        InsertAddress_IPv6(.IncomingDatagramsDiscarded, "IncomingDatagramsDiscarded", "")
            '        InsertAddress_IPv6(.DatagramsSent, "DatagramsSent", "")
            '        InsertAddress_IPv6(.DatagramsReceived, "DatagramsReceived", "")
            '    End With
            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try
            'Try
            '    With properties.GetTcpIPv6Statistics
            '        InsertAddress_IPv6(.ConnectionsAccepted, "ConnectionsAccepted", "")
            '        InsertAddress_IPv6(.ResetsSent, "ResetsSent", "")
            '        InsertAddress_IPv6(.CurrentConnections, "CurrentConnections", "")
            '        InsertAddress_IPv6(.ResetsSent, "ResetsSent", "")
            '        InsertAddress_IPv6(.CumulativeConnections, "CumulativeConnections", "")
            '    End With
            '    'InsertAddress_IPv6(properties.GetUdpIPv6Statistics().UdpListeners, "UdpListeners", "")
            '    'InsertAddress_IPv6(properties.GetUdpIPv6Statistics().IncomingDatagramsWithErrors, "IncomingDatagramsWithErrors", "")
            '    'InsertAddress_IPv6(properties.GetUdpIPv6Statistics().IncomingDatagramsDiscarded, "IncomingDatagramsDiscarded", "")
            '    'InsertAddress_IPv6(properties.GetUdpIPv6Statistics().DatagramsSent, "DatagramsSent", "")
            '    'InsertAddress_IPv6(properties.GetUdpIPv6Statistics().DatagramsReceived, "DatagramsReceived", "")
            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try


            Dim nics As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            Dim count As Integer = 0

            Dim adapter As NetworkInterface
            For Each adapter In nics
                ' Only display informatin for interfaces that support IPv6.
                If adapter.Supports(NetworkInterfaceComponent.IPv6) = False Then
                    GoTo 99970
                End If
                count += 1


                'InsertAddress_IPv6(info.Address, "Gateway", info.ToString)
                InsertAddress_IPv6(adapter.Description, "", "")
                ' Underline the description.
                '    InsertAddress_IPv6(String.Empty.PadLeft(adapter.Description.Length, "="c), "", "")
                InsertAddress_IPv6(adapter.Description.Length, "", "")
                Dim adapterProperties As IPInterfaceProperties = adapter.GetIPProperties()
                ' Try to get the IPv6 interface properties.
                Dim p As IPv6InterfaceProperties = adapterProperties.GetIPv6Properties()


                If p Is Nothing Then
                    InsertAddress_IPv6("No IPv6 information is available for this interface.", "", "")
                    GoTo 99970
                End If
                ' Display the IPv6 specific data.
                InsertAddress_IPv6(p.Index, "Index", "")
                InsertAddress_IPv6(p.Mtu, "MTU", "")
99970:
            Next adapter

            If count = 0 Then
                InsertAddress_IPv6("  No IPv6 interfaces were found.", "", "")

            End If

        Catch ex As Exception

        End Try


        ' InsertAddress_IPv6(, "MTU", "tranmision Max")
        'Dim anycastInfo As IPAddressInformationCollection = ipProperties.Index

        'For Each info As IPAddressInformation In anycastInfo
        '    InsertAddress_IPv6(info.Address, "Anycast", "Trasitorio=" & info.IsTransient)
        'Next
        'Dim unicastInfo As UnicastIPAddressInformationCollection = ipProperties.UnicastAddresses

        'For Each info As UnicastIPAddressInformation In unicastInfo
        '    InsertAddress_IPv6(info.Address, "Unicast", info.PrefixOrigin)
        'Next
        'Dim multicastInfo As MulticastIPAddressInformationCollection = ipProperties.MulticastAddresses

        'For Each info As MulticastIPAddressInformation In multicastInfo
        '    InsertAddress_IPv6(info.Address, "Multicast", "multi Difusion=" & info.SuffixOrigin & "multi Difusion=" & info.PrefixOrigin)
        'Next
        'Dim gatewayInfo As GatewayIPAddressInformationCollection = ipProperties.GatewayAddresses

        'For Each info As GatewayIPAddressInformation In gatewayInfo
        '    InsertAddress_IPv6(info.Address, "Gateway", info.ToString)
        'Next


        'Dim ipAddresses As IPAddressCollection = ipProperties.WinsServersAddresses

        'InsertAddresses(ipAddresses, "WINS Server")
        'ipAddresses = ipProperties.DhcpServerAddresses
        'InsertAddresses(ipAddresses, "DHCP Server")
        'ipAddresses = ipProperties.DnsAddresses
        'InsertAddresses(ipAddresses, "DNS Server")
        'Dim ipStats As IPv6InterfaceProperties '= New IPv6InterfaceProperties
        'ipStats.Index
        'ipStats.Mtu
    End Sub

    Private Sub InsertAddresses(ByVal ipAddresses As IPAddressCollection, ByVal addressType As String)

        For Each address As IPAddress In ipAddresses
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
    Private Sub InsertAddress(ByVal address As IPAddress, ByVal addressType As String, ByVal NombreTipo As String)


        Dim listViewInformation(2) As String
        listViewInformation(0) = address.ToString()
        listViewInformation(1) = addressType
        listViewInformation(2) = NombreTipo

        Dim item As ListViewItem = New ListViewItem(listViewInformation)
        ListView_a_IP.Items.Add(item)



        ' Try
        'If DataGridView1.RowCount > 0 Then
        '    DataGridView1.Item(0, DataGridView1.RowCount - 1).ToolTipText = address.ToString()
        '    DataGridView1.Item(0, DataGridView1.RowCount - 1).Value = address.ToString()
        '    DataGridView1.Item(1, DataGridView1.RowCount - 1).ToolTipText = addressType
        '    DataGridView1.Item(1, DataGridView1.RowCount - 1).Value = addressType
        '    DataGridView1.Item(2, DataGridView1.RowCount - 1).ToolTipText = NombreTipo
        '    DataGridView1.Item(2, DataGridView1.RowCount - 1).Value = NombreTipo
        'End If


        'Dim Registro0 As DataGridViewCell
        'Registro0.Value = address.ToString()
        'Dim Registro1 As DataGridViewCell
        'Registro1.Value = addressType
        'Dim Registro2 As DataGridViewCell
        'Registro2.Value = NombreTipo
        ''  Registro1.DataGridView.
        'Dim Registro As GridItem
        'Registro.GridItems.Item(DataGridView1.RowCount - 1).Value = Registro0.Value

        'Try
        '    Dim listViewInformation_ipSelect(2) As String
        '    listViewInformation_ipSelect(0) = address.ToString()
        '    listViewInformation_ipSelect(1) = addressType
        '    listViewInformation_ipSelect(2) = NombreTipo

        '    Dim item_ipSelect As ListViewItem = New ListViewItem(listViewInformation_ipSelect)
        '    ListView_ipSelect.Items.Add(item_ipSelect)
        'Catch ex As Exception
        '    'MsgBox(ex.Message)
        '    Label_EstadoApp.Text = ex.Message
        'End Try
        ''   Catch ex As Exception

        '   End Try


        'Dim view As DataView


        'Dim DirArc() As String = IO.Directory.GetFiles("")
        'Dim ArchivosSD As SortedDictionary(Of Integer, String) = New SortedDictionary(Of Integer, String)
        'For IndiceArc_C1 As Integer = 1 To IO.Directory.GetFiles("").Count
        '    ArchivosSD.Add((IndiceArc_C1 - 1), DirArc.ElementAt(IndiceArc_C1 - 1))
        'Next

        'Dim table As DataTable = New DataTable()
        'Dim column As DataColumn
        'Dim row As DataRow

        'column = New DataColumn()
        'column.DataType = System.Type.GetType("System.String")
        'column.ColumnName = "Direccion"
        'table.Columns.Add(column)
        'column = New DataColumn()
        'column.DataType = Type.GetType("System.String")
        'column.ColumnName = "Tipo"
        'table.Columns.Add(column)
        'column = New DataColumn()
        'column.DataType = Type.GetType("System.String")
        'column.ColumnName = "Comentario"
        'table.Columns.Add(column)

        'Dim nombreTmp As String = " "
        'Dim rutaTmp As String = " "
        'Dim dirInfo1 'As FileInfo
        'Dim path As String
        'Dim pathExist1 As Boolean = True

        'For IndiceA_0 As Integer = 1 To ArchivosSD.Count()

        '    Try
        '        path = ArchivosSD.Item(IndiceA_0 - 1).ToString
        '        '         dirInfo1 = New FileInfo(path)
        '        nombreTmp = dirInfo1.Name.ToString
        '        rutaTmp = dirInfo1.DirectoryName
        '        pathExist1 = dirInfo1.Exists
        '    Catch ex As Exception
        '        '  LabelEstado.Text = ex.Message.ToString
        '    End Try

        '    Try
        '        row = table.NewRow()
        '        row("Nombre") = nombreTmp
        '        row("Ruta") = rutaTmp
        '        row("Raiz") = 0
        '        table.Rows.Add(row)
        '    Catch ex As Exception

        '    End Try



        'Next
        'view = New DataView(table)

        'DataGridView1.DataSource = view

        ''DataGridView1.DataBind()
        '' DataGridView1.
    End Sub
    Private Sub InsertAddress_IPv6(ByVal address As String, ByVal addressType As String, ByVal NombreTipo As String)

        Try
            Dim listViewInformation_ipSelect(2) As String
            listViewInformation_ipSelect(0) = address.ToString
            listViewInformation_ipSelect(1) = addressType
            listViewInformation_ipSelect(2) = NombreTipo

            Dim item_ipSelect As ListViewItem = New ListViewItem(listViewInformation_ipSelect)
            ListView_ipSelect.Items.Add(item_ipSelect)
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

            Dim ipStats As IPv4InterfaceStatistics = currentInterface.GetIPv4Statistics()
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
            Dim numberFormat As NumberFormatInfo = NumberFormatInfo.CurrentInfo
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
            Label_MensagesCeciv.Text = currentInterface.GetIPProperties.GetIPv6Properties.Index
            Labe_MensagesSalida.Text = currentInterface.GetIPProperties.GetIPv6Properties.Mtu
        Catch ex As Exception

        End Try


        Try
            'Dim ipProperties As System.Net.NetworkInformation.IcmpV6Statistics '= currentInfoIPstatus
            'Dim ipStats As IPv6InterfaceProperties


            'Label_MensagesCeciv.Text = ipStats.
            'Labe_MensagesSalida.Text = ipProperties.RouterSolicitsSent


            'ListView_ipSelect.Dispose()
        Catch ex As Exception

        End Try
        Try
            'Dim ipStats As IPv6InterfaceProperties = currentInterface.
            'Dim ipProperties2 As System.Net.NetworkInformation.IcmpV6Statistics '= currentInterface.GetIPProperties



            'Label_MensagesCeciv.Text = ipProperties2.RouterSolicitsReceived
            'Labe_MensagesSalida.Text = ipProperties2.RouterSolicitsSent
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
        'Dim aaaa As String = NumberFormatInfo.CurrentInfo.NativeDigits
        Dim VelocidadWifi As Double = speed.ToString(NumberFormatInfo.CurrentInfo)
        Dim millares1 As Integer = speed.ToString(NumberFormatInfo.CurrentInfo).Length
        If millares1 >= 4 And millares1 < 7 Then
            GetSpeedString = speed.ToString(NumberFormatInfo.CurrentInfo) / 1000 & " KBbps"
        ElseIf millares1 >= 7 And millares1 < 13 Then
            GetSpeedString = speed.ToString(NumberFormatInfo.CurrentInfo) / 1000000 & " MBbps"
        ElseIf millares1 >= 13 And millares1 < 16 Then
            GetSpeedString = speed.ToString(NumberFormatInfo.CurrentInfo) / 1000000000 & " GBbps"
        ElseIf millares1 >= 16 And millares1 < 19 Then
            GetSpeedString = speed.ToString(NumberFormatInfo.CurrentInfo) / 1000000000000000 & " TBbps"
        ElseIf millares1 >= 19 And millares1 < 22 Then
            GetSpeedString = speed.ToString(NumberFormatInfo.CurrentInfo) / 1000000000000000000 & " EBbps"
            'ElseIf miles1 >= 22 And miles1 < 25 Then
            '    GetSpeedString = speed.ToString(NumberFormatInfo.CurrentInfo) / 1000000000000000000000 & " ZB"
            'ElseIf miles1 >= 25 And miles1 < 28 Then
            '    GetSpeedString = speed.ToString(NumberFormatInfo.CurrentInfo) / 1000000000000000000000000000 & " YB"
        Else
            GetSpeedString = speed.ToString(NumberFormatInfo.CurrentInfo)
        End If

    End Function

    'Private Sub speedTextLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles speedTextLabel.Click

    'End Sub

    'Private Sub networkAvailabilityTextLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles networkAvailabilityTextLabel.Click

    'End Sub

    'Private Sub Process1_Exited(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Process1.Exited

    'End Sub
    Private Sub ObtenerDatos()
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
            Dim peticion As HttpWebRequest
            Dim respuesta As HttpWebResponse
            Dim stream As IO.Stream

            Dim reader As IO.StreamReader
            peticion = WebRequest.Create(IPUrl)
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
            ObtenerDatos()
        End If
        ' Dim aa As String = System.Net.Dns.Resolve(My.Computer.Name).AddressList(0).ToString()
        'Try
        '    Dim i_cont As Integer
        '    Dim Host As String
        '    ' Si no se pasa como parametro un nombre, muestra las ip locales
        '    If Environment.GetCommandLineArgs().Length > 1 Then
        '        Host = Environment.GetCommandLineArgs(1)
        '    Else
        '        Host = Dns.GetHostName
        '    End If

        '    Dim IPs As IPHostEntry = Dns.GetHostByName(Host)
        '    Dim Direcciones As IPAddress() = IPs.AddressList

        '    'Se despliega la lista de IP's
        '    For i_cont = 0 To i_cont = Direcciones.Length
        '        Label17.Text = Label17.Text & "  " & i_cont + 1 & "  " & Direcciones(i_cont).ToString()
        '    Next
        'Catch ex As Exception

        'End Try

        'Label17.Text = Label17.Text & "  " & PublicIP 'pui_ID.GetAddressBytes.GetLength(pui_ID.ScopeId)
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
        If updateInfoTimer.Enabled = False Then
            updateInfoTimer.Enabled = True
            Button_EncendidoTimer.Text = " Parar "
        Else
            updateInfoTimer.Enabled = False
            Button_EncendidoTimer.Text = " Encender "
        End If

    End Sub

    Private Sub Label17_Click_1(sender As System.Object, e As System.EventArgs) Handles Label17.Click
        Dim Class_IPn As New Class_IP
        Label17.Text = Class_IPn.GetWanIP()
    End Sub



    Private Sub ListView_ipSelect_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView_ipSelect.SelectedIndexChanged

    End Sub
    Private Sub ListView_a_IP_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView_a_IP.SelectedIndexChanged

    End Sub
    Private Sub ComboBox_networkInterfaces_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_networkInterfaces.SelectedIndexChanged

        currentInterface = networkInterfaces(ComboBox_networkInterfaces.SelectedIndex)
        ListView_ipSelect.Items.Clear()
        UpdateCurrentNicInformation()
        UpdateCurrentNicInformation_IPv_6()
    End Sub

    Private Sub Button_PingMTU_Click(sender As Object, e As EventArgs) Handles Button_PingMTU.Click
        Try
            'RichTextBox_Resultado.AppendText(Shell("PING " & TextBox_Direccion.Text.Trim & "-f -1 " & TextBox_TamañoMTU.Text) & vbCrLf)
            Dim exitCode As Integer
            Dim Pross As Process = New Process
            Dim processInfo As New ProcessStartInfo
            'processInfo = New ProcessStartInfo("cmd.exe", "/c PING " & TextBox_Direccion.Text.Trim & " -f -l " & TextBox_TamañoMTU.Text & "")

            processInfo.FileName = "cmd.exe"
            processInfo.Arguments = "/c PING " & TextBox_Direccion.Text.Trim & " -f -l " & TextBox_TamañoMTU.Text

            processInfo.CreateNoWindow = False
            processInfo.UseShellExecute = False

            ' *** Redirect the output ***
            processInfo.RedirectStandardError = True
            processInfo.RedirectStandardOutput = True
            'Pross.StartInfo.FileName = "cmd.exe"
            ' Pross.StartInfo.Arguments = "/C instruccón /y"
            'Pross.StartInfo.Arguments = "/C PING " & TextBox_Direccion.Text.Trim & " -f -1 " & TextBox_TamañoMTU.Text & "/y"
            Pross.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            'Pross.Start()
            Pross = Process.Start(processInfo)
            Pross.WaitForExit(10000)
            Dim output As String = Pross.StandardOutput.ReadToEnd
            Dim error1 As String = Pross.StandardError.ReadToEnd.ToString
            exitCode = Pross.ExitCode
            Pross.Close()

            TextBox_Resultado.AppendText(output & vbCrLf)
            TextBox_Resultado.AppendText(String.IsNullOrEmpty(output) & vbCrLf)
            TextBox_Resultado.AppendText(String.IsNullOrEmpty(error1) & vbCrLf)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
