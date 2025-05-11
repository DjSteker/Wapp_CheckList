Public Class Form_CalculadoraMezclas

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabControl1.Click

    End Sub

    Private Sub Form_CalculadoraMezclas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CalcularMezcla()
        Dim total As Double = Double.Parse(TextBox_MezclaTotal.Text)
        Dim proporcion1 As Double = Replace(TextBox_Proporcion1.Text, ".", ",")
        Dim proporcion2 As Double = Replace(TextBox_Proporcion2.Text, ".", ",")

        Dim factor As Double = total / (proporcion1 + proporcion2)
        Dim componente1 As Double = proporcion1 * factor
        Dim componente2 As Double = proporcion2 * factor

        TextBox_ResultadoMezcla.Text = $"Componente 1: {componente1:N2} | Componente 2: {componente2:N2}"
    End Sub

    Private Sub CalcularAleacion()
        Dim ley1 As Double = Double.Parse(TextBox_Ley1.Text)
        Dim ley2 As Double = Double.Parse(TextBox_Ley2.Text)
        Dim peso1 As Double = Double.Parse(TextBox_Peso1.Text)
        Dim peso2 As Double = Double.Parse(TextBox_Peso2.Text)

        Dim leyFinal As Double = (ley1 * peso1 + ley2 * peso2) / (peso1 + peso2)
        TextBox_ResultadoAleacion.Text = $"Ley final: {leyFinal:P2}"
    End Sub

    Private Sub btnCalcularMezcla_Click(sender As Object, e As EventArgs) Handles Button_CalcularMezcla.Click
        CalcularMezcla()
    End Sub

    ' Coloca esto en el archivo Form_CalculadoraMezclas.vb

    Private Sub Button_CalcularAleacion_Click(sender As Object, e As EventArgs) Handles Button_CalcularAleacion.Click
        ' Validar entradas
        Dim peso1, peso2, pureza1, pureza2 As Double

        If Not Double.TryParse(TextBox_Peso1.Text, peso1) OrElse peso1 <= 0 Then
            MessageBox.Show("Ingrese un peso válido para la Aleación 1")
            Exit Sub
        End If
        If Not Double.TryParse(TextBox_Ley1.Text, pureza1) OrElse pureza1 < 0 OrElse pureza1 > 100 Then
            MessageBox.Show("Ingrese una pureza válida (0-100) para la Aleación 1")
            Exit Sub
        End If
        If Not Double.TryParse(TextBox_Peso2.Text, peso2) OrElse peso2 <= 0 Then
            MessageBox.Show("Ingrese un peso válido para la Aleación 2")
            Exit Sub
        End If
        If Not Double.TryParse(TextBox_Ley2.Text, pureza2) OrElse pureza2 < 0 OrElse pureza2 > 100 Then
            MessageBox.Show("Ingrese una pureza válida (0-100) para la Aleación 2")
            Exit Sub
        End If

        ' Cálculo de pureza final
        Dim pesoTotal As Double = peso1 + peso2
        Dim metalPuroTotal As Double = (peso1 * pureza1 / 100) + (peso2 * pureza2 / 100)
        Dim purezaFinal As Double = (metalPuroTotal / pesoTotal) * 100

        ' Mostrar resultado
        TextBox_ResultadoAleacion.Text = $"Peso total: {pesoTotal:N2} - Pureza final: {purezaFinal:N2}%"
    End Sub
End Class