

Imports System.Xml

Public Class Class_PaisesISO



    Shared Archivo As String = "\PaisesCodeISO.xml"
    Event Modificacion()


#Region "Leer"
    '<?xml version="1.0" encoding="iso-8859-15"?>
    '<body>
    '    <tabla_Datos>
    '    <C_Pais>
    '    <C_Id>0</C_Id>
    '      <C_IdPais>0</C_IdPais>
    '      <C_NamePais>0</C_NamePais>
    '      <C_2>0</C_2>
    '      <C_3>0</C_3>
    '      <C_iso>0</C_iso>
    '    </C_Pais>
    '  </tabla_Datos>
    '</body>
    Friend Shared Function ObtenerTodos() As List(Of Archivo_PaisesIso)

        Dim Registros As New List(Of Archivo_PaisesIso)
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

        Dim Cerebros_Compara As XmlNode = Nudo.SelectSingleNode("tabla_Datos")
        Try
            For Indice As ULong = 0 To Cerebros_Compara.ChildNodes.Count - 1
                Dim Rejistro1 As XmlNode = Cerebros_Compara.SelectNodes("C_Pais").ItemOf(Indice)
                Dim Rejistro As New Archivo_PaisesIso
                Rejistro.Id = Rejistro1.SelectSingleNode("C_Id").InnerText.ToString.Trim

                Rejistro.IdPais = Rejistro1.SelectSingleNode("C_IdPais").InnerText.ToString()
                Rejistro.NamePais = Rejistro1.SelectSingleNode("C_NamePais").InnerText.ToString()
                Rejistro.C_2 = Rejistro1.SelectSingleNode("C_2").InnerText.ToString()
                Rejistro.C_3 = Rejistro1.SelectSingleNode("C_3").InnerText.ToString()
                Rejistro.C_iso = Rejistro1.SelectSingleNode("C_iso").InnerText.ToString()


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

    Friend Shared Function ObtenerWhereId(ByVal Id As String) As Archivo_PaisesIso
        Dim Rejistro As New Archivo_PaisesIso
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
                    Rejistro.IdPais = Rejistro1.SelectSingleNode("C_IdPais").InnerText.ToString()
                    Rejistro.NamePais = Rejistro1.SelectSingleNode("C_NamePais").InnerText.ToString()
                    Rejistro.C_2 = Rejistro1.SelectSingleNode("C_2").InnerText.ToString()
                    Rejistro.C_3 = Rejistro1.SelectSingleNode("C_3").InnerText.ToString()
                    Rejistro.C_iso = Rejistro1.SelectSingleNode("C_iso").InnerText.ToString()


                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Rejistro
    End Function

    Friend Shared Function ObtenerWhereNombre(ByVal Nombre As String) As Archivo_PaisesIso
        Dim Rejistro As New Archivo_PaisesIso
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

        Dim Cerebros_Compara As XmlNode = Nudo.SelectSingleNode("tabla_Datos")
        Try
            For Each Rejistro1 As XmlNode In Cerebros_Compara.ChildNodes
                Dim Valor_Compara As String = Rejistro1.SelectSingleNode("C_NamePais").InnerText.ToString.Trim
                If Nombre.ToString = Valor_Compara Then



                    Rejistro.Id = Rejistro1.SelectSingleNode("C_Id").InnerText.ToString.Trim
                    Rejistro.IdPais = Rejistro1.SelectSingleNode("C_IdPais").InnerText.ToString()
                    Rejistro.NamePais = Rejistro1.SelectSingleNode("C_NamePais").InnerText.ToString()
                    Rejistro.C_2 = Rejistro1.SelectSingleNode("C_2").InnerText.ToString()
                    Rejistro.C_3 = Rejistro1.SelectSingleNode("C_3").InnerText.ToString()
                    Rejistro.C_iso = Rejistro1.SelectSingleNode("C_iso").InnerText.ToString()



                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Rejistro
    End Function

#End Region



    Friend Shared Function InsertarRejistro(ByVal Archivo_Envio As Archivo_PaisesIso)
        Dim DatosAgregados As Boolean = False

        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Body As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

        Dim NudoTabla As XmlNode = Body.SelectSingleNode("tabla_Datos")
        Try

            Dim NudoNuevo As XmlNode = xmlDoc.CreateElement("C_Pais")
            NudoNuevo.AppendChild(xmlDoc.CreateTextNode(""))
            '________---------

            Dim NuevoNudoC_Id As XmlNode = xmlDoc.CreateElement("C_Id")
            NuevoNudoC_Id.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Id.ToString))
            NudoNuevo.AppendChild(NuevoNudoC_Id)
            '------------------
            Dim NuevoNudoC_IdPais As XmlNode = xmlDoc.CreateElement("C_IdPais")
            NuevoNudoC_IdPais.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.IdPais))
            NudoNuevo.AppendChild(NuevoNudoC_IdPais)
            '------------------
            Dim NuevoNudoC_NamePais As XmlNode = xmlDoc.CreateElement("C_NamePais")
            NuevoNudoC_NamePais.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.NamePais))
            NudoNuevo.AppendChild(NuevoNudoC_NamePais)
            '------------------
            Dim NuevoNudoC_2 As XmlNode = xmlDoc.CreateElement("C_2")
            NuevoNudoC_2.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.C_2))
            NudoNuevo.AppendChild(NuevoNudoC_2)
            '------------------
            Dim NuevoNudoC_3 As XmlNode = xmlDoc.CreateElement("C_3")
            NuevoNudoC_3.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.C_3))
            NudoNuevo.AppendChild(NuevoNudoC_3)
            '------------------
            Dim NuevoNudoC_iso As XmlNode = xmlDoc.CreateElement("C_iso")
            NuevoNudoC_iso.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.C_iso))
            NudoNuevo.AppendChild(NuevoNudoC_iso)
            '------------------



            '------------------
            NudoTabla.AppendChild(NudoNuevo)
            Application.DoEvents()
            xmlDoc.Save(RutaXMLConfigPrintInt)

            DatosAgregados = True
            Dim PARADA As New Stopwatch
            PARADA.Start()
            Do While PARADA.ElapsedMilliseconds < 500
                Application.DoEvents()
            Loop
            PARADA.Stop()
            '   Next
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        'Try
        '    'ObtenerTodos()
        '    My.Application.DoEvents()
        '    'Module_Central.CopasSeguridad(Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo)

        'Catch ex As Exception
        '    MsgBox("" & vbCr & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        'End Try

        Return DatosAgregados
    End Function

    Friend Shared Function ModificarRejistro(ByVal Valor_Id As String, ByVal Columnas As Archivo_PaisesIso) As Boolean
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
                    Rejistros.SelectSingleNode("C_IdPais").InnerText = Columnas.IdPais
                    Rejistros.SelectSingleNode("C_NamePais").InnerText = Columnas.NamePais
                    Rejistros.SelectSingleNode("C_2").InnerText = Columnas.C_2
                    Rejistros.SelectSingleNode("C_3").InnerText = Columnas.C_3
                    Rejistros.SelectSingleNode("C_iso").InnerText = Columnas.C_iso

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

    Friend Structure Archivo_PaisesIso
        Dim Id As String
        Dim IdPais As String
        Dim NamePais As String
        Dim C_2 As String
        Dim C_3 As String
        Dim C_iso As String
    End Structure

End Class

