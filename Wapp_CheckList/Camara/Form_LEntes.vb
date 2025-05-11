

Public Class Form_LEntes


    Private Sub Form_LEntes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Class Lente
        Public Tipo As String
        Public DiametroPrincipal As Integer
        Public DiametroSecundario As Integer ' Para la segunda cara en lentes combinadas
        Public Distancia As Integer
        Public IndiceRefraccion As Double
        Public DistanciaFocal As Double
        Public Aumento As Double
        Public X As Integer
        Public Y As Integer
    End Class

    Private lentes(2) As Lente
    Private currentLente As Integer = 0

    Public Sub Nuevo()
        InitializeComponent()

        ' Inicializar las lentes
        For i As Integer = 0 To 2
            lentes(i) = New Lente With {
                .Tipo = "Biconvexa",
                .DiametroPrincipal = 50,
                .DiametroSecundario = 50,
                .Distancia = 100,
                .IndiceRefraccion = 1.5,
                .X = 100 + (i * 200),
                .Y = 150
            }
        Next

        ' Configurar ComboBox
        For i As Integer = 0 To 2
            Dim cb As New ComboBox
            cb.Items.AddRange({"Biconvexa", "Bicóncava", "Plano-convexa", "Plano-cóncava", "Convexo-cóncava", "Cóncavo-convexa"})
            cb.SelectedIndex = 0
            cb.Location = New Point(50 + (i * 200), 20)
            cb.Tag = i
            AddHandler cb.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
            Me.Controls.Add(cb)

            ' TrackBar para Diámetro Principal
            Dim tbDiametroPrincipal As New TrackBar
            tbDiametroPrincipal.Minimum = 20
            tbDiametroPrincipal.Maximum = 100
            tbDiametroPrincipal.Value = 50
            tbDiametroPrincipal.Location = New Point(50 + (i * 200), 50)
            tbDiametroPrincipal.Tag = $"P{i}" ' P indica Principal
            AddHandler tbDiametroPrincipal.Scroll, AddressOf TrackBar_Diametro_Scroll
            Me.Controls.Add(tbDiametroPrincipal)

            ' TrackBar para Diámetro Secundario (para lentes combinadas)
            Dim tbDiametroSecundario As New TrackBar
            tbDiametroSecundario.Minimum = 20
            tbDiametroSecundario.Maximum = 100
            tbDiametroSecundario.Value = 50
            tbDiametroSecundario.Location = New Point(50 + (i * 200), 80)
            tbDiametroSecundario.Tag = $"S{i}" ' S indica Secundario
            AddHandler tbDiametroSecundario.Scroll, AddressOf TrackBar_Diametro_Scroll
            Me.Controls.Add(tbDiametroSecundario)

            ' TrackBar para Distancia
            Dim tbDistancia As New TrackBar
            tbDistancia.Minimum = 50
            tbDistancia.Maximum = 200
            tbDistancia.Value = 100
            tbDistancia.Location = New Point(50 + (i * 200), 110)
            tbDistancia.Tag = i
            AddHandler tbDistancia.Scroll, AddressOf TrackBar_Distancia_Scroll
            Me.Controls.Add(tbDistancia)

            ' TextBox para Índice de Refracción
            Dim txt As New TextBox
            txt.Text = "1.5"
            txt.Location = New Point(50 + (i * 200), 140)
            txt.Tag = i
            AddHandler txt.TextChanged, AddressOf TextBox_TextChanged
            Me.Controls.Add(txt)

            ' Labels para identificar los controles
            Dim lblPrincipal As New Label
            lblPrincipal.Text = "Diámetro Cara 1"
            lblPrincipal.Location = New Point(50 + (i * 200), 35)
            Me.Controls.Add(lblPrincipal)

            Dim lblSecundario As New Label
            lblSecundario.Text = "Diámetro Cara 2"
            lblSecundario.Location = New Point(50 + (i * 200), 65)
            Me.Controls.Add(lblSecundario)

            Dim lblDistancia As New Label
            lblDistancia.Text = "Distancia Focal"
            lblDistancia.Location = New Point(50 + (i * 200), 95)
            Me.Controls.Add(lblDistancia)

            Dim lblIndice As New Label
            lblIndice.Text = "Índice Refracción"
            lblIndice.Location = New Point(50 + (i * 200), 125)
            Me.Controls.Add(lblIndice)
        Next

        ' Configurar el formulario
        Me.Width = 700
        Me.Height = 450
        Me.DoubleBuffered = True
    End Sub

    Private Sub ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim cb As ComboBox = DirectCast(sender, ComboBox)
        Dim index As Integer = CInt(cb.Tag)
        lentes(index).Tipo = cb.SelectedItem.ToString()
        Me.Invalidate()
    End Sub

    Private Sub TrackBar_Diametro_Scroll(sender As Object, e As EventArgs)
        Dim tb As TrackBar = DirectCast(sender, TrackBar)
        Dim tag As String = tb.Tag.ToString()
        Dim index As Integer = CInt(tag.Substring(1))

        If tag.StartsWith("P") Then
            lentes(index).DiametroPrincipal = tb.Value
        Else
            lentes(index).DiametroSecundario = tb.Value
        End If
        Me.Invalidate()
    End Sub

    Private Sub TrackBar_Distancia_Scroll(sender As Object, e As EventArgs)
        Dim tb As TrackBar = DirectCast(sender, TrackBar)
        Dim index As Integer = CInt(tb.Tag)
        lentes(index).Distancia = tb.Value
        Me.Invalidate()
    End Sub

    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs)
        Dim txt As TextBox = DirectCast(sender, TextBox)
        Dim index As Integer = CInt(txt.Tag)
        Double.TryParse(txt.Text, lentes(index).IndiceRefraccion)
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        ' Dibujar cada lente
        For Each lente In lentes
            DibujarLente1(e.Graphics, lente)
            CalcularYMostrarAumento1(e.Graphics, lente)
        Next
    End Sub

    Private Sub DibujarLente1(g As Graphics, lente As Lente)
        Dim pen As New Pen(Color.Black, 2)
        Dim midY As Single = lente.Y - lente.DiametroPrincipal / 1.5
        Dim midX As Single = lente.X - lente.DiametroPrincipal / 2

        Select Case lente.Tipo
            Case "Biconvexa"
                ' Dibujar lente biconvexa
                g.DrawArc(pen, midX, midY, lente.DiametroPrincipal, lente.DiametroPrincipal, 0, 180)
                g.DrawArc(pen, midX, midY, lente.DiametroPrincipal, lente.DiametroPrincipal, 180, 180)

            Case "Bicóncava"
                ' Dibujar lente bicóncava
                g.DrawArc(pen, midX, midY, lente.DiametroPrincipal, lente.DiametroPrincipal, 0, -180)
                g.DrawArc(pen, midX, midY, lente.DiametroPrincipal, lente.DiametroPrincipal, 180, -180)

            Case "Plano-convexa"
                ' Dibujar lente plano-convexa
                g.DrawLine(pen, lente.X, CInt(lente.Y - lente.DiametroPrincipal / 2), lente.X, CInt(lente.Y + lente.DiametroPrincipal / 2))
                g.DrawArc(pen, CInt(lente.X - lente.DiametroPrincipal / 2), midY, lente.DiametroPrincipal, lente.DiametroPrincipal, -90, 180)

            Case "Plano-cóncava"
                ' Dibujar lente plano-cóncava
                g.DrawLine(pen, lente.X - lente.DiametroPrincipal, CInt(lente.Y - lente.DiametroPrincipal / 2), lente.X - lente.DiametroPrincipal, CInt(lente.Y + lente.DiametroPrincipal / 2))
                g.DrawArc(pen, midX, midY, lente.DiametroPrincipal, lente.DiametroPrincipal, 90, 180)

            Case "Convexo-cóncava"
                ' Dibujar lente convexa-cóncava (menisco convergente)
                g.DrawArc(pen, midX, midY, lente.DiametroPrincipal, lente.DiametroPrincipal, 0, 180)
                g.DrawArc(pen, CInt(lente.X - lente.DiametroSecundario / 2), CInt(lente.Y - lente.DiametroSecundario / 2), lente.DiametroSecundario, lente.DiametroSecundario, 180, -180)

            Case "Cóncavo-convexa"
                ' Dibujar lente cóncava-convexa (menisco divergente)
                g.DrawArc(pen, midX, midY, lente.DiametroPrincipal, lente.DiametroPrincipal, 0, -180)
                g.DrawArc(pen, CInt(lente.X - lente.DiametroSecundario / 2), CInt(lente.Y - lente.DiametroSecundario / 2), lente.DiametroSecundario, lente.DiametroSecundario, 180, 180)
        End Select
    End Sub


    Private Sub CalcularYMostrarAumento1(g As Graphics, lente As Lente)
        ' Cálculo del aumento considerando ambos diámetros para lentes combinadas
        Dim aumentoPrincipal As Double = lente.IndiceRefraccion * (lente.DiametroPrincipal / 100.0)
        Dim aumentoSecundario As Double = lente.IndiceRefraccion * (lente.DiametroSecundario / 100.0)
        Dim aumentoTotal As Double = (aumentoPrincipal + aumentoSecundario) / 2 * (lente.Distancia / 100.0)

        ' Mostrar el aumento debajo de la lente
        g.DrawString($"Aumento: {aumentoTotal:F2}x",
                    New Font("Arial", 8),
                    Brushes.Black,
                    lente.X - 30,
                    lente.Y + Math.Max(lente.DiametroPrincipal, lente.DiametroSecundario))
    End Sub

#Region "Cordic"

    Sub MainCordic()
        ' Ángulo en grados
        Dim theta As Double = 30.0

        ' Convertir el ángulo a radianes
        Dim thetaRad As Double = theta * Math.PI / 180.0

        ' Variables para almacenar los resultados del seno y el coseno
        Dim cosTheta As Double
        Dim sinTheta As Double

        ' Llamar al algoritmo CORDIC
        CORDIC(thetaRad, cosTheta, sinTheta)

        ' Mostrar los resultados
        Console.WriteLine("Ángulo: " & theta & " grados")
        Console.WriteLine("Coseno: " & cosTheta)
        Console.WriteLine("Seno: " & sinTheta)

        ' Pausar la consola para ver los resultados
        Console.ReadLine()
    End Sub

    Sub CORDIC(ByVal theta As Double, ByRef cosTheta As Double, ByRef sinTheta As Double)
        Const K As Double = 0.607252935
        Dim x As Double = K
        Dim y As Double = 0
        Dim z As Double = theta

        ' Ángulos de rotación predefinidos en radianes
        Dim angles() As Double = {0.785398163, 0.463647609, 0.244978663, 0.124354995, 0.06241881, 0.031239833, 0.015623729, 0.007812341, 0.00390623, 0.001953123}

        For i As Integer = 0 To angles.Length - 1
            Dim di As Integer = If(z >= 0, 1, -1)
            Dim xi As Double = x - di * y * 2 ^ -i
            Dim yi As Double = y + di * x * 2 ^ -i
            Dim zi As Double = z - di * angles(i)
            x = xi
            y = yi
            z = zi
        Next

        cosTheta = x
        sinTheta = y
    End Sub
#End Region


#Region "Taylor"


    Sub MainTaylor()
        ' Ángulo en grados
        Dim theta As Double = 30.0

        ' Convertir el ángulo a radianes
        Dim thetaRad As Double = theta * Math.PI / 180.0

        ' Calcular el seno y el coseno usando series de Taylor
        Dim sinTheta As Double = TaylorSeriesSin(thetaRad)
        Dim cosTheta As Double = TaylorSeriesCos(thetaRad)

        ' Mostrar los resultados
        Console.WriteLine("Ángulo: " & theta & " grados")
        Console.WriteLine("Seno (Serie de Taylor): " & sinTheta)
        Console.WriteLine("Coseno (Serie de Taylor): " & cosTheta)

        ' Pausar la consola para ver los resultados
        Console.ReadLine()
    End Sub

    Function TaylorSeriesSin(x As Double, Optional terms As Integer = 10) As Double
            Dim result As Double = 0.0
            Dim sign As Integer = 1

            For n As Integer = 0 To terms - 1
                Dim term As Double = sign * (x ^ (2 * n + 1)) / Factorial(2 * n + 1)
                result += term
                sign = -sign
            Next

            Return result
        End Function

        Function TaylorSeriesCos(x As Double, Optional terms As Integer = 10) As Double
            Dim result As Double = 0.0
            Dim sign As Integer = 1

            For n As Integer = 0 To terms - 1
                Dim term As Double = sign * (x ^ (2 * n)) / Factorial(2 * n)
                result += term
                sign = -sign
            Next

            Return result
        End Function

        Function Factorial(n As Integer) As Double
            If n = 0 Then
                Return 1
            Else
                Return n * Factorial(n - 1)
            End If
        End Function

#End Region

    Public Tipo As String
    Public DiametroPrincipal As Integer
    Public DiametroSecundario As Integer
    Public Distancia As Integer
    Public IndiceRefraccion As Double
    Public PotenciaTotal As Double
    Public X As Integer
    Public Y As Integer

    ' Propiedades calculadas
    Public ReadOnly Property PotenciaTotal1 As Double
        Get
            Dim R1, R2 As Double
            R1 = DiametroPrincipal / 2
            R2 = DiametroSecundario / 2

            Select Case Tipo
                Case "Biconvexa"
                    Return (IndiceRefraccion - 1) * (1 / R1 + 1 / R2)
                Case "Bicóncava"
                    Return -(IndiceRefraccion - 1) * (1 / R1 + 1 / R2)
                Case "Plano-convexa"
                    Return (IndiceRefraccion - 1) * (1 / R1)
                Case "Plano-cóncava"
                    Return -(IndiceRefraccion - 1) * (1 / R1)
                Case "Convexo-cóncava"
                    Return (IndiceRefraccion - 1) * (1 / R1 - 1 / R2)
                Case "Cóncavo-convexa"
                    Return (IndiceRefraccion - 1) * (-1 / R1 + 1 / R2)
                Case Else
                    Return 0
            End Select
        End Get
    End Property

    Public ReadOnly Property DistanciaFocal As Double
        Get
            If PotenciaTotal <> 0 Then
                Return 1 / PotenciaTotal
            End If
            Return 0
        End Get
    End Property

    Public ReadOnly Property Aumento As Double
        Get
            If DistanciaFocal <> 0 Then
                Return -Distancia / DistanciaFocal
            End If
            Return 0
        End Get
    End Property

    Private Sub DibujarLente(g As Graphics, lente As Lente)
    Dim pen As New Pen(Color.Black, 2)
    Const escala As Integer = 1

    ' Convertir todos los valores a Integer usando CInt
    Dim radio1 As Integer = CInt(lente.DiametroPrincipal * escala)
    Dim radio2 As Integer = CInt(lente.DiametroSecundario * escala)
    Dim altura As Integer = Math.Max(radio1, radio2)

    ' Coordenadas base
    Dim centroX As Integer = lente.X
    Dim centroY As Integer = lente.Y

    ' Coordenadas para DrawArc
    Dim x1 As Integer = CInt(centroX - radio1)
    Dim y1 As Integer = CInt(centroY - altura / 2)
    Dim x2 As Integer = CInt(centroX - radio2)
    Dim y2 As Integer = CInt(centroY - altura / 2)

    Select Case lente.Tipo
        Case "Biconvexa"
            g.DrawArc(pen, x1, y1,
            CInt(radio1 * 2), altura,
            CInt(-90), CInt(180))
            g.DrawArc(pen, x1, y1,
            CInt(radio1 * 2), altura,
            CInt(90), CInt(180))

        Case "Bicóncava"
            g.DrawArc(pen, x1, y1,
            CInt(radio1 * 2), altura,
            CInt(90), CInt(-180))
            g.DrawArc(pen, x1, y1,
            CInt(radio1 * 2), altura,
            CInt(-90), CInt(-180))

        Case "Plano-convexa"
            g.DrawLine(pen,
            CInt(centroX - radio1 / 2), CInt(centroY - altura / 2),
            CInt(centroX - radio1 / 2), CInt(centroY + altura / 2))
            g.DrawArc(pen, x1, y1,
            CInt(radio1 * 2), altura,
            CInt(-90), CInt(180))

        Case "Plano-cóncava"
            g.DrawLine(pen,
            CInt(centroX + radio1 / 2), CInt(centroY - altura / 2),
            CInt(centroX + radio1 / 2), CInt(centroY + altura / 2))
            g.DrawArc(pen, x1, y1,
            CInt(radio1 * 2), altura,
            CInt(90), CInt(180))

        Case "Convexo-cóncava"
            g.DrawArc(pen, x1, y1,
            CInt(radio1 * 2), altura,
            CInt(-90), CInt(180))
            g.DrawArc(pen, x2, y2,
            CInt(radio2 * 2), altura,
            CInt(90), CInt(180))

        Case "Cóncavo-convexa"
            g.DrawArc(pen, x1, y1,
            CInt(radio1 * 2), altura,
            CInt(90), CInt(-180))
            g.DrawArc(pen, x2, y2,
            CInt(radio2 * 2), altura,
            CInt(90), CInt(180))
    End Select

    ' Dibujar información de la lente
    Using font As New Font("Arial", 8)
        g.DrawString($"n = {lente.IndiceRefraccion:F2}", font, Brushes.Black,
        CInt(centroX - 20), CInt(centroY - altura / 2 - 20))
        g.DrawString($"f = {lente.DistanciaFocal:F1} mm", font, Brushes.Black,
        CInt(centroX - 20), CInt(centroY - altura / 2 - 35))
        g.DrawString($"M = {lente.Aumento:F2}x", font, Brushes.Black,
        CInt(centroX - 20), CInt(centroY + altura / 2 + 10))
    End Using
End Sub


End Class