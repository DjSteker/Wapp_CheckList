Public Class Class_Narrador

    Private Shared SAPIvoice = CreateObject("SAPI.spvoice")   'V
    Private Shared SAPIvoiceToken = CreateObject("SAPI.SpObjectToken")  'T

    Friend Shared Property Volumen() As Int16
        Set(value As Int16)
            SAPIvoice.Volume = value
        End Set
        Get
            Return SAPIvoice.Volume
        End Get
    End Property

    Friend Shared Property Velocidad As Int16
        Set(value As Int16)
            SAPIvoice.Rate = value
        End Set
        Get
            Return SAPIvoice.Rate
        End Get
    End Property

#Region "Voces"

    Friend Shared ReadOnly Property VocesGet As ArrayList
        Get
            Dim VocesRetum As New ArrayList
            Dim Numero As Integer = 0
            For Each Voz In SAPIvoice.GetVoices()
                VocesRetum.Add(Voz.GetDescription())
            Next
            Return VocesRetum
        End Get
    End Property

    Friend Shared WriteOnly Property VocesSet As Integer
        Set(value As Integer)
            SAPIvoice.GetVoices().Item(value)
        End Set
    End Property

    Friend Shared ReadOnly Property VozGet As String
        Get
            '   SAPIvoiceToken = SAPIvoice.AudioOutput
            Return SAPIvoice.Voice.GetDescription()
        End Get
    End Property

#End Region

#Region "Salidas"

    Friend Shared WriteOnly Property AltavozSet As Integer
        Set(value As Integer)
            SAPIvoice.AudioOutput = SAPIvoice.GetAudioOutputs().Item(value)
        End Set
    End Property

    Friend Shared ReadOnly Property AltavozGet As String
        Get
            SAPIvoiceToken = SAPIvoice.AudioOutput
            Return SAPIvoiceToken.GetDescription
        End Get
    End Property

    Friend Shared ReadOnly Property AltavozesGet As ArrayList
        Get
            Dim Lista As New ArrayList
            For Each T In SAPIvoice.GetAudioOutputs
                Lista.Add(T.GetDescription)    'Get description from token
            Next
            Return Lista
        End Get
    End Property

#End Region




    Friend Shared Sub Narra(ByVal Texto As String)
        Try
            SAPIvoice.Speak(Texto)
        Catch ex As Exception

        End Try
    End Sub


End Class
