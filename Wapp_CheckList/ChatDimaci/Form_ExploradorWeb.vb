

Imports System.IO
Imports System.Net
Imports System.Text
Imports Wapp_CheckList.Class_ServidorDNS

Public Class Form_ExploradorWeb


    Private Sub Form_ExploradorWeb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Label_Estado.Text = ""

            AddHandler WebBrowser1.Navigated, AddressOf EstadoNavigated
            AddHandler WebBrowser1.DockChanged, AddressOf EstadoDockChanged
            AddHandler WebBrowser1.DocumentCompleted, AddressOf EstadoDocumentCompleted
            AddHandler WebBrowser1.Navigating, AddressOf EstadoNavigating
            AddHandler WebBrowser1.ProgressChanged, AddressOf EstadoProgressChanged
            AddHandler WebBrowser1.FileDownload, AddressOf EstadoDescarga



            AddHandler WebBrowser1.DocumentTitleChanged, AddressOf EstadoDocumentTitleChanged
            'AddHandler WebBrowser1.ProgressChanged, AddressOf Estaduado

            WebBrowser1.ScriptErrorsSuppressed = True

            Dim proxy As New System.Net.WebProxy("http://proxyserver:80", True)
            proxy.Credentials = New System.Net.NetworkCredential("username", "password")
            System.Net.WebRequest.DefaultWebProxy = proxy

        Catch ex As Exception

        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) 'Handles Button1.Click
        '' Crear una instancia del WebBrowser
        'Dim browser As New WebBrowser()
        '' Asignarle el nombre del archivo HTML a abrir
        'browser.Navigate("https://www.bing.com")
        '' Crear una instancia del WebRequest
        'Dim request As New WebRequest(browser)
        '' Crear una instancia del WebProxy
        'Dim proxy As New WebProxy(request)
        '' Configurar el proxy y el DNS con los valores deseados
        'proxy.Address = "http://192.168.1.100:8080" ' El IP y la puerto del servidor proxy
        'proxy.Credentials = New NetworkCredential("user", "password") ' El nombre de usuario y la contraseña del servidor proxy
        'proxy.DNSSuffixes = "example.com" ' El dominio al que se redirige el DNS
        '' Asignar la propiedad Proxy del objeto WebBrowser con el objeto WebProxy creado
        'browser.Proxy = proxy
    End Sub


    'Private Shared Sub Main(ByVal args As String())
    '    Dim ipAddress As System.Net.IPAddress = ipAddress.Parse("127.0.0.1")
    '    Dim port As Integer = 8080
    '    Dim listener As System.Net.TcpListener = New System.Net.TcpListener(ipAddress, port)
    '    listener.Start()
    '    Console.WriteLine("Server started on {0}:{1}", ipAddress, port)

    '    While True
    '        Dim client As TcpClient = listener.AcceptTcpClient()
    '    End While
    'End Sub


    Private Sub TextBox_URL_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox_URL.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                WebBrowser1.Navigate(TextBox_URL.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Button10_Click(sender As Object, e As EventArgs) 'Handles Button1.Click
        ' Escuchar en el puerto 8080
        Dim listener As New System.Net.Sockets.TcpListener(8080)
        listener.Start()

        ' Esperar a que llegue una conexión
        Dim client As System.Net.Sockets.TcpClient = listener.AcceptTcpClient()

        ' Obtener el stream de entrada y salida de la conexión
        Dim stream As System.Net.Sockets.NetworkStream = client.GetStream()

        ' Leer la petición del cliente
        Dim buffer(1024) As Byte
        Dim bytesRead As Integer = stream.Read(buffer, 0, buffer.Length)
        Dim request As String = System.Text.Encoding.ASCII.GetString(buffer, 0, bytesRead)

        ' Imprimir la petición del cliente
        Console.WriteLine(request)

        ' Enviar la respuesta al cliente
        Dim response As String = "HTTP/1.1 200 OK" & vbCrLf & vbCrLf & "Hello, world!"
        Dim bytes() As Byte = System.Text.Encoding.ASCII.GetBytes(response)
        stream.Write(bytes, 0, bytes.Length)

        ' Cerrar la conexión
        client.Close()
        listener.Stop()

    End Sub

    'Private Sub Button11_Click(sender As Object, e As EventArgs) 'Handles Button1.Click
    '    ' Crear una instancia del WebBrowser
    '    Dim browser As New WebBrowser()
    '    ' Asignarle el nombre del archivo HTML a abrir
    '    browser.Navigate("https://www.bing.com")
    '    ' Crear una instancia del WebRequest
    '    Dim request As WebRequest(browser)
    '    ' Crear una instancia del WebProxy
    '    Dim proxy As WebProxy(request)
    '    ' Configurar el proxy y el DNS con los valores deseados
    '    proxy.Address = "http://192.168.1.100:8080" ' El IP y la puerto del servidor proxy
    '    proxy.Credentials = New NetworkCredential("user", "password") ' El nombre de usuario y la contraseña del servidor proxy
    '    proxy.DNSSuffixes = "example.com" ' El dominio al que se redirige el DNS
    '    ' Asignar la propiedad Proxy del objeto WebBrowser con el objeto WebProxy creado
    '    browser.Proxy = proxy


    'End Sub

    Private Sub Button_Nevegar_Click(sender As Object, e As EventArgs) Handles Button_Nevegar.Click
        Try
            'WebBrowser1.EncryptionLevel = WebBrowserEncryptionLevel.Mixed


            ' Escuchar en el puerto 8080
            Dim listener As New System.Net.Sockets.TcpListener(8080)
            listener.Start()

            ' Esperar a que llegue una conexión
            Dim client As System.Net.Sockets.TcpClient = listener.AcceptTcpClient()

            ' Obtener el stream de entrada y salida de la conexión
            Dim stream As System.Net.Sockets.NetworkStream = client.GetStream()

            ' Leer la petición del cliente
            Dim buffer(1024) As Byte
            Dim bytesRead As Integer = stream.Read(buffer, 0, buffer.Length)
            Dim request As String = System.Text.Encoding.ASCII.GetString(buffer, 0, bytesRead)

            ' Imprimir la petición del cliente
            Console.WriteLine(request)

            ' Enviar la respuesta al cliente
            Dim response As String = "HTTP/1.1 200 OK" & vbCrLf & vbCrLf & "Hello, world!"
            Dim bytes() As Byte = System.Text.Encoding.ASCII.GetBytes(response)
            stream.Write(bytes, 0, bytes.Length)

            ' Cerrar la conexión
            client.Close()
            listener.Stop()


            WebBrowser1.Navigate(TextBox_URL.Text)
            If CheckBox_Rellamar.Checked Then
                Timer1.Enabled = True
            Else
                Timer1.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            WebBrowser1.Navigate(TextBox_URL.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox_TiempoRefreco_TextChanged(sender As Object, e As EventArgs) Handles TextBox_TiempoRefreco.TextChanged
        Try
            Timer1.Interval = TextBox_TiempoRefreco.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WebBrowser1_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles WebBrowser1.Navigated
        Try
            Label_Encriptacion.Text = WebBrowser1.EncryptionLevel.ToString
        Catch ex As Exception

        End Try
    End Sub



    Structure DnsARecord
        Public Name As String
        Public IpAddress As IPAddress
    End Structure

    Friend Function Main_DNS()
        Dim domainName As String = TextBox_URL.Text
        Dim dnsServerAddress As IPAddress = IPAddress.Parse(TextBox_DNS.Text) '(TextBox_DNSip.Text) ' Por ejemplo, utiliza el servidor DNS de Google
        Dim dnsServerPort As Integer = 53 ' Puerto estándar para DNS

        ' Crea un socket UDP
        Dim dnsSocket As New System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Dgram, System.Net.Sockets.ProtocolType.Udp)

        ' Construye la consulta DNS
        Dim queryBytes As Byte() = BuildDnsQuery(domainName)

        ' Envía la consulta al servidor DNS
        dnsSocket.SendTo(queryBytes, New IPEndPoint(dnsServerAddress, dnsServerPort))

        ' Recibe la respuesta del servidor DNS
        'Dim responseBuffer(1024) As Byte
        Dim responseBuffer(11) As Byte
        Dim bytesRead As Integer = dnsSocket.Receive(responseBuffer)
        'Dim ReadBytes As Byte() = dnsSocket.Receive(responseBuffer)

        ' Procesa la respuesta (analiza los registros DNS, etc.)
        ' Aquí deberías implementar la lógica para extraer la dirección IP del resultado








        ' Lista para almacenar los registros A
        Dim aRecords As New List(Of DnsARecord)()

        ' Analiza la respuesta DNS
        ' Aquí debes implementar la lógica para extraer los registros A
        ' Puedes usar BitConverter para leer los bytes y extraer la dirección IP
        Dim IPtexto As String = String.Empty
        Dim cuenta As Int16 = 0
        ' Ejemplo de extracción de registros A (simplificado)

        For Each rr In responseBuffer
            'If rr.Type = DnsRecordType.A Then
            Dim ipAddressBytes = rr ' Supongamos que aquí obtienes los bytes de la dirección IP
            '    Dim ipAddress = New IPAddress(ipAddressBytes)
            '    Dim aRecord As New DnsARecord With {.Name = rr.Name, .IpAddress = ipAddress}
            '    aRecords.Add(aRecord)
            'End If
            IPtexto &= rr
            cuenta += 1
            If cuenta > 3 Then
                cuenta = 0
                Dim nuevoRegistro As New DnsARecord()
                nuevoRegistro.Name = TextBox_DNSip.Text
                nuevoRegistro.IpAddress = IPAddress.Parse(IPtexto)
                aRecords.Add(nuevoRegistro)
                IPtexto = ""
            Else
                IPtexto &= "."
            End If
        Next

        TextBox_DestIp.Text = aRecords(0).IpAddress.ToString  '.Address.ToString


        ' Ahora tienes una lista de registros A con nombres de dominio e IP
        ' Puedes acceder a la dirección IP según tus necesidades
        For Each record In aRecords
            Console.WriteLine($"Nombre de dominio: {record.Name}, Dirección IP: {record.IpAddress}")
        Next




        ' Cierra el socket
        dnsSocket.Close()

        Return bytesRead
    End Function


    Private Function BuildDnsQuery(domainName As String) As Byte()
        ' Construye una consulta DNS de tipo A (IPv4)
        ' El formato general de una consulta DNS es el siguiente:
        '   - Cabecera (12 bytes)
        '   - Preguntas (variable)
        '   - Otras secciones (Respuestas, Autoridad, Adicional) (variable)

        ' Aquí se muestra una implementación simplificada:
        Dim queryBytes As New List(Of Byte)()

        ' ID de consulta (2 bytes, se puede generar aleatoriamente)
        queryBytes.AddRange(BitConverter.GetBytes(CUShort(1234)))

        ' Flags (2 bytes, por ejemplo, 0x0100 para una consulta estándar)
        queryBytes.AddRange(BitConverter.GetBytes(CUShort(&H100)))

        ' Conteo de preguntas (2 bytes, en este caso, 1 pregunta)
        queryBytes.AddRange(BitConverter.GetBytes(CUShort(1)))

        ' Conteo de respuestas, autoridad y adicional (2 bytes cada uno, todos 0 para una consulta)
        queryBytes.AddRange(BitConverter.GetBytes(CUShort(0)))
        queryBytes.AddRange(BitConverter.GetBytes(CUShort(0)))
        queryBytes.AddRange(BitConverter.GetBytes(CUShort(0)))

        ' Nombre de dominio (convertido a etiquetas y longitud)
        Dim domainParts As String() = domainName.Split("."c)
        For Each part In domainParts
            queryBytes.Add(CByte(part.Length))
            queryBytes.AddRange(Encoding.ASCII.GetBytes(part))
        Next

        ' Tipo de registro (2 bytes, 1 para A)
        queryBytes.AddRange(BitConverter.GetBytes(CUShort(1)))

        ' Clase (2 bytes, 1 para Internet)
        queryBytes.AddRange(BitConverter.GetBytes(CUShort(1)))

        ' Retorna los bytes de la consulta
        Return queryBytes.ToArray()
        'Return New Byte() {}
    End Function

    Dim ServidorDNS As DNSServer

    Private Sub Label_DNS_Click(sender As Object, e As EventArgs) Handles Label_DNS.Click
        Try


            Dim lookup = Main_DNS()

            Dim endpoint As IPEndPoint = New IPEndPoint(System.Net.IPAddress.Parse(TextBox_DNSip.Text), CInt(TextBox_DNSport.Text))

            'Dim endpoint As var = New IPEndPoint(NameServer.GooglePublicDns)
            'Dim lookup As var = New LookupClient(endpoint)
            'Dim hostEntry As IPHostEntry = lookup.GetHostEntry(hostOrIp)
            'Console.WriteLine(hostEntry.HostName)
            'For Each ip In hostEntry.AddressList
            '    Console.WriteLine(ip)
            'Next
            'For Each alias In hostEntry.Aliases
            '    Console.WriteLine(alias)
            'Next



            Dim nombrePC As String = Dns.GetHostName()
            Dim entradasIP As Net.IPHostEntry = Dns.GetHostEntry(TextBox_DNSip.Text.ToString)
            'Dim Direcciones() As String = New String() {}
            'Dim Direcciones As Net.IPAddress
            'Direcciones = entradasIP.AddressList
            Dim direccionIP As String = entradasIP.AddressList(0).ToString()
            TextBox_DestIp.Text = direccionIP

            ComboBox_ListaIP.Items.Clear()
            For index = 0 To entradasIP.AddressList.Length - 1
                ComboBox_DestIp.Items.Add(entradasIP.AddressList(index).ToString())
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetDns(ByVal hostName As String, ByVal dnsServer As String)
        Dim processStartInfo As New ProcessStartInfo("cmd.exe")
        processStartInfo.Arguments = "/c netsh interface ip set dns """ & hostName & """ static " & dnsServer & " primary"
        processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
        Process.Start(processStartInfo).WaitForExit()
    End Sub

#Region ""


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

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EstadoDescarga(sender As Object, e As EventArgs)
        Try

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
            Label_Encriptacion.Text = WebBrowser1.EncryptionLevel & " " & DirectCast(sender, WebBrowser).DocumentTitle
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
            Label_Encriptacion.Text = WebBrowser1.EncryptionLevel
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

    Private Sub Label_Encriptacion_Click(sender As Object, e As EventArgs) Handles Label_Encriptacion.Click
        ServidorDNS = New DNSServer
    End Sub


#End Region


End Class