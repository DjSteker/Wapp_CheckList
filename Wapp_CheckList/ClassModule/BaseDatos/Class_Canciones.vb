Imports System.Xml


Namespace BaseDatos

    Public Class Class_Canciones
        Shared Archivo As String = "\Canciones.xml"
        Event Modificacion()

        '    <body>
        '    <Aparato>
        '    <C_ID>0</C_ID>
        '    <C_Nombre> PC0</C_Nombre>
        '    <Accesorio>
        '    <C_RasgoId>0</C_RasgoId>
        '      <C_RasgoNombre> Teclado0</C_RasgoNombre>
        '    </Accesorio>
        '    <Accesorio>
        '    <C_RasgoId>1</C_RasgoId>
        '      <C_RasgoNombre> CableAlimentacion0</C_RasgoNombre>
        '    </Accesorio>
        '  </Aparato>
        '</body>

        Friend Shared Function ObtenerTodos() As List(Of Archivo_Cancion)
            Dim Lista As New List(Of Archivo_Cancion)
            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(RutaXMLConfigPrintInt)
            Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
            '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
            Try


                For Each RejistroNudo As XmlNode In Nudo.ChildNodes
                    Dim Rejistro As New Archivo_Cancion
                    Rejistro.Id = RejistroNudo.SelectSingleNode("C_ID").InnerText
                    Rejistro.Nombre = RejistroNudo.SelectSingleNode("C_Nombre").InnerText
                    Rejistro.Ruta = RejistroNudo.SelectSingleNode("C_Ruta").InnerText
                    Rejistro.Genero = RejistroNudo.SelectSingleNode("C_Genero").InnerText
                    Dim NudoRasgos As XmlNode = RejistroNudo.SelectSingleNode("C_Rasgos")
                    Try
                        For Each AccesorioLista As XmlNode In RejistroNudo.SelectNodes("Rasgo")
                            Dim Accesorio As New Archivo_Rasgo
                            Accesorio.Id = AccesorioLista.SelectSingleNode("C_RasgoId").InnerText
                            Accesorio.RasgoNombre = AccesorioLista.SelectSingleNode("C_RasgoNombre").InnerText
                            Accesorio.Valor = AccesorioLista.SelectSingleNode("C_valor").InnerText
                            Rejistro.Rasgos.Add(Accesorio)
                        Next
                    Catch ex As Exception

                    End Try
                    Lista.Add(Rejistro)
                Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Lista
        End Function


        Friend Shared Function ObtenerWhereId(ByVal Id As String) As Archivo_Cancion
            Dim Rejistro As New Archivo_Cancion
            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(RutaXMLConfigPrintInt)
            Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
            '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
            Try
                For Each RejistroNudo As XmlNode In Nudo.ChildNodes
                    Dim ID_Compara As String = RejistroNudo.SelectSingleNode("C_ID").InnerText
                    If Id = ID_Compara Then
                        Rejistro.Id = RejistroNudo.SelectSingleNode("C_ID").InnerText
                        Rejistro.Nombre = RejistroNudo.SelectSingleNode("C_Nombre").InnerText
                        Rejistro.Ruta = RejistroNudo.SelectSingleNode("C_Ruta").InnerText
                        Rejistro.Genero = RejistroNudo.SelectSingleNode("C_Genero").InnerText
                        Rejistro.Rasgos = New List(Of Archivo_Rasgo)
                        ' Dim NudoHijos As XmlNode = xmlDoc.GetElementsByTagName("Rasgo").Item(0)
                        Dim NudoRasgos As XmlNode = RejistroNudo.SelectSingleNode("C_Rasgos")
                        If IsNothing(NudoRasgos) = False Then



                            For Each NudoHijo As XmlNode In RejistroNudo.SelectSingleNode("C_Rasgos")
                                Dim Rasgo As New Class_Canciones.Archivo_Rasgo
                                Try
                                    Rasgo.Id = NudoHijo.SelectSingleNode("C_RasgoId").InnerText
                                    Rasgo.RasgoNombre = NudoHijo.SelectSingleNode("C_RasgoNombre").InnerText
                                    Rasgo.Valor = NudoHijo.SelectSingleNode("C_valor").InnerText

                                Catch ex As Exception

                                End Try
                                Rejistro.Rasgos.Add(Rasgo)

                            Next

                        End If


                        Exit For
                        End If

                Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Rejistro
        End Function

        Friend Shared Function ObtenerWhereNombre(ByVal Nombre As String) As Archivo_Cancion
            Dim Rejistro As New Archivo_Cancion
            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(RutaXMLConfigPrintInt)
            Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
            '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
            Try
                For Each RejistroNudo As XmlNode In Nudo.ChildNodes
                    Dim Nombre_Compara As String = RejistroNudo.SelectSingleNode("C_Nombre").InnerText
                    If Nombre = Nombre_Compara Then
                        Rejistro.Id = RejistroNudo.SelectSingleNode("C_ID").InnerText
                        Rejistro.Nombre = RejistroNudo.SelectSingleNode("C_Nombre").InnerText
                        Rejistro.Ruta = RejistroNudo.SelectSingleNode("C_Ruta").InnerText
                        Rejistro.Genero = RejistroNudo.SelectSingleNode("C_Genero").InnerText
                        Try
                            For Each AccesorioLista As XmlNode In RejistroNudo.SelectNodes("Rasgo")
                                Dim Accesorio As New Archivo_Rasgo
                                Accesorio.Id = AccesorioLista.SelectSingleNode("C_RasgoId").InnerText
                                Accesorio.RasgoNombre = AccesorioLista.SelectSingleNode("C_RasgoNombre").InnerText
                                Accesorio.Valor = AccesorioLista.SelectSingleNode("C_valor").InnerText
                                Rejistro.Rasgos.Add(Accesorio)
                            Next
                        Catch ex As Exception

                        End Try

                        Exit For
                    End If

                Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Rejistro
        End Function




        Friend Shared Function ObtenerAccesoriosWhereIdCancion(ByVal Id As String) As Archivo_Cancion
            Dim Rejistro As New Archivo_Cancion
            Rejistro.Rasgos = New List(Of Archivo_Rasgo)
            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(RutaXMLConfigPrintInt)
            Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
            '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
            Try
                For Each RejistroNudo As XmlNode In Nudo.ChildNodes
                    Dim ID_Compara As String = RejistroNudo.SelectSingleNode("C_ID").InnerText

                    If Id = ID_Compara Then

                        Rejistro.Id = RejistroNudo.SelectSingleNode("C_ID").InnerText
                        Rejistro.Nombre = RejistroNudo.SelectSingleNode("C_Nombre").InnerText
                        Rejistro.Ruta = RejistroNudo.SelectSingleNode("C_Ruta").InnerText
                        Rejistro.Genero = RejistroNudo.SelectSingleNode("C_Genero").InnerText
                        '<C_Rasgos></C_Rasgos>
                        Try
                            For Each AccesorioLista As XmlNode In RejistroNudo.SelectSingleNode("C_Rasgos")
                                Dim Accesorio As New Archivo_Rasgo
                                Accesorio.Id = AccesorioLista.SelectSingleNode("C_RasgoId").InnerText
                                Accesorio.RasgoNombre = AccesorioLista.SelectSingleNode("C_RasgoNombre").InnerText
                                Accesorio.Valor = AccesorioLista.SelectSingleNode("C_valor").InnerText
                                Rejistro.Rasgos.Add(Accesorio)
                            Next
                        Catch ex As Exception

                        End Try



                        'For Each AccesorioLista As XmlNode In RejistroNudo.ChildNodes
                        '    Dim Accesorio As New Archivo_Accesorio
                        '    Accesorio.Id = AccesorioLista.SelectSingleNode("C_RasgoId").InnerText
                        '    Accesorio.AcesorioNombre = AccesorioLista.SelectSingleNode("C_RasgoNombre").InnerText
                        '    Rejistro.Accesosrios.Add(Accesorio)
                        'Next


                        Exit For
                    End If

                Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Rejistro
        End Function


        Friend Shared Function InsertarCancion(ByVal Archivo_Envio As Archivo_Cancion) As Boolean
            '    Dim Datos1 As New List(Of Archivo_Aparatos)
            Dim Agregado As Boolean = False
            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(RutaXMLConfigPrintInt)
            Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
            '      Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)

            Try

                Dim NuevoNudo As XmlNode = xmlDoc.CreateElement("Cancion")
                NuevoNudo.AppendChild(xmlDoc.CreateTextNode(""))


                Dim NuevoNudoC_Id As XmlNode = xmlDoc.CreateElement("C_ID")
                NuevoNudoC_Id.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Id.ToString))
                NuevoNudo.AppendChild(NuevoNudoC_Id)




                If IsNothing(Archivo_Envio.Nombre) Then
                    Archivo_Envio.Nombre = String.Empty
                End If
                Dim NuevoNudoC_Nombre As XmlNode = xmlDoc.CreateElement("C_Nombre")
                NuevoNudoC_Nombre.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Nombre.ToString))
                NuevoNudo.AppendChild(NuevoNudoC_Nombre)

                Dim NuevoNudoC_Ruta As XmlNode = xmlDoc.CreateElement("C_Ruta")
                If IsNothing(Archivo_Envio.Ruta) Then
                    Archivo_Envio.Ruta = String.Empty
                End If
                NuevoNudoC_Ruta.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Ruta.ToString))
                NuevoNudo.AppendChild(NuevoNudoC_Ruta)

                If IsNothing(Archivo_Envio.Genero) Then
                    Archivo_Envio.Genero = String.Empty
                End If
                Dim NuevoNudoC_Genero As XmlNode = xmlDoc.CreateElement("C_Genero")
                NuevoNudoC_Genero.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Genero.ToString))
                NuevoNudo.AppendChild(NuevoNudoC_Genero)

                Dim NuevoNudoC_RasgoNombre As XmlNode = xmlDoc.CreateElement("C_Rasgos")
                NuevoNudoC_RasgoNombre.AppendChild(xmlDoc.CreateTextNode(""))
                NuevoNudo.AppendChild(NuevoNudoC_RasgoNombre)

                NudoTabla.AppendChild(NuevoNudo)

                ' xmlDoc.Save(My.Application.Info.DirectoryPath & Archivo)
                xmlDoc.Save(RutaXMLConfigPrintInt)
                Agregado = True
                '   Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            Return Agregado
        End Function

        Friend Shared Function InsertarRasgo(ByVal ByValArchivo_Cancion As Archivo_Cancion, ByVal ByValArchivo_Rasgo As Archivo_Rasgo) As Boolean
            '  Dim Datos1 As New List(Of Archivo_Aparatos)
            Dim Insetado As Boolean = False
            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(RutaXMLConfigPrintInt)
            Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
            '      Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)

            Try


                For Each Rejistro As XmlNode In CuerpoXL_1
                    Dim Comparador As String = Rejistro.SelectSingleNode("C_ID").InnerText
                    If Comparador = ByValArchivo_Cancion.Id Then

                        Dim NudoRasgos As XmlNode = Rejistro.SelectSingleNode("C_Rasgos")

                        Dim NuevoNudo As XmlNode = xmlDoc.CreateElement("Rasgo")
                        NudoRasgos.AppendChild(xmlDoc.CreateTextNode(""))


                        Dim NuevoNudoC_RasgoId As XmlNode = xmlDoc.CreateElement("C_RasgoId")
                        NuevoNudoC_RasgoId.AppendChild(xmlDoc.CreateTextNode(ByValArchivo_Rasgo.Id.ToString))
                        NuevoNudo.AppendChild(NuevoNudoC_RasgoId)

                        Dim NuevoNudoC_RasgoNombre As XmlNode = xmlDoc.CreateElement("C_RasgoNombre")
                        NuevoNudoC_RasgoNombre.AppendChild(xmlDoc.CreateTextNode(ByValArchivo_Rasgo.RasgoNombre.ToString))
                        NuevoNudo.AppendChild(NuevoNudoC_RasgoNombre)

                        Dim NuevoNudoC_valor As XmlNode = xmlDoc.CreateElement("C_valor")
                        NuevoNudoC_valor.AppendChild(xmlDoc.CreateTextNode(ByValArchivo_Rasgo.Valor.ToString))
                        NuevoNudo.AppendChild(NuevoNudoC_valor)


                        NudoRasgos.AppendChild(NuevoNudo)


                    End If
                Next


                xmlDoc.Save(RutaXMLConfigPrintInt)

                '   xmlDoc.Save(My.Application.Info.DirectoryPath & Archivo)
                Insetado = True
                '   Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            Return Insetado
        End Function

        Friend Shared Function ModificarCancion(ByVal Cancion As Archivo_Cancion) As Boolean
            Dim Guardado As Boolean = False
            Try
                'Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & "\Contenido\ConfigPrintInt.xml"
                Dim xmlDoc As New XmlDocument
                Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
                xmlDoc.Load(RutaXMLConfigPrintInt)

                Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)


                For Each Rejistros As XmlNode In CuerpoXL_1

                    Dim Comparador As String = Rejistros.SelectSingleNode("C_ID").InnerText

                    If Comparador = Cancion.Id Then

                        'Rejistros.SelectSingleNode("C_ID").InnerText = Cancion.Id
                        Rejistros.SelectSingleNode("C_Nombre").InnerText = Cancion.Nombre
                        Rejistros.SelectSingleNode("C_Ruta").InnerText = Cancion.Ruta
                        Rejistros.SelectSingleNode("C_Genero").InnerText = Cancion.Genero

                        Dim NudoC_Rasgos As XmlNode = Rejistros.SelectSingleNode("C_Rasgos")
                        If IsNothing(NudoC_Rasgos) Then
                            NudoC_Rasgos = xmlDoc.CreateElement("C_Rasgos")
                            Rejistros.AppendChild(NudoC_Rasgos)
                        End If
                        For Each Rasgo As Class_Canciones.Archivo_Rasgo In Cancion.Rasgos
                            'Dim Rasgo As New Class_Canciones.Archivo_Rasgo
                            Try

                                Dim encontrado As Boolean = False

                                Try

                                    For Each XMLHijo As XmlNode In NudoC_Rasgos
                                        If NudoC_Rasgos.SelectSingleNode("C_RasgoNombre").InnerText.ToString.ToUpper = Rasgo.RasgoNombre.ToString.ToUpper Then
                                            'NudoHijo.SelectSingleNode("C_RasgoNombre").InnerText = Rasgo.RasgoNombre
                                            NudoC_Rasgos.SelectSingleNode("C_valor").InnerText = Rasgo.Valor
                                            encontrado = True
                                        End If
                                    Next
                                Catch ex As Exception

                                End Try

                                If encontrado = False Then

                                    Dim NuevoNudo_Rasgo As XmlNode = xmlDoc.CreateElement("Rasgo")
                                    NuevoNudo_Rasgo.AppendChild(xmlDoc.CreateTextNode(""))


                                    Dim NuevoNudoC_RasgoId As XmlNode = xmlDoc.CreateElement("C_RasgoId")
                                    NuevoNudoC_RasgoId.AppendChild(xmlDoc.CreateTextNode(Rasgo.Id.ToString))
                                    NuevoNudo_Rasgo.AppendChild(NuevoNudoC_RasgoId)

                                    Dim NuevoNudoC_RasgoNombre As XmlNode = xmlDoc.CreateElement("C_RasgoNombre")
                                    NuevoNudoC_RasgoNombre.AppendChild(xmlDoc.CreateTextNode(Rasgo.RasgoNombre.ToString))
                                    NuevoNudo_Rasgo.AppendChild(NuevoNudoC_RasgoNombre)

                                    Dim NuevoNudoC_valor As XmlNode = xmlDoc.CreateElement("C_valor")
                                    NuevoNudoC_valor.AppendChild(xmlDoc.CreateTextNode(Rasgo.Valor.ToString))
                                    NuevoNudo_Rasgo.AppendChild(NuevoNudoC_valor)

                                    NudoC_Rasgos.AppendChild(NuevoNudo_Rasgo)
                                    'Rejistros.AppendChild(NudoHijo)
                                End If

                            Catch ex As Exception

                            End Try
                            'Rejistro.Rasgos.Add(Rasgo)

                        Next


                    End If

                Next
                xmlDoc.Save(RutaXMLConfigPrintInt)
                'xmlDoc.Save(My.Application.Info.DirectoryPath & Archivo)

                Guardado = True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Guardado
        End Function

        Friend Shared Function ModificarRejistro(ByVal Tabla As String, ByVal SeleccColumna As String, ByVal SelecValor As String, ByVal Columnas As Archivo_Cancion) As Boolean
            Dim Guardado As Boolean = False
            Try
                'Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & "\Contenido\ConfigPrintInt.xml"
                Dim xmlDoc As New XmlDocument
                Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
                xmlDoc.Load(RutaXMLConfigPrintInt)

                Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

                Dim CuerpoXL_1a As XmlNodeList = CuerpoXL_1.SelectSingleNode(Tabla).ChildNodes

                For Each Rejistros As XmlNode In CuerpoXL_1a

                    Dim Comparador As String = Rejistros.SelectSingleNode(SeleccColumna).InnerText

                    If Comparador = SelecValor Then

                        Rejistros.SelectSingleNode("C_ID").InnerText = Columnas.Id
                        Rejistros.SelectSingleNode("C_Nombre").InnerText = Columnas.Nombre
                        Rejistros.SelectSingleNode("C_Ruta").InnerText = Columnas.Ruta
                        Rejistros.SelectSingleNode("C_Genero").InnerText = Columnas.Genero

                    End If

                Next
                xmlDoc.Save(RutaXMLConfigPrintInt)
                'xmlDoc.Save(My.Application.Info.DirectoryPath & Archivo)

                Guardado = True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Guardado
        End Function

        Friend Shared Function EliminarCancion(ByVal SelecId As String) As Boolean
            Dim Guardado As Boolean = False
            Try
                Dim xmlDoc As New XmlDocument
                Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
                xmlDoc.Load(RutaXMLConfigPrintInt)

                Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
                '   Dim Cuerpo_Cliente As XmlNode = CuerpoXL_1.SelectSingleNode("C_Cliente")

                For Each Rejistros As XmlNode In CuerpoXL_1
                    Dim Comparador As String = Rejistros.SelectSingleNode("C_ID").InnerText
                    If Comparador = SelecId Then
                        CuerpoXL_1.RemoveChild(Rejistros)
                    End If
                Next

                '    xmlDoc.Save(My.Application.Info.DirectoryPath & Archivo)
                xmlDoc.Save(RutaXMLConfigPrintInt)
                Guardado = True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Guardado
        End Function

        Friend Shared Function EliminarRasgo(ByVal AparatoId As String, ByVal SelecAccesorioId As String) As Boolean
            Dim Guardado As Boolean = False
            Try
                Dim xmlDoc As New XmlDocument
                Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
                xmlDoc.Load(RutaXMLConfigPrintInt)

                Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
                '   Dim Cuerpo_Cliente As XmlNode = CuerpoXL_1.SelectSingleNode("C_Cliente")


                For Each Rejistros As XmlNode In CuerpoXL_1
                    Dim Comparador As String = Rejistros.SelectSingleNode("C_ID").InnerText
                    If Comparador = AparatoId Then
                        '   For Each Aparatos As XmlNode In Rejistros
                        '   Comparador = String.Empty
                        '     Dim NudoSelect As XmlNode = Accesorios.SelectSingleNode("C_RasgoId")
                        '   Comparador = Accesorios.SelectSingleNode("C_RasgoId").InnerText


                        Dim NudosAccesorios As XmlNode = Rejistros.SelectSingleNode("C_Rasgos")

                        For Each Accesorio As XmlNode In NudosAccesorios
                            Dim ComparadorAccesorio As String = Accesorio.SelectSingleNode("C_RasgoId").InnerText
                            If ComparadorAccesorio = SelecAccesorioId Then
                                Try
                                    NudosAccesorios.RemoveChild(Accesorio)
                                    Guardado = True

                                Catch ex As Exception

                                End Try
                                Exit For
                            End If
                        Next
                        '   Next


                        Exit For
                    End If
                Next

                '   xmlDoc.Save(My.Application.Info.DirectoryPath & Archivo)
                If Guardado = True Then
                    Guardado = False
                    xmlDoc.Save(RutaXMLConfigPrintInt)
                    Guardado = True


                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Guardado
        End Function

        '    <body>
        '    <Aparato>
        '    <C_ID>0</C_ID>
        '    <C_Nombre> PC0</C_Nombre>
        '    <Accesorio>
        '    <C_RasgoId>0</C_RasgoId>
        '      <C_RasgoNombre> Teclado0</C_RasgoNombre>
        '    </Accesorio>
        '    <Accesorio>
        '    <C_RasgoId>1</C_RasgoId>
        '      <C_RasgoNombre> CableAlimentacion0</C_RasgoNombre>
        '    </Accesorio>
        '  </Aparato>
        '</body>

        Friend Structure Archivo_Cancion
            Dim Id As String
            Dim Nombre As String
            Dim Ruta As String
            Dim Genero As String
            Dim Rasgos As List(Of Archivo_Rasgo)
        End Structure

        Friend Structure Archivo_Rasgo
            Dim Id As String
            Dim RasgoNombre As String
            Dim Valor As String
        End Structure


    End Class


End Namespace