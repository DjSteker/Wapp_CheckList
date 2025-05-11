Imports WApp_ProcesadoSonido.Activation
Imports WApp_ProcesadoSonido.Utilities

Namespace Data
    Public Class Processor

        Public Property InputRange As Range
        Public Property OutputRange As Range

        Public Sub New(ByRef input_function As BaseActivation, ByRef output_function As BaseActivation)


        End Sub

        Public Function PreProcess(ByVal data As List(Of Training)) As List(Of Training)
            Dim result = New List(Of Training)
            For Each item In data
                Dim temp As New Training()
                For Each entry In item.Entrada
                    temp.Entrada.Add(entry / InputRange.Delta + InputRange.Minimum)
                Next

                For Each entry In item.Salida
                    temp.Salida.Add(entry / OutputRange.Delta + OutputRange.Minimum)
                Next
            Next
            Return result
        End Function

    End Class
End Namespace
