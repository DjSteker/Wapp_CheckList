

Namespace Calendario


    Public Class Class_CalendarioCalculador

        Public Shared Function EsBisiesto(año As Integer) As Boolean
            Return (año Mod 4 = 0 AndAlso año Mod 100 <> 0) OrElse (año Mod 400 = 0)
        End Function

        Public Shared Function DiasEnMes(mes As Integer, año As Integer) As Integer
            Select Case mes
                Case 1, 3, 5, 7, 8, 10, 12
                    Return 31
                Case 4, 6, 9, 11
                    Return 30
                Case 2
                    Return If(EsBisiesto(año), 29, 28)
                Case Else
                    Throw New ArgumentException("Mes inválido")
            End Select
        End Function

        Public Shared Function DiasEnAño(año As Integer) As Integer
            Return If(EsBisiesto(año), 366, 365)
        End Function

        Public Shared Function DiferenciaEnDias(fecha1 As Date, fecha2 As Date) As Long
            Return DateDiff(DateInterval.Day, fecha1, fecha2)
        End Function

        Public Shared Function AgregarDias(fecha As Date, dias As Integer) As Date
            Return fecha.AddDays(dias)
        End Function
    End Class

    ' Dim año As Integer = 2025
    'Dim esBisiesto As Boolean = CalendarioCalculador.EsBisiesto(año)
    'Console.WriteLine($"¿Es {año} bisiesto? {esBisiesto}")

    'Dim diasEnFebrero As Integer = CalendarioCalculador.DiasEnMes(2, año)
    'Console.WriteLine($"Días en febrero de {año}: {diasEnFebrero}")

    'Dim fecha1 As Date = New Date(2025, 3, 12)
    'Dim fecha2 As Date = New Date(2025, 12, 25)
    'Dim diferencia As Long = CalendarioCalculador.DiferenciaEnDias(fecha1, fecha2)
    'Console.WriteLine($"Días entre {fecha1.ToShortDateString()} y {fecha2.ToShortDateString()}: {diferencia}")

    'Dim nuevaFecha As Date = CalendarioCalculador.AgregarDias(fecha1, 100)
    'Console.WriteLine($"100 días después del {fecha1.ToShortDateString()}: {nuevaFecha.ToShortDateString()}")

End Namespace
