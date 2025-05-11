

'Imports System.DirectoryServices.ActiveDirectory


Public Class Class_JsonBot

    Public Structure ListVal
        Dim Cla As String
        Dim Val As String
    End Structure

    Public Vals As New List(Of ListVal)

    Friend Sub ObEle(ByRef Texto As String)
        Try
            Texto = Replace(Texto, """", "")
            Texto = Replace(Texto, vbCr, "")
            Texto = Replace(Texto, vbCrLf, "")
            Texto = Replace(Texto, vbLf, "")
            Texto = Replace(Texto, vbTab, "")


            Dim Elem() As String = New String() {}

            Dim PosObj As UInteger = 0


            If 1 = CInt(Texto.IndexOf("{")) Then


                For Indice As UInteger = 0 To Texto.Length - 1

                    Dim PrDeli As UInteger = Texto.IndexOf(":", CInt(PosObj))
                    If Texto.Chars(PrDeli + 1) = "{" Then
                        Try
                            Dim PosBrazo As UInteger = Texto.IndexOf("}", CInt(PrDeli))
                            Dim NuevoPar As New ListVal
                            NuevoPar.Cla = Replace(Texto.Substring(PosObj, PrDeli - PosObj), ",", "")
                            NuevoPar.Val = Texto.Substring(PrDeli + 1, PosBrazo - (PrDeli))
                            Vals.Add(NuevoPar)
                            PosObj = PosBrazo + 1
                            Indice = PosBrazo + 1
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    ElseIf Texto.Chars(PrDeli + 1) = "[" Then
                        Try
                            Dim PosBrazo As UInteger = Texto.IndexOf("]", CInt(PrDeli))
                            Dim NuevoPar As New ListVal
                            NuevoPar.Cla = Replace(Texto.Substring(PosObj, PrDeli - PosObj), ",", "")
                            NuevoPar.Val = Texto.Substring(PrDeli + 1, PosBrazo - (PrDeli))
                            Vals.Add(NuevoPar)
                            PosObj = PosBrazo + 1
                            Indice = PosBrazo + 1
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    Else
                        Try
                            Dim Par() As String = Split(Elem(Indice), ":")
                            Dim NuevoPar As New ListVal
                            NuevoPar.Cla = Replace(Par(0), "{", "")
                            NuevoPar.Val = Replace(Par(1), "}", "")
                            Vals.Add(NuevoPar)
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                    End If

                Next

            Else
                Elem = Split(Texto, ",")

                For Indice As UInteger = 0 To Elem.Length - 1

                    Dim PrimerDelimitador As UInteger = Texto.IndexOf(":", CInt(PosObj))
                    If Texto.Chars(PrimerDelimitador + 1) = "{" Then
                        Try
                            Dim PosBrazo As UInteger = Texto.IndexOf("}", CInt(PrimerDelimitador))
                            Dim NuevoPar As New ListVal
                            NuevoPar.Cla = Replace(Texto.Substring(PosObj, PrimerDelimitador - PosObj), ",", "")
                            Dim Cantidad As Integer = PosBrazo - (PrimerDelimitador)
                            Dim Posicion As Integer = PrimerDelimitador + 1
                            NuevoPar.Val = Texto.Substring(Posicion, Cantidad)
                            Vals.Add(NuevoPar)
                            PosObj = PosBrazo + 1
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    ElseIf Texto.Chars(PrimerDelimitador + 1) = "[" Then
                        Try
                            Dim PosBrazo As UInteger = Texto.IndexOf("]", CInt(PrimerDelimitador))
                            Dim NuevoPar As New ListVal
                            NuevoPar.Cla = Replace(Texto.Substring(PosObj, PrimerDelimitador - PosObj), ",", "")
                            Dim Cantidad As Integer = PosBrazo - (PrimerDelimitador)
                            Dim Posicion As Integer = PrimerDelimitador + 1
                            NuevoPar.Val = Texto.Substring(Posicion, Cantidad)
                            Vals.Add(NuevoPar)
                            PosObj = PosBrazo + 1
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    Else
                        Try
                            Dim Par() As String = Split(Elem(Indice), ":")
                            Dim NuevoPar As New ListVal
                            NuevoPar.Cla = Replace(Par(0), "{", "")
                            NuevoPar.Val = Replace(Par(1), "}", "")
                            Vals.Add(NuevoPar)
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                    End If
                    If PosObj >= Texto.Length Then
                        Exit For
                    End If

                Next


            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private m_StringValue As String = String.Empty

    Public Property StVal() As String
        Get
            Return m_StringValue
        End Get
        Set(ByVal value As String)
            m_StringValue = value
            GetNodes(m_StringValue)
        End Set
    End Property

    Public Property He As String = String.Empty

    Friend Property Typ As String = String.Empty
    Friend Property Hi As Boolean = False

    Public Property ckeLi As New List(Of Class_JsonBot)
    Public Property BraLi As New List(Of Class_JsonBot)

    Private Sub GetNodes(ByRef Input As String)
        Dim braCo As Integer = 0
        Dim ckeCo As Integer = 0
        Dim braSt As Integer = 0
        Dim ckeSt As Integer = 0
        Dim laSt As Integer = 0

        For i As Integer = 0 To Input.Length - 1
            If ckeCo > 1 Or braCo > 1 Then
                Me.Hi = True
            End If

            If (Input(i) = "{") And ((Typ = "") Or (Typ = "Bra")) Then


                braCo += 1
                If (Typ = "") Then
                    braSt = i
                    Typ = "Bra"
                End If

            ElseIf (Input(i) = "[") And ((Typ = "") Or (Typ = "ckets")) Then
                ckeCo += 1
                If (Typ = "") Then
                    ckeSt = i
                    Typ = "ckets"
                End If
            ElseIf (Input(i) = "}") And (Typ = "Bra") Then
                braCo -= 1
                If braCo = 0 Then
                    Dim node As New Class_JsonBot()
                    node.He = GetHe(Input.Substring(laSt + 1, (i - braSt)).Trim())
                    node.StVal = Input.Substring(braSt + 1, (i - braSt) - 1)
                    node.ObEle(node.StVal)
                    Typ = ""
                    BraLi.Add(node)
                    braSt = -1
                    laSt = i
                    braSt = i + 1
                End If

            ElseIf (Input(i) = "]") And (Typ = "ckets") Then
                ckeCo -= 1
                If ckeCo = 0 Then
                    Dim node As New Class_JsonBot()
                    node.He = GetHe(Mid(Input, laSt + 1, i - ckeSt - 1))
                    node.StVal = Input.Substring(ckeSt + 1, (i - ckeSt) - 1)
                    node.ObEle(node.StVal)
                    Typ = ""
                    ckeLi.Add(node)
                    ckeSt = -1
                    laSt = i
                End If
            End If
        Next

        Dim aaasdf As Boolean = False
    End Sub

    Private Function GetHe(ByRef Inp As String) As String
        Dim TSal As String = ""
        Dim PosIni As UInteger = 0
        Dim Texto As String = Replace(Inp, """", "")
        Texto = Replace(Texto, " ", "")
        For i As Integer = 0 To Inp.Length - 1
            Try
                If Inp(i) = "," Then
                    PosIni = i
                End If
                If Inp(i) = ":" Then

                    TSal = Inp.Substring(PosIni, i - PosIni - 1).ToString
                    TSal = Replace(TSal, ":", "").Trim
                    TSal = Replace(TSal, ",", "").Trim
                    TSal = Replace(TSal, """", "").Trim
                    Exit For
                End If
            Catch ex As Exception

            End Try
        Next
        Return TSal
    End Function

End Class







Public Class Class_JsonEstructuraGithub

    Public Structure ListaValores
        Dim Clave As String
        Dim Valor As String
    End Structure

    Public Valores As New List(Of ListaValores)

    Friend Sub ObtenerElementos(ByRef Texto As String)

        Texto = Replace(Texto, """", "")
        Dim Elementos() As String = New String() {}
        Dim PosicionObjetos As UInteger = 0
        If 1 = CInt(Texto.IndexOf("{")) Then
            For Indice As UInteger = 0 To Texto.Length - 1
                Dim PrimerDelimitador As UInteger = Texto.IndexOf(":", CInt(PosicionObjetos))
                If Texto.Chars(PrimerDelimitador + 1) = "{" Then
                    Try
                        Dim PosBrazo As UInteger = Texto.IndexOf("}", CInt(PrimerDelimitador))
                        Dim NuevoPar As New ListaValores
                        NuevoPar.Clave = Replace(Texto.Substring(PosicionObjetos, PrimerDelimitador - PosicionObjetos), ",", "")
                        Dim Cantidad As Integer = PosBrazo - (PrimerDelimitador)
                        Dim Posicion As Integer = PrimerDelimitador + 1
                        NuevoPar.Valor = Texto.Substring(Posicion, Cantidad)
                        Valores.Add(NuevoPar)
                        PosicionObjetos = PosBrazo + 1
                        Indice = PosBrazo + 1
                    Catch ex As Exception
                        'MsgBox(ex.Message)
                    End Try
                ElseIf Texto.Chars(PrimerDelimitador + 1) = "[" Then
                    Try
                        Dim PosBrazo As UInteger = Texto.IndexOf("]", CInt(PrimerDelimitador))
                        Dim NuevoPar As New ListaValores
                        NuevoPar.Clave = Replace(Texto.Substring(PosicionObjetos, PrimerDelimitador - PosicionObjetos), ",", "")
                        Dim Cantidad As Integer = PosBrazo - (PrimerDelimitador)
                        Dim Posicion As Integer = PrimerDelimitador + 1
                        NuevoPar.Valor = Texto.Substring(Posicion, Cantidad)
                        Valores.Add(NuevoPar)
                        PosicionObjetos = PosBrazo + 1
                        Indice = PosBrazo + 1
                    Catch ex As Exception
                        'MsgBox(ex.Message)
                    End Try
                Else
                    Try
                        Dim Par() As String = Split(Elementos(Indice), ":")
                        Dim NuevoPar As New ListaValores
                        NuevoPar.Clave = Replace(Par(0), "{", "")
                        NuevoPar.Valor = Replace(Par(1), "}", "")
                        Valores.Add(NuevoPar)
                    Catch ex As Exception
                        'MsgBox(ex.Message)
                    End Try

                End If

            Next

        Else
            Elementos = Split(Texto, ",")
            For Indice As UInteger = 0 To Elementos.Length - 1

                Dim PrimerDelimitador As UInteger = Texto.IndexOf(":", CInt(PosicionObjetos))
                If Texto.Chars(PrimerDelimitador + 1) = "{" Then
                    Try
                        Dim PosBrazo As UInteger = Texto.IndexOf("}", CInt(PrimerDelimitador))
                        Dim NuevoPar As New ListaValores
                        NuevoPar.Clave = Replace(Texto.Substring(PosicionObjetos, PrimerDelimitador - PosicionObjetos), ",", "")
                        Dim Cantidad As Integer = PosBrazo - (PrimerDelimitador)
                        Dim Posicion As Integer = PrimerDelimitador + 1
                        NuevoPar.Valor = Texto.Substring(Posicion, Cantidad)
                        Valores.Add(NuevoPar)
                        PosicionObjetos = PosBrazo + 1
                    Catch ex As Exception
                        'MsgBox(ex.Message)
                    End Try
                ElseIf Texto.Chars(PrimerDelimitador + 1) = "[" Then
                    Try
                        Dim PosBrazo As UInteger = Texto.IndexOf("]", CInt(PrimerDelimitador))
                        Dim NuevoPar As New ListaValores
                        NuevoPar.Clave = Replace(Texto.Substring(PosicionObjetos, PrimerDelimitador - PosicionObjetos), ",", "")
                        Dim Cantidad As Integer = PosBrazo - (PrimerDelimitador)
                        Dim Posicion As Integer = PrimerDelimitador + 1
                        NuevoPar.Valor = Texto.Substring(Posicion, Cantidad)
                        Valores.Add(NuevoPar)
                        PosicionObjetos = PosBrazo + 1
                    Catch ex As Exception
                        'MsgBox(ex.Message)
                    End Try
                Else
                    Try
                        Dim Par() As String = Split(Elementos(Indice), ":")
                        Dim NuevoPar As New ListaValores
                        NuevoPar.Clave = Replace(Par(0), "{", "")
                        NuevoPar.Valor = Replace(Par(1), "}", "")
                        Valores.Add(NuevoPar)
                    Catch ex As Exception
                        'MsgBox(ex.Message)
                    End Try

                End If
                If PosicionObjetos >= Texto.Length Then
                    Exit For
                End If

            Next
        End If
    End Sub

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

    Public Property BracketsList As New List(Of Class_JsonEstructuraGithub)
    Public Property BracesList As New List(Of Class_JsonEstructuraGithub)

    Private Sub GetNodes(ByRef Input As String)
        Dim braceCount As Integer = 0
        Dim cketsCount As Integer = 0
        Dim braceStart As Integer = 0
        Dim cketsStart As Integer = 0
        Dim lastStart As Integer = 0

        For i As Integer = 0 To Input.Length - 1
            If cketsCount > 1 Or braceCount > 1 Then
                Me.ContainsHijos = True
            End If
            If (Input(i) = "{") And ((BracesOrBrackets = "") Or (BracesOrBrackets = "Braces")) Then
                braceCount += 1
                If (BracesOrBrackets = "") Then
                    braceStart = i
                    BracesOrBrackets = "Braces"
                End If
            ElseIf (Input(i) = "[") And ((BracesOrBrackets = "") Or (BracesOrBrackets = "Brackets")) Then
                cketsCount += 1
                If (BracesOrBrackets = "") Then
                    cketsStart = i
                    BracesOrBrackets = "Brackets"
                End If
            ElseIf (Input(i) = "}") And (BracesOrBrackets = "Braces") Then
                braceCount -= 1
                If braceCount = 0 Then
                    Dim node As New Class_JsonEstructuraGithub()
                    Try
                        Dim headerStart As Integer = Input.LastIndexOf(":", 1) + 1
                        Dim headerEnd As Integer = braceStart - 1
                        node.Header = GetHeader(Input.Substring(lastStart + 1, (i - braceStart)).Trim())
                    Catch ex As Exception
                        'Console.WriteLine("Error obteniendo el nombre del nodo: " & ex.Message)
                    End Try
                    Dim Texto As String = Input.Substring(braceStart + 1, i - braceStart - 1)
                    node.StringValue = Input.Substring(braceStart + 1, (i - braceStart) - 1)
                    node.ObtenerElementos(node.StringValue)
                    BracesOrBrackets = ""
                    BracesList.Add(node)
                    braceStart = -1
                    lastStart = i
                    braceStart = i + 1
                End If

            ElseIf (Input(i) = "]") And (BracesOrBrackets = "Brackets") Then
                cketsCount -= 1
                If cketsCount = 0 Then
                    Dim node As New Class_JsonEstructuraGithub()
                    Try
                        node.Header = GetHeader(Mid(Input, lastStart + 1, i - cketsStart - 1))
                    Catch ex As Exception
                        ' Manejar el error de manera adecuada, por ejemplo, imprimir un mensaje
                        Console.WriteLine("Error obteniendo el nombre del nodo: " & ex.Message)
                    End Try
                    node.StringValue = Input.Substring(cketsStart + 1, (i - cketsStart) - 1)
                    node.ObtenerElementos(node.StringValue)
                    BracesOrBrackets = ""
                    BracketsList.Add(node)
                    cketsStart = -1
                    lastStart = i
                End If
            End If
        Next

        Dim aaasdf As Boolean = False
    End Sub

    Private Function GetHeader(ByRef Input As String) As String
        Dim TextoSalida As String = ""
        Dim Comillas As String = """"
        Dim Llave As String = "{"
        Dim Coma As String = ","
        Dim PosicinInicio As UInteger = 0
        Dim Texto As String = Replace(Input, """", "")
        Texto = Replace(Texto, " ", "")
        For i As Integer = 0 To Input.Length - 1
            Try
                If Input(i) = Coma Then
                    PosicinInicio = i
                End If
                If Input(i) = ":" Then
                    TextoSalida = Input.Substring(PosicinInicio, i - PosicinInicio - 1).ToString
                    TextoSalida = Replace(TextoSalida, ":", "").Trim
                    TextoSalida = Replace(TextoSalida, ",", "").Trim
                    TextoSalida = Replace(TextoSalida, """", "").Trim
                    Exit For
                End If
            Catch ex As Exception

            End Try
        Next
        Return TextoSalida
    End Function

End Class











Public Class Class_JsonEstructuraMuyBueno


    Public Property Header As String = String.Empty

    Friend Property BracesOrBrackets As String = String.Empty  ' array=Brackets, Braces=objeto
    Friend Property ContainsHijos As Boolean = False

    Public Property BracketsList As New List(Of Class_JsonEstructuraMuyBueno)
    Public Property BracesList As New List(Of Class_JsonEstructuraMuyBueno)



#Region "Extra"



    Friend Sub ObtenerElementos0(ByRef Texto As String)
        Try
            Texto = Replace(Texto, """", "")

            Dim Elementos() As String = Split(Texto, ",")
            ReDim Valores(Elementos.Length - 1)
            For Indice As UInteger = 0 To Elementos.Length - 1
                Dim Par() As String = Split(Elementos(Indice), ":")
                Dim NuevoPar As New ListaValores
                NuevoPar.Clave = Par(0)
                NuevoPar.Valor = Par(1)
                Valores(Indice) = NuevoPar
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Property StringValue1() As String
        Get
            Return m_StringValue
        End Get
        Set(ByVal value As String)
            m_StringValue = value
            GetNodesv2(m_StringValue)
        End Set
    End Property

    Public Property StringValue2() As String
        Get
            Return m_StringValue
        End Get
        Set(ByVal value As String)
            m_StringValue = value
            GetNodes(m_StringValue)
        End Set
    End Property

    Private Sub GetNodesv2(ByRef Input As String)
        Dim braceCount As Integer = 0
        Dim bracketCount As Integer = 0
        Dim braceStart As Integer = -1
        Dim bracketStart As Integer = -1
        Dim inString As Boolean = False
        Dim lastQuoteIndex As Integer = -1

        For i As Integer = 0 To Input.Length - 1
            Dim c As Char = Input(i)

            If c = """" Then
                inString = Not inString
                If inString Then
                    lastQuoteIndex = i
                End If
            ElseIf Not inString Then
                If c = "{" Then
                    braceCount += 1
                    If braceCount = 1 Then
                        braceStart = i
                    End If
                ElseIf c = "}" Then
                    braceCount -= 1
                    If braceCount = 0 Then
                        ' Extract the node name and content
                        Dim node As New Class_JsonEstructuraMuyBueno()
                        node.Header = Input.Substring(lastQuoteIndex + 1, braceStart - lastQuoteIndex - 1).Trim(New Char() {""""c, ":"c})
                        node.StringValue = Input.Substring(braceStart + 1, i - braceStart - 1)
                        node.ObtenerElementos(node.StringValue)
                        BracesList.Add(node)
                        braceStart = -1
                    End If
                ElseIf c = "[" Then
                    bracketCount += 1
                    If bracketCount = 1 Then
                        bracketStart = i
                    End If
                ElseIf c = "]" Then
                    bracketCount -= 1
                    If bracketCount = 0 Then
                        ' Extract the node name and content
                        Dim node As New Class_JsonEstructuraMuyBueno()
                        node.Header = Input.Substring(lastQuoteIndex + 1, bracketStart - lastQuoteIndex - 1).Trim(New Char() {""""c, ":"c})
                        node.StringValue = Input.Substring(bracketStart + 1, i - bracketStart - 1)
                        node.ObtenerElementos(node.StringValue)
                        BracketsList.Add(node)
                        bracketStart = -1
                    End If
                End If
            End If
        Next
    End Sub

#End Region


    Public Structure ListaValores
        Dim Clave As String
        Dim Valor As String
    End Structure

    Public Valores() As ListaValores = New ListaValores() {} 'New List(Of ListaValores) 'New ListaValores() {}

    Friend Sub ObtenerElementos(ByRef Texto As String)
        Try
            Texto = Replace(Texto, """", "")

            Dim Elementos() As String = Split(Texto, ",")
            ReDim Valores(Elementos.Length - 1)

            Dim PosicionObjetos As UInteger = 0

            For Indice As UInteger = 0 To Elementos.Length - 1

                Dim PrimerDelimitador As UInteger = Texto.IndexOf(":", CInt(PosicionObjetos))
                If Texto.Chars(PrimerDelimitador + 1) = "{" Then
                    Try
                        Dim PosBrazo As UInteger = Texto.IndexOf("}", CInt(PrimerDelimitador))
                        Dim NuevoPar As New ListaValores
                        NuevoPar.Clave = Texto.Substring(PosicionObjetos, PrimerDelimitador - PosicionObjetos)
                        Dim Cantidad As Integer = PosBrazo - (PrimerDelimitador)
                        NuevoPar.Valor = Texto.Substring(PosicionObjetos + PrimerDelimitador + 1, Cantidad)
                        Valores(Indice) = NuevoPar
                        PosicionObjetos = PosBrazo + 1
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                Else
                    Dim Par() As String = Split(Elementos(Indice), ":")
                    Dim NuevoPar As New ListaValores
                    NuevoPar.Clave = Replace(Par(0), "{", "")
                    NuevoPar.Valor = Replace(Par(0), "}", "")
                    Valores(Indice) = NuevoPar
                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

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

    Private Sub GetNodes(ByRef Input As String)
        Dim braceCount As Integer = 0
        Dim cketsCount As Integer = 0
        Dim braceStart As Integer = 0
        Dim cketsStart As Integer = 0
        Dim lastStart As Integer = 0

        For i As Integer = 0 To Input.Length - 1
            If cketsCount > 1 Or braceCount > 1 Then
                Me.ContainsHijos = True
            End If

            If (Input(i) = "{") And ((BracesOrBrackets = "") Or (BracesOrBrackets = "Braces")) Then


                braceCount += 1
                If (BracesOrBrackets = "") Then
                    braceStart = i
                    BracesOrBrackets = "Braces"
                End If

            ElseIf (Input(i) = "[") And ((BracesOrBrackets = "") Or (BracesOrBrackets = "Brackets")) Then


                cketsCount += 1
                If (BracesOrBrackets = "") Then
                    cketsStart = i
                    BracesOrBrackets = "Brackets"
                End If

            ElseIf (Input(i) = "}") And (BracesOrBrackets = "Braces") Then
                braceCount -= 1
                If braceCount = 0 Then
                    Dim node As New Class_JsonEstructuraMuyBueno()
                    Try
                        Dim headerStart As Integer = Input.LastIndexOf(":", 1) + 1
                        Dim headerEnd As Integer = braceStart - 1
                        node.Header = GetHeader(Input.Substring(lastStart + 1, (i - braceStart)).Trim())
                    Catch ex As Exception
                        ' Manejar el error de manera adecuada, por ejemplo, imprimir un mensaje
                        Console.WriteLine("Error obteniendo el nombre del nodo: " & ex.Message)
                    End Try
                    Dim Texto As String = Input.Substring(braceStart + 1, i - braceStart - 1)
                    node.StringValue = Input.Substring(braceStart + 1, (i - braceStart) - 1)
                    node.ObtenerElementos(node.StringValue)
                    BracesOrBrackets = ""
                    BracesList.Add(node)
                    braceStart = -1
                    lastStart = i
                    braceStart = i + 1
                End If

            ElseIf (Input(i) = "]") And (BracesOrBrackets = "Brackets") Then
                cketsCount -= 1
                If cketsCount = 0 Then
                    Dim node As New Class_JsonEstructuraMuyBueno()
                    Try
                        node.Header = GetHeader(Mid(Input, lastStart + 1, i - cketsStart - 1))
                    Catch ex As Exception
                        ' Manejar el error de manera adecuada, por ejemplo, imprimir un mensaje
                        Console.WriteLine("Error obteniendo el nombre del nodo: " & ex.Message)
                    End Try
                    node.StringValue = Input.Substring(cketsStart + 1, (i - cketsStart) - 1)
                    node.ObtenerElementos(node.StringValue)
                    BracesOrBrackets = ""
                    BracketsList.Add(node)
                    cketsStart = -1
                    lastStart = i
                End If

            ElseIf Input(i) = ":" Then
                'lastColonIndex = i
            End If
        Next

        Dim aaasdf As Boolean = False
    End Sub

    Private Function GetHeader(ByRef Input As String) As String
        Dim TextoSalida As String = ""
        Dim Comillas As String = """"
        Dim Llave As String = "{"
        Dim Coma As String = ","
        Dim PosicinInicio As UInteger = 0
        Dim Texto As String = Replace(Input, """", "")
        Texto = Replace(Texto, " ", "")
        For i As Integer = 0 To Input.Length - 1
            Try
                If Input(i) = Coma Then
                    PosicinInicio = i
                End If
                If Input(i) = ":" Then

                    TextoSalida = Input.Substring(PosicinInicio, i - PosicinInicio - 1).ToString
                    TextoSalida = Replace(TextoSalida, ":", "").Trim
                    TextoSalida = Replace(TextoSalida, ",", "").Trim
                    TextoSalida = Replace(TextoSalida, """", "").Trim
                    Exit For
                End If
            Catch ex As Exception

            End Try
        Next
        Return TextoSalida
    End Function

End Class


Public Class Class_JsonEstructura_UTIL_OK

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

    Public Property StringValue1() As String
        Get
            Return m_StringValue
        End Get
        Set(ByVal value As String)
            m_StringValue = value
            GetNodesv2(m_StringValue)
        End Set
    End Property


    Public Property Header As String = String.Empty

    Friend Property BracesOrBrackets As String = String.Empty  ' array=Brackets, Braces=objeto
    Friend Property ContainsHijos As Boolean = False

    Public Property BracketsList As New List(Of Class_JsonEstructura_UTIL_OK)
    Public Property BracesList As New List(Of Class_JsonEstructura_UTIL_OK)

    Private Sub GetNodesv2(ByRef Input As String)
        Dim braceCount As Integer = 0
        Dim bracketCount As Integer = 0
        Dim braceStart As Integer = -1
        Dim bracketStart As Integer = -1
        Dim inString As Boolean = False
        Dim lastQuoteIndex As Integer = -1

        For i As Integer = 0 To Input.Length - 1
            Dim c As Char = Input(i)

            If c = """" Then
                inString = Not inString
                If inString Then
                    lastQuoteIndex = i
                End If
            ElseIf Not inString Then
                If c = "{" Then
                    braceCount += 1
                    If braceCount = 1 Then
                        braceStart = i
                    End If
                ElseIf c = "}" Then
                    braceCount -= 1
                    If braceCount = 0 Then
                        ' Extract the node name and content
                        Dim node As New Class_JsonEstructura_UTIL_OK()
                        node.Header = Input.Substring(lastQuoteIndex + 1, braceStart - lastQuoteIndex - 1).Trim(New Char() {""""c, ":"c})
                        node.StringValue = Input.Substring(braceStart + 1, i - braceStart - 1)
                        BracesList.Add(node)
                        braceStart = -1
                    End If
                ElseIf c = "[" Then
                    bracketCount += 1
                    If bracketCount = 1 Then
                        bracketStart = i
                    End If
                ElseIf c = "]" Then
                    bracketCount -= 1
                    If bracketCount = 0 Then
                        ' Extract the node name and content
                        Dim node As New Class_JsonEstructura_UTIL_OK()
                        node.Header = Input.Substring(lastQuoteIndex + 1, bracketStart - lastQuoteIndex - 1).Trim(New Char() {""""c, ":"c})
                        node.StringValue = Input.Substring(bracketStart + 1, i - bracketStart - 1)
                        BracketsList.Add(node)
                        bracketStart = -1
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub GetNodes(ByRef Input As String)
        Dim braceCount As Integer = 0
        Dim cketsCount As Integer = 0
        Dim braceStart As Integer = 0
        Dim cketsStart As Integer = 0
        Dim lastStart As Integer = 0

        For i As Integer = 0 To Input.Length - 1
            If cketsCount > 1 Or braceCount > 1 Then
                Me.ContainsHijos = True
            End If

            If (Input(i) = "{") And ((BracesOrBrackets = "") Or (BracesOrBrackets = "Braces")) Then


                braceCount += 1
                If (BracesOrBrackets = "") Then
                    braceStart = i
                    BracesOrBrackets = "Braces"
                End If

            ElseIf (Input(i) = "[") And ((BracesOrBrackets = "") Or (BracesOrBrackets = "Brackets")) Then


                cketsCount += 1
                If (BracesOrBrackets = "") Then
                    cketsStart = i
                    BracesOrBrackets = "Brackets"
                End If

            ElseIf (Input(i) = "}") And (BracesOrBrackets = "Braces") Then
                braceCount -= 1
                If braceCount = 0 Then
                    Dim node As New Class_JsonEstructura_UTIL_OK()
                    Try
                        Dim headerStart As Integer = Input.LastIndexOf(":", 1) + 1
                        Dim headerEnd As Integer = braceStart - 1
                        node.Header = GetHeader(Input.Substring(lastStart + 1, (i - braceStart)).Trim())
                    Catch ex As Exception
                        ' Manejar el error de manera adecuada, por ejemplo, imprimir un mensaje
                        Console.WriteLine("Error obteniendo el nombre del nodo: " & ex.Message)
                    End Try
                    Dim Texto As String = Input.Substring(braceStart + 1, i - braceStart - 1)
                    node.StringValue = Input.Substring(braceStart + 1, (i - braceStart) - 1)
                    BracesOrBrackets = ""
                    BracesList.Add(node)
                    braceStart = -1
                    lastStart = i
                    braceStart = i + 1
                End If

            ElseIf (Input(i) = "]") And (BracesOrBrackets = "Brackets") Then
                cketsCount -= 1
                If cketsCount = 0 Then
                    Dim node As New Class_JsonEstructura_UTIL_OK()
                    Try
                        node.Header = GetHeader(Mid(Input, lastStart + 1, i - cketsStart - 1))
                    Catch ex As Exception
                        ' Manejar el error de manera adecuada, por ejemplo, imprimir un mensaje
                        Console.WriteLine("Error obteniendo el nombre del nodo: " & ex.Message)
                    End Try
                    node.StringValue = Input.Substring(cketsStart + 1, (i - cketsStart) - 1)
                    BracesOrBrackets = ""
                    BracketsList.Add(node)
                    cketsStart = -1
                    lastStart = i
                End If

            ElseIf Input(i) = ":" Then
                'lastColonIndex = i
            End If
        Next

        Dim aaasdf As Boolean = False
    End Sub

    Private Function GetHeader(ByRef Input As String) As String
        Dim TextoSalida As String = ""
        Dim Comillas As String = """"
        Dim Llave As String = "{"
        Dim Coma As String = ","
        Dim PosicinInicio As UInteger = 0
        Dim Texto As String = Replace(Input, """", "")
        Texto = Replace(Texto, " ", "")
        For i As Integer = 0 To Input.Length - 1
            Try
                If Input(i) = Coma Then
                    PosicinInicio = i
                End If
                If Input(i) = ":" Then

                    TextoSalida = Input.Substring(PosicinInicio, i - PosicinInicio - 1).ToString
                    TextoSalida = Replace(TextoSalida, ":", "").Trim
                    TextoSalida = Replace(TextoSalida, ",", "").Trim
                    TextoSalida = Replace(TextoSalida, """", "").Trim
                    Exit For
                End If
            Catch ex As Exception

            End Try
        Next
        Return TextoSalida
    End Function


    Private Function GetHeaderEndToStart(ByRef Input As String) As String
        Dim TextoSalida As String = ""
        Dim Comillas As String = """"
        Dim Puntos As Boolean = False
        Dim PosFinal As Boolean = False
        Dim lastColonIndex As Integer = 0

        For i As Integer = Input.Length - 1 To 0 Step -1
            Try
                If Input(i) = ":" AndAlso Puntos = False Then
                    Puntos = True
                ElseIf Input(i) = Comillas AndAlso Puntos = True Then
                    If PosFinal = False Then
                        PosFinal = True
                        lastColonIndex = i
                    Else
                        TextoSalida = Input.Substring(i + 1, lastColonIndex - i - 1).Trim()
                        Exit For
                    End If
                End If
            Catch ex As Exception
                ' Manejar el error de manera adecuada, por ejemplo, imprimir un mensaje
                Console.WriteLine("Error obteniendo el nombre del nodo: " & ex.Message)
            End Try
        Next

        Return TextoSalida
    End Function



    Public Sub ParseJson(ByVal jsonString As String)
        Dim stack As New Stack(Of Class_JsonEstructura_UTIL_OK)
        Dim currentObject As Class_JsonEstructura_UTIL_OK = New Class_JsonEstructura_UTIL_OK
        Dim currentKey As String = ""
        Dim inString As Boolean = False
        Dim braceCount As Integer = 0
        Dim bracketCount As Integer = 0

        For i As Integer = 0 To jsonString.Length - 1
            Dim c As Char = jsonString(i)

            If c = "{" And Not inString Then
                braceCount += 1
                If braceCount = 1 And bracketCount = 0 Then
                    currentObject = New Class_JsonEstructura_UTIL_OK()
                    stack.Push(currentObject)
                End If
            ElseIf c = "[" And Not inString Then
                bracketCount += 1
                If bracketCount = 1 And braceCount = 0 Then
                    currentObject = New Class_JsonEstructura_UTIL_OK()
                    stack.Push(currentObject)
                End If
            ElseIf c = "}" And Not inString Then
                braceCount -= 1
                If braceCount = 0 And bracketCount = 0 Then
                    stack.Pop()
                    If stack.Count > 0 Then
                        currentObject = stack.Peek()
                    Else
                        currentObject = Nothing
                    End If
                End If
            ElseIf c = "]" And Not inString Then
                bracketCount -= 1
                If bracketCount = 0 And braceCount = 0 Then
                    stack.Pop()
                    If stack.Count > 0 Then
                        currentObject = stack.Peek()
                    Else
                        currentObject = Nothing
                    End If
                End If
            ElseIf c = ":" And Not inString Then
                Try
                    currentKey = currentObject.GetHeader(jsonString.Substring(i + 1))
                Catch ex As Exception

                End Try

            ElseIf c = "," And Not inString Then
                currentObject = New Class_JsonEstructura_UTIL_OK()
                currentObject.BracesOrBrackets = "Value"
                currentObject.Header = currentKey
                currentObject.StringValue1 = jsonString.Substring(i + 1, jsonString.IndexOfAny({",", "}", "]"}, i + 1) - i - 1).Trim()
                If stack.Count > 0 Then
                    Dim parentObject As Class_JsonEstructura_UTIL_OK = stack.Peek()
                    If parentObject.BracesOrBrackets = "Braces" Then
                        parentObject.BracesList.Add(currentObject)
                    ElseIf parentObject.BracesOrBrackets = "Brackets" Then
                        parentObject.BracketsList.Add(currentObject)
                    End If
                End If
            ElseIf c = """" Then
                inString = Not inString
            End If
        Next
        Dim aa = 0
    End Sub

End Class


Public Class Class_JsonEstructura_ooooooooooooooo
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

    Public Property BracketsList As New List(Of Class_JsonEstructura_ooooooooooooooo)
    Public Property BracesList As New List(Of Class_JsonEstructura_ooooooooooooooo)


    Sub aa()
        'Dim Registros() As String = Split(NodoTexto, ",")
    End Sub

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

            If Input(i) = "{" And BracesOrBrackets = "" Then
                BracesOrBrackets = "Braces"
                bracesCount += 1
                bracesStartIndex = i

            ElseIf Input(i) = "[" And BracesOrBrackets = "" Then
                BracesOrBrackets = "Brackets"
                bracketsCount += 1
                bracketsStartIndex = i
            ElseIf Input(i) = "}" And BracesOrBrackets = "Braces" Then
                bracesCount -= 1
                If bracesCount = 0 Then
                    Dim node As New Class_JsonEstructura_ooooooooooooooo()
                    Try
                        Dim piopio As UInteger = Input.IndexOf(":")
                        Dim Textero As String = Mid(Input, 1, piopio)
                        node.Header = Replace(Textero, """", "") 'GetHeader(Mid(Input, lastColonIndex + 1, i - lastColonIndex - 1))
                    Catch ex As Exception

                    End Try
                    node.StringValue = Input.Substring(bracesStartIndex + 1, i - bracesStartIndex)
                    node.BracesOrBrackets = "Braces"
                    BracesList.Add(node)
                    bracesStartIndex = -1
                    lastColonIndex = i
                End If
            ElseIf Input(i) = "]" And BracesOrBrackets = "Brackets" Then
                bracketsCount -= 1
                If bracketsCount = 0 Then
                    Dim node As New Class_JsonEstructura_ooooooooooooooo()

                    Try
                        node.Header = GetHeader(Mid(Input, lastColonIndex + 1, i - lastColonIndex - 1))
                    Catch ex As Exception

                    End Try
                    node.StringValue = Input.Substring(bracketsStartIndex + 1, i - bracketsStartIndex - 1)
                    node.BracesOrBrackets = "Brackets"
                    BracketsList.Add(node)
                    bracketsStartIndex = -1
                    lastColonIndex = i
                End If
            ElseIf Input(i) = ":" Then
                'lastColonIndex = i
            End If
        Next
    End Sub

    Private Function GetHeader(ByRef Input As String) As String
        Dim TextoSalida As String = ""
        Dim Comillas As String = """"
        Dim Puntos As Boolean = False
        Dim PosFinal As Boolean = False
        Dim lastColonIndex As Integer = 0

        For i As Integer = Input.Length - 1 To 0 Step -1
            Try
                If Input(i) = ":" AndAlso Puntos = False Then
                    Puntos = True
                ElseIf Input(i) = Comillas AndAlso Puntos = True Then
                    If PosFinal = False Then
                        PosFinal = True
                        lastColonIndex = i
                    Else
                        TextoSalida = Input.Substring(i + 1, lastColonIndex - i - 1).Trim()
                        Exit For
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next

        Return TextoSalida
    End Function
End Class


Public Class Class_JsonEstructuraNopePRO
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

    Public Property BracketsList As New List(Of Class_JsonEstructuraNopePRO)
    Public Property BracesList As New List(Of Class_JsonEstructuraNopePRO)

    Private Sub GetNodes(ByRef Input As String)
        Dim bracesCount As Integer = 0
        Dim bracketsCount As Integer = 0
        Dim bracesStartIndex As Integer = 0
        Dim bracketsStartIndex As Integer = 0
        Dim lastColonIndex As Integer = 0

        For i As Integer = 0 To Input.Length - 1
            If bracketsCount > 1 Or bracesCount > 1 Then
                ContainsHijos = True
            End If

            If Input(i) = "{" And BracesOrBrackets = "" Then
                BracesOrBrackets = "Braces"
                bracesCount += 1
                bracesStartIndex = i
            ElseIf Input(i) = "[" And BracesOrBrackets = "" Then
                BracesOrBrackets = "Brackets"
                bracketsCount += 1
                bracketsStartIndex = i
            ElseIf Input(i) = "}" And BracesOrBrackets = "Braces" Then
                bracesCount -= 1
                If bracesCount = 0 Then
                    Dim node As New Class_JsonEstructuraNopePRO()

                    node.BracesOrBrackets = "Braces"
                    node.Header = GetHeader0(Input, lastColonIndex, bracesStartIndex)
                    node.StringValue = Input.Substring(bracesStartIndex + 1, i - bracesStartIndex - 1)
                    BracesList.Add(node)
                    bracesStartIndex = -1
                    lastColonIndex = i
                End If
            ElseIf Input(i) = "]" And BracesOrBrackets = "Brackets" Then
                bracketsCount -= 1
                If bracketsCount = 0 Then
                    Dim node As New Class_JsonEstructuraNopePRO()
                    node.StringValue = Input.Substring(bracketsStartIndex + 1, i - bracketsStartIndex - 1)
                    node.BracesOrBrackets = "Brackets"
                    node.Header = GetHeader0(Input, lastColonIndex, bracketsStartIndex)
                    BracketsList.Add(node)
                    bracketsStartIndex = -1
                    lastColonIndex = i
                End If
            ElseIf Input(i) = ":" Then
                ' lastColonIndex = i
            End If
        Next
    End Sub

    Private Function GetHeader0(ByVal Input As String, ByVal lastColonIndex As Integer, ByVal braceOrBracketIndex As Integer) As String
        Dim TextoSalida As String = ""
        Dim Comillas As String = """"

        For i As Integer = braceOrBracketIndex - 1 To 0 Step -1
            Try
                If Input(i) = ":" AndAlso i = lastColonIndex Then
                    ' Si se encuentra un ":" en el mismo índice que lastColonIndex, salimos del bucle
                    Exit For
                ElseIf Input(i) = Comillas Then
                    ' Se encontró una comilla, se toma el contenido entre comillas como el nombre del nodo
                    TextoSalida = Input.Substring(i + 1, braceOrBracketIndex - i - 1).Trim()
                    Exit For
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
        Return TextoSalida
    End Function
End Class

Public Class Class_JsonEstructura2
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

    Public Property BracketsList As New List(Of Class_JsonEstructura2)
    Public Property BracesList As New List(Of Class_JsonEstructura2)

    Private Sub GetNodes(ByRef Input As String)

        Dim bracesCount As Integer = 0
        Dim bracketsCount As Integer = 0
        Dim bracesStartIndex As Integer = 0
        Dim bracketsStartIndex As Integer = 0
        Dim lastColonIndex As Integer = 0

        For i As Integer = 0 To Input.Length - 1

            If bracketsCount > 1 Or bracesCount > 1 Then
                ContainsHijos = True
            End If

            If Input(i) = "{" And BracesOrBrackets = "" Then
                BracesOrBrackets = "Braces"
                bracesCount += 1
                bracesStartIndex = i

            ElseIf Input(i) = "[" And BracesOrBrackets = "" Then
                BracesOrBrackets = "Brackets"
                bracketsCount += 1
                bracketsStartIndex = i

            ElseIf Input(i) = "}" And BracesOrBrackets = "Braces" Then
                bracesCount -= 1
                If bracesCount = 0 Then
                    Dim node As New Class_JsonEstructura2()
                    node.StringValue = Input.Substring(bracesStartIndex + 1, i - bracesStartIndex - 1)
                    node.BracesOrBrackets = "Braces"





                    Dim PosibleHead As String = ""
                    Try
                        PosibleHead = Mid(Input, lastColonIndex + 1, bracesStartIndex - lastColonIndex)
                    Catch ex As Exception

                    End Try
                    node.Header = GetHeader0(PosibleHead)
                    BracesList.Add(node)


                    bracesStartIndex = -1
                    lastColonIndex = i


                End If
            ElseIf Input(i) = "]" And BracesOrBrackets = "Brackets" Then
                bracketsCount -= 1
                If bracketsCount = 0 Then
                    Dim node As New Class_JsonEstructura2()
                    node.StringValue = Input.Substring(bracketsStartIndex + 1, i - bracketsStartIndex - 1)
                    node.BracesOrBrackets = "Brackets"






                    Dim PosibleHead As String = ""
                    Try
                        PosibleHead = Mid(Input, lastColonIndex + 1, bracesStartIndex - lastColonIndex)
                    Catch ex As Exception

                    End Try
                    node.Header = GetHeader0(PosibleHead)

                    BracketsList.Add(node)

                    bracketsStartIndex = -1
                    lastColonIndex = i


                End If
            ElseIf Input(i) = ":" Then
                ' lastColonIndex = i
            End If

        Next

    End Sub


    Private Function GetHeader0(ByRef Input As String) As String
        Dim TextoSalida As String = ""
        Dim lastColonIndex As Integer = -1
        Dim Comillas As String = """"
        Dim Puntos As Boolean = False
        Dim PosFinal As Boolean = False
        For i As Integer = Input.Length - 1 To 0 Step -1

            Try
                If Input(i) = ":" AndAlso lastColonIndex = -1 Then
                    lastColonIndex = i
                    Puntos = True
                ElseIf Input(i) = Comillas AndAlso lastColonIndex <> -1 Then
                    If Puntos = True And PosFinal = False Then
                        lastColonIndex = i
                        PosFinal = True

                    ElseIf PosFinal = True Then
                        TextoSalida = Input.Substring(i + 1, lastColonIndex - i - 1).Trim()
                        Exit For
                    End If

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next


        Return TextoSalida
    End Function


End Class




Public Class Class_JsonEstructuraOkSemi
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

    Public Property BracketsList As New List(Of Class_JsonEstructuraOkSemi)
    Public Property BracesList As New List(Of Class_JsonEstructuraOkSemi)

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

                        'Dim PosibleHead As String = ""
                        'Try
                        '    PosibleHead = Mid(Input, lastColonIndex + 1, bracesStartIndex - lastColonIndex)
                        'Catch ex As Exception

                        'End Try

                        'Header = GetHeader(PosibleHead)

                    End If
                End If
            ElseIf Input(i) = "[" Then
                bracketsCount += 1
                If bracketsStartIndex = -1 Then
                    bracketsStartIndex = i
                    If lastColonIndex <> -1 Then


                        'Dim PosibleHead As String = ""
                        'Try
                        '    PosibleHead = Mid(Input, lastColonIndex + 1, bracketsStartIndex - lastColonIndex)
                        'Catch ex As Exception

                        'End Try

                        'Header = GetHeader(PosibleHead)

                    End If
                End If
            ElseIf Input(i) = "}" Then
                bracesCount -= 1
                If bracesCount = 0 Then
                    Dim node As New Class_JsonEstructuraOkSemi()
                    node.StringValue = Input.Substring(bracesStartIndex + 1, i - bracesStartIndex - 1)
                    node.BracesOrBrackets = "Braces"





                    Dim PosibleHead As String = ""
                    Try
                        PosibleHead = Mid(Input, lastColonIndex + 1, bracesStartIndex - lastColonIndex)
                    Catch ex As Exception

                    End Try
                    node.Header = GetHeader0(PosibleHead)
                    BracesList.Add(node)


                    bracesStartIndex = -1
                    lastColonIndex = i


                End If
            ElseIf Input(i) = "]" Then
                bracketsCount -= 1
                If bracketsCount = 0 Then
                    Dim node As New Class_JsonEstructuraOkSemi()
                    node.StringValue = Input.Substring(bracketsStartIndex + 1, i - bracketsStartIndex - 1)
                    node.BracesOrBrackets = "Brackets"






                    Dim PosibleHead As String = ""
                    Try
                        PosibleHead = Mid(Input, lastColonIndex + 1, bracesStartIndex - lastColonIndex)
                    Catch ex As Exception

                    End Try
                    node.Header = GetHeader0(PosibleHead)

                    BracketsList.Add(node)

                    bracketsStartIndex = -1
                    lastColonIndex = i


                End If
            ElseIf Input(i) = ":" Then
                ' lastColonIndex = i
            End If

        Next

    End Sub


    Private Function GetHeader(ByRef Input As String) As String
        Dim TextoSalida As String = ""
        Dim lastColonIndex As Integer = -1
        Dim puntos As Boolean = False
        Dim comillasAbiertas As Integer = 0
        Dim comillasCerradas As Integer = 0

        For i As Integer = 0 To Input.Length - 1
            If Input(i) = ":" Then
                lastColonIndex = i
                puntos = True
            ElseIf Input(i) = "\""" Then
                If puntos Then
                    If comillasAbiertas = comillasCerradas Then
                        TextoSalida = Input.Substring(lastColonIndex + 1, i - lastColonIndex - 1).Trim()
                        Exit For
                    End If
                End If

                If comillasAbiertas = 0 Then
                    comillasAbiertas += 1
                Else
                    comillasCerradas += 1
                End If
            End If
        Next

        Return TextoSalida
    End Function

    Private Function GetHeader0(ByRef Input As String) As String
        Dim TextoSalida As String = ""
        Dim lastColonIndex As Integer = -1
        Dim Comillas As String = """"
        Dim Puntos As Boolean = False
        Dim PosFinal As Boolean = False
        For i As Integer = Input.Length - 1 To 0 Step -1

            Try
                If Input(i) = ":" AndAlso lastColonIndex = -1 Then
                    lastColonIndex = i
                    Puntos = True
                ElseIf Input(i) = Comillas AndAlso lastColonIndex <> -1 Then
                    If Puntos = True And PosFinal = False Then
                        lastColonIndex = i
                        PosFinal = True

                    ElseIf PosFinal = True Then
                        TextoSalida = Input.Substring(i + 1, lastColonIndex - i - 1).Trim()
                        Exit For
                    End If

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next


        Return TextoSalida
    End Function


End Class












Public Class Class_JsonEstructura3Alfa
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

    Public Property BracketsList As New List(Of Class_JsonEstructura3Alfa)
    Public Property BracesList As New List(Of Class_JsonEstructura3Alfa)

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


            If Input(i) = "{" And BracesOrBrackets = "" Then
                BracesOrBrackets = "Braces"
                bracesCount += 1
                If bracesStartIndex = -1 Then
                    bracesStartIndex = i
                    If lastColonIndex <> -1 Then
                        Dim Inicio As UInteger = (lastColonIndex + 1)
                        Dim Fin As UInteger = i
                        Header = Input.Substring(lastColonIndex + 1, bracesStartIndex - lastColonIndex - 1).Trim()
                        Header = GetHeader(Mid(Input, lastColonIndex + 1, bracesStartIndex - lastColonIndex)) 'GetHeader(Mid(Input, lastColonIndex - (Fin), bracesStartIndex))
                    End If
                End If
            ElseIf Input(i) = "[" And BracesOrBrackets = "" Then
                BracesOrBrackets = "Brackets"
                bracketsCount += 1
                If bracketsStartIndex = -1 Then
                    bracketsStartIndex = i
                    If lastColonIndex <> -1 Then
                        Dim Inicio As UInteger = (lastColonIndex + 1)
                        Dim Fin As UInteger = (bracketsStartIndex - lastColonIndex - 1)
                        Header = Input.Substring(lastColonIndex + 1, bracketsStartIndex - lastColonIndex - 1).Trim()
                        'Header = GetHeader(Mid(Input, lastColonIndex - (Fin), bracketsStartIndex))
                        Header = GetHeader(Mid(Input, lastColonIndex + 1, bracketsStartIndex - lastColonIndex))
                    End If
                End If
            ElseIf Input(i) = "}" And BracesOrBrackets = "Braces" Then
                bracesCount -= 1
                If bracesCount = 0 Then
                    Dim node As New Class_JsonEstructura3Alfa()
                    node.StringValue = Input.Substring(bracesStartIndex + 1, i - bracesStartIndex - 1)
                    node.BracesOrBrackets = "Braces"
                    BracesList.Add(node)
                    bracesStartIndex = -1
                    lastColonIndex = i
                End If
            ElseIf Input(i) = "]" And BracesOrBrackets = "Brackets" Then
                bracketsCount -= 1
                If bracketsCount = 0 Then
                    Dim node As New Class_JsonEstructura3Alfa()
                    node.StringValue = Input.Substring(bracketsStartIndex + 1, i - bracketsStartIndex - 1)
                    node.BracesOrBrackets = "Brackets"
                    BracketsList.Add(node)
                    bracketsStartIndex = -1
                    lastColonIndex = i
                End If
            ElseIf Input(i) = ":" Then
                ' lastColonIndex = i
            End If

        Next

    End Sub



    Private Function GetHeader(ByRef Input As String)
        Dim TextoSalida As String = ""
        Dim lastColonIndex As Integer = -1
        Dim Comillas As String = """"
        Dim Puntos As Boolean = False
        Dim PosFinal As Boolean = False
        For i As Integer = Input.Length - 1 To 0 Step -1

            Try
                If Input(i) = ":" AndAlso lastColonIndex = -1 Then
                    lastColonIndex = i
                    Puntos = True
                ElseIf Input(i) = Comillas AndAlso lastColonIndex <> -1 Then
                    If Puntos = True And PosFinal = False Then
                        lastColonIndex = i
                        PosFinal = True

                    ElseIf PosFinal = True Then
                        TextoSalida = Input.Substring(i + 1, lastColonIndex - i - 1).Trim()
                        Exit For
                    End If

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next


        Return TextoSalida
    End Function


End Class







Public Class Class_JsonEstructura1
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

    Public Property BracketsList As New List(Of Class_JsonEstructura1)
    Public Property BracesList As New List(Of Class_JsonEstructura1)

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
                        Dim Inicio As UInteger = (lastColonIndex + 1)
                        Dim Fin As UInteger = i
                        Header = Input.Substring(lastColonIndex + 1, bracesStartIndex - lastColonIndex - 1).Trim()
                        Header = GetHeader(Mid(Input, lastColonIndex + 1, bracesStartIndex - lastColonIndex)) 'GetHeader(Mid(Input, lastColonIndex - (Fin), bracesStartIndex))
                    End If
                End If
            ElseIf Input(i) = "[" Then
                bracketsCount += 1
                If bracketsStartIndex = -1 Then
                    bracketsStartIndex = i
                    If lastColonIndex <> -1 Then
                        Dim Inicio As UInteger = (lastColonIndex + 1)
                        Dim Fin As UInteger = (bracketsStartIndex - lastColonIndex - 1)
                        Header = Input.Substring(lastColonIndex + 1, bracketsStartIndex - lastColonIndex - 1).Trim()
                        'Header = GetHeader(Mid(Input, lastColonIndex - (Fin), bracketsStartIndex))
                        Header = GetHeader(Mid(Input, lastColonIndex + 1, bracketsStartIndex - lastColonIndex))
                    End If
                End If
            ElseIf Input(i) = "}" Then
                bracesCount -= 1
                If bracesCount = 0 Then
                    Dim node As New Class_JsonEstructura1()
                    node.StringValue = Input.Substring(bracesStartIndex + 1, i - bracesStartIndex - 1)
                    node.BracesOrBrackets = "Braces"
                    BracesList.Add(node)
                    bracesStartIndex = -1
                    lastColonIndex = i
                End If
            ElseIf Input(i) = "]" Then
                bracketsCount -= 1
                If bracketsCount = 0 Then
                    Dim node As New Class_JsonEstructura1()
                    node.StringValue = Input.Substring(bracketsStartIndex + 1, i - bracketsStartIndex - 1)
                    node.BracesOrBrackets = "Brackets"
                    BracketsList.Add(node)
                    bracketsStartIndex = -1
                    lastColonIndex = i
                End If
            ElseIf Input(i) = ":" Then
                ' lastColonIndex = i
            End If

        Next

    End Sub



    Private Function GetHeader(ByRef Input As String)
        Dim TextoSalida As String = ""
        Dim lastColonIndex As Integer = -1
        Dim Comillas As String = """"
        Dim Puntos As Boolean = False
        Dim PosFinal As Boolean = False
        For i As Integer = Input.Length - 1 To 0 Step -1

            Try
                If Input(i) = ":" AndAlso lastColonIndex = -1 Then
                    lastColonIndex = i
                    Puntos = True
                ElseIf Input(i) = Comillas AndAlso lastColonIndex <> -1 Then
                    If Puntos = True And PosFinal = False Then
                        lastColonIndex = i
                        PosFinal = True

                    ElseIf PosFinal = True Then
                        TextoSalida = Input.Substring(i + 1, lastColonIndex - i - 1).Trim()
                        Exit For
                    End If

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next


        Return TextoSalida
    End Function


End Class





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


    Private Function GetHeader(ByRef Input As String)
        Dim TextoSalida As String = ""
        Dim lastColonIndex As Integer = -1
        For i As Integer = Input.Length - 1 To 0 Step -1


            If Input(i) = ":" AndAlso lastColonIndex = -1 Then
                lastColonIndex = i
            ElseIf Input(i) = """" AndAlso lastColonIndex <> -1 Then
                TextoSalida = Input.Substring(i + 1, lastColonIndex - i - 1).Trim()
                Exit For
            End If
        Next
        Return TextoSalida
    End Function



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
                lastColonIndex = i
            End If

        Next

    End Sub

End Class











