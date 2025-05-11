Public Class Class_FourierGeneral



    ''' <summary>
    ''' La función Serie Fourier
    ''' </summary>
    ''' <param name="f">arreglo de valores que representan la función periódica</param>
    ''' <param name="T_">el período de la función</param>
    ''' <param name="tiempo">el tiempo en el que se desea evaluar la función</param>
    ''' <returns></returns>
    Friend Function SerieFourier(ByRef f() As Double, ByVal T_ As Double, ByVal tiempo As Double) As Double
        Dim a0 As Double = 0
        Dim an As Double = 0
        Dim bn As Double = 0
        Dim w As Double = 2 * Math.PI / T_

        For i As Integer = 0 To f.Length - 1
            a0 += f(i)
            For n As Integer = 1 To f.Length - 1
                an += f(i) * Math.Cos(w * n * tiempo)
                bn += f(i) * Math.Sin(w * n * tiempo)
            Next
        Next

        a0 /= f.Length
        an *= 2 / f.Length
        bn *= 2 / f.Length

        Return a0 + an + bn
    End Function


    ''' <summary>
    ''' calcula los coeficientes de Fourier para una función periódica
    ''' </summary>
    ''' <param name="f_">un arreglo de valores que representan la función periódica</param>
    ''' <param name="T_">el período de la función</param>
    ''' <param name="N_">el número de coeficientes de Fourier que se desean calcular</param>
    ''' <returns></returns>
    Private Function CoeficientesFourier(ByRef f_() As Double, ByVal T_ As Double, ByVal N_ As Integer) As Double()
        Dim a(N_) As Double
        Dim b(N_) As Double
        Dim w As Double = 2 * Math.PI / T_
        Dim dt As Double = T_ / f_.Length

        For n As Integer = 0 To N_
            For i As Integer = 0 To f_.Length - 1
                a(n) += f_(i) * Math.Cos(w * n * i * dt)
                b(n) += f_(i) * Math.Sin(w * n * i * dt)
            Next
            a(n) *= 2 / T_
            b(n) *= 2 / T_
        Next

        Return Concatenar(a, b)
    End Function

    ''' <summary>
    ''' simplemente concatena dos arreglos en uno solo
    ''' </summary>
    ''' <param name="a">son los coeficientes de Fourier</param>
    ''' <param name="b">son los coeficientes de Fourier</param>
    ''' <returns></returns>
    Private Function Concatenar(ByVal a() As Double, ByVal b() As Double) As Double()
        Dim c(a.Length + b.Length - 1) As Double
        Array.Copy(a, c, a.Length)
        Array.Copy(b, 0, c, a.Length, b.Length)
        Return c
    End Function

    Private Function FFT(ByRef x_() As Double) As Complex_FG1()
        'Dim N As Integer = x_.Length
        'Dim X(N - 1) As Complex_FG1

        'If N = 1 Then
        '    X(0) = x_(0)
        'Else
        '    Dim xe(N / 2 - 1) As Double
        '    Dim xo(N / 2 - 1) As Double

        '    For i As Integer = 0 To N - 1 Step 2
        '        xe(i / 2) = x_(i)
        '        xo(i / 2) = x_(i + 1)
        '    Next

        '    Dim Fe() As Complex_FG1 = FFT(xe)
        '    Dim Fo() As Complex_FG1 = FFT(xo)

        '    For k As Integer = 0 To N / 2 - 1
        '        Dim t As Complex_FG1 = Fe(k) * Complex_FG1.Exp(-2 * Math.PI * Complex_FG1.ImaginaryOne * k / N)
        '        X(k) = Fe(k) + t
        '        X(k + N / 2) = Fo(k) - t
        '    Next
        'End If

        'Return X
    End Function

    Friend Structure Complex_FG1
        'Sub New(ByVal X_0 As Double, ByVal Y_0 As Double)

        'End Sub
        Friend X_Imaginary As Double
        Friend Y_Real As Double
        'Friend Sub New()
        '    Me.Y_Real = 0
        '    Me.X_Imaginary = 0

        'End Sub
        Public Sub New(ByVal real As Double, ByVal imaginary As Double)
            Y_Real = real
            X_Imaginary = imaginary
        End Sub

        Public Property Real() As Double
            Get
                Return Y_Real
            End Get
            Set(ByVal value As Double)
                Y_Real = value
            End Set
        End Property

        Public Property Imaginary() As Double
            Get
                Return X_Imaginary
            End Get
            Set(ByVal value As Double)
                X_Imaginary = value
            End Set
        End Property

        'Friend Shared Function ImaginaryOne() As ComplexNumber
        '    'Throw New NotImplementedException()
        'End Function

        'Friend Shared Function Abs(p As Object) As Double
        '    'Throw New NotImplementedException()
        'End Function
        Public ReadOnly Property Abs As Double
            Get
                Return Math.Sqrt(Me.Real ^ 2 + Me.Imaginary ^ 2)
            End Get
        End Property

        Public Function Magnitude() As Double
            Return Math.Sqrt(Y_Real * Y_Real + X_Imaginary * X_Imaginary)
        End Function

        Public Function Phase() As Double
            Return Math.Atan2(X_Imaginary, Y_Real)
        End Function

        Public Shared ReadOnly Property ImaginaryOne As Complex_FG1
            Get
                Return New Complex_FG1(0, 1)
            End Get
        End Property

        Public Shared Function Exp(value As Complex_FG1) As Complex_FG1
            Dim magnitude As Double = Math.Exp(value.Real)
            Return New Complex_FG1(magnitude * Math.Cos(value.X_Imaginary), magnitude * Math.Sin(value.X_Imaginary))
        End Function


#Region "Bart"

        'Public Shared Function fourierSeriesAM(fourier As Complex_3(), t As Double, terms As Integer) As Vector
        '    Dim c As Complex_3() = fourier
        '    Dim sumX As Double = 0
        '    Dim sumY As Double = 0
        '    Dim k As Integer = 0
        '    While k < terms
        '        Dim f As Double = c(k).MeComplex_0.freq
        '        Dim r As Double = c(k).MeComplex_1.re
        '        Dim i As Double = c(k).MeComplex_1.im
        '        Dim carrier As Complex_1 = New Complex_1(Math.Cos(f * t), Math.Sin(f * t))
        '        Dim modulatedSignal As Complex_1 = carrier * New Complex_1(amplitude, 0)
        '        sumX += Math.Cos(f * t) * r * modulatedSignal.re - Math.Sin(f * t) * i * modulatedSignal.re
        '        sumY += Math.Cos(f * t) * i * modulatedSignal.re + Math.Sin(f * t) * r * modulatedSignal.re
        '        k += 1
        '    End While
        '    Return New Vector(sumX, sumY)
        'End Function

        'Public Shared Function fourierSeriesFM(fourier As Complex_3(), t As Double, terms As Integer) As Vector
        '    Dim c As Complex_3() = fourier
        '    Dim sumX As Double = 0
        '    Dim sumY As Double = 0
        '    Dim k As Integer = 0
        '    While k < terms
        '        Dim f As Double = c(k).MeComplex_0.freq
        '        Dim r As Double = c(k).MeComplex_1.re
        '        Dim i As Double = c(k).MeComplex_1.im
        '        Dim carrier As Complex_1 = New Complex_1(Math.Cos(f * t), Math.Sin(f * t))
        '        Dim modulatedSignal As Complex_1 = carrier * New Complex_1(1.0, amplitude)
        '        sumX += Math.Cos(f * t) * r - Math.Sin(f * t) * i
        '        sumY += Math.Cos(f * t) * i + Math.Sin(f * t) * r
        '        k += 1
        '    End While
        '    Return New Vector(sumX, sumY)
        'End Function

#End Region








        Public Shared Operator +(ByVal c1 As Complex_FG1, ByVal c2 As Complex_FG1) As Complex_FG1
            Return New Complex_FG1(c1.Y_Real + c2.Y_Real, c1.X_Imaginary + c2.X_Imaginary)
        End Operator

        Public Shared Operator -(ByVal c1 As Complex_FG1, ByVal c2 As Complex_FG1) As Complex_FG1
            Return New Complex_FG1(c1.Y_Real - c2.Y_Real, c1.X_Imaginary - c2.X_Imaginary)
        End Operator

        Public Shared Operator *(ByVal c1 As Complex_FG1, ByVal c2 As Complex_FG1) As Complex_FG1
            Return New Complex_FG1(c1.Y_Real * c2.Y_Real - c1.X_Imaginary * c2.X_Imaginary, c1.Y_Real * c2.X_Imaginary + c1.X_Imaginary * c2.Y_Real)
        End Operator

        Public Shared Operator /(ByVal c1 As Complex_FG1, ByVal c2 As Complex_FG1) As Complex_FG1
            Dim d As Double = c2.Y_Real * c2.Y_Real + c2.X_Imaginary * c2.X_Imaginary
            Return New Complex_FG1((c1.Y_Real * c2.Y_Real + c1.X_Imaginary * c2.X_Imaginary) / d, (c1.X_Imaginary * c2.Y_Real - c1.Y_Real * c2.X_Imaginary) / d)
        End Operator

        Public Overrides Function ToString() As String
            Return String.Format("({0}, {1})", Me.Y_Real, Me.X_Imaginary)
        End Function

        Public Shared Function ToInt16(value As Complex_FG1) As Int16
            Dim sum As Double = value.X_Imaginary * value.X_Imaginary + value.Y_Real * value.Y_Real
            Return Convert.ToInt16(Math.Sqrt(sum))
        End Function

    End Structure

End Class
