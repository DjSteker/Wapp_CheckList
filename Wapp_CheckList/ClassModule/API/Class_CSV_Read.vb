Imports System.IO
Imports Wapp_CheckList.Class_ArchivoTrading


Public Class Class_CSV_Read
    Friend Function Read_list(ByVal Archivo As String) As List(Of Archivo_Trading)
        Dim Registros As New List(Of Archivo_Trading)
        Dim strfilename As String = My.Application.Info.DirectoryPath & "\Datos\" & Archivo '"\Datos\BTC-EUR_2019To2021_EUR.csv"


        'Check if file exist
        If File.Exists(strfilename) Then
            Dim tmpstream As StreamReader = File.OpenText(strfilename)

            'Dim TextoCSV As String = tmpstream.Read()
            'Dim TextoCSV As String = tmpstream.Read()

            Dim encabezado As String = tmpstream.ReadLine
            Dim strline() As String
            Dim Texto As String = tmpstream.ReadToEnd
            tmpstream.Close()


            Dim encabezadoSplit() As String = encabezado.Split(",")

            If encabezadoSplit.Length = 7 Then
                For Each Linea As String In Texto.Split(vbLf)
                    strline = Linea.Split(",")
                    Dim Rejistro As New Archivo_Trading
                    Try
                        Rejistro.Fecha = strline(0)
                        Rejistro.Open = Replace(strline(1), ".", ",")
                        Rejistro.High = Replace(strline(2), ".", ",")
                        Rejistro.Low = Replace(strline(3), ".", ",")
                        Rejistro.Close = Replace(strline(4), ".", ",")
                        Rejistro.AdjClose = Replace(strline(5), ".", ",")
                        Rejistro.Volume = Replace(strline(6), ".", ",")
                        Registros.Add(Rejistro)
                    Catch ex As Exception

                    End Try

                Next
            ElseIf encabezadoSplit.Length = 7 Then
                For Each Linea As String In Texto.Split(vbLf)
                    strline = Linea.Split(",")
                    Dim Rejistro As New Archivo_Trading
                    Try
                        Rejistro.Fecha = strline(0)
                        Rejistro.Open = Replace(strline(1), ".", ",")
                        Rejistro.High = Replace(strline(2), ".", ",")
                        Rejistro.Low = Replace(strline(3), ".", ",")
                        Rejistro.Close = Replace(strline(4), ".", ",")
                        'Rejistro.AdjClose = Replace(strline(5), ".", ",")
                        Rejistro.Volume = Replace(strline(5), ".", ",")
                        Registros.Add(Rejistro)
                    Catch ex As Exception

                    End Try

                Next
            Else

            End If






        End If
        Return Registros
    End Function

    Friend Function ConvertToClass(ByVal ByVal_Texto As String) As List(Of Archivo_Trading)
        Dim Registros As New List(Of Archivo_Trading)
        'Dim strfilename As String = My.Application.Info.DirectoryPath & "\Datos\" & Archivo '"\Datos\BTC-EUR_2019To2021_EUR.csv"


        'Dim tmpstream As New StreamReader(ByVal_Texto)
        Dim Lineas() As String = ByVal_Texto.Split(vbCrLf)

        'Dim TextoCSV As String = tmpstream.Read()
        'Dim TextoCSV As String = tmpstream.Read()

        Dim encabezado As String = Lineas(0) 'tmpstream.ReadLine
        Dim LineasTabla = Lineas.Skip(1)
        Dim strline() As String
        'Dim Texto As String = tmpstream.ReadToEnd
        'tmpstream.Close()

        For Each Linea As String In LineasTabla
            strline = Linea.Split(",")
            Dim Rejistro As New Archivo_Trading
            Try
                Rejistro.Fecha = Replace(CStr(strline(0)), vbLf, "")
                Rejistro.Open = Replace(strline(1), ".", ",")
                Rejistro.High = Replace(strline(2), ".", ",")
                Rejistro.Low = Replace(strline(3), ".", ",")
                Rejistro.Close = Replace(strline(4), ".", ",")
                'Rejistro.AdjClose = Replace(strline(5), ".", ",")
                Rejistro.Volume = Replace(strline(5), ".", ",")
                Registros.Add(Rejistro)
            Catch ex As Exception

            End Try

        Next




        Return Registros
    End Function


    Friend Sub ReadCSVFileToArray1()
        Dim strfilename As String
        Dim num_rows As Long
        Dim num_cols As Long
        Dim indiceRows As Integer
        Dim indiceCols As Integer
        Dim strarray(1, 1) As String

        ' Load the file.
        strfilename = My.Application.Info.DirectoryPath & "\Datos\BTC-EUR_2019To2021_EUR.csv"

        'Check if file exist
        If File.Exists(strfilename) Then
            Dim tmpstream As StreamReader = File.OpenText(strfilename)
            Dim strlines() As String
            Dim strline() As String

            'Load content of file to strLines array
            strlines = tmpstream.ReadToEnd().Split(Environment.NewLine)

            ' Redimension the array.
            num_rows = UBound(strlines)
            strline = strlines(0).Split(",")
            num_cols = UBound(strline)
            ReDim strarray(num_rows, num_cols)

            ' Copy the data into the array.
            For indiceRows = 0 To num_rows
                strline = strlines(indiceRows).Split(",")
                For indiceCols = 0 To num_cols
                    strarray(indiceRows, indiceCols) = strline(indiceCols)
                Next
            Next

            ' Display the data in textbox
            For indiceRows = 0 To num_rows

                For indiceCols = 0 To num_cols
                    'TextBox1.Text = TextBox1.Text & strarray(x, y) & ","

                Next
                'TextBox1.Text = TextBox1.Text & Environment.NewLine
            Next

        End If

    End Sub


    Friend Function ReadCSVFileToArray2() As List(Of Archivo_Trading)
        Dim Registros As New List(Of Archivo_Trading)
        Dim strfilename As String
        Dim num_rows As Long
        Dim num_cols As Long
        Dim indiceRows As Integer
        Dim indiceCols As Integer
        Dim strarray(1, 1) As String

        ' Load the file.
        strfilename = My.Application.Info.DirectoryPath & "\Datos\BTC-EUR_2019To2021_EUR.csv"

        'Check if file exist
        If File.Exists(strfilename) Then
            Dim tmpstream As StreamReader = File.OpenText(strfilename)
            Dim strlines() As String
            Dim strline() As String
            Dim CadenaTexto As String = tmpstream.ReadLine
            Dim CadenaTexto2 As String = tmpstream.ReadLine
            'Load content of file to strLines array
            strlines = tmpstream.ReadToEnd().Split(Environment.NewLine)
            If strlines.Count < 1 Then
                'strlines = tmpstream.ReadToEnd().Split(vbLf)
                strlines = tmpstream.ReadToEnd().Split(vbLf)
            End If
            ' Redimension the array.
            num_rows = UBound(strlines)
            strline = strlines(0).Split(",")
            num_cols = UBound(strline)
            ReDim strarray(num_rows, num_cols)

            ' Copy the data into the array.
            For indiceRows = 0 To num_rows
                strline = strlines(indiceRows).Split(",")
                For indiceCols = 0 To num_cols
                    strarray(indiceRows, indiceCols) = strline(indiceCols)
                Next
            Next

            ' Display the data in textbox
            For indiceRows = 0 To num_rows
                Dim Rejistro As New Archivo_Trading
                For indiceCols = 0 To num_cols
                    'TextBox1.Text = TextBox1.Text & strarray(x, y) & ","
                    Rejistro.Fecha = strarray(indiceRows, 0)
                    Rejistro.Open = strarray(indiceRows, 1)
                    Rejistro.High = strarray(indiceRows, 2)
                    Rejistro.Low = strarray(indiceRows, 3)
                    Rejistro.Close = strarray(indiceRows, 4)
                    Rejistro.AdjClose = strarray(indiceRows, 5)
                    Rejistro.Volume = strarray(indiceRows, 6)
                Next
                'TextBox1.Text = TextBox1.Text & Environment.NewLine
            Next

        End If
        Return Registros
    End Function



    'Friend Structure Archivo_Trading
    '    'Open,High,Low,Close,Adj Close,Volume
    '    Dim Fecha As String
    '    Dim Open As Double
    '    Dim High As Double
    '    Dim Low As Double
    '    Dim Close As Double
    '    Dim AdjClose As Double
    '    Dim Volume As Double
    'End Structure

End Class
