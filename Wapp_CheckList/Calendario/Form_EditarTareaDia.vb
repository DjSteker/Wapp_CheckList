Public Class Form_EditarTareaDia
    Public Property TareaAEditar As New Calendario.TareaDiaria ' Calendario.Class_GestorTareasDiarias.TareaDiaria

    ' Controles del formulario
    Private lblFecha As New Label
    Private txtDescripcion As New TextBox
    Private dtpHora As New DateTimePicker
    Private btnGuardar As New Button
    Private btnEliminar As New Button
    Private btnCancelar As New Button

    Public Sub New()
        ' Inicialización del formulario
        Me.Text = "Editar Tarea"
        Me.Size = New Size(400, 300)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ShowInTaskbar = False
        Me.ControlBox = False

        ' Configurar controles
        lblFecha.Text = "Fecha:"
        lblFecha.Location = New Point(20, 20)
        lblFecha.Size = New Size(360, 20)

        txtDescripcion.Location = New Point(20, 60)
        txtDescripcion.Size = New Size(360, 50)

        dtpHora.Format = DateTimePickerFormat.Time
        dtpHora.ShowUpDown = True
        dtpHora.Location = New Point(20, 130)

        btnGuardar.Text = "Guardar"
        btnGuardar.Location = New Point(20, 200)

        btnEliminar.Text = "Eliminar"
        btnEliminar.Location = New Point(140, 200)

        btnCancelar.Text = "Cancelar"
        btnCancelar.Location = New Point(260, 200)

        ' Eventos de los botones
        AddHandler btnGuardar.Click, AddressOf GuardarTarea
        AddHandler btnEliminar.Click, AddressOf EliminarTarea
        AddHandler btnCancelar.Click, AddressOf Cancelar

        ' Agregar controles al formulario
        Me.Controls.Add(lblFecha)
        Me.Controls.Add(txtDescripcion)
        Me.Controls.Add(dtpHora)
        Me.Controls.Add(btnGuardar)
        Me.Controls.Add(btnEliminar)
        Me.Controls.Add(btnCancelar)
    End Sub

    ' Mostrar datos de la tarea
    Private Sub Form_EditarTareaDia_Load(sender As Object, e As EventArgs) Handles Me.Load
        If TareaAEditar.Id IsNot Nothing Then
            lblFecha.Text = $"Fecha: {TareaAEditar.Fecha.ToLongDateString()}"
            txtDescripcion.Text = TareaAEditar.Descripcion
            dtpHora.Value = If(TareaAEditar.Hora.HasValue, Date.Today.Add(TareaAEditar.Hora.Value), Date.Now)
        End If
    End Sub

    ' Guardar los cambios
    Private Sub GuardarTarea(sender As Object, e As EventArgs)
        ' Actualizar los datos de la tarea
        'TareaAEditar.Descripcion = txtDescripcion.Text
        'TareaAEditar.Hora = dtpHora.Value.TimeOfDay

        ' Guardar la tarea en el archivo
        ' Aquí debes implementar la lógica para guardar los cambios en el archivo
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    ' Eliminar la tarea
    Private Sub EliminarTarea(sender As Object, e As EventArgs)
        ' Mostrar un mensaje de confirmación
        If MessageBox.Show("¿Está seguro de que desea eliminar esta tarea?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ' Eliminar la tarea del archivo
            ' Aquí debes implementar la lógica para eliminar la tarea del archivo
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    ' Cancelar la edición
    Private Sub Cancelar(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
