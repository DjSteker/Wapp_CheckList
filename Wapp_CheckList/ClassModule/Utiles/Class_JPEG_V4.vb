Imports System.Drawing.Imaging
Imports System.Drawing
Imports Wapp_CheckList.Class_JPEG_3



Public Class Class_JPEG_V4

    Sub CompressImageToJPEG()
        ' Cargar la imagen original
        Dim originalImage As New Bitmap("ruta/al/archivo.bmp")

        ' Dividir la imagen en bloques de 8x8 píxeles
        Dim blockSize As Integer = 8
        Dim numBlocksX As Integer = originalImage.Width \ blockSize
        Dim numBlocksY As Integer = originalImage.Height \ blockSize
        Dim compressedImage As New Bitmap(originalImage.Width, originalImage.Height, PixelFormat.Format24bppRgb)

        For blockX As Integer = 0 To numBlocksX - 1
            For blockY As Integer = 0 To numBlocksY - 1
                ' Obtener el bloque actual
                Dim block(blockSize - 1, blockSize - 1) As Double
                For x As Integer = 0 To blockSize - 1
                    For y As Integer = 0 To blockSize - 1
                        Dim pixelX As Integer = blockX * blockSize + x
                        Dim pixelY As Integer = blockY * blockSize + y
                        Dim pixel As Color = originalImage.GetPixel(pixelX, pixelY)
                        block(x, y) = (pixel.R + pixel.G + pixel.B) / 3
                    Next
                Next

                ' Aplicar la Transformada Discreta del Coseno (DCT)
                ApplyDCT(block)

                ' Cuantizar los coeficientes de la DCT
                QuantizeCoefficients(block)

                ' Codificar los coeficientes cuantizados usando Huffman
                Dim huffmanEncoded As Byte() = EncodeHuffman(block)

                ' Asignar los píxeles codificados a la imagen comprimida
                For x As Integer = 0 To blockSize - 1
                    For y As Integer = 0 To blockSize - 1
                        Dim pixelX As Integer = blockX * blockSize + x
                        Dim pixelY As Integer = blockY * blockSize + y
                        compressedImage.SetPixel(pixelX, pixelY, Color.FromArgb(huffmanEncoded(x * blockSize + y), huffmanEncoded(x * blockSize + y), huffmanEncoded(x * blockSize + y)))
                    Next
                Next
            Next
        Next

        ' Guardar la imagen comprimida
        compressedImage.Save("ruta/al/archivo.jpg", ImageFormat.Jpeg)
    End Sub

    'Sub ApplyDCT(ByRef block(,) As Double)
    '    ' Implementar la Transformada Discreta del Coseno (DCT)
    '    ' ...
    'End Sub

    'Sub ApplyDCT(ByRef block(,) As Double)
    '    ' Implementar la Transformada Discreta del Coseno (DCT)
    '    ' ...

    '    ' Inicializar los coeficientes de la DCT
    '    Dim dctCoefficients(block.Length - 1, block(0).Length - 1) As Double

    '    ' Aplicar la DCT a cada bloque
    '    For x As Integer = 0 To block.Length - 1
    '        For y As Integer = 0 To block(0).Length - 1
    '            ' Calcular los coeficientes de la DCT
    '            dctCoefficients(x, y) = block(x, y) * Math.Cos((x * Math.PI) / (block.Length - 1)) * Math.Cos((y * Math.PI) / (block(0).Length - 1))
    '        Next
    '    Next

    '    ' Devolver los coeficientes de la DCT
    '    Return dctCoefficients
    'End Sub
    'Sub ApplyDCT(ByRef block(,) As Double)
    '    ' Inicializar los coeficientes de la DCT
    '    Dim dctCoefficients(block.Length - 1, block(0).Length - 1) As Double

    '    ' Aplicar la DCT a cada bloque
    '    For x As Integer = 0 To block.Length - 1
    '        For y As Integer = 0 To block(0).Length - 1
    '            ' Calcular los coeficientes de la DCT
    '            dctCoefficients(x, y) = block(x, y) * Math.Cos((x * Math.PI) / (block.Length - 1)) * Math.Cos((y * Math.PI) / (block(0).Length - 1))
    '        Next
    '    Next

    '    ' Devolver los coeficientes de la DCT
    '    Return dctCoefficients
    'End Sub

    Sub ApplyDCT(ByRef block(,) As Double)
        ' Definir las constantes para la DCT
        Const DCT_SIZE As Integer = 8
        Const DCT_COEFFICIENTS As Integer = 64

        ' Crear un array para almacenar los coeficientes de la DCT
        Dim dctCoefficients(DCT_SIZE - 1, DCT_SIZE - 1) As Double

        ' Calcular los coeficientes de la DCT
        For x As Integer = 0 To DCT_SIZE - 1
            For y As Integer = 0 To DCT_SIZE - 1
                ' Calcular el valor de cada coeficiente
                dctCoefficients(x, y) = block(x, y) * Math.Cos((2 * x + 1) * Math.PI / (2 * DCT_SIZE)) * Math.Cos((2 * y + 1) * Math.PI / (2 * DCT_SIZE))
            Next
        Next

        ' Asignar los coeficientes de la DCT al bloque original
        For x As Integer = 0 To DCT_SIZE - 1
            For y As Integer = 0 To DCT_SIZE - 1
                block(x, y) = dctCoefficients(x, y)
            Next
        Next
    End Sub
    'Sub QuantizeCoefficients(ByRef block(,) As Double)
    '    ' Implementar la cuantización de los coeficientes de la DCT
    '    ' ...
    'End Sub

    Sub QuantizeCoefficients(ByRef block(,) As Double)
        ' Definir las constantes para la cuantización
        Dim QUANTIZATION_TABLE As Double() = {16, 11, 10, 16, 24, 40, 51, 61, 12, 12, 14, 19, 26, 58, 60, 55, 69, 56, 64, 72, 80, 80, 79, 72, 58, 51, 46, 15, 16, 24, 40, 52, 61, 60, 55, 69, 56, 64, 72, 80, 80, 79, 72, 58, 51, 46, 15, 16, 24, 40, 52, 61, 60, 55, 69, 56, 64, 72, 80, 80, 79, 72, 58, 51, 46, 15}

        ' Cuantizar los coeficientes de la DCT
        For x As Integer = 0 To block.Length - 1
            For y As Integer = 0 To block.Length - 1
                ' Calcular el valor cuantizado
                block(x, y) = Math.Round(block(x, y) / QUANTIZATION_TABLE(x * block.Length + y))
            Next
        Next
    End Sub

    'Sub QuantizeCoefficients(ByRef block(,) As Double)
    '    ' Utilizar la biblioteca Accord.NET para cuantizar los coeficientes de la DCT
    '    Dim quantizer As New Quantizer(block)
    '    Dim quantizedBlock As Double() = quantizer.Quantize(block)

    '    ' Devolver los coeficientes cuantizados
    '    Return quantizedBlock
    'End Sub

    'Function EncodeHuffman(block(,) As Double) As Byte()
    '    ' Implementar la codificación de Huffman de los coeficientes cuantizados
    '    ' ...
    '    Return New Byte() {}
    'End Function
    Function EncodeHuffman(block(,) As Double) As Byte()
        ' Crear una lista de pares de coeficiente y frecuencia
        Dim frequencyList As New List(Of Tuple(Of Double, Integer))
        For x As Integer = 0 To block.Length - 1
            For y As Integer = 0 To block.Length - 1
                Dim coefficient As Double = block(x, y)
                Dim frequency As Integer = 0
                For i As Integer = 0 To frequencyList.Count - 1
                    If frequencyList(i).Item1 = coefficient Then
                        frequency = frequencyList(i).Item2
                        Exit For
                    End If
                Next
                frequencyList.Add(New Tuple(Of Double, Integer)(coefficient, frequency + 1))
            Next
        Next

        ' Crear una tabla de Huffman
        Dim huffmanTable As New Dictionary(Of Double, String)
        Dim huffmanCodes As New Dictionary(Of Double, String)
        For i As Integer = 0 To frequencyList.Count - 1
            Dim coefficient As Double = frequencyList(i).Item1
            Dim code As String = ""
            For j As Integer = 0 To frequencyList.Count - 1
                If frequencyList(j).Item1 = coefficient Then
                    code += "0"
                    Exit For
                End If
            Next
            huffmanTable.Add(coefficient, code)
            huffmanCodes.Add(coefficient, code)
        Next

        ' Codificar los coeficientes cuantizados utilizando Huffman
        Dim encodedBlock As Byte() = New Byte(block.Length * block.Length - 1) {}
        For x As Integer = 0 To block.Length - 1
            For y As Integer = 0 To block.Length - 1
                Dim coefficient As Double = block(x, y)
                Dim code As String = huffmanTable(coefficient)
                For i As Integer = 0 To code.Length - 1
                    If code(i) = "0" Then
                        encodedBlock(x * block.Length + y) = 0
                    Else
                        encodedBlock(x * block.Length + y) = 1
                    End If
                Next
            Next
        Next

        ' Devolver el bloque codificado
        Return encodedBlock
    End Function

End Class
