
Namespace Calendario

    Public Structure TareaDiaria
        Dim Id As String
        Dim Fecha As DateTime
        Dim Hora As TimeSpan?
        Dim Descripcion As String
        Dim ChecklistId As String ' ID de la tarea en el checklist (opcional)
    End Structure

End Namespace
