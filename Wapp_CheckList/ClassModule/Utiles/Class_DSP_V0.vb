




Public Class Class_DSP_V0

    Friend _waveLeft As Single()
    Friend _waveRight As Single()

    Private _signalGenerator As SignalGenerator
        Friend _isTest As Boolean = False


        Public FiltroFactor As Double = 0.6
        Public VolumenFactor As Double = 0.6
        Public VolumenGrabes As Double = 1.0
        Public VolumenAgudos As Double = 1.0



#Region "Filtro"

        Dim y_Filtro As Single
        Dim y_FiltroAnterior1 As Single
        Dim y_FiltroAnterior2 As Single
        Dim y_FiltroAnterior3 As Single
        Dim y_FiltroAnterior4 As Single

        Dim yAxisFiltro As Single
        Dim yAxisFiltroAnterior1 As Single
        Dim yAxisFiltroAnterior2 As Single
        Dim yAxisFiltroAnterior3 As Single
        Dim yAxisFiltroAnterior4 As Single

#End Region

        Public Sub Process(ByRef wave As Byte())

            _waveLeft = New Single((wave.Length / 4) - 1) {}
            _waveRight = New Single((wave.Length / 4) - 1) {}


            Dim h As Integer = 0

            For i As Integer = 0 To wave.Length - 1 Step 4

                Dim CanalIzquierdo As Double = CDbl(BitConverter.ToInt16(wave, i)) * VolumenFactor
                If CanalIzquierdo > Int16.MaxValue Then
                    CanalIzquierdo = Int16.MaxValue
                End If
                Dim CanalDerecho As Double = CDbl(BitConverter.ToInt16(wave, i + 2)) * VolumenFactor
                If CanalDerecho > Int16.MaxValue Then
                    CanalDerecho = Int16.MaxValue
                End If

                _waveLeft(h) = CanalIzquierdo
                _waveRight(h) = CanalDerecho
                h += 1
            Next



        'Dim aaaaaaaaaa = 1

    End Sub

        Public Sub GenerarSeñal(ByRef wave As Byte())
            'Try
            _waveLeft = New Single((wave.Length / 4) - 1) {}
            _waveRight = New Single((wave.Length / 4) - 1) {}



            _signalGenerator = New SignalGenerator()
            _signalGenerator.SetWaveform("Sine")
            _signalGenerator.SetSamplingRate(44100)
            _signalGenerator.SetSamples(16384)
            _signalGenerator.SetFrequency(5000)
            _signalGenerator.SetAmplitude(32768)
            _waveLeft = _signalGenerator.GenerateSignal()
            _waveRight = _signalGenerator.GenerateSignal()




        End Sub



        Function Chanels_Filters() As ClassArchivo_BufferEstereo

            Dim ListaCanalesFilrados As New ClassArchivo_BufferEstereo
            'ListaCanalesFilrados.Grabe = New List(Of Double)
            'ListaCanalesFilrados.Agudo = New List(Of Double)
            'Dim CanalesGrabe As List(Of Double) = New List(Of Double)
            'Dim CanalesAgudo As List(Of Double) = New List(Of Double)

            ListaCanalesFilrados.canal_L = New Single(_waveLeft.Length - 1) {}
            ListaCanalesFilrados.canal_R = New Single(_waveLeft.Length - 1) {}

            Try





                Dim xPrevLeft As Integer = 0, yPrevLeft As Integer = 0



                For indice As Integer = 0 To _waveLeft.Length - 1

                    Dim ValorGeometricoCanales As Single = _waveLeft(indice) 'Math.Sqrt((Math.Pow(_waveLeft(indice), 2) + Math.Pow(_waveRight(indice), 2)))

                    If ValorGeometricoCanales > Int16.MaxValue - 1 Then
                        ValorGeometricoCanales = Int16.MaxValue - 1
                    End If

                    'Dim Media As Single = ((y_FiltroAnterior1 * 10 + y_FiltroAnterior2 + y_FiltroAnterior3 + y_FiltroAnterior4) / 14)
                    'CanalesGrabe.Add((Class_Configuracion.FiltroFactor * ((_waveLeft(indice) * 2 + y_Filtro) / 3) + (y_FiltroAnterior1 * (1 - Class_Configuracion.FiltroFactor))))
                    Dim calculado As Single = ((Class_Configuracion.FiltroFactor * ((ValorGeometricoCanales * 2 + y_Filtro) / 3) + (y_FiltroAnterior1 * (1 - Class_Configuracion.FiltroFactor))))
                    Dim GraveValor As Single = calculado * VolumenGrabes

                    If GraveValor > Int16.MaxValue - 1 Then
                        GraveValor = Int16.MaxValue - 1
                    End If

                    'ListaCanalesFilrados.Grabe.Add(GraveValor)
                    ListaCanalesFilrados.canal_L(indice) = (GraveValor)

                    y_Filtro = ValorGeometricoCanales
                    y_FiltroAnterior4 = y_FiltroAnterior3
                    y_FiltroAnterior3 = y_FiltroAnterior2
                    y_FiltroAnterior2 = y_FiltroAnterior1
                    y_FiltroAnterior1 = ListaCanalesFilrados.canal_L(indice) 'ListaCanalesFilrados.Grabe(indice)
                    'CanalesAgudo.Add(y_Filtro - CanalesGrabe(indice))

                    Dim AgudoValor As Single = ((ValorGeometricoCanales - (VolumenGrabes / VolumenGrabes)) * VolumenAgudos)

                    If AgudoValor > Int16.MaxValue - 1 Then
                        AgudoValor = Int16.MaxValue - 1
                    End If
                    ListaCanalesFilrados.canal_R(indice) = AgudoValor

                    'ListaCanalesFilrados.Agudo.Add(AgudoValor)





                Next


            Catch ex As Exception

            End Try


            Return ListaCanalesFilrados
        End Function



    End Class




