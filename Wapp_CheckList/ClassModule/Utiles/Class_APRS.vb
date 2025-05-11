Imports System.Text
Imports System.Media
Imports System.Security.Cryptography

Public Class Class_APRS





    'El Sistema de Reporte Automático de Paquetes (APRS) utiliza una frecuencia compartida para transmitir datos en tiempo real. Aquí tienes algunos detalles:

    'Frecuencia de transmisión: En los Estados Unidos, la frecuencia utilizada para APRS es 144.39 MHz. Sin embargo, esto puede variar según el país1.
    'Velocidad de transmisión: APRS utiliza el protocolo AX.25 y transmite a 1200 baudios (bits por segundo) utilizando la modulación AFSK (Audio Frequency-Shift Keying)
    'con una frecuencia de 1200 Hz para marcar un bit 1 y 2200 Hz para marcar un bit 02.
    'En resumen, los bits del paquete APRS se transmiten a 1200 baudios en la banda de 2 metros utilizando la modulación AFSK.



    Friend Event msg(ByVal mensaje As String)

    Structure StructureBeepRec
        Public Amplitude As Integer
        Public Frequency As Integer
        Public Duration As Integer
    End Structure



    Structure MorseTrama
        Public Archivo As String
        Public text As String
        Public Volumen As Integer
        Public Velocity As Double
        Public VelocityShort As Double
        Public VelocityLong As Double
        Public VelocityEntreSigno As Double
        Public VelocityEntreLetra As Double
        Public Frecuencia0 As Integer
        Public Frecuencia1 As Integer
    End Structure



    Sub Main_APRS_1()
        Dim callsign As String = "TUINDICATIVO"
        Dim passcode As Integer = 12345 ' Reemplaza con tu passcode
        Dim latitud As Double = 40.123456 ' Ejemplo de latitud
        Dim longitud As Double = -3.789012 ' Ejemplo de longitud
        Dim mensaje As String = "Hola desde VB-APRS!"

        Dim paquete As String = $"{callsign}>APRS:!{latitud:0000.00}N/{longitud:00000.00}W{mensaje}"
        Dim checksum As Integer = 0
        For Each c As Char In paquete
            checksum = checksum Xor Asc(c)
        Next

        Dim paqueteFinal As String = $"{paquete}{Chr(&H3)}{passcode:00000}*" & checksum.ToString("X2")
        ' Envía paqueteFinal a través del puerto serial a tu módulo APRS

    End Sub

    Function CodificarAPRS(mensaje As String) As String

    End Function


    Function DecodificarAPRS(mensajeCodificado As String) As String


    End Function


    Sub Main_APRS_2()
        Dim mensajeOriginal As String = "Hola desde AX.25"
        Dim bitsAX25 As String = StringToAX25Bits(mensajeOriginal)
        Console.WriteLine("Mensaje original: " & mensajeOriginal)
        Console.WriteLine("Bits en formato AX.25: " & bitsAX25)
    End Sub

    Function StringToAX25Bits(message As String) As String
        ' Codifica cada carácter en su representación de 8 bits (ASCII)
        Dim sb As New StringBuilder()
        For Each c As Char In message
            Dim charByte As Byte = Asc(c)
            Dim charBits As String = Convert.ToString(charByte, 2).PadLeft(8, "0"c)
            sb.Append(charBits)
        Next

        ' Agrega el campo de bandera (flag) al inicio y al final
        Dim flag As String = "01111110"
        Return flag & sb.ToString() & flag
    End Function




    Sub Main_APRS_3()
        Dim ax25Frame As String = "011111100110110100000011011111100110110"
        Dim message As String = AX25BitsToString(ax25Frame)
        Console.WriteLine("Mensaje decodificado: " & message)
    End Sub

    Function AX25BitsToString(ax25Bits As String) As String
        ' Elimina las banderas al inicio y al final
        ax25Bits = ax25Bits.Trim("0"c)

        ' Divide la trama en bytes de 8 bits
        Dim bytes As New List(Of Byte)()
        For i As Integer = 0 To ax25Bits.Length - 1 Step 8
            Dim byteStr As String = ax25Bits.Substring(i, 8)
            Dim byteValue As Byte = Convert.ToByte(byteStr, 2)
            bytes.Add(byteValue)
        Next

        ' Convierte los bytes en caracteres
        Dim message As String = Encoding.ASCII.GetString(bytes.ToArray())
        Return message
    End Function



    Public Shared Sub BeepBeep(ByVal Amplitude As Integer, ByVal Frequency As Double, ByVal Duration As Double, Optional ByVal StrFilename As String = "")

        'El encabezado de un archivo WAV (RIFF) tiene una longitud de 44 bytes y sigue este formato
        '1-4: “RIFF”: Marca el archivo como archivo RIFF.
        '5-8: Tamaño del archivo (entero): Representa el tamaño total del archivo en bytes (entero de 32 bits).
        '9-12: “WAVE”: Encabezado de tipo de archivo. Siempre es igual a “WAVE” para nuestros propósitos.
        '13-16: "fmt ": Marcador de fragmento de formato. Incluye un cero al final.
        '17-20: Longitud de los datos de formato (generalmente 16).
        '21-22: Tipo de formato (1 para PCM).
        '23-24: Número de canales (2 para estéreo, 1 para mono).
        '25-28: Frecuencia de muestreo (por ejemplo, 44100 para CD).
        '29-32: Tasa de bits (Frecuencia de muestreo * Bits por muestra * Canales) / 8.
        '33-34: Tamaño de muestra (Bits por muestra * Canales) / 8.
        '35-36: Bits por muestra (generalmente 16).
        '37-40: “data”: Encabezado del fragmento de datos. Marca el comienzo de la sección de datos.
        '41-44: Tamaño del archivo de datos2.

        Dim BitsSampler As Integer = 16
        Dim Canales As UInt16 = 2
        Dim FrecuenciaMuestreo As Integer = 44100

        Try
            Dim Datos() As String = BaseDatos.Class_XmlAudioMorse.ObtenerTodos()
            FrecuenciaMuestreo = Datos(0)
            BitsSampler = Datos(1)
            Canales = Datos(2)
        Catch ex As Exception

        End Try



        Dim A As Double = ((Amplitude * (System.Math.Pow(2, 15))) / 1000) - 1
        Dim DeltaFT As Double = 2 * Math.PI * Frequency / FrecuenciaMuestreo
        Dim Samples As Integer = (FrecuenciaMuestreo / 100) * Duration \ 10
        Dim Bytes As Integer = Samples * 4
        Dim Hdr() As Integer = {&H46464952, 36 + Bytes, &H45564157, &H20746D66, BitsSampler, &H20001, FrecuenciaMuestreo, 176400, &H100004, &H61746164, Bytes}
        Dim MakeFile As Boolean = IsValidPath(StrFilename)
        Dim FW As System.IO.BinaryWriter
        Using MS As New System.IO.MemoryStream(44 + Bytes)
            Using BW As New System.IO.BinaryWriter(MS)
                If MakeFile = True Then FW = New System.IO.BinaryWriter(System.IO.File.Open(StrFilename, System.IO.FileMode.Create))
                For I As Integer = 0 To Hdr.Length - 1
                    BW.Write(Hdr(I))
                    If MakeFile = True Then FW.Write(Hdr(I))
                Next I
                For T As Integer = 0 To Samples - 1
                    Dim Sample As Short = System.Convert.ToInt16(A * Math.Sin(DeltaFT * T))
                    BW.Write(Sample)
                    BW.Write(Sample)
                    If MakeFile = True Then
                        FW.Write(Sample)
                        FW.Write(Sample)
                    End If
                Next T
                BW.Flush()
                If MakeFile = True Then
                    FW.Flush()
                    FW.Close()
                End If
                MS.Seek(0, System.IO.SeekOrigin.Begin)
                Using SP As New SoundPlayer(MS)
                    SP.PlaySync()
                End Using
            End Using
        End Using
    End Sub



    Friend Sub BeepRec(ByVal MorseBeepRec As List(Of StructureBeepRec), Optional ByVal StrFilename As String = "") ', ByVal AttacControl As Boolean, ByVal DecayControl As Boolean)

        Dim A As Double
        Dim DeltaFT As Double
        Dim Samples As Double
        Dim Bytes As Integer
        Dim Hdr() As Integer
        Dim MakeFile As Boolean
        Dim FW As System.IO.BinaryWriter
        Dim audio As New List(Of Double)
        Dim UltimoT As Integer = 0


        Dim FrecuenciaMuestreo As UInt32 = 44100.0
        Dim BitsSampler As UInt32 = 16
        Dim Canales As UInt32 = 2
        Dim BytesSampler As Double = BitsSampler / 8

        Try
            Dim DatosFormato() As String = BaseDatos.Class_XmlAudioSSTV.ObtenerTodos()
            FrecuenciaMuestreo = DatosFormato(0)
            BitsSampler = DatosFormato(1)
            Canales = DatosFormato(2)
        Catch ex As Exception

        End Try

        'Dim AmplitudAtacc As Double

        For indice As Integer = 0 To MorseBeepRec.Count - 1


            A = ((MorseBeepRec(indice).Amplitude) / 1000)  ' ((MorseBeepRec(indice).Amplitude * (System.Math.Pow(2, 15))) / 1000) - 1
            DeltaFT = 2 * Math.PI * MorseBeepRec(indice).Frequency / FrecuenciaMuestreo
            Samples = (FrecuenciaMuestreo / 100) * MorseBeepRec(indice).Duration \ 10
            Bytes += (Samples * Canales * BytesSampler) 'Samples * 4

            Dim Ciclo As Integer = CInt(FrecuenciaMuestreo / MorseBeepRec(indice).Frequency)
            Dim SamplerPorCiclo As Integer = CInt(FrecuenciaMuestreo / MorseBeepRec(indice).Frequency)

            Dim MustraCiclo As Double = Ciclo * (1 / FrecuenciaMuestreo)
            Dim CicloMuetras As Double = 1 / MustraCiclo
            Dim Contador As Integer = 0

            Dim CiclosEnteros As Double = (Samples / CicloMuetras)
            Dim SamplerUltimociclo As Integer = Math.Floor(CiclosEnteros) * CicloMuetras
            Dim MedioCicloEntero As Integer = CicloMuetras / 2




            'If audio.Count > 1 Then
            '    Dim Sample As Short = System.Convert.ToInt16(Math.Floor(((A) * Math.Sin(DeltaFT * UltimoT)) * 0.7))
            '    audio.Item(audio.Count - 2) = System.Convert.ToInt16((audio.Item(audio.Count - 2) + Sample) / 2)
            '    audio.Item(audio.Count - 1) = audio.Item(audio.Count - 2)
            'End If

            Dim CicloAtaque As Integer = SamplerPorCiclo / 8
            Dim CicloDecaimento As Integer = SamplerPorCiclo - CicloAtaque



            'If audio.Count > 4 And UltimoT > 3 Then
            '    Dim Sample1 As Short = System.Convert.ToInt16(Math.Floor(((A) * Math.Sin(DeltaFT * UltimoT)) * 0.2))
            '    Dim Sample2 As Short = System.Convert.ToInt16(Math.Floor(((A) * Math.Sin(DeltaFT * (UltimoT - 1))) * 0.1))

            '    Dim Sample_1 As Short = audio.Item(audio.Count - 2)
            '    Dim Sample_2 As Short = audio.Item(audio.Count - 4)

            '    audio.Item(audio.Count - 2) = System.Convert.ToInt16(((Sample_1 * 2) + Sample1) / 3)
            '    audio.Item(audio.Count - 1) = audio.Item(audio.Count - 2)

            '    audio.Item(audio.Count - 4) = System.Convert.ToInt16(((Sample_2 * 10) + (Sample2 * 2) + Sample1) / 13)
            '    audio.Item(audio.Count - 3) = audio.Item(audio.Count - 4)

            'End If



            For T As Integer = 0 To Samples - 1

                Dim Sample As Double = 0

                If T < (Ciclo / 2) And (Samples > Ciclo) Then
                    'Sample = System.Convert.ToInt16((A * (T / Ciclo)) * Math.Sin(DeltaFT * T))
                    Sample = ((A * 0.25) * Math.Sin(DeltaFT * T)) 'Sample = System.Convert.ToInt16((A * 0.25) * Math.Sin(DeltaFT * T))

                ElseIf (T < Ciclo) Then

                    Sample = ((A * 0.45) * Math.Sin(DeltaFT * T)) 'Sample = System.Convert.ToInt16((A * 0.45) * Math.Sin(DeltaFT * T))
                ElseIf SamplerUltimociclo < T Then
                    Sample = ((A * 0.4) * Math.Sin(DeltaFT * T)) 'Sample = System.Convert.ToInt16((A * 0.4) * Math.Sin(DeltaFT * T))

                ElseIf (T < ((Ciclo / 2) + Samples)) And (Samples > Ciclo) Then 'ElseIf (T < (Ciclo / 2)) + Samples Then
                    Sample = ((A * 0.5) * Math.Sin(DeltaFT * T)) 'Sample = System.Convert.ToInt16((A * 0.5) * Math.Sin(DeltaFT * T))
                Else
                    Sample = (A * Math.Sin(DeltaFT * T))  'Sample = System.Convert.ToInt16(A * Math.Sin(DeltaFT * T))
                End If

                ''Dim Sample As Short = System.Convert.ToInt16(A * Math.Sin(DeltaFT * T))
                'audio.Add(Sample)
                'audio.Add(Sample)
                For I_Chan As UInt16 = 0 To Canales - 1
                    audio.Add(Sample)
                Next I_Chan

            Next T
            UltimoT = Samples - 1
        Next



        'Posiciones  Valor de muestra	Descripción
        '1 - 4	“RIFF”	Marca el archivo como archivo riff. Los caracteres tienen 1 byte de longitud cada uno.
        '5 - 8	Tamaño del archivo (entero)	Tamaño del archivo total: 8 bytes, en bytes (entero de 32 bits). Por lo general, completará esto después de la creación.
        '9 -12	“WAVE”	Encabezado de tipo de archivo. Para nuestros propósitos, siempre es igual a “ONDA”.
        '13-16	"fmt "	Marcador de fragmento de formato. Incluye cero final.
        '17-20	16	Longitud de los datos de formato como se indica arriba.
        '21-22	1	Tipo de formato (1 es PCM) - entero de 2 bytes.
        '23-24	2	Número de canales: entero de 2 bytes.
        '25-28	44100	Frecuencia de muestreo: entero de 32 bytes. Los valores comunes son 44100 (CD), 48000 (DAT). Frecuencia de muestreo = Número de muestras por segundo, o Hertz.
        '29-32	176400	(Frecuencia de muestreo * Bits por muestra * Canales) / 8.
        '33-34	4	(BitsPerSample * Canales) / 8.
        '35-36	16	Bits por muestra.
        '37-40	“datos”	Encabezado de fragmento de “datos”. Marca el comienzo de la sección de datos.
        '41-44	Tamaño del archivo (datos)	Tamaño del archivo total: tamaño de los datos de audio + 36 bytes.
        ' Write audio to file
        'Using writer As New System.IO.BinaryWriter(System.IO.File.OpenWrite(My.Application.Info.DirectoryPath & "\SSTV\audio.wav"))
        '    writer.Write(System.Text.Encoding.ASCII.GetBytes("RIFF"))
        '    writer.Write(0)
        '    writer.Write(System.Text.Encoding.ASCII.GetBytes("WAVE"))
        '    writer.Write(System.Text.Encoding.ASCII.GetBytes("fmt "))
        '    writer.Write(16)
        '    writer.Write(CShort(1))
        '    writer.Write(CShort(1))
        '    writer.Write(sr)
        '    writer.Write(sr * 2)
        '    writer.Write(CShort(2))
        '    writer.Write(CShort(16))
        '    writer.Write(System.Text.Encoding.ASCII.GetBytes("data"))
        '    writer.Write(sr * dur * 2)

        '    For i As Integer = 0 To sr * dur - 1
        '        writer.Write(CShort(audio(i) * Short.MaxValue))
        '    Next
        'End Using

        SoundViewer.Class_FileAudio.GrabarWav(StrFilename, audio, Bytes, FrecuenciaMuestreo, BitsSampler, Canales)

        'Hdr = {&H46464952, 36 + Bytes, &H45564157, &H20746D66, 16, &H20001, 44100, 176400, &H100004, &H61746164, Bytes}
        'MakeFile = IsValidPath(StrFilename)

        'Using MS As New System.IO.MemoryStream()
        '    Using BW As New System.IO.BinaryWriter(MS)
        '        If MakeFile = True Then FW = New System.IO.BinaryWriter(System.IO.File.Open(StrFilename, System.IO.FileMode.Create))
        '        For I As Integer = 0 To Hdr.Length - 1
        '            BW.Write(Hdr(I))
        '            If MakeFile = True Then FW.Write(Hdr(I))
        '        Next I
        '        For Each Sample As Short In audio
        '            BW.Write(Sample)
        '            If MakeFile = True Then FW.Write(Sample)
        '        Next
        '        BW.Flush()
        '        If MakeFile = True Then
        '            FW.Flush()
        '            FW.Close()
        '        End If
        '        MS.Seek(0, System.IO.SeekOrigin.Begin)
        '        If MakeFile = False Then
        '            Using SP As New System.Media.SoundPlayer(MS)
        '                SP.PlaySync()
        '            End Using
        '        End If

        '    End Using
        'End Using

        'msg("se guardo el archivo" & StrFilename)
        RaiseEvent msg("se guardo el archivo" & StrFilename)

    End Sub


    Public Shared Function IsValidPath(ByVal path As String) As Boolean
        Try
            Dim f As New System.IO.FileInfo(path)
            Return True
        Catch e As Exception
            Return False
        End Try
    End Function




    Friend Shared Sub Sub_BeepRec_FAX480_V3(ByVal MorseBeepRec As List(Of StructureBeepRec), Optional ByVal StrFilename As String = "") ', ByVal AttacControl As Boolean, ByVal DecayControl As Boolean)

        'El encabezado de un archivo WAV (RIFF) tiene una longitud de 44 bytes y sigue este formato
        '1-4: “RIFF”: Marca el archivo como archivo RIFF.
        '5-8: Tamaño del archivo (entero): Representa el tamaño total del archivo en bytes (entero de 32 bits).
        '9-12: “WAVE”: Encabezado de tipo de archivo. Siempre es igual a “WAVE” para nuestros propósitos.
        '13-16: "fmt ": Marcador de fragmento de formato. Incluye un cero al final.
        '17-20: Longitud de los datos de formato (generalmente 16).
        '21-22: Tipo de formato (1 para PCM).
        '23-24: Número de canales (2 para estéreo, 1 para mono).
        '25-28: Frecuencia de muestreo (por ejemplo, 44100 para CD).
        '29-32: Tasa de bits (Frecuencia de muestreo * Bits por muestra * Canales) / 8.
        '33-34: Tamaño de muestra (Bits por muestra * Canales) / 8.
        '35-36: Bits por muestra (generalmente 16).
        '37-40: “data”: Encabezado del fragmento de datos. Marca el comienzo de la sección de datos.
        '41-44: Tamaño del archivo de datos2.

        Dim BitsSampler As Integer = 16
        Dim Canales As UInt16 = 2
        Dim FrecuenciaMuestreo As Integer = 44100

        Try
            Dim Datos() As String = BaseDatos.Class_XmlAudioMorse.ObtenerTodos()
            FrecuenciaMuestreo = Datos(0)
            BitsSampler = Datos(1)
            Canales = Datos(2)
        Catch ex As Exception

        End Try




        Dim A As Double = 1
        Dim DeltaFT As Double
        Dim Samples As Integer
        Dim Bytes As UInteger
        Dim Hdr() As Integer
        Dim MakeFile As Boolean
        Dim FW As System.IO.BinaryWriter
        Dim audio As New List(Of Double)
        'Dim FrecuenciaMuestreo As Integer = 48000 '44100.0
        'Dim BitsSampler = 32
        Dim BytesSampler As Double = BitsSampler / 8 ' Math.Sqrt(1 / 16) 'Math.Pow(25, 1 / 2)
        'Dim Canales As UInt16 = 1


        Try
            Dim DatosFormato() As String = BaseDatos.Class_XmlAudioSSTV.ObtenerTodos()
            FrecuenciaMuestreo = DatosFormato(0)
            BitsSampler = DatosFormato(1)
            Canales = DatosFormato(2)
        Catch ex As Exception

        End Try


        Dim UltimoT As ULong = 0

        For indice As Integer = 0 To MorseBeepRec.Count - 1

            Dim Ciclos As Double = (FrecuenciaMuestreo / MorseBeepRec(indice).Frequency)
            Dim UltimoSamplerCicloCompleto As Integer = Ciclos * (1 / FrecuenciaMuestreo) 'ciclos * (1 / fs)

            Dim A2 As Double = ((MorseBeepRec(indice).Amplitude * (System.Math.Pow(2, 15))) / 1000) - 1
            'A = ((MorseBeepRec(indice).Amplitude * (System.Math.Pow(2, 15))) / 1000) - 1
            A = (MorseBeepRec(indice).Amplitude / 1000)
            DeltaFT = 2 * Math.PI * MorseBeepRec(indice).Frequency / FrecuenciaMuestreo
            Samples = (FrecuenciaMuestreo / 100) * MorseBeepRec(indice).Duration / 10
            'Bytes += Samples * 4
            Bytes += (Samples * Canales * BytesSampler)

            Dim Ciclo As Integer = CInt(FrecuenciaMuestreo / MorseBeepRec(indice).Frequency)
            Dim SamplerPorCiclo As Integer = CInt(FrecuenciaMuestreo / MorseBeepRec(indice).Frequency)

            Dim MustraCiclo As Double = Ciclo * (1 / FrecuenciaMuestreo)
            Dim CicloMuetras As Double = 1 / MustraCiclo
            Dim Contador As Integer = 0

            Dim CiclosEnteros As Double = (Samples / CicloMuetras)
            Dim SamplerUltimociclo As Integer = (CiclosEnteros) * CicloMuetras
            Dim MedioCicloEntero As Integer = CicloMuetras / 2


            Dim CicloAtaque As Integer = SamplerPorCiclo / 8
            Dim CicloDecaimento As Integer = SamplerPorCiclo - CicloAtaque

            If (MorseBeepRec(indice).Duration = 5.12) And MorseBeepRec(indice).Frequency = 1200 Then
                UltimoT = 0
            End If
            Dim T2 As Double = 0

            Try
                For T As UInteger = UltimoT To UltimoT + (Samples - 1)

                    Contador += 1
                    Dim Sample As Double = 0

                    'Sample = System.Convert.ToInt16(Math.Floor(A * Math.Sin(DeltaFT * T)))
                    If Contador < (CicloMuetras / 2) Then
                        'Sample = System.Convert.ToInt16((A * (T / Ciclo)) * Math.Sin(DeltaFT * T))
                        'Sample = System.Convert.ToInt16(Math.Floor((A * 0.5) * Math.Sin(DeltaFT * T)))
                        Sample = ((A) * Math.Sin(DeltaFT * T)) * 0.8
                    ElseIf Contador < (CicloMuetras) Then
                        'Sample = System.Convert.ToInt16((A * (T / Ciclo)) * Math.Sin(DeltaFT * T))
                        'Sample = System.Convert.ToInt16(Math.Floor((A * 0.75) * Math.Sin(DeltaFT * T)))
                        Sample = ((A) * Math.Sin(DeltaFT * T)) * 0.9
                    ElseIf (Contador > (Samples - MedioCicloEntero)) Then
                        'Sample = System.Convert.ToInt16(Math.Floor((A * 0.0125) * Math.Sin(DeltaFT * T)))
                        Sample = (A) * Math.Sin(DeltaFT * T) * 0.00125
                    Else
                        Sample = A * Math.Sin(DeltaFT * T)
                    End If

                    'Sample = System.Convert.ToInt16(A * Math.Sin(DeltaFT * T))


                    'Dim Sample As Short = System.Convert.ToInt16(A * Math.Sin(DeltaFT * T))
                    For I_Chan As UInt16 = 0 To Canales - 1
                        audio.Add(Sample)
                        'audio.Add(Sample)
                    Next I_Chan
                    'audio.Add(Sample)

                Next T
            Catch ex As Exception

            End Try




            UltimoT += Samples



        Next


        'ObtenerFFT_Single(audio)

        'El encabezado de un archivo WAV (RIFF) tiene una longitud de 44 bytes y sigue este formato
        '1-4: “RIFF”: Marca el archivo como archivo RIFF.
        '5-8: Tamaño del archivo (entero): Representa el tamaño total del archivo en bytes (entero de 32 bits).
        '9-12: “WAVE”: Encabezado de tipo de archivo. Siempre es igual a “WAVE” para nuestros propósitos.
        '13-16: "fmt ": Marcador de fragmento de formato. Incluye un cero al final.
        '17-20: Longitud de los datos de formato (generalmente 16).
        '21-22: Tipo de formato (1 para PCM).
        '23-24: Número de canales (2 para estéreo, 1 para mono).
        '25-28: Frecuencia de muestreo (por ejemplo, 44100 para CD).
        '29-32: Tasa de bits (Frecuencia de muestreo * Bits por muestra * Canales) / 8.
        '33-34: Tamaño de muestra (Bits por muestra * Canales) / 8.
        '35-36: Bits por muestra (generalmente 16).
        '37-40: “data”: Encabezado del fragmento de datos. Marca el comienzo de la sección de datos.
        '41-44: Tamaño del archivo de datos2.



        'Hdr = {&H46464952, 36 + Bytes, &H45564157, &H20746D66, 16, &H20001, 44100, 176400, &H100004, &H61746164, Bytes}
        Hdr = {&H46464952, 36 + Bytes, &H45564157, &H20746D66, BitsSampler, &H20001, FrecuenciaMuestreo, 176400, &H100004, &H61746164, Bytes}


        Try
            If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\APRS") = False Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\APRS")
            End If
        Catch ex As Exception

        End Try

        Dim RutaArchivo As String = My.Application.Info.DirectoryPath & "\APRS\" & StrFilename



        MakeFile = IsValidPath(RutaArchivo)


        'Class_FileAudio.WriteWavFile(RutaArchivo, audio, Bytes, 44100, 16, 2)
        SoundViewer.Class_FileAudio.GrabarWav(RutaArchivo, audio, Bytes, FrecuenciaMuestreo, BitsSampler, Canales)




        'Using MS As New System.IO.MemoryStream()
        '    Using BW As New System.IO.BinaryWriter(MS)
        '        If MakeFile = True Then FW = New System.IO.BinaryWriter(System.IO.File.Open(RutaArchivo, System.IO.FileMode.Create))
        '        For I As Integer = 0 To Hdr.Length - 1
        '            BW.Write(Hdr(I))
        '            If MakeFile = True Then FW.Write(Hdr(I))
        '        Next I
        '        For Each Sample As Short In audio
        '            BW.Write(Sample)
        '            If MakeFile = True Then FW.Write(Sample)
        '        Next
        '        BW.Flush()
        '        If MakeFile = True Then
        '            FW.Flush()
        '            FW.Close()
        '        End If
        '        MS.Seek(0, System.IO.SeekOrigin.Begin)
        '        If MakeFile = False Then
        '            Using SP As New System.Media.SoundPlayer(MS)
        '                SP.PlaySync()
        '            End Using
        '        End If

        '    End Using
        'End Using
    End Sub

    Friend Sub Sub_BeepRec_FAX480_V03(ByVal MorseBeepRec As List(Of StructureBeepRec), Optional ByVal StrFilename As String = "") ', ByVal AttacControl As Boolean, ByVal DecayControl As Boolean)


        Dim BitsSampler As Integer = 16
        Dim Canales As UInt16 = 2
        Dim FrecuenciaMuestreo As Integer = 44100

        Try
            Dim Datos() As String = BaseDatos.Class_XmlAudioMorse.ObtenerTodos()
            FrecuenciaMuestreo = Datos(0)
            BitsSampler = Datos(1)
            Canales = Datos(2)
        Catch ex As Exception

        End Try

        Dim A As Double = 1
        Dim DeltaFT As Double
        Dim Samples As Integer
        Dim Bytes As UInteger
        Dim Hdr() As Integer
        Dim MakeFile As Boolean
        Dim FW As System.IO.BinaryWriter
        Dim audio As New List(Of Double)

        Dim BytesSampler As Double = BitsSampler / 8 ' Math.Sqrt(1 / 16) 'Math.Pow(25, 1 / 2)



        Try
            Dim DatosFormato() As String = BaseDatos.Class_XmlAudioSSTV.ObtenerTodos()
            FrecuenciaMuestreo = DatosFormato(0)
            BitsSampler = DatosFormato(1)
            Canales = DatosFormato(2)
        Catch ex As Exception

        End Try


        Dim UltimoT As ULong = 0

        For indice As Integer = 0 To MorseBeepRec.Count - 1

            Dim Ciclos As Double = (FrecuenciaMuestreo / MorseBeepRec(indice).Frequency)
            Dim UltimoSamplerCicloCompleto As Integer = Ciclos * (1 / FrecuenciaMuestreo) 'ciclos * (1 / fs)

            Dim A2 As Double = ((MorseBeepRec(indice).Amplitude * (System.Math.Pow(2, 15))) / 1000) - 1
            A = (MorseBeepRec(indice).Amplitude / 1000)
            DeltaFT = 2 * Math.PI * MorseBeepRec(indice).Frequency / FrecuenciaMuestreo
            Samples = (FrecuenciaMuestreo / 100) * MorseBeepRec(indice).Duration / 10
            'Bytes += Samples * 4
            Bytes += (Samples * Canales * BytesSampler)

            Dim Ciclo As Integer = CInt(FrecuenciaMuestreo / MorseBeepRec(indice).Frequency)
            Dim SamplerPorCiclo As Integer = CInt(FrecuenciaMuestreo / MorseBeepRec(indice).Frequency)

            Dim MustraCiclo As Double = Ciclo * (1 / FrecuenciaMuestreo)
            Dim CicloMuetras As Double = 1 / MustraCiclo
            Dim Contador As Integer = 0

            Dim CiclosEnteros As Double = (Samples / CicloMuetras)
            Dim SamplerUltimociclo As Integer = (CiclosEnteros) * CicloMuetras
            Dim MedioCicloEntero As Integer = CicloMuetras / 2


            Dim CicloAtaque As Integer = SamplerPorCiclo / 8
            Dim CicloDecaimento As Integer = SamplerPorCiclo - CicloAtaque

            If (MorseBeepRec(indice).Duration = 5.12) And MorseBeepRec(indice).Frequency = 1200 Then
                UltimoT = 0
            End If
            Dim T2 As Double = 0



            For T As UInteger = UltimoT To UltimoT + (Samples - 1)

                Contador += 1
                Dim Sample As Double = 0

                'Sample = System.Convert.ToInt16(Math.Floor(A * Math.Sin(DeltaFT * T)))
                If Contador < (CicloMuetras / 2) Then
                    Sample = ((A) * Math.Sin(DeltaFT * T)) * 0.8
                ElseIf Contador < (CicloMuetras) Then
                    Sample = ((A) * Math.Sin(DeltaFT * T)) * 0.9
                ElseIf (Contador > (Samples - MedioCicloEntero)) Then
                    Sample = (A) * Math.Sin(DeltaFT * T) * 0.00125
                Else
                    Sample = A * Math.Sin(DeltaFT * T)
                End If

                For I_Chan As UInt16 = 0 To Canales - 1
                    audio.Add(Sample)
                    'audio.Add(Sample)
                Next I_Chan
                'audio.Add(Sample)

            Next T



            UltimoT += Samples



        Next


        Hdr = {&H46464952, 36 + Bytes, &H45564157, &H20746D66, 16, &H20001, 44100, 176400, &H100004, &H61746164, Bytes}

        Dim RutaArchivo As String = My.Application.Info.DirectoryPath & "\SSTV\" & StrFilename

        MakeFile = IsValidPath(RutaArchivo)


        'Class_FileAudio.WriteWavFile(RutaArchivo, audio, Bytes, 44100, 16, 2)
        SoundViewer.Class_FileAudio.GrabarWav(RutaArchivo, audio, Bytes, FrecuenciaMuestreo, BitsSampler, Canales)



    End Sub





















#Region ""


    Sub Mainioso2()
        ' Datos de ejemplo para codificar y descodificar
        Dim originalData As String = "Hola, mundo!"
        Dim clave As String = "MiClaveSecreta"

        ' Codificación
        Dim encodedData As Byte() = EncodeAX25(originalData, clave)
        Console.WriteLine("Datos codificados: " & BitConverter.ToString(encodedData))

        ' Descodificación
        Dim decodedData As String = DecodeAX25(encodedData, clave)
        Console.WriteLine("Datos descodificados: " & decodedData)

        Console.ReadLine()
    End Sub

    Function EncodeAX25(data As String, key As String) As Byte()
        Dim encoding As Encoding = Encoding.ASCII
        Dim keyBytes As Byte() = encoding.GetBytes(key)
        Dim dataBytes As Byte() = encoding.GetBytes(data)

        ' Realiza alguna operación de codificación específica del protocolo AX.25
        ' Aquí puedes implementar tu lógica personalizada para codificar los datos

        ' Devuelve los datos codificados
        Return dataBytes
    End Function

    Function DecodeAX25(encodedData As Byte(), key As String) As String
        Dim encoding As Encoding = Encoding.ASCII
        Dim keyBytes As Byte() = encoding.GetBytes(key)

        ' Realiza alguna operación de descodificación específica del protocolo AX.25
        ' Aquí puedes implementar tu lógica personalizada para descodificar los datos

        ' Devuelve los datos descodificados
        Return encoding.GetString(encodedData)
    End Function


#End Region




#Region ""

    Private Const POLYNOMIAL As Integer = &H11D ' Polinomio generador CRC-CCITT

    Public Shared Function EncodeAX25Frame(ByVal sourceCallsign As String, ByVal destinationCallsign As String, ByVal control As Byte, ByVal pid As Byte, ByVal payload As Byte()) As Byte()
        Dim frame As New List(Of Byte)

        ' Codificar el campo de dirección
        frame.AddRange(EncodeCallsign(destinationCallsign))
        frame.AddRange(EncodeCallsign(sourceCallsign))

        ' Agregar el campo de control
        frame.Add(control)

        ' Agregar el campo PID
        frame.Add(pid)

        ' Agregar la carga útil
        frame.AddRange(payload)

        ' Calcular y agregar el FCS (Frame Check Sequence)
        Dim fcs As Integer = CalculateCRC(frame.ToArray(), frame.Count)
        frame.Add(CByte(fcs And &HFF))
        frame.Add(CByte((fcs >> 8) And &HFF))

        Return frame.ToArray()
    End Function

    Public Shared Function DecodeAX25Frame(ByVal frame As Byte()) As (String, String, Byte, Byte, Byte())
        Dim sourceCallsign As String = DecodeCallsign(frame, 0)
        Dim destinationCallsign As String = DecodeCallsign(frame, 7)
        Dim control As Byte = frame(14)
        Dim pid As Byte = frame(15)
        Dim payload As Byte() = New Byte(frame.Length - 17) {}
        Array.Copy(frame, 16, payload, 0, frame.Length - 17)
        Return (sourceCallsign, destinationCallsign, control, pid, payload)
    End Function

    Private Shared Function EncodeCallsign(ByVal callsign As String) As Byte()
        Dim bytes As New List(Of Byte)
        Dim ssid As Byte = 0

        For i As Integer = 0 To callsign.Length - 1
            Dim c As Char = callsign(i)
            If c = "-"c Then
                ssid = CByte(callsign.Substring(i + 1).Trim())
            Else
                bytes.Add(CByte(Asc(c) << 1))
            End If
        Next

        bytes(bytes.Count - 1) = CByte(bytes(bytes.Count - 1) Or (ssid And &HF))

        Return bytes.ToArray()
    End Function

    Private Shared Function DecodeCallsign(ByVal frame As Byte(), ByVal offset As Integer) As String
        Dim callsign As New StringBuilder()
        Dim ssid As Byte = 0

        For i As Integer = 0 To 6
            Dim b As Byte = frame(offset + i)
            If (b And &H1) = 0 Then
                callsign.Append(Chr(b >> 1))
            Else
                ssid = CByte(b >> 1)
                Exit For
            End If
        Next

        If ssid > 0 Then
            callsign.Append("-").Append(ssid.ToString())
        End If

        Return callsign.ToString()
    End Function

    Private Shared Function CalculateCRC(ByVal data As Byte(), ByVal length As Integer) As Integer
        Dim crc As Integer = &HFFFF
        For i As Integer = 0 To length - 1
            crc = (crc Xor (data(i) And &HFF)) And &HFFFF
            For j As Integer = 0 To 7
                If (crc And 1) = 1 Then
                    crc = ((crc >> 1) And &H7FFF) Xor POLYNOMIAL
                Else
                    crc = (crc >> 1) And &H7FFF
                End If
            Next
        Next
        Return crc
    End Function


#End Region




End Class
