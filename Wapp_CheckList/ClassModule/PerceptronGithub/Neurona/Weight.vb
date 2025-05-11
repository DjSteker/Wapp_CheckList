
Namespace Neurons
    Public Class Weight

        Private distance As Double = 0
        Private P As Double = 0
        Private Q_distance As Double = 1.5
        Private R_measure As Double = 5



        'Dim alpha As Double = 0.03 '0.16
        'Dim a0 As Double = (1 - alpha) / 2
        'Dim a1 As Double = 0.9 '0.9
        'Dim a2 As Double = alpha / 2
        'Dim N As Integer = 3
        'Dim x As Double


        Public Property Value As Double
            Get


                Return distance
            End Get
            Set(value1 As Double)
                distance = value1
            End Set
        End Property

        Public Property ValueSet As Double
            Get
                Return distance
            End Get
            Set(value1 As Double)
                ' Q_distance = 10
                'Q_distance = 150
                ' P = (P + (Q_distance * dt))
                P = (P + (Q_distance))
                'estimation error covariance
                'Kalman gain
                Dim S As Double = (P + R_measure)
                Dim K As Double = (P / S)
                'Update whith measurement 
                Dim y As Double = (value1 - distance)
                'Calculate distance

                distance = (distance + (K * y))
                'Dim Diferencia As Double = (distance + (K * y))
                'If Diferencia > Previous < Previous2 < Previous3 Then
                '    distance = (Diferencia + Previous) / 2
                'ElseIf Diferencia < Previous > Previous2 > Previous3 Then
                '    distance = (Diferencia + Previous) / 2
                'Else
                '    distance = Diferencia
                'End If
                'Update the error covariance
                P = (P * (1 - K))

                ' Dim x As Double = 2 * Math.PI * 2 / (N - 1)
                'x = 2 * Math.PI * 2 / (N - 1)
                'Dim w As Double = a0 - a1 * Math.Cos(x) + a2 * Math.Cos(2 * x)
                'distance *= w
                'If Previous < Previous2 < Previous3 Then
                '    'Dim MEdia As Double = (value1 + Previous + Previous2 + Previous3) / 4
                '    distance = distance - ((Previous3 - Previous) / 2)
                'ElseIf Previous > Previous2 > Previous3 Then
                '    'distance = value1
                '    distance = distance + ((Previous - Previous3) / 2)
                '    'Else
                '    'Dim y As Double = (value1 - distance)
                '    'distance = (distance + (K * y))
                'End If
                'Return distance
                'distance = value1
            End Set
        End Property




        Public Property Previous As Double
        Public Property Previous2 As Double
        Public Property Previous3 As Double

        Public Property Child As Neuron
        Public Property Parent As Neuron

        Public Sub New(ByVal value As Double, ByRef parent_node As Neuron, ByRef child_node As Neuron)
            Dim standard As New WApp_ProcesadoSonido.Randoms.Standard(New WApp_ProcesadoSonido.Utilities.Range(-1, 1), DateTime.Now.Millisecond)
            Previous = value
            Previous2 = (standard.Generate() + (value * 2)) / 3
            Previous3 = (standard.Generate() + value) / 2
            Me.Value = value
            Me.Child = child_node
            Me.Parent = parent_node


            'a0 = (1 - 0.16) / 2
            'a1 = 0.5
            'a2 = 1.08
            'x = 2 * Math.PI * 2 / (N - 1)

        End Sub

    End Class
End Namespace
