Public Class Class_Fourier2
    ' Función que realiza la FFT y devuelve la frecuencia predominante
    Public Shared Function CalculateDominantFrequency(signal As Short()) As Double
        Dim n As Integer = signal.Length
        Dim fftComplex As Complex_1() = New Complex_1(n - 1) {}

        ' Convertir la señal de Int16 a Complex para la FFT
        For i As Integer = 0 To n - 1
            fftComplex(i) = New Complex_1(signal(i), 0.0)
        Next

        ' Realizar la FFT
        Dim fftResult As Complex_1() = FFT(fftComplex)

        ' Calcular la magnitud de los resultados de la FFT
        Dim magnitudes As Double() = fftResult.Select(Function(c) c.Magnitude).ToArray()

        ' Encontrar el índice de la magnitud máxima
        Dim maxIndex As Integer = Array.IndexOf(magnitudes, magnitudes.Max())

        ' Calcular la frecuencia predominante
        Dim sampleRate As Double = 44100 ' Asumiendo una tasa de muestreo de 44100 Hz
        Dim dominantFrequency As Double = maxIndex * sampleRate / n

        Return dominantFrequency
    End Function

    ' Implementación de la FFT (este es un ejemplo simple y no optimizado)
    Private Shared Function FFT(buffer As Complex_1()) As Complex_1()
        Dim n As Integer = buffer.Length
        If n = 1 Then Return buffer

        Dim even As Complex_1() = FFT(buffer.Where(Function(x, i) i Mod 2 = 0).ToArray())
        Dim odd As Complex_1() = FFT(buffer.Where(Function(x, i) i Mod 2 <> 0).ToArray())

        Dim combined As Complex_1() = New Complex_1(n - 1) {}
        For k As Integer = 0 To n \ 2 - 1
            Dim expToken As Complex_1 = Complex_1.Exp(New Complex_1(0, -2 * Math.PI * k / n))
            combined(k) = even(k) + expToken * odd(k)
            combined(k + n \ 2) = even(k) - expToken * odd(k)
        Next

        Return combined
    End Function

    Public Class Complex_0
        Public Property freq As Double
        Public Property amp As Double
        Public Property phase As Double

        Public Sub New(freq As Double, amp As Double, phase As Double)
            Me.freq = freq
            Me.amp = amp
            Me.phase = phase
        End Sub
    End Class

    Class Complex_1
        Friend re As Double
        Friend im As Double

        Public Sub New(a As Double, b As Double)
            Me.re = a
            Me.im = b
        End Sub

        Public Sub add(c As Complex_1)
            Me.re += c.re
            Me.im += c.im
        End Sub

        Public Function mult(c As Complex_1) As Complex_1
            Dim re As Double = Me.re * c.re - Me.im * c.im
            Dim im As Double = Me.re * c.im + Me.im * c.re
            Return New Complex_1(re, im)
        End Function

        Public ReadOnly Property Abs As Double
            Get
                Return Math.Sqrt(Me.re ^ 2 + Me.im ^ 2)
            End Get
        End Property

        Public Function Magnitude() As Double
            Return Math.Sqrt(re * re + im * im)
        End Function

        Public Function Phase() As Double
            Return Math.Atan2(im, re)
        End Function

        Public Shared ReadOnly Property ImaginaryOne As Complex_1
            Get
                Return New Complex_1(0, 1)
            End Get
        End Property

        Public Shared Function Exp(value As Complex_1) As Complex_1
            Dim magnitude As Double = Math.Exp(value.re)
            Return New Complex_1(magnitude * Math.Cos(value.im), magnitude * Math.Sin(value.im))
        End Function

        ' Devuelve el ángulo del número complejo.
        Public Function Angle() As Double
            ' Calcula el ángulo del número complejo.
            If re = 0 Then
                If im = 0 Then
                    Return 0
                ElseIf im > 0 Then
                    Return Math.PI / 2
                Else
                    Return Math.PI * 3 / 2
                End If
            Else
                Dim angle_ As Double = Math.Atan2(im, re)
                If angle_ < 0 Then
                    angle_ += 2 * Math.PI
                End If
                Return angle_
            End If
        End Function

        ' Devuelve el número complejo elevado a la potencia especificada.
        Public Function Pow(exponent As Double) As Complex_1
            ' Calcula el número complejo elevado a la potencia especificada.
            Dim magnitude As Double = Math.Pow(Abs(), exponent)
            Dim angle_ As Double = Angle() * exponent
            Dim result As New Complex_1(magnitude * Math.Cos(angle_), magnitude * Math.Sin(angle_))
            Return result
        End Function

        ' Devuelve el conjugado del número complejo.
        Public Function Conjugate() As Complex_1
            ' Construye y devuelve el conjugado del número complejo.
            Dim conjugate_ As New Complex_1(re, -im)
            Return conjugate_
        End Function

        Public Shared Operator +(ByVal c1 As Complex_1, ByVal c2 As Complex_1) As Complex_1
            Return New Complex_1(c1.re + c2.re, c1.im + c2.im)
        End Operator

        Public Shared Operator -(ByVal c1 As Complex_1, ByVal c2 As Complex_1) As Complex_1
            Return New Complex_1(c1.re - c2.re, c1.im - c2.im)
        End Operator

        Public Shared Operator *(ByVal c1 As Complex_1, ByVal c2 As Complex_1) As Complex_1
            Return New Complex_1(c1.re * c2.re - c1.im * c2.im, c1.re * c2.im + c1.im * c2.re)
        End Operator

        Public Shared Operator /(ByVal c1 As Complex_1, ByVal c2 As Complex_1) As Complex_1
            Dim d As Double = c2.re * c2.re + c2.im * c2.im
            Return New Complex_1((c1.re * c2.re + c1.im * c2.im) / d, (c1.im * c2.re - c1.re * c2.im) / d)
        End Operator

        Public Overrides Function ToString() As String
            Return String.Format("({0}, {1})", Me.re, Me.im)
        End Function
    End Class

    Class Complex_3

        Friend MeComplex_0 As Complex_0
        Friend MeComplex_1 As Complex_1

        Public Sub New(a As Double, b As Double, freq As Double, amp As Double, phase As Double)

            MeComplex_0 = New Complex_0(freq, amp, phase)
            MeComplex_1 = New Complex_1(a, b)

        End Sub

    End Class

    Friend Sub sort(lista() As Complex_3, p As Func(Of Object, Object, Object))
        'fourierX.sort((a,b)=>b.amp-a.amp);
        'Array.Sort(fourierX,Function(a,b) b.amp.CompareTo(a.amp))
        'For Each Item As Complex_3 In lista
        'Next
        Return
    End Sub

    Public Class Vector

        Public Property x As Double
        Public Property y As Double

        Public Sub New(x As Double, y As Double)
            Me.x = x
            Me.y = y
        End Sub

    End Class

End Class