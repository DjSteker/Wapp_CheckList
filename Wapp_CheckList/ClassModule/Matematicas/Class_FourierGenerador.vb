Public Class Class_FourierGenerador

    ''' <summary>
    ''' Generar señal senoidal
    ''' </summary>
    ''' <param name="Frecuencia">Frecuencia señal</param>
    ''' <param name="Duracion">Duración señal</param>
    ''' <param name="NumeroMuestrasSeg">Número de muestras por segundo</param>
    ''' <param name="Escala"></param>
    ''' <returns></returns>
    Friend Function GenerarSenal_1(Frecuencia As Double, Duracion As Double, NumeroMuestrasSeg As Integer, Escala As Double) As Double()
        ' Calcular el período de la señal
        Dim Tiempo As Double = 1 / Frecuencia

        Dim NumeroMuestras As UInteger = NumeroMuestrasSeg * Duracion
        ' Calcular el vector de tiempo
        Dim t(NumeroMuestras - 1) As Double
        For i As Integer = 0 To NumeroMuestras - 1
            t(i) = i * Duracion / NumeroMuestras
        Next

        ' Calcular la función f(t)
        Dim f(NumeroMuestras - 1) As Double
        For i As Integer = 0 To NumeroMuestras - 1
            f(i) = Math.Sin(2 * Math.PI * Frecuencia * t(i)) * Escala
        Next

        ' Devolver la matriz de Double()
        Return f
    End Function

    Friend Function GenerarSenal_2(Frecuencia As Double, Duracion As Double, NumeroMuestrasSeg As Integer, Escala As Double) As Double()
        Dim Tiempo As Double = 1 / Frecuencia ' Periodo de la señal
        Dim f As Double = 1 / Tiempo ' Frecuencia de la señal
        Dim N_samplers As UInteger = Duracion * NumeroMuestrasSeg ' Número de muestras por segundo
        Dim t(N_samplers - 1) As Double ' Vector de tiempo
        Dim f_(N_samplers - 1) As Double ' Función sinusoidal
        Try
            For i As Integer = 0 To N_samplers - 1
                t(i) = (i * Tiempo) / N_samplers ' Vector de tiempo
                f_(i) = Math.Sin(2 * Math.PI * f * t(i)) ' Función sinusoidal
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim Nter As Integer = 50 ' Número de términos en la serie
        Dim a0 As Double = 0.6472 ' Coeficiente DC
        Dim an(Nter - 1) As Double ' Coeficientes de coseno
        Dim bn(Nter - 1) As Double ' Coeficientes de seno
        Try
            ' Calcular los coeficientes de Fourier
            For n_ As Integer = 0 To Nter - 1
                For i As Integer = 0 To N_samplers - 1
                    Try
                        an(n_) += 2 / Tiempo * f_(i) * Math.Cos(N_samplers * 2 * Math.PI * f * t(i))
                        bn(n_) += 2 / Tiempo * f_(i) * Math.Sin(N_samplers * 2 * Math.PI * f * t(i))
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Next
                Try
                    an(n_) /= N_samplers
                    bn(n_) /= N_samplers
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim f_fourier(N_samplers - 1) As Double ' Vector de la señal generada
        Try
            ' Generar la señal utilizando la serie de Fourier
            For i As Integer = 0 To N_samplers - 1
                f_fourier(i) = a0 / 2
                For n_ As Integer = 0 To Nter - 1
                    f_fourier(i) += an(n_) * Math.Cos(n_ * 2 * Math.PI * f * t(i)) + bn(n_) * Math.Sin(n_ * 2 * Math.PI * f * t(i))
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim NumerosAleatoriosFiltro(f_fourier.Length - 1) As Double
        For indice As UInteger = 0 To f_fourier.Length - 1
            NumerosAleatoriosFiltro(indice) = f_fourier(indice) * Escala
        Next
        Return NumerosAleatoriosFiltro
    End Function


    Function GenerarSenalFourier(Frecuencia As Double, Duracion As Double, NumeroMuestrasSeg As Integer, Escala As Double) As Double()
        '' Calcular los coeficientes de Fourier
        'Dim an(Nter - 1) As Double ' Coeficientes de coseno
        'Dim bn(Nter - 1) As Double ' Coeficientes de seno
        'For n As Integer = 0 To Nter - 1
        '    For i As Integer = 0 To n - 1
        '        an(n) += 2 / T * f_(i) * Math.Cos(n * 2 * Math.PI * f * T(i))
        '        bn(n) += 2 / T * f_(i) * Math.Sin(n * 2 * Math.PI * f * T(i))
        '    Next
        '    an(n) /= n
        '    bn(n) /= n
        'Next

        '' Generar la señal utilizando la serie de Fourier
        'Dim f_fourier(N - 1) As Double ' Vector de la señal generada
        'For i As Integer = 0 To N - 1
        '    f_fourier(i) = a0 / 2
        '    For n As Integer = 0 To Nter - 1
        '        f_fourier(i) += an(n) * Math.Cos(n * 2 * Math.PI * f * T(i)) + bn(n) * Math.Sin(n * 2 * Math.PI * f * T(i))
        '    Next
        'Next

        ' Devolver la matriz de Double()
        'Return f_fourier
    End Function










End Class
