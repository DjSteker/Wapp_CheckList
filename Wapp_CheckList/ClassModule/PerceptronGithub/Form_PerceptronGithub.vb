

Imports WApp_ProcesadoSonido.Data
Imports WApp_ProcesadoSonido.Network
Imports WApp_ProcesadoSonido.Randoms
Imports WApp_ProcesadoSonido.Activation
Imports WApp_ProcesadoSonido.Utilities


Imports WApp_ProcesadoSonido.BaseDatos


Public Class Form_PerceptronGithub


    Dim Network_LearningRate_Initial As Double = 0.0000001

    Private Sub Form_PerceptronGithub_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            MapaBitsPictureBox1 = New Bitmap(DireccionBMP)
            PictureBox1.Image = MapaBitsPictureBox1
            ' Dim Training As New List(Of Training)
            Training.Add(New Training({0, 1}, {0}))
            Training.Add(New Training({0, 0}, {0}))
            Training.Add(New Training({1, 0}, {0}))
            Training.Add(New Training({1, 1}, {0}))
            Training.Add(New Training({0.5, 0.5}, {1}))
            Training.Add(New Training({1, 0.5}, {0.5}))
            Training.Add(New Training({0.5, 1}, {0.5}))
            Training.Add(New Training({0, 0.5}, {0.5}))
            Training.Add(New Training({0.5, 0}, {0.5}))

        Catch ex As Exception

        End Try
        Try
            ComboBox_CerebrosLista.Items.Clear()

            For Each Cerebro As ClassArchivo_Cerebro In Class_CerebrosXML.ObtenerTodos
                ComboBox_CerebrosLista.Items.Add(Cerebro.Nombre)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Dim X1 As New List(Of vector2)
    Dim X2 As New List(Of vector2)
    Dim Y1 As New List(Of vector2)
    Dim Network As MultilayerPerceptron
    Dim Training As New List(Of Training)
    Dim DireccionBMP As String = My.Application.Info.DirectoryPath & "\Resources\Init_1.bmp"
    Private SymbolFont As Font = New Font("Symbol", 14, FontStyle.Bold)
    Dim MapaBitsPictureBox1 As Bitmap

    Delegate Sub DelegateImagen(ByVal IMG As Bitmap)
    Private Sub Img(ByVal Imagen As Bitmap)
        If Me.PictureBox1.InvokeRequired Then
            Dim d As New DelegateImagen(AddressOf Img)
            'Call PictureBox1.Invoke(d, New Object() {Imagen})
            Call PictureBox1.Invoke(d, New Object() {Imagen})
        Else
            PictureBox1.Image = Imagen
            PictureBox1.Invalidate()
            PictureBox2.Invalidate()
        End If
    End Sub
    Private Sub Img2(Imagen As Bitmap)

        If Me.PictureBox2.InvokeRequired Then
            Dim d As New DelegateImagen(AddressOf Img2)
            Call PictureBox2.Invoke(d, New Object() {Imagen})
            Try
                'PictureBox2.Image = Imagen
                'PictureBox1.Invalidate()
            Catch ex As Exception

            End Try
        Else
            PictureBox2.Image = Imagen
            PictureBox1.Invalidate()
            PictureBox2.Invalidate()
        End If


    End Sub



    Delegate Sub DelegateMensaje(ByVal MSG As String)
    Private Sub msg(ByVal Mensaje As String)
        If Me.RichTextBox1.InvokeRequired Then
            Dim d As New DelegateMensaje(AddressOf msg)
            Call RichTextBox1.Invoke(d, New Object() {Mensaje})
        Else
            RichTextBox1.Text &= Environment.NewLine & Mensaje
        End If
    End Sub




    Private Sub Button_GenerarRed_Click(sender As Object, e As EventArgs) Handles Button_GenerarRed.Click
        Try
            RichTextBox1.Text = ""
            Dim standard As New Standard(New Range(-1, 1), DateTime.Now.Millisecond)
            Dim num_hidden_A() As Integer
            If TextBox_Capas.Text = 1 Then
                num_hidden_A = {TextBox_Neuronas.Text}
            ElseIf TextBox_Capas.Text = 1 Then
                num_hidden_A = {TextBox_Neuronas.Text, TextBox_Neuronas.Text}

            Else
                num_hidden_A = {TextBox_Neuronas.Text, TextBox_Neuronas.Text, TextBox_Neuronas.Text}
            End If

            If ListBox_Neuronas.Items.Count > 0 Then
                Dim num_hidden_B(ListBox_Neuronas.Items.Count - 1) As Integer

                For indice As Integer = 0 To ListBox_Neuronas.Items.Count - 1
                    If CInt(ListBox_Neuronas.Items.Item(indice)) <> 0 Then
                        num_hidden_B.SetValue(CInt(ListBox_Neuronas.Items.Item(indice)), indice)
                    End If



                Next
                Network = New MultilayerPerceptron(TextBox_ConexionesNumero.Text, num_hidden_B, TextBox_Salidas.Text, Replace(TextBox_AlfaEntrenamiento.Text, ".", ","), Replace(TextBox_Momento.Text, ".", ","), standard, New BipolarSigmoid(0.5))
            Else
                Network = New MultilayerPerceptron(TextBox_ConexionesNumero.Text, num_hidden_A, TextBox_Salidas.Text, Replace(TextBox_AlfaEntrenamiento.Text, ".", ","), Replace(TextBox_Momento.Text, ".", ","), standard, New BipolarSigmoid(0.5))

            End If



            ' Network = New MultilayerPerceptron(TextBox_ConexionesNumero.Text, num_hidden_A, TextBox_Salidas.Text, Replace(TextBox_AlfaEntrenamiento.Text, ".", ","), Replace(TextBox_Momento.Text, ".", ","), standard, New BipolarSigmoid(0.5))
        Catch ex As Exception

        End Try
        Try

            Red_Paint(PictureBox_ImagenRed, PictureBox_ImagenRed.CreateGraphics)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Button_GenerarRed2_Click_1(sender As Object, e As EventArgs) Handles Button_GenerarRed2.Click
        Try
            Dim entradas As List(Of Double()) = New List(Of Double())()
            Dim salidas As List(Of Double()) = New List(Of Double())()
            For i As Integer = 0 To 4 - 1
                entradas.Add(New Double(1) {})
                salidas.Add(New Double(0) {})
            Next

            entradas(0)(0) = 0
            entradas(0)(1) = 0
            salidas(0)(0) = 1
            entradas(1)(0) = 0
            entradas(1)(1) = 1
            salidas(1)(0) = 0
            entradas(2)(0) = 1
            entradas(2)(1) = 0
            salidas(2)(0) = 0
            entradas(3)(0) = 1
            entradas(3)(1) = 1
            salidas(3)(0) = 1

            Dim num_perlayer(0 To 2 + ListBox_Neuronas.Items.Count - 1) As Integer

            num_perlayer.SetValue(CInt(TextBox_Salidas.Text), num_perlayer.Count - 1)
            num_perlayer.SetValue(CInt(TextBox_ConexionesNumero.Text), 0)


            For indice As Integer = 0 To ListBox_Neuronas.Items.Count - 1
                num_perlayer.SetValue(CInt(ListBox_Neuronas.Items.Item(indice)), indice + 1)
            Next

            'RedCerebro = New Perceptron(num_perlayer)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_GenerarRed2_Click(sender As Object, e As EventArgs) Handles Button_GenerarRed2.Click

    End Sub


    Private Sub Red_Paint(sender As Object, ByVal g As Graphics) ' Handles MyBase.Paint
        Try
            sender.Invalidate()
            Dim PenLinea1 As New Pen(Color.Black)
            ' Draw the neural network
            Dim input As Integer = Network.InputLayer.Neurons.Count
            Dim layers As Integer = Network.Layers.Count - 2
            Dim hidden As Integer = Network.Layers.Item(1).Neurons.Count
            Dim output As Integer = Network.OutputLayer.Neurons.Count
            ' Dim g As Graphics = e.Graphics
            ' draw input values
            Dim i1 As Integer = 0
            Do While (i1 < input)
                'g.DrawString(Me.inputs(CurrentCount, i1).ToString, Font, Brushes.Navy, (((ClientRectangle.Width - (input * 50)) / 2) + ((i1 * 50) + 15)), 5, New StringFormat)
                i1 = (i1 + 1)
            Loop

            ' g.DrawString(CurrentCount.ToString, Font, Brushes.Green, (ClientRectangle.Width - 20), 5, New StringFormat)
            ' draw input layer
            Dim i2 As Integer = 0
            Do While (i2 < input)
                ' center around client
                Dim x1 As Integer = (((TabPage2.Width - (input * 50)) / 2) + (i2 * 50))
                g.DrawEllipse(PenLinea1, x1, 20, 30, 30)
                g.DrawString("S", SymbolFont, Brushes.Green, (((sender.Width - (input * 50)) / 2) + ((i2 * 50) + 5)), (20 + 5))
                i2 = (i2 + 1)
            Loop

            ' draw hidden layer
            Dim i3 As Integer = 0
            Do While (i3 < hidden)
                Dim x1 As Integer = (((TabPage2.Width - (hidden * 50)) / 2) + (i3 * 50))
                g.DrawEllipse(Pens.Black, x1, 70, 30, 30)
                g.DrawString("S", SymbolFont, Brushes.Green, ((((sender.Width - (hidden * 50)) + 5) / 2) + (i3 * 50)), (70 + 5))
                i3 = (i3 + 1)
            Loop

            ' draw output layer
            Dim i4 As Integer = 0
            Do While (i4 < output)
                Dim x1 As Integer = (((TabPage2.Width - (output * 50)) / 2) + (i4 * 50))
                g.DrawEllipse(Pens.Black, x1, 120, 30, 30)
                g.DrawString("S", SymbolFont, Brushes.Green, (((sender.Width - (output * 50)) / 2) + ((i4 * 50) + 10)), (120 + 5))
                i4 = (i4 + 1)
            Loop
            Try
                '' draw output values
                'Dim i5 As Integer = 0
                'Do While (i5 < output)
                '    If SimulationStarted = False Then 'If SimulationStarted Then
                '        g.DrawString(CurrentOutputValue(i5), Font, Brushes.Purple, (((ClientRectangle.Width - (output * 50)) / 2) + ((i5 * 50) + 15)), 160, New StringFormat)
                '    Else
                '        g.DrawString(Me.outputs(CurrentCount, i5).ToString, Font, Brushes.Navy, (((ClientRectangle.Width - (output * 50)) / 2) + ((i5 * 50) + 15)), 160, New StringFormat)
                '    End If

                '    i5 = (i5 + 1)
                'Loop
            Catch ex As Exception

            End Try


            ' now connect each input layer to the hidden layer
            Dim i6 As Integer = 0
            Do While (i6 < input)
                Dim j As Integer = 0
                Do While (j < hidden)
                    Dim x1 As Integer = (((TabPage2.Width - (input * 50)) / 2) + ((i6 * 50) + 15))
                    Dim x2 As Integer = 50
                    Dim y1 As Integer = (((TabPage2.Width - (hidden * 50)) / 2) + ((j * 50) + 15))
                    Dim y2 As Integer = 70
                    g.DrawLine(Pens.Red, x1, 50, y2, 70)
                    j = (j + 1)
                Loop

                i6 = (i6 + 1)
            Loop

            ' now connect each hidden layer to the output layer
            Dim i7 As Integer = 0
            Do While (i7 < hidden)
                Dim j As Integer = 0
                Do While (j < output)
                    Dim x1 As Integer = (((TabPage2.Width - (hidden * 50)) / 2) + ((i7 * 50) + 15))
                    Dim x2 As Integer = 100
                    Dim y1 As Integer = (((TabPage2.Width - (output * 50)) / 2) + ((j * 50) + 15))
                    Dim y2 As Integer = 120
                    g.DrawLine(Pens.Red, x1, 100, y1, 120)
                    j = (j + 1)
                Loop

                i7 = (i7 + 1)
            Loop
            g.Flush()

            'sender.Refresh()
            'PictureBox_ImagenRed.Update()
            'PictureBox_ImagenRed.Show()
            'PictureBox1.Refresh()
            'PictureBox_ImagenRed.Image = 
            'Panel_ImagenRed.()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try



            Network.TrainProgrsive(Training, TextBox_EpocasEntrenamiento.Text, Replace(TextBox_FactorActivacion.Text, ".", ","), Replace(TextBox_Momento.Text, ".", ","))
            ' Network.TrainProgrsive(Training, TextBox_EpocasEntrenamiento.Text, Replace(TextBox_FactorActivacion.Text, ".", ","))
            msg(Network.TotalError)





        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button_EntrenamientoSencillo_Click(sender As Object, e As EventArgs) Handles Button_EntrenamientoSencillo.Click
        Try



            Network.Train(Training, TextBox_EpocasEntrenamiento.Text, Replace(TextBox_FactorActivacion.Text, ".", ","))
            ' Network.TrainProgrsive(Training, TextBox_EpocasEntrenamiento.Text, Replace(TextBox_FactorActivacion.Text, ".", ","))
            msg(Network.TotalError)





        Catch ex As Exception

        End Try
    End Sub

    Dim ctThread_Test As Threading.Thread
    Dim ctThread As Threading.Thread
    Dim result As Integer = 0
    Event Event_Mensage(ByVal EventNumber As String)


    Private Sub Button_Entrenamiento_Click(sender As Object, e As EventArgs) Handles Button_Entrenamiento.Click



        Try
            Dim DatosEntrenamiento As New Class_ArchivoEntrenamiento
            DatosEntrenamiento.data = Training
            DatosEntrenamiento.epochs = TextBox_EpocasEntrenamiento.Text
            DatosEntrenamiento.min_error = Replace(TextBox_FactorActivacion.Text, ".", ",")
            ' Dim Training As New List(Of Training)
            Network.LearningRate = Replace(TextBox_AlfaEntrenamiento.Text, ".", ",")


            RichTextBox1.Text = ""
            ctThread = New Threading.Thread(AddressOf Entrenamiento)
            AddHandler Event_Mensage, AddressOf msg
            ctThread.Start(DatosEntrenamiento)
            Threading.Thread.Sleep(300)


        Catch ex As Exception
            msg(ex.Message)
        End Try



    End Sub



    Private Sub EntrenamientoGeneCirculosDataSheet(datos As Class_ArchivoEntrenamiento)
        Try
            Dim BubleRepeticiones As Int16 = 1000
            result = BubleRepeticiones

            While Not result







                Try
                    'MapaBitsPictureBox1.
                    Dim n As Integer = 500 ' numero de registros
                    Dim p As Integer = 2 ' Propiedades de cada registros (columnas)
                    Dim Graficos As Graphics = PictureBox1.CreateGraphics
                    Dim pixelColor_Set1a As Color = Color.FromArgb(255, 255, 255, 255)
                    For indice1 As Integer = 1 To PictureBox1.Size.Height - 1
                        For incice2 As Integer = 1 To PictureBox1.Size.Width - 1
                            MapaBitsPictureBox1.SetPixel(incice2, indice1, pixelColor_Set1a)
                        Next
                    Next
                    Graficos.Clear(Color.White)
                    'Dim MapaBits As New Bitmap(PictureBox1.Image)
                    'GraficosPictureBox1 = New Bitmap(PictureBox1.Image)
                    Dim radio As Integer = 20
                    Dim PosX As Integer = PictureBox1.Width / 2
                    Dim PosY As Integer = PictureBox1.Height / 2
                    Dim angulo As Double = 45
                    Dim DibujarRadio As Boolean = False
                    Dim Distanciamiento As Double = 0.1
                    Dim Tolrancias As Double = 0.4
                    'PictureBox1.Invalidate()
                    DibujarCirculo(Graficos, radio, PosX, PosY, angulo, DibujarRadio, Distanciamiento, Tolrancias)
                    'PictureBox1.Refresh()
                    'MapaBitsPictureBox1 = New Bitmap(PictureBox1.Image)
                    'PictureBox1.Image = MapaBitsPictureBox1
                    'PictureBox1.Refresh()
                Catch ex As Exception

                End Try
                Try
                    Training = New List(Of Training)
                    'Dim Graficos As New Bitmap(PictureBox1.Image)
                    Dim PosX As Decimal = 0
                    Dim PosY As Decimal = 0
                    For indice As Integer = 1 To PictureBox1.Size.Height - 1
                        For Incice2 As Integer = 1 To PictureBox1.Size.Width - 1



                            Dim Pixel As Color = MapaBitsPictureBox1.GetPixel(Incice2, indice)
                            Dim IntensidadPixel As Decimal = (CInt(Pixel.B) + CInt(Pixel.G) + CInt(Pixel.R)) / 765
                            PosX = Incice2 / 64
                            PosY = indice / 64
                            If (PosX > 1) Then
                                PosX = 1
                            End If
                            If (PosY > 1) Then
                                PosY = 1
                            End If
                            If (IntensidadPixel > 1) Then
                                IntensidadPixel = 1
                            End If
                            Training.Add(New Training({PosX, PosY}, {IntensidadPixel}))

                        Next
                    Next

                Catch ex As Exception

                End Try







                Network.Train(Training, datos.epochs, Network.LearningRate)
                ' Network.TrainProgrsive(Training, TextBox_EpocasEntrenamiento.Text, Replace(TextBox_FactorActivacion.Text, ".", ","), Replace(TextBox_Momento.Text, ".", ","))
                If datos.epochs > 0.000001 Then
                    datos.epochs = datos.epochs - 0.000001
                End If

                'If RichTextBox1.Text.Length > 200 Then
                '    RichTextBox1.Text = RichTextBox1.Text.Skip(200 - RichTextBox1.Text.Length)
                'End If
                'RichTextBox1.Text &= Network.TotalError & vbCrLf
                msg(Network.TotalError)
                Console.WriteLine(String.Format("Total error on correctly predicting training set: {0}", Network.TotalError))
                Console.ReadLine()
                result -= 1
                Threading.Thread.Sleep(1500)


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                Try
                    Dim Test As List(Of Testing) = New List(Of Testing)
                    'Dim Test1 As Testing = New Testing({0, 0})
                    Try

                        Dim Graficos As New Bitmap(PictureBox1.Image)

                        Dim PosX As Decimal = 0
                        Dim PosY As Decimal = 0

                        For indice As Integer = 1 To PictureBox1.Size.Height - 1
                            For Incice2 As Integer = 1 To PictureBox1.Size.Width - 1



                                'Dim Pixel As Color = Graficos.GetPixel(Incice2, indice)
                                'Dim IntensidadPixel As Decimal = (CInt(Pixel.A) + CInt(Pixel.G) + CInt(Pixel.R)) / 765
                                PosX = Incice2 / 64
                                PosY = indice / 64
                                If (PosX > 1) Then
                                    PosX = 1
                                End If
                                If (PosY > 1) Then
                                    PosY = 1
                                End If
                                'If (IntensidadPixel > 1) Then
                                '    IntensidadPixel = 1
                                'End If
                                Test.Add(New Testing({PosX, PosY}))

                            Next
                        Next
                        'Test1 = Test
                    Catch ex As Exception

                    End Try
                    'Dim DatosEntrenamiento As New Class_ArchivoEntrenamiento
                    'DatosEntrenamiento.data = Training
                    'DatosEntrenamiento.epochs = TextBox_EpocasEntrenamiento.Text
                    'DatosEntrenamiento.min_error = Replace(TextBox_FactorActivacion.Text, ".", ",")
                    ' Dim Training As New List(Of Training)
                    'Network.LearningRate = Replace(TextBox_AlfaEntrenamiento.Text, ".", ",")


                    'RichTextBox1.Text = ""
                    'ctThread_Test = New Threading.Thread(AddressOf Prueba)
                    'AddHandler Event_Mensage, AddressOf msg
                    'ctThread_Test.Start(Test)
                    'Threading.Thread.Sleep(1000)
                    Prueba(Test)

                Catch ex As Exception
                    msg("0x0 " & ex.Message)
                End Try
                If Network.TotalError < 1 Then
                    Network.LearningRate = ((Network_LearningRate_Initial * 10) + (Network.LearningRate * Network.TotalError)) / 11
                ElseIf Network.TotalError < 10 Then
                    Network.LearningRate = ((Network_LearningRate_Initial * 10) + (Network.LearningRate * (Network.TotalError / 4))) / 11
                ElseIf Network.TotalError < 100 Then
                    Network.LearningRate = ((Network_LearningRate_Initial * 30) + (Network.LearningRate * (Network.TotalError / 10))) / 31
                ElseIf Network.TotalError < 1000 Then
                    Network.LearningRate = ((Network_LearningRate_Initial * 50) + (Network.LearningRate * (Network.TotalError / 100))) / 51
                End If

            End While




        Catch ex As Exception

        End Try

    End Sub
    Private Sub Entrenamiento(datos As Class_ArchivoEntrenamiento)
        Try

            result = 1000

            While Not result

                Network.Train(Training, datos.epochs, Network.LearningRate)
                ' Network.TrainProgrsive(Training, TextBox_EpocasEntrenamiento.Text, Replace(TextBox_FactorActivacion.Text, ".", ","), Replace(TextBox_Momento.Text, ".", ","))
                If datos.epochs > 0.000001 Then
                    datos.epochs = datos.epochs - 0.000001
                End If

                'If RichTextBox1.Text.Length > 200 Then
                '    RichTextBox1.Text = RichTextBox1.Text.Skip(200 - RichTextBox1.Text.Length)
                'End If
                'RichTextBox1.Text &= Network.TotalError & vbCrLf
                msg(Network.TotalError)
                Console.WriteLine(String.Format("Total error on correctly predicting training set: {0}", Network.TotalError))
                Console.ReadLine()
                result -= 1
                Threading.Thread.Sleep(1000)
            End While




        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_Test_Click(sender As Object, e As EventArgs) Handles Button_Test.Click
        Try
            Dim Test As List(Of Testing) = New List(Of Testing)
            'Dim Test1 As Testing = New Testing({0, 0})
            Try

                Dim Graficos As New Bitmap(PictureBox1.Image)

                Dim PosX As Decimal = 0
                Dim PosY As Decimal = 0

                For indice As Integer = 1 To PictureBox1.Size.Height - 1
                    For Incice2 As Integer = 1 To PictureBox1.Size.Width - 1



                        'Dim Pixel As Color = Graficos.GetPixel(Incice2, indice)
                        'Dim IntensidadPixel As Decimal = (CInt(Pixel.A) + CInt(Pixel.G) + CInt(Pixel.R)) / 765
                        PosX = Incice2 / 64
                        PosY = indice / 64
                        If (PosX > 1) Then
                            PosX = 1
                        End If
                        If (PosY > 1) Then
                            PosY = 1
                        End If
                        'If (IntensidadPixel > 1) Then
                        '    IntensidadPixel = 1
                        'End If
                        Test.Add(New Testing({PosX, PosY}))

                    Next
                Next
                'Test1 = Test
            Catch ex As Exception

            End Try
            'Dim DatosEntrenamiento As New Class_ArchivoEntrenamiento
            'DatosEntrenamiento.data = Training
            'DatosEntrenamiento.epochs = TextBox_EpocasEntrenamiento.Text
            'DatosEntrenamiento.min_error = Replace(TextBox_FactorActivacion.Text, ".", ",")
            ' Dim Training As New List(Of Training)
            Network.LearningRate = Replace(TextBox_AlfaEntrenamiento.Text, ".", ",")


            RichTextBox1.Text = ""
            ctThread_Test = New Threading.Thread(AddressOf Prueba)
            AddHandler Event_Mensage, AddressOf msg
            ctThread_Test.Start(Test)
            Threading.Thread.Sleep(30)


        Catch ex As Exception
            msg("0x0 " & ex.Message)
        End Try
    End Sub
    Private Sub Prueba(datos As List(Of Testing))
        Try


            'result = 1000

            'While Not result

            Dim Resultados As New List(Of Double)
            Resultados = Network.TestList(datos)
            msg(Network.TotalError)

            'Console.WriteLine(String.Format("Total error on correctly predicting training set: {0}", Network.TotalError))
            'Console.ReadLine()
            'result -= 1
            'End While
            Dim IndiceTotal As Integer = 0
            Dim Graficos1 As New Bitmap(PictureBox1.Image)
            Dim Graficos2 As New Bitmap(PictureBox2.Image)
            Dim PosX As Decimal = 0
            Dim PosY As Decimal = 0
            For indice1 As Integer = 1 To PictureBox2.Size.Height - 1
                For incice2 As Integer = 1 To PictureBox2.Size.Width - 1
                    'Dim Pixel As Color = Graficos.GetPixel(Incice2, indice)
                    'Dim IntensidadPixel As Decimal = (CInt(Pixel.A) + CInt(Pixel.G) + CInt(Pixel.R)) / 765
                    'PosX = Incice2 / 64
                    'PosY = indice / 64

                    Dim Pixel As Color = New Color
                    Dim brillo As Integer = Math.Abs(256 - Math.Abs(Resultados.Item(IndiceTotal)) * 766)
                    If brillo < 0 Then
                        Dim pixelColor_Set1 As Color = Color.FromArgb(100, 55, 255, 55)
                        Graficos2.SetPixel(incice2, indice1, pixelColor_Set1)
                    ElseIf brillo > 255 Then
                        Dim pixelColor_Set1 As Color = Color.FromArgb(100, 255, 5, 5)
                        Graficos2.SetPixel(incice2, indice1, pixelColor_Set1)

                    Else
                        Dim pixelColor_Set1 As Color = Color.FromArgb(255, brillo, brillo, brillo)
                        Graficos2.SetPixel(incice2, indice1, pixelColor_Set1)
                    End If



                    'Pixel.ToArgb(brillo, brillo, brillo, brillo)

                    IndiceTotal += 1
                Next
                'Img2(Graficos)

            Next



            Threading.Thread.Sleep(100)

            Img2(Graficos2)
            msg("ok")
            Dim pixelColor_Set1a As Color = Color.FromArgb(255, 255, 255, 255)
            For indice1 As Integer = 1 To PictureBox1.Size.Height - 1
                For incice2 As Integer = 1 To PictureBox1.Size.Width - 1
                    Graficos1.SetPixel(incice2, indice1, pixelColor_Set1a)
                Next
            Next

            IndiceTotal = 0
            For indice1 As Integer = 1 To PictureBox1.Size.Height - 1
                For incice2 As Integer = 1 To PictureBox1.Size.Width - 1
                    'Dim Pixel As Color = Graficos.GetPixel(Incice2, indice)
                    'Dim IntensidadPixel As Decimal = (CInt(Pixel.A) + CInt(Pixel.G) + CInt(Pixel.R)) / 765
                    'PosX = Incice2 / 64
                    'PosY = indice / 64
                    If IndiceTotal > Training.Count - 1 Then
                        Img(Graficos1)
                        Exit Sub
                    End If
                    Dim Pixel As Color = New Color
                    Dim brillo As Integer = (Training.Item(IndiceTotal).Salida.Item(0) * 765) / 3 'Math.Abs(256 - Math.Abs(Resultados.Item(IndiceTotal)) * 766)
                    If brillo < 0 Then
                        Dim pixelColor_Set1 As Color = Color.FromArgb(255, 55, 255, 55)
                        Graficos1.SetPixel(incice2, indice1, pixelColor_Set1)
                    ElseIf brillo > 255 Then
                        Dim pixelColor_Set1 As Color = Color.FromArgb(255, 255, 5, 5)
                        Graficos1.SetPixel(incice2, indice1, pixelColor_Set1)
                    Else
                        Dim pixelColor_Set1 As Color = Color.FromArgb(255, brillo, brillo, brillo)
                        Graficos1.SetPixel(incice2, indice1, pixelColor_Set1)
                    End If



                    'Pixel.ToArgb(brillo, brillo, brillo, brillo)

                    IndiceTotal += 1
                Next
                'Img2(Graficos)

            Next

            Img(Graficos1)



        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub
    Private Sub Button_DetenerNeurona_Click(sender As Object, e As EventArgs) Handles Button_DetenerNeurona.Click
        Try
            result = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_GenerarDataSet_Click(sender As Object, e As EventArgs) Handles Button_GenerarDataSet.Click
        Try



            'MapaBitsPictureBox1.
            Dim n As Integer = 500 ' numero de registros
            Dim p As Integer = 2 ' Propiedades de cada registros (columnas)
            Dim Graficos As Graphics = PictureBox1.CreateGraphics
            Dim pixelColor_Set1a As Color = Color.FromArgb(255, 255, 255, 255)
            For indice1 As Integer = 1 To PictureBox1.Size.Height - 1
                For incice2 As Integer = 1 To PictureBox1.Size.Width - 1
                    MapaBitsPictureBox1.SetPixel(incice2, indice1, pixelColor_Set1a)
                Next
            Next
            Graficos.Clear(Color.White)
            'Dim MapaBits As New Bitmap(PictureBox1.Image)
            'GraficosPictureBox1 = New Bitmap(PictureBox1.Image)
            Dim radio As Integer = 20
            Dim PosX As Integer = PictureBox1.Width / 2
            Dim PosY As Integer = PictureBox1.Height / 2
            Dim angulo As Double = 45
            Dim DibujarRadio As Boolean = False
            Dim Distanciamiento As Double = 0.1
            Dim Tolrancias As Double = 0.4
            PictureBox1.Invalidate()
            DibujarCirculo(Graficos, radio, PosX, PosY, angulo, DibujarRadio, Distanciamiento, Tolrancias)
            'PictureBox1.Refresh()
            'MapaBitsPictureBox1 = New Bitmap(PictureBox1.Image)
            PictureBox1.Image = MapaBitsPictureBox1
            PictureBox1.Refresh()
            'Img(Graficos2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DibujarCirculo(ByRef Graficos As Graphics, ByVal Radio As Integer, ByVal PosX As Integer, ByVal PosY As Integer,
                               ByVal Angulo As Double, ByVal DibujarRadio As Boolean, ByVal Distanciamiento As Double, ByVal Tolerancias As Double)
        Try
            'Mapa = New Bitmap(PictureBox1.Image, PictureBox1.Size)

            Dim Randomizar As New Random()
            Dim PenLinea1 As New Pen(Color.Black)
            Dim X1a As Single = (Radio + (Tolerancias * (Randomizar.NextDouble() - 0.5) * 10) * Math.Cos(0)) + PosX
            Dim Y1a As Single = (Radio + (Tolerancias * (Randomizar.NextDouble() - 0.5) * 10) * Math.Sin(0)) + PosY
            Dim ValorAnteriorXa As Double = X1a '(X + X2) / 2
            Dim ValorAnteriorYa As Double = Y1a '(Y + Y2) / 2

            Dim X1b As Single = (Radio + (Tolerancias * (Randomizar.NextDouble() - 0.5) * 10) * Math.Cos(0)) + PosX
            Dim Y1b As Single = (Radio + (Tolerancias * (Randomizar.NextDouble() - 0.5) * 10) * Math.Sin(0)) + PosY
            Dim ValorAnteriorXb As Double = X1b '(X + X2) / 2
            Dim ValorAnteriorYb As Double = Y1b '(Y + Y2) / 2
            Dim ColorNegro As Color = Color.Black
            'eeee
            Dim RadioRandom As Double
            For index = CInt(0) To Math.PI * 2 + 0.1 Step 0.06 '((Math.PI * 2) * 10) + 0.1 Step 0.1 'To 1777 + CInt((180 - (RadioGrafica_Reflexion + AnguloCoeficienteInflexion)) * 4.9361111111111109) '360 * Math.PI * 1.6 '55


                'X = (Radio + ((Tolerancias) * (Randomizar.Next(-500 * -1 * Tolerancias, 500 * Tolerancias)) * Distanciamiento) * Math.Cos(index)) + PosX
                'Y = (Radio + ((Tolerancias) * (Randomizar.Next(-500 * -1 * Tolerancias, 500 * Tolerancias)) * Distanciamiento) * Math.Sin(index)) + PosY
                RadioRandom = (Tolerancias * (Randomizar.NextDouble() - 0.5) * 10)
                X1a = ((Radio + RadioRandom) * Math.Cos(index)) + PosX
                Y1a = ((Radio + RadioRandom) * Math.Sin(index)) + PosY
                Dim Vector1 As New vector2
                Vector1.X = X1a
                Vector1.Y = Y1a
                X1.Add(Vector1)
                Graficos.DrawLine(PenLinea1, X1a, Y1a, X1a + 1, Y1a + 1)
                Dim pixelColor_Set1 As Color = Color.FromArgb(255, 255, 255, 255)
                MapaBitsPictureBox1.SetPixel(CInt(X1a), Y1a, pixelColor_Set1)
                ValorAnteriorXa = X1a '(X + X2) / 2
                ValorAnteriorYa = Y1a '(Y + Y2) / 2


                RadioRandom = (Tolerancias * (Randomizar.NextDouble() - 0.5) * 10)
                X1b = ((Radio / 2 + RadioRandom) * Math.Cos(index)) + PosX
                Y1b = ((Radio / 2 + RadioRandom) * Math.Sin(index)) + PosY
                Dim Vector2 As New vector2
                Vector2.X = X1b
                Vector2.Y = Y1b
                X2.Add(Vector2)
                Graficos.DrawLine(PenLinea1, X1b, Y1b, X1b + 1, Y1b + 1)
                MapaBitsPictureBox1.SetPixel(X1a, Y1a, ColorNegro)
                ValorAnteriorXa = X1b
                ValorAnteriorYa = Y1b

            Next
            If DibujarRadio Then
                Graficos.DrawLine(PenLinea1, PosX, PosY, CInt(ValorAnteriorXa), CInt(ValorAnteriorYa))
            End If
            Graficos.Flush()

            'Img(Graficos)
            ' Graficos.DrawLine(PenLinea1, CInt(250.0), CInt(250.0), CInt(ValorAnteriorX2), CInt(ValorAnteriorY2))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_GenerarEntrenaCirculo_Click(sender As Object, e As EventArgs) Handles Button_GenerarEntrenaCirculo.Click



        Try

            Dim DatosEntrenamiento As New Class_ArchivoEntrenamiento
            DatosEntrenamiento.data = Training
            DatosEntrenamiento.epochs = TextBox_EpocasEntrenamiento.Text
            DatosEntrenamiento.min_error = Replace(TextBox_FactorActivacion.Text, ".", ",")
            ' Dim Training As New List(Of Training)
            Network.LearningRate = Replace(TextBox_AlfaEntrenamiento.Text, ".", ",")
            Network_LearningRate_Initial = Network.LearningRate

            RichTextBox1.Text = ""
            ctThread = New Threading.Thread(AddressOf EntrenamientoGeneCirculosDataSheet)
            AddHandler Event_Mensage, AddressOf msg
            ctThread.Start(DatosEntrenamiento)
            Threading.Thread.Sleep(30)


        Catch ex As Exception
            msg(ex.Message)
        End Try



    End Sub

    Private Sub Button_GenerarEntrenaCirculo2_Click(sender As Object, e As EventArgs) Handles Button_GenerarEntrenaCirculo2.Click
        Try
            Training.Clear()
            Training.Add(New Training({1, 1}, {1}))
            Training.Add(New Training({0, 0}, {1}))
            Training.Add(New Training({0, 1}, {1}))
            Training.Add(New Training({1, 0}, {1}))

            Training.Add(New Training({0.5, 1}, {0}))
            Training.Add(New Training({0, 0.5}, {0}))
            Training.Add(New Training({0.5, 0}, {0}))
            Training.Add(New Training({1, 0.5}, {0}))

            Training.Add(New Training({0.5, 0.5}, {0}))
            Training.Add(New Training({0.5, 0.5}, {1}))
            'If IsNumeric(TextBox_X2.Text) = False Or IsNumeric(TextBox_X1.Text) = False Then
            '    TextBox_X2.Text = "0,5"
            '    TextBox_X1.Text = "0,5"
            'End If
            'Dim Radio As Double = Math.Sqrt(Math.Pow(Replace(TextBox_X1.Text, ".", ","), 2) + Math.Pow(Replace(TextBox_X2.Text, ".", ","), 2))
            'Dim X1a As Double = 0 '(Radio * 10) * Math.Cos(0)
            'Dim Y1a As Double = 0 '(Radio * 10) * Math.Sin(0)
            'For index = CInt(0) To Math.PI * 2 + 0.1 Step 0.09
            '    X1a = (Radio) * Math.Cos(index) + Radio
            '    Y1a = (Radio) * Math.Sin(index) + Radio
            '    Training.Add(New Training({X1a, Y1a}, {0}))
            'Next
        Catch ex As Exception

        End Try
        Try
            Dim Test As List(Of Testing) = New List(Of Testing)
            Dim Graficos As New Bitmap(PictureBox1.Image)

            Dim PosX As Decimal = 0
            Dim PosY As Decimal = 0

            For indice As Integer = 1 To PictureBox1.Size.Height - 1
                For Incice2 As Integer = 1 To PictureBox1.Size.Width - 1



                    'Dim Pixel As Color = Graficos.GetPixel(Incice2, indice)
                    'Dim IntensidadPixel As Decimal = (CInt(Pixel.A) + CInt(Pixel.G) + CInt(Pixel.R)) / 765
                    PosX = Incice2 / 64
                    PosY = indice / 64
                    If (PosX > 1) Then
                        PosX = 1
                    End If
                    If (PosY > 1) Then
                        PosY = 1
                    End If
                    'If (IntensidadPixel > 1) Then
                    '    IntensidadPixel = 1
                    'End If
                    Test.Add(New Testing({PosX, PosY}))

                Next
            Next
            'Test1 = Test
        Catch ex As Exception

        End Try
        Try
            Dim Test As List(Of Testing) = New List(Of Testing)
            'Dim Test1 As Testing = New Testing({0, 0})
            Try

                Dim Graficos As New Bitmap(PictureBox1.Image)

                Dim PosX As Decimal = 0
                Dim PosY As Decimal = 0

                For indice As Integer = 1 To PictureBox1.Size.Height - 1
                    For Incice2 As Integer = 1 To PictureBox1.Size.Width - 1



                        'Dim Pixel As Color = Graficos.GetPixel(Incice2, indice)
                        'Dim IntensidadPixel As Decimal = (CInt(Pixel.A) + CInt(Pixel.G) + CInt(Pixel.R)) / 765
                        PosX = Incice2 / 64
                        PosY = indice / 64
                        If (PosX > 1) Then
                            PosX = 1
                        End If
                        If (PosY > 1) Then
                            PosY = 1
                        End If
                        'If (IntensidadPixel > 1) Then
                        '    IntensidadPixel = 1
                        'End If
                        Test.Add(New Testing({PosX, PosY}))

                    Next
                Next
                'Test1 = Test
            Catch ex As Exception

            End Try
            'Dim DatosEntrenamiento As New Class_ArchivoEntrenamiento
            'DatosEntrenamiento.data = Training
            'DatosEntrenamiento.epochs = TextBox_EpocasEntrenamiento.Text
            'DatosEntrenamiento.min_error = Replace(TextBox_FactorActivacion.Text, ".", ",")
            ' Dim Training As New List(Of Training)
            Network.LearningRate = Replace(TextBox_AlfaEntrenamiento.Text, ".", ",")


            RichTextBox1.Text = ""
            ctThread_Test = New Threading.Thread(AddressOf Prueba)
            AddHandler Event_Mensage, AddressOf msg
            ctThread_Test.Start(Test)
            Threading.Thread.Sleep(30)


        Catch ex As Exception
            msg("0x0 " & ex.Message)
        End Try
    End Sub

    Private Sub Button_Pruebas_Click(sender As Object, e As EventArgs) Handles Button_Pruebas.Click
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_DataSheEntrenamiento_Click(sender As Object, e As EventArgs) Handles Button_DataSheEntrenamiento.Click
        Try
            Training = New List(Of Training)
            'Dim Graficos As New Bitmap(PictureBox1.Image)
            Dim PosX As Decimal = 0
            Dim PosY As Decimal = 0
            For indice As Integer = 1 To PictureBox1.Size.Height - 1
                For Incice2 As Integer = 1 To PictureBox1.Size.Width - 1



                    Dim Pixel As Color = MapaBitsPictureBox1.GetPixel(Incice2, indice)
                    Dim IntensidadPixel As Decimal = (CInt(Pixel.B) + CInt(Pixel.G) + CInt(Pixel.R)) / 765
                    PosX = Incice2 / 64
                    PosY = indice / 64
                    If (PosX > 1) Then
                        PosX = 1
                    End If
                    If (PosY > 1) Then
                        PosY = 1
                    End If
                    If (IntensidadPixel > 1) Then
                        IntensidadPixel = 1
                    End If
                    Training.Add(New Training({PosX, PosY}, {IntensidadPixel}))

                Next
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_RedImagen_Click(sender As Object, e As EventArgs) Handles Button_RedImagen.Click

    End Sub

#Region "Base de datos"


    Private Sub Button_Guardar_Click(sender As Object, e As EventArgs) Handles Button_Guardar.Click


        Try

            If Class_CerebrosXML.ExisteNombre(TextBox_GuardarNombre.Text.Trim) Then
                Dim MsgResponse As MsgBoxResult
                MsgResponse = MsgBox(" El Id. ya se encuentra en la lista " & vbCr & " ¿ desea agregarlo ? ", MsgBoxStyle.YesNo)
                If MsgResponse = MsgBoxResult.Yes Then

                Else
                    Exit Sub
                End If
            End If


            Dim ContadorRegistros As Integer = Class_Contadores.ObtenerWhereContador("CuentaCerebros").Cuenta + 1
            If Class_CerebrosXML.ExisteId(ContadorRegistros) Then
                Dim PosicionTexto As Integer = RichTextBox1.Text.Length
                RichTextBox1.Text &= "Ya existe  = " & ContadorRegistros & vbCrLf
                RichTextBox1.Select(PosicionTexto, RichTextBox1.Text.Length)
                'MsgBox("El id del contador ya existe" & vbCr & "puede modificarlo para poder agregar nuevos socios", MsgBoxStyle.Information)
                'Exit Sub
            End If



            Dim Texto As String = ""
            Dim Capa_Count As Integer = 0
            Dim nodos_Count As Integer = 0
            Dim CerebroLista As ClassArchivo_Cerebro = Network.Get_Pesos()
            CerebroLista.Id = ContadorRegistros + 1
            CerebroLista.Nombre = TextBox_GuardarNombre.Text
            CerebroLista.Delta = Network.Bias.Primed 'Network.Bias.WeightToBias.Value
            CerebroLista.TotalError = Network.TotalError

            'CerebroLista.Delt = Network.ActivationFunction
            For Each Capas As ClassArchivo_Cerebro.ClassArchivo_Capa In CerebroLista.Capas
                Capa_Count += 1
                For Each Nodos As ClassArchivo_Cerebro.ClassArchivo_Capa.ClassArchivo_Neurona In Capas.Nodos
                    nodos_Count += 1
                    Texto &= " Capa:" & Capa_Count & "  nodo:" & nodos_Count & "  Peso:" & Nodos.Peso & "  Prima:" & Network.Bias.ErrorDelta & vbCrLf
                Next
            Next
            RichTextBox1.Text = Texto
            Class_CerebrosXML.InsertarRejistro(CerebroLista)
            Class_Contadores.ModificarRejistro("CuentaCerebros", ContadorRegistros + 1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            ComboBox_CerebrosLista.Items.Clear()

            For Each Cerebro As ClassArchivo_Cerebro In Class_CerebrosXML.ObtenerTodos
                ComboBox_CerebrosLista.Items.Add(Cerebro.Nombre)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_Cargar_Click(sender As Object, e As EventArgs) Handles Button_Cargar.Click
        Try
            Dim standard As New Standard(New Range(-1, 1), DateTime.Now.Millisecond)

            Dim CerebroEstructura As ClassArchivo_Cerebro = Class_CerebrosXML.ObtenerWhereNombre(ComboBox_CerebrosLista.Text)

            Dim num_hidden() As Integer

            If CerebroEstructura.Capas.Count = 3 Then
                num_hidden = {CerebroEstructura.Capas.Item(1).Nodos.Count}
            ElseIf CerebroEstructura.Capas.Count = 4 Then
                num_hidden = {CerebroEstructura.Capas.Item(1).Nodos.Count, CerebroEstructura.Capas.Item(2).Nodos.Count}

            Else
                num_hidden = {CerebroEstructura.Capas.Item(1).Nodos.Count, CerebroEstructura.Capas.Item(2).Nodos.Count, CerebroEstructura.Capas.Item(3).Nodos.Count}
            End If


            Network = New MultilayerPerceptron(CerebroEstructura.Capas.Item(0).Nodos.Count, num_hidden, CerebroEstructura.Capas.Item(CerebroEstructura.Capas.Count - 1).Nodos.Count, Replace(TextBox_AlfaEntrenamiento.Text, ".", ","), Replace(TextBox_Momento.Text, ".", ","), standard, New BipolarSigmoid(0.5))

            TextBox_ConexionesNumero.Text = CerebroEstructura.Capas.First.Nodos.Count
            TextBox_Capas.Text = CerebroEstructura.Capas.Count - 2
            TextBox_Salidas.Text = CerebroEstructura.Capas.Last.Nodos.Count
            TextBox_Neuronas.Text = CerebroEstructura.Capas.Item(1).Nodos.Count


            Network.Set_Pesos(CerebroEstructura)



            Dim Capa_Count As Integer = 0
            Dim nodos_Count As Integer = 0
            Dim Texto As String = ""
            For Each Capas As ClassArchivo_Cerebro.ClassArchivo_Capa In CerebroEstructura.Capas
                Capa_Count += 1
                For Each Nodos As ClassArchivo_Cerebro.ClassArchivo_Capa.ClassArchivo_Neurona In Capas.Nodos
                    nodos_Count += 1
                    Texto &= " Capa:" & Capa_Count & "  nodo:" & nodos_Count & "  Peso:" & Nodos.Peso & "  Prima:" & Nodos.Primed & vbCrLf
                Next
            Next
            RichTextBox1.Text = Texto

        Catch ex As Exception

        End Try

        Try
            ListBox_Neuronas.Items.Clear()

            For Each CapaOculta In Network.HiddenLayers

                ListBox_Neuronas.Items.Add(CapaOculta.Neurons.Count)
            Next

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ComboBox_CerebrosLista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_CerebrosLista.SelectedIndexChanged
        Try
            ' TextBox_GuardarNombre.Text = ComboBox_CerebrosLista.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_CargarImagen_Click(sender As Object, e As EventArgs) Handles Button_CargarImagen.Click
        Try
            Dim OpenFileDialog1 As New OpenFileDialog
            Dim FileName As String = ""
            OpenFileDialog1.RestoreDirectory = True
            If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                FileName = OpenFileDialog1.FileName
            End If
            'PictureBox1.ImageLocation = FileName
            PictureBox1.Image = New Bitmap(FileName)
            'Dim Formato As System.Drawing.Imaging.ImageFormat = System.Drawing.Imaging.ImageFormat.Bmp
            ' ConvertBMP(FileName, Formato)
            PictureBox1.Invalidate()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_BorrarEntrenamiento_Click(sender As Object, e As EventArgs) Handles Button_BorrarEntrenamiento.Click
        Try
            Training = New List(Of Training)
            'Training.Add(New Training({TextBox_X1.Text, TextBox_X2.Text}, {TextBox_Resultado.Text}))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_Circulo_Click(sender As Object, e As EventArgs) Handles Button_Circulo.Click
        Try
            Training.Add(New Training({1, 1}, {1}))
            Training.Add(New Training({0, 0}, {1}))
            Training.Add(New Training({0, 1}, {1}))
            Training.Add(New Training({1, 0}, {1}))

            Training.Add(New Training({0.5, 1}, {1}))
            Training.Add(New Training({0, 0.5}, {1}))
            Training.Add(New Training({0.5, 0}, {1}))
            Training.Add(New Training({1, 0.5}, {1}))

            Training.Add(New Training({0.5, 0.5}, {1}))
            If IsNumeric(TextBox_X2.Text) = False Or IsNumeric(TextBox_X1.Text) = False Then
                TextBox_X2.Text = "0,3"
                TextBox_X1.Text = "0,3"
            End If
            Dim Radio As Double = Math.Sqrt(Math.Pow(Replace(TextBox_X1.Text, ".", ","), 2) + Math.Pow(Replace(TextBox_X2.Text, ".", ","), 2))
            Dim X1a As Double = 0 '(Radio * 10) * Math.Cos(0)
            Dim Y1a As Double = 0 '(Radio * 10) * Math.Sin(0)
            For index = CInt(0) To Math.PI * 2 + 0.1 Step 0.09
                X1a = (Radio) * Math.Cos(index) + Radio
                Y1a = (Radio) * Math.Sin(index) + Radio
                Training.Add(New Training({X1a, Y1a}, {0}))
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_Aentrenamiento_Click(sender As Object, e As EventArgs) Handles Button_Aentrenamiento.Click
        Try
            'Training = New List(Of Training)
            Training.Add(New Training({TextBox_X1.Text, TextBox_X2.Text}, {TextBox_Target.Text}))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_APrueba_Click(sender As Object, e As EventArgs) Handles Button_APrueba.Click
        Try
            Dim Testing1 As Testing
            Testing1 = New Testing({TextBox_X1.Text, TextBox_X2.Text})
            TextBox_Resultado.Text = Network.Test(Testing1).First.ToString

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_AñadirCapa_Click(sender As Object, e As EventArgs) Handles Button_AñadirCapa.Click
        Try
            ListBox_Neuronas.Items.Add(TextBox_Neuronas.Text)
            TextBox_Capas.Text = ListBox_Neuronas.Items.Count
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_QuitarCapa_Click(sender As Object, e As EventArgs) Handles Button_QuitarCapa.Click
        Try
            ListBox_Neuronas.Items.Remove(ListBox_Neuronas.SelectedItem)
            TextBox_Capas.Text = ListBox_Neuronas.Items.Count
        Catch ex As Exception

        End Try
    End Sub








#End Region


End Class