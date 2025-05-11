Public Class Class_GQRXRemote

    Delegate Sub DelegateMensaje(ByVal TextBoxSelect As TextBox, ByVal MSG As String)

    Friend TextBoxSalida As TextBox

    Dim TamañoBufferSalida As UInt32 = 1024

    Private Sub TexBox_msg(ByVal TextBoxSelect As TextBox, ByVal Mensaje As String)
        If TextBoxSelect.InvokeRequired Then
            Dim d As New DelegateMensaje(AddressOf TexBox_msg)

            Call TextBoxSelect.Invoke(d, New Object() {Mensaje})
        Else
            'TextBoxSelect.Text &= Environment.NewLine & " " & Mensaje
            TextBoxSelect.SelectionStart = TextBoxSelect.Text.Length
            TextBoxSelect.ScrollToCaret()

        End If
    End Sub



    ' Definir el puerto y la dirección IP de GQRX
    Friend PORT As Integer = 7356
    Friend IP As String = "127.0.0.1"

    ' Crear un objeto socket para la comunicación
    Private socket As System.Net.Sockets.Socket

    ' Crear un constructor que se conecte a GQRX
    Public Sub New()

    End Sub

    ' Crear un constructor que se conecte a GQRX
    Public Sub Conection()
        ' Inicializar el socket con los parámetros adecuados
        socket = New System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp)
        ' Conectarse a GQRX usando la dirección IP y el puerto
        socket.Connect(System.Net.IPAddress.Parse(IP), PORT)
        ' Comprobar si la conexión fue exitosa
        If socket.Connected Then
            TexBox_msg(TextBoxSalida, "Conectado a GQRX" & vbCrLf)
            Console.WriteLine("Conectado a GQRX")
        Else
            TexBox_msg(TextBoxSalida, "No se pudo conectar a GQRX" & vbCrLf)
            Console.WriteLine("No se pudo conectar a GQRX")
        End If
    End Sub




    ' Crear un método que envíe un comando a GQRX
    Public Sub SendCommand(command As String)
        ' Convertir el comando a un array de bytes
        Dim bytes As Byte() = System.Text.Encoding.ASCII.GetBytes(command & vbLf)
        ' Enviar el comando al socket
        Dim bytesArray(TamañoBufferSalida - 1) As Byte
        If bytesArray.Length < bytes.Length Then
            ReDim bytesArray(bytes.Length - 1)
        End If

        For indice As UInteger = 0 To bytes.Length - 1
            bytesArray(indice) = bytes(indice)
        Next
        If socket.Connected Then
            socket.Send(bytesArray)

        End If



    End Sub

    Friend Sub RecibirDatos()
        ' Recibir la respuesta del socket
        Dim buffer As Byte() = New Byte(TamañoBufferSalida - 1) {}
        Dim received As Integer = socket.Receive(buffer)
        ' Convertir la respuesta a una cadena
        Dim response As String = System.Text.Encoding.ASCII.GetString(buffer, 0, received)
        ' TextBox_Recive.
        ' Mostrar la respuesta en la consola
        TexBox_msg(TextBoxSalida, response & vbCrLf)
        Console.WriteLine(response)
    End Sub


    ' Crear un método que cambie la frecuencia de GQRX
    Public Sub SetFrequency(frequency As Double)
        ' Crear el comando con el formato adecuado
        Dim command As String = "F " & frequency.ToString("0.000000")
        ' Enviar el comando a GQRX
        SendCommand(command)
    End Sub

    ' Crear un método que cierre la conexión con GQRX
    Public Sub Close()
        ' Enviar el comando de cierre a GQRX
        SendCommand("c")
        ' Cerrar el socket
        socket.Close()
    End Sub



End Class


'Try
'Dim MIFILESTREAM As System.IO.FileStream = New FileStream(FileNameAudio, FileMode.Open, FileAccess.Read)
'Dim LECTOR As System.IO.BinaryReader = New BinaryReader(MIFILESTREAM)
'Dim NOMBRE As String = FileNameAudio
'NOMBRE = NOMBRE.Remove(0, NOMBRE.LastIndexOf("\") + 1)
'TextBox_Recive.Text += "NOMBRE: " & NOMBRE & vbLf & vbCrLf
'Dim CHUNKID As Byte() = LECTOR.ReadBytes(4)
'Dim STRCHUNKID As String = System.Text.Encoding.ASCII.GetString(CHUNKID)
'Dim CHUNKSIZE As Int32 = LECTOR.ReadInt32() + 8
'Dim FORMAT As Byte() = LECTOR.ReadBytes(4)
'Dim STRFORMAT As String = System.Text.Encoding.ASCII.GetString(FORMAT)
'Dim SUBCHUNK1ID As Byte() = LECTOR.ReadBytes(4)
'Dim STRSUBCHUNK1ID As String = System.Text.Encoding.ASCII.GetString(SUBCHUNK1ID)
'Dim SUBCHUNK1SIZE As Int32 = LECTOR.ReadInt32()
'Dim AUDIOFORMAT As Int16 = LECTOR.ReadInt16()
'Dim NUMCHANNELS As Int16 = LECTOR.ReadInt16()
'Dim SAMPLERATE As Int32 = LECTOR.ReadInt32()
'Dim BYTERATE As Int32 = LECTOR.ReadInt32()
'Dim BLOCKALIGN As Int16 = LECTOR.ReadInt16()
'Dim BITPERSAMPLE As Int16 = LECTOR.ReadInt16()
'Dim SUBCHUNK2ID As Byte() = LECTOR.ReadBytes(4)
'Dim STRSUBCHUNK2ID As String = System.Text.Encoding.ASCII.GetString(SUBCHUNK2ID)
'Dim SUBCHUNK2SIZE As Int32 = LECTOR.ReadInt32()
'MIARRAY = New ArrayList ' ARRAY DE DATOS ORIGINALES
'Dim ORDENAR As New ArrayList 'SOLO PARA ORDENAR Y OBTENER EL VALOR MAS ALTO
'For I = 0 To (SUBCHUNK2SIZE - 1) / 2 'MUESTRAS PARA CADA CANAL(DERECHO E IZQUIERDO)
'MIARRAY.Add(LECTOR.ReadInt16) 'DATOS EN INT16
'ORDENAR.Add(MIARRAY(I))
'Next
'ORDENAR.Sort()
'MAXIMO = ORDENAR(ORDENAR.Count - 1) 'OBTENER EL VALOR MAS ALTO
'PINTA()
'If STRSUBCHUNK2ID <> "data" Then ' EN UN FORMATO APROPIADO ESTE CAMPO DEBE DECIR = data
'TextBox_Recive.Text += vbCrLf & vbCrLf & "FORMATO INCORRECTO" & vbCrLf
'TextBox_Recive.BackColor = Color.Red
'End If
'Catch ex As Exception
'MsgBox(ex.Message)
'End Try



'Dim MIFILESTREAM As System.IO.FileStream = New FileStream(FileNameAudio, FileMode.Open, FileAccess.Read)
'Dim LECTOR As System.IO.BinaryReader = New BinaryReader(MIFILESTREAM)
'Dim NOMBRE As String = FileNameAudio
'Dim CHUNKID As Byte() = LECTOR.ReadBytes(4)
'Dim STRCHUNKID As String = System.Text.Encoding.ASCII.GetString(CHUNKID)
'Dim CHUNKSIZE As Int32 = LECTOR.ReadInt32() + 8
'Dim FORMAT As Byte() = LECTOR.ReadBytes(4)
'Dim STRFORMAT As String = System.Text.Encoding.ASCII.GetString(FORMAT)
'Dim SUBCHUNK1ID As Byte() = LECTOR.ReadBytes(4)
'Dim STRSUBCHUNK1ID As String = System.Text.Encoding.ASCII.GetString(SUBCHUNK1ID)
'Dim SUBCHUNK1SIZE As Int32 = LECTOR.ReadInt32()
'Dim AUDIOFORMAT As Int16 = LECTOR.ReadInt16()
'Dim NUMCHANNELS As Int16 = LECTOR.ReadInt16()
'Dim SAMPLERATE As Int32 = LECTOR.ReadInt32()
'Dim BYTERATE As Int32 = LECTOR.ReadInt32()
'Dim BLOCKALIGN As Int16 = LECTOR.ReadInt16()
'Dim BITPERSAMPLE As Int16 = LECTOR.ReadInt16()
'Dim SUBCHUNK2ID As Byte() = LECTOR.ReadBytes(4)
'Dim STRSUBCHUNK2ID As String = System.Text.Encoding.ASCII.GetString(SUBCHUNK2ID)
'Dim SUBCHUNK2SIZE As Int32 = LECTOR.ReadInt32()

