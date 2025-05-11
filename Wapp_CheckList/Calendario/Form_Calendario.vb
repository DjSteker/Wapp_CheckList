
Public Class Form_Calendario
    Private WithEvents CalendarioControl As New Calendario.Class_CalendarioGrafico
    Private WithEvents btnAnterior As New Button
    Private WithEvents btnSiguiente As New Button
    Private WithEvents lblMesAnio As New Label
    Private WithEvents pnlControles As New Panel

    Private Sub Form_Calendario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarInterfaz()
        ConfigurarCalendario()
    End Sub

    Private Sub ConfigurarInterfaz()
        ' Configuración principal del formulario
        Me.Size = New Size(800, 600)
        Me.Text = "Calendario Interactivo"
        Me.BackColor = Color.WhiteSmoke

        ' Panel de controles superiores
        pnlControles.Dock = DockStyle.Top
        pnlControles.Height = 50
        pnlControles.BackColor = Color.LightSteelBlue

        ' Botones de navegación
        btnAnterior.Text = "◄"
        btnAnterior.Size = New Size(45, 30)
        btnAnterior.Location = New Point(20, 10)
        btnAnterior.Font = New Font("Arial", 12, FontStyle.Bold)
        btnAnterior.FlatStyle = FlatStyle.Flat
        btnAnterior.FlatAppearance.BorderSize = 0

        btnSiguiente.Text = "►"
        btnSiguiente.Size = New Size(45, 30)
        btnSiguiente.Location = New Point(300, 10)
        btnSiguiente.Font = New Font("Arial", 12, FontStyle.Bold)
        btnSiguiente.FlatStyle = FlatStyle.Flat
        btnSiguiente.FlatAppearance.BorderSize = 0

        ' Etiqueta de mes/año
        lblMesAnio.Size = New Size(200, 30)
        lblMesAnio.Location = New Point(80, 10)
        lblMesAnio.Font = New Font("Arial", 14, FontStyle.Bold)
        lblMesAnio.ForeColor = Color.DarkBlue
        lblMesAnio.TextAlign = ContentAlignment.MiddleCenter

        ' Calendario gráfico
        CalendarioControl.Size = New Size(500, 400)
        CalendarioControl.Location = New Point(20, 70)
        CalendarioControl.BackColor = Color.White
        CalendarioControl.ColorDiaActual = Color.LightSkyBlue
        CalendarioControl.ColorBorde = Color.SteelBlue

        ' Agregar controles al panel
        pnlControles.Controls.Add(btnAnterior)
        pnlControles.Controls.Add(btnSiguiente)
        pnlControles.Controls.Add(lblMesAnio)

        ' Agregar controles al formulario
        Me.Controls.Add(pnlControles)
        Me.Controls.Add(CalendarioControl)
    End Sub

    Private Sub ConfigurarCalendario()
        ActualizarTituloMes()
        AddHandler CalendarioControl.DiaSeleccionado, AddressOf Calendario_DiaSeleccionado
    End Sub

    Private Sub ActualizarTituloMes()
        lblMesAnio.Text = CalendarioControl.FechaActual.ToString("MMMM yyyy") '.ToUpper()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        CalendarioControl.CambiarMes(-1)
        ActualizarTituloMes()
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        CalendarioControl.CambiarMes(1)
        ActualizarTituloMes()
    End Sub

    'Private Sub Calendario_DiaSeleccionado(fecha As DateTime)
    '    Dim pnlDetalles As New Panel With {
    '    .Size = New Size(250, 400),
    '    .Location = New Point(530, 70),
    '    .BackColor = Color.White,
    '    .BorderStyle = BorderStyle.FixedSingle
    '}

    '    Dim lblInfo As New Label With {
    '    .Text = $"Fecha seleccionada: {fecha:dddd, dd MMMM yyyy}",
    '    .Font = New Font("Arial", 12),
    '    .Size = New Size(230, 60),
    '    .Location = New Point(10, 20),
    '    .TextAlign = ContentAlignment.MiddleCenter
    '}

    '    ' Eliminar detalles anteriores
    '    For Each ctrl As Control In Me.Controls.OfType(Of Panel).Where(Function(p) p.Name = "pnlDetalles")
    '        Me.Controls.Remove(ctrl)
    '    Next

    '    pnlDetalles.Name = "pnlDetalles"
    '    pnlDetalles.Controls.Add(lblInfo)
    '    Me.Controls.Add(pnlDetalles)
    'End Sub

    Private Sub Calendario_DiaSeleccionado(fecha As DateTime)
        ' Panel para mostrar detalles del día seleccionado.
        Dim pnlDetalles As New Panel With {
    .Size = New Size(250, 400),
    .Location = New Point(530, 70),
    .BackColor = Color.White,
    .BorderStyle = BorderStyle.FixedSingle,
    .Name = "pnlDetalles"
}

        ' Etiqueta con la fecha seleccionada.
        Dim lblInfo As New Label With {
    .Text = $"Fecha seleccionada: {fecha:dddd, dd MMMM yyyy}",
    .Font = New Font("Arial", 12),
    .Size = New Size(230, 60),
    .Location = New Point(10, 20),
    .TextAlign = ContentAlignment.MiddleCenter
}

        ' Botón para agregar nueva tarea.
        Dim btnAgregarTarea As New Button With {
    .Text = "Agregar Tarea",
    .Size = New Size(120, 30),
    .Location = New Point(10, 90)
}
        AddHandler btnAgregarTarea.Click, Sub() AgregarNuevaTarea(fecha)

        ' DataGridView para mostrar tareas del día.
        Dim dgvDetalles As New DataGridView With {
    .Size = New Size(230, 250),
    .Location = New Point(10, 130),
    .AllowUserToAddRows = False,
    .AllowUserToDeleteRows = False,
    .ReadOnly = True,
    .AutoGenerateColumns = False,
    .RowHeadersVisible = False,
    .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
    .BackgroundColor = Color.WhiteSmoke,
    .BorderStyle = BorderStyle.FixedSingle
}
        dgvDetalles.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Descripcion", .HeaderText = "Descripción", .Width = 150})
        dgvDetalles.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Hora", .HeaderText = "Hora", .Width = 70})

        ' Cargar tareas del día.
        Dim tareasDelDia = Calendario.Class_GestorTareasDiarias.ObtenerPorFecha(fecha)
        For Each tarea In tareasDelDia
            dgvDetalles.Rows.Add(tarea.Descripcion, If(tarea.Hora.HasValue, tarea.Hora.Value.ToString(), ""))
        Next

        ' Limpiar paneles anteriores y agregar nuevos controles.
        For Each ctrl In Me.Controls.OfType(Of Panel).Where(Function(p) p.Name = "pnlDetalles")
            Me.Controls.Remove(ctrl)
        Next

        pnlDetalles.Controls.Add(lblInfo)
        pnlDetalles.Controls.Add(btnAgregarTarea)
        pnlDetalles.Controls.Add(dgvDetalles)
        Me.Controls.Add(pnlDetalles)
    End Sub

    'Private Sub AgregarNuevaTarea(fecha As DateTime)
    '    Using dialogoNuevaTarea As New Form_AgregarNuevaTarea(fecha) ' Crear formulario específico para ingresar datos.
    '        If dialogoNuevaTarea.ShowDialog() = DialogResult.OK Then
    '            Calendario.Class_GestorTareasDiarias.Agregar(dialogoNuevaTarea.TareaCreada) ' Guardar la nueva tarea.
    '            Calendario_DiaSeleccionado(fecha) ' Recargar las tareas del día.
    '        End If
    '    End Using
    'End Sub
    Private Sub AgregarNuevaTarea(fecha As DateTime)
        Using dialogoNuevaTarea As New Form_AgregarNuevaTarea()
            dialogoNuevaTarea.FechaSeleccionada = fecha

            If dialogoNuevaTarea.ShowDialog() = DialogResult.OK Then
                Calendario.Class_GestorTareasDiarias.Agregar(dialogoNuevaTarea.TareaCreada) ' Guardar la nueva tarea.

                ' Recargar las tareas del día seleccionado en el calendario.
                Calendario_DiaSeleccionado(fecha)
            End If
        End Using
    End Sub


End Class
