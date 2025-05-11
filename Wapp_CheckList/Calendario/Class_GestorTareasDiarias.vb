Imports System.Xml

Namespace Calendario

    Public Class Class_GestorTareasDiarias
        Private Shared ArchivoTareas As String = "\BaseDatos\DB_TareasDiarias.xml"

        Public Shared Sub ObtenerArchivo()
            Try
                Dim RutaXMLTareas As String = My.Application.Info.DirectoryPath & ArchivoTareas

                If Not My.Computer.FileSystem.FileExists(RutaXMLTareas) Then
                    Dim Texto As String = "<?xml version=""1.0"" encoding=""utf-8"" ?>" & vbCr & "<tareas></tareas>"
                    My.Computer.FileSystem.WriteAllText(RutaXMLTareas, Texto, False)
                End If
            Catch ex As Exception
                MessageBox.Show("Error al obtener o crear el archivo de tareas: " & ex.Message)
            End Try
        End Sub

        Public Shared Function ObtenerPorFecha(fecha As DateTime) As List(Of Calendario.TareaDiaria)
            Dim ListaTareas As New List(Of TareaDiaria)
            Try
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(My.Application.Info.DirectoryPath & ArchivoTareas)

                For Each NodoTarea As XmlNode In xmlDoc.SelectNodes("/tareas/tarea")
                    Dim tarea As New TareaDiaria With {
                    .Id = NodoTarea.Attributes("id").Value,
                    .Fecha = DateTime.Parse(NodoTarea.Attributes("fecha").Value),
                    .Hora = If(TimeSpan.TryParse(NodoTarea.Attributes("hora")?.Value, Nothing), TimeSpan.Parse(NodoTarea.Attributes("hora")?.Value), Nothing),
                    .Descripcion = NodoTarea.SelectSingleNode("descripcion").InnerText,
                    .ChecklistId = NodoTarea.Attributes("checklistId")?.Value
                }
                    If tarea.Fecha.Date = fecha.Date Then ListaTareas.Add(tarea)
                Next
            Catch ex As Exception
                MessageBox.Show("Error al obtener tareas por fecha: " & ex.Message)
            End Try

            Return ListaTareas
        End Function

        'Public Shared Sub Agregar(tarea As TareaDiaria)
        '    Try
        '        Dim xmlDoc As New XmlDocument()
        '        xmlDoc.Load(My.Application.Info.DirectoryPath & ArchivoTareas)

        '        Dim NodoRaiz = xmlDoc.SelectSingleNode("/tareas")
        '        Dim NodoNuevaTarea = xmlDoc.CreateElement("tarea")
        '        NodoNuevaTarea.SetAttribute("id", tarea.Id)
        '        NodoNuevaTarea.SetAttribute("fecha", tarea.Fecha.ToString("yyyy-MM-dd"))
        '        If tarea.Hora.HasValue Then NodoNuevaTarea.SetAttribute("hora", tarea.Hora.Value.ToString())
        '        NodoNuevaTarea.SetAttribute("checklistId", tarea.ChecklistId)

        '        Dim NodoDescripcion = xmlDoc.CreateElement("descripcion")
        '        NodoDescripcion.InnerText = tarea.Descripcion
        '        NodoNuevaTarea.AppendChild(NodoDescripcion)

        '        NodoRaiz.AppendChild(NodoNuevaTarea)
        '        xmlDoc.Save(My.Application.Info.DirectoryPath & ArchivoTareas)
        '    Catch ex As Exception
        '        MessageBox.Show("Error al agregar tarea: " & ex.Message)
        '    End Try
        'End Sub
        ' En la clase GestorTareasDiarias (BaseDatos)
        Public Shared Sub Agregar(tarea As TareaDiaria)
            Try
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(My.Application.Info.DirectoryPath & ArchivoTareas)

                Dim NodoRaiz = xmlDoc.SelectSingleNode("/tareas")
                Dim NodoNuevaTarea = xmlDoc.CreateElement("tarea")

                ' Validar campos obligatorios
                If String.IsNullOrEmpty(tarea.Id) Then Throw New ArgumentException("ID de tarea inválido")
                If tarea.Fecha = DateTime.MinValue Then Throw New ArgumentException("Fecha inválida")

                NodoNuevaTarea.SetAttribute("id", tarea.Id)
                NodoNuevaTarea.SetAttribute("fecha", tarea.Fecha.ToString("yyyy-MM-dd"))

                ' Manejar valores opcionales
                If tarea.Hora.HasValue Then
                    NodoNuevaTarea.SetAttribute("hora", tarea.Hora.Value.ToString("hh\:mm"))
                End If

                If Not String.IsNullOrEmpty(tarea.ChecklistId) Then
                    NodoNuevaTarea.SetAttribute("checklistId", tarea.ChecklistId)
                End If

                Dim NodoDescripcion = xmlDoc.CreateElement("descripcion")
                NodoDescripcion.InnerText = If(String.IsNullOrEmpty(tarea.Descripcion), "Sin descripción", tarea.Descripcion)
                NodoNuevaTarea.AppendChild(NodoDescripcion)

                NodoRaiz.AppendChild(NodoNuevaTarea)
                xmlDoc.Save(My.Application.Info.DirectoryPath & ArchivoTareas)
            Catch ex As Exception
                Throw New Exception($"Error al guardar tarea: {ex.Message}")
            End Try
        End Sub


        Public Shared Sub EliminarPorId(id As String)
            Try
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(My.Application.Info.DirectoryPath & ArchivoTareas)

                For Each NodoTarea As XmlNode In xmlDoc.SelectNodes("/tareas/tarea")
                    If NodoTarea.Attributes("id").Value = id Then
                        NodoTarea.ParentNode.RemoveChild(NodoTarea)
                        Exit For
                    End If
                Next

                xmlDoc.Save(My.Application.Info.DirectoryPath & ArchivoTareas)
            Catch ex As Exception
                MessageBox.Show("Error al eliminar tarea: " & ex.Message)
            End Try
        End Sub
    End Class

End Namespace