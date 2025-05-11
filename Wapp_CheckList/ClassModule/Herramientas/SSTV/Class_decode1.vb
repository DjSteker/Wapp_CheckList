'Public Class Class_decode

'End Class


Imports System
Imports System.IO
'Imports Numpy As np
'Imports Soundfile
'Imports PIL.Image
'Imports Scipy.Signal.Windows.Hann
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Numerics

Namespace SSTVDecoder
    Public Class SSTVDecoder
        Private mode As Object
        Private _audio_file As String
        Private _samples As Double() ' np.array
        Private _sample_rate As Integer


        '    Private ReadOnly _audioFile As String
        '    Private _samples As Double()
        '    Private _sampleRate As Integer


        '' Función para leer un archivo de audio
        'Function read_audio_file(filename As String, ByRef data As Integer(), ByRef sample_rate As Integer) As Integer
        '        Dim info As SF_INFO
        '        Dim file As SNDFILE

        '        ' Abrir el archivo de audio
        '        file = sf_open(filename, SFM_READ, info)
        '        If file = Nothing Then
        '            Console.WriteLine("Error al abrir el archivo de audio: {0}", filename)
        '            Return 1
        '        End If

        '        ' Leer los datos del archivo
        '        ReDim data(info.frames - 1)
        '        sf_read_int(file, data, info.frames)

        '        ' Cerrar el archivo
        '        sf_close(file)

        '        ' Almacenar la frecuencia de muestreo
        '        sample_rate = info.samplerate

        '        Return 0
        '    End Function

        '    ' Función para encontrar la frecuencia pico
        '    Function find_peak_frequency(data As Integer(), sample_rate As Integer) As Integer
        '        Dim window_size As Integer = 1024
        '        Dim fft_data(window_size - 1) As Integer
        '        gsl_fft_complex_radix2_forward(fft_data, 1, window_size)

        '        ' Calcular la magnitud de la FFT
        '        Dim max_index As Integer = gsl_max_index(fft_data, window_size)

        '        ' Convertir el índice a frecuencia
        '        Dim peak_frequency As Integer = (max_index * sample_rate) / window_size

        '        Return peak_frequency
        '    End Function

        '    ' Función para decodificar la imagen
        '    Function decode_image(data As Integer(), sample_rate As Integer) As SDL_Surface
        '        Dim width As Integer = 640
        '        Dim height As Integer = 480

        '        ' Crear una superficie SDL
        '        Dim surface As SDL_Surface = SDL_CreateRGBSurface(0, width, height, 32, 0, 0, 0, 0)

        '        ' Decodificar cada línea de la imagen
        '        For y As Integer = 0 To height - 1
        '            For x As Integer = 0 To width - 1
        '                ' Calcular el valor del píxel
        '                Dim pixel_value As Integer = (data(y * width + x) * 255) / 32767

        '                ' Establecer el valor del píxel en la superficie
        '                SDL_SetPixel(surface, x, y, SDL_MapRGB(surface.format, pixel_value, pixel_value, pixel_value))
        '            Next
        '        Next

        '        Return surface
        '    End Function




        Public Sub New(audio_file As String)
            mode = Nothing
            _audio_file = audio_file
            Dim audioData As Tuple(Of Double(), Integer) = soundfile.read(_audio_file)
            _samples = audioData.Item1
            _sample_rate = audioData.Item2

            If _samples.ndim > 1 Then
                _samples = np.mean(_samples, axis:=1)
            End If
        End Sub

        Public Sub Decode(Optional skip As Double = 0.0)
            If skip > 0.0 Then
                _samples = np.round(_samples(skip * _sample_rate))
            End If

            Dim header_end As Integer = _find_header()

            If header_end Is Nothing Then
                Return Nothing
            End If

            mode = _decode_vis(header_end)

            Dim vis_end As Integer = header_end + np.round(spec.VIS_BIT_SIZE * 9 * _sample_rate)

            Dim image_data As Object = _decode_image_data(vis_end)

            Return _draw_image(image_data)
        End Sub

        Public Sub Close()
            If _audio_file IsNot Nothing AndAlso Not _audio_file.closed Then
                _audio_file.Close()
            End If
        End Sub

        'Private Function _peak_fft_freq(data As np.array)
        '    Dim windowed_data As np.array = data * hann(data.Length)
        '    Dim fft As np.array = np.abs(np.fft.rfft(windowed_data))

        '    Dim x As Integer = np.argmax(fft)
        '    Dim peak As Double = barycentric_peak_interp(fft, x)

        '    Return peak * _sample_rate / windowed_data.Length
        'End Function

        Private Function _peak_fft_freq(data As Double()) As Double
            ' Aplica una ventana de Hann a los datos
            Dim windowedData As Double() = data.Zip(MathNet.Numerics.Window.Hann(data.Length), Function(d, w) d * w).ToArray()

            ' Calcula la transformada rápida de Fourier
            Dim fft As Complex() = New Complex(windowedData.Length - 1) {}
            Fourier.Forward(windowedData, fft)

            ' Encuentra el índice de la frecuencia pico
            Dim x As Integer = fft.Select(Function(c) c.Magnitude).ToArray().IndexOf(fft.Select(Function(c) c.Magnitude).Max())

            ' Frecuencia pico interpolada
            Dim peak As Double = BarycentricPeakInterp(fft, x)

            ' Retorna la frecuencia en Hz
            Return peak * _sampleRate / windowedData.Length
        End Function

        ' Otras funciones y propiedades de la clase SSTVDecoder...

        Private Function BarycentricPeakInterp(bins As Complex(), x As Integer) As Double
            ' Implementa la interpolación barycentric para encontrar el valor x del pico
            ' ...

            ' Debes implementar esta función según las necesidades específicas
            ' y la lógica de tu aplicación.
            ' Puedes referirte a la implementación original de Python para obtener detalles sobre la lógica.

            Return 0.0 ' Valor de retorno de ejemplo
        End Function


        Private Function calc_lum(freq As Double) As Integer
            Dim lum As Integer = np.round((freq - 1500) / 3.1372549)
            Return Math.Min(Math.Max(lum, 0), 255)
        End Function

        Private Function barycentric_peak_interp(bins As np.array, x As Integer) As Double
            Dim y1 As Double = If(x <= 0, bins(x), bins(x - 1))
            Dim y3 As Double = If(x + 1 >= bins.Length, bins(x), bins(x + 1))

            Dim denom As Double = y3 + bins(x) + y1
            If denom = 0 Then
                Return 0
            End If

            Return (y3 - y1) / denom + x
        End Function








        Private Sub _find_header()
            'Finds the approx sample of the end of the calibration header

            Dim header_size As Integer = Math.Round(spec.HDR_SIZE * Me._sample_rate)
            Dim window_size As Integer = Math.Round(spec.HDR_WINDOW_SIZE * Me._sample_rate)

            'Relative sample offsets of the header tones
            Dim leader_1_sample As Integer = 0
            Dim leader_1_search As Integer = leader_1_sample + window_size

            Dim break_sample As Integer = Math.Round(spec.BREAK_OFFSET * Me._sample_rate)
            Dim break_search As Integer = break_sample + window_size

            Dim leader_2_sample As Integer = Math.Round(spec.LEADER_OFFSET * Me._sample_rate)
            Dim leader_2_search As Integer = leader_2_sample + window_size

            Dim vis_start_sample As Integer = Math.Round(spec.VIS_START_OFFSET * Me._sample_rate)
            Dim vis_start_search As Integer = vis_start_sample + window_size

            Dim jump_size As Integer = Math.Round(0.002 * Me._sample_rate) 'check every 2ms

            'The margin of error created here will be negligible when decoding the
            'vis due to each bit having a length of 30ms. We fix this error margin
            'when decoding the image by aligning each sync pulse

            For current_sample As Integer = 0 To Me._samples.Length - header_size Step jump_size
                'Update search progress message
                If current_sample Mod (jump_size * 256) = 0 Then
                    Dim search_msg As String = "Searching for calibration header... {:.1f}s"
                    Dim progress As Double = current_sample / Me._sample_rate
                    log_message(String.Format(search_msg, progress), True)
                End If

                Dim search_end As Integer = current_sample + header_size
                Dim search_area As Double() = Me._samples.Skip(current_sample).Take(header_size).ToArray()

                Dim leader_1_area As Double() = search_area.Skip(leader_1_sample).Take(leader_1_search).ToArray()
                Dim break_area As Double() = search_area.Skip(break_sample).Take(break_search).ToArray()
                Dim leader_2_area As Double() = search_area.Skip(leader_2_sample).Take(leader_2_search).ToArray()
                Dim vis_start_area As Double() = search_area.Skip(vis_start_sample).Take(vis_start_search).ToArray()

                'Check they're the correct frequencies
                If (Math.Abs(Me._peak_fft_freq(leader_1_area) - 1900) < 50 AndAlso
                   Math.Abs(Me._peak_fft_freq(break_area) - 1200) < 50 AndAlso
                   Math.Abs(Me._peak_fft_freq(leader_2_area) - 1900) < 50 AndAlso
                   Math.Abs(Me._peak_fft_freq(vis_start_area) - 1200) < 50) Then

                    Dim stop_msg As String = "Searching for calibration header... Found!{:>4}"
                    log_message(String.Format(stop_msg, " "))
                    Return current_sample + header_size
                End If
            Next

            log_message()
            log_message("Couldn't find SSTV header in the given audio file", True)
            Return Nothing
        End Sub

        Private Sub _decode_vis(vis_start As Integer)
            'Decodes the vis from the audio data and returns the SSTV mode

            Dim bit_size As Integer = Math.Round(spec.VIS_BIT_SIZE * Me._sample_rate)
            Dim vis_bits As New List(Of Integer)()

            For bit_idx As Integer = 0 To 7
                Dim bit_offset As Integer = vis_start + bit_idx * bit_size
                Dim section As Double() = Me._samples.Skip(bit_offset).Take(bit_size).ToArray()
                Dim freq As Double = Me._peak_fft_freq(section)
                '1100 hz = 1, 1300hz = 0
                vis_bits.Add(If(freq <= 1200, 1, 0))
            Next

            'Check for even parity in last bit
            Dim parity As Boolean = vis_bits.Sum() Mod 2 = 0
            If Not parity Then
                Throw New Exception("Error decoding VIS header (invalid parity bit)")
            End If

            'LSB first so we must reverse and ignore the parity bit
            Dim vis_value As Integer = 0
            For i As Integer = vis_bits.Count - 2 To 0 Step -1
                vis_value = (vis_value << 1) Or vis_bits(i)
            Next

            If Not spec.VIS_MAP.ContainsKey(vis_value) Then
                Dim error As String = "SSTV mode is unsupported (VIS: {})"
                Throw New Exception(String.Format(error, vis_value))
            End If

            Dim mode As String = spec.VIS_MAP(vis_value).NAME
            log_message(String.Format("Detected SSTV mode {0}", mode))
            Return mode
        End Sub

        Private Sub _align_sync(align_start As Integer, Optional start_of_sync As Boolean = True)
            'Returns sample where the beginning of the sync pulse was found

            'TODO - improve this

            Dim sync_window As Integer = Math.Round(Me.mode.SYNC_PULSE * 1.4 * Me._sample_rate)
            Dim align_stop As Integer = Me._samples.Length - sync_window

            If align_stop <= align_start Then
                Return Nothing 'Reached end of audio
            End If

            For current_sample As Integer = align_start To align_stop
                Dim section_end As Integer = current_sample + sync_window
                Dim search_section As Double() = Me._samples.Skip(current_sample).Take(sync_window).ToArray()

                If Me._peak_fft_freq(search_section) > 1350 Then
                    Exit For
                End If
            Next

            Dim end_sync As Integer = current_sample + (sync_window \ 2)

            If start_of_sync Then
                Return end_sync - Math.Round(Me.mode.SYNC_PULSE * Me._sample_rate)
            Else
                Return end_sync
            End If
        End Sub





        Private Function _decode_image_data(ByVal image_start As Integer) As List(Of List(Of List(Of Integer)))
            ' Decodes image from the transmission section of an sstv signal

            Dim window_factor As Integer = Me.mode.WINDOW_FACTOR
            Dim centre_window_time As Double = (Me.mode.PIXEL_TIME * window_factor) / 2
            Dim pixel_window As Integer = Math.Round(centre_window_time * 2 * Me._sample_rate)

            Dim height As Integer = Me.mode.LINE_COUNT
            Dim channels As Integer = Me.mode.CHAN_COUNT
            Dim width As Integer = Me.mode.LINE_WIDTH
            ' Use list comprehension to init list so we can return data early
            Dim image_data As New List(Of List(Of List(Of Integer)))()
            For k As Integer = 0 To height - 1
                Dim channelList As New List(Of List(Of Integer))()
                For j As Integer = 0 To channels - 1
                    Dim widthList As New List(Of Integer)()
                    For i As Integer = 0 To width - 1
                        widthList.Add(0)
                    Next
                    channelList.Add(widthList)
                Next
                image_data.Add(channelList)
            Next

            Dim seq_start As Integer = image_start
            If Me.mode.HAS_START_SYNC Then
                ' Start at the end of the initial sync pulse
                seq_start = Me._align_sync(image_start, False)
                If seq_start Is Nothing Then
                    Throw New EOFException("Reached end of audio before image data")
                End If
            End If

            For line As Integer = 0 To height - 1
                If Me.mode.CHAN_SYNC > 0 AndAlso line = 0 Then
                    ' Align seq_start to the beginning of the previous sync pulse
                    Dim sync_offset As Double = Me.mode.CHAN_OFFSETS(Me.mode.CHAN_SYNC)
                    seq_start -= Math.Round((sync_offset + Me.mode.SCAN_TIME) * Me._sample_rate)
                End If

                For chan As Integer = 0 To channels - 1
                    If chan = Me.mode.CHAN_SYNC Then
                        If line > 0 OrElse chan > 0 Then
                            ' Set base offset to the next line
                            seq_start += Math.Round(Me.mode.LINE_TIME * Me._sample_rate)
                        End If

                        ' Align to start of sync pulse
                        seq_start = Me._align_sync(seq_start)
                        If seq_start Is Nothing Then
                            log_message()
                            log_message("Reached end of audio whilst decoding.")
                            Return image_data
                        End If
                    End If

                    Dim pixel_time As Double = Me.mode.PIXEL_TIME
                    If Me.mode.HAS_HALF_SCAN Then
                        ' Robot mode has half-length second/third scans
                        If chan > 0 Then
                            pixel_time = Me.mode.HALF_PIXEL_TIME
                        End If

                        centre_window_time = (pixel_time * window_factor) / 2
                        pixel_window = Math.Round(centre_window_time * 2 * Me._sample_rate)
                    End If

                    For px As Integer = 0 To width - 1
                        Dim chan_offset As Double = Me.mode.CHAN_OFFSETS(chan)

                        Dim px_pos As Integer = Math.Round(seq_start + (chan_offset + px * pixel_time - centre_window_time) * Me._sample_rate)
                        Dim px_end As Integer = px_pos + pixel_window

                        ' If we are performing fft past audio length, stop early
                        If px_end >= Me._samples.Count Then
                            log_message()
                            log_message("Reached end of audio whilst decoding.")
                            Return image_data
                        End If

                        Dim pixel_area As List(Of Double) = Me._samples.GetRange(px_pos, px_end - px_pos)
                        Dim freq As Double = Me._peak_fft_freq(pixel_area)

                        image_data(line)(chan)(px) = calc_lum(freq)
                    Next

                    progress_bar(line, height - 1, "Decoding image...")
                Next
            Next

            Return image_data
        End Function

        Private Function _draw_image(ByVal image_data As List(Of List(Of List(Of Integer)))) As Image
            ' Renders the image from the decoded sstv signal

            ' Let PIL do YUV-RGB conversion for us
            Dim col_mode As String
            If Me.mode.COLOR = spec.COL_FMT.YUV Then
                col_mode = "YCbCr"
            Else
                col_mode = "RGB"
            End If

            Dim width As Integer = Me.mode.LINE_WIDTH
            Dim height As Integer = Me.mode.LINE_COUNT
            Dim channels As Integer = Me.mode.CHAN_COUNT

            Dim image As Image = image.New(col_mode, New Drawing.Size(width, height))
            Dim pixel_data As BitmapData = image.LockBits(New Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, image.PixelFormat)

            log_message("Drawing image data...")

            For y As Integer = 0 To height - 1
                Dim odd_line As Integer = y Mod 2
                For x As Integer = 0 To width - 1
                    Dim pixel As Color

                    If channels = 2 Then
                        If Me.mode.HAS_ALT_SCAN Then
                            If Me.mode.COLOR = spec.COL_FMT.YUV Then
                                ' R36
                                pixel = Color.FromArgb(image_data(y)(0)(x), image_data(y - (odd_line - 1))(1)(x), image_data(y - odd_line)(1)(x))
                            End If
                        End If
                    ElseIf channels = 3 Then
                        If Me.mode.COLOR = spec.COL_FMT.GBR Then
                            ' M1, M2, S1, S2, SDX
                            pixel = Color.FromArgb(image_data(y)(2)(x), image_data(y)(0)(x), image_data(y)(1)(x))
                        ElseIf Me.mode.COLOR = spec.COL_FMT.YUV Then
                            ' R72
                            pixel = Color.FromArgb(image_data(y)(0)(x), image_data(y)(2)(x), image_data(y)(1)(x))
                        ElseIf Me.mode.COLOR = spec.COL_FMT.RGB Then
                            pixel = Color.FromArgb(image_data(y)(0)(x), image_data(y)(1)(x), image_data(y)(2)(x))
                        End If
                    End If

                    pixel_data.SetPixel(x, y, pixel)
                Next
            Next

            image.UnlockBits(pixel_data)

            If image.PixelFormat <> PixelFormat.Format24bppRgb Then
                image = image.Convert("RGB")
            End If

            log_message("...Done!")
            Return image
        End Function



    End Class


















    'Friend Class Program
    '    <STAThread>
    '    Shared Sub Main()
    '        ' Reemplaza este camino con la ubicación de tu archivo de audio
    '        Dim audioFilePath As String = "Ruta/Al/Archivo/De/Audio.wav"

    '        Using decoder As New SSTVDecoder(audioFilePath)
    '            Try
    '                Dim image As Image = decoder.Decode()
    '                If image IsNot Nothing Then
    '                    ' Muestra la imagen decodificada en un formulario
    '                    Dim form As New Form()
    '                    form.ClientSize = New Size(image.Width, image.Height)
    '                    Dim pictureBox As New PictureBox With {
    '                        .Dock = DockStyle.Fill,
    '                        .Image = image
    '                    }
    '                    form.Controls.Add(pictureBox)
    '                    Application.Run(form)
    '                Else
    '                    Console.WriteLine("No se encontró una señal SSTV en el archivo de audio.")
    '                End If
    '            Catch ex As Exception
    '                Console.WriteLine($"Error al decodificar la señal SSTV: {ex.Message}")
    '            End Try
    '        End Using
    '    End Sub
    'End Class

    'Friend Class SSTVDecoder
    '    Private ReadOnly _audioFile As String
    '    Private _samples As Double()
    '    Private _sampleRate As Integer

    '    ' Otras propiedades y métodos de la clase SSTVDecoder...


    '    ' Otros campos, propiedades y métodos de la clase SSTVDecoder...

    '    Public Sub New(audioFile As String)
    '        ' Tareas de inicialización
    '        _audioFile = audioFile

    '        ' Lee las muestras del archivo de audio
    '        Using reader As New SoundIO.SoundIOFileReader(_audioFile)
    '            _samples = reader.ReadSamples().Select(Function(sample) Convert.ToDouble(sample)).ToArray()
    '            _sampleRate = reader.SampleRate
    '        End Using

    '        ' Otros inicializadores...
    '    End Sub


    '    Public Function Decode() As Image
    '        ' Encuentra el encabezado
    '        Dim headerEnd As Integer = FindHeader()
    '        If headerEnd Is Nothing Then
    '            Console.WriteLine("No se encontró el encabezado de SSTV en el archivo de audio.")
    '            Return Nothing
    '        End If

    '        ' Decodifica la información de la imagen
    '        Dim mode As SSTVMode = DecodeVIS(headerEnd)
    '        If mode Is Nothing Then
    '            Console.WriteLine("No se pudo decodificar la información de la imagen SSTV.")
    '            Return Nothing
    '        End If

    '        Dim visEnd As Integer = headerEnd + CInt(Spec.VIS_BIT_SIZE * 9 * _sampleRate)
    '        Dim imageData As List(Of List(Of List(Of Integer))) = DecodeImageData(visEnd)
    '        If imageData Is Nothing Then
    '            Console.WriteLine("No se pudo decodificar la información de la imagen SSTV.")
    '            Return Nothing
    '        End If

    '        ' Dibuja la imagen
    '        Return DrawImage(imageData)
    '    End Function

    '    ' Otros métodos y propiedades de la clase SSTVDecoder...


    '    Public Sub Close()
    '        If _audio_file IsNot Nothing AndAlso Not _audio_file.closed Then
    '            _audio_file.Close()
    '        End If
    '    End Sub

    'End Class









    'Imports System.Numerics

    Public Class AudioProcessor
    Private _sampleRate As Integer

    Public Sub New(sampleRate As Integer)
        _sampleRate = sampleRate
    End Sub

    Private Function BarycentricPeakInterp(fft As Complex(), peakIndex As Integer) As Double
        ' Implementa tu lógica de interpolación Barycentric aquí
        ' Esta es una función de marcador de posición; debes reemplazarla con tu implementación real
        ' Para fines de demostración, devolveremos la magnitud de la frecuencia pico
        Return fft(peakIndex).Magnitude
    End Function

    Public Function PeakFftFrequency(data As Double()) As Double
        ' Aplica una ventana Hann a los datos
        Dim windowedData As Double() = data.Zip(Hann(data.Length), Function(d, w) d * w).ToArray()

        ' Calcula la Transformada Rápida de Fourier
        Dim fft As Complex() = New Complex(windowedData.Length - 1) {}
        ForwardFourier(windowedData, fft)

            ' Encuentra el índice de la frecuencia pico
            Dim peakIndex As Integer = fft.Select(Function(c) c.Magnitude).ToArray().IndexOf(fft.Select(Function(c) c.Magnitude).Max())

            ' Frecuencia pico interpolada
            Dim peak As Double = BarycentricPeakInterp(fft, peakIndex)

        ' Devuelve la frecuencia en Hz
        Return peak * _sampleRate / windowedData.Length
    End Function

    Private Function Hann(length As Integer) As Double()
        ' Genera una ventana Hann
        Dim window As Double() = New Double(length - 1) {}
        For i As Integer = 0 To length - 1
            window(i) = 0.5 * (1 - Math.Cos(2 * Math.PI * i / (length - 1)))
        Next
        Return window
    End Function

    Private Sub ForwardFourier(input As Double(), output As Complex())
        ' Implementa tu lógica FFT aquí
        ' Esta es una función de marcador de posición; debes reemplazarla con tu implementación real
        ' Para fines de demostración, utilizaremos una FFT simple que asume que la longitud de entrada es una potencia de 2
        Dim n As Integer = input.Length
        For k As Integer = 0 To n - 1
            Dim sum As Complex = 0
            For j As Integer = 0 To n - 1
                sum += input(j) * Complex.Exp(-2 * Math.PI * Complex.ImaginaryOne * j * k / n)
            Next
            output(k) = sum
        Next
    End Sub
End Class

    '' Ejemplo de uso:
    'Dim sampleRate As Integer = 44100
    'Dim audioProcessor As New AudioProcessor(sampleRate)
    'Dim datosDeAudio As Double() = {1.0, 2.0, 3.0, 4.0, 5.0}
    'Dim frecuenciaPico As Double = audioProcessor.PeakFftFrequency(datosDeAudio)
    'Console.WriteLine($"Frecuencia pico: {frecuenciaPico} Hz")
End Namespace