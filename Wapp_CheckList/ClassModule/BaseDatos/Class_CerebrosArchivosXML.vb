
Imports System.Xml

Public Class Class_CerebrosArchivosXML


    'Shared Archivo As String = "\Cerebros\x.xml"
    Event Modificacion()

#Region "Leer"

    Friend Shared Function ObtenerCerebros() As List(Of String)
        Dim lista As New List(Of String)
        Try

            Dim listaArchivos = FileIO.FileSystem.GetFiles(My.Application.Info.DirectoryPath & "\BaseDatos\Cerebros\")
            'ReDim Archivos(listaArchivos.Count)
            For indice As Integer = 0 To listaArchivos.Count - 1
                Dim Archivo As New System.IO.FileInfo(listaArchivos(indice))
                'Archivos.SetValue(Archivo.Name, indice)
                lista.Add(Archivo.Name)
            Next

        Catch ex As Exception

        End Try
        Return lista
    End Function


    Friend Shared Function ObtenerTodos(ByVal Archivo As String) As List(Of ClassArchivo_Cerebro)

        Dim Registros As New List(Of ClassArchivo_Cerebro)
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & "\Cerebros\" & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
        Dim Cerebros_Compara As XmlNode = Nudo.SelectSingleNode("tabla_Datos")
        Try
            For Indice As ULong = 0 To Cerebros_Compara.ChildNodes.Count - 1
                Dim Rejistro1 As XmlNode = Cerebros_Compara.SelectNodes("C_Cerebro").ItemOf(Indice)
                Dim Rejistro As New ClassArchivo_Cerebro(0, "")
                Rejistro.Id = Rejistro1.SelectSingleNode("C_Id").InnerText.ToString.Trim
                'Dim a As String = Cerebros_Compara.SelectNodes("C_Cerebro").ItemOf(1).SelectSingleNode("C_Id").InnerText
                'If Id.ToString = ID_Compara Then

                'Dim RejistroNombre As New ClassArchivo_Cerebro(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
                Rejistro.Nombre = Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString()
                Dim RegistroCapas As XmlNode = Rejistro1.SelectSingleNode("C_Capas")
                Dim CapasArchivo As New List(Of ClassArchivo_Cerebro.ClassArchivo_Capa)


                'For IndiceCapas As Integer = 0 To RegistroCapas.ChildNodes.Count - 1
                '    Dim Capa As XmlNode = RegistroCapas.ChildNodes.Item(IndiceCapas)
                '    Dim CapaArchivo As New ClassArchivo_Cerebro.ClassArchivo_Capas
                '    CapaArchivo.Nodos = New List(Of ClassArchivo_Cerebro.ClassArchivo_Capas.ClassArchivo_Neurona)


                '    For IndiceNeuronas As Integer = 0 To Capa.ChildNodes.Count - 1
                '        Dim RegistroNeuronas As XmlNode = RegistroCapas.ChildNodes.Item(IndiceCapas).ChildNodes.Item(IndiceNeuronas)
                '        Dim RegistroArchivoNodo As New ClassArchivo_Cerebro.ClassArchivo_Capas.ClassArchivo_Neurona
                '        RegistroArchivoNodo.Peso = RegistroNeuronas.ChildNodes.Item(0).InnerText
                '        CapaArchivo.Nodos.Add(RegistroArchivoNodo)

                '        RegistroArchivoNodo.errDelta = RegistroNeuronas.ChildNodes.Item(1).InnerText
                '        CapaArchivo.Nodos.Add(RegistroArchivoNodo)
                '        Try
                '            Dim RegistroHijos As XmlNode = RegistroNeuronas.SelectSingleNode("C_Hijos")
                '            For IndiceHijos As Integer = 0 To RegistroHijos.ChildNodes.Count - 1
                '                RegistroArchivoNodo.NodosHijos.Add(RegistroHijos.ChildNodes.Item(IndiceHijos).InnerText)
                '            Next

                '            Dim RegistroPadres As XmlNode = RegistroNeuronas.SelectSingleNode("C_Padres")
                '            For IndicePadres As Integer = 0 To RegistroPadres.ChildNodes.Count - 1
                '                RegistroArchivoNodo.NodosHijos.Add(RegistroPadres.ChildNodes.Item(IndicePadres).InnerText)
                '            Next
                '        Catch ex As Exception

                '        End Try

                '        'For IndiceHijos As Integer = 0 To RegistroNeuronas.se "C_Hijos"



                '        'C_ErrDelta
                '    Next


                '        CapasArchivo.Add(CapaArchivo)

                'Next

                'Rejistro.Capas = CapasArchivo

                Registros.Add(Rejistro)


            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Registros
    End Function


    Friend Shared Function ExisteId(ByVal Id As String, ByVal Archivo As String) As Boolean
        Dim Resultado As Boolean = False
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & "\Cerebros\" & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
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

    Friend Shared Function ExisteNombre(ByVal Id As String, ByVal Archivo As String) As Boolean
        Dim Resultado As Boolean = False
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & "\Cerebros\" & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
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

    Friend Shared Function ObtenerWhereId(ByVal Id As String, ByVal Archivo As String) As ClassArchivo_Cerebro
        Dim Rejistro As New ClassArchivo_Cerebro(Id, "")
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & "\Cerebros\" & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
        Dim Cerebros_Compara As XmlNode = Nudo.SelectSingleNode("tabla_Datos")
        Try
            For Each Rejistro1 As XmlNode In Cerebros_Compara.ChildNodes
                Dim ID_Compara As String = Rejistro1.SelectSingleNode("C_Id").InnerText.ToString.Trim
                If Id.ToString = ID_Compara Then

                    'Dim RejistroNombre As New ClassArchivo_Cerebro(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
                    Rejistro.Nombre = Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString()
                    Dim RegistroCapas As XmlNode = Rejistro1.SelectSingleNode("C_Capas")
                    Dim CapasArchivo As New List(Of ClassArchivo_Cerebro.ClassArchivo_Capa)


                    For IndiceCapas As Integer = 0 To RegistroCapas.ChildNodes.Count - 1
                        Dim Capa As XmlNode = RegistroCapas.ChildNodes.Item(IndiceCapas)
                        Dim CapaArchivo As New ClassArchivo_Cerebro.ClassArchivo_Capa
                        CapaArchivo.Nodos = New List(Of ClassArchivo_Cerebro.ClassArchivo_Capa.ClassArchivo_Neurona)


                        For IndiceNeuronas As Integer = 0 To Capa.ChildNodes.Count - 1
                            Dim RegistroNeuronas As XmlNode = RegistroCapas.ChildNodes.Item(IndiceCapas).ChildNodes.Item(IndiceNeuronas)
                            Dim RegistroArchivo As New ClassArchivo_Cerebro.ClassArchivo_Capa.ClassArchivo_Neurona
                            RegistroArchivo.Peso = RegistroNeuronas.InnerText.ToString
                            CapaArchivo.Nodos.Add(RegistroArchivo)


                            'For IndiceHijos As Integer = 0 To RegistroNeuronas. "C_Hijos"


                        Next


                        CapasArchivo.Add(CapaArchivo)

                    Next

                    Rejistro.Capas = CapasArchivo
                    'Dim RejistroCapa As New ClassArchivo_Cerebro.ClassArchivo_Capas

                    'Dim RejistroNodo As New ClassArchivo_Cerebro.ClassArchivo_Capas.ClassArchivo_Nodo




                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Rejistro
    End Function

    Friend Shared Function ObtenerWhereNombre(ByVal Nombre As String, ByVal Archivo As String) As ClassArchivo_Cerebro
        Dim Rejistro As New ClassArchivo_Cerebro(0, "")
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & "\Cerebros\" & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
        Dim Cerebros_Compara As XmlNode = Nudo.SelectSingleNode("tabla_Datos")
        Try
            For Each Rejistro1 As XmlNode In Cerebros_Compara.ChildNodes
                Dim Valor_Compara As String = Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString.Trim
                'If Nombre.ToString = Valor_Compara Then
                Rejistro.Id = Rejistro1.SelectSingleNode("C_Id").InnerText.ToString()
                    'Dim RejistroNombre As New ClassArchivo_Cerebro(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
                    Rejistro.Nombre = Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString()
                    Dim RegistroCapas As XmlNode = Rejistro1.SelectSingleNode("C_Capas")
                    Dim CapasArchivo As New List(Of ClassArchivo_Cerebro.ClassArchivo_Capa)


                    For IndiceCapas As Integer = 0 To RegistroCapas.ChildNodes.Count - 1
                        Dim CapaXml As XmlNode = RegistroCapas.ChildNodes.Item(IndiceCapas)
                        Dim CapaArchivo As New ClassArchivo_Cerebro.ClassArchivo_Capa
                        CapaArchivo.Nodos = New List(Of ClassArchivo_Cerebro.ClassArchivo_Capa.ClassArchivo_Neurona)
                        Try
                            CapaArchivo.Alfa = RegistroCapas.ChildNodes.Item(IndiceCapas).SelectSingleNode("C_Alpha").InnerText
                        Catch ex As Exception
                            MsgBox("Alpha go " & vbCrLf & ex.Message)
                        End Try
                        Dim RegistroNeuronas As XmlNodeList = CapaXml.SelectNodes("C_Neurona")

                        For IndiceNeuronas As Integer = 0 To RegistroNeuronas.Count - 1 'CapaXml.ChildNodes.Count - 1
                            Dim RegistroNeurona0 As XmlNode = RegistroCapas.ChildNodes.Item(IndiceCapas).ChildNodes.Item(IndiceNeuronas)
                            Dim RegistroNeurona As XmlNode = RegistroNeuronas.ItemOf(IndiceNeuronas)
                            Dim RegistroArchivo As New ClassArchivo_Cerebro.ClassArchivo_Capa.ClassArchivo_Neurona


                            Try
                                Try
                                    RegistroArchivo.Peso = RegistroNeurona.SelectSingleNode("C_W").InnerText
                                    RegistroArchivo.Bias = RegistroNeurona.SelectSingleNode("C_Bias").InnerText
                                    RegistroArchivo.BiasPrebio = RegistroNeurona.SelectSingleNode("C_BiasPrebio").InnerText
                                    RegistroArchivo.errDelta = RegistroNeurona.SelectSingleNode("C_ErrDelta").InnerText
                                    'RegistroArchivo.Bias = RegistroNeurona.SelectSingleNode("C_Bias").InnerText
                                Catch ex As Exception

                                End Try




                                CapaArchivo.Nodos.Add(RegistroArchivo)
                                'C_W> -1, 80810961139673</C_W>
                                '<C_ErrDelta>0</C_ErrDelta>
                                Try
                                    If RegistroNeurona.SelectSingleNode("C_Hijos").InnerText <> String.Empty Then
                                        Dim RegistroHijos As XmlNode = RegistroNeurona.SelectSingleNode("C_Hijos")
                                        Dim RegistroHijosActual As XmlNodeList = RegistroHijos.SelectNodes("C_Wh")
                                        For IndiceHijos As Integer = 0 To RegistroHijosActual.Count - 1
                                            RegistroArchivo.NodosHijos.Add(RegistroHijosActual.Item(IndiceHijos).InnerText)
                                        Next
                                        Dim RegistroHijosPrevio As XmlNodeList = RegistroHijos.SelectNodes("C_Wha")
                                        For IndiceHijos As Integer = 0 To RegistroHijosPrevio.Count - 1
                                            RegistroArchivo.NodosHijosPrevio.Add(RegistroHijosPrevio.Item(IndiceHijos).InnerText)
                                        Next

                                    End If
                                Catch ex As Exception
                                    MsgBox("Hijos" & vbCrLf & ex.Message)
                                End Try


                                Try
                                    If RegistroNeurona.SelectSingleNode("C_Padres").InnerText <> String.Empty Then
                                        Dim RegistroPadres As XmlNode = RegistroNeurona.SelectSingleNode("C_Padres")
                                        Dim RegistroPadresActual As XmlNodeList = RegistroPadres.SelectNodes("C_Wp")
                                        For IndicePadres As Integer = 0 To RegistroPadresActual.Count - 1
                                            RegistroArchivo.NodosPadres.Add(RegistroPadresActual.Item(IndicePadres).InnerText)
                                        Next
                                        Dim RegistroPadresPrevio As XmlNodeList = RegistroPadres.SelectNodes("C_Wpa")
                                        For IndicePadres As Integer = 0 To RegistroPadresActual.Count - 1
                                            RegistroArchivo.NodosPadresPrevio.Add(RegistroPadresPrevio.Item(IndicePadres).InnerText)
                                        Next
                                    End If
                                Catch ex As Exception
                                    MsgBox("Padres" & vbCrLf & ex.Message)
                                End Try


                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try

                        Next


                        CapasArchivo.Add(CapaArchivo)


                    Next

                    Rejistro.Capas = CapasArchivo
                    'Dim RejistroCapa As New ClassArchivo_Cerebro.ClassArchivo_Capas

                'Dim RejistroNodo As New ClassArchivo_Cerebro.ClassArchivo_Capas.ClassArchivo_Nodo




                'Exit For
                'End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Rejistro
    End Function

#End Region



    Friend Shared Function InsertarRejistro(ByVal Archivo_Envio As ClassArchivo_Cerebro, ByVal Archivo As String)
        Dim DatosAgregados As Boolean = False

        Dim RutaXMLConfigPrintInt As String = Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Body As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        '      Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
        Dim NudoTabla As XmlNode = Body.SelectSingleNode("tabla_Datos")
        Try

            Dim NudoCerebro As XmlNode = xmlDoc.CreateElement("C_Cerebro")
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
            Dim NuevoNudoC_Delta As XmlNode = xmlDoc.CreateElement("C_Delta")
            NuevoNudoC_Delta.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Delta))
            NudoCerebro.AppendChild(NuevoNudoC_Delta)
            '------------------


            Dim NuevoNudoC_Capas As XmlNode = xmlDoc.CreateElement("C_Capas")
            NuevoNudoC_Capas.AppendChild(xmlDoc.CreateTextNode(""))
            '________---------
            For IndiceCapa As Integer = 0 To Archivo_Envio.Capas.Count - 1
                Dim NuevoNudoC_Capa As XmlNode = xmlDoc.CreateElement("C_Capa")
                NuevoNudoC_Capa.AppendChild(xmlDoc.CreateTextNode(""))

                Dim NuevoNudoC_Alpha As XmlNode = xmlDoc.CreateElement("C_Alpha")
                NuevoNudoC_Alpha.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Capas.Item(IndiceCapa).Alfa))
                NuevoNudoC_Capa.AppendChild(NuevoNudoC_Alpha)
                '------------------

                For Indice As Integer = 0 To Archivo_Envio.Capas.Item(IndiceCapa).Nodos.Count - 1


                    Dim NuevoNudoC_Neurona As XmlNode = xmlDoc.CreateElement("C_Neurona")
                    NuevoNudoC_Neurona.AppendChild(xmlDoc.CreateTextNode(""))
                    NuevoNudoC_Capa.AppendChild(NuevoNudoC_Neurona)
                    Dim NuevoNudoC_W As XmlNode = xmlDoc.CreateElement("C_W")
                    NuevoNudoC_W.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Capas.Item(IndiceCapa).Nodos.Item(Indice).Peso))
                    NuevoNudoC_Neurona.AppendChild(NuevoNudoC_W)
                    Dim NuevoNudoC_ErrDelta As XmlNode = xmlDoc.CreateElement("C_ErrDelta")
                    NuevoNudoC_ErrDelta.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Capas.Item(IndiceCapa).Nodos.Item(Indice).errDelta))
                    NuevoNudoC_Neurona.AppendChild(NuevoNudoC_ErrDelta)

                    Dim NuevoNudoC_Bias As XmlNode = xmlDoc.CreateElement("C_Bias")
                    NuevoNudoC_Bias.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Capas.Item(IndiceCapa).Nodos.Item(Indice).Bias))
                    NuevoNudoC_Neurona.AppendChild(NuevoNudoC_Bias)

                    Dim NuevoNudoC_BiasPrebio As XmlNode = xmlDoc.CreateElement("C_BiasPrebio")
                    NuevoNudoC_BiasPrebio.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Capas.Item(IndiceCapa).Nodos.Item(Indice).BiasPrebio))
                    NuevoNudoC_Neurona.AppendChild(NuevoNudoC_BiasPrebio)

                    Dim NuevoNudoC_BiasPrebio2 As XmlNode = xmlDoc.CreateElement("C_BiasPrebio2")
                    NuevoNudoC_BiasPrebio2.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Capas.Item(IndiceCapa).Nodos.Item(Indice).BiasPrebio2))
                    NuevoNudoC_Neurona.AppendChild(NuevoNudoC_BiasPrebio2)

                    Dim NuevoNudoC_BiasPrebio3 As XmlNode = xmlDoc.CreateElement("C_BiasPrebio3")
                    NuevoNudoC_BiasPrebio3.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Capas.Item(IndiceCapa).Nodos.Item(Indice).BiasPrebio3))
                    NuevoNudoC_Neurona.AppendChild(NuevoNudoC_BiasPrebio3)




                    Dim NodosHijos As XmlNode = xmlDoc.CreateElement("C_Hijos")
                    NodosHijos.AppendChild(xmlDoc.CreateTextNode(""))
                    For IndiceHijos As Integer = 0 To Archivo_Envio.Capas.Item(IndiceCapa).Nodos.Item(Indice).NodosHijos.Count - 1
                        Dim NodosHijoPeso As XmlNode = xmlDoc.CreateElement("C_Wh")
                        NodosHijoPeso.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Capas.Item(IndiceCapa).Nodos.Item(Indice).NodosHijos.Item(IndiceHijos)))
                        NodosHijos.AppendChild(NodosHijoPeso)

                        Dim NodosHijoPesoAnterior As XmlNode = xmlDoc.CreateElement("C_Wha")
                        NodosHijoPesoAnterior.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Capas.Item(IndiceCapa).Nodos.Item(Indice).NodosHijos.Item(IndiceHijos)))
                        NodosHijos.AppendChild(NodosHijoPesoAnterior)
                    Next
                    NuevoNudoC_Neurona.AppendChild(NodosHijos)




                    Dim NodosPadres As XmlNode = xmlDoc.CreateElement("C_Padres")
                    NodosPadres.AppendChild(xmlDoc.CreateTextNode(""))
                    For IndicePadres As Integer = 0 To Archivo_Envio.Capas.Item(IndiceCapa).Nodos.Item(Indice).NodosPadres.Count - 1
                        Dim NodosPadrePeso As XmlNode = xmlDoc.CreateElement("C_Wp")
                        NodosPadrePeso.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Capas.Item(IndiceCapa).Nodos.Item(Indice).NodosPadres.Item(IndicePadres)))
                        NodosPadres.AppendChild(NodosPadrePeso)
                        Dim NodosPadrePesoAnterior As XmlNode = xmlDoc.CreateElement("C_Wpa")
                        NodosPadrePesoAnterior.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Capas.Item(IndiceCapa).Nodos.Item(Indice).NodosPadres.Item(IndicePadres)))
                        NodosPadres.AppendChild(NodosPadrePesoAnterior)
                    Next
                    NuevoNudoC_Neurona.AppendChild(NodosPadres)



                Next
                NuevoNudoC_Capas.AppendChild(NuevoNudoC_Capa)
            Next
            NudoCerebro.AppendChild(NuevoNudoC_Capas)



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

    Friend Shared Function ModificarRejistro(ByVal Valor_Id As String, ByVal Columnas As ClassArchivo_Cerebro, ByVal Archivo As String) As Boolean
        Dim Guardado As Boolean = False
        Try
            'Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & "\Contenido\ConfigPrintInt.xml"
            Dim xmlDoc As New XmlDocument
            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & "\Cerebros\" & Archivo
            xmlDoc.Load(RutaXMLConfigPrintInt)

            Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

            ' Dim CuerpoXL_1a As XmlNodeList = CuerpoXL_1.SelectSingleNode(Tabla).ChildNodes

            For Each Rejistros As XmlNode In CuerpoXL_1

                Dim Comparador As String = Rejistros.SelectSingleNode("C_Id").InnerText

                If Comparador = Valor_Id Then
                    Rejistros.SelectSingleNode("C_Id").InnerText = Columnas.Id
                    Rejistros.SelectSingleNode("C_Nombre").InnerText = Columnas.Nombre
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

    Friend Shared Function Update_TemperaturaBullicion(ByVal Valor_Id As String, ByVal Val_TemperaturaBullicion As String, ByVal Archivo As String) As Boolean
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
                    '<?xml version="1.0" encoding="iso-8859-15" ?>
                    '<body>
                    '  <C_Material>
                    '    <C_Id>0</C_Id>
                    '    <C_Nombre></C_Nombre>
                    '    <C_ResistenciaEspecifica></C_ResistenciaEspecifica>
                    '    <C_VariacionResistenciaTemperatura></C_VariacionResistenciaTemperatura>
                    '    <C_TemperaturaDilatacion></C_TemperaturaDilatacion>
                    '    <C_TemperaturaEspecifica></C_TemperaturaEspecifica>
                    '    <C_PermitividadElectrica></C_PermitividadElectrica>
                    '    <C_PermeabilidadMagnetica></C_PermeabilidadMagnetica>
                    '    <C_TemperaturaBullicion></C_TemperaturaBullicion>
                    '    <C_Activo>FALSE</C_Activo>
                    '  </C_Material>
                    '</body>

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


    Friend Shared Function EliminarRejistro0(ByVal ByVal_Id As String, ByVal Archivo As String) As Boolean
        Dim Guardado As Boolean = False
        Try
            Dim xmlDoc As New XmlDocument
            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & "\Cerebros\" & Archivo
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


End Class
