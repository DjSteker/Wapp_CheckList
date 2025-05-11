Public Class Class_FiltroNotch
    Sub maioso()
        Dim lowPassCoefficients() As Double = {0.1, 0.2, 0.3, 0.2, 0.1} ' Coeficientes del filtro paso bajo
        Dim highPassCoefficients() As Double = {1.0, -0.8} ' Coeficientes del filtro paso alto
        Dim filter As New Class_FiltroNotch(lowPassCoefficients, highPassCoefficients)

        ' Filtrar algunas muestras
        Dim inputSamples() As Double = {1.0, 2.0, 3.0, 4.0, 5.0}
        For Each sample In inputSamples
            Dim outputSample As Double = filter.Filter(sample)
            ' Hacer algo con outputSample...
        Next
    End Sub
    Private _lowPassFilter As Class_FiltroIIR
    Private _highPassFilter As Class_FiltroIIR

    Public Sub New(lowPassCoefficients() As Double, highPassCoefficients() As Double)
        _lowPassFilter = New Class_FiltroIIR(lowPassCoefficients, New Double(lowPassCoefficients.Length - 1) {})
        _highPassFilter = New Class_FiltroIIR(highPassCoefficients, New Double(highPassCoefficients.Length - 1) {})
    End Sub

    Public Function Filter(input As Double) As Double
        Dim lowPassOutput As Double = _lowPassFilter.Filter(input)
        Dim highPassOutput As Double = _highPassFilter.Filter(input)
        Return lowPassOutput - highPassOutput
    End Function
End Class
