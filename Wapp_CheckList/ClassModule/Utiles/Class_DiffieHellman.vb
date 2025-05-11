Imports System.Security.Cryptography

Imports System.Net.Sockets

Imports System.Threading.Tasks

Imports System.Numerics
Imports System.Text

Imports System.Net

Public Class Class_DiffieHellman


    Public Shared Sub Main0()
        Using alice As New System.Security.Cryptography.ECDiffieHellmanCng()
            alice.KeyDerivationFunction = System.Security.Cryptography.ECDiffieHellmanKeyDerivationFunction.Hash
            alice.HashAlgorithm = System.Security.Cryptography.CngAlgorithm.Sha256
            Dim alicePublicKey = alice.PublicKey.ToByteArray()

            Using bob As New System.Security.Cryptography.ECDiffieHellmanCng()
                bob.KeyDerivationFunction = System.Security.Cryptography.ECDiffieHellmanKeyDerivationFunction.Hash
                bob.HashAlgorithm = System.Security.Cryptography.CngAlgorithm.Sha256
                Dim bobPublicKey = bob.PublicKey.ToByteArray()

                Dim aliceKey = alice.DeriveKeyMaterial(System.Security.Cryptography.CngKey.Import(bobPublicKey, System.Security.Cryptography.CngKeyBlobFormat.EccPublicBlob))
                Dim bobKey = bob.DeriveKeyMaterial(System.Security.Cryptography.CngKey.Import(alicePublicKey, System.Security.Cryptography.CngKeyBlobFormat.EccPublicBlob))

                ' Ahora aliceKey y bobKey son iguales y pueden usarse para cifrar y descifrar mensajes
                Console.WriteLine("Clave compartida: " & Convert.ToBase64String(aliceKey))
            End Using
        End Using
    End Sub

    Sub Main_Primo()
        Dim limite As Integer
        Console.WriteLine("Introduce el límite superior para encontrar números primos:")
        limite = Convert.ToInt32(Console.ReadLine())

        For num As Integer = 2 To limite
            If EsPrimo(num) Then
                Console.WriteLine(num & " es un número primo.")
            End If
        Next

        Console.ReadLine()
    End Sub

    Function EsPrimo(ByVal numero As Integer) As Boolean
        If numero < 2 Then
            Return False
        End If

        For i As Integer = 2 To Math.Sqrt(numero)
            If numero Mod i = 0 Then
                Return False
            End If
        Next

        Return True
    End Function
End Class



Public Class EncryptedSocketClient
    Private client As TcpClient
    Private aes As AesCryptoServiceProvider

    Public Sub New()
        client = New TcpClient()
        aes = New AesCryptoServiceProvider()
        aes.Key = Encoding.UTF8.GetBytes("your-encryption-key")
        aes.IV = Encoding.UTF8.GetBytes("your-iv")
    End Sub

    Public Async Function ConnectAsync(ip As String, port As Integer) As Task
        Await client.ConnectAsync(ip, port)
    End Function

    Public Async Function SendMessageAsync(message As String) As Task
        Dim stream = client.GetStream()
        Dim encryptedMessage = Encrypt(message)
        Await stream.WriteAsync(encryptedMessage, 0, encryptedMessage.Length)
    End Function

    Private Function Encrypt(plainText As String) As Byte()
        Dim encryptor = aes.CreateEncryptor()
        Dim plainBytes = Encoding.UTF8.GetBytes(plainText)
        Return encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length)
    End Function
End Class


'Public Class DiffieHellmanServer
'    Private listener As TcpListener
'    Private p As BigInteger = 23 ' Número primo
'    Private g As BigInteger = 5  ' Generador
'    Private privateKey As BigInteger
'    Private publicKey As BigInteger

'    Public Sub New(port As Integer)
'        listener = New TcpListener(IPAddress.Any, port)
'        privateKey = GeneratePrivateKey()
'        publicKey = BigInteger.ModPow(g, privateKey, p)
'    End Sub

'    Public Sub Start()
'        listener.Start()
'        Console.WriteLine("Servidor iniciado...")
'        While True
'            Dim client = listener.AcceptTcpClient()
'            Dim stream = client.GetStream()

'            ' Enviar clave pública del servidor
'            Dim publicKeyBytes = publicKey.ToByteArray()
'            stream.Write(publicKeyBytes, 0, publicKeyBytes.Length)

'            ' Recibir clave pública del cliente
'            Dim clientPublicKeyBytes(255) As Byte
'            stream.Read(clientPublicKeyBytes, 0, clientPublicKeyBytes.Length)
'            Dim clientPublicKey = New BigInteger(clientPublicKeyBytes)

'            ' Generar clave compartida
'            Dim sharedKey = BigInteger.ModPow(clientPublicKey, privateKey, p)
'            Console.WriteLine("Clave compartida: " & sharedKey.ToString())

'            ' Aquí puedes agregar la lógica para manejar la comunicación encriptada
'        End While
'    End Sub

'    Private Function GeneratePrivateKey() As BigInteger
'        Dim rng As New Random()
'        Return New BigInteger(rng.Next(1, 100))
'    End Function
'End Class


'Public Class DiffieHellmanClient
'    Private client As TcpClient
'    Private p As BigInteger = 23 ' Número primo
'    Private g As BigInteger = 5  ' Generador
'    Private privateKey As BigInteger
'    Private publicKey As BigInteger

'    Public Sub New(ip As String, port As Integer)
'        client = New TcpClient(ip, port)
'        privateKey = GeneratePrivateKey()
'        publicKey = BigInteger.ModPow(g, privateKey, p)
'    End Sub

'    Public Sub Connect()
'        Dim stream = client.GetStream()

'        ' Recibir clave pública del servidor
'        Dim serverPublicKeyBytes(255) As Byte
'        stream.Read(serverPublicKeyBytes, 0, serverPublicKeyBytes.Length)
'        Dim serverPublicKey = New BigInteger(serverPublicKeyBytes)

'        ' Enviar clave pública del cliente
'        Dim publicKeyBytes = publicKey.ToByteArray()
'        stream.Write(publicKeyBytes, 0, publicKeyBytes.Length)

'        ' Generar clave compartida
'        Dim sharedKey = BigInteger.ModPow(serverPublicKey, privateKey, p)
'        Console.WriteLine("Clave compartida: " & sharedKey.ToString())

'        ' Aquí puedes agregar la lógica para manejar la comunicación encriptada
'    End Sub

'    Private Function GeneratePrivateKey() As BigInteger
'        Dim rng As New Random()
'        Return New BigInteger(rng.Next(1, 100))
'    End Function
'End Class





Public Class DiffieHellmanServer
    Private listener As TcpListener
    Private primo As Integer = 23 ' Número primo
    Private g As Integer = 5  ' Generador
    Private privateKey As Integer
    Private publicKey As Integer

    'Public Sub New(port As Integer)
    '    listener = New TcpListener(IPAddress.Any, port)
    '    privateKey = GeneratePrivateKey()
    '    publicKey = Math.Pow(g, privateKey, primo)
    'End Sub

    'Public Sub Start()
    '    listener.Start()
    '    Console.WriteLine("Servidor iniciado...")
    '    While True
    '        Dim client = listener.AcceptTcpClient()
    '        Dim stream = client.GetStream()

    '        ' Enviar clave pública del servidor
    '        Dim publicKey1 As Integer = publicKey
    '        Dim publicKeyBytes = publicKey1.ToByteArray()
    '        stream.Write(publicKeyBytes, 0, publicKeyBytes.Length)

    '        ' Recibir clave pública del cliente
    '        Dim clientPublicKeyBytes(255) As Byte
    '        stream.Read(clientPublicKeyBytes, 0, clientPublicKeyBytes.Length)
    '        Dim clientPublicKey = New Integer(clientPublicKeyBytes)

    '        ' Generar clave compartida
    '        Dim sharedKey As Integer = Math.Pow(clientPublicKey, privateKey, primo)
    '        Console.WriteLine("Clave compartida: " & sharedKey.ToString())

    '        ' Aquí puedes agregar la lógica para manejar la comunicación encriptada
    '    End While
    'End Sub

    Private Function GeneratePrivateKey() As Integer
        Dim rng As New Random()
        Return New Integer = (rng.Next(1, 100))
    End Function

End Class


Public Class DiffieHellmanClient
    Private client As TcpClient
    Private primo As Integer = 23 ' Número primo
    Private g As Integer = 5  ' Generador
    Private privateKey As Integer
    Private publicKey As Integer

    'Public Sub New(ip As String, port As Integer)
    '    client = New TcpClient(ip, port)
    '    privateKey = GeneratePrivateKey()
    '    publicKey = Math.Pow(g, privateKey, primo)
    'End Sub

    'Public Sub Connect()
    '    Dim stream = client.GetStream()

    '    ' Recibir clave pública del servidor
    '    Dim serverPublicKeyBytes(255) As Byte
    '    stream.Read(serverPublicKeyBytes, 0, serverPublicKeyBytes.Length)
    '    Dim serverPublicKey() As Integer = (serverPublicKeyBytes)

    '    ' Enviar clave pública del cliente
    '    Dim publicKeyBytes = publicKey.ToByteArray()
    '    stream.Write(publicKeyBytes, 0, publicKeyBytes.Length)

    '    ' Generar clave compartida
    '    Dim sharedKey As Integer = Math.Pow(Math.Pow(serverPublicKey, privateKey), primo)
    '    Console.WriteLine("Clave compartida: " & sharedKey.ToString())

    '    ' Aquí puedes agregar la lógica para manejar la comunicación encriptada
    'End Sub

    'Private Function GeneratePrivateKey() As Integer
    '    Dim rng As New Random()
    '    Return New Integer = (rng.Next(1, 100))
    'End Function

End Class
