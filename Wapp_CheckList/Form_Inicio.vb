Public Class Form_Inicio
  
        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim cultures As CultureInfo() = CultureInfo.GetCultures(CultureTypes.AllCultures)
            ComboBox_Idioma.Items.Clear()
            For Each culture As CultureInfo In cultures
                ComboBox_Idioma.Items.Add(culture.Name)
            Next
        Catch ex As Exception

        End Try
        Try
            ComboBox_Idioma.Text = CultureInfo.CurrentCulture.IetfLanguageTag
        Catch ex As Exception

        End Try
    End Sub

    Private Function idioma_fr()

    End Function
    Private Function idioma_es()

    End Function

    Private Function idioma_de()

    End Function
    Private Function idioma_it()

    End Function
    Private Function idioma_pr()

    End Function
    Private Function idioma_ar()

    End Function
    Private Sub Button_Agenda_Click(sender As Object, e As EventArgs) Handles Button_Agenda.Click
        Try
            Form_Calendario.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_CheckList_Click(sender As Object, e As EventArgs) Handles Button_CheckList.Click
        Try
            Form_Checklist.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_Camara_Click(sender As Object, e As EventArgs) Handles Button_Camara.Click
        Try
            Form_CamaraWebV2.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_CodigoBarras_Click(sender As Object, e As EventArgs) Handles Button_CodigoBarras.Click
        Try
            Form_CodigoBarras128EAN.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_QR_Click(sender As Object, e As EventArgs) Handles Button_QR.Click
        Try
            Form_CodeQR_Alfanumerico.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox_Idioma_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Idioma.SelectedIndexChanged
        Try

            Dim Valor As String = ComboBox_Idioma.Text.Trim.ToLower
            If "es-es" = Valor Then
                System.Globalization.CultureInfo.CurrentUICulture = New System.Globalization.CultureInfo("es-ES")
            ElseIf "en-us" = Valor Then
                System.Globalization.CultureInfo.CurrentUICulture = New System.Globalization.CultureInfo("en-US")
            ElseIf "fr-fr" = Valor Then
                System.Globalization.CultureInfo.CurrentUICulture = New System.Globalization.CultureInfo("fr-FR")
            ElseIf "de-de" = Valor Then
                System.Globalization.CultureInfo.CurrentUICulture = New System.Globalization.CultureInfo("de-DE")
            ElseIf "" = Valor Then
                System.Globalization.CultureInfo.CurrentUICulture = New System.Globalization.CultureInfo("")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox_Idioma_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox_Idioma.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True ' Evita el sonido
                Task.Run(Sub() Me.Invoke(Sub() ComboBox_Idioma.SelectedItem = ComboBox_Idioma.Text))
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Button_Mezclas_Click(sender As Object, e As EventArgs) Handles Button_Mezclas.Click
        Try
            Form_CalculadoraMezclas.Show()

        Catch ex As Exception

        End Try
    End Sub

End Class
