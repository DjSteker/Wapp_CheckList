Public Class Form_Inicio
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

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

End Class
