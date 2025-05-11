Public Class Class_Fourier


    Private frequencyLim() As Single = {100, 200, 360, 740, 920, 1200, 1600, 2200, 3600, 4800, 6200, 8800, 12000, 14000, 16000, 18000, 20000, 22000, 32000, 44100, 88200}
    Private NUMBER_OF_BARS As Integer = 40
    Private frequencyLim_IA() As Single = {100, 200, 360, 740, 920, 1200, 1600, 2200, 3600, 4800, 6200, 8800, 12000, 14000, 16000, 18000, 20000, 22000, 32000, 44100, 88200}

    Public Sub New(ByVal NumBars As Integer)
        NUMBER_OF_BARS = NumBars
        Try
            Dim minimo As Int16 = 100
            Dim maximo As Int64 = 44100 '44100 '88200
            Dim stepSize As Double = (maximo - minimo) / NUMBER_OF_BARS
            Dim LosgaritmoCoe As Double = Math.Log(minimo)
            Dim LosgaritmoDividor As Double = -10 * (Math.Log(100) - Math.Log(maximo))


            frequencyLim_IA = New Single(NUMBER_OF_BARS - 1) {}
            For indiceF As Int16 = 0 To NUMBER_OF_BARS - 1
                Try
                    'Dim a As Double = (Math.Log(indiceF + minimo + (maximo * indiceF)))
                    Dim x As Double = minimo + indiceF * stepSize
                    Dim b As Double = Math.Log(x)
                    Dim z As Double = (x - Math.Log(x)) / LosgaritmoDividor
                    LosgaritmoCoe = Math.Log(minimo * (1 + indiceF))
                    Dim x2 As Double = Math.Exp(stepSize * (indiceF + 1))
                    frequencyLim_IA(indiceF) = (x + b + (z)) '((x + b + (z)) * 2 + frequencyLim0(indiceF)) / 3 ' ((255 - 1) / NUMBER_OF_BARS) / (Math.Exp((indiceF + 1)) - Math.Exp((255)))

                Catch ex As Exception

                End Try

            Next
        Catch ex As Exception

        End Try
        InicializarTransformada()
    End Sub

    Friend Sub InicializarTransformada()
        Try
            Dim minimo As Int16 = 100
            Dim maximo As Int64 = 44100 '44100 '88200
            Dim stepSize As Double = (maximo - minimo) / NUMBER_OF_BARS
            Dim LosgaritmoCoe As Double = Math.Log(minimo)
            Dim LosgaritmoDividor As Double = -10 * (Math.Log(100) - Math.Log(maximo))


            frequencyLim = New Single(NUMBER_OF_BARS - 1) {}
            For indiceF As Int16 = 0 To NUMBER_OF_BARS - 1
                Try
                    'Dim a As Double = (Math.Log(indiceF + minimo + (maximo * indiceF)))

                    Dim x As Double = minimo + indiceF * stepSize
                    Dim b As Double = Math.Log(x)
                    Dim z As Double = (x - Math.Log(x)) / LosgaritmoDividor
                    LosgaritmoCoe = Math.Log(minimo * (1 + indiceF))
                    Dim x2 As Double = Math.Exp(stepSize * (indiceF + 1))
                    frequencyLim(indiceF) = (x + b + (z)) '((x + b + (z)) * 2 + frequencyLim0(indiceF)) / 3 ' ((255 - 1) / NUMBER_OF_BARS) / (Math.Exp((indiceF + 1)) - Math.Exp((255)))

                Catch ex As Exception

                End Try

            Next
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' obtener en fominio de la frecuencia
    ''' </summary>
    ''' <param name="buffer">Valores de la señal de entrada</param>
    ''' <param name="Barras">divisiones para la devolucion de la frecuencia de salida</param>
    ''' <returns>magnitudes del dominio de la frecuencia en divisiones de frequencyLim()</returns>
    Friend Function ObtenerTransformada(ByRef buffer() As Double, ByVal Barras As Integer) As Double()
        Dim dft_real(buffer.Length - 1) As Double
        Dim dft_imag(buffer.Length - 1) As Double
        Dim result() As Double = New Double(Barras - 1) {}


        For k As Integer = 0 To buffer.Length - 1
            For n As Integer = 0 To buffer.Length - 1
                dft_real(k) += buffer(n) * Math.Cos(2 * Math.PI * k * n / buffer.Length)
                dft_imag(k) -= buffer(n) * Math.Sin(2 * Math.PI * k * n / buffer.Length)
            Next
            dft_real(k) /= buffer.Length
            dft_imag(k) /= buffer.Length
        Next

        ' Encontrar la frecuencia dominante
        Dim max_magnitude As Double = 0.0
        Dim dominant_frequency As Double = 0.0

        For k As Integer = 0 To buffer.Length / 2 - 1 ' Solo necesitamos considerar la mitad del espectro debido a la simetría conjugada compleja







            Dim frequency1 As Double = (k / buffer.Length) * 88200 '44100 '(1 / (k / buffer.Length)) * 4420000
            Dim magnitude1 As Double = Math.Sqrt(dft_real(k) ^ 2 + dft_imag(k) ^ 2)

            If magnitude1 > max_magnitude Then
                max_magnitude = magnitude1
                dominant_frequency = frequency1
            End If

            'frequency = New Integer() {3, 6, 9, 12, 15, 30, 38, 41, 43, 46, 50, 55, 60, 85, 95, 110, 150, 200, 240, 255}

            Dim encontro As Boolean = False
            For indiceCol As Int16 = 0 To Barras - 1
                'If (radioReal1) < frequency(indiceCol) Then
                'If 44100 < frequency1 Then
                '    Dim a = 0
                'End If

                Dim ss = frequencyLim(indiceCol)
                If (frequency1) < frequencyLim(indiceCol) Then

                    result(indiceCol) += magnitude1
                    encontro = True
                    Exit For
                End If
            Next
            If encontro = False Then

                If frequencyLim(frequencyLim.Length - 1) < frequency1 Then
                    result(frequencyLim.Length - 1) += magnitude1
                Else
                    Dim a = 0
                End If

            End If



        Next


        Return result
    End Function

    Friend Function ObtenerTransformadaLimite1(ByRef buffer() As Double, ByVal Barras As Integer) As Double()
        Dim dft_real(buffer.Length - 1) As Double
        Dim dft_imag(buffer.Length - 1) As Double
        Dim result() As Double = New Double(Barras - 1) {}


        For k As Integer = 0 To buffer.Length - 1
            For n As Integer = 0 To buffer.Length - 1
                dft_real(k) += buffer(n) * Math.Cos(2 * Math.PI * k * n / buffer.Length)
                dft_imag(k) -= buffer(n) * Math.Sin(2 * Math.PI * k * n / buffer.Length)
            Next
            dft_real(k) /= buffer.Length
            dft_imag(k) /= buffer.Length
        Next

        ' Encontrar la frecuencia dominante
        Dim max_magnitude As Double = 0.0
        Dim dominant_frequency As Double = 0.0
        Dim Escala As Double = 1 + (1 / (buffer.Length / 256))
        For k As Integer = 0 To buffer.Length / 2 - 1 ' Solo necesitamos considerar la mitad del espectro debido a la simetría conjugada compleja







            Dim frequency1 As Double = (k / buffer.Length) * 88200 '44100 '(1 / (k / buffer.Length)) * 4420000
            Dim magnitude1 As Double = Math.Sqrt(dft_real(k) ^ 2 + dft_imag(k) ^ 2)

            If magnitude1 > max_magnitude Then
                max_magnitude = magnitude1
                dominant_frequency = frequency1
            End If

            'frequency = New Integer() {3, 6, 9, 12, 15, 30, 38, 41, 43, 46, 50, 55, 60, 85, 95, 110, 150, 200, 240, 255}

            Dim encontro As Boolean = False
            For indiceCol As Int16 = 0 To Barras - 1
                'If (radioReal1) < frequency(indiceCol) Then
                'If 44100 < frequency1 Then
                '    Dim a = 0
                'End If

                Dim ss = frequencyLim(indiceCol)
                If (frequency1) < frequencyLim(indiceCol) Then

                    result(indiceCol) += magnitude1 * Escala
                    encontro = True
                    Exit For
                End If
            Next
            If encontro = False Then

                If frequencyLim(frequencyLim.Length - 1) < frequency1 Then
                    result(frequencyLim.Length - 1) += magnitude1
                    If result(frequencyLim.Length - 1) > 1 Then
                        result(frequencyLim.Length - 1) = 1
                    End If
                Else
                    Dim a = 0
                End If

            End If



        Next


        Return result
    End Function

    Friend Function ObtenerTransformadaSingle(ByRef buffer() As Single, ByVal Barras As Integer) As Single()
        Dim dft_real() As Single = New Single(buffer.Length - 1) {}
        Dim dft_imag() As Single = New Single(buffer.Length - 1) {}
        Dim result() As Single = New Single(Barras - 1) {}
        Dim max_magnitude As Single = 0.0
        Dim dominant_frequency As Single = 0.0

        Try



            For k As Integer = 0 To buffer.Length - 1
                For n As Integer = 0 To buffer.Length - 1
                    dft_real(k) += buffer(n) * Math.Cos(2 * Math.PI * k * n / buffer.Length)
                    dft_imag(k) -= buffer(n) * Math.Sin(2 * Math.PI * k * n / buffer.Length)
                Next
                dft_real(k) /= buffer.Length
                dft_imag(k) /= buffer.Length
            Next

            ' Encontrar la frecuencia dominante


            For k As Integer = 0 To buffer.Length / 2 - 1 ' Solo necesitamos considerar la mitad del espectro debido a la simetría conjugada compleja







                Dim frequency1 As Single = (k / buffer.Length) * 88200 '44100 '(1 / (k / buffer.Length)) * 4420000
                Dim magnitude1 As Single = Math.Sqrt(dft_real(k) ^ 2 + dft_imag(k) ^ 2)

                If magnitude1 > max_magnitude Then
                    max_magnitude = magnitude1
                    dominant_frequency = frequency1
                End If

                'frequency = New Integer() {3, 6, 9, 12, 15, 30, 38, 41, 43, 46, 50, 55, 60, 85, 95, 110, 150, 200, 240, 255}

                Dim encontro As Boolean = False
                For indiceCol As Int16 = 0 To Barras - 1
                    'If (radioReal1) < frequency(indiceCol) Then
                    'If 44100 < frequency1 Then
                    '    Dim a = 0
                    'End If
                    Try
                        Dim ss = frequencyLim_IA(indiceCol)
                        If (frequency1) < frequencyLim_IA(indiceCol) Then

                            result(indiceCol) += magnitude1
                            encontro = True
                            Exit For
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                Next
                If encontro = False Then

                    If frequencyLim_IA(frequencyLim_IA.Length - 1) < frequency1 Then
                        result(frequencyLim_IA.Length - 1) += magnitude1
                    Else
                        Dim a = 0
                    End If

                End If



            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



        Return result
    End Function

#Region "bart"

    Public Function GenerateFrequencies(samples As Integer) As Double()
        Dim frequencies() As Double = New Double(samples) {}
        Dim minimum As Double = 100.0
        Dim maximum As Double = 88200.0
        Dim stepSize As Double = (maximum - minimum) / (samples - 1)
        Dim exponentialDivisor As Double = Math.Exp(-10 * (Math.Log10(100) - Math.Log10(maximum)))

        For i As Integer = 0 To samples - 1
            frequencies(i) = Math.Exp(minimum * (i + 1)) / exponentialDivisor
        Next
        Return frequencies
    End Function
    Public Function ObtenerTransformada1(ByRef buffer() As Double, ByVal Barras As Integer) As Double()
        Dim dft_real(buffer.Length - 1) As Double
        Dim dft_imag(buffer.Length - 1) As Double
        Dim result() As Double = New Double(Barras - 1) {}

        For k As Integer = 0 To buffer.Length - 1
            For n As Integer = 0 To buffer.Length - 1
                dft_real(k) += buffer(n) * Math.Cos(2 * Math.PI * k * n / buffer.Length)
                dft_imag(k) -= buffer(n) * Math.Sin(2 * Math.PI * k * n / buffer.Length)
            Next
            dft_real(k) /= buffer.Length
            dft_imag(k) /= buffer.Length
        Next

        ' Encontrar la frecuencia dominante
        Dim max_magnitude As Double = 0.0
        Dim dominant_frequency As Double = 0.0

        For k As Integer = 0 To buffer.Length / 2 - 1
            Dim frequency1 As Double = (k / buffer.Length) * 88200 '44100 '(1 / (k / buffer.Length)) * 4420000
            Dim magnitude1 As Double = Math.Abs(dft_real(k) + dft_imag(k))

            If magnitude1 > max_magnitude Then
                max_magnitude = magnitude1
                dominant_frequency = frequency1
            End If
            Dim encontro As Boolean = False
            For indiceCol As Int16 = 0 To Barras - 1
                Dim ss = frequencyLim(indiceCol)
                If (frequency1) < frequencyLim(indiceCol) Then
                    result(indiceCol) += magnitude1
                    encontro = True
                    Exit For
                End If
            Next
            If encontro = False Then
                If frequencyLim(frequencyLim.Length - 1) < frequency1 Then
                    result(frequencyLim.Length - 1) += magnitude1
                Else
                    Dim a = 0
                End If
            End If
        Next

        Return result
    End Function
    Public Function ObtenerTransformada2(ByRef buffer() As Double, ByVal Barras As Integer) As Double()
        Dim dft_real(buffer.Length - 1) As Double
        Dim dft_imag(buffer.Length - 1) As Double
        Dim result() As Double = New Double(Barras - 1) {}

        For k As Integer = 0 To buffer.Length - 1
            For n As Integer = 0 To buffer.Length - 1
                dft_real(k) += buffer(n) * Math.Cos(2 * Math.PI * k * n / buffer.Length)
                dft_imag(k) -= buffer(n) * Math.Sin(2 * Math.PI * k * n / buffer.Length)
            Next
            dft_real(k) /= buffer.Length
            dft_imag(k) /= buffer.Length
        Next

        ' Encontrar la frecuencia dominante
        Dim max_magnitude As Double = 0.0
        Dim dominant_frequency As Double = 0.0

        For k As Integer = 0 To buffer.Length / 2 - 1
            Dim frequency1 As Double = k / buffer.Length
            Dim magnitude1 As Double = Math.Abs(dft_real(k) + dft_imag(k))

            If magnitude1 > max_magnitude Then
                max_magnitude = magnitude1
                dominant_frequency = frequency1
            End If
            Dim encontro As Boolean = False
            For indiceCol As Int16 = 0 To Barras - 1
                Dim ss = frequencyLim(indiceCol)
                If (frequency1) < ss Then
                    result(indiceCol) += magnitude1
                    encontro = True
                    Exit For
                End If
            Next
            If encontro = False Then
                If frequencyLim(frequencyLim.Length - 1) < frequency1 Then
                    result(frequencyLim.Length - 1) += magnitude1
                Else
                    Dim a = 0
                End If
            End If
        Next

        Return result
    End Function

    Public Function LaplaceTransform(f As Func(Of Double, Double), s As Double) As Double
        Dim a As Double = 0
        Dim b As Double = 1000
        Dim n As Integer = 10000
        Dim h As Double = (b - a) / n
        Dim sum As Double = 0

        For i As Integer = 0 To n - 1
            Dim t As Double = a + i * h
            sum += f(t) * Math.Exp(-s * t) * h
        Next

        Return sum
    End Function

#End Region







End Class

