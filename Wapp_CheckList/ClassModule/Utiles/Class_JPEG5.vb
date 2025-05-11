'Imports System
'Imports System.Drawing
'Imports System.IO
'Imports System.Drawing.Imaging

'Public Class JPEGDemodulator
'    Private _imagePath As String
'    Private _imageData As Byte()
'    Private _bitmap As Bitmap

'    Public Sub New(imagePath As String)
'        _imagePath = imagePath
'        LoadImage()
'    End Sub

'    Private Sub LoadImage()
'        Try
'            _bitmap = New Bitmap(_imagePath)
'            Using ms As New MemoryStream()
'                _bitmap.Save(ms, ImageFormat.Jpeg)
'                _imageData = ms.ToArray()
'            End Using
'        Catch ex As Exception
'            Throw New Exception("Error al cargar la imagen: " & ex.Message)

'        End Try
'    End Sub

'    Public Function DemodulateImage() As Double(,)
'        Dim width As Integer = _bitmap.Width
'        Dim height As Integer = _bitmap.Height
'        Dim demodulatedData(height - 1, width - 1) As Double

'        ' Procesar cada píxel de la imagen
'        For y As Integer = 0 To height - 1
'            For x As Integer = 0 To width - 1
'                Dim pixel As Color = _bitmap.GetPixel(x, Y)

'                ' Convertir RGB a YCbCr
'                Dim Y As Double = 0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B
'                Dim Cb As Double = -0.1687 * pixel.R - 0.3313 * pixel.G + 0.5 * pixel.B + 128
'                Dim Cr As Double = 0.5 * pixel.R - 0.4187 * pixel.G - 0.0813 * pixel.B + 128

'                ' Almacenar el valor de luminancia (Y)
'                demodulatedData(Y, x) = Y
'            Next
'        Next

'        Return demodulatedData
'    End Function

'    Public Function GetDCTCoefficients(blockSize As Integer) As Double(,,,)
'        Dim width As Integer = _bitmap.Width
'        Dim height As Integer = _bitmap.Height
'        Dim numBlocksX As Integer = width \ blockSize
'        Dim numBlocksY As Integer = height \ blockSize
'        Dim dctCoefficients(numBlocksY - 1, numBlocksX - 1, blockSize - 1, blockSize - 1) As Double

'        ' Procesar la imagen por bloques
'        For blockY As Integer = 0 To numBlocksY - 1
'            For blockX As Integer = 0 To numBlocksX - 1
'                ' Extraer bloque
'                Dim block(blockSize - 1, blockSize - 1) As Double
'                For y As Integer = 0 To blockSize - 1
'                    For x As Integer = 0 To blockSize - 1
'                        Dim pixelX As Integer = blockX * blockSize + x
'                        Dim pixelY As Integer = blockY * blockSize + y
'                        Dim pixel As Color = _bitmap.GetPixel(pixelX, pixelY)
'                        block(y, x) = 0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B
'                    Next
'                Next

'                ' Aplicar DCT al bloque
'                For v As Integer = 0 To blockSize - 1
'                    For u As Integer = 0 To blockSize - 1
'                        Dim sum As Double = 0
'                        For y As Integer = 0 To blockSize - 1
'                            For x As Integer = 0 To blockSize - 1
'                                sum += block(y, x) *
'                                      Math.Cos((2 * x + 1) * u * Math.PI / (2 * blockSize)) * Math.Cos((2 * y + 1) * v * Math.PI / (2 * blockSize))
'                            Next
'                        Next

'                        Dim cu As Double = If(u = 0, 1.0 / Math.Sqrt(2), 1.0)
'                        Dim cv As Double = If(v = 0, 1.0 / Math.Sqrt(2), 1.0)
'                        dctCoefficients(blockY, blockX, v, u) = 0.25 * cu * cv * sum
'                    Next
'                Next
'            Next
'        Next

'        Return dctCoefficients
'    End Function

'    Public Function GetQuantizationTable() As Integer(,)
'        ' Tabla de cuantización JPEG estándar para luminancia
'        Dim qTable(,) As Integer = {
'            {16, 11, 10, 16, 24, 40, 51, 61},
'            {12, 12, 14, 19, 26, 58, 60, 55},
'            {14, 13, 16, 24, 40, 57, 69, 56},
'            {14, 17, 22, 29, 51, 87, 80, 62},
'            {18, 22, 37, 56, 68, 109, 103, 77},
'            {24, 35, 55, 64, 81, 104, 113, 92},
'            {49, 64, 78, 87, 103, 121, 120, 101},
'            {72, 92, 95, 98, 112, 100, 103, 99}
'        }
'        Return qTable
'    End Function

'    Public Sub Dispose()
'        If _bitmap IsNot Nothing Then
'            _bitmap.Dispose()
'        End If
'    End Sub
'End Class


'Imports System
'Imports System.Drawing
'Imports System.IO
'Imports System.Drawing.Imaging

'Public Class DemoduladorJPEG
'    Private _rutaImagen As String
'    Private _datosImagen As Byte()
'    Private _imagenBitmap As Bitmap

'    Public Sub New(rutaImagen As String)
'        _rutaImagen = rutaImagen
'        LoadImageFromPath()
'    End Sub

'    Private Sub LoadImageFromPath()
'        Try
'            _imagenBitmap = New Bitmap(_rutaImagen)
'            Using flujoMemoria As New MemoryStream()
'                _imagenBitmap.Save(flujoMemoria, ImageFormat.Jpeg)
'                _datosImagen = flujoMemoria.ToArray()
'            End Using
'        Catch ex As Exception
'            Throw New Exception("Error al cargar la imagen: " & ex.Message)
'        End Try
'    End Sub

'    Public Function ExtractDemodulatedSignals() As Double(,)
'        Dim ancho As Integer = _imagenBitmap.Width
'        Dim alto As Integer = _imagenBitmap.Height
'        Dim datosDemodulados(alto - 1, ancho - 1) As Double

'        ' Procesar cada píxel de la imagen
'        For fila As Integer = 0 To alto - 1
'            For columna As Integer = 0 To ancho - 1
'                Dim pixelActual As Color = _imagenBitmap.GetPixel(columna, fila)

'                ' Convertir RGB a YCbCr
'                Dim luminancia As Double = 0.299 * pixelActual.R + 0.587 * pixelActual.G + 0.114 * pixelActual.B
'                Dim componenteAzul As Double = -0.1687 * pixelActual.R - 0.3313 * pixelActual.G + 0.5 * pixelActual.B + 128
'                Dim componenteRojo As Double = 0.5 * pixelActual.R - 0.4187 * pixelActual.G - 0.0813 * pixelActual.B + 128

'                ' Almacenar el valor de luminancia
'                datosDemodulados(fila, columna) = luminancia
'            Next
'        Next

'        Return datosDemodulados
'    End Function

'    Public Function ProcessDCTTransformation(tamañoBloque As Integer) As Double(,,,)
'        Dim ancho As Integer = _imagenBitmap.Width
'        Dim alto As Integer = _imagenBitmap.Height
'        Dim numBloqueX As Integer = ancho \ tamañoBloque
'        Dim numBloqueY As Integer = alto \ tamañoBloque
'        Dim coeficientesDCT(numBloqueY - 1, numBloqueX - 1, tamañoBloque - 1, tamañoBloque - 1) As Double

'        ' Procesar la imagen por bloques
'        For bloqueY As Integer = 0 To numBloqueY - 1
'            For bloqueX As Integer = 0 To numBloqueX - 1
'                ' Extraer bloque
'                Dim bloqueActual(tamañoBloque - 1, tamañoBloque - 1) As Double
'                For posY As Integer = 0 To tamañoBloque - 1
'                    For posX As Integer = 0 To tamañoBloque - 1
'                        Dim pixelX As Integer = bloqueX * tamañoBloque + posX
'                        Dim pixelY As Integer = bloqueY * tamañoBloque + posY
'                        Dim pixelActual As Color = _imagenBitmap.GetPixel(pixelX, pixelY)
'                        bloqueActual(posY, posX) = 0.299 * pixelActual.R + 0.587 * pixelActual.G + 0.114 * pixelActual.B
'                    Next
'                Next

'                ' Apply DCT transformation to block
'                For frecV As Integer = 0 To tamañoBloque - 1
'                    For frecU As Integer = 0 To tamañoBloque - 1
'                        Dim sumatoria As Double = 0
'                        For posY As Integer = 0 To tamañoBloque - 1
'                            For posX As Integer = 0 To tamañoBloque - 1
'                                sumatoria += bloqueActual(posY, posX) *
'                                           Math.Cos((2 * posX + 1) * frecU * Math.PI / (2 * tamañoBloque)) *
'                                           Math.Cos((2 * posY + 1) * frecV * Math.PI / (2 * tamañoBloque))
'                            Next
'                        Next

'                        Dim coeficienteU As Double = If(frecU = 0, 1.0 / Math.Sqrt(2), 1.0)
'                        Dim coeficienteV As Double = If(frecV = 0, 1.0 / Math.Sqrt(2), 1.0)
'                        coeficientesDCT(bloqueY, bloqueX, frecV, frecU) = 0.25 * coeficienteU * coeficienteV * sumatoria
'                    Next
'                Next
'            Next
'        Next

'        Return coeficientesDCT
'    End Function

'    Public Function GetQuantizationMatrix() As Integer(,)
'        ' Tabla de cuantización JPEG estándar para luminancia
'        Dim tablaQuantizacion(,) As Integer = {
'            {16, 11, 10, 16, 24, 40, 51, 61},
'            {12, 12, 14, 19, 26, 58, 60, 55},
'            {14, 13, 16, 24, 40, 57, 69, 56},
'            {14, 17, 22, 29, 51, 87, 80, 62},
'            {18, 22, 37, 56, 68, 109, 103, 77},
'            {24, 35, 55, 64, 81, 104, 113, 92},
'            {49, 64, 78, 87, 103, 121, 120, 101},
'            {72, 92, 95, 98, 112, 100, 103, 99}
'        }
'        Return tablaQuantizacion
'    End Function

'    Public Sub ReleaseResources()
'        If _imagenBitmap IsNot Nothing Then
'            _imagenBitmap.Dispose()
'        End If
'    End Sub
'End Class

Imports System
Imports System.Drawing
Imports System.IO
Imports System.Drawing.Imaging

Public Class DemoduladorJPEG
    Private _rutaImagen As String
    Private _datosImagen As Byte()
    Private _imagenBitmap As Bitmap


    ' Método para abrir un archivo JPEG y leer su encabezado en binario
    Private Sub OpenJpegButton_Click(sender As Object, e As EventArgs) 'Handles OpenJpegButton.Click
        ' Crear un OpenFileDialog para seleccionar el archivo JPEG
        Dim openFileDialog As New OpenFileDialog With {
            .Filter = "JPEG files (*.jpg;*.jpeg)|*.jpg;*.jpeg|All files (*.*)|*.*"
        }

        ' Mostrar el diálogo y comprobar si se seleccionó un archivo
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Leer el archivo JPEG en binario
            Dim filePath As String = openFileDialog.FileName
            Dim fileBytes As Byte() = File.ReadAllBytes(filePath)

            ' Extraer información del encabezado del archivo JPEG
            Dim headerInfo As String = ExtractJpegHeaderInfo(fileBytes)

            ' Mostrar la información del encabezado en un TextBox (por ejemplo)
            'TextBox1.Text = headerInfo
        End If
    End Sub

    ' Método para extraer información del encabezado del archivo JPEG
    Private Function ExtractJpegHeaderInfo(fileBytes As Byte()) As String
        Dim info As String = ""

        ' Los archivos JPEG normalmente comienzan con el marcador FFD8
        If fileBytes.Length > 2 AndAlso fileBytes(0) = &HFF AndAlso fileBytes(1) = &HD8 Then
            info &= "JPEG file detected." & vbCrLf

            ' Buscar el marcador de segmentación (APP0 - JFIF, APP1 - EXIF, etc.)
            Dim i As Integer = 2
            While i < fileBytes.Length - 1
                If fileBytes(i) = &HFF Then
                    Select Case fileBytes(i + 1)
                        Case &HE0 ' APP0 - JFIF
                            info &= "APP0 (JFIF) segment found." & vbCrLf
                            ' Leer longitud del segmento APP0
                            Dim segmentLength As Integer = (fileBytes(i + 2) << 8) + fileBytes(i + 3)
                            info &= "Segment length: " & segmentLength & " bytes" & vbCrLf

                        Case &HE1 ' APP1 - EXIF
                            info &= "APP1 (EXIF) segment found." & vbCrLf
                            ' Leer longitud del segmento APP1
                            Dim segmentLength As Integer = (fileBytes(i + 2) << 8) + fileBytes(i + 3)
                            info &= "Segment length: " & segmentLength & " bytes" & vbCrLf

                            ' Añadir más casos según sea necesario para otros segmentos
                    End Select
                End If
                i += 1
            End While
        Else
            info &= "Not a JPEG file."
        End If

        Return info
    End Function


    Public Sub Iniciar(rutaImagen As String)
        _rutaImagen = rutaImagen
        CargarImagen()

        'Using demodulador As New DemoduladorJPEG("ruta/imagen.jpg")
        '    ' Obtener datos demodulados
        '    Dim datosDemodulados = demodulador.DemodularImagen()

        '    ' Obtener coeficientes DCT (usando bloques de 8x8)
        '    Dim coeficientesDCT = demodulador.ObtenerCoeficientesDCT(8)
        'End Using

        Dim fileContents As Byte()
        fileContents = My.Computer.FileSystem.ReadAllBytes("C:\Test.txt")


    End Sub

    Private Sub CargarImagen()
        Try
            _imagenBitmap = New Bitmap(_rutaImagen)
            Using flujoMemoria As New MemoryStream()
                _imagenBitmap.Save(flujoMemoria, ImageFormat.Jpeg)
                _datosImagen = flujoMemoria.ToArray()

            End Using
        Catch ex As Exception
            Throw New Exception("Error al cargar la imagen: " & ex.Message)
        End Try
    End Sub

    Public Function DemodularImagen() As Double(,)
        Dim ancho As Integer = _imagenBitmap.Width
        Dim alto As Integer = _imagenBitmap.Height
        Dim datosDemodulados(alto - 1, ancho - 1) As Double


        ' Procesar cada píxel de la imagen
        For fila As Integer = 0 To alto - 1
            For columna As Integer = 0 To ancho - 1
                Dim pixelActual As Color = _imagenBitmap.GetPixel(columna, fila)

                ' Convertir RGB a YCbCr
                Dim luminancia As Double = 0.299 * pixelActual.R + 0.587 * pixelActual.G + 0.114 * pixelActual.B
                Dim componenteAzul As Double = -0.1687 * pixelActual.R - 0.3313 * pixelActual.G + 0.5 * pixelActual.B + 128
                Dim componenteRojo As Double = 0.5 * pixelActual.R - 0.4187 * pixelActual.G - 0.0813 * pixelActual.B + 128

                ' Almacenar el valor de luminancia
                datosDemodulados(fila, columna) = luminancia
            Next
        Next

        Return datosDemodulados
    End Function

    Public Function ObtenerCoeficientesDCT(tamañoBloque As Integer) As Double(,,,)
        Dim ancho As Integer = _imagenBitmap.Width
        Dim alto As Integer = _imagenBitmap.Height
        Dim numBloqueX As Integer = ancho \ tamañoBloque
        Dim numBloqueY As Integer = alto \ tamañoBloque
        Dim coeficientesDCT(numBloqueY - 1, numBloqueX - 1, tamañoBloque - 1, tamañoBloque - 1) As Double
        Try
            ' Procesar la imagen por bloques
            For bloqueY As Integer = 0 To numBloqueY - 1
                For bloqueX As Integer = 0 To numBloqueX - 1
                    ' Extraer bloque
                    Dim bloqueActual(tamañoBloque - 1, tamañoBloque - 1) As Double
                    For posY As Integer = 0 To tamañoBloque - 1
                        For posX As Integer = 0 To tamañoBloque - 1
                            Dim pixelX As Integer = bloqueX * tamañoBloque + posX
                            Dim pixelY As Integer = bloqueY * tamañoBloque + posY
                            Dim pixelActual As Color = _imagenBitmap.GetPixel(pixelX, pixelY)
                            bloqueActual(posY, posX) = 0.299 * pixelActual.R + 0.587 * pixelActual.G + 0.114 * pixelActual.B
                        Next
                    Next

                    ' Aplicar DCT al bloque
                    For frecV As Integer = 0 To tamañoBloque - 1
                        For frecU As Integer = 0 To tamañoBloque - 1
                            Dim sumatoria As Double = 0
                            For posY As Integer = 0 To tamañoBloque - 1
                                For posX As Integer = 0 To tamañoBloque - 1
                                    sumatoria += bloqueActual(posY, posX) * Math.Cos((2 * posX + 1) * frecU * Math.PI / (2 * tamañoBloque)) * Math.Cos((2 * posY + 1) * frecV * Math.PI / (2 * tamañoBloque))
                                Next
                            Next

                            Dim coeficienteU As Double = If(frecU = 0, 1.0 / Math.Sqrt(2), 1.0)
                            Dim coeficienteV As Double = If(frecV = 0, 1.0 / Math.Sqrt(2), 1.0)
                            coeficientesDCT(bloqueY, bloqueX, frecV, frecU) = 0.25 * coeficienteU * coeficienteV * sumatoria
                        Next
                    Next
                Next
            Next
        Catch ex As Exception

        End Try
        Return coeficientesDCT
    End Function

    Public Function ObtenerTablaQuantizacion() As Integer(,)
        ' Tabla de cuantización JPEG estándar para luminancia
        Dim tablaQuantizacion(,) As Integer = {
            {16, 11, 10, 16, 24, 40, 51, 61},
            {12, 12, 14, 19, 26, 58, 60, 55},
            {14, 13, 16, 24, 40, 57, 69, 56},
            {14, 17, 22, 29, 51, 87, 80, 62},
            {18, 22, 37, 56, 68, 109, 103, 77},
            {24, 35, 55, 64, 81, 104, 113, 92},
            {49, 64, 78, 87, 103, 121, 120, 101},
            {72, 92, 95, 98, 112, 100, 103, 99}
        }
        Return tablaQuantizacion
    End Function

    Public Sub Dispose()
        If _imagenBitmap IsNot Nothing Then
            _imagenBitmap.Dispose()
        End If
    End Sub

End Class