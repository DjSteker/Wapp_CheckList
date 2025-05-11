

Imports System.Security.Cryptography.Xml
Imports System.Text

Namespace BaseDatos

    Public Class Class_ApiConfig

        Private Shared Archivo As String = My.Application.Info.DirectoryPath & "\BaseDatos\BaseDatos1.bin"

        Friend Shared Function EscrivirKeyApi(ByVal ApiKey As String) As Boolean
            Dim Ercrivio As Boolean = False
            Try
                Dim Codificador As Class_DesTriple = Class_DesTriple.Iniciar
                Dim Cifrado As String = Codificador.EncryptData(ApiKey)
                Dim fileContents() As Byte = Encoding.ASCII.GetBytes(Cifrado.ToCharArray) ' Encoding.Latin1.GetBytes(Cifrado.ToCharArray) '{244, 123, 56, 34}
                'Dim fileOuter(Len(fileContents.Length)) As Byte '= New Byte(Len(fileContents)) {}
                Dim fileOuter() As Byte = New Byte(fileContents.Length - 1) {}
                If fileContents.Length Mod 2 = 0 Then
                    Dim InciceOut As UInteger = 0
                    For i_for1 As UInteger = (fileContents.Length / 2) To fileContents.Length - 1
                        fileOuter(InciceOut) = fileContents(i_for1)
                        InciceOut += 1
                    Next i_for1
                    For i_for2 As UInteger = 0 To (fileContents.Length / 2) - 1
                        fileOuter(InciceOut) = fileContents(i_for2)
                        InciceOut += 1
                    Next i_for2
                Else


                    Dim InciceOut As UInteger = 0
                    For i_for1 As UInteger = Int(fileContents.Length / 2) To fileContents.Length - 1
                        fileOuter(InciceOut) = fileContents(i_for1)
                        InciceOut += 1
                    Next i_for1
                    Try
                        For i_for2 As UInteger = 0 To Int(fileContents.Length / 2) - 1
                            fileOuter(InciceOut) = fileContents(i_for2)
                            InciceOut += 1
                        Next i_for2
                    Catch ex As Exception
                    End Try



                End If



                My.Computer.FileSystem.WriteAllBytes(Archivo, fileOuter, False)
                Ercrivio = True
            Catch ex As Exception

            End Try
            Return Ercrivio
        End Function

        Friend Shared Function LeerKeyApi() As String
            Dim Lectura As String = String.Empty
            Try



                Dim fileContents As Byte()
                fileContents = My.Computer.FileSystem.ReadAllBytes(Archivo)
                Dim fileOuter() As Byte = New Byte(fileContents.Length - 1) {}

                If fileContents.Length Mod 2 = 0 Then
                    Dim InciceOut As UInteger = 0
                    For i_for1 As UInteger = (fileContents.Length / 2) To fileContents.Length - 1
                        fileOuter(InciceOut) = fileContents(i_for1)
                        InciceOut += 1
                    Next i_for1
                    For i_for2 As UInteger = 0 To (fileContents.Length / 2) - 1
                        fileOuter(InciceOut) = fileContents(i_for2)
                        InciceOut += 1
                    Next i_for2
                Else


                    Dim InciceOut As UInteger = 0
                    For i_for1 As UInteger = Int(fileContents.Length / 2) + 1 To fileContents.Length - 1
                        fileOuter(InciceOut) = fileContents(i_for1)
                        InciceOut += 1
                    Next i_for1
                    For i_for2 As UInteger = 0 To Int(fileContents.Length / 2)
                        fileOuter(InciceOut) = fileContents(i_for2)
                        InciceOut += 1
                    Next i_for2



                End If

                Dim Codificador As Class_DesTriple = Class_DesTriple.Iniciar
                Lectura = Codificador.DecryptData(Encoding.ASCII.GetString(fileOuter)) '(Encoding.Latin1.GetString(fileOuter))

                Dim aaa = 0
            Catch ex As Exception

            End Try
            Return Lectura
        End Function

    End Class

End Namespace