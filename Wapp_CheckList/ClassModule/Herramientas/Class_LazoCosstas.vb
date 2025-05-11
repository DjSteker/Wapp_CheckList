
Imports System.Math

Public Class Class_LazoCosstas
    Private phaseEstimate As Double
    Private loopGain As Double
    Private frequencyOffset As Double
    Private samplingRate As Double

    Public Sub New(loopGain As Double, frequencyOffset As Double, samplingRate As Double)
        Me.phaseEstimate = 0.0
        Me.loopGain = loopGain
        Me.frequencyOffset = frequencyOffset
        Me.samplingRate = samplingRate
    End Sub

    Public Function Demodulate(inputSample As Double) As Double
        ' Implementación del lazo de Costas
        Dim errorTerm As Double = Sin(phaseEstimate) * inputSample - Cos(phaseEstimate) * inputSample
        phaseEstimate += loopGain * errorTerm

        ' Corrección de la frecuencia de portadora
        phaseEstimate += 2 * PI * frequencyOffset / samplingRate

        ' Asegurar que la fase esté en el rango [0, 2*PI]
        If phaseEstimate > 2 * PI Then
            phaseEstimate -= 2 * PI
        ElseIf phaseEstimate < 0 Then
            phaseEstimate += 2 * PI
        End If

        Return errorTerm ' Puedes devolver la señal demodulada o el error según tus necesidades
    End Function


    Sub Main()
        ' Parámetros del lazo de Costas
        Dim loopGain As Double = 0.01 ' Ajusta según tus necesidades
        Dim frequencyOffset As Double = 0.0 ' Frecuencia de portadora offset
        Dim samplingRate As Double = 1000.0 ' Tasa de muestreo en Hz

        ' Crear un objeto CostasLoop
        Dim costasLoop As New Class_LazoCosstas(loopGain, frequencyOffset, samplingRate)

        ' Ejemplo de uso con una señal de entrada (puedes reemplazar con tus propios datos)
        Dim numSamples As Integer = 1000
        Dim inputSignal(numSamples - 1) As Double
        ' Rellenar inputSignal con tu señal de entrada

        ' Procesar la señal a través del lazo de Costas
        For i As Integer = 0 To numSamples - 1
            Dim demodulatedSignal As Double = costasLoop.Demodulate(inputSignal(i))
            ' Haz algo con la señal demodulada (o el error) aquí
        Next

    End Sub

End Class
