Public Class Class_JSON_0
    Sub Main()
        Dim jsonString As String = "{""name"": ""John Doe"", ""age"": 30, ""city"": ""New York"", ""isStudent"": false, ""grades"": [95, 87, 92]}"
        Dim parsedJson As Object = ParseJson(jsonString)

        ' Puedes imprimir el resultado para verificar
        Console.WriteLine(parsedJson.ToString())
    End Sub

    Public Class Class_JsonEstructura0
        Private m_StringValue As String = String.Empty
        Public Property StringValue() As String
            Get
                Return m_StringValue
            End Get
            Set(ByVal value As String)
                m_StringValue = value
                GetNodes(m_StringValue)
            End Set
        End Property

        Public Property Header As String = String.Empty

        Friend Property BracesOrBrackets As String = String.Empty  ' array=Brackets, Braces=objeto
        Friend Property ContainsHijos As Boolean = False

        Public Property BracketsList As New List(Of Class_JsonEstructura0)
        Public Property BracesList As New List(Of Class_JsonEstructura0)


        Private Sub GetNodes(ByRef Input As String)

            Dim bracesCount As Integer = 0
            Dim bracketsCount As Integer = 0
            Dim bracesStartIndex As Integer = -1
            Dim bracketsStartIndex As Integer = -1
            Dim lastColonIndex As Integer = -1

            For i As Integer = 0 To Input.Length - 1

                If bracketsCount > 1 Or bracesCount > 1 Then
                    ContainsHijos = True
                End If

                If Input(i) = "{" Then
                    bracesCount += 1
                    If bracesStartIndex = -1 Then
                        bracesStartIndex = i
                        If lastColonIndex <> -1 Then
                            Header = Input.Substring(lastColonIndex + 1, bracesStartIndex - lastColonIndex - 1).Trim()
                        End If
                    End If
                ElseIf Input(i) = "[" Then
                    bracketsCount += 1
                    If bracketsStartIndex = -1 Then
                        bracketsStartIndex = i
                        If lastColonIndex <> -1 Then
                            Header = Input.Substring(lastColonIndex + 1, bracketsStartIndex - lastColonIndex - 1).Trim()
                        End If
                    End If
                ElseIf Input(i) = "}" Then
                    bracesCount -= 1
                    If bracesCount = 0 Then
                        Dim node As New Class_JsonEstructura0()
                        node.StringValue = Input.Substring(bracesStartIndex + 1, i - bracesStartIndex - 1)
                        node.BracesOrBrackets = "Braces"
                        BracesList.Add(node)
                        bracesStartIndex = -1
                    End If
                ElseIf Input(i) = "]" Then
                    bracketsCount -= 1
                    If bracketsCount = 0 Then
                        Dim node As New Class_JsonEstructura0()
                        node.StringValue = Input.Substring(bracketsStartIndex + 1, i - bracketsStartIndex - 1)
                        node.BracesOrBrackets = "Brackets"
                        BracketsList.Add(node)
                        bracketsStartIndex = -1
                    End If
                ElseIf Input(i) = ":" Then
                    'lastColonIndex = i
                End If

            Next

        End Sub

    End Class

    Public Class Class_JsonOjetoV0
        Private m_StringValue As String = String.Empty
        Public Property StringValue() As String
            Get
                Return m_StringValue
            End Get
            Set(ByVal value As String)
                m_StringValue = value
                GetNodes(m_StringValue)
            End Set
        End Property

        Public Property Header As String = String.Empty
        Public Property BracketsValue As String = String.Empty
        Public Property BracesValue As String = String.Empty

        Public Property BracketsList As New List(Of Class_JsonOjetoV0)
        Public Property BracesList As New List(Of Class_JsonOjetoV0)

        Friend Property BracesOrBrackets As String = String.Empty  ' array=Brackets, Braces=objeto
        Friend Property ContainsObjectValue As Boolean = False



        Private Sub GetNodes(ByRef Input As String)
            Dim bracesCount As Integer = 0
            Dim bracketsCount As Integer = 0
            Dim bracesStartIndex As Integer = -1
            Dim bracketsStartIndex As Integer = -1
            Dim lastColonIndex As Integer = -1
            For i As Integer = 0 To Input.Length - 1


                If Input(i) = "{" Then
                    bracesCount += 1
                    If bracesStartIndex = -1 Then
                        bracesStartIndex = i
                        If lastColonIndex <> -1 Then
                            Header = Input.Substring(lastColonIndex + 1, bracesStartIndex - lastColonIndex - 1).Trim()
                        End If
                    End If
                ElseIf Input(i) = "[" Then
                    bracketsCount += 1
                    If bracketsStartIndex = -1 Then
                        bracketsStartIndex = i
                        If lastColonIndex <> -1 Then
                            Header = Input.Substring(lastColonIndex + 1, bracketsStartIndex - lastColonIndex - 1).Trim()
                        End If
                    End If
                ElseIf Input(i) = "}" Then
                    bracesCount -= 1
                    If bracesCount = 0 Then
                        Dim node As New Class_JsonOjetoV0()
                        node.StringValue = Input.Substring(bracesStartIndex + 1, i - bracesStartIndex - 1)
                        node.BracesOrBrackets = "Braces"
                        'node.ContainsHijos = True
                        BracesList.Add(node)
                        bracesStartIndex = -1
                    End If
                ElseIf Input(i) = "]" Then
                    bracketsCount -= 1
                    If bracketsCount = 0 Then
                        Dim node As New Class_JsonOjetoV0()
                        node.StringValue = Input.Substring(bracketsStartIndex + 1, i - bracketsStartIndex - 1)
                        node.BracesOrBrackets = "Brackets"
                        'node.ContainsHijos = True
                        BracketsList.Add(node)
                        bracketsStartIndex = -1
                    End If
                ElseIf Input(i) = ":" Then
                    lastColonIndex = i
                End If
            Next
        End Sub


        Private Sub GetNodes1(ByRef Input As String)
            Dim bracesCount As Integer = 0
            Dim bracketsCount As Integer = 0
            Dim bracesStartIndex As Integer = -1
            Dim bracketsStartIndex As Integer = -1
            Dim lastColonIndex As Integer = -1
            For i As Integer = 0 To Input.Length - 1
                If Input(i) = "{" Then
                    bracesCount += 1
                    If bracesStartIndex = -1 Then
                        bracesStartIndex = i
                        If lastColonIndex <> -1 Then
                            Header = Input.Substring(lastColonIndex + 1, bracesStartIndex - lastColonIndex - 1).Trim()
                        End If
                    End If
                ElseIf Input(i) = "[" Then
                    bracketsCount += 1
                    If bracketsStartIndex = -1 Then
                        bracketsStartIndex = i
                        If lastColonIndex <> -1 Then
                            Header = Input.Substring(lastColonIndex + 1, bracketsStartIndex - lastColonIndex - 1).Trim()
                        End If
                    End If
                ElseIf Input(i) = "}" Then
                    bracesCount -= 1
                    If bracesCount = 0 Then
                        Dim node As New Class_JsonOjetoV0()
                        'node.BracesValue = Input.Substring(bracesStartIndex + 1, i - bracesStartIndex - 1)
                        node.StringValue = Input.Substring(bracesStartIndex + 1, i - bracesStartIndex - 1)
                        node.BracesOrBrackets = "Braces"
                        node.ContainsObjectValue = True
                        BracketsList.Add(node)
                        bracesStartIndex = -1
                    End If
                ElseIf Input(i) = "]" Then
                    bracketsCount -= 1
                    If bracketsCount = 0 Then
                        Dim node As New Class_JsonOjetoV0()
                        'node.BracketsValue = Input.Substring(bracketsStartIndex + 1, i - bracketsStartIndex - 1)
                        node.StringValue = Input.Substring(bracesStartIndex + 1, i - bracesStartIndex - 1)
                        node.BracesOrBrackets = "Brackets"
                        node.ContainsObjectValue = True
                        BracesList.Add(node)
                        bracketsStartIndex = -1
                    End If
                ElseIf Input(i) = ":" Then
                    lastColonIndex = i
                End If
            Next
        End Sub






        Private Sub GetNodes0(ByRef Input As String)
            Dim bracesCount As Integer = 0
            Dim bracketsCount As Integer = 0
            Dim bracesStartIndex As Integer = -1
            Dim bracketsStartIndex As Integer = -1
            For i As Integer = 0 To Input.Length - 1
                If Input(i) = "{" Then
                    bracesCount += 1
                    If bracesStartIndex = -1 Then
                        bracesStartIndex = i
                    End If
                ElseIf Input(i) = "[" Then
                    bracketsCount += 1
                    If bracketsStartIndex = -1 Then
                        bracketsStartIndex = i
                    End If
                ElseIf Input(i) = "}" Then
                    bracesCount -= 1
                    If bracesCount = 0 Then
                        Dim node As New Class_JsonOjetoV0()
                        node.BracesValue = Input.Substring(bracesStartIndex + 1, i - bracesStartIndex - 1)
                        node.BracesOrBrackets = "Braces"
                        node.ContainsObjectValue = True
                        BracketsList.Add(node)
                        bracesStartIndex = -1
                    End If
                ElseIf Input(i) = "]" Then
                    bracketsCount -= 1
                    If bracketsCount = 0 Then
                        Dim node As New Class_JsonOjetoV0()
                        node.BracketsValue = Input.Substring(bracketsStartIndex + 1, i - bracketsStartIndex - 1)
                        node.BracesOrBrackets = "Brackets"
                        node.ContainsObjectValue = True
                        BracesList.Add(node)
                        bracketsStartIndex = -1
                    End If
                End If
            Next
        End Sub



    End Class

    Friend Sub GetNodes(ByRef Input As String)
        Dim Header As String = String.Empty
        Dim BracketsList As New List(Of Class_JsonOjetoV0)
        Dim BracesList As New List(Of Class_JsonOjetoV0)
        Dim bracesCount As Integer = 0
        Dim bracketsCount As Integer = 0
        Dim bracesStartIndex As Integer = -1
        Dim bracketsStartIndex As Integer = -1
        Dim lastColonIndex As Integer = -1
        For i As Integer = 0 To Input.Length - 1
            If Input(i) = "{" Then
                bracesCount += 1
                If bracesStartIndex = -1 Then
                    bracesStartIndex = i
                    If lastColonIndex <> -1 Then
                        Header = Input.Substring(lastColonIndex + 1, bracesStartIndex - lastColonIndex - 1).Trim()
                    End If
                End If
            ElseIf Input(i) = "[" Then
                bracketsCount += 1
                If bracketsStartIndex = -1 Then
                    bracketsStartIndex = i
                    If lastColonIndex <> -1 Then
                        Header = Input.Substring(lastColonIndex + 1, bracketsStartIndex - lastColonIndex - 1).Trim()
                    End If
                End If
            ElseIf Input(i) = "}" Then
                bracesCount -= 1
                If bracesCount = 0 Then
                    Dim node As New Class_JsonOjetoV0()
                    node.BracesValue = Input.Substring(bracesStartIndex + 1, i - bracesStartIndex - 1)
                    node.BracesOrBrackets = "Braces"
                    node.ContainsObjectValue = True
                    BracketsList.Add(node)
                    bracesStartIndex = -1
                End If
            ElseIf Input(i) = "]" Then
                bracketsCount -= 1
                If bracketsCount = 0 Then
                    Dim node As New Class_JsonOjetoV0()
                    node.BracketsValue = Input.Substring(bracketsStartIndex + 1, i - bracketsStartIndex - 1)
                    node.BracesOrBrackets = "Brackets"
                    node.ContainsObjectValue = True
                    BracesList.Add(node)
                    bracketsStartIndex = -1
                End If
            ElseIf Input(i) = ":" Then
                lastColonIndex = i
            End If
        Next
    End Sub


    Public Function GetNodes0(ByVal input As String) As List(Of Class_JsonOjetoV0)
        Dim nodesJson As New List(Of Class_JsonOjetoV0)
        Dim bracesCount As Integer = 0
        Dim bracketsCount As Integer = 0
        Dim bracesStartIndex As Integer = -1
        Dim bracketsStartIndex As Integer = -1

        For i As Integer = 0 To input.Length - 1
            If input(i) = "{" Then
                bracesCount += 1
                If bracesStartIndex = -1 Then
                    bracesStartIndex = i
                End If
            ElseIf input(i) = "[" Then
                bracketsCount += 1
                If bracketsStartIndex = -1 Then
                    bracketsStartIndex = i
                End If
            ElseIf input(i) = "}" Then
                bracesCount -= 1
                If bracesCount = 0 Then
                    Dim node As New Class_JsonOjetoV0()
                    node.BracesValue = input.Substring(bracesStartIndex + 1, i - bracesStartIndex - 1)
                    node.BracesOrBrackets = "Braces"
                    node.ContainsObjectValue = True
                    nodesJson.Add(node)
                    bracesStartIndex = -1
                End If
            ElseIf input(i) = "]" Then
                bracketsCount -= 1
                If bracketsCount = 0 Then
                    Dim node As New Class_JsonOjetoV0()
                    node.BracketsValue = input.Substring(bracketsStartIndex + 1, i - bracketsStartIndex - 1)
                    node.BracesOrBrackets = "Brackets"
                    node.ContainsObjectValue = True
                    nodesJson.Add(node)
                    bracketsStartIndex = -1
                End If
            End If
        Next

        Return nodesJson
    End Function


    'Public Function GetNodes(ByVal input As String) As List(Of String)
    '    Dim nodesJson As New List(Of Class_JsonObject)
    '    Dim nodes As New List(Of String)
    '    Dim bracesCount As Integer = 0
    '    Dim bracketsCount As Integer = 0
    '    Dim bracesStartIndex As Integer = -1
    '    Dim bracketsStartIndex As Integer = -1



    '    For i As Integer = 0 To input.Length - 1
    '        If input(i) = "{" Then
    '            bracesCount += 1
    '            If bracesStartIndex = -1 Then
    '                bracesStartIndex = i
    '            End If
    '        ElseIf input(i) = "[" Then
    '            bracketsCount += 1
    '            If bracketsStartIndex = -1 Then
    '                bracketsStartIndex = i
    '            End If
    '        ElseIf input(i) = "}" Then
    '            bracesCount -= 1
    '            If bracesCount = 0 Then
    '                nodes.Add(input.Substring(bracesStartIndex + 1, i - bracesStartIndex - 1))
    '                bracesStartIndex = -1
    '            End If
    '        ElseIf input(i) = "]" Then
    '            bracketsCount -= 1
    '            If bracketsCount = 0 Then
    '                nodes.Add(input.Substring(bracketsStartIndex + 1, i - bracketsStartIndex - 1))
    '                bracketsStartIndex = -1
    '            End If
    '        End If
    '    Next

    '    Return nodes
    'End Function



    Sub leer_json(archivo As String)
        'Dim objeto As New Dictionary(Of String, Object)
        'Dim array As New List(Of Object)
        'Dim estado As String = "inicial"
        'For i As Integer = 0 To archivo.Length - 1
        '    Dim caracter As Char = archivo(i)
        '    If estado = "inicial" Then
        '        If caracter = "{" Then
        '            estado = "objeto"
        '        ElseIf caracter = "[" Then
        '            estado = "array"
        '        Else
        '            Throw New ArgumentException("Error en el JSON")
        '        End If
        '    ElseIf estado = "objeto" Then
        '        If caracter = "}" Then
        '            estado = "inicial"
        '        ElseIf caracter = "," Then
        '            Continue For
        '        Else
        '            If caracter = """" Then
        '                Dim clave As String = ""
        '                While caracter <> """"
        '                    clave += caracter
        '                    caracter = archivo(i + 1)
        '                End While
        '                objeto(clave) = leer_json(archivo.Substring(i + 2))
        '            End If
        '        End If
        '    ElseIf estado = "array" Then
        '        If caracter = "]" Then
        '            estado = "inicial"
        '        ElseIf caracter = "," Then
        '            Continue For
        '        Else
        '            objeto(leer_json(archivo.Substring(i, 2))) = leer_json(archivo.Substring(i + 3))
        '        End If
        '    End If
        'Next
        'Return objeto
    End Sub







    Function ParseJson(jsonString As String) As Object
        Dim jsonDict As New Dictionary(Of String, Object)
        Dim key As String = Nothing
        Dim value As Object = Nothing
        Dim inString As Boolean = False
        Dim isEscape As Boolean = False

        For Each c As Char In jsonString
            If inString Then
                If isEscape Then
                    isEscape = False
                ElseIf c = "\"c Then
                    isEscape = True
                ElseIf c = """"c Then
                    inString = False
                Else
                    value += c
                End If
            Else
                If c = "{"c Then
                    If key IsNot Nothing Then
                        jsonDict.Add(key, value)
                        key = Nothing
                        value = Nothing
                    End If
                ElseIf c = "}"c Then
                    If key IsNot Nothing Then
                        jsonDict(key) = value
                        key = Nothing
                        value = Nothing
                    End If
                ElseIf c = ","c Then
                    If key IsNot Nothing Then
                        jsonDict(key) = value
                        key = Nothing
                        value = Nothing
                    End If
                ElseIf c = ":"c Then
                    ' No hacer nada en este ejemplo simple
                ElseIf c = """"c Then
                    inString = True
                    value = ""
                Else
                    If c <> " "c AndAlso c <> vbCr AndAlso c <> vbLf AndAlso c <> vbTab Then
                        If key Is Nothing Then
                            key = c
                        ElseIf value Is Nothing Then
                            value = c
                        Else
                            value += c
                        End If
                    End If
                End If
            End If
        Next

        If key IsNot Nothing Then
            jsonDict(key) = value
        End If

        Return jsonDict
    End Function

End Class
