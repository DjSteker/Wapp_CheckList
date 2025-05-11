Public Class Form_ObtenerDominioEmail

    Private Sub Obtener_Dominio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim correo As New System.Net.Mail.MailMessage
        correo.From = New System.Net.Mail.MailAddress("ivanmarvill@yahoo.com")
        Label1.Text = correo.From.Host
    End Sub


    Friend Function EnviarEmailPrueba01(ByVal Remitenete As String, ByVal HostSMTP As String,
                        ByVal Usuario As String, ByVal Contraseña As String, ByVal CorreoDestino As String,
                        ByVal Sujeto As String, ByVal Puerto As Int32, ByVal Mensaje As String,
                        ByVal TiempoEspera As Integer, ByVal CheckBox_IsBodyHtml As Boolean,
                        ByVal CheckBox_Ssl As Boolean) As DatosVuelta
        ' Friend Sub EnviarEmail01(ByVal RefDoc As String, ByVal Usuario As String, ByVal Marca As String, ByVal Referencia As String, ByVal Matricula As String, ByVal Texto_Str As StringBuilder)
        ' 587    465 
        Dim correo As New System.Net.Mail.MailMessage
        correo.From = New System.Net.Mail.MailAddress(Remitenete)
        correo.To.Add(CorreoDestino)
        correo.Subject = Sujeto
        correo.Body = Mensaje
        correo.IsBodyHtml = CheckBox_IsBodyHtml
        correo.Priority = System.Net.Mail.MailPriority.Normal
        correo.SubjectEncoding = System.Text.Encoding.UTF8()
        Dim smtp As New System.Net.Mail.SmtpClient
        smtp.EnableSsl = CheckBox_Ssl
        ' smtp.ClientCertificates =
        smtp.Port = Puerto ' 587   465 
        smtp.Timeout = TiempoEspera - 500
        smtp.Host = HostSMTP ' "smtp.gmail.com"
        smtp.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
        ' Dim t As New Thread(AddressOf ThreadProc)
        Try
            ' MsgBox(smtp.ServicePoint.Address.IsDefaultPort)
            smtp.Send(correo)

            MsgBox(vbCr & " Se a enviado un correo " & vbCr & " Puerto= " & Puerto & vbCr)

            smtp.Dispose()

            ' CadenadeVuelta(0) = True
            ' Return True
        Catch ex As Net.Mail.SmtpFailedRecipientException
            ' CadenadeVuelta(1) = vbCr & ex.Message & " " & Puerto & vbCr
            ' CadenadeVuelta(0) = False
            ' Return False
            ' Catch ex As Net.Mail.SmtpFailedRecipientsException
            ' RichTextBox1.Text &= vbCr & ex.Message & vbCr
            ' Return False

        Catch ex As Net.Mail.SmtpException
            ' CadenadeVuelta(1) = vbCr & ex.Message & " " & Puerto & vbCr
            ' CadenadeVuelta(0) = False
            ' Return False
        Catch ex As Exception
            ' Class_ErrorReg.Log_Exception(ex, " Error al enviar correo PETICION DE REPARACION de el cliente " & Usuario & "    " & DateAndTime.Now)
            ' Throw New NotImplementedException
            ' CadenadeVuelta(1) = vbCr & ex.Message & " " & Puerto & vbCr
            ' CadenadeVuelta(0) = False
            ' Return False

        End Try
        Try
            smtp.Dispose()
        Catch ex As Exception

        End Try
    End Function
End Class