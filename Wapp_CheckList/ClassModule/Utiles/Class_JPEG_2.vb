

Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Public Class Class_JPEG_2

    '    Importar la biblioteca GDI32.dll:
    'VB.Net
    Public Declare Function RGB2YCbCr Lib "GDI32.dll" Alias "RGB2YCbCr_" (ByVal lpRGB As Long, ByRef lpY As Long, ByRef lpCb As Long, ByRef lpCr As Long)
    Dim rgbColor As Long
    Dim yColor As Long
    Dim cbColor As Long
    Dim crColor As Long
    Friend Sub Manioso1()
        rgbColor = &HFF0000 ' Rojo
        RGB2YCbCr(rgbColor, yColor, cbColor, crColor)

    End Sub
    'Public Declare Function RGB2YCbCr Lib "GDI32.dll" Alias "RGB2YCbCr_" (  ByVal lpRGB As Long, ByRef lpY As Long, ByRef lpCb As Long, ByRef lpCr As Long  )
    Public Sub RGB2YCbCr_Ejemplo()
        ' Importar la biblioteca GDI32.dll


        ' Definir variables para los valores RGB y YCbCr
        Dim rgbColor As Long
        Dim yColor As Long
        Dim cbColor As Long
        Dim crColor As Long

        ' Asignar el valor RGB al que se desea convertir
        rgbColor = &HFF0000 ' Rojo

        ' Convertir el color RGB a YCbCr
        RGB2YCbCr(rgbColor, yColor, cbColor, crColor)

        ' Mostrar los valores YCbCr
        Debug.Print("Y:", yColor)
        Debug.Print("Cb:", cbColor)
        Debug.Print("Cr:", crColor)
        'Y = 0.299 * R + 0.587 * G + 0.114 * B
        'Cb = -0.1687 * R - 0.3313 * G + 0.5 * B + 128
        'Cr = 0.5 * R - 0.4186 * G - 0.0814 * B + 128
    End Sub


    Friend Sub Manioso2()
        rgbColor = &HFF0000 ' Rojo
        RGB2YCbCr(rgbColor, yColor, cbColor, crColor)

        yColor = 0.299 * red + 0.587 * green + 0.114 * blue
        cbColor = -0.1687 * red - 0.3313 * green + 0.5 * blue + 128
        crColor = 0.5 * red - 0.4186 * green - 0.0814 * blue + 128

    End Sub
    Dim red As Integer
    Dim green As Integer
    Dim blue As Integer
    'Dim yColor As Double
    'Dim cbColor As Double
    'Dim crColor As Double


    '    Friend Sub Manioso3()

    '        Dim imagenOriginal As Image = Image.FromFile("ruta/imagen.jpg")

    '        Dim anchoImagen As Integer = imagenOriginal.Width
    '        Dim alturaImagen As Integer = imagenOriginal.Height

    '        For fila As Integer = 0 To alturaImagen Step 8
    '            For columna As Integer = 0 To anchoImagen Step 8
    '                 Procesar el bloque de 8x8 actual (fila, columna)
    '                ProcesarBloque(imagenOriginal, fila, columna)
    '            Next columna
    '        Next fila

    '    End Sub

    '    Sub ProcesarBloque(imagen As Image, filaInicio As Integer, columnaInicio As Integer)
    '         Extraer el bloque de 8x8
    '        Dim bloque As Bitmap = New Bitmap(imagen, columnaInicio, filaInicio, 8, 8)

    '         Procesar el bloque (por ejemplo, convertir a YCbCr, aplicar DCT, etc.)

    '         Liberar recursos
    '        bloque.Dispose()
    '    End Sub

    '    Public Sub DividirBloques_Ejemplo()
    '         Cargar la imagen
    '        Dim imagenOriginal As Image = Image.FromFile("ruta/imagen.jpg")

    '         Obtener el ancho y la altura de la imagen
    '        Dim anchoImagen As Integer = imagenOriginal.Width
    '        Dim alturaImagen As Integer = imagenOriginal.Height

    '         Recorrer la imagen por bloques de 8x8
    '        For fila As Integer = 0 To alturaImagen Step 8
    '            For columna As Integer = 0 To anchoImagen Step 8
    '                 Procesar el bloque de 8x8 actual (fila, columna)
    '                ProcesarBloque(imagenOriginal, fila, columna)
    '            Next columna
    '        Next fila
    '    End Sub

    '     Función para procesar un bloque de 8x8
    '    Sub ProcesarBloque(imagen As Image, filaInicio As Integer, columnaInicio As Integer)
    '         Extraer el bloque de 8x8
    '        Dim bloque As Bitmap = New Bitmap(imagen, columnaInicio, filaInicio, 8, 8)

    '         Procesar el bloque (por ejemplo, convertir a YCbCr, aplicar DCT, etc.)
    '         ...

    '         Liberar recursos
    '        bloque.Dispose()

    '        Dim imagenOriginal As Image = Image.FromFile("ruta/imagen.jpg")
    '        Dim imagenData As BitmapData = imagenOriginal.LockBits(
    '            New Rectangle(0, 0, imagenOriginal.Width, imagenOriginal.Height),
    '            ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)


    '        For fila As Integer = 0 To imagenOriginal.Height Step 8
    '            For columna As Integer = 0 To imagenOriginal.Width Step 8
    '                 Obtener el bloque de 8x8 actual (fila, columna)
    '                Dim bloqueData As IntPtr = imagenData.Scan0 +
    '                    fila * imagenData.Stride + columna * 4

    '                 Procesar el bloque de 8x8 (por ejemplo, convertir a YCbCr, aplicar DCT, etc.)

    '            Next columna
    '        Next fila


    '        imagenOriginal.UnlockBits(imageData)
    '        imageData = Nothing


    '    End Sub

    '    Public Sub DividirBloques_Data()
    '         Cargar la imagen y obtener sus datos
    '        Dim imagenOriginal As Image = Image.FromFile("ruta/imagen.jpg")
    '        Dim imagenData As BitmapData = imagenOriginal.LockBits(New Rectangle(0, 0, imagenOriginal.Width, imagenOriginal.Height),


    '    Public Sub CompresionJPEG_DCT_OpenCV()
    '         Cargar la imagen y dividirla en bloques
    '        Dim imagenOriginal As Image = Image.FromFile("ruta/imagen.jpg")
    '        Dim bloques As List(Bitmap) = DividirBloques(imagenOriginal)

    '         Importar la biblioteca OpenCV
    '        Imports Emgu.CV

    '         Recorrer los bloques
    '        For bloque As Bitmap In bloques
    '         Convertir el bloque a Mat
    '        Dim bloqueMat As Mat = New Mat(bloque)

    '             Aplicar la DCT al bloque
    '            Cv2.Dct(bloqueMat, bloqueMat)

    '             Convertir el Mat de nuevo a Bitmap
    '            Dim bloqueProcesado As Bitmap = bloqueMat.ToBitmap()

    '             Procesar el bloque procesado (por ejemplo, cuantificar, codificar, etc.)
    '            ProcesarBloqueProcesado(bloqueProcesado)
    '        Next bloque
    '    End Sub


    '     Transponer la matriz de entrada
    '    Dim F_t As Matrix = F.Transpose()

    '     Multiplicar las matrices F_t y C
    '    Dim temp As Matrix = F_t * C

    ' Multiplicar la matriz temp por la transpuesta de C
    'F_dct = temp * C.Transpose()









    '    ' Función para calcular la DCT de un bloque de 8x8
    '    Public Function DCT(bloque As Bitmap) As Matrix
    '        ' Definir las matrices
    '        Dim F As New Matrix(bloque)
    '        Dim F_dct As New Matrix(8, 8)
    '        Dim C As New Matrix(8, 8)

    '        ' Calcular la matriz de cosenos
    '        ' ... (implementar el cálculo de la matriz C)

    '        ' Realizar la transformación
    '        Dim F_t As Matrix = F.Transpose()
    '        Dim temp As Matrix = F_t * C
    '        F_dct = temp * C.Transpose()

    '        ' Normalizar la matriz de salida
    '        ' ... (implementar la normalización de la matriz F_dct)

    '        ' Devolver la matriz de coeficientes de DCT
    '        Return F_dct
    '    End Function

    '    ' Función para cuantificar un bloque de coeficientes DCT
    '    Public Function CuantificarBloque(bloqueDCT As Matrix, tablaCuantizacion As Matrix) As Matrix
    '        ' Definir la matriz de coeficientes cuantificados
    '        Dim bloqueCuantificado As New Matrix(bloqueDCT.RowCount, bloqueDCT.ColumnCount)

    '        ' Recorrer la matriz de coeficientes DCT
    '        For fila As Integer = 0 To bloqueDCT.RowCount - 1
    '            For columna As Integer = 0 To bloqueDCT.ColumnCount - 1
    '                ' Obtener el valor de cuantización
    '                Dim valorCuantizacion As Integer = tablaCuantizacion(fila, columna)

    '                ' Dividir el coeficiente por el valor de cuantización
    '                Dim coeficienteCuantificado As Integer = bloqueDCT(fila, columna) / valorCuantizacion

    '                ' Redondear el resultado
    '                bloqueCuantificado(fila, columna) = Math.Round(coeficienteCuantificado)
    '            Next columna
    '        Next fila

    '        ' Devolver la matriz de coeficientes cuantificados
    '        Return bloqueCuantificado

    '    ' Función para crear el árbol de Huffman
    'Public Function CrearArbolHuffman(simbolos As List(Of Integer), frecuencias As List(Of Integer)) As TreeNode
    '        ' Si solo hay un símbolo, devuelve ese símbolo
    '        If simbolos.Count = 1 Then
    '            Return New TreeNode(simbolos(0), frecuencias(0))
    '        End If

    '        ' Encontrar los dos símbolos con menor frecuencia
    '        Dim minIndex1 As Integer = EncontrarMinimo(frecuencias)
    '        Dim minSymbol1 As Integer = simbolos(minIndex1)
    '        Dim minFrecuencia1 As Integer = frecuencias(minIndex1)

    '        frecuencias.RemoveAt(minIndex1)
    '        simbolos.RemoveAt(minIndex1)

    '        Dim minIndex2 As Integer = EncontrarMinimo(frecuencias)
    '        Dim minSymbol2 As Integer = simbolos(minIndex2)
    '        Dim minFrecuencia2 As Integer = frecuencias(minIndex2)

    '        frecuencias.RemoveAt(minIndex2)
    '        simbolos.RemoveAt(minIndex2)

    '        ' Crear nodos hoja
    '        Dim nodoHoja1 As New TreeNode(minSymbol1, minFrecuencia1)
    '        Dim nodoHoja2 As New TreeNode(minSymbol2, minFrecuencia2)

    '        ' Crear un nodo padre
    '        Dim nodoPadre As New TreeNode(0, minFrecuencia1 + minFrecuencia2)
    '        nodoPadre.Left = nodoHoja1
    '        nodoPadre.Right = nodoHoja2

    '        ' Recorrer recursivamente para construir el árbol
    '        Return nodoPadre
    '    End Function

    '    ' Función para encontrar el índice del valor mínimo en una lista
    '    Public Function EncontrarMinimo(lista As List(Of Integer)) As Integer
    '        Dim minIndex As Integer = 0
    '        Dim minValue As Integer = lista(0)

    '        For i As Integer = 1 To lista.Count - 1
    '            If lista(i) < minValue Then
    '                minIndex = i
    '                minValue = lista(i)
    '            End If
    '        Next i

    '        Return minIndex
    '    End Function

    '    ' Función para asignar códigos de Huffman a los símbolos
    '    Public Sub AsignarCodigosHuffman(nodo As TreeNode, codigo As String, simbolos As Dictionary(Of Integer, String))
    '        If nodo Is Nothing Then
    '            Exit Sub
    '        End If

    '        If nodo.Left Is Nothing AndAlso nodo.Right Is Nothing Then
    '            ' Es un nodo hoja, almacenar el código
    '            simbolos.Add(nodo.Value, codigo)
    '            Exit Sub
    '        End If

    '        AsignarCodigosHuffman(nodo.Left, codigo & "0", simbolos)
    '        AsignarCodigosHuffman(nodo.Right, codigo & "1", simbolos)

End Class
