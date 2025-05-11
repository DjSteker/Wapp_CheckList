
Imports System.Xml

Public Class Class_XmlNarra
    Shared Archivo As String = "\Datos\BaseDatos\DB_Narra.xml"
    Event Modificacion()


    Friend Shared Function ObtenerDatosClient() As Archivo_Clientes
        Dim Enviado As New Archivo_Clientes
        Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & Archivo


        If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Datos\BaseDatos") = False Then
            My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Datos\BaseDatos")
        End If

        If My.Computer.FileSystem.FileExists(RutaXMLConfigPrintInt) = False Then
            Dim Texto As String = "<?xml version=""1.0"" encoding=""utf-8"" ?>" &
        "<tabla1>" &
              " <RejTrC>" & vbCr &
              "     <NarraConexion>0</NarraConexion>" & vbCr &
              "     <NarraMensaje>0</NarraMensaje>" &
              "     <Volumen>75</Volumen>" & vbCr &
              "     <Velocidad>0</Velocidad>" & vbCr &
              "     <Voz></Voz>" & vbCr &
              "     <Salidas></Salidas>" & vbCr &
              " </RejTrC>" &
        "</tabla1>"
            My.Computer.FileSystem.WriteAllText(RutaXMLConfigPrintInt, Texto, False)
        End If


        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("tabla1").Item(0)
        Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("RejTrC").Item(0)
        Try
            Enviado.NarraConexion = NudoTabla.SelectSingleNode("NarraConexion").InnerText
            Enviado.NarraMensaje = NudoTabla.SelectSingleNode("NarraMensaje").InnerText
            Enviado.Volumen = NudoTabla.SelectSingleNode("Volumen").InnerText
            Enviado.Velocidad = NudoTabla.SelectSingleNode("Velocidad").InnerText
            Enviado.Voz = NudoTabla.SelectSingleNode("Voz").InnerText
            Enviado.Salidas = NudoTabla.SelectSingleNode("Salidas").InnerText
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Enviado
    End Function

    Friend Shared Function ModificarDatosClient(ByVal Clolumnas As Archivo_Clientes) As Boolean
        Dim Guardado As Boolean = False
        Try
            'Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & "\Contenido\ConfigPrintInt.xml"
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(My.Application.Info.DirectoryPath & Archivo)

            Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("tabla1").Item(0)
            Dim Rej_1 As XmlNode = CuerpoXL_1.SelectSingleNode("RejTrC") '.Item(0)
            Rej_1.SelectSingleNode("NarraConexion").InnerText = Clolumnas.NarraConexion
            Rej_1.SelectSingleNode("NarraMensaje").InnerText = Clolumnas.NarraMensaje
            Rej_1.SelectSingleNode("Volumen").InnerText = Clolumnas.Volumen
            Rej_1.SelectSingleNode("Velocidad").InnerText = Clolumnas.Velocidad
            Rej_1.SelectSingleNode("Voz").InnerText = Clolumnas.Voz
            Rej_1.SelectSingleNode("Salidas").InnerText = Clolumnas.Salidas

            xmlDoc.Save(My.Application.Info.DirectoryPath & Archivo)

            Guardado = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Guardado
    End Function



    Friend Structure Archivo_Clientes
        Dim NarraConexion As String
        Dim NarraMensaje As String
        Dim Volumen As String
        Dim Velocidad As String
        Dim Voz As String
        Dim Salidas As String
    End Structure

End Class

