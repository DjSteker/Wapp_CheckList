Imports System.Threading

Public Class Form_ProbarEmail
#Region "Propiedades y EVENTOS"
    ' Event Event_Intento()
    Friend Event Event_ProgresCantidadMeta(ByVal CantidadInt As String)
    Friend Event Event_ProgresBarMas(ByVal CantidadInt As String)



    Public Delegate Sub AddTexto(myString As String)
    Private Property Delegado_Suceso As AddTexto
    Private Property Delegado_Mesaje As AddTexto
    Private Property Delegado_IntentosMeta As AddTexto
    Private Property Delegado_IntentoFin As AddTexto

    ' Private Property Delegado_ClienteList As AddTextoBool
    WithEvents mod_EmailMoto As Class_EmailMotor
    Private Thread_Probando As Thread
    Private t_EnviarEmail As Thread
    Dim Enviado As Boolean
    Dim PuertoSeleccionConsola As Int32
    'Dim Mensaje As String
    Dim FuncionaInternet As Boolean
#End Region
#Region " Instancia intefaz grafica "

    Private Sub Form_ProbarEmail_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        '     Delegado_ClienteList = New AddTextoBool(AddressOf Imprimir_ClienteList)
        mod_EmailMoto = New Class_EmailMotor
        Delegado_Suceso = New AddTexto(AddressOf Imprimir_Sucesos)
        Delegado_Mesaje = New AddTexto(AddressOf Imprimir_NuevoMensaje)
        Delegado_IntentosMeta = New AddTexto(AddressOf ProgresBar_CantidadMeta)
        Delegado_IntentoFin = New AddTexto(AddressOf ProgresBar_Mas1)
        Try
            AddHandler System.Net.NetworkInformation.NetworkChange.NetworkAvailabilityChanged, AddressOf Me.networkChange_NetworkAvailabilityChanged
        Catch ex As Exception

        End Try
        Try
            WebBrowser1.Navigate("http://marvill.somee.com/index.htm")
            AddHandler WebBrowser1.DocumentCompleted, AddressOf LecturaInternet
        Catch ex2 As Exception

        End Try

    End Sub
    Private Sub LecturaInternet(sender As Object, e As WebBrowserDocumentCompletedEventArgs)
        FuncionaInternet = True
    End Sub
    Private Sub EnviarEmailToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EnviarEmailToolStripMenuItem.Click
        ' Form_ProbarEmail.Show()
    End Sub
    Private Sub ProbarPuertosToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ProbarPuertosToolStripMenuItem1.Click

    End Sub

    Private Sub Button_EnviarPrueba_Click(sender As System.Object, e As System.EventArgs) Handles Button_EnviarPrueba.Click
        Try
            If CInt(TextBox_TiempoEspera.Text) < 1000 Then
                TextBox_TiempoEspera.Text = 1000
            End If
            If Button_EnviarPrueba.Text = "Enviar" Then
                RichTextBox_Sucesos.Text = String.Empty
                RichTextBox_Mesaje.Text = String.Empty
                Thread_Probando = New Thread(AddressOf EnviarEmails_Trama)
                Button_EnviarPrueba.Text = "Parar"
                Thread_Probando.Start()
            Else
                Try
                    t_EnviarEmail.Abort()
                Catch ex As Exception

                End Try
                Thread_Probando.Abort()
                Button_EnviarPrueba.Text = "Enviar"
                ProgressBar1.Value = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub



    Delegate Sub NetworkAvailabilityCallback(ByVal isNetworkAvailable As Boolean)
    Private Sub networkChange_NetworkAvailabilityChanged(sender As Object, e As Net.NetworkInformation.NetworkAvailabilityEventArgs)
        Me.Invoke(New NetworkAvailabilityCallback(AddressOf UpdateNetworkAvailability), New Object() {e.IsAvailable})
        FuncionaInternet = e.IsAvailable
    End Sub
    Private Sub UpdateNetworkAvailability(ByVal isNetworkAvailable As Boolean)
        If isNetworkAvailable Then
            FuncionaInternet = True
        Else
            FuncionaInternet = True
        End If
    End Sub






    Private Sub Imprimir_NuevoMensaje(ByVal Texto As String)
        Me.RichTextBox_Mesaje.Text = Texto.ToString ' & vbCrLf
    End Sub
    Private Sub Imprimir_Sucesos(ByVal Texto As String)
        '  Throw New NotImplementedException
        Me.RichTextBox_Sucesos.Text &= Texto.ToString ' & vbCrLf
    End Sub
    Private Sub ProgresBar_CantidadMeta(ByVal Cantidad As String)
        Me.ProgressBar1.Maximum = CInt(Cantidad + 1)
    End Sub
    Private Sub ProgresBar_Mas1(ByVal Cantidad As String)
        Try
            Me.ProgressBar1.Value += CInt(Cantidad)
        Catch ex As Exception

        End Try

    End Sub

#End Region



#Region "Tramas Enviar"

    Private Sub EnviarEmails_Trama()
        'Try
        '    RichTextBox1.Text = vbCr & "Inicio" & vbCr
        '    For index_Puerto = CInt(TextBox_Puerto.Text.Trim) To CInt(TextBox_PuertoAsta.Text.Trim)
        Thread.Sleep(1000)
        '        Try
        '            If EnviarEmailPrueba01(index_Puerto) Then
        '                RichTextBox1.Text &= vbCr & "Finalizado"
        '                Exit For
        '            End If
        '        Catch ex As Exception
        '        End Try
        '    Next
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        Enviado = False
        Try

            Me.RichTextBox_Sucesos.Invoke(Delegado_Suceso, New Object() {vbCr & "Inicio" & vbCr & vbCrLf})
            Dim BustarTotal As Int32 = CInt(TextBox_PuertoAsta.Text.Trim) - CInt(TextBox_Puerto.Text.Trim)
            RaiseEvent Event_ProgresCantidadMeta(BustarTotal * 2 + 1)
            Dim PorcientoUno As Integer = Math.Round(BustarTotal / 100)
            Dim PorcientoContadorIntentos As Integer = 0
            If BustarTotal < 0 Then
                Me.RichTextBox_Sucesos.Invoke(Delegado_Suceso, New Object() {" Error puertos , se a especificado un intervalo fuera de contexto "})
                Exit Sub
            Else
                Dim CantidadPor1 As Int32 = BustarTotal - 100
            End If
            For index_Puerto = CInt(TextBox_Puerto.Text.Trim) To CInt(TextBox_PuertoAsta.Text.Trim)
                PorcientoContadorIntentos += 1
                RaiseEvent Event_ProgresBarMas(1)
                '  Me.ProgressBar1.Invoke(Delegado_IntentoFin, New Object() {"1"})
                Thread.Sleep(1000)
                Try
                    ' Dim t_EnviarEmail As New Thread(AddressOf EnviarEmail)
                    t_EnviarEmail = New Thread(AddressOf EnviarEmail)
                    PuertoSeleccionConsola = index_Puerto
                    t_EnviarEmail.Start()
                    Me.RichTextBox_Sucesos.Invoke(Delegado_Suceso, New Object() {" Intento por el puerto " & PuertoSeleccionConsola & vbCrLf})
                    Thread.Sleep(CInt(TextBox_TiempoEspera.Text) / 2)
                    RaiseEvent Event_ProgresBarMas(1)
                    Thread.Sleep(CInt(TextBox_TiempoEspera.Text) / 2 + 100)
                    t_EnviarEmail.Abort()
                    t_EnviarEmail.Join()
                    ' t_EnviarEmail.
                    ' Me.RichTextBox1.Invoke(Delegado_Mesaje, New Object() {Mensaje & vbCr})


                    'If PorcientoContadorIntentos >= PorcientoUno Then
                    '    PorcientoContadorIntentos = 0
                    '    ProgressBar1.Value += 1
                    'End If

                Catch ex As Exception
                    'RichTextBox1.Text &= vbCr & index_Puerto & vbCr & ex.Message
                    Me.RichTextBox_Sucesos.Invoke(Delegado_Suceso, New Object() {vbCr & index_Puerto & vbCr & ex.Message})
                End Try
            Next
            ' RichTextBox1.Text &= vbCr & " Finalizado " & vbCr
            Me.RichTextBox_Sucesos.Invoke(Delegado_Suceso, New Object() {vbCr & " Finalizado " & vbCr})
        Catch ex As Exception
            Try
                '   RichTextBox1.Text &= vbCr & ex.Message
                '     MsgBox(ex.Message)
                Me.RichTextBox_Sucesos.Invoke(Delegado_Suceso, New Object() {vbCr & "Error trama" & ex.Message})

            Catch ex2 As Exception

            End Try

        End Try
    End Sub

    Friend Sub EnviarEmail() 'As String
        Dim MensageObtenido As String = ""
        Try
            With mod_EmailMoto.EnviarEmailPrueba01(TextBox_Remitenete.Text, TextBox_HostSMTP.Text,
                      TextBox_Usuario.Text, TextBox_Contraseña.Text, TextBox_CorreoDestino.Text, TextBox_Sujeto.Text, PuertoSeleccionConsola,
                      TextBox_Mensaje.Text & vbCr & " Puerto" & PuertoSeleccionConsola, TextBox_TiempoEspera.Text, CheckBox_IsBodyHtml.Checked, CheckBox_Ssl.Checked)
                MensageObtenido &= vbCr & .Mensaje.ToString
                If CBool(.Estado) Then
                    Enviado = True
                    Try
                        Thread_Probando.Interrupt()
                    Catch ex As Exception

                    End Try


                    MsgBox(.Mensaje)
                    Try
                        Thread_Probando.Abort()
                    Catch ex As Exception

                    End Try
                    Try
                        t_EnviarEmail.Abort()
                    Catch ex As Exception

                    End Try
                End If
            End With

            MensageObtenido &= MensageObtenido
        Catch ex As Exception
            ' MensageObtenido &= vbCr & ex.Message
            ' Me.RichTextBox_Sucesos.Invoke(Delegado_Suceso, New Object() {vbCr & "Error trama" & ex.Message})
        End Try
        'Mensaje = MensageObtenido  '  Return MensageObtenido
    End Sub

#End Region

#Region "Eventos y propiedades de la trama"
    Private Sub WinSockServer_MensajeSuceso(ByVal Texto As String) Handles mod_EmailMoto.FalloConexion

        Try
            Me.RichTextBox_Sucesos.Invoke(Delegado_Suceso, New Object() {" Fallo conexion " & Texto.ToString & "  Internet=" & FuncionaInternet & vbCrLf})
        Catch ex As Exception

        End Try

    End Sub
    Private Sub WinSockServer_MensajeFallo(ByVal Texto As String) Handles mod_EmailMoto.Mensaje_Suceso

        Try
            Me.RichTextBox_Sucesos.Invoke(Delegado_Suceso, New Object() {Texto.ToString & vbCrLf})
        Catch ex As Exception

        End Try

    End Sub
    Private Sub WinSockServer_MensajeConexion(ByVal Texto As String) Handles mod_EmailMoto.Mensaje_Conexion

        Try
            Me.RichTextBox_Mesaje.Invoke(Delegado_Mesaje, New Object() {"  " & Texto.ToString & vbCrLf & "  Internet=" & FuncionaInternet})
        Catch ex As Exception

        End Try

    End Sub


    Private Sub WinSockServer_SetMeta(ByVal Cantidad As String) Handles Me.Event_ProgresCantidadMeta

        Try
            Me.ProgressBar1.Invoke(Delegado_IntentosMeta, New Object() {Cantidad})
        Catch ex As Exception

        End Try

    End Sub
    Private Sub WinSockServer_ProgresBarMas(ByVal Cantidad As String) Handles Me.Event_ProgresBarMas

        Try
            Me.ProgressBar1.Invoke(Delegado_IntentoFin, New Object() {(Cantidad)})
        Catch ex As Exception

        End Try

    End Sub

#End Region



    'Friend Function EnviarEmailPrueba01(ByVal Puerto As Int32) As Boolean
    '    ' Friend Sub EnviarEmail01(ByVal RefDoc As String, ByVal Usuario As String, ByVal Marca As String, ByVal Referencia As String, ByVal Matricula As String, ByVal Texto_Str As StringBuilder)
    '    ' 587    465 
    '    Dim correo As New System.Net.Mail.MailMessage
    '    correo.From = New System.Net.Mail.MailAddress(TextBox_Remitenete.Text.Trim)
    '    correo.To.Add(TextBox_CorreoDestino.Text.Trim)
    '    correo.Subject = TextBox_Sujeto.Text.Trim
    '    correo.Body = TextBox_Mensaje.Text.Trim
    '    correo.IsBodyHtml = CheckBox_IsBodyHtml.Checked
    '    correo.Priority = System.Net.Mail.MailPriority.Normal
    '    correo.SubjectEncoding = System.Text.Encoding.UTF8()
    '    Dim smtp As New System.Net.Mail.SmtpClient
    '    smtp.EnableSsl = CheckBox_Ssl.Checked
    '    'smtp.ClientCertificates =
    '    smtp.Port = Puerto ' 587   465 
    '    smtp.Timeout = CInt(TextBox_TiempoEspera.Text)

    '    smtp.Host = TextBox_HostSMTP.Text.Trim '"smtp.gmail.com"
    '    smtp.Credentials = New System.Net.NetworkCredential(TextBox_Usuario.Text.Trim, TextBox_Contraseña.Text.Trim)
    '    Try
    '        smtp.Send(correo)
    '        RichTextBox1.Text &= vbCr & vbCr & "ENVIADO al puerto=" & Puerto & vbCr
    '        MsgBox(vbCr & " Se a enviado un correo " & vbCr & " Puerto=" & Puerto & vbCr)
    '        Return True
    '    Catch ex As Net.Mail.SmtpFailedRecipientException
    '        RichTextBox1.Text &= vbCr & ex.Message & " " & Puerto & vbCr
    '        Return False
    '        'Catch ex As Net.Mail.SmtpFailedRecipientsException
    '        '   RichTextBox1.Text &= vbCr & ex.Message & vbCr
    '        '   Return False
    '    Catch ex As Net.Mail.SmtpException
    '        RichTextBox1.Text &= vbCr & ex.Message & " " & Puerto & vbCr
    '        Return False
    '    Catch ex As Exception
    '        ' Class_ErrorReg.Log_Exception(ex, " Error al enviar correo PETICION DE REPARACION de el cliente " & Usuario & "    " & DateAndTime.Now)
    '        ' Throw New NotImplementedException
    '        RichTextBox1.Text &= vbCr & ex.Message & " " & Puerto & vbCr
    '        Return False
    '    End Try
    'End Function

#Region "Cerrar y Salir "


    Private Sub SalirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalirToolStripMenuItem.Click

        End
    End Sub
    Protected Overrides Sub Finalize()
        Try
            Thread_Probando.Abort()
        Catch ex As Exception

        End Try
        Try
            t_EnviarEmail.Abort()
        Catch ex As Exception

        End Try
        MyBase.Finalize()
    End Sub

#End Region








    Private Sub ObtenerInfoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ObtenerInfoToolStripMenuItem.Click
        Form_ObtenerDominioEmail.Show()
    End Sub
End Class

'Class EmailMotor
'    'Module Modulo_Email
'    Public Event Mensaje_Suceso(ByVal Mensaje As String)
'    Public Event Mensaje_Conexion(ByVal Mensaje As String)
'    Public Event FalloConexion(ByVal Mensaje As String)



'    ' Friend Event ProgresBar_Mas(ByVal ValorSuma As String)
'    '  Friend CadenadeVuelta() As String

'    Friend Function EnviarEmailPrueba01(ByVal Remitenete As String, ByVal HostSMTP As String, _
'                        ByVal Usuario As String, ByVal Contraseña As String, ByVal CorreoDestino As String, _
'                        ByVal Sujeto As String, ByVal Puerto As Int32, ByVal Mensaje As String, _
'                        ByVal TiempoEspera As Integer, ByVal CheckBox_IsBodyHtml As Boolean, _
'                        ByVal CheckBox_Ssl As Boolean) As DatosVuelta
'        ' Friend Sub EnviarEmail01(ByVal RefDoc As String, ByVal Usuario As String, ByVal Marca As String, ByVal Referencia As String, ByVal Matricula As String, ByVal Texto_Str As StringBuilder)
'        ' 587    465 
'        Dim InsDatosVuelta As DatosVuelta
'        RaiseEvent Mensaje_Conexion("Intento en el puerto " & Puerto)
'        Dim correo As New System.Net.Mail.MailMessage
'        correo.From = New System.Net.Mail.MailAddress(Remitenete)
'        correo.To.Add(CorreoDestino)
'        correo.Subject = Sujeto
'        correo.Body = Mensaje
'        correo.IsBodyHtml = CheckBox_IsBodyHtml
'        correo.Priority = System.Net.Mail.MailPriority.Normal
'        correo.SubjectEncoding = System.Text.Encoding.UTF8()
'        Dim smtp As New System.Net.Mail.SmtpClient
'        smtp.EnableSsl = CheckBox_Ssl
'        ' smtp.ClientCertificates =
'        smtp.Port = Puerto ' 587   465 
'        smtp.Timeout = TiempoEspera - 300
'        smtp.Host = HostSMTP ' "smtp.gmail.com"
'        smtp.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
'        ' Dim t As New Thread(AddressOf ThreadProc)
'        Try
'            ' MsgBox(smtp.ServicePoint.Address.IsDefaultPort)
'            smtp.Send(correo)
'            InsDatosVuelta = New DatosVuelta(True, vbCr & vbCr & "ENVIADO al puerto=" & Puerto & vbCr)
'            ' DatosVuelta.Mensaje = vbCr & vbCr & "ENVIADO al puerto=" & Puerto & vbCr
'            RaiseEvent Mensaje_Suceso(" Se a enviado un correo " & vbCr & " Puerto= " & Puerto & vbCr)
'            MsgBox(vbCr & " Se a enviado un correo " & vbCr & " Puerto= " & Puerto & vbCr)
'            RaiseEvent Mensaje_Conexion(" Se a enviado un correo " & vbCr & " Puerto= " & Puerto & vbCr & _
'                                     " Remitente= " & Remitenete.ToString & vbCr & " Del dominio= " & HostSMTP)

'            smtp.Dispose()

'            ' CadenadeVuelta(0) = True
'            ' Return True
'        Catch ex As Net.Mail.SmtpFailedRecipientException
'            ' CadenadeVuelta(1) = vbCr & ex.Message & " " & Puerto & vbCr
'            ' CadenadeVuelta(0) = False
'            ' Return False
'            ' Catch ex As Net.Mail.SmtpFailedRecipientsException
'            ' RichTextBox1.Text &= vbCr & ex.Message & vbCr
'            ' Return False
'            InsDatosVuelta = New DatosVuelta(False, vbCr & ex.Message & " " & Puerto & vbCr)
'            RaiseEvent FalloConexion(vbCr & ex.Message & " " & Puerto & vbCr)
'        Catch ex As Net.Mail.SmtpException
'            ' CadenadeVuelta(1) = vbCr & ex.Message & " " & Puerto & vbCr
'            ' CadenadeVuelta(0) = False
'            ' Return False
'            InsDatosVuelta = New DatosVuelta(False, vbCr & ex.Message & " " & Puerto & vbCr)
'            RaiseEvent FalloConexion(vbCr & ex.Message & " " & Puerto & vbCr)
'        Catch ex As Exception
'            ' Class_ErrorReg.Log_Exception(ex, " Error al enviar correo PETICION DE REPARACION de el cliente " & Usuario & "    " & DateAndTime.Now)
'            ' Throw New NotImplementedException
'            ' CadenadeVuelta(1) = vbCr & ex.Message & " " & Puerto & vbCr
'            ' CadenadeVuelta(0) = False
'            ' Return False
'            InsDatosVuelta = New DatosVuelta(False, vbCr & ex.Message & " " & Puerto & vbCr)
'            RaiseEvent FalloConexion(vbCr & ex.Message & " " & Puerto & vbCr)
'        End Try
'        Return InsDatosVuelta
'    End Function
'    '  End Module

'End Class