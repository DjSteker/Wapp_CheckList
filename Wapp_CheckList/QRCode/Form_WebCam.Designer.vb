<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_WebCam
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
        Me.bntStart = New System.Windows.Forms.Button()
        Me.bntStop = New System.Windows.Forms.Button()
        Me.bntContinue = New System.Windows.Forms.Button()
        Me.bntCapture = New System.Windows.Forms.Button()
        Me.bntSave = New System.Windows.Forms.Button()
        Me.bntVideoFormat = New System.Windows.Forms.Button()
        Me.bntVideoSource = New System.Windows.Forms.Button()
        Me.imgCapture = New System.Windows.Forms.PictureBox()
        Me.imgVideo = New System.Windows.Forms.PictureBox()
        CType(Me.imgCapture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgVideo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bntStart
        '
        Me.bntStart.Location = New System.Drawing.Point(426, 85)
        Me.bntStart.Name = "bntStart"
        Me.bntStart.Size = New System.Drawing.Size(199, 23)
        Me.bntStart.TabIndex = 0
        Me.bntStart.Text = "bntStart"
        Me.bntStart.UseVisualStyleBackColor = True
        '
        'bntStop
        '
        Me.bntStop.Location = New System.Drawing.Point(426, 115)
        Me.bntStop.Name = "bntStop"
        Me.bntStop.Size = New System.Drawing.Size(199, 23)
        Me.bntStop.TabIndex = 1
        Me.bntStop.Text = "bntStop"
        Me.bntStop.UseVisualStyleBackColor = True
        '
        'bntContinue
        '
        Me.bntContinue.Location = New System.Drawing.Point(426, 145)
        Me.bntContinue.Name = "bntContinue"
        Me.bntContinue.Size = New System.Drawing.Size(199, 23)
        Me.bntContinue.TabIndex = 2
        Me.bntContinue.Text = "bntContinue"
        Me.bntContinue.UseVisualStyleBackColor = True
        '
        'bntCapture
        '
        Me.bntCapture.Location = New System.Drawing.Point(426, 175)
        Me.bntCapture.Name = "bntCapture"
        Me.bntCapture.Size = New System.Drawing.Size(199, 23)
        Me.bntCapture.TabIndex = 3
        Me.bntCapture.Text = "bntCapture"
        Me.bntCapture.UseVisualStyleBackColor = True
        '
        'bntSave
        '
        Me.bntSave.Location = New System.Drawing.Point(426, 205)
        Me.bntSave.Name = "bntSave"
        Me.bntSave.Size = New System.Drawing.Size(199, 23)
        Me.bntSave.TabIndex = 4
        Me.bntSave.Text = "bntSave"
        Me.bntSave.UseVisualStyleBackColor = True
        '
        'bntVideoFormat
        '
        Me.bntVideoFormat.Location = New System.Drawing.Point(426, 235)
        Me.bntVideoFormat.Name = "bntVideoFormat"
        Me.bntVideoFormat.Size = New System.Drawing.Size(199, 23)
        Me.bntVideoFormat.TabIndex = 5
        Me.bntVideoFormat.Text = "bntVideoFormat"
        Me.bntVideoFormat.UseVisualStyleBackColor = True
        '
        'bntVideoSource
        '
        Me.bntVideoSource.Location = New System.Drawing.Point(426, 265)
        Me.bntVideoSource.Name = "bntVideoSource"
        Me.bntVideoSource.Size = New System.Drawing.Size(199, 23)
        Me.bntVideoSource.TabIndex = 6
        Me.bntVideoSource.Text = "bntVideoSource"
        Me.bntVideoSource.UseVisualStyleBackColor = True
        '
        'imgCapture
        '
        Me.imgCapture.Location = New System.Drawing.Point(13, 13)
        Me.imgCapture.Name = "imgCapture"
        Me.imgCapture.Size = New System.Drawing.Size(256, 143)
        Me.imgCapture.TabIndex = 7
        Me.imgCapture.TabStop = False
        '
        'imgVideo
        '
        Me.imgVideo.Location = New System.Drawing.Point(13, 162)
        Me.imgVideo.Name = "imgVideo"
        Me.imgVideo.Size = New System.Drawing.Size(256, 143)
        Me.imgVideo.TabIndex = 8
        Me.imgVideo.TabStop = False
        '
        'Form_WebCam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.imgVideo)
        Me.Controls.Add(Me.imgCapture)
        Me.Controls.Add(Me.bntVideoSource)
        Me.Controls.Add(Me.bntVideoFormat)
        Me.Controls.Add(Me.bntSave)
        Me.Controls.Add(Me.bntCapture)
        Me.Controls.Add(Me.bntContinue)
        Me.Controls.Add(Me.bntStop)
        Me.Controls.Add(Me.bntStart)
        Me.Name = "Form_WebCam"
        Me.Text = "Form_WebCam"
        CType(Me.imgCapture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgVideo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents bntStart As Button
    Friend WithEvents bntStop As Button
    Friend WithEvents bntContinue As Button
    Friend WithEvents bntCapture As Button
    Friend WithEvents bntSave As Button
    Friend WithEvents bntVideoFormat As Button
    Friend WithEvents bntVideoSource As Button
    Friend WithEvents imgCapture As PictureBox
    Friend WithEvents imgVideo As PictureBox
End Class
