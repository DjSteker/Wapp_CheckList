Public Class Form_AgregarNuevaTarea

    Public Property FechaSeleccionada As DateTime
    Public TareaCreada As New Calendario.TareaDiaria

    'Private Sub Form_AgregarNuevaTarea_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '        Me.Text = "Agregar Nueva Tarea"
    '        Me.Size = New Size(400, 300)
    '        Me.StartPosition = FormStartPosition.CenterScreen

    '        ' Etiqueta para mostrar la fecha seleccionada
    '        Dim lblFecha As New Label With {
    '        .Text = $"Fecha seleccionada: {FechaSeleccionada.ToString("dddd, dd MMMM yyyy")}",
    '        .Font = New Font("Arial", 12),
    '        .Size = New Size(350, 30),
    '        .Location = New Point(20, 20)
    '    }
    '        Me.Controls.Add(lblFecha)

    '        ' ComboBox para seleccionar una tarea del CheckList
    '        Dim lblChecklist As New Label With {
    '        .Text = "Seleccionar tarea del CheckList:",
    '        .Font = New Font("Arial", 10),
    '        .Size = New Size(200, 20),
    '        .Location = New Point(20, 60)
    '    }
    '        Me.Controls.Add(lblChecklist)

    '        Dim cmbChecklist As New ComboBox With {
    '        .Name = "cmbChecklist",
    '        .DropDownStyle = ComboBoxStyle.DropDownList,
    '        .Size = New Size(300, 30),
    '        .Location = New Point(20, 90)
    '    }
    '        Me.Controls.Add(cmbChecklist)

    '        ' Cargar tareas del checklist en el ComboBox
    '        Dim checklists = BaseDatos.Class_XmlChecklist.ObtenerAll()
    '        For Each checklist In checklists
    '            For Each item In checklist.Items
    '                cmbChecklist.Items.Add(New With {
    '                Key .Id = item.Id,
    '                Key .Descripcion = item.Descripcion
    '            })
    '            Next
    '        Next

    '        ' TextBox para descripción personalizada
    '        Dim lblDescripcion As New Label With {
    '        .Text = "Descripción personalizada:",
    '        .Font = New Font("Arial", 10),
    '        .Size = New Size(200, 20),
    '        .Location = New Point(20, 130)
    '    }
    '        Me.Controls.Add(lblDescripcion)

    '        Dim txtDescripcion As New TextBox With {
    '        .Name = "txtDescripcion",
    '        .Size = New Size(300, 30),
    '        .Location = New Point(20, 160)
    '    }
    '        Me.Controls.Add(txtDescripcion)

    '        ' DateTimePicker para establecer la hora de la tarea
    '        Dim lblHora As New Label With {
    '        .Text = "Hora de la tarea:",
    '        .Font = New Font("Arial", 10),
    '        .Size = New Size(200, 20),
    '        .Location = New Point(20, 200)
    '    }
    '        Me.Controls.Add(lblHora)

    '        Dim dtpHora As New DateTimePicker With {
    '        .Name = "dtpHora",
    '        .Format = DateTimePickerFormat.Time,
    '        .ShowUpDown = True,
    '        .Size = New Size(150, 30),
    '        .Location = New Point(20, 230)
    '    }
    '        Me.Controls.Add(dtpHora)

    '        ' Botones Guardar y Cancelar
    '        Dim btnGuardar As New Button With {
    '        .Text = "Guardar",
    '        .Size = New Size(100, 30),
    '        .Location = New Point(50, 270)
    '    }
    '        AddHandler btnGuardar.Click, AddressOf GuardarTarea
    '        Me.Controls.Add(btnGuardar)

    '        Dim btnCancelar As New Button With {
    '        .Text = "Cancelar",
    '        .Size = New Size(100, 30),
    '        .Location = New Point(200, 270)
    '    }
    '    AddHandler btnCancelar.Click, Sub() DialogResult = DialogResult.Cancel : Me.Close()
    '        Me.Controls.Add(btnCancelar)
    '    End Sub


    Private Sub Form_AgregarNuevaTarea_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Agregar Nueva Tarea"
        Me.Size = New Size(400, 350)
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Etiqueta para mostrar la fecha seleccionada
        Dim lblFecha As New Label With {
            .Text = $"Fecha seleccionada: {FechaSeleccionada.ToString("dddd, dd MMMM yyyy")}",
            .Font = New Font("Arial", 12),
            .Size = New Size(350, 30),
            .Location = New Point(20, 20)
        }
        Me.Controls.Add(lblFecha)

        ' ComboBox para seleccionar una tarea del CheckList
        Dim lblChecklist As New Label With {
            .Text = "Seleccionar tarea del CheckList:",
            .Font = New Font("Arial", 10),
            .Size = New Size(200, 20),
            .Location = New Point(20, 60)
        }
        Me.Controls.Add(lblChecklist)

        Dim cmbChecklist As New ComboBox With {
            .Name = "cmbChecklist",
            .DropDownStyle = ComboBoxStyle.DropDownList,
            .Size = New Size(300, 30),
            .Location = New Point(20, 90),
            .DisplayMember = "Descripcion", ' Lo que se muestra al usuario
            .ValueMember = "Id"           ' Lo que se usa internamente 
        }
        Me.Controls.Add(cmbChecklist)

        ' Cargar tareas del checklist en el ComboBox
        Dim checklists = BaseDatos.Class_XmlChecklist.ObtenerAll()
        For Each checklist In checklists
            For Each item In checklist.Items
                cmbChecklist.Items.Add(New With {Key .Id = item.Id, Key .Descripcion = item.Descripcion})
            Next
        Next

        ' TextBox para descripción personalizada
        Dim lblDescripcion As New Label With {
            .Text = "Descripción personalizada:",
            .Font = New Font("Arial", 10),
            .Size = New Size(200, 20),
            .Location = New Point(20, 130)
        }
        Me.Controls.Add(lblDescripcion)

        Dim txtDescripcion As New TextBox With {
            .Name = "txtDescripcion",
            .Size = New Size(300, 30),
            .Location = New Point(20, 160)
        }
        Me.Controls.Add(txtDescripcion)

        ' DateTimePicker para establecer la hora de la tarea
        Dim lblHora As New Label With {
            .Text = "Hora de la tarea:",
            .Font = New Font("Arial", 10),
            .Size = New Size(200, 20),
            .Location = New Point(20, 200)
        }
        Me.Controls.Add(lblHora)

        Dim dtpHora As New DateTimePicker With {
            .Name = "dtpHora",
            .Format = DateTimePickerFormat.Time,
            .ShowUpDown = True,
            .Size = New Size(150, 30),
            .Location = New Point(20, 230)
        }
        Me.Controls.Add(dtpHora)

        ' Botones Guardar y Cancelar
        Dim btnGuardar As New Button With {
            .Text = "Guardar",
            .Size = New Size(100, 30),
            .Location = New Point(50, 270)
        }
        AddHandler btnGuardar.Click, AddressOf GuardarTarea
        Me.Controls.Add(btnGuardar)

        Dim btnCancelar As New Button With {
            .Text = "Cancelar",
            .Size = New Size(100, 30),
            .Location = New Point(200, 270)
        }
        AddHandler btnCancelar.Click, Sub()
                                          Me.DialogResult = DialogResult.Cancel
                                          Me.Close()
                                      End Sub
        Me.Controls.Add(btnCancelar)
    End Sub

    Private Sub GuardarTarea(sender As Object, e As EventArgs)
        Try
            ' Obtener datos de los controles
            Dim cmbChecklist As ComboBox = CType(Me.Controls("cmbChecklist"), ComboBox)
            Dim txtDescripcion As TextBox = CType(Me.Controls("txtDescripcion"), TextBox)
            Dim dtpHora As DateTimePicker = CType(Me.Controls("dtpHora"), DateTimePicker)

            ' Crear nueva tarea
            TareaCreada.Id = Guid.NewGuid().ToString()
            TareaCreada.Fecha = FechaSeleccionada
            TareaCreada.Hora = dtpHora.Value.TimeOfDay

            If cmbChecklist.SelectedItem IsNot Nothing Then
                TareaCreada.ChecklistId = CType(cmbChecklist.SelectedItem, Object).Id
                TareaCreada.Descripcion = CType(cmbChecklist.SelectedItem, Object).Descripcion
            ElseIf Not String.IsNullOrWhiteSpace(txtDescripcion.Text) Then
                TareaCreada.Descripcion = txtDescripcion.Text.Trim()
                TareaCreada.ChecklistId = Nothing ' No está vinculada a un checklist
            Else
                MessageBox.Show("Debe seleccionar una tarea o ingresar una descripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Cerrar el formulario con éxito
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show($"Error al guardar la tarea: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub GuardarTarea(sender As Object, e As EventArgs)
    '    Try
    '        ' Obtener datos de los controles
    '        Dim cmbChecklist As ComboBox = CType(Me.Controls("cmbChecklist"), ComboBox)
    '        Dim txtDescripcion As TextBox = CType(Me.Controls("txtDescripcion"), TextBox)
    '        Dim dtpHora As DateTimePicker = CType(Me.Controls("dtpHora"), DateTimePicker)

    '        ' Crear nueva tarea
    '        TareaCreada.Id = Guid.NewGuid().ToString()
    '        TareaCreada.Fecha = FechaSeleccionada
    '        TareaCreada.Hora = dtpHora.Value.TimeOfDay

    '        If cmbChecklist.SelectedItem IsNot Nothing Then
    '            TareaCreada.ChecklistId = CType(cmbChecklist.SelectedItem, Object).Id
    '            TareaCreada.Descripcion = CType(cmbChecklist.SelectedItem, Object).Descripcion
    '        ElseIf Not String.IsNullOrWhiteSpace(txtDescripcion.Text) Then
    '            TareaCreada.Descripcion = txtDescripcion.Text.Trim()
    '            TareaCreada.ChecklistId = Nothing ' No está vinculada a un checklist
    '        Else
    '            MessageBox.Show("Debe seleccionar una tarea o ingresar una descripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Return
    '        End If

    '        ' Cerrar el formulario con éxito
    '        Me.DialogResult = DialogResult.OK
    '        Me.Close()
    '    Catch ex As Exception
    '        MessageBox.Show($"Error al guardar la tarea: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    ' En el formulario Form_Calendario (corrección del método AgregarNuevaTarea)
    'Private Sub AgregarNuevaTarea(fecha As DateTime)
    '    Using dialogoNuevaTarea As New Form_AgregarNuevaTarea()
    '        ' Pasar la fecha seleccionada al formulario
    '        dialogoNuevaTarea.FechaSeleccionada = fecha

    '        If dialogoNuevaTarea.ShowDialog() = DialogResult.OK Then
    '            ' Validar que se creó una tarea válida
    '            If dialogoNuevaTarea.TareaCreada.Id IsNot Nothing Then
    '                BaseDatos.GestorTareasDiarias.Agregar(dialogoNuevaTarea.TareaCreada)
    '                ActualizarVistaDia(fecha)
    '            Else
    '                MessageBox.Show("No se pudo crear la tarea. Verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            End If
    '        End If
    '    End Using
    'End Sub

    '' Método para actualizar la vista del día
    'Private Sub ActualizarVistaDia(fecha As DateTime)
    '    ' Limpiar controles antiguos
    '    For Each ctrl As Control In Me.Controls.OfType(Of Panel).Where(Function(p) p.Name = "pnlDetalles")
    '        Me.Controls.Remove(ctrl)
    '    Next

    '    ' Volver a cargar los detalles del día
    '    Calendario_DiaSeleccionado(fecha)
    'End Sub


End Class