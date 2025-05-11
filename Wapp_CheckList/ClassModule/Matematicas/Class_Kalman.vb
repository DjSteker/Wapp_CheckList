Public Class Class_Kalman

    Friend Q_distance As Double
    Friend R_measure As Double
    Private distance As Double
    Private P As Double
    Private K As Double
    Private y As Double
    Private S As Double


    Friend Sub New(Optional ByVal Qdistacia As Double = 1, Optional ByVal Rmedida As Double = 10.1)
        MyBase.New
        Q_distance = Qdistacia
        R_measure = Rmedida
        distance = 0
        'reset the distance
        P = 0
        'initial covariance matrix     
    End Sub

    ''' <summary>
    ''' Predice el valor de filtrado
    ''' </summary>
    ''' <param name="newDistance">Entrada del sensor</param>
    ''' <param name="dt">Tiempo desde la ultima lectura en segundos</param>
    ''' <returns>Prediccion del valor de filtrado</returns>
    Friend Function getDistance(ByVal newDistance As Double, ByVal dt As Double) As Double
        ' Q_distance = 2
        'distance=distance; //priori distance
        P = (P + (Q_distance * dt))
        'estimation error covariance
        'Kalman gain
        S = (P + R_measure)
        K = (P / S)
        'Update whith measurement 
        y = (newDistance - distance)
        'Calculate distance
        distance = (distance + (K * y))
        'Update the error covariance
        P = (P * (1 - K))
        Return distance
    End Function


    ''' <summary>
    ''' Set valor de salida, es coeficiente a la vez
    ''' </summary>
    ''' <param name="newDistance"></param>
    Friend Sub setDistance(ByVal newDistance As Double)
        distance = newDistance
    End Sub

    ''' <summary>
    ''' Coeficiente filtro
    ''' </summary>
    ''' <returns></returns>
    Friend Function getQdistance() As Double
        Return Q_distance
    End Function

    ''' <summary>
    ''' ' Coeficiente filtro
    ''' </summary>
    ''' <param name="newQ_distance"></param>
    Friend Sub setQdistance(ByVal newQ_distance As Double)
        Q_distance = newQ_distance
    End Sub

    ''' <summary>
    ''' ' Coeficiente filtro
    ''' </summary>
    ''' <returns></returns>
    Friend Function getRmeasure() As Double
        Return R_measure
    End Function

    ''' <summary>
    ''' ' Coeficiente filtro
    ''' </summary>
    ''' <param name="newR_measure"></param>
    Friend Sub setRmeasure(ByVal newR_measure As Double)
        R_measure = newR_measure
    End Sub



End Class
Public Class KalmanFilter
    Private X As Double ' Estado estimado
    Private P As Double ' Estimación de error
    Private Q As Double ' Ruido del proceso
    Private R As Double ' Ruido de medición
    Private K As Double ' Ganancia de Kalman

    Public Sub New(Q As Double, R As Double)
        Me.Q = Q
        Me.R = R
        X = 0
        P = 1
    End Sub

    Public Function Filter(Z As Double) As Double
        ' Paso de predicción
        P = P + Q

        ' Paso de actualización
        K = P / (P + R)
        X = X + K * (Z - X)
        P = (1 - K) * P

        Return X
    End Function
End Class