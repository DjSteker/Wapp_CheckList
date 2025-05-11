Public Class Class_Generador128_Beta

#Region " Obtener Caracter de control "
    ''' <summary>
    ''' Obtiene el indice del caracter de control
    ''' </summary>
    ''' <param name="Start_Code">Typo de de variable (del Code128) de inicio: 1 para Start A, 2 para Start B, 3 para Start C.</param>
    ''' <param name="ByVal_CadebaTexto">Cadena de texto del codigo de barras</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function Obtener_CaracterControl_Indice(ByVal Start_Code As String, ByVal ByVal_CadebaTexto As String)
        Dim CadenaSalida As String
        Dim Suma As Long
        Dim SumaDeControles As Long = 0
        Dim Variable128 As Int16 = 0
        Dim Variable128_Suguiente As Int16 = 0
        Dim CaracteresCantidad As Int16 = 1
        Dim ShiftOn As Boolean = False
        Dim FNC4On As Boolean = False
        Dim FNC4Bloqueo As Boolean = False
        Dim IndiceCadenaX As Long = 1
        Dim CaracteresInicio = 1
        Dim CaracterComando As Boolean = False
        Try
            Dim aaaa As String = Mid$(ByVal_CadebaTexto, 1, 7)
            Select Case aaaa
                Case "Start A"
                    Start_Code = eCode128Type.eCode128_CodeSetA
                    ByVal_CadebaTexto = Replace(ByVal_CadebaTexto, "Start A", "")
                    '  CaracteresInicio = 7
                Case "Start B"
                    Start_Code = eCode128Type.eCode128_CodeSetB
                    ByVal_CadebaTexto = Replace(ByVal_CadebaTexto, "Start B", "")
                    ' CaracteresInicio = 7
                Case "Start C"
                    Start_Code = eCode128Type.eCode128_CodeSetC
                    ByVal_CadebaTexto = Replace(ByVal_CadebaTexto, "Start C", "")
                    ' CaracteresInicio = 7
            End Select
        Catch ex As Exception

        End Try

        'AddEntry(103, "Start A", "Start A", "Start A", "2 1 1 4 1 2")
        'AddEntry(104, "Start B", "Start B", "Start B", "2 1 1 2 1 4")
        'AddEntry(105, "Start C", "Start C", "Start C", "2 1 1 2 3 2")


        Select Case Start_Code
            Case eCode128Type.eCode128_CodeSetA
                Suma = 103 : Variable128 = 1 : Variable128_Suguiente = 1
            Case eCode128Type.eCode128_CodeSetB
                Suma = 104 : Variable128 = 2 : Variable128_Suguiente = 2
            Case eCode128Type.eCode128_CodeSetC
                Suma = 105 : Variable128 = 3 : Variable128_Suguiente = 3
                CaracteresCantidad = 2
        End Select



        'AddEntry(96, "FNC 3", "FNC 3", "96", "1 1 4 3 1 1")
        'AddEntry(97, "FNC 2", "FNC 2", "97", "4 1 1 1 1 3")
        'AddEntry(98, "SHIFT", "SHIFT", "98", "4 1 1 3 1 1")
        'AddEntry(99, "CODE C", "CODE C", "99", "1 1 3 1 4 1")
        'AddEntry(100, "CODE B", "FNC 4", "CODE B", "1 1 4 1 3 1")
        'AddEntry(101, "FNC 4", "CODE A", "CODE A", "3 1 1 1 4 1")
        'AddEntry(102, "FNC 1", "FNC 1", "FNC 1", "4 1 1 1 3 1")
        'AddEntry(103, "Start A", "Start A", "Start A", "2 1 1 4 1 2")
        'AddEntry(104, "Start B", "Start B", "Start B", "2 1 1 2 1 4")
        'AddEntry(105, "Start C", "Start C", "Start C", "2 1 1 2 3 2")
        'AddEntry(106, "Stop", "Stop", "Stop", "2 3 3 1 1 1 2")

        For IndiceCadenaX = CaracteresInicio To ByVal_CadebaTexto.Length
            Dim Caracter As String = String.Empty
            Dim aaaaa As String = Mid$(ByVal_CadebaTexto, IndiceCadenaX, 6)

            If Mid$(ByVal_CadebaTexto, IndiceCadenaX, 6) = "CODE A" Then
                Caracter = "CODE A"
                CaracteresCantidad = 1
                Variable128_Suguiente = 1
                IndiceCadenaX = IndiceCadenaX + 5
                SumaDeControles = SumaDeControles + 5
                CaracterComando = True
            ElseIf Mid$(ByVal_CadebaTexto, IndiceCadenaX, 6) = "CODE B" Then
                Caracter = "CODE B"
                CaracteresCantidad = 1
                IndiceCadenaX = IndiceCadenaX + 5
                Variable128_Suguiente = 2
                SumaDeControles = SumaDeControles + 5
                CaracterComando = True
            ElseIf Mid$(ByVal_CadebaTexto, IndiceCadenaX, 6) = "CODE C" Then
                Caracter = "CODE C"
                CaracteresCantidad = 2
                IndiceCadenaX = IndiceCadenaX + 5
                Variable128_Suguiente = 3
                SumaDeControles = SumaDeControles + 5
                CaracterComando = True
            ElseIf Mid$(ByVal_CadebaTexto, IndiceCadenaX, 5) = "FNC 1" Then
                Caracter = "FNC 1"
                '  CaracteresCantidad = 1
                SumaDeControles = SumaDeControles + 4
                IndiceCadenaX = IndiceCadenaX + 4
                CaracterComando = True
            ElseIf Mid$(ByVal_CadebaTexto, IndiceCadenaX, 5) = "FNC 2" Then
                Caracter = "FNC 2"
                ' CaracteresCantidad = 1
                SumaDeControles = SumaDeControles + 4
                IndiceCadenaX = IndiceCadenaX + 4
                CaracterComando = True
            ElseIf Mid$(ByVal_CadebaTexto, IndiceCadenaX, 5) = "FNC 3" Then
                Caracter = "FNC 3"
                CaracteresCantidad = 1
                SumaDeControles = SumaDeControles + 4
                IndiceCadenaX = IndiceCadenaX + 4
                CaracterComando = True
            ElseIf Mid$(ByVal_CadebaTexto, IndiceCadenaX, 5) = "FNC 4" Then
                Caracter = "FNC 4"
                If FNC4Bloqueo = False And FNC4On = False Then : FNC4On = True
                ElseIf FNC4Bloqueo = False And FNC4On = True Then : FNC4Bloqueo = True
                ElseIf FNC4Bloqueo = True And FNC4On = True Then : FNC4Bloqueo = False : FNC4On = False
                Else : MsgBox("FNC 4", MsgBoxStyle.Critical)
                End If
                CaracteresCantidad = 1
                SumaDeControles = SumaDeControles + 4
                IndiceCadenaX = IndiceCadenaX + 4
                CaracterComando = True
            ElseIf Mid$(ByVal_CadebaTexto, IndiceCadenaX, 5) = "SHIFT" And Variable128 = 1 Then
                Caracter = "SHIFT"
                CaracteresCantidad = 1
                Variable128_Suguiente = 2
                ShiftOn = True
                SumaDeControles = SumaDeControles + 4
                IndiceCadenaX = IndiceCadenaX + 4
                CaracterComando = True
            ElseIf Mid$(ByVal_CadebaTexto, IndiceCadenaX, 5) = "SHIFT" And Variable128 = 2 Then
                Caracter = "SHIFT"
                CaracteresCantidad = 1
                Variable128_Suguiente = 1
                ShiftOn = True
                SumaDeControles = SumaDeControles + 4
                IndiceCadenaX = IndiceCadenaX + 4
                CaracterComando = True
            ElseIf Mid$(ByVal_CadebaTexto, IndiceCadenaX, 5) = "SHIFT" And Variable128 = 3 Then
                MsgBox("Error en los codigos de control")
            Else
                Caracter = Mid$(ByVal_CadebaTexto, IndiceCadenaX, CaracteresCantidad)  '  ByVal_CadebaTexto.ToString.
                SumaDeControles = SumaDeControles + (CaracteresCantidad - 1)
                IndiceCadenaX = IndiceCadenaX + (CaracteresCantidad - 1)
                CaracterComando = False
            End If
            Select Case Variable128
                Case 1
                    If FNC4On = True Then
                        Suma = Suma + (ObtenerIndiceCaracterAscii(Caracter) * (IndiceCadenaX - SumaDeControles))
                        If FNC4Bloqueo = False Then : FNC4On = False : End If
                    Else
                        Suma = Suma + (ObtenerIndiceCaracterA(Caracter) * (IndiceCadenaX - SumaDeControles))
                    End If
                Case 2
                    If FNC4On = True Then
                        Suma = Suma + (ObtenerIndiceCaracterAscii(Caracter) * (IndiceCadenaX - SumaDeControles))
                        If FNC4Bloqueo = False Then : FNC4On = False : End If
                    Else
                        Suma = Suma + (ObtenerIndiceCaracterB(Caracter) * (IndiceCadenaX - SumaDeControles))
                    End If
                Case 3
                    If Caracter.Length = 2 And (Variable128_Suguiente = 3) Then
                        Dim Betas As Integer = (ObtenerIndiceCaracterC(Caracter) * (IndiceCadenaX - SumaDeControles))
                        Suma = Suma + (ObtenerIndiceCaracterC(Caracter) * (IndiceCadenaX - SumaDeControles))
                        '    SumaDeControles = SumaDeControles + 1
                    ElseIf Variable128_Suguiente <> 3 Then
                        Suma = Suma + (ObtenerIndiceCaracterC(Caracter) * (IndiceCadenaX - SumaDeControles))
                    ElseIf CaracterComando = True Then
                        Suma = Suma + (ObtenerIndiceCaracterC(Caracter) * (IndiceCadenaX - (SumaDeControles)))
                    Else
                        MsgBox("Error. La variable C (del tipo Code 128) necesita valore un carateres pares. " & vbCr & "Puede añadir un caracter de control Code A o Code B para excluer un carater en este tipo para adecuar la cadena")
                    End If

            End Select
            If (Variable128_Suguiente <> Variable128) Then
                If ShiftOn = True Then
                    If Variable128 = 1 Then
                        Variable128 = 2
                        Variable128_Suguiente = 1
                        ShiftOn = False
                    Else
                        Variable128 = 1
                        Variable128_Suguiente = 2
                        ShiftOn = False
                    End If
                Else
                    Variable128 = Variable128_Suguiente
                End If
            End If
            'Select Case Variable128

            '    Case 1 Or 2
            '        Suma = Suma + (ObtenerIndiceCaracterA(Caracter) * IndiceCadenaX)
            '    Case 3
            '        Suma = Suma + (ObtenerIndiceCaracterC(Caracter) * IndiceCadenaX)
            'End Select

        Next






        'If Start_Code = eCode128Type.eCode128_CodeSetA Then
        '    Suma = 103 : Variable128 = 1
        '    For IndiceCadenaA As Long = 1 To ByVal_CadebaTexto.Length
        '        'SHIFT
        '        Dim Caracter As String = Mid$(ByVal_CadebaTexto, IndiceCadenaA, 1)  '  ByVal_CadebaTexto.ToString.
        '        Suma = Suma + (ObtenerIndiceCaracterA(Caracter) * IndiceCadenaA)

        '    Next
        'ElseIf Start_Code = eCode128Type.eCode128_CodeSetB Then
        '    Suma = 104 : Variable128 = 2
        '    For IndiceCadenaB As Long = 1 To ByVal_CadebaTexto.Length
        '        Dim Caracter As String = Mid$(ByVal_CadebaTexto, IndiceCadenaB, 1)  '  ByVal_CadebaTexto.ToString.
        '        Suma = Suma + (ObtenerIndiceCaracterB(Caracter) * IndiceCadenaB)
        '    Next
        'ElseIf Start_Code = eCode128Type.eCode128_CodeSetC Then
        '    Suma = 105 : Variable128 = 3

        '    For IndiceCadenaC As Long = 1 To ByVal_CadebaTexto.Length

        '        Dim Caracter As String
        '        If Mid$(ByVal_CadebaTexto, IndiceCadenaC, 6) = "Code B" Then
        '            ' Caracter = "Code B"  '  ByVal_CadebaTexto.ToString.
        '            ObtenerIndiceCaracterC("Code B")
        '            Variable128 = 2
        '        ElseIf Mid$(ByVal_CadebaTexto, IndiceCadenaC, 6) = "Code A" Then
        '            ' Caracter = "Code A"  '  ByVal_CadebaTexto.ToString.
        '            ObtenerIndiceCaracterC("Code A")
        '            Variable128 = 1
        '        ElseIf Mid$(ByVal_CadebaTexto, IndiceCadenaC, 5) = "FNC 1" Then
        '            ' Caracter = "FNC 1"
        '            Caracter = ObtenerIndiceCaracterC("FNC 1")
        '        Else
        '            Caracter = Mid$(ByVal_CadebaTexto, IndiceCadenaC, 1)  '  ByVal_CadebaTexto.ToString.
        '        End If
        '        Suma = Suma + (Caracter * IndiceCadenaC)

        '        Select Case Variable128

        '            Case 1

        '            Case 2

        '            Case 3

        '        End Select



        '    Next
        'Else
        '    MsgBox("Error no se a seleccionado un TIPO DE CODIFICADO valido " & vbCr & " Solo se admite las variables de Code128: A, B y C.")
        'End If

        'For IndiceCadena As Long = 1 To ByVal_CadebaTexto.Length

        '    Dim Caracter As String = Mid$(ByVal_CadebaTexto, IndiceCadena, 1)  '  ByVal_CadebaTexto.ToString.
        '    Suma = Suma + (ObtenerIndiceCaracterA(Caracter) * IndiceCadena)

        'Next

        CadenaSalida = CInt((Suma Mod 103))

        Return CadenaSalida
    End Function

    Private Function ObtenerIndiceCaracterA(ByVal Caracter As String) As Int32
        Dim IndiceSalida As Int32
        Dim Encontrado As Boolean = False
        For Each CaraterInList As tCode In CodeArr
            If Caracter = CaraterInList.ASet Then
                Encontrado = True
                IndiceSalida = CaraterInList.Indice : Exit For  ' CodeArr(K).ASet Then Exit For
            End If

        Next
        If Encontrado = False Then
            IndiceSalida = -1
        End If


        Return IndiceSalida
    End Function
    Private Function ObtenerIndiceCaracterB(ByVal Caracter As String) As Int32
        Dim IndiceSalida As Int32
        Dim Encontrado As Boolean = False
        For Each CaraterInList As tCode In CodeArr
            If Caracter = CaraterInList.BSet Then
                Encontrado = True
                IndiceSalida = CaraterInList.Indice : Exit For  ' CodeArr(K).ASet Then Exit For
            End If

        Next
        If Encontrado = False Then
            IndiceSalida = -1
        End If


        Return IndiceSalida
    End Function
    Private Function ObtenerIndiceCaracterC(ByVal Caracter As String) As Int32
        Dim IndiceSalida As Int32
        Dim Encontrado As Boolean = False
        For Each CaraterInList As tCode In CodeArr
            If Caracter = CaraterInList.CSet Then
                Encontrado = True
                IndiceSalida = CaraterInList.Indice : Exit For  ' CodeArr(K).ASet Then Exit For
            End If

        Next
        If Encontrado = False Then
            IndiceSalida = -1
        End If


        Return IndiceSalida
    End Function
    Private Function ObtenerIndiceCaracterAscii(ByVal Caracter As String) As Int32
        Dim IndiceSalida As Int32
        Dim Encontrado As Boolean = False
        For Each CaraterInList As tCode In CodeArr
            If Caracter = CaraterInList.Ascii Then
                Encontrado = True
                IndiceSalida = CaraterInList.Indice : Exit For  ' CodeArr(K).ASet Then Exit For
            End If

        Next
        If Encontrado = False Then
            IndiceSalida = -1
        End If


        Return IndiceSalida
    End Function
#End Region

#Region "Obtener Indices de los caracteres"
    Private Function ObtenerCaracterAscii_Ancho(ByVal Caracter As String) As String
        Dim IndiceSalida As String = String.Empty
        Dim Encontrado As Boolean = False
        For Each CaraterInList As tCode In CodeArr
            If Caracter = CaraterInList.Ascii Then
                Encontrado = True
                IndiceSalida = CaraterInList.BarSpacePattern : Exit For  ' CodeArr(K).ASet Then Exit For
            End If
        Next
        If Encontrado = False Then
            IndiceSalida = -1
        End If
        Return IndiceSalida
    End Function
    Private Function ObtenerCaracterIndice_Ancho(ByVal Caracter As Integer) As String
        Dim IndiceSalida As String = String.Empty
        Dim Encontrado As Boolean = False
        For Each CaraterInList As tCode In CodeArr
            If Caracter = CaraterInList.Indice Then
                Encontrado = True
                IndiceSalida = CaraterInList.BarSpacePattern : Exit For  ' CodeArr(K).ASet Then Exit For
            End If
        Next
        If Encontrado = False Then
            IndiceSalida = -1
        End If
        Return IndiceSalida
    End Function
    Private Function ObtenerCaracterA_Ancho(ByVal Caracter As String) As String
        Dim IndiceSalida As String = String.Empty
        Dim Encontrado As Boolean = False
        For Each CaraterInList As tCode In CodeArr
            If Caracter = CaraterInList.ASet Then
                Encontrado = True
                IndiceSalida = CaraterInList.BarSpacePattern : Exit For  ' CodeArr(K).ASet Then Exit For
            End If
        Next
        If Encontrado = False Then
            IndiceSalida = -1
        End If
        Return IndiceSalida
    End Function
    Private Function ObtenerCaracterB_Ancho(ByVal Caracter As String) As String
        Dim IndiceSalida As String = String.Empty
        Dim Encontrado As Boolean = False
        For Each CaraterInList As tCode In CodeArr
            If Caracter = CaraterInList.BSet Then
                Encontrado = True
                IndiceSalida = CaraterInList.BarSpacePattern : Exit For  ' CodeArr(K).ASet Then Exit For
            End If
        Next
        If Encontrado = False Then
            IndiceSalida = -1
        End If
        Return IndiceSalida
    End Function
    Private Function ObtenerCaracterC_Ancho(ByVal Caracter As String) As String
        Dim IndiceSalida As String = String.Empty
        Dim Encontrado As Boolean = False
        For Each CaraterInList As tCode In CodeArr
            If Caracter = CaraterInList.CSet Then
                Encontrado = True
                IndiceSalida = CaraterInList.BarSpacePattern : Exit For  ' CodeArr(K).ASet Then Exit For
            End If
        Next
        If Encontrado = False Then
            IndiceSalida = -1
        End If
        Return IndiceSalida
    End Function

#End Region
#Region "Obtener codigos de control "

    Friend Function ObtenerCodigoControlAuto(ByVal ByVal_CadenaTexto As String)
        Dim CadenaSalida As String = ""
        Dim Variable128 As Int16 = 0
        Dim FNC4On As Boolean = False
        Dim FNC4Bloqueo As Boolean = False
        Dim ValorPar As Boolean = False
        Try
            Dim Integro As Integer = Mid$(ByVal_CadenaTexto, 1, 4)
            Dim IntegrStr As String = Mid$(ByVal_CadenaTexto, 1, 4)
            If IntegrStr.Length >= 4 Then : ValorPar = True
            Else : ValorPar = False
            End If
        Catch ex As Exception
            ValorPar = False
        End Try
        If ValorPar = True And ByVal_CadenaTexto.Length > 2 Then  '---------------------------------- Caracter SetC ------------------------------------------------
            Variable128 = 3
            CadenaSalida = "Start C"
        ElseIf ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, 1, 1)) >= 0 Then  '---------------------------------- Caracter SetB ----------------------------------
            If ObtenerIndiceCaracterA(Mid$(ByVal_CadenaTexto, 1, 1)) >= 0 Then
                Dim EncontradoNo As Boolean = False
                For Indice As Long = 1 To ByVal_CadenaTexto.Length
                    If ObtenerIndiceCaracterA(Mid$(ByVal_CadenaTexto, Indice, 1)) = (-1) And ObtenerIndiceCaracterAscii(Mid$(ByVal_CadenaTexto, Indice, 1)) > (-1) Then
                        Variable128 = 2
                        CadenaSalida = "Start B"
                        EncontradoNo = True
                        Exit For

                    End If
                    If ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, Indice, 1)) = (-1) And ObtenerIndiceCaracterAscii(Mid$(ByVal_CadenaTexto, Indice, 1)) > (-1) Then
                        Variable128 = 1
                        CadenaSalida = "Start A"
                        EncontradoNo = True
                        Exit For
                    End If
                Next
                If EncontradoNo = False Then : Variable128 = 1 : CadenaSalida = "Start B" : End If
            Else
                Variable128 = 2
                CadenaSalida = "Start B"
            End If



        ElseIf ObtenerIndiceCaracterA(Mid$(ByVal_CadenaTexto, 1, 1)) >= 0 Then '----------------------------- Caracter SetA ---------------------------------------
            Variable128 = 1
            CadenaSalida = "Start A"
        ElseIf ObtenerIndiceCaracterAscii(Mid$(ByVal_CadenaTexto, 1, 1)) >= 0 Then '----------------------------- Caracter ASCII ----------------------------------
            Dim Encontrado_1 As Boolean = False
            For Indice As Long = 1 To ByVal_CadenaTexto.Length



                If ObtenerIndiceCaracterA(Mid$(ByVal_CadenaTexto, Indice, 1)) >= (-1) And ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, Indice, 1)) >= (-1) Then
                    Dim EncontradoNo_a As Boolean = False
                    For IndiceDisputa As Long = Indice To ByVal_CadenaTexto.Length
                        If ObtenerIndiceCaracterA(Mid$(ByVal_CadenaTexto, Indice, 1)) = (-1) Then
                            Variable128 = 2
                            CadenaSalida = "Start B"
                            EncontradoNo_a = True
                            Exit For
                        End If
                        If ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, Indice, 1)) = (-1) Then
                            Variable128 = 1
                            CadenaSalida = "Start A"
                            EncontradoNo_a = True
                            Exit For
                        End If

                    Next
                    If EncontradoNo_a = False Then : Variable128 = 1 : CadenaSalida = "Start A" : End If
                    Exit For

                ElseIf ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, Indice, 1)) >= (-1) Then



                    Variable128 = 2
                    CadenaSalida = "Start B"
                    Encontrado_1 = True
                    Exit For



                ElseIf ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, Indice, 1)) >= (-1) Then



                    Variable128 = 1
                    CadenaSalida = "Start A"
                    Encontrado_1 = True
                    Exit For



                End If
                'If ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, Indice, 1)) >= (-1) Then
                'End If
            Next
            If Encontrado_1 = False Then : Variable128 = 1 : CadenaSalida = "Start A" : End If

        Else
            MsgBox("Error, caracter no reconocido")
        End If



        For IndiceCadenaX = 1 To ByVal_CadenaTexto.Length


            Try
                Dim aaa As String = Mid$(ByVal_CadenaTexto, IndiceCadenaX, 4)
                Dim Integro As Integer = CInt(aaa)
                Dim IntegerString As String = Integro
                If IntegerString.Length >= 4 Then : ValorPar = True
                Else : ValorPar = False
                End If
                ' ValorPar = True
            Catch ex As Exception
                ValorPar = False
            End Try
            Dim Aaaaa As String = Mid$(ByVal_CadenaTexto, IndiceCadenaX, 4)
            If ValorPar = True And Aaaaa.Length >= 4 And Variable128 <> 3 Then '----------------------------------------------------------------------- Caracter SetC ------------------------------------------------
                If (FNC4Bloqueo = True) Then
                    FNC4Bloqueo = False
                    FNC4On = False
                    CadenaSalida = CadenaSalida & "FNC 4"
                End If
                CadenaSalida = CadenaSalida & "CODE C" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 2)
                IndiceCadenaX = IndiceCadenaX + 1
                Variable128 = 3
                If FNC4Bloqueo = True Then
                    FNC4Bloqueo = True : FNC4On = True
                    'CadenaSalida = CadenaSalida & "CODE C" & "FNC 4FNC 4" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                    CadenaSalida = CadenaSalida & "FNC 4" & "CODE C" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                End If
            ElseIf Variable128 = 1 And ObtenerIndiceCaracterA(Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)) = (-1) And (FNC4Bloqueo = False And FNC4On = False) Then '---------------------------------- Caracter SetA ------------------------------------------------

                If ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, IndiceCadenaX + 1, 1)) = (-1) And ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)) > (-1) Then
                    CadenaSalida = CadenaSalida & "SHIFT" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                ElseIf ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, IndiceCadenaX + 1, 1)) >= 0 And ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)) >= 0 Then
                    CadenaSalida = CadenaSalida & "CODE B" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                    Variable128 = 2
                ElseIf ObtenerIndiceCaracterAscii(Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)) >= 0 Then
                    If FNC4On = False And FNC4Bloqueo = False Then
                        If ObtenerIndiceCaracterAscii(Mid$(ByVal_CadenaTexto, IndiceCadenaX + 1, 1)) >= 0 And ObtenerIndiceCaracterA(Mid$(ByVal_CadenaTexto, IndiceCadenaX + 1, 1)) = (-1) Then
                            FNC4Bloqueo = True : FNC4On = True
                            CadenaSalida = CadenaSalida & "FNC 4FNC 4" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                        Else
                            FNC4Bloqueo = False : FNC4On = True
                            CadenaSalida = CadenaSalida & "FNC 4" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                        End If

                    End If

                Else
                    MsgBox("Error Caracter no encontrado ")
                End If

            ElseIf Variable128 = 2 And ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)) = (-1) And (FNC4Bloqueo = False And FNC4On = False) Then '----------------------------------- Caracter SetB ------------------------------------------------

                If ObtenerIndiceCaracterA(Mid$(ByVal_CadenaTexto, IndiceCadenaX + 1, 1)) = (-1) And ObtenerIndiceCaracterA(Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)) > (-1) Then
                    CadenaSalida = CadenaSalida & "SHIFT" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                ElseIf ObtenerIndiceCaracterA(Mid$(ByVal_CadenaTexto, IndiceCadenaX + 1, 1)) >= 0 And ObtenerIndiceCaracterA(Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)) >= 0 Then
                    CadenaSalida = CadenaSalida & "CODE A" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                    Variable128 = 1
                ElseIf ObtenerIndiceCaracterAscii(Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)) >= 0 Then
                    If FNC4On = False And FNC4Bloqueo = False Then
                        If ObtenerIndiceCaracterAscii(Mid$(ByVal_CadenaTexto, IndiceCadenaX + 1, 1)) >= 0 And ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, IndiceCadenaX + 1, 1)) = (-1) Then
                            FNC4Bloqueo = True : FNC4On = True
                            CadenaSalida = CadenaSalida & "FNC 4FNC 4" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                        Else
                            FNC4Bloqueo = False : FNC4On = True
                            CadenaSalida = CadenaSalida & "FNC 4" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                        End If
                    ElseIf FNC4On = True Then
                        MsgBox("Error  pppp")
                    End If

                Else
                    MsgBox("Error, Caracter no encontrado ")
                End If

            ElseIf Variable128 = 3 And ObtenerIndiceCaracterC(Mid$(ByVal_CadenaTexto, IndiceCadenaX, 2)) = (-1) Then 'And (FNC4Bloqueo = False And FNC4On = False) Then '----------------------------------- Caracter SetC ------------------------------------------------
                '  asdffasdfasdf()
                Dim FNC4_C As Boolean = False
                Dim FNC4Bolqueo_C As Boolean = False
                If ObtenerIndiceCaracterAscii(Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)) > (-1) And ObtenerIndiceCaracterAscii(Mid$(ByVal_CadenaTexto, IndiceCadenaX + 1, 1)) > (-1) And
                    ObtenerIndiceCaracterA(Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)) = (-1) And ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)) = (-1) And
                     ObtenerIndiceCaracterA(Mid$(ByVal_CadenaTexto, IndiceCadenaX + 1, 1)) = (-1) And ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, IndiceCadenaX + 1, 1)) = (-1) Then
                    FNC4Bolqueo_C = True
                ElseIf ObtenerIndiceCaracterAscii(Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)) > (-1) And
                       ObtenerIndiceCaracterA(Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)) = (-1) And ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)) = (-1) Then
                    FNC4_C = True
                End If

                ' If ObtenerIndiceCaracterA(Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)) > (-1) And ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)) > (-1) Then
                Dim EncontradoNo_C As Boolean = False
                For IndiceC As Long = IndiceCadenaX To ByVal_CadenaTexto.Length
                    ' asdfasdfasdf222222222()
                    If ObtenerIndiceCaracterA(Mid$(ByVal_CadenaTexto, IndiceC, 1)) > (-1) And ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, IndiceC, 1)) > (-1) Then
                        'Variable128 = 2
                        'CadenaSalida = CadenaSalida & "CODE B" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                        'EncontradoNo5 = True
                        '  Exit For
                    ElseIf ObtenerIndiceCaracterA(Mid$(ByVal_CadenaTexto, IndiceC, 1)) = (-1) And ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, IndiceC, 1)) = (-1) And ObtenerIndiceCaracterAscii(Mid$(ByVal_CadenaTexto, IndiceC, 1)) = (-1) Then
                        MsgBox("Error, Caracter no encontrado")

                    ElseIf ObtenerIndiceCaracterA(Mid$(ByVal_CadenaTexto, IndiceC, 1)) > (-1) And ObtenerIndiceCaracterAscii(Mid$(ByVal_CadenaTexto, IndiceC, 1)) = (-1) Then
                        Variable128 = 1
                        EncontradoNo_C = True
                        If FNC4Bolqueo_C = True Then
                            FNC4Bloqueo = True : FNC4On = True
                            CadenaSalida = CadenaSalida & "CODE A" & "FNC 4FNC 4" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                        ElseIf FNC4_C = True Then
                            FNC4Bloqueo = False : FNC4On = True
                            CadenaSalida = CadenaSalida & "CODE A" & "FNC 4" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                        Else
                            CadenaSalida = CadenaSalida & "CODE A" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                        End If
                        Exit For
                    ElseIf ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, IndiceC, 1)) > (-1) And (ObtenerIndiceCaracterAscii(Mid$(ByVal_CadenaTexto, IndiceC, 1)) = (-1) Or ObtenerIndiceCaracterA(Mid$(ByVal_CadenaTexto, IndiceC, 1)) = (-1)) Then
                        Variable128 = 2
                        EncontradoNo_C = True
                        If FNC4Bolqueo_C = True Then
                            FNC4Bloqueo = True : FNC4On = True
                            CadenaSalida = CadenaSalida & "CODE B" & "FNC 4FNC 4" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                        ElseIf FNC4_C = True Then
                            FNC4Bloqueo = False : FNC4On = True
                            CadenaSalida = CadenaSalida & "CODE B" & "FNC 4" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                        Else
                            CadenaSalida = CadenaSalida & "CODE B" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                        End If
                        Exit For
                    Else
                        Dim aaaa As String = "asdfasdf"
                    End If


                    'If ObtenerIndiceCaracterA(Mid$(ByVal_CadenaTexto, IndiceC, 1)) = (-1) And ObtenerIndiceCaracterAscii(Mid$(ByVal_CadenaTexto, IndiceC, 1)) > (-1) Then 'And ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, Indice, 1)) > (-1) Then
                    '    Variable128 = 2
                    '    CadenaSalida = CadenaSalida & "CODE B" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                    '    EncontradoNo5 = True
                    '    Exit For
                    'End If
                    'If ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, IndiceC, 1)) = (-1) And ObtenerIndiceCaracterAscii(Mid$(ByVal_CadenaTexto, IndiceC, 1)) > (-1) Then
                    '    Variable128 = 1
                    '    CadenaSalida = CadenaSalida & "CODE A" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                    '    EncontradoNo5 = True
                    '    Exit For
                    'End If

                Next
                If EncontradoNo_C = False Then
                    Variable128 = 1
                    If FNC4Bolqueo_C = True Then
                        FNC4Bloqueo = True : FNC4On = True
                        CadenaSalida = CadenaSalida & "CODE A" & "FNC 4FNC 4" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                    ElseIf FNC4_C = True Then
                        FNC4Bloqueo = False : FNC4On = True
                        CadenaSalida = CadenaSalida & "CODE A" & "FNC 4" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                    Else
                        CadenaSalida = CadenaSalida & "CODE A" & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                    End If
                    '  End If
                    'ElseIf ObtenerIndiceCaracterA(Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)) = (-1) Or ObtenerIndiceCaracterB(Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)) > (-1) Or ObtenerIndiceCaracterAscii(Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)) > (-1) Then
                    '    MsgBox("Caracter no encontrado")
                End If


                'ElseIf (Variable128 = 2 Or Variable128 = 1) And ObtenerIndiceCaracterAscii(Mid$(ByVal_CadenaTexto, IndiceCadenaX, 2)) >= 0 Then '------------ Caracter ASCII ------------------------------------------------
                '    sdfasdfasdf()
                '    'Dim FNC4On As Boolean = False
                '    'Dim FNC4Bloqueo As Boolean = False
                '    If FNC4On = False And FNC4Bloqueo = False Then

                '    End If


                '  MsgBox("Holaaa")
            Else
                ' MsgBox("Error")



                If (FNC4Bloqueo = True) And ObtenerIndiceCaracterAscii(Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)) = (-1) Then
                    FNC4Bloqueo = False
                    FNC4On = False
                    CadenaSalida = CadenaSalida & "FNC 4FNC 4"
                End If


                Select Case Variable128
                    Case 1
                        CadenaSalida = CadenaSalida & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                    Case 2
                        CadenaSalida = CadenaSalida & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 1)
                    Case 3
                        CadenaSalida = CadenaSalida & Mid$(ByVal_CadenaTexto, IndiceCadenaX, 2)
                        IndiceCadenaX = IndiceCadenaX + 1
                    Case Else
                        MsgBox("Error")
                End Select

            End If
            FNC4On = False
            'Dim Caracter As String
            'If Mid$(ByVal_CadenaTexto, IndiceCadenaX, 6) = "Code A" Then

            'ElseIf Mid$(ByVal_CadenaTexto, IndiceCadenaX, 6) = "Code B" Then

            'ElseIf Mid$(ByVal_CadenaTexto, IndiceCadenaX, 6) = "Code C" Then

            'ElseIf Mid$(ByVal_CadenaTexto, IndiceCadenaX, 5) = "FNC 1" Then

            'ElseIf Mid$(ByVal_CadenaTexto, IndiceCadenaX, 5) = "FNC 2" Then

            'ElseIf Mid$(ByVal_CadenaTexto, IndiceCadenaX, 5) = "FNC 3" Then

            'ElseIf Mid$(ByVal_CadenaTexto, IndiceCadenaX, 5) = "FNC 4" Then

            'ElseIf Mid$(ByVal_CadenaTexto, IndiceCadenaX, 5) = "SHIFT" And Variable128 = 1 Then

            'ElseIf Mid$(ByVal_CadenaTexto, IndiceCadenaX, 5) = "SHIFT" And Variable128 = 2 Then

            'ElseIf Mid$(ByVal_CadenaTexto, IndiceCadenaX, 5) = "SHIFT" And Variable128 = 3 Then
            '    MsgBox("Error en los codigos de control")
            'Else
            '    Caracter = Mid$(ByVal_CadenaTexto, IndiceCadenaX, CaracteresCantidad)  '  ByVal_CadebaTexto.ToString.

            'End If
        Next

        If FNC4Bloqueo = True Then
            CadenaSalida = CadenaSalida & "FNC 4FNC 4"
        End If


        Return CadenaSalida
    End Function

#End Region

#Region "Iprimir"

    Friend Function ImprimirCodigo(ByVal ByVal_Codigo As String, ByVal ByVal_CodigoControl As String, ByVal ByVal_CodigoStop As String, ByRef ControlGrafico As Graphics, ByVal AnchoBarras As Double, ByVal AltoBarras As Double, ByRef ByValPosicionH As Single, ByVal ByValPosicionV As Single) As Graphics
        ControlGrafico.PageUnit = GraphicsUnit.Millimeter
        ControlGrafico.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixel
        ' ControlGrafico.Clip=(New SizeF(AnchoBarras, AltoBarras) '= New Size(AnchoBarras, AltoBarras).Width ' New SizeF(AnchoBarras, AltoBarras).Width
        Dim CadenaSalida As String = String.Empty
        '  Dim Suma As Long
        Dim SumaDeControles As Long = 0
        Dim Variable128 As Int16 = 0
        Dim Variable128_Suguiente As Int16 = 0
        Dim CaracteresCantidad As Int16 = 1
        Dim ShiftOn As Boolean = False
        Dim IndiceCadenaX As Long = 1
        Dim CaracteresInicio = 1
        Dim Start_Code As Int16
        Dim FNC4On As Boolean = False
        Dim FNC4Bloqueo As Boolean = False
        Dim FNC4Caracter As Boolean = False

        ''''''''Variables Graficos''''''''
        Dim PosicionH As Single = ByValPosicionH
        'Dim AnchoTotal As Single = 110
        Dim AnchoTemporal As Single = 0
        Dim AnchoBarraFina As Single = AnchoBarras
        Dim AltoBarra As Single = AltoBarras
        ''''''''''''''''''''''''''''''''''
        Try
            Dim aaaa As String = Mid$(ByVal_Codigo, 1, 7)
            Select Case aaaa
                Case "Start A"
                    Start_Code = eCode128Type.eCode128_CodeSetA
                    CaracteresInicio = 8
                    CaracteresCantidad = 1
                    Variable128 = 1
                    Variable128_Suguiente = 1
                    ObtenerBarrasCaracter(ObtenerCaracterA_Ancho("Start A"), ControlGrafico, AnchoBarraFina, AltoBarra, PosicionH, ByValPosicionV)
                Case "Start B"
                    Start_Code = eCode128Type.eCode128_CodeSetB
                    CaracteresInicio = 8
                    CaracteresCantidad = 1
                    Variable128 = 2
                    Variable128_Suguiente = 2
                    ObtenerBarrasCaracter(ObtenerCaracterA_Ancho("Start B"), ControlGrafico, AnchoBarraFina, AltoBarra, PosicionH, ByValPosicionV)
                Case "Start C"
                    Start_Code = eCode128Type.eCode128_CodeSetC
                    CaracteresInicio = 8
                    CaracteresCantidad = 2
                    Variable128 = 3
                    Variable128_Suguiente = 3
                    ObtenerBarrasCaracter(ObtenerCaracterA_Ancho("Start C"), ControlGrafico, AnchoBarraFina, AltoBarra, PosicionH, ByValPosicionV)
                Case Else
                    MsgBox("Error, no hay encavezado")
            End Select



            For IndiceCadenaX = CaracteresInicio To ByVal_Codigo.Length
                Dim Caracter As String = String.Empty
                Dim aaaaa As String = Mid$(ByVal_Codigo, IndiceCadenaX, 6)

                If Mid$(ByVal_Codigo, IndiceCadenaX, 6) = "CODE A" Then
                    Caracter = "CODE A"
                    'CaracteresCantidad = 1
                    Variable128_Suguiente = 1
                    IndiceCadenaX = IndiceCadenaX + 5

                ElseIf Mid$(ByVal_Codigo, IndiceCadenaX, 6) = "CODE B" Then
                    Caracter = "CODE B"
                    ' CaracteresCantidad = 1
                    IndiceCadenaX = IndiceCadenaX + 5
                    Variable128_Suguiente = 2
                    SumaDeControles = SumaDeControles + 6
                ElseIf Mid$(ByVal_Codigo, IndiceCadenaX, 6) = "CODE C" Then
                    Caracter = "CODE C"
                    ' CaracteresCantidad = 2
                    IndiceCadenaX = IndiceCadenaX + 5
                    Variable128_Suguiente = 3
                    SumaDeControles = SumaDeControles + 6
                ElseIf Mid$(ByVal_Codigo, IndiceCadenaX, 5) = "FNC 1" Then
                    Caracter = "FNC 1"
                    ' CaracteresCantidad = 1
                    SumaDeControles = SumaDeControles + 5
                    IndiceCadenaX = IndiceCadenaX + 4
                ElseIf Mid$(ByVal_Codigo, IndiceCadenaX, 5) = "FNC 2" Then
                    Caracter = "FNC 2"
                    '  CaracteresCantidad = 1
                    SumaDeControles = SumaDeControles + 5
                    IndiceCadenaX = IndiceCadenaX + 4
                ElseIf Mid$(ByVal_Codigo, IndiceCadenaX, 5) = "FNC 3" Then
                    Caracter = "FNC 3"
                    '  CaracteresCantidad = 1
                    SumaDeControles = SumaDeControles + 5
                    IndiceCadenaX = IndiceCadenaX + 4
                ElseIf Mid$(ByVal_Codigo, IndiceCadenaX, 5) = "FNC 4" Then
                    FNC4Caracter = True
                    If Mid$(ByVal_Codigo, IndiceCadenaX, 10) = "FNC 4FNC 4" Then
                        FNC4On = True
                        FNC4Bloqueo = True
                        Caracter = "FNC 4FNC 4"
                        ' CaracteresCantidad = 1
                        SumaDeControles = SumaDeControles + 10
                        IndiceCadenaX = IndiceCadenaX + 9
                    ElseIf Mid$(ByVal_Codigo, IndiceCadenaX, 5) = "FNC 4" And FNC4Bloqueo = False Then
                        FNC4On = True
                        FNC4Bloqueo = False
                        Caracter = "FNC 4"
                        ' CaracteresCantidad = 1
                        SumaDeControles = SumaDeControles + 5
                        IndiceCadenaX = IndiceCadenaX + 4
                    ElseIf Mid$(ByVal_Codigo, IndiceCadenaX, 5) = "FNC 4" And FNC4Bloqueo = True Then
                        FNC4On = False
                        FNC4Bloqueo = False
                        Caracter = "FNC 4"
                        ' CaracteresCantidad = 1
                        SumaDeControles = SumaDeControles + 5
                        IndiceCadenaX = IndiceCadenaX + 4
                    End If

                ElseIf Mid$(ByVal_Codigo, IndiceCadenaX, 5) = "SHIFT" And Variable128 = 1 Then
                    Caracter = "SHIFT"
                    ' CaracteresCantidad = 1
                    Variable128_Suguiente = 2
                    ShiftOn = True
                    SumaDeControles = SumaDeControles + 5
                    IndiceCadenaX = IndiceCadenaX + 4
                ElseIf Mid$(ByVal_Codigo, IndiceCadenaX, 5) = "SHIFT" And Variable128 = 2 Then
                    Caracter = "SHIFT"
                    ' CaracteresCantidad = 1
                    Variable128_Suguiente = 1
                    ShiftOn = True
                    SumaDeControles = SumaDeControles + 5
                    IndiceCadenaX = IndiceCadenaX + 4
                ElseIf Mid$(ByVal_Codigo, IndiceCadenaX, 4) = "Stop" And Variable128 = 3 Then
                    Caracter = "Stop"
                    'CaracteresCantidad = 1
                    SumaDeControles = SumaDeControles + 4
                    IndiceCadenaX = IndiceCadenaX + 3
                ElseIf Mid$(ByVal_Codigo, IndiceCadenaX, 5) = "SHIFT" And Variable128 = 3 Then
                    MsgBox("Error en los codigos de control")

                Else
                    'Select Case Variable128
                    '    Case 1 Or 2
                    '    Case 3
                    'End Select
                    '  asdfasdfasdf()
                    'If Variable128 = 3 Then
                    '    Dim ValorPar As Boolean = False
                    '    Try
                    '        Dim Integro As Int16 = Mid$(ByVal_Codigo, IndiceCadenaX, 2)
                    '        ValorPar = True
                    '    Catch ex As Exception
                    '        ValorPar = False
                    '    End Try
                    '    If ValorPar = True And ByVal_Codigo.Length > 2 Then
                    '        CaracteresCantidad = 2
                    '        else
                    '    End If

                    'Else

                    'End If
                    Caracter = Mid$(ByVal_Codigo, IndiceCadenaX, CaracteresCantidad)  '  ByVal_CadebaTexto.ToString.
                    IndiceCadenaX = IndiceCadenaX + (CaracteresCantidad - 1)
                End If
                Select Case Variable128
                    Case 1
                        '  Suma = Suma + (ObtenerIndiceCaracterA(Caracter) * (IndiceCadenaX - SumaDeControles))
                        If (FNC4On = True Or FNC4Bloqueo = True) And FNC4Caracter = False Then
                            ObtenerBarrasCaracter(ObtenerCaracterAscii_Ancho(Caracter), ControlGrafico, AnchoBarraFina, AltoBarra, PosicionH, ByValPosicionV)
                        ElseIf FNC4Bloqueo = True And FNC4Caracter = True Then
                            ObtenerBarrasCaracter(ObtenerCaracterA_Ancho(Mid$(Caracter, 1, 5)), ControlGrafico, AnchoBarraFina, AltoBarra, PosicionH, ByValPosicionV)
                            ObtenerBarrasCaracter(ObtenerCaracterA_Ancho(Mid$(Caracter, 6, 5)), ControlGrafico, AnchoBarraFina, AltoBarra, PosicionH, ByValPosicionV)
                        Else
                            ObtenerBarrasCaracter(ObtenerCaracterA_Ancho(Caracter), ControlGrafico, AnchoBarraFina, AltoBarra, PosicionH, ByValPosicionV)
                        End If

                    Case 2
                        ' Suma = Suma + (ObtenerIndiceCaracterB(Caracter) * (IndiceCadenaX - SumaDeControles))
                        If (FNC4On = True Or FNC4Bloqueo = True) And FNC4Caracter = False Then
                            ObtenerBarrasCaracter(ObtenerCaracterAscii_Ancho(Caracter), ControlGrafico, AnchoBarraFina, AltoBarra, PosicionH, ByValPosicionV)
                        ElseIf FNC4Bloqueo = True And FNC4Caracter = True Then
                            ObtenerBarrasCaracter(ObtenerCaracterA_Ancho(Mid$(Caracter, 1, 5)), ControlGrafico, AnchoBarraFina, AltoBarra, PosicionH, ByValPosicionV)
                            ObtenerBarrasCaracter(ObtenerCaracterA_Ancho(Mid$(Caracter, 6, 5)), ControlGrafico, AnchoBarraFina, AltoBarra, PosicionH, ByValPosicionV)
                        Else
                            ObtenerBarrasCaracter(ObtenerCaracterB_Ancho(Caracter), ControlGrafico, AnchoBarraFina, AltoBarra, PosicionH, ByValPosicionV)
                        End If

                    Case 3
                        ObtenerBarrasCaracter(ObtenerCaracterC_Ancho(Caracter), ControlGrafico, AnchoBarraFina, AltoBarra, PosicionH, ByValPosicionV)
                        'If Caracter.Length = 2 Then
                        '    Suma = Suma + (ObtenerIndiceCaracterC(Caracter) * (IndiceCadenaX - SumaDeControles))
                        '    SumaDeControles = SumaDeControles + 1
                        'Else
                        '    MsgBox("Error. La variable C (del tipo Code 128) necesita valore un carateres pares. " & vbCr & "Puede añadir un caracter de control Code A o Code B para excluer un carater en este tipo para adecuar la cadena")
                        'End If
                    Case Else
                        MsgBox("Error Variable del code128 no programado")
                End Select

                If FNC4Caracter = True Then
                    FNC4Caracter = False
                Else
                    FNC4On = False
                End If

                If (Variable128_Suguiente <> Variable128) Then
                    If ShiftOn = True Then
                        If Variable128 = 1 Then
                            Variable128 = 2
                            Variable128_Suguiente = 1
                            ShiftOn = False

                        Else
                            Variable128 = 1
                            Variable128_Suguiente = 2
                            ShiftOn = False
                        End If
                    Else
                        Select Case Variable128_Suguiente
                            Case 1
                                CaracteresCantidad = 1
                            Case 2
                                CaracteresCantidad = 1
                            Case 3
                                CaracteresCantidad = 2
                            Case Else
                                MsgBox("Error el variable de Code1128 no programado")
                        End Select
                        Variable128 = Variable128_Suguiente
                    End If
                End If
            Next

            ObtenerBarrasCaracter(ObtenerCaracterIndice_Ancho(ByVal_CodigoControl), ControlGrafico, AnchoBarraFina, AltoBarra, PosicionH, ByValPosicionV)
            ObtenerBarrasCaracter(ObtenerCaracterA_Ancho(ByVal_CodigoStop), ControlGrafico, AnchoBarraFina, AltoBarra, PosicionH, ByValPosicionV)
            ByValPosicionH = PosicionH
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



        Return ImprimirCodigo
    End Function
    Friend Function ObtenerBarrasCaracter(ByVal Anchos As String, ByRef Graficos As Graphics, ByVal AnchoBarrasFina As Single, ByVal AltoBarras As Single, ByRef PosicionH As Single, ByVal posicionV As Single)
        Dim BlancoNegro As Boolean = False
        Dim AnchoTotal As Integer = Graficos.ClipBounds.Size.Width
        'Dim PocicionHorizontalAncho As New Point(AltoBarras)
        Dim posicionHorizontal As Single = PosicionH

        For IndiceBarras As Int16 = 1 To Anchos.Length
            Dim valorBarra As Int16 = Mid$(Anchos, IndiceBarras, 1)
            Dim ValorAnchoBarra As Single = valorBarra * AnchoBarrasFina
            Dim MediaBarra As Single = ValorAnchoBarra / 2
            posicionHorizontal = posicionHorizontal + (MediaBarra)
            If BlancoNegro = False Then
                BlancoNegro = True
                Dim blackPen As New Pen(Color.Black, ValorAnchoBarra)
                '   blackPen.PenType.
                Graficos.DrawLine(blackPen, posicionHorizontal, posicionV, posicionHorizontal, posicionV + AltoBarras)
            Else
                BlancoNegro = False
                Dim whitePen As New Pen(Color.White, ValorAnchoBarra)
                Graficos.DrawLine(whitePen, posicionHorizontal, posicionV, posicionHorizontal, posicionV + AltoBarras)
            End If

            '  Dim aa As Single = (Math.Ceiling(valorBarra * 100))
            '  Dim bbb As Single = (aa / 100)

            posicionHorizontal = posicionHorizontal + MediaBarra '(aa / 100)


        Next
        PosicionH = posicionHorizontal
        Return Graficos
    End Function
    Friend Function ObtenerBarraEspacio(ByVal Anchos As String, ByRef Graficos As Graphics, ByVal AnchoBarrasFina As Single, ByVal AltoBarras As Single, ByRef PosicionH As Single, ByVal posicionV As Single)
        '   Dim BlancoNegro As Boolean = False
        'Dim AnchoTotal As Integer = Graficos.ClipBounds.Size.Width
        'Dim PocicionHorizontalAncho As New Point(AltoBarras)
        Dim posicionHorizontal As Single = PosicionH

        For IndiceBarras As Int16 = 1 To Anchos.Length
            Dim valorBarra As Int16 = Mid$(Anchos, IndiceBarras, 1)
            Dim ValorAnchoBarra As Single = valorBarra * AnchoBarrasFina
            Dim MediaBarra As Single = ValorAnchoBarra / 2
            posicionHorizontal = posicionHorizontal + (MediaBarra)
            '   If BlancoNegro = False Then
            'BlancoNegro = True
            '    Dim blackPen As New Pen(Color.Black, ValorAnchoBarra)
            '   blackPen.PenType.
            '   Graficos.DrawLine(blackPen, posicionHorizontal, posicionV + 6, posicionHorizontal, AltoBarras)
            '    Else
            '   BlancoNegro = False
            Dim whitePen As New Pen(Color.White, ValorAnchoBarra)
            Graficos.DrawLine(whitePen, posicionHorizontal, posicionV, posicionHorizontal, (AltoBarras / 2) + posicionV)
            '    End If

            '  Dim aa As Single = (Math.Ceiling(valorBarra * 100))
            '  Dim bbb As Single = (aa / 100)

            posicionHorizontal = posicionHorizontal + MediaBarra '(aa / 100)


        Next
        PosicionH = posicionHorizontal
        Return Graficos
    End Function
#End Region

#Region "Variables y estructuras"

    Private Enum eCode128Type
        eCode128_CodeSetA = 1
        eCode128_CodeSetB = 2
        eCode128_CodeSetC = 3
    End Enum
    Private Structure tCode
        Dim Indice As String
        Dim ASet As String
        Dim BSet As String
        Dim CSet As String
        Dim Ascii As String
        Dim BarSpacePattern As String
    End Structure
    Private CodeArr() As tCode

    Friend Sub Class_Initialize1()
        ReDim CodeArr(106)

        AddEntry(0, " ", " ", "00", " ", "2 1 2 2 2 2")
        AddEntry(1, "!", "!", "01", "!", "2 2 2 1 2 2")
        AddEntry(2, """", """", "02", """", "2 2 2 2 2 1")
        AddEntry(3, "#", "#", "03", "#", "1 2 1 2 2 3")
        AddEntry(4, "$", "$", "04", "$", "1 2 1 3 2 2")
        AddEntry(5, "%", "%", "05", "%", "1 3 1 2 2 2")
        AddEntry(6, "&", "&", "06", "&", "1 2 2 2 1 3")
        AddEntry(7, "'", "'", "07", "'", "1 2 2 3 1 2")
        AddEntry(8, "(", "(", "08", "(", "1 3 2 2 1 2")
        AddEntry(9, ")", ")", "09", ")", "2 2 1 2 1 3")
        AddEntry(10, "*", "*", "10", "*", "2 2 1 3 1 2")
        AddEntry(11, "+", "+", "11", "+", "2 3 1 2 1 2")
        AddEntry(12, ",", ",", "12", ",", "1 1 2 2 3 2")
        AddEntry(13, "-", "-", "13", "-", "1 2 2 1 3 2")
        AddEntry(14, ".", ".", "14", ".", "1 2 2 2 3 1")
        AddEntry(15, "/", "/", "15", "/", "1 1 3 2 2 2")
        AddEntry(16, "0", "0", "16", "0", "1 2 3 1 2 2")
        AddEntry(17, "1", "1", "17", "1", "1 2 3 2 2 1")
        AddEntry(18, "2", "2", "18", "2", "2 2 3 2 1 1")
        AddEntry(19, "3", "3", "19", "3", "2 2 1 1 3 2")
        AddEntry(20, "4", "4", "20", "4", "2 2 1 2 3 1")
        AddEntry(21, "5", "5", "21", "5", "2 1 3 2 1 2")
        AddEntry(22, "6", "6", "22", "6", "2 2 3 1 1 2")
        AddEntry(23, "7", "7", "23", "7", "3 1 2 1 3 1")
        AddEntry(24, "8", "8", "24", "8", "3 1 1 2 2 2")
        AddEntry(25, "9", "9", "25", "9", "3 2 1 1 2 2")
        AddEntry(26, ":", ":", "26", ":", "3 2 1 2 2 1")
        AddEntry(27, ";", ";", "27", ";", "3 1 2 2 1 2")
        AddEntry(28, "<", "<", "28", "<", "3 2 2 1 1 2")
        AddEntry(29, "=", "=", "29", "=", "3 2 2 2 1 1")
        AddEntry(30, ">", ">", "30", ">", "2 1 2 1 2 3")
        AddEntry(31, "?", "?", "31", "?", "2 1 2 3 2 1")
        AddEntry(32, "@", "@", "32", "@", "2 3 2 1 2 1")
        AddEntry(33, "A", "A", "33", "A", "1 1 1 3 2 3")
        AddEntry(34, "B", "B", "34", "B", "1 3 1 1 2 3")
        AddEntry(35, "C", "C", "35", "C", "1 3 1 3 2 1")
        AddEntry(36, "D", "D", "36", "D", "1 1 2 3 1 3")
        AddEntry(37, "E", "E", "37", "E", "1 3 2 1 1 3")
        AddEntry(38, "F", "F", "38", "F", "1 3 2 3 1 1")
        AddEntry(39, "G", "G", "39", "G", "2 1 1 3 1 3")
        AddEntry(40, "H", "H", "40", "H", "2 3 1 1 1 3")
        AddEntry(41, "I", "I", "41", "I", "2 3 1 3 1 1")
        AddEntry(42, "J", "J", "42", "J", "1 1 2 1 3 3")
        AddEntry(43, "K", "K", "43", "K", "1 1 2 3 3 1")
        AddEntry(44, "L", "L", "44", "L", "1 3 2 1 3 1")
        AddEntry(45, "M", "M", "45", "M", "1 1 3 1 2 3")
        AddEntry(46, "N", "N", "46", "N", "1 1 3 3 2 1")
        AddEntry(47, "O", "O", "47", "O", "1 3 3 1 2 1")
        AddEntry(48, "P", "P", "48", "P", "3 1 3 1 2 1")
        AddEntry(49, "Q", "Q", "49", "Q", "2 1 1 3 3 1")
        AddEntry(50, "R", "R", "50", "R", "2 3 1 1 3 1")
        AddEntry(51, "S", "S", "51", "S", "2 1 3 1 1 3")
        AddEntry(52, "T", "T", "52", "T", "2 1 3 3 1 1")
        AddEntry(53, "U", "U", "53", "U", "2 1 3 1 3 1")
        AddEntry(54, "V", "V", "54", "V", "3 1 1 1 2 3")
        AddEntry(55, "W", "W", "55", "W", "3 1 1 3 2 1")
        AddEntry(56, "X", "X", "56", "X", "3 3 1 1 2 1")
        AddEntry(57, "Y", "Y", "57", "Y", "3 1 2 1 1 3")
        AddEntry(58, "Z", "Z", "58", "Z", "3 1 2 3 1 1")
        AddEntry(59, "[", "[", "59", "[", "3 3 2 1 1 1")
        AddEntry(60, "\", "\", "60", "\", "3 1 4 1 1 1")
        AddEntry(61, "]", "]", "61", "]", "2 2 1 4 1 1")
        AddEntry(62, "^", "^", "62", "^", "4 3 1 1 1 1")
        AddEntry(63, "_", "_", "63", "_", "1 1 1 2 2 4")
        AddEntry(64, Chr(0), "`", "64", "`", "1 1 1 4 2 2") ' Null
        AddEntry(65, Chr(1), "a", "65", "a", "1 2 1 1 2 4") ' SOH
        AddEntry(66, Chr(2), "b", "66", "b", "1 2 1 4 2 1") ' STX
        AddEntry(67, Chr(3), "c", "67", "c", "1 4 1 1 2 2") ' ETX
        AddEntry(68, Chr(4), "d", "68", "d", "1 4 1 2 2 1") ' EOT
        AddEntry(69, Chr(5), "e", "69", "e", "1 1 2 2 1 4") ' ENQ
        AddEntry(70, Chr(6), "f", "70", "f", "1 1 2 4 1 2") ' ACK
        AddEntry(71, Chr(7), "g", "71", "g", "1 2 2 1 1 4") ' BEL
        AddEntry(72, Chr(8), "h", "72", "h", "1 2 2 4 1 1") ' BS
        AddEntry(73, Chr(9), "i", "73", "i", "1 4 2 1 1 2") ' HT
        AddEntry(74, Chr(10), "j", "74", "j", "1 4 2 2 1 1") ' LF
        AddEntry(75, Chr(11), "k", "75", "k", "2 4 1 2 1 1") ' VT
        AddEntry(76, Chr(12), "l", "76", "l", "2 2 1 1 1 4") ' FF
        AddEntry(77, Chr(13), "m", "77", "m", "4 1 3 1 1 1") ' CR
        AddEntry(78, Chr(14), "n", "78", "n", "2 4 1 1 1 2") ' SO
        AddEntry(79, Chr(15), "o", "79", "o", "1 3 4 1 1 1") ' SI
        AddEntry(80, Chr(16), "p", "80", "p", "1 1 1 2 4 2") ' DLE
        AddEntry(81, Chr(17), "q", "81", "q", "1 2 1 1 4 2") ' DC1
        AddEntry(82, Chr(18), "r", "82", "r", "1 2 1 2 4 1") ' DC2
        AddEntry(83, Chr(19), "s", "83", "s", "1 1 4 2 1 2") ' DC3
        AddEntry(84, Chr(20), "t", "84", "t", "1 2 4 1 1 2") ' DC4
        AddEntry(85, Chr(21), "u", "85", "u", "1 2 4 2 1 1") ' NAK
        AddEntry(86, Chr(22), "v", "86", "v", "4 1 1 2 1 2") ' SYN
        AddEntry(87, Chr(23), "w", "87", "w", "4 2 1 1 1 2") ' ETB
        AddEntry(88, Chr(24), "x", "88", "x", "4 2 1 2 1 1") ' CAN
        AddEntry(89, Chr(25), "y", "89", "y", "2 1 2 1 4 1") ' EM
        AddEntry(90, Chr(26), "z", "90", "z", "2 1 4 1 2 1") ' SUB
        AddEntry(91, Chr(27), "{", "91", "{", "4 1 2 1 2 1") ' ESC
        AddEntry(92, Chr(28), "|", "92", "|", "1 1 1 1 4 3") ' FS
        AddEntry(93, Chr(29), "}", "93", "}", "1 1 1 3 4 1") ' GS
        AddEntry(94, Chr(30), "~", "94", "~", "1 3 1 1 4 1") ' RS
        AddEntry(95, Chr(31), Chr(127), "95", "È", "1 1 4 1 1 3") ' US, DEL
        AddEntry(96, "FNC 3", "FNC 3", "96", "É", "1 1 4 3 1 1")
        AddEntry(97, "FNC 2", "FNC 2", "97", "Ê", "4 1 1 1 1 3")
        AddEntry(98, "SHIFT", "SHIFT", "98", "Ë", "4 1 1 3 1 1")
        AddEntry(99, "CODE C", "CODE C", "99", "Ì", "1 1 3 1 4 1")
        AddEntry(100, "CODE B", "FNC 4", "CODE B", "Í", "1 1 4 1 3 1")
        AddEntry(101, "FNC 4", "CODE A", "CODE A", "Î", "3 1 1 1 4 1")
        AddEntry(102, "FNC 1", "FNC 1", "FNC 1", "Ï", "4 1 1 1 3 1")
        AddEntry(103, "Start A", "Start A", "Start A", "Ð", "2 1 1 4 1 2")
        AddEntry(104, "Start B", "Start B", "Start B", "Ñ", "2 1 1 2 1 4")
        AddEntry(105, "Start C", "Start C", "Start C", "Ò", "2 1 1 2 3 2")
        AddEntry(106, "Stop", "Stop", "Stop", "Ó", "2 3 3 1 1 1 2")
    End Sub

    Private Sub AddEntry(ByVal Index As Integer, ASet As String, BSet As String, CSet As String, AsciiSet As String, BarSpacePattern As String)
        With CodeArr(Index)
            .Indice = Index
            .ASet = ASet
            .BSet = BSet
            .CSet = CSet
            .Ascii = AsciiSet
            .BarSpacePattern = Replace(BarSpacePattern, " ", "")
        End With
    End Sub

    'Public Function Code128_Str(ByVal Str As String)
    '    Code128_Str = Replace(BuildStr(Str), " ", "")
    'End Function

#End Region

End Class

