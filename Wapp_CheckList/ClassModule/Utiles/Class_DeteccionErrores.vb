Public Class Class_DeteccionErrores

#Region "generateCRC"
    'Function generateCRC(data, divisor)
    '    append data with the length of divisor - 1 zeros
    'For Each bit In data
    '        If bit Is 1 Then
    '            data = data Xor divisor
    '            shift data to the right
    'Return data

    'End Function

    'Function verifyCRC(data, divisor, receivedCRC)
    '    append data with receivedCRC
    'For Each bit In data
    '        If bit Is 1 Then
    '            data = data Xor divisor
    '            shift data to the right
    'If data Is 0 Then
    '                Return "No errors"
    '            Else
    '                Return "Error detected"

    ' Este es un ejemplo simplificado de un codificador Reed-Solomon
#End Region




#Region "ReedSolomon"
    'Function ReedSolomonEncode(message As Byte(), n As Integer, k As Integer) As Byte()
    '    Dim generator As Byte() = GenerateGenerator(n, k)
    '    Dim codeword As Byte() = New Byte(n - 1) {}

    '    Array.Copy(message, codeword, message.Length)

    '    For i As Integer = 0 To k - 1
    '        Dim coef As Byte = codeword(i)
    '        If coef <> 0 Then
    '            For j As Integer = 0 To n - k - 1
    '                codeword(i + j) = codeword(i + j) Xor Multiply(generator(j), coef)
    '            Next
    '        End If
    '    Next

    '    Array.Copy(message, codeword, message.Length)

    '    Return codeword
    'End Function

    '' Este es un ejemplo simplificado de un decodificador Reed-Solomon
    'Function ReedSolomonDecode(codeword As Byte(), n As Integer, k As Integer) As Byte()
    '    Dim generator As Byte() = GenerateGenerator(n, k)
    '    Dim syndromes As Byte() = New Byte(n - k - 1) {}
    '    Dim errors As Boolean() = New Boolean(n - 1) {}

    '    For i As Integer = 0 To n - 1
    '        Dim sum As Byte = 0
    '        For j As Integer = 0 To n - k - 1
    '            sum = sum Xor Multiply(generator(j), codeword((i + j) Mod n))
    '        Next
    '        syndromes(i Mod (n - k)) = sum
    '        If sum <> 0 Then
    '            errors(i) = True
    '        End If
    '    Next

    '    Dim message As Byte() = New Byte(k - 1) {}
    '    Array.Copy(codeword, message, k)

    '    For i As Integer = 0 To n - 1
    '        If errors(i) Then
    '            message(i Mod k) = message(i Mod k) Xor syndromes(i Mod (n - k))
    '        End If
    '    Next

    '    Return message
    'End Function
#End Region

#Region "Paridad"

    Private Shared Function GetEncoderInfo(ByVal format As System.Drawing.Imaging.ImageFormat) As System.Drawing.Imaging.ImageCodecInfo
        Dim j As Integer
        Dim encoders() As System.Drawing.Imaging.ImageCodecInfo
        encoders = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()

        j = 0
        While j < encoders.Length
            If encoders(j).FormatID = format.Guid Then
                Return encoders(j)
            End If
            j += 1
        End While
        Return Nothing

    End Function 'GetEncoderInfo

    Public Shared Function CalcularParidad0(data As Byte()) As Boolean
        Dim count = 0
        For i = 0 To data.Length - 1
            If data(i) = 1 Then
                count += 1
            End If
        Next
        Return count Mod 2 = 1
    End Function

    Public Shared Function FrecuenciaParidad0(data As Byte()) As Double
        Dim DatoSalida As Double
        Dim count = 0
        For i = 0 To data.Length - 1
            If data(i) = 1 Then
                count += 1
            End If
        Next
        Dim Paridad As Int16 = count Mod 2 = 1
        If (count Mod 2 = 1) = True Then
            DatoSalida = 1100
        Else
            DatoSalida = 1300
        End If
        Return DatoSalida
    End Function

    Public Shared Function FrecuenciaParidad(data As Byte()) As Double
        Dim count As Integer = 0
        For Each b As Byte In data
            count += Convert.ToString(b, 2).Count(Function(c) c = "1")
        Next
        Dim Paridad As Int16 = count Mod 2 = 0
        Dim DatoSalida As Double
        If (count Mod 2 = 1) = True Then
            DatoSalida = 1100
        Else
            DatoSalida = 1300
        End If
        Return DatoSalida
    End Function

    Public Shared Function CalcularParidad(data As Byte()) As Boolean
        Dim count As Integer = 0
        For Each b As Byte In data
            count += Convert.ToString(b, 2).Count(Function(c) c = "1")
        Next
        Dim Paridad As Int16 = count Mod 2 = 0

        Return count Mod 2 = 0
    End Function

    Public Shared Function CalculateParity2D(data As Byte()()) As Boolean
        Dim countRows = data.Length
        Dim countCols = data(0).Length

        Dim countParityRows = 0
        Dim countParityCols = 0

        For i = 0 To countRows - 1
            countParityRows += CalcularParidad(data(i))
        Next

        For i = 0 To countCols - 1
            countParityCols += CalcularParidad(data.Select(Function(row) row(i)))
        Next

        Return countParityRows Mod 2 = 1 OrElse countParityCols Mod 2 = 1
    End Function

    Public Shared Function VerificarParidad2d(data As Boolean(,)) As Boolean
        Dim rows As Integer = data.GetLength(0)
        Dim cols As Integer = data.GetLength(1)
        For i As Integer = 0 To rows - 1
            Dim count As Integer = 0
            For j As Integer = 0 To cols - 1
                If data(i, j) Then count += 1
            Next
            If count Mod 2 <> 0 Then Return False
        Next
        For j As Integer = 0 To cols - 1
            Dim count As Integer = 0
            For i As Integer = 0 To rows - 1
                If data(i, j) Then count += 1
            Next
            If count Mod 2 <> 0 Then Return False
        Next
        Return True
    End Function

#End Region


End Class
