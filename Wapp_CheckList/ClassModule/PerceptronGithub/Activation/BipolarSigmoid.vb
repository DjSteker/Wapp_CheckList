Imports WApp_ProcesadoSonido.Utilities

Namespace Activation
    Public Class BipolarSigmoid
        Inherits BaseActivation

        Public Property Alpha As Double

        Public Sub New()
            Alpha = 1
            in_range = New Range(Double.NegativeInfinity, Double.PositiveInfinity)
            out_range = New Range(-1, 1)
        End Sub

        Public Sub New(ByVal Alpha As Double)
            Me.Alpha = Alpha
            in_range = New Range(Double.NegativeInfinity, Double.PositiveInfinity)
            out_range = New Range(-1, 1)
        End Sub

        Public Overrides Function AbstractedDerivative(ByVal value As Double) As Double
            Throw New NotImplementedException
        End Function

        Public Overrides Function Derivative(ByVal value As Double) As Double
            Dim exp = Math.Exp(Alpha * value)
            Return 2 * (Alpha * exp) / ((exp + 1) * (exp + 1))
        End Function

        Public Overrides Function Evaluate(ByVal value As Double) As Double
            Return 2 / (1 + Math.Exp(-Alpha * value)) - 1
        End Function

        Public Overrides Property Alfa_p() As Double
            Get
                Return Alpha
            End Get
            Set(value As Double)
                Alpha = value
            End Set
        End Property
    End Class
End Namespace
