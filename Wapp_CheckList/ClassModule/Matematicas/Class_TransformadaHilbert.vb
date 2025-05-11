
Public Class Class_TransformadaHilbert

    Public Function ObtenerTransformadaHilbert(ByRef buffer() As Double) As Double()
        Dim n As Integer = buffer.Length
        Dim dft_real(n - 1) As Double
        Dim dft_imag(n - 1) As Double
        Dim hilbertTransformed(n - 1) As Double

        ' Calcular la DFT
        For k As Integer = 0 To n - 1
            For t As Integer = 0 To n - 1
                dft_real(k) += buffer(t) * Math.Cos(2 * Math.PI * k * t / n)
                dft_imag(k) -= buffer(t) * Math.Sin(2 * Math.PI * k * t / n)
            Next
        Next

        ' Aplicar la transformada de Hilbert
        For k As Integer = 0 To n - 1
            If k < n / 2 Then
                hilbertTransformed(k) = -dft_imag(k)
            Else
                hilbertTransformed(k) = dft_imag(k)
            End If
        Next

        ' Inversa de la DFT para obtener la señal en el dominio del tiempo
        Dim hilbertSignal(n - 1) As Double
        For t As Integer = 0 To n - 1
            For k As Integer = 0 To n - 1
                hilbertSignal(t) += hilbertTransformed(k) * Math.Cos(2 * Math.PI * k * t / n) - dft_real(k) * Math.Sin(2 * Math.PI * k * t / n)
            Next
            hilbertSignal(t) /= n
        Next

        Return hilbertSignal
    End Function

    Public Function BandPassFilter(ByRef buffer() As Double, ByVal lowFreq As Double, ByVal highFreq As Double) As Double()
        Dim n As Integer = buffer.Length
        Dim hilbertSignal() As Double = ObtenerTransformadaHilbert(buffer)
        Dim analyticSignal_real(n - 1) As Double
        Dim analyticSignal_imag(n - 1) As Double

        ' Crear la señal analítica
        For i As Integer = 0 To n - 1
            analyticSignal_real(i) = buffer(i)
            analyticSignal_imag(i) = hilbertSignal(i)
        Next

        ' Aplicar el filtro pasa banda
        Dim filteredSignal_real(n - 1) As Double
        Dim filteredSignal_imag(n - 1) As Double
        For k As Integer = 0 To n - 1
            Dim freq As Double = k / n
            If freq >= lowFreq And freq <= highFreq Then
                filteredSignal_real(k) = analyticSignal_real(k)
                filteredSignal_imag(k) = analyticSignal_imag(k)
            Else
                filteredSignal_real(k) = 0
                filteredSignal_imag(k) = 0
            End If
        Next

        ' Inversa de la DFT para obtener la señal filtrada en el dominio del tiempo
        Dim result(n - 1) As Double
        For t As Integer = 0 To n - 1
            For k As Integer = 0 To n - 1
                result(t) += filteredSignal_real(k) * Math.Cos(2 * Math.PI * k * t / n) - filteredSignal_imag(k) * Math.Sin(2 * Math.PI * k * t / n)
            Next
            result(t) /= n
        Next

        Return result
    End Function

End Class
