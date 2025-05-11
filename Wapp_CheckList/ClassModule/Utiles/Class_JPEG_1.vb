


Imports System.Drawing


Public Class Class_JPEG_1


    ' Función para convertir RGB a YCbCr
    'Function RGBtoYCbCr(R As Byte, G As Byte, B As Byte) As (Y As Byte, Cb As Byte, Cr As Byte)
    '    Dim Y As Double = 0.299 * R + 0.587 * G + 0.114 * B
    '    Dim Cb As Double = -0.1687 * R - 0.3313 * G + 0.5 * B + 128
    '    Dim Cr As Double = 0.5 * R - 0.4187 * G - 0.0813 * B + 128

    '    Y = Math.Max(0, Math.Min(255, Y))
    '    Cb = Math.Max(0, Math.Min(255, Cb))
    '    Cr = Math.Max(0, Math.Min(255, Cr))

    '    Return (CByte(Y), CByte(Cb), CByte(Cr))
    'End Function

    '' Función para dividir la imagen en bloques de 8x8 píxeles
    'Sub DividirEnBloques8x8(ByVal bmp As Bitmap, ByRef bloques(,) As Double(,))
    '    Dim ancho As Integer = bmp.Width
    '    Dim alto As Integer = bmp.Height
    '    Dim bloquesX As Integer = ancho \ 8
    '    Dim bloquesY As Integer = alto \ 8

    '    ReDim bloques(bloquesX - 1, bloquesY - 1)

    '    For y As Integer = 0 To bloquesY - 1
    '        For x As Integer = 0 To bloquesX - 1
    '            Dim bloque(7, 7) As Double
    '            For j As Integer = 0 To 7
    '                For i As Integer = 0 To 7
    '                    Dim pixel As Color = bmp.GetPixel(x * 8 + i, y * 8 + j)
    '                    'Dim (y, _, _) = RGBtoYCbCr(pixel.R, pixel.G, pixel.B)
    '                    Dim y(,,) = RGBtoYCbCr(pixel.R, pixel.G, pixel.B)
    '                    bloque(i, j) = y
    '                Next
    '            Next
    '            bloques(x, y) = bloque
    '        Next
    '    Next
    'End Sub


    ' Ejemplo de uso
    Sub Main2()
        Dim bmp As New Bitmap("ruta/a/tu/imagen.jpg")
        'Dim bloques(,) As Double(,)
        Dim bloques(,) As (Y As Byte, Cb As Byte, Cr As Byte)
        DividirEnBloques8x8(bmp, bloques)

        Dim matrizCuantizacion(,) As Integer = {
{16, 11, 10, 16, 24, 40, 51, 61},
{12, 12, 14, 19, 26, 58, 60, 55},
{14, 13, 16, 24, 40, 57, 69, 56},
{14, 17, 22, 29, 51, 87, 80, 62},
{18, 22, 37, 56, 68, 109, 103, 77},
{24, 35, 55, 64, 81, 104, 113, 92},
{49, 64, 78, 87, 103, 121, 120, 101},
{72, 92, 95, 98, 112, 100, 103, 99}
}

        For Each bloque In bloques

            'Dim dct As (Y As Byte, Cb As Byte, Cr As Byte)(,) = DCT8x8(bloque)
            'Dim cuantizado As Integer(,) = CuantizarDCT(dct, matrizCuantizacion)
            'Dim codigosHuffman As Dictionary(Of Integer, String) = CodificarHuffman(cuantizado)
            ' Aquí puedes guardar o procesar los códigos Huffman

        Next
    End Sub

    Function RGBtoYCbCr(R As Byte, G As Byte, B As Byte) As (Y As Byte, Cb As Byte, Cr As Byte) 'As List(Of Tuple(Of (CByte(Y), CByte(Cb), CByte(Cr)), Integer)) 
        Dim Y As Double
        Dim Cb As Double
        Dim Cr As Double

        ' Conversión de RGB a YCbCr
        Y = 0.299 * R + 0.587 * G + 0.114 * B
        Cb = -0.1687 * R - 0.3313 * G + 0.5 * B + 128
        Cr = 0.5 * R - 0.4187 * G - 0.0813 * B + 128

        ' Asegurarse de que los valores estén en el rango de 0 a 255
        Y = Math.Max(0, Math.Min(255, Y))
        Cb = Math.Max(0, Math.Min(255, Cb))
        Cr = Math.Max(0, Math.Min(255, Cr))

        Return (CByte(Y), CByte(Cb), CByte(Cr))
    End Function

    Sub DividirEnBloques8x8(ByVal bmp As Bitmap, ByRef Bloques1 As (Y As Byte, Cb As Byte, Cr As Byte)(,))
        Dim ancho As Integer = bmp.Width
        Dim alto As Integer = bmp.Height

        For y As Integer = 0 To alto - 1 Step 8
            For x As Integer = 0 To ancho - 1 Step 8
                ' Procesar cada bloque de 8x8 píxeles
                For j As Integer = 0 To 7
                    For i As Integer = 0 To 7
                        If x + i < ancho And y + j < alto Then
                            Dim pixel As Color = bmp.GetPixel(x + i, y + j)
                            ' Aquí puedes realizar operaciones con cada píxel del bloque

                            'Dim pixel As Color = bmp.GetPixel(x * 8 + i, y * 8 + j)
                            'Dim (y, _, _) = RGBtoYCbCr(pixel.R, pixel.G, pixel.B)
                            Dim y1 As (Y As Byte, Cb As Byte, Cr As Byte) = RGBtoYCbCr(pixel.R, pixel.G, pixel.B)
                            Bloques1(i, j) = y1


                        End If
                    Next
                Next
            Next
        Next
    End Sub


    ' Función para aplicar la DCT a un bloque de 8x8
    Function DCT8x8(block(,) As (Y As Byte, Cb As Byte, Cr As Byte)) As (Y As Byte, Cb As Byte, Cr As Byte)(,)
        Dim N As Integer = 8
        Dim dct(N - 1, N - 1) As (Y As Byte, Cb As Byte, Cr As Byte)
        Dim ci, cj, sum_Y, sum_Cb, sum_Cr As Double
        Dim pi As Double = Math.PI

        For u As Integer = 0 To N - 1
            For v As Integer = 0 To N - 1
                If u = 0 Then
                    ci = 1 / Math.Sqrt(N)
                Else
                    ci = Math.Sqrt(2) / Math.Sqrt(N)
                End If
                If v = 0 Then
                    cj = 1 / Math.Sqrt(N)
                Else
                    cj = Math.Sqrt(2) / Math.Sqrt(N)
                End If

                sum_Y = 0
                sum_Cb = 0
                sum_Cr = 0
                For x As Integer = 0 To N - 1
                    For y As Integer = 0 To N - 1
                        sum_Y += block(x, y).Y * Math.Cos((2 * x + 1) * u * pi / (2 * N)) * Math.Cos((2 * y + 1) * v * pi / (2 * N))
                        sum_Cb += block(x, y).Cb * Math.Cos((2 * x + 1) * u * pi / (2 * N)) * Math.Cos((2 * y + 1) * v * pi / (2 * N))
                        sum_Cr += block(x, y).Cr * Math.Cos((2 * x + 1) * u * pi / (2 * N)) * Math.Cos((2 * y + 1) * v * pi / (2 * N))
                    Next
                Next

                dct(u, v).Y = ci * cj * sum_Y
                dct(u, v).Cb = ci * cj * sum_Cb
                dct(u, v).Cr = ci * cj * sum_Cr
            Next
        Next

        Return dct
    End Function

    ' Función para cuantizar los coeficientes DCT
    Function CuantizarDCT(dct(,) As (Y As Byte, Cb As Byte, Cr As Byte), matrizCuantizacion(,) As Integer) As Integer(,)
        Dim N As Integer = 8
        Dim cuantizado(N - 1, N - 1) As Integer

        For i As Integer = 0 To N - 1
            For j As Integer = 0 To N - 1
                cuantizado(i, j) = CInt(Math.Round(dct(i, j).Y / matrizCuantizacion(i, j)))
                cuantizado(i, j) = CInt(Math.Round(dct(i, j).Cb / matrizCuantizacion(i, j)))
                cuantizado(i, j) = CInt(Math.Round(dct(i, j).Cr / matrizCuantizacion(i, j)))
            Next
        Next

        Return cuantizado
    End Function

    ' Función para construir el árbol de Huffman
    Function ConstruirArbolHuffman(frequencies As Dictionary(Of Integer, Integer)) As HuffmanNode
        Dim priorityQueue As New SortedList(Of Integer, HuffmanNode)

        For Each kvp In frequencies
            priorityQueue.Add(kvp.Value, New HuffmanNode(kvp.Key, kvp.Value))
        Next

        While priorityQueue.Count > 1
            Dim left As HuffmanNode = priorityQueue.Values(0)
            priorityQueue.RemoveAt(0)
            Dim right As HuffmanNode = priorityQueue.Values(0)
            priorityQueue.RemoveAt(0)

            Dim newNode As New HuffmanNode(-1, left.Frequency + right.Frequency)
            newNode.Left = left
            newNode.Right = right
            priorityQueue.Add(newNode.Frequency, newNode)
        End While

        Return priorityQueue.Values(0)
    End Function

    ' Función para generar los códigos de Huffman
    Sub GenerarCodigosHuffman(node As HuffmanNode, prefix As String, codes As Dictionary(Of Integer, String))
        If node Is Nothing Then Return

        If node.Left Is Nothing AndAlso node.Right Is Nothing Then
            codes(node.Symbol) = prefix
        Else
            GenerarCodigosHuffman(node.Left, prefix & "0", codes)
            GenerarCodigosHuffman(node.Right, prefix & "1", codes)
        End If
    End Sub

    ' Función principal para codificar los coeficientes DCT cuantizados
    Function CodificarHuffman(coeficientes As Integer(,)) As Dictionary(Of Integer, String)
        Dim frequencies As New Dictionary(Of Integer, Integer)

        For Each coef In coeficientes
            If Not frequencies.ContainsKey(coef) Then
                frequencies(coef) = 0
            End If
            frequencies(coef) += 1
        Next

        Dim root As HuffmanNode = ConstruirArbolHuffman(frequencies)
        Dim codes As New Dictionary(Of Integer, String)
        GenerarCodigosHuffman(root, "", codes)

        Return codes
    End Function

    ' Clase para el nodo del árbol de Huffman
    Class HuffmanNode
        Public Property Symbol As Integer
        Public Property Frequency As Integer
        Public Property Left As HuffmanNode
        Public Property Right As HuffmanNode

        Public Sub New(symbol As Integer, frequency As Integer)
            Me.Symbol = symbol
            Me.Frequency = frequency
            Me.Left = Nothing
            Me.Right = Nothing
        End Sub
    End Class







    Sub MainJPEG1()
        ' Ejemplo de datos de imagen (una fila de píxeles)
        Dim imageData As Byte() = {255, 255, 255, 0, 0, 0, 0, 255, 255, 255, 255, 0}

        ' Comprimir los datos usando RLE
        Dim compressedData As List(Of Tuple(Of Byte, Integer)) = RLECompress(imageData)

        ' Mostrar los datos comprimidos
        For Each item In compressedData
            Console.WriteLine("Valor: " & item.Item1 & ", Repeticiones: " & item.Item2)
        Next

        Console.ReadLine()
    End Sub

    Function RLECompress(data As Byte()) As List(Of Tuple(Of Byte, Integer))
        Dim compressed As New List(Of Tuple(Of Byte, Integer))()
        Dim count As Integer = 1

        For i As Integer = 1 To data.Length - 1
            If data(i) = data(i - 1) Then
                count += 1
            Else
                compressed.Add(New Tuple(Of Byte, Integer)(data(i - 1), count))
                count = 1
            End If
        Next

        ' Añadir el último grupo
        compressed.Add(New Tuple(Of Byte, Integer)(data(data.Length - 1), count))

        Return compressed
    End Function


End Class










'El algoritmo de compresión JPEG es una técnica ampliamente utilizada para reducir el tamaño de los archivos de imágenes sin perder demasiada calidad visual. Aquí tienes un resumen de cómo funciona:

'Conversión de color: La imagen se convierte del espacio de color RGB al espacio de color YCbCr, que separa la información de luminancia (Y) de la crominancia (Cb y Cr).
'División en bloques: La imagen se divide en bloques de 8x8 píxeles. Esto facilita la aplicación de la compresión.
'Transformada Discreta del Coseno (DCT): Cada bloque de 8x8 se transforma usando la DCT, que convierte los valores de píxeles en frecuencias. Esto ayuda a identificar las partes de la imagen que son más importantes para la percepción visual.
'Cuantización: Las frecuencias obtenidas se cuantizan, es decir, se redondean a valores más simples. Este paso es donde se pierde la mayor parte de la información, pero también es el que más reduce el tamaño del archivo.
'Codificación: Los valores cuantizados se codifican usando técnicas como la codificación de Huffman, que reduce aún más el tamaño del archivo al eliminar redundancias.
'Almacenamiento: Finalmente, los datos comprimidos se almacenan en el formato JPEG.

'Function RGBtoYCbCr(R As Byte, G As Byte, B As Byte) As (Y As Byte, Cb As Byte, Cr As Byte)
'    Dim Y As Double
'    Dim Cb As Double
'    Dim Cr As Double

'    ' Conversión de RGB a YCbCr
'    Y = 0.299 * R + 0.587 * G + 0.114 * B
'    Cb = -0.1687 * R - 0.3313 * G + 0.5 * B + 128
'    Cr = 0.5 * R - 0.4187 * G - 0.0813 * B + 128

'    ' Asegurarse de que los valores estén en el rango de 0 a 255
'    Y = Math.Max(0, Math.Min(255, Y))
'    Cb = Math.Max(0, Math.Min(255, Cb))
'    Cr = Math.Max(0, Math.Min(255, Cr))

'    Return (CByte(Y), CByte(Cb), CByte(Cr))
'End Function

'Sub DividirEnBloques8x8(ByVal bmp As Bitmap)
'    Dim ancho As Integer = bmp.Width
'    Dim alto As Integer = bmp.Height

'    For y As Integer = 0 To alto - 1 Step 8
'        For x As Integer = 0 To ancho - 1 Step 8
'            ' Procesar cada bloque de 8x8 píxeles
'            For j As Integer = 0 To 7
'                For i As Integer = 0 To 7
'                    If x + i < ancho And y + j < alto Then
'                        Dim pixel As Color = bmp.GetPixel(x + i, y + j)
'                        ' Aquí puedes realizar operaciones con cada píxel del bloque
'                    End If
'                Next
'            Next
'        Next
'    Next
'End Sub


'Function DCT8x8(block(,) As Double) As Double(,)
'    Dim N As Integer = 8
'    Dim dct(N - 1, N - 1) As Double
'    Dim ci, cj, sum As Double
'    Dim pi As Double = Math.PI

'    For u As Integer = 0 To N - 1
'        For v As Integer = 0 To N - 1
'            If u = 0 Then
'                ci = 1 / Math.Sqrt(N)
'            Else
'                ci = Math.Sqrt(2) / Math.Sqrt(N)
'            End If
'            If v = 0 Then
'                cj = 1 / Math.Sqrt(N)
'            Else
'                cj = Math.Sqrt(2) / Math.Sqrt(N)
'            End If

'            sum = 0
'            For x As Integer = 0 To N - 1
'                For y As Integer = 0 To N - 1
'                    sum += block(x, y) * Math.Cos((2 * x + 1) * u * pi / (2 * N)) * Math.Cos((2 * y + 1) * v * pi / (2 * N))
'                Next
'            Next

'            dct(u, v) = ci * cj * sum
'        Next
'    Next

'    Return dct
'End Function







'____________________________

'Function CuantizarDCT(dct(,) As Double, matrizCuantizacion(,) As Integer) As Integer(,)
'    Dim N As Integer = 8
'    Dim cuantizado(N - 1, N - 1) As Integer

'    For i As Integer = 0 To N - 1
'        For j As Integer = 0 To N - 1
'            cuantizado(i, j) = CInt(Math.Round(dct(i, j) / matrizCuantizacion(i, j)))
'        Next
'    Next

'    Return cuantizado
'End Function


'Dim matrizCuantizacion(,) As Integer = {
'{16, 11, 10, 16, 24, 40, 51, 61},
'{12, 12, 14, 19, 26, 58, 60, 55},
'{14, 13, 16, 24, 40, 57, 69, 56},
'{14, 17, 22, 29, 51, 87, 80, 62},
'{18, 22, 37, 56, 68, 109, 103, 77},
'{24, 35, 55, 64, 81, 104, 113, 92},
'{49, 64, 78, 87, 103, 121, 120, 101},
'{72, 92, 95, 98, 112, 100, 103, 99}
'}




'____________________________


'Class HuffmanNode
'    Public Property Symbol As Integer
'    Public Property Frequency As Integer
'    Public Property Left As HuffmanNode
'    Public Property Right As HuffmanNode

'    Public Sub New(symbol As Integer, frequency As Integer)
'        Me.Symbol = symbol
'        Me.Frequency = frequency
'        Me.Left = Nothing
'        Me.Right = Nothing
'    End Sub
'End Class

'' Función para construir el árbol de Huffman
'Function ConstruirArbolHuffman(frequencies As Dictionary(Of Integer, Integer)) As HuffmanNode
'    Dim priorityQueue As New SortedList(Of Integer, HuffmanNode)

'    ' Crear un nodo para cada símbolo y añadirlo a la cola de prioridad
'    For Each kvp In frequencies
'        priorityQueue.Add(kvp.Value, New HuffmanNode(kvp.Key, kvp.Value))
'    Next

'    ' Construir el árbol de Huffman
'    While priorityQueue.Count > 1
'        Dim left As HuffmanNode = priorityQueue.Values(0)
'        priorityQueue.RemoveAt(0)
'        Dim right As HuffmanNode = priorityQueue.Values(0)
'        priorityQueue.RemoveAt(0)

'        Dim newNode As New HuffmanNode(-1, left.Frequency + right.Frequency)
'        newNode.Left = left
'        newNode.Right = right
'        priorityQueue.Add(newNode.Frequency, newNode)
'    End While

'    Return priorityQueue.Values(0)
'End Function

'' Función para generar los códigos de Huffman
'Sub GenerarCodigosHuffman(node As HuffmanNode, prefix As String, codes As Dictionary(Of Integer, String))
'    If node Is Nothing Then Return

'    ' Si es una hoja, añadir el código al diccionario
'    If node.Left Is Nothing AndAlso node.Right Is Nothing Then
'        codes(node.Symbol) = prefix
'    Else
'        GenerarCodigosHuffman(node.Left, prefix & "0", codes)
'        GenerarCodigosHuffman(node.Right, prefix & "1", codes)
'    End If
'End Sub

'' Función principal para codificar los coeficientes DCT cuantizados
'Function CodificarHuffman(coeficientes As Integer(,)) As Dictionary(Of Integer, String)
'    Dim frequencies As New Dictionary(Of Integer, Integer)

'    ' Calcular las frecuencias de cada coeficiente
'    For Each coef In coeficientes
'        If Not frequencies.ContainsKey(coef) Then
'            frequencies(coef) = 0
'        End If
'        frequencies(coef) += 1
'    Next

'    ' Construir el árbol de Huffman
'    Dim root As HuffmanNode = ConstruirArbolHuffman(frequencies)

'    ' Generar los códigos de Huffman
'    Dim codes As New Dictionary(Of Integer, String)
'    GenerarCodigosHuffman(root, "", codes)

'    Return codes
'End Function





'____________________________



'Imports System.Drawing

'Module JPEGCompression

'    ' Función para convertir RGB a YCbCr
'    Function RGBtoYCbCr(R As Byte, G As Byte, B As Byte) As (Y As Byte, Cb As Byte, Cr As Byte)
'        Dim Y As Double = 0.299 * R + 0.587 * G + 0.114 * B
'        Dim Cb As Double = -0.1687 * R - 0.3313 * G + 0.5 * B + 128
'        Dim Cr As Double = 0.5 * R - 0.4187 * G - 0.0813 * B + 128

'        Y = Math.Max(0, Math.Min(255, Y))
'        Cb = Math.Max(0, Math.Min(255, Cb))
'        Cr = Math.Max(0, Math.Min(255, Cr))

'        Return (CByte(Y), CByte(Cb), CByte(Cr))
'    End Function

'    ' Función para dividir la imagen en bloques de 8x8 píxeles
'    Sub DividirEnBloques8x8(ByVal bmp As Bitmap, ByRef bloques(,) As Double(,))
'        Dim ancho As Integer = bmp.Width
'        Dim alto As Integer = bmp.Height
'        Dim bloquesX As Integer = ancho \ 8
'        Dim bloquesY As Integer = alto \ 8

'        ReDim bloques(bloquesX - 1, bloquesY - 1)

'        For y As Integer = 0 To bloquesY - 1
'            For x As Integer = 0 To bloquesX - 1
'                Dim bloque(7, 7) As Double
'                For j As Integer = 0 To 7
'                    For i As Integer = 0 To 7
'                        Dim pixel As Color = bmp.GetPixel(x * 8 + i, y * 8 + j)
'                        Dim (y, _, _) = RGBtoYCbCr(pixel.R, pixel.G, pixel.B)
'                        bloque(i, j) = y
'                    Next
'                Next
'                bloques(x, y) = bloque
'            Next
'        Next
'    End Sub

'    ' Función para aplicar la DCT a un bloque de 8x8
'    Function DCT8x8(block(,) As Double) As Double(,)
'        Dim N As Integer = 8
'        Dim dct(N - 1, N - 1) As Double
'        Dim ci, cj, sum As Double
'        Dim pi As Double = Math.PI

'        For u As Integer = 0 To N - 1
'            For v As Integer = 0 To N - 1
'                If u = 0 Then
'                    ci = 1 / Math.Sqrt(N)
'                Else
'                    ci = Math.Sqrt(2) / Math.Sqrt(N)
'                End If
'                If v = 0 Then
'                    cj = 1 / Math.Sqrt(N)
'                Else
'                    cj = Math.Sqrt(2) / Math.Sqrt(N)
'                End If

'                sum = 0
'                For x As Integer = 0 To N - 1
'                    For y As Integer = 0 To N - 1
'                        sum += block(x, y) * Math.Cos((2 * x + 1) * u * pi / (2 * N)) * Math.Cos((2 * y + 1) * v * pi / (2 * N))
'                    Next
'                Next

'                dct(u, v) = ci * cj * sum
'            Next
'        Next

'        Return dct
'    End Function

'    ' Función para cuantizar los coeficientes DCT
'    Function CuantizarDCT(dct(,) As Double, matrizCuantizacion(,) As Integer) As Integer(,)
'        Dim N As Integer = 8
'        Dim cuantizado(N - 1, N - 1) As Integer

'        For i As Integer = 0 To N - 1
'            For j As Integer = 0 To N - 1
'                cuantizado(i, j) = CInt(Math.Round(dct(i, j) / matrizCuantizacion(i, j)))
'            Next
'        Next

'        Return cuantizado
'    End Function

'    ' Función para construir el árbol de Huffman
'    Function ConstruirArbolHuffman(frequencies As Dictionary(Of Integer, Integer)) As HuffmanNode
'        Dim priorityQueue As New SortedList(Of Integer, HuffmanNode)

'        For Each kvp In frequencies
'            priorityQueue.Add(kvp.Value, New HuffmanNode(kvp.Key, kvp.Value))
'        Next

'        While priorityQueue.Count > 1
'            Dim left As HuffmanNode = priorityQueue.Values(0)
'            priorityQueue.RemoveAt(0)
'            Dim right As HuffmanNode = priorityQueue.Values(0)
'            priorityQueue.RemoveAt(0)

'            Dim newNode As New HuffmanNode(-1, left.Frequency + right.Frequency)
'            newNode.Left = left
'            newNode.Right = right
'            priorityQueue.Add(newNode.Frequency, newNode)
'        End While

'        Return priorityQueue.Values(0)
'    End Function

'    ' Función para generar los códigos de Huffman
'    Sub GenerarCodigosHuffman(node As HuffmanNode, prefix As String, codes As Dictionary(Of Integer, String))
'        If node Is Nothing Then Return

'        If node.Left Is Nothing AndAlso node.Right Is Nothing Then
'            codes(node.Symbol) = prefix
'        Else
'            GenerarCodigosHuffman(node.Left, prefix & "0", codes)
'            GenerarCodigosHuffman(node.Right, prefix & "1", codes)
'        End If
'    End Sub

'    ' Función principal para codificar los coeficientes DCT cuantizados
'    Function CodificarHuffman(coeficientes As Integer(,)) As Dictionary(Of Integer, String)
'        Dim frequencies As New Dictionary(Of Integer, Integer)

'        For Each coef In coeficientes
'            If Not frequencies.ContainsKey(coef) Then
'                frequencies(coef) = 0
'            End If
'            frequencies(coef) += 1
'        Next

'        Dim root As HuffmanNode = ConstruirArbolHuffman(frequencies)
'        Dim codes As New Dictionary(Of Integer, String)
'        GenerarCodigosHuffman(root, "", codes)

'        Return codes
'    End Function

'    ' Clase para el nodo del árbol de Huffman
'    Class HuffmanNode
'        Public Property Symbol As Integer
'        Public Property Frequency As Integer
'        Public Property Left As HuffmanNode
'        Public Property Right As HuffmanNode

'        Public Sub New(symbol As Integer, frequency As Integer)
'            Me.Symbol = symbol
'            Me.Frequency = frequency
'            Me.Left = Nothing
'            Me.Right = Nothing
'        End Sub
'    End Class

'    ' Ejemplo de uso
'    Sub Main()
'        Dim bmp As New Bitmap("ruta/a/tu/imagen.jpg")
'        Dim bloques(,) As Double(,)
'        DividirEnBloques8x8(bmp, bloques)

'        Dim matrizCuantizacion(,) As Integer = {
'{16, 11, 10, 16, 24, 40, 51, 61},
'{12, 12, 14, 19, 26, 58, 60, 55},
'{14, 13, 16, 24, 40, 57, 69, 56},
'{14, 17, 22, 29, 51, 87, 80, 62},
'{18, 22, 37, 56, 68, 109, 103, 77},
'{24, 35, 55, 64, 81, 104, 113, 92},
'{49, 64, 78, 87, 103, 121, 120, 101},
'{72, 92, 95, 98, 112, 100, 103, 99}
'}

'        For Each bloque In bloques
'            Dim dct As Double(,) = DCT8x8(bloque)
'            Dim cuantizado As Integer(,) = CuantizarDCT(dct, matrizCuantizacion)
'            Dim codigosHuffman As Dictionary(Of Integer, String) = CodificarHuffman(cuantizado)
'            ' Aquí puedes guardar o procesar los códigos Huffman
'        Next
'    End Sub

'End Module


'________________________

'Module Module1
'    Sub Main()
'        ' Ejemplo de datos de imagen (una fila de píxeles)
'        Dim imageData As Byte() = {255, 255, 255, 0, 0, 0, 0, 255, 255, 255, 255, 0}

'        ' Comprimir los datos usando RLE
'        Dim compressedData As List(Of Tuple(Of Byte, Integer)) = RLECompress(imageData)

'        ' Mostrar los datos comprimidos
'        For Each item In compressedData
'            Console.WriteLine("Valor: " & item.Item1 & ", Repeticiones: " & item.Item2)
'        Next

'        Console.ReadLine()
'    End Sub

'    Function RLECompress(data As Byte()) As List(Of Tuple(Of Byte, Integer))
'        Dim compressed As New List(Of Tuple(Of Byte, Integer))()
'        Dim count As Integer = 1

'        For i As Integer = 1 To data.Length - 1
'            If data(i) = data(i - 1) Then
'                count += 1
'            Else
'                compressed.Add(New Tuple(Of Byte, Integer)(data(i - 1), count))
'                count = 1
'            End If
'        Next

'        ' Añadir el último grupo
'        compressed.Add(New Tuple(Of Byte, Integer)(data(data.Length - 1), count))

'        Return compressed
'    End Function
'End Module















