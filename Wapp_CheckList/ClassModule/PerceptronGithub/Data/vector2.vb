Class vector2
    Dim m_X As Integer
    Dim m_Y As Integer
    Friend Property X() As String
        Get
            Return m_X
        End Get
        Set(value As String)
            m_X = value
        End Set
    End Property
    Friend Property Y() As String
        Get
            Return m_Y
        End Get
        Set(value As String)
            m_Y = value
        End Set
    End Property
End Class
