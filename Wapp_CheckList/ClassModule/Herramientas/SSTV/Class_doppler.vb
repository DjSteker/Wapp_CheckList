'Public Class Class_doppler

'End Class

Imports System
Imports System.Net
Imports System.Text
Imports System.Net.Sockets
Imports System.Security.Cryptography.X509Certificates
Imports System.Net.Security
Imports System.Threading
Imports System.Math
Imports System.IO
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks

Class Class_doppler

    Const C As Double = 300000000.0
    Const F0 As Double = 145800000.0

    Const LATITUDE As String = "52.219308"
    Const LONGITUDE As String = "4.419926"
    Const ALTITUDE As Integer = 20

    Class tle_reader
        Private _tle_name As String
        Private _tle_file As String
        Private _tle_max_age As Integer
        Private _tle As Object
        Private _tle_age As Double

        Public Sub New(Optional ByVal tle_name As String = "ISS (ZARYA)",
                       Optional ByVal tle_file As String = "https://celestrak.com/NORAD/elements/stations.txt",
                       Optional ByVal tle_max_age As Integer = 3600)
            _tle_name = tle_name
            _tle_file = tle_file
            _tle_max_age = tle_max_age
            reload()
        End Sub

        Private Function build_index(tle_lines As String()) As Dictionary(Of String, Tuple(Of String, String))
            Dim index As New Dictionary(Of String, Tuple(Of String, String))
            For i As Integer = 0 To tle_lines.Length - 1 Step 3
                index(tle_lines(i).Trim()) = New Tuple(Of String, String)(tle_lines(i + 1), tle_lines(i + 2))
            Next
            Return index
        End Function

        Public Sub reload()
            Console.WriteLine("Loading: " & _tle_file)

            Try
                Dim ctx As New SslStream(New MemoryStream())
                ctx.CheckCertRevocationStatus = False
                ctx.CheckCertificateRevocationList = False
                ctx.CheckHostName = Function() True
                ServicePointManager.ServerCertificateValidationCallback = Function(sender, certificate, chain, sslPolicyErrors) True

                Dim request As HttpWebRequest = WebRequest.Create(_tle_file)
                request.ServerCertificateValidationCallback = Function(sender, certificate, chain, sslPolicyErrors) True
                Dim response As HttpWebResponse = request.GetResponse()
                Dim reader As New StreamReader(response.GetResponseStream())
                Dim tle_lines As String() = reader.ReadToEnd().Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                Dim index As Dictionary(Of String, Tuple(Of String, String)) = build_index(tle_lines)
                Dim tle_data As Tuple(Of String, String) = index(_tle_name)
                _tle = New ephem.readtle(_tle_name, tle_data.Item1, tle_data.Item2)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

            _tle_age = DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalSeconds
        End Sub

        Public ReadOnly Property tle As Object
            Get
                Return _tle
            End Get
        End Property

        Public ReadOnly Property tle_expired As Boolean
            Get
                Return DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalSeconds - _tle_age > _tle_max_age
            End Get
        End Property
    End Class

    Class rtl_fm_remote
        Private _host As String
        Private _port As Integer
        Private _s As UdpClient

        Public Sub New(Optional ByVal host As String = "localhost",
                       Optional ByVal port As Integer = 6020)
            _host = host
            _port = port
            _s = New UdpClient()
            _s.Connect(_host, _port)
        End Sub

        Public Sub set_freq(freq As Integer)
            send_cmd(0, freq)
        End Sub

        Public Sub set_mode(mode As Integer)
            send_cmd(1, mode)
        End Sub

        Public Sub set_squelch(squelch As Integer)
            send_cmd(2, squelch)
        End Sub

        Public Sub set_gain(gain As Integer)
            send_cmd(3, gain)
        End Sub

        Private Sub send_cmd(cmd As Integer, param As Integer)
            Dim cmd_bytes As Byte() = BitConverter.GetBytes(cmd)
            Dim param_bytes As Byte() = BitConverter.GetBytes(param)
            Dim send_bytes As Byte() = cmd_bytes.Concat(param_bytes).ToArray()
            _s.Send(send_bytes, send_bytes.Length)
        End Sub

        Protected Overrides Sub Finalize()
            _s.Close()
        End Sub
    End Class

    Sub Main()
        Dim rtl As New rtl_fm_remote()
        Dim iss As New tle_reader("ISS (ZARYA)", 5520)

        If iss.tle Is Nothing Then
            Environment.Exit(0)
        End If

        Dim myloc As New ephem.Observer()
        myloc.lon = LONGITUDE
        myloc.lat = LATITUDE
        myloc.elevation = ALTITUDE

        Dim freq As Integer = F0
        Dim running As Boolean = True

        Try
            While running
                myloc.date = DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture)
                iss.tle.compute(myloc)
                Dim alt As Double = Math.Round(Math.Asin(iss.tle.alt) * 180 / Math.PI, 2)

                If alt > 0 Then
                    Dim new_freq As Integer = CInt(F0 - iss.tle.range_velocity * F0 / C)
                    If new_freq <> freq Then
                        Console.WriteLine(new_freq & " " & alt & " " & myloc.date)
                        rtl.set_freq(new_freq)
                    End If
                    freq = new_freq
                ElseIf iss.tle_expired Then
                    iss.reload()
                Else
                    Thread.Sleep(10000)
                    freq = F0
                End If
            End While
        Catch ex As Exception
            running = False
        End Try

        Console.WriteLine("Bye")
    End Sub

End Class
