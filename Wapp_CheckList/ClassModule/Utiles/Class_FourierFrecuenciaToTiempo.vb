
'Imports System.Numerics

Public Class Class_FourierFrecuenciaToTiempo
    'Public Shared Function IFT(ByVal signal As Complex()) As Double()
    '    Dim N_Length As Integer = signal.Length
    '    Dim result(N_Length - 1) As Double

    '    For n As Integer = 0 To N_Length - 1
    '        Dim sum As Complex = 0

    '        For k As Integer = 0 To N_Length - 1
    '            sum += signal(k) * Complex.Exp(Complex.ImaginaryOne * 2 * Math.PI * k * n / N_Length)
    '        Next

    '        result(n) = sum.Real / N_Length
    '    Next

    '    Return result
    'End Function
    Public Shared Function IFT(ByVal signal As Double()) As Double()
        Dim N_Length As Integer = signal.Length
        Dim result(N_Length - 1) As Double

        For n As Integer = 0 To N_Length - 1
            Dim sum As Double = 0

            For k As Integer = 0 To N_Length - 1
                sum += signal(k) * Math.Cos(2 * Math.PI * k * n / N_Length) - signal(k) * Math.Sin(2 * Math.PI * k * n / N_Length)
            Next

            result(n) = sum / N_Length
        Next

        Return result
    End Function
End Class