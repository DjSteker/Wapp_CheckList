Imports WApp_ProcesadoSonido.ClassArchivo_Cerebro.ClassArchivo_Capa
'Imports WApp_Perceptrones_V1.ClassArchivo_Cerebro
Imports WApp_ProcesadoSonido.Randoms

Friend Class ClassArchivo_Cerebro


    Public Enum NeuronType
        Input
        Hidden
        Output
    End Enum

    Public Enum BaseActivation
        AdjustableSigmoid
        BipolarSigmoid
        HyperbolicTangent
        Linear
        Sigmoid
    End Enum

    'Public Property TotalError As Single
    Public Property Alpha As Double
    Public Property Momentum As Double
    Public Property LearningRate As Double


    Public Property Randomizer As BaseRandom
    Public Property ActivationFunction As BaseActivation

    Public Property Layers As List(Of ClassArchivo_Capa)

    Public Property InputLayer As ClassArchivo_Capa
    Public Property OutputLayer As ClassArchivo_Capa
    Public Property HiddenLayers As List(Of ClassArchivo_Capa)


#Region "Procesos construccion"

    Public Sub Nuevo(ByVal num_input As Integer, ByVal num_hidden As Integer(), ByVal num_output As Integer, ByVal learning_rate As Double, ByVal momentum As Double, ByRef randomi As BaseRandom)
        'setting properties
        Me.Momentum = momentum
        Me.Randomizer = randomi
        Me.LearningRate = learning_rate
        'Me.ActivationFunction = Activation

        'setting bias
        'Me.Bias = New Neuron(NeuronType.Input)
        'Me.Bias.Input = 1
        'Me.Bias.Output = 1

        'initializing lists
        Layers = New List(Of ClassArchivo_Capa)
        HiddenLayers = New List(Of ClassArchivo_Capa)

        'creating layers
        InputLayer = New ClassArchivo_Capa
        For Indice As Integer = 0 To num_input - 1
            Dim NeuronaNueva As New ClassArchivo_Neurona
            NeuronaNueva.Bias = randomi.Generate()
            InputLayer.Nodos.Add(NeuronaNueva)
        Next
        Layers.Add(InputLayer)

        'For Each i In num_hidden
        '    Dim hiddenLayer = New HiddenLayer(i, ActivationFunction)
        '    HiddenLayers.Add(hiddenLayer)
        '    Layers.Add(hiddenLayer)
        'Next
        For Each i In num_hidden
            Dim hiddenLayer = New ClassArchivo_Capa()
            For Indice As Integer = 0 To i - 1
                Dim NeuronaNueva As New ClassArchivo_Neurona
                NeuronaNueva.Bias = randomi.Generate()
                hiddenLayer.Nodos.Add(NeuronaNueva)
            Next
            HiddenLayers.Add(hiddenLayer)
            Layers.Add(hiddenLayer)
        Next

        OutputLayer = New ClassArchivo_Capa
        For Indice As Integer = 0 To num_output - 1
            Dim NeuronaNueva As New ClassArchivo_Neurona
            NeuronaNueva.Bias = randomi.Generate()
            OutputLayer.Nodos.Add(NeuronaNueva)
        Next
        Layers.Add(OutputLayer)

        'connecting layers (creating weights)
        For x As Integer = 0 To (Layers.Count - 2)
            ConectChild((x), Randomizer)

            'connecting bias
            'Layers(x + 1).ConnectBias(Bias, randomizer)
            ConnectNeurona((x), Randomizer)
            'Layers(x).ConnectChild(Layers(x + 1), randomizer)

            ''connecting bias
            'Layers(x + 1).ConnectBias(Bias, randomizer)
        Next

        For x As Integer = 1 To (Layers.Count - 1)
            ConectParent((x), Randomizer)
            ConnectNeurona((x), Randomizer)
        Next

    End Sub

    Public Sub ConectParent(ByRef Indice As Integer, ByRef Random As BaseRandom)

        For Each n2 As ClassArchivo_Neurona In Layers.Item(Indice).Nodos
            n2.Bias = (Random.Generate())
            For Each n As ClassArchivo_Neurona In Layers.Item(Indice - 1).Nodos
                ' Dim weight = New Weight(Random.Generate(), n2, n)
                ' n.WeightsToParent.Add(weight)
                '  n2.WeightsToChild.Add(weight)
                n2.NodosPadres.Add(Random.Generate())
                n2.NodosPadresPrevio.Add(Random.Generate())
            Next

        Next
    End Sub
    Public Sub ConectChild(ByRef Indice As Integer, ByRef Random As BaseRandom)

        For Each n2 As ClassArchivo_Neurona In Layers.Item(Indice).Nodos
            For Each n As ClassArchivo_Neurona In Layers.Item(Indice + 1).Nodos
                ' Dim weight = New Weight(Random.Generate(), n2, n)
                ' n.WeightsToParent.Add(weight)
                '  n2.WeightsToChild.Add(weight)
                n2.NodosHijos.Add(Random.Generate())
                n2.NodosHijosPrevio.Add(Random.Generate())
            Next

        Next
    End Sub
    Public Sub ConnectNeurona(ByRef IndiceCapa As Integer, ByRef Random As BaseRandom)
        'For Each n As ClassArchivo_Neurona In Me.Neurons
        '    'Dim weight = New Weight(Random.Generate(), bias, n)
        '    'n.WeightToBias = weight
        '    'bias.WeightsToChild.Add(weight)
        '    n.Alfa = Random.Generate()
        'Next
        For Each n2 As ClassArchivo_Neurona In Layers.Item(IndiceCapa).Nodos
            n2.Bias = Random.Generate()
            n2.Peso = 0 'Random.Generate()
            n2.Umbral = Random.Generate()
        Next

    End Sub


#End Region

#Region "Calculos hacia a delante y atras"

    Public Sub SetInput(ByVal input As List(Of Double))
        For x = 0 To (InputLayer.Nodos.Count - 1)
            InputLayer.Nodos(x).Input = input(x)
            InputLayer.Nodos(x).Output = input(x)
        Next
    End Sub

    Public Function DerivativeSigmoid0(ByVal value As Double) As Double
        Dim exp = Math.Exp(Alpha * value)
        Return OutputRange.Delta * (Alpha * exp) / ((exp + 1) * (exp + 1))
    End Function
    Public Function Evaluate_Sigmoid0(ByVal value As Double) As Double
        Return OutputRange.Delta / (1 + Math.Exp(-Alpha * value)) '+ OutputRange.Minimum
    End Function

    Public Function DerivativeSigmoid1(ByVal value As Double) As Double
        Dim exp = Math.Exp(Alpha * value)
        Return exp * (1 - exp) 'OutputRange.Delta * (Alpha * exp) / ((exp + 1) * (exp + 1))
    End Function
    Public Function Evaluate_Sigmoid1(ByVal value As Double) As Double
        Return 1 / (1 + Math.Exp(-Alpha * value)) 'OutputRange.Delta / (1 + Math.Exp(-Alpha * value)) '+ OutputRange.Minimum
    End Function

    Public Function AbstractedDerivative(ByVal value As Double) As Double
        Throw New NotImplementedException
    End Function

    Public Function Derivative(ByVal value As Double) As Double
        Dim exp = Math.Exp(Alpha * value)
        Return 2 * (Alpha * exp) / ((exp + 1) * (exp + 1))
    End Function
    Public Function Evaluate(ByVal value As Double) As Double
        Return 2 / (1 + Math.Exp(-Alpha * value)) - 1
    End Function

    Public Function ExtractOutputs(NumeroCapa As Integer) As List(Of Double)
        Dim results = New List(Of Double)
        For Each n In Layers.Item(NumeroCapa).Nodos
            results.Add(n.Output)
        Next
        Return results
    End Function

    Public Sub ForwardPropogate()

        'Dim aaa As Decimal = 0.9
        'Dim bbb As Decimal = Evaluate(aaa)
        'Dim ccc As Decimal = Derivative(bbb)


        'For x As Integer = 1 To (Layers.Count - 1)
        '    For Each node In Layers(x).Neurons
        '        node.Input = 0.0
        '        For Each w In node.WeightsToParent
        '            Dim a = Layers(x - 1).Neurons
        '            node.Input += w.Parent.Output * w.Value
        '        Next
        '        'adding bias
        '        node.Input += node.WeightToBias.Parent.Output * node.WeightToBias.Value
        '        node.Output = Layers(x).ActivationFunction.Evaluate(node.Input)
        '    Next
        'Next
        For IndiceCapas As Integer = 1 To (Layers.Count - 1)
            For Each node In Layers(IndiceCapas).Nodos
                node.Input = 0.0

                Dim CapaPadres As ClassArchivo_Capa = Layers(IndiceCapas - 1)

                For IndicePades As Integer = 0 To CapaPadres.Nodos.Count - 1
                    node.Input += Layers(IndiceCapas - 1).Nodos.Item(IndicePades).Output * node.NodosPadres.Item(IndicePades)
                    'node.Input += Layers(IndiceCapas - 1).Nodos.Item(IndicePades).Output * node.NodosPadres.Item(IndicePades) + node.Bias
                Next
                'adding bias
                node.Input += 1 * node.Bias
                'node.Input += node.Umbral
                node.Output = Evaluate(node.Input)
            Next
        Next

    End Sub


    Public Sub BackwardPropogate0()

        'updating weights for all other layers
        For x = (Layers.Count - 1) To 1 Step -1
            'For Each node In Layers(x).Nodos
            For indiceNodo As Integer = 0 To Layers(x).Nodos.Count - 1
                Dim node As ClassArchivo_Neurona = Layers(x).Nodos.Item(indiceNodo)

                ''if not output layer, then errors need to be backpropogated from child layer to parent
                'If node.Type <> NeuronType.Output Then
                '    node.ErrorDelta = 0.0
                '    For Each w In node.WeightsToChild
                '        node.ErrorDelta += w.Value * w.Child.ErrorDelta * w.Child.Primed
                '    Next
                'End If

                If x <> (Layers.Count - 1) Then
                    node.errDelta = 0.0
                    'For Each w In node.NodosHijos
                    For Indice As Integer = 0 To Layers(x + 1).Nodos.Count - 1
                        node.errDelta += node.NodosHijos.Item(Indice) * Layers(x + 1).Nodos.Item(Indice).errDelta * Layers(x + 1).Nodos.Item(Indice).Primed
                    Next
                End If

                'calculating derivative value of input
                'node.Primed = Layers(x).ActivationFunction.AbstractDerivative(node.Output)
                node.Primed = Derivative(node.Output)

                'adjusting weight values between parent layer
                'For Each w In node.NodosPadres
                '    Dim adjustment = LearningRate * (node.errDelta * node.Primed * w.Parent.Output)
                '    w.Value += adjustment + w.Previous * Momentum
                '    w.Previous = adjustment
                'Next

                For indice As Integer = 0 To node.NodosPadres.Count - 1
                    Dim adjustment = LearningRate * (node.errDelta * node.Primed * Layers(x - 1).OutputTotal) 't.Output)
                    node.NodosPadres.Item(indice) = node.NodosPadresPrevio.Item(indice) * Momentum
                    'Layers(x - 1).Nodos.Item(indice).Bias = node.NodosPadresPrevio.Item(indice) * Momentum
                    node.NodosPadresPrevio.Item(indice) = adjustment
                    'Layers(x - 1).Nodos.Item(indice).BiasPrebio = adjustment
                    'Layers(x - 1).Nodos.Item(indice).NodosHijos.Item(indiceNodo) = node.NodosPadres.Item(indice)
                    'Layers(x - 1).Nodos.Item(indice).NodosHijosPrevio.Item(indiceNodo) = adjustment
                Next


                'adjusting weights between bias
                'Dim biasAdjustment = LearningRate * (node.ErrorDelta * node.Primed * node.WeightToBias.Parent.Output)
                'node.WeightToBias.Value += biasAdjustment + node.WeightToBias.Previous * Momentum
                'node.WeightToBias.Previous = biasAdjustment


                Dim biasAdjustment = LearningRate * (node.errDelta * node.Primed * 1)
                node.Bias += biasAdjustment + node.BiasPrebio * Momentum
                node.BiasPrebio = biasAdjustment

            Next
        Next



        For x = (Layers.Count - 1) To 1 Step -1
            'For Each node In Layers(x).Nodos
            For indiceNodo As Integer = 0 To Layers(x).Nodos.Count - 1
                Dim node As ClassArchivo_Neurona = Layers(x).Nodos.Item(indiceNodo)
                For indice As Integer = 0 To node.NodosPadres.Count - 1
                    Dim adjustment = LearningRate * (node.errDelta * node.Primed * Layers(x - 1).OutputTotal) 't.Output)
                    'Layers(x - 1).Nodos.Item(indice).BiasPrebio = adjustment
                    Layers(x - 1).Nodos.Item(indice).NodosHijosPrevio.Item(indiceNodo) = Layers(x - 1).Nodos.Item(indice).NodosHijos.Item(indiceNodo)
                    Layers(x - 1).Nodos.Item(indice).NodosHijos.Item(indiceNodo) = node.NodosPadres.Item(indice)
                Next
            Next
        Next
    End Sub

    Public Sub BackwardPropogate()

        'updating weights for all other layers
        For x = (Layers.Count - 1) To 1 Step -1

            For indiceNodo As Integer = 0 To Layers(x).Nodos.Count - 1
                Dim node As ClassArchivo_Neurona = Layers(x).Nodos.Item(indiceNodo)



                If x <> (Layers.Count - 1) Then
                    node.errDelta = 0.0

                    For Indice As Integer = 0 To Layers(x + 1).Nodos.Count - 1
                        node.errDelta += node.NodosHijos.Item(Indice) * Layers(x + 1).Nodos.Item(Indice).errDelta * Layers(x + 1).Nodos.Item(Indice).Primed
                    Next
                End If


                node.Primed = Derivative(node.Output)



                For indice As Integer = 0 To node.NodosPadres.Count - 1
                    Dim adjustment = LearningRate * (node.errDelta * node.Primed * Layers(x - 1).OutputTotal) 't.Output)
                    node.NodosPadres.Item(indice) = node.NodosPadresPrevio.Item(indice) * Momentum

                    node.NodosPadresPrevio.Item(indice) = adjustment

                Next



                Dim biasAdjustment = LearningRate * (node.errDelta * node.Primed * 1)
                node.Bias += biasAdjustment + node.BiasPrebio * Momentum
                node.BiasPrebio3 = node.BiasPrebio2
                node.BiasPrebio2 = node.BiasPrebio
                node.BiasPrebio = biasAdjustment

            Next
        Next



        For x = (Layers.Count - 1) To 1 Step -1
            'For Each node In Layers(x).Nodos
            For indiceNodo As Integer = 0 To Layers(x).Nodos.Count - 1
                Dim node As ClassArchivo_Neurona = Layers(x).Nodos.Item(indiceNodo)
                For indice As Integer = 0 To node.NodosPadres.Count - 1
                    'Dim adjustment = LearningRate * (node.errDelta * node.Primed * Layers(x - 1).OutputTotal) 't.Output)
                    'Layers(x - 1).Nodos.Item(indice).BiasPrebio = adjustment
                    Layers(x - 1).Nodos.Item(indice).NodosHijosPrevio.Item(indiceNodo) = Layers(x - 1).Nodos.Item(indice).NodosHijos.Item(indiceNodo)
                    Layers(x - 1).Nodos.Item(indice).NodosHijos.Item(indiceNodo) = node.NodosPadres.Item(indice)
                Next
            Next
        Next
    End Sub



#End Region

#Region "Funciones nuevas"

    Public Function ExtractErrorIndividual(RealOutput() As Integer, DesiredOutput() As Integer) As Double
        Dim Salida As Double = 0
        For indice As Integer = 0 To RealOutput.Count - 1
            Salida += 0.5 * Math.Pow(Math.Abs(RealOutput(indice) - DesiredOutput(indice)), 2)
        Next
        Return Salida
    End Function

    Friend Function GeneralError(ByVal Capa As ClassArchivo_Capa) As Double


        Dim err As Double = 0
        For Each Neurona As ClassArchivo_Neurona In Capa.Nodos
            If Neurona.Tipo = NeuronType.Input Or Neurona.Tipo = NeuronType.Hidden Then
                For Each Peso As Double In Neurona.NodosHijos
                    err += Peso
                Next
            Else
                For Each Peso As Double In Neurona.NodosPadres
                    err += Peso
                Next
            End If

        Next
        Return m_Delta
        Return err
    End Function

    Public Sub SetBiases(ByVal alpha As Double)
        For i_Capa As Integer = 0 To Layers.Count - 1
            For j_Neuron As Integer = 0 To Layers.Item(i_Capa).Nodos.Count - 1
                Layers.Item(i_Capa).Nodos.Item(j_Neuron).Bias -= alpha * Layers.Item(i_Capa).Nodos.Item(j_Neuron).Sigma
            Next
        Next

    End Sub

    Friend Sub ResetDeltas()
        For i As Integer = 0 To Layers.Count - 1
            For j As Integer = 0 To Layers.Item(i).Nodos.Count - 1
                For k As Integer = 0 To Layers.Item(i).Nodos.Item(j).NodosHijos.Count - 1
                    If k > Layers.Item(i).Nodos.Item(j).Deltas.Count - 1 Then
                        Layers.Item(i).Nodos.Item(j).Deltas.Add(0)
                    Else
                        Layers.Item(i).Nodos.Item(j).Deltas.Item(k) = 0
                    End If

                Next
            Next

        Next



    End Sub

    Friend Sub SetWeights(ByRef alpha)
        For i As Integer = 0 To Layers.Count - 1
            For j As Integer = 0 To Layers.Item(i).Nodos.Count - 1
                For k As Integer = 0 To Layers.Item(i).Nodos.Item(j).NodosHijos.Count - 1
                    Layers.Item(i).Nodos.Item(j).NodosHijos.Item(k) -= alpha * Layers.Item(i).Nodos.Item(j).Deltas.Item(k)
                Next
            Next

        Next
    End Sub
    Friend Sub SetBias(ByRef alpha)
        For i As Integer = 0 To Layers.Count - 1
            For j As Integer = 0 To Layers.Item(i).Nodos.Count - 1
                For k As Integer = 0 To Layers.Item(i).Nodos.Item(j).NodosHijos.Count - 1
                    Layers.Item(i).Nodos.Item(k).NodosHijos.Item(k) -= alpha * Layers.Item(i).Nodos.Item(k).Sigma
                Next
            Next

        Next
    End Sub

    Friend Sub SetDelta()

        For i As Integer = 0 To Layers.Count - 1
            For j As Integer = 0 To Layers.Item(i).Nodos.Count - 1
                For k As Integer = 0 To Layers.Item(i).Nodos.Item(j).NodosHijos.Count - 1
                    Layers.Item(i).Nodos.Item(j).Deltas.Item(k) += Layers.Item(i).Nodos.Item(j).Sigma * Evaluate(Layers.Item(i).Nodos.Item(j).Output)
                Next
            Next

        Next
    End Sub

    Friend Sub SetSigmas()


        For i As Integer = Layers.Count - 1 To 0 Step -1
            Layers.Item(i).Delta = 0
            For j As Integer = 0 To Layers.Item(i).Nodos.Count - 1
                If i <> Layers.Count - 1 Then
                    Dim Suma As Double = 0

                    Try
                        For k As Integer = 0 To Layers.Item(i + 1).Nodos.Count - 1

                            Suma += Layers.Item(i).Nodos.Item(j).NodosHijos.Item(k) * Layers.Item(i + 1).Nodos.Item(k).Sigma
                        Next
                        Layers.Item(i).Nodos.Item(j).Sigma = Derivative(Layers.Item(i).Nodos.Item(j).Output) * Suma

                    Catch ex As Exception
                        Dim a = 0
                    End Try

                Else
                    Dim y As Double = Layers.Item(i).Nodos.Item(j).Output
                    Layers.Item(i).Delta += -(Layers.Item(i).Nodos.Item(j).errDelta) * (1 - Layers.Item(i).Nodos.Item(j).Output) * Derivative(y)
                    Layers.Item(i).Nodos.Item(j).Sigma = Layers.Item(i).Nodos.Item(j).errDelta * Derivative(y)
                End If




            Next

        Next
    End Sub

    Friend Sub AplyBackPropagation(ByVal data As List(Of Training), ByVal epochs As Integer, ByVal min_error As Double)
        ResetDeltas()
        Dim imputs As Integer = 1
        TotalError = 0.0

        For Each item In data
            'SetInput(item.Entrada)
            'ForwardPropogate()
            'OutputLayer.AssignErrors(item.Salida)
            'SetSigmas()
            'SetDelta()
            'SetBiases(Alpha)
            'TotalError += OutputLayer.CalculateSquaredError()
            SetInput(item.Entrada)
            ForwardPropogate()
            OutputLayer.AssignErrors(item.Salida)
            SetSigmas()

            SetBiases(Alpha)
            SetDelta()

            TotalError += OutputLayer.CalculateSquaredError()
        Next
        SetWeights(Alpha)

    End Sub

#End Region


#Region "Controles"

    Public Function Test(ByVal data As Testing) As List(Of Double)
        SetInput(data.Input)
        ForwardPropogate()
        Return ExtractOutputs(Layers.Count - 1)
    End Function

    Public Function TestList(ByVal data As List(Of Testing)) As List(Of Double)
        Dim Salidas As New List(Of Double)
        Dim tempResultado As List(Of Double)
        For Each item In data
            SetInput(item.Input)
            ForwardPropogate()
            tempResultado = ExtractOutputs(Layers.Count - 1)
            Salidas.Add(tempResultado.Item(tempResultado.Count - 1))
        Next


        Return Salidas
    End Function

    Public Sub Train(ByVal data As List(Of Training), ByVal epochs As Integer, ByVal min_error As Double)
        Do
            TotalError = 0.0
            For Each item In data
                SetInput(item.Entrada)
                ForwardPropogate()
                OutputLayer.AssignErrors(item.Salida)
                BackwardPropogate()
                TotalError += OutputLayer.CalculateSquaredError()
            Next
            epochs -= 1
        Loop While epochs > 0 And TotalError > min_error

    End Sub

#End Region

#Region "Datos"

    Private m_Id As Integer
    Private m_Nombre As String
    Private m_Capas As New List(Of ClassArchivo_Capa)
    Private m_Delta As Double
    Private m_TotalError As Double

    Public Sub New(c_Id As Integer, c_Nombre As String)

        Me.m_Id = c_Id
        Me.m_Nombre = c_Nombre

    End Sub

    Friend Property Id() As Integer
        Get
            Return m_Id
        End Get
        Set(value As Integer)
            m_Id = value
        End Set
    End Property

    Friend Property Capas() As List(Of ClassArchivo_Capa)
        Get
            Return m_Capas
        End Get
        Set(value As List(Of ClassArchivo_Capa))
            m_Capas = value
        End Set
    End Property

    Friend Property Nombre() As String
        Get
            Return m_Nombre
        End Get
        Set(value As String)
            m_Nombre = value
        End Set
    End Property

    Friend Property Delta() As Double
        Get
            Return m_Delta
        End Get
        Set(value As Double)
            m_Delta = value
        End Set
    End Property

    Friend Property TotalError() As Double
        Get
            Return m_TotalError
        End Get
        Set(value As Double)
            m_TotalError = value
        End Set
    End Property

#End Region



    Class ClassArchivo_Capa

        Class ClassArchivo_Neurona

            Private m_Peso As Double
            Friend BiasPrebio As Double
            Friend BiasPrebio2 As Double
            Friend BiasPrebio3 As Double
            Private m_Bias As Double
            Private m_Umbral As Double
            Private m_Alfa As Double
            Private m_ErrorDelta As Double
            Private m_Input As Double
            Private m_Output As Double
            Private m_Primed As Double
            Private m_Delta As Double
            Private m_Sigma As Double
            Friend Deltas As New List(Of Double)

            Friend DentritasDeltas As New List(Of Double)
            Friend NodosPadres As New List(Of Double)
            Friend NodosHijos As New List(Of Double)
            Friend NodosPadresPrevio As New List(Of Double)
            Friend NodosHijosPrevio As New List(Of Double)
            Friend NodosHijosPrevio2 As New List(Of Double)
            Friend NodosHijosPrevio3 As New List(Of Double)
            Friend NodosPadresPrevio2 As New List(Of Double)
            Friend NodosPadresPrevio3 As New List(Of Double)

            Friend Tipo As NeuronType


            Friend N_Padre As Double
            Friend N_Hijo As Double

            Friend Property Peso() As Double
                Get
                    Return m_Peso
                End Get
                Set(value As Double)
                    m_Peso = value
                End Set
            End Property

            Friend Property Bias() As Double
                Get
                    Return m_Bias
                End Get
                Set(value As Double)
                    m_Bias = value
                End Set
            End Property

            Friend Property Umbral() As Double
                Get
                    Return m_Umbral
                End Get
                Set(value As Double)
                    m_Umbral = value
                End Set
            End Property

            Friend Property Alfa() As Double
                Get
                    Return m_Alfa
                End Get
                Set(value As Double)
                    m_Alfa = value
                End Set
            End Property


            Friend Property errDelta() As Double
                Get
                    Return m_ErrorDelta
                End Get
                Set(value As Double)
                    m_ErrorDelta = value
                End Set
            End Property

            Friend Property Input() As Double
                Get
                    Return m_Input
                End Get
                Set(value As Double)
                    m_Input = value
                End Set
            End Property

            Friend Property Output() As Double
                Get
                    Return m_Output
                End Get
                Set(value As Double)
                    m_Output = value
                End Set
            End Property

            Friend Property Primed() As Double
                Get
                    Return m_Primed
                End Get
                Set(value As Double)
                    m_Primed = value
                End Set
            End Property

            Friend Property Delta() As Double
                Get
                    Return m_Delta
                End Get
                Set(value As Double)
                    m_Delta = value
                End Set
            End Property

            Friend Property Sigma() As Double
                Get
                    Return m_Sigma
                End Get
                Set(value As Double)
                    m_Sigma = value
                End Set
            End Property

        End Class


        Private m_ErrorDelta As Double
        Public Property Size As Integer
        Private m_Alfa As Double
        Private m_Nodos As New List(Of ClassArchivo_Neurona)
        Private m_OutputTotal As Double
        Private m_Delta As Double

        Friend Function OutputTotal() As Double
            Dim Salida As Double = 0
            For indice As Integer = 0 To m_Nodos.Count - 1
                Salida += m_Nodos.Item(indice).Output
            Next
            Return Salida
        End Function

        Friend Property ErrorDelta() As Double
            Get
                Return m_ErrorDelta
            End Get
            Set(value As Double)
                m_ErrorDelta = value
            End Set
        End Property

        Friend Property Nodos() As List(Of ClassArchivo_Neurona)
            Get
                Return m_Nodos
            End Get
            Set(value As List(Of ClassArchivo_Neurona))
                m_Nodos = value
            End Set
        End Property

        Friend Property Alfa() As Double
            Get
                Return m_Alfa
            End Get
            Set(value As Double)
                m_Alfa = value
            End Set
        End Property

        Public Sub AssignErrors(ByVal expected As List(Of Double))
            'For x = 0 To (m_Nodos.Count - 1)
            '    m_Nodos.Item(x).errDelta = expected(x) - m_Nodos(x).Output
            'Next
            For x = (m_Nodos.Count - 1) To 0 Step -1
                m_Nodos.Item(x).errDelta = expected(x) - m_Nodos(x).Output
            Next
        End Sub

        Friend Property Delta(Optional Actulizar As Boolean = False) As Double
            Get
                If Actulizar Then
                    m_Delta = 0
                    For Each Neurona As ClassArchivo_Neurona In m_Nodos
                        If Neurona.Tipo = NeuronType.Input Or Neurona.Tipo = NeuronType.Hidden Then
                            For Each Peso As Double In Neurona.NodosHijos
                                m_Delta += Peso
                            Next
                        Else
                            For Each Peso As Double In Neurona.NodosPadres
                                m_Delta += Peso
                            Next
                        End If

                        'm_Delta += Neurona.Bias
                    Next
                End If

                Return m_Delta
            End Get
            Set(value As Double)
                m_Delta = value
            End Set
        End Property


        Public Function CalculateSquaredError() As Double
            Dim sum = 0.0
            'For Each n In m_Nodos
            '    sum += n.ErrorDelta * n.ErrorDelta
            'Next
            For x = 0 To (m_Nodos.Count - 1)
                sum += m_Nodos.Item(x).errDelta * m_Nodos.Item(x).errDelta
            Next
            Return sum / 2
        End Function

    End Class



    Protected out_range As Range1
    Public ReadOnly Property OutputRange As Range1
        Get
            Return out_range
        End Get
    End Property



End Class

