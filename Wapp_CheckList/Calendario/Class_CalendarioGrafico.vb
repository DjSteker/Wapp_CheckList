
Imports System.Globalization

Namespace Calendario

    Public Class Class_CalendarioGrafico
        Inherits PictureBox

        Private _fechaActual As DateTime = DateTime.Now
        Private _diasRectangulos As New Dictionary(Of Rectangle, DateTime)
        Private _fuenteDias As New Font("Arial", 10)

        ' Propiedades personalizables
        Public Property ColorFondo As Color = Color.White
        Public Property ColorTexto As Color = Color.Black
        Public Property ColorBorde As Color = Color.Gray
        Public Property ColorDiaActual As Color = Color.LightBlue

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            DibujarCalendario(e.Graphics)
        End Sub

        Private Sub DibujarCalendario(g As Graphics)
            g.Clear(ColorFondo)
            _diasRectangulos.Clear()

            Dim tamanoCelda As New Size(40, 30)
            Dim inicioX As Integer = 10
            Dim inicioY As Integer = 30
            Dim espacio As Integer = 2

            ' Dibujar encabezados de días de la semana
            For i As Integer = 0 To 6
                Dim diaSemana As String = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames((i + 1) Mod 7)
                Dim rect As New Rectangle(inicioX + i * (tamanoCelda.Width + espacio), inicioY - 25, tamanoCelda.Width, 20)
                g.DrawString(diaSemana, _fuenteDias, New SolidBrush(ColorTexto), rect, New StringFormat With {.Alignment = StringAlignment.Center})
            Next

            ' Calcular días del mes
            Dim primerDiaMes As New DateTime(_fechaActual.Year, _fechaActual.Month, 1)
            Dim diasEnMes As Integer = DateTime.DaysInMonth(_fechaActual.Year, _fechaActual.Month)
            Dim offsetInicial As Integer = CInt(primerDiaMes.DayOfWeek)

            ' Ajustar para que la semana empiece en lunes
            If offsetInicial = 0 Then offsetInicial = 6 Else offsetInicial -= 1

            Dim filaActual As Integer = 0
            For dia As Integer = 1 To diasEnMes
                Dim fechaActual As New DateTime(_fechaActual.Year, _fechaActual.Month, dia)
                Dim columna As Integer = (offsetInicial + dia - 1) Mod 7
                filaActual = (offsetInicial + dia - 1) \ 7

                Dim rect As New Rectangle(inicioX + columna * (tamanoCelda.Width + espacio), inicioY + filaActual * (tamanoCelda.Height + espacio), tamanoCelda.Width, tamanoCelda.Height)

                ' Resaltar día actual
                If fechaActual.Date = DateTime.Today.Date Then
                    g.FillRectangle(New SolidBrush(ColorDiaActual), rect)
                End If

                ' Dibujar borde y número de día
                Using pen As New Pen(ColorBorde)
                    g.DrawRectangle(pen, rect)
                End Using

                g.DrawString(dia.ToString(), _fuenteDias, New SolidBrush(ColorTexto),
                New Point(rect.X + 5, rect.Y + 5))

                _diasRectangulos.Add(rect, fechaActual)
            Next
        End Sub

        Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
            MyBase.OnMouseClick(e)
            For Each kvp In _diasRectangulos
                If kvp.Key.Contains(e.Location) Then
                    OnDiaClic(kvp.Value)
                    Exit For
                End If
            Next
        End Sub

        Public Event DiaSeleccionado(fecha As DateTime)

        Protected Overridable Sub OnDiaClic(fecha As DateTime)
            RaiseEvent DiaSeleccionado(fecha)
            Invalidate() ' Redibujar al seleccionar
        End Sub

        Public Sub CambiarMes(incremento As Integer)
            _fechaActual = _fechaActual.AddMonths(incremento)
            Invalidate()
        End Sub

        Friend Function FechaActual() As DateTime
            Return _fechaActual
        End Function
    End Class

End Namespace