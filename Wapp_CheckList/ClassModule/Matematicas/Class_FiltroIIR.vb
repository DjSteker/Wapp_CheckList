Public Class Class_FiltroIIR

    Sub mainioso()
        Dim aCoefficients() As Double = {0.1, 0.2, 0.3, 0.2, 0.1} ' Coeficientes a del filtro
        Dim bCoefficients() As Double = {1.0, -0.8} ' Coeficientes b del filtro
        Dim filter As New Class_FiltroIIR(aCoefficients, bCoefficients)

        ' Filtrar algunas muestras
        Dim inputSamples() As Double = {1.0, 2.0, 3.0, 4.0, 5.0}
        For Each sample In inputSamples
            Dim outputSample As Double = filter.Filter(sample)
            ' Hacer algo con outputSample...
        Next
    End Sub

    Private _aCoefficients() As Double
    Private _bCoefficients() As Double
    Private _inputBuffer() As Double
    Private _outputBuffer() As Double

    Public Sub New(aCoefficients() As Double, bCoefficients() As Double)
        _aCoefficients = aCoefficients
        _bCoefficients = bCoefficients
        _inputBuffer = New Double(aCoefficients.Length - 1) {}
        _outputBuffer = New Double(bCoefficients.Length - 1) {}
    End Sub

    Public Function Filter(input As Double) As Double
        ' Shift the old samples
        For i = _inputBuffer.Length - 1 To 1 Step -1
            _inputBuffer(i) = _inputBuffer(i - 1)
        Next
        _inputBuffer(0) = input

        For i = _outputBuffer.Length - 1 To 1 Step -1
            _outputBuffer(i) = _outputBuffer(i - 1)
        Next

        ' Apply the filter
        Dim output As Double = 0.0
        For i = 0 To _aCoefficients.Length - 1
            output += _aCoefficients(i) * _inputBuffer(i)
        Next
        For i = 1 To _bCoefficients.Length - 1
            output -= _bCoefficients(i) * _outputBuffer(i)
        Next
        _outputBuffer(0) = output

        Return output
    End Function

End Class
