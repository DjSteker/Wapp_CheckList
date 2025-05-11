Public Class Class_ProPictureBox
    Inherits PictureBox

    Private _clickedPoint As Point
    Private _transformation As ProTransformation

    Public Property Transformation As ProTransformation
        Set(ByVal value As ProTransformation)
            _transformation = FixTranslation(value)
            Invalidate()
        End Set
        Get
            Return _transformation
        End Get
    End Property

    Public Sub New()
        _transformation = New ProTransformation(New Point(0, 0), 1.1F)
        AddHandler MouseDown, AddressOf OnMouseDown
        AddHandler MouseMove, AddressOf OnMouseMove
        AddHandler MouseUp, AddressOf OnMouseUp
        AddHandler MouseWheel, AddressOf OnMouseWheel
        AddHandler Resize, AddressOf OnResize
    End Sub

    Private Function FixTranslation(ByVal value As ProTransformation) As ProTransformation
        'Dim maxScale = Math.Max(CDbl(Image.Width) / ClientRectangle.Width, CDbl(Image.Height) / ClientRectangle.Height)
        'If value.Scale > maxScale Then value = value.SetScale(maxScale)
        'If value.Scale < 0.3 Then value = value.SetScale(0.3)
        'Dim rectSize = value.ConvertToIm(ClientRectangle.Size)
        'Dim max = New Size(Image.Width - rectSize.Width, Image.Height - rectSize.Height)
        'value = value.SetTranslate((New Point(Math.Min(value.Translation.X, max.Width), Math.Min(value.Translation.Y, max.Height))))

        'If value.Translation.X < 0 OrElse value.Translation.Y < 0 Then
        '    value = value.SetTranslate(New Point(Math.Max(value.Translation.X, 0), Math.Max(value.Translation.Y, 0)))
        'End If

        'Return value
        Dim maxScale = Math.Max(CDbl(Image.Width) / ClientRectangle.Width, CDbl(Image.Height) / ClientRectangle.Height)
        If value.Scale > maxScale Then
            value = value.SetScale(maxScale)
        End If
        If value.Scale < 0.3 Then
            value = value.SetScale(0.3)
        End If
        Dim rectSize = value.ConvertToIm(ClientRectangle.Size)
        Dim max = New Size(Image.Width - rectSize.Width, Image.Height - rectSize.Height)
        value = value.SetTranslate(New Point(Math.Min(value.Translation.X, max.Width), Math.Min(value.Translation.Y, max.Height)))
        If value.Translation.X < 0 OrElse value.Translation.Y < 0 Then
            value = value.SetTranslate(New Point(Math.Max(value.Translation.X, 0), Math.Max(value.Translation.Y, 0)))
        End If
        Return value
    End Function

    Private Sub OnResize(ByVal sender As Object, ByVal eventArgs As EventArgs)
        If Image Is Nothing Then Return
        Transformation = Transformation
    End Sub

    Private Sub OnMouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs)

        'If e.Delta > 0 Then
        '    zoom *= 1.2F
        'Else
        '    zoom *= 0.8F
        'End If
        'Dim image As Image = PictureBox1.Image
        'If image IsNot Nothing Then
        '    Dim width As Integer = CInt(image.Width * zoom)
        '    Dim height As Integer = CInt(image.Height * zoom)
        '    Dim x As Integer = (PictureBox1.ClientSize.Width - width) \ 2
        '    Dim y As Integer = (PictureBox1.ClientSize.Height - height) \ 2
        '    Dim mousePoint As Point = PictureBox1.PointToClient(MousePosition)
        '    Dim dx As Integer = mousePoint.X - x
        '    Dim dy As Integer = mousePoint.Y - y
        '    x = CInt(dx * (zoom - 1))
        '    y = CInt(dy * (zoom - 1))
        '    PictureBox1.Invalidate()
        '    PictureBox1.Image = New Bitmap(image, width, height)
        '    PictureBox1.Location = New Point(x, y)
        'End If

        Dim pos1 = _transformation.ConvertToIm(e.Location)

        If e.Delta > 0 Then
            _transformation = _transformation.SetScale(_transformation.Scale / 1.25)
        Else
            _transformation = _transformation.SetScale(_transformation.Scale * 1.25)
        End If

        Dim pos2 = _transformation.ConvertToIm(e.Location)
        _transformation = _transformation.AddTranslate(pos1 - CType(pos2, Size))
        '_transformation = _transformation
        Transformation = _transformation
        'Invalidate()

    End Sub

    Private Sub OnMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        ''_transformation = _transformation.SetTranslate(_clickedPoint)
        'Transformation = _transformation.SetTranslate(_clickedPoint)
        '_clickedPoint = Nothing
        If IsNothing(_clickedPoint) = False Then
            Dim p = _transformation.ConvertToIm(e.Location)
            Dim newTranslation As New Point(_transformation.Translation.X - p.X + _clickedPoint.X, _transformation.Translation.Y - p.Y + _clickedPoint.Y)
            _transformation = _transformation.SetTranslate(newTranslation)
            '_clickedPoint = Nothing
            Invalidate()
        End If
    End Sub

    Private Sub OnMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)

        If IsNothing(_clickedPoint) Then
            Return
        End If

        ' Dim p = _transformation.ConvertToIm(CType(e.Location, Size))
        'Transformation = _transformation.SetTranslate(_clickedPoint - p)
        'If _clickedPoint Is Nothing Then Return
        If e.Button.Left = e.Button Then
            Dim p = _transformation.ConvertToIm(CType(e.Location, Size))
            Dim PuntoNuevo As New Point(_clickedPoint.X - p.Width, _clickedPoint.Y - p.Height)
            'Transformation = _transformation.SetTranslate(_clickedPoint.X - p.Width, _clickedPoint.Y - p.Height)
            Transformation = _transformation.SetTranslate(PuntoNuevo)
        End If


    End Sub

    Private Sub OnMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        Focus()
        _clickedPoint = _transformation.ConvertToIm(e.Location)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim imRect = Transformation.ConvertToIm(ClientRectangle)
        e.Graphics.DrawImage(Image, ClientRectangle, imRect, GraphicsUnit.Pixel)
    End Sub

    Public Sub DecideInitialTransformation()
        Transformation = New ProTransformation(Point.Empty, Integer.MaxValue)
    End Sub


#Region ""

    Friend Sub DrawUpdate()
        Transformation = Transformation
    End Sub
    Friend Sub DrawLatitudeLine(ByVal latitude As Double)
        ' Crea un objeto Graphics a partir de la imagen
        Dim g As Graphics = Graphics.FromImage(Me.Image)

        ' Define el color y el grosor de la línea
        Dim pen As New Pen(Color.Red, 2)

        ' Calcula la posición y en la imagen basándose en la latitud
        ' Asume que la imagen abarca desde la latitud -90 hasta la latitud 90
        Dim y As Integer = Math.Sin((90 - latitude) / 180) * Me.Image.Height

        ' Dibuja la línea de latitud
        g.DrawLine(pen, 0, y, Me.Image.Width, y)

        ' Libera los recursos utilizados por el objeto Graphics
        g.Dispose()
    End Sub

    Friend Sub DrawLongitudeLine(ByVal longitude As Double)
        ' Crea un objeto Graphics a partir de la imagen
        Using g As Graphics = Graphics.FromImage(Me.Image)
            ' Define el color y el grosor de la línea
            Using pen As New Pen(Color.Blue, 2)
                ' Calcula la posición x en la imagen basándose en la longitud
                ' Asume que la imagen abarca desde la longitud -180 hasta la longitud 180
                Dim x As Integer = CInt(((longitude + 180) / 360) * Me.Image.Width)

                ' Dibuja la línea de longitud
                g.DrawLine(pen, x, 0, x, Me.Image.Height)
            End Using

        End Using
    End Sub

    'Friend Sub DrawLatitudeLine(ByVal latitude As Double)
    '    ' Crea un objeto Graphics a partir de la imagen
    '    Dim g As Graphics = Graphics.FromImage(Me.Image)

    '    ' Define el color y el grosor de la línea
    '    Dim pen As New Pen(Color.Red, 2)

    '    ' Calcula la posición y en la imagen basándose en la latitud
    '    ' Asume que la imagen abarca desde la latitud -90 hasta la latitud 90
    '    Dim y As Integer = Math.Sin((90 - latitude) / 180) * Me.Image.Height

    '    ' Dibuja la línea de latitud
    '    g.DrawLine(pen, 0, y, Me.Image.Width, y)

    '    ' Libera los recursos utilizados por el objeto Graphics
    '    g.Dispose()
    'End Sub

    Friend Sub DrawLongitudeLatitude(ByVal longitude As Double, ByVal latitude As Double)
        ' Crea un objeto Graphics a partir de la imagen
        Dim g As Graphics = Graphics.FromImage(Me.Image)
        ' Define el color y el grosor de la línea
        Dim pen1 As New Pen(Color.Blue, 2)
        Dim pen2 As New Pen(Color.Red, 2)
        ' Calcula la posición x en la imagen basándose en la longitud
        ' Asume que la imagen abarca desde la longitud -180 hasta la longitud 180
        Dim x As Integer = CInt(((longitude + 180) / 360) * Me.Image.Width)
        g.DrawLine(pen1, x, 0, x, Me.Image.Height) ' Dibuja la línea de longitud
        Dim y As Integer = Math.Sin((90 - latitude) / 180) * Me.Image.Height
        g.DrawLine(pen2, 0, y, Me.Image.Width, y) ' Dibuja la línea de latitud

        ' Libera los recursos utilizados por el objeto Graphics
        g.Dispose()
    End Sub


#End Region
#Region ""

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="f_s">la frecuencia emitida.</param>
    ''' <param name="v_s">la velocidad del emisor.</param>
    ''' <param name="v_r">la velocidad del receptor.</param>
    ''' <returns>la frecuencia que recibe el receptor</returns>
    Function FrecuenciaRecibida0(f_s As Double, v_s As Double, v_r As Double) As Double
        Dim c As Double
        c = 299792458 ' m/s
        FrecuenciaRecibida0 = f_s * (c + v_r) / (c + v_s)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="masa"> la masa del cuerpo central en kilogramos</param>
    ''' <param name="radio">el radio de la órbita en metros</param>
    ''' <returns>La función devuelve la velocidad orbital en metros por segundo</returns>
    Function VelocidadOrbital(masa As Double, radio As Double) As Double
        Dim G As Double
        G = 0.000000000066743 ' m^3/(kg*s^2)  La constante gravitacional 
        VelocidadOrbital = Math.Sqrt(G * masa / radio)
    End Function

    Function VelocidadTangencial(radio As Double, velocidadAngular As Double) As Double
        VelocidadTangencial = radio * velocidadAngular
    End Function

    ''' <summary>
    '''  velocidad angular en radianes por segundo 
    ''' </summary>
    ''' <param name="Hercios"></param>
    ''' <returns></returns>
    Function velocidadAngular(Hercios As Double) As Double
        Return 2 * Math.PI / (1 / Hercios)
    End Function

    Function velocidadLineal(velAng As Double, radio As Double) As Double
        Return velAng * radio
    End Function
    ''' <summary>
    '''  calcula el período orbital
    ''' </summary>
    ''' <param name="a">a distancia promedio entre los objetos en metros</param>
    ''' <param name="M">la suma de las masas de los objetos en kilogramos</param>
    ''' <returns>La función devuelve el período orbital en segundos. La constante gravitacional G se define como 6.6743E-11 m^3/(kg*s^2)</returns>
    Function PeriodoOrbital(a As Double, M As Double) As Double
        Dim G As Double
        G = 0.000000000066743 ' m^3/(kg*s^2) 6.6743E-11 ' m^3/(kg*s^2)
        PeriodoOrbital = 2 * Math.PI * Math.Sqrt(a ^ 3 / (G * M))
    End Function
#End Region
#Region ""
    ''' <summary>
    ''' Esta función toma como entrada el semieje mayor de la órbita (a), y las masas de los dos cuerpos en la órbita (M1 y M2), y devuelve el período de la órbita (T) en segundos.
    ''' </summary>
    ''' <param name="a"> es el semieje mayor de la órbita</param>
    ''' <param name="M1">son las masas de los dos cuerpos en la órbita</param>
    ''' <param name="M2">son las masas de los dos cuerpos en la órbita</param>
    ''' <returns>período de la órbita</returns>
    Friend Function CalcularPeriodoOrbital(a As Double, M1 As Double, M2 As Double) As Double
        Dim G As Double
        G = 6.6743 * (10 ^ -11) ' Constante de gravitación universal en m^3 kg^-1 s^-2
        Dim T As Double
        T = 2 * Math.PI * (a ^ 1.5) / Math.Sqrt(G * (M1 + M2))
        Return T
    End Function

    Friend Function RadioObjeto(Angulo As Double, Distancia As Double)
        Return Distancia * Math.Tan(Angulo) / 2 '(Distancia * Math.Sin(Angulo)) / (1 - Math.Sin(Angulo))
    End Function

    Friend Function CalcularDistancia(lat1 As Double, lon1 As Double, lat2 As Double, lon2 As Double) As Double
        Dim R As Double = 6371 ' Radio de la Tierra en kilómetros
        Dim dLat As Double = DegreeToRadian(lat2 - lat1)
        Dim dLon As Double = DegreeToRadian(lon2 - lon1)
        Dim a As Double = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(DegreeToRadian(lat1)) * Math.Cos(DegreeToRadian(lat2)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
        Dim c As Double = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a))
        Dim distance As Double = R * c
        Return distance
    End Function

    Friend Function DegreeToRadian(deg As Double) As Double
        Return deg * (Math.PI / 180)
    End Function

    Private Sub Label_VelocidadLuz_Click(sender As Object, e As EventArgs) 'Handles Label_VelocidadLuz.Click
        Try
            Dim a = RadioObjeto(0.25833333333333336, 384000)
            Dim b = 0
        Catch ex As Exception

        End Try
    End Sub

    '''' <summary>
    '''' la parte de la tierra soleada
    '''' </summary>
    '''' <param name="latitud">φ es la latitud del lugar</param>
    '''' <param name="declinacionSolar">δ es la declinación solar</param>
    '''' <param name="horaActual"></param>
    '''' <returns>H es el ángulo horario</returns>
    'Function CalcularAnguloHorario(latitud As Double, declinacionSolar As Double, horaActual As Double) As Double
    '    ' Convertir la latitud y la declinación solar a radianes
    '    Dim latitudRad As Double = latitud * (Math.PI / 180)
    '    Dim declinacionSolarRad As Double = declinacionSolar * (Math.PI / 180)

    '    ' Calcular el ángulo horario
    '    Dim anguloHorario As Double = (horaActual * 15 + 180) - 15 * LongitudLocal - AscensionRecta

    '    Return anguloHorario
    'End Function

    Friend Function CalcularDeclinacionSolar(diaDelAño As Integer) As Double
        ' Calcular el ángulo diario en radianes
        Dim ang_diario As Double = 2 * Math.PI * ((diaDelAño - 1) / 365.24)

        ' Calcular la declinación solar en radianes
        Dim declinacion As Double = 0.006918 - 0.399912 * Math.Cos(ang_diario) + 0.070257 * Math.Sin(ang_diario) - 0.006758 * Math.Cos(2 * ang_diario)

        ' Convertir la declinación solar a grados
        declinacion = declinacion * (180 / Math.PI)

        Return declinacion
    End Function

    ''' <summary>
    ''' Calcular El efeccto Doppler para un frecuencia de un emisor en movimiento  
    ''' </summary>
    ''' <param name="f_s">la frecuencia emitida.</param>
    ''' <param name="v_s">la velocidad del emisor.</param>
    ''' <param name="v_r">la velocidad del receptor.</param>
    ''' <returns>la frecuencia que recibe el receptor</returns>
    Function FrecuenciaRecibida(f_s As Double, v_s As Double, v_r As Double) As Double
        Dim c As Double
        c = 299792458 ' m/s
        FrecuenciaRecibida = f_s * (c + v_r) / (c + v_s)
    End Function
#End Region

#Region ""
    ''' <summary>
    '''  calcular la dirección geográfica de un emisor en órbita a cierta altura dada dos posiciones LATITUDE LONGITUDE
    ''' </summary>
    ''' <param name="lat1">LATITUDE 1</param>
    ''' <param name="lon1">LONGITUDE 2</param>
    ''' <param name="lat2">LATITUDE 2</param>
    ''' <param name="lon2">LONGITUDE 2</param>
    ''' <returns>distancia entre dos posiciones</returns>
    Friend Function Haversine(lat1 As Double, lon1 As Double, lat2 As Double, lon2 As Double) As Double
        Const R As Double = 6371 ' Earth's radius in km
        Dim dLat As Double, dLon As Double, a As Double, c As Double, d As Double
        dLat = Radians(lat2 - lat1)
        dLon = Radians(lon2 - lon1)
        a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(Radians(lat1)) * Math.Cos(Radians(lat2)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
        c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a))
        d = R * c
        Haversine = d
    End Function

    Function Radians(degrees As Double) As Double
        Radians = degrees * (Math.PI / 180)
    End Function

    Function AngulosDireccion3d(x1 As Double, y1 As Double, z1 As Double, x2 As Double, y2 As Double, z2 As Double) As Double()
        Dim dx As Double, dy As Double, dz As Double
        Dim alpha As Double, beta As Double, gamma As Double

        dx = x2 - x1
        dy = y2 - y1
        dz = z2 - z1

        alpha = Math.Atan(dy / dx)
        beta = Math.Atan(dz / Math.Sqrt(dx ^ 2 + dy ^ 2))
        gamma = Math.Atan(Math.Sqrt(dx ^ 2 + dy ^ 2) / dz)

        Dim Angulos3d As String = "α = " & alpha & " radianes" & vbCrLf & "β = " & beta & " radianes" & vbCrLf & "γ = " & gamma & " radianes"

        Dim DatosSalida() = New Double() {0, 0, 0}

        DatosSalida(0) = alpha
        DatosSalida(1) = beta
        DatosSalida(2) = gamma
        Return DatosSalida
    End Function

#End Region

#Region ""

    Function ConvertirCoordenadasPolarACartesiana(ByVal r As Double, ByVal θ As Double) As Point
        'Declara las variables
        Dim x As Double
        Dim y As Double
        'Calcula las coordenadas cartesianas
        x = r * Math.Cos(θ)
        y = r * Math.Sin(θ)
        'Devuelve las coordenadas cartesianas
        Return New Point(x, y)
    End Function

    ''' <summary>
    ''' calcular la trayectoria en el tiempo de un satélite que se mueve a una velocidad específica, a una altura determinada, y con un ángulo respecto a los polos
    ''' </summary>
    ''' <param name="velocidad">Velocidad del satelite</param>
    ''' <param name="altura">Altura del satelite</param>
    ''' <param name="inclinacion">Inclinacion respecto al los polos</param>
    ''' <param name="tiempo">Momento en el tiempo, para obtener la posición</param>
    ''' <returns>array con la posicion en el eje x y eje y</returns>
    Public Function CalcularTrayectoria0(ByVal velocidad As Double, ByVal altura As Double, ByVal inclinacion As Double, ByVal tiempo As Double) As Double()
        Dim DatoSalida() As Double = New Double() {0, 0}
        ' Constantes
        Dim mu As Double = 398600.4418 ' Gravitational parameter for Earth in km^3/s^2
        Dim radioTierra As Double = 6371.0 ' Average radius of Earth in km
        ' Calcula el semieje mayor a partir de la velocidad y la altura
        Dim semiejeMayor As Double = mu / (velocidad ^ 2)
        ' Calcula el periodo orbital
        Dim periodo As Double = 2 * Math.PI * Math.Sqrt(semiejeMayor ^ 3 / mu)
        ' Calcula la anomalía media
        Dim M As Double = (2 * Math.PI / periodo) * tiempo
        ' Asume órbita circular para simplificar: anomalía excéntrica E = M y anomalía verdadera v = E
        Dim v As Double = M
        ' Calcula la distancia al centro de la Tierra
        Dim r As Double = semiejeMayor * (1 - altura / (semiejeMayor + radioTierra))
        ' Calcula las coordenadas cartesianas
        Dim x As Double = r * Math.Cos(v)
        Dim y As Double = r * Math.Sin(v)
        ' Convierte a coordenadas esféricas (longitud y latitud)
        Dim latitud As Double = Math.Asin(Math.Sin(inclinacion) * Math.Sin(v))
        'Dim longitud As Double = Math.Atan2(y * Math.Cos(inclinacion), x) Mod (2 * Math.PI)
        ' Calcula la longitud teniendo en cuenta la rotación de la Tierra
        'Dim longitud As Double = (Math.Atan2(y * Math.Cos(inclinacion), x) Mod (2 * Math.PI))
        Dim Desfase As Double = (15 * tiempo * Math.PI / 180)
        Dim tasaRotacion As Double = 0.9856 ' Tasa de rotación sidérea de la Tierra en grados por minuto
        Dim desfaseAjustado As Double = tiempo * tasaRotacion Mod Desfase '(2 * Math.PI) ' Calcula el desfase ajustado con la rotación de la Tierra

        Dim longitudTierra As Double = (Math.Atan2(y * Math.Cos(inclinacion), x) Mod Desfase)
        ' Ajusta la longitud para que esté en el rango [-PI, PI]2
        If longitudTierra > Math.PI Then
            longitudTierra -= 2 * Math.PI
        End If
        ' Convierte radianes a grados
        latitud *= (180 / Math.PI)
        longitudTierra *= (180 / Math.PI)
        ' Almacena las coordenadas en el array de salida
        DatoSalida(0) = longitudTierra
        DatoSalida(1) = latitud
        ' Devuelve las coordenadas
        Return DatoSalida
    End Function

    ''' <summary>
    ''' calcular la trayectoria en el tiempo de un satélite que se mueve a una velocidad específica, a una altura determinada, y con un ángulo respecto a los polos
    ''' </summary>
    ''' <param name="velocidad">Velocidad del satelite</param>
    ''' <param name="altura">Altura del satelite</param>
    ''' <param name="inclinacion">Inclinacion respecto al los polos</param>
    ''' <param name="tiempo">Momento en el tiempo, para obtener la posición</param>
    ''' <returns>array con la posicion en el eje x y eje y</returns>
    Public Function CalcularTrayectoriaBueno(ByVal velocidad As Double, ByVal altura As Double, ByVal inclinacion As Double, ByVal tiempo As Double) As Double()
        Dim DatoSalida() As Double = New Double() {0, 0}
        ' Constantes
        Dim mu As Double = 398600.4418 ' Gravitational parameter for Earth in km^3/s^2
        Dim radioTierra As Double = 6371.0 ' Average radius of Earth in km
        ' Calcula el semieje mayor a partir de la velocidad y la altura
        Dim semiejeMayor As Double = mu / (velocidad ^ 2)
        ' Calcula el periodo orbital
        Dim periodo As Double = 2 * Math.PI * Math.Sqrt(semiejeMayor ^ 3 / mu)
        ' Calcula la anomalía media
        Dim M As Double = (2 * Math.PI / periodo) * tiempo
        ' Asume órbita circular para simplificar: anomalía excéntrica E = M y anomalía verdadera v = E
        Dim v As Double = M
        ' Calcula la distancia al centro de la Tierra
        Dim r As Double = semiejeMayor * (1 - altura / (semiejeMayor + radioTierra))
        ' Calcula las coordenadas cartesianas
        Dim x As Double = r * Math.Cos(v)
        Dim y As Double = r * Math.Sin(v)
        ' Convierte a coordenadas esféricas (longitud y latitud)
        Dim latitud As Double = Math.Asin(Math.Sin(inclinacion) * Math.Sin(v))
        'Dim longitud As Double = Math.Atan2(y * Math.Cos(inclinacion), x) Mod (2 * Math.PI)
        ' Calcula la longitud teniendo en cuenta la rotación de la Tierra
        Dim longitud As Double = (Math.Atan2(y * Math.Cos(inclinacion), x) Mod (2 * Math.PI))
        Dim Desfase As Double = (15 * tiempo * Math.PI / 180)
        Dim tasaRotacion As Double = 0.9856 ' Tasa de rotación sidérea de la Tierra en grados por minuto
        Dim desfaseAjustado As Double = tiempo * tasaRotacion 'Mod Desfase '(2 * Math.PI) ' Calcula el desfase ajustado con la rotación de la Tierra

        Dim longitudTierra As Double = (Math.Atan2(y * Math.Cos(inclinacion), x) Mod Desfase)
        ' Ajusta la longitud para que esté en el rango [-PI, PI]2
        If longitud > Math.PI Then
            longitud -= 2 * Math.PI
        End If
        ' Convierte radianes a grados
        latitud *= (180 / Math.PI)
        longitud *= (180 / Math.PI)
        ' Almacena las coordenadas en el array de salida
        DatoSalida(0) = longitud
        DatoSalida(1) = latitud
        ' Devuelve las coordenadas
        Return DatoSalida
    End Function

    Public Function CalcularTrayectoria(ByVal velocidad As Double, ByVal altura As Double, ByVal inclinacion As Double, ByVal tiempo As Double, ByVal semiejeMayor As Double) As Double()
        Dim DatoSalida() As Double = New Double() {0, 0}
        ' Constantes
        Const G As Double = 0.0000000000667408 ' Constante gravitacional
        Const Mt As Double = 5.972E+24 ' Masa de la Tierra
        Dim mu As Double = 398600.4418 ' Gravitational parameter for Earth in km^3/s^2
        Dim radioTierra As Double = 6371.0 ' Average radius of Earth in km
        ' Calcula el semieje mayor a partir de la velocidad y la altura
        'If semiejeMayor <> mu / (velocidad ^ 2) Then semiejeMayor = mu / (velocidad ^ 2)
        ' Calcula el periodo orbital
        Dim periodo As Double = 2 * Math.PI * Math.Sqrt(semiejeMayor ^ 3 / mu)
        Dim Minutos As Double = periodo / 60
        ' Calcula la anomalía media
        Dim M As Double = (2 * Math.PI / periodo) * tiempo
        ' Asume órbita circular para simplificar: anomalía excéntrica E = M y anomalía verdadera v = E
        Dim v As Double = M
        ' Calcula la distancia al centro de la Tierra
        Dim r As Double = semiejeMayor * (1 - altura / (semiejeMayor + radioTierra))
        ' Calcula las coordenadas cartesianas
        Dim x As Double = r * Math.Cos(v)
        Dim y As Double = r * Math.Sin(v)
        ' Convierte a coordenadas esféricas (longitud y latitud)
        Dim latitud As Double = Math.Asin(Math.Sin(inclinacion) * Math.Sin(v))
        'Dim longitud As Double = Math.Atan2(y * Math.Cos(inclinacion), x) Mod (2 * Math.PI)
        ' Calcula la longitud teniendo en cuenta la rotación de la Tierra
        Dim longitud As Double = (Math.Atan2(y * Math.Cos(inclinacion), x) Mod (2 * Math.PI))
        Dim Desfase As Double = (15 * tiempo * Math.PI / 180)
        Dim tasaRotacion As Double = 0.9856 ' Tasa de rotación sidérea de la Tierra en grados por minuto
        Dim desfaseAjustado As Double = tiempo * tasaRotacion 'Mod Desfase '(2 * Math.PI) ' Calcula el desfase ajustado con la rotación de la Tierra

        ' Calcula el radio orbital (distancia desde el centro de la Tierra hasta el satélite)
        Dim radioOrbital As Double = radioTierra + altura
        ' Calcula la velocidad orbital necesaria para una órbita circular
        Dim velocidadOrbital As Double = Math.Sqrt(G * Mt / radioOrbital)


        Dim longitudTierra As Double = (Math.Atan2(y * Math.Cos(inclinacion), x) Mod Desfase)
        ' Ajusta la longitud para que esté en el rango [-PI, PI]2
        If longitud > Math.PI Then
            longitud -= 2 * Math.PI
        End If
        ' Convierte radianes a grados
        latitud *= (180 / Math.PI)
        longitud *= (180 / Math.PI)
        ' Almacena las coordenadas en el array de salida
        DatoSalida(0) = longitud
        DatoSalida(1) = latitud
        ' Devuelve las coordenadas
        Return DatoSalida
    End Function
    Dim semiejeMayor As Double = 6378137
    Dim excentricidad As Double = 0.001
    Dim tiempo As Double = 24 * 3600

    Dim trayectoria As Tuple(Of Double, Double)()


    Public Function CalcularPosicion(ByVal semiejeMayor As Double, ByVal excentricidad As Double, ByVal inclinacion As Double, ByVal tiempo As Double) As Double()
        Dim DatoSalida() As Double = New Double() {0, 0}
        ' Declara las variables
        Dim r As Double
        Dim x As Double
        Dim y As Double
        'Dim θ As Double

        ' Calcula la distancia del satélite al centro de la Tierra para cada ángulo θ
        r = semiejeMayor * (1 - excentricidad ^ 2) / (1 + excentricidad * Math.Cos(tiempo))

        ' Calcula las coordenadas cartesianas
        x = r * Math.Cos(tiempo)
        y = r * Math.Sin(tiempo)

        ' Rota las coordenadas cartesianas
        x = x * Math.Cos(inclinacion) - y * Math.Sin(inclinacion)
        y = x * Math.Sin(inclinacion) + y * Math.Cos(inclinacion)

        DatoSalida(0) = x
        DatoSalida(1) = y
        ' Almacena las coordenadas cartesianas
        'CalcularPosicion = CalcularPosicion.Add(x, y)


        ' Devuelve las coordenadas cartesianas
        Return DatoSalida

    End Function

    Public Function CalcularOrbitaBaja(ByVal semiejeMayor As Double, ByVal excentricidad As Double, ByVal inclinacion As Double, ByVal desplazamientoPolar As Double, ByVal tiempo As Double) As Double()
        Dim DatoSalida() As Double = New Double() {0, 0, 0}
        ' Declara las variables
        Dim r As Double
        Dim x As Double
        Dim y As Double
        Dim θ As Double = tiempo

        r = semiejeMayor * (1 - excentricidad ^ 2) / (1 + excentricidad * Math.Cos(θ))

        ' Calcula las coordenadas cartesianas
        x = r * Math.Cos(θ)
        y = r * Math.Sin(θ)

        ' Rota las coordenadas cartesianas
        x = x * Math.Cos(inclinacion) - y * Math.Sin(inclinacion)
        y = x * Math.Sin(inclinacion) + y * Math.Cos(inclinacion)

        ' Desplaza el satélite
        x = x * Math.Cos(desplazamientoPolar) - y * Math.Sin(desplazamientoPolar)
        y = x * Math.Sin(desplazamientoPolar) + y * Math.Cos(desplazamientoPolar)

        ' Almacena las coordenadas cartesianas
        DatoSalida(0) = x
        DatoSalida(0) = y
        DatoSalida(0) = θ
        ' Devuelve las coordenadas cartesianas
        Return DatoSalida

    End Function
    Function CalcularPosicionSatelitePolar(ByVal inclinacion As Double, ByVal altura As Double, ByVal tiempo As Double) As Double()
        Const G As Double = 0.0000000000667408 ' Constante gravitacional
        Const M As Double = 5.972E+24 ' Masa de la Tierra
        Const R As Double = 6371000 ' Radio de la Tierra
        Const T As Double = 86164.1 ' Periodo de rotación de la Tierra
        Dim DatoSalida() As Double = New Double() {0, 0, 0}
        Dim a As Double = R + altura
        Dim n As Double = 2 * Math.PI / T
        Dim θ As Double = n * tiempo
        Dim r_ As Double = a * (1 - excentricidad ^ 2) / (1 + excentricidad * Math.Cos(θ))
        Dim x As Double = R * Math.Cos(θ)
        Dim y As Double = R * Math.Sin(θ)
        Dim z As Double = 0
        Dim v As Double = Math.Sqrt(G * M / r_)
        Dim vx As Double = -v * Math.Sin(θ)
        Dim vy As Double = v * Math.Cos(θ)
        Dim vz As Double = 0
        Dim i As Double = inclinacion
        Dim ω As Double = 2 * Math.PI / T
        Dim ohm As Double = 0
        Dim cosi As Double = Math.Cos(i)
        Dim sini As Double = Math.Sin(i)
        Dim cosω As Double = Math.Cos(ω)
        Dim sinω As Double = Math.Sin(ω)
        Dim cosohm As Double = Math.Cos(ω)
        Dim sinohm As Double = Math.Sin(ω)
        Dim x1 As Double = x * (cosω * cosω - sinω * sinω * cosi) + y * (-sinω * cosω - cosω * sinω * cosi) + z * (sinω * sini)
        Dim y1 As Double = x * (cosω * sinω + sinω * cosω * cosi) + y * (-sinω * sinω + cosω * cosω * cosi) + z * (-cosω * sini)
        Dim z1 As Double = x * (sinω * sini) + y * (cosω * sini) + z * (cosi)
        DatoSalida(0) = x1
        DatoSalida(1) = y1
        DatoSalida(2) = z1
        Return DatoSalida
    End Function
#End Region

#Region ""

    Public Function CalcularTrayectoriaConRotacion(ByVal velocidad As Double, ByVal altura As Double, ByVal inclinacion As Double, ByVal tiempo As Double, ByVal longitudPunto As Double, ByVal latitudPunto As Double) As Double()
        Dim DatoSalida() As Double = New Double() {0, 0, 0, 0, 0}
        ' Constantes
        Dim mu As Double = 398600.4418 ' Gravitational parameter for Earth in km^3/s^2
        Dim radioTierra As Double = 6371.0 ' Average radius of Earth in km
        Dim rotacionTierra As Double = 360 / 86164 ' Earth's rotation per second (360 degrees / 86164 seconds)
        ' Calcula el semieje mayor a partir de la velocidad y la altura
        Dim semiejeMayor As Double = mu / (velocidad ^ 2)
        ' Calcula el periodo orbital
        Dim periodo As Double = 2 * Math.PI * Math.Sqrt(semiejeMayor ^ 3 / mu)
        ' Calcula la anomalía media
        Dim M As Double = (2 * Math.PI / periodo) * tiempo
        ' Asume órbita circular para simplificar: anomalía excéntrica E = M y anomalía verdadera v = E
        Dim v As Double = M
        ' Calcula la distancia al centro de la Tierra
        Dim r As Double = semiejeMayor * (1 - altura / (semiejeMayor + radioTierra))
        ' Calcula las coordenadas cartesianas
        Dim x As Double = r * Math.Cos(v)
        Dim y As Double = r * Math.Sin(v)
        ' Convierte a coordenadas esféricas (longitud y latitud)
        Dim latitudSatelite As Double = Math.Asin(Math.Sin(inclinacion) * Math.Sin(v))
        'Dim longitud As Double = Math.Atan2(y * Math.Cos(inclinacion), x) Mod (2 * Math.PI)
        ' Calcula la longitud teniendo en cuenta la rotación de la Tierra
        Dim longitudSatelite As Double = (Math.Atan2(y * Math.Cos(inclinacion), x) Mod (2 * Math.PI))
        Dim Desfase As Double = (15 * tiempo * Math.PI / 180)
        Dim tasaRotacion As Double = 0.9856 ' Tasa de rotación sidérea de la Tierra en grados por minuto
        Dim desfaseAjustado As Double = tiempo * tasaRotacion 'Mod Desfase '(2 * Math.PI) ' Calcula el desfase ajustado con la rotación de la Tierra
        Dim desfaseRotacion As Double = rotacionTierra * tiempo

        Dim longitudTierra As Double = (Math.Atan2(y * Math.Cos(inclinacion), x) Mod Desfase)
        'longitudSatelite = (longitudSatelite * (180 / Math.PI) - desfaseRotacion) Mod (2 * Math.PI)
        ' Ajusta la longitud para que esté en el rango [-PI, PI]2
        If longitudSatelite > Math.PI Then
            longitudSatelite -= 2 * Math.PI
        End If
        ' Convierte radianes a grados
        latitudSatelite *= (180 / Math.PI)
        longitudSatelite *= (180 / Math.PI)
        Dim Angulos() As Double = AngulosDireccion3d(longitudPunto, latitudPunto, 6371.0, longitudSatelite, latitudSatelite, r)
        DatoSalida(2) = Angulos(0)
        DatoSalida(3) = Angulos(1)
        DatoSalida(4) = Angulos(2)
        ' Devuelve las coordenadas
        Return DatoSalida
    End Function


    Public Function CalcularTrayectoriaInicio(ByVal velocidad As Double, ByVal altura As Double, ByVal inclinacion As Double, ByVal tiempo As Double, ByVal anomaliaVerdaderaInicial As Double, ByVal semiejeMayor As Double) As Double()
        Dim DatoSalida() As Double = New Double() {0, 0, 0}
        ' Constantes
        Dim masaSatelite As Double = 500 'kg
        Dim G As Double = 0.000000000066743 ' Constante gravitacional en m^3/kg/s^2
        Dim mu As Double = 398600.4418 ' Gravitational parameter for Earth in km^3/s^2
        Dim radioTierra As Double = 6371.0 ' Average radius of Earth in km
        Dim masaTierra As Double = 5.972E+24 ' Masa de la Tierra en kg

        ' Calcula el radio orbital (distancia desde el centro de la Tierra hasta el satélite)
        Dim radioOrbital As Double = radioTierra + altura
        ' Calcula la velocidad orbital necesaria para una órbita circular
        Dim velocidadOrbital As Double = Math.Sqrt(G * masaTierra / radioOrbital)
        ' Calcula la fuerza centrípeta necesaria para mantener el satélite en órbita
        Dim fuerzaCentripeta As Double = masaSatelite * Math.Pow(velocidadOrbital, 2) / radioOrbital


        ' Calcula el semieje mayor a partir de la velocidad y la altura
        'Dim semiejeMayor As Double = mu / (velocidad ^ 2)
        ' Calcula el periodo orbital
        Dim periodo As Double = 2 * Math.PI * Math.Sqrt(semiejeMayor ^ 3 / mu)
        ' Calcula la anomalía media
        Dim M As Double = (2 * Math.PI / periodo) * tiempo + anomaliaVerdaderaInicial
        ' Asume órbita circular para simplificar: anomalía excéntrica E = M y anomalía verdadera v = E
        Dim angulo As Double = M
        ' Calcula la distancia al centro de la Tierra
        Dim r As Double = semiejeMayor * (1 - altura / (semiejeMayor + radioTierra))
        ' Calcula las coordenadas cartesianas
        Dim x As Double = r * Math.Cos(angulo)
        Dim y As Double = r * Math.Sin(angulo)
        ' Convierte a coordenadas esféricas (longitud y latitud)
        Dim latitud As Double = Math.Asin(Math.Sin(inclinacion) * Math.Sin(angulo))
        Dim longitud As Double = Math.Atan2(y * Math.Cos(inclinacion), x) Mod (2 * Math.PI)
        ' Ajusta la longitud para que esté en el rango [-PI, PI]
        If longitud > Math.PI Then
            longitud -= 2 * Math.PI
        End If
        ' Convierte radianes a grados
        latitud *= (180 / Math.PI)
        longitud *= (180 / Math.PI)
        ' Almacena las coordenadas en el array de salida
        DatoSalida(0) = longitud
        DatoSalida(1) = latitud
        DatoSalida(2) = fuerzaCentripeta
        Dim Angulos() As Double = AngulosDireccion3d(0, 0, 6371.0, longitud, latitud, r)
        DatoSalida(2) = Angulos(0)
        DatoSalida(3) = Angulos(1)
        DatoSalida(4) = Angulos(2)
        ' Devuelve las coordenadas
        Return DatoSalida
    End Function


    Friend Function Excentricidad1(ByVal apogeo As Double, ByVal perigeo As Double) As Double
        Return ((apogeo - perigeo) / (apogeo + perigeo))
    End Function

#End Region

#Region ""

    ''' <summary>
    ''' calcula la orbita de un satélite con una declinación polar
    ''' </summary>
    ''' <param name="inclinacion"></param>
    ''' <param name="altura"></param>
    ''' <param name="tiempo"></param>
    ''' <returns></returns>
    Function CalcularPosicionSateliteDeclinaPolar(ByVal inclinacion As Double, ByVal desplazamientoPolar As Double, ByVal altura As Double, ByVal tiempo As Double) As Double()
        Const G As Double = 0.0000000000667408 ' Constante gravitacional
        Const M As Double = 5.972E+24 ' Masa de la Tierra
        Const R As Double = 6371000 ' Radio de la Tierra
        Const T As Double = 86164.1 ' Periodo de rotación de la Tierra

        Dim DatoSalida() As Double = New Double() {0, 0, 0}
        Dim a As Double = R + altura
        Dim n As Double = 2 * Math.PI / T
        Dim θ As Double = n * tiempo
        Dim r_ As Double = a * (1 - excentricidad ^ 2) / (1 + excentricidad * Math.Cos(θ))
        Dim x As Double = R * Math.Cos(θ)
        Dim y As Double = R * Math.Sin(θ)
        Dim z As Double = 0
        Dim v As Double = Math.Sqrt(G * M / r_)
        Dim vx As Double = -v * Math.Sin(θ)
        Dim vy As Double = v * Math.Cos(θ)
        Dim vz As Double = 0
        Dim i As Double = inclinacion
        Dim ω As Double = 2 * Math.PI / T
        Dim ohm As Double = 0
        Dim cosi As Double = Math.Cos(i)
        Dim sini As Double = Math.Sin(i)

        ' Calcula las coordenadas cartesianas
        x = r_ * Math.Cos(θ)
        y = r_ * Math.Sin(θ)

        ' Rota las coordenadas cartesianas
        x = x * Math.Cos(inclinacion) - y * Math.Sin(inclinacion)
        y = x * Math.Sin(inclinacion) + y * Math.Cos(inclinacion)

        ' Desplaza el satélite
        x = x * Math.Cos(desplazamientoPolar) - y * Math.Sin(desplazamientoPolar)
        y = x * Math.Sin(desplazamientoPolar) + y * Math.Cos(desplazamientoPolar)

        ' Almacena las coordenadas cartesianas
        DatoSalida(0) = x
        DatoSalida(1) = y
        DatoSalida(2) = θ

        ' Devuelve las coordenadas cartesianas
        Return DatoSalida
    End Function
#End Region

End Class


Public Structure ProTransformation
    Public ReadOnly Property Translation As Point
        Get
            Return _translation
        End Get
    End Property

    Public ReadOnly Property Scale As Double
        Get
            Return _scale
        End Get
    End Property

    Private ReadOnly _translation As Point
    Private ReadOnly _scale As Double

    Public Sub New(ByVal translation As Point, ByVal scale As Double)
        _translation = translation
        _scale = scale
    End Sub

    Public Function ConvertToIm(ByVal p As Point) As Point
        Return New Point(CInt((p.X * _scale + _translation.X)), CInt((p.Y * _scale + _translation.Y)))
    End Function

    Public Function ConvertToIm(ByVal p As Size) As Size
        Return New Size(CInt((p.Width * _scale)), CInt((p.Height * _scale)))
    End Function

    Public Function ConvertToIm(ByVal r As Rectangle) As Rectangle
        Return New Rectangle(ConvertToIm(r.Location), ConvertToIm(r.Size))
    End Function

    Public Function ConvertToPb(ByVal p As Point) As Point
        Return New Point(CInt(((p.X - _translation.X) / _scale)), CInt(((p.Y - _translation.Y) / _scale)))
    End Function

    Public Function ConvertToPb(ByVal p As Size) As Size
        Return New Size(CInt((p.Width / _scale)), CInt((p.Height / _scale)))
    End Function

    Public Function ConvertToPb(ByVal r As Rectangle) As Rectangle
        Return New Rectangle(ConvertToPb(r.Location), ConvertToPb(r.Size))
    End Function

    Public Function SetTranslate(ByVal p As Point) As ProTransformation
        Return New ProTransformation(p, _scale)
    End Function

    Public Function AddTranslate(ByVal p As Point) As ProTransformation
        Return SetTranslate(New Point(p.X + _translation.X, p.Y + _translation.Y))
    End Function

    Public Function SetScale(ByVal scale As Double) As ProTransformation
        Return New ProTransformation(_translation, scale)
    End Function
End Structure

