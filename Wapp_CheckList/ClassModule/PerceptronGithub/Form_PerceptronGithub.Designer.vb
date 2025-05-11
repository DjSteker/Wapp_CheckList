<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_PerceptronGithub
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TextBox_Capas = New System.Windows.Forms.TextBox()
        Me.TextBox_Momento = New System.Windows.Forms.TextBox()
        Me.TextBox_AlfaEntrenamiento = New System.Windows.Forms.TextBox()
        Me.TextBox_Salidas = New System.Windows.Forms.TextBox()
        Me.TextBox_Neuronas = New System.Windows.Forms.TextBox()
        Me.TextBox_FactorActivacion = New System.Windows.Forms.TextBox()
        Me.TextBox_ConexionesNumero = New System.Windows.Forms.TextBox()
        Me.Button_CargarImagen = New System.Windows.Forms.Button()
        Me.Button_GenerarDataSet = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button_GenerarRed2 = New System.Windows.Forms.Button()
        Me.Button_QuitarCapa = New System.Windows.Forms.Button()
        Me.ListBox_Neuronas = New System.Windows.Forms.ListBox()
        Me.Button_AñadirCapa = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox_ImagenRed = New System.Windows.Forms.PictureBox()
        Me.Button_Circulo = New System.Windows.Forms.Button()
        Me.Button_EntrenamientoSencillo = New System.Windows.Forms.Button()
        Me.Button_BorrarEntrenamiento = New System.Windows.Forms.Button()
        Me.Button_APrueba = New System.Windows.Forms.Button()
        Me.Button_Aentrenamiento = New System.Windows.Forms.Button()
        Me.ComboBox_CerebrosLista = New System.Windows.Forms.ComboBox()
        Me.TextBox_Bias = New System.Windows.Forms.TextBox()
        Me.Button_Cargar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox_GuardarNombre = New System.Windows.Forms.TextBox()
        Me.Label_X1 = New System.Windows.Forms.Label()
        Me.Button_Guardar = New System.Windows.Forms.Button()
        Me.Button_Test = New System.Windows.Forms.Button()
        Me.Button_DetenerNeurona = New System.Windows.Forms.Button()
        Me.TextBox_X1 = New System.Windows.Forms.TextBox()
        Me.Label_X2 = New System.Windows.Forms.Label()
        Me.TextBox_X2 = New System.Windows.Forms.TextBox()
        Me.Label_Target = New System.Windows.Forms.Label()
        Me.Label_Momento = New System.Windows.Forms.Label()
        Me.TextBox_Target = New System.Windows.Forms.TextBox()
        Me.Label_Independiente = New System.Windows.Forms.Label()
        Me.TextBox_Independiente = New System.Windows.Forms.TextBox()
        Me.Label_Umbral = New System.Windows.Forms.Label()
        Me.TextBox_EpocasEntrenamiento = New System.Windows.Forms.TextBox()
        Me.TextBox_Umbral = New System.Windows.Forms.TextBox()
        Me.Label_EpocasEntrenamiento = New System.Windows.Forms.Label()
        Me.Label_Resultado = New System.Windows.Forms.Label()
        Me.TextBox_Resultado = New System.Windows.Forms.TextBox()
        Me.Label_FactorActivacion = New System.Windows.Forms.Label()
        Me.Label_Incremento = New System.Windows.Forms.Label()
        Me.TextBox_Incremento = New System.Windows.Forms.TextBox()
        Me.Button_Entrenamiento = New System.Windows.Forms.Button()
        Me.Button_GenerarRed = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button_Divide = New System.Windows.Forms.Button()
        Me.Button_Suma = New System.Windows.Forms.Button()
        Me.Button_Pruebas = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button_RedImagen = New System.Windows.Forms.Button()
        Me.Button_DataSheEntrenamiento = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button_GenerarEntrenaCirculo = New System.Windows.Forms.Button()
        Me.Button_GenerarEntrenaCirculo2 = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox_ImagenRed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox_Capas
        '
        Me.TextBox_Capas.Location = New System.Drawing.Point(240, 362)
        Me.TextBox_Capas.Name = "TextBox_Capas"
        Me.TextBox_Capas.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Capas.TabIndex = 96
        Me.TextBox_Capas.Text = "1"
        Me.ToolTip1.SetToolTip(Me.TextBox_Capas, "Capas")
        '
        'TextBox_Momento
        '
        Me.TextBox_Momento.Location = New System.Drawing.Point(89, 332)
        Me.TextBox_Momento.Name = "TextBox_Momento"
        Me.TextBox_Momento.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Momento.TabIndex = 95
        Me.TextBox_Momento.Text = "0,8"
        Me.ToolTip1.SetToolTip(Me.TextBox_Momento, "Momento")
        '
        'TextBox_AlfaEntrenamiento
        '
        Me.TextBox_AlfaEntrenamiento.Location = New System.Drawing.Point(195, 429)
        Me.TextBox_AlfaEntrenamiento.Name = "TextBox_AlfaEntrenamiento"
        Me.TextBox_AlfaEntrenamiento.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_AlfaEntrenamiento.TabIndex = 93
        Me.TextBox_AlfaEntrenamiento.Text = "0,000001"
        Me.ToolTip1.SetToolTip(Me.TextBox_AlfaEntrenamiento, "Alfa de entrenamiento")
        '
        'TextBox_Salidas
        '
        Me.TextBox_Salidas.Location = New System.Drawing.Point(346, 388)
        Me.TextBox_Salidas.Name = "TextBox_Salidas"
        Me.TextBox_Salidas.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Salidas.TabIndex = 92
        Me.TextBox_Salidas.Text = "1"
        Me.ToolTip1.SetToolTip(Me.TextBox_Salidas, "Conexiones de salida")
        '
        'TextBox_Neuronas
        '
        Me.TextBox_Neuronas.Location = New System.Drawing.Point(240, 388)
        Me.TextBox_Neuronas.Name = "TextBox_Neuronas"
        Me.TextBox_Neuronas.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Neuronas.TabIndex = 91
        Me.TextBox_Neuronas.Text = "5"
        Me.ToolTip1.SetToolTip(Me.TextBox_Neuronas, "Neuronas")
        '
        'TextBox_FactorActivacion
        '
        Me.TextBox_FactorActivacion.Location = New System.Drawing.Point(407, 430)
        Me.TextBox_FactorActivacion.Name = "TextBox_FactorActivacion"
        Me.TextBox_FactorActivacion.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_FactorActivacion.TabIndex = 88
        Me.TextBox_FactorActivacion.Text = "0,1"
        Me.ToolTip1.SetToolTip(Me.TextBox_FactorActivacion, "Factor de activacion")
        '
        'TextBox_ConexionesNumero
        '
        Me.TextBox_ConexionesNumero.Location = New System.Drawing.Point(136, 388)
        Me.TextBox_ConexionesNumero.Name = "TextBox_ConexionesNumero"
        Me.TextBox_ConexionesNumero.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_ConexionesNumero.TabIndex = 86
        Me.TextBox_ConexionesNumero.Text = "2"
        Me.ToolTip1.SetToolTip(Me.TextBox_ConexionesNumero, "Conexiones de entrada")
        '
        'Button_CargarImagen
        '
        Me.Button_CargarImagen.Location = New System.Drawing.Point(912, 97)
        Me.Button_CargarImagen.Name = "Button_CargarImagen"
        Me.Button_CargarImagen.Size = New System.Drawing.Size(119, 23)
        Me.Button_CargarImagen.TabIndex = 112
        Me.Button_CargarImagen.Text = "Cargar Imagen"
        Me.Button_CargarImagen.UseVisualStyleBackColor = True
        '
        'Button_GenerarDataSet
        '
        Me.Button_GenerarDataSet.Location = New System.Drawing.Point(764, 227)
        Me.Button_GenerarDataSet.Name = "Button_GenerarDataSet"
        Me.Button_GenerarDataSet.Size = New System.Drawing.Size(101, 23)
        Me.Button_GenerarDataSet.TabIndex = 105
        Me.Button_GenerarDataSet.Text = "Generar DataSet"
        Me.Button_GenerarDataSet.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(722, 586)
        Me.TabControl1.TabIndex = 111
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button_GenerarRed2)
        Me.TabPage1.Controls.Add(Me.Button_QuitarCapa)
        Me.TabPage1.Controls.Add(Me.ListBox_Neuronas)
        Me.TabPage1.Controls.Add(Me.Button_AñadirCapa)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.PictureBox_ImagenRed)
        Me.TabPage1.Controls.Add(Me.Button_Circulo)
        Me.TabPage1.Controls.Add(Me.Button_EntrenamientoSencillo)
        Me.TabPage1.Controls.Add(Me.Button_BorrarEntrenamiento)
        Me.TabPage1.Controls.Add(Me.Button_APrueba)
        Me.TabPage1.Controls.Add(Me.Button_Aentrenamiento)
        Me.TabPage1.Controls.Add(Me.ComboBox_CerebrosLista)
        Me.TabPage1.Controls.Add(Me.TextBox_Bias)
        Me.TabPage1.Controls.Add(Me.Button_Cargar)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.TextBox_GuardarNombre)
        Me.TabPage1.Controls.Add(Me.Label_X1)
        Me.TabPage1.Controls.Add(Me.Button_Guardar)
        Me.TabPage1.Controls.Add(Me.Button_Test)
        Me.TabPage1.Controls.Add(Me.Button_DetenerNeurona)
        Me.TabPage1.Controls.Add(Me.TextBox_X1)
        Me.TabPage1.Controls.Add(Me.Label_X2)
        Me.TabPage1.Controls.Add(Me.TextBox_X2)
        Me.TabPage1.Controls.Add(Me.TextBox_Capas)
        Me.TabPage1.Controls.Add(Me.Label_Target)
        Me.TabPage1.Controls.Add(Me.TextBox_Momento)
        Me.TabPage1.Controls.Add(Me.Label_Momento)
        Me.TabPage1.Controls.Add(Me.TextBox_Target)
        Me.TabPage1.Controls.Add(Me.TextBox_AlfaEntrenamiento)
        Me.TabPage1.Controls.Add(Me.Label_Independiente)
        Me.TabPage1.Controls.Add(Me.TextBox_Salidas)
        Me.TabPage1.Controls.Add(Me.TextBox_Independiente)
        Me.TabPage1.Controls.Add(Me.TextBox_Neuronas)
        Me.TabPage1.Controls.Add(Me.Label_Umbral)
        Me.TabPage1.Controls.Add(Me.TextBox_EpocasEntrenamiento)
        Me.TabPage1.Controls.Add(Me.TextBox_Umbral)
        Me.TabPage1.Controls.Add(Me.Label_EpocasEntrenamiento)
        Me.TabPage1.Controls.Add(Me.Label_Resultado)
        Me.TabPage1.Controls.Add(Me.TextBox_FactorActivacion)
        Me.TabPage1.Controls.Add(Me.TextBox_Resultado)
        Me.TabPage1.Controls.Add(Me.Label_FactorActivacion)
        Me.TabPage1.Controls.Add(Me.Label_Incremento)
        Me.TabPage1.Controls.Add(Me.TextBox_ConexionesNumero)
        Me.TabPage1.Controls.Add(Me.TextBox_Incremento)
        Me.TabPage1.Controls.Add(Me.Button_Entrenamiento)
        Me.TabPage1.Controls.Add(Me.Button_GenerarRed)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(714, 560)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button_GenerarRed2
        '
        Me.Button_GenerarRed2.Location = New System.Drawing.Point(240, 229)
        Me.Button_GenerarRed2.Name = "Button_GenerarRed2"
        Me.Button_GenerarRed2.Size = New System.Drawing.Size(101, 23)
        Me.Button_GenerarRed2.TabIndex = 118
        Me.Button_GenerarRed2.Text = "GenerarRed 2"
        Me.Button_GenerarRed2.UseVisualStyleBackColor = True
        '
        'Button_QuitarCapa
        '
        Me.Button_QuitarCapa.Location = New System.Drawing.Point(346, 309)
        Me.Button_QuitarCapa.Name = "Button_QuitarCapa"
        Me.Button_QuitarCapa.Size = New System.Drawing.Size(42, 20)
        Me.Button_QuitarCapa.TabIndex = 117
        Me.Button_QuitarCapa.Text = "-"
        Me.Button_QuitarCapa.UseVisualStyleBackColor = True
        '
        'ListBox_Neuronas
        '
        Me.ListBox_Neuronas.FormattingEnabled = True
        Me.ListBox_Neuronas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ListBox_Neuronas.Items.AddRange(New Object() {"5"})
        Me.ListBox_Neuronas.Location = New System.Drawing.Point(240, 283)
        Me.ListBox_Neuronas.Name = "ListBox_Neuronas"
        Me.ListBox_Neuronas.Size = New System.Drawing.Size(100, 56)
        Me.ListBox_Neuronas.TabIndex = 116
        '
        'Button_AñadirCapa
        '
        Me.Button_AñadirCapa.Location = New System.Drawing.Point(346, 283)
        Me.Button_AñadirCapa.Name = "Button_AñadirCapa"
        Me.Button_AñadirCapa.Size = New System.Drawing.Size(42, 20)
        Me.Button_AñadirCapa.TabIndex = 115
        Me.Button_AñadirCapa.Text = "+"
        Me.Button_AñadirCapa.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(195, 455)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 23)
        Me.Button1.TabIndex = 109
        Me.Button1.Text = "Entrenamiento Progresivo"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox_ImagenRed
        '
        Me.PictureBox_ImagenRed.Location = New System.Drawing.Point(7, 4)
        Me.PictureBox_ImagenRed.Name = "PictureBox_ImagenRed"
        Me.PictureBox_ImagenRed.Size = New System.Drawing.Size(701, 218)
        Me.PictureBox_ImagenRed.TabIndex = 108
        Me.PictureBox_ImagenRed.TabStop = False
        '
        'Button_Circulo
        '
        Me.Button_Circulo.Location = New System.Drawing.Point(598, 246)
        Me.Button_Circulo.Name = "Button_Circulo"
        Me.Button_Circulo.Size = New System.Drawing.Size(110, 23)
        Me.Button_Circulo.TabIndex = 107
        Me.Button_Circulo.Text = "entrenamiento cIRCULO"
        Me.Button_Circulo.UseVisualStyleBackColor = True
        '
        'Button_EntrenamientoSencillo
        '
        Me.Button_EntrenamientoSencillo.Location = New System.Drawing.Point(24, 457)
        Me.Button_EntrenamientoSencillo.Name = "Button_EntrenamientoSencillo"
        Me.Button_EntrenamientoSencillo.Size = New System.Drawing.Size(165, 23)
        Me.Button_EntrenamientoSencillo.TabIndex = 106
        Me.Button_EntrenamientoSencillo.Text = "Entrenamiento sencillo"
        Me.Button_EntrenamientoSencillo.UseVisualStyleBackColor = True
        '
        'Button_BorrarEntrenamiento
        '
        Me.Button_BorrarEntrenamiento.Location = New System.Drawing.Point(598, 325)
        Me.Button_BorrarEntrenamiento.Name = "Button_BorrarEntrenamiento"
        Me.Button_BorrarEntrenamiento.Size = New System.Drawing.Size(110, 23)
        Me.Button_BorrarEntrenamiento.TabIndex = 105
        Me.Button_BorrarEntrenamiento.Text = "borrar entrenamiento"
        Me.Button_BorrarEntrenamiento.UseVisualStyleBackColor = True
        '
        'Button_APrueba
        '
        Me.Button_APrueba.Location = New System.Drawing.Point(598, 299)
        Me.Button_APrueba.Name = "Button_APrueba"
        Me.Button_APrueba.Size = New System.Drawing.Size(110, 23)
        Me.Button_APrueba.TabIndex = 104
        Me.Button_APrueba.Text = "a prueba"
        Me.Button_APrueba.UseVisualStyleBackColor = True
        '
        'Button_Aentrenamiento
        '
        Me.Button_Aentrenamiento.Location = New System.Drawing.Point(598, 273)
        Me.Button_Aentrenamiento.Name = "Button_Aentrenamiento"
        Me.Button_Aentrenamiento.Size = New System.Drawing.Size(110, 23)
        Me.Button_Aentrenamiento.TabIndex = 103
        Me.Button_Aentrenamiento.Text = "a entrenamiento"
        Me.Button_Aentrenamiento.UseVisualStyleBackColor = True
        '
        'ComboBox_CerebrosLista
        '
        Me.ComboBox_CerebrosLista.FormattingEnabled = True
        Me.ComboBox_CerebrosLista.Location = New System.Drawing.Point(377, 504)
        Me.ComboBox_CerebrosLista.Name = "ComboBox_CerebrosLista"
        Me.ComboBox_CerebrosLista.Size = New System.Drawing.Size(186, 21)
        Me.ComboBox_CerebrosLista.TabIndex = 102
        '
        'TextBox_Bias
        '
        Me.TextBox_Bias.Location = New System.Drawing.Point(89, 280)
        Me.TextBox_Bias.Name = "TextBox_Bias"
        Me.TextBox_Bias.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Bias.TabIndex = 69
        '
        'Button_Cargar
        '
        Me.Button_Cargar.Location = New System.Drawing.Point(377, 531)
        Me.Button_Cargar.Name = "Button_Cargar"
        Me.Button_Cargar.Size = New System.Drawing.Size(186, 23)
        Me.Button_Cargar.TabIndex = 101
        Me.Button_Cargar.Text = "Cargar"
        Me.Button_Cargar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(56, 283)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Bias"
        '
        'TextBox_GuardarNombre
        '
        Me.TextBox_GuardarNombre.Location = New System.Drawing.Point(169, 504)
        Me.TextBox_GuardarNombre.Name = "TextBox_GuardarNombre"
        Me.TextBox_GuardarNombre.Size = New System.Drawing.Size(186, 20)
        Me.TextBox_GuardarNombre.TabIndex = 98
        '
        'Label_X1
        '
        Me.Label_X1.AutoSize = True
        Me.Label_X1.Location = New System.Drawing.Point(439, 254)
        Me.Label_X1.Name = "Label_X1"
        Me.Label_X1.Size = New System.Drawing.Size(47, 13)
        Me.Label_X1.TabIndex = 70
        Me.Label_X1.Text = "Valor X1"
        '
        'Button_Guardar
        '
        Me.Button_Guardar.Location = New System.Drawing.Point(169, 530)
        Me.Button_Guardar.Name = "Button_Guardar"
        Me.Button_Guardar.Size = New System.Drawing.Size(186, 23)
        Me.Button_Guardar.TabIndex = 97
        Me.Button_Guardar.Text = "Guardar"
        Me.Button_Guardar.UseVisualStyleBackColor = True
        '
        'Button_Test
        '
        Me.Button_Test.Location = New System.Drawing.Point(24, 486)
        Me.Button_Test.Name = "Button_Test"
        Me.Button_Test.Size = New System.Drawing.Size(101, 23)
        Me.Button_Test.TabIndex = 99
        Me.Button_Test.Text = "Test"
        Me.Button_Test.UseVisualStyleBackColor = True
        '
        'Button_DetenerNeurona
        '
        Me.Button_DetenerNeurona.Location = New System.Drawing.Point(24, 515)
        Me.Button_DetenerNeurona.Name = "Button_DetenerNeurona"
        Me.Button_DetenerNeurona.Size = New System.Drawing.Size(99, 23)
        Me.Button_DetenerNeurona.TabIndex = 66
        Me.Button_DetenerNeurona.Text = "Detener"
        Me.Button_DetenerNeurona.UseVisualStyleBackColor = True
        '
        'TextBox_X1
        '
        Me.TextBox_X1.Location = New System.Drawing.Point(492, 247)
        Me.TextBox_X1.Name = "TextBox_X1"
        Me.TextBox_X1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_X1.TabIndex = 71
        '
        'Label_X2
        '
        Me.Label_X2.AutoSize = True
        Me.Label_X2.Location = New System.Drawing.Point(439, 276)
        Me.Label_X2.Name = "Label_X2"
        Me.Label_X2.Size = New System.Drawing.Size(47, 13)
        Me.Label_X2.TabIndex = 72
        Me.Label_X2.Text = "Valor X2"
        '
        'TextBox_X2
        '
        Me.TextBox_X2.Location = New System.Drawing.Point(492, 273)
        Me.TextBox_X2.Name = "TextBox_X2"
        Me.TextBox_X2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_X2.TabIndex = 73
        '
        'Label_Target
        '
        Me.Label_Target.AutoSize = True
        Me.Label_Target.Location = New System.Drawing.Point(426, 302)
        Me.Label_Target.Name = "Label_Target"
        Me.Label_Target.Size = New System.Drawing.Size(60, 13)
        Me.Label_Target.TabIndex = 74
        Me.Label_Target.Text = "Target (S1)"
        '
        'Label_Momento
        '
        Me.Label_Momento.AutoSize = True
        Me.Label_Momento.Location = New System.Drawing.Point(34, 335)
        Me.Label_Momento.Name = "Label_Momento"
        Me.Label_Momento.Size = New System.Drawing.Size(51, 13)
        Me.Label_Momento.TabIndex = 94
        Me.Label_Momento.Text = "Momento"
        '
        'TextBox_Target
        '
        Me.TextBox_Target.Location = New System.Drawing.Point(492, 299)
        Me.TextBox_Target.Name = "TextBox_Target"
        Me.TextBox_Target.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Target.TabIndex = 75
        '
        'Label_Independiente
        '
        Me.Label_Independiente.AutoSize = True
        Me.Label_Independiente.Location = New System.Drawing.Point(8, 309)
        Me.Label_Independiente.Name = "Label_Independiente"
        Me.Label_Independiente.Size = New System.Drawing.Size(75, 13)
        Me.Label_Independiente.TabIndex = 76
        Me.Label_Independiente.Text = "Independiente"
        '
        'TextBox_Independiente
        '
        Me.TextBox_Independiente.Location = New System.Drawing.Point(89, 306)
        Me.TextBox_Independiente.Name = "TextBox_Independiente"
        Me.TextBox_Independiente.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Independiente.TabIndex = 77
        '
        'Label_Umbral
        '
        Me.Label_Umbral.AutoSize = True
        Me.Label_Umbral.Location = New System.Drawing.Point(43, 231)
        Me.Label_Umbral.Name = "Label_Umbral"
        Me.Label_Umbral.Size = New System.Drawing.Size(40, 13)
        Me.Label_Umbral.TabIndex = 78
        Me.Label_Umbral.Text = "Umbral"
        '
        'TextBox_EpocasEntrenamiento
        '
        Me.TextBox_EpocasEntrenamiento.Location = New System.Drawing.Point(407, 456)
        Me.TextBox_EpocasEntrenamiento.Name = "TextBox_EpocasEntrenamiento"
        Me.TextBox_EpocasEntrenamiento.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_EpocasEntrenamiento.TabIndex = 90
        Me.TextBox_EpocasEntrenamiento.Text = "100"
        '
        'TextBox_Umbral
        '
        Me.TextBox_Umbral.Location = New System.Drawing.Point(89, 228)
        Me.TextBox_Umbral.Name = "TextBox_Umbral"
        Me.TextBox_Umbral.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Umbral.TabIndex = 79
        '
        'Label_EpocasEntrenamiento
        '
        Me.Label_EpocasEntrenamiento.AutoSize = True
        Me.Label_EpocasEntrenamiento.Location = New System.Drawing.Point(273, 459)
        Me.Label_EpocasEntrenamiento.Name = "Label_EpocasEntrenamiento"
        Me.Label_EpocasEntrenamiento.Size = New System.Drawing.Size(128, 13)
        Me.Label_EpocasEntrenamiento.TabIndex = 89
        Me.Label_EpocasEntrenamiento.Text = "Epocas de entrenamiento"
        '
        'Label_Resultado
        '
        Me.Label_Resultado.AutoSize = True
        Me.Label_Resultado.Location = New System.Drawing.Point(521, 357)
        Me.Label_Resultado.Name = "Label_Resultado"
        Me.Label_Resultado.Size = New System.Drawing.Size(71, 13)
        Me.Label_Resultado.TabIndex = 80
        Me.Label_Resultado.Text = "Resultado Y1"
        '
        'TextBox_Resultado
        '
        Me.TextBox_Resultado.Location = New System.Drawing.Point(598, 354)
        Me.TextBox_Resultado.Multiline = True
        Me.TextBox_Resultado.Name = "TextBox_Resultado"
        Me.TextBox_Resultado.Size = New System.Drawing.Size(103, 68)
        Me.TextBox_Resultado.TabIndex = 81
        '
        'Label_FactorActivacion
        '
        Me.Label_FactorActivacion.AutoSize = True
        Me.Label_FactorActivacion.Location = New System.Drawing.Point(312, 433)
        Me.Label_FactorActivacion.Name = "Label_FactorActivacion"
        Me.Label_FactorActivacion.Size = New System.Drawing.Size(89, 13)
        Me.Label_FactorActivacion.TabIndex = 87
        Me.Label_FactorActivacion.Text = "Facrot activacion"
        '
        'Label_Incremento
        '
        Me.Label_Incremento.AutoSize = True
        Me.Label_Incremento.Location = New System.Drawing.Point(23, 257)
        Me.Label_Incremento.Name = "Label_Incremento"
        Me.Label_Incremento.Size = New System.Drawing.Size(60, 13)
        Me.Label_Incremento.TabIndex = 83
        Me.Label_Incremento.Text = "Incremento"
        '
        'TextBox_Incremento
        '
        Me.TextBox_Incremento.Location = New System.Drawing.Point(89, 254)
        Me.TextBox_Incremento.Name = "TextBox_Incremento"
        Me.TextBox_Incremento.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Incremento.TabIndex = 84
        '
        'Button_Entrenamiento
        '
        Me.Button_Entrenamiento.Location = New System.Drawing.Point(24, 428)
        Me.Button_Entrenamiento.Name = "Button_Entrenamiento"
        Me.Button_Entrenamiento.Size = New System.Drawing.Size(165, 23)
        Me.Button_Entrenamiento.TabIndex = 60
        Me.Button_Entrenamiento.Text = "Entrenamiento"
        Me.Button_Entrenamiento.UseVisualStyleBackColor = True
        '
        'Button_GenerarRed
        '
        Me.Button_GenerarRed.Location = New System.Drawing.Point(24, 388)
        Me.Button_GenerarRed.Name = "Button_GenerarRed"
        Me.Button_GenerarRed.Size = New System.Drawing.Size(101, 23)
        Me.Button_GenerarRed.TabIndex = 64
        Me.Button_GenerarRed.Text = "GenerarRed"
        Me.Button_GenerarRed.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button_Divide)
        Me.TabPage2.Controls.Add(Me.Button_Suma)
        Me.TabPage2.Controls.Add(Me.Button_Pruebas)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(714, 560)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button_Divide
        '
        Me.Button_Divide.Location = New System.Drawing.Point(111, 385)
        Me.Button_Divide.Name = "Button_Divide"
        Me.Button_Divide.Size = New System.Drawing.Size(75, 23)
        Me.Button_Divide.TabIndex = 59
        Me.Button_Divide.Text = "Divide "
        Me.Button_Divide.UseVisualStyleBackColor = True
        '
        'Button_Suma
        '
        Me.Button_Suma.Location = New System.Drawing.Point(30, 385)
        Me.Button_Suma.Name = "Button_Suma"
        Me.Button_Suma.Size = New System.Drawing.Size(75, 23)
        Me.Button_Suma.TabIndex = 58
        Me.Button_Suma.Text = "Suma +"
        Me.Button_Suma.UseVisualStyleBackColor = True
        '
        'Button_Pruebas
        '
        Me.Button_Pruebas.Location = New System.Drawing.Point(192, 385)
        Me.Button_Pruebas.Name = "Button_Pruebas"
        Me.Button_Pruebas.Size = New System.Drawing.Size(75, 23)
        Me.Button_Pruebas.TabIndex = 63
        Me.Button_Pruebas.Text = "Pruebas"
        Me.Button_Pruebas.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(740, 389)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(291, 205)
        Me.RichTextBox1.TabIndex = 108
        Me.RichTextBox1.Text = ""
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(784, 48)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox1.TabIndex = 107
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button_RedImagen
        '
        Me.Button_RedImagen.Location = New System.Drawing.Point(762, 285)
        Me.Button_RedImagen.Name = "Button_RedImagen"
        Me.Button_RedImagen.Size = New System.Drawing.Size(101, 23)
        Me.Button_RedImagen.TabIndex = 104
        Me.Button_RedImagen.Text = "Red imagen"
        Me.Button_RedImagen.UseVisualStyleBackColor = True
        '
        'Button_DataSheEntrenamiento
        '
        Me.Button_DataSheEntrenamiento.Location = New System.Drawing.Point(764, 256)
        Me.Button_DataSheEntrenamiento.Name = "Button_DataSheEntrenamiento"
        Me.Button_DataSheEntrenamiento.Size = New System.Drawing.Size(101, 23)
        Me.Button_DataSheEntrenamiento.TabIndex = 106
        Me.Button_DataSheEntrenamiento.Text = "DataSet a entrenamiento"
        Me.Button_DataSheEntrenamiento.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(842, 97)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox2.TabIndex = 114
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(772, 97)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox1.TabIndex = 113
        Me.PictureBox1.TabStop = False
        '
        'Button_GenerarEntrenaCirculo
        '
        Me.Button_GenerarEntrenaCirculo.Location = New System.Drawing.Point(871, 227)
        Me.Button_GenerarEntrenaCirculo.Name = "Button_GenerarEntrenaCirculo"
        Me.Button_GenerarEntrenaCirculo.Size = New System.Drawing.Size(164, 23)
        Me.Button_GenerarEntrenaCirculo.TabIndex = 115
        Me.Button_GenerarEntrenaCirculo.Text = "Generar Entrena circulo"
        Me.Button_GenerarEntrenaCirculo.UseVisualStyleBackColor = True
        '
        'Button_GenerarEntrenaCirculo2
        '
        Me.Button_GenerarEntrenaCirculo2.Location = New System.Drawing.Point(871, 256)
        Me.Button_GenerarEntrenaCirculo2.Name = "Button_GenerarEntrenaCirculo2"
        Me.Button_GenerarEntrenaCirculo2.Size = New System.Drawing.Size(164, 23)
        Me.Button_GenerarEntrenaCirculo2.TabIndex = 116
        Me.Button_GenerarEntrenaCirculo2.Text = "Agrega entrena circulo "
        Me.Button_GenerarEntrenaCirculo2.UseVisualStyleBackColor = True
        '
        'Form_PerceptronGithub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1047, 609)
        Me.Controls.Add(Me.Button_GenerarEntrenaCirculo2)
        Me.Controls.Add(Me.Button_GenerarEntrenaCirculo)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button_CargarImagen)
        Me.Controls.Add(Me.Button_GenerarDataSet)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button_RedImagen)
        Me.Controls.Add(Me.Button_DataSheEntrenamiento)
        Me.Name = "Form_PerceptronGithub"
        Me.Text = "Form_PerceptronGithub"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureBox_ImagenRed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Button_CargarImagen As Button
    Friend WithEvents Button_GenerarDataSet As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox_ImagenRed As PictureBox
    Friend WithEvents Button_Circulo As Button
    Friend WithEvents Button_EntrenamientoSencillo As Button
    Friend WithEvents Button_BorrarEntrenamiento As Button
    Friend WithEvents Button_APrueba As Button
    Friend WithEvents Button_Aentrenamiento As Button
    Friend WithEvents ComboBox_CerebrosLista As ComboBox
    Friend WithEvents TextBox_Bias As TextBox
    Friend WithEvents Button_Cargar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox_GuardarNombre As TextBox
    Friend WithEvents Label_X1 As Label
    Friend WithEvents Button_Guardar As Button
    Friend WithEvents Button_Test As Button
    Friend WithEvents Button_DetenerNeurona As Button
    Friend WithEvents TextBox_X1 As TextBox
    Friend WithEvents Label_X2 As Label
    Friend WithEvents TextBox_X2 As TextBox
    Friend WithEvents TextBox_Capas As TextBox
    Friend WithEvents Label_Target As Label
    Friend WithEvents TextBox_Momento As TextBox
    Friend WithEvents Label_Momento As Label
    Friend WithEvents TextBox_Target As TextBox
    Friend WithEvents TextBox_AlfaEntrenamiento As TextBox
    Friend WithEvents Label_Independiente As Label
    Friend WithEvents TextBox_Salidas As TextBox
    Friend WithEvents TextBox_Independiente As TextBox
    Friend WithEvents TextBox_Neuronas As TextBox
    Friend WithEvents Label_Umbral As Label
    Friend WithEvents TextBox_EpocasEntrenamiento As TextBox
    Friend WithEvents TextBox_Umbral As TextBox
    Friend WithEvents Label_EpocasEntrenamiento As Label
    Friend WithEvents Label_Resultado As Label
    Friend WithEvents TextBox_FactorActivacion As TextBox
    Friend WithEvents TextBox_Resultado As TextBox
    Friend WithEvents Label_FactorActivacion As Label
    Friend WithEvents Label_Incremento As Label
    Friend WithEvents TextBox_ConexionesNumero As TextBox
    Friend WithEvents TextBox_Incremento As TextBox
    Friend WithEvents Button_Entrenamiento As Button
    Friend WithEvents Button_GenerarRed As Button
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Button_Divide As Button
    Friend WithEvents Button_Suma As Button
    Friend WithEvents Button_Pruebas As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button_RedImagen As Button
    Friend WithEvents Button_DataSheEntrenamiento As Button
    Friend WithEvents Button_QuitarCapa As Button
    Public WithEvents ListBox_Neuronas As ListBox
    Friend WithEvents Button_AñadirCapa As Button
    Friend WithEvents Button_GenerarRed2 As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button_GenerarEntrenaCirculo As Button
    Friend WithEvents Button_GenerarEntrenaCirculo2 As Button
End Class
