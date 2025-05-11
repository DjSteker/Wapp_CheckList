Imports WApp_ProcesadoSonido.Activation
Imports WApp_ProcesadoSonido.Neurons

Namespace Layers
    Public Class InputLayer
        Inherits BaseLayer

        Public Sub New(ByVal Size As Integer, ByRef Activation As BaseActivation)
            MyBase.New(Size, Activation)
            For x = 1 To Size
                Neurons.Add(New Neuron(NeuronType.Input))
            Next
        End Sub

        Public Sub SetInput(ByVal input_ As List(Of Double))
            For x = 0 To (Size - 1)
                Neurons(x).Input = input_(x)
                Neurons(x).Output = input_(x)
            Next
        End Sub

    End Class
End Namespace
