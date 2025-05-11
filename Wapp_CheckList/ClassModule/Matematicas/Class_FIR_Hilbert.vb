Public Class Class_FIR_Hilbert

    'Sub Main()
    '    ' Generar una señal de ejemplo
    '    Dim sampleRate As Integer = 1000
    '    Dim t(1000) As Double
    '    Dim x(1000) As Double
    '    For i As Integer = 0 To 1000
    '        t(i) = i / sampleRate
    '        x(i) = Math.Sin(2 * Math.PI * 50 * t(i)) + Math.Sin(2 * Math.PI * 120 * t(i))
    '    Next

    '    ' Crear un filtro FIR de Hilbert
    '    Dim hilbertFilter As OnlineFirFilter = OnlineFirFilter.CreateHilbert(ImpulseResponse.Finite, 21)

    '    ' Aplicar el filtro FIR de Hilbert a la señal
    '    Dim x_hilbert(1000) As Double
    '    For i As Integer = 0 To 1000
    '        x_hilbert(i) = hilbertFilter.ProcessSample(x(i))
    '    Next

    '    ' Mostrar la señal original y la señal transformada por Hilbert
    '    For i As Integer = 0 To 1000
    '        Console.WriteLine("t: " & t(i) & " Original: " & x(i) & " Hilbert: " & x_hilbert(i))
    '    Next
    'End Sub

    Sub Main()
        ' Generar una señal de ejemplo
        Dim sampleRate As Integer = 1000
        Dim t(1000) As Double
        Dim x(1000) As Double
        For i As Integer = 0 To 1000
            t(i) = i / sampleRate
            x(i) = Math.Sin(2 * Math.PI * 50 * t(i)) + Math.Sin(2 * Math.PI * 120 * t(i))
        Next

        ' Coeficientes del filtro FIR de Hilbert (ejemplo con 21 coeficientes)
        Dim hilbertCoeffs() As Double = {0, -0.091, 0, -0.303, 0, 1, 0, -1, 0, 0.303, 0, 0.091, 0, -0.091, 0, -0.303, 0, 1, 0, -1, 0, 0.091}

        ' Aplicar el filtro FIR de Hilbert a la señal
        Dim x_hilbert(1000) As Double
        For i As Integer = 0 To 1000
            x_hilbert(i) = 0
            For j As Integer = 0 To hilbertCoeffs.Length - 1
                If i - j >= 0 Then
                    x_hilbert(i) += hilbertCoeffs(j) * x(i - j)
                End If
            Next
        Next

        ' Mostrar la señal original y la señal transformada por Hilbert
        For i As Integer = 0 To 1000
            Console.WriteLine("t: " & t(i) & " Original: " & x(i) & " Hilbert: " & x_hilbert(i))
        Next
    End Sub

End Class
