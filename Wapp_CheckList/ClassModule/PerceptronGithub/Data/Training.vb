Namespace Data
    Public Class Training
        Public Property Entrada As List(Of Double)
        Public Property Salida As List(Of Double)

        Public Sub New()
            Me.Entrada = New List(Of Double)
            Me.Salida = New List(Of Double)
        End Sub

        Public Sub New(ByVal input As IEnumerable(Of Double), ByVal output As IEnumerable(Of Double))
            Me.Entrada = New List(Of Double)
            Me.Salida = New List(Of Double)
            Me.Entrada.AddRange(input)
            Me.Salida.AddRange(output)
        End Sub

    End Class
End Namespace
