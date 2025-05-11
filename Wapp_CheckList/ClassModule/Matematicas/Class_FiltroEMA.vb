Public Class Class_FiltroEMA

    Private Property alpha As Double
    Private Property EMA_LP As Double
    Private Property EMA_HP As Double

    Public Sub New(ByVal alpha As Double)
        Me.alpha = alpha
        EMA_LP = 0
        EMA_HP = 0
    End Sub

    Public Function FiltrarPasoBajo(ByVal value As Double) As Double
        EMA_LP = alpha * value + (1 - alpha) * EMA_LP
        Return EMA_LP
    End Function

    Public Function FiltrarPasoAlto(ByVal value As Double) As Double
        EMA_HP = value - FiltrarPasoBajo(value)
        Return EMA_HP
    End Function

End Class
