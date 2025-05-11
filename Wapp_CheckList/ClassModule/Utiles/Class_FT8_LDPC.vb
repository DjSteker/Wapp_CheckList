Imports System.Security.Policy
Imports System.Text

Public Class Class_FT8_LDPC







#Region "FT8"



    'LDPC Codificación
    'Paridad de Densidad Baja: LDPC utiliza matrices de paridad esparsas, lo que permite construir códigos con distancias mínimas grandes y mejoras significativas en el rendimiento de corrección de errores.
    'Codificación FEC: La codificación FEC se basa en la adición de redundancia a la secuencia de bits del mensaje. Esto permite detectar y corregir errores en la recepción.
    'Decodificación: La decodificación se realiza mediante algoritmos iterativos de propagación de creencias (Belief Propagation) o sum-product. Estos algoritmos trabajan intercambiando mensajes entre los nodos de verificación y los nodos de variable.



    'Imports System
    '    Imports System.Collections.Generic

    'Public Class FT8Encoder
    Private Const MESSAGE_LENGTH As Integer = 75
    Private Const CRC_LENGTH As Integer = 12

    Public Function EncodeMessage(message As String) As Byte()
        ' Verificar que el mensaje tenga la longitud correcta
        If message.Length <> MESSAGE_LENGTH Then
            Throw New ArgumentException($"El mensaje debe tener {MESSAGE_LENGTH} caracteres.")
        End If

        ' Convertir el mensaje a una lista de bits
        Dim messageBits As New List(Of Boolean)
        For Each c In message
            'Dim bits As Byte() = Convert.ToString(Asc(c), 2).PadLeft(8, "0"c).Select(Function(x) x = "1"c).ToArray()
            Dim bits() As Byte = Convert.ToString(Asc(c), 2).PadLeft(8, "0"c).Select(Function(x) x = "1"c)
            messageBits.AddRange(bits)
        Next



        'For Each c In message : Este bucle itera sobre cada carácter del mensaje de entrada.
        'Dim bits As Byte() = Convert.ToString(Asc(c), 2) : Convierte el valor ASCII del carácter actual a una cadena binaria. Por ejemplo, si el carácter es "A", su valor ASCII es 65,
        'y la cadena binaria sería "1000001".
        '.PadLeft(8, "0"c) : Asegura que la cadena binaria tenga siempre 8 bits, agregando ceros a la izquierda si es necesario. Esto garantiza que cada carácter se represente con 8 bits.
        '.Select(Function(x) x = "1"c).ToArray() : Convierte cada carácter de la cadena binaria a un valor booleano, donde "1" se convierte en True y cualquier otro carácter se convierte en False.
        'Luego, se convierte el resultado a un array de bytes.
        'messageBits.AddRange(bits) : Agrega la secuencia de bits correspondiente al carácter actual a la lista messageBits.
        'En resumen, este fragmento de código convierte cada carácter del mensaje de entrada a una secuencia de 8 bits y
        'los agrega a la lista messageBits. Esto es un paso necesario para la codificación del mensaje utilizando el Código de Redundancia Cíclica (CRC) de 12 bits.






        ' Calcular el CRC de 12 bits
        Dim crc As UInteger = CalculateCRC(messageBits)

        ' Combinar el mensaje y el CRC
        Dim encodedMessage As New List(Of Boolean)
        encodedMessage.AddRange(messageBits)
        encodedMessage.AddRange(GetBits(crc, CRC_LENGTH))

        ' Convertir la lista de bits a un array de bytes
        Dim result(encodedMessage.Count \ 8 - 1) As Byte
        For i As Integer = 0 To result.Length - 1
            result(i) = CByte(encodedMessage.GetRange(i * 8, 8).Aggregate(0, Function(acc, b) acc * 2 + (If(b, 1, 0))))
        Next
        Return result
    End Function

    Private Function CalculateCRC(bits As IEnumerable(Of Boolean)) As UInteger
        Const POLYNOMIAL As UInteger = &HFFF
        Const INITIAL_VALUE As UInteger = &HFFF

        Dim crc As UInteger = INITIAL_VALUE
        For Each bit In bits
            crc = (crc And &H7FFF) * 2 + (If(bit, 1, 0))
            If (crc And &H10000) <> 0 Then
                crc = crc Xor POLYNOMIAL
            End If
        Next

        Return crc And &HFFF
    End Function

    Private Function GetBits(value As UInteger, count As Integer) As IEnumerable(Of Boolean)
        Dim result As New List(Of Boolean)
        For i As Integer = 0 To count - 1
            result.Add((value And (1 << i)) <> 0)
        Next
        Return result
    End Function

    Sub MainFT8()
        Dim message As String = "HELLO WORLD"

        'Dim encoder As New FT8Encoder()
        'Dim encodedMessage As Byte() = encoder.EncodeMessage(Message)

        Dim encodedMessage As Byte() = EncodeMessage(message)

        Console.WriteLine("Mensaje original: " & message)
        Console.Write("Mensaje codificado: ")
        For Each b In encodedMessage
            Console.Write(Convert.ToString(b, 2).PadLeft(8, "0"c) & " ")
        Next
        Console.WriteLine()
    End Sub

#End Region











#Region "LDPCDecoder"


    Private Sub DecodeLDPC()
        ' Paridad de densidad baja
        Dim H As New Dictionary(Of Integer, List(Of Integer))()
        H.Add(0, New List(Of Integer) From {0, 1, 2})
        H.Add(1, New List(Of Integer) From {1, 2, 3})
        H.Add(2, New List(Of Integer) From {0, 2, 3})

        ' Mensaje de entrada
        Dim message As New List(Of Integer) From {0, 1, 0, 1, 1}

        ' Codificación FEC
        Dim encodedMessage As New List(Of Integer)()
        For Each bit In message
            encodedMessage.Add(bit)
            encodedMessage.Add(bit)
        Next

        ' Decodificación
        Dim decodedMessage As New List(Of Integer)()
        For Each bit In encodedMessage
            ' Iterar sobre los nodos de verificación
            For Each checkNode In H
                ' Iterar sobre los nodos de variable
                For Each variableNode In H(checkNode.Key)
                    ' Actualizar la creencia
                    If variableNode = bit Then
                        decodedMessage.Add(bit)
                    End If
                Next
            Next
        Next

        ' Mostrar el mensaje decodificado
        Console.WriteLine("Mensaje decodificado:")
        For Each bit In decodedMessage
            Console.Write(bit & " ")
        Next
        Console.WriteLine()
    End Sub


    Sub Mainioso_LDPC()
        'Dim decoder As New LDPCDecoder()
        'decoder.DecodeLDPC()
        DecodeLDPC()
    End Sub

#End Region
End Class
