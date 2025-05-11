Public Class Form_XML_kismet

    Private Sub Form_XML_kismet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim openFileDialog1 As New OpenFileDialog()

            'openFileDialog1.InitialDirectory = "c:\"
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            openFileDialog1.FilterIndex = 2
            openFileDialog1.RestoreDirectory = True

            If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                Class_XML_kismet.Archivo = openFileDialog1.FileName
                '   Limpiar()
                DataGridView1.Rows.Clear()
            Else

            End If
            Dim Rejistro As New Class_XML_kismet.ClassArchivo_kismet(0, "", "", "", "", "", "", "", "", "", "", "", "", "", "")
            'Dim DatosIntefaz As New Class_Socios.ClassArchivo_Socios(0, "", TextBox_Nombre.Text.ToString.Trim, TextBox_Nif.Text.ToString.Trim,
            '                                                        DateTimePicker_Nacimiento.Value, TextBox_Direccion.Text.ToString.ToString.Trim,
            '                                                        TextBox_Telefono.Text.ToString.ToString.Trim, TextBox_Email.Text.ToString.ToString.Trim,
            '                                                        ComboBox_EstadoCivil.Text.ToString, TextBox_Tarifa.Text.ToString.ToString.Trim, TextBox_Pago.ToString.ToString.Trim,
            '                                                        Date_Inscripcion.Value, Date_Renovacion.Value, CheckBox_Activo.Checked)
            'DatosIntefaz.Renovacion = Date_Renovacion.Value
            'DatosIntefaz.Id = Label_IDSeleccionada.Text.ToString.Trim
            'DatosIntefaz.Nombre = TextBox_Nombre.Text.ToString.Trim
            'DatosIntefaz.Nif = TextBox_Nif.Text.ToString.Trim
            'DatosIntefaz.Direccion = TextBox_Direccion.Text.ToString.ToString.Trim
            'DatosIntefaz.NumeroCliente = TextBox_Numero.Text.ToString.ToString.Trim

            'DatosIntefaz.Estado = False ' TextBox_.Text.ToString.ToString.Trim
            'DatosIntefaz.Tarifa = TextBox_Tarifa.Text.ToString.ToString.Trim
            'DatosIntefaz.Fechanacimiento = DateTimePicker_Nacimiento.Value 'Text.ToString.ToString.Trim
            'DatosIntefaz.Telefono = TextBox_Telefono.Text.ToString.ToString.Trim
            'DatosIntefaz.Email = TextBox_Email.Text.ToString.ToString.Trim
            'DatosIntefaz.Inscripcion = Date_Inscripcion.Value
            'DatosIntefaz.Renovacion = Date_Renovacion.Value

            '
            ' ActulizarDatosIntefaz(Class_Socios.ObtenerWhereNif(TextBox_Nif.Text.Trim))


            With Class_XML_kismet.ObtenerTodos
                For Indice As Integer = 0 To (.Count - 1)

                    DataGridView1.Rows.Add(.Item(Indice).essid.Trim, .Item(Indice).BSSID.Trim, .Item(Indice).type.Trim,
                                                                        .Item(Indice).max_rate.Trim, .Item(Indice).packets.Trim, .Item(Indice).beaconrate.Trim,
                                                                        .Item(Indice).encryption1.Trim, .Item(Indice).encryption2.Trim,
                                                                        .Item(Indice).manuf.Trim, .Item(Indice).channel.Trim, .Item(Indice).freqmhz.ToString.Trim,
                                                                        .Item(Indice).encoding.Trim, .Item(Indice).datasize.Trim)

                Next
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class