Public Class Class_FourierTransformada

    Friend Lista() As Complex_3b

    Public Class Complex_3a
        Public Property m_freq As Double
        Public Property m_amp As Double
        Public Property m_phase As Double

        Public Sub New(freq As Double, amp As Double, phase As Double)
            Me.m_freq = freq
            Me.m_amp = amp
            Me.m_phase = phase
        End Sub

        Public Shared Operator +(ByVal c1 As Complex_3a, ByVal c2 As Complex_3a) As Complex_3a
            Return New Complex_3a(c1.m_freq + c2.m_freq, c1.m_amp + c2.m_amp, c1.m_phase + c2.m_phase)
        End Operator

        Public Shared Operator -(ByVal c1 As Complex_3a, ByVal c2 As Complex_3a) As Complex_3a
            Return New Complex_3a(c1.m_freq - c2.m_freq, c1.m_amp - c2.m_amp, c1.m_phase - c2.m_phase)
        End Operator

        ' Para los operadores * y /, necesitamos definir cómo se multiplican y dividen las propiedades freq, amp y phase.
        ' Aquí hay un ejemplo simplificado que puede no ser correcto dependiendo de la interpretación física de estas propiedades.
        Public Shared Operator *(ByVal c1 As Complex_3a, ByVal c2 As Complex_3a) As Complex_3a
            Return New Complex_3a(c1.m_freq * c2.m_freq, c1.m_amp * c2.m_amp, c1.m_phase * c2.m_phase)
        End Operator

        Public Shared Operator /(ByVal c1 As Complex_3a, ByVal c2 As Complex_3a) As Complex_3a
            Return New Complex_3a(c1.m_freq / c2.m_freq, c1.m_amp / c2.m_amp, c1.m_phase / c2.m_phase)
        End Operator

        Public Function mult(c As Complex_3a) As Complex_3a
            ' Implementación de la multiplicación
        End Function

        Public ReadOnly Property Abs As Double
            Get
                ' Implementación de la propiedad Abs
            End Get
        End Property

        Public Function Magnitude() As Double
            ' Implementación de la Magnitude
        End Function

        Public Function Phase1(fourier As Complex_3b, t As Double) As Double
            Return Math.Atan2(fourier.MeComplex2.im, fourier.MeComplex3.m_amp * Math.Cos(2 * Math.PI * fourier.MeComplex3.m_freq * t + fourier.MeComplex3.m_phase))
        End Function

        Public Shared ReadOnly Property ImaginaryOne As Complex_3a
            Get
                ' Implementación de la propiedad ImaginaryOne
            End Get
        End Property

        Public Shared Function Exp(value As Complex_3a) As Complex_3a
            ' Implementación de la función Exp
        End Function

        Public Function Angle() As Double
            ' Implementación de la función Angle
        End Function

        Public Function Pow(exponent As Double) As Complex_3a
            ' Implementación de la función Pow
        End Function

        Public Function Conjugate() As Complex_3a
            ' Implementación de la función Conjugate
        End Function



    End Class

    Class Complex_2a
        Friend re As Double
        Friend im As Double

        Public Sub New(a As Double, b As Double)
            Me.re = a
            Me.im = b
        End Sub

        Public Sub add(c As Complex_2a)
            Me.re += c.re
            Me.im += c.im
        End Sub

        Public Function mult(c As Complex_2a) As Complex_2a
            Dim re As Double = Me.re * c.re - Me.im * c.im
            Dim im As Double = Me.re * c.im + Me.im * c.re
            Return New Complex_2a(re, im)
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

        Public Shared ReadOnly Property ImaginaryOne As Complex_2a
            Get
                Return New Complex_2a(0, 1)
            End Get
        End Property

        Public Shared Function Exp(value As Complex_2a) As Complex_2a
            Dim magnitude As Double = Math.Exp(value.re)
            Return New Complex_2a(magnitude * Math.Cos(value.im), magnitude * Math.Sin(value.im))
        End Function

        ' Devuelve el ángulo del número complejo.
        Public Function Angle() As Double
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
        Public Function Pow(exponent As Double) As Complex_2a
            ' Calcula el número complejo elevado a la potencia especificada.
            Dim magnitude As Double = Math.Pow(Abs(), exponent)
            Dim angle_ As Double = Angle() * exponent
            Dim result As New Complex_2a(magnitude * Math.Cos(angle_), magnitude * Math.Sin(angle_))
            Return result
        End Function

        ' Devuelve el conjugado del número complejo.
        Public Function Conjugate() As Complex_2a
            ' Construye y devuelve el conjugado del número complejo.
            Dim conjugate_ As New Complex_2a(re, -im)
            Return conjugate_
        End Function

        Public Shared Operator +(ByVal c1 As Complex_2a, ByVal c2 As Complex_2a) As Complex_2a
            Return New Complex_2a(c1.re + c2.re, c1.im + c2.im)
        End Operator

        Public Shared Operator -(ByVal c1 As Complex_2a, ByVal c2 As Complex_2a) As Complex_2a
            Return New Complex_2a(c1.re - c2.re, c1.im - c2.im)
        End Operator

        Public Shared Operator *(ByVal c1 As Complex_2a, ByVal c2 As Complex_2a) As Complex_2a
            Return New Complex_2a(c1.re * c2.re - c1.im * c2.im, c1.re * c2.im + c1.im * c2.re)
        End Operator

        Public Shared Operator /(ByVal c1 As Complex_2a, ByVal c2 As Complex_2a) As Complex_2a
            Dim d As Double = c2.re * c2.re + c2.im * c2.im
            Return New Complex_2a((c1.re * c2.re + c1.im * c2.im) / d, (c1.im * c2.re - c1.re * c2.im) / d)
        End Operator

        Public Overrides Function ToString() As String
            Return String.Format("({0}, {1})", Me.re, Me.im)
        End Function
    End Class

    Class Complex_3b

        Friend MeComplex3 As Complex_3a
        Friend MeComplex2 As Complex_2a

        Public Sub New(a As Double, b As Double, freq As Double, amp As Double, phase As Double)

            MeComplex3 = New Complex_3a(freq, amp, phase)
            MeComplex2 = New Complex_2a(a, b)

        End Sub

    End Class

    Friend Sub sort(lista() As Complex_3b, p As Func(Of Object, Object, Object))
        'fourierX.sort((a,b)=>b.amp-a.amp);
        'Array.Sort(fourierX,Function(a,b) b.amp.CompareTo(a.amp))
        'For Each Item As Complex_3 In lista
        'Next
        Array.Sort(lista, Function(a, b) a.MeComplex3.m_amp.CompareTo(b.MeComplex3.m_amp))
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

    Public Shared Function dft(ByRef x_ByRef As Complex_2a()) As Complex_3b()

        Dim X As Complex_3b() = New Complex_3b(x_ByRef.Length - 1) {}
        Dim N As Integer = X.Length

        For k As Double = -(N - 1) / 2 To (N - 1) / 2
            Dim sum As New Complex_2a(0, 0)
            For l As Integer = 0 To N - 1
                Dim phi As Double = k * 2 * Math.PI * l / N
                Dim c As New Complex_2a(Math.Cos(phi), -Math.Sin(phi))
                sum.add(x_ByRef(l).mult(c))
            Next
            sum.re = sum.re / N
            sum.im = sum.im / N

            Dim freq As Double = k
            Dim amp As Double = Math.Sqrt(sum.re * sum.re + sum.im * sum.im)
            Dim phase As Double = Math.Atan2(sum.im, sum.re)
            X(k + (N - 1) / 2) = New Complex_3b(sum.re, sum.im, freq, amp, phase)
        Next

        Return X
    End Function

    Public Shared Function fourierSeries(fourier As Complex_3b(), t As Double, terms As Integer) As Vector

        Dim c As Complex_3b() = fourier
        Dim sumX As Double = 0
        Dim sumY As Double = 0
        Dim k As Integer = 0
        While k < terms
            Dim f As Double = c(k).MeComplex3.m_freq
            Dim r As Double = c(k).MeComplex2.re
            Dim i As Double = c(k).MeComplex2.im
            sumX += Math.Cos(f * t) * r - Math.Sin(f * t) * i
            sumY += Math.Cos(f * t) * i + Math.Sin(f * t) * r
            k += 1
        End While
        Return New Vector(sumX, sumY)
    End Function

    Public Shared Function fourierSeriesFase(fourier As Complex_3b(), t As Double, terms As Integer) As Vector

        Dim c As Complex_3b() = fourier
        Dim sumX As Double = 0
        Dim sumY As Double = 0
        Dim k As Integer = 0
        While k < terms
            Dim f As Double = c(k).MeComplex3.m_freq
            Dim r As Double = c(k).MeComplex2.re
            Dim i As Double = c(k).MeComplex2.im
            sumX += Math.Cos(f * t) * r - Math.Sin(f * t) * i
            sumY += Math.Cos(f * t) * i + Math.Sin(f * t) * r
            Dim phase As Double = Math.Atan2(c(k).MeComplex2.im, c(k).MeComplex3.m_amp * Math.Cos(2 * Math.PI * f * t + c(k).MeComplex3.m_phase))
            'asdfg
            k += 1
        End While
        Return New Vector(sumX, sumY)
    End Function


    Friend Shared Function epicycles(x As Double, y As Double, rotation As Double, fourier As Complex_3b(), terms As Integer, t As Double, offScreenDC As System.Drawing.Graphics) As Vector
        'Dim g As Graphics = PictureBox1.CreateGraphics() ' Me.CreateGraphics()


        For i As Integer = 0 To terms - 1
            Dim prevx As Double = x
            Dim prevy As Double = y
            Dim freq As Double = fourier(i).MeComplex3.m_freq
            Dim radius As Double = fourier(i).MeComplex3.m_amp
            Dim phase As Double = fourier(i).MeComplex3.m_phase

            x += (radius * Math.Cos(freq * t + phase + rotation))
            y += radius * Math.Sin(freq * t + phase + rotation)
            Dim Tono As Int16 = (255 * 3 * i / fourier.Length) / 3
            If Tono < 0 Then
                Tono = 0
            ElseIf Tono > 255 Then
                Tono = 255
            End If
            Using pen As New Pen(Color.FromArgb(Tono, (255), (255), 1))
                offScreenDC.DrawEllipse(pen, CSng(prevx - radius), CSng(prevy - radius), CSng(radius * 2), CSng(radius * 2))
            End Using
            Using pen As New Pen(Color.FromArgb(255, 0, 255), 1)
                offScreenDC.DrawLine(pen, CSng(prevx), CSng(prevy), CSng(x), CSng(y))
            End Using
        Next
        Return New Vector(x, y)
    End Function



#Region ""


    Public Shared Function ToInt16(value As Vector) As Int16
        Dim sum As Double = value.x * value.x + value.y * value.y
        Dim aa As Int16 = Int16.MaxValue
        Return Convert.ToInt16(Math.Sqrt(sum))
    End Function
    Friend Shared amplitude As Double = 1

    Public Shared Function fourierSeries_FM(fourier As Complex_3b(), t As Double, terms As Integer) As Vector
        Dim c As Complex_3b() = fourier
        Dim sumX As Double = 0
        Dim sumY As Double = 0
        Dim k As Integer = 0
        While k < terms
            Dim f As Double = c(k).MeComplex3.m_freq
            Dim r As Double = c(k).MeComplex2.re
            Dim i As Double = c(k).MeComplex2.im
            Dim carrier As Complex_2a = New Complex_2a(Math.Cos(f * t), Math.Sin(f * t))
            Dim modulatedSignal As Complex_2a = carrier * New Complex_2a(1.0, amplitude)
            sumX += Math.Cos(f * t) * r - Math.Sin(f * t) * i
            sumY += Math.Cos(f * t) * i + Math.Sin(f * t) * r
            k += 1
        End While
        Return New Vector(sumX, sumY)
    End Function

    Public Shared Function fourierSeries_AM(fourier As Complex_3b(), t As Double, terms As Integer) As Vector
        Dim c As Complex_3b() = fourier
        Dim sumX As Double = 0
        Dim sumY As Double = 0
        Dim k As Integer = 0
        While k < terms
            Dim f As Double = c(k).MeComplex3.m_freq
            Dim r As Double = c(k).MeComplex2.re
            Dim i As Double = c(k).MeComplex2.im
            Dim carrier As Complex_2a = New Complex_2a(Math.Cos(f * t), Math.Sin(f * t))
            Dim modulatedSignal As Complex_2a = carrier * New Complex_2a(amplitude, 0)
            sumX += Math.Cos(f * t) * r * modulatedSignal.re - Math.Sin(f * t) * i * modulatedSignal.re
            sumY += Math.Cos(f * t) * i * modulatedSignal.re + Math.Sin(f * t) * r * modulatedSignal.re
            k += 1
        End While
        Return New Vector(sumX, sumY)
    End Function



#End Region


End Class
