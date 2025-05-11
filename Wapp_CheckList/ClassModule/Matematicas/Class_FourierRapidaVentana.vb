Public Class Class_FourierRapidaVentana


    ' Función para calcular la FFT
    Function FFT(x() As Class_Fourier2.Complex_1) As Class_Fourier2.Complex_1()
        Dim N As Integer = x.Length
        If N <= 1 Then
            Return x
        End If

        ' Dividir la señal en componentes pares e impares
        Dim even(N / 2 - 1) As Class_Fourier2.Complex_1
        Dim odd(N / 2 - 1) As Class_Fourier2.Complex_1
        For i As Integer = 0 To N / 2 - 1
            even(i) = x(2 * i)
            odd(i) = x(2 * i + 1)
        Next

        ' Calcular la FFT de los componentes pares e impares
        even = FFT(even)
        odd = FFT(odd)

        ' Combinar
        Dim result(N - 1) As Class_Fourier2.Complex_1
        For k As Integer = 0 To N / 2 - 1
            Dim t As Class_Fourier2.Complex_1 = Class_Fourier2.Complex_1.Exp(New Class_Fourier2.Complex_1(0, -2 * Math.PI * k / N)) * odd(k)
            result(k) = even(k) + t
            result(k + N / 2) = even(k) - t
        Next

        Return result
    End Function

    ' Función para aplicar la ventana de Hamming a una señal
    Sub ApplyHammingWindow(ByRef signal() As Double)
        Dim N As Integer = signal.Length
        For i As Integer = 0 To N - 1
            signal(i) = signal(i) * (0.54 - 0.46 * Math.Cos(2 * Math.PI * i / (N - 1)))
        Next
    End Sub

    ' Función para aplicar la ventana de Hamming a una señal
    Function GetHammingWindow(ByRef signal() As Double) As Double()
        Dim N As Integer = signal.Length
        For i As Integer = 0 To N - 1
            signal(i) = signal(i) * (0.54 - 0.46 * Math.Cos(2 * Math.PI * i / (N - 1)))
        Next
        Return signal
    End Function
End Class
