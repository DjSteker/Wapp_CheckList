Public Class Class_MiQR
    Dim pictureBox1 As New PictureBox

    Friend Sub main1()

        Dim moduleSize As Integer = 10
        Dim detectionPositionSize As Integer

        detectionPositionSize = GetQRCodeDetectionPositionSize(moduleSize)
        MsgBox("El tamaño del patrón de detección de posición es " & detectionPositionSize)


        DrawAlignmentPositionSynchronizationBoxes(pictureBox1, 250, 250, 10)
        MsgBox("El tamaño del patrón de detección de posición es " & detectionPositionSize)

    End Sub



    Public Function GetQRCodeDetectionPositionSize(ByVal moduleSize As Integer) As Integer

        ' Calcula el tamaño del patrón de detección de posición
        Dim detectionPositionSize As Integer = moduleSize / 2

        ' Devuelve el tamaño del patrón de detección de posición
        Return detectionPositionSize

    End Function


    Function PatronTemporizacion(ByVal numModulos As Integer) As Integer
        ' Restar 17 al número de módulos
        Dim resta As Integer = numModulos - 17
        ' Dividir la resta entre 2
        Dim division As Integer = resta \ 2
        ' Devolver el resultado de la división
        Return division
    End Function

    Public Function GetQRCodeAlignmentSize(ByVal moduleSize As Integer) As Integer

        ' Calcula el tamaño del patrón de alineación
        Dim alignmentSize As Integer = moduleSize / 2

        ' Devuelve el tamaño del patrón de alineación
        Return alignmentSize

    End Function


    Public Sub DrawAlignmentPositionSynchronizationBoxes(ByRef pictureBox As PictureBox, _offsetX As Double, _offsetY As Double, _moduleSize As Integer)
        Try
            ' Create a new bitmap for drawing the boxes
            Dim canvasTimeDomain = New Bitmap(pictureBox.Width, pictureBox.Height)
            Dim offScreenDC As Graphics = Graphics.FromImage(canvasTimeDomain)

            ' Define colors for the boxes
            Dim alignmentBoxColor As Color = Color.Black
            Dim positionBoxColor As Color = Color.Green
            Dim syncBoxColor As Color = Color.Blue

            ' Draw alignment box
            Dim alignmentBoxX As Integer = (pictureBox.Width - _moduleSize) / 2
            Dim alignmentBoxY As Integer = (pictureBox.Height - _moduleSize) / 2
            Dim alignmentBoxWidth As Integer = _moduleSize
            Dim alignmentBoxHeight As Integer = _moduleSize

            offScreenDC.DrawRectangle(New Pen(alignmentBoxColor), alignmentBoxX, alignmentBoxY, alignmentBoxWidth, alignmentBoxHeight)

            ' Draw position box
            Dim positionBoxX As Integer = (pictureBox.Width - _moduleSize) / 2 + _offsetX
            Dim positionBoxY As Integer = (pictureBox.Height - _moduleSize) / 2
            Dim positionBoxWidth As Integer = _moduleSize
            Dim positionBoxHeight As Integer = _moduleSize

            offScreenDC.DrawRectangle(New Pen(positionBoxColor), positionBoxX, positionBoxY, positionBoxWidth, positionBoxHeight)

            ' Draw synchronization box
            Dim syncBoxX As Integer = (pictureBox.Width - _moduleSize) / 2
            Dim syncBoxY As Integer = (pictureBox.Height - _moduleSize) / 2 + _offsetY
            Dim syncBoxWidth As Integer = _moduleSize
            Dim syncBoxHeight As Integer = _moduleSize

            offScreenDC.DrawRectangle(New Pen(syncBoxColor), syncBoxX, syncBoxY, syncBoxWidth, syncBoxHeight)

            ' Set the image of the PictureBox to the bitmap
            pictureBox.Image = canvasTimeDomain

            ' Dispose of the Graphics instance
            offScreenDC.Dispose()
        Catch ex As Exception
            ' Handle any exceptions
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Sub DrawPositionBox(ByRef pictureBox As PictureBox, _offsetX As Double, _offsetY As Double, _moduleSize As Integer)
        Try
            ' Create a new bitmap for drawing the box
            Dim canvasTimeDomain = New Bitmap(pictureBox.Width, pictureBox.Height)
            Dim offScreenDC As Graphics = Graphics.FromImage(canvasTimeDomain)

            ' Define colors for the boxes
            Dim positionBoxColor As Color = Color.Green

            ' Draw position box
            Dim positionBoxX As Integer = (pictureBox.Width - _moduleSize) / 2 + _offsetX
            Dim positionBoxY As Integer = (pictureBox.Height - _moduleSize) / 2
            Dim positionBoxWidth As Integer = _moduleSize
            Dim positionBoxHeight As Integer = _moduleSize

            offScreenDC.DrawRectangle(New Pen(positionBoxColor), positionBoxX, positionBoxY, positionBoxWidth, positionBoxHeight)

            ' Set the image of the PictureBox to the bitmap
            pictureBox.Image = canvasTimeDomain

            ' Dispose of the Graphics instance
            offScreenDC.Dispose()
        Catch ex As Exception
            ' Handle any exceptions
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub DrawSynchronizationBox(ByRef pictureBox As PictureBox, _offsetY As Double, _moduleSize As Integer)
        Try
            ' Create a new bitmap for drawing the box
            Dim canvasTimeDomain = New Bitmap(pictureBox.Width, pictureBox.Height)
            Dim offScreenDC As Graphics = Graphics.FromImage(canvasTimeDomain)

            ' Define colors for the boxes
            Dim syncBoxColor As Color = Color.Blue

            ' Draw synchronization box
            Dim syncBoxX As Integer = (pictureBox.Width - _moduleSize) / 2
            Dim syncBoxY As Integer = (pictureBox.Height - _moduleSize) / 2 + _offsetY
            Dim syncBoxWidth As Integer = _moduleSize
            Dim syncBoxHeight As Integer = _moduleSize

            offScreenDC.DrawRectangle(New Pen(syncBoxColor), syncBoxX, syncBoxY, syncBoxWidth, syncBoxHeight)

            ' Set the image of the PictureBox to the bitmap
            pictureBox.Image = canvasTimeDomain

            ' Dispose of the Graphics instance
            offScreenDC.Dispose()
        Catch ex As Exception
            ' Handle any exceptions
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub DrawVersionInformationBoxes(ByRef pictureBox As PictureBox, _version As Integer, _moduleSize As Integer)
        Try
            ' Create a new bitmap for drawing the boxes
            Dim canvasTimeDomain = New Bitmap(pictureBox.Width, pictureBox.Height)
            Dim offScreenDC As Graphics = Graphics.FromImage(canvasTimeDomain)

            ' Define colors for the boxes
            Dim versionBoxColor As Color = Color.Red

            ' Calculate the coordinates of the version information boxes
            Dim versionBox1X As Integer = (pictureBox.Width - _moduleSize) / 2 + 10
            Dim versionBox1Y As Integer = (pictureBox.Height - _moduleSize) / 2 - 10
            Dim versionBox2X As Integer = (pictureBox.Width - _moduleSize) / 2 + 10
            Dim versionBox2Y As Integer = (pictureBox.Height - _moduleSize) / 2 + 10

            ' Draw the version information boxes
            offScreenDC.DrawRectangle(New Pen(versionBoxColor), versionBox1X, versionBox1Y, _moduleSize, _moduleSize)
            offScreenDC.DrawRectangle(New Pen(versionBoxColor), versionBox2X, versionBox2Y, _moduleSize, _moduleSize)

            ' Write the version number to the boxes
            Dim versionNumber As String = "V" & CStr(_version)
            Dim versionBox1Text As String = versionNumber.Substring(0, 1)
            Dim versionBox2Text As String = versionNumber.Substring(1, 1)
            offScreenDC.DrawString(versionBox1Text, New Font("Arial", 12), New SolidBrush(Color.White), versionBox1X + 5, versionBox1Y + 5)
            offScreenDC.DrawString(versionBox2Text, New Font("Arial", 12), New SolidBrush(Color.White), versionBox2X + 5, versionBox2Y + 5)

            ' Set the image of the PictureBox to the bitmap
            pictureBox.Image = canvasTimeDomain

            ' Dispose of the Graphics instance
            offScreenDC.Dispose()
        Catch ex As Exception
            ' Handle any exceptions
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
