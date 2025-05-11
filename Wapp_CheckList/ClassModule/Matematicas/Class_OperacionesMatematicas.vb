
Public Class Class_OperacionesMatematicas

    ' Función para calcular el Máximo Común Divisor (MCD)
    Public Function MCD(ByVal a As Integer, ByVal b As Integer) As Integer
        While b <> 0
            Dim t As Integer = b
            b = a Mod b
            a = t
        End While
        Return a
    End Function

    ' Función para calcular el Mínimo Común Múltiplo (MCM)
    Public Function MCM(ByVal a As Integer, ByVal b As Integer) As Integer
        Return (a / MCD(a, b)) * b
    End Function

    Friend Function Logaritmico(ByVal ValorMinimo As Double, ByVal ValorMaximo As Double, ByVal Saltos As UInteger) As Single()
        Dim frequencyLim() As Single
        Try
            Dim minimo As Int16 = ValorMinimo
            Dim maximo As Int64 = ValorMaximo
            Dim stepSize As Double = (maximo - minimo) / Saltos
            Dim LosgaritmoCoe As Double = Math.Log(minimo)
            Dim LosgaritmoDividor As Double = -10 * (Math.Log(100) - Math.Log(maximo))


            frequencyLim = New Single(Saltos - 1) {}
            For indiceF As Int16 = 0 To Saltos - 1
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
        Return frequencyLim
    End Function

End Class
