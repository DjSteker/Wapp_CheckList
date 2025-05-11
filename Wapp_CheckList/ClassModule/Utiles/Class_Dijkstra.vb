Public Class Class_Dijkstra



    Sub MiniosoDistrtra()
        ' Definición del grafo como una matriz de adyacencia
        Dim graph(,) As Integer = {
        {0, 10, 0, 30, 100},
        {10, 0, 50, 0, 0},
        {0, 50, 0, 20, 10},
        {30, 0, 20, 0, 60},
        {100, 0, 10, 60, 0}
    }

        Dim source As Integer = 0 ' Nodo de origen
        Dijkstra(graph, source)
    End Sub

    Sub Dijkstra(ByVal graph(,) As Integer, ByVal src As Integer)
        Dim n As Integer = graph.GetLength(0)
        Dim dist(n - 1) As Integer
        Dim sptSet(n - 1) As Boolean

        ' Inicialización de distancias
        For i As Integer = 0 To n - 1
            dist(i) = Integer.MaxValue
            sptSet(i) = False
        Next

        dist(src) = 0

        For count As Integer = 0 To n - 2
            Dim u As Integer = MinDistance(dist, sptSet, n)
            sptSet(u) = True

            For v As Integer = 0 To n - 1
                If Not sptSet(v) AndAlso graph(u, v) <> 0 AndAlso dist(u) <> Integer.MaxValue AndAlso dist(u) + graph(u, v) < dist(v) Then
                    dist(v) = dist(u) + graph(u, v)
                End If
            Next
        Next

        PrintSolution(dist, n)
    End Sub

    Function MinDistance(ByVal dist() As Integer, ByVal sptSet() As Boolean, ByVal n As Integer) As Integer
        Dim min As Integer = Integer.MaxValue
        Dim minIndex As Integer = -1

        For v As Integer = 0 To n - 1
            If Not sptSet(v) AndAlso dist(v) <= min Then
                min = dist(v)
                minIndex = v
            End If
        Next

        Return minIndex
    End Function

    Sub PrintSolution(ByVal dist() As Integer, ByVal n As Integer)
        Console.WriteLine("Nodo   Distancia desde el origen")
        For i As Integer = 0 To n - 1
            Console.WriteLine(i & " \t " & dist(i))
        Next
    End Sub

End Class
