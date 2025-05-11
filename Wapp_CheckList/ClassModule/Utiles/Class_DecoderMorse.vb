

Public Class Class_DecoderMorse

    'Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
    '    timePerParse.Start() 'Iniciar el cronómetro
    'End Sub
    'Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
    '    timePerParse.Stop() 'Detener el cronómetro
    '    Dim ts As TimeSpan = timePerParse.Elapsed 'Obtener el tiempo transcurrido
    '    lblOutput.Text = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds \ 10) 'Mostrar el tiempo transcurrido en la etiqueta
    'End Sub

    Dim timePerParse As Stopwatch = New Stopwatch()

    Enum MorsePartes
        Corto
        Largo
        Signo
        Letra
        Espacio
    End Enum

    Public Sub Inicio()
        Try
            timePerParse.Start()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Parar()
        Try
            timePerParse.Stop()
        Catch ex As Exception

        End Try
    End Sub

    Dim NivelAlto As Boolean = False

    Dim TiempoLargo As ULong = 2500 ' unidad=0,1microsegundos unidad=100nanosegundos
    Dim TiempoCorto As ULong = 1250 ' unidad=0,1microsegundos unidad=100nanosegundos
    Dim TiempoEntreLetras As ULong = 500 ' unidad=0,1microsegundos unidad=100nanosegundos
    Dim TiempoEntreSimbolo As ULong = 500 ' unidad=0,1microsegundos unidad=100nanosegundos
    Dim TiempoEspacio As ULong = 2500 ' unidad=0,1microsegundos unidad=100nanosegundos

    Dim UltimoCambio As ULong = 0  ' unidad=0,1microsegundos unidad=100nanosegundos . estavariable es inecesaria

    Dim CadenaSigno As String



    Public Function Decoder(BarraSelect As Integer, Barras() As Single, Squelch As Single) As MorsePartes
        Try

            'Dim xPrevLeft As Integer = 0, yPrevLeft As Integer = 0
            Dim Retorno As New MorsePartes
            For IndiceWave As Integer = 0 To Barras.Length - 1

                If Squelch < Barras(IndiceWave) Then

                    If NivelAlto = True Then
                        'Dim ts As ULong = timePerParse.ElapsedTicks

                    Else

                        Retorno = DecoderTiempo(timePerParse.ElapsedTicks, True)
                        timePerParse.Reset()
                        ' Dim ts As ULong = timePerParse.ElapsedTicks



                    End If

                    NivelAlto = True
                Else

                    If NivelAlto = False Then
                        'Dim ts As ULong = timePerParse.ElapsedTicks

                    Else

                        Retorno = DecoderTiempo(timePerParse.ElapsedTicks, False)
                        timePerParse.Reset()
                        'Dim ts As ULong = timePerParse.ElapsedTicks

                    End If

                    NivelAlto = False
                End If

            Next




        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function DecoderTiempo(ByVal Tiempo As ULong, ByVal Alto As Boolean) As MorsePartes

        If Alto = True Then

            If TiempoLargo < timePerParse.ElapsedTicks Then



            ElseIf TiempoEspacio < timePerParse.ElapsedTicks Then



            End If

        Else

            If TiempoEspacio < timePerParse.ElapsedTicks Then



            ElseIf TiempoEntreSimbolo < timePerParse.ElapsedTicks Then



            End If

        End If



    End Function


End Class

