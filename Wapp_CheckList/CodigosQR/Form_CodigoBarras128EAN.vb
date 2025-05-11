Public Class Form_CodigoBarras128EAN


    Shared ReadOnly Property FuenteDatos() As FontFamily
        Get
            Dim Fuente As FontFamily
            Try
                Fuente = New FontFamily("Roman")
            Catch ex As Exception
                Try
                    Fuente = New FontFamily("Terminal")
                Catch ex2 As Exception
                    Try
                        Fuente = New FontFamily("Consolas")
                    Catch ex3 As Exception
                        Fuente = New FontFamily("Impact")
                    End Try

                End Try

            End Try
            Return Fuente
        End Get

    End Property

    Private Shared Margenes_1 As System.Drawing.Printing.Margins
    Private Shared AnchoBarraFina As Single = 0.35
    Friend Shared Canvas1 As Bitmap

    Private Sub Form_CodigoBarras128EAN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Canvas1 = New Bitmap(PictureBox1.Width, PictureBox1.Height)
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
    Dim solidBrush As New SolidBrush(Color.Black)
    Dim Pos1X As Single = 0.2
    Friend Shared Pos1Y As Single = 20.4
    Dim Pos2X As Single = 2.2
    Dim Pos2Y As Single = 23.8

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim fontTitulos As New Font(FuenteDatos, 2, FontStyle.Bold, GraphicsUnit.Millimeter)
            AnchoBarraFina = TrackBar_BarraFina.Value / 1000
            '
            'Dim originalImage As Image = Image.FromFile(TextBox_ArchivoEntrada.Text)
            'Dim scaledImage As Image = New Bitmap(originalImage, New Size(320, 256))
            Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & "\BaseDatos\ODETE\OpcionesImpresion.xml"
            Dim xmlDoc As New System.Xml.XmlDocument
            xmlDoc.Load(RutaXMLConfigPrintInt)
            Dim Nudo As System.Xml.XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)


            Dim PrintSeting1 As System.Drawing.Printing.PageSettings = New System.Drawing.Printing.PageSettings
            PrintSeting1.Margins = New System.Drawing.Printing.Margins(CSng(Nudo.SelectSingleNode("Margen_izquierdo").InnerText), CSng(Nudo.SelectSingleNode("Margen_derecho").InnerText), CSng(Nudo.SelectSingleNode("Margen_superior").InnerText), CSng(Nudo.SelectSingleNode("Margen_inferior").InnerText))
            'ev.PageSettings.Margins = PrintSeting1.Margins
            PrintSeting1.Landscape = CBool(Nudo.SelectSingleNode("imp_Horizontal").InnerText)


            Margenes_1 = PrintSeting1.Margins
            Pos1X = 0.2 + Margenes_1.Left
            Pos1Y = 2.4 + Margenes_1.Top
            Pos2X = 2.2 + Margenes_1.Left
            Pos2Y = 2.8 + Margenes_1.Top

            Dim Graficos As Graphics = Graphics.FromImage(Canvas1)
            Graficos.PageUnit = GraphicsUnit.Millimeter

            Graficos.Clear(Color.FromArgb(250, 250, 250))

            For Each Linea As String In TextBox1.Lines
                Pos1Y += ObtenerA1(Graficos, fontTitulos, Linea).Y
            Next


            Try
                PictureBox1.Image = Me.Canvas1
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
    Private Shared Sub ObtenerC1(ByRef Graficos As Graphics, ByVal FuenteTitulo As Font, ByVal datos As String, ByVal IconoSeguridad As Image)
        Dim fontDatos As New Font(FuenteDatos, 11.8, FontStyle.Bold, GraphicsUnit.Millimeter)
        'Dim solidBrush As New SolidBrush(Color.FromArgb(20, 20, 20, 100))
        Dim solidBrush As New SolidBrush(Color.Black)
        Dim Pos1X As Single = 0.2 + Margenes_1.Left
        Dim Pos1Y As Single = 20.4 + Margenes_1.Top
        Dim Pos2X As Single = 2.2 + Margenes_1.Left
        Dim Pos2Y As Single = 23.8 + Margenes_1.Top
        Graficos.DrawString("CÓDIGO", FuenteTitulo, solidBrush, New PointF(Pos1X, Pos1Y))
        Graficos.DrawString("PRODUCTO (P)", FuenteTitulo, solidBrush, New PointF(Pos1X, Pos1Y + 2.2))
        Graficos.DrawString(datos, fontDatos, solidBrush, New PointF(Pos2X, Pos2Y))
        Dim GeneradorBarras As New Class_Generador128_Beta


        Dim posicionHorizontal As Single = 0.4 + Margenes_1.Left
        Dim posicionVertical As Single = 36.7 + Margenes_1.Top
        Try
            If datos <> String.Empty Then
                Dim Generador As New Class_Generador128_Beta
                Generador.Class_Initialize1()
                Dim CadenaComandos As String = Generador.ObtenerCodigoControlAuto(datos)
                Dim CaracterControl As String = Generador.Obtener_CaracterControl_Indice(1, CadenaComandos)
                Generador.ObtenerBarraEspacio("2222222222", Graficos, AnchoBarraFina, 6, posicionHorizontal, posicionVertical)
                Generador.ImprimirCodigo(CadenaComandos, CaracterControl, "Stop", Graficos, AnchoBarraFina, 6, posicionHorizontal, posicionVertical)
                Generador.ObtenerBarraEspacio("2222222222", Graficos, AnchoBarraFina, 6, posicionHorizontal, posicionVertical)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try

            Dim x As Single = 108.0F + Margenes_1.Left
            Dim y As Single = 24.0F + Margenes_1.Top
            Dim width As Single = 16.0F
            Dim height As Single = 16.0F
            Graficos.DrawImage(IconoSeguridad, x, y, width, height)

        Catch ex As Exception

        End Try


    End Sub

    Private Shared Function ObtenerA1(ByRef Graficos As Graphics, ByVal FuenteTitulo As Font, ByVal datos As String) As Point
        'Dim fontDatos As New Font(FuenteDatos, 11.8, FontStyle.Bold, GraphicsUnit.Millimeter)
        'Dim solidBrush As New SolidBrush(Color.FromArgb(20, 20, 20, 100))


        ' Dim Canvas1 As Bitmap = New Bitmap '(Graficos.ClipBounds.Width, Graficos.ClipBounds.Height)
        'Graficos = Graphics.FromImage(Canvas1)



        'Graficos.DrawString("CÓDIGO", FuenteTitulo, solidBrush, New PointF(Pos1X, Pos1Y))
        'Graficos.DrawString("PRODUCTO (P)", FuenteTitulo, solidBrush, New PointF(Pos1X, Pos1Y + 2.2))
        'Graficos.DrawString(datos, fontDatos, solidBrush, New PointF(Pos2X, Pos2Y))
        'Dim GeneradorBarras As New Class_Generador128_Beta


        Dim posicionHorizontal As Single = 0.4 + Margenes_1.Left
        Dim posicionVertical As Single = Pos1Y '0.7 + Margenes_1.Top
        Try
            If datos <> String.Empty Then
                Dim Generador As New Class_Generador128_Beta
                Generador.Class_Initialize1()
                Dim CadenaComandos As String = Generador.ObtenerCodigoControlAuto(datos)
                Dim CaracterControl As String = Generador.Obtener_CaracterControl_Indice(1, CadenaComandos)
                Generador.ObtenerBarraEspacio("2222222222", Graficos, AnchoBarraFina, 6, posicionHorizontal, posicionVertical)
                Generador.ImprimirCodigo(CadenaComandos, CaracterControl, "Stop", Graficos, AnchoBarraFina, 6, posicionHorizontal, posicionVertical)
                Generador.ObtenerBarraEspacio("2222222222", Graficos, AnchoBarraFina, 6, posicionHorizontal, posicionVertical)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Return New Point(posicionHorizontal, posicionVertical + 6)
    End Function
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        Try
            'SaveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif"
            'If SaveFileDialog1.ShowDialog().OK Then

            '    If SaveFileDialog1.FileName <> "" Then
            '        ' Saves the Image via a FileStream created by the OpenFile method.
            '        Dim fs As System.IO.FileStream = CType(SaveFileDialog1.OpenFile(), System.IO.FileStream)
            '        ' Saves the Image in the appropriate ImageFormat based upon the
            '        ' file type selected in the dialog box.
            '        ' NOTE that the FilterIndex property is one-based.
            '        Select Case SaveFileDialog1.FilterIndex
            '            Case 1
            '                Me.PictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg)

            '            Case 2
            '                Me.PictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp)

            '            Case 3
            '                Me.PictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Gif)
            '        End Select

            '        fs.Close()
            '    End If
            'End If






            'Dim g As Graphics = Graphics.FromImage(PictureBox1.Image)

            'g.FillRectangle(Brushes.AliceBlue, PictureBox1.ClientRectangle)

            'Dim lado As Integer = IIf(PictureBox1.ClientRectangle.Width < PictureBox1.ClientRectangle.Height, PictureBox1.ClientRectangle.Width, PictureBox1.ClientRectangle.Height)
            'lado *= Math.Sin(Math.PI / 4)
            'For k As Integer = 1 To 120
            '    g.TranslateTransform(PictureBox1.ClientRectangle.Width / 2, PictureBox1.ClientRectangle.Height / 2)
            '    g.RotateTransform(3)
            '    g.TranslateTransform(-PictureBox1.ClientRectangle.Width / 2, -PictureBox1.ClientRectangle.Height / 2)
            '    g.DrawRectangle(Pens.RosyBrown, (PictureBox1.ClientRectangle.Width - lado) \ 2, (PictureBox1.ClientRectangle.Height - lado) \ 2, lado, lado)
            'Next
            'g.Dispose()
            'PictureBox1.Invalidate()








            Try
                Dim saveImage As New SaveFileDialog 'Este es el SaveFileDialog
                Dim ruta As String = "" 'Para tener la ruta de la imagen

                saveImage.Title = "Guardar imagen como..." 'Título de la ventana
                saveImage.Filter = "Imagen BMP (*.bmp)|*.bmp|Imagen JPG (*.jpg)|*.jpg|Imagen PNG (*.png)|*.png" 'Los formatos en que se guardará la imagen
                If saveImage.ShowDialog() = DialogResult.OK Then ' Windows.Forms.DialogResult.OK Then
                    'Recuperar la ruta de la imagen si no está vacía
                    If Not String.IsNullOrEmpty(saveImage.FileName) Then ruta = saveImage.FileName
                    Dim mimag As Graphics = Graphics.FromImage(PictureBox1.Image) 'Objeto Image para guardar la imagen del Picture
                    Dim extension As String = ruta.Substring(ruta.Length - 3, 3) 'Recuperar los ultimos 3 caracteres de la extensión
                    Dim myImg As Image
                    myImg = PictureBox1.Image 'Guardar la imagen del PictureBox en el objeto Image

                    'ESTO SOLO FUNCIONA EN VISUAL BASIC 2008
                    Select Case extension
                        Case "bmp"
                            PictureBox1.Image.Save(ruta, System.Drawing.Imaging.ImageFormat.Bmp)
                        'myImg.Save(ruta, Imaging.ImageFormat.Bmp) 'Guardar en formato BMP
                        Case "jpg"
                            myImg.Save(ruta, Imaging.ImageFormat.Jpeg) 'Guardar en formato JPG
                        Case "png"
                            myImg.Save(ruta, Imaging.ImageFormat.Png) 'Guardar en formato PNG
                    End Select
                End If
            Catch ex As Exception
                MsgBox("Ocurrió el siguiente error: " & ex.Message, MsgBoxStyle.Critical, "Error!")
            End Try


        Catch ex As Exception

        End Try
    End Sub

    Private Sub TrackBar_BarraFina_Scroll(sender As Object, e As EventArgs) Handles TrackBar_BarraFina.Scroll
        Try
            Button1.Text = TrackBar_BarraFina.Value / 1000 & "mm"
        Catch ex As Exception

        End Try
    End Sub
End Class