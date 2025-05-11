Public Class Class_FiltroFIR

    Sub manioso()
        Dim coefficients() As Double = {0.1, 0.2, 0.3, 0.2, 0.1} ' Coeficientes del filtro
        Dim filter As New Class_FiltroFIR(coefficients)

        ' Filtrar algunas muestras
        Dim inputSamples() As Double = {1.0, 2.0, 3.0, 4.0, 5.0}
        For Each sample In inputSamples
            Dim outputSample As Double = filter.Filter(sample)
            ' Hacer algo con outputSample...
        Next
    End Sub


    Private _coefficients() As Double
    Private _buffer() As Double

    Public Sub New(coefficients() As Double)
        _coefficients = coefficients
        _buffer = New Double(coefficients.Length - 1) {}
    End Sub

    Public Function Filter(input As Double) As Double
        ' Shift the old samples
        For i = _buffer.Length - 1 To 1 Step -1
            _buffer(i) = _buffer(i - 1)
        Next

        ' Add new sample to the buffer
        _buffer(0) = input

        ' Apply the filter (convolution)
        Dim output As Double = 0.0
        For i = 0 To _coefficients.Length - 1
            output += _coefficients(i) * _buffer(i)
        Next

        Return output
    End Function
End Class
