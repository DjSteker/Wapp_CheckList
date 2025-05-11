
Public Class Class_FeedForwardController
    Private _gain As Double
    Private _feedbackGain As Double
    Private _SeñaDeseada As Double
    Private _SeñalEntrada As Double
    Friend _SeñalAnterior As Double

    ''' <summary>
    ''' Establecer la ganancia del controlador FeedForward
    ''' </summary>
    ''' <param name="gain">Ganancia del procesador</param>
    Public Sub New(gain As Double)
        _gain = gain
    End Sub

    ''' <summary>
    ''' Calcular la señal de control FeedForward
    ''' </summary>
    ''' <param name="perturbation">perturbación medida</param>
    ''' <returns>u(t) = Gf(s) ⋅ d(t)</returns>
    Public Function CalculateControl(perturbation As Double) As Double
        Return _gain * perturbation
    End Function

    Public Function MeasureError() As Double
        '  error de seguimiento
        Return _SeñaDeseada - _SeñalEntrada
    End Function
    Public Function MeasurePerturbation() As Double
        '  perturbación en el sistema
        Return _SeñalAnterior - _SeñalEntrada
    End Function
    ''' <summary>
    ''' Establecer las ganancias del controlador FeedForward y de retroalimentación
    ''' </summary>
    ''' <param name="feedForwardGain"></param>
    ''' <param name="feedbackGain"></param>
    Public Sub New(feedForwardGain As Double, feedbackGain As Double)
        _gain = feedForwardGain
        _feedbackGain = feedbackGain
    End Sub

    ''' <summary>
    ''' Calcular la señal de control combinando FeedForward y retroalimentación
    ''' </summary>
    ''' <param name="perturbation">error de seguimiento, que es la diferencia entre la salida deseada y la salida actual del sistema</param>
    ''' <param name="error_">error de seguimiento, que es la diferencia entre la salida deseada y la salida actual del sistema</param>
    ''' <returns>u(t) = Gf(s) ⋅ d(t) + Gc(s) ⋅ e(t)</returns>
    Public Function CalculateControl(perturbation As Double, error_ As Double) As Double
        Return _gain * perturbation + _feedbackGain * error_
    End Function

    Public Function Procesar(ByVal SeñalDesada As Double, ByVal SeñalLectura As Double) As Double
        _SeñaDeseada = SeñalDesada
        _SeñalEntrada = SeñalLectura
        Return CalculateControl(MeasurePerturbation, MeasureError)
        _SeñalAnterior = SeñalLectura
    End Function
End Class

Public Class FeedForwardController2
    Private _feedForwardGain As Double
    Private _feedbackGain As Double
    Private _desiredSignal As Double
    Private _inputSignal As Double
    Friend _previousSignal As Double

    Public Sub New(feedForwardGain As Double, feedbackGain As Double)
        ' Establecer las ganancias del controlador FeedForward y de retroalimentación
        _feedForwardGain = feedForwardGain
        _feedbackGain = feedbackGain
    End Sub

    Public Function CalculateControl(perturbation As Double, error_ As Double) As Double
        ' Calcular la señal de control combinando FeedForward y retroalimentación
        Return _feedForwardGain * perturbation + _feedbackGain * error_
    End Function

    Public Function MeasureError() As Double
        ' Error de seguimiento
        Return _desiredSignal - _inputSignal
    End Function

    Public Function MeasurePerturbation() As Double
        ' Perturbación en el sistema
        Return _previousSignal - _inputSignal
    End Function

    Public Function Process(ByVal desiredSignal As Double, ByVal inputSignal As Double) As Double
        _desiredSignal = desiredSignal
        _inputSignal = inputSignal
        Return CalculateControl(MeasurePerturbation(), MeasureError())
        _previousSignal = inputSignal
    End Function
End Class