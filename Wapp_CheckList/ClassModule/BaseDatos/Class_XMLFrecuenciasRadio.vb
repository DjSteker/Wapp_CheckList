
Imports System.Xml

Namespace BaseDatos

    Public Class Class_XMLFrecuenciasRadio

        Shared Archivo As String = "\FrecuenciasLibro.xml"
        Event Modificacion()

#Region "Leer"

        Friend Shared Function ObtenerTodos() As List(Of Archivo_Frecuencias)

            Dim Registros As New List(Of Archivo_Frecuencias)
            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(RutaXMLConfigPrintInt)
            Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

            'Dim Cerebros_Compara As XmlNode = Nudo.SelectSingleNode("C_registro")
            Try
                For Indice As ULong = 0 To Nudo.ChildNodes.Count - 1
                    Dim Rejistro1 As XmlNode = Nudo.ChildNodes(Indice)  'Cerebros_Compara.SelectNodes("C_registro").ItemOf(Indice)
                    Dim Rejistro As New Archivo_Frecuencias


                    Rejistro.Id = Rejistro1.SelectSingleNode("C_ID").InnerText.ToString.Trim
                    Rejistro.Nombre = Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString()
                    Rejistro.Frecuencia = Rejistro1.SelectSingleNode("C_Frecuencia").InnerText.ToString()
                    Rejistro.Modulacion = Rejistro1.SelectSingleNode("C_Modulacion").InnerText.ToString()

                    Rejistro.ModulaBand = Rejistro1.SelectSingleNode("C_ModulaBand").InnerText.ToString()
                    Rejistro.Ganancia = Rejistro1.SelectSingleNode("C_Ganancia").InnerText.ToString()

                    Rejistro.Señal = Rejistro1.SelectSingleNode("C_Señal").InnerText.ToString()
                    Rejistro.Squelch = Rejistro1.SelectSingleNode("C_Squelch").InnerText.ToString()
                    Rejistro.Tags = Rejistro1.SelectSingleNode("C_Tags").InnerText.ToString()
                    Rejistro.Latitud = Rejistro1.SelectSingleNode("C_Latitud").InnerText.ToString()
                    Rejistro.Longitud = Rejistro1.SelectSingleNode("C_Longitud").InnerText.ToString()
                    Rejistro.Altitud = Rejistro1.SelectSingleNode("C_Altitud").InnerText.ToString()
                    Rejistro.Nota = Rejistro1.SelectSingleNode("C_Nota").InnerText.ToString()
                    Rejistro.Cominicacion = Rejistro1.SelectSingleNode("C_Cominicacion").InnerText.ToString()
                    Rejistro.LnbLo = Rejistro1.SelectSingleNode("C_LnbLo").InnerText.ToString()
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
                    Dim ID_Compara As String = Rejistro1.SelectSingleNode("C_ID").InnerText.ToString.Trim
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
                    Dim ID_Compara As String = Rejistro1.SelectSingleNode("C_ID").InnerText.ToString.Trim
                    If Id.ToString = ID_Compara Then
                        Resultado = True

                    End If

                Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Resultado
        End Function

        Friend Shared Function ObtenerWhereId(ByVal Id As String) As Archivo_Frecuencias
            Dim Rejistro As New Archivo_Frecuencias
            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(RutaXMLConfigPrintInt)
            Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

            Dim Cerebros_Compara As XmlNode = Nudo.SelectSingleNode("tabla_Datos")
            Try
                For Each Rejistro1 As XmlNode In Nudo.ChildNodes
                    Dim ID_Compara As String = Rejistro1.SelectSingleNode("C_ID").InnerText.ToString.Trim
                    If Id.ToString = ID_Compara Then


                        Rejistro.Id = Rejistro1.SelectSingleNode("C_ID").InnerText.ToString.Trim
                        Rejistro.Nombre = Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString()
                        Rejistro.Frecuencia = Rejistro1.SelectSingleNode("C_Frecuencia").InnerText.ToString()
                        Rejistro.Modulacion = Rejistro1.SelectSingleNode("C_Modulacion").InnerText.ToString()

                        Rejistro.ModulaBand = Rejistro1.SelectSingleNode("C_ModulaBand").InnerText.ToString()
                        Rejistro.Ganancia = Rejistro1.SelectSingleNode("C_Ganancia").InnerText.ToString()

                        Rejistro.Señal = Rejistro1.SelectSingleNode("C_Señal").InnerText.ToString()
                        Rejistro.Squelch = Rejistro1.SelectSingleNode("C_Squelch").InnerText.ToString()
                        Rejistro.Tags = Rejistro1.SelectSingleNode("C_Tags").InnerText.ToString()
                        Rejistro.Latitud = Rejistro1.SelectSingleNode("C_Latitud").InnerText.ToString()
                        Rejistro.Longitud = Rejistro1.SelectSingleNode("C_Longitud").InnerText.ToString()
                        Rejistro.Altitud = Rejistro1.SelectSingleNode("C_Altitud").InnerText.ToString()
                        Rejistro.Nota = Rejistro1.SelectSingleNode("C_Nota").InnerText.ToString()
                        Rejistro.Cominicacion = Rejistro1.SelectSingleNode("C_Cominicacion").InnerText.ToString()
                        Rejistro.LnbLo = Rejistro1.SelectSingleNode("C_LnbLo").InnerText.ToString()
                    End If

                Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Rejistro
        End Function
        Friend Shared Function ObtenerWhereNombre(ByVal Nombre As String) As Archivo_Frecuencias
            '    <?xml version="1.0" encoding="iso-8859-15" ?>
            Dim Rejistro As New Archivo_Frecuencias
            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(RutaXMLConfigPrintInt)
            Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

            Dim Cerebros_Compara As XmlNode = Nudo.SelectSingleNode("tabla_Datos")
            Try
                For Each Rejistro1 As XmlNode In Cerebros_Compara.ChildNodes
                    Dim Valor_Compara As String = Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString.Trim
                    If Nombre.ToString = Valor_Compara Then


                        Rejistro.Id = Rejistro1.SelectSingleNode("C_ID").InnerText.ToString.Trim
                        Rejistro.Nombre = Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString()
                        Rejistro.Frecuencia = Rejistro1.SelectSingleNode("C_Frecuencia").InnerText.ToString()
                        Rejistro.Modulacion = Rejistro1.SelectSingleNode("C_Modulacion").InnerText.ToString()

                        Rejistro.ModulaBand = Rejistro1.SelectSingleNode("C_ModulaBand").InnerText.ToString()
                        Rejistro.Ganancia = Rejistro1.SelectSingleNode("C_Ganancia").InnerText.ToString()

                        Rejistro.Señal = Rejistro1.SelectSingleNode("C_Señal").InnerText.ToString()
                        Rejistro.Squelch = Rejistro1.SelectSingleNode("C_Squelch").InnerText.ToString()
                        Rejistro.Tags = Rejistro1.SelectSingleNode("C_Tags").InnerText.ToString()
                        Rejistro.Latitud = Rejistro1.SelectSingleNode("C_Latitud").InnerText.ToString()
                        Rejistro.Longitud = Rejistro1.SelectSingleNode("C_Longitud").InnerText.ToString()
                        Rejistro.Altitud = Rejistro1.SelectSingleNode("C_Altitud").InnerText.ToString()
                        Rejistro.Nota = Rejistro1.SelectSingleNode("C_Nota").InnerText.ToString()

                        Rejistro.Cominicacion = Rejistro1.SelectSingleNode("C_Cominicacion").InnerText.ToString()
                        Rejistro.LnbLo = Rejistro1.SelectSingleNode("C_LnbLo").InnerText.ToString()

                    End If

                Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Rejistro
        End Function

#End Region

        Friend Shared Function InsertarRejistro(ByVal Archivo_Envio As Archivo_Frecuencias)
            Dim DatosAgregados As Boolean = False

            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(RutaXMLConfigPrintInt)
            Dim Body As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

            Dim NudoTabla As XmlNode = Body.SelectSingleNode("tabla_Datos")
            Try

                Dim NudoNuevo As XmlNode = xmlDoc.CreateElement("C_registro")
                NudoNuevo.AppendChild(xmlDoc.CreateTextNode(""))
                '________---------

                Dim NuevoNudoC_Id As XmlNode = xmlDoc.CreateElement("C_ID")
                NuevoNudoC_Id.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Id.ToString))
                NudoNuevo.AppendChild(NuevoNudoC_Id)
                '------------------
                Dim NuevoNudoC_Nombre As XmlNode = xmlDoc.CreateElement("C_Nombre")
                NuevoNudoC_Nombre.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Nombre))
                NudoNuevo.AppendChild(NuevoNudoC_Nombre)
                '------------------
                Dim NuevoNudoC_Frecuencia As XmlNode = xmlDoc.CreateElement("C_Frecuencia")
                NuevoNudoC_Frecuencia.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Frecuencia))
                NudoNuevo.AppendChild(NuevoNudoC_Frecuencia)
                '------------------
                Dim NuevoNudoC_Modulaciond As XmlNode = xmlDoc.CreateElement("C_Modulacion")
                NuevoNudoC_Modulaciond.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Modulacion))
                NudoNuevo.AppendChild(NuevoNudoC_Modulaciond)
                '------------------




                '------------------
                Dim NuevoNudoC_ModulaBand As XmlNode = xmlDoc.CreateElement("C_ModulaBand")
                NuevoNudoC_ModulaBand.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.ModulaBand))
                NudoNuevo.AppendChild(NuevoNudoC_ModulaBand)
                '------------------
                Dim NuevoNudoC_Ganancia As XmlNode = xmlDoc.CreateElement("C_Ganancia")
                NuevoNudoC_Ganancia.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Ganancia))
                NudoNuevo.AppendChild(NuevoNudoC_Ganancia)
                '------------------






                Dim NuevoNudC_Señal As XmlNode = xmlDoc.CreateElement("C_Señal")
                NuevoNudC_Señal.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Señal))
                NudoNuevo.AppendChild(NuevoNudC_Señal)
                '------------------
                Dim NuevoNudoC_Squelch As XmlNode = xmlDoc.CreateElement("C_Squelch")
                NuevoNudoC_Squelch.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Squelch))
                NudoNuevo.AppendChild(NuevoNudoC_Squelch)

                '------------------
                Dim NuevoNudoC_Tags As XmlNode = xmlDoc.CreateElement("C_Tags")
                NuevoNudoC_Tags.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Tags))
                NudoNuevo.AppendChild(NuevoNudoC_Tags)
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
                Dim NuevoNudoC_Nota As XmlNode = xmlDoc.CreateElement("C_Nota")
                NuevoNudoC_Nota.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Nota))
                NudoNuevo.AppendChild(NuevoNudoC_Nota)
                '------------------
                Dim NuevoNudoC_Cominicacion As XmlNode = xmlDoc.CreateElement("C_Cominicacion")
                NuevoNudoC_Cominicacion.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Cominicacion))
                NudoNuevo.AppendChild(NuevoNudoC_Cominicacion)
                '------------------
                Dim NuevoNudoC_LnbLo As XmlNode = xmlDoc.CreateElement("C_LnbLo")
                NuevoNudoC_LnbLo.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.LnbLo))
                NudoNuevo.AppendChild(NuevoNudoC_LnbLo)


                '------------------
                Body.AppendChild(NudoNuevo)

                xmlDoc.Save(RutaXMLConfigPrintInt)
                DatosAgregados = True
                '   Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Try
                'ObtenerTodos()
                My.Application.DoEvents()
                'Module_Central.CopasSeguridad(Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo)

            Catch ex As Exception
                MsgBox("" & vbCr & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            End Try

            Return DatosAgregados
        End Function

        Friend Shared Function ModificarRejistro(ByVal Valor_Id As String, ByVal Columnas As Archivo_Frecuencias) As Boolean
            Dim Guardado As Boolean = False
            Try
                'Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & "\Contenido\ConfigPrintInt.xml"
                Dim xmlDoc As New XmlDocument
                Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
                xmlDoc.Load(RutaXMLConfigPrintInt)

                Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

                ' Dim CuerpoXL_1a As XmlNodeList = CuerpoXL_1.SelectSingleNode(Tabla).ChildNodes

                For Each Rejistros As XmlNode In CuerpoXL_1

                    Dim Comparador As String = Rejistros.SelectSingleNode("C_ID").InnerText

                    If Comparador = Valor_Id Then
                        Rejistros.SelectSingleNode("C_ID").InnerText = Columnas.Id
                        Rejistros.SelectSingleNode("C_Nombre").InnerText = Columnas.Nombre
                        Rejistros.SelectSingleNode("C_Frecuencia").InnerText = Columnas.Frecuencia
                        Rejistros.SelectSingleNode("C_Modulacion").InnerText = Columnas.Modulacion

                        Rejistros.SelectSingleNode("C_ModulaBand").InnerText = Columnas.ModulaBand
                        Rejistros.SelectSingleNode("C_Ganancia").InnerText = Columnas.Ganancia


                        Rejistros.SelectSingleNode("C_Señal").InnerText = Columnas.Señal
                        Rejistros.SelectSingleNode("C_Squelch").InnerText = Columnas.Squelch
                        Rejistros.SelectSingleNode("C_Tags").InnerText = Columnas.Tags
                        Rejistros.SelectSingleNode("C_Latitud").InnerText = Columnas.Latitud
                        Rejistros.SelectSingleNode("C_Longitud").InnerText = Columnas.Longitud
                        Rejistros.SelectSingleNode("C_Altitud").InnerText = Columnas.Altitud
                        Rejistros.SelectSingleNode("C_Nota").InnerText = Columnas.Nota
                        Rejistros.SelectSingleNode("C_Cominicacion").InnerText = Columnas.Cominicacion
                        Rejistros.SelectSingleNode("C_LnbLo").InnerText = Columnas.LnbLo

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
                'Module_Central.CopasSeguridad(Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo)

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
                    Dim Comparador As String = Rejistros.SelectSingleNode("C_ID").InnerText
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
                'Module_Central.CopasSeguridad(Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo)

            Catch ex As Exception
                MsgBox("" & vbCr & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            End Try
            Return Guardado
        End Function


        Friend Structure Archivo_Frecuencias
            Dim Id As String
            Dim Nombre As String
            Dim Frecuencia As String
            Dim Modulacion As String
            Dim ModulaBand As String
            Dim Ganancia As String
            Dim Señal As String
            Dim Squelch As String
            Dim Tags As String
            Dim Latitud As String
            Dim Longitud As String
            Dim Altitud As String
            Dim Nota As String
            Dim Cominicacion As String
            Dim LnbLo As String
        End Structure

    End Class

End Namespace