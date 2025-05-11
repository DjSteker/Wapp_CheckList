<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Inicio
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Button_Agenda = New Button()
        Button_CheckList = New Button()
        Button_Camara = New Button()
        Button_CodigoBarras = New Button()
        Button_QR = New Button()
        SuspendLayout()
        ' 
        ' Button_Agenda
        ' 
        Button_Agenda.Location = New Point(12, 12)
        Button_Agenda.Name = "Button_Agenda"
        Button_Agenda.Size = New Size(180, 60)
        Button_Agenda.TabIndex = 0
        Button_Agenda.Text = "Agenda"
        Button_Agenda.UseVisualStyleBackColor = True
        ' 
        ' Button_CheckList
        ' 
        Button_CheckList.Location = New Point(12, 78)
        Button_CheckList.Name = "Button_CheckList"
        Button_CheckList.Size = New Size(180, 60)
        Button_CheckList.TabIndex = 1
        Button_CheckList.Text = "CheckList"
        Button_CheckList.UseVisualStyleBackColor = True
        ' 
        ' Button_Camara
        ' 
        Button_Camara.Location = New Point(12, 144)
        Button_Camara.Name = "Button_Camara"
        Button_Camara.Size = New Size(180, 60)
        Button_Camara.TabIndex = 2
        Button_Camara.Text = "Camara"
        Button_Camara.UseVisualStyleBackColor = True
        ' 
        ' Button_CodigoBarras
        ' 
        Button_CodigoBarras.Location = New Point(12, 210)
        Button_CodigoBarras.Name = "Button_CodigoBarras"
        Button_CodigoBarras.Size = New Size(180, 60)
        Button_CodigoBarras.TabIndex = 3
        Button_CodigoBarras.Text = "Codigo de barras"
        Button_CodigoBarras.UseVisualStyleBackColor = True
        ' 
        ' Button_QR
        ' 
        Button_QR.Location = New Point(12, 276)
        Button_QR.Name = "Button_QR"
        Button_QR.Size = New Size(180, 60)
        Button_QR.TabIndex = 4
        Button_QR.Text = "Codigo QR"
        Button_QR.UseVisualStyleBackColor = True
        ' 
        ' Form_Inicio
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Button_QR)
        Controls.Add(Button_CodigoBarras)
        Controls.Add(Button_Camara)
        Controls.Add(Button_CheckList)
        Controls.Add(Button_Agenda)
        Name = "Form_Inicio"
        Text = "Inicio"
        ResumeLayout(False)
    End Sub

    Friend WithEvents Button_Agenda As Button
    Friend WithEvents Button_CheckList As Button
    Friend WithEvents Button_Camara As Button
    Friend WithEvents Button_CodigoBarras As Button
    Friend WithEvents Button_QR As Button

End Class
