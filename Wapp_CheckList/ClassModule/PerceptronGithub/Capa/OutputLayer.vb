Imports WApp_ProcesadoSonido.Activation
Imports WApp_ProcesadoSonido.Neurons

Namespace Layers
    Public Class OutputLayer
        Inherits BaseLayer

        Public Sub New(ByVal Size As Integer, ByRef Activation As BaseActivation)
            MyBase.New(Size, Activation)
            For x = 1 To Size
                Neurons.Add(New Neuron(NeuronType.Output))
            Next
        End Sub

        Public Sub AssignErrors(ByVal expected As List(Of Double))
            For x = 0 To (Size - 1)
                Neurons(x).ErrorDelta = expected(x) - Neurons(x).Output
            Next
        End Sub

        Public Function ExtractOutputs() As List(Of Double)
            Dim results = New List(Of Double)
            For Each n In Neurons
                results.Add(n.Output)
            Next
            Return results
        End Function

        Public Function ExtractoOutputs() As Double()
            Dim results = New Double(Neurons.Count - 1) {}
            For n As Integer = 0 To Neurons.Count - 1
                results(n) = Neurons(n).Output
            Next
            Return results
        End Function

        Public Function CalculateSquaredError() As Double
            Dim sum = 0.0
            For Each n In Neurons
                sum += n.ErrorDelta * n.ErrorDelta
            Next
            Return sum / 2
        End Function

    End Class
End Namespace