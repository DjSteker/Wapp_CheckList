
Public Class Class_IIR

    Friend Function Filtro_IIR(signal() As Double) As Double()
        Dim filteredSignal(signal.Length - 1) As Double
        ' Generar los coeficientes del filtro
        Dim a() As Double = {1, -2.2071067811865479, 1}
        Dim b() As Double = {1}

        ' Inicializar las variables
        Dim x() As Double = {0, 0, 0}
        Dim y() As Double = {0, 0, 0}

        ' Procesar la señal
        For i As Integer = 0 To signal.Length - 1
            x(0) = signal(i)
            y(0) = (b(0) * x(0) + b(1) * x(1) + b(2) * x(2) - a(1) * y(1) - a(2) * y(2)) / a(0)
            x(2) = x(1)
            x(1) = x(0)
            y(2) = y(1)
            y(1) = y(0)
            filteredSignal(i) = y(0)
        Next
        Return filteredSignal
    End Function

    Friend Shared Function Filtro_IIR_Short(signal As List(Of Short)) As List(Of Short)
        'Dim filteredSignal(signal.Count - 1) As Short
        Dim filteredSignal As List(Of Short) = New List(Of Short)
        ' Generar los coeficientes del filtro
        'Dim a() As Double = {1, -2.2071067811865479, 1}
        'Dim b() As Double = {1, 0, 0}
        Dim a() As Double = {1.0, -0.8, 0.6}
        Dim b() As Double = {0.8, 0.0, 0.2}
        ' Inicializar las variables
        Dim x() As Double = {1, 1, 1}
        Dim y() As Double = {1, 1, 1}
        'Dim x() As Double = {0, 0, 0}
        'Dim y() As Double = {0, 0, 0}
        ' Procesar la señal
        For i As Integer = 0 To signal.Count - 1
            Try
                x(0) = signal.Item(i)
                Dim Resultado As Double = ((b(0) * x(0) + b(1) * x(1) + b(2) * x(2) - a(1) * y(1) - a(2) * y(2)) / a(0))
                If Resultado > Int16.MaxValue Then
                    Resultado = Int16.MaxValue
                ElseIf Resultado < Int16.MinValue Then
                    Resultado = Int16.MinValue
                End If
                y(0) = Resultado 'System.Convert.ToInt16((b(0) * x(0) + b(1) * x(1) + b(2) * x(2) - a(1) * y(1) - a(2) * y(2)) / a(0))
                x(2) = x(1)
                x(1) = x(0)
                y(2) = y(1)
                y(1) = y(0)
                'filteredSignal(i) = y(0)
                filteredSignal.Add(y(0))
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Next
        Return filteredSignal
    End Function



    Private a_ As Double() = New Double() {1.0, -0.8, 0.6}
    Private b_ As Double() = New Double() {0.8, 0.0, 0.2}

    Public Function Filter(sample As Double) As Double
        Dim y As Double = 0
        For i = 2 To 0 Step -1
            y = sample * b_(i) + y * a_(i)
        Next
        Return y
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="order"> indica el orden del filtro. El orden de un filtro IIR es el número de coeficientes que tiene el filtro. Un filtro de orden 1 tiene un coeficiente, un filtro de orden 2 tiene dos coeficientes, y así sucesivamente</param>
    ''' <param name="dampingFactor">indica el factor de amortiguamiento del filtro. El factor de amortiguamiento determina la respuesta al impulso del filtro. Un factor de amortiguamiento de 1 produce una respuesta al impulso sin amortiguamiento, mientras que un factor de amortiguamiento de 0 produce una respuesta al impulso totalmente amortiguada</param>
    ''' <returns>Los coeficientes a y b se utilizan para describir el comportamiento del filtro. Los coeficientes a determinan la respuesta del filtro a las frecuencias altas, mientras que los coeficientes b determinan la respuesta del filtro a las frecuencias bajas.</returns>
    Function CalculateCoefficients(ByVal order As Integer, ByVal dampingFactor As Double) As Double()()
        Dim a() As Double = New Double(order) {}
        Dim b() As Double = New Double(order) {}
        For i As Integer = 0 To order
            a(i) = (1 - Math.Pow(-1, i)) / (1 - dampingFactor * Math.Pow(-1, i))
        Next
        For i As Integer = 0 To order - 1
            Try
                b(i) = a(i) * a(i - 1)
            Catch ex As Exception

            End Try

        Next
        Return {a, b}
    End Function

    ''' <summary>
    ''' 
    ''' filtro IIR (Infinite Impulse Response) es un tipo de filtro digital que tiene una respuesta al impulso infinita. Esto significa que la salida de un filtro IIR depende no solo de la entrada actual, sino también de las entradas anteriores. Los filtros IIR se caracterizan por tener una estructura de retroalimentación, lo que significa que la señal de salida se retroalimenta a la entrada
    ''' </summary>
    ''' <param name="signal"></param>
    ''' <param name="a">Los coeficientes del filtro (a y b) deben ser determinados por el diseño del filtro, que depende de la frecuencia de corte deseada y la tasa de muestreo</param>
    ''' <param name="b">se diseña un filtro Butterworth de paso bajo de orden 6 con una frecuencia de corte de 300 Hz para datos muestreados a 1000 Hz. La frecuencia de corte se normaliza dividiéndola por la mitad de la tasa de muestreo (la tasa de Nyquist), por lo que la frecuencia de corte normalizada es 300/500 = 0.6</param>
    ''' <returns></returns>
    Friend Function Filtro_IIR(signal() As Double, a As Double, b As Double) As Double()
        'se diseña un filtro Butterworth de paso bajo de orden 6 con una frecuencia de corte de 300 Hz para datos muestreados a 1000 Hz. La frecuencia de corte se normaliza dividiéndola por la mitad de la tasa de muestreo (la tasa de Nyquist), por lo que la frecuencia de corte normalizada es 300/500 = 0.6
        'butter(6,0.6,'low');
        Dim output(signal.Length - 1) As Double
        output(0) = b * signal(0)

        For i As Integer = 1 To signal.Length - 1
            output(i) = b * signal(i) - a * output(i - 1)
        Next

        Return output
    End Function


#Region "Bueno"
    Public Function CalcularCoeficientes(Coef As Double, RateSample As Double) As Tuple(Of Double, Double)
        Dim wc As Double = 2 * Math.PI * Coef / RateSample ' Frecuencia de corte normalizada
        Dim Q As Double = 1 / Math.Sqrt(2) ' Factor de calidad para un filtro Butterworth
        Dim K As Double = Math.Tan(wc / 2) ' Constante de pre-guerra

        ' Coeficientes del filtro
        Dim a As Double = (K ^ 2) / (1 + K / Q + K ^ 2)
        Dim b As Double = 2 * (K ^ 2 - 1) / (1 + K / Q + K ^ 2)

        Return New Tuple(Of Double, Double)(a, b)
    End Function
#End Region
End Class
