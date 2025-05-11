Public Class Class_GrafosIndundacion
    Sub Main_GrafosIndundacion()
        ' Grafo representado como una lista de adyacencia
        Dim grafo As New Dictionary(Of Integer, List(Of Integer)) From {
            {0, New List(Of Integer) From {1, 2}},
            {1, New List(Of Integer) From {0, 3, 4}},
            {2, New List(Of Integer) From {0, 5}},
            {3, New List(Of Integer) From {1}},
            {4, New List(Of Integer) From {1, 5}},
            {5, New List(Of Integer) From {2, 4}}
        }

        ' Nodo de origen y destino
        Dim origen As Integer = 0
        Dim destino As Integer = 5

        ' Llamada a la función para encontrar el camino más corto
        Dim camino As List(Of Integer) = EncontrarCaminoMasCorto(grafo, origen, destino)

        ' Imprimir el camino encontrado
        If camino IsNot Nothing Then
            Console.WriteLine("Camino más corto: " & String.Join(" -> ", camino))
        Else
            Console.WriteLine("No se encontró un camino.")
        End If
    End Sub

    Function EncontrarCaminoMasCorto(ByVal grafo As Dictionary(Of Integer, List(Of Integer)), ByVal origen As Integer, ByVal destino As Integer) As List(Of Integer)
        Dim visitado As New HashSet(Of Integer)
        Dim cola As New Queue(Of List(Of Integer))
        cola.Enqueue(New List(Of Integer) From {origen})

        While cola.Count > 0
            Dim camino As List(Of Integer) = cola.Dequeue()
            Dim nodo As Integer = camino.Last()

            If nodo = destino Then
                Return camino
            End If

            If Not visitado.Contains(nodo) Then
                visitado.Add(nodo)
                For Each vecino In grafo(nodo)
                    Dim nuevoCamino As New List(Of Integer)(camino)
                    nuevoCamino.Add(vecino)
                    cola.Enqueue(nuevoCamino)
                Next
            End If
        End While

        Return Nothing
    End Function
End Class
