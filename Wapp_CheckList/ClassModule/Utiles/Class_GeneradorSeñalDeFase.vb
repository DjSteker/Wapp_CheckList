Public Class Class_GeneradorSeñalDeFase

    ' Constantes
    Const A As Double = 1.0 ' Amplitud de la señal
    Const fc As Double = 1000.0 ' Frecuencia portadora en Hz
    Const T As Double = 0.001 ' Intervalo de señalización en segundos
    Const h As Double = 0.5 ' Índice de modulación
    Const B As Double = 0.3 ' Ancho de banda de -3 dB del filtro

    Sub MainSeñalFase()
        ' Generar la señal
        Dim signal As List(Of Double) = GenerateSignal(1000)

        ' Imprimir la señal generada
        For Each value As Double In signal
            Console.WriteLine(value)
        Next
    End Sub

    Function GenerateSignal(samples As Integer) As List(Of Double)
        Dim signal As New List(Of Double)
        Dim t As Double = 0.0
        Dim dt As Double = t / samples

        For i As Integer = 0 To samples - 1
            Dim phase As Double = 2 * Math.PI * fc * t + PhaseDeviation(t)
            Dim value As Double = A * Math.Cos(phase)
            signal.Add(value)
            t += dt
        Next

        Return signal
    End Function

    Function PhaseDeviation(t As Double) As Double
        ' Ejemplo de desviación de fase utilizando un pulso rectangular
        Dim fd As Double = h * PulseShape(t)
        Return 2 * Math.PI * fd * t
    End Function

    Function PulseShape(t As Double) As Double
        ' Forma del pulso de desviación de frecuencia (rectangular en este caso)
        If t >= 0 AndAlso t <= t Then
            Return 1.0 / t
        Else
            Return 0.0
        End If
    End Function

End Class
