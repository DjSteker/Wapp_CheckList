Imports WApp_Morse

Public Class Class_ReceptorQpsk

#Region "FiltroEntrada BPF"

    'Dim Filtrado2 As Double
    'Dim Filtrado3 As Double
    Friend FactorFIR As Double = 0.99
    Friend Filtro_FIR As Class_FIR
    Private Const NUMBER_OF_BARS As Integer = 40
    Dim InstanciaTff As New Class_Fourier(NUMBER_OF_BARS)
    Dim Filtro_Kalman As Class_Kalman

    Function FiltroFIR(ByVal ValorNuevo As Double) As Double

        If Filtro_FIR.FiltroFactor = Nothing Then
            Filtro_FIR = New Class_FIR
        End If
        Filtro_FIR.FiltroFactor = FactorFIR 'Replace(TextBox_FactorFIR.Text, ".", ",")
        'Filtrado3 = Filtrado2
        'Filtrado2 = ((FactorFIR * Filtrado2) + (((Filtrado2 + Filtrado3) / 2) * (1 - FactorFIR)))
        Return Filtro_FIR.ObtenerValor(ValorNuevo)
    End Function


    Friend Qdistance As Double = 100
    Friend KalmanGanancia As Double = 10
    Function FiltroKalman(ByVal ValorNuevo As Double) As Double

        Filtro_Kalman = New Class_Kalman
        If Filtro_Kalman.Q_distance = Nothing Then
            Filtro_Kalman = New Class_Kalman
            Filtro_Kalman.Q_distance = Qdistance
            Filtro_Kalman.R_measure = KalmanGanancia
        End If

        'Filtro_Kalman.setQdistance(100) '(Replace(TextBox_Qdistance.Text, ".", ","))
        'Filtro_Kalman.setRmeasure(10) '(Replace(TextBox_KalmanGanancia.Text, ".", ","))

        Return Filtro_Kalman.getDistance(ValorNuevo, 1)
    End Function

    Function FiltroFirKalman(ByVal ValorNuevo As Double) As Double
        Return Filtro_Kalman.getDistance(Filtro_FIR.ObtenerValor(ValorNuevo), 1)
    End Function


#End Region

#Region ""

    Function LazoCostasSegundoOrden(input As Double()) As Double()
        ' Declarar las variables y constantes
        Dim fs As Double ' Frecuencia de muestreo
        Dim K As Double ' Ganancia del lazo
        Dim zeta As Double ' Coeficiente de amortiguamiento
        Dim wn As Double ' Ancho de banda natural
        Dim b As Double ' Coeficiente b del filtro
        Dim k1 As Double ' Coeficiente k1 del filtro
        Dim k2 As Double ' Coeficiente k2 del filtro
        'Dim input As Double() ' Señal de entrada
        Dim output As Double() ' Señal de salida
        Dim phase As Double ' Fase estimada
        Dim freq As Double ' Frecuencia estimada
        Dim i As Integer ' Índice del bucle

        ' Asignar valores a las variables y constantes
        fs = 1000 ' Hz
        K = 1 ' Ajustar según la señal de entrada
        zeta = 0.707 ' Valor óptimo para un lazo de segundo orden
        wn = 0.01 ' Rad/s, ajustar según el ancho de banda deseado
        b = (1 + 2 * zeta * wn + wn ^ 2) / (2 * K) ' Fórmula del texto
        k1 = (4 * zeta * wn - 2) / b ' Fórmula del texto
        k2 = (4 * wn ^ 2) / b ' Fórmula del texto
        'input = ... ' Leer la señal de entrada desde un archivo o un dispositivo
        output = New Double(input.Length - 1) {} ' Inicializar la señal de salida
        phase = 0 ' Inicializar la fase estimada
        freq = 0 ' Inicializar la frecuencia estimada

        ' Crear un objeto de la clase PLL
        Dim pll As New PLL(K, b, k1, k2)

        '' Recorrer la señal de entrada
        'For i = 0 To input.Length - 1
        '    ' Actualizar el lazo de costas con el valor actual de la entrada
        '    pll.Update(input(i))
        '    ' Obtener la fase y la frecuencia estimadas
        '    phase = pll.Phase
        '    freq = pll.Freq
        '    ' Rotar la entrada para obtener la señal en banda base
        '    output(i) = input(i) * Math.Exp(-1 * phase * Complex.ImaginaryOne)
        '    ' Corregir el desplazamiento de frecuencia
        '    output(i) = output(i) * Math.Exp(-1 * freq * i * Complex.ImaginaryOne)
        'Next


        ' Recorrer la señal de entrada
        For i = 0 To input.Length - 1
            ' Actualizar el lazo de costas con el valor actual de la entrada
            pll.Update(input(i))
            ' Obtener la fase y la frecuencia estimadas
            phase = Math.Atan2(Math.Sin(pll.Phase), Math.Cos(pll.Phase))
            freq = pll.Freq
            ' Rotar la entrada para obtener la señal en banda base
            output(i) = input(i) * Math.Cos(phase) - Math.Sin(phase) * 0
            ' Corregir el desplazamiento de frecuencia
            output(i) = output(i) * Math.Exp(-1 * freq * i * 2 * Math.PI / input.Length)
        Next














        ' Decodificar la señal en banda base según el tipo de modulación
        ' Por ejemplo, para QPSK se podría usar el siguiente código
        'Dim bits As New List(Of Integer) ' Lista para almacenar los bits
        'Dim symbol As Complex ' Símbolo actual
        'Dim bit1 As Integer ' Primer bit del símbolo
        'Dim bit2 As Integer ' Segundo bit del símbolo
        'For i = 0 To output.Length - 1
        '    ' Obtener el símbolo actual
        '    symbol = output(i)
        '    ' Decodificar el primer bit según el cuadrante del símbolo
        '    If symbol.Real >= 0 Then
        '        bit1 = 0
        '    Else
        '        bit1 = 1
        '    End If
        '    ' Decodificar el segundo bit según el cuadrante del símbolo
        '    If symbol.Imaginary >= 0 Then
        '        bit2 = 0
        '    Else
        '        bit2 = 1
        '    End If
        '    ' Añadir los bits a la lista
        '    bits.Add(bit1)
        '    bits.Add(bit2)
        'Next

        ' Recorrer la señal de entrada
        For i = 0 To input.Length - 1
            ' Actualizar el lazo de costas con el valor actual de la entrada
            pll.Update(input(i))
            ' Obtener la fase y la frecuencia estimadas
            phase = Math.Atan2(Math.Sin(pll.Phase), Math.Cos(pll.Phase))
            freq = pll.Freq
            ' Rotar la entrada para obtener la señal en banda base
            output(i) = input(i) * Math.Cos(phase) - Math.Sin(phase) * 0
            ' Corregir el desplazamiento de frecuencia
            output(i) = output(i) * Math.Exp(-1 * freq * i * 2 * Math.PI / input.Length)
        Next

        ' Decodificar los bits
        Dim bits As New List(Of Integer) ' Lista para almacenar los bits
        Dim symbol As Double ' Símbolo actual
        Dim bit1 As Integer ' Primer bit del símbolo
        Dim bit2 As Integer ' Segundo bit del símbolo
        For i = 0 To output.Length - 1
            ' Obtener el símbolo actual
            symbol = output(i)
            ' Decodificar el primer bit según el cuadrante del símbolo
            If symbol >= 0 Then
                bit1 = 0
            Else
                bit1 = 1
            End If
            ' Decodificar el segundo bit según el cuadrante del símbolo
            If Math.Abs(symbol) < 1 Then
                bit2 = 0
            Else
                bit2 = 1
            End If
            ' Añadir los bits a la lista
            bits.Add(bit1)
            bits.Add(bit2)
        Next











        ' Mostrar o guardar los bits obtenidos
        Return output
    End Function


    Function LazoCostasSegundoOrdenBin(input As Double()) As List(Of Integer)
        ' Declarar las variables y constantes
        Dim fs As Double ' Frecuencia de muestreo
        Dim K As Double ' Ganancia del lazo
        Dim zeta As Double ' Coeficiente de amortiguamiento
        Dim wn As Double ' Ancho de banda natural
        Dim b As Double ' Coeficiente b del filtro
        Dim k1 As Double ' Coeficiente k1 del filtro
        Dim k2 As Double ' Coeficiente k2 del filtro
        'Dim input As Double() ' Señal de entrada
        Dim output As Double() ' Señal de salida
        Dim phase As Double ' Fase estimada
        Dim freq As Double ' Frecuencia estimada
        Dim i As Integer ' Índice del bucle

        ' Asignar valores a las variables y constantes
        fs = 1000 ' Hz
        K = 1 ' Ajustar según la señal de entrada
        zeta = 0.707 ' Valor óptimo para un lazo de segundo orden
        wn = 0.01 ' Rad/s, ajustar según el ancho de banda deseado
        b = (1 + 2 * zeta * wn + wn ^ 2) / (2 * K) ' Fórmula del texto
        k1 = (4 * zeta * wn - 2) / b ' Fórmula del texto
        k2 = (4 * wn ^ 2) / b ' Fórmula del texto
        'input = ... ' Leer la señal de entrada desde un archivo o un dispositivo
        output = New Double(input.Length - 1) {} ' Inicializar la señal de salida
        phase = 0 ' Inicializar la fase estimada
        freq = 0 ' Inicializar la frecuencia estimada

        ' Crear un objeto de la clase PLL
        Dim pll As New PLL(K, b, k1, k2)

        '' Recorrer la señal de entrada
        'For i = 0 To input.Length - 1
        '    ' Actualizar el lazo de costas con el valor actual de la entrada
        '    pll.Update(input(i))
        '    ' Obtener la fase y la frecuencia estimadas
        '    phase = pll.Phase
        '    freq = pll.Freq
        '    ' Rotar la entrada para obtener la señal en banda base
        '    output(i) = input(i) * Math.Exp(-1 * phase * Complex.ImaginaryOne)
        '    ' Corregir el desplazamiento de frecuencia
        '    output(i) = output(i) * Math.Exp(-1 * freq * i * Complex.ImaginaryOne)
        'Next


        ' Recorrer la señal de entrada
        For i = 0 To input.Length - 1
            ' Actualizar el lazo de costas con el valor actual de la entrada
            pll.Update(input(i))
            ' Obtener la fase y la frecuencia estimadas
            phase = Math.Atan2(Math.Sin(pll.Phase), Math.Cos(pll.Phase))
            freq = pll.Freq
            ' Rotar la entrada para obtener la señal en banda base
            output(i) = input(i) * Math.Cos(phase) - Math.Sin(phase) * 0
            ' Corregir el desplazamiento de frecuencia
            output(i) = output(i) * Math.Exp(-1 * freq * i * 2 * Math.PI / input.Length)
        Next














        ' Decodificar la señal en banda base según el tipo de modulación
        ' Por ejemplo, para QPSK se podría usar el siguiente código
        'Dim bits As New List(Of Integer) ' Lista para almacenar los bits
        'Dim symbol As Complex ' Símbolo actual
        'Dim bit1 As Integer ' Primer bit del símbolo
        'Dim bit2 As Integer ' Segundo bit del símbolo
        'For i = 0 To output.Length - 1
        '    ' Obtener el símbolo actual
        '    symbol = output(i)
        '    ' Decodificar el primer bit según el cuadrante del símbolo
        '    If symbol.Real >= 0 Then
        '        bit1 = 0
        '    Else
        '        bit1 = 1
        '    End If
        '    ' Decodificar el segundo bit según el cuadrante del símbolo
        '    If symbol.Imaginary >= 0 Then
        '        bit2 = 0
        '    Else
        '        bit2 = 1
        '    End If
        '    ' Añadir los bits a la lista
        '    bits.Add(bit1)
        '    bits.Add(bit2)
        'Next

        ' Recorrer la señal de entrada
        For i = 0 To input.Length - 1
            ' Actualizar el lazo de costas con el valor actual de la entrada
            pll.Update(input(i))
            ' Obtener la fase y la frecuencia estimadas
            phase = Math.Atan2(Math.Sin(pll.Phase), Math.Cos(pll.Phase))
            freq = pll.Freq
            ' Rotar la entrada para obtener la señal en banda base
            output(i) = input(i) * Math.Cos(phase) - Math.Sin(phase) * 0
            ' Corregir el desplazamiento de frecuencia
            output(i) = output(i) * Math.Exp(-1 * freq * i * 2 * Math.PI / input.Length)
        Next

        ' Decodificar los bits
        Dim bits As New List(Of Integer) ' Lista para almacenar los bits
        Dim symbol As Double ' Símbolo actual
        Dim bit1 As Integer ' Primer bit del símbolo
        Dim bit2 As Integer ' Segundo bit del símbolo
        For i = 0 To output.Length - 1
            ' Obtener el símbolo actual
            symbol = output(i)
            ' Decodificar el primer bit según el cuadrante del símbolo
            If symbol >= 0 Then
                bit1 = 0
            Else
                bit1 = 1
            End If
            ' Decodificar el segundo bit según el cuadrante del símbolo
            If Math.Abs(symbol) < 1 Then
                bit2 = 0
            Else
                bit2 = 1
            End If
            ' Añadir los bits a la lista
            bits.Add(bit1)
            bits.Add(bit2)
        Next











        ' Mostrar o guardar los bits obtenidos
        Return bits
    End Function
#End Region
    Public Class PLL
        Private K As Double ' Ganancia del lazo
        Private b As Double ' Coeficiente b del filtro
        Private k1 As Double ' Coeficiente k1 del filtro
        Private k2 As Double ' Coeficiente k2 del filtro
        Private PLL_phase As Double ' Fase estimada
        Private PLL_freq As Double ' Frecuencia estimada
        Private vco As Double ' Salida del VCO

        Public Sub New(ByVal K As Double, ByVal b As Double, ByVal k1 As Double, ByVal k2 As Double)
            Me.K = K
            Me.b = b
            Me.k1 = k1
            Me.k2 = k2
            Me.PLL_phase = 0
            Me.PLL_freq = 0
            Me.vco = 0
        End Sub

        Public Sub Update(ByVal input As Double)
            Dim error1 As Double = input * Me.vco
            Me.PLL_phase += Me.PLL_freq + Me.k1 * error1
            Me.PLL_freq += Me.k2 * error1
            Me.vco = Math.Cos(Me.Phase)
        End Sub

        Public ReadOnly Property Phase As Double
            Get
                Return Me.PLL_phase
            End Get
        End Property

        Public ReadOnly Property Freq As Double
            Get
                Return Me.PLL_freq
            End Get
        End Property
    End Class

#Region ""

    'Friend Function constellation(ByVal x As Double, ByVal y As Double, ByVal z As Double)



    Friend Property constellation1(ByVal x As Double, ByVal y As Double, ByVal z As Double) As Complex_Qpsk
        Get

        End Get
        Set()

        End Set
    End Property

    'Function constellation() As Double()
    '    Dim c(2, 2) As Double = {New Double(-1, -1), New Double(-1, 1), New Double(1, -1), New Double(1, 1)}
    '    For i As Integer = 0 To c.Length - 1
    '        c(i) /= Math.Sqrt(2)
    '    Next
    '    Return c
    'End Function



#End Region
    '    import numpy As np

    'def demodulador_QPSK(signal) : 
    '    # Tamaño de la señal
    '    N = len(signal)
    '    # Puntos de constelación para QPSK
    '    constellation = np.array([-1-1j, -1+1j, 1-1j, 1+1j]) / np.sqrt(2)
    '    # Inicializar arreglo para almacenar los símbolos demodulados
    '    demod_signal = np.zeros(N, dtype=complex)
    '    # Demodulación
    '    For i in range(0, N, 2):
    '        # Extraer el símbolo actual
    '        symbol = signal[i] + 1j * signal[i+1]
    '        # Calcular la distancia mínima entre el símbolo y los puntos de constelación
    '        distances = np.abs(symbol - constellation)
    '        # Obtener el índice del punto más cercano en la constelación
    '        demod_index = np.argmin(distances)
    '        # Almacenar el símbolo demodulado en el arreglo de salida
    '        demod_signal[i] = np.real(constellation[demod_index])
    '        demod_signal[i+1] = np.imag(constellation[demod_index])
    '    Return demod_signal

    '# Ejemplo de uso
    '# Generar señal QPSK aleatoria
    'N = 1000  # Tamaño de la señal
    'signal = np.random.randint(0, 2, N) * 2 - 1  # Convertir bits en símbolos BPSK
    'signal = signal + 1j * (np.random.randint(0, 2, N) * 2 - 1)  # Agregar componente imaginaria
    '# Demodular la señal
    'demodulated_signal = demodulador_QPSK(signal)
    Function Demodulador_QPSK_2(ByVal signal() As Double) As Double()
        ' Tamaño de la señal
        Dim N As Integer = signal.Length
        ' Puntos de constelación para QPSK
        Dim constellation() As Double = {-1 / Math.Sqrt(2), 1 / Math.Sqrt(2), -1 / Math.Sqrt(2), 1 / Math.Sqrt(2)}
        ' Inicializar arreglo para almacenar los símbolos demodulados
        Dim demod_signal(N - 1) As Double
        ' Demodulación
        For i As Integer = 0 To N - 1 Step 2
            Try
                ' Extraer el símbolo actual
                Dim symbol As Double = signal(i) * Math.Cos(Math.PI / 4) + signal(i + 1) * Math.Sin(Math.PI / 4)
                ' Calcular la distancia mínima entre el símbolo y los puntos de constelación
                Dim distances(constellation.Length - 1) As Double
                For j As Integer = 0 To constellation.Length - 1 Step 2
                    distances(j) = Math.Sqrt((symbol - constellation(j)) ^ 2 + (symbol - constellation(j + 1)) ^ 2)
                Next
                ' Obtener el índice del punto más cercano en la constelación
                Dim demod_index As Integer = Array.IndexOf(distances, distances.Min())
                ' Almacenar el símbolo demodulado en el arreglo de salida
                demod_signal(i) = constellation(demod_index)
                demod_signal(i + 1) = constellation(demod_index + 1)
            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try

        Next
        Return demod_signal
    End Function
    'Imports System
    'Imports System.Numerics

#Region ""

    Function Obtener_Fase(ByVal V_max As Double, ByVal V As Double) As Double
        Return Math.Acos(V_max / V)
    End Function

    Function demodular_I(t As Double, s As Double, fc As Double) As Double
        demodular_I = s * Math.Cos(2 * Math.PI * fc * t)
    End Function

    Function demodular_Q(s As Double, fc As Double, t As Double) As Double
        demodular_Q = s * Math.Sin(2 * Math.PI * fc * t)
    End Function

    Friend Function DivisorCanales_IQ(ByVal SeñalIn As Double, ByVal Tiempo1 As Double, ByVal Tiempo2 As Double, ByVal Frecuencia As Double) As Double()
        Dim SeñalFiltrada_BPF As Double = FiltroFirKalman(SeñalIn)
        Dim Canal_I As Double = -Math.Sin(2 * Math.PI * Frecuencia * Tiempo1) + Math.Cos(2 * Math.PI * Frecuencia * Tiempo1)
        Dim Canal_Q As Double = -Math.Sin(2 * Math.PI * Frecuencia * Tiempo2) + Math.Cos(2 * Math.PI * Frecuencia * Tiempo2)

        Dim Canal_I2 As Double = (-Math.Sin(2 * Math.PI * Frecuencia * Tiempo1) + Math.Cos(2 * Math.PI * Frecuencia * Tiempo1)) * Math.Sin(2 * Math.PI * Frecuencia * Tiempo1)
        Dim Canal_Q2 As Double = 0.5 + (0.5 * Math.Cos(4 * Math.PI * Frecuencia * Tiempo2)) - (0.5 * Math.Sin(4 * Math.PI * Frecuencia * Tiempo2)) - (0.5 * Math.Sin(0))

        'Dim Canales_IQ() As Double = New Double() {Canal_I, Canal_Q}

        Return New Double() {Canal_I, Canal_Q}
    End Function

    Function Demodular_IQ(ByVal signal() As Double) As Complex_IQ()
        Dim N As Integer = signal.Length
        Dim demodulated_signal(N / 2 - 1) As Complex_IQ
        For i As Integer = 0 To N - 1 Step 2
            Dim _I As Double = signal(i)
            Dim _Q As Double = signal(i + 1)
            demodulated_signal(i / 2) = New Complex_IQ(_I, _Q)
        Next
        Return demodulated_signal
    End Function

    Function Desfasar_90_Grados(ByVal signal() As Double) As Double()
        Dim N As Integer = signal.Length
        Dim desfasada(N - 1) As Double
        For i As Integer = 0 To N - 1
            desfasada(i) = signal(i) * Math.Cos(Math.PI / 2) + 0 * Math.Sin(Math.PI / 2)
        Next
        Return desfasada
    End Function

#End Region

    Public Class Complex_IQ
        Private _I As Double
        Private _Q As Double

        Public Sub New(i As Double, q As Double)
            _I = i
            _Q = q
        End Sub
    End Class

    Function Demodulador_QPSK(signal() As Double) As Double()
        ' Tamaño de la señal
        Dim N As Integer = signal.Length
        ' Puntos de constelación para QPSK
        Dim constellation(3) As Double
        constellation(0) = -1 / Math.Sqrt(2)
        constellation(1) = 1 / Math.Sqrt(2)
        constellation(2) = -1 / Math.Sqrt(2)
        constellation(3) = 1 / Math.Sqrt(2)
        ' Inicializar arreglo para almacenar los símbolos demodulados
        Dim demod_signal(N - 1) As Double
        ' Demodulación
        For i As Integer = 0 To N - 1 Step 2
            Try
                ' Extraer el símbolo actual
                Dim symbol_real As Double = signal(i)
                Dim symbol_imag As Double = signal(i + 1)
                ' Calcular la distancia mínima entre el símbolo y los puntos de constelación
                Dim distances(3) As Double
                For j As Integer = 0 To 3
                    Try
                        Dim distance_real As Double = symbol_real - constellation(j)
                        Dim distance_imag As Double = symbol_imag - constellation(j)
                        distances(j) = Math.Sqrt((distance_real * distance_real) + (distance_imag * distance_imag))
                    Catch ex As Exception

                    End Try

                Next
                ' Obtener el índice del punto más cercano en la constelación
                Dim demod_index As Integer = Array.IndexOf(distances, distances.Min())
                ' Almacenar el símbolo demodulado en el arreglo de salida
                demod_signal(i) = constellation(demod_index)
                demod_signal(i + 1) = constellation(demod_index)
            Catch ex As Exception

            End Try

        Next
        Return demod_signal
    End Function

End Class

Module Module1
    Sub Main(ByVal signal_ByVal() As Double)
        ' Ejemplo de uso
        ' Generar señal QPSK aleatoria
        Dim N As Integer = signal_ByVal.Length ' 1000 ' Tamaño de la señal
        Dim signal(N - 1) As ComplexNumber
        Dim random As New Random()
        For i As Integer = 0 To N - 1
            Dim bit As Integer = random.Next(0, 2)
            Dim symbol As Integer = bit * 2 - 1
            signal(i) = New ComplexNumber(symbol, (random.Next(0, 2) * 2 - 1))
        Next
        ' Demodular la señal
        Dim demodulated_signal() As ComplexNumber = Demodulador_QPSK_1(signal)
    End Sub

    Friend Class Complex_Qpsk
        Sub New(ByVal X_0 As Double, ByVal Y_0 As Double)

        End Sub
        Friend X_val As Double
        Friend Y_val As Double
    End Class

    Function Demodulador_QPSK_1(ByVal signal() As ComplexNumber) As ComplexNumber()
        '' Tamaño de la señal
        'Dim N As Integer = signal.Length
        '' Puntos de constelación para QPSK
        'Dim constellation() As ComplexNumber = {New ComplexNumber(-1, -1), New ComplexNumber(-1, 1), New ComplexNumber(1, -1), New ComplexNumber(1, 1)}
        'For i As Integer = 0 To constellation.Length - 1
        '    constellation(i) /= Math.Sqrt(2)
        'Next
        '' Inicializar arreglo para almacenar los símbolos demodulados
        'Dim demod_signal(N - 1) As ComplexNumber
        '' Demodulación
        'For i As Integer = 0 To N - 1 Step 2
        '    ' Extraer el símbolo actual
        '    Dim symbol As ComplexNumber = signal(i) + signal(i + 1) * ComplexNumber.ImaginaryOne
        '    ' Calcular la distancia mínima entre el símbolo y los puntos de constelación
        '    Dim distances(constellation.Length - 1) As Double
        '    For j As Integer = 0 To constellation.Length - 1
        '        distances(j) = ComplexNumber.Abs(symbol - constellation(j))
        '    Next
        '    ' Obtener el índice del punto más cercano en la constelación
        '    Dim demod_index As Integer = Array.IndexOf(distances, distances.Min())
        '    ' Almacenar el símbolo demodulado en el arreglo de salida
        '    demod_signal(i) = constellation(demod_index).Real
        '    demod_signal(i + 1) = constellation(demod_index).Imaginary
        'Next

        '' Tamaño de la señal
        'Dim N As Integer = signal.Length
        '' Puntos de constelación para QPSK
        'Dim constellation() As ComplexNumber = {New ComplexNumber(-1, -1), New ComplexNumber(-1, 1), New ComplexNumber(1, -1), New ComplexNumber(1, 1)}
        'For i As Integer = 0 To constellation.Length - 1
        '    constellation(i) /= Math.Sqrt(2)
        'Next
        '' Inicializar arreglo para almacenar los símbolos demodulados
        'Dim demod_signal(N - 1) As ComplexNumber
        '' Demodulación
        'For i As Integer = 0 To N - 1 Step 2
        '    ' Extraer el símbolo actual
        '    Dim symbol As ComplexNumber = signal(i) + signal(i + 1) * ComplexNumber.ImaginaryOne
        '    ' Calcular la distancia mínima entre el símbolo y los puntos de constelación
        '    Dim distances(constellation.Length - 1) As Double
        '    For j As Integer = 0 To constellation.Length - 1
        '        distances(j) = ComplexNumber.Abs(symbol - constellation(j))
        '    Next
        '    ' Obtener el índice del punto más cercano en la constelación
        '    Dim demod_index As Integer = Array.IndexOf(distances, distances.Min())
        '    ' Almacenar el símbolo demodulado en el arreglo de salida
        '    demod_signal(i) = constellation(demod_index).Real
        '    demod_signal(i + 1) = constellation(demod_index).Imaginary
        'Next


        'Return signal
    End Function


    Function Demodulador_QPSK_2(ByVal signal() As Double) As Double()
        ' Tamaño de la señal
        Dim N As Integer = signal.Length
        ' Puntos de constelación para QPSK
        Dim constellation() As Double = {-1 / Math.Sqrt(2), 1 / Math.Sqrt(2), -1 / Math.Sqrt(2), 1 / Math.Sqrt(2)}
        ' Inicializar arreglo para almacenar los símbolos demodulados
        Dim demod_signal(N - 1) As Double
        ' Demodulación
        For i As Integer = 0 To N - 1 Step 2
            ' Extraer el símbolo actual
            Dim symbol As Double = signal(i) * Math.Cos(Math.PI / 4) + signal(i + 1) * Math.Sin(Math.PI / 4)
            ' Calcular la distancia mínima entre el símbolo y los puntos de constelación
            Dim distances(constellation.Length - 1) As Double
            For j As Integer = 0 To constellation.Length - 1 Step 2
                distances(j) = Math.Sqrt((symbol - constellation(j)) ^ 2 + (symbol - constellation(j + 1)) ^ 2)
            Next
            ' Obtener el índice del punto más cercano en la constelación
            Dim demod_index As Integer = Array.IndexOf(distances, distances.Min())
            ' Almacenar el símbolo demodulado en el arreglo de salida
            demod_signal(i) = constellation(demod_index)
            demod_signal(i + 1) = constellation(demod_index + 1)
        Next
        Return demod_signal
    End Function

    Function Demodulador_QPSK(ByVal signal() As Double) As Double()
        ' Tamaño de la señal
        Dim N As Integer = signal.Length
        ' Puntos de constelación para QPSK
        Dim constellation() As Double = {-1 / Math.Sqrt(2), 1 / Math.Sqrt(2), -1 / Math.Sqrt(2), 1 / Math.Sqrt(2)}
        ' Inicializar arreglo para almacenar los símbolos demodulados
        Dim demod_signal(N - 1) As Double
        ' Demodulación
        For i As Integer = 0 To N - 1 Step 2
            ' Extraer el símbolo actual
            Dim symbol As Double = signal(i) * Math.Cos(Math.PI / 4) + signal(i + 1) * Math.Sin(Math.PI / 4)
            ' Calcular la distancia mínima entre el símbolo y los puntos de constelación
            Dim distances(constellation.Length - 1) As Double
            For j As Integer = 0 To constellation.Length - 1 Step 2
                distances(j) = Math.Sqrt((symbol - constellation(j)) ^ 2 + (symbol - constellation(j + 1)) ^ 2)
            Next
            ' Obtener el índice del punto más cercano en la constelación
            Dim demod_index As Integer = Array.IndexOf(distances, distances.Min())
            ' Almacenar el símbolo demodulado en el arreglo de salida
            demod_signal(i) = constellation(demod_index)
            demod_signal(i + 1) = constellation(demod_index + 1)
        Next
        Return demod_signal
    End Function



#Region ""
    ''' <summary>
    '''  La señal modulada
    ''' </summary>
    ''' <param name="t">tiempo</param>
    ''' <param name="A">amplitud de la señal</param>
    ''' <param name="fc">frecuencia de la portadora</param>
    ''' <param name="theta_n">es la fase de la señal</param>
    ''' <returns></returns>
    Function s(t As Double, A As Double, fc As Double, theta_n As Double) As Double
        s = A * Math.Cos(2 * Math.PI * fc * t + theta_n)
    End Function
    ''' <summary>
    '''  La señal en fase
    ''' </summary>
    ''' <param name="s"></param>
    ''' <param name="fc"></param>
    ''' <param name="t"></param>
    ''' <returns></returns>
    Function demodular_I(s As Double, fc As Double, t As Double) As Double
        demodular_I = s * Math.Cos(2 * Math.PI * fc * t)
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="s"></param>
    ''' <param name="fc"></param>
    ''' <param name="t"></param>
    ''' <returns></returns>
    Function demodular_Q(s As Double, fc As Double, t As Double) As Double
        demodular_Q = s * Math.Sin(2 * Math.PI * fc * t)
    End Function

#End Region


End Module


Module Module2


    'Imports System
    'Imports System.Numerics

    'Module Module1
    '    Sub Main()
    '        ' Ejemplo de uso
    '        ' Generar señal QPSK aleatoria
    '        Dim N As Integer = 1000 ' Tamaño de la señal
    '        Dim signal(N - 1) As Complex
    '        Dim random As New Random()
    '        For i As Integer = 0 To N - 1
    '            Dim bit As Integer = random.Next(0, 2)
    '            Dim symbol As Integer = bit * 2 - 1
    '            signal(i) = New Complex(symbol, (random.Next(0, 2) * 2 - 1))
    '        Next
    '        ' Demodular la señal
    '        Dim demodulated_signal() As Complex = Demodulador_QPSK(signal)
    '    End Sub

    '    Function Demodulador_QPSK(ByVal signal() As Complex) As Complex()
    '        ' Tamaño de la señal
    '        Dim N As Integer = signal.Length
    '        ' Puntos de constelación para QPSK
    '        Dim constellation() As Complex = {New Complex(-1, -1), New Complex(-1, 1), New Complex(1, -1), New Complex(1, 1)}
    '        For i As Integer = 0 To constellation.Length - 1
    '            constellation(i) /= Math.Sqrt(2)
    '        Next
    '        ' Inicializar arreglo para almacenar los símbolos demodulados
    '        Dim demod_signal(N - 1) As Complex
    '        ' Demodulación
    '        For i As Integer = 0 To N - 1 Step 2
    '            ' Extraer el símbolo actual
    '            Dim symbol As Complex = signal(i) + signal(i + 1) * Complex.ImaginaryOne
    '            ' Calcular la distancia mínima entre el símbolo y los puntos de constelación
    '            Dim distances(constellation.Length - 1) As Double
    '            For j As Integer = 0 To constellation.Length - 1
    '                distances(j) = Complex.Abs(symbol - constellation(j))
    '            Next
    '            ' Obtener el índice del punto más cercano en la constelación
    '            Dim demod_index As Integer = Array.IndexOf(distances, distances.Min())
    '            ' Almacenar el símbolo demodulado en el arreglo de salida
    '            demod_signal(i) = constellation(demod_index).Real
    '            demod_signal(i + 1) = constellation(demod_index).Imaginary
    '        Next
    '        Return demod_signal
    '    End Function
    'End Module


    Public Class ComplexNumber
        Private _real As Double
        Private _imaginary As Double
        Public Sub New()
            Me.Real = 0
            Me.Imaginary = 0
        End Sub
        Public Sub New(ByVal real As Double, ByVal imaginary As Double)
            _real = real
            _imaginary = imaginary
        End Sub

        Public Property Real() As Double
            Get
                Return _real
            End Get
            Set(ByVal value As Double)
                _real = value
            End Set
        End Property

        Public Property Imaginary() As Double
            Get
                Return _imaginary
            End Get
            Set(ByVal value As Double)
                _imaginary = value
            End Set
        End Property

        'Friend Shared Function ImaginaryOne() As ComplexNumber
        '    'Throw New NotImplementedException()
        'End Function

        Friend Shared Function Abs(p As Object) As Double
            'Throw New NotImplementedException()
        End Function

        Public Function Magnitude() As Double
            Return Math.Sqrt(_real * _real + _imaginary * _imaginary)
        End Function

        Public Function Phase() As Double
            Return Math.Atan2(_imaginary, _real)
        End Function

        Public Shared ReadOnly Property ImaginaryOne As ComplexNumber
            Get
                Return New ComplexNumber(0, 1)
            End Get
        End Property

        Public Shared Function Exp(value As ComplexNumber) As ComplexNumber
            Dim magnitude As Double = Math.Exp(value.Real)
            Return New ComplexNumber(magnitude * Math.Cos(value.Imaginary), magnitude * Math.Sin(value.Imaginary))
        End Function


        'Public Shared Operator +(ByVal c1 As ComplexNumber, ByVal c2 As ComplexNumber) As ComplexNumber
        '    Return New ComplexNumber(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary)
        'End Operator

        'Public Shared Operator *(ByVal c1 As ComplexNumber, ByVal c2 As ComplexNumber) As ComplexNumber
        '    Return New ComplexNumber(c1.Real * c2.Real - c1.Imaginary * c2.Imaginary, c1.Real * c2.Imaginary + c1.Imaginary * c2.Real)
        'End Operator

        'Public Shared Operator /(ByVal Dividendo As ComplexNumber, ByVal Divisor As Double)
        '    Return New ComplexNumber(Divisor.Real / Divisor, Divisor.Imaginary / Divisor)
        'End Operator


        Public Shared Operator +(ByVal c1 As ComplexNumber, ByVal c2 As ComplexNumber) As ComplexNumber
            Return New ComplexNumber(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary)
        End Operator

        Public Shared Operator -(ByVal c1 As ComplexNumber, ByVal c2 As ComplexNumber) As ComplexNumber
            Return New ComplexNumber(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary)
        End Operator

        Public Shared Operator *(ByVal c1 As ComplexNumber, ByVal c2 As ComplexNumber) As ComplexNumber
            Return New ComplexNumber(c1.Real * c2.Real - c1.Imaginary * c2.Imaginary, c1.Real * c2.Imaginary + c1.Imaginary * c2.Real)
        End Operator

        Public Shared Operator /(ByVal c1 As ComplexNumber, ByVal c2 As ComplexNumber) As ComplexNumber
            Dim d As Double = c2.Real * c2.Real + c2.Imaginary * c2.Imaginary
            Return New ComplexNumber((c1.Real * c2.Real + c1.Imaginary * c2.Imaginary) / d, (c1.Imaginary * c2.Real - c1.Real * c2.Imaginary) / d)
        End Operator

        Public Overrides Function ToString() As String
            Return String.Format("({0}, {1})", Me.Real, Me.Imaginary)
        End Function

    End Class

End Module