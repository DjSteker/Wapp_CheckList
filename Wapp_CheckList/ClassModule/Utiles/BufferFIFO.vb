Public Class BufferFIFO
    Private buffer As New List(Of Double())

    Friend Sub Enqueue(ByVal value As Double())
        buffer.Add(value)
    End Sub

    Friend Function Dequeue() As Double()
        If buffer.Count = 0 Then
            Return Nothing
        End If

        Dim value As Double() = buffer(0)
        buffer.RemoveAt(0)
        Return value
    End Function

End Class