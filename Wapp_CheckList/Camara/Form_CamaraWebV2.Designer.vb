<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_CamaraWebV2
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
        Me.PictureBox_Camara = New System.Windows.Forms.PictureBox()
        Me.GroupBox_Camara = New System.Windows.Forms.GroupBox()
        Me.Label_Zoom = New System.Windows.Forms.Label()
        Me.Label_BitsColor = New System.Windows.Forms.Label()
        Me.TextBox_FPS = New System.Windows.Forms.TextBox()
        Me.Label_FPS = New System.Windows.Forms.Label()
        Me.ComboBox_Zoom = New System.Windows.Forms.ComboBox()
        Me.ComboBox_BitsColor = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Resolucion = New System.Windows.Forms.ComboBox()
        Me.TextBox_TiempoFotos = New System.Windows.Forms.TextBox()
        Me.TextBox_ResolucionAlto = New System.Windows.Forms.TextBox()
        Me.Label_Resolucion = New System.Windows.Forms.Label()
        Me.TextBox_ResolucionAncho = New System.Windows.Forms.TextBox()
        Me.Button_Capturar = New System.Windows.Forms.Button()
        Me.Label_TiempoActulizacion = New System.Windows.Forms.Label()
        Me.TextBoxl_TiempoActulizacion = New System.Windows.Forms.TextBox()
        Me.Button_PararCam = New System.Windows.Forms.Button()
        Me.Label_TiempoFotos = New System.Windows.Forms.Label()
        Me.Button_IniciarCam = New System.Windows.Forms.Button()
        Me.TextBox_NombreFoto = New System.Windows.Forms.TextBox()
        Me.Label_NombreFoto = New System.Windows.Forms.Label()
        Me.Label_Camaras = New System.Windows.Forms.Label()
        Me.ComboBox_Camaras = New System.Windows.Forms.ComboBox()
        CType(Me.PictureBox_Camara, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_Camara.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox_Camara
        '
        Me.PictureBox_Camara.Location = New System.Drawing.Point(13, 13)
        Me.PictureBox_Camara.Name = "PictureBox_Camara"
        Me.PictureBox_Camara.Size = New System.Drawing.Size(640, 480)
        Me.PictureBox_Camara.TabIndex = 0
        Me.PictureBox_Camara.TabStop = False
        '
        'GroupBox_Camara
        '
        Me.GroupBox_Camara.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.GroupBox_Camara.Controls.Add(Me.Label_Zoom)
        Me.GroupBox_Camara.Controls.Add(Me.Label_BitsColor)
        Me.GroupBox_Camara.Controls.Add(Me.TextBox_FPS)
        Me.GroupBox_Camara.Controls.Add(Me.Label_FPS)
        Me.GroupBox_Camara.Controls.Add(Me.ComboBox_Zoom)
        Me.GroupBox_Camara.Controls.Add(Me.ComboBox_BitsColor)
        Me.GroupBox_Camara.Controls.Add(Me.ComboBox_Resolucion)
        Me.GroupBox_Camara.Controls.Add(Me.TextBox_TiempoFotos)
        Me.GroupBox_Camara.Controls.Add(Me.TextBox_ResolucionAlto)
        Me.GroupBox_Camara.Controls.Add(Me.Label_Resolucion)
        Me.GroupBox_Camara.Controls.Add(Me.TextBox_ResolucionAncho)
        Me.GroupBox_Camara.Controls.Add(Me.Button_Capturar)
        Me.GroupBox_Camara.Controls.Add(Me.Label_TiempoActulizacion)
        Me.GroupBox_Camara.Controls.Add(Me.TextBoxl_TiempoActulizacion)
        Me.GroupBox_Camara.Controls.Add(Me.Button_PararCam)
        Me.GroupBox_Camara.Controls.Add(Me.Label_TiempoFotos)
        Me.GroupBox_Camara.Controls.Add(Me.Button_IniciarCam)
        Me.GroupBox_Camara.Location = New System.Drawing.Point(659, 13)
        Me.GroupBox_Camara.Name = "GroupBox_Camara"
        Me.GroupBox_Camara.Size = New System.Drawing.Size(406, 197)
        Me.GroupBox_Camara.TabIndex = 30
        Me.GroupBox_Camara.TabStop = False
        Me.GroupBox_Camara.Text = "Camara"
        '
        'Label_Zoom
        '
        Me.Label_Zoom.AutoSize = True
        Me.Label_Zoom.Location = New System.Drawing.Point(25, 173)
        Me.Label_Zoom.Name = "Label_Zoom"
        Me.Label_Zoom.Size = New System.Drawing.Size(34, 13)
        Me.Label_Zoom.TabIndex = 35
        Me.Label_Zoom.Text = "Zoom"
        '
        'Label_BitsColor
        '
        Me.Label_BitsColor.AutoSize = True
        Me.Label_BitsColor.Location = New System.Drawing.Point(9, 119)
        Me.Label_BitsColor.Name = "Label_BitsColor"
        Me.Label_BitsColor.Size = New System.Drawing.Size(50, 13)
        Me.Label_BitsColor.TabIndex = 34
        Me.Label_BitsColor.Text = "Bits color"
        '
        'TextBox_FPS
        '
        Me.TextBox_FPS.Location = New System.Drawing.Point(65, 143)
        Me.TextBox_FPS.Name = "TextBox_FPS"
        Me.TextBox_FPS.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_FPS.TabIndex = 33
        Me.TextBox_FPS.Text = "15"
        '
        'Label_FPS
        '
        Me.Label_FPS.AutoSize = True
        Me.Label_FPS.Location = New System.Drawing.Point(32, 146)
        Me.Label_FPS.Name = "Label_FPS"
        Me.Label_FPS.Size = New System.Drawing.Size(27, 13)
        Me.Label_FPS.TabIndex = 32
        Me.Label_FPS.Text = "FPS"
        '
        'ComboBox_Zoom
        '
        Me.ComboBox_Zoom.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.ComboBox_Zoom.FormattingEnabled = True
        Me.ComboBox_Zoom.Items.AddRange(New Object() {"AutoSize", "CenterImage", "Normal", "StretchImage", "Zoom"})
        Me.ComboBox_Zoom.Location = New System.Drawing.Point(65, 170)
        Me.ComboBox_Zoom.Name = "ComboBox_Zoom"
        Me.ComboBox_Zoom.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox_Zoom.TabIndex = 31
        Me.ComboBox_Zoom.Text = "Zoom"
        '
        'ComboBox_BitsColor
        '
        Me.ComboBox_BitsColor.FormattingEnabled = True
        Me.ComboBox_BitsColor.Items.AddRange(New Object() {"32", "24", "16", "8", "4"})
        Me.ComboBox_BitsColor.Location = New System.Drawing.Point(65, 116)
        Me.ComboBox_BitsColor.Name = "ComboBox_BitsColor"
        Me.ComboBox_BitsColor.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox_BitsColor.TabIndex = 12
        Me.ComboBox_BitsColor.Text = "24"
        '
        'ComboBox_Resolucion
        '
        Me.ComboBox_Resolucion.FormattingEnabled = True
        Me.ComboBox_Resolucion.Items.AddRange(New Object() {"2592·1944", "1920·1080", "1280·720", "640·480", "320·240"})
        Me.ComboBox_Resolucion.Location = New System.Drawing.Point(135, 20)
        Me.ComboBox_Resolucion.Name = "ComboBox_Resolucion"
        Me.ComboBox_Resolucion.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox_Resolucion.TabIndex = 11
        '
        'TextBox_TiempoFotos
        '
        Me.TextBox_TiempoFotos.Location = New System.Drawing.Point(276, 92)
        Me.TextBox_TiempoFotos.Name = "TextBox_TiempoFotos"
        Me.TextBox_TiempoFotos.Size = New System.Drawing.Size(75, 20)
        Me.TextBox_TiempoFotos.TabIndex = 10
        Me.TextBox_TiempoFotos.Text = "2000"
        '
        'TextBox_ResolucionAlto
        '
        Me.TextBox_ResolucionAlto.Location = New System.Drawing.Point(135, 92)
        Me.TextBox_ResolucionAlto.Name = "TextBox_ResolucionAlto"
        Me.TextBox_ResolucionAlto.Size = New System.Drawing.Size(77, 20)
        Me.TextBox_ResolucionAlto.TabIndex = 5
        Me.TextBox_ResolucionAlto.Text = "1944"
        '
        'Label_Resolucion
        '
        Me.Label_Resolucion.AutoSize = True
        Me.Label_Resolucion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_Resolucion.Location = New System.Drawing.Point(135, 50)
        Me.Label_Resolucion.Name = "Label_Resolucion"
        Me.Label_Resolucion.Size = New System.Drawing.Size(62, 15)
        Me.Label_Resolucion.TabIndex = 6
        Me.Label_Resolucion.Text = "Resolucion"
        '
        'TextBox_ResolucionAncho
        '
        Me.TextBox_ResolucionAncho.Location = New System.Drawing.Point(135, 66)
        Me.TextBox_ResolucionAncho.Name = "TextBox_ResolucionAncho"
        Me.TextBox_ResolucionAncho.Size = New System.Drawing.Size(77, 20)
        Me.TextBox_ResolucionAncho.TabIndex = 4
        Me.TextBox_ResolucionAncho.Text = "2592"
        '
        'Button_Capturar
        '
        Me.Button_Capturar.Location = New System.Drawing.Point(12, 84)
        Me.Button_Capturar.Name = "Button_Capturar"
        Me.Button_Capturar.Size = New System.Drawing.Size(106, 23)
        Me.Button_Capturar.TabIndex = 3
        Me.Button_Capturar.Text = "Capturar"
        Me.Button_Capturar.UseVisualStyleBackColor = True
        '
        'Label_TiempoActulizacion
        '
        Me.Label_TiempoActulizacion.AutoSize = True
        Me.Label_TiempoActulizacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_TiempoActulizacion.Location = New System.Drawing.Point(276, 29)
        Me.Label_TiempoActulizacion.Name = "Label_TiempoActulizacion"
        Me.Label_TiempoActulizacion.Size = New System.Drawing.Size(118, 15)
        Me.Label_TiempoActulizacion.TabIndex = 7
        Me.Label_TiempoActulizacion.Text = "Tiempo de actulizacion"
        '
        'TextBoxl_TiempoActulizacion
        '
        Me.TextBoxl_TiempoActulizacion.Location = New System.Drawing.Point(276, 45)
        Me.TextBoxl_TiempoActulizacion.Name = "TextBoxl_TiempoActulizacion"
        Me.TextBoxl_TiempoActulizacion.Size = New System.Drawing.Size(75, 20)
        Me.TextBoxl_TiempoActulizacion.TabIndex = 9
        Me.TextBoxl_TiempoActulizacion.Text = "67"
        '
        'Button_PararCam
        '
        Me.Button_PararCam.Location = New System.Drawing.Point(12, 54)
        Me.Button_PararCam.Name = "Button_PararCam"
        Me.Button_PararCam.Size = New System.Drawing.Size(106, 23)
        Me.Button_PararCam.TabIndex = 2
        Me.Button_PararCam.Text = "Parar"
        Me.Button_PararCam.UseVisualStyleBackColor = True
        '
        'Label_TiempoFotos
        '
        Me.Label_TiempoFotos.AutoSize = True
        Me.Label_TiempoFotos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_TiempoFotos.Location = New System.Drawing.Point(276, 76)
        Me.Label_TiempoFotos.Name = "Label_TiempoFotos"
        Me.Label_TiempoFotos.Size = New System.Drawing.Size(97, 15)
        Me.Label_TiempoFotos.TabIndex = 8
        Me.Label_TiempoFotos.Text = "Tiempo entre fotos"
        '
        'Button_IniciarCam
        '
        Me.Button_IniciarCam.Location = New System.Drawing.Point(12, 24)
        Me.Button_IniciarCam.Name = "Button_IniciarCam"
        Me.Button_IniciarCam.Size = New System.Drawing.Size(106, 23)
        Me.Button_IniciarCam.TabIndex = 1
        Me.Button_IniciarCam.Text = "Iniciar"
        Me.Button_IniciarCam.UseVisualStyleBackColor = True
        '
        'TextBox_NombreFoto
        '
        Me.TextBox_NombreFoto.Location = New System.Drawing.Point(730, 251)
        Me.TextBox_NombreFoto.Name = "TextBox_NombreFoto"
        Me.TextBox_NombreFoto.Size = New System.Drawing.Size(335, 20)
        Me.TextBox_NombreFoto.TabIndex = 31
        '
        'Label_NombreFoto
        '
        Me.Label_NombreFoto.AutoSize = True
        Me.Label_NombreFoto.Location = New System.Drawing.Point(656, 254)
        Me.Label_NombreFoto.Name = "Label_NombreFoto"
        Me.Label_NombreFoto.Size = New System.Drawing.Size(68, 13)
        Me.Label_NombreFoto.TabIndex = 32
        Me.Label_NombreFoto.Text = "Nombre Foto"
        '
        'Label_Camaras
        '
        Me.Label_Camaras.AutoSize = True
        Me.Label_Camaras.Location = New System.Drawing.Point(676, 224)
        Me.Label_Camaras.Name = "Label_Camaras"
        Me.Label_Camaras.Size = New System.Drawing.Size(48, 13)
        Me.Label_Camaras.TabIndex = 33
        Me.Label_Camaras.Text = "Camaras"
        '
        'ComboBox_Camaras
        '
        Me.ComboBox_Camaras.FormattingEnabled = True
        Me.ComboBox_Camaras.Location = New System.Drawing.Point(730, 221)
        Me.ComboBox_Camaras.Name = "ComboBox_Camaras"
        Me.ComboBox_Camaras.Size = New System.Drawing.Size(335, 21)
        Me.ComboBox_Camaras.TabIndex = 34
        '
        'Form_CamaraWebV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1077, 501)
        Me.Controls.Add(Me.ComboBox_Camaras)
        Me.Controls.Add(Me.Label_Camaras)
        Me.Controls.Add(Me.Label_NombreFoto)
        Me.Controls.Add(Me.TextBox_NombreFoto)
        Me.Controls.Add(Me.GroupBox_Camara)
        Me.Controls.Add(Me.PictureBox_Camara)
        Me.Name = "Form_CamaraWebV2"
        Me.Text = "Form_CamaraWebV2"
        CType(Me.PictureBox_Camara, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_Camara.ResumeLayout(False)
        Me.GroupBox_Camara.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox_Camara As PictureBox
    Friend WithEvents GroupBox_Camara As GroupBox
    Friend WithEvents ComboBox_Resolucion As ComboBox
    Friend WithEvents TextBox_TiempoFotos As TextBox
    Friend WithEvents TextBox_ResolucionAlto As TextBox
    Friend WithEvents Label_Resolucion As Label
    Friend WithEvents TextBox_ResolucionAncho As TextBox
    Friend WithEvents Button_Capturar As Button
    Friend WithEvents Label_TiempoActulizacion As Label
    Friend WithEvents TextBoxl_TiempoActulizacion As TextBox
    Friend WithEvents Button_PararCam As Button
    Friend WithEvents Label_TiempoFotos As Label
    Friend WithEvents Button_IniciarCam As Button
    Friend WithEvents ComboBox_BitsColor As ComboBox
    Friend WithEvents TextBox_NombreFoto As TextBox
    Friend WithEvents Label_NombreFoto As Label
    Friend WithEvents Label_Camaras As Label
    Friend WithEvents ComboBox_Camaras As ComboBox
    Friend WithEvents ComboBox_Zoom As ComboBox
    Friend WithEvents Label_Zoom As Label
    Friend WithEvents Label_BitsColor As Label
    Friend WithEvents TextBox_FPS As TextBox
    Friend WithEvents Label_FPS As Label
End Class
