Public Class Class_FourierTransdormaInversa


    Friend Function IDFT_1()
        '' Supongamos que tienes una señal discreta f(n) con N muestras
        'Dim N As Integer = 8
        'Dim f(N - 1) As Complex ' Usaremos números complejos para almacenar los valores

        '' Llena la señal f(n) con valores (puedes ajustarlos según tus necesidades)
        'For n As Integer = 0 To n - 1
        '    f(n) = New Complex(Math.Cos(2 * Math.PI * n / n), 0)
        'Next

        '' Calcula la DFT
        'Dim F(N - 1) As Complex
        'For k As Integer = 0 To N - 1
        '    f(k) = Complex.Zero
        '    For n As Integer = 0 To n - 1
        '        f(k) += f(n) * Complex.Exp(-2 * Math.PI * Complex.ImaginaryOne * k * n / n)
        '    Next
        'Next

        '' Calcula la IDFT
        'Dim f_reconstructed(N - 1) As Complex
        'For n As Integer = 0 To n - 1
        '    f_reconstructed(n) = Complex.Zero
        '    For k As Integer = 0 To n - 1
        '        f_reconstructed(n) += f(k) * Complex.Exp(2 * Math.PI * Complex.ImaginaryOne * k * n / n)
        '    Next
        '    f_reconstructed(n) /= n
        'Next

        '' Imprime los resultados (puedes adaptar esto según tus necesidades)
        'Console.WriteLine("Señal original:")
        'For n As Integer = 0 To n - 1
        '    Console.WriteLine($"f({n}) = {f(n).Real}")
        'Next

        'Console.WriteLine("DFT:")
        'For k As Integer = 0 To N - 1
        '    Console.WriteLine($"F({k}) = {f(k).Magnitude}")
        'Next

        'Console.WriteLine("IDFT (señal reconstruida):")
        'For n As Integer = 0 To n - 1
        '    Console.WriteLine($"f_reconstructed({n}) = {f_reconstructed(n).Real}")
        'Next

    End Function




    Dim I As Double

    Function DFT(data As Double()) As Double()
        Dim N As Integer = UBound(data) + 1
        Dim X As Double()
        ReDim X(0 To N - 1)

        For k = 0 To N - 1
            For N = 0 To N - 1
                X(k) = X(k) + data(N) * Math.Exp(-2 * Math.PI * I * k * N / N)
            Next N
        Next k

        DFT = X
    End Function


    Function IDFT(data As Double()) As Double()
        Dim N As Integer = UBound(data) + 1
        Dim X As Double()
        ReDim X(0 To N - 1)

        For N = 0 To N - 1
            For k = 0 To N - 1
                X(N) = X(N) + data(k) * Math.Exp(2 * Math.PI * I * k * N / N)
            Next k
        Next N

        For i = 0 To N - 1
            X(i) = X(i) / N
        Next i

        IDFT = X
    End Function


    Sub maniosi1()
        Dim data As Double() = New Double() {1.0, 2.0, 3.0, 4.0, 5.0}
        Dim dft1 As Double() = DFT(data)
        Dim idft1 As Double() = IDFT(dft1)

        Console.WriteLine("Señal original:")
        Console.WriteLine(String.Join(", ", data))

        Console.WriteLine("Componentes de frecuencia (DFT):")
        Console.WriteLine(String.Join(", ", dft1))

        Console.WriteLine("Señal reconstruida (IDFT):")
        Console.WriteLine(String.Join(", ", idft1))
    End Sub











End Class


