

Imports System.Xml

Public Class Class_Paises



    Shared Archivo As String = "\Paises.xml"
    Event Modificacion()


#Region "Leer"

    Friend Shared Function ObtenerTodos() As List(Of Archivo_Paises)

        Dim Registros As New List(Of Archivo_Paises)
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

        Dim Cerebros_Compara As XmlNode = Nudo.SelectSingleNode("tabla_Datos")
        Try
            For Indice As ULong = 0 To Cerebros_Compara.ChildNodes.Count - 1
                Dim Rejistro1 As XmlNode = Cerebros_Compara.SelectNodes("C_Pais").ItemOf(Indice)
                Dim Rejistro As New Archivo_Paises
                Rejistro.Id = Rejistro1.SelectSingleNode("C_Id").InnerText.ToString.Trim

                Rejistro.Nombre = Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString()
                Rejistro.Capital = Rejistro1.SelectSingleNode("C_Capital").InnerText.ToString()
                Rejistro.Extension = Rejistro1.SelectSingleNode("C_Extension").InnerText.ToString()
                Rejistro.Poblacion = Rejistro1.SelectSingleNode("C_Poblacion").InnerText.ToString()
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
                Dim ID_Compara As String = Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString.Trim
                If Id.ToString = ID_Compara Then
                    Resultado = True

                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Resultado
    End Function

    Friend Shared Function ObtenerWhereId(ByVal Id As String) As Archivo_Paises
        Dim Rejistro As New Archivo_Paises
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
                    Rejistro.Nombre = Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString()
                    Rejistro.Capital = Rejistro1.SelectSingleNode("C_Capital").InnerText.ToString()
                    Rejistro.Extension = Rejistro1.SelectSingleNode("C_Extension").InnerText.ToString()
                    Rejistro.Poblacion = Rejistro1.SelectSingleNode("C_Poblacion").InnerText.ToString()
                    Rejistro.Activo = Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString()


                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Rejistro
    End Function

    Friend Shared Function ObtenerWhereNombre(ByVal Nombre As String) As Archivo_Paises
        Dim Rejistro As New Archivo_Paises
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
                    Rejistro.Nombre = Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString()
                    Rejistro.Capital = Rejistro1.SelectSingleNode("C_Capital").InnerText.ToString()
                    Rejistro.Extension = Rejistro1.SelectSingleNode("C_Extension").InnerText.ToString()
                    Rejistro.Poblacion = Rejistro1.SelectSingleNode("C_Poblacion").InnerText.ToString()
                    Rejistro.Activo = Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString()


                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Rejistro
    End Function

#End Region



    Friend Shared Function InsertarRejistro(ByVal Archivo_Envio As Archivo_Paises)
        Dim DatosAgregados As Boolean = False

        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Body As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

        Dim NudoTabla As XmlNode = Body.SelectSingleNode("tabla_Datos")
        Try

            Dim NudoCerebro As XmlNode = xmlDoc.CreateElement("C_Pais")
            NudoCerebro.AppendChild(xmlDoc.CreateTextNode(""))
            '________---------

            Dim NuevoNudoC_Id As XmlNode = xmlDoc.CreateElement("C_Id")
            NuevoNudoC_Id.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Id.ToString))
            NudoCerebro.AppendChild(NuevoNudoC_Id)
            '------------------
            Dim NuevoNudoC_Nombre As XmlNode = xmlDoc.CreateElement("C_Nombre")
            NuevoNudoC_Nombre.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Nombre))
            NudoCerebro.AppendChild(NuevoNudoC_Nombre)
            '------------------
            Dim NuevoNudoC_Capital As XmlNode = xmlDoc.CreateElement("C_Capital")
            NuevoNudoC_Capital.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Capital))
            NudoCerebro.AppendChild(NuevoNudoC_Capital)
            '------------------
            Dim NuevoNudoC_Extension As XmlNode = xmlDoc.CreateElement("C_Extension")
            NuevoNudoC_Extension.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Extension))
            NudoCerebro.AppendChild(NuevoNudoC_Extension)
            '------------------
            Dim NuevoNudoC_Poblacion As XmlNode = xmlDoc.CreateElement("C_Poblacion")
            NuevoNudoC_Poblacion.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Poblacion))
            NudoCerebro.AppendChild(NuevoNudoC_Poblacion)
            '------------------
            Dim NuevoNudoC_Activo As XmlNode = xmlDoc.CreateElement("C_Activo")
            NuevoNudoC_Activo.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Activo))
            NudoCerebro.AppendChild(NuevoNudoC_Activo)
            '------------------


            '------------------
            NudoTabla.AppendChild(NudoCerebro)

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

    Friend Shared Function ModificarRejistro(ByVal Valor_Id As String, ByVal Columnas As Archivo_Paises) As Boolean
        Dim Guardado As Boolean = False
        Try
            'Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & "\Contenido\ConfigPrintInt.xml"
            Dim xmlDoc As New XmlDocument
            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
            xmlDoc.Load(RutaXMLConfigPrintInt)

            Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

            ' Dim CuerpoXL_1a As XmlNodeList = CuerpoXL_1.SelectSingleNode(Tabla).ChildNodes
            'Dim Tabla As XmlNode = CuerpoXL_1.SelectSingleNode("tabla_Datos")
            For Each Rejistros As XmlNode In CuerpoXL_1.SelectSingleNode("tabla_Datos")

                Dim Comparador As String = Rejistros.SelectSingleNode("C_Id").InnerText

                If Comparador = Valor_Id Then
                    Rejistros.SelectSingleNode("C_Id").InnerText = Columnas.Id
                    Rejistros.SelectSingleNode("C_Nombre").InnerText = Columnas.Nombre
                    Rejistros.SelectSingleNode("C_Capital").InnerText = Columnas.Capital
                    Rejistros.SelectSingleNode("C_Extension").InnerText = Columnas.Extension
                    Rejistros.SelectSingleNode("C_Poblacion").InnerText = Columnas.Poblacion
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

    Friend Shared Function Update_TemperaturaBullicion(ByVal Valor_Id As String, ByVal Val_TemperaturaBullicion As String) As Boolean
        Dim Guardado As Boolean = False
        Try

            Dim xmlDoc As New XmlDocument
            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
            xmlDoc.Load(RutaXMLConfigPrintInt)

            Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)


            For Each Rejistros As XmlNode In CuerpoXL_1

                Dim Comparador As String = Rejistros.SelectSingleNode("C_Id").InnerText

                If Comparador = Valor_Id Then

                    Rejistros.SelectSingleNode("C_TemperaturaBullicion").InnerText = Val_TemperaturaBullicion

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

    Friend Structure Archivo_Paises
        Dim Id As String
        Dim Nombre As String
        Dim Capital As String
        Dim Extension As String
        Dim Poblacion As String
        Dim Activo As Boolean
    End Structure

End Class

