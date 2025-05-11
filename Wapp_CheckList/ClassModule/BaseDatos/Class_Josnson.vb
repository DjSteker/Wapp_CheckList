
Imports System.IO

Namespace JsonReader
    Public Class JsonDocument
        Private m_docString As String
        Private m_paranthesis As Stack(Of Char)
        Private m_bracket As Stack(Of Char)

        Public Sub LoadDocument(fileName As String)
            Dim file As New StreamReader(fileName)

            Dim ch As Char
            While file.Peek() >= 0
                ch = ChrW(file.Read())

                If ch <> " " AndAlso ch <> vbTab AndAlso ch <> vbLf AndAlso ch <> """" Then
                    m_docString &= ch
                End If
            End While

            file.Close()

            Dim Validity_Check As Boolean = (m_docString(m_docString.Length - 1) = ChrW(AscW(m_docString(0)) + 2))
            'custom assert
            If Not Validity_Check Then
                Console.WriteLine("Assertion Failed.... Invalid Json Bracket Mismatch!")
                Environment.Exit(0)
            End If
        End Sub

        'returns root of JsonItem*
        Public Function Parse() As JsonItem
            Dim root As JsonItem

            If m_docString(0) = "{"c Then
                root = New JsonObjectItem()
            Else
                root = New JsonArrayItem()
            End If

            root = Value()

            Return root
        End Function

        Public Function [Object]() As JsonItem
            Dim parentObject As New JsonObjectItem()
            Dim tempObj As New JsonObjectItem()

            While m_docString.Length > 0
                Dim ch As Char = m_docString(0)
                m_docString = m_docString.Remove(0, 1)

                Select Case ch
                    Case "{"c
                        If m_docString(0) = "}"c Then
                            Return Nothing
                        End If
                        tempObj = New JsonObjectItem()
                        m_paranthesis.Push(ch)
                        tempObj = Pair()
                    Case "}"c
                        If m_paranthesis.Peek() = "{"c Then
                            m_paranthesis.Pop()
                            parentObject = tempObj 'fixed from parentobject.addchild();
                            Return parentObject
                        Else
                            Console.WriteLine("Assertion Failed.... Invalid Json ' { ' or ' } ' Expected.")
                            Environment.Exit(0)
                        End If
                    Case ","c
                        tempObj = [Object]()
                        parentObject.AddChild(tempObj)
                    Case Else
                        Console.WriteLine("Assertion Failed....Invalid Json' { ' or ' } ' Expected.")
                        Environment.Exit(0)
                End Select
            End While
        End Function

        Public Function Pair() As JsonItem
            Dim parentPairList As New JsonObjectItem()

            Dim keystr As String = ""

            While m_docString.Length > 0
                Dim ch As Char = m_docString(0)

                Select Case ch
                    Case ":"c
                        m_docString = m_docString.Remove(0, 1)
                        Dim tempPair As JsonItem = Value()
                        tempPair.m_key = keystr
                        parentPairList.AddChild(tempPair)

                        keystr = ""
                    Case "}"c
                        Return parentPairList
                    Case ","c
                        m_docString = m_docString.Remove(0, 1)
                    Case Else
                        m_docString = m_docString.Remove(0, 1)
                        keystr &= ch
                End Select
            End While
        End Function

        Public Function [Array]() As JsonItem
            Dim arrayItem As New JsonArrayItem()
            Dim tempItem As New JsonObjectItem()

            While m_docString.Length > 0
                Dim ch As Char = m_docString(0)

                Select Case ch
                    Case "["c
                        m_docString = m_docString.Remove(0, 1)
                        If m_docString(0) = "]"c Then
                            Return Nothing
                        End If

                        m_bracket.Push(ch)

                        If m_docString(0) = "{"c Then
                            tempItem = New JsonObjectItem()
                            tempItem = [Object]()
                            Return tempItem
                        ElseIf m_docString(0) = "["c Then
                            arrayItem = New JsonArrayItem()
                            arrayItem = [Array]()
                            Return arrayItem
                        Else
                            tempItem.AddChild(Value())
                        End If
                    Case "]"c
                        m_docString = m_docString.Remove(0, 1)
                        If m_bracket.Peek() = "["c Then
                            m_bracket.Pop()
                            'arrayItem = tempItem
                            Return arrayItem
                        Else
                            Console.WriteLine("Assertion Failed.... Invalid Json ' [ ' or ' ] ' Expected.")
                            Environment.Exit(0)
                        End If
                    Case Else
                        tempItem.AddChild(Value())
                End Select
            End While
        End Function

        Public Function Value() As JsonItem
            Dim parentVal As JsonItem
            Dim valuestr As String = ""

            While m_docString.Length > 0
                Dim ch As Char = m_docString(0)

                Select Case ch
                    Case "{"c
                        parentVal = [Object]()
                        Return parentVal
                    Case "["c
                        parentVal = [Array]()
                        Return parentVal
                    Case ","c
                        m_docString = m_docString.Remove(0, 1)
                        Dim tempstr As String = valuestr 'Type.typeof(valuestr)

                        If tempstr = "String" Then
                            Dim item As New JsonStringItem(valuestr)
                            Return item
                        ElseIf tempstr = "Integer" Then
                            Dim item As New JsonIntItem(valuestr)
                            Return item
                        ElseIf tempstr = "Double" Then
                            Dim item As New JsonDoubleItem(valuestr)
                            Return item
                        ElseIf tempstr = "Bool" Then
                            Dim item As New JsonBoolItem(valuestr)
                            Return item
                        End If
                    Case "}"c
                        Dim tempstr As String = valuestr ' Type.typeof(valuestr)

                        If tempstr = "String" Then
                            Dim item As New JsonStringItem(valuestr)
                            Return item
                        ElseIf tempstr = "Integer" Then
                            Dim item As New JsonIntItem(valuestr)
                            Return item
                        ElseIf tempstr = "Double" Then
                            Dim item As New JsonDoubleItem(valuestr)
                            Return item
                        ElseIf tempstr = "Bool" Then
                            Dim item As New JsonBoolItem(valuestr)
                            Return item
                        End If
                    Case "]"c
                        Dim tempstr As String = valuestr 'Type.typeof(valuestr)

                        If tempstr = "String" Then
                            Dim item As New JsonStringItem(valuestr)
                            Return item
                        ElseIf tempstr = "Integer" Then
                            Dim item As New JsonIntItem(valuestr)
                            Return item
                        ElseIf tempstr = "Double" Then
                            Dim item As New JsonDoubleItem(valuestr)
                            Return item
                        ElseIf tempstr = "Bool" Then
                            Dim item As New JsonBoolItem(valuestr)
                            Return item
                        End If
                    Case Else
                        m_docString = m_docString.Remove(0, 1)
                        valuestr &= ch
                End Select
            End While
        End Function
    End Class

    Public Class JsonItem
        Public m_key As String

        Public Overridable Sub AddChild(child As JsonItem)
        End Sub
    End Class

    Public Class JsonObjectItem
        Inherits JsonItem
        Private m_children As List(Of JsonItem)

        Public Sub New()
            m_children = New List(Of JsonItem)()
        End Sub

        Public Overrides Sub AddChild(child As JsonItem)
            m_children.Add(child)
        End Sub
    End Class

    Public Class JsonArrayItem
        Inherits JsonItem
        Private m_children As List(Of JsonItem)

        Public Sub New()
            m_children = New List(Of JsonItem)()
        End Sub

        Public Overrides Sub AddChild(child As JsonItem)
            m_children.Add(child)
        End Sub
    End Class

    Public Class JsonStringItem
        Inherits JsonItem
        Private m_value As String

        Public Sub New(value As String)
            m_value = value
        End Sub
    End Class

    Public Class JsonIntItem
        Inherits JsonItem
        Private m_value As Integer

        Public Sub New(value As String)
            m_value = Integer.Parse(value)
        End Sub
    End Class

    Public Class JsonDoubleItem
        Inherits JsonItem
        Private m_value As Double

        Public Sub New(value As String)
            m_value = Double.Parse(value)
        End Sub
    End Class

    Public Class JsonBoolItem
        Inherits JsonItem
        Private m_value As Boolean

        Public Sub New(value As String)
            m_value = Boolean.Parse(value)
        End Sub
    End Class
End Namespace
