Public Class Class_PIDController

    Friend _Kp As Double
    Friend _Ki As Double
    Friend _Kd As Double
    Friend _integral As Double
    Friend _previousError As Double
    Friend _integralLimit As Double

    Private _Kcu As Double
    Private _tu As Double
    Private _lastTime As DateTime


    Public Sub New(Kp As Double, Ki As Double, Kd As Double)
        _Kp = Kp
        _Ki = Ki
        _Kd = Kd
        _integral = 0
        _previousError = 0
        _integralLimit = 16384
    End Sub

    Public Function Update(error_ As Double, deltaTime_ As Double) As Double
        Dim output As Double
        Dim derivative As Double

        _integral += error_ * deltaTime_
        If _integral > _integralLimit Then _integral = _integralLimit
        If _integral < -_integralLimit Then _integral = -_integralLimit

        derivative = (error_ - _previousError) / deltaTime_

        output = _Kp * error_ + _Ki * _integral + _Kd * derivative

        _previousError = error_

        Return output
    End Function

    Public Function Calculate(ByVal setpoint As Double, ByVal processVariable As Double) As Double
        Dim error_ As Double = setpoint - processVariable
        Dim derivative As Double = error_ - _previousError
        _previousError = error_
        Dim currentTime As DateTime = DateTime.Now
        Dim timeDifference As TimeSpan = currentTime - _lastTime
        _lastTime = currentTime
        If (error_ > 0 And _previousError < 0) Or (error_ < 0 And _previousError > 0) Then
            _Kcu = 4 * error_ / (Math.PI * processVariable)
            _tu = timeDifference.TotalSeconds
        End If
        _integral += error_
        Return _Kp * error_ + _Ki * _integral + _Kd * derivative
    End Function
End Class
