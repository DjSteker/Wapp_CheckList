
Public Class Form_CodigoQR_V1

    Private Sub Form_CodigoQR_V1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub MainCodeQR()
        Dim data As String = TextBox1.Text
        Dim qrCode As String = GenerateQRCode(data, 7)
        Console.WriteLine(qrCode)

        'Nivel L	7 % de las claves se pueden restaurar
        'Nivel M	15 % de las claves se pueden restaurar
        'Nivel Q	25 % de las claves se pueden restaurar
        'Nivel H	30 % de las claves se pueden restaurar

    End Sub

    Function GenerateQRCode(data As String, level As Integer) As String



        Dim errorCorrection As String = "110101011000100"
        Dim errorCorrectionLength As Integer = errorCorrection.Length





        ' Crea la matriz de datos
        Dim dataMatrix(20, 20) As Integer
        Dim dataLength As Integer = data.Length

        ReDim dataMatrix(dataLength + errorCorrectionLength, 20)


        ' Inserta los datos en la matriz
        For i As Integer = 0 To dataLength - 1
            Dim binaryValue As String = Convert.ToString(AscW(data(i)), 2).PadLeft(8, "0")
            For j As Integer = 0 To 7
                dataMatrix(i, j) = Convert.ToInt32(binaryValue(j).ToString())
            Next
        Next


        Try
            ' Agrega los bits de corrección de errores

            For i As Integer = dataLength To dataLength + errorCorrectionLength - 1
                dataMatrix(i, 0) = Convert.ToInt32(errorCorrection(i - dataLength).ToString())
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' Convierte la matriz en una cadena de caracteres
        Dim qrCode As String = ""
        For i As Integer = 0 To dataLength + errorCorrectionLength - 1
            For j As Integer = 0 To 7
                qrCode += dataMatrix(i, j).ToString()
            Next
        Next

        ' Agrega el nivel de corrección de errores
        Dim errorCorrectionLevel As String = ""
        Select Case level
            Case 0
                errorCorrectionLevel = "01"
            Case 1
                errorCorrectionLevel = "00"
            Case 2
                errorCorrectionLevel = "11"
            Case 3
                errorCorrectionLevel = "10"
            Case 7
                errorCorrectionLevel = "110"
        End Select
        qrCode = errorCorrectionLevel + qrCode

        ' Agrega los bits de relleno
        Dim padding As String = "1110110000010001"
        Dim paddingLength As Integer = 20 - (dataLength + errorCorrectionLength) Mod 20
        Try
            For i As Integer = 0 To paddingLength - 1
                qrCode += padding(i Mod 2).ToString()
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        ' Agrega los bits de terminación
        qrCode += "0000"

        ' Divide la cadena en bloques de 8 bits y convierte cada bloque en un carácter ASCII
        Dim qrCodeLength As Integer = qrCode.Length
        Dim asciiCode As String = ""
        Try
            For i As Integer = 0 To qrCodeLength - 1 Step 8
                Dim binaryValue As String = qrCode.Substring(i, 8)
                Dim decimalValue As Integer = Convert.ToInt32(binaryValue, 2)
                asciiCode += Chr(decimalValue)
            Next
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

        'Try
        '    PictureBox1.Image = GenerateImage(qrCode)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try




        Return asciiCode
    End Function


    Function GenerateQRCodeBin(data As String, level As Integer) As String



        Dim errorCorrection As String = "110101011000100"
        Dim errorCorrectionLength As Integer = errorCorrection.Length





        ' Crea la matriz de datos
        Dim dataMatrix(20, 20) As Integer
        Dim dataLength As Integer = data.Length

        ReDim dataMatrix(dataLength + errorCorrectionLength, 20)


        ' Inserta los datos en la matriz
        For i As Integer = 0 To dataLength - 1
            Dim binaryValue As String = Convert.ToString(AscW(data(i)), 2).PadLeft(8, "0")
            For j As Integer = 0 To 7
                dataMatrix(i, j) = Convert.ToInt32(binaryValue(j).ToString())
            Next
        Next


        Try
            ' Agrega los bits de corrección de errores

            For i As Integer = dataLength To dataLength + errorCorrectionLength - 1
                dataMatrix(i, 0) = Convert.ToInt32(errorCorrection(i - dataLength).ToString())
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' Convierte la matriz en una cadena de caracteres
        Dim qrCode As String = ""
        For i As Integer = 0 To dataLength + errorCorrectionLength - 1
            For j As Integer = 0 To 7
                qrCode += dataMatrix(i, j).ToString()
            Next
        Next

        ' Agrega el nivel de corrección de errores
        Dim errorCorrectionLevel As String = ""
        Select Case level
            Case 0
                errorCorrectionLevel = "01"
            Case 1
                errorCorrectionLevel = "00"
            Case 2
                errorCorrectionLevel = "11"
            Case 3
                errorCorrectionLevel = "10"
            Case 7
                errorCorrectionLevel = "110"
        End Select
        qrCode = errorCorrectionLevel + qrCode

        ' Agrega los bits de relleno
        Dim padding As String = "1110110000010001"
        Dim paddingLength As Integer = 20 - (dataLength + errorCorrectionLength) Mod 20
        Try
            For i As Integer = 0 To paddingLength - 1
                qrCode += padding(i Mod 2).ToString()
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        ' Agrega los bits de terminación
        qrCode += "0000"

        ' Divide la cadena en bloques de 8 bits y convierte cada bloque en un carácter ASCII
        Dim qrCodeLength As Integer = qrCode.Length
        Dim asciiCode As String = ""
        Try
            For i As Integer = 0 To qrCodeLength - 1 Step 8
                Dim binaryValue As String = qrCode.Substring(i, 8)
                Dim decimalValue As Integer = Convert.ToInt32(binaryValue, 2)
                asciiCode += Chr(decimalValue)
            Next
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

        'Try
        '    PictureBox1.Image = GenerateImage(qrCode)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try




        Return qrCode
    End Function

    Dim Canvas1 As Bitmap '= New Bitmap(PictureBox1.Width, PictureBox1.Height)
    Dim offScreenDC As Graphics ' = Graphics.FromImage(Canvas1)
    Function GenerateImage(qrCode As String) As Image



        Dim width As Integer = 20
        Dim height As Integer = 200
        Canvas1 = New Bitmap(width, height)
        offScreenDC = Graphics.FromImage(Canvas1)
        offScreenDC.Clear(Color.White)
        'offScreenDC = Graphics.FromImage(bitmap)
        'offScreenDC.Clear(Color.Black)
        Dim pen1 As New Pen(Color.FromArgb(128, 128, 128, 1))
        For i As Integer = 0 To qrCode.Length - 1
            Dim x As Integer = i Mod width
            Dim y As Integer = i \ width
            If qrCode(i) = "1" Then
                Canvas1.SetPixel(x, y, Color.Black)
                offScreenDC.DrawLine(pen1, x, y, x, y)
            End If
        Next

        PictureBox1.Image = Me.Canvas1


        Return Canvas1
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim data As String = TextBox1.Text
            Dim qrCode As String = GenerateQRCodeBin(data, 7)
            GenerateImage(qrCode)
            'image.Save("qr-code.png", System.Drawing.Imaging.ImageFormat.Png)
            'PictureBox1.Image = GenerateImage(qrCode)
        Catch ex As Exception

        End Try
    End Sub




#Region ""
    Sub generar_codigo_qr(contenido As String)
        ' Tamaño del código QR
        Dim tamaño As Integer = 21

        ' Caracteres para el código QR
        Dim caracteres As New Dictionary(Of String, String) From {
        {"blanco", " "},
        {"negro", "█"}
    }

        ' Generar la matriz del código QR
        Dim qr(tamaño - 1, tamaño - 1) As String
        For i As Integer = 0 To tamaño - 1
            For j As Integer = 0 To tamaño - 1
                qr(i, j) = caracteres("blanco")
            Next
        Next

        ' Insertar contenido en el código QR
        For fila As Integer = 9 To tamaño - 10
            For columna As Integer = 9 To tamaño - 10
                qr(fila, columna) = caracteres("negro")
            Next
        Next

        ' Imprimir el código QR
        For fila As Integer = 0 To tamaño - 1
            For columna As Integer = 0 To tamaño - 1
                Console.Write(qr(fila, columna))
            Next
            Console.WriteLine()
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim contenido As String = "https://www.example.com"
            generar_codigo_qr(contenido)
        Catch ex As Exception

        End Try
    End Sub

    ' Ejemplo de uso

#End Region
End Class