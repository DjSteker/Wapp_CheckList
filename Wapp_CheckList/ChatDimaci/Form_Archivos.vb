Imports Microsoft.VisualBasic.FileIO
Public Class Form_Archivos
    Dim myStream As System.IO.StreamReader = Nothing
    Dim fileContents As String
    Private Sub Form_Archivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            'Dim myStream As System.IO.Stream = Nothing
            Dim openFileDialog1 As New OpenFileDialog()

            'openFileDialog1.InitialDirectory = "c:\"
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            openFileDialog1.FilterIndex = 2
            openFileDialog1.RestoreDirectory = True

            If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Try
                    myStream = New System.IO.StreamReader(openFileDialog1.FileName)
                    'fileContents = My.Computer.FileSystem.ReadAllText(openFileDialog1.FileName)
                    If (myStream IsNot Nothing) Then
                        TextBox1.Text = openFileDialog1.FileName
                    Else
                        MsgBox("archivo vacio", MsgBoxStyle.Information)
                    End If
                Catch Ex As Exception
                    MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
                Finally
                    ' Check this again, since we need to make sure we didn't throw an exception on open.
                    'If (myStream IsNot Nothing) Then
                    '    myStream.Close()
                    'End If
                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            'For index = 1 To TextBox2.Text.Length - myStream.Length + 1
            '    Dim Caracteres As String = Mid(myStream., index, TextBox2.Text.Length).ToLower
            '    If ByVal_Nombre.ToString.Trim.ToLower = Caracteres Then
            '        'If ByVal_Nombre.ToString.Trim.ToLower = Nombre_Compara Then

            '        Exit For
            '        'End If
            '    End If
            'Next


            Dim line As String
            ' Read and display the lines from the file until the end 
            ' of the file is reached.
            Do
                line = myStream.ReadLine()

                For index = 1 To TextBox2.Text.Length - line.Length + 1
                    Dim Caracteres As String = Mid(line, index, TextBox2.Text.Length).ToLower
                    If TextBox2.Text.ToString = Caracteres Then
                        'If ByVal_Nombre.ToString.Trim.ToLower = Nombre_Compara Then

                        Exit For
                        'End If
                    End If
                Next


                Console.WriteLine(line)
            Loop Until line Is Nothing
            myStream.Close()




            'For index = 1 To TextBox2.Text.Length - fileContents.Length + 1
            '    Dim Caracteres As String = Mid(fileContents, index, TextBox2.Text.Length).ToLower
            '    If TextBox2.Text.ToString.Trim = Caracteres Then
            '        'If ByVal_Nombre.ToString.Trim.ToLower = Nombre_Compara Then

            '        Exit For
            '        'End If
            '    End If
            'Next
        Catch ex As Exception

        End Try
    End Sub
End Class