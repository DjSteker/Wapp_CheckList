

Public Class Class_PhaseVocoder
    Private numSamples As Integer
    Private samples As Double()

    Public Sub New(samples As Double())
        numSamples = samples.Length
        Me.samples = samples
    End Sub

    Public Function ChangeFrequency(frequency As Double, newFrequency As Double) As Double()
        Dim newSamples = New Double(numSamples - 1) {}
        For n = 0 To numSamples - 1
            newSamples(n) = samples(CInt(n * newFrequency / frequency) Mod numSamples)
        Next
        Return newSamples
    End Function

End Class

Public Class Class_PhaseVocoderShort
    Private numSamples As Integer
    Private samples As Short()

    Public Sub New(samples As Short())
        numSamples = samples.Length
        Me.samples = samples
    End Sub

    Public Function ChangeFrequency(frequency As Short, newFrequency As Double) As Short()
        Dim newSamples = New Short(numSamples - 1) {}
        For n = 0 To numSamples - 1
            Dim NumeSampler As UInteger = CInt(n * newFrequency / frequency) Mod numSamples
            newSamples(n) = samples(CInt(n * newFrequency / frequency) Mod numSamples)
        Next
        Return newSamples
    End Function

End Class