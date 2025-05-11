<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Checklist
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
        Me.components = New System.ComponentModel.Container()
        Me.Button_Agregar = New System.Windows.Forms.Button()
        Me.Button_Actulizar = New System.Windows.Forms.Button()
        Me.Button_Eliminar = New System.Windows.Forms.Button()
        Me.DataGridView_Tareas = New System.Windows.Forms.DataGridView()
        Me.DataGridView_Funciones = New System.Windows.Forms.DataGridView()
        Me.CF_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CF_Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CF_Notas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CF_Completado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label_ID = New System.Windows.Forms.Label()
        Me.RichTextBox_Descripcion = New System.Windows.Forms.RichTextBox()
        Me.TextBox_Buscar = New System.Windows.Forms.TextBox()
        Me.ComboBox_Tipo = New System.Windows.Forms.ComboBox()
        Me.Label_Status = New System.Windows.Forms.Label()
        Me.ComboBox_Tematica = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button_AgregarTarea = New System.Windows.Forms.Button()
        Me.Button_EliminarTarea = New System.Windows.Forms.Button()
        Me.Label_Tipo = New System.Windows.Forms.Label()
        Me.Label_Tematica = New System.Windows.Forms.Label()
        Me.Label_Buscar = New System.Windows.Forms.Label()
        Me.Label_Titulo = New System.Windows.Forms.Label()
        Me.TextBox_Titulo = New System.Windows.Forms.TextBox()
        Me.Label_Descripcion = New System.Windows.Forms.Label()
        Me.Label_Nota = New System.Windows.Forms.Label()
        Me.RichTextBox_Nota = New System.Windows.Forms.RichTextBox()
        Me.CheckBox_Completado = New System.Windows.Forms.CheckBox()
        CType(Me.DataGridView_Tareas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView_Funciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button_Agregar
        '
        Me.Button_Agregar.Location = New System.Drawing.Point(12, 415)
        Me.Button_Agregar.Name = "Button_Agregar"
        Me.Button_Agregar.Size = New System.Drawing.Size(75, 23)
        Me.Button_Agregar.TabIndex = 0
        Me.Button_Agregar.Text = "Agregar"
        Me.Button_Agregar.UseVisualStyleBackColor = True
        '
        'Button_Actulizar
        '
        Me.Button_Actulizar.Location = New System.Drawing.Point(93, 415)
        Me.Button_Actulizar.Name = "Button_Actulizar"
        Me.Button_Actulizar.Size = New System.Drawing.Size(75, 23)
        Me.Button_Actulizar.TabIndex = 1
        Me.Button_Actulizar.Text = "Actulizar"
        Me.Button_Actulizar.UseVisualStyleBackColor = True
        '
        'Button_Eliminar
        '
        Me.Button_Eliminar.Location = New System.Drawing.Point(174, 415)
        Me.Button_Eliminar.Name = "Button_Eliminar"
        Me.Button_Eliminar.Size = New System.Drawing.Size(75, 23)
        Me.Button_Eliminar.TabIndex = 2
        Me.Button_Eliminar.Text = "Eliminar"
        Me.Button_Eliminar.UseVisualStyleBackColor = True
        '
        'DataGridView_Tareas
        '
        Me.DataGridView_Tareas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Tareas.Location = New System.Drawing.Point(12, 13)
        Me.DataGridView_Tareas.Name = "DataGridView_Tareas"
        Me.DataGridView_Tareas.Size = New System.Drawing.Size(416, 396)
        Me.DataGridView_Tareas.TabIndex = 3
        '
        'DataGridView_Funciones
        '
        Me.DataGridView_Funciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView_Funciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Funciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CF_Id, Me.CF_Descripcion, Me.CF_Notas, Me.CF_Completado})
        Me.DataGridView_Funciones.Location = New System.Drawing.Point(434, 12)
        Me.DataGridView_Funciones.Name = "DataGridView_Funciones"
        Me.DataGridView_Funciones.Size = New System.Drawing.Size(443, 396)
        Me.DataGridView_Funciones.TabIndex = 4
        '
        'CF_Id
        '
        Me.CF_Id.HeaderText = "ID"
        Me.CF_Id.Name = "CF_Id"
        Me.CF_Id.Visible = False
        '
        'CF_Descripcion
        '
        Me.CF_Descripcion.FillWeight = 200.0!
        Me.CF_Descripcion.HeaderText = "Descripcion"
        Me.CF_Descripcion.Name = "CF_Descripcion"
        Me.CF_Descripcion.Width = 400
        '
        'CF_Notas
        '
        Me.CF_Notas.FillWeight = 200.0!
        Me.CF_Notas.HeaderText = "Notas"
        Me.CF_Notas.Name = "CF_Notas"
        Me.CF_Notas.Width = 300
        '
        'CF_Completado
        '
        Me.CF_Completado.HeaderText = "✓"
        Me.CF_Completado.Name = "CF_Completado"
        '
        'Label_ID
        '
        Me.Label_ID.AutoSize = True
        Me.Label_ID.Location = New System.Drawing.Point(93, 441)
        Me.Label_ID.Name = "Label_ID"
        Me.Label_ID.Size = New System.Drawing.Size(18, 13)
        Me.Label_ID.TabIndex = 5
        Me.Label_ID.Text = "ID"
        '
        'RichTextBox_Descripcion
        '
        Me.RichTextBox_Descripcion.Location = New System.Drawing.Point(434, 415)
        Me.RichTextBox_Descripcion.Name = "RichTextBox_Descripcion"
        Me.RichTextBox_Descripcion.Size = New System.Drawing.Size(354, 136)
        Me.RichTextBox_Descripcion.TabIndex = 6
        Me.RichTextBox_Descripcion.Text = ""
        '
        'TextBox_Buscar
        '
        Me.TextBox_Buscar.Location = New System.Drawing.Point(288, 457)
        Me.TextBox_Buscar.Name = "TextBox_Buscar"
        Me.TextBox_Buscar.Size = New System.Drawing.Size(140, 20)
        Me.TextBox_Buscar.TabIndex = 7
        '
        'ComboBox_Tipo
        '
        Me.ComboBox_Tipo.FormattingEnabled = True
        Me.ComboBox_Tipo.Location = New System.Drawing.Point(19, 498)
        Me.ComboBox_Tipo.Name = "ComboBox_Tipo"
        Me.ComboBox_Tipo.Size = New System.Drawing.Size(161, 21)
        Me.ComboBox_Tipo.TabIndex = 8
        Me.ComboBox_Tipo.Text = "Tipo"
        '
        'Label_Status
        '
        Me.Label_Status.AutoSize = True
        Me.Label_Status.Location = New System.Drawing.Point(12, 639)
        Me.Label_Status.Name = "Label_Status"
        Me.Label_Status.Size = New System.Drawing.Size(40, 13)
        Me.Label_Status.TabIndex = 9
        Me.Label_Status.Text = "Estado"
        '
        'ComboBox_Tematica
        '
        Me.ComboBox_Tematica.FormattingEnabled = True
        Me.ComboBox_Tematica.Location = New System.Drawing.Point(22, 539)
        Me.ComboBox_Tematica.Name = "ComboBox_Tematica"
        Me.ComboBox_Tematica.Size = New System.Drawing.Size(158, 21)
        Me.ComboBox_Tematica.TabIndex = 10
        Me.ComboBox_Tematica.Text = "Tematica"
        '
        'Button_AgregarTarea
        '
        Me.Button_AgregarTarea.Location = New System.Drawing.Point(802, 413)
        Me.Button_AgregarTarea.Name = "Button_AgregarTarea"
        Me.Button_AgregarTarea.Size = New System.Drawing.Size(75, 23)
        Me.Button_AgregarTarea.TabIndex = 11
        Me.Button_AgregarTarea.Text = "AgregarTarea"
        Me.Button_AgregarTarea.UseVisualStyleBackColor = True
        '
        'Button_EliminarTarea
        '
        Me.Button_EliminarTarea.Location = New System.Drawing.Point(802, 442)
        Me.Button_EliminarTarea.Name = "Button_EliminarTarea"
        Me.Button_EliminarTarea.Size = New System.Drawing.Size(75, 23)
        Me.Button_EliminarTarea.TabIndex = 12
        Me.Button_EliminarTarea.Text = "EliminarTarea"
        Me.Button_EliminarTarea.UseVisualStyleBackColor = True
        '
        'Label_Tipo
        '
        Me.Label_Tipo.AutoSize = True
        Me.Label_Tipo.Location = New System.Drawing.Point(19, 482)
        Me.Label_Tipo.Name = "Label_Tipo"
        Me.Label_Tipo.Size = New System.Drawing.Size(28, 13)
        Me.Label_Tipo.TabIndex = 13
        Me.Label_Tipo.Text = "Tipo"
        '
        'Label_Tematica
        '
        Me.Label_Tematica.AutoSize = True
        Me.Label_Tematica.Location = New System.Drawing.Point(19, 523)
        Me.Label_Tematica.Name = "Label_Tematica"
        Me.Label_Tematica.Size = New System.Drawing.Size(51, 13)
        Me.Label_Tematica.TabIndex = 14
        Me.Label_Tematica.Text = "Tematica"
        '
        'Label_Buscar
        '
        Me.Label_Buscar.AutoSize = True
        Me.Label_Buscar.Location = New System.Drawing.Point(285, 441)
        Me.Label_Buscar.Name = "Label_Buscar"
        Me.Label_Buscar.Size = New System.Drawing.Size(40, 13)
        Me.Label_Buscar.TabIndex = 15
        Me.Label_Buscar.Text = "Buscar"
        '
        'Label_Titulo
        '
        Me.Label_Titulo.AutoSize = True
        Me.Label_Titulo.Location = New System.Drawing.Point(19, 441)
        Me.Label_Titulo.Name = "Label_Titulo"
        Me.Label_Titulo.Size = New System.Drawing.Size(33, 13)
        Me.Label_Titulo.TabIndex = 17
        Me.Label_Titulo.Text = "Titulo"
        '
        'TextBox_Titulo
        '
        Me.TextBox_Titulo.Location = New System.Drawing.Point(22, 457)
        Me.TextBox_Titulo.Name = "TextBox_Titulo"
        Me.TextBox_Titulo.Size = New System.Drawing.Size(158, 20)
        Me.TextBox_Titulo.TabIndex = 16
        Me.TextBox_Titulo.Text = "Titulo"
        '
        'Label_Descripcion
        '
        Me.Label_Descripcion.AutoSize = True
        Me.Label_Descripcion.Location = New System.Drawing.Point(365, 418)
        Me.Label_Descripcion.Name = "Label_Descripcion"
        Me.Label_Descripcion.Size = New System.Drawing.Size(63, 13)
        Me.Label_Descripcion.TabIndex = 18
        Me.Label_Descripcion.Text = "Descripción"
        '
        'Label_Nota
        '
        Me.Label_Nota.AutoSize = True
        Me.Label_Nota.Location = New System.Drawing.Point(398, 560)
        Me.Label_Nota.Name = "Label_Nota"
        Me.Label_Nota.Size = New System.Drawing.Size(30, 13)
        Me.Label_Nota.TabIndex = 20
        Me.Label_Nota.Text = "Nota"
        '
        'RichTextBox_Nota
        '
        Me.RichTextBox_Nota.Location = New System.Drawing.Point(434, 557)
        Me.RichTextBox_Nota.Name = "RichTextBox_Nota"
        Me.RichTextBox_Nota.Size = New System.Drawing.Size(354, 82)
        Me.RichTextBox_Nota.TabIndex = 19
        Me.RichTextBox_Nota.Text = ""
        '
        'CheckBox_Completado
        '
        Me.CheckBox_Completado.AutoSize = True
        Me.CheckBox_Completado.Location = New System.Drawing.Point(802, 471)
        Me.CheckBox_Completado.Name = "CheckBox_Completado"
        Me.CheckBox_Completado.Size = New System.Drawing.Size(82, 17)
        Me.CheckBox_Completado.TabIndex = 21
        Me.CheckBox_Completado.Text = "Completado"
        Me.CheckBox_Completado.UseVisualStyleBackColor = True
        '
        'Form_Checklist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 661)
        Me.Controls.Add(Me.CheckBox_Completado)
        Me.Controls.Add(Me.Label_Nota)
        Me.Controls.Add(Me.RichTextBox_Nota)
        Me.Controls.Add(Me.Label_Descripcion)
        Me.Controls.Add(Me.Label_Titulo)
        Me.Controls.Add(Me.TextBox_Titulo)
        Me.Controls.Add(Me.Label_Buscar)
        Me.Controls.Add(Me.Label_Tematica)
        Me.Controls.Add(Me.Label_Tipo)
        Me.Controls.Add(Me.Button_EliminarTarea)
        Me.Controls.Add(Me.Button_AgregarTarea)
        Me.Controls.Add(Me.ComboBox_Tematica)
        Me.Controls.Add(Me.Label_Status)
        Me.Controls.Add(Me.ComboBox_Tipo)
        Me.Controls.Add(Me.TextBox_Buscar)
        Me.Controls.Add(Me.RichTextBox_Descripcion)
        Me.Controls.Add(Me.Label_ID)
        Me.Controls.Add(Me.DataGridView_Funciones)
        Me.Controls.Add(Me.DataGridView_Tareas)
        Me.Controls.Add(Me.Button_Eliminar)
        Me.Controls.Add(Me.Button_Actulizar)
        Me.Controls.Add(Me.Button_Agregar)
        Me.Name = "Form_Checklist"
        Me.Text = "Form_Checklist"
        CType(Me.DataGridView_Tareas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView_Funciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button_Agregar As Button
    Friend WithEvents Button_Actulizar As Button
    Friend WithEvents Button_Eliminar As Button
    Friend WithEvents DataGridView_Tareas As DataGridView
    Friend WithEvents DataGridView_Funciones As DataGridView
    Friend WithEvents Label_ID As Label
    Friend WithEvents RichTextBox_Descripcion As RichTextBox
    Friend WithEvents TextBox_Buscar As TextBox
    Friend WithEvents ComboBox_Tipo As ComboBox
    Friend WithEvents Label_Status As Label
    Friend WithEvents ComboBox_Tematica As ComboBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Button_AgregarTarea As Button
    Friend WithEvents Button_EliminarTarea As Button
    Friend WithEvents Label_Tipo As Label
    Friend WithEvents Label_Tematica As Label
    Friend WithEvents Label_Buscar As Label
    Friend WithEvents Label_Titulo As Label
    Friend WithEvents TextBox_Titulo As TextBox
    Friend WithEvents Label_Descripcion As Label
    Friend WithEvents Label_Nota As Label
    Friend WithEvents RichTextBox_Nota As RichTextBox
    Friend WithEvents CheckBox_Completado As CheckBox
    Friend WithEvents CF_Id As DataGridViewTextBoxColumn
    Friend WithEvents CF_Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents CF_Notas As DataGridViewTextBoxColumn
    Friend WithEvents CF_Completado As DataGridViewTextBoxColumn
End Class
