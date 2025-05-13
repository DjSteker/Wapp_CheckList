
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form_CamaraWebV2



    Private _camHandle As IntPtr
    Private Const WM_CAP_START As Integer = &H400S
    Private Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP_START + 10
    Private Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP_START + 11
    Private Const WM_CAP_SET_PREVIEW As Integer = WM_CAP_START + 50
    Private Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP_START + 52
    Private Const WM_CAP_SET_SCALE As Integer = WM_CAP_START + 53
    Private Const WM_CAP_SET_VIDEOFORMAT As Integer = WM_CAP_START + 45
    Private Const WM_CAP_EDIT_COPY As Integer = WM_CAP_START + 30
    Private Const WM_CAP_GRAB_FRAME As Integer = WM_CAP_START + 60

    Private Const WS_VISIBLE As Integer = &H10000000
    Private Const WS_CHILD As Integer = &H40000000
    Private Const WS_DISABLED As Integer = &H8000000

    <StructLayout(LayoutKind.Sequential)>
    Public Structure BITMAPINFOHEADER
        Public biSize As UInteger
        Public biWidth As Integer
        Public biHeight As Integer
        Public biPlanes As UShort
        Public biBitCount As UShort
        Public biCompression As UInteger
        Public biSizeImage As UInteger
        Public biXPelsPerMeter As Integer
        Public biYPelsPerMeter As Integer
        Public biClrUsed As UInteger
        Public biClrImportant As UInteger
    End Structure

    <DllImport("avicap32.dll")>
    Private Shared Function capCreateCaptureWindowA(lpszWindowName As String, dwStyle As Integer, x As Integer, y As Integer, nWidth As Integer, nHeight As Integer, hwndParent As IntPtr, nID As Integer) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Private Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, ByRef lParam As BITMAPINFOHEADER) As Integer
    End Function

    <DllImport("user32.dll")>
    Private Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As IntPtr) As Integer
    End Function

    <DllImport("user32.dll", EntryPoint:="SendMessage", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Private Shared Function OpenClipboard(hWnd As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll")>
    Private Shared Function GetClipboardData(uFormat As UInteger) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Private Shared Function CloseClipboard() As Boolean
    End Function

    Private Const CF_BITMAP As UInteger = 2

    Private Sub Form_CamaraWebV2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ObtenerCamaras()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_IniciarCam_Click(sender As Object, e As EventArgs) Handles Button_IniciarCam.Click
        Try
            IniciarCam()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_PararCam_Click(sender As Object, e As EventArgs) Handles Button_PararCam.Click
        Try
            DetenerCamara()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_Capturar_Click(sender As Object, e As EventArgs) Handles Button_Capturar.Click
        Try
            CapturarImagen()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            DetenerCamara()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ComboBox_Resolucion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Resolucion.SelectedIndexChanged
        Try
            If ComboBox_Resolucion.Text = "320·240" Then
                TextBox_ResolucionAncho.Text = "320"
                TextBox_ResolucionAlto.Text = "240"
            ElseIf ComboBox_Resolucion.Text = "640·480" Then
                TextBox_ResolucionAncho.Text = "640"
                TextBox_ResolucionAlto.Text = "480"
            ElseIf ComboBox_Resolucion.Text = "1280·720" Then
                TextBox_ResolucionAncho.Text = "1280"
                TextBox_ResolucionAlto.Text = "720"
            ElseIf ComboBox_Resolucion.Text = "1920·1080" Then
                TextBox_ResolucionAncho.Text = "1920"
                TextBox_ResolucionAlto.Text = "1080"
            ElseIf ComboBox_Resolucion.Text = "2592·1944" Then
                TextBox_ResolucionAncho.Text = "2592"
                TextBox_ResolucionAlto.Text = "1944"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label_Camaras_Click(sender As Object, e As EventArgs) Handles Label_Camaras.Click
        Try
            ObtenerCamaras()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox_Zoom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Zoom.SelectedIndexChanged
        Try
            If ComboBox_Zoom.Text = "AutoSize" Then
                PictureBox_Camara.SizeMode = PictureBoxSizeMode.AutoSize
            ElseIf ComboBox_Zoom.Text = "CenterImage" Then
                PictureBox_Camara.SizeMode = PictureBoxSizeMode.CenterImage
            ElseIf ComboBox_Zoom.Text = "Normal" Then
                PictureBox_Camara.SizeMode = PictureBoxSizeMode.Normal
            ElseIf ComboBox_Zoom.Text = "StretchImage" Then
                PictureBox_Camara.SizeMode = PictureBoxSizeMode.StretchImage
            ElseIf ComboBox_Zoom.Text = "Zoom" Then
                PictureBox_Camara.SizeMode = PictureBoxSizeMode.Zoom
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ObtenerCamaras()
        ComboBox_Camaras.Items.Clear()
        ' Llenar ComboBox con dispositivos de cámaras disponibles
        For i As Integer = 0 To 10
            Dim tempCamHandle As IntPtr = capCreateCaptureWindowA("Webcam", WS_CHILD Or WS_DISABLED, 0, 0, 320, 240, Me.Handle, 0)
            If tempCamHandle <> IntPtr.Zero Then
                If SendMessage(tempCamHandle, WM_CAP_DRIVER_CONNECT, i, IntPtr.Zero) Then
                    ComboBox_Camaras.Items.Add("Cámara " & i)
                    SendMessage(tempCamHandle, WM_CAP_DRIVER_DISCONNECT, 0, IntPtr.Zero)
                End If
            End If
            SendMessage(tempCamHandle, WM_CAP_DRIVER_DISCONNECT, 0, IntPtr.Zero)
        Next
        If ComboBox_Camaras.Items.Count > 0 Then
            ComboBox_Camaras.SelectedIndex = 0 ' Seleccionar la primera cámara por defecto
        Else
            MessageBox.Show("No se encontraron cámaras disponibles.")
        End If
    End Sub

    Private Sub IniciarCam()
        Dim cameraIndex As Integer = ComboBox_Camaras.SelectedIndex ' Índice de la cámara seleccionada
        _camHandle = capCreateCaptureWindowA("Webcam", WS_VISIBLE Or WS_CHILD, 0, 0, PictureBox_Camara.Width, PictureBox_Camara.Height, PictureBox_Camara.Handle, 0)
        If _camHandle <> IntPtr.Zero Then
            SendMessage(_camHandle, WM_CAP_DRIVER_CONNECT, cameraIndex, IntPtr.Zero)

            ' Configurar resolución
            Dim bmi As New BITMAPINFOHEADER()
            bmi.biSize = CType(Marshal.SizeOf(GetType(BITMAPINFOHEADER)), UInteger)
            bmi.biWidth = CInt(TextBox_ResolucionAncho.Text.Trim) ' Ancho de resolución
            bmi.biHeight = CInt(TextBox_ResolucionAlto.Text.Trim) ' Altura de resolución
            bmi.biPlanes = 1
            bmi.biBitCount = CInt(ComboBox_BitsColor.Text.Trim) ' Bits por píxel
            bmi.biCompression = 0
            bmi.biSizeImage = CType(bmi.biWidth * bmi.biHeight * 3, UInteger)
            SendMessage(_camHandle, WM_CAP_SET_VIDEOFORMAT, 0, bmi)

            ' Configurar tasa de fotogramas (FPS)
            Dim fps As Integer = CInt(1000 / CInt(TextBox_FPS.Text.Trim)) ' Convertir FPS a milisegundos por frame
            SendMessage(_camHandle, WM_CAP_SET_PREVIEWRATE, fps, IntPtr.Zero) ' Configurar la tasa de fotogramas

            SendMessage(_camHandle, WM_CAP_SET_PREVIEW, 1, IntPtr.Zero)
            SendMessage(_camHandle, WM_CAP_SET_SCALE, 1, IntPtr.Zero)
        Else
            MessageBox.Show("No se pudo acceder a la cámara.")
        End If
    End Sub

    Private Sub DetenerCamara()
        If _camHandle <> IntPtr.Zero Then
            SendMessage(_camHandle, WM_CAP_DRIVER_DISCONNECT, 0, IntPtr.Zero)
            _camHandle = IntPtr.Zero
        End If
    End Sub

    Private Sub CapturarImagen()
        If _camHandle <> IntPtr.Zero Then
            SendMessage(_camHandle, WM_CAP_GRAB_FRAME, 0, 0)
            SendMessage(_camHandle, WM_CAP_EDIT_COPY, 0, 0)

            If OpenClipboard(IntPtr.Zero) Then
                Dim hBitmap As IntPtr = GetClipboardData(CF_BITMAP)
                If hBitmap <> IntPtr.Zero Then
                    Dim bmp As Bitmap = Image.FromHbitmap(hBitmap)
                    Dim fechaL As String = Replace(DateTime.Now, "/", "")
                    fechaL = Replace(fechaL, ":", "")
                    fechaL = Replace(fechaL, " ", "")
                    ' Guardar la imagen en un archivo
                    bmp.Save(My.Application.Info.DirectoryPath & "\Fotos\" & TextBox_NombreFoto.Text.Trim & ".jpg", ImageFormat.Jpeg)
                    'MessageBox.Show("Imagen capturada y guardada como " & TextBox_NombreFoto.Text.Trim & ".jpg")
                End If
                CloseClipboard()
            End If

            ' Reactivar la vista previa de la cámara
            SendMessage(_camHandle, WM_CAP_SET_PREVIEW, 1, IntPtr.Zero)
        End If
    End Sub

    Private Sub TextBox_FPS_TextChanged(sender As Object, e As EventArgs) Handles TextBox_FPS.TextChanged
        Try
            Dim fps As Integer = CInt(1000 / CInt(TextBox_FPS.Text.Trim))
            TextBoxl_TiempoActulizacion.Text = fps
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBoxl_TiempoActulizacion_TextChanged(sender As Object, e As EventArgs) Handles TextBoxl_TiempoActulizacion.TextChanged
        Try
            Dim fps As Integer = CInt(1000 / CInt(TextBoxl_TiempoActulizacion.Text.Trim))
            TextBox_FPS.Text = fps
        Catch ex As Exception

        End Try
    End Sub

End Class
