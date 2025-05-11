
'Public Class Form_Checklist

'    Private Sub Form_Checklist_Load(sender As Object, e As EventArgs) Handles MyBase.Load

'    End Sub

'    Private Sub DataGridView_Tareas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_Tareas.CellContentClick

'    End Sub

'    Private Sub DataGridView_Tareas_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView_Tareas.CellClick 'Handles DataGridView_Reparaciones.RowHeaderMouseClick
'        Try
'            ''  Me.DataGridView_Etiquetas.Rows(e.RowIndex).Selected = True
'            Me.DataGridView_Tareas.Rows.Item(e.RowIndex).Selected = True

'            Label_ID.Text = CStr(DataGridView_Tareas("C_Id", e.RowIndex).Value).ToString.Trim

'            Dim Id_ As String = String.Empty
'            With BaseDatos.Class_XmlChecklist.ObtenerID(Label_ID.Text.ToString)

'            End With
'        Catch ex As Exception
'            ' MsgBox(ex.Message)
'        End Try
'    End Sub

'    Private Sub DataGridView_Funciones_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_Funciones.CellContentClick

'    End Sub

'    Private Sub DataGridView_Funciones_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView_Funciones.CellClick 'Handles DataGridView_Reparaciones.RowHeaderMouseClick
'        Try
'            ''  Me.DataGridView_Etiquetas.Rows(e.RowIndex).Selected = True
'            Me.DataGridView_Funciones.Rows.Item(e.RowIndex).Selected = True

'            Label_ID.Text = CStr(DataGridView_Funciones("C_Id", e.RowIndex).Value).ToString.Trim

'            Dim Id_ As String = String.Empty
'            With BaseDatos.Class_XmlChecklist.ObtenerID(Label_ID.Text.ToString)

'            End With
'        Catch ex As Exception
'            ' MsgBox(ex.Message)
'        End Try
'    End Sub

'    Private Sub Button_Agregar_Click(sender As Object, e As EventArgs) Handles Button_Agregar.Click

'    End Sub

'    Private Sub Button_Actulizar_Click(sender As Object, e As EventArgs) Handles Button_Actulizar.Click

'    End Sub

'    Private Sub Button_Eliminar_Click(sender As Object, e As EventArgs) Handles Button_Eliminar.Click

'    End Sub

'    Private Sub RichTextBox_Texto_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox_Texto.TextChanged

'    End Sub

'End Class

Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Wapp_CheckList.BaseDatos

Public Class Form_Checklist

    Private _checklistSeleccionado As BaseDatos.Class_XmlChecklist.Checklist
    Private TareaSeleccionada As BaseDatos.Class_XmlChecklist.ChecklistItem

    Private _modoEdicion As Boolean = False

    Private Sub Form_Checklist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            BaseDatos.Class_XmlChecklist.ObtenerArchivo()
            ConfigurarGrids()
            CargarChecklists() 'DataGridView_Tareas.DataSource = BaseDatos.Class_XmlChecklist.ObtenerAll()
            CargarTematicas()
            CargarTipos()

            _modoEdicion = False
            HabilitarEdicion(_modoEdicion)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.S
                   ' GuardarCambios()
                Case Keys.N
                   ' LimpiarCamposEdicion()
                Case Keys.F
                    ' TextBox_Buscar.Focus()
            End Select
        End If
    End Sub
    Private Sub ConfigurarGrids()
        ' Configuración DataGridView principal
        With DataGridView_Tareas
            .AutoGenerateColumns = False
            .Columns.Clear()

            ' Columna ID (oculta)
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "C_Id", .DataPropertyName = "Id", .HeaderText = "ID", .Visible = False})

            ' Columna Nombre
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "C_Nombre", .DataPropertyName = "Nombre", .HeaderText = "Nombre", .Width = 200})

            ' Columna Tipo
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "C_Tipo", .DataPropertyName = "Tipo", .HeaderText = "Tipo", .Width = 150})

            ' Nueva Columna Temática
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "C_Tematica", .DataPropertyName = "Tematica", .HeaderText = "Tematica", .Width = 150})  ' Asegúrate que la propiedad existe en tu clase Checklist.HeaderText = "Temática",.Width = 150})

        End With
        '    With DataGridView_Tareas
        '        .AutoGenerateColumns = False
        '        .Columns.Clear()
        '        .Columns.Add(New DataGridViewTextBoxColumn With {
        '    .Name = "C_Id",
        '    .DataPropertyName = "Id",
        '    .HeaderText = "ID",
        '    .Visible = False
        '})
        '        .Columns.Add(New DataGridViewTextBoxColumn With {
        '    .Name = "C_Nombre",
        '    .DataPropertyName = "Nombre",
        '    .HeaderText = "Nombre",
        '    .Width = 200
        '})
        '        .Columns.Add(New DataGridViewTextBoxColumn With {
        '    .Name = "C_Tipo",
        '    .DataPropertyName = "Tipo",
        '    .HeaderText = "Tipo",
        '    .Width = 150
        '})
        '    End With

        ' Configuración DataGridView de items



        '        With DataGridView_Funciones
        '            .AutoGenerateColumns = False
        '            .Columns.Clear()
        '            .Columns.Add(New DataGridViewCheckBoxColumn With {
        '.Name = "C_Completado",
        '.DataPropertyName = "Completado",
        '.HeaderText = "✓",
        '.Width = 30
        '})
        '            .Columns.Add(New DataGridViewTextBoxColumn With {
        '.Name = "C_Descripcion",
        '.DataPropertyName = "Descripcion",
        '.HeaderText = "Descripción",
        '.Width = 300
        '})
        '            .Columns.Add(New DataGridViewTextBoxColumn With {
        '.Name = "C_Notas",
        '.DataPropertyName = "Notas",
        '.HeaderText = "Notas",
        '.Width = 200
        '})
        '        End With


        '        With DataGridView_Funciones
        '            .AutoGenerateColumns = False
        '            .Columns.Clear()
        '            .Columns.Add(New DataGridViewCheckBoxColumn With {
        '.Name = "C_Completado",
        '.DataPropertyName = "Completado",
        '.HeaderText = "✓",
        '.Width = 30
        '})
        '            .Columns.Add(New DataGridViewTextBoxColumn With {
        '.Name = "C_Descripcion",
        '.DataPropertyName = "Descripcion",
        '.HeaderText = "Descripción",
        '.Width = 300
        '})
        '            .Columns.Add(New DataGridViewTextBoxColumn With {
        '.Name = "C_Notas",
        '.DataPropertyName = "Notas",
        '.HeaderText = "Notas",
        '.Width = 200
        '})


        'With DataGridView_Funciones
        '    .AutoGenerateColumns = False
        '    .Columns.Clear()
        '    .Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "C_Completado", .DataPropertyName = "Completado", .HeaderText = "✓", .Width = 30})
        '    .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "C_Descripcion", .DataPropertyName = "Descripcion", .HeaderText = "Descripción", .Width = 300})
        '    .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "C_Notas", .DataPropertyName = "Notas", .HeaderText = "Notas", .Width = 200})
        '    .EditMode = DataGridViewEditMode.EditOnEnter
        '    .AllowUserToAddRows = True
        '    .AllowUserToDeleteRows = True
        'End With

    End Sub


    'Private Sub DataGridView_Tareas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_Tareas.CellClick
    '    If e.RowIndex < 0 Then Return

    '    Try
    '        If IsNothing(DataGridView_Tareas.Rows(e.RowIndex).Cells("C_Id").Value) = False Then

    '            Label_ID.Text = DataGridView_Tareas.Rows(e.RowIndex).Cells("C_Id").Value

    '            Dim idChecklist = DataGridView_Tareas.Rows(e.RowIndex).Cells("C_Id").Value.ToString()
    '            _checklistSeleccionado = BaseDatos.Class_XmlChecklist.ObtenerID(idChecklist)

    '            MostrarDetalleChecklist(True)

    '            Try
    '                'DataGridView_Funciones.Rows.Clear()
    '                ' Verificar si hay filas antes de limpiarlas
    '                If DataGridView_Funciones.Rows.Count > 0 Then
    '                    DataGridView_Funciones.Rows.Clear()
    '                End If
    '            Catch ex As Exception

    '            End Try
    '            For indice1 As Integer = 0 To _checklistSeleccionado.Items.Count - 1
    '                Try
    '                    DataGridView_Funciones.Rows.Add(_checklistSeleccionado.Items(indice1).Completado, _checklistSeleccionado.Items(indice1).Descripcion, _checklistSeleccionado.Items(indice1).Notas)
    '                Catch ex As Exception

    '                End Try

    '            Next



    '        Else
    '            MostrarDetalleChecklist(True)
    '            Label_ID.Text = "IsNothing"


    '        End If


    '    Catch ex As Exception
    '        MessageBox.Show("Error al cargar checklist: " & ex.Message)
    '    End Try
    'End Sub

    Private Sub DataGridView_Tareas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_Tareas.CellClick
        If e.RowIndex < 0 Then
            'LimpiarCamposEdicion()
            Return
        End If

        Try
            If CambiosPendientes Then
                Dim resultado As DialogResult = MessageBox.Show("Tiene cambios sin guardar. ¿Está seguro de que desea cambiar?", "Confirmar el cambio", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If resultado = DialogResult.No Then
                    Return
                    'e.Cancel = True ' Cancelar el cierre del formulario
                Else
                    CambiosPendientes = False
                End If
            End If

            RichTextBox_Descripcion.Text = ""
            RichTextBox_Nota.Text = ""
        Catch ex As Exception

        End Try
        Try
            ' Validar si la celda seleccionada no es Nothing
            If Not IsNothing(DataGridView_Tareas.Rows(e.RowIndex).Cells("C_Id").Value) Then
                ' Actualizar la etiqueta con el ID del checklist seleccionado
                Label_ID.Text = DataGridView_Tareas.Rows(e.RowIndex).Cells("C_Id").Value.ToString()

                ' Obtener el checklist seleccionado
                Dim idChecklist = DataGridView_Tareas.Rows(e.RowIndex).Cells("C_Id").Value.ToString()
                _checklistSeleccionado = BaseDatos.Class_XmlChecklist.ObtenerID(idChecklist)

                ' Mostrar los detalles del checklist
                MostrarDetalleChecklist(True)

                ' Limpiar las filas actuales de DataGridView_Funciones
                DataGridView_Funciones.Rows.Clear()

                ' Poblar DataGridView_Funciones con los items del checklist
                For Each item As BaseDatos.Class_XmlChecklist.ChecklistItem In _checklistSeleccionado.Items
                    DataGridView_Funciones.Rows.Add(item.Id, item.Descripcion, item.Notas, item.Completado)
                Next
            Else
                ' Mostrar detalles vacíos si no hay selección
                MostrarDetalleChecklist(True)
                Label_ID.Text = "IsNothing"
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar checklist: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub MostrarDetalleChecklist(Optional ByVal Edicion As Boolean = False)
        'DataGridView_Funciones.DataSource = _checklistSeleccionado.Items
        TextBox_Titulo.Text = _checklistSeleccionado.Nombre
        ComboBox_Tipo.Text = _checklistSeleccionado.Tipo
        ComboBox_Tematica.Text = _checklistSeleccionado.Tematica

        _modoEdicion = Edicion
        HabilitarEdicion(Edicion)
    End Sub

    'Private Sub HabilitarEdicion(habilitar As Boolean)
    '    DataGridView_Funciones.ReadOnly = Not habilitar
    '    RichTextBox_Descripcion.ReadOnly = Not habilitar
    '    Button_Agregar.Visible = Not habilitar
    '    Button_Eliminar.Visible = Not habilitar
    '    Button_Actulizar.Visible = habilitar
    'End Sub
    Private Sub HabilitarEdicion(habilitar As Boolean)
        'DataGridView_Funciones.ReadOnly = Not habilitar
        'RichTextBox_Descripcion.ReadOnly = Not habilitar
        'Button_Agregar.Enabled = Not habilitar
        'Button_Eliminar.Enabled = Not habilitar
        'Button_Actulizar.Enabled = habilitar
        Button_Agregar.Enabled = Not habilitar
        Button_Eliminar.Enabled = habilitar
        Button_Actulizar.Enabled = habilitar

        Button_AgregarTarea.Enabled = habilitar
        Button_EliminarTarea.Enabled = False

        If habilitar Then
            Button_Agregar.BackColor = Color.LightGray
            Button_Eliminar.BackColor = SystemColors.Control
            Button_Actulizar.BackColor = SystemColors.Control
            Button_AgregarTarea.BackColor = SystemColors.Control
            Button_EliminarTarea.BackColor = SystemColors.Control
        Else
            Button_Agregar.BackColor = SystemColors.Control
            Button_Eliminar.BackColor = Color.LightGray
            Button_Actulizar.BackColor = Color.LightGray
            Button_AgregarTarea.BackColor = Color.LightGray
            Button_EliminarTarea.BackColor = Color.LightGray
        End If

        'If habilitar Then

        '    'DataGridView_Funciones.ReadOnly = habilitar
        '    'RichTextBox_Descripcion.ReadOnly = habilitar
        '    Button_Agregar.Enabled = Not habilitar
        '    Button_Eliminar.Enabled = habilitar
        '    Button_Actulizar.Enabled = habilitar


        '    Button_Agregar.BackColor = Color.LightGray
        '    Button_Eliminar.BackColor = Color.LightGray
        '    Button_Actulizar.BackColor = SystemColors.Control

        'Else

        '    'DataGridView_Funciones.ReadOnly = Not habilitar
        '    'RichTextBox_Descripcion.ReadOnly = Not habilitar
        '    Button_Agregar.Enabled = Not habilitar
        '    Button_Eliminar.Enabled = habilitar
        '    Button_Actulizar.Enabled = habilitar


        '    Button_Agregar.BackColor = SystemColors.Control
        '    Button_Eliminar.BackColor = SystemColors.Control
        '    Button_Actulizar.BackColor = Color.LightGray

        'End If
    End Sub

    'Private Sub Button_Agregar_Click(sender As Object, e As EventArgs) Handles Button_Agregar.Click
    '    Dim nuevoChecklist As New BaseDatos.Class_XmlChecklist.Checklist With {
    '        .Id = Guid.NewGuid().ToString(),
    '        .Nombre = "Nueva Plantilla",
    '        .Tipo = "General",
    '        .Items = New List(Of BaseDatos.Class_XmlChecklist.ChecklistItem)
    '    }

    '    If BaseDatos.Class_XmlChecklist.Agregar(nuevoChecklist) Then
    '        CargarChecklists()
    '    End If
    'End Sub

    'Private Sub Button_Actulizar_Click(sender As Object, e As EventArgs) Handles Button_Actulizar.Click
    '    Try
    '        _checklistSeleccionado.Nombre = RichTextBox_Texto.Text
    '        If BaseDatos.Class_XmlChecklist.Modificar(_checklistSeleccionado) Then
    '            CargarChecklists()
    '            HabilitarEdicion(False)
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("Error al actualizar: " & ex.Message)
    '    End Try
    'End Sub

    Private Sub Button_Eliminar_Click(sender As Object, e As EventArgs) Handles Button_Eliminar.Click
        If MessageBox.Show("¿Eliminar esta plantilla?", "Confirmar", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            If BaseDatos.Class_XmlChecklist.Eliminar(_checklistSeleccionado.Id) Then
                CargarChecklists() 'DataGridView_Tareas.DataSource = BaseDatos.Class_XmlChecklist.ObtenerAll()
                LimpiarDetalle()
            End If
        End If
    End Sub

    Private Sub LimpiarDetalle()
        _checklistSeleccionado = Nothing
        'DataGridView_Funciones.DataSource = Nothing
        RichTextBox_Descripcion.Clear()
    End Sub

    'Private Sub DataGridView_Funciones_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_Funciones.CellEndEdit
    '    If Not _checklistSeleccionado.Equals(Nothing) Then
    '        _checklistSeleccionado.Items = DirectCast(DataGridView_Funciones.DataSource, List(Of BaseDatos.Class_XmlChecklist.ChecklistItem))
    '    End If
    'End Sub
    Private Sub DataGridView_Tareas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_Tareas.CellContentClick
        Try
            CambiosPendientes = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView_Tareas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_Tareas.CellDoubleClick
        Try
            If MessageBox.Show("¿Desea agregar un nuevo registro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                _modoEdicion = False
                DataGridView_Funciones.ClearSelection()
                HabilitarEdicion(_modoEdicion)
                LimpiarCamposEdicion()
                Label_Status.Text = ""
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView_Funciones_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_Funciones.CellEndEdit
        Try
            If Not _checklistSeleccionado.Equals(Nothing) Then
                Dim item As BaseDatos.Class_XmlChecklist.ChecklistItem = DirectCast(DataGridView_Funciones.Rows(e.RowIndex).DataBoundItem, BaseDatos.Class_XmlChecklist.ChecklistItem)

                Select Case e.ColumnIndex
                    Case 0 ' Completado
                        item.Completado = CBool(DataGridView_Funciones.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                    Case 1 ' Descripción
                        item.Descripcion = CStr(DataGridView_Funciones.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                    Case 2 ' Notas
                        item.Notas = CStr(DataGridView_Funciones.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                End Select
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub SeleccionarFilaPorIndice(indice As Integer)
        Try
            ' Validar si el índice está dentro de los límites del DataGridView
            If indice >= 0 AndAlso indice < DataGridView_Funciones.Rows.Count Then
                ' Deseleccionar todas las filas primero
                DataGridView_Funciones.ClearSelection()

                ' Seleccionar la fila por su índice
                DataGridView_Funciones.Rows(indice).Selected = True

                ' Asegurar que la fila seleccionada sea visible
                DataGridView_Funciones.FirstDisplayedScrollingRowIndex = indice
            Else
                MessageBox.Show("Índice fuera de rango.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al seleccionar la fila: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    'Private Sub DataGridView_Funciones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_Funciones.CellDoubleClick
    '    HabilitarEdicion(True)
    '    _modoEdicion = True
    'End Sub

    Private Sub DataGridView_Funciones_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_Funciones.CellContentClick
        'Try
        '    CambiosPendientes = False
        'Catch ex As Exception

        'End Try
        Try
            Button_EliminarTarea.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView_Funciones_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_Funciones.RowEnter
        Try

            If Not IsNothing(_checklistSeleccionado.Id) Then

                'CambiosPendientes = True
                Button_EliminarTarea.Enabled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView_Funciones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_Funciones.CellDoubleClick

    End Sub

    Private Sub DataGridView_Funciones_CellClick2(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_Funciones.CellClick
        Try
            ' Validar índice para evitar errores en filas no válidas
            If e.RowIndex < 0 OrElse e.RowIndex >= DataGridView_Funciones.Rows.Count Then Return

            ' Seleccionar la fila correspondiente
            Me.DataGridView_Funciones.Rows.Item(e.RowIndex).Selected = True

            ' Obtener los valores de la fila seleccionada
            Dim TareaID As String = CStr(DataGridView_Funciones("CF_Id", e.RowIndex).Value).ToString.Trim
            RichTextBox_Descripcion.Text = CStr(DataGridView_Funciones("CF_Descripcion", e.RowIndex).Value).ToString.Trim

            ' Buscar la tarea seleccionada en la lista
            TareaSeleccionada = _checklistSeleccionado.Items.FirstOrDefault(Function(item) item.Id = TareaID)

            ' Actualizar otros controles si es necesario
            RichTextBox_Nota.Text = If(DataGridView_Funciones("CF_Notas", e.RowIndex).Value IsNot Nothing, CStr(DataGridView_Funciones("CF_Notas", e.RowIndex).Value).ToString.Trim, String.Empty)
            CheckBox_Completado.Checked = If(DataGridView_Funciones("CF_Completado", e.RowIndex).Value IsNot Nothing, Boolean.Parse(DataGridView_Funciones("CF_Completado", e.RowIndex).Value.ToString()), False)

        Catch ex As Exception
            MessageBox.Show("Error al seleccionar la tarea: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub DataGridView_Funciones_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_Funciones.CellClick
    '    Try
    '        Me.DataGridView_Funciones.Rows.Item(e.RowIndex).Selected = True

    '        Dim TareaID2 As String = CStr(DataGridView_Funciones("CF_Id", e.RowIndex).Value).ToString.Trim
    '        RichTextBox_Descripcion.Text = CStr(DataGridView_Funciones("CF_Descripcion", e.RowIndex).Value).ToString.Trim
    '        RichTextBox_Nota.Text = CStr(DataGridView_Funciones("CF_Notas", e.RowIndex).Value).ToString.Trim
    '        'RichTextBox_Nota.Text = CStr(DataGridView_Funciones("CF_Notas", e.RowIndex).Value).ToString.Trim

    '        'Dim SelectedRowIndex As Integer = DataGridView_Funciones.SelectedRows.Item(0).Index
    '        'If IsNothing(DataGridView_Funciones.Rows(SelectedRowIndex).Cells("CF_Id").Value) Then
    '        '    ' DataGridView_Funciones.Rows(SelectedRowIndex)
    '        '    Return
    '        'End If
    '        ''Dim TareaSelec As String = DataGridView_Funciones.Rows(SelectedRowIndex).Cells(3).Value.ToString()
    '        ''Dim TareaID As String = DataGridView_Funciones.SelectedRows(0).Cells(0).Value.ToString
    '        'Dim TareaID As String = DataGridView_Funciones.SelectedRows(0).Cells("CF_Id").Value.ToString()
    '        ''Dim tareaSeleccionada As BaseDatos.Class_XmlChecklist.ChecklistItem ' = DirectCast(DataGridView_Funciones.SelectedRows(0).DataBoundItem, BaseDatos.Class_XmlChecklist.ChecklistItem)
    '        ''For Indice As Integer = 0 To _checklistSeleccionado.Items.Count - 1
    '        ''    If _checklistSeleccionado.Items(Indice).Id = TareaID Then
    '        ''        tareaSeleccionada = _checklistSeleccionado.Items(Indice)
    '        ''    End If
    '        ''Next
    '        'Dim tareaSeleccionada As BaseDatos.Class_XmlChecklist.ChecklistItem = _checklistSeleccionado.Items.FirstOrDefault(Function(item) item.Id = TareaID)


    '        ' Dim tareaSeleccionada As BaseDatos.Class_XmlChecklist.ChecklistItem = _checklistSeleccionado.Items.FirstOrDefault(Function(item) item.Id = TareaID)

    '    Catch ex As Exception

    '    End Try
    'End Sub

#Region "Extras"

    Private Sub ConfigurarToolbar()
        Dim btnNuevo As New ToolStripButton("Nuevo") With {.Image = My.Resources.New_document}
        AddHandler btnNuevo.Click, AddressOf Button_Agregar_Click

        Dim btnGuardar As New ToolStripButton("Guardar") With {.Image = My.Resources.Save}
        AddHandler btnGuardar.Click, AddressOf Button_Actulizar_Click

        Dim ts As New ToolStrip With {.Dock = DockStyle.Top}
        ts.Items.AddRange({btnNuevo, btnGuardar})
        Me.Controls.Add(ts)
    End Sub


    Private Sub TextBox_Buscar_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Buscar.TextChanged
        '    Dim listaFiltrada = BaseDatos.Class_XmlChecklist.ObtenerAll.Where(
        '    Function(c) c.Nombre.ToLower().Contains(TextBox_Buscar.Text.ToLower()) Or
        '                    c.Tipo.ToLower().Contains(TextBox_Buscar.Text.ToLower())
        ').ToList()

        '    DataGridView_Tareas.DataSource = listaFiltrada
    End Sub
    Private Sub TextBox_Buscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Buscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True ' Previene el sonido de "beep"
            RealizarBusqueda()
        End If
    End Sub

    'Private Sub RealizarBusqueda()
    '    Try
    '        Dim textoBusqueda As String = TextBox_Buscar.Text.ToLower()
    '        Dim listaFiltrada = BaseDatos.Class_XmlChecklist.ObtenerAll().Where(
    '        Function(c) c.Nombre.ToLower().Contains(textoBusqueda) Or
    '                    c.Tipo.ToLower().Contains(textoBusqueda)
    '    ).ToList()

    '        DataGridView_Tareas.DataSource = listaFiltrada

    '        ' Opcional: Dar feedback al usuario
    '        Label_Status.Text = $"Se encontraron {listaFiltrada.Count} resultados."
    '    Catch ex As Exception
    '        MessageBox.Show("Error al realizar la búsqueda: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub


    Private Sub CargarTiposChecklist()
        ComboBox_Tipo.Items.AddRange({"Mecánica", "Recetas", "Mantenimiento", "Personalizado"})
        ComboBox_Tipo.SelectedIndex = 0
    End Sub


#End Region

#Region "Tematicas"

    Private Sub CargarTematicas()
        ComboBox_Tematica.Items.Clear()
        ComboBox_Tematica.Items.Add("Todas") ' Opción para mostrar todas las temáticas
        ComboBox_Tematica.Items.AddRange(BaseDatos.Class_XmlChecklist.ObtenerTematicasUnicas().ToArray())
        ComboBox_Tematica.SelectedIndex = 0 ' Selecciona "Todas" por defecto
    End Sub
    Private Sub CargarTipos()
        ComboBox_Tipo.Items.Clear()
        ComboBox_Tipo.Items.Add("Todos") ' Opción para mostrar todas las temáticas
        ComboBox_Tipo.Items.AddRange(BaseDatos.Class_XmlChecklist.ObtenerTiposUnicos().ToArray())
        ComboBox_Tipo.SelectedIndex = 0 ' Selecciona "Todas" por defecto
    End Sub

    '    Private Sub RealizarBusqueda()
    '        Try
    '            Dim textoBusqueda As String = TextBox_Buscar.Text.ToLower()
    '            Dim tematicaSeleccionada As String = ComboBox_Tematica.SelectedItem.ToString()

    '            Dim listaFiltrada = BaseDatos.Class_XmlChecklist.ObtenerAll().Where(
    '    Function(c) (c.Nombre.ToLower().Contains(textoBusqueda) Or
    '                    c.Tipo.ToLower().Contains(textoBusqueda)) And
    '                (tematicaSeleccionada = "Todas" Or c.Tematica = tematicaSeleccionada)
    ').ToList()

    '            DataGridView_Tareas.DataSource = listaFiltrada

    '            Label_Status.Text = $"Se encontraron {listaFiltrada.Count} resultados."
    '        Catch ex As Exception
    '            MessageBox.Show("Error al realizar la búsqueda: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try
    '    End Sub
    Private Sub RealizarBusqueda()
        Try
            Dim textoBusqueda As String = TextBox_Buscar.Text.ToLower()
            Dim tematicaSeleccionada As String = ComboBox_Tematica.SelectedItem.ToString()
            Dim listaFiltrada = BaseDatos.Class_XmlChecklist.ObtenerAll().Where(
Function(c) (c.Nombre.ToLower().Contains(textoBusqueda) Or c.Tipo.ToLower().Contains(textoBusqueda)) And (tematicaSeleccionada = "Todas" Or c.Tematica = tematicaSeleccionada)).ToList()

            DataGridView_Tareas.Rows.Clear()

            For Each checklist In listaFiltrada
                DataGridView_Tareas.Rows.Add(checklist.Id, checklist.Nombre, checklist.Tipo, checklist.Tematica)
            Next

            Label_Status.Text = $"Se encontraron {listaFiltrada.Count} resultados."
        Catch ex As Exception
            MessageBox.Show("Error al realizar la búsqueda: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ActualizarTematicas()
        Dim tematicaActual As String = ComboBox_Tematica.SelectedItem?.ToString()
        CargarTematicas()
        If Not String.IsNullOrEmpty(tematicaActual) AndAlso ComboBox_Tematica.Items.Contains(tematicaActual) Then
            ComboBox_Tematica.SelectedItem = tematicaActual
        Else
            ComboBox_Tematica.SelectedIndex = 0
        End If
    End Sub




#End Region


    Private Sub Button_Agregar_Click(sender As Object, e As EventArgs) Handles Button_Agregar.Click
        '        Dim nuevoChecklist As New BaseDatos.Class_XmlChecklist.Checklist With {
        '    .Id = Guid.NewGuid().ToString(),
        '    .Nombre = TextBox_Titulo.Text.Trim, ' "Nueva Plantilla",
        '    .Tipo = ComboBox_Tipo.Text.Trim, ' "General",
        '    .Tematica = ComboBox_Tematica.Text.Trim, ' "General",
        '    .Items = New List(Of BaseDatos.Class_XmlChecklist.ChecklistItem)
        '}

        '        If BaseDatos.Class_XmlChecklist.Agregar(nuevoChecklist) Then
        '            DataGridView_Tareas.DataSource = BaseDatos.Class_XmlChecklist.ObtenerAll()
        '        End If
        '        If BaseDatos.Class_XmlChecklist.Agregar(nuevoChecklist) Then
        '            DataGridView_Tareas.DataSource = BaseDatos.Class_XmlChecklist.ObtenerAll()
        '            ActualizarTematicas()
        '        End If
        '    End Sub

        'Private Sub Button_Agregar_Click(sender As Object, e As EventArgs) Handles Button_Agregar.Click
        '    Dim nuevoChecklist As New BaseDatos.Class_XmlChecklist.Checklist With {
        '        .Id = Guid.NewGuid().ToString(), .Nombre = TextBox_Titulo.Text.Trim, .Tipo = ComboBox_Tipo.Text.Trim, .Tematica = ComboBox_Tematica.Text.Trim, .Items = New List(Of BaseDatos.Class_XmlChecklist.ChecklistItem)
        '    }

        '    For indice As Integer = 0 To DataGridView_Funciones.Rows.Count - 1
        '        Dim NuevaTarea As New Class_XmlChecklist.ChecklistItem
        '        NuevaTarea.Id = DataGridView_Funciones
        '        NuevaTarea.Descripcion = DataGridView_Funciones
        '        NuevaTarea.Completado = False
        '        NuevaTarea.Notas = DataGridView_Funciones
        '        nuevoChecklist.Items.Add(NuevaTarea)
        '    Next

        '    If BaseDatos.Class_XmlChecklist.Agregar(nuevoChecklist) Then
        '        CargarChecklists()
        '        ActualizarTematicas()
        '        LimpiarCamposEdicion()
        '        MessageBox.Show("Checklist agregado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Else
        '        MessageBox.Show("No se pudo agregar el checklist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End If
        'End Sub
        '    Private Sub Button_Agregar_Click(sender As Object, e As EventArgs) Handles Button_Agregar.Click
        '        ' Crear un nuevo checklist con los datos ingresados
        '        Dim nuevoChecklist As New BaseDatos.Class_XmlChecklist.Checklist With {
        '    .Id = Guid.NewGuid().ToString(), ' Generar un nuevo ID único
        '    .Nombre = TextBox_Titulo.Text.Trim, ' Título del checklist
        '    .Tipo = ComboBox_Tipo.Text.Trim, ' Tipo seleccionado
        '    .Tematica = ComboBox_Tematica.Text.Trim, ' Temática seleccionada
        '    .Items = New List(Of BaseDatos.Class_XmlChecklist.ChecklistItem) ' Inicializar lista de items
        '}

        '        ' Recorrer las filas del DataGridView_Funciones para agregar los artículos
        '        For Each fila As DataGridViewRow In DataGridView_Funciones.Rows
        '            ' Evitar procesar filas nuevas vacías
        '            'If Not fila.IsNewRow Then
        '            Dim NuevaTarea As New BaseDatos.Class_XmlChecklist.ChecklistItem
        '            NuevaTarea.Id = Guid.NewGuid().ToString() ' Generar un ID único para cada tarea
        '            NuevaTarea.Descripcion = If(fila.Cells("CF_Descripcion").Value IsNot Nothing, fila.Cells("CF_Descripcion").Value.ToString(), String.Empty)
        '            NuevaTarea.Completado = If(fila.Cells("CF_Completado").Value IsNot Nothing, Convert.ToBoolean(fila.Cells("CF_Completado").Value), False)
        '            NuevaTarea.Notas = If(fila.Cells("CF_Notas").Value IsNot Nothing, fila.Cells("CF_Notas").Value.ToString(), String.Empty)

        '            ' Agregar la tarea al checklist
        '            nuevoChecklist.Items.Add(NuevaTarea)
        '            'End If
        '        Next



        Dim nuevoChecklist As New BaseDatos.Class_XmlChecklist.Checklist With {
        .Id = Guid.NewGuid().ToString(), .Nombre = TextBox_Titulo.Text.Trim, .Tipo = ComboBox_Tipo.Text.Trim, .Tematica = ComboBox_Tematica.Text.Trim, .Items = New List(Of BaseDatos.Class_XmlChecklist.ChecklistItem)}



        ' Agregar el nuevo checklist al sistema
        If BaseDatos.Class_XmlChecklist.Agregar(nuevoChecklist) Then
            CargarChecklists() ' Refrescar la lista de checklists
            ActualizarTematicas() ' Actualizar las temáticas disponibles
            LimpiarCamposEdicion() ' Limpiar los campos del formulario
            Label_ID.Text = nuevoChecklist.Id.ToString
            _checklistSeleccionado = nuevoChecklist

            _modoEdicion = True
            HabilitarEdicion(_modoEdicion)
            Label_Status.Text = "Checklist agregado con éxito."
            'MessageBox.Show("Checklist agregado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            DataGridView_Tareas.ClearSelection()

            Dim IndiceSeleccion As Integer = DataGridView_Tareas.Rows.Count - 1
            ' Seleccionar la fila por su índice
            DataGridView_Tareas.Rows(IndiceSeleccion).Selected = True

            ' Asegurar que la fila seleccionada sea visible
            DataGridView_Tareas.FirstDisplayedScrollingRowIndex = IndiceSeleccion

        Else


            MessageBox.Show("No se pudo agregar el checklist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    'Private Sub Button_Actulizar_Click(sender As Object, e As EventArgs) Handles Button_Actulizar.Click
    '    Try
    '        _checklistSeleccionado.Nombre = RichTextBox_Texto.Text
    '        If BaseDatos.Class_XmlChecklist.Modificar(_checklistSeleccionado) Then
    '            CargarChecklists()
    '            HabilitarEdicion(False)
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("Error al actualizar: " & ex.Message)
    '    End Try
    '    If BaseDatos.Class_XmlChecklist.Modificar(_checklistSeleccionado) Then
    '        CargarChecklists()
    '        ActualizarTematicas()
    '        HabilitarEdicion(False)
    '    End If
    'End Sub
    'Private Sub Button_Actulizar_Click(sender As Object, e As EventArgs) Handles Button_Actulizar.Click
    '    Try

    '        _checklistSeleccionado.Nombre = RichTextBox_Descripcion.Text
    '        _checklistSeleccionado.Tipo = ComboBox_Tipo.Text.Trim 'ComboBox_Tipo.SelectedItem.ToString()
    '        _checklistSeleccionado.Tematica = ComboBox_Tematica.Text.Trim 'ComboBox_Tematica.SelectedItem.ToString()

    '        If BaseDatos.Class_XmlChecklist.Modificar(_checklistSeleccionado) Then
    '            DataGridView_Tareas.DataSource = BaseDatos.Class_XmlChecklist.ObtenerAll()
    '            ActualizarTematicas()
    '            HabilitarEdicion(False)
    '            MessageBox.Show("Checklist actualizado con éxito.", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Else
    '            MessageBox.Show("No se pudo actualizar el checklist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("Error al actualizar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    Private Sub Button_Actulizar_Click(sender As Object, e As EventArgs) Handles Button_Actulizar.Click
        Try
            _checklistSeleccionado.Nombre = TextBox_Titulo.Text.ToString.Trim
            _checklistSeleccionado.Tipo = ComboBox_Tipo.Text.Trim
            _checklistSeleccionado.Tematica = ComboBox_Tematica.Text.Trim

            If BaseDatos.Class_XmlChecklist.Modificar(_checklistSeleccionado) Then
                ' Actualizar la fila correspondiente en el DataGridView
                For Each row As DataGridViewRow In DataGridView_Tareas.Rows
                    If row.Cells("C_Id").Value.ToString() = _checklistSeleccionado.Id Then
                        row.Cells("C_Nombre").Value = _checklistSeleccionado.Nombre
                        row.Cells("C_Tipo").Value = _checklistSeleccionado.Tipo
                        row.Cells("C_Tematica").Value = _checklistSeleccionado.Tematica
                        Exit For
                    End If
                Next

                ActualizarTematicas()
                HabilitarEdicion(False)
                Label_Status.Text = "Checklist actualizado con éxito."
                CambiosPendientes = False
                'MessageBox.Show("Checklist actualizado con éxito.", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No se pudo actualizar el checklist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al actualizar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button_AgregarTarea_Click(sender As Object, e As EventArgs) Handles Button_AgregarTarea.Click
        Try
            If _checklistSeleccionado.Equals(Nothing) Then
                MessageBox.Show("Por favor, seleccione un checklist primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim nuevaTarea As New BaseDatos.Class_XmlChecklist.ChecklistItem With {.Id = Guid.NewGuid().ToString(), .Descripcion = RichTextBox_Descripcion.Text, .Completado = CheckBox_Completado.Checked, .Notas = RichTextBox_Nota.Text.Trim}

            If (IsNothing(_checklistSeleccionado.Items)) Then
                _checklistSeleccionado.Items = New List(Of BaseDatos.Class_XmlChecklist.ChecklistItem)
            End If


            _checklistSeleccionado.Items.Add(nuevaTarea)
            'ActualizarGridTareas()
        Catch ex As Exception

        End Try
        Try
            ' ... (código existente) ...
            ActualizarGridTareas()
            CambiosPendientes = True
            SeleccionarFilaPorIndice(DataGridView_Funciones.Rows.Count - 1)
            'BaseDatos.Class_XmlChecklist.Modificar(_checklistSeleccionado)
        Catch ex As Exception
            MessageBox.Show("Error al agregar tarea: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button_EliminarTarea_Click(sender As Object, e As EventArgs) Handles Button_EliminarTarea.Click
        Try
            If DataGridView_Funciones.SelectedRows.Count = 0 Then
                MessageBox.Show("Por favor, seleccione una tarea para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim SelectedRowIndex As Integer = DataGridView_Funciones.SelectedRows.Item(0).Index
            If IsNothing(DataGridView_Funciones.Rows(SelectedRowIndex).Cells("CF_Id").Value) Then
                ' DataGridView_Funciones.Rows(SelectedRowIndex)
                Return
            End If
            'Dim TareaSelec As String = DataGridView_Funciones.Rows(SelectedRowIndex).Cells(3).Value.ToString()
            'Dim TareaID As String = DataGridView_Funciones.SelectedRows(0).Cells(0).Value.ToString
            Dim TareaID As String = DataGridView_Funciones.SelectedRows(0).Cells("CF_Id").Value.ToString()
            'Dim tareaSeleccionada As BaseDatos.Class_XmlChecklist.ChecklistItem ' = DirectCast(DataGridView_Funciones.SelectedRows(0).DataBoundItem, BaseDatos.Class_XmlChecklist.ChecklistItem)
            'For Indice As Integer = 0 To _checklistSeleccionado.Items.Count - 1
            '    If _checklistSeleccionado.Items(Indice).Id = TareaID Then
            '        tareaSeleccionada = _checklistSeleccionado.Items(Indice)
            '    End If
            'Next
            Dim tareaSeleccionada As BaseDatos.Class_XmlChecklist.ChecklistItem = _checklistSeleccionado.Items.FirstOrDefault(Function(item) item.Id = TareaID)

            If MessageBox.Show("¿Está seguro de que desea eliminar esta tarea?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Try
                    _checklistSeleccionado.Items.Remove(tareaSeleccionada)
                    ActualizarGridTareas()
                    CambiosPendientes = True
                Catch ex As Exception

                End Try

                'Try
                'BaseDatos.Class_XmlChecklist.Modificar(_checklistSeleccionado)
                'Catch ex As Exception
                'MessageBox.Show("Error al eliminar tarea: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End Try

                Button_EliminarTarea.Enabled = False

            End If
        Catch ex As Exception

        End Try

    End Sub




    Private Sub ActualizarGridTareas2()
        ' DataGridView_Funciones.Rows.Clear()

        ' If _checklistSeleccionado IsNot Nothing AndAlso
        '_checklistSeleccionado.Items IsNot Nothing Then

        '     For Each item In _checklistSeleccionado.Items
        '         DataGridView_Funciones.Rows.Add(
        '         item.Completado,
        '         item.Descripcion,
        '         item.Notas,
        '         item.Id ' Columna oculta
        '     )
        '     Next
        ' End If
    End Sub



    Private Sub ActualizarGridTareas()
        'DataGridView_Funciones.DataSource = Nothing
        'DataGridView_Funciones.DataSource = _checklistSeleccionado.Items
        'DataGridView_Funciones.Refresh()

        If DataGridView_Funciones.Rows.Count > 0 Then
            DataGridView_Funciones.Rows.Clear()
        End If

        If IsNothing(_checklistSeleccionado.Items) = False Then

            For Each item As BaseDatos.Class_XmlChecklist.ChecklistItem In _checklistSeleccionado.Items

                DataGridView_Funciones.Rows.Add(item.Id, item.Descripcion, item.Notas, item.Completado)

            Next

        End If

        DataGridView_Funciones.Refresh()
    End Sub
    Private Sub LimpiarCamposEdicion()
        Label_ID.Text = ""
        RichTextBox_Descripcion.Clear()
        CheckBox_Completado.Checked = False
        RichTextBox_Nota.Clear()
        DataGridView_Funciones.Rows.Clear()
        CambiosPendientes = False
        _checklistSeleccionado = New Class_XmlChecklist.Checklist
        TareaSeleccionada = New Class_XmlChecklist.ChecklistItem

    End Sub


    Private Sub ActualizarGrid()
        CargarChecklists()
        If DataGridView_Tareas.Rows.Count > 0 Then
            DataGridView_Tareas.Rows(0).Selected = True
        End If
    End Sub

    Private Sub CargarChecklists()
        Try
            DataGridView_Tareas.Rows.Clear()

            For Each checklist In BaseDatos.Class_XmlChecklist.ObtenerAll()
                DataGridView_Tareas.Rows.Add(checklist.Id, checklist.Nombre, checklist.Tipo, checklist.Tematica)
            Next

        Catch ex As Exception
            MessageBox.Show("Error al cargar checklists: " & ex.Message)
        End Try
    End Sub

    Private CambiosPendientes As Boolean = False

    ' Evento para manejar la salida sin guardar
    Private Sub Form_Checklist_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If CambiosPendientes Then
            Dim resultado As DialogResult = MessageBox.Show("Tiene cambios sin guardar. ¿Está seguro de que desea salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If resultado = DialogResult.No Then
                e.Cancel = True ' Cancelar el cierre del formulario
            End If
        End If
    End Sub

    ' Guardar los cambios y resetear estado
    Private Sub GuardarCambios()
        Try
            If BaseDatos.Class_XmlChecklist.Modificar(_checklistSeleccionado) Then
                CambiosPendientes = False
                MessageBox.Show("Cambios guardados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error al guardar cambios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al intentar guardar los cambios: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RichTextBox_Descripcion_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox_Descripcion.TextChanged
        Try

            If Not IsNothing(_checklistSeleccionado.Id) Then

                CambiosPendientes = True
                Button_AgregarTarea.Enabled = True
            End If

        Catch ex As Exception

        End Try
        Try

            If Not IsNothing(TareaSeleccionada.Id) And Not IsNothing(_checklistSeleccionado.Id) Then
                TareaSeleccionada.Descripcion = RichTextBox_Descripcion.Text
                ' Asegurarse de que la tarea esté sincronizada con la lista de _checklistSeleccionado
                Dim index As Integer = _checklistSeleccionado.Items.FindIndex(Function(item) item.Id = TareaSeleccionada.Id)
                If index >= 0 Then
                    _checklistSeleccionado.Items(index) = TareaSeleccionada
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RichTextBox_Nota_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox_Nota.TextChanged
        Try

            If Not IsNothing(_checklistSeleccionado.Id) Then
                CambiosPendientes = True
            End If

        Catch ex As Exception

        End Try
        Try

            If Not IsNothing(TareaSeleccionada.Id) And Not IsNothing(_checklistSeleccionado.Id) Then
                TareaSeleccionada.Notas = RichTextBox_Nota.Text
                ' Asegurarse de que la tarea esté sincronizada con la lista de _checklistSeleccionado
                Dim index As Integer = _checklistSeleccionado.Items.FindIndex(Function(item) item.Id = TareaSeleccionada.Id)
                If index >= 0 Then
                    _checklistSeleccionado.Items(index) = TareaSeleccionada
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub


    'Private Sub RichTextBox_Descripcion_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox_Descripcion.TextChanged
    '    ActualizarTareaSeleccionada("Descripcion", RichTextBox_Descripcion.Text)
    'End Sub

    'Private Sub RichTextBox_Nota_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox_Nota.TextChanged
    '    ActualizarTareaSeleccionada("Notas", RichTextBox_Nota.Text)
    'End Sub

    'Private Sub ActualizarTareaSeleccionada(campo As String, valor As String)
    '    Try
    '        ' Marcar cambios pendientes si el checklist está seleccionado
    '        If _checklistSeleccionado IsNot Nothing AndAlso Not String.IsNullOrEmpty(_checklistSeleccionado.Id) Then
    '            CambiosPendientes = True
    '        End If

    '        ' Actualizar el campo correspondiente en la tarea seleccionada
    '        If TareaSeleccionada IsNot Nothing Then
    '            Select Case campo
    '                Case "Descripcion"
    '                    TareaSeleccionada.Descripcion = valor
    '                Case "Notas"
    '                    TareaSeleccionada.Notas = valor
    '            End Select
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show($"Error al actualizar el campo {campo}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub


End Class
