Imports System.Xml




Friend Class Class_Materiales
    Shared Archivo As String = "\Materiales.xml"
    Event Modificacion()


    Friend Shared Function ObtenerCuenta() As Integer

        '   Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & Archivo
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        '   Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
        Dim Cuenta As Integer
        Try

            Cuenta = Nudo.ChildNodes.Count


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Cuenta
    End Function

    Private Shared Function ObtenerCuerpo0() As XmlNode
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        '  xmlDoc.DocumentType = Xml.XmlDataDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        '  Dim CuerpoXL_1a As XmlNodeList = 
        Return Nudo
    End Function

    ''' <summary>
    ''' Obtener las columnas del archivo y tabla
    ''' </summary>
    ''' <param name="Colunma">Nombre de la tabla</param>
    ''' <param name="Rejistros">Numero del rejistro a comprobar</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Shared Function ObtenerColumnas(ByVal Colunma As String, ByVal Rejistros As Long) As ArrayList
        Dim Columnas As New ArrayList
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        '  xmlDoc.DocumentType = Xml.XmlDataDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        '  Dim output As String = ""
        '   Dim summary As XmlNode = Nothing
        Dim CuerpoXL_1 As XmlNodeList = xmlDoc.GetElementsByTagName("body")
        Dim CuerpoXD_1 As New XmlDocument
        CuerpoXD_1.LoadXml(CuerpoXL_1.Item(0).InnerXml)

        Dim Tabla1 As XmlNodeList = CuerpoXD_1.GetElementsByTagName(Colunma)
        Dim BodyDb As XmlNode = Tabla1.Item(0)

        Dim Rejistro1 As XmlNodeList = BodyDb.ChildNodes
        '  For Each member As XmlNode In BodyDb

        For Each member1 As XmlNode In Rejistro1.Item(Rejistros)
            Columnas.Add(member1.Name)
        Next
        '  Next
        Return Columnas
    End Function



    Friend Shared Function ObtenerWhereId(ByVal Id As String) As ClassArchivo_Materiales
        Dim Rejistro As New ClassArchivo_Materiales(0, "", "", "", "", "", "", "", "", "", False)
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
        Try
            For Each Rejistro1 As XmlNode In Nudo.ChildNodes
                Dim ID_Compara As String = Rejistro1.SelectSingleNode("C_Id").InnerText.ToString.Trim
                If Id.ToString = ID_Compara Then
                    '<body>
                    '  <C_Socio>
                    '    <C_Id>0</C_Id>
                    '    <C_Nombre></C_Nombre>
                    '    <C_ResistenciaEspecifica></C_ResistenciaEspecifica>
                    '    <C_VariacionResistenciaTemperatura></C_VariacionResistenciaTemperatura>
                    '    <C_TemperaturaDilatacion></C_TemperaturaDilatacion>
                    '    <C_TemperaturaEspecifica></C_TemperaturaEspecifica>
                    '    <C_PermitividadElectrica></C_PermitividadElectrica>
                    '    <C_PermeabilidadMagnetica></C_PermeabilidadMagnetica>
                    '    <C_Activo>False</C_Activo>
                    '  </C_Socio>
                    '</body>
                    'Private m_Id As Integer
                    'Private m_Nombre As String
                    'Private m_ResistenciaEspecifica As String
                    'Private m_VariacionResistenciaTemperatura As String
                    'Private m_TemperaturaDilatacion As String
                    'Private m_TemperaturaEspecifica As String
                    'Private m_PermitividadElectrica As String
                    'Private c_PermeabilidadMagnetica As String
                    Dim RejistroTemp As New ClassArchivo_Materiales(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
                        Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_ResistenciaEspecifica").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_VariacionResistenciaTemperatura").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_TemperaturaDilatacion").InnerText(),
                        Rejistro1.SelectSingleNode("C_TemperaturaEspecifica").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_PermitividadElectrica").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_PermeabilidadMagnetica").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_TemperaturaBullicion").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_Densidad").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
                    Rejistro = RejistroTemp

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Rejistro
    End Function


    '<body>
    '  <C_Socio>
    '    <C_Id>0</C_Id>
    '    <C_Nombre></C_Nombre>
    '    <C_ResistenciaEspecifica></C_ResistenciaEspecifica>
    '    <C_VariacionResistenciaTemperatura></C_VariacionResistenciaTemperatura>
    '    <C_TemperaturaDilatacion></C_TemperaturaDilatacion>
    '    <C_TemperaturaEspecifica></C_TemperaturaEspecifica>
    '    <C_PermitividadElectrica></C_PermitividadElectrica>
    '    <C_PermeabilidadMagnetica></C_PermeabilidadMagnetica>
    '    <C_Activo>False</C_Activo>
    '  </C_Socio>
    '</body>
    Friend Shared Function ObtenerWhereTelefono2(ByVal Telefonos As String) As ClassArchivo_Materiales
        Dim Rejistro As ClassArchivo_Materiales
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
        Try
            For Each Rejistro1 As XmlNode In Nudo.ChildNodes
                Dim Compara As String = Rejistro1.SelectSingleNode("C_Telefonos").InnerText.ToString.Trim


                For indiceCaracteres As Integer = 0 To Compara.Length - Telefonos.ToString.Length
                    Dim CadenaFragmento As String = Mid(Compara.ToString, indiceCaracteres + 1, Telefonos.ToString.Length) ' dato_Compara.ToString.Skip(indiceCaracteres).Take(dato_Compara.Length).ToString()

                    If Telefonos.ToString = Mid(Compara.ToString, indiceCaracteres + 1, Telefonos.ToString.Length) Then
                        Dim RejistroTemp As New ClassArchivo_Materiales(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
                         Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_ResistenciaEspecifica").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_VariacionResistenciaTemperatura").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_TemperaturaDilatacion").InnerText(),
                        Rejistro1.SelectSingleNode("C_TemperaturaEspecifica").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_PermitividadElectrica").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_PermeabilidadMagnetica").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_TemperaturaBullicion").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_Densidad").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
                        Rejistro = RejistroTemp

                        Exit For
                    End If
                Next

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
#Disable Warning BC42104 ' La variable 'Rejistro' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
        Return Rejistro
#Enable Warning BC42104 ' La variable 'Rejistro' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
    End Function
    Friend Shared Function ObtenerWhereNif(ByVal Nif As String) As ClassArchivo_Materiales
        Dim Rejistro As New ClassArchivo_Materiales(0, "", "", "", "", "", "", "", "", "", False)
        Dim Encontrado As Boolean = False
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
        Try
            For Each Rejistro1 As XmlNode In Nudo.ChildNodes
                Dim Nif_Compara As String = Rejistro1.SelectSingleNode("C_Nif").InnerText.ToString.Trim.ToLower
                If Nif.ToString.Trim.ToLower = Nif_Compara Then
                    Rejistro = New ClassArchivo_Materiales(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString, Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString,
                                Rejistro1.SelectSingleNode("C_ResistenciaEspecifica").InnerText.ToString, Rejistro1.SelectSingleNode("C_VariacionResistenciaTemperatura").InnerText.ToString, Rejistro1.SelectSingleNode("C_TemperaturaDilatacion").InnerText,
                                Rejistro1.SelectSingleNode("C_TemperaturaEspecifica").InnerText.ToString, Rejistro1.SelectSingleNode("C_PermitividadElectrica").InnerText.ToString, Rejistro1.SelectSingleNode("C_PermeabilidadMagnetica").InnerText.ToString,
                                Rejistro1.SelectSingleNode("C_TemperaturaBullicion").InnerText.ToString(), Rejistro1.SelectSingleNode("C_Densidad").InnerText.ToString(), Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString)
                    Encontrado = True
                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return Rejistro
    End Function
    Friend Shared Function ObtenerWhereActivos(ByVal Activo As String) As List(Of ClassArchivo_Materiales)
        Dim Rejistro As New List(Of ClassArchivo_Materiales)
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
        Try
            For Each Rejistro1 As XmlNode In Nudo.ChildNodes
                Dim Compara As String = Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString.Trim.ToLower
                If Activo.ToString.Trim.ToLower = Compara Then

                    Dim RejistroTemp As New ClassArchivo_Materiales(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
                        Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_ResistenciaEspecifica").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_VariacionResistenciaTemperatura").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_TemperaturaDilatacion").InnerText(),
                        Rejistro1.SelectSingleNode("C_TemperaturaEspecifica").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_PermitividadElectrica").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_PermeabilidadMagnetica").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_TemperaturaBullicion").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_Densidad").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
                    Rejistro.Add(RejistroTemp)

                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Rejistro
    End Function


#Region "busquedas"

    'Friend Shared Function ObtenerTodos(ByVal ByVal_ValorComparador As String) As List(Of ClassArchivo_Socios)
    '    Dim ValorComparador As String = ByVal_ValorComparador.ToString.Trim.ToLower
    '    Dim Rejistro As New List(Of ClassArchivo_Socios)
    '    Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
    '    Dim xmlDoc As New XmlDocument
    '    xmlDoc.Load(RutaXMLConfigPrintInt)
    '    Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
    '    '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
    '    Try
    '        For Each Rejistro1 As XmlNode In Nudo.ChildNodes
    '            Dim coparador As New ClassArchivo_Socios(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
    '                    Rejistro1.SelectSingleNode("C_NumeroCliente").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nif").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Fechanacimiento").InnerText(),
    '                    Rejistro1.SelectSingleNode("C_Direccion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Telefono").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Email").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Estado").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Tarifa").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Pago").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Inscripcion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Renovacion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
    '            ' Dim Compara As String = Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString.Trim.ToLower
    '            If ValorComparador = coparador.Direccion.ToString.ToLower.Trim Or ValorComparador = coparador.Email.ToString.ToLower.Trim Or
    '                ValorComparador = coparador.Estado.ToString.ToLower.Trim Or ValorComparador = coparador.Fechanacimiento Or
    '                ValorComparador = coparador.Inscripcion Or ValorComparador = coparador.Nif.ToString.ToLower.Trim Or
    '                ValorComparador = coparador.Nombre.ToString.ToLower.Trim Or
    '                ValorComparador = coparador.NumeroCliente.ToString.ToLower.Trim Or ValorComparador = coparador.Pago.ToString.ToLower.Trim Or
    '                ValorComparador = coparador.Renovacion Or
    '                ValorComparador = coparador.Tarifa.ToString.ToLower.Trim Or ValorComparador = coparador.Telefono.ToString.ToLower.Trim Then




    '                Dim RejistroTemp As New ClassArchivo_Socios(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
    '                    Rejistro1.SelectSingleNode("C_NumeroCliente").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nif").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Fechanacimiento").InnerText(),
    '                    Rejistro1.SelectSingleNode("C_Direccion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Telefono").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Email").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Estado").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Tarifa").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Pago").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Inscripcion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Renovacion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
    '                Rejistro.Add(RejistroTemp)


    '            End If

    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    Return Rejistro
    'End Function

    'Friend Shared Function ObtenerWhereTodosPesonales(ByVal ByVal_ValorComparador As String) As List(Of ClassArchivo_Socios)
    '    Dim ValorComparador As String = ByVal_ValorComparador.ToString.Trim.ToLower
    '    Dim Rejistro As New List(Of ClassArchivo_Socios)
    '    Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
    '    Dim xmlDoc As New XmlDocument
    '    xmlDoc.Load(RutaXMLConfigPrintInt)
    '    Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
    '    '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
    '    Try
    '        For Each Rejistro1 As XmlNode In Nudo.ChildNodes
    '            Dim coparador As New ClassArchivo_Socios(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
    '                    Rejistro1.SelectSingleNode("C_NumeroCliente").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nif").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Fechanacimiento").InnerText(),
    '                    Rejistro1.SelectSingleNode("C_Direccion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Telefono").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Email").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Estado").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Tarifa").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Pago").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Inscripcion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Renovacion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
    '            ' Dim Compara As String = Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString.Trim.ToLower


    '            'If ValorComparador = coparador.Direccion Or ValorComparador = coparador.Email Or
    '            '    ValorComparador = coparador.Estado Or ValorComparador = coparador.Fechanacimiento Or
    '            '    ValorComparador = coparador.Inscripcion Or ValorComparador = coparador.Nif Or ValorComparador = coparador.Nombre Or
    '            '    ValorComparador = coparador.NumeroCliente Or ValorComparador = coparador.Pago Or ValorComparador = coparador.Renovacion Or
    '            '    ValorComparador = coparador.Tarifa Or ValorComparador = coparador.Telefono Then
    '            If ObtenerColector(ByVal_ValorComparador, coparador) Then



    '                Dim RejistroTemp As New ClassArchivo_Socios(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
    '                    Rejistro1.SelectSingleNode("C_NumeroCliente").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nif").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Fechanacimiento").InnerText(),
    '                    Rejistro1.SelectSingleNode("C_Direccion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Telefono").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Email").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Estado").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Tarifa").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Pago").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Inscripcion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Renovacion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
    '                Rejistro.Add(RejistroTemp)


    '            End If

    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    Return Rejistro
    'End Function

    'Friend Shared Function ObtenerWhereTodosInscripcion(ByVal ByVal_ValorComparador As String) As List(Of ClassArchivo_Socios)
    '    Dim ValorComparador As String = ByVal_ValorComparador.ToString.Trim.ToLower
    '    Dim Rejistro As New List(Of ClassArchivo_Socios)
    '    Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
    '    Dim xmlDoc As New XmlDocument
    '    xmlDoc.Load(RutaXMLConfigPrintInt)
    '    Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
    '    '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
    '    Try
    '        For Each Rejistro1 As XmlNode In Nudo.ChildNodes
    '            Dim coparador As New ClassArchivo_Socios(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
    '                    Rejistro1.SelectSingleNode("C_NumeroCliente").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nif").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Fechanacimiento").InnerText(),
    '                    Rejistro1.SelectSingleNode("C_Direccion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Telefono").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Email").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Estado").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Tarifa").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Pago").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Inscripcion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Renovacion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
    '            ' Dim Compara As String = Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString.Trim.ToLower


    '            'If ValorComparador = coparador.Direccion Or ValorComparador = coparador.Email Or
    '            '    ValorComparador = coparador.Estado Or ValorComparador = coparador.Fechanacimiento Or
    '            '    ValorComparador = coparador.Inscripcion Or ValorComparador = coparador.Nif Or ValorComparador = coparador.Nombre Or
    '            '    ValorComparador = coparador.NumeroCliente Or ValorComparador = coparador.Pago Or ValorComparador = coparador.Renovacion Or
    '            '    ValorComparador = coparador.Tarifa Or ValorComparador = coparador.Telefono Then
    '            If ObtenerColectorInscripcion(ByVal_ValorComparador, coparador) Then



    '                Dim RejistroTemp As New ClassArchivo_Socios(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
    '                    Rejistro1.SelectSingleNode("C_NumeroCliente").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nif").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Fechanacimiento").InnerText(),
    '                    Rejistro1.SelectSingleNode("C_Direccion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Telefono").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Email").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Estado").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Tarifa").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Pago").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Inscripcion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Renovacion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
    '                Rejistro.Add(RejistroTemp)


    '            End If

    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    Return Rejistro
    'End Function

    'Friend Shared Function ObtenerColectorInscripcion(ByVal ByVal_Buqueda As String, ByVal ClassArchivo_Socios As ClassArchivo_Socios) As Boolean
    '    Dim Respuesta As Boolean = False
    '    Try

    '        If ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Estado) OrElse ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Inscripcion) OrElse
    '           ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Nombre) OrElse ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.NumeroCliente) OrElse
    '           ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Pago) OrElse ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Renovacion) OrElse
    '           ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Tarifa) Then

    '            Respuesta = True

    '        End If

    '    Catch ex As Exception

    '    End Try
    '    Return Respuesta
    'End Function



    'Friend Shared Function ObtenerColector(ByVal ByVal_Buqueda As String, ByVal ClassArchivo_Socios As ClassArchivo_Socios) As Boolean
    '    Dim Respuesta As Boolean = False
    '    Try

    '        If ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Direccion) OrElse ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Email) OrElse
    '           ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Estado) OrElse ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Fechanacimiento) OrElse
    '           ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Inscripcion) OrElse ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Nif) OrElse
    '           ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Nombre) OrElse ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.NumeroCliente) OrElse
    '           ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Pago) OrElse ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Renovacion) OrElse
    '           ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Tarifa) OrElse ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Telefono) Then

    '            Respuesta = True

    '        End If

    '    Catch ex As Exception

    '    End Try
    '    Return Respuesta
    'End Function
    'Friend Shared Function ObtenerColectorPersonales(ByVal ByVal_Buqueda As String, ByVal ClassArchivo_Socios As ClassArchivo_Socios) As Boolean
    '    Dim Respuesta As Boolean = False
    '    Try

    '        If ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Direccion) OrElse ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Email) OrElse
    '           ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Estado) OrElse ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Fechanacimiento) OrElse
    '           ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Inscripcion) OrElse ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Nif) OrElse
    '           ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Nombre) OrElse ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.NumeroCliente) OrElse
    '           ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Pago) OrElse ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Renovacion) OrElse
    '           ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Tarifa) OrElse ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Telefono) Then

    '            Respuesta = True

    '        End If

    '    Catch ex As Exception

    '    End Try
    '    Return Respuesta
    'End Function
    'Friend Shared Function ObtenerColectorInscriccion(ByVal ByVal_Buqueda As String, ByVal ClassArchivo_Socios As ClassArchivo_Socios) As Boolean
    '    Dim Respuesta As Boolean = False
    '    Try

    '        If ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Direccion) OrElse ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Email) OrElse
    '           ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Estado) OrElse ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Fechanacimiento) OrElse
    '           ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Inscripcion) OrElse ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Nif) OrElse
    '           ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Nombre) OrElse ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.NumeroCliente) OrElse
    '           ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Pago) OrElse ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Renovacion) OrElse
    '           ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Tarifa) OrElse ObtenerPartes(ByVal_Buqueda, ClassArchivo_Socios.Telefono) Then

    '            Respuesta = True

    '        End If

    '    Catch ex As Exception

    '    End Try
    '    Return Respuesta
    'End Function

    'Friend Shared Function ObtenerPartes(ByVal ByVal_Buqueda As String, ByVal ClassArchivo_Socios As String) As Boolean


    '    'Friend Shared Function ObtenerPartes(ByVal ByVal_Buqueda As String, ByVal ClassArchivo_Socios As ClassArchivo_Socios) As Boolean
    '    Dim Rejistro As Boolean = False
    '    '    Try
    '    '        'If ValorComparador = coparador.Direccion Or ValorComparador = coparador.Email Or
    '    '        '   ValorComparador = coparador.Estado Or ValorComparador = coparador.Fechanacimiento Or
    '    '        '   ValorComparador = coparador.Inscripcion Or ValorComparador = coparador.Nif Or ValorComparador = coparador.Nombre Or
    '    '        '   ValorComparador = coparador.NumeroCliente Or ValorComparador = coparador.Pago Or ValorComparador = coparador.Renovacion Or
    '    '        '   ValorComparador = coparador.Tarifa Or ValorComparador = coparador.Telefono Then
    '    '        For Each columna As ClassArchivo_Socios In ClassArchivo_Socios
    '    '            columna.
    '    '        Next
    '    '        For Indice As Int16 = 0 To ClassArchivo_Socios.Length
    '    '        Next
    '    '    Catch ex As Exception

    '    '    End Try
    '    '    Return Rejistro
    '    'End Function
    '    Try
    '        For indice As Integer = 1 To (ClassArchivo_Socios.Length + 2) - (ByVal_Buqueda.Length + 1)

    '            If ByVal_Buqueda.Trim.ToUpper = Mid(ClassArchivo_Socios.Trim.ToUpper, indice, ByVal_Buqueda.Length) Then
    '                Rejistro = True
    '            End If

    '        Next



    '    Catch ex As Exception

    '    End Try
    '    Return Rejistro
    'End Function

    'Friend Shared Function ObtenerWhereNIFs(ByVal ByVal_Nif As String) As List(Of ClassArchivo_Socios)
    '    Dim Rejistro As New List(Of ClassArchivo_Socios)
    '    Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
    '    Dim xmlDoc As New XmlDocument
    '    xmlDoc.Load(RutaXMLConfigPrintInt)
    '    Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
    '    '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
    '    Try
    '        For Each Rejistro1 As XmlNode In Nudo.ChildNodes
    '            Dim Nif_Compara As String = Rejistro1.SelectSingleNode("C_Nif").InnerText.ToString.Trim.ToLower
    '            If ByVal_Nif.ToString.Trim.ToLower = Nif_Compara Then
    '                Dim RejistroTemp As New ClassArchivo_Socios(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
    '                    Rejistro1.SelectSingleNode("C_NumeroCliente").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nif").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Fechanacimiento").InnerText(),
    '                    Rejistro1.SelectSingleNode("C_Direccion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Telefono").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Email").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Estado").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Tarifa").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Pago").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Inscripcion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Renovacion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
    '                Rejistro.Add(RejistroTemp)

    '            End If

    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    Return Rejistro
    'End Function




    Friend Shared Function ObtenerWhereNombre(ByVal ByVal_Nombre As String) As List(Of ClassArchivo_Materiales)
        Dim Rejistro As New List(Of ClassArchivo_Materiales)
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
        Try
            For Each Rejistro1 As XmlNode In Nudo.ChildNodes
                Dim Nombre_Compara As String = Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString.Trim.ToLower


                If Nombre_Compara.Length >= ByVal_Nombre.Length And Nombre_Compara.Length > 0 Then

                    For index = 1 To Nombre_Compara.Length - ByVal_Nombre.Length + 1
                        Dim Caracteres As String = Mid(Nombre_Compara, index, ByVal_Nombre.Length).ToLower
                        If ByVal_Nombre.ToString.Trim.ToLower = Caracteres Then
                            'If ByVal_Nombre.ToString.Trim.ToLower = Nombre_Compara Then
                            Dim RejistroTemp As New ClassArchivo_Materiales(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
                                Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
                                Rejistro1.SelectSingleNode("C_ResistenciaEspecifica").InnerText.ToString(),
                                Rejistro1.SelectSingleNode("C_VariacionResistenciaTemperatura").InnerText.ToString(),
                                Rejistro1.SelectSingleNode("C_TemperaturaDilatacion").InnerText(),
                                Rejistro1.SelectSingleNode("C_TemperaturaEspecifica").InnerText.ToString(),
                                Rejistro1.SelectSingleNode("C_PermitividadElectrica").InnerText.ToString(),
                                Rejistro1.SelectSingleNode("C_PermeabilidadMagnetica").InnerText.ToString(),
                                Rejistro1.SelectSingleNode("C_TemperaturaBullicion").InnerText.ToString(),
                                Rejistro1.SelectSingleNode("C_Densidad").InnerText.ToString(),
                                Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
                            Rejistro.Add(RejistroTemp)
                            Exit For
                            'End If
                        End If
                    Next

                Else

                    If ByVal_Nombre.ToString.Trim.ToLower = Nombre_Compara Then
                        Dim RejistroTemp As New ClassArchivo_Materiales(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
                         Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_ResistenciaEspecifica").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_VariacionResistenciaTemperatura").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_TemperaturaDilatacion").InnerText(),
                        Rejistro1.SelectSingleNode("C_TemperaturaEspecifica").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_PermitividadElectrica").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_PermeabilidadMagnetica").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_TemperaturaBullicion").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_Densidad").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
                        Rejistro.Add(RejistroTemp)

                    End If

                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Rejistro
    End Function

    'Friend Shared Function ObtenerWhereDireccion(ByVal ByVal_1 As String) As List(Of ClassArchivo_Socios)
    '    Dim Rejistro As New List(Of ClassArchivo_Socios)
    '    Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
    '    Dim xmlDoc As New XmlDocument
    '    xmlDoc.Load(RutaXMLConfigPrintInt)
    '    Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
    '    '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
    '    Try
    '        For Each Rejistro1 As XmlNode In Nudo.ChildNodes
    '            Dim Nif_Compara As String = Rejistro1.SelectSingleNode("C_Direccion").InnerText.ToString.Trim.ToLower
    '            If ByVal_1.ToString.Trim.ToLower = Nif_Compara Then
    '                Dim RejistroTemp As New ClassArchivo_Socios(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
    '                    Rejistro1.SelectSingleNode("C_NumeroCliente").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nif").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Fechanacimiento").InnerText(),
    '                    Rejistro1.SelectSingleNode("C_Direccion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Telefono").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Email").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Estado").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Tarifa").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Pago").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Inscripcion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Renovacion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
    '                Rejistro.Add(RejistroTemp)

    '            End If

    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    Return Rejistro
    'End Function

    'Friend Shared Function ObtenerWhereNumero(ByVal ByVal_1 As String) As List(Of ClassArchivo_Socios)
    '    Dim Rejistro As New List(Of ClassArchivo_Socios)
    '    Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
    '    Dim xmlDoc As New XmlDocument
    '    xmlDoc.Load(RutaXMLConfigPrintInt)
    '    Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
    '    '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
    '    Try
    '        For Each Rejistro1 As XmlNode In Nudo.ChildNodes
    '            Dim Nif_Compara As String = Rejistro1.SelectSingleNode("C_NumeroCliente").InnerText.ToString.Trim.ToLower
    '            If ByVal_1.ToString.Trim.ToLower = Nif_Compara Then
    '                Dim RejistroTemp As New ClassArchivo_Socios(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
    '                    Rejistro1.SelectSingleNode("C_NumeroCliente").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nif").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Fechanacimiento").InnerText(),
    '                    Rejistro1.SelectSingleNode("C_Direccion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Telefono").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Email").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Estado").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Tarifa").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Pago").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Inscripcion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Renovacion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
    '                Rejistro.Add(RejistroTemp)

    '            End If

    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    Return Rejistro
    'End Function

    'Friend Shared Function ObtenerWhereTarifa(ByVal ByVal_1 As String) As ClassArchivo_Socios
    '    Dim Rejistro As ClassArchivo_Socios
    '    Dim Encontrado As Double = False
    '    Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
    '    Dim xmlDoc As New XmlDocument
    '    xmlDoc.Load(RutaXMLConfigPrintInt)
    '    Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
    '    '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
    '    Try
    '        For Each Rejistro1 As XmlNode In Nudo.ChildNodes
    '            Dim Compara As String = Rejistro1.SelectSingleNode("C_Tarifa").InnerText.ToString.Trim.ToLower
    '            If ByVal_1.ToString.Trim.ToLower = Compara Then
    '                Dim RejistroTemp As New ClassArchivo_Socios(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
    '                    Rejistro1.SelectSingleNode("C_NumeroCliente").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nif").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Fechanacimiento").InnerText(),
    '                    Rejistro1.SelectSingleNode("C_Direccion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Telefono").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Email").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Estado").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Tarifa").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Pago").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Inscripcion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Renovacion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
    '                Encontrado = True
    '                Exit For

    '            End If

    '        Next
    '        If Encontrado = False Then
    '            Rejistro = New ClassArchivo_Socios(0, "", "", "", "", "", "", "", "", "", "", "", "", False)
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    Return Rejistro
    'End Function
    'Friend Shared Function ObtenerWhereTarifas(ByVal ByVal_1 As String) As List(Of ClassArchivo_Socios)
    '    Dim Rejistro As New List(Of ClassArchivo_Socios)
    '    Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
    '    Dim xmlDoc As New XmlDocument
    '    xmlDoc.Load(RutaXMLConfigPrintInt)
    '    Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
    '    '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
    '    Try
    '        For Each Rejistro1 As XmlNode In Nudo.ChildNodes
    '            Dim Nif_Compara As String = Rejistro1.SelectSingleNode("C_Tarifa").InnerText.ToString.Trim.ToLower
    '            If ByVal_1.ToString.Trim.ToLower = Nif_Compara Then
    '                Dim RejistroTemp As New ClassArchivo_Socios(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
    '                    Rejistro1.SelectSingleNode("C_NumeroCliente").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nif").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Fechanacimiento").InnerText(),
    '                    Rejistro1.SelectSingleNode("C_Direccion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Telefono").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Email").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Estado").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Tarifa").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Pago").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Inscripcion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Renovacion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
    '                Rejistro.Add(RejistroTemp)

    '            End If

    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    Return Rejistro
    'End Function

    'Friend Shared Function ObtenerWhereFechanacimiento(ByVal ByVal_1 As String) As List(Of ClassArchivo_Socios)
    '    Dim Rejistro As New List(Of ClassArchivo_Socios)
    '    Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
    '    Dim xmlDoc As New XmlDocument
    '    xmlDoc.Load(RutaXMLConfigPrintInt)
    '    Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
    '    '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
    '    Try
    '        For Each Rejistro1 As XmlNode In Nudo.ChildNodes
    '            Dim Nif_Compara As String = Rejistro1.SelectSingleNode("C_Fechanacimiento").InnerText.ToString.Trim.ToLower
    '            If ByVal_1.ToString.Trim.ToLower = Nif_Compara Then
    '                Dim RejistroTemp As New ClassArchivo_Socios(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
    '                    Rejistro1.SelectSingleNode("C_NumeroCliente").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nif").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Fechanacimiento").InnerText(),
    '                    Rejistro1.SelectSingleNode("C_Direccion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Telefono").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Email").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Estado").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Tarifa").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Pago").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Inscripcion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Renovacion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
    '                Rejistro.Add(RejistroTemp)

    '            End If

    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    Return Rejistro
    'End Function

    'Friend Shared Function ObtenerWhereEstado(ByVal ByVal_1 As String) As List(Of ClassArchivo_Socios)
    '    Dim Rejistro As New List(Of ClassArchivo_Socios)
    '    Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
    '    Dim xmlDoc As New XmlDocument
    '    xmlDoc.Load(RutaXMLConfigPrintInt)
    '    Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
    '    '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
    '    Try
    '        For Each Rejistro1 As XmlNode In Nudo.ChildNodes
    '            Dim Nif_Compara As String = Rejistro1.SelectSingleNode("C_Estado").InnerText.ToString.Trim.ToLower
    '            If ByVal_1.ToString.Trim.ToLower = Nif_Compara Then
    '                Dim RejistroTemp As New ClassArchivo_Socios(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
    '                    Rejistro1.SelectSingleNode("C_NumeroCliente").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nif").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Fechanacimiento").InnerText(),
    '                    Rejistro1.SelectSingleNode("C_Direccion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Telefono").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Email").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Estado").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Tarifa").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Pago").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Inscripcion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Renovacion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
    '                Rejistro.Add(RejistroTemp)

    '            End If

    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    Return Rejistro
    'End Function

    'Friend Shared Function ObtenerWhereEmail(ByVal ByVal_1 As String) As List(Of ClassArchivo_Socios)
    '    Dim Rejistro As New List(Of ClassArchivo_Socios)
    '    Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
    '    Dim xmlDoc As New XmlDocument
    '    xmlDoc.Load(RutaXMLConfigPrintInt)
    '    Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
    '    '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
    '    Try
    '        For Each Rejistro1 As XmlNode In Nudo.ChildNodes
    '            Dim Nif_Compara As String = Rejistro1.SelectSingleNode("C_Email").InnerText.ToString.Trim.ToLower
    '            If ByVal_1.ToString.Trim.ToLower = Nif_Compara Then
    '                Dim RejistroTemp As New ClassArchivo_Socios(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
    '                    Rejistro1.SelectSingleNode("C_NumeroCliente").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nif").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Fechanacimiento").InnerText(),
    '                    Rejistro1.SelectSingleNode("C_Direccion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Telefono").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Email").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Estado").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Tarifa").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Pago").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Inscripcion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Renovacion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
    '                Rejistro.Add(RejistroTemp)

    '            End If

    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    Return Rejistro
    'End Function

    'Friend Shared Function ObtenerWhereTelefono(ByVal ByVal_1 As String) As List(Of ClassArchivo_Socios)
    '    Dim Rejistro As New List(Of ClassArchivo_Socios)
    '    Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
    '    Dim xmlDoc As New XmlDocument
    '    xmlDoc.Load(RutaXMLConfigPrintInt)
    '    Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
    '    '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
    '    Try
    '        For Each Rejistro1 As XmlNode In Nudo.ChildNodes
    '            Dim Nif_Compara As String = Rejistro1.SelectSingleNode("C_Telefono").InnerText.ToString.Trim.ToLower
    '            If ByVal_1.ToString.Trim.ToLower = Nif_Compara Then
    '                Dim RejistroTemp As New ClassArchivo_Socios(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
    '                    Rejistro1.SelectSingleNode("C_NumeroCliente").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nif").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Fechanacimiento").InnerText(),
    '                    Rejistro1.SelectSingleNode("C_Direccion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Telefono").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Email").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Estado").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Tarifa").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Pago").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Inscripcion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Renovacion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
    '                Rejistro.Add(RejistroTemp)

    '            End If

    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    Return Rejistro
    'End Function


    'Friend Shared Function ObtenerWhereFechaInscripccion(ByVal ByVal_1 As String) As List(Of ClassArchivo_Socios)
    '    Dim Rejistro As New List(Of ClassArchivo_Socios)
    '    Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
    '    Dim xmlDoc As New XmlDocument
    '    xmlDoc.Load(RutaXMLConfigPrintInt)
    '    Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
    '    '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
    '    Try
    '        For Each Rejistro1 As XmlNode In Nudo.ChildNodes
    '            Dim Nif_Compara As String = Rejistro1.SelectSingleNode("C_Inscripcion").InnerText.ToString.Trim.ToLower
    '            If ByVal_1.ToString.Trim.ToLower = Nif_Compara Then
    '                Dim RejistroTemp As New ClassArchivo_Socios(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
    '                    Rejistro1.SelectSingleNode("C_NumeroCliente").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nif").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Fechanacimiento").InnerText(),
    '                    Rejistro1.SelectSingleNode("C_Direccion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Telefono").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Email").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Estado").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Tarifa").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Pago").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Inscripcion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Renovacion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
    '                Rejistro.Add(RejistroTemp)

    '            End If

    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    Return Rejistro
    'End Function

    'Friend Shared Function ObtenerWherePago(ByVal ByVal_1 As String) As List(Of ClassArchivo_Socios)
    '    Dim Rejistro As New List(Of ClassArchivo_Socios)
    '    Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
    '    Dim xmlDoc As New XmlDocument
    '    xmlDoc.Load(RutaXMLConfigPrintInt)
    '    Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
    '    '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
    '    Try
    '        For Each Rejistro1 As XmlNode In Nudo.ChildNodes
    '            Dim Nif_Compara As String = Rejistro1.SelectSingleNode("C_Pago").InnerText.ToString.Trim.ToLower
    '            If ByVal_1.ToString.Trim.ToLower = Nif_Compara Then
    '                Dim RejistroTemp As New ClassArchivo_Socios(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
    '                    Rejistro1.SelectSingleNode("C_NumeroCliente").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Nif").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Fechanacimiento").InnerText(),
    '                    Rejistro1.SelectSingleNode("C_Direccion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Telefono").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Email").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Estado").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Tarifa").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Pago").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Inscripcion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Renovacion").InnerText.ToString(),
    '                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
    '                Rejistro.Add(RejistroTemp)

    '            End If

    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    Return Rejistro
    'End Function

#End Region

#Region "AAAA"



    Friend Shared Function ObtenerWhereBusqueda(ByVal DatosBusqueda As ClassArchivo_Materiales) As List(Of ClassArchivo_Materiales)
        Dim RejistroLista As New List(Of ClassArchivo_Materiales)
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
        Try

            Dim Lista As New ArrayList









            'Dim ColumnasXml As New ArrayList
            'Dim ColumnasStructure As New ArrayList
            'If DatosBusqueda.Id <> String.Empty Then : ColumnasXml.Add("C_Id") : ColumnasStructure.Add(DatosBusqueda.Id.ToString.ToLower) : End If
            'If DatosBusqueda.Nombre <> String.Empty Then : ColumnasXml.Add("C_Nombre") : ColumnasStructure.Add(DatosBusqueda.Nombre.ToString.ToLower) : End If
            'If DatosBusqueda.Apellidos <> String.Empty Then : ColumnasXml.Add("C_Apellidos") : ColumnasStructure.Add(DatosBusqueda.Apellidos.ToString.ToLower) : End If
            'If DatosBusqueda.Nif <> String.Empty Then : ColumnasXml.Add("C_Nif") : ColumnasStructure.Add(DatosBusqueda.Nif.ToString.ToLower) : End If
            'If DatosBusqueda.Poblacion <> String.Empty Then : ColumnasXml.Add("C_CPostal") : ColumnasStructure.Add(DatosBusqueda.CPostal.ToString.ToLower) : End If
            'If DatosBusqueda.Poblacion <> String.Empty Then : ColumnasXml.Add("C_Poblacion") : ColumnasStructure.Add(DatosBusqueda.Poblacion.ToString.ToLower) : End If
            'If DatosBusqueda.Poblacion <> String.Empty Then : ColumnasXml.Add("C_Calle") : ColumnasStructure.Add(DatosBusqueda.Calle.ToString.ToLower) : End If
            'If DatosBusqueda.Telefonos <> String.Empty Then : ColumnasXml.Add("C_Telefonos") : ColumnasStructure.Add(DatosBusqueda.Telefonos.ToString.ToLower) : End If





            'For Each RejistroNudo As XmlNode In Nudo.ChildNodes
            '    Dim Encontrados As Int16 = 0
            '    For Indice As Int64 = 0 To ColumnasXml.Count - 1
            '        Dim dato_Compara As String = RejistroNudo.SelectSingleNode(ColumnasXml.Item(Indice)).InnerText.ToString.Trim.ToLower
            '        If ColumnasStructure.Item(Indice).ToString = dato_Compara Then
            '            Encontrados += 1

            '        ElseIf ColumnasStructure.Item(Indice).ToString.Length < dato_Compara.Length
            '            For indiceCaracteres As Integer = 0 To dato_Compara.Length - ColumnasStructure.Item(Indice).ToString.Length
            '                Dim CadenaFragmento As String = Mid(dato_Compara.ToString, indiceCaracteres + 1, ColumnasStructure.Item(Indice).ToString.Length) ' dato_Compara.ToString.Skip(indiceCaracteres).Take(dato_Compara.Length).ToString()

            '                If ColumnasStructure.Item(Indice).ToString = Mid(dato_Compara.ToString, indiceCaracteres + 1, ColumnasStructure.Item(Indice).ToString.Length) Then
            '                    Encontrados += 1
            '                    Exit For
            '                End If
            '            Next

            '        End If

            '    Next

            '    If Encontrados = ColumnasXml.Count Then
            '        Dim Rejistro As New Archivo_Clientes
            '        Rejistro.Id = RejistroNudo.SelectSingleNode("C_Id").InnerText.ToString.Trim
            '        Rejistro.Nombre = RejistroNudo.SelectSingleNode("C_Nombre").InnerText.ToString
            '        Rejistro.Apellidos = RejistroNudo.SelectSingleNode("C_Apellidos").InnerText.ToString
            '        Rejistro.Nif = RejistroNudo.SelectSingleNode("C_Nif").InnerText.ToString
            '        ' Rejistro.Direccion = Rejistro1.SelectSingleNode("C_Direccion").InnerText
            '        Rejistro.CPostal = RejistroNudo.SelectSingleNode("C_CPostal").InnerText.ToString
            '        Rejistro.Poblacion = RejistroNudo.SelectSingleNode("C_Poblacion").InnerText.ToString
            '        Rejistro.Calle = RejistroNudo.SelectSingleNode("C_Calle").InnerText.ToString
            '        Rejistro.DireccionValida = RejistroNudo.SelectSingleNode("C_DireccionValida").InnerText.ToString
            '        Rejistro.Email = RejistroNudo.SelectSingleNode("C_Email").InnerText.ToString
            '        Rejistro.Telefonos = RejistroNudo.SelectSingleNode("C_Telefonos").InnerText.ToString
            '        Rejistro.Provincia = RejistroNudo.SelectSingleNode("C_Provincia").InnerText.ToString
            '        Rejistro.Pais = RejistroNudo.SelectSingleNode("C_Pais").InnerText.ToString
            '        RejistroLista.Add(Rejistro)
            '    End If

            'Next



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return RejistroLista
    End Function



    Friend Shared Function GetAll_Errores() As Boolean
        Dim Lista As Boolean = False
        'Dim Rejistro As New ClassArchivo_Socios(0, "", "", "", "", "", "", "", False)
        'Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        'Dim xmlDoc As New XmlDocument
        'xmlDoc.Load(RutaXMLConfigPrintInt)
        'Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        ''   Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
        'Try
        '    For Each Rejistro_Nudo As XmlNode In Nudo.ChildNodes


        '        Rejistro.Id = Rejistro_Nudo.SelectSingleNode("C_Id").InnerText
        '        Rejistro.NumeroCliente = Rejistro_Nudo.SelectSingleNode("C_NumeroCliente").InnerText
        '        Rejistro.Nombre = Rejistro_Nudo.SelectSingleNode("C_Nombre").InnerText
        '        Rejistro.Nif = Rejistro_Nudo.SelectSingleNode("C_Nif").InnerText
        '        Rejistro.Fechanacimiento = Rejistro_Nudo.SelectSingleNode("C_Fechanacimiento").InnerText
        '        Rejistro.Direccion = Rejistro_Nudo.SelectSingleNode("C_Direccion").InnerText
        '        Rejistro.Telefono = Rejistro_Nudo.SelectSingleNode("C_Telefono").InnerText
        '        Rejistro.Email = Rejistro_Nudo.SelectSingleNode("C_Email").InnerText
        '        Rejistro.Estado = Rejistro_Nudo.SelectSingleNode("C_Estado").InnerText
        '        Rejistro.Tarifa = Rejistro_Nudo.SelectSingleNode("C_Tarifa").InnerText
        '        Rejistro.Pago = Rejistro_Nudo.SelectSingleNode("C_Pago").InnerText
        '        Rejistro.Inscripcion = Rejistro_Nudo.SelectSingleNode("C_Inscripcion").InnerText
        '        Rejistro.Renovacion = Rejistro_Nudo.SelectSingleNode("C_Renovacion").InnerText
        '        Rejistro.Activo = Rejistro_Nudo.SelectSingleNode("C_Activo").InnerText
        '        'Lista.Add(Rejistro)

        '    Next
        'Catch ex As Exception
        '    Lista = True
        '    MsgBox(ex.Message)

        'End Try
        Return Lista
    End Function


    Friend Shared Function ObtenerTodos1() As List(Of ClassArchivo_Materiales)
        Dim Lista As New List(Of ClassArchivo_Materiales)
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        '   Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
        Try
            For Each Rejistro1 As XmlNode In Nudo.ChildNodes



                Dim Rejistro As New ClassArchivo_Materiales(Rejistro1.SelectSingleNode("C_Id").InnerText,
                      Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_ResistenciaEspecifica").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_VariacionResistenciaTemperatura").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_TemperaturaDilatacion").InnerText(),
                        Rejistro1.SelectSingleNode("C_TemperaturaEspecifica").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_PermitividadElectrica").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_PermeabilidadMagnetica").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_TemperaturaBullicion").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_Densidad").InnerText.ToString(),
                        Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())

                'Rejistro.Activo = Rejistro_Nudo.SelectSingleNode("C_Activo").InnerText
                Lista.Add(Rejistro)

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Lista
    End Function

    Friend Shared Function ExisteId(ByVal Id As String) As Boolean
        Dim Existe As Boolean = False
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        '    Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
        Try
            For Each Rejistro1 As XmlNode In Nudo.ChildNodes
                Dim Comparador As String = Rejistro1.SelectSingleNode("C_Id").InnerText
                If Comparador = Id Then
                    Existe = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Existe
    End Function

    Friend Shared Function ExisteNombre(ByVal Id As String) As Boolean
        Dim Existe As Boolean = False
        Dim ValorSelectivo As String = Id.ToString.Trim.ToUpper
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        '    Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
        Try
            For Each Rejistro1 As XmlNode In Nudo.ChildNodes
                Dim Comparador As String = Rejistro1.SelectSingleNode("C_Nombre").InnerText
                If Comparador.ToString.Trim.ToUpper = ValorSelectivo Then
                    Existe = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Existe
    End Function


    Friend Shared Function InsertarRejistro(ByVal Archivo_Envio As ClassArchivo_Materiales)
        Dim Datos1 As New List(Of ClassArchivo_Materiales)

        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        '      Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)

        Try

            Dim NuevoNudo As XmlNode = xmlDoc.CreateElement("C_Material")
            NuevoNudo.AppendChild(xmlDoc.CreateTextNode(""))

            Dim NuevoNudoC_Id As XmlNode = xmlDoc.CreateElement("C_Id")
            NuevoNudoC_Id.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Id.ToString))
            NuevoNudo.AppendChild(NuevoNudoC_Id)
            '------------------
            Dim NuevoNudoC_Nombre As XmlNode = xmlDoc.CreateElement("C_Nombre")
            NuevoNudoC_Nombre.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Nombre))
            NuevoNudo.AppendChild(NuevoNudoC_Nombre)
            '------------------

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
            Dim NuevoNudoC_Nif As XmlNode = xmlDoc.CreateElement("C_ResistenciaEspecifica")
            NuevoNudoC_Nif.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.ResistenciaEspecifica))
            NuevoNudo.AppendChild(NuevoNudoC_Nif)
            '------------------

            Dim NuevoNudoC_Fechanacimiento As XmlNode = xmlDoc.CreateElement("C_VariacionResistenciaTemperatura")
            NuevoNudoC_Fechanacimiento.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.VariacionResistenciaTemperatura))
            NuevoNudo.AppendChild(NuevoNudoC_Fechanacimiento)
            '------------------
            Dim NuevoNudoC_Direccion As XmlNode = xmlDoc.CreateElement("C_TemperaturaDilatacion")
            NuevoNudoC_Direccion.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.TemperaturaDilatacion))
            NuevoNudo.AppendChild(NuevoNudoC_Direccion)
            '------------------
            Dim NuevoNudoC_Telefono As XmlNode = xmlDoc.CreateElement("C_TemperaturaEspecifica")
            NuevoNudoC_Telefono.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.TemperaturaEspecifica))
            NuevoNudo.AppendChild(NuevoNudoC_Telefono)
            '------------------
            Dim NuevoNudoC_Email As XmlNode = xmlDoc.CreateElement("C_PermitividadElectrica")
            NuevoNudoC_Email.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.PermitividadElectrica))
            NuevoNudo.AppendChild(NuevoNudoC_Email)
            '------------------
            Dim NuevoNudoC_Estado As XmlNode = xmlDoc.CreateElement("C_PermeabilidadMagnetica")
            NuevoNudoC_Estado.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.PermeabilidadMagnetica))
            NuevoNudo.AppendChild(NuevoNudoC_Estado)
            '------------------
            Dim NuevoNudoC_Tarifa As XmlNode = xmlDoc.CreateElement("C_TemperaturaBullicion")
            NuevoNudoC_Tarifa.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.TemperaturaBullicion))
            NuevoNudo.AppendChild(NuevoNudoC_Tarifa)
            '------------------
            '------------------
            Dim NuevoNudoC_Densidad As XmlNode = xmlDoc.CreateElement("C_Densidad")
            NuevoNudoC_Densidad.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Densidad))
            NuevoNudo.AppendChild(NuevoNudoC_Densidad)
            '------------------
            Dim NuevoNudoC_Activo As XmlNode = xmlDoc.CreateElement("C_Activo")
            NuevoNudoC_Activo.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Activo))
            NuevoNudo.AppendChild(NuevoNudoC_Activo)
            '------------------

            NudoTabla.AppendChild(NuevoNudo)

            xmlDoc.Save(RutaXMLConfigPrintInt)
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

        Return Datos1
    End Function

    Friend Shared Function ModificarRejistro(ByVal Valor_Id As String, ByVal Columnas As ClassArchivo_Materiales) As Boolean
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
                    Rejistros.SelectSingleNode("C_Id").InnerText = Columnas.Id
                    Rejistros.SelectSingleNode("C_Nombre").InnerText = Columnas.Nombre
                    Rejistros.SelectSingleNode("C_ResistenciaEspecifica").InnerText = Columnas.ResistenciaEspecifica
                    Rejistros.SelectSingleNode("C_VariacionResistenciaTemperatura").InnerText = Columnas.VariacionResistenciaTemperatura
                    '  Rejistros.SelectSingleNode("C_Direccion").InnerText = Columnas.Direccion
                    Rejistros.SelectSingleNode("C_TemperaturaDilatacion").InnerText = Columnas.TemperaturaDilatacion
                    Rejistros.SelectSingleNode("C_TemperaturaEspecifica").InnerText = Columnas.TemperaturaEspecifica
                    Rejistros.SelectSingleNode("C_PermitividadElectrica").InnerText = Columnas.PermitividadElectrica
                    Rejistros.SelectSingleNode("C_PermeabilidadMagnetica").InnerText = Columnas.PermeabilidadMagnetica
                    Rejistros.SelectSingleNode("C_TemperaturaBullicion").InnerText = Columnas.TemperaturaBullicion
                    Rejistros.SelectSingleNode("C_Densidad").InnerText = Columnas.Densidad

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


    Friend Shared Function EliminarRejistro0(ByVal ByVal_Id As String) As Boolean
        Dim Guardado As Boolean = False
        Try
            Dim xmlDoc As New XmlDocument
            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
            xmlDoc.Load(RutaXMLConfigPrintInt)

            Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
            Dim Cuerpo_Cliente As XmlNode = CuerpoXL_1.SelectSingleNode("C_Material")

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

#End Region
    '<body>
    '  <C_Socio>
    '    <C_Id>0</C_Id>
    '    <C_Nombre></C_Nombre>
    '    <C_ResistenciaEspecifica></C_ResistenciaEspecifica>
    '    <C_VariacionResistenciaTemperatura></C_VariacionResistenciaTemperatura>
    '    <C_TemperaturaDilatacion></C_TemperaturaDilatacion>
    '    <C_TemperaturaEspecifica></C_TemperaturaEspecifica>
    '    <C_PermitividadElectrica></C_PermitividadElectrica>
    '    <C_PermeabilidadMagnetica></C_PermeabilidadMagnetica>
    '    <C_Activo>False</C_Activo>
    '  </C_Socio>
    '</body>
    'Private m_Id As Integer
    'Private m_Nombre As String
    'Private m_ResistenciaEspecifica As String
    'Private m_VariacionResistenciaTemperatura As String
    'Private m_TemperaturaDilatacion As String
    'Private m_TemperaturaEspecifica As String
    'Private m_PermitividadElectrica As String
    'Private c_PermeabilidadMagnetica As String


    Friend Class ClassArchivo_Materiales


        Friend Sub New(ByVal C_Id As Integer, ByVal c_Nombre As String, ByVal c_ResistenciaEspecifica As String, ByVal c_VariacionResistenciaTemperatura As String,
                   ByVal c_TemperaturaDilatacion As String, ByVal c_TemperaturaEspecifica As String, ByVal c_PermitividadElectrica As String, ByVal c_PermeabilidadMagnetica As String,
                       ByVal c_TemperaturaBullicion As String, ByVal C_Densidad As String, ByVal C_Activo As Boolean)
            'Id, Nombre, Nif, Direccion,
            'Telefono, Email, Estado, Tarifa,
            'Pago, Inscripcion, Renovacion
            Try
                Me.Densidad = C_Densidad
            Catch ex As Exception
                Me.Densidad = "-- --"
            End Try
            Try
                Me.Id = C_Id
            Catch ex As Exception
                Me.Id = "-- --"
            End Try
            Try
                Me.Nombre = c_Nombre
            Catch ex As Exception
                Me.Nombre = "-- --"
            End Try
            Try
                Me.ResistenciaEspecifica = c_ResistenciaEspecifica
            Catch ex As Exception
                Me.ResistenciaEspecifica = "-- --"
            End Try
            Try
                Me.TemperaturaDilatacion = c_TemperaturaDilatacion
            Catch ex As Exception
                Me.TemperaturaDilatacion = "-- --"
            End Try
            Try
                Me.TemperaturaEspecifica = c_TemperaturaEspecifica
            Catch ex As Exception
                Me.TemperaturaEspecifica = "-- --"
            End Try
            Try
                Me.PermitividadElectrica = c_PermitividadElectrica
            Catch ex As Exception
                Me.PermitividadElectrica = "-- --"
            End Try
            Try
                Me.PermeabilidadMagnetica = c_PermeabilidadMagnetica
            Catch ex As Exception
                Me.PermeabilidadMagnetica = "-- --"
            End Try
            Try
                Me.VariacionResistenciaTemperatura = c_VariacionResistenciaTemperatura
            Catch ex As Exception
                Me.VariacionResistenciaTemperatura = "-- --"
            End Try
            Try
                Me.TemperaturaBullicion = c_TemperaturaBullicion
            Catch ex As Exception
                Me.TemperaturaBullicion = "-- --"
            End Try
            Try
                Me.Activo = C_Activo
            Catch ex As Exception
                Me.Activo = "-- --"
            End Try
        End Sub

        Private m_Id As Integer
        Private m_Nombre As String
        Private m_ResistenciaEspecifica As String
        Private m_VariacionResistenciaTemperatura As String
        Private m_TemperaturaDilatacion As String
        Private m_TemperaturaEspecifica As String
        Private m_PermitividadElectrica As String
        Private m_PermeabilidadMagnetica As String
        Private m_TemperaturaBullicion As String
        Private m_Densidad As String

        Private m_Activo As Boolean



        Friend Property Id() As Integer
            Get
                Return m_Id
            End Get
            Set(value As Integer)
                m_Id = value
            End Set
        End Property
        Friend Property Nombre() As String
            Get
                Return m_Nombre
            End Get
            Set(value As String)
                m_Nombre = value
            End Set
        End Property
        Friend Property ResistenciaEspecifica() As String
            Get
                Return m_ResistenciaEspecifica
            End Get
            Set(value As String)
                m_ResistenciaEspecifica = value
            End Set
        End Property
        Friend Property TemperaturaDilatacion() As String
            Get
                Return m_TemperaturaDilatacion
            End Get
            Set(value As String)
                m_TemperaturaDilatacion = value
            End Set
        End Property
        Friend Property TemperaturaEspecifica() As String
            Get
                Return m_TemperaturaEspecifica
            End Get
            Set(value As String)
                m_TemperaturaEspecifica = value
            End Set
        End Property
        Friend Property PermitividadElectrica() As String
            Get
                Return m_PermitividadElectrica
            End Get
            Set(value As String)
                m_PermitividadElectrica = value
            End Set
        End Property
        Friend Property PermeabilidadMagnetica() As String
            Get
                Return m_PermeabilidadMagnetica
            End Get
            Set(value As String)
                m_PermeabilidadMagnetica = value
            End Set
        End Property
        Friend Property VariacionResistenciaTemperatura() As String
            Get
                Return m_VariacionResistenciaTemperatura
            End Get
            Set(value As String)
                m_VariacionResistenciaTemperatura = value
            End Set
        End Property
        Friend Property TemperaturaBullicion() As String
            Get
                Return m_TemperaturaBullicion
            End Get
            Set(value As String)
                m_TemperaturaBullicion = value
            End Set
        End Property

        Friend Property Densidad() As String
            Get
                Return m_Densidad
            End Get
            Set(value As String)
                m_Densidad = value
            End Set
        End Property

        Friend Property Activo() As Boolean
            Get
                Return m_Activo
            End Get
            Set(value As Boolean)
                m_Activo = value
            End Set
        End Property

    End Class



End Class


