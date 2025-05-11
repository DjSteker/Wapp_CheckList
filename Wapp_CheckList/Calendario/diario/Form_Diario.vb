
Imports System.Xml.Linq

Public Class Form_Diario

    ' Al iniciar el formulario se cargan los datos del diario y el checklist.
    Private Sub Form_Diario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDiary()
        LoadCheckList()
    End Sub

    ' Función para cargar el archivo XML del diario en el DataGridView_Diario
    Private Sub LoadDiary()
        Dim filePath As String = "BaseDatos\diario.xml"
        Dim ds As New DataSet()
        If IO.File.Exists(filePath) Then
            ds.ReadXml(filePath)
            ' Se asume que el archivo tiene un elemento raíz <Diario> con elementos <Entrada>
            If ds.Tables.Contains("Entrada") Then
                DataGridView_Diario.DataSource = ds.Tables("Entrada")
            Else
                DataGridView_Diario.DataSource = Nothing
            End If
        Else
            ' Si el archivo no existe, se crea uno vacío con la estructura básica.
            Dim doc As New XDocument(New XElement("Diario"))
            doc.Save(filePath)
            DataGridView_Diario.DataSource = Nothing
        End If
    End Sub

    ' Función para cargar el archivo XML del checklist en el DataGridView_CheckList
    Private Sub LoadCheckList()
        Dim filePath As String = "BaseDatos\checklist.xml"
        Dim ds As New DataSet()
        If IO.File.Exists(filePath) Then
            ds.ReadXml(filePath)
            ' Se asume que el archivo tiene un elemento raíz <Checklist> con elementos <Tarea>
            If ds.Tables.Contains("Tarea") Then
                DataGridView_CheckList.DataSource = ds.Tables("Tarea")
            Else
                DataGridView_CheckList.DataSource = Nothing
            End If
        Else
            Dim doc As New XDocument(New XElement("Checklist"))
            doc.Save(filePath)
            DataGridView_CheckList.DataSource = Nothing
        End If
    End Sub

    ' Al hacer clic en el botón Guardar se agrega una nueva entrada del diario.
    Private Sub Button_Guardar_Click(sender As Object, e As EventArgs) Handles Button_Guardar.Click
        ' Solicitar el texto de la entrada al usuario
        Dim entryText As String = InputBox("Ingrese el texto de la entrada", "Nueva entrada del diario")
        If String.IsNullOrEmpty(entryText) Then Exit Sub

        ' Permitir que el usuario seleccione una imagen
        Dim imagePath As String = ""
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            If ofd.ShowDialog() = DialogResult.OK Then
                imagePath = ofd.FileName
            End If
        End Using

        ' Solicitar el tema de la entrada
        Dim theme As String = InputBox("Ingrese el tema", "Tema entrada")

        Dim filePath As String = "BaseDatos\diario.xml"
        Dim doc As XDocument
        If IO.File.Exists(filePath) Then
            doc = XDocument.Load(filePath)
        Else
            doc = New XDocument(New XElement("Diario"))
        End If

        ' Determinar el ID de la nueva entrada (se asume que es el máximo ya existente + 1)
        Dim newId As Integer = 1
        Dim existingIds = From entrada In doc.Root.Elements("Entrada")
                          Let idVal = Val(entrada.Element("Id").Value)
                          Select idVal
        If existingIds.Any() Then
            newId = existingIds.Max() + 1
        End If

        ' Procesar la imagen copiándola a la carpeta "Imagenes" con fecha en su nombre
        Dim destImagePath As String = ""
        If Not String.IsNullOrEmpty(imagePath) AndAlso IO.File.Exists(imagePath) Then
            Dim imagenFolder As String = "Imagenes"
            If Not IO.Directory.Exists(imagenFolder) Then
                IO.Directory.CreateDirectory(imagenFolder)
            End If
            Dim newImageName As String = DateTime.Now.ToString("yyyyMMddHHmmss") & "_" & IO.Path.GetFileName(imagePath)
            destImagePath = IO.Path.Combine(imagenFolder, newImageName)
            IO.File.Copy(imagePath, destImagePath, True)
        End If

        ' Crear el nuevo elemento de entrada y agregarlo al documento XML
        doc.Root.Add(New XElement("Entrada",
                         New XElement("Id", newId),
                         New XElement("Fecha", DateTime.Now.ToString("s")),
                         New XElement("Texto", entryText),
                         New XElement("RutaImagen", destImagePath),
                         New XElement("Tema", theme)
                         ))
        doc.Save(filePath)

        ' Recargar el DataGridView con los nuevos datos
        LoadDiary()
    End Sub

    ' Al hacer clic en el botón Eliminar se borra la entrada seleccionada
    Private Sub Button_Eliminar_Click(sender As Object, e As EventArgs) Handles Button_Eliminar.Click
        If DataGridView_Diario.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione una entrada para eliminar.")
            Return
        End If

        Dim filePath As String = "BaseDatos\diario.xml"
        Dim doc As XDocument = XDocument.Load(filePath)

        ' Se recorre cada fila seleccionada y se elimina la entrada correspondiente de acuerdo con el ID.
        For Each row As DataGridViewRow In DataGridView_Diario.SelectedRows
            Dim idVal As String = row.Cells("C_DiarioId").Value.ToString()
            Dim entryElement = doc.Root.Elements("Entrada").Where(Function(x) x.Element("Id").Value = idVal).FirstOrDefault()
            If entryElement IsNot Nothing Then
                entryElement.Remove()
            End If
        Next

        doc.Save(filePath)
        LoadDiary()
    End Sub

    ' Evento para cuando se haga clic en el contenido de una celda del DataGridView del diario.
    Private Sub DataGridView_Diario_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_Diario.CellContentClick
        ' Aquí se puede implementar alguna acción, por ejemplo, mostrar la imagen en un PictureBox o habilitar la edición.
    End Sub

    ' Evento para cuando se haga clic en el contenido de una celda del DataGridView del checklist.
    Private Sub DataGridView_CheckList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_CheckList.CellContentClick
        ' Aquí podrías implementar la marca de una tarea como completada u otro comportamiento deseado.
    End Sub

    Dim ID_Seleccionada As Integer = -1

    Private Sub DataGridView_LibroGuardia_RowHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView_Diario.RowHeaderMouseClick
        Try
            '  Me.DataGridView_Etiquetas.Rows(e.RowIndex).Selected = True


            ID_Seleccionada = CStr(DataGridView_Diario("C_ID", e.RowIndex).Value)

            If RichTextBox_Tarea.Visible = False Then
                RichTextBox_Tarea.Visible = True
                DataGridView_Diario.Height = DataGridView_Diario.Height - 48
                'With BaseDatos.Class_PaisesIsoA.ObtenerTodos
                '    Dim aaa = DataGridView_Diario("C_IndicativoCorreponsal", e.RowIndex).Value
                '    For indice As Integer = 0 To .Count - 1
                '        Dim PrefijosPais As List(Of String) = ProcesarPrefijo(.Item(indice).C_Prefijo)

                '        For IndicePrefijosPais As Integer = 0 To PrefijosPais.Count - 1
                '            If Mid(aaa, 1, PrefijosPais.Item(IndicePrefijosPais).Count).ToUpper = PrefijosPais.Item(IndicePrefijosPais).ToUpper Then
                '                RichTextBox_Tarea.Text &= " " & PrefijosPais.Item(IndicePrefijosPais).ToUpper & vbCrLf
                '            End If
                '        Next

                '    Next
                'End With
            Else

            End If



        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
End Class