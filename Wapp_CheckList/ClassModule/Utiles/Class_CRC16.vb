Public Class Class_CRC16


    Shared table As UShort()

    Shared Sub New()
        Dim poly As UShort = &HA001US ' Calcula el CRC-16 usando el polinomio A001 (Modbus)
        table = New UShort(255) {}
        Dim temp As UShort = 0

        For i As UShort = 0 To table.Length - 1
            temp = i
            For j As Integer = 8 To 1 Step -1
                If (temp And 1) = 1 Then
                    temp = CUShort((temp >> 1) Xor poly)
                Else
                    temp >>= 1
                End If
            Next
            table(i) = temp
        Next
    End Sub

    Public Shared Function ComputeChecksum(ByVal bytes As Byte()) As UShort
        Dim crc As UShort = &H0US ' El cálculo comienza con 0x00
        For i As Integer = 0 To bytes.Length - 1
            Dim index As Byte = CByte(((crc) And &HFF) Xor bytes(i))
            crc = CUShort((crc >> 8) Xor table(index))
        Next
        Return crc
    End Function


    Public Shared Function ValidateMessage(ByVal receivedBytes As Byte()) As Boolean
        ' Supongamos que los primeros n-2 bytes son los datos del mensaje y los últimos 2 bytes son el CRC.
        Dim messageDataLength As Integer = receivedBytes.Length - 2
        Dim messageData(messageDataLength - 1) As Byte
        Array.Copy(receivedBytes, messageData, messageDataLength)

        Dim receivedCRC As UShort = BitConverter.ToUInt16(receivedBytes, messageDataLength)
        Dim calculatedCRC As UShort = Class_CRC16.ComputeChecksum(messageData)

        Return receivedCRC = calculatedCRC
    End Function

End Class
