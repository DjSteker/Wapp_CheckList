Imports System.IO
Imports System.Net.Sockets
Imports System.Text
Imports System.Xml

Public Class Class_WebSearchEngine
    Private Index As Dictionary(Of String, Page) ' Índice de páginas web
    Private VisitLog As Dictionary(Of String, Dictionary(Of DateTime, Integer)) ' Seguimiento de visitas y logaritmo temporal
    Private Categories As Dictionary(Of String, List(Of String)) ' Búsqueda por categorías
    Private XmlFilePath As String = "web_data.xml" ' Ruta del archivo XML para almacenar datos

    Public Sub New()
        Index = New Dictionary(Of String, Page)()
        VisitLog = New Dictionary(Of String, Dictionary(Of DateTime, Integer))()
        Categories = New Dictionary(Of String, List(Of String))()
        LoadDataFromXml()
    End Sub

    Public Sub IndexPage(url As String, content As String, category As String)
        ' Indexar una nueva página
        Dim page As New Page(url, content, category)
        Index(url) = page

        ' Actualizar las categorías
        If Not Categories.ContainsKey(category) Then
            Categories(category) = New List(Of String)()
        End If
        Categories(category).Add(url)
    End Sub

    Public Sub VisitPage(url As String)
        ' Registrar la visita de una página
        If Not VisitLog.ContainsKey(url) Then
            VisitLog(url) = New Dictionary(Of DateTime, Integer)()
        End If

        Dim currentTime As DateTime = DateTime.Now
        VisitLog(url)(currentTime) = VisitLog(url).Count + 1
    End Sub

    Public Function Search(query As String) As List(Of String)
        ' Búsqueda simple utilizando la consulta en el contenido de las páginas
        Dim results As New List(Of String)()

        For Each page In Index.Values
            If page.Content.Contains(query) Then
                results.Add(page.Url)
            End If
        Next

        Return results
    End Function

    Public Function GetPagesInCategory(category As String) As List(Of String)
        ' Obtener todas las páginas en una categoría específica
        If Categories.ContainsKey(category) Then
            Return Categories(category)
        Else
            Return New List(Of String)()
        End If
    End Function

    Public Sub SaveDataToXml()
        ' Guardar datos en un archivo XML
        Dim doc As New XmlDocument()
        Dim root As XmlElement = doc.CreateElement("WebSearchEngine")
        doc.AppendChild(root)

        ' Guardar páginas indexadas
        For Each page In Index.Values
            Dim pageElement As XmlElement = doc.CreateElement("Page")
            pageElement.SetAttribute("Url", page.Url)
            pageElement.SetAttribute("Category", page.Category)
            pageElement.InnerText = page.Content
            root.AppendChild(pageElement)
        Next

        ' Guardar registro de visitas
        For Each url In VisitLog.Keys
            Dim visitElement As XmlElement = doc.CreateElement("VisitLog")
            visitElement.SetAttribute("Url", url)

            For Each entry In VisitLog(url)
                Dim visitEntry As XmlElement = doc.CreateElement("VisitEntry")
                visitEntry.SetAttribute("DateTime", entry.Key.ToString())
                visitEntry.SetAttribute("VisitCount", entry.Value.ToString())
                visitElement.AppendChild(visitEntry)
            Next

            root.AppendChild(visitElement)
        Next

        ' Guardar categorías
        For Each category In Categories.Keys
            Dim categoryElement As XmlElement = doc.CreateElement("Category")
            categoryElement.SetAttribute("Name", category)

            For Each url In Categories(category)
                Dim urlElement As XmlElement = doc.CreateElement("Url")
                urlElement.InnerText = url
                categoryElement.AppendChild(urlElement)
            Next

            root.AppendChild(categoryElement)
        Next

        doc.Save(XmlFilePath)
    End Sub

    Public Sub LoadDataFromXml()
        ' Cargar datos desde un archivo XML
        If File.Exists(XmlFilePath) Then
            Dim doc As New XmlDocument()
            doc.Load(XmlFilePath)

            ' Cargar páginas indexadas
            For Each pageElement As XmlElement In doc.SelectNodes("//Page")
                Dim url As String = pageElement.GetAttribute("Url")
                Dim content As String = pageElement.InnerText
                Dim category As String = pageElement.GetAttribute("Category")
                IndexPage(url, content, category)
            Next

            ' Cargar registro de visitas
            For Each visitElement As XmlElement In doc.SelectNodes("//VisitLog")
                Dim url As String = visitElement.GetAttribute("Url")
                VisitLog(url) = New Dictionary(Of DateTime, Integer)()

                For Each visitEntry As XmlElement In visitElement.SelectNodes("VisitEntry")
                    Dim dateTime As DateTime = DateTime.Parse(visitEntry.GetAttribute("DateTime"))
                    Dim visitCount As Integer = Integer.Parse(visitEntry.GetAttribute("VisitCount"))
                    VisitLog(url)(dateTime) = visitCount
                Next
            Next

            ' Cargar categorías
            For Each categoryElement As XmlElement In doc.SelectNodes("//Category")
                Dim category As String = categoryElement.GetAttribute("Name")
                Categories(category) = New List(Of String)()

                For Each urlElement As XmlElement In categoryElement.SelectNodes("Url")
                    Categories(category).Add(urlElement.InnerText)
                Next
            Next
        End If
    End Sub
End Class

Public Class Page
    Public Property Url As String
    Public Property Content As String
    Public Property Category As String
    Public Property H1Content As List(Of String)
    Public Property H2Content As List(Of String)
    Public Property H3Content As List(Of String)
    Public Property H4Content As List(Of String)

    Public Sub New(url As String, content As String, category As String)
        Me.Url = url
        Me.Content = content
        Me.Category = category
        Me.H1Content = New List(Of String)()
        Me.H2Content = New List(Of String)()
        Me.H3Content = New List(Of String)()
        Me.H4Content = New List(Of String)()

        ' Parsear contenido y llenar las listas correspondientes
        ParseContent()
    End Sub

    Private Sub ParseContent()
        ' Analizar el contenido para extraer texto de los encabezados
        ' Puedes usar una biblioteca HTML parser más robusta para esto, pero aquí
        ' lo haremos de manera simple para fines de ejemplo.

        ' Ejemplo: Buscar y extraer texto de los encabezados H1, H2, H3, H4
        'Dim doc As New HtmlAgilityPack.HtmlDocument()
        'doc.LoadHtml(Content)

        'For Each h1Node In doc.DocumentNode.SelectNodes("//h1")
        '    H1Content.Add(h1Node.InnerText.Trim())
        'Next

        'For Each h2Node In doc.DocumentNode.SelectNodes("//h2")
        '    H2Content.Add(h2Node.InnerText.Trim())
        'Next

        'For Each h3Node In doc.DocumentNode.SelectNodes("//h3")
        '    H3Content.Add(h3Node.InnerText.Trim())
        'Next

        'For Each h4Node In doc.DocumentNode.SelectNodes("//h4")
        '    H4Content.Add(h4Node.InnerText.Trim())
        'Next
    End Sub
End Class

Public Class HtmlAgilityPackWithSocket
    Public Function GetHtmlContent(url As String) As String
        Dim host As String = GetHostFromUrl(url)
        Dim ipAddress As String = GetIpAddress(host)

        If Not String.IsNullOrEmpty(ipAddress) Then
            Dim htmlRequest As String = $"GET / HTTP/1.1{vbCrLf}Host: {host}{vbCrLf}Connection: close{vbCrLf}{vbCrLf}"
            Dim htmlResponse As String = SendHttpRequest(ipAddress, 80, htmlRequest)

            ' Puedes parsear el htmlResponse con HtmlAgilityPack aquí
            Return htmlResponse
        Else
            Return String.Empty
        End If
    End Function

    Private Function GetHostFromUrl(url As String) As String
        Dim uri As New Uri(url)
        Return uri.Host
    End Function

    Private Function GetIpAddress(host As String) As String
        Try
            Dim ipHostEntry As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(host)
            Dim ipAddress As System.Net.IPAddress = ipHostEntry.AddressList(0)
            Return ipAddress.ToString()
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Private Function SendHttpRequest(ipAddress As String, port As Integer, request As String) As String
        Try
            Using socket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim endPoint As New System.Net.IPEndPoint(System.Net.IPAddress.Parse(ipAddress), port)
                socket.Connect(endPoint)

                Dim data As Byte() = Encoding.UTF8.GetBytes(request)
                socket.Send(data, data.Length, SocketFlags.None)

                Dim receiveBuffer As Byte() = New Byte(8191) {}
                Dim receivedBytes As Integer = socket.Receive(receiveBuffer, receiveBuffer.Length, SocketFlags.None)
                Dim response As String = Encoding.UTF8.GetString(receiveBuffer, 0, receivedBytes)

                Return response
            End Using
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
End Class