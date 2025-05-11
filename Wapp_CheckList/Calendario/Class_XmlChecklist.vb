
Imports System.Xml
Imports Wapp_CheckList.BaseDatos.Class_XmlChecklist

Namespace BaseDatos


    Public Class Class_XmlChecklist
        Shared Archivo As String = "\BaseDatos\DB_Checklist.xml"
        Event Modificacion()

        Friend Shared Sub ObtenerArchivo()
            Try
                Dim RutaXMLChecklist As String = My.Application.Info.DirectoryPath & Archivo

                If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Datos\BaseDatos") = False Then
                    My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Datos\BaseDatos")
                End If

                If My.Computer.FileSystem.FileExists(RutaXMLChecklist) = False Then
                    Dim respuesta As DialogResult = MessageBox.Show("El archivo de checklists no existe. ¿Desea crearlo?", "Archivo no encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    If respuesta = DialogResult.Yes Then
                        Dim Texto As String = "<?xml version=""1.0"" encoding=""utf-8"" ?>" & vbCr & "<checklists></checklists>"
                        My.Computer.FileSystem.WriteAllText(RutaXMLChecklist, Texto, False)
                        MessageBox.Show("Se ha creado un nuevo archivo de checklists.", "Archivo creado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("No se puede continuar sin el archivo de checklists.", "Operación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ' Opcionalmente, puedes lanzar una excepción aquí si quieres que el programa maneje este caso de forma específica
                        ' Throw New Exception("El usuario decidió no crear el archivo de checklists.")
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Error al obtener o crear el archivo: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub



        Friend Shared Function ObtenerAll() As List(Of Checklist)
            Dim ListaChecklists As New List(Of Checklist)
            Dim RutaXMLChecklist As String = My.Application.Info.DirectoryPath & Archivo

            Try
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(RutaXMLChecklist)

                ' Obtener el nodo raíz directamente
                Dim NodoRaiz As XmlNode = xmlDoc.SelectSingleNode("/checklists")

                ' Validar si el nodo raíz existe
                If NodoRaiz Is Nothing Then
                    Throw New Exception("El nodo raíz 'checklists' no se encuentra en el archivo XML.")
                End If

                ' Iterar por los hijos directos del nodo raíz (nodos checklist)
                For Each NodoChecklist As XmlNode In NodoRaiz.ChildNodes
                    If NodoChecklist.Name = "checklist" Then ' Validar si el nodo es un 'checklist'
                        Dim ElementoChecklist As New Checklist

                        Try
                            ' Leer los atributos del nodo checklist
                            ElementoChecklist.Id = If(NodoChecklist.Attributes("id") IsNot Nothing, NodoChecklist.Attributes("id").Value, String.Empty)
                            ElementoChecklist.Nombre = If(NodoChecklist.Attributes("nombre") IsNot Nothing, NodoChecklist.Attributes("nombre").Value, String.Empty)
                            ElementoChecklist.Tipo = If(NodoChecklist.Attributes("tipo") IsNot Nothing, NodoChecklist.Attributes("tipo").Value, String.Empty)
                            ElementoChecklist.Tematica = If(NodoChecklist.Attributes("tematica") IsNot Nothing, NodoChecklist.Attributes("tematica").Value, String.Empty)

                            ' Obtener el nodo <funciones>
                            Dim NodoFunciones As XmlNode = NodoChecklist.SelectSingleNode("funciones")
                            ElementoChecklist.Items = New List(Of ChecklistItem)
                            ' Validar si existe el nodo <funciones>
                            If NodoFunciones IsNot Nothing Then
                                ' Iterar por los nodos hijos <item> dentro de <funciones>
                                For Each NodoItem As XmlNode In NodoFunciones.SelectNodes("item")
                                    Dim ElementoItem As New ChecklistItem

                                    ' Leer los datos del nodo item
                                    ElementoItem.Id = If(NodoItem.Attributes("id") IsNot Nothing, NodoItem.Attributes("id").Value, String.Empty)
                                    ElementoItem.Descripcion = If(NodoItem.SelectSingleNode("descripcion") IsNot Nothing, NodoItem.SelectSingleNode("descripcion").InnerText, String.Empty)
                                    ElementoItem.Completado = If(Boolean.TryParse(NodoItem.SelectSingleNode("completado")?.InnerText, False), Boolean.Parse(NodoItem.SelectSingleNode("completado")?.InnerText), False)
                                    ElementoItem.Notas = If(NodoItem.SelectSingleNode("notas") IsNot Nothing, NodoItem.SelectSingleNode("notas").InnerText, String.Empty)

                                    ' Agregar el item a la lista de items del checklist
                                    'If ElementoChecklist.Items Is Nothing Then
                                    '    ElementoChecklist.Items = New List(Of ChecklistItem)
                                    'End If
                                    ElementoChecklist.Items.Add(ElementoItem)
                                Next
                            End If

                        Catch ex As Exception
                            MsgBox("Error al procesar checklist: " & ex.Message)
                        End Try

                        ' Agregar el checklist a la lista principal
                        ListaChecklists.Add(ElementoChecklist)
                    End If
                Next
            Catch ex As Exception
                MsgBox("Error al obtener todos los checklists: " & ex.Message)
            End Try

            Return ListaChecklists
        End Function

        Friend Shared Function ObtenerID(ByVal Id As String) As Checklist
            Dim Rejistro As New Checklist
            Try
                ' Cargar el archivo XML
                Dim xmlDoc As New XmlDocument()
                Dim RutaXMLChecklist As String = My.Application.Info.DirectoryPath & Archivo
                xmlDoc.Load(RutaXMLChecklist)

                ' Obtener el nodo raíz <checklists>
                Dim NodoRaiz As XmlNode = xmlDoc.SelectSingleNode("/checklists")

                ' Validar si el nodo raíz existe
                If NodoRaiz Is Nothing Then
                    Throw New Exception("El nodo raíz 'checklists' no se encuentra en el archivo XML.")
                End If

                ' Buscar el nodo <checklist> con el atributo id coincidente
                For Each NodoChecklist As XmlNode In NodoRaiz.SelectNodes("checklist")
                    If NodoChecklist.Attributes("id") IsNot Nothing AndAlso NodoChecklist.Attributes("id").Value = Id Then
                        ' Rellenar los datos del checklist
                        Rejistro.Id = NodoChecklist.Attributes("id").Value
                        Rejistro.Nombre = If(NodoChecklist.Attributes("nombre") IsNot Nothing, NodoChecklist.Attributes("nombre").Value, String.Empty)
                        Rejistro.Tipo = If(NodoChecklist.Attributes("tipo") IsNot Nothing, NodoChecklist.Attributes("tipo").Value, String.Empty)
                        Rejistro.Tematica = If(NodoChecklist.Attributes("tematica") IsNot Nothing, NodoChecklist.Attributes("tematica").Value, String.Empty)

                        ' Buscar el nodo <funciones> dentro del checklist
                        Dim NodoFunciones As XmlNode = NodoChecklist.SelectSingleNode("funciones")
                        Rejistro.Items = New List(Of ChecklistItem)
                        ' Validar si existe el nodo <funciones>
                        If NodoFunciones IsNot Nothing Then
                            ' Iterar por los nodos <item> dentro de <funciones>
                            For Each NodoItem As XmlNode In NodoFunciones.SelectNodes("item")
                                Dim ElementoItem As New ChecklistItem

                                ' Leer los datos del nodo item
                                ElementoItem.Id = If(NodoItem.Attributes("id") IsNot Nothing, NodoItem.Attributes("id").Value, String.Empty)
                                ElementoItem.Descripcion = If(NodoItem.SelectSingleNode("descripcion") IsNot Nothing, NodoItem.SelectSingleNode("descripcion").InnerText, String.Empty)
                                ElementoItem.Completado = If(Boolean.TryParse(NodoItem.SelectSingleNode("completado")?.InnerText, False), Boolean.Parse(NodoItem.SelectSingleNode("completado")?.InnerText), False)
                                ElementoItem.Notas = If(NodoItem.SelectSingleNode("notas") IsNot Nothing, NodoItem.SelectSingleNode("notas").InnerText, String.Empty)

                                ' Agregar el item a la lista del checklist
                                If Rejistro.Items Is Nothing Then
                                    Rejistro.Items = New List(Of ChecklistItem)
                                End If
                                Rejistro.Items.Add(ElementoItem)
                            Next
                        End If

                        ' Salir del bucle una vez encontrado el checklist
                        Exit For
                    End If
                Next
            Catch ex As Exception
                MsgBox("Error al obtener checklist por ID: " & ex.Message, MsgBoxStyle.Critical)
            End Try

            Return Rejistro
        End Function


        Friend Shared Function Agregar(ByVal NuevoChecklist As Checklist) As Boolean
            Dim Guardado As Boolean = False
            Try
                ' Cargar el archivo XML
                Dim xmlDoc As New XmlDocument()
                Dim RutaXMLChecklist As String = My.Application.Info.DirectoryPath & Archivo
                xmlDoc.Load(RutaXMLChecklist)

                ' Obtener el nodo raíz <checklists>
                Dim NodoRaiz As XmlNode = xmlDoc.SelectSingleNode("/checklists")

                ' Validar si el nodo raíz existe
                If NodoRaiz Is Nothing Then
                    Throw New Exception("El nodo raíz 'checklists' no se encuentra en el archivo XML.")
                End If

                ' Crear el nuevo nodo <checklist> con sus atributos
                Dim NodoChecklist As XmlElement = xmlDoc.CreateElement("checklist")
                NodoChecklist.SetAttribute("id", NuevoChecklist.Id)
                NodoChecklist.SetAttribute("nombre", NuevoChecklist.Nombre)
                NodoChecklist.SetAttribute("tipo", NuevoChecklist.Tipo)
                NodoChecklist.SetAttribute("tematica", NuevoChecklist.Tematica)

                ' Crear el nodo <funciones>
                Dim NodoFunciones As XmlElement = xmlDoc.CreateElement("funciones")

                ' Agregar los nodos <item> al nodo <funciones>
                For Each Item As ChecklistItem In NuevoChecklist.Items
                    Dim NodoItem As XmlElement = xmlDoc.CreateElement("item")
                    NodoItem.SetAttribute("id", Item.Id)

                    Dim NodoDescripcion As XmlElement = xmlDoc.CreateElement("descripcion")
                    NodoDescripcion.InnerText = Item.Descripcion
                    NodoItem.AppendChild(NodoDescripcion)

                    Dim NodoCompletado As XmlElement = xmlDoc.CreateElement("completado")
                    NodoCompletado.InnerText = Item.Completado.ToString()
                    NodoItem.AppendChild(NodoCompletado)

                    Dim NodoNotas As XmlElement = xmlDoc.CreateElement("notas")
                    NodoNotas.InnerText = Item.Notas
                    NodoItem.AppendChild(NodoNotas)

                    NodoFunciones.AppendChild(NodoItem)
                Next

                ' Agregar el nodo <funciones> al nodo <checklist>
                NodoChecklist.AppendChild(NodoFunciones)

                ' Agregar el nodo <checklist> al nodo raíz <checklists>
                NodoRaiz.AppendChild(NodoChecklist)

                ' Guardar los cambios en el archivo XML
                xmlDoc.Save(RutaXMLChecklist)
                Guardado = True

            Catch ex As Exception
                MsgBox("Error al agregar checklist: " & ex.Message)
            End Try

            Return Guardado
        End Function

        'Friend Shared Function Modificar(ByVal ChecklistModificado As Checklist) As Boolean
        '    Dim Guardado As Boolean = False
        '    Try
        '        Dim xmlDoc As New XmlDocument()
        '        xmlDoc.Load(My.Application.Info.DirectoryPath & Archivo)

        '        Dim NodoChecklists As XmlNode = xmlDoc.GetElementsByTagName("checklists").Item(0)

        '        For Each NodoChecklist As XmlNode In NodoChecklists.SelectNodes("checklist")
        '            ' Validar si el nodo tiene el atributo "id"
        '            If NodoChecklist.Attributes("id") IsNot Nothing AndAlso NodoChecklist.Attributes("id").Value = ChecklistModificado.Id Then
        '                ' Actualizar atributos principales del checklist
        '                NodoChecklist.Attributes("nombre").Value = ChecklistModificado.Nombre
        '                NodoChecklist.Attributes("tipo").Value = ChecklistModificado.Tipo
        '                NodoChecklist.Attributes("tematica").Value = ChecklistModificado.Tematica
        '                Dim Nudo1 As XmlNode = xmlDoc.GetElementsByTagName("funciones").Item(0)

        '                ' Eliminar todos los nodos "item" existentes antes de agregar los nuevos
        '                For Each NodoItemExistente As XmlNode In Nudo1.SelectNodes("item")
        '                    Nudo1.RemoveChild(NodoItemExistente)
        '                Next

        '                ' Agregar los nuevos items al nodo checklist
        '                For Each Item As ChecklistItem In ChecklistModificado.Items
        '                    Dim NodoItem As XmlElement = xmlDoc.CreateElement("item")
        '                    NodoItem.SetAttribute("id", Item.Id)

        '                    Dim NodoDescripcion As XmlElement = xmlDoc.CreateElement("descripcion")
        '                    NodoDescripcion.InnerText = Item.Descripcion
        '                    NodoItem.AppendChild(NodoDescripcion)

        '                    Dim NodoCompletado As XmlElement = xmlDoc.CreateElement("completado")
        '                    NodoCompletado.InnerText = Item.Completado.ToString()
        '                    NodoItem.AppendChild(NodoCompletado)

        '                    Dim NodoNotas As XmlElement = xmlDoc.CreateElement("notas")
        '                    NodoNotas.InnerText = Item.Notas
        '                    NodoItem.AppendChild(NodoNotas)

        '                    ' Añadir el nodo item al checklist
        '                    Nudo1.AppendChild(NodoItem)
        '                Next

        '                ' Guardar los cambios en el archivo XML
        '                xmlDoc.Save(My.Application.Info.DirectoryPath & Archivo)
        '                Guardado = True
        '                Exit For
        '            End If
        '        Next
        '    Catch ex As Exception
        '        MsgBox("Error al modificar checklist: " & ex.Message)
        '    End Try

        '    Return Guardado
        'End Function
        Friend Shared Function Modificar(ByVal ChecklistModificado As Checklist) As Boolean
            Dim Guardado As Boolean = False
            Try
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(My.Application.Info.DirectoryPath & Archivo)

                Dim NodoChecklists As XmlNode = xmlDoc.GetElementsByTagName("checklists").Item(0)

                For Each NodoChecklist As XmlNode In NodoChecklists.SelectNodes("checklist")
                    If NodoChecklist.Attributes("id")?.Value = ChecklistModificado.Id Then
                        ' Actualizar atributos
                        NodoChecklist.Attributes("nombre").Value = ChecklistModificado.Nombre
                        NodoChecklist.Attributes("tipo").Value = ChecklistModificado.Tipo
                        NodoChecklist.Attributes("tematica").Value = ChecklistModificado.Tematica

                        ' Buscar nodo funciones
                        Dim NodoFunciones As XmlNode = NodoChecklist.SelectSingleNode("funciones")
                        If NodoFunciones Is Nothing Then
                            NodoFunciones = xmlDoc.CreateElement("funciones")
                            NodoChecklist.AppendChild(NodoFunciones)
                        Else
                            NodoFunciones.RemoveAll() ' Limpiar items existentes
                        End If

                        ' Agregar nuevos items
                        For Each Item As ChecklistItem In ChecklistModificado.Items
                            Dim NodoItem As XmlElement = xmlDoc.CreateElement("item")
                            NodoItem.SetAttribute("id", Item.Id)

                            Dim NodoDescripcion As XmlElement = xmlDoc.CreateElement("descripcion")
                            NodoDescripcion.InnerText = Item.Descripcion
                            NodoItem.AppendChild(NodoDescripcion)

                            Dim NodoCompletado As XmlElement = xmlDoc.CreateElement("completado")
                            NodoCompletado.InnerText = Item.Completado.ToString()
                            NodoItem.AppendChild(NodoCompletado)

                            Dim NodoNotas As XmlElement = xmlDoc.CreateElement("notas")
                            NodoNotas.InnerText = Item.Notas
                            NodoItem.AppendChild(NodoNotas)

                            NodoFunciones.AppendChild(NodoItem)
                        Next

                        xmlDoc.Save(My.Application.Info.DirectoryPath & Archivo)
                        Guardado = True
                        Exit For
                    End If
                Next
            Catch ex As Exception
                MessageBox.Show("Error al modificar: " & ex.Message)
            End Try
            Return Guardado
        End Function


        Friend Shared Function Eliminar(ByVal IdChecklist As String) As Boolean
            Dim Eliminado As Boolean = False
            Try
                Dim xmlDoc As New XmlDocument
                xmlDoc.Load(My.Application.Info.DirectoryPath & Archivo)
                Dim NodoChecklists As XmlNode = xmlDoc.GetElementsByTagName("checklists").Item(0)

                For Each NodoChecklist As XmlNode In NodoChecklists.SelectNodes("checklist")
                    If IsNothing(IdChecklist) And IsNothing(IdChecklist) Then
                        NodoChecklists.RemoveChild(NodoChecklist)
                        xmlDoc.Save(My.Application.Info.DirectoryPath & Archivo)
                        Eliminado = True
                        Exit For
                    End If
                    If IsNothing(IdChecklist) Or IsNothing(IdChecklist) Then
                        'NodoChecklists.RemoveChild(NodoChecklist)
                        'xmlDoc.Save(My.Application.Info.DirectoryPath & Archivo)
                        'Eliminado = True


                    ElseIf NodoChecklist.Attributes("id").Value = IdChecklist Then
                        NodoChecklists.RemoveChild(NodoChecklist)
                        xmlDoc.Save(My.Application.Info.DirectoryPath & Archivo)
                        Eliminado = True
                        Exit For
                    End If
                Next
            Catch ex As Exception
                MsgBox("Error al eliminar checklist: " & ex.Message)
            End Try
            Return Eliminado
        End Function

        'Friend Shared Function ObtenerTematicasUnicas() As List(Of String)
        '    Dim tematicas As New HashSet(Of String)()
        '    For Each checklist In ObtenerAll()
        '        If Not String.IsNullOrEmpty(checklist.Tematica) Then
        '            tematicas.Add(checklist.Tematica)
        '        End If
        '    Next
        '    Return tematicas.ToList()
        'End Function
        Friend Shared Function ObtenerTematicasUnicas() As List(Of String)
            Dim tematicas As New HashSet(Of String)()
            For Each checklist In ObtenerAll()
                If Not String.IsNullOrEmpty(checklist.Tematica) Then
                    Dim Encontrado As Boolean = False
                    For indice As Integer = 0 To tematicas.Count - 1
                        If tematicas(indice).ToString = checklist.Tematica Then
                            Encontrado = True
                            Exit For
                        End If
                    Next
                    If Not Encontrado Then
                        tematicas.Add(checklist.Tematica)
                    End If
                End If
            Next
            Return tematicas.ToList()
        End Function
        Friend Shared Function ObtenerTiposUnicos() As List(Of String)
            Dim Tipo As New HashSet(Of String)()
            For Each checklist In ObtenerAll()
                If Not String.IsNullOrEmpty(checklist.Tipo) Then
                    Dim Encontrado As Boolean = False
                    For indice As Integer = 0 To Tipo.Count - 1
                        If Tipo(indice).ToString = checklist.Tipo Then
                            Encontrado = True
                            Exit For
                        End If
                    Next
                    If Not Encontrado Then
                        Tipo.Add(checklist.Tipo)
                    End If
                End If
            Next
            Return Tipo.ToList()
        End Function
        Friend Structure Checklist
            Dim Id As String
            Dim Nombre As String
            Dim Tipo As String
            Dim Tematica As String ' Nuevo campo
            Dim Items As List(Of ChecklistItem)
        End Structure


        Friend Structure ChecklistItem
            Dim Id As String
            Dim Descripcion As String
            Dim Completado As Boolean
            Dim Notas As String
        End Structure
    End Class

End Namespace

