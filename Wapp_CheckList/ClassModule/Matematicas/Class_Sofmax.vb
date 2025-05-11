Public Class Class_Sofmax
    Friend Function Softmax(ByVal values() As Double, Optional Escala As Double = 1) As Double()
        'Dim maxVal As Double = values.Max()
        Dim maxVal As Double = values.Max()
        Dim exp = values.Select(Function(v) Math.Exp(v - maxVal))
        Dim sumExp As Double = exp.Sum()
        Return exp.Select(Function(v) CDbl(v / sumExp) * Escala).ToArray()
    End Function
End Class
