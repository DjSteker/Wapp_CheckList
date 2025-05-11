Imports WApp_ProcesadoSonido.Utilities

Namespace Activation

    Public Class Linear
        Inherits BaseActivation

        Public Property Slope As Double

        Public Sub New()
            Slope = 1
            in_range = New Range(Double.NegativeInfinity, Double.PositiveInfinity)
            out_range = New Range(Double.NegativeInfinity, Double.PositiveInfinity)
        End Sub

        Public Sub New(ByVal slope As Single)
            Me.Slope = slope
            in_range = New Range(Double.NegativeInfinity, Double.PositiveInfinity)
            out_range = New Range(Double.NegativeInfinity, Double.PositiveInfinity)
        End Sub

        Public Sub New(ByVal slope As Integer)
            Me.Slope = slope
        End Sub

        Public Overrides Function AbstractedDerivative(ByVal value As Double) As Double
            Return Slope
        End Function

        Public Overrides Function Derivative(ByVal value As Double) As Double
            Return Slope
        End Function

        Public Overrides Function Evaluate(ByVal value As Double) As Double
            Return Slope * value
        End Function

        Public Overrides Property Alfa_p() As Double
            Get
                Return Slope
            End Get
            Set(value As Double)
                Slope = value
            End Set
        End Property
    End Class
End Namespace
