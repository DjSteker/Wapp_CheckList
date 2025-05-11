'Public Class Class_decode_SSTV

'End Class

Imports System
Imports System.Numerics
Imports Windows.Win32.UI.Input

Module Main
    Dim img As img
    Dim pcm As pcm
    Dim nco As Complex
    Dim hz2rad As Single
    Dim channels As Integer
    Dim buff As Short()
    Dim rate As Integer = 48000

    Const sync_porch_sec As Double = 0.003
    Const porch_sec As Double = 0.0015
    Const y_sec As Double = 0.088
    Const uv_sec As Double = 0.044
    Const hor_sync_sec As Double = 0.009
    Const seperator_sec As Double = 0.0045

    Dim sync_porch_len As Integer = 0
    Dim porch_len As Integer = 0
    Dim y_len As Integer = 0
    Dim uv_len As Integer = 0
    Dim hor_sync_len As Integer = 0
    Dim seperator_len As Integer = 0

    Function add_sample(val As Single) As Integer
        For i As Integer = 0 To channels - 1
            buff(i) = CShort(Short.MaxValue * val)
        Next
        Return write_pcm(pcm, buff, 1)
    End Function

    Sub add_freq(freq As Single)
        add_sample(nco.Real)
        nco *= Complex.Exp(freq * hz2rad * Complex.ImaginaryOne)
    End Sub

    Sub hor_sync()
        For ticks As Integer = 0 To hor_sync_len - 1
            add_freq(1200.0)
        Next
    End Sub

    Sub sync_porch()
        For ticks As Integer = 0 To sync_porch_len - 1
            add_freq(1500.0)
        Next
    End Sub

    Sub porch()
        For ticks As Integer = 0 To porch_len - 1
            add_freq(1900.0)
        Next
    End Sub

    Sub even_seperator()
        For ticks As Integer = 0 To seperator_len - 1
            add_freq(1500.0)
        Next
    End Sub

    Sub odd_seperator()
        For ticks As Integer = 0 To seperator_len - 1
            add_freq(2300.0)
        Next
    End Sub

    Sub y_scan(y As Integer)
        For ticks As Integer = 0 To y_len - 1
            Dim xf As Single = fclampf((320.0 * ticks) / y_len, 0.0, 319.0)
            Dim x0 As Integer = xf
            Dim x1 As Integer = fclampf(x0 + 1, 0.0, 319.0)
            Dim off0 As Integer = 3 * y * img.width + 3 * x0
            Dim off1 As Integer = 3 * y * img.width + 3 * x1
            Dim R0 As Single = linear(img.pixel(off0))
            Dim G0 As Single = linear(img.pixel(off0 + 1))
            Dim B0 As Single = linear(img.pixel(off0 + 2))
            Dim R1 As Single = linear(img.pixel(off1))
            Dim G1 As Single = linear(img.pixel(off1 + 1))
            Dim B1 As Single = linear(img.pixel(off1 + 2)
            Dim R As Byte = srgb(flerpf(R0, R1, xf - x0))
            Dim G As Byte = srgb(flerpf(G0, G1, xf - x0))
            Dim B As Byte = srgb(flerpf(B0, B1, xf - x0))
            add_freq(1500.0 + 800.0 * Y_RGB(R, G, B) / 255.0)
        Next
    End Sub

    Sub v_scan(y As Integer)
        For ticks As Integer = 0 To uv_len - 1
            Dim xf As Single = fclampf((160.0 * ticks) / uv_len, 0.0, 159.0)
            Dim x0 As Integer = xf
            Dim x1 As Integer = fclampf(x0 + 1, 0.0, 159.0)
            Dim evn0 As Integer = 3 * y * img.width + 6 * x0
            Dim evn1 As Integer = 3 * y * img.width + 6 * x1
            Dim odd0 As Integer = 3 * (y + 1) * img.width + 6 * x0
            Dim odd1 As Integer = 3 * (y + 1) * img.width + 6 * x1
            Dim R0 As Single = (linear(img.pixel(evn0)) + linear(img.pixel(odd0)) + linear(img.pixel(evn0 + 3)) + linear(img.pixel(odd0 + 3))) / 4
            Dim G0 As Single = (linear(img.pixel(evn0 + 1)) + linear(img.pixel(odd0 + 1)) + linear(img.pixel(evn0 + 4)) + linear(img.pixel(odd0 + 4))) / 4
            Dim B0 As Single = (linear(img.pixel(evn0 + 2)) + linear(img.pixel(odd0 + 2)) + linear(img.pixel(evn0 + 5)) + linear(img.pixel(odd0 + 5))) / 4
            Dim R1 As Single = (linear(img.pixel(evn1)) + linear(img.pixel(odd1)) + linear(img.pixel(evn1 + 3)) + linear(img.pixel(odd1 + 3))) / 4
            Dim G1 As Single = (linear(img.pixel(evn1 + 1)) + linear(img.pixel(odd1 + 1)) + linear(img.pixel(evn1 + 4)) + linear(img.pixel(odd1 + 4))) / 4
            Dim B1 As Single = (linear(img.pixel(evn1 + 2)) + linear(img.pixel(odd1 + 2)) + linear(img.pixel(evn1 + 5)) + linear(img.pixel(odd1 + 5))) / 4
            Dim R As Byte = srgb(flerpf(R0, R1, xf - x0))
            Dim G As Byte = srgb(flerpf(G0, G1, xf - x0))
            Dim B As Byte = srgb(flerpf(B0, B1, xf - x0))
            add_freq(1500.0 + 800.0 * V_RGB(R, G, B) / 255.0)
        Next
    End Sub

    Sub u_scan(y As Integer)
        For ticks As Integer = 0 To uv_len - 1
            Dim xf As Single = fclampf((160.0 * ticks) / uv_len, 0.0, 159.0)
            Dim x0 As Integer = xf
            Dim x1 As Integer = fclampf(x0 + 1, 0.0, 159.0)
            Dim evn0 As Integer = 3 * (y - 1) * img.width + 6 * x0
            Dim evn1 As Integer = 3 * (y - 1) * img.width + 6 * x1
            Dim odd0 As Integer = 3 * y * img.width + 6 * x0
            Dim odd1 As Integer = 3 * y * img.width + 6 * x1
            Dim R0 As Single = (linear(img.pixel(evn0)) + linear(img.pixel(odd0)) + linear(img.pixel(evn0 + 3)) + linear(img.pixel(odd0 + 3))) / 4
            Dim G0 As Single = (linear(img.pixel(evn0 + 1)) + linear(img.pixel(odd0 + 1)) + linear(img.pixel(evn0 + 4)) + linear(img.pixel(odd0 + 4))) / 4
            Dim B0 As Single = (linear(img.pixel(evn0 + 2)) + linear(img.pixel(odd0 + 2)) + linear(img.pixel(evn0 + 5)) + linear(img.pixel(odd0 + 5))) / 4
            Dim R1 As Single = (linear(img.pixel(evn1)) + linear(img.pixel(odd1)) + linear(img.pixel(evn1 + 3)) + linear(img.pixel(odd1 + 3))) / 4
            Dim G1 As Single = (linear(img.pixel(evn1 + 1)) + linear(img.pixel(odd1 + 1)) + linear(img.pixel(evn1 + 4)) + linear(img.pixel(odd1 + 4))) / 4
            Dim B1 As Single = (linear(img.pixel(evn1 + 2)) + linear(img.pixel(odd1 + 2)) + linear(img.pixel(evn1 + 5)) + linear(img.pixel(odd1 + 5))) / 4
            Dim R As Byte = srgb(flerpf(R0, R1, xf - x0))
            Dim G As Byte = srgb(flerpf(G0, G1, xf - x0))
            Dim B As Byte = srgb(flerpf(B0, B1, xf - x0))
            add_freq(1500.0 + 800.0 * U_RGB(R, G, B) / 255.0)
        Next
    End Sub

    Sub Main(args As String())
            If args.Length < 2 Then
                Console.Error.WriteLine("usage: {0} <input.ppm> <output.wav|default|hw:?,?> <rate>", args(0))
                Environment.Exit(1)
            End If

            Dim img As Image = New Image()
            If Not open_img_read(img, args(1)) Then
                Environment.Exit(1)
            End If

            If 320 <> img.Width OrElse 240 <> img.Height Then
                Console.Error.WriteLine("image not 320x240")
                close_img(img)
                Environment.Exit(1)
            End If

            Dim pcm_name As String = "default"
            Dim rate As Integer
            Dim channels As Integer
            Dim sync_porch_len As Integer
            Dim porch_len As Integer
            Dim y_len As Integer
            Dim uv_len As Integer
            Dim hor_sync_len As Integer
            Dim seperator_len As Integer

            If args.Length > 2 Then
                pcm_name = args(2)
            End If
            If args.Length > 3 Then
                rate = Integer.Parse(args(3))
            End If
            If Not open_pcm_write(pcm, pcm_name, rate, 1, 37.5) Then
                Environment.Exit(1)
            End If

            rate = rate_pcm(pcm)
            channels = channels_pcm(pcm)

            sync_porch_len = rate * sync_porch_sec
            porch_len = rate * porch_sec
            y_len = rate * y_sec
            uv_len = rate * uv_sec
            hor_sync_len = rate * hor_sync_sec
            seperator_len = rate * seperator_sec

            Dim buff(channels - 1) As Short

            info_pcm(pcm)

            If Math.Abs(porch_sec * rate - porch_len) > 0.0001 Then
                Console.Error.WriteLine("this rate will not give accurate (smooth) results. try 40000Hz and resample to {0}Hz", rate)
            End If

            Dim hz2rad As Double = (2.0 * Math.PI) / rate
            Dim nco As Complex = -Complex.ImaginaryOne * 0.7
            Dim N As Integer = 13
            Dim seq_freq() As Double = {1900.0, 1200.0, 1900.0, 1200.0, 1300.0, 1300.0, 1300.0, 1100.0, 1300.0, 1300.0, 1300.0, 1100.0, 1200.0}
            Dim seq_time() As Double = {0.3, 0.01, 0.3, 0.03, 0.03, 0.03, 0.03, 0.03, 0.03, 0.03, 0.03, 0.03, 0.03}

            For ticks As Integer = 0 To CInt(0.3 * rate) - 1
                add_sample(0.0)
            Next

            For i As Integer = 0 To N - 1
                For ticks As Integer = 0 To CInt(seq_time(i) * rate) - 1
                    add_freq(seq_freq(i))
                Next
            Next

            For y As Integer = 0 To img.Height - 1
                ' EVEN LINES
                hor_sync()
                sync_porch()
                y_scan(y)
                even_seperator()
                porch()
                v_scan(y)
                ' ODD LINES
                y += 1
                hor_sync()
                sync_porch()
                y_scan(y)
                odd_seperator()
                porch()
                u_scan(y)
            Next

            While add_sample(0.0)
            End While

            close_pcm(pcm)
            close_img(img)
            Environment.Exit(0)
        End Sub

    End Module