Imports System.IO

Public Class Class_CSV

    Sub Escrbe()
        ' Especifica la ruta del archivo CSV
        Dim rutaArchivo As String = "C:\Ruta\Al\Archivo.csv"

        ' Llama a la función para escribir registros en el archivo CSV
        EscribirRegistrosCSV(rutaArchivo)

        Console.WriteLine("Registros escritos exitosamente en el archivo CSV.")
        Console.ReadLine()
    End Sub

    Sub EscribirRegistrosCSV(rutaArchivo As String)
        ' Datos para escribir en el archivo CSV
        Dim registros As List(Of String()) = New List(Of String()) From {
            New String() {"Juan", "25", "Medellín"},
            New String() {"María", "30", "Bogotá"},
            New String() {"Carlos", "22", "Cali"}
        }

        ' Abrir el archivo CSV para escribir
        Using escritor As StreamWriter = New StreamWriter(rutaArchivo)
            ' Escribir encabezados
            escritor.WriteLine("Nombre,Edad,Ciudad")

            ' Escribir registros
            For Each registro As String() In registros
                escritor.WriteLine(String.Join(",", registro))
            Next
        End Using
    End Sub

    Sub Lee()
        ' Especifica la ruta del archivo CSV
        Dim rutaArchivo As String = "C:\Ruta\Al\Archivo.csv"

        ' Llama a la función para leer y mostrar el contenido del archivo CSV
        LeerArchivoCSV(rutaArchivo)

        Console.ReadLine()
    End Sub

    Sub LeerArchivoCSV(rutaArchivo As String)
        ' Verifica si el archivo existe antes de intentar leerlo
        If File.Exists(rutaArchivo) Then
            ' Lee todas las líneas del archivo CSV
            Dim lineas As String() = File.ReadAllLines(rutaArchivo)

            ' Verifica si hay al menos una línea (encabezados) en el archivo
            If lineas.Length > 0 Then
                ' Divide la primera línea en encabezados
                Dim encabezados As String() = lineas(0).Split(",")

                ' Muestra los encabezados
                Console.WriteLine("Encabezados:")
                For Each encabezado As String In encabezados
                    Console.Write(encabezado + " | ")
                Next
                Console.WriteLine()

                ' Muestra los registros
                Console.WriteLine("Registros:")
                For i As Integer = 1 To lineas.Length - 1
                    Dim campos As String() = lineas(i).Split(",")
                    For Each campo As String In campos
                        Console.Write(campo + " | ")
                    Next
                    Console.WriteLine()
                Next
            Else
                Console.WriteLine("El archivo CSV está vacío.")
            End If
        Else
            Console.WriteLine("El archivo CSV no existe en la ruta especificada.")
        End If
    End Sub


End Class
