Public Class Class_ModuladorResonante


    Sub Main_AM()

        ' Parámetros de la señal
        Dim frecuenciaPortadora As Double = 1000 ' Hz
        Dim frecuenciaModuladora As Double = 100 ' Hz
        Dim amplitudModuladora As Double = 0.5

        ' Generación de la señal modulada
        Dim tiempo As Double
        Dim señalModulada As Double
        For tiempo = 0 To 1 Step 0.001
            Dim señalPortadora As Double = Math.Cos(2 * Math.PI * frecuenciaPortadora * tiempo)
            Dim señalModuladora As Double = amplitudModuladora * Math.Cos(2 * Math.PI * frecuenciaModuladora * tiempo)
            señalModulada = señalPortadora * (1 + señalModuladora)
            Console.WriteLine(tiempo & vbTab & señalModulada)
        Next

    End Sub

    Sub Main_RM()
        ' Parámetros de la señal
        Dim frecuenciaPortadora As Double = 1000 ' Hz
        Dim frecuenciaModuladora As Double = 100 ' Hz
        Dim amplitudModuladora As Double = 0.5
        Dim velocidadMaterial As Double = 200 ' m/s (por ejemplo)

        ' Generación de la señal modulada
        Dim tiempo As Double
        Dim señalModulada As Double
        For tiempo = 0 To 1 Step 0.001
            Dim señalPortadora As Double = Math.Cos(2 * Math.PI * frecuenciaPortadora * tiempo)
            Dim señalModuladora As Double = amplitudModuladora * Math.Sin(2 * Math.PI * frecuenciaModuladora * tiempo)
            Dim faseReflejo As Double = Math.Cos(2 * Math.PI * frecuenciaPortadora * tiempo) ' Fase debida al reflejo
            señalModulada = señalPortadora * (1 + señalModuladora) * faseReflejo
            Console.WriteLine(tiempo & vbTab & señalModulada)
        Next
    End Sub

    Sub Main_RM_Rendija()
        ' Parámetros de la señal
        Dim frecuenciaPortadora As Double = 1000 ' Hz
        Dim frecuenciaModuladora As Double = 100 ' Hz
        Dim amplitudModuladora As Double = 0.5
        Dim longitudOnda As Double = 0.0000005 ' Longitud de onda en metros (por ejemplo)
        Dim distanciaRanuras As Double = 0.1 ' Distancia entre las ranuras (d)
        Dim distanciaHaces As Double = 0.02 ' Distancia entre los haces (x)

        ' Generación de la señal modulada
        Dim tiempo As Double
        Dim señalModulada As Double
        For tiempo = 0 To 1 Step 0.001
            Dim señalPortadora As Double = Math.Cos(2 * Math.PI * frecuenciaPortadora * tiempo)
            Dim señalModuladora As Double = amplitudModuladora * Math.Sin(2 * Math.PI * frecuenciaModuladora * tiempo)
            Dim faseInterferencia As Double = 2 * Math.PI * distanciaRanuras * Math.Sin(2 * Math.PI * distanciaHaces / longitudOnda)
            señalModulada = señalPortadora * (1 + señalModuladora) * Math.Cos(faseInterferencia)
            Console.WriteLine(tiempo & vbTab & señalModulada)
        Next
    End Sub


    Sub Main_RM_Larmor()
        ' Parámetros de la señal
        Dim frecuenciaPortadora As Double = 1000 ' Hz
        Dim frecuenciaModuladora As Double = 100 ' Hz
        Dim amplitudModuladora As Double = 0.5
        Dim campoMagnetico As Double = 1.5 ' Tesla (por ejemplo)

        ' Generación de la señal modulada
        Dim tiempo As Double
        Dim señalModulada As Double
        For tiempo = 0 To 1 Step 0.001
            Dim señalPortadora As Double = Math.Cos(2 * Math.PI * frecuenciaPortadora * tiempo)
            Dim señalModuladora As Double = amplitudModuladora * Math.Sin(2 * Math.PI * frecuenciaModuladora * tiempo)
            Dim faseLarmor As Double = -campoMagnetico * frecuenciaPortadora ' Fase debido a la precesión de Larmor
            señalModulada = señalPortadora * (1 + señalModuladora) * Math.Cos(faseLarmor * tiempo)
            Console.WriteLine(tiempo & vbTab & señalModulada)
        Next
    End Sub

End Class
