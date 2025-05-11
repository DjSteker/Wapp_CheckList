Imports WApp_ProcesadoSonido.Data

Class Class_ArchivoEntrenamiento
    Private m_data As List(Of Training)
    Private m_epochs As Integer
    Private m_min_error As Double


    Friend Property data() As List(Of Training)
        Get
            Return m_data
        End Get
        Set(value As List(Of Training))
            m_data = value
        End Set
    End Property
    Friend Property epochs() As Integer
        Get
            Return m_epochs
        End Get
        Set(value As Integer)
            m_epochs = value
        End Set
    End Property
    Friend Property min_error() As Double
        Get
            Return m_min_error
        End Get
        Set(value As Double)
            m_min_error = value
        End Set
    End Property

End Class
