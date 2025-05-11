Imports System.Diagnostics


Public Class Class_APPs


    Private Sub Button1_Click()
        Dim openVpn As New ProcessStartInfo
        openVpn.FileName = "ruta_a_tu_archivo_openvpn.exe"
        openVpn.Arguments = "--config ruta_a_tu_archivo_de_configuracion.ovpn"
        openVpn.WindowStyle = ProcessWindowStyle.Hidden
        Process.Start(openVpn)
    End Sub

    Private Sub Button2_Click()
        For Each proc As Process In Process.GetProcesses
            If proc.ProcessName.Equals("openvpn") Then
                proc.Kill()
            End If
        Next
    End Sub

End Class
