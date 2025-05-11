Imports System.Xml

Namespace BaseDatos

    Public Class Class_XmlServidores
    Shared Archivo As String = "\BaseDatos\DB_Servidores.xml"
    Event Modificacion()

    '<?xml version="1.0" encoding="utf-32" ?>
    '<tabla1>
    '  <RejTr>
    '    <IpLocalTCP></IpLocalTCP>
    '    <IpDestinoTCP></IpDestinoTCP>
    '    <PuertoTCP>27033</PuertoTCP>
    '    <IpDestinoUDP></IpDestinoUDP>
    '    <PuertoUDPAudio>27033</PuertoUDPAudio>
    '    <PuertoUDPVideo></PuertoUDPVideo>
    '    <ConexionesMaximas>256</ConexionesMaximas>
    '    <Nick></Nick>
    '    <IdConexion></IdConexion>
    '  </RejTr>
    '</tabla1>
    Friend Shared Sub ObtenerArchivo()
        Try
            Dim Enviado As New Archivo_Servidores
            Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & Archivo


            If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Datos\BaseDatos") = False Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Datos\BaseDatos")
            End If

            If My.Computer.FileSystem.FileExists(RutaXMLConfigPrintInt) = False Then

                Dim Texto As String = "<?xml version=""1.0"" encoding=""utf-32"" ?>" & vbCr & "<tabla1></tabla1>"
                My.Computer.FileSystem.WriteAllText(RutaXMLConfigPrintInt, Texto, False)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Friend Shared Function ObtenerAll() As List(Of Archivo_Servidores)
        Dim EnviadoLista As New List(Of Archivo_Servidores)
        Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & Archivo
        ObtenerArchivo()
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("tabla1").Item(0)
        ' Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("RejTr").Item(0)
        For Each NudoTabla As XmlNode In Nudo.SelectNodes("RejTr") 'xmlDoc.GetElementsByTagName("RejTr")
            Dim Elemento As New Archivo_Servidores
            Try

                '<IpLocalTCP></IpLocalTCP>
                '<IpDestinoTCP></IpDestinoTCP>
                '<PuertoTCP>27033</PuertoTCP>
                '<IpDestinoUDP></IpDestinoUDP>
                '<PuertoUDPAudio>27033</PuertoUDPAudio>
                '<PuertoUDPVideo></PuertoUDPVideo>
                '<ConexionesMaximas>256</ConexionesMaximas>
                '<Nick></Nick>
                '<IdConexion></IdConexion>

                Elemento.IpLocalTCP = NudoTabla.SelectSingleNode("IpLocalTCP").InnerText
                Elemento.IpDestinoTCP = NudoTabla.SelectSingleNode("IpDestinoTCP").InnerText
                Elemento.PuertoTCP = NudoTabla.SelectSingleNode("PuertoTCP").InnerText
                Elemento.IpDestinoUDP = NudoTabla.SelectSingleNode("IpDestinoUDP").InnerText
                Elemento.PuertoUDPAudio = NudoTabla.SelectSingleNode("PuertoUDPAudio").InnerText
                Elemento.PuertoUDPVideo = NudoTabla.SelectSingleNode("PuertoUDPVideo").InnerText
                Elemento.NombreServer = NudoTabla.SelectSingleNode("NombreServer").InnerText
                Elemento.Nick = NudoTabla.SelectSingleNode("Nick").InnerText
                Elemento.IdConexion = NudoTabla.SelectSingleNode("IdConexion").InnerText
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            EnviadoLista.Add(Elemento)
        Next

        Return EnviadoLista
    End Function


    'Friend Shared Function InsertarRejistro(ByVal Archivo_Envio As Archivo_Clientes)
    '    Dim Datos1 As New List(Of Archivo_Clientes)

    '    Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & Archivo
    '    Dim xmlDoc As New XmlDocument
    '    xmlDoc.Load(RutaXMLConfigPrintInt)
    '    Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
    '    Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("tabla1").Item(0)

    '    Try


    '        Dim NuevoNudo As XmlNode = xmlDoc.CreateElement("Rejistro")
    '        NuevoNudo.AppendChild(xmlDoc.CreateTextNode(""))

    '        ' <Id></Id>
    '        '<C_Nombre></C_Nombre>
    '        '<C_Destino></C_Destino>
    '        '<C_PuntoDescarga></C_PuntoDescarga>

    '        Dim NuevoNudoC_Id As XmlNode = xmlDoc.CreateElement("C_Id")
    '        NuevoNudoC_Id.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Id.ToString))
    '        NuevoNudo.AppendChild(NuevoNudoC_Id)
    '        '------------------
    '        Dim NuevoNudoC_Nombre As XmlNode = xmlDoc.CreateElement("C_Nombre")
    '        NuevoNudoC_Nombre.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Nombre))
    '        NuevoNudo.AppendChild(NuevoNudoC_Nombre)
    '        '------------------
    '        Dim NuevoNudoC_Destino As XmlNode = xmlDoc.CreateElement("C_Destino")
    '        NuevoNudoC_Destino.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Destino))
    '        NuevoNudo.AppendChild(NuevoNudoC_Destino)
    '        '------------------
    '        Dim NuevoNudoC_PuntoDescarga As XmlNode = xmlDoc.CreateElement("C_PuntoDescarga")
    '        NuevoNudoC_PuntoDescarga.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.PuntoDescarga))
    '        NuevoNudo.AppendChild(NuevoNudoC_PuntoDescarga)

    '        NudoTabla.AppendChild(NuevoNudo)

    '        xmlDoc.Save(My.Application.Info.DirectoryPath & Archivo)
    '        '   Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try


    '    Return Datos1
    'End Function

    Friend Shared Function Agregar(ByVal Columnas As Archivo_Servidores) As Boolean
        Dim Guardado As Boolean = False
        Try
            'Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & "\Contenido\ConfigPrintInt.xml"
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(My.Application.Info.DirectoryPath & Archivo)
            Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("tabla1").Item(0)
            ' Dim Rej_1 As XmlNode = CuerpoXL_1.SelectSingleNode("RejTr") '.Item(0)
            Dim NuevoNudo As XmlNode = xmlDoc.CreateElement("RejTr")
            CuerpoXL_1.AppendChild(xmlDoc.CreateTextNode(""))

            Dim NuevoNudoC_IpLocalTCP As XmlNode = xmlDoc.CreateElement("IpLocalTCP")
            NuevoNudoC_IpLocalTCP.AppendChild(xmlDoc.CreateTextNode(Columnas.IpLocalTCP.ToString))
            NuevoNudo.AppendChild(NuevoNudoC_IpLocalTCP)
            Dim NuevoNudoC_IpDestinoTCP As XmlNode = xmlDoc.CreateElement("IpDestinoTCP")
            NuevoNudoC_IpDestinoTCP.AppendChild(xmlDoc.CreateTextNode(Columnas.IpDestinoTCP.ToString))
            NuevoNudo.AppendChild(NuevoNudoC_IpDestinoTCP)
            Dim NuevoNudoC_PuertoTCP As XmlNode = xmlDoc.CreateElement("PuertoTCP")
            NuevoNudoC_PuertoTCP.AppendChild(xmlDoc.CreateTextNode(Columnas.PuertoTCP.ToString))
            NuevoNudo.AppendChild(NuevoNudoC_PuertoTCP)
            Dim NuevoNudoC_IpDestinoUDP As XmlNode = xmlDoc.CreateElement("IpDestinoUDP")
            NuevoNudoC_IpDestinoUDP.AppendChild(xmlDoc.CreateTextNode(Columnas.IpDestinoUDP.ToString))
            NuevoNudo.AppendChild(NuevoNudoC_IpDestinoUDP)
            Dim NuevoNudoC_PuertoUDPAudio As XmlNode = xmlDoc.CreateElement("PuertoUDPAudio")
            NuevoNudoC_PuertoUDPAudio.AppendChild(xmlDoc.CreateTextNode(Columnas.PuertoUDPAudio.ToString))
            NuevoNudo.AppendChild(NuevoNudoC_PuertoUDPAudio)
            Dim NuevoNudoC_PuertoUDPVideo As XmlNode = xmlDoc.CreateElement("PuertoUDPVideo")
            NuevoNudoC_PuertoUDPVideo.AppendChild(xmlDoc.CreateTextNode(Columnas.PuertoUDPVideo.ToString))
            NuevoNudo.AppendChild(NuevoNudoC_PuertoUDPVideo)
            Dim NuevoNudoC_Nick As XmlNode = xmlDoc.CreateElement("Nick")
            NuevoNudoC_Nick.AppendChild(xmlDoc.CreateTextNode(Columnas.Nick.ToString))
            NuevoNudo.AppendChild(NuevoNudoC_Nick)
            Dim NuevoNudoC_NombreServer As XmlNode = xmlDoc.CreateElement("NombreServer")
            NuevoNudoC_NombreServer.AppendChild(xmlDoc.CreateTextNode(Columnas.NombreServer.ToString))
            NuevoNudo.AppendChild(NuevoNudoC_NombreServer)
            Dim NuevoNudoC_IdConexion As XmlNode = xmlDoc.CreateElement("IdConexion")
            NuevoNudoC_IdConexion.AppendChild(xmlDoc.CreateTextNode(Columnas.IdConexion.ToString))
            NuevoNudo.AppendChild(NuevoNudoC_IdConexion)

            CuerpoXL_1.AppendChild(NuevoNudo)

            xmlDoc.Save(My.Application.Info.DirectoryPath & Archivo)
            Guardado = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Guardado
    End Function


    Friend Shared Function Modificar(ByVal Columnas As Archivo_Servidores) As Boolean
        Dim Guardado As Boolean = False
        Try
            'Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & "\Contenido\ConfigPrintInt.xml"
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(My.Application.Info.DirectoryPath & Archivo)
            Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("tabla1").Item(0)
            ' Dim Rej_1 As XmlNode = CuerpoXL_1.SelectSingleNode("RejTr") '.Item(0)
            For Each NudoTabla As XmlNode In xmlDoc.GetElementsByTagName("RejTr")
                If Columnas.IdConexion = NudoTabla.SelectSingleNode("IdConexion").InnerText Then
                    NudoTabla.SelectSingleNode("IpLocalTCP").InnerText = Columnas.IpLocalTCP
                    NudoTabla.SelectSingleNode("IpDestinoTCP").InnerText = Columnas.IpDestinoTCP
                    NudoTabla.SelectSingleNode("PuertoTCP").InnerText = Columnas.PuertoTCP
                    NudoTabla.SelectSingleNode("IpDestinoUDP").InnerText = Columnas.IpDestinoUDP
                    NudoTabla.SelectSingleNode("PuertoUDPAudio").InnerText = Columnas.PuertoUDPAudio
                    NudoTabla.SelectSingleNode("PuertoUDPVideo").InnerText = Columnas.PuertoUDPVideo
                    NudoTabla.SelectSingleNode("NombreServer").InnerText = Columnas.NombreServer
                    NudoTabla.SelectSingleNode("Nick").InnerText = Columnas.Nick
                    NudoTabla.SelectSingleNode("IdConexion").InnerText = Columnas.IdConexion
                    xmlDoc.Save(My.Application.Info.DirectoryPath & Archivo)
                    Guardado = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Guardado
    End Function

    Friend Shared Function Eliminar(ByVal Columnas As Archivo_Servidores) As Boolean
        Dim Guardado As Boolean = False
        Try
            'Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & "\Contenido\ConfigPrintInt.xml"
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(My.Application.Info.DirectoryPath & Archivo)
            Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("tabla1").Item(0)
            ' Dim Rej_1 As XmlNode = CuerpoXL_1.SelectSingleNode("RejTr") '.Item(0)
            For Each NudoTabla As XmlNode In xmlDoc.GetElementsByTagName("RejTr")
                If Columnas.IdConexion = NudoTabla.SelectSingleNode("IdConexion").InnerText Then
                    CuerpoXL_1.RemoveChild(NudoTabla)
                    xmlDoc.Save(My.Application.Info.DirectoryPath & Archivo)
                    Guardado = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Guardado
    End Function




    '    <IpLocalTCP></IpLocalTCP>
    '    <IpDestinoTCP></IpDestinoTCP>
    '    <PuertoTCP>27033</PuertoTCP>
    '    <IpDestinoUDP></IpDestinoUDP>
    '    <PuertoUDP>27033</PuertoUDP>
    '    <ConexionesMaximas>256</ConexionesMaximas>
    '    <Nick></Nick>
    '    <IdConexion></IdConexion>

    Friend Structure Archivo_Servidores
        Dim IpLocalTCP As String
        Dim IpDestinoTCP As String
        Dim PuertoTCP As String
        Dim BufferTCP As String
        Dim IpDestinoUDP As String
        Dim PuertoUDPAudio As String
        Dim PuertoUDPVideo As String
        Dim Nick As String
        Dim NombreServer As String
        Dim IdConexion As String
    End Structure
End Class


End Namespace