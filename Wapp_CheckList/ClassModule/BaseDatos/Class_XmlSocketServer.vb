Imports System.Xml

Namespace BaseDatos


    Public Class Class_XmlSocketServer

        Shared Archivo As String = "\BaseDatos\DB_ConfigSocket.xml"
        Event Modificacion()

#Region "Extras"
        Private Shared Function ObtenerCuerpo0() As XmlNode
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
        Friend Shared Function ObtenerColumnas0(ByVal Tabla As String, ByVal Rejistro As Long) As ArrayList
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

#Region "Extras PRO"

        Friend Shared Function ObtenerWhereId0(ByVal Id As String) As Archivo_Clientes
            Dim Enviado As New Archivo_Clientes
            Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & Archivo
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(RutaXMLConfigPrintInt)
            Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("tabla1").Item(0)
            Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("RejTr").Item(0)
            Try
                For Each Rejistro1 As XmlNode In NudoTabla.ChildNodes

                    Dim ID_Compara As String = Rejistro1.SelectSingleNode("PuertoTCP").InnerText
                    If Id = ID_Compara Then
                        Enviado.IpLocalTCP = Rejistro1.SelectSingleNode("IpLocalTCP").InnerText
                        Enviado.IpDestinoTCP = Rejistro1.SelectSingleNode("IpDestinoTCP").InnerText
                        Enviado.PuertoTCP = Rejistro1.SelectSingleNode("PuertoTCP").InnerText
                        Enviado.IpDestinoUDP = Rejistro1.SelectSingleNode("IpDestinoUDP").InnerText
                        Enviado.PuertoUDP = Rejistro1.SelectSingleNode("PuertoUDP").InnerText
                        Enviado.Nick = Rejistro1.SelectSingleNode("Nick").InnerText
                        Exit For
                    End If

                Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Enviado
        End Function

        Friend Shared Function ObtenerTodos0() As List(Of Archivo_Clientes)
            Dim Lista As New List(Of Archivo_Clientes)
            Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & Archivo
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(RutaXMLConfigPrintInt)
            Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("tabla1").Item(0)
            Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("RejTr").Item(0)
            Try
                For Each Rejistro_Nudo As XmlNode In NudoTabla.ChildNodes

                    Dim Rejistro As New Archivo_Clientes '= Rejistro1.SelectSingleNode("C_Id").InnerText
                    Rejistro.IpLocalTCP = Rejistro_Nudo.SelectSingleNode("IpLocalTCP").InnerText
                    Rejistro.IpDestinoTCP = Rejistro_Nudo.SelectSingleNode("IpDestinoTCP").InnerText
                    Rejistro.PuertoTCP = Rejistro_Nudo.SelectSingleNode("PuertoTCP").InnerText
                    Rejistro.IpDestinoUDP = Rejistro_Nudo.SelectSingleNode("IpDestinoUDP").InnerText
                    Rejistro.PuertoUDP = Rejistro_Nudo.SelectSingleNode("PuertoUDP").InnerText
                    Rejistro.Nick = Rejistro_Nudo.SelectSingleNode("Nick").InnerText
                    Lista.Add(Rejistro)

                Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Lista
        End Function

        Friend Shared Function InsertarRejistro0(ByVal Archivo_Envio As Archivo_Clientes)
            Dim Datos1 As New List(Of Archivo_Clientes)

            Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & Archivo
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(RutaXMLConfigPrintInt)
            Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("tabla1").Item(0)
            '   Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("RejTr").Item(0)

            Try


                Dim NuevoNudo As XmlNode = xmlDoc.CreateElement("RejTr")
                NuevoNudo.AppendChild(xmlDoc.CreateTextNode(""))
                '------------------
                Dim NuevoNudoC_IpLocalTCP As XmlNode = xmlDoc.CreateElement("IpLocalTCP")
                NuevoNudoC_IpLocalTCP.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.PuertoTCP.ToString))
                NuevoNudo.AppendChild(NuevoNudoC_IpLocalTCP)
                '------------------
                Dim NuevoNudoC_IpDestinoTCP As XmlNode = xmlDoc.CreateElement("IpDestinoTCP")
                NuevoNudoC_IpDestinoTCP.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.PuertoTCP.ToString))
                NuevoNudo.AppendChild(NuevoNudoC_IpDestinoTCP)
                '------------------
                Dim NuevoNudoC_PuertoTCP As XmlNode = xmlDoc.CreateElement("PuertoTCP")
                NuevoNudoC_PuertoTCP.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.PuertoTCP.ToString))
                NuevoNudo.AppendChild(NuevoNudoC_PuertoTCP)
                '------------------
                Dim NuevoNudoC_IpDestinoUDP As XmlNode = xmlDoc.CreateElement("IpDestinoUDP")
                NuevoNudoC_IpDestinoUDP.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.PuertoUDP))
                NuevoNudo.AppendChild(NuevoNudoC_IpDestinoUDP)
                '------------------
                Dim NuevoNudoC_PuertoUDP As XmlNode = xmlDoc.CreateElement("PuertoUDP")
                NuevoNudoC_PuertoUDP.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.PuertoUDP))
                NuevoNudo.AppendChild(NuevoNudoC_PuertoUDP)
                '------------------
                Dim NuevoNudoC_Nick As XmlNode = xmlDoc.CreateElement("Nick")
                NuevoNudoC_PuertoUDP.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.PuertoUDP))
                NuevoNudo.AppendChild(NuevoNudoC_Nick)

                Nudo.AppendChild(NuevoNudo)

                xmlDoc.Save(My.Application.Info.DirectoryPath & Archivo)
                '   Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            Return Datos1
        End Function

        Friend Shared Function ExisteId0(ByVal Id As String) As Boolean
            Dim Existe As Boolean = False
            Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & Archivo
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(RutaXMLConfigPrintInt)
            Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("tabla1").Item(0)
            Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("RejTr").Item(0)
            Try
                For Each Rejistro1 As XmlNode In NudoTabla.ChildNodes
                    Dim Comparador As String = Rejistro1.SelectSingleNode("PuertoTCP").InnerText
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

        Friend Shared Function ModificarRejistro0(ByVal Tabla As String, ByVal SeleccColumna As String, ByVal SelecValor As String, ByVal Clolumnas As Archivo_Clientes) As Boolean
            Dim Guardado As Boolean = False
            Try
                'Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & "\Contenido\ConfigPrintInt.xml"
                Dim xmlDoc As New XmlDocument
                xmlDoc.Load(My.Application.Info.DirectoryPath & Archivo)
                'Dim output As String = ""
                'Dim summary As XmlNode = Nothing
                'Dim name As String = ""


                '  xmlDoc.DocumentType = Xml.XmlDataDocument
                xmlDoc.Load(My.Application.Info.DirectoryPath & Archivo)

                Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("tabla1").Item(0)



                Dim CuerpoXL_1a As XmlNodeList = CuerpoXL_1.SelectSingleNode(Tabla).ChildNodes

                ' <Id></Id>
                '<C_Nombre></C_Nombre>
                '<C_Destino></C_Destino>
                '<C_PuntoDescarga></C_PuntoDescarga>


                For Each Rejistros As XmlNode In CuerpoXL_1a

                    Dim Comparador As String = Rejistros.SelectSingleNode(SeleccColumna).InnerText

                    If Comparador = SelecValor Then
                        Rejistros.SelectSingleNode("IpLocalTCP").InnerText = Clolumnas.IpLocalTCP
                        Rejistros.SelectSingleNode("IpDestinoTCP").InnerText = Clolumnas.IpDestinoTCP
                        Rejistros.SelectSingleNode("PuertoTCP").InnerText = Clolumnas.PuertoTCP
                        Rejistros.SelectSingleNode("IpDestinoUDP").InnerText = Clolumnas.IpDestinoUDP
                        Rejistros.SelectSingleNode("PuertoUDP").InnerText = Clolumnas.PuertoUDP
                        Rejistros.SelectSingleNode("Nick").InnerText = Clolumnas.Nick
                    End If

                Next

                xmlDoc.Save(My.Application.Info.DirectoryPath & Archivo)

                Guardado = True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Guardado
        End Function

        Friend Shared Function EliminarRejistro0(ByVal SeleccColumna As String, ByVal SelecValor As String) As Boolean
            Dim Guardado As Boolean = False
            Try
                Dim xmlDoc As New XmlDocument
                xmlDoc.Load(My.Application.Info.DirectoryPath & Archivo)
                'xmlDoc.Load(My.Application.Info.DirectoryPath & Archivo)

                Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("tabla1").Item(0)
                Dim CuerpoXL_1a As XmlNode = CuerpoXL_1.SelectSingleNode("RejTr")

                For Each Rejistros As XmlNode In CuerpoXL_1a
                    Dim Comparador As String = Rejistros.SelectSingleNode(SeleccColumna).InnerText
                    If Comparador = SelecValor Then
                        CuerpoXL_1a.RemoveChild(Rejistros)
                    End If
                Next

                xmlDoc.Save(My.Application.Info.DirectoryPath & Archivo)

                Guardado = True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Guardado
        End Function


#End Region


        Friend Shared Function ObtenerDatosServer() As Archivo_Clientes
            Dim Enviado As New Archivo_Clientes
            Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & Archivo


            If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Datos\BaseDatos") = False Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Datos\BaseDatos")
            End If

            If My.Computer.FileSystem.FileExists(RutaXMLConfigPrintInt) = False Then

                Dim Texto As String = "<?xml version=""1.0"" encoding=""utf-8"" ?>" &
        "<tabla1>" &
              " <RejTrS>" &
              "     <IpLocalTCP>0.0.0.0</IpLocalTCP>" &
              "     <IpDestinoTCP>0.0.0.0</IpDestinoTCP>" &
              "     <BufferTCP>2048</BufferTCP>" &
              "     <PuertoTCP>27033</PuertoTCP>" &
              "     <IpDestinoUDP>0.0.0.0</IpDestinoUDP>" &
              "     <PuertoUDP>27033</PuertoUDP>" &
              "     <ConexionesMaximas>256</ConexionesMaximas>" &
              "     <Nick>Server</Nick>" &
              " </RejTrS>" &
              " <RejTr>" &
              "     <IpLocalTCP>0.0.0.0</IpLocalTCP>" &
              "     <IpDestinoTCP>0.0.0.0</IpDestinoTCP>" &
              "     <BufferTCP>2048</BufferTCP>" &
              "     <PuertoTCP>27033</PuertoTCP>" &
              "     <IpDestinoUDP>0.0.0.0</IpDestinoUDP>" &
              "     <PuertoUDP>27033</PuertoUDP>" &
              "     <ConexionesMaximas>256</ConexionesMaximas>" &
              "     <Nick>Cliente</Nick>" &
              " </RejTr>" &
        "</tabla1>"
                My.Computer.FileSystem.WriteAllText(RutaXMLConfigPrintInt, Texto, False)
            End If


            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(RutaXMLConfigPrintInt)
            Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("tabla1").Item(0)
            Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("RejTrS").Item(0)
            Try
                Enviado.IpLocalTCP = NudoTabla.SelectSingleNode("IpLocalTCP").InnerText
                Enviado.IpDestinoTCP = NudoTabla.SelectSingleNode("IpDestinoTCP").InnerText
                Enviado.BufferTCP = NudoTabla.SelectSingleNode("BufferTCP").InnerText
                Enviado.PuertoTCP = NudoTabla.SelectSingleNode("PuertoTCP").InnerText
                Enviado.IpDestinoUDP = NudoTabla.SelectSingleNode("IpDestinoUDP").InnerText
                Enviado.PuertoUDP = NudoTabla.SelectSingleNode("PuertoUDP").InnerText
                Enviado.ConexionesMaximas = NudoTabla.SelectSingleNode("ConexionesMaximas").InnerText
                Enviado.Nick = NudoTabla.SelectSingleNode("Nick").InnerText
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Enviado
        End Function

        Friend Shared Function ModificarDatosServer(ByVal Columnas As Archivo_Clientes) As Boolean
            Dim Guardado As Boolean = False
            Try
                'Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & "\Contenido\ConfigPrintInt.xml"
                Dim xmlDoc As New XmlDocument
                xmlDoc.Load(My.Application.Info.DirectoryPath & Archivo)

                Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("tabla1").Item(0)
                Dim Rej_1 As XmlNode = CuerpoXL_1.SelectSingleNode("RejTrS") '.Item(0)
                Rej_1.SelectSingleNode("IpLocalTCP").InnerText = Columnas.IpLocalTCP
                Rej_1.SelectSingleNode("IpDestinoTCP").InnerText = Columnas.IpDestinoTCP
                Rej_1.SelectSingleNode("BufferTCP").InnerText = Columnas.BufferTCP
                Rej_1.SelectSingleNode("PuertoTCP").InnerText = Columnas.PuertoTCP
                Rej_1.SelectSingleNode("IpDestinoUDP").InnerText = Columnas.IpDestinoUDP
                Rej_1.SelectSingleNode("PuertoUDP").InnerText = Columnas.PuertoUDP
                Rej_1.SelectSingleNode("ConexionesMaximas").InnerText = Columnas.ConexionesMaximas
                Rej_1.SelectSingleNode("Nick").InnerText = Columnas.Nick
                xmlDoc.Save(My.Application.Info.DirectoryPath & Archivo)

                Guardado = True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Guardado
        End Function



        Friend Shared Function ObtenerDatosClient() As Archivo_Clientes
            Dim Enviado As New Archivo_Clientes
            Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & Archivo


            If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Datos\BaseDatos") = False Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Datos\BaseDatos")
            End If

            If My.Computer.FileSystem.FileExists(RutaXMLConfigPrintInt) = False Then

                Dim Texto As String = "<?xml version=""1.0"" encoding=""utf-8"" ?>" &
        "<tabla1>" &
              " <RejTrS>" &
              "     <IpLocalTCP></IpLocalTCP>" & vbCr &
              "     <IpDestinoTCP></IpDestinoTCP>" & vbCr &
              "     <BufferTCP></BufferTCP>" & vbCr &
              "     <PuertoTCP>27033</PuertoTCP>" & vbCr &
              "     <IpDestinoUDP></IpDestinoUDP>" & vbCr &
              "     <PuertoUDP>27033</PuertoUDP>" & vbCr &
              "     <ConexionesMaximas>256</ConexionesMaximas>" & vbCr &
              "     <Nick></Nick>" & vbCr &
              "     </RejTrS>" & vbCr &
              " <RejTrC>" & vbCr &
              "     <IpLocalTCP></IpLocalTCP>" & vbCr &
              "     <IpDestinoTCP></IpDestinoTCP>" & vbCr &
              "     <BufferTCP></BufferTCP>" & vbCr &
              "     <PuertoTCP>27033</PuertoTCP>" & vbCr &
              "     <IpDestinoUDP></IpDestinoUDP>" & vbCr &
              "     <PuertoUDP>27033</PuertoUDP>" & vbCr &
              "     <ConexionesMaximas>256</ConexionesMaximas>" & vbCr &
              "     <Nick></Nick>" &
              " </RejTrC>" &
        "</tabla1>"
                My.Computer.FileSystem.WriteAllText(RutaXMLConfigPrintInt, Texto, False)
            End If


            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(RutaXMLConfigPrintInt)
            Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("tabla1").Item(0)
            Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("RejTrC").Item(0)
            Try
                Enviado.IpLocalTCP = NudoTabla.SelectSingleNode("IpLocalTCP").InnerText
                Enviado.IpDestinoTCP = NudoTabla.SelectSingleNode("IpDestinoTCP").InnerText
                Enviado.BufferTCP = NudoTabla.SelectSingleNode("BufferTCP").InnerText
                Enviado.PuertoTCP = NudoTabla.SelectSingleNode("PuertoTCP").InnerText
                Enviado.IpDestinoUDP = NudoTabla.SelectSingleNode("IpDestinoUDP").InnerText
                Enviado.PuertoUDP = NudoTabla.SelectSingleNode("PuertoUDP").InnerText
                Enviado.ConexionesMaximas = NudoTabla.SelectSingleNode("ConexionesMaximas").InnerText
                Enviado.Nick = NudoTabla.SelectSingleNode("Nick").InnerText
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
                Rej_1.SelectSingleNode("IpLocalTCP").InnerText = Clolumnas.IpLocalTCP
                Rej_1.SelectSingleNode("IpDestinoTCP").InnerText = Clolumnas.IpDestinoTCP
                Rej_1.SelectSingleNode("BufferTCP").InnerText = Clolumnas.BufferTCP
                Rej_1.SelectSingleNode("PuertoTCP").InnerText = Clolumnas.PuertoTCP
                Rej_1.SelectSingleNode("IpDestinoUDP").InnerText = Clolumnas.IpDestinoUDP
                Rej_1.SelectSingleNode("PuertoUDP").InnerText = Clolumnas.PuertoUDP
                Rej_1.SelectSingleNode("ConexionesMaximas").InnerText = Clolumnas.ConexionesMaximas
                Rej_1.SelectSingleNode("Nick").InnerText = Clolumnas.Nick
                xmlDoc.Save(My.Application.Info.DirectoryPath & Archivo)

                Guardado = True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Guardado
        End Function



        Friend Structure Archivo_Clientes
            Dim NombreServidor As String
            Dim IpLocalTCP As String
            Dim IpDestinoTCP As String
            Dim PuertoTCP As String
            Dim BufferTCP As String
            Dim IpDestinoUDP As String
            Dim PuertoUDP As String
            Dim ConexionesMaximas As Long
            Dim Nick As String
        End Structure

    End Class


End Namespace

