Imports System.Xml

Public Class Class_Ciudades
    '<?xml version="1.0" encoding="iso-8859-15"?>
    '<body>
    '    <tabla_Datos>
    '    <C_Ciudad>
    '      <C_Id>0</C_Id>
    '      <C_PaisId></C_PaisId>
    '      <C_Pais></C_Pais>
    '      <C_NombreCiudad></C_NombreCiudad>
    '      <C_Latitud></C_Latitud>
    '      <C_Longitud></C_Longitud>
    '      <C_Altitud></C_Altitud>
    '      <C_Activo>False</C_Activo>
    '    </C_Ciudad>
    '  </tabla_Datos>
    '</body>

    Shared Archivo As String = "\Ciudades.xml"
    Event Modificacion()

#Region "Leer"

    Friend Shared Function ObtenerTodos() As List(Of Archivo_Ciudades)

        Dim Registros As New List(Of Archivo_Ciudades)
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

        Dim Cerebros_Compara As XmlNode = Nudo.SelectSingleNode("tabla_Datos")
        Try
            For Indice As ULong = 0 To Cerebros_Compara.ChildNodes.Count - 1
                Dim Rejistro1 As XmlNode = Cerebros_Compara.SelectNodes("C_Ciudad").ItemOf(Indice)
                Dim Rejistro As New Archivo_Ciudades
                Rejistro.Id = Rejistro1.SelectSingleNode("C_Id").InnerText.ToString.Trim
                Rejistro.PaisId = Rejistro1.SelectSingleNode("C_PaisId").InnerText.ToString()
                Rejistro.Pais = Rejistro1.SelectSingleNode("C_Pais").InnerText.ToString()
                Rejistro.NombreCiudad = Rejistro1.SelectSingleNode("C_NombreCiudad").InnerText.ToString()
                Rejistro.Latitud = Rejistro1.SelectSingleNode("C_Latitud").InnerText.ToString()
                Rejistro.Longitud = Rejistro1.SelectSingleNode("C_Longitud").InnerText.ToString()
                Rejistro.Altitud = Rejistro1.SelectSingleNode("C_Altitud").InnerText.ToString()
                Rejistro.Activo = Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString()


                Registros.Add(Rejistro)


            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Registros
    End Function

    Friend Shared Function ExisteId(ByVal Id As String) As Boolean
        Dim Resultado As Boolean = False
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

        Dim Cerebros_Compara As XmlNode = Nudo.SelectSingleNode("tabla_Datos")
        Try
            For Each Rejistro1 As XmlNode In Cerebros_Compara.ChildNodes
                Dim ID_Compara As String = Rejistro1.SelectSingleNode("C_Id").InnerText.ToString.Trim
                If Id.ToString = ID_Compara Then
                    Resultado = True

                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Resultado
    End Function

    Friend Shared Function ExisteNombre(ByVal Id As String) As Boolean
        Dim Resultado As Boolean = False
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

        Dim Cerebros_Compara As XmlNode = Nudo.SelectSingleNode("tabla_Datos")
        Try
            For Each Rejistro1 As XmlNode In Cerebros_Compara.ChildNodes
                Dim ID_Compara As String = Rejistro1.SelectSingleNode("C_NombreCiudad").InnerText.ToString.Trim
                If Id.ToString = ID_Compara Then
                    Resultado = True

                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Resultado
    End Function

    Friend Shared Function ObtenerWhereId(ByVal Id As String) As Archivo_Ciudades
        Dim Rejistro As New Archivo_Ciudades
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

        Dim Cerebros_Compara As XmlNode = Nudo.SelectSingleNode("tabla_Datos")
        Try
            For Each Rejistro1 As XmlNode In Cerebros_Compara.ChildNodes
                Dim ID_Compara As String = Rejistro1.SelectSingleNode("C_Id").InnerText.ToString.Trim
                If Id.ToString = ID_Compara Then

                    Rejistro.Id = Rejistro1.SelectSingleNode("C_Id").InnerText.ToString.Trim
                    Rejistro.PaisId = Rejistro1.SelectSingleNode("C_PaisId").InnerText.ToString()
                    Rejistro.Pais = Rejistro1.SelectSingleNode("C_Pais").InnerText.ToString()
                    Rejistro.NombreCiudad = Rejistro1.SelectSingleNode("C_NombreCiudad").InnerText.ToString()
                    Rejistro.Latitud = Rejistro1.SelectSingleNode("C_Latitud").InnerText.ToString()
                    Rejistro.Longitud = Rejistro1.SelectSingleNode("C_Longitud").InnerText.ToString()
                    Rejistro.Altitud = Rejistro1.SelectSingleNode("C_Altitud").InnerText.ToString()
                    Rejistro.Activo = Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString()

                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Rejistro
    End Function
    Friend Shared Function ObtenerWhereNombre(ByVal Nombre As String) As Archivo_Ciudades
        Dim Rejistro As New Archivo_Ciudades
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

        Dim Cerebros_Compara As XmlNode = Nudo.SelectSingleNode("tabla_Datos")
        Try
            For Each Rejistro1 As XmlNode In Cerebros_Compara.ChildNodes
                Dim Valor_Compara As String = Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString.Trim
                If Nombre.ToString = Valor_Compara Then


                    Rejistro.Id = Rejistro1.SelectSingleNode("C_Id").InnerText.ToString.Trim
                    Rejistro.PaisId = Rejistro1.SelectSingleNode("C_PaisId").InnerText.ToString()
                    Rejistro.Pais = Rejistro1.SelectSingleNode("C_Pais").InnerText.ToString()
                    Rejistro.NombreCiudad = Rejistro1.SelectSingleNode("C_NombreCiudad").InnerText.ToString()
                    Rejistro.Latitud = Rejistro1.SelectSingleNode("C_Latitud").InnerText.ToString()
                    Rejistro.Longitud = Rejistro1.SelectSingleNode("C_Longitud").InnerText.ToString()
                    Rejistro.Altitud = Rejistro1.SelectSingleNode("C_Altitud").InnerText.ToString()
                    Rejistro.Activo = Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString()

                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Rejistro
    End Function

#End Region

    Friend Shared Function InsertarRejistro(ByVal Archivo_Envio As Archivo_Ciudades)
        Dim DatosAgregados As Boolean = False

        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Body As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

        Dim NudoTabla As XmlNode = Body.SelectSingleNode("tabla_Datos")
        Try

            Dim NudoNuevo As XmlNode = xmlDoc.CreateElement("C_Ciudad")
            NudoNuevo.AppendChild(xmlDoc.CreateTextNode(""))
            '________---------

            Dim NuevoNudoC_Id As XmlNode = xmlDoc.CreateElement("C_Id")
            NuevoNudoC_Id.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Id.ToString))
            NudoNuevo.AppendChild(NuevoNudoC_Id)
            '------------------
            Dim NuevoNudoC_PaisId As XmlNode = xmlDoc.CreateElement("C_PaisId")
            NuevoNudoC_PaisId.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.PaisId))
            NudoNuevo.AppendChild(NuevoNudoC_PaisId)
            '------------------
            Dim NuevoNudoC_Pais As XmlNode = xmlDoc.CreateElement("C_Pais")
            NuevoNudoC_Pais.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Pais))
            NudoNuevo.AppendChild(NuevoNudoC_Pais)
            '------------------
            Dim NuevoNudoC_NombreCiudad As XmlNode = xmlDoc.CreateElement("C_NombreCiudad")
            NuevoNudoC_NombreCiudad.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.NombreCiudad))
            NudoNuevo.AppendChild(NuevoNudoC_NombreCiudad)
            '------------------
            Dim NuevoNudoC_Latitud As XmlNode = xmlDoc.CreateElement("C_Latitud")
            NuevoNudoC_Latitud.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Latitud))
            NudoNuevo.AppendChild(NuevoNudoC_Latitud)
            '------------------
            Dim NuevoNudoC_Longitud As XmlNode = xmlDoc.CreateElement("C_Longitud")
            NuevoNudoC_Longitud.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Longitud))
            NudoNuevo.AppendChild(NuevoNudoC_Longitud)
            '------------------
            Dim NuevoNudoC_Altitud As XmlNode = xmlDoc.CreateElement("C_Altitud")
            NuevoNudoC_Altitud.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Altitud))
            NudoNuevo.AppendChild(NuevoNudoC_Altitud)
            '------------------
            Dim NuevoNudoC_Activo As XmlNode = xmlDoc.CreateElement("C_Activo")
            NuevoNudoC_Activo.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Activo))
            NudoNuevo.AppendChild(NuevoNudoC_Activo)
            '------------------

            '------------------
            NudoTabla.AppendChild(NudoNuevo)

            xmlDoc.Save(RutaXMLConfigPrintInt)
            DatosAgregados = True
            '   Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            'ObtenerTodos()
            My.Application.DoEvents()
            Module_Central.CopasSeguridad(Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo)

        Catch ex As Exception
            MsgBox("" & vbCr & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try

        Return DatosAgregados
    End Function

    Friend Shared Function ModificarRejistro(ByVal Valor_Id As String, ByVal Columnas As Archivo_Ciudades) As Boolean
        Dim Guardado As Boolean = False
        Try
            'Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & "\Contenido\ConfigPrintInt.xml"
            Dim xmlDoc As New XmlDocument
            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
            xmlDoc.Load(RutaXMLConfigPrintInt)

            Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

            ' Dim CuerpoXL_1a As XmlNodeList = CuerpoXL_1.SelectSingleNode(Tabla).ChildNodes

            For Each Rejistros As XmlNode In CuerpoXL_1

                Dim Comparador As String = Rejistros.SelectSingleNode("C_Id").InnerText

                If Comparador = Valor_Id Then
                    Rejistros.SelectSingleNode("C_Id").InnerText = Columnas.Id
                    Rejistros.SelectSingleNode("C_PaisId").InnerText = Columnas.PaisId
                    Rejistros.SelectSingleNode("C_Pais").InnerText = Columnas.Pais
                    Rejistros.SelectSingleNode("C_NombreCiudad").InnerText = Columnas.NombreCiudad
                    Rejistros.SelectSingleNode("C_Latitud").InnerText = Columnas.Latitud
                    Rejistros.SelectSingleNode("C_Longitud").InnerText = Columnas.Longitud
                    Rejistros.SelectSingleNode("C_Altitud").InnerText = Columnas.Altitud
                    Rejistros.SelectSingleNode("C_Activo").InnerText = Columnas.Activo

                    xmlDoc.Save(RutaXMLConfigPrintInt)
                    Guardado = True
                End If

            Next


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            'ObtenerTodos()
            My.Application.DoEvents()
            Module_Central.CopasSeguridad(Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo)

        Catch ex As Exception
            MsgBox("" & vbCr & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
        Return Guardado
    End Function

    Friend Shared Function EliminarRejistro0(ByVal ByVal_Id As String) As Boolean
        Dim Guardado As Boolean = False
        Try
            Dim xmlDoc As New XmlDocument
            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
            xmlDoc.Load(RutaXMLConfigPrintInt)

            Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
            Dim Cuerpo_Cliente As XmlNode = CuerpoXL_1.SelectSingleNode("tabla_Datos")

            For Each Rejistros As XmlNode In CuerpoXL_1
                Dim Comparador As String = Rejistros.SelectSingleNode("C_Id").InnerText
                If Comparador = ByVal_Id Then
                    CuerpoXL_1.RemoveChild(Rejistros)
                    xmlDoc.Save(RutaXMLConfigPrintInt)
                    Guardado = True
                End If
            Next


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            'ObtenerTodos()
            My.Application.DoEvents()
            Module_Central.CopasSeguridad(Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo)

        Catch ex As Exception
            MsgBox("" & vbCr & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
        Return Guardado
    End Function


    Friend Structure Archivo_Ciudades
        Dim Id As String
        Dim PaisId As String
        Dim Pais As String
        Dim NombreCiudad As String
        Dim Latitud As String
        Dim Longitud As String
        Dim Altitud As String
        Dim Activo As Boolean
    End Structure

End Class
