<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Diario
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
        Me.Button_Guardar = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage_Diario = New System.Windows.Forms.TabPage()
        Me.DataGridView_Diario = New System.Windows.Forms.DataGridView()
        Me.C_DiarioId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_DiarioFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_DiarioTexto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_DiarioRutaImagen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_DiarioTema = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button_Eliminar = New System.Windows.Forms.Button()
        Me.TabPage_CheckList = New System.Windows.Forms.TabPage()
        Me.DataGridView_CheckList = New System.Windows.Forms.DataGridView()
        Me.TabPage_Tarea = New System.Windows.Forms.TabPage()
        Me.RichTextBox_Tarea = New System.Windows.Forms.RichTextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage_Diario.SuspendLayout()
        CType(Me.DataGridView_Diario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage_CheckList.SuspendLayout()
        CType(Me.DataGridView_CheckList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage_Tarea.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_Guardar
        '
        Me.Button_Guardar.Location = New System.Drawing.Point(6, 3)
        Me.Button_Guardar.Name = "Button_Guardar"
        Me.Button_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Button_Guardar.TabIndex = 0
        Me.Button_Guardar.Text = "Guardar"
        Me.Button_Guardar.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage_Diario)
        Me.TabControl1.Controls.Add(Me.TabPage_CheckList)
        Me.TabControl1.Controls.Add(Me.TabPage_Tarea)
        Me.TabControl1.Location = New System.Drawing.Point(4, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(790, 434)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage_Diario
        '
        Me.TabPage_Diario.Controls.Add(Me.DataGridView_Diario)
        Me.TabPage_Diario.Controls.Add(Me.Button_Eliminar)
        Me.TabPage_Diario.Controls.Add(Me.Button_Guardar)
        Me.TabPage_Diario.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Diario.Name = "TabPage_Diario"
        Me.TabPage_Diario.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Diario.Size = New System.Drawing.Size(782, 408)
        Me.TabPage_Diario.TabIndex = 0
        Me.TabPage_Diario.Text = "Diario"
        Me.TabPage_Diario.UseVisualStyleBackColor = True
        '
        'DataGridView_Diario
        '
        Me.DataGridView_Diario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Diario.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.C_DiarioId, Me.C_DiarioFecha, Me.C_DiarioTexto, Me.C_DiarioRutaImagen, Me.C_DiarioTema})
        Me.DataGridView_Diario.Location = New System.Drawing.Point(6, 33)
        Me.DataGridView_Diario.Name = "DataGridView_Diario"
        Me.DataGridView_Diario.Size = New System.Drawing.Size(770, 369)
        Me.DataGridView_Diario.TabIndex = 2
        '
        'C_DiarioId
        '
        Me.C_DiarioId.HeaderText = "Id"
        Me.C_DiarioId.Name = "C_DiarioId"
        Me.C_DiarioId.Visible = False
        '
        'C_DiarioFecha
        '
        Me.C_DiarioFecha.HeaderText = "Fecha"
        Me.C_DiarioFecha.Name = "C_DiarioFecha"
        '
        'C_DiarioTexto
        '
        Me.C_DiarioTexto.FillWeight = 150.0!
        Me.C_DiarioTexto.HeaderText = "Texto "
        Me.C_DiarioTexto.Name = "C_DiarioTexto"
        Me.C_DiarioTexto.Width = 350
        '
        'C_DiarioRutaImagen
        '
        Me.C_DiarioRutaImagen.FillWeight = 50.0!
        Me.C_DiarioRutaImagen.HeaderText = "Ruta imagen"
        Me.C_DiarioRutaImagen.Name = "C_DiarioRutaImagen"
        '
        'C_DiarioTema
        '
        Me.C_DiarioTema.FillWeight = 120.0!
        Me.C_DiarioTema.HeaderText = "Tema"
        Me.C_DiarioTema.Name = "C_DiarioTema"
        Me.C_DiarioTema.Width = 150
        '
        'Button_Eliminar
        '
        Me.Button_Eliminar.Location = New System.Drawing.Point(87, 3)
        Me.Button_Eliminar.Name = "Button_Eliminar"
        Me.Button_Eliminar.Size = New System.Drawing.Size(75, 23)
        Me.Button_Eliminar.TabIndex = 1
        Me.Button_Eliminar.Text = "Eliminar"
        Me.Button_Eliminar.UseVisualStyleBackColor = True
        '
        'TabPage_CheckList
        '
        Me.TabPage_CheckList.Controls.Add(Me.DataGridView_CheckList)
        Me.TabPage_CheckList.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_CheckList.Name = "TabPage_CheckList"
        Me.TabPage_CheckList.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_CheckList.Size = New System.Drawing.Size(782, 408)
        Me.TabPage_CheckList.TabIndex = 1
        Me.TabPage_CheckList.Text = "Check list"
        Me.TabPage_CheckList.UseVisualStyleBackColor = True
        '
        'DataGridView_CheckList
        '
        Me.DataGridView_CheckList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_CheckList.Location = New System.Drawing.Point(6, 36)
        Me.DataGridView_CheckList.Name = "DataGridView_CheckList"
        Me.DataGridView_CheckList.Size = New System.Drawing.Size(770, 369)
        Me.DataGridView_CheckList.TabIndex = 3
        '
        'TabPage_Tarea
        '
        Me.TabPage_Tarea.Controls.Add(Me.RichTextBox_Tarea)
        Me.TabPage_Tarea.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Tarea.Name = "TabPage_Tarea"
        Me.TabPage_Tarea.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Tarea.Size = New System.Drawing.Size(782, 408)
        Me.TabPage_Tarea.TabIndex = 2
        Me.TabPage_Tarea.Text = "Tarea"
        Me.TabPage_Tarea.UseVisualStyleBackColor = True
        '
        'RichTextBox_Tarea
        '
        Me.RichTextBox_Tarea.Location = New System.Drawing.Point(7, 7)
        Me.RichTextBox_Tarea.Name = "RichTextBox_Tarea"
        Me.RichTextBox_Tarea.Size = New System.Drawing.Size(424, 395)
        Me.RichTextBox_Tarea.TabIndex = 0
        Me.RichTextBox_Tarea.Text = ""
        '
        'Form_Diario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Form_Diario"
        Me.Text = "Diario"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage_Diario.ResumeLayout(False)
        CType(Me.DataGridView_Diario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage_CheckList.ResumeLayout(False)
        CType(Me.DataGridView_CheckList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage_Tarea.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button_Guardar As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage_Diario As TabPage
    Friend WithEvents TabPage_CheckList As TabPage
    Friend WithEvents Button_Eliminar As Button
    Friend WithEvents DataGridView_Diario As DataGridView
    Friend WithEvents DataGridView_CheckList As DataGridView
    Friend WithEvents C_DiarioId As DataGridViewTextBoxColumn
    Friend WithEvents C_DiarioFecha As DataGridViewTextBoxColumn
    Friend WithEvents C_DiarioTexto As DataGridViewTextBoxColumn
    Friend WithEvents C_DiarioRutaImagen As DataGridViewTextBoxColumn
    Friend WithEvents C_DiarioTema As DataGridViewTextBoxColumn
    Friend WithEvents TabPage_Tarea As TabPage
    Friend WithEvents RichTextBox_Tarea As RichTextBox
End Class
