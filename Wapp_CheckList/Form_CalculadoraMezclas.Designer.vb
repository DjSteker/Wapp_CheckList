<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_CalculadoraMezclas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label_MezclaTotal = New System.Windows.Forms.Label()
        Me.TextBox_MezclaTotal = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageMezclas = New System.Windows.Forms.TabPage()
        Me.Button_CalcularMezcla = New System.Windows.Forms.Button()
        Me.TextBox_Proporcion2Porcentaje = New System.Windows.Forms.TextBox()
        Me.Label_Proporcion2Porcentaje = New System.Windows.Forms.Label()
        Me.TextBox_Proporcion1Porcentaje = New System.Windows.Forms.TextBox()
        Me.Label_Proporcion1Porcentaje = New System.Windows.Forms.Label()
        Me.TextBox_Proporcion2 = New System.Windows.Forms.TextBox()
        Me.Label_Proporcion2 = New System.Windows.Forms.Label()
        Me.TextBox_ResultadoMezcla = New System.Windows.Forms.TextBox()
        Me.Label_ResultadoMezcla = New System.Windows.Forms.Label()
        Me.TextBox_Proporcion1 = New System.Windows.Forms.TextBox()
        Me.Label_Proporcion1 = New System.Windows.Forms.Label()
        Me.TabPageAleaciones = New System.Windows.Forms.TabPage()
        Me.Button_CalcularAleacion = New System.Windows.Forms.Button()
        Me.TextBox_Ley2 = New System.Windows.Forms.TextBox()
        Me.Label_Ley2 = New System.Windows.Forms.Label()
        Me.TextBox_Ley1 = New System.Windows.Forms.TextBox()
        Me.Label_Ley1 = New System.Windows.Forms.Label()
        Me.TextBox_Peso2 = New System.Windows.Forms.TextBox()
        Me.Label_Peso2 = New System.Windows.Forms.Label()
        Me.TextBox_ResultadoAleacion = New System.Windows.Forms.TextBox()
        Me.Label_ResultadoAleacion = New System.Windows.Forms.Label()
        Me.TextBox_Peso1 = New System.Windows.Forms.TextBox()
        Me.Label_Peso1 = New System.Windows.Forms.Label()
        Me.TextBox_PesoTotal = New System.Windows.Forms.TextBox()
        Me.Label_PesoTotal = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPageMezclas.SuspendLayout()
        Me.TabPageAleaciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label_MezclaTotal
        '
        Me.Label_MezclaTotal.AutoSize = True
        Me.Label_MezclaTotal.Location = New System.Drawing.Point(58, 27)
        Me.Label_MezclaTotal.Name = "Label_MezclaTotal"
        Me.Label_MezclaTotal.Size = New System.Drawing.Size(65, 13)
        Me.Label_MezclaTotal.TabIndex = 0
        Me.Label_MezclaTotal.Text = "MezclaTotal"
        '
        'TextBox_MezclaTotal
        '
        Me.TextBox_MezclaTotal.Location = New System.Drawing.Point(129, 24)
        Me.TextBox_MezclaTotal.Name = "TextBox_MezclaTotal"
        Me.TextBox_MezclaTotal.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_MezclaTotal.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageMezclas)
        Me.TabControl1.Controls.Add(Me.TabPageAleaciones)
        Me.TabControl1.Location = New System.Drawing.Point(13, 61)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(775, 377)
        Me.TabControl1.TabIndex = 2
        '
        'TabPageMezclas
        '
        Me.TabPageMezclas.Controls.Add(Me.Button_CalcularMezcla)
        Me.TabPageMezclas.Controls.Add(Me.TextBox_Proporcion2Porcentaje)
        Me.TabPageMezclas.Controls.Add(Me.Label_Proporcion2Porcentaje)
        Me.TabPageMezclas.Controls.Add(Me.TextBox_Proporcion1Porcentaje)
        Me.TabPageMezclas.Controls.Add(Me.Label_Proporcion1Porcentaje)
        Me.TabPageMezclas.Controls.Add(Me.TextBox_Proporcion2)
        Me.TabPageMezclas.Controls.Add(Me.Label_Proporcion2)
        Me.TabPageMezclas.Controls.Add(Me.TextBox_ResultadoMezcla)
        Me.TabPageMezclas.Controls.Add(Me.Label_ResultadoMezcla)
        Me.TabPageMezclas.Controls.Add(Me.TextBox_Proporcion1)
        Me.TabPageMezclas.Controls.Add(Me.Label_Proporcion1)
        Me.TabPageMezclas.Controls.Add(Me.TextBox_MezclaTotal)
        Me.TabPageMezclas.Controls.Add(Me.Label_MezclaTotal)
        Me.TabPageMezclas.Location = New System.Drawing.Point(4, 22)
        Me.TabPageMezclas.Name = "TabPageMezclas"
        Me.TabPageMezclas.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageMezclas.Size = New System.Drawing.Size(767, 351)
        Me.TabPageMezclas.TabIndex = 0
        Me.TabPageMezclas.Text = "Mezclas"
        Me.TabPageMezclas.UseVisualStyleBackColor = True
        '
        'Button_CalcularMezcla
        '
        Me.Button_CalcularMezcla.Location = New System.Drawing.Point(34, 128)
        Me.Button_CalcularMezcla.Name = "Button_CalcularMezcla"
        Me.Button_CalcularMezcla.Size = New System.Drawing.Size(471, 23)
        Me.Button_CalcularMezcla.TabIndex = 16
        Me.Button_CalcularMezcla.Text = "CalcularMezcla"
        Me.Button_CalcularMezcla.UseVisualStyleBackColor = True
        '
        'TextBox_Proporcion2Porcentaje
        '
        Me.TextBox_Proporcion2Porcentaje.Location = New System.Drawing.Point(405, 76)
        Me.TextBox_Proporcion2Porcentaje.Name = "TextBox_Proporcion2Porcentaje"
        Me.TextBox_Proporcion2Porcentaje.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Proporcion2Porcentaje.TabIndex = 15
        '
        'Label_Proporcion2Porcentaje
        '
        Me.Label_Proporcion2Porcentaje.AutoSize = True
        Me.Label_Proporcion2Porcentaje.Location = New System.Drawing.Point(284, 79)
        Me.Label_Proporcion2Porcentaje.Name = "Label_Proporcion2Porcentaje"
        Me.Label_Proporcion2Porcentaje.Size = New System.Drawing.Size(115, 13)
        Me.Label_Proporcion2Porcentaje.TabIndex = 14
        Me.Label_Proporcion2Porcentaje.Text = "Proporcion2Porcentaje"
        '
        'TextBox_Proporcion1Porcentaje
        '
        Me.TextBox_Proporcion1Porcentaje.Location = New System.Drawing.Point(405, 53)
        Me.TextBox_Proporcion1Porcentaje.Name = "TextBox_Proporcion1Porcentaje"
        Me.TextBox_Proporcion1Porcentaje.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Proporcion1Porcentaje.TabIndex = 13
        '
        'Label_Proporcion1Porcentaje
        '
        Me.Label_Proporcion1Porcentaje.AutoSize = True
        Me.Label_Proporcion1Porcentaje.Location = New System.Drawing.Point(284, 56)
        Me.Label_Proporcion1Porcentaje.Name = "Label_Proporcion1Porcentaje"
        Me.Label_Proporcion1Porcentaje.Size = New System.Drawing.Size(115, 13)
        Me.Label_Proporcion1Porcentaje.TabIndex = 12
        Me.Label_Proporcion1Porcentaje.Text = "Proporcion1Porcentaje"
        '
        'TextBox_Proporcion2
        '
        Me.TextBox_Proporcion2.Location = New System.Drawing.Point(129, 76)
        Me.TextBox_Proporcion2.Name = "TextBox_Proporcion2"
        Me.TextBox_Proporcion2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Proporcion2.TabIndex = 7
        '
        'Label_Proporcion2
        '
        Me.Label_Proporcion2.AutoSize = True
        Me.Label_Proporcion2.Location = New System.Drawing.Point(59, 79)
        Me.Label_Proporcion2.Name = "Label_Proporcion2"
        Me.Label_Proporcion2.Size = New System.Drawing.Size(64, 13)
        Me.Label_Proporcion2.TabIndex = 6
        Me.Label_Proporcion2.Text = "Proporcion2"
        '
        'TextBox_ResultadoMezcla
        '
        Me.TextBox_ResultadoMezcla.Location = New System.Drawing.Point(129, 102)
        Me.TextBox_ResultadoMezcla.Name = "TextBox_ResultadoMezcla"
        Me.TextBox_ResultadoMezcla.Size = New System.Drawing.Size(376, 20)
        Me.TextBox_ResultadoMezcla.TabIndex = 5
        '
        'Label_ResultadoMezcla
        '
        Me.Label_ResultadoMezcla.AutoSize = True
        Me.Label_ResultadoMezcla.Location = New System.Drawing.Point(31, 105)
        Me.Label_ResultadoMezcla.Name = "Label_ResultadoMezcla"
        Me.Label_ResultadoMezcla.Size = New System.Drawing.Size(92, 13)
        Me.Label_ResultadoMezcla.TabIndex = 4
        Me.Label_ResultadoMezcla.Text = "Resultado Mezcla"
        '
        'TextBox_Proporcion1
        '
        Me.TextBox_Proporcion1.Location = New System.Drawing.Point(129, 50)
        Me.TextBox_Proporcion1.Name = "TextBox_Proporcion1"
        Me.TextBox_Proporcion1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Proporcion1.TabIndex = 3
        '
        'Label_Proporcion1
        '
        Me.Label_Proporcion1.AutoSize = True
        Me.Label_Proporcion1.Location = New System.Drawing.Point(59, 53)
        Me.Label_Proporcion1.Name = "Label_Proporcion1"
        Me.Label_Proporcion1.Size = New System.Drawing.Size(64, 13)
        Me.Label_Proporcion1.TabIndex = 2
        Me.Label_Proporcion1.Text = "Proporcion1"
        '
        'TabPageAleaciones
        '
        Me.TabPageAleaciones.Controls.Add(Me.Button_CalcularAleacion)
        Me.TabPageAleaciones.Controls.Add(Me.TextBox_Ley2)
        Me.TabPageAleaciones.Controls.Add(Me.Label_Ley2)
        Me.TabPageAleaciones.Controls.Add(Me.TextBox_Ley1)
        Me.TabPageAleaciones.Controls.Add(Me.Label_Ley1)
        Me.TabPageAleaciones.Controls.Add(Me.TextBox_Peso2)
        Me.TabPageAleaciones.Controls.Add(Me.Label_Peso2)
        Me.TabPageAleaciones.Controls.Add(Me.TextBox_ResultadoAleacion)
        Me.TabPageAleaciones.Controls.Add(Me.Label_ResultadoAleacion)
        Me.TabPageAleaciones.Controls.Add(Me.TextBox_Peso1)
        Me.TabPageAleaciones.Controls.Add(Me.Label_Peso1)
        Me.TabPageAleaciones.Controls.Add(Me.TextBox_PesoTotal)
        Me.TabPageAleaciones.Controls.Add(Me.Label_PesoTotal)
        Me.TabPageAleaciones.Location = New System.Drawing.Point(4, 22)
        Me.TabPageAleaciones.Name = "TabPageAleaciones"
        Me.TabPageAleaciones.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageAleaciones.Size = New System.Drawing.Size(767, 351)
        Me.TabPageAleaciones.TabIndex = 1
        Me.TabPageAleaciones.Text = "Aleaciones"
        Me.TabPageAleaciones.UseVisualStyleBackColor = True
        '
        'Button_CalcularAleacion
        '
        Me.Button_CalcularAleacion.Location = New System.Drawing.Point(149, 216)
        Me.Button_CalcularAleacion.Name = "Button_CalcularAleacion"
        Me.Button_CalcularAleacion.Size = New System.Drawing.Size(357, 23)
        Me.Button_CalcularAleacion.TabIndex = 29
        Me.Button_CalcularAleacion.Text = "CalcularAleacion"
        Me.Button_CalcularAleacion.UseVisualStyleBackColor = True
        '
        'TextBox_Ley2
        '
        Me.TextBox_Ley2.Location = New System.Drawing.Point(406, 161)
        Me.TextBox_Ley2.Name = "TextBox_Ley2"
        Me.TextBox_Ley2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Ley2.TabIndex = 28
        '
        'Label_Ley2
        '
        Me.Label_Ley2.AutoSize = True
        Me.Label_Ley2.Location = New System.Drawing.Point(370, 167)
        Me.Label_Ley2.Name = "Label_Ley2"
        Me.Label_Ley2.Size = New System.Drawing.Size(30, 13)
        Me.Label_Ley2.TabIndex = 27
        Me.Label_Ley2.Text = "Ley2"
        '
        'TextBox_Ley1
        '
        Me.TextBox_Ley1.Location = New System.Drawing.Point(406, 138)
        Me.TextBox_Ley1.Name = "TextBox_Ley1"
        Me.TextBox_Ley1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Ley1.TabIndex = 26
        '
        'Label_Ley1
        '
        Me.Label_Ley1.AutoSize = True
        Me.Label_Ley1.Location = New System.Drawing.Point(370, 141)
        Me.Label_Ley1.Name = "Label_Ley1"
        Me.Label_Ley1.Size = New System.Drawing.Size(30, 13)
        Me.Label_Ley1.TabIndex = 25
        Me.Label_Ley1.Text = "Ley1"
        '
        'TextBox_Peso2
        '
        Me.TextBox_Peso2.Location = New System.Drawing.Point(244, 164)
        Me.TextBox_Peso2.Name = "TextBox_Peso2"
        Me.TextBox_Peso2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Peso2.TabIndex = 24
        '
        'Label_Peso2
        '
        Me.Label_Peso2.AutoSize = True
        Me.Label_Peso2.Location = New System.Drawing.Point(201, 167)
        Me.Label_Peso2.Name = "Label_Peso2"
        Me.Label_Peso2.Size = New System.Drawing.Size(37, 13)
        Me.Label_Peso2.TabIndex = 23
        Me.Label_Peso2.Text = "Peso2"
        '
        'TextBox_ResultadoAleacion
        '
        Me.TextBox_ResultadoAleacion.Location = New System.Drawing.Point(244, 190)
        Me.TextBox_ResultadoAleacion.Name = "TextBox_ResultadoAleacion"
        Me.TextBox_ResultadoAleacion.Size = New System.Drawing.Size(262, 20)
        Me.TextBox_ResultadoAleacion.TabIndex = 22
        '
        'Label_ResultadoAleacion
        '
        Me.Label_ResultadoAleacion.AutoSize = True
        Me.Label_ResultadoAleacion.Location = New System.Drawing.Point(146, 193)
        Me.Label_ResultadoAleacion.Name = "Label_ResultadoAleacion"
        Me.Label_ResultadoAleacion.Size = New System.Drawing.Size(92, 13)
        Me.Label_ResultadoAleacion.TabIndex = 21
        Me.Label_ResultadoAleacion.Text = "Resultado Mezcla"
        '
        'TextBox_Peso1
        '
        Me.TextBox_Peso1.Location = New System.Drawing.Point(244, 138)
        Me.TextBox_Peso1.Name = "TextBox_Peso1"
        Me.TextBox_Peso1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Peso1.TabIndex = 20
        '
        'Label_Peso1
        '
        Me.Label_Peso1.AutoSize = True
        Me.Label_Peso1.Location = New System.Drawing.Point(201, 141)
        Me.Label_Peso1.Name = "Label_Peso1"
        Me.Label_Peso1.Size = New System.Drawing.Size(37, 13)
        Me.Label_Peso1.TabIndex = 19
        Me.Label_Peso1.Text = "Peso1"
        '
        'TextBox_PesoTotal
        '
        Me.TextBox_PesoTotal.Location = New System.Drawing.Point(244, 112)
        Me.TextBox_PesoTotal.Name = "TextBox_PesoTotal"
        Me.TextBox_PesoTotal.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_PesoTotal.TabIndex = 18
        '
        'Label_PesoTotal
        '
        Me.Label_PesoTotal.AutoSize = True
        Me.Label_PesoTotal.Location = New System.Drawing.Point(183, 115)
        Me.Label_PesoTotal.Name = "Label_PesoTotal"
        Me.Label_PesoTotal.Size = New System.Drawing.Size(55, 13)
        Me.Label_PesoTotal.TabIndex = 17
        Me.Label_PesoTotal.Text = "PesoTotal"
        '
        'Form_CalculadoraMezclas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Form_CalculadoraMezclas"
        Me.Text = "Form_CalculadoraMezclas"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageMezclas.ResumeLayout(False)
        Me.TabPageMezclas.PerformLayout()
        Me.TabPageAleaciones.ResumeLayout(False)
        Me.TabPageAleaciones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label_MezclaTotal As Label
    Friend WithEvents TextBox_MezclaTotal As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageMezclas As TabPage
    Friend WithEvents TabPageAleaciones As TabPage
    Friend WithEvents TextBox_Proporcion2Porcentaje As TextBox
    Friend WithEvents Label_Proporcion2Porcentaje As Label
    Friend WithEvents TextBox_Proporcion1Porcentaje As TextBox
    Friend WithEvents Label_Proporcion1Porcentaje As Label
    Friend WithEvents TextBox_Proporcion2 As TextBox
    Friend WithEvents Label_Proporcion2 As Label
    Friend WithEvents TextBox_ResultadoMezcla As TextBox
    Friend WithEvents Label_ResultadoMezcla As Label
    Friend WithEvents TextBox_Proporcion1 As TextBox
    Friend WithEvents Label_Proporcion1 As Label
    Friend WithEvents Button_CalcularMezcla As Button
    Friend WithEvents Button_CalcularAleacion As Button
    Friend WithEvents TextBox_Ley2 As TextBox
    Friend WithEvents Label_Ley2 As Label
    Friend WithEvents TextBox_Ley1 As TextBox
    Friend WithEvents Label_Ley1 As Label
    Friend WithEvents TextBox_Peso2 As TextBox
    Friend WithEvents Label_Peso2 As Label
    Friend WithEvents TextBox_ResultadoAleacion As TextBox
    Friend WithEvents Label_ResultadoAleacion As Label
    Friend WithEvents TextBox_Peso1 As TextBox
    Friend WithEvents Label_Peso1 As Label
    Friend WithEvents TextBox_PesoTotal As TextBox
    Friend WithEvents Label_PesoTotal As Label
End Class
