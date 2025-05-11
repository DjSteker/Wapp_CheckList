Public Class Class_KnuthMorrisPratt
    Sub MainKnuthMorrisPratt()
        Dim text As String = "ABABDABACDABABCABAB"
        Dim pattern As String = "ABABCABAB"
        KMPSearch(pattern, text)
    End Sub

    Private Sub ComputeLPSArray(ByVal pattern As String, ByVal M As Integer, ByVal lps() As Integer)
        Dim length As Integer = 0
        Dim i As Integer = 1
        lps(0) = 0

        While i < M
            If pattern(i) = pattern(length) Then
                length += 1
                lps(i) = length
                i += 1
            Else
                If length <> 0 Then
                    length = lps(length - 1)
                Else
                    lps(i) = length
                    i += 1
                End If
            End If
        End While
    End Sub

    Private Sub KMPSearch(ByVal pattern As String, ByVal text As String)
        Dim M As Integer = pattern.Length
        Dim N As Integer = text.Length
        Dim lps(M) As Integer
        Dim j As Integer = 0

        ComputeLPSArray(pattern, M, lps)

        Dim i As Integer = 0
        While i < N
            If pattern(j) = text(i) Then
                j += 1
                i += 1
            End If

            If j = M Then
                Console.WriteLine("Found pattern at index " & (i - j))
                j = lps(j - 1)
            ElseIf i < N AndAlso pattern(j) <> text(i) Then
                If j <> 0 Then
                    j = lps(j - 1)
                Else
                    i = i + 1
                End If
            End If
        End While
    End Sub
End Class
