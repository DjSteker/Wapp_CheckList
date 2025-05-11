Imports WApp_ProcesadoSonido.Layers
Imports WApp_ProcesadoSonido.Activation
Imports WApp_ProcesadoSonido.Data
Imports WApp_ProcesadoSonido.Neurons
Imports WApp_ProcesadoSonido.Randoms
Imports WApp_ProcesadoSonido

Namespace Network
    Public Class MultilayerPerceptron

        Public Property TotalError As Double
        Public Property MinError As Double

        Public Property Momentum As Double
        Public Property LearningRate As Double
        Public Property FactorFIR As Double = 0.49 '0.5 '0.2
        Public Property FactorFIRNeurona As Double = 0.7

        Public Property Bias As Neuron
        Public Property Randomizer As BaseRandom
        Public Property ActivationFunction As BaseActivation

        Public Property Layers As List(Of BaseLayer)

        Public Property InputLayer As InputLayer
        Public Property OutputLayer As OutputLayer
        Public Property HiddenLayers As List(Of HiddenLayer)


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="num_input"></param>
        ''' <param name="num_hidden"></param>
        ''' <param name="num_output"></param>
        ''' <param name="learning_rate">Entrenamiento</param>
        ''' <param name="momentum"></param>
        ''' <param name="randomizer"></param>
        ''' <param name="activation"></param>
        Public Sub New(ByVal num_input As Integer, ByVal num_hidden As Integer(), ByVal num_output As Integer, ByVal learning_rate As Double, ByVal momentum As Double, ByRef randomizer As BaseRandom, ByRef activation As BaseActivation)

            'setting properties
            Me.Momentum = momentum
            Me.Randomizer = randomizer
            Me.LearningRate = learning_rate
            Me.ActivationFunction = activation

            'setting bias
            Me.Bias = New Neuron(NeuronType.Input)
            Me.Bias.Input = 1
            Me.Bias.Output = 1

            'initializing lists
            Layers = New List(Of BaseLayer)
            HiddenLayers = New List(Of HiddenLayer)

            'creating layers
            InputLayer = New InputLayer(num_input, ActivationFunction)
            Layers.Add(InputLayer)
            For Each i In num_hidden
                Dim hiddenLayer = New HiddenLayer(i, ActivationFunction)
                HiddenLayers.Add(hiddenLayer)
                Layers.Add(hiddenLayer)
            Next
            OutputLayer = New OutputLayer(num_output, ActivationFunction)
            Layers.Add(OutputLayer)

            'connecting layers (creating weights)
            For x As Integer = 0 To (Layers.Count - 2)
                Layers(x).ConnectChild(Layers(x + 1), randomizer)

                'connecting bias
                Layers(x + 1).ConnectBias(Bias, randomizer)
            Next

        End Sub

        Public Function Test(ByVal data As Testing) As List(Of Double)
            InputLayer.SetInput(data.Input)
            ForwardPropogate()
            Return OutputLayer.ExtractOutputs()
        End Function

        Public Function TestList(ByVal data As List(Of Testing)) As List(Of Double)
            Dim Salidas As New List(Of Double)
            Dim tempResultado As List(Of Double)
            For Each item In data
                InputLayer.SetInput(item.Input)
                ForwardPropogate()
                tempResultado = OutputLayer.ExtractOutputs()
                Salidas.Add(tempResultado.Item(tempResultado.Count - 1))
            Next


            Return Salidas
        End Function

        Public Function TestLista1(ByVal data As List(Of Testing)) As List(Of Double())
            Dim Salidas As New List(Of Double())
            Dim tempResultado As List(Of Double)
            For Each item In data
                InputLayer.SetInput(item.Input)
                ForwardPropogate()
                tempResultado = OutputLayer.ExtractOutputs()


                Dim Array() As Double = New Double(tempResultado.Count - 1) {}

                For indice As Integer = 0 To tempResultado.Count - 1
                    'Salidas.Add(tempResultado.Item(indice))
                    Array(indice) = tempResultado.Item(indice)
                Next

                Salidas.Add(Array)
            Next


            Return Salidas
        End Function






        Public Sub TrainProgrsive(ByVal data As List(Of Training), ByVal epochs As Integer, ByVal min_error As Double, ByVal c_Momentum As Double)
            Dim Anterior As Decimal = LearningRate
            Momentum = c_Momentum
            Do
                LearningRate = Anterior + (Anterior / ((TotalError / 2) + (Math.Sin(1 / epochs))) / 2)
                TotalError = 0.0
                For Each item In data
                    InputLayer.SetInput(item.Entrada)
                    ForwardPropogate()
                    OutputLayer.AssignErrors(item.Salida)
                    BackwardPropogate()
                    TotalError += OutputLayer.CalculateSquaredError()
                Next
                epochs -= 1
            Loop While epochs > 0 And TotalError > min_error
            LearningRate = Anterior
        End Sub
        Public Sub Train(ByVal data As List(Of Training), ByVal epochs As Integer, ByVal min_error As Double)
            Do


                TotalError = 0.0
                For Each item In data
                    InputLayer.SetInput(item.Entrada)
                    ForwardPropogate()
                    OutputLayer.AssignErrors(item.Salida)
                    BackwardPropogate()
                    TotalError += OutputLayer.CalculateSquaredError()
                    Threading.Thread.Sleep(0.1)
                Next
                epochs -= 1
            Loop While epochs > 0 And TotalError > min_error

        End Sub


        Public Sub TrainSlow(ByVal data As List(Of Training), ByVal epochs As Integer, ByVal min_error As Double)
            'Do


            TotalError = 0.0
            For Each item In data
                Try
                    InputLayer.SetInput(item.Entrada)
                    ForwardPropogate()
                    System.Threading.Thread.Sleep(1)
                    OutputLayer.AssignErrors(item.Salida)
                    System.Threading.Thread.Sleep(1)
                    BackwardPropogateSlow()
                    System.Threading.Thread.Sleep(1)
                    TotalError += OutputLayer.CalculateSquaredError()
                Catch ex As Exception

                End Try

            Next
            '    epochs -= 1
            'Loop While epochs > 0 And TotalError > min_error

        End Sub

        Public Sub ForwardPropogate()

            For x As Integer = 1 To (Layers.Count - 1)
                For Each node In Layers(x).Neurons
                    node.Input = 0.0
                    For Each w In node.WeightsToParent
                        'Dim a = Layers(x - 1).Neurons
                        node.Input += w.Parent.Output * w.Value
                    Next
                    'adding bias
                    node.Input += node.WeightToBias.Parent.Output * node.WeightToBias.Value
                    node.Output = Layers(x).ActivationFunction.Evaluate(node.Input)
                Next
            Next

        End Sub


        Friend Function Get_Pesos() As ClassArchivo_Cerebro

            Dim Lista As New ClassArchivo_Cerebro(1, "Nombre")

            For x As Integer = 0 To (Layers.Count - 1)
                Dim Capa As New ClassArchivo_Cerebro.ClassArchivo_Capa
                Capa.Alfa = Layers(x).ActivationFunction.Alfa_p

                If (x > 0) And (x <> (Layers.Count - 1)) Then
                    For Each node In Layers(x).Neurons
                        Dim NeuronaGet As New ClassArchivo_Cerebro.ClassArchivo_Capa.ClassArchivo_Neurona
                        Try
                            NeuronaGet.Peso = node.Input / node.Output

                            If Double.IsNaN(NeuronaGet.Peso) Then
                                NeuronaGet.Peso = 0
                            End If

                            NeuronaGet.errDelta = node.ErrorDelta.ToString("R34", New System.Globalization.CultureInfo("es-ES"))
                            NeuronaGet.Bias = node.WeightToBias.Value.ToString("e64")
                            NeuronaGet.BiasPrebio = node.WeightToBias.Previous.ToString("e64")
                            NeuronaGet.BiasPrebio2 = node.WeightToBias.Previous2.ToString("e64")
                            NeuronaGet.BiasPrebio3 = node.WeightToBias.Previous3.ToString("e64")
                            Dim aaa As String = node.Type.ToString
                            Try
                                For IndiceHijos As Integer = 0 To node.WeightsToChild.Count - 1
                                    NeuronaGet.NodosHijos.Add(node.WeightsToChild.Item(IndiceHijos).Value.ToString("e64"))
                                    NeuronaGet.NodosHijosPrevio.Add(node.WeightsToChild.Item(IndiceHijos).Previous.ToString("e64"))
                                    NeuronaGet.NodosHijosPrevio2.Add(node.WeightsToChild.Item(IndiceHijos).Previous2.ToString("e64"))
                                    NeuronaGet.NodosHijosPrevio3.Add(node.WeightsToChild.Item(IndiceHijos).Previous3.ToString("e64"))
                                Next
                            Catch ex As Exception

                            End Try

                            Try
                                For IndicePaderes As Integer = 0 To node.WeightsToParent.Count - 1
                                    NeuronaGet.NodosPadres.Add(node.WeightsToParent.Item(IndicePaderes).Value.ToString("e64"))
                                    NeuronaGet.NodosPadresPrevio.Add(node.WeightsToParent.Item(IndicePaderes).Previous.ToString("e64"))
                                    NeuronaGet.NodosPadresPrevio2.Add(node.WeightsToParent.Item(IndicePaderes).Previous2.ToString("e64"))
                                    NeuronaGet.NodosPadresPrevio3.Add(node.WeightsToParent.Item(IndicePaderes).Previous3.ToString("e64"))
                                Next
                            Catch ex As Exception

                            End Try


                            'Nodo.Bias = node.WeightToBias.Value
                            Capa.Nodos.Add(NeuronaGet)
                        Catch ex As Exception

                        End Try

                    Next
                ElseIf x = (Layers.Count - 1) Then

                    For Each node In Layers(x).Neurons
                        Dim Nodo As New ClassArchivo_Cerebro.ClassArchivo_Capa.ClassArchivo_Neurona
                        Try
                            Nodo.Bias = node.WeightToBias.Value.ToString("e64")
                            Nodo.BiasPrebio = node.WeightToBias.Previous.ToString("e64")
                            Nodo.BiasPrebio2 = node.WeightToBias.Previous2.ToString("e64")
                            Nodo.BiasPrebio3 = node.WeightToBias.Previous3.ToString("e64")
                            Nodo.errDelta = node.ErrorDelta
                            Nodo.Peso = node.Input / node.Output

                            If Double.IsNaN(Nodo.Peso) Then
                                Nodo.Peso = 0
                            End If

                            For IndicePaderes As Integer = 0 To node.WeightsToParent.Count - 1
                                Nodo.NodosPadres.Add(node.WeightsToParent.Item(IndicePaderes).Value.ToString("e64"))
                                Nodo.NodosPadresPrevio.Add(node.WeightsToParent.Item(IndicePaderes).Previous.ToString("e64"))
                                Nodo.NodosPadresPrevio2.Add(node.WeightsToParent.Item(IndicePaderes).Previous2.ToString("e64"))
                                Nodo.NodosPadresPrevio3.Add(node.WeightsToParent.Item(IndicePaderes).Previous3.ToString("e64"))

                            Next
                            Nodo.Bias = node.WeightToBias.Value.ToString("e99")
                            Nodo.BiasPrebio = node.WeightToBias.Previous.ToString("e99")
                            Capa.Nodos.Add(Nodo)
                        Catch ex As Exception

                        End Try

                    Next

                Else
                    For Each node In Layers(x).Neurons
                        Dim Nodo As New ClassArchivo_Cerebro.ClassArchivo_Capa.ClassArchivo_Neurona
                        Nodo.errDelta = node.ErrorDelta
                        Nodo.Input = node.Input
                        Nodo.Output = node.Output

                        If node.Type <> Neurons.NeuronEnum.NeuronType.Input Then
                            Nodo.Bias = node.WeightToBias.Value.ToString("e64")
                            Nodo.BiasPrebio = node.WeightToBias.Previous.ToString("e64")
                            Nodo.BiasPrebio2 = node.WeightToBias.Previous2.ToString("e64")
                            Nodo.BiasPrebio3 = node.WeightToBias.Previous3.ToString("e64")
                        End If

                        Nodo.Primed = node.Primed
                        'Nodo.Bias = node.WeightToBias.Value

                        For IndiceHijos As Integer = 0 To node.WeightsToChild.Count - 1 ' Nodo.NodosHijos.Count - 1
                            Try
                                Nodo.NodosHijos.Add(node.WeightsToChild.Item(IndiceHijos).Value.ToString("e64"))
                                Nodo.NodosHijosPrevio.Add(node.WeightsToChild.Item(IndiceHijos).Previous.ToString("e64"))
                                Nodo.NodosHijosPrevio2.Add(node.WeightsToChild.Item(IndiceHijos).Previous2.ToString("e64"))
                                Nodo.NodosHijosPrevio3.Add(node.WeightsToChild.Item(IndiceHijos).Previous3.ToString("e64"))
                                Nodo.errDelta = node.ErrorDelta.ToString("e64")
                                Nodo.Input = node.ErrorDelta.ToString("e99")
                                Nodo.Output = node.Output.ToString("R64")
                                If node.Type <> Neurons.NeuronEnum.NeuronType.Input Then
                                    Nodo.Bias = node.WeightToBias.Value.ToString("e64")
                                    Nodo.BiasPrebio = node.WeightToBias.Previous.ToString("e64")
                                    Nodo.BiasPrebio2 = node.WeightToBias.Previous2.ToString("e64")
                                    Nodo.BiasPrebio3 = node.WeightToBias.Previous3.ToString("e64")
                                End If

                                Nodo.Primed = node.Primed

                            Catch ex As Exception

                            End Try

                        Next

                        'For IndicePaderes As Integer = 0 To node.WeightsToParent.Count - 1
                        '    Nodo.NodosPadres.Add(node.WeightsToParent.Item(IndicePaderes).Value)
                        'Next

                        Capa.Nodos.Add(Nodo)

                    Next



                End If

                Lista.Capas.Add(Capa)
            Next
            Return Lista
        End Function

        Friend Function Set_Pesos(Datos As ClassArchivo_Cerebro) As Boolean
            Dim Resultado As Boolean = False

            For IndiceCapa As Integer = 0 To (Layers.Count - 1)
                'Dim Capa As New ClassArchivo_Cerebro.ClassArchivo_Capa
                If (IndiceCapa > 0) And (IndiceCapa <> (Layers.Count - 1)) Then
                    'Capa.Alfa = Layers.Item(IndiceCapa).ActivationFunction.Alfa_p


                    Layers(IndiceCapa).ActivationFunction.Alfa_p = Datos.Capas.Item(IndiceCapa).Alfa

                    'For Each node In Layers(IndiceCapa).Neurons
                    '    Dim Nodo As New ClassArchivo_Cerebro.ClassArchivo_Capa.ClassArchivo_Neurona
                    '    For IndiceNodos As Integer = 0 To Datos.Capas.Item(IndiceCapa).Nodos.Count - 1
                    '        node.ErrorDelta = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).errDelta
                    '        node.WeightToBias.Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).Bias
                    '        For IndiceHijo As Integer = 0 To node.WeightsToChild.Count - 1
                    '            node.WeightsToChild.Item(IndiceHijo).Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijos.Item(IndiceHijo)
                    '            node.WeightsToChild.Item(IndiceHijo).Previous = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijosPrevio.Item(IndiceHijo)
                    '        Next
                    '        For IndicePadres As Integer = 0 To node.WeightsToParent.Count - 1
                    '            Dim a = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadres.Item(IndicePadres)
                    '            node.WeightsToParent.Item(IndicePadres).Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadres.Item(IndicePadres)
                    '            node.WeightsToParent.Item(IndicePadres).Previous = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadresPrevio.Item(IndicePadres)
                    '        Next
                    '    Next
                    'Next

                    Dim IndiceNodos As Integer = 0

                    For IndiceNeurona As Integer = 0 To Layers(IndiceCapa).Neurons.Count - 1
                        Layers(IndiceCapa).Neurons.Item(IndiceNeurona).ErrorDelta = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).errDelta
                        Layers(IndiceCapa).Neurons.Item(IndiceNeurona).WeightToBias.Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).Bias
                        Layers(IndiceCapa).Neurons.Item(IndiceNeurona).WeightToBias.Previous = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).BiasPrebio
                        Layers(IndiceCapa).Neurons.Item(IndiceNeurona).WeightToBias.Previous2 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).BiasPrebio2
                        Layers(IndiceCapa).Neurons.Item(IndiceNeurona).WeightToBias.Previous3 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).BiasPrebio3

                        For IndiceHijo As Integer = 0 To Layers(IndiceCapa).Neurons.Item(IndiceNeurona).WeightsToChild.Count - 1
                            Dim Paso As Boolean = False
                            Try

                                Layers(IndiceCapa).Neurons.Item(IndiceNeurona).WeightsToChild.Item(IndiceHijo).Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNeurona).NodosHijos.Item(IndiceHijo)
                                Layers(IndiceCapa).Neurons.Item(IndiceNeurona).WeightsToChild.Item(IndiceHijo).Previous = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNeurona).NodosHijosPrevio.Item(IndiceHijo)


                            Catch ex As Exception

                            End Try
                            If Paso = True Then
                                Dim aaa = 0
                            End If
                        Next

                    Next

                    'For Each node In Layers(IndiceCapa).Neurons
                    '    'Dim Nodo As New ClassArchivo_Cerebro.ClassArchivo_Capa.ClassArchivo_Neurona
                    '    'For IndiceNodos As Integer = 0 To Datos.Capas.Item(IndiceCapa).Nodos.Count - 1
                    '    node.ErrorDelta = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).errDelta
                    '    node.WeightToBias.Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).Bias
                    '    Try
                    '        node.WeightToBias.Previous = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).BiasPrebio
                    '        node.WeightToBias.Previous2 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).BiasPrebio2
                    '        node.WeightToBias.Previous3 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).BiasPrebio3
                    '    Catch ex As Exception

                    '    End Try

                    '    For IndiceHijo As Integer = 0 To node.WeightsToChild.Count - 1
                    '        Dim Paso As Boolean = False
                    '        Try

                    '            'Dim aaa As Double = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijosPrevio2.Item(IndiceHijo)
                    '            'Dim aaa2 As Double = node.WeightsToChild.Item(IndiceHijo).Previous2
                    '            node.WeightsToChild.Item(IndiceHijo).Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceHijo).NodosHijos.Item(IndiceHijo)
                    '            node.WeightsToChild.Item(IndiceHijo).Previous = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceHijo).NodosHijosPrevio.Item(IndiceHijo)

                    '            'Dim aaaaaaa As String = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijosPrevio2.Item(IndiceHijo)
                    '            'If Not IsNothing(Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos)) Then
                    '            '    node.WeightsToChild.Item(IndiceHijo).Previous2 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijosPrevio2.Item(IndiceHijo)
                    '            'End If

                    '            'node.WeightsToChild.Item(IndiceHijo).Previous3 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijosPrevio3.Item(IndiceHijo)
                    '            'Paso = True
                    '        Catch ex As Exception

                    '        End Try
                    '        If Paso = True Then
                    '            Dim aaa = 0
                    '        End If
                    '    Next










                    '    'For IndicePadres As Integer = 0 To node.WeightsToParent.Count - 1
                    '    '    Dim Paso As Boolean = False
                    '    '    Try
                    '    '        'Dim a = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadres.Item(IndicePadres)
                    '    '        node.WeightsToParent.Item(IndicePadres).Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadres.Item(IndicePadres)
                    '    '        node.WeightsToParent.Item(IndicePadres).Previous = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadresPrevio.Item(IndicePadres)





                    '    '        'node.WeightsToParent.Item(IndicePadres).Previous2 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadresPrevio2.Item(IndicePadres)
                    '    '        'node.WeightsToParent.Item(IndicePadres).Previous3 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadresPrevio3.Item(IndicePadres)





                    '    '        'Paso = True
                    '    '    Catch ex As Exception

                    '    '    End Try
                    '    '    If Paso = True Then
                    '    '        Dim aaa = 0
                    '    '    End If
                    '    'Next
                    '    'Next
                    '    IndiceNodos += 1
                    'Next
                ElseIf IndiceCapa = (Layers.Count - 1) Then

                    'For Each node In Layers(IndiceCapa).Neurons
                    '    Dim Nodo As New ClassArchivo_Cerebro.ClassArchivo_Capa.ClassArchivo_Neurona
                    '    For IndiceNodos As Integer = 0 To Datos.Capas.Item(IndiceCapa).Nodos.Count - 1
                    '        node.ErrorDelta = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).errDelta
                    '        'For IndiceHijo As Integer = 0 To node.WeightsToChild.Count - 1
                    '        '    node.WeightsToChild.Item(IndiceHijo).Value = Datos.Capas.Item(x).Nodos.Item(IndiceNodos).NodosHijos.Item(IndiceHijo)
                    '        'Next
                    '        Try
                    '            node.WeightToBias.Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).Bias
                    '            node.WeightToBias.Previous = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).BiasPrebio
                    '            node.WeightToBias.Previous2 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).BiasPrebio2
                    '            node.WeightToBias.Previous3 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).BiasPrebio3
                    '        Catch ex As Exception

                    '        End Try

                    '        For IndicePadres As Integer = 0 To node.WeightsToParent.Count - 1
                    '            Try
                    '                node.WeightsToParent.Item(IndicePadres).Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadres.Item(IndicePadres)
                    '                node.WeightsToParent.Item(IndicePadres).Previous = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadresPrevio.Item(IndicePadres)
                    '                'node.WeightsToParent.Item(IndicePadres).Previous2 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadresPrevio2.Item(IndicePadres)
                    '                'node.WeightsToParent.Item(IndicePadres).Previous3 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadresPrevio3.Item(IndicePadres)
                    '            Catch ex As Exception

                    '            End Try

                    '        Next
                    '    Next
                    'Next

                    For IndiceNeurona As Integer = 0 To Layers(IndiceCapa).Neurons.Count - 1

                        'For IndiceNodos As Integer = 0 To Datos.Capas.Item(IndiceCapa).Nodos.Count - 1
                        Layers(IndiceCapa).Neurons.Item(IndiceNeurona).ErrorDelta = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNeurona).errDelta
                        'For IndiceHijo As Integer = 0 To node.WeightsToChild.Count - 1
                        '    node.WeightsToChild.Item(IndiceHijo).Value = Datos.Capas.Item(x).Nodos.Item(IndiceNodos).NodosHijos.Item(IndiceHijo)
                        'Next
                        Try
                            Layers(IndiceCapa).Neurons.Item(IndiceNeurona).WeightToBias.Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNeurona).Bias
                            Layers(IndiceCapa).Neurons.Item(IndiceNeurona).WeightToBias.Previous = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNeurona).BiasPrebio
                            Layers(IndiceCapa).Neurons.Item(IndiceNeurona).WeightToBias.Previous2 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNeurona).BiasPrebio2
                            Layers(IndiceCapa).Neurons.Item(IndiceNeurona).WeightToBias.Previous3 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNeurona).BiasPrebio3
                        Catch ex As Exception

                        End Try

                        'For IndicePadres As Integer = 0 To Layers(IndiceCapa).Neurons.Item(IndiceNeurona).WeightsToParent.Count - 1
                        '    Try
                        '        Layers(IndiceCapa).Neurons.Item(IndiceNeurona).WeightsToParent.Item(IndicePadres).Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadres.Item(IndicePadres)
                        '        Layers(IndiceCapa).Neurons.Item(IndiceNeurona).WeightsToParent.Item(IndicePadres).Previous = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadresPrevio.Item(IndicePadres)
                        '        'node.WeightsToParent.Item(IndicePadres).Previous2 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadresPrevio2.Item(IndicePadres)
                        '        'node.WeightsToParent.Item(IndicePadres).Previous3 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadresPrevio3.Item(IndicePadres)
                        '    Catch ex As Exception

                        '    End Try

                        'Next

                        'Next

                    Next



                Else
                    Try
                        'For Each node In Layers(IndiceCapa).Neurons
                        '    Dim Nodo As New ClassArchivo_Cerebro.ClassArchivo_Capa.ClassArchivo_Neurona
                        '    For IndiceNodos As Integer = 0 To Datos.Capas.Item(IndiceCapa).Nodos.Count - 1
                        '        node.ErrorDelta = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).errDelta
                        '        'node.WeightToBias.Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).Bias
                        '        'node.WeightToBias = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).Bias
                        '        For IndiceHijo As Integer = 0 To node.WeightsToChild.Count - 1
                        '            Dim valor As Double = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijos.Item(IndiceHijo)
                        '            node.WeightsToChild.Item(IndiceHijo).Value = valor
                        '            node.WeightsToChild.Item(IndiceHijo).Previous = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijosPrevio.Item(IndiceHijo)

                        '        Next
                        '        'For IndicePadres As Integer = 0 To node.WeightsToParent.Count - 1
                        '        '    node.WeightsToChild.Item(IndicePadres).Value = Datos.Capas.Item(x).Nodos.Item(IndiceNodos).NodosHijos.Item(IndicePadres)
                        '        'Next
                        '    Next
                        'Next
                        'For Each node In Layers(IndiceCapa).Neurons
                        Dim Nodo As New ClassArchivo_Cerebro.ClassArchivo_Capa.ClassArchivo_Neurona
                        For IndiceNodos As Integer = 0 To Datos.Capas.Item(IndiceCapa).Nodos.Count - 1
                            Layers(IndiceCapa).Neurons.Item(IndiceNodos).ErrorDelta = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).errDelta
                            'node.WeightToBias.Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).Bias
                            'node.WeightToBias = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).Bias
                            For IndiceHijo As Integer = 0 To Layers(IndiceCapa).Neurons.Item(IndiceNodos).WeightsToChild.Count - 1
                                Try
                                    Dim valor As Double = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijos.Item(IndiceHijo)
                                    Layers(IndiceCapa).Neurons.Item(IndiceNodos).WeightsToChild.Item(IndiceHijo).Value = valor
                                    Layers(IndiceCapa).Neurons.Item(IndiceNodos).WeightsToChild.Item(IndiceHijo).Previous = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijosPrevio.Item(IndiceHijo)


                                    'Dim aaa As String = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijosPrevio2.Item(IndiceHijo)
                                    'Layers(IndiceCapa).Neurons.Item(IndiceNodos).WeightsToChild.Item(IndiceHijo).Previous2 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijosPrevio2.Item(IndiceHijo)
                                    'Layers(IndiceCapa).Neurons.Item(IndiceNodos).WeightsToChild.Item(IndiceHijo).Previous3 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijosPrevio3.Item(IndiceHijo)
                                Catch ex As Exception

                                End Try

                            Next
                            'For IndicePadres As Integer = 0 To node.WeightsToParent.Count - 1
                            '    node.WeightsToChild.Item(IndicePadres).Value = Datos.Capas.Item(x).Nodos.Item(IndiceNodos).NodosHijos.Item(IndicePadres)
                            'Next
                        Next
                        'Next




                    Catch ex As Exception
                        Dim a As Boolean = False
                    End Try

                End If


            Next
            Return Resultado
        End Function

        Friend Function Set_Pesos_V0(Datos As ClassArchivo_Cerebro) As Boolean
            Dim Resultado As Boolean = False

            For IndiceCapa As Integer = 0 To (Layers.Count - 1)
                Dim Capa As New ClassArchivo_Cerebro.ClassArchivo_Capa
                If (IndiceCapa > 0) And (IndiceCapa <> (Layers.Count - 1)) Then
                    Capa.Alfa = Layers.Item(IndiceCapa).ActivationFunction.Alfa_p




                    'For Each node In Layers(IndiceCapa).Neurons
                    '    Dim Nodo As New ClassArchivo_Cerebro.ClassArchivo_Capa.ClassArchivo_Neurona
                    '    For IndiceNodos As Integer = 0 To Datos.Capas.Item(IndiceCapa).Nodos.Count - 1
                    '        node.ErrorDelta = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).errDelta
                    '        node.WeightToBias.Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).Bias
                    '        For IndiceHijo As Integer = 0 To node.WeightsToChild.Count - 1
                    '            node.WeightsToChild.Item(IndiceHijo).Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijos.Item(IndiceHijo)
                    '            node.WeightsToChild.Item(IndiceHijo).Previous = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijosPrevio.Item(IndiceHijo)
                    '        Next
                    '        For IndicePadres As Integer = 0 To node.WeightsToParent.Count - 1
                    '            Dim a = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadres.Item(IndicePadres)
                    '            node.WeightsToParent.Item(IndicePadres).Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadres.Item(IndicePadres)
                    '            node.WeightsToParent.Item(IndicePadres).Previous = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadresPrevio.Item(IndicePadres)
                    '        Next
                    '    Next
                    'Next

                    Dim IndiceNodos As Integer = 0
                    For Each node In Layers(IndiceCapa).Neurons
                        'Dim Nodo As New ClassArchivo_Cerebro.ClassArchivo_Capa.ClassArchivo_Neurona
                        'For IndiceNodos As Integer = 0 To Datos.Capas.Item(IndiceCapa).Nodos.Count - 1
                        node.ErrorDelta = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).errDelta
                        node.WeightToBias.Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).Bias
                        Try
                            node.WeightToBias.Previous = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).BiasPrebio
                            node.WeightToBias.Previous2 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).BiasPrebio2
                            node.WeightToBias.Previous3 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).BiasPrebio3
                        Catch ex As Exception

                        End Try

                        For IndiceHijo As Integer = 0 To node.WeightsToChild.Count - 1
                            Dim Paso As Boolean = False
                            Try

                                'Dim aaa As Double = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijosPrevio2.Item(IndiceHijo)
                                'Dim aaa2 As Double = node.WeightsToChild.Item(IndiceHijo).Previous2
                                node.WeightsToChild.Item(IndiceHijo).Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijos.Item(IndiceHijo)
                                node.WeightsToChild.Item(IndiceHijo).Previous = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijosPrevio.Item(IndiceHijo)

                                'Dim aaaaaaa As String = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijosPrevio2.Item(IndiceHijo)
                                'node.WeightsToChild.Item(IndiceHijo).Previous2 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijosPrevio2.Item(IndiceHijo)




                                'node.WeightsToChild.Item(IndiceHijo).Previous3 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijosPrevio3.Item(IndiceHijo)
                                'Paso = True
                            Catch ex As Exception

                            End Try
                            If Paso = True Then
                                Dim aaa = 0
                            End If
                        Next
                        For IndicePadres As Integer = 0 To node.WeightsToParent.Count - 1
                            Dim Paso As Boolean = False
                            Try
                                'Dim a = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadres.Item(IndicePadres)
                                node.WeightsToParent.Item(IndicePadres).Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadres.Item(IndicePadres)
                                node.WeightsToParent.Item(IndicePadres).Previous = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadresPrevio.Item(IndicePadres)





                                'node.WeightsToParent.Item(IndicePadres).Previous2 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadresPrevio2.Item(IndicePadres)
                                'node.WeightsToParent.Item(IndicePadres).Previous3 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadresPrevio3.Item(IndicePadres)





                                'Paso = True
                            Catch ex As Exception

                            End Try
                            If Paso = True Then
                                Dim aaa = 0
                            End If
                        Next
                        'Next
                        IndiceNodos += 1
                    Next
                ElseIf IndiceCapa = (Layers.Count - 1) Then

                    For Each node In Layers(IndiceCapa).Neurons
                        Dim Nodo As New ClassArchivo_Cerebro.ClassArchivo_Capa.ClassArchivo_Neurona
                        For IndiceNodos As Integer = 0 To Datos.Capas.Item(IndiceCapa).Nodos.Count - 1
                            node.ErrorDelta = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).errDelta
                            'For IndiceHijo As Integer = 0 To node.WeightsToChild.Count - 1
                            '    node.WeightsToChild.Item(IndiceHijo).Value = Datos.Capas.Item(x).Nodos.Item(IndiceNodos).NodosHijos.Item(IndiceHijo)
                            'Next
                            Try
                                node.WeightToBias.Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).Bias
                                node.WeightToBias.Previous = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).BiasPrebio
                                node.WeightToBias.Previous2 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).BiasPrebio2
                                node.WeightToBias.Previous3 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).BiasPrebio3
                            Catch ex As Exception

                            End Try

                            For IndicePadres As Integer = 0 To node.WeightsToParent.Count - 1
                                Try
                                    node.WeightsToParent.Item(IndicePadres).Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadres.Item(IndicePadres)
                                    node.WeightsToParent.Item(IndicePadres).Previous = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadresPrevio.Item(IndicePadres)
                                    'node.WeightsToParent.Item(IndicePadres).Previous2 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadresPrevio2.Item(IndicePadres)
                                    'node.WeightsToParent.Item(IndicePadres).Previous3 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosPadresPrevio3.Item(IndicePadres)
                                Catch ex As Exception

                                End Try

                            Next
                        Next
                    Next



                Else
                    Try
                        'For Each node In Layers(IndiceCapa).Neurons
                        '    Dim Nodo As New ClassArchivo_Cerebro.ClassArchivo_Capa.ClassArchivo_Neurona
                        '    For IndiceNodos As Integer = 0 To Datos.Capas.Item(IndiceCapa).Nodos.Count - 1
                        '        node.ErrorDelta = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).errDelta
                        '        'node.WeightToBias.Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).Bias
                        '        'node.WeightToBias = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).Bias
                        '        For IndiceHijo As Integer = 0 To node.WeightsToChild.Count - 1
                        '            Dim valor As Double = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijos.Item(IndiceHijo)
                        '            node.WeightsToChild.Item(IndiceHijo).Value = valor
                        '            node.WeightsToChild.Item(IndiceHijo).Previous = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijosPrevio.Item(IndiceHijo)

                        '        Next
                        '        'For IndicePadres As Integer = 0 To node.WeightsToParent.Count - 1
                        '        '    node.WeightsToChild.Item(IndicePadres).Value = Datos.Capas.Item(x).Nodos.Item(IndiceNodos).NodosHijos.Item(IndicePadres)
                        '        'Next
                        '    Next
                        'Next
                        'For Each node In Layers(IndiceCapa).Neurons
                        Dim Nodo As New ClassArchivo_Cerebro.ClassArchivo_Capa.ClassArchivo_Neurona
                        For IndiceNodos As Integer = 0 To Datos.Capas.Item(IndiceCapa).Nodos.Count - 1
                            Layers(IndiceCapa).Neurons.Item(IndiceNodos).ErrorDelta = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).errDelta
                            'node.WeightToBias.Value = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).Bias
                            'node.WeightToBias = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).Bias
                            For IndiceHijo As Integer = 0 To Layers(IndiceCapa).Neurons.Item(IndiceNodos).WeightsToChild.Count - 1
                                Try
                                    Dim valor As Double = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijos.Item(IndiceHijo)
                                    Layers(IndiceCapa).Neurons.Item(IndiceNodos).WeightsToChild.Item(IndiceHijo).Value = valor
                                    Layers(IndiceCapa).Neurons.Item(IndiceNodos).WeightsToChild.Item(IndiceHijo).Previous = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijosPrevio.Item(IndiceHijo)


                                    'Dim aaa As String = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijosPrevio2.Item(IndiceHijo)
                                    'Layers(IndiceCapa).Neurons.Item(IndiceNodos).WeightsToChild.Item(IndiceHijo).Previous2 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijosPrevio2.Item(IndiceHijo)
                                    'Layers(IndiceCapa).Neurons.Item(IndiceNodos).WeightsToChild.Item(IndiceHijo).Previous3 = Datos.Capas.Item(IndiceCapa).Nodos.Item(IndiceNodos).NodosHijosPrevio3.Item(IndiceHijo)
                                Catch ex As Exception

                                End Try

                            Next
                            'For IndicePadres As Integer = 0 To node.WeightsToParent.Count - 1
                            '    node.WeightsToChild.Item(IndicePadres).Value = Datos.Capas.Item(x).Nodos.Item(IndiceNodos).NodosHijos.Item(IndicePadres)
                            'Next
                        Next
                        'Next




                    Catch ex As Exception
                        Dim a As Boolean = False
                    End Try

                End If


            Next
            Return Resultado
        End Function




        Public Sub BackwardInicializa0()
            Try
                For x As Integer = 1 To (Layers.Count - 1) Step 1
                    For Each node In Layers(x).Neurons

                        For Each w In node.WeightsToParent

                            If w.Previous = 0 Then

                                w.Previous = 0.5
                            End If


                            If w.Previous2 = 0 Then

                                w.Previous2 = w.Previous
                            End If
                            Try
                                If w.Previous3 = 0 Then

                                    w.Previous3 = (w.Previous2 + w.Previous) / 2
                                    'w.Previous = adjustment
                                End If
                            Catch ex As Exception

                            End Try


                        Next


                    Next


                Next
            Catch ex As Exception

            End Try



        End Sub



        Public Sub BackwardInicializa1()
            Try



                For x As Integer = 1 To (Layers.Count - 1) Step 1
                    For Each node In Layers(x).Neurons

                        For Each w In node.WeightsToParent

                            Dim Resultado As Double = 0


                            If Double.IsNaN(node.Primed) Then
                                node.Primed = 6.626 * 10 ^ -34 '4.94065645841247E-200 '4.94065645841247E-324
                            End If

                            If w.Previous2 = 0 Then






                                'Dim Filtrado As Double = ((FactorFIR * w.Previous) + (node.Primed * (1 - FactorFIR)))
                                'If node.Primed = 0 Then
                                '    node.Primed = 6.62607015 * 10 ^ -34
                                'End If
                                'If w.Previous = 0 Then
                                '    Filtrado = (1.61699 * 10 ^ -35) + (node.Primed)
                                '    w.Previous2 = Filtrado * Math.Sqrt(5)
                                'Else
                                '    w.Previous2 = ((w.Previous * Filtrado) + (w.Previous * 8)) / 9
                                'End If










                                Try
                                    Resultado = RepararPesosPrevios(x, node, LearningRate * (node.ErrorDelta * node.WeightToBias.Parent.Output))
                                Catch ex As Exception

                                End Try

                                ' Dim Filtrado As Double = ((FactorFIR * w.Previous) + (node.Primed * (1 - FactorFIR)))
                                'w.Value += adjustment + (Filtrado) * Momentum

                                'w.Previous = adjustment
                            End If
                            Try
                                If w.Previous3 = 0 Then
                                    If w.Previous2 = 0 Then
                                        w.Previous2 = Resultado
                                        'w.Previous2 = 6.626 * 10 ^ -34
                                    End If
                                    'Dim Filtrado As Double = ((FactorFIR * w.Previous) + (node.Primed * (1 - w.Previous2)))
                                    'w.Value += adjustment + (Filtrado) * Momentum
                                    w.Previous3 = (w.Previous2 + w.Previous) / 2
                                    'w.Previous = adjustment
                                End If
                            Catch ex As Exception

                            End Try


                        Next


                    Next


                Next
            Catch ex As Exception

            End Try



        End Sub
        Private Function RepararPesosPrevios(ByVal Capa As Integer, ByVal node As Neuron, ByVal biasAdjustment As Double) As Double
            Dim Resultado As Double = 0
            Dim Resultado2 As Double = 0
            Dim NeuronasCamino(Layers.Count - 2) As Neuron
            Dim AdelanteOutput As Single = 0

            For IndiceCapas As Integer = 1 To Layers.Count - 2
                If IndiceCapas = Capa Then
                    'NeuronasCamino(IndiceCapas) = Layers(IndiceCapas).Neurons.Item(x)
                    'AdelanteOutput += NeuronasCamino(IndiceCapas).Output
                Else
                    Dim Randon1 As New Random()
                    Dim NumeroRando As Integer = Randon1.Next(0, Layers(IndiceCapas).Neurons.Count - 1)
                    NeuronasCamino(IndiceCapas) = Layers(IndiceCapas).Neurons.Item(NumeroRando)
                    AdelanteOutput += NeuronasCamino(IndiceCapas).Output
                End If

            Next


            Dim PesoBiasPrevCalulando As Double = AdelanteOutput

            For Each Neurona1 As Neuron In NeuronasCamino
                Try
                    If IsNumeric(Neurona1.WeightToBias.Value) Then
                        PesoBiasPrevCalulando -= Neurona1.WeightToBias.Value * Neurona1.Input
                    Else

                    End If
                Catch ex As Exception

                End Try



            Next
            'node.WeightToBias.Previous = (PesoBiasPrevCalulando / node.WeightToBias.Value) '((PesoBiasPrevCalulando / node.Output) + (node.WeightToBias.Value * 8)) / 10
            Resultado = (PesoBiasPrevCalulando / node.WeightToBias.Value) '((PesoBiasPrevCalulando / node.Output) + (node.WeightToBias.Value * 8)) / 10
            'Dim Adelante1 As Single = (TextBox_u.Text + (TextBox_j1_a.Text * TextBox_y1_w1.Text)) + (TextBox_u.Text + (TextBox_j2_a.Text * TextBox_y1_w2.Text) + (TextBox_u.Text + (TextBox_j3_a * TextBox_y2_w1) + (TextBox_u.Text + (TextBox_j4_a * TextBox_y2_w2)))) '
            'Dim T_y1_w1 As Single = (Adelante1 - 4 * TextBox_u.Text - (TextBox_j2_a.Text * TextBox_y1_w2.Text) - (TextBox_j3_a * TextBox_y2_w1) - (TextBox_j4_a * TextBox_y2_w2)) / TextBox_j1_a.Text
            'Dim T_j1_w As Single = (Adelante1 - 4 * TextBox_u.Text - (TextBox_j2_a.Text * TextBox_y1_w2.Text) - (TextBox_j3_a * TextBox_y2_w1) - (TextBox_j4_a * TextBox_y2_w2)) / TextBox_j1_a.Text
            'Dim _j1_a As Single = (Adelante1 - 4 * TextBox_u.Text - (TextBox_j2_a.Text * TextBox_y1_w2.Text) - (TextBox_j3_a * TextBox_y2_w1) - (TextBox_j4_a * TextBox_y2_w2)) / TextBox_y1_w1.Text

            node.WeightToBias.Previous2 = Resultado


            If biasAdjustment <> 0 Then
                biasAdjustment = ((Randomizer.Generate + (Momentum * biasAdjustment)) * 4.94065645841247E-81)



            ElseIf node.Primed <> 0 Then
                node.Primed = ((Randomizer.Generate + node.Primed) * 4.94065645841247E-32)

            ElseIf node.ErrorDelta <> 0 Then

                node.ErrorDelta = ((Randomizer.Generate * node.ErrorDelta) * 0.000000000000000494065645841247)
            End If

            Resultado2 = 4.94065645841247E-324 + ((Resultado + node.WeightToBias.Value) / 2)
            If node.WeightToBias.Previous2 = 0 Then

                If Resultado2 <> 0 Then
                    'node.WeightToBias.Previous2 = Resultado2
                    Resultado = Resultado2
                Else
                    'node.WeightToBias.Previous2 = node.WeightToBias.Value
                    Resultado = node.WeightToBias.Value
                End If


            End If
            Return Resultado
        End Function



        Public Sub BackwardPropogate()

            'updating weights for all other layers
            For x = (Layers.Count - 1) To 1 Step -1
                For Each node As Neuron In Layers(x).Neurons

                    'if not output layer, then errors need to be backpropogated from child layer to parent
                    If node.Type <> NeuronType.Output Then
                        node.ErrorDelta = 0.0
                        For Each w In node.WeightsToChild

                            Dim a1 As Double = (w.Value * w.Child.ErrorDelta * w.Child.Primed)
                            If Double.IsNaN(a1) Then
                                Dim aaa As Int16 = 0
                            Else
                                node.ErrorDelta += a1
                            End If

                        Next
                    End If

                    'calculating derivative value of input
                    'node.Primed = Layers(x).ActivationFunction.AbstractDerivative(node.Output)
                    node.Primed = Layers(x).ActivationFunction.Derivative(node.Input)

                    'adjusting weight values between parent layer
                    For Each w In node.WeightsToParent
                        If Double.IsNaN(node.Primed) Then
                            node.Primed = 4.94065645841247E-324
                        End If
                        'FactorFIR = 0.4

                        Dim adjustment = LearningRate * (node.ErrorDelta * node.Primed * w.Parent.Output)
                        If Double.IsNaN(adjustment) Then
                            '    Dim a = 0
                        Else
                            'Dim Filtrado As Double = ((FactorFIR * w.Previous) + (w.Previous2 * (1 - FactorFIR)))
                            'w.Value += adjustment + (Filtrado) * Momentum
                            'Dim Filtrado As Double = ((FactorFIR * w.Previous) + (w.Previous2 * (1 - FactorFIR)))
                            Dim Filtrado2 As Double = ((FactorFIR * w.Previous) + (((w.Previous2 + w.Previous3) / 2) * (1 - FactorFIR)))
                            'w.Value += adjustment + ((FactorFIR * w.Previous) + (w.Previous2 * (1 - FactorFIR))) * Momentum


                            Dim ValorNuevo As Double = adjustment + Filtrado2 * Momentum

                            If Double.IsNaN(ValorNuevo) = False Then
                                If adjustment = 0 Then
                                    ValorNuevo = Math.E * 10 ^ -100
                                Else
                                    ValorNuevo = adjustment + w.Previous * Momentum
                                End If

                            End If
                            w.ValueSet += ValorNuevo
                            w.Previous3 = w.Previous2
                            w.Previous2 = w.Previous
                            w.Previous = adjustment
                        End If

                    Next

                    'adjusting weights between bias
                    Dim biasAdjustment As Double = LearningRate * (node.ErrorDelta * node.Primed * node.WeightToBias.Parent.Output)
                    'Dim Ajuste As Double = (biasAdjustment + (node.WeightToBias.Previous * 2) / 2)
                    'Dim Ajuste1 As Double = biasAdjustment + node.WeightToBias.Previous * Momentum
                    'Dim Ajuste1a As Double = (biasAdjustment + (node.WeightToBias.Previous + (node.WeightToBias.Previous * Momentum)) / 2)
                    'Dim Ajuste1b As Double = (biasAdjustment + ((biasAdjustment - node.WeightToBias.Previous) + (node.WeightToBias.Previous * Momentum)))
                    'Dim Ajuste1a As Double = biasAdjustment + (node.WeightToBias.Previous * Momentum)
                    'node.WeightToBias.Value += (Ajuste + Ajuste1) / 2
                    'node.WeightToBias.Value += (biasAdjustment + ((node.WeightToBias.Previous * 2) / 2) + (biasAdjustment + (node.WeightToBias.Previous * Momentum))) / 2

                    If Double.IsNaN(biasAdjustment) Then
                        Dim a = 0
                    End If

                    'node.WeightToBias.Value += (biasAdjustment + ((biasAdjustment - node.WeightToBias.Previous) + (node.WeightToBias.Previous * Momentum)))
                    'Dim aaaa As Double = (biasAdjustment + ((biasAdjustment - node.WeightToBias.Previous) + (node.WeightToBias.Previous * Momentum)))
                    'Dim bbbb As Double = (biasAdjustment + (((biasAdjustment - node.WeightToBias.Previous) * Momentum) + (node.WeightToBias.Previous * Momentum)))
                    'Dim calculado As Single = ((FiltroFactor * ((ValorCanales * 2 + y_Filtro) / 3) + (y_FiltroAnterior1 * (1 - FiltroFactor))))
                    Dim BiasPrevioCalculando As Double = ((FactorFIRNeurona * ((node.WeightToBias.Previous + node.WeightToBias.Previous2 + node.WeightToBias.Previous3) / 3) + (node.WeightToBias.Previous * (1 - FactorFIRNeurona))))
                    'node.WeightToBias.Value += (biasAdjustment + (((biasAdjustment - node.WeightToBias.Previous) * Momentum) + ((node.WeightToBias.Previous + biasAdjustment) / 2)))
                    node.WeightToBias.ValueSet += (biasAdjustment + (((biasAdjustment - BiasPrevioCalculando) * Momentum) + ((BiasPrevioCalculando + biasAdjustment) / 2)))
                    'node.WeightToBias.Value += biasAdjustment + node.WeightToBias.Previous * Momentum

                    If node.WeightToBias.Previous = 0 Then
                        Dim aaaaaa As Double = 0
                        Dim NeuronasCamino(Layers.Count - 2) As Neuron
                        Dim AdelanteOutput As Single = 0

                        For IndiceCapas As Integer = 0 To Layers.Count - 2
                            If IndiceCapas = x Then
                                'NeuronasCamino(IndiceCapas) = Layers(IndiceCapas).Neurons.Item(x)
                                'AdelanteOutput += NeuronasCamino(IndiceCapas).Output
                            Else
                                Dim Randon1 As New Random()
                                Dim NumeroRando As Integer = Randon1.Next(0, Layers(IndiceCapas).Neurons.Count - 1)
                                NeuronasCamino(IndiceCapas) = Layers(IndiceCapas).Neurons.Item(NumeroRando)
                                AdelanteOutput += NeuronasCamino(IndiceCapas).Output
                            End If

                        Next

                        'For x As Integer = 1 To (Layers.Count - 1)
                        '    For Each node In Layers(x).Neurons
                        '        node.Input = 0.0
                        '        For Each w In node.WeightsToParent
                        '            'Dim a = Layers(x - 1).Neurons
                        '            node.Input += w.Parent.Output * w.Value
                        '        Next
                        '        'adding bias
                        '        node.Input += node.WeightToBias.Parent.Output * node.WeightToBias.Value
                        '        node.Output = Layers(x).ActivationFunction.Evaluate(node.Input)
                        '    Next
                        'Next
                        Dim PesoBiasPrevCalulando As Double = AdelanteOutput

                        For Each Neurona1 As Neuron In NeuronasCamino
                            Try
                                If IsNumeric(Neurona1.WeightToBias.Value) Then
                                    PesoBiasPrevCalulando -= Neurona1.WeightToBias.Value * Neurona1.Input
                                Else

                                End If
                            Catch ex As Exception

                            End Try



                        Next
                        node.WeightToBias.Previous = (PesoBiasPrevCalulando / node.WeightToBias.Value) '((PesoBiasPrevCalulando / node.Output) + (node.WeightToBias.Value * 8)) / 10
                        'Dim Adelante1 As Single = (TextBox_u.Text + (TextBox_j1_a.Text * TextBox_y1_w1.Text)) + (TextBox_u.Text + (TextBox_j2_a.Text * TextBox_y1_w2.Text) + (TextBox_u.Text + (TextBox_j3_a * TextBox_y2_w1) + (TextBox_u.Text + (TextBox_j4_a * TextBox_y2_w2)))) '
                        'Dim T_y1_w1 As Single = (Adelante1 - 4 * TextBox_u.Text - (TextBox_j2_a.Text * TextBox_y1_w2.Text) - (TextBox_j3_a * TextBox_y2_w1) - (TextBox_j4_a * TextBox_y2_w2)) / TextBox_j1_a.Text
                        'Dim T_j1_w As Single = (Adelante1 - 4 * TextBox_u.Text - (TextBox_j2_a.Text * TextBox_y1_w2.Text) - (TextBox_j3_a * TextBox_y2_w1) - (TextBox_j4_a * TextBox_y2_w2)) / TextBox_j1_a.Text
                        'Dim _j1_a As Single = (Adelante1 - 4 * TextBox_u.Text - (TextBox_j2_a.Text * TextBox_y1_w2.Text) - (TextBox_j3_a * TextBox_y2_w1) - (TextBox_j4_a * TextBox_y2_w2)) / TextBox_y1_w1.Text

                        If biasAdjustment <> 0 Then
                            aaaaaa = ((Randomizer.Generate + (Momentum * biasAdjustment)) * 4.94065645841247E-81)



                        ElseIf node.Primed <> 0 Then
                            aaaaaa = ((Randomizer.Generate + node.Primed) * 4.94065645841247E-32)

                        ElseIf node.ErrorDelta <> 0 Then

                            aaaaaa = ((Randomizer.Generate * node.ErrorDelta) * 0.000000000000000494065645841247)
                        End If

                        node.WeightToBias.Previous = 4.94065645841247E-324 + ((aaaaaa + node.WeightToBias.Value) / 2)
                        If node.WeightToBias.Previous2 = 0 Then
                            node.WeightToBias.Previous2 = node.WeightToBias.Value
                        End If
                    End If

                    node.WeightToBias.Previous3 = node.WeightToBias.Previous2
                    node.WeightToBias.Previous2 = node.WeightToBias.Previous
                    node.WeightToBias.Previous = biasAdjustment
                Next
            Next

        End Sub


        Public Sub BackwardPropogateSlow()

            'updating weights for all other layers
            For x = (Layers.Count - 1) To 1 Step -1
                For Each node As Neuron In Layers(x).Neurons
                    System.Threading.Thread.Sleep(1)
                    'if not output layer, then errors need to be backpropogated from child layer to parent
                    If node.Type <> NeuronType.Output Then
                        node.ErrorDelta = 0.0
                        For Each w In node.WeightsToChild

                            Dim a1 As Double = (w.Value * w.Child.ErrorDelta * w.Child.Primed)
                            If Double.IsNaN(a1) Then
                                Dim aaa As Int16 = 0
                            Else
                                node.ErrorDelta += a1
                            End If

                        Next
                    End If

                    'calculating derivative value of input
                    'node.Primed = Layers(x).ActivationFunction.AbstractDerivative(node.Output)
                    node.Primed = Layers(x).ActivationFunction.Derivative(node.Input)

                    'adjusting weight values between parent layer
                    For Each w In node.WeightsToParent
                        'System.Threading.Thread.Sleep(1)
                        If Double.IsNaN(node.Primed) Then
                            node.Primed = 4.94065645841247E-324
                        End If


                        Dim adjustment = LearningRate * (node.ErrorDelta * node.Primed * w.Parent.Output)
                        If Double.IsNaN(adjustment) Then
                            Dim a = 0
                        Else
                            'Dim Filtrado As Double = ((FactorFIR * w.Previous) + (w.Previous2 * (1 - FactorFIR)))
                            'w.Value += adjustment + (Filtrado) * Momentum
                            'Dim Filtrado As Double = ((FactorFIR * w.Previous) + (w.Previous2 * (1 - FactorFIR)))
                            Dim Filtrado2 As Double = ((FactorFIR * w.Previous) + (((w.Previous2 + w.Previous3) / 2) * (1 - FactorFIR)))
                            'w.Value += adjustment + ((FactorFIR * w.Previous) + (w.Previous2 * (1 - FactorFIR))) * Momentum


                            Dim ValorNuevo As Double = adjustment + Filtrado2 * Momentum

                            If IsNumeric(ValorNuevo) = False Then
                                If adjustment = 0 Then
                                    ValorNuevo = Math.E * 10 ^ -100
                                Else
                                    ValorNuevo = adjustment + w.Previous * Momentum
                                End If

                            End If
                            w.ValueSet += ValorNuevo
                            w.Previous3 = w.Previous2
                            w.Previous2 = w.Previous
                            w.Previous = adjustment
                        End If

                    Next

                    'adjusting weights between bias
                    Dim biasAdjustment As Double = LearningRate * (node.ErrorDelta * node.Primed * node.WeightToBias.Parent.Output)
                    'Dim Ajuste As Double = (biasAdjustment + (node.WeightToBias.Previous * 2) / 2)
                    'Dim Ajuste1 As Double = biasAdjustment + node.WeightToBias.Previous * Momentum
                    'Dim Ajuste1a As Double = (biasAdjustment + (node.WeightToBias.Previous + (node.WeightToBias.Previous * Momentum)) / 2)
                    'Dim Ajuste1b As Double = (biasAdjustment + ((biasAdjustment - node.WeightToBias.Previous) + (node.WeightToBias.Previous * Momentum)))
                    'Dim Ajuste1a As Double = biasAdjustment + (node.WeightToBias.Previous * Momentum)
                    'node.WeightToBias.Value += (Ajuste + Ajuste1) / 2
                    'node.WeightToBias.Value += (biasAdjustment + ((node.WeightToBias.Previous * 2) / 2) + (biasAdjustment + (node.WeightToBias.Previous * Momentum))) / 2

                    If Double.IsNaN(biasAdjustment) = True Then
                        Dim a = 0
                    End If

                    'node.WeightToBias.Value += (biasAdjustment + ((biasAdjustment - node.WeightToBias.Previous) + (node.WeightToBias.Previous * Momentum)))
                    'Dim aaaa As Double = (biasAdjustment + ((biasAdjustment - node.WeightToBias.Previous) + (node.WeightToBias.Previous * Momentum)))
                    'Dim bbbb As Double = (biasAdjustment + (((biasAdjustment - node.WeightToBias.Previous) * Momentum) + (node.WeightToBias.Previous * Momentum)))
                    'Dim calculado As Single = ((FiltroFactor * ((ValorCanales * 2 + y_Filtro) / 3) + (y_FiltroAnterior1 * (1 - FiltroFactor))))
                    Dim BiasPrevioCalculando As Double = ((FactorFIRNeurona * ((node.WeightToBias.Previous + node.WeightToBias.Previous2 + node.WeightToBias.Previous3) / 3) + (node.WeightToBias.Previous * (1 - FactorFIRNeurona))))
                    'node.WeightToBias.Value += (biasAdjustment + (((biasAdjustment - node.WeightToBias.Previous) * Momentum) + ((node.WeightToBias.Previous + biasAdjustment) / 2)))
                    node.WeightToBias.ValueSet += (biasAdjustment + (((biasAdjustment - BiasPrevioCalculando) * Momentum) + ((BiasPrevioCalculando + biasAdjustment) / 2)))
                    'node.WeightToBias.Value += biasAdjustment + node.WeightToBias.Previous * Momentum

                    If node.WeightToBias.Previous = 0 Then
                        Dim aaaaaa As Double = 0
                        Dim NeuronasCamino(Layers.Count - 2) As Neuron
                        Dim AdelanteOutput As Single = 0

                        For IndiceCapas As Integer = 0 To Layers.Count - 2
                            'System.Threading.Thread.Sleep(2)
                            If IndiceCapas = x Then
                                'NeuronasCamino(IndiceCapas) = Layers(IndiceCapas).Neurons.Item(x)
                                'AdelanteOutput += NeuronasCamino(IndiceCapas).Output
                            Else
                                Dim Randon1 As New Random()
                                Dim NumeroRando As Integer = Randon1.Next(0, Layers(IndiceCapas).Neurons.Count - 1)
                                NeuronasCamino(IndiceCapas) = Layers(IndiceCapas).Neurons.Item(NumeroRando)
                                AdelanteOutput += NeuronasCamino(IndiceCapas).Output
                            End If

                        Next

                        'For x As Integer = 1 To (Layers.Count - 1)
                        '    For Each node In Layers(x).Neurons
                        '        node.Input = 0.0
                        '        For Each w In node.WeightsToParent
                        '            'Dim a = Layers(x - 1).Neurons
                        '            node.Input += w.Parent.Output * w.Value
                        '        Next
                        '        'adding bias
                        '        node.Input += node.WeightToBias.Parent.Output * node.WeightToBias.Value
                        '        node.Output = Layers(x).ActivationFunction.Evaluate(node.Input)
                        '    Next
                        'Next
                        Dim PesoBiasPrevCalulando As Double = AdelanteOutput

                        For Each Neurona1 As Neuron In NeuronasCamino

                            Try
                                If IsNumeric(Neurona1.WeightToBias.Value) Then
                                    PesoBiasPrevCalulando -= Neurona1.WeightToBias.Value * Neurona1.Input
                                Else

                                End If
                            Catch ex As Exception
                                System.Threading.Thread.Sleep(1)
                            End Try



                        Next
                        node.WeightToBias.Previous = (PesoBiasPrevCalulando / node.WeightToBias.Value) '((PesoBiasPrevCalulando / node.Output) + (node.WeightToBias.Value * 8)) / 10
                        'Dim Adelante1 As Single = (TextBox_u.Text + (TextBox_j1_a.Text * TextBox_y1_w1.Text)) + (TextBox_u.Text + (TextBox_j2_a.Text * TextBox_y1_w2.Text) + (TextBox_u.Text + (TextBox_j3_a * TextBox_y2_w1) + (TextBox_u.Text + (TextBox_j4_a * TextBox_y2_w2)))) '
                        'Dim T_y1_w1 As Single = (Adelante1 - 4 * TextBox_u.Text - (TextBox_j2_a.Text * TextBox_y1_w2.Text) - (TextBox_j3_a * TextBox_y2_w1) - (TextBox_j4_a * TextBox_y2_w2)) / TextBox_j1_a.Text
                        'Dim T_j1_w As Single = (Adelante1 - 4 * TextBox_u.Text - (TextBox_j2_a.Text * TextBox_y1_w2.Text) - (TextBox_j3_a * TextBox_y2_w1) - (TextBox_j4_a * TextBox_y2_w2)) / TextBox_j1_a.Text
                        'Dim _j1_a As Single = (Adelante1 - 4 * TextBox_u.Text - (TextBox_j2_a.Text * TextBox_y1_w2.Text) - (TextBox_j3_a * TextBox_y2_w1) - (TextBox_j4_a * TextBox_y2_w2)) / TextBox_y1_w1.Text

                        If biasAdjustment <> 0 Then
                            aaaaaa = ((Randomizer.Generate + (Momentum * biasAdjustment)) * 4.94065645841247E-81)



                        ElseIf node.Primed <> 0 Then
                            aaaaaa = ((Randomizer.Generate + node.Primed) * 4.94065645841247E-32)

                        ElseIf node.ErrorDelta <> 0 Then

                            aaaaaa = ((Randomizer.Generate * node.ErrorDelta) * 0.000000000000000494065645841247)
                        End If

                        node.WeightToBias.Previous = 4.94065645841247E-324 + ((aaaaaa + node.WeightToBias.Value) / 2)
                        If node.WeightToBias.Previous2 = 0 Then
                            node.WeightToBias.Previous2 = node.WeightToBias.Value
                        End If
                    End If

                    node.WeightToBias.Previous3 = node.WeightToBias.Previous2
                    node.WeightToBias.Previous2 = node.WeightToBias.Previous
                    node.WeightToBias.Previous = biasAdjustment
                    System.Threading.Thread.Sleep(10)
                Next
            Next

        End Sub






        Public Sub BackwardPropogateFIR()

            'updating weights for all other layers
            For x = (Layers.Count - 1) To 1 Step -1
                For Each node In Layers(x).Neurons

                    'if not output layer, then errors need to be backpropogated from child layer to parent
                    If node.Type <> NeuronType.Output Then
                        node.ErrorDelta = 0.0
                        For Each w In node.WeightsToChild

                            Dim a1 As Double = (w.Value * w.Child.ErrorDelta * w.Child.Primed)
                            If Double.IsNaN(a1) Then
                                Dim aaa As Int16 = 0
                            Else
                                node.ErrorDelta += a1
                            End If

                        Next
                    End If

                    'calculating derivative value of input
                    'node.Primed = Layers(x).ActivationFunction.AbstractDerivative(node.Output)
                    node.Primed = Layers(x).ActivationFunction.Derivative(node.Input)

                    'adjusting weight values between parent layer
                    For Each w In node.WeightsToParent
                        If Double.IsNaN(node.Primed) Then
                            node.Primed = 4.94065645841247E-324
                        End If


                        Dim adjustment = LearningRate * (node.ErrorDelta * node.Primed * w.Parent.Output)
                        If Double.IsNaN(adjustment) Then
                            Dim a = 0
                        Else
                            'Dim Filtrado As Double = ((FactorFIR * w.Previous) + (w.Previous2 * (1 - FactorFIR)))
                            'w.Value += adjustment + (Filtrado) * Momentum
                            ' Dim Filtrado As Double = ((FactorFIR * w.Previous) + (w.Previous2 * (1 - FactorFIR)))
                            w.ValueSet += adjustment + ((FactorFIR * w.Previous) + (w.Previous2 * (1 - FactorFIR))) * Momentum
                            w.Previous2 = w.Previous
                            w.Previous = adjustment
                        End If

                    Next

                    'adjusting weights between bias
                    Dim biasAdjustment = LearningRate * (node.ErrorDelta * node.Primed * node.WeightToBias.Parent.Output)
                    'Dim Ajuste As Double = (biasAdjustment + (node.WeightToBias.Previous * 2) / 2)
                    'Dim Ajuste1 As Double = biasAdjustment + node.WeightToBias.Previous * Momentum
                    'Dim Ajuste1a As Double = (biasAdjustment + (node.WeightToBias.Previous + (node.WeightToBias.Previous * Momentum)) / 2)
                    'Dim Ajuste1b As Double = (biasAdjustment + ((biasAdjustment - node.WeightToBias.Previous) + (node.WeightToBias.Previous * Momentum)))
                    'Dim Ajuste1a As Double = biasAdjustment + (node.WeightToBias.Previous * Momentum)
                    'node.WeightToBias.Value += (Ajuste + Ajuste1) / 2
                    'node.WeightToBias.Value += (biasAdjustment + ((node.WeightToBias.Previous * 2) / 2) + (biasAdjustment + (node.WeightToBias.Previous * Momentum))) / 2

                    If (biasAdjustment) = Double.NaN Then
                        Dim a = 0
                    End If

                    'node.WeightToBias.Value += (biasAdjustment + ((biasAdjustment - node.WeightToBias.Previous) + (node.WeightToBias.Previous * Momentum)))
                    'Dim aaaa As Double = (biasAdjustment + ((biasAdjustment - node.WeightToBias.Previous) + (node.WeightToBias.Previous * Momentum)))
                    'Dim bbbb As Double = (biasAdjustment + (((biasAdjustment - node.WeightToBias.Previous) * Momentum) + (node.WeightToBias.Previous * Momentum)))
                    node.WeightToBias.Value += (biasAdjustment + (((biasAdjustment - node.WeightToBias.Previous) * Momentum) + ((node.WeightToBias.Previous + biasAdjustment) / 2)))
                    'node.WeightToBias.Value += biasAdjustment + node.WeightToBias.Previous * Momentum

                    If node.WeightToBias.Previous = 0 Then
                        Dim aaaaaa As Double = 0
                        If biasAdjustment <> 0 Then
                            aaaaaa = ((Randomizer.Generate + (Momentum * biasAdjustment)) * 4.94065645841247E-81)
                        ElseIf node.Primed <> 0 Then
                            aaaaaa = ((Randomizer.Generate + node.Primed) * 4.94065645841247E-32)

                        ElseIf node.ErrorDelta <> 0 Then

                            aaaaaa = ((Randomizer.Generate * node.ErrorDelta) * 0.000000000000000494065645841247)
                        End If

                        node.WeightToBias.Previous = 4.94065645841247E-324 + aaaaaa
                    End If

                    node.WeightToBias.Previous = biasAdjustment
                Next
            Next

        End Sub



        Public Sub BackwardPropogate_V2()

            'updating weights for all other layers
            For x = (Layers.Count - 1) To 1 Step -1
                For Each node In Layers(x).Neurons

                    'if not output layer, then errors need to be backpropogated from child layer to parent
                    If node.Type <> NeuronType.Output Then
                        node.ErrorDelta = 0.0
                        For Each w In node.WeightsToChild

                            Dim a1 As Double = (w.Value * w.Child.ErrorDelta * w.Child.Primed)
                            If Double.IsNaN(a1) Then
                                Dim aaa As Int16 = 0
                            Else
                                node.ErrorDelta += a1
                            End If

                        Next
                    End If

                    'calculating derivative value of input
                    'node.Primed = Layers(x).ActivationFunction.AbstractDerivative(node.Output)
                    node.Primed = Layers(x).ActivationFunction.Derivative(node.Input)

                    'adjusting weight values between parent layer
                    For Each w In node.WeightsToParent
                        If Double.IsNaN(node.Primed) Then
                            node.Primed = 4.94065645841247E-324
                        End If


                        Dim adjustment = LearningRate * (node.ErrorDelta * node.Primed * w.Parent.Output)
                        If Double.IsNaN(adjustment) Then
                            Dim a = 0
                        Else
                            w.ValueSet += adjustment + w.Previous * Momentum
                            w.Previous = adjustment
                        End If

                    Next

                    'adjusting weights between bias
                    Dim biasAdjustment = LearningRate * (node.ErrorDelta * node.Primed * node.WeightToBias.Parent.Output)
                    'Dim Ajuste As Double = (biasAdjustment + (node.WeightToBias.Previous * 2) / 2)
                    'Dim Ajuste1 As Double = biasAdjustment + node.WeightToBias.Previous * Momentum
                    'Dim Ajuste1a As Double = (biasAdjustment + (node.WeightToBias.Previous + (node.WeightToBias.Previous * Momentum)) / 2)
                    'Dim Ajuste1b As Double = (biasAdjustment + ((biasAdjustment - node.WeightToBias.Previous) + (node.WeightToBias.Previous * Momentum)))
                    'Dim Ajuste1a As Double = biasAdjustment + (node.WeightToBias.Previous * Momentum)
                    'node.WeightToBias.Value += (Ajuste + Ajuste1) / 2
                    'node.WeightToBias.Value += (biasAdjustment + ((node.WeightToBias.Previous * 2) / 2) + (biasAdjustment + (node.WeightToBias.Previous * Momentum))) / 2

                    If (biasAdjustment) = Double.NaN Then
                        Dim a = 0
                    End If

                    'node.WeightToBias.Value += (biasAdjustment + ((biasAdjustment - node.WeightToBias.Previous) + (node.WeightToBias.Previous * Momentum)))
                    'Dim aaaa As Double = (biasAdjustment + ((biasAdjustment - node.WeightToBias.Previous) + (node.WeightToBias.Previous * Momentum)))
                    'Dim bbbb As Double = (biasAdjustment + (((biasAdjustment - node.WeightToBias.Previous) * Momentum) + (node.WeightToBias.Previous * Momentum)))
                    node.WeightToBias.ValueSet += (biasAdjustment + (((biasAdjustment - node.WeightToBias.Previous) * Momentum) + ((node.WeightToBias.Previous + biasAdjustment) / 2)))
                    'node.WeightToBias.Value += biasAdjustment + node.WeightToBias.Previous * Momentum

                    If node.WeightToBias.Previous = 0 Then
                        Dim aaaaaa As Double = 0
                        If biasAdjustment <> 0 Then
                            aaaaaa = ((Randomizer.Generate + (Momentum * biasAdjustment)) * 4.94065645841247E-81)
                        ElseIf node.Primed <> 0 Then
                            aaaaaa = ((Randomizer.Generate + node.Primed) * 4.94065645841247E-32)

                        ElseIf node.ErrorDelta <> 0 Then

                            aaaaaa = ((Randomizer.Generate * node.ErrorDelta) * 0.000000000000000494065645841247)
                        End If

                        node.WeightToBias.Previous = 4.94065645841247E-324 + aaaaaa
                    End If

                    node.WeightToBias.Previous = biasAdjustment
                Next
            Next

        End Sub

        Public Sub BackwardPropogateClasic()

            'updating weights for all other layers
            For x = (Layers.Count - 1) To 1 Step -1
                For Each node In Layers(x).Neurons

                    'if not output layer, then errors need to be backpropogated from child layer to parent
                    If node.Type <> NeuronType.Output Then
                        node.ErrorDelta = 0.0
                        For Each w In node.WeightsToChild

                            Dim a1 As Double = (w.Value * w.Child.ErrorDelta * w.Child.Primed)
                            If Double.IsNaN(a1) Then
                                Dim aaa As Int16 = 0
                            Else
                                node.ErrorDelta += a1
                            End If

                        Next
                    End If

                    'calculating derivative value of input
                    'node.Primed = Layers(x).ActivationFunction.AbstractedDerivative(node.Output)
                    node.Primed = Layers(x).ActivationFunction.Derivative(node.Input)

                    'adjusting weight values between parent layer
                    For Each w In node.WeightsToParent
                        If Double.IsNaN(node.Primed) Then
                            node.Primed = 4.94065645841247E-324
                        End If


                        Dim adjustment = LearningRate * (node.ErrorDelta * node.Primed * w.Parent.Output)
                        If Double.IsNaN(adjustment) Then
                            Dim a = 0
                        Else
                            w.ValueSet += adjustment + w.Previous * Momentum
                            w.Previous = adjustment
                        End If

                    Next

                    'adjusting weights between bias
                    Dim biasAdjustment = LearningRate * (node.ErrorDelta * node.Primed * node.WeightToBias.Parent.Output)
                    If (biasAdjustment) = Double.NaN Then
                        Dim a = 0
                    End If
                    node.WeightToBias.ValueSet += biasAdjustment + (node.WeightToBias.Previous * Momentum)


                Next
            Next

        End Sub

#Region "Entrenamiento inicial"

        Public Sub TrainInicial(ByVal data As List(Of Training), ByVal epochs As Integer, ByVal min_error As Double)



            TotalError = 0.0
            For Each item In data
                InputLayer.SetInput(item.Entrada)
                ForwardPropogate()
                OutputLayer.AssignErrors(item.Salida)
                BackwardPropogateInicial()
                TotalError += OutputLayer.CalculateSquaredError()
            Next


        End Sub



        Public Sub BackwardPropogateInicial()
            Dim Aleatorio As New Random
            Dim NumAleatorio(Layers.Count - 1) As Integer
            For indice As Integer = 0 To Layers.Count - 1
                NumAleatorio(indice) = Aleatorio.Next(0, Layers(indice).Neurons.Count - 1)
            Next

            'updating weights for all other layers
            For x = (Layers.Count - 1) To 1 Step -1



                Dim FactorFiltrado As Double = 1 / Layers(x).Neurons.Count
                If FactorFiltrado < 0.00000000001 Then
                    FactorFiltrado = 0.00000000001
                ElseIf FactorFiltrado > 0.9 Then
                    FactorFiltrado = 0.9
                End If

                'For Each node As Neuron In Layers(x).Neurons
                Dim node As Neuron
                Try
                    node = Layers(x).Neurons.Item(NumAleatorio(x))
                Catch ex As Exception

                End Try

                'if not output layer, then errors need to be backpropogated from child layer to parent
                If node.Type <> NeuronType.Output Then
                    node.ErrorDelta = 0.0
                    Try
                        'For Each w In node.WeightsToChild
                        Dim w1 As Weight = node.WeightsToChild.Item(NumAleatorio(x + 1))
                        Dim a1 As Double = (w1.Value * w1.Child.ErrorDelta * w1.Child.Primed)
                        If Double.IsNaN(a1) Then
                            Dim aaa As Int16 = 0
                        Else
                            node.ErrorDelta += a1
                        End If
                    Catch ex As Exception

                    End Try


                    ' Next
                End If

                'calculating derivative value of input
                'node.Primed = Layers(x).ActivationFunction.AbstractDerivative(node.Output)
                node.Primed = Layers(x).ActivationFunction.Derivative(node.Input)

                'adjusting weight values between parent layer
                'For Each w In node.WeightsToParent
                If node.WeightsToParent.Count > 0 Then


                    Dim w2 As Weight = node.WeightsToParent.Item(x + 1)
                    If Double.IsNaN(node.Primed) Then
                        node.Primed = 4.94065645841247E-324
                    End If


                    'Dim adjustment = LearningRate * (node.ErrorDelta * node.Primed * w.Parent.Output)
                    Dim adjustment = (FactorFiltrado / 5) * (node.ErrorDelta * node.Primed * w2.Parent.Output)
                    If Double.IsNaN(adjustment) Then
                        Dim a = 0
                    Else

                        'Dim Filtrado2 As Double = ((FactorFIR * w.Previous) + (((w.Previous2 + w.Previous3) / 2) * (1 - FactorFIR)))
                        Dim Filtrado2 As Double = ((FactorFiltrado * w2.Previous) + (((w2.Previous2 + w2.Previous3) / 2) * (1 - FactorFiltrado)))

                        Dim ValorNuevo As Double = adjustment + Filtrado2 * Momentum

                        If IsNumeric(ValorNuevo) = False Then
                            If adjustment = 0 Then
                                ValorNuevo = Math.E * 10 ^ -100
                            Else
                                ValorNuevo = adjustment + w2.Previous * Momentum
                            End If

                        End If
                        w2.Value += ValorNuevo
                        w2.Previous3 = w2.Previous2
                        w2.Previous2 = w2.Previous
                        w2.Previous = adjustment
                    End If

                    'Next
                End If
                'adjusting weights between bias
                'Dim biasAdjustment As Double = LearningRate * (node.ErrorDelta * node.Primed * node.WeightToBias.Parent.Output)
                Dim biasAdjustment As Double = FactorFiltrado * (node.ErrorDelta * node.Primed * node.WeightToBias.Parent.Output)


                If (biasAdjustment) = Double.NaN Then
                    Dim a = 0
                End If


                'Dim BiasPrevioCalculando As Double = ((FactorFIRNeurona * ((node.WeightToBias.Previous + node.WeightToBias.Previous2 + node.WeightToBias.Previous3) / 3) + (node.WeightToBias.Previous * (1 - FactorFIRNeurona))))
                Dim BiasPrevioCalculando As Double = ((FactorFiltrado * ((node.WeightToBias.Previous + node.WeightToBias.Previous2 + node.WeightToBias.Previous3) / 3) + (node.WeightToBias.Previous * (1 - FactorFiltrado))))
                node.WeightToBias.ValueSet += (biasAdjustment + (((biasAdjustment - BiasPrevioCalculando) * Momentum) + ((BiasPrevioCalculando + biasAdjustment) / 2)))

                If node.WeightToBias.Previous = 0 Then
                    Dim aaaaaa As Double = 0
                    Dim NeuronasCamino(Layers.Count - 2) As Neuron
                    Dim AdelanteOutput As Single = 0

                    For IndiceCapas As Integer = 0 To Layers.Count - 2
                        If IndiceCapas = x Then
                            'NeuronasCamino(IndiceCapas) = Layers(IndiceCapas).Neurons.Item(x)
                            'AdelanteOutput += NeuronasCamino(IndiceCapas).Output
                        Else
                            Dim Randon1 As New Random()
                            Dim NumeroRando As Integer = Randon1.Next(0, Layers(IndiceCapas).Neurons.Count - 1)
                            NeuronasCamino(IndiceCapas) = Layers(IndiceCapas).Neurons.Item(NumeroRando)
                            AdelanteOutput += NeuronasCamino(IndiceCapas).Output
                        End If

                    Next

                    Dim PesoBiasPrevCalulando As Double = AdelanteOutput

                    For Each Neurona1 As Neuron In NeuronasCamino
                        Try
                            If IsNumeric(Neurona1.WeightToBias.Value) Then
                                PesoBiasPrevCalulando -= Neurona1.WeightToBias.Value * Neurona1.Input
                            Else

                            End If
                        Catch ex As Exception

                        End Try



                    Next
                    node.WeightToBias.Previous = (PesoBiasPrevCalulando / node.WeightToBias.Value) '((PesoBiasPrevCalulando / node.Output) + (node.WeightToBias.Value * 8)) / 10
                    'Dim Adelante1 As Single = (TextBox_u.Text + (TextBox_j1_a.Text * TextBox_y1_w1.Text)) + (TextBox_u.Text + (TextBox_j2_a.Text * TextBox_y1_w2.Text) + (TextBox_u.Text + (TextBox_j3_a * TextBox_y2_w1) + (TextBox_u.Text + (TextBox_j4_a * TextBox_y2_w2)))) '
                    'Dim T_y1_w1 As Single = (Adelante1 - 4 * TextBox_u.Text - (TextBox_j2_a.Text * TextBox_y1_w2.Text) - (TextBox_j3_a * TextBox_y2_w1) - (TextBox_j4_a * TextBox_y2_w2)) / TextBox_j1_a.Text
                    'Dim T_j1_w As Single = (Adelante1 - 4 * TextBox_u.Text - (TextBox_j2_a.Text * TextBox_y1_w2.Text) - (TextBox_j3_a * TextBox_y2_w1) - (TextBox_j4_a * TextBox_y2_w2)) / TextBox_j1_a.Text
                    'Dim _j1_a As Single = (Adelante1 - 4 * TextBox_u.Text - (TextBox_j2_a.Text * TextBox_y1_w2.Text) - (TextBox_j3_a * TextBox_y2_w1) - (TextBox_j4_a * TextBox_y2_w2)) / TextBox_y1_w1.Text

                    If biasAdjustment <> 0 Then
                        aaaaaa = ((Randomizer.Generate + (Momentum * biasAdjustment)) * 4.94065645841247E-81)
                    ElseIf node.Primed <> 0 Then
                        aaaaaa = ((Randomizer.Generate + node.Primed) * 4.94065645841247E-32)

                    ElseIf node.ErrorDelta <> 0 Then

                        aaaaaa = ((Randomizer.Generate * node.ErrorDelta) * 0.000000000000000494065645841247)
                    End If

                    node.WeightToBias.Previous = 4.94065645841247E-324 + ((aaaaaa + node.WeightToBias.Value) / 2)
                    If node.WeightToBias.Previous2 = 0 Then
                        node.WeightToBias.Previous2 = node.WeightToBias.Value
                    End If
                End If

                node.WeightToBias.Previous3 = node.WeightToBias.Previous2
                node.WeightToBias.Previous2 = node.WeightToBias.Previous
                node.WeightToBias.Previous = biasAdjustment

                'Next
            Next

        End Sub

        Public Sub BackwardPropogateInicial_0()
            Dim Aleatorio As New Random



            'updating weights for all other layers
            For x = (Layers.Count - 1) To 1 Step -1
                Dim NumAleatorio As Integer = Aleatorio.Next(0, Layers(x).Neurons.Count - 1)
                Dim FactorFiltrado As Double = 1 / Layers(x).Neurons.Count
                'For Each node As Neuron In Layers(x).Neurons
                Dim node As Neuron = Layers(x).Neurons.Item(NumAleatorio)
                'if not output layer, then errors need to be backpropogated from child layer to parent
                If node.Type <> NeuronType.Output Then
                    node.ErrorDelta = 0.0
                    For Each w In node.WeightsToChild

                        Dim a1 As Double = (w.Value * w.Child.ErrorDelta * w.Child.Primed)
                        If Double.IsNaN(a1) Then
                            Dim aaa As Int16 = 0
                        Else
                            node.ErrorDelta += a1
                        End If

                    Next
                End If

                'calculating derivative value of input
                'node.Primed = Layers(x).ActivationFunction.AbstractDerivative(node.Output)
                node.Primed = Layers(x).ActivationFunction.Derivative(node.Input)

                'adjusting weight values between parent layer
                For Each w In node.WeightsToParent
                    If Double.IsNaN(node.Primed) Then
                        node.Primed = 4.94065645841247E-324
                    End If


                    'Dim adjustment = LearningRate * (node.ErrorDelta * node.Primed * w.Parent.Output)
                    Dim adjustment = FactorFiltrado * (node.ErrorDelta * node.Primed * w.Parent.Output)
                    If Double.IsNaN(adjustment) Then
                        Dim a = 0
                    Else

                        'Dim Filtrado2 As Double = ((FactorFIR * w.Previous) + (((w.Previous2 + w.Previous3) / 2) * (1 - FactorFIR)))
                        Dim Filtrado2 As Double = ((FactorFiltrado * w.Previous) + (((w.Previous2 + w.Previous3) / 2) * (1 - FactorFiltrado)))

                        Dim ValorNuevo As Double = adjustment + Filtrado2 * Momentum

                        If IsNumeric(ValorNuevo) = False Then
                            If adjustment = 0 Then
                                ValorNuevo = Math.E * 10 ^ -100
                            Else
                                ValorNuevo = adjustment + w.Previous * Momentum
                            End If

                        End If
                        w.ValueSet += ValorNuevo
                        w.Previous3 = w.Previous2
                        w.Previous2 = w.Previous
                        w.Previous = adjustment
                    End If

                Next

                'adjusting weights between bias
                'Dim biasAdjustment As Double = LearningRate * (node.ErrorDelta * node.Primed * node.WeightToBias.Parent.Output)
                Dim biasAdjustment As Double = FactorFiltrado * (node.ErrorDelta * node.Primed * node.WeightToBias.Parent.Output)


                If (biasAdjustment) = Double.NaN Then
                    Dim a = 0
                End If


                'Dim BiasPrevioCalculando As Double = ((FactorFIRNeurona * ((node.WeightToBias.Previous + node.WeightToBias.Previous2 + node.WeightToBias.Previous3) / 3) + (node.WeightToBias.Previous * (1 - FactorFIRNeurona))))
                Dim BiasPrevioCalculando As Double = ((FactorFiltrado * ((node.WeightToBias.Previous + node.WeightToBias.Previous2 + node.WeightToBias.Previous3) / 3) + (node.WeightToBias.Previous * (1 - FactorFiltrado))))
                node.WeightToBias.ValueSet += (biasAdjustment + (((biasAdjustment - BiasPrevioCalculando) * Momentum) + ((BiasPrevioCalculando + biasAdjustment) / 2)))

                If node.WeightToBias.Previous = 0 Then
                    Dim aaaaaa As Double = 0
                    Dim NeuronasCamino(Layers.Count - 2) As Neuron
                    Dim AdelanteOutput As Single = 0

                    For IndiceCapas As Integer = 0 To Layers.Count - 2
                        If IndiceCapas = x Then
                            'NeuronasCamino(IndiceCapas) = Layers(IndiceCapas).Neurons.Item(x)
                            'AdelanteOutput += NeuronasCamino(IndiceCapas).Output
                        Else
                            Dim Randon1 As New Random()
                            Dim NumeroRando As Integer = Randon1.Next(0, Layers(IndiceCapas).Neurons.Count - 1)
                            NeuronasCamino(IndiceCapas) = Layers(IndiceCapas).Neurons.Item(NumeroRando)
                            AdelanteOutput += NeuronasCamino(IndiceCapas).Output
                        End If

                    Next

                    Dim PesoBiasPrevCalulando As Double = AdelanteOutput

                    For Each Neurona1 As Neuron In NeuronasCamino
                        Try
                            If IsNumeric(Neurona1.WeightToBias.Value) Then
                                PesoBiasPrevCalulando -= Neurona1.WeightToBias.Value * Neurona1.Input
                            Else

                            End If
                        Catch ex As Exception

                        End Try



                    Next
                    node.WeightToBias.Previous = (PesoBiasPrevCalulando / node.WeightToBias.Value) '((PesoBiasPrevCalulando / node.Output) + (node.WeightToBias.Value * 8)) / 10
                    'Dim Adelante1 As Single = (TextBox_u.Text + (TextBox_j1_a.Text * TextBox_y1_w1.Text)) + (TextBox_u.Text + (TextBox_j2_a.Text * TextBox_y1_w2.Text) + (TextBox_u.Text + (TextBox_j3_a * TextBox_y2_w1) + (TextBox_u.Text + (TextBox_j4_a * TextBox_y2_w2)))) '
                    'Dim T_y1_w1 As Single = (Adelante1 - 4 * TextBox_u.Text - (TextBox_j2_a.Text * TextBox_y1_w2.Text) - (TextBox_j3_a * TextBox_y2_w1) - (TextBox_j4_a * TextBox_y2_w2)) / TextBox_j1_a.Text
                    'Dim T_j1_w As Single = (Adelante1 - 4 * TextBox_u.Text - (TextBox_j2_a.Text * TextBox_y1_w2.Text) - (TextBox_j3_a * TextBox_y2_w1) - (TextBox_j4_a * TextBox_y2_w2)) / TextBox_j1_a.Text
                    'Dim _j1_a As Single = (Adelante1 - 4 * TextBox_u.Text - (TextBox_j2_a.Text * TextBox_y1_w2.Text) - (TextBox_j3_a * TextBox_y2_w1) - (TextBox_j4_a * TextBox_y2_w2)) / TextBox_y1_w1.Text

                    If biasAdjustment <> 0 Then
                        aaaaaa = ((Randomizer.Generate + (Momentum * biasAdjustment)) * 4.94065645841247E-81)
                    ElseIf node.Primed <> 0 Then
                        aaaaaa = ((Randomizer.Generate + node.Primed) * 4.94065645841247E-32)

                    ElseIf node.ErrorDelta <> 0 Then

                        aaaaaa = ((Randomizer.Generate * node.ErrorDelta) * 0.000000000000000494065645841247)
                    End If

                    node.WeightToBias.Previous = 4.94065645841247E-324 + ((aaaaaa + node.WeightToBias.Value) / 2)
                    If node.WeightToBias.Previous2 = 0 Then
                        node.WeightToBias.Previous2 = node.WeightToBias.Value
                    End If
                End If

                node.WeightToBias.Previous3 = node.WeightToBias.Previous2
                node.WeightToBias.Previous2 = node.WeightToBias.Previous
                node.WeightToBias.Previous = biasAdjustment
            Next
            'Next

        End Sub

#End Region




    End Class
End Namespace