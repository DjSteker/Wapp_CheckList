Public Class Class_ComprimirLZ77 'LZ77

    Private Const MAX_WINDOW_SIZE As Integer = 400
    Private Const MAX_LOOKAHEAD_SIZE As Integer = 15

    Public Function Compress(input As String) As List(Of Tuple(Of Integer, Integer, Char))
        Dim output As New List(Of Tuple(Of Integer, Integer, Char))()
        Dim pos As Integer = 0

        While pos < input.Length
            Dim length As Integer = 0
            Dim offset As Integer = 0
            Dim nextChar As Char = input(pos)

            For i As Integer = Math.Max(0, pos - MAX_WINDOW_SIZE) To pos - 1
                Dim j As Integer = 0
                While j < MAX_LOOKAHEAD_SIZE AndAlso pos + j < input.Length AndAlso input(i + j) = input(pos + j)
                    j += 1
                End While

                If j > length OrElse (j = length AndAlso i + j = pos) Then
                    length = j
                    offset = pos - i
                    If pos + length < input.Length Then
                        nextChar = input(pos + length)
                    End If
                End If
            Next

            output.Add(New Tuple(Of Integer, Integer, Char)(offset, length, nextChar))
            pos += Math.Max(1, length)
        End While

        Return output
    End Function
End Class