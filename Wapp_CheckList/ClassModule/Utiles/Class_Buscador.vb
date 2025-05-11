
Namespace Buscador1


    Public Class Class_Buscador


        Public Class BusquedaEnProfundidad

            Public Sub MainBuscador()

                '' Crear el árbol de búsqueda
                'Dim arbol = New Arbol()
                'arbol.AgregarNodo("Inicio")
                'arbol.AgregarNodo("A", "Inicio")
                'arbol.AgregarNodo("B", "Inicio")
                'arbol.AgregarNodo("C", "A")
                'arbol.AgregarNodo("D", "B")
                'arbol.AgregarNodo("E", "C")

                '' Iniciar la búsqueda
                'Dim resultado = Buscar(arbol, "E")

                '' Imprimir el resultado
                'If resultado IsNot Nothing Then
                '    Console.WriteLine("La solución es: " & resultado)
                'Else
                '    Console.WriteLine("No se encontró la solución")
                'End If

            End Sub

            Public Function Buscar(ByVal arbol As Arbol, ByVal objetivo As String) As String

                '        ' Pila para almacenar los nodos a explorar
                '        Dim pila = New Stack(Of Nodo)

                '        ' Agregar el nodo inicial a la pila
                '        pila.Push(arbol.Raiz)

                '        ' Bucle de búsqueda
                '        While Not pila.IsEmpty

                '            ' Obtener el nodo actual de la pila
                '            Dim nodoActual = pila.Pop()

                '            ' Si el nodo actual es el objetivo, devolverlo
                '            If nodoActual.Etiqueta = objetivo Then
                '                Return nodoActual.Etiqueta

                '                ' Agregar los hijos del nodo actual a la pila
                '                For Each hijo In nodoActual.Hijos
                '                    pila.Push(hijo)
                '                Next

                'End While

                '        ' No se encontró la solución
                '        Return Nothing

            End Function

        End Class

        Public Class BusquedaEnAnchura

            Public Sub MainBusquedaEnAnchura()

                '' Crear el árbol de búsqueda
                'Dim arbol = New Arbol()
                'arbol.AgregarNodo("Inicio")
                'arbol.AgregarNodo("A", "Inicio")
                'arbol.AgregarNodo("B", "Inicio")
                'arbol.AgregarNodo("C", "A")
                'arbol.AgregarNodo("D", "B")
                'arbol.AgregarNodo("E", "C")

                '' Iniciar la búsqueda
                'Dim resultado = Buscar(arbol, "E")

                '' Imprimir el resultado
                'If resultado IsNot Nothing Then
                '    Console.WriteLine("La solución es: " & resultado)
                'Else
                '    Console.WriteLine("No se encontró la solución")
                'End If

            End Sub

            Public Function Buscar(ByVal arbol As Arbol, ByVal objetivo As String) As String

                '        ' Cola para almacenar los nodos a explorar
                '        Dim cola = New Queue(Of Nodo)

                '        ' Agregar el nodo inicial a la cola
                '        cola.Enqueue(arbol.Raiz)

                '        ' Bucle de búsqueda
                '        While Not cola.IsEmpty

                '            ' Obtener el nodo actual de la cola
                '            Dim nodoActual = cola.Dequeue()

                '            ' Si el nodo actual es el objetivo, devolverlo
                '            If nodoActual.Etiqueta = objetivo Then
                '                Return nodoActual.Etiqueta

                '                ' Agregar los hijos del nodo actual a la cola
                '                For Each hijo In nodoActual.Hijos
                '                    cola.Enqueue(hijo)
                '                Next

                'End While

                '        ' No se encontró la solución
                '        Return Nothing

            End Function

        End Class

        Public Class AlgoritmoA

            Public Sub MainAlgoritmoA()

                '' Crear el árbol de búsqueda
                'Dim arbol = New Arbol()
                'arbol.AgregarNodo("Inicio")
                'arbol.AgregarNodo("A", "Inicio")
                'arbol.AgregarNodo("B", "Inicio")
                'arbol.AgregarNodo("C", "A")
                'arbol.AgregarNodo("D", "B")
                'arbol.AgregarNodo("E", "C")

                '' Establecer la función heurística
                'Dim heuristica = Function(nodo) As Integer
                '                     Return nodo.DistanciaAlObjetivo
                '                 End Function

                '' Iniciar la búsqueda
                'Dim resultado = Buscar(arbol, "E", heuristica)

                '' Imprimir el resultado
                'If resultado IsNot Nothing Then
                '    Console.WriteLine("La solución es: " & resultado)
                'Else
                '    Console.WriteLine("No se encontró la solución")
                'End If

            End Sub

            'Public Function Buscar(ByVal arbol As Arbol, ByVal objetivo As String, ByVal heuristica As Function(ByVal nodo As Nodo) As Integer) As String

            '' Pila para almacenar los nodos a explorar
            'Dim pila = New Stack(Of Nodo)

            '        ' Agregar el nodo inicial a la pila
            '        pila.Push(arbol.Raiz)

            '        ' Bucle de búsqueda
            '        While Not pila.IsEmpty

            '            ' Obtener el nodo actual de la pila
            '            Dim nodoActual = pila.Pop()

            '            ' Si el nodo actual es el objetivo, devolverlo
            '            If nodoActual.Etiqueta = objetivo Then
            '                Return nodoActual.Etiqueta

            '                ' Agregar los hijos del nodo actual a la pila, ordenados por costo estimado
            '                For Each hijo In nodoActual.Hijos
            '                    pila.Push(hijo, heuristica(hijo) + nodoActual.Costo)
            '                Next

            'End While

            '        ' No se encontró la solución
            '        Return Nothing

            'End Function

        End Class



    End Class



    Public Class Arbol

        Public Property Raiz As Nodo
        Public Property Nodos As List(Of Nodo)

        'Public Property FuncionHeuristica As Function(ByVal nodo As Nodo) As Integer

        Public Sub New()
            Me.Raiz = Nothing
            Me.Nodos = New List(Of Nodo)
        End Sub

        Public Sub AgregarNodo(ByVal etiqueta As String)
            Dim nodo = New Nodo(etiqueta)
            Me.Nodos.Add(nodo)

            If Me.Raiz Is Nothing Then
                Me.Raiz = nodo
            End If
        End Sub

        Public Sub AgregarHijo(ByVal nodo As Nodo, ByVal padre As Nodo)
            nodo.Predecesor = padre
            padre.Hijos.Add(nodo)
        End Sub

    End Class

    Public Class Nodo

        Public Property Etiqueta As String
        Public Property Hijos As List(Of Nodo)
        Public Property Costo As Integer
        Public Property DistanciaAlObjetivo As Integer

        Public Property Predecesor As Nodo
        Public Property Abierto As Boolean
        Public Property Cerrado As Boolean

        Public Sub New(ByVal etiqueta As String)
            Me.Etiqueta = etiqueta
            Me.Hijos = New List(Of Nodo)
            Me.Costo = 0
            Me.DistanciaAlObjetivo = 0
            Me.Predecesor = Nothing
            Me.Abierto = False
            Me.Cerrado = False
        End Sub

        Public Sub AgregarHijo(ByVal hijo As Nodo)
            Me.Hijos.Add(hijo)
        End Sub

    End Class


End Namespace

Namespace Buscador2
    'ejemplo de cómo podrías implementar un algoritmo de búsqueda heurística simple en Visual Basic. Este algoritmo utiliza una lista de nodos y una función heurística para determinar el siguiente nodo a visitar.
    ' En este caso, la función heurística simplemente selecciona el nodo con el valor más bajo, pero en un escenario real, esta función podría ser más compleja y depender de los detalles específicos del problema que estás tratando de resolver.
    Public Class Nodo
        Public valor As Integer
        Public visitado As Boolean
    End Class

    Public Class BusquedaHeuristica
        Private nodos As List(Of Nodo)

        Public Sub New()
            nodos = New List(Of Nodo)
        End Sub

        Public Sub AgregarNodo(valor As Integer)
            nodos.Add(New Nodo With {.valor = valor, .visitado = False})
        End Sub

        Public Function Buscar() As Nodo
            Dim nodoSeleccionado As Nodo = Nothing

            For Each nodo As Nodo In nodos
                If Not nodo.visitado Then
                    If nodoSeleccionado Is Nothing OrElse nodo.valor < nodoSeleccionado.valor Then
                        nodoSeleccionado = nodo
                    End If
                End If
            Next

            If nodoSeleccionado IsNot Nothing Then
                nodoSeleccionado.visitado = True
            End If

            Return nodoSeleccionado
        End Function
    End Class

    Class Monioso
        Sub mainBucadorMonioso()
            Dim busqueda As New BusquedaHeuristica()
            busqueda.AgregarNodo(5)
            busqueda.AgregarNodo(3)
            busqueda.AgregarNodo(7)

            Dim nodo As Nodo = busqueda.Buscar()
            While nodo IsNot Nothing
                Console.WriteLine(nodo.valor)
                nodo = busqueda.Buscar()
            End While
        End Sub
    End Class


    Public Class SimulatedAnnealing
        'Este algoritmo se utiliza para resolver el problema del viajante de comercio (TSP), que es un problema clásico de optimización.
        Private cities As List(Of City)
        Private rnd As Random
        Private temperature As Double
        Private coolingRate As Double

        Public Sub New(cities As List(Of City), temperature As Double, coolingRate As Double)
            Me.cities = cities
            Me.rnd = New Random()
            Me.temperature = temperature
            Me.coolingRate = coolingRate
        End Sub

        Public Function Solve() As List(Of City)
            Dim currentSolution As List(Of City) = cities.OrderBy(Function(x) rnd.Next()).ToList()
            Dim bestSolution As List(Of City) = New List(Of City)(currentSolution)
            Dim bestDistance As Double = TotalDistance(bestSolution)

            While temperature > 1
                Dim newSolution As List(Of City) = New List(Of City)(currentSolution)
                Dim pos1 As Integer = rnd.Next(newSolution.Count)
                Dim pos2 As Integer = rnd.Next(newSolution.Count)
                Dim city1 As City = newSolution(pos1)
                Dim city2 As City = newSolution(pos2)
                newSolution(pos2) = city1
                newSolution(pos1) = city2

                Dim currentDistance As Double = TotalDistance(currentSolution)
                Dim newDistance As Double = TotalDistance(newSolution)
                If (newDistance < currentDistance OrElse Math.Exp((currentDistance - newDistance) / temperature) > rnd.NextDouble()) Then
                    currentSolution = newSolution
                End If

                If (newDistance < bestDistance) Then
                    bestSolution = New List(Of City)(newSolution)
                    bestDistance = newDistance
                End If

                temperature *= 1 - coolingRate
            End While

            Return bestSolution
        End Function

        Private Function TotalDistance(cities As List(Of City)) As Double
            Dim total As Double = 0
            For i As Integer = 0 To cities.Count - 2
                total += Distance(cities(i), cities(i + 1))
            Next
            total += Distance(cities.Last(), cities.First())
            Return total
        End Function

        Private Function Distance(city1 As City, city2 As City) As Double
            Dim dx As Double = city2.X - city1.X
            Dim dy As Double = city2.Y - city1.Y
            Return Math.Sqrt(dx * dx + dy * dy)
        End Function
    End Class

    Public Class City
        Public Property X As Double
        Public Property Y As Double
    End Class

End Namespace

Namespace Buscador3
    'algoritmo de Dijkstra en VB.Net. Este código asume que tienes una matriz de adyacencia para representar el grafo y que estás buscando el camino más corto desde el nodo 0 a todos los demás nodos.
    Public Class Dijkstra
        Private Const INF As Integer = Integer.MaxValue
        Private vertices As Integer

        Public Sub New(vertices As Integer)
            Me.vertices = vertices
        End Sub

        Private Function MinDistance(dist As Integer(), sptSet As Boolean()) As Integer
            Dim min As Integer = INF
            Dim min_index As Integer = -1

            For v As Integer = 0 To vertices - 1
                If sptSet(v) = False AndAlso dist(v) <= min Then
                    min = dist(v)
                    min_index = v
                End If
            Next v

            Return min_index
        End Function

        Public Sub Dijkstra(graph As Integer(,), src As Integer)
            Dim dist(vertices) As Integer
            Dim sptSet(vertices) As Boolean

            For i As Integer = 0 To vertices - 1
                dist(i) = INF
                sptSet(i) = False
            Next i

            dist(src) = 0

            For count As Integer = 0 To vertices - 2
                Dim u As Integer = MinDistance(dist, sptSet)
                sptSet(u) = True

                For v As Integer = 0 To vertices - 1
                    If Not sptSet(v) AndAlso graph(u, v) <> 0 AndAlso dist(u) <> INF AndAlso dist(u) + graph(u, v) < dist(v) Then
                        dist(v) = dist(u) + graph(u, v)
                    End If
                Next v
            Next count

            PrintSolution(dist)
        End Sub

        Private Sub PrintSolution(dist As Integer())
            Console.WriteLine("Vertex    Distance from Source")

            For i As Integer = 0 To vertices - 1
                Console.WriteLine(i.ToString() & "          " & dist(i).ToString())
            Next i
        End Sub
    End Class
    Class Maniososo
        Sub mainManiososo()
            Dim graph As Integer(,) = New Integer(,) {{0, 2, 0, 6, 0}, {2, 0, 3, 8, 5}, {0, 3, 0, 0, 7}, {6, 8, 0, 0, 9}, {0, 5, 7, 9, 0}}
            Dim dijkstra As New Dijkstra(5)
            dijkstra.Dijkstra(graph, 0)
        End Sub
    End Class
End Namespace

Namespace Buscador4
    Public Class SimulatedAnnealing
        'Simulated Annealing en Visual Basic .NET. Este algoritmo se utiliza para resolver el problema del viajante de comercio (TSP), que es un problema clásico de optimización.
        Private cities As List(Of City)
        Private rnd As Random
        Private temperature As Double
        Private coolingRate As Double

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="cities">Ciudades que representan coordenadas en el mapa</param>
        ''' <param name="temperature"> (temperatura) en el algoritmo de Simulated Annealing representa el nivel de "agitación" o aleatoriedad en la búsqueda de soluciones. Inicialmente, una temperatura alta permite aceptar soluciones peores con una probabilidad relativamente alta, lo que ayuda a escapar de óptimos locales. A medida que la temperatura disminuye, la probabilidad de aceptar soluciones peores también disminuye, lo que lleva a una búsqueda más enfocada en la vecindad de la solución actual.</param>
        ''' <param name="coolingRate">(tasa de enfriamiento) afecta la rapidez con la que la temperatura disminuye durante la búsqueda. Una tasa de enfriamiento más lenta permite una exploración más amplia del espacio de soluciones al principio, mientras que una tasa de enfriamiento más rápida lleva a una búsqueda más localizada a medida que avanza el algoritmo.</param>
        Public Sub New(cities As List(Of City), temperature As Double, coolingRate As Double)
            Me.cities = cities
            Me.rnd = New Random()
            Me.temperature = temperature
            Me.coolingRate = coolingRate
        End Sub

        ''' <summary>
        ''' La función Solve realiza la búsqueda de la mejor ruta, y las funciones TotalDistance y Distance calculan la distancia total de una ruta y la distancia entre dos ciudades, respectivament
        ''' </summary>
        ''' <returns>el algoritmo busca encontrar la mejor ruta que pase por todas las ciudades exactamente una vez y regrese a la ciudad de origen, en lugar de una ciudad de origen y una de destino específicas</returns>
        Public Function Solve() As List(Of City)
            Dim currentSolution As List(Of City) = cities.OrderBy(Function(x) rnd.Next()).ToList()
            Dim bestSolution As List(Of City) = New List(Of City)(currentSolution)
            Dim bestDistance As Double = TotalDistance(bestSolution)

            While temperature > 1
                Dim newSolution As List(Of City) = New List(Of City)(currentSolution)
                Dim pos1 As Integer = rnd.Next(newSolution.Count)
                Dim pos2 As Integer = rnd.Next(newSolution.Count)
                Dim city1 As City = newSolution(pos1)
                Dim city2 As City = newSolution(pos2)
                newSolution(pos2) = city1
                newSolution(pos1) = city2

                Dim currentDistance As Double = TotalDistance(currentSolution)
                Dim newDistance As Double = TotalDistance(newSolution)
                If (newDistance < currentDistance OrElse Math.Exp((currentDistance - newDistance) / temperature) > rnd.NextDouble()) Then
                    currentSolution = newSolution
                End If

                If (newDistance < bestDistance) Then
                    bestSolution = New List(Of City)(newSolution)
                    bestDistance = newDistance
                End If

                temperature *= 1 - coolingRate
            End While

            Return bestSolution
        End Function

        Private Function TotalDistance(cities As List(Of City)) As Double
            Dim total As Double = 0
            For i As Integer = 0 To cities.Count - 2
                total += Distance(cities(i), cities(i + 1))
            Next
            total += Distance(cities.Last(), cities.First())
            Return total
        End Function

        Private Function Distance(city1 As City, city2 As City) As Double
            Dim dx As Double = city2.X - city1.X
            Dim dy As Double = city2.Y - city1.Y
            Return Math.Sqrt(dx * dx + dy * dy)
        End Function
    End Class

    Public Class City
        Public Property X As Double
        Public Property Y As Double
    End Class
End Namespace

Namespace Buscador5

    Public Class AhoCorasick1
        'buscar patrones en una cadena de texto

        Private Const MAXCHARS As Integer = 256
        Private Const ROOT As Integer = 0

        Private trie As New List(Of Dictionary(Of Char, Integer))
        Private fail As New List(Of Integer)
        Private out As New List(Of List(Of Integer))

        Public Sub New()
            trie.Add(New Dictionary(Of Char, Integer)())
            fail.Add(ROOT)
            out.Add(New List(Of Integer)())
        End Sub

        ''' <summary>
        ''' primero se deben agregar los patrones que se desean buscar utilizando el método
        ''' </summary>
        ''' <param name="pattern"></param>
        Public Sub AddPattern(pattern As String)
            Dim node As Integer = ROOT
            For Each c As Char In pattern
                If Not trie(node).ContainsKey(c) Then
                    trie(node)(c) = trie.Count
                    trie.Add(New Dictionary(Of Char, Integer)())
                    fail.Add(ROOT)
                    out.Add(New List(Of Integer)())
                End If
                node = trie(node)(c)
            Next
            out(node).Add(out.Count - 1)
        End Sub

        ''' <summary>
        '''  segundo, se debe llamar al método Build para construir el autómata de búsqueda.
        ''' </summary>
        Public Sub Build()
            Dim queue As New Queue(Of Integer)()
            For Each c As Char In trie(ROOT).Keys
                Dim node As Integer = trie(ROOT)(c)
                fail(node) = ROOT
                queue.Enqueue(node)
            Next
            While queue.Count > 0
                Dim r As Integer = queue.Dequeue()
                For Each c As Char In trie(r).Keys
                    Dim s As Integer = trie(r)(c)
                    queue.Enqueue(s)
                    Dim state As Integer = fail(r)
                    While state <> ROOT AndAlso Not trie(state).ContainsKey(c)
                        state = fail(state)
                    End While
                    If trie(state).ContainsKey(c) Then
                        fail(s) = trie(state)(c)
                    Else
                        fail(s) = ROOT
                    End If
                    out(s).AddRange(out(fail(s)))
                Next
            End While
        End Sub

        ''' <summary>
        ''' Finalmente, se puede llamar al método Search para buscar los patrones en una cadena de texto.
        ''' </summary>
        ''' <param name="text"></param>
        ''' <returns></returns>
        Public Function Search(text As String) As List(Of Integer)
            Dim node As Integer = ROOT
            Dim result As New List(Of Integer)()
            For i As Integer = 0 To text.Length - 1
                While node <> ROOT AndAlso Not trie(node).ContainsKey(text(i))
                    node = fail(node)
                End While
                If trie(node).ContainsKey(text(i)) Then
                    node = trie(node)(text(i))
                End If
                result.AddRange(out(node))
            Next
            Return result
        End Function
    End Class

    Public Class AhoCorasickNode2
        Public NextState As New Dictionary(Of Char, Integer)()
        Public Parent As Integer
        Public Suffix As Integer
        Public IsLeaf As Boolean
        Public Word As String

        Public Sub New(ByVal parent As Integer, ByVal char1 As Char)
            Me.Parent = parent
            Me.Suffix = -1
            Me.IsLeaf = False
            Me.Word = char1.ToString()
        End Sub
    End Class

    Public Class AhoCorasick2
        Private Nodes As New List(Of AhoCorasickNode2)()
        Private Output As New List(Of List(Of Integer))()
        Private Fails As New List(Of Integer)()
        Private Last As Integer

        Public Sub New()
            Nodes.Add(New AhoCorasickNode2(0, " "c))
            Last = 0
        End Sub

        Public Sub AddWord(ByVal s As String)
            Dim cur As Integer = 0
            For i As Integer = 0 To s.Length - 1
                If Not Nodes(cur).NextState.ContainsKey(s(i)) Then
                    Nodes.Add(New AhoCorasickNode2(cur, s(i)))
                    Nodes(cur).NextState(s(i)) = Nodes.Count - 1
                End If
                cur = Nodes(cur).NextState(s(i))
            Next
            Nodes(cur).IsLeaf = True
            Nodes(cur).Word = s
        End Sub

        Public Sub InitializeOutput()
            For i As Integer = 0 To Nodes.Count - 1
                Output.Add(New List(Of Integer)())
            Next
        End Sub

        Public Sub InitializeFails()
            Fails.AddRange(Enumerable.Repeat(-1, Nodes.Count))
        End Sub

        Public Sub BuildFails()
            Dim q As New Queue(Of Integer)()
            For Each a In Nodes(0).NextState
                q.Enqueue(a.Value)
                Fails(a.Value) = 0
            Next
            While q.Count > 0
                Dim state As Integer = q.Dequeue()
                For Each a In Nodes(state).NextState
                    Dim r As Integer = Fails(state)
                    While Not Nodes(r).NextState.ContainsKey(a.Key)
                        r = Fails(r)
                    End While
                    r = Nodes(r).NextState(a.Key)
                    Fails(a.Value) = r
                    For Each b In Output(r)
                        Output(a.Value).Add(b)
                    Next
                    If Nodes(r).IsLeaf Then
                        Output(a.Value).Add(r)
                    End If
                    q.Enqueue(a.Value)
                Next
            End While
        End Sub

        Public Function Search(ByVal s As String) As List(Of String)
            Dim cur As Integer = 0
            Dim result As New List(Of String)()
            For i As Integer = 0 To s.Length - 1
                While Not Nodes(cur).NextState.ContainsKey(s(i)) AndAlso cur <> 0
                    cur = Fails(cur)
                End While
                If Nodes(cur).NextState.ContainsKey(s(i)) Then
                    cur = Nodes(cur).NextState(s(i))
                End If
                For Each a In Output(cur)
                    result.Add(Nodes(a).Word)
                Next
            Next
            Return result
        End Function
    End Class
End Namespace