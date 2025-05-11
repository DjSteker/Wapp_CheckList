Imports System.IO
Imports Wapp_CheckList.BaseDatos.Class_XmlChecklist

Imports System.Text.Json
Imports System.Logging


Public Class Form_CheckListV2
    Private Sub Form_CheckListV2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    '' Logging
    'Private Shared ReadOnly Logger As ILogger = LoggerFactory.GetLogger(GetType(EnhancedChecklistForm))

    '    ' Input Validation
    '    Private Function ValidateInput() As Boolean
    '        If String.IsNullOrWhiteSpace(TextBox_Titulo.Text) Then
    '            MessageBox.Show("El título no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Return False
    '        End If

    '        If ComboBox_Tipo.SelectedIndex = -1 Then
    '            MessageBox.Show("Debe seleccionar un tipo de checklist.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Return False
    '        End If

    '        Return True
    '    End Function

    '    ' Export Functionality
    '    Private Sub ExportChecklists(format As String)
    '        Try
    '            Dim checklists = BaseDatos.Class_XmlChecklist.ObtenerAll()

    '            Select Case format
    '                Case "CSV"
    '                    ExportToCSV(checklists)
    '                Case "JSON"
    '                    ExportToJSON(checklists)
    '                Case "PDF"
    '                    ExportToPDF(checklists)
    '            End Select
    '        Catch ex As Exception
    '            Logger.Error("Error exportando checklists", ex)
    '            MessageBox.Show($"Error al exportar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try
    '    End Sub

    ' Keyboard Shortcuts

    'Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
    '    If e.Control Then
    '        Select Case e.KeyCode
    '            Case Keys.S
    '                GuardarCambios()
    '            Case Keys.N
    '                LimpiarCamposEdicion()
    '            Case Keys.F
    '                TextBox_Buscar.Focus()
    '        End Select
    '    End If
    'End Sub

    '' Advanced Search
    'Private Sub AdvancedSearch()
    '    Dim busqueda As New AdvancedSearchDialog()
    '    If busqueda.ShowDialog() = DialogResult.OK Then
    '        Dim resultados = FiltrarChecklists(
    '        busqueda.TextoBusqueda,
    '        busqueda.TipoSeleccionado,
    '        busqueda.TematicaSeleccionada,
    '        busqueda.FechaDesde,
    '        busqueda.FechaHasta,
    '        busqueda.SoloCompletados
    '    )
    '        ActualizarGridResultados(resultados)
    '    End If
    'End Sub

    '' Recurring Tasks
    'Private Sub CrearTareaRecurrente(tarea As ChecklistItem, frecuencia As RecurrenceType, cantidadVeces As Integer)
    '    Dim fechaBase = DateTime.Now

    '    For i As Integer = 0 To cantidadVeces - 1
    '        Dim nuevaTarea = tarea.Clone()
    '        nuevaTarea.Id = Guid.NewGuid().ToString()

    '        Select Case frecuencia
    '            Case RecurrenceType.Diario
    '                nuevaTarea.FechaVencimiento = fechaBase.AddDays(i)
    '            Case RecurrenceType.Semanal
    '                nuevaTarea.FechaVencimiento = fechaBase.AddDays(i * 7)
    '            Case RecurrenceType.Mensual
    '                nuevaTarea.FechaVencimiento = fechaBase.AddMonths(i)
    '        End Select

    '        _checklistSeleccionado.Items.Add(nuevaTarea)
    '    Next

    '    ActualizarGridTareas()
    'End Sub

    '' Backup Feature
    'Private Sub CrearBackup()
    '    Dim carpetaBackup As String = Path.Combine(Application.StartupPath, "Backups")
    '    Directory.CreateDirectory(carpetaBackup)

    '    Dim nombreArchivo = $"Checklist_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.xml"
    '    Dim rutaBackup = Path.Combine(carpetaBackup, nombreArchivo)

    '    Try
    '        BaseDatos.Class_XmlChecklist.GuardarBackup(rutaBackup)
    '        MessageBox.Show($"Backup creado: {nombreArchivo}", "Backup Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    Catch ex As Exception
    '        Logger.Error("Error creando backup", ex)
    '    End Try
    'End Sub

    '' Enumeraciones para tipos de recurrencia
    'Enum RecurrenceType
    '    Diario
    '    Semanal
    '    Mensual
    'End Enum
End Class