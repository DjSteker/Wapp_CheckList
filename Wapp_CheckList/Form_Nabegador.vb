Public Class Form_Nabegador

    Private Sub Form_Nabegador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Label_Estado.Text = ""

            AddHandler WebBrowser1.Navigated, AddressOf EstadoNavigated
            AddHandler WebBrowser1.DockChanged, AddressOf EstadoDockChanged
            AddHandler WebBrowser1.DocumentCompleted, AddressOf EstadoDocumentCompleted
            AddHandler WebBrowser1.Navigating, AddressOf EstadoNavigating
            AddHandler WebBrowser1.ProgressChanged, AddressOf EstadoProgressChanged
            AddHandler WebBrowser1.FileDownload, AddressOf EstadoDescargado6


            AddHandler WebBrowser1.DocumentTitleChanged, AddressOf EstadoTitulo
            AddHandler WebBrowser1.FileDownload, AddressOf EstadoDescargado
            AddHandler WebBrowser1.ProgressChanged, AddressOf EstadoProgressChanged
            AddHandler WebBrowser1.Navigating, AddressOf EstadoNabegado
            AddHandler WebBrowser1.CanGoBackChanged, AddressOf CanGoBack
            AddHandler WebBrowser1.CanGoForwardChanged, AddressOf CanGoForward

            AddHandler WebBrowser1.DocumentTitleChanged, AddressOf EstadoDocumentTitleChanged
            'AddHandler WebBrowser1.ProgressChanged, AddressOf Estaduado

            AddHandler TabControl1.SelectedIndexChanged, AddressOf TabControl1_Selecting

            'BiblitecaWebArrayList = New ArrayList
            'BiblitecaWebArrayList.Add(WebBrowser1)

            ArrayBrowsers.Add(WebBrowser1)

            TabControl1.TabPages.Remove(TabControl1.TabPages.Item(1)) '  (TabControl1.TabIndex(1))

            LimpiarTextosBotones()

            Me.KeyPreview = True
            WebBrowser1.ScriptErrorsSuppressed = True


            'TextBox_URL.KeyPreview = True

        Catch ex As Exception

        End Try
    End Sub


    Private Sub SetDns(ByVal hostName As String, ByVal dnsServer As String)
        Dim processStartInfo As New ProcessStartInfo("cmd.exe")
        processStartInfo.Arguments = "/c netsh interface ip set dns """ & hostName & """ static " & dnsServer & " primary"
        processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
        Process.Start(processStartInfo).WaitForExit()
    End Sub

    Private Sub LimpiarTextosBotones()
        Try
            Button_Atras.Text = String.Empty
            Button_Adelante.Text = String.Empty
            Button_Parada.Text = String.Empty
            Button_Navega.Text = String.Empty
            Button_Agregar.Text = String.Empty
            Button_Borra.Text = String.Empty
        Catch ex As Exception

        End Try
    End Sub

#Region ""

    'Y empieza la segunda
    Event _PunteroParaWebBrowser()
    Friend WithEvents WebBrowserNuevo As System.Windows.Forms.WebBrowser
    Friend WithEvents myTabPage As System.Windows.Forms.TabPage
    ' Dim SeleccionComputadoraWebBrowser11a As WebBrowser = (BiblitecaWebArrayList(NumeroPajina))'Estta esta sin uso
    'Dim BiblitecaWebArrayList As ArrayList
    Dim ArrayBrowsers As New List(Of WebBrowser)
    Public WebTabPageSelcionado As Object
    Public NumeroPajina As Object
    'Public NumeroSeleccion As Object
    Public NumeroPajina1 As Object
    Private Selector As WebBrowser
    Dim SeleccionComputadora_WebBrowser

#End Region


    Private Sub TextBox_URL_KeyDown(sender As Object, e As KeyPressEventArgs) Handles TextBox_URL.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                ArrayBrowsers.Item(NumeroPajina).Navigate(TextBox_URL.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Estaduado(sender As Object, e As WebBrowserProgressChangedEventArgs)
        Try
            Dim valorMax As Integer = e.MaximumProgress
            Dim valor As Integer = e.CurrentProgress
            Label_Estado.Text = valor & "%"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub EstadoNavigating(sender As Object, e As WebBrowserNavigatingEventArgs)
        Try
            Label_Estado.Visible = True
            ProgressBar_Web.Visible = True
        Catch ex As Exception

        End Try
        Try
            SetDns(e.Url.Host, TextBox_DNS.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EstadoDocumentTitleChanged(sender As Object, e As EventArgs)
        Try
            If ArrayBrowsers.Item(NumeroPajina).Document.Title.Length > 12 Then


                TabControl1.SelectedTab.Text = Mid(ArrayBrowsers.Item(NumeroPajina).Document.Title, 1, 12)
            Else

                TabControl1.SelectedTab.Text = ArrayBrowsers.Item(NumeroPajina).Document.Title

            End If

        Catch ex As Exception

        End Try





    End Sub

    Private Sub EstadoDescargado6(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EstadoProgressChanged(sender As Object, e As WebBrowserProgressChangedEventArgs)
        Try
            Dim valorMax As Integer = e.MaximumProgress
            Dim valor As Integer = e.CurrentProgress
            Label_Estado.Text = (valor / valorMax) & "%"
            ProgressBar_Web.Maximum = valorMax
            ProgressBar_Web.Value = valor
        Catch ex As Exception

        End Try

        'Try
        '    Dim valorMax As Integer = e.MaximumProgress
        '    Dim valor As Integer = e.CurrentProgress
        '    Label_Estado.Text = valor & "%"
        'Catch ex As Exception

        'End Try

    End Sub



    Private Sub EstadoDocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs)
        Try
            Label_Estado.Text = ArrayBrowsers.Item(NumeroPajina).EncryptionLevel & " " & DirectCast(sender, WebBrowser).DocumentTitle
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EstadoDockChanged(sender As Object, e As EventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EstadoNavigated(sender As Object, e As WebBrowserNavigatedEventArgs)
        Try

            Label_Estado.Visible = False
            ProgressBar_Web.Visible = False
            Dim tabPage As TabPage = TabControl1.TabPages.Item(CInt(TabControl1.SelectedIndex))
            'TabControl1.SelectedIndex(tabPage.Text)
            tabPage.Text = ArrayBrowsers.Item(NumeroPajina).DocumentTitle

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_Browser_Click(sender As Object, e As EventArgs) ' Handles Button_Navigate.Click
        Try
            WebBrowser1.Navigate(TextBox_URL.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EstadoTitulo()
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EstadoActuliza()
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EstadoNabegado()
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EstadoDescargado()
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_Parada_Click(sender As Object, e As EventArgs) Handles Button_Parada.Click

        Try
            'Dim SeleccionComputadoraWebBrowser As Object = (BiblitecaWebArrayList(NumeroPajina))

            ArrayBrowsers.Item(NumeroPajina).Stop()

            'SeleccionComputadoraWebBrowser.Stop()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button_Navegar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Navega.Click
        Try
            'Dim SeleccionComputadoraWebBrowser As Object = (BiblitecaWebArrayList(NumeroPajina))
            'SeleccionComputadoraWebBrowser.Navigate(TextBox_URL.Text)

            ArrayBrowsers.Item(NumeroPajina).Navigate(TextBox_URL.Text)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            ' WebBrowser1.Navigate(TextBox1.Text)
            Dim glpa2 As Boolean = My.Computer.Network.IsAvailable
            If glpa2 = True Then : Label_Estado.Text = ("Conexion")
            ElseIf glpa2 = False Then : Label_Estado.Text = "sin conexon"
            End If
            My.Computer.FileSystem.WriteAllText("AB_D1\Fichero_Rutas.txt", "          ", False)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub NavegaAdelante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Adelante.Click

        Try
            'Dim SeleccionComputadoraWebBrowser As Object = (BiblitecaWebArrayList(SelectorBibliteca))
            'SeleccionComputadoraWebBrowser.GoForward()
            ArrayBrowsers.Item(NumeroPajina).GoForward()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            ' WebBrowser1.Navigate(TextBox1.Text)
            Dim glpa2 As Boolean = My.Computer.Network.IsAvailable
            If glpa2 = True Then : Label_Estado.Text = ("Conexion")
            ElseIf glpa2 = False Then : Label_Estado.Text = "sin conexon"
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub NavegaAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Atras.Click
        Dim SelectorBibliteca = (NumeroPajina)
        Try
            'Dim SeleccionComputadoraWebBrowser As Object = (BiblitecaWebArrayList(SelectorBibliteca))
            'SeleccionComputadoraWebBrowser.GoBack() '(TextBox1.Text)
            ArrayBrowsers.Item(NumeroPajina).GoBack()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            Dim glpa2 As Boolean = My.Computer.Network.IsAvailable
            If glpa2 = True Then : Label_Estado.Text = ("Conexion")
            ElseIf glpa2 = False Then : Label_Estado.Text = ("sin conexon")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    'Public Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As TabControlCancelEventArgs) Handles TabControl1.Selecting
    Public Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As EventArgs) Handles TabControl1.Selecting
        Try
            WebTabPageSelcionado = Nothing
            'NumeroPajina = (e.TabPageIndex)
            NumeroPajina = TabControl1.SelectedIndex
            'NumeroPajina1 = (e.TabPageIndex + 1)
            NumeroPajina1 = (TabControl1.SelectedIndex + 1)
            ' Label_Estado.Text = ((("WebBrowser") & (NumeroPajina1) & "  " & BiblitecaWebArrayList.Count))

            Dim octalNumero As Object = Oct((NumeroPajina1))
            Dim WebTabPage As Object = ("WebBrowser" & CStr(octalNumero))
            'NumeroSeleccion = e.TabPageIndex
        Catch ex As Exception

        End Try

        Try
            'Selector = BiblitecaWebArrayList(NumeroPajina)
            Selector = ArrayBrowsers.Item(NumeroPajina)
        Catch ex As Exception
            '  RaiseEvent _PunteroParaWebBrowser()
            MsgBox(" error " & ex.ToString)
            ' RaiseEvent _PunteroParaWebBrowser()
        End Try

        Try
            'Dim SelectorBibliteca = (NumeroPajina)
            'Dim SeleccionComputadoraWebBrowser As Object = (BiblitecaWebArrayList(SelectorBibliteca))
            'SeleccionComputadora_WebBrowser = SeleccionComputadoraWebBrowser

            'If SeleccionComputadora_WebBrowser <> String.Empty Then

            'End If
            If ArrayBrowsers.Item(NumeroPajina).Url <> Nothing Then
                Label_Estado.Text = ArrayBrowsers.Item(NumeroPajina).Url.AbsoluteUri.ToString 'SeleccionComputadora_WebBrowser.Url.AbsoluteUri.ToString
                TextBox_URL.Text = ArrayBrowsers.Item(NumeroPajina).Url.ToString ' SeleccionComputadora_WebBrowser.Url.ToString
            Else
                Label_Estado.Text = ""
                TextBox_URL.Text = ""
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button_Agregar_Click(sender As Object, e As EventArgs) Handles Button_Agregar.Click
        Try

            Dim WebTabPageNumero As Integer = (TabControl1.TabPages.Count + 1)
            Dim NumbreNuevoWebBrowser As Object = ("WebBrowser" & WebTabPageNumero.ToString)
            Dim NumeroTabPge As Object = (TabControl1.TabPages.Count - 1)
            Me.myTabPage = New TabPage()
            myTabPage.Text = "TabPage" & (TabControl1.TabPages.Count + 1)
            TabControl1.TabPages.Add(myTabPage)
            myTabPage.Select()

            Me.WebBrowserNuevo = New System.Windows.Forms.WebBrowser
            Me.WebBrowserNuevo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.WebBrowserNuevo.Location = New System.Drawing.Point(3, 3)
            Me.WebBrowserNuevo.MinimumSize = New System.Drawing.Size(20, 20)
            Me.WebBrowserNuevo.Name = NumbreNuevoWebBrowser.ToString
            Me.WebBrowserNuevo.Size = New System.Drawing.Size(220, 143)
            Me.WebBrowserNuevo.TabIndex = 0
            Me.myTabPage.Controls.Add(Me.WebBrowserNuevo)

            AddHandler WebBrowserNuevo.Navigating, AddressOf Navegando
            AddHandler WebBrowserNuevo.ProgressChanged, AddressOf WebTabPage1_ProgressChanged
            AddHandler WebBrowserNuevo.DocumentTitleChanged, AddressOf DocumendoCamviaTitulo
            AddHandler WebBrowserNuevo.StatusTextChanged, AddressOf webBrowser1_StatusTextChanged
            AddHandler WebBrowserNuevo.Navigated, AddressOf webBrowser1_Navigated

            AddHandler WebBrowserNuevo.DocumentTitleChanged, AddressOf EstadoTitulo
            AddHandler WebBrowserNuevo.FileDownload, AddressOf EstadoDescargado
            AddHandler WebBrowserNuevo.ProgressChanged, AddressOf EstadoProgressChanged
            AddHandler WebBrowserNuevo.Navigating, AddressOf EstadoNabegado
            AddHandler WebBrowserNuevo.CanGoBackChanged, AddressOf CanGoBack
            AddHandler WebBrowserNuevo.CanGoForwardChanged, AddressOf CanGoForward
            'WebTabPage1_ProgressChanged(ByVal sender As Object, ByVal e As WebBrowserProgressChangedEventArgs) 'Handles WebBrowser1.ProgressChanged
            WebBrowserNuevo.TabIndex = TabControl1.TabPages.Count
            'BiblitecaWebArrayList.Add(WebBrowserNuevo)
            WebBrowserNuevo.ScriptErrorsSuppressed = True
            ArrayBrowsers.Add(WebBrowserNuevo)
            Label_Estado.Text = ""

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button_Borra_Click(sender As Object, e As EventArgs) Handles Button_Borra.Click
        'Dim DestructorSelecTab As Object
        'Dim SeleccionComputadoraWebBrowser1 As Object
        Try
            'DestructorSelecTab = (TabControl1.SelectedTab)
            'SeleccionComputadoraWebBrowser1 = ArrayBrowsers.Item(NumeroPajina) '(BiblitecaWebArrayList(NumeroPajina))


            If ArrayBrowsers.Count = 1 Then 'If BiblitecaWebArrayList.Count = 1 Then
                Label_Estado.Text = " No se puede " : GoTo 10
            End If
        Catch ex As Exception

        End Try

        Try
            '   SeleccionComputadoraWebBrowser1.Stop()
            'SeleccionComputadoraWebBrowser1.Dispose()
            TabControl1.TabPages.Remove(TabControl1.SelectedTab)
            'BiblitecaWebArrayList.Remove(SeleccionComputadoraWebBrowser1)
            ArrayBrowsers.Remove(ArrayBrowsers.Item(NumeroPajina))
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
10:     ' salida
    End Sub



#Region "nuevaPestaña"


    Private Sub webBrowser1_StatusTextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            'Dim SeleccionComputadoraWebBrowser As Object = (BiblitecaWebArrayList(NumeroPajina))
            'Label_Estado.Text = SeleccionComputadoraWebBrowser.StatusText.ToString & " "

            Label_Estado.Text = ArrayBrowsers.Item(NumeroPajina).StatusText.ToString & " "
        Catch ex As Exception
            Label_Estado.Text = ex.Message '  MsgBox(ex.Message)
        End Try
    End Sub
    Sub WebTabPage1_ProgressChanged(ByVal sender As WebBrowser, ByVal e As WebBrowserProgressChangedEventArgs)
        Try
            Dim MaximoIncremento As Integer = (e.MaximumProgress) / (100)
            ProgressBar_Web.Maximum = (e.MaximumProgress)
            ProgressBar_Web.Increment(e.CurrentProgress)
        Catch ex As Exception
            '    MsgBox("  En EL Progreso :  " & ex.Message & "  _-y-_  " & ex.ToString)
        End Try 'ex.InnerException
        Try
            '  Dim SelectroProgres As WebBrowser = BiblitecaWebArrayList(NumeroPajina)
            Dim nevegando As String = sender.DocumentText & "  " & sender.StatusText.ToString  'SeleccionComputadora_WebBrowser.Url.AbsoluteUri
            Label_Estado.Text = (nevegando)
            'My.Computer.FileSystem.WriteAllText("AB_D1\Fichero_Rutas.txt", " ", False)
            'My.Computer.FileSystem.WriteAllText("AB_D1\Fichero_Rutas.txt", " " & nevegando & " ,", True)
        Catch ex As Exception
            '   MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Private Sub webBrowser1_Navigated(ByVal sender As WebBrowser, ByVal e As WebBrowserNavigatedEventArgs)
        Try
            Dim RutaWeb As String = sender.Url.DnsSafeHost
            'Label4.Text = (RutaWeb)
            TextBox_URL.Text = RutaWeb
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub


    Friend Sub DocumendoCamviaTitulo(ByVal sender As WebBrowser, ByVal e As EventArgs)
        Try
            Dim Titulo As String
            Dim Tipo As String
            With sender
                Titulo = .DocumentTitle
                Tipo = .DocumentType()
            End With
            Dim ContenedorWebBrow As TabPage = sender.Parent
            ContenedorWebBrow.Text = Mid(Titulo, 1, 8)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Friend Sub Navegando(ByVal sender As Object, ByVal e As WebBrowserNavigatingEventArgs)
        'Dim SelectorBibliteca = (NumeroPajina)
        Try
            My.Computer.FileSystem.WriteAllText("AB_D1\Fichero_Rutas.txt", e.Url.ToString & "  ", False)
            Label_Estado.Text &= " " & e.Url.ToString 'SeleccionComputadoraWebBrowser.Url.ToString
        Catch ex As Exception
            Label_Estado.Text = ex.Message
        End Try
        Try
            Dim ContenedorWebBrow As TabPage = sender.Parent
            ContenedorWebBrow.ToolTipText = e.Url.AbsoluteUri.ToString
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub TextBox_URL_TextChanged(sender As Object, e As EventArgs) Handles TextBox_URL.TextChanged

    End Sub



#End Region


    Private Sub CanGoBack(sender As Object, e As EventArgs)
        Try
            Button_Atras.Enabled = CType(sender, WebBrowser).CanGoBack
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CanGoForward(sender As Object, e As EventArgs)
        Try
            Button_Adelante.Enabled = CType(sender, WebBrowser).CanGoForward
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#Region "DNS"

    'Private Sub Label_DNS_Click(sender As Object, e As EventArgs) Handles Label_DNS.Click
    '    Try

    '        Dim endpoint As IPEndPoint = New IPEndPoint(System.Net.IPAddress.Parse(TextBox_DNSip.Text), CInt(TextBox_DNSport.Text))

    '        Dim lookup = Main_DNS()


    '        'Dim endpoint As var = New IPEndPoint(NameServer.GooglePublicDns)
    '        'Dim lookup As var = New LookupClient(endpoint)
    '        'Dim hostEntry As IPHostEntry = lookup.GetHostEntry(hostOrIp)
    '        'Console.WriteLine(hostEntry.HostName)
    '        'For Each ip In hostEntry.AddressList
    '        '    Console.WriteLine(ip)
    '        'Next
    '        'For Each alias In hostEntry.Aliases
    '        '    Console.WriteLine(alias)
    '        'Next



    '        Dim nombrePC As String = Dns.GetHostName()
    '        Dim entradasIP As Net.IPHostEntry = Dns.GetHostEntry(TextBox_URL.Text.ToString)
    '        'Dim Direcciones() As String = New String() {}
    '        'Dim Direcciones As Net.IPAddress
    '        'Direcciones = entradasIP.AddressList
    '        Dim direccionIP As String = entradasIP.AddressList(0).ToString()
    '        TextBox_DestIp.Text = direccionIP

    '        ComboBox_ListaIP.Items.Clear()
    '        For index = 0 To entradasIP.AddressList.Length - 1
    '            ComboBox_DestIp.Items.Add(entradasIP.AddressList(index).ToString())
    '        Next

    '    Catch ex As Exception

    '    End Try
    'End Sub


    'Structure DnsARecord
    '    Public Name As String
    '    Public IpAddress As IPAddress
    'End Structure

    'Friend Function Main_DNS()
    '    Dim domainName As String = TextBox_DNSip.Text
    '    Dim dnsServerAddress As IPAddress = IPAddress.Parse(TextBox_DNSip.Text) ' Por ejemplo, utiliza el servidor DNS de Google
    '    Dim dnsServerPort As Integer = 53 ' Puerto estándar para DNS

    '    ' Crea un socket UDP
    '    Dim dnsSocket As New System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Dgram, System.Net.Sockets.ProtocolType.Udp)

    '    ' Construye la consulta DNS
    '    Dim queryBytes As Byte() = BuildDnsQuery(domainName)

    '    ' Envía la consulta al servidor DNS
    '    dnsSocket.SendTo(queryBytes, New IPEndPoint(dnsServerAddress, dnsServerPort))

    '    ' Recibe la respuesta del servidor DNS
    '    'Dim responseBuffer(1024) As Byte
    '    Dim responseBuffer(11) As Byte
    '    Dim bytesRead As Integer = dnsSocket.Receive(responseBuffer)
    '    'Dim ReadBytes As Byte() = dnsSocket.Receive(responseBuffer)

    '    ' Procesa la respuesta (analiza los registros DNS, etc.)
    '    ' Aquí deberías implementar la lógica para extraer la dirección IP del resultado








    '    ' Lista para almacenar los registros A
    '    Dim aRecords As New List(Of DnsARecord)()

    '    ' Analiza la respuesta DNS
    '    ' Aquí debes implementar la lógica para extraer los registros A
    '    ' Puedes usar BitConverter para leer los bytes y extraer la dirección IP
    '    Dim IPtexto As String = String.Empty
    '    Dim cuenta As Int16 = 0
    '    ' Ejemplo de extracción de registros A (simplificado)

    '    For Each rr In responseBuffer
    '        'If rr.Type = DnsRecordType.A Then
    '        Dim ipAddressBytes = rr ' Supongamos que aquí obtienes los bytes de la dirección IP
    '        '    Dim ipAddress = New IPAddress(ipAddressBytes)
    '        '    Dim aRecord As New DnsARecord With {.Name = rr.Name, .IpAddress = ipAddress}
    '        '    aRecords.Add(aRecord)
    '        'End If
    '        IPtexto &= rr
    '        cuenta += 1
    '        If cuenta > 3 Then
    '            cuenta = 0
    '            Dim nuevoRegistro As New DnsARecord()
    '            nuevoRegistro.Name = TextBox_DNSip.Text
    '            nuevoRegistro.IpAddress = IPAddress.Parse(IPtexto)
    '            aRecords.Add(nuevoRegistro)
    '            IPtexto = ""
    '        Else
    '            IPtexto &= "."
    '        End If
    '    Next

    '    TextBox_DestIp.Text = aRecords(0).IpAddress.ToString  '.Address.ToString


    '    ' Ahora tienes una lista de registros A con nombres de dominio e IP
    '    ' Puedes acceder a la dirección IP según tus necesidades
    '    For Each record In aRecords
    '        Console.WriteLine($"Nombre de dominio: {record.Name}, Dirección IP: {record.IpAddress}")
    '    Next




    '    ' Cierra el socket
    '    dnsSocket.Close()

    '    Return bytesRead
    'End Function


    'Private Function BuildDnsQuery(domainName As String) As Byte()
    '    ' Construye una consulta DNS de tipo A (IPv4)
    '    ' El formato general de una consulta DNS es el siguiente:
    '    '   - Cabecera (12 bytes)
    '    '   - Preguntas (variable)
    '    '   - Otras secciones (Respuestas, Autoridad, Adicional) (variable)

    '    ' Aquí se muestra una implementación simplificada:
    '    Dim queryBytes As New List(Of Byte)()

    '    ' ID de consulta (2 bytes, se puede generar aleatoriamente)
    '    queryBytes.AddRange(BitConverter.GetBytes(CUShort(1234)))

    '    ' Flags (2 bytes, por ejemplo, 0x0100 para una consulta estándar)
    '    queryBytes.AddRange(BitConverter.GetBytes(CUShort(&H100)))

    '    ' Conteo de preguntas (2 bytes, en este caso, 1 pregunta)
    '    queryBytes.AddRange(BitConverter.GetBytes(CUShort(1)))

    '    ' Conteo de respuestas, autoridad y adicional (2 bytes cada uno, todos 0 para una consulta)
    '    queryBytes.AddRange(BitConverter.GetBytes(CUShort(0)))
    '    queryBytes.AddRange(BitConverter.GetBytes(CUShort(0)))
    '    queryBytes.AddRange(BitConverter.GetBytes(CUShort(0)))

    '    ' Nombre de dominio (convertido a etiquetas y longitud)
    '    Dim domainParts As String() = domainName.Split("."c)
    '    For Each part In domainParts
    '        queryBytes.Add(CByte(part.Length))
    '        queryBytes.AddRange(Encoding.ASCII.GetBytes(part))
    '    Next

    '    ' Tipo de registro (2 bytes, 1 para A)
    '    queryBytes.AddRange(BitConverter.GetBytes(CUShort(1)))

    '    ' Clase (2 bytes, 1 para Internet)
    '    queryBytes.AddRange(BitConverter.GetBytes(CUShort(1)))

    '    ' Retorna los bytes de la consulta
    '    Return queryBytes.ToArray()
    '    'Return New Byte() {}
    'End Function

#End Region




End Class