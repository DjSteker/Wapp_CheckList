Imports System.Xml
'Imports WinApp_Morse_V01.BaseDatos.Class_XMLFrecuenciasRadio
Namespace BaseDatos


    Public Class Class_XmlAudioSSTV
        Shared Archivo As String = "\AudioSSTV.xml"
        Event Modificacion()


#Region ""

        Private Shared Function ObtenerCuerpo() As XmlNode
            Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & Archivo
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
        ''' <param name="Tabla">Nombre de la tabla</param>
        ''' <param name="Rejistro">Numero del rejistro a comprobar</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Shared Function ObtenerColumnas(ByVal Tabla As String, ByVal Rejistro As Long) As ArrayList
            Dim Columnas As New ArrayList
            Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & Archivo
            Dim xmlDoc As New XmlDocument
            '  xmlDoc.DocumentType = Xml.XmlDataDocument
            xmlDoc.Load(RutaXMLConfigPrintInt)
            '  Dim output As String = ""
            '   Dim summary As XmlNode = Nothing
            Dim CuerpoXL_1 As XmlNodeList = xmlDoc.GetElementsByTagName("body")
            Dim CuerpoXD_1 As New XmlDocument
            CuerpoXD_1.LoadXml(CuerpoXL_1.Item(0).InnerXml)

            Dim Tabla1 As XmlNodeList = CuerpoXD_1.GetElementsByTagName(Tabla)
            Dim BodyDb As XmlNode = Tabla1.Item(0)

            Dim Rejistro1 As XmlNodeList = BodyDb.ChildNodes
            '  For Each member As XmlNode In BodyDb

            For Each member1 As XmlNode In Rejistro1.Item(Rejistro)
                Columnas.Add(member1.Name)
            Next
            '  Next
            Return Columnas
        End Function

#End Region

#Region "Datos codigo"



        ''' <summary>
        ''' obtener datos
        ''' </summary>
        ''' <returns>(C_Rate, C_Bits, C_Chanels)</returns>
        Friend Shared Function ObtenerTodos() As String()

            Dim Registros(2) As String
            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(RutaXMLConfigPrintInt)
            Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

            'Dim Cerebros_Compara As XmlNode = Nudo.SelectSingleNode("C_registro")
            Try


                Dim Rejistro1 As XmlNode = Nudo.SelectSingleNode("tabla_Datos")
                Registros(0) = Rejistro1.SelectSingleNode("C_Rate").InnerText.ToString()
                Registros(1) = Rejistro1.SelectSingleNode("C_Bits").InnerText.ToString()
                Registros(2) = Rejistro1.SelectSingleNode("C_Chanels").InnerText.ToString()


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Registros
        End Function

        '<body>
        '<tabla_Datos>
        '<C_Rate></C_Rate>
        '<C_Bits></C_Bits>
        '<C_Chanels></C_Chanels>
        '</tabla_Datos>
        '</body>

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Valor_Id"></param>
        ''' <param name="Columnas"></param>
        ''' <returns></returns>
        Friend Shared Function ModificarRejistro(ByVal Datos As String()) As Boolean
            Dim Guardado As Boolean = False
            Try
                'Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & "\Contenido\ConfigPrintInt.xml"
                Dim xmlDoc As New XmlDocument
                Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
                xmlDoc.Load(RutaXMLConfigPrintInt)

                Dim Cuerpo_1 As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)


                Dim NodoDatos As XmlNode = Cuerpo_1.SelectSingleNode("tabla_Datos")


                NodoDatos.SelectSingleNode("C_Rate").InnerText = Datos(0)
                NodoDatos.SelectSingleNode("C_Bits").InnerText = Datos(1)
                NodoDatos.SelectSingleNode("C_Chanels").InnerText = Datos(2)

                xmlDoc.Save(RutaXMLConfigPrintInt)
                Guardado = True

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
#End Region


    End Class

End Namespace