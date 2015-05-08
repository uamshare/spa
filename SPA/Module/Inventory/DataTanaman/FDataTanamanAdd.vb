Public Class FDataTanamanAdd
    Private Model As New MTanaman

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        'MessageBox.Show(Model.EscapeString(TextBox1.Text))
        'Exit Sub
        If DataIsValid() Then
            Dim res As Integer

            Model.GetKey = Model.EscapeString(txtKeyID.Text)
            Model.mmtrhid = Model.EscapeString(txtMmtrhid.Text)
            Model.mmtrg = Model.EscapeString(txtMmtrg.Text)
            Model.mmtrname = Model.EscapeString(txtJnsTanaman.Text)
            Model.polybag = cmbPolybag.Text
            Model.mmtrunit = txtSatuan.Text
            Model.mmtrprice = Convert.ToDouble(txtHarga.Text)
            Model.mmtrid = txtKode.Text + txtKode2.Text + txtKode3.Text
            If txtMmtrg.Text <> "" Then
                res = Model.UpdateData()
                'MyApplication.ShowStatus("Data has been updated")
            Else
                res = Model.InsertData()
                'MyApplication.ShowStatus("Data has been saved")
            End If
            FDataTanaman.init()
            'FUserGroup.RetrieveLast()
            Me.Close()

        End If
    End Sub

    Private Sub txtJnsTanaman_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJnsTanaman.KeyPress
        txtJnsTanaman.ReadOnly = True
        txtJnsTanaman.BackColor = Color.White
    End Sub

    Private Sub FDataTanamanAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtKode2.Text = "3"
        statmsg.Text = ""

        txtJnsTanaman.Focus()
    End Sub

    Private Sub Prompt_Click(sender As Object, e As EventArgs) Handles Prompt.Click
        FjensiTanaman.ShowDialog()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        FDataTanaman.Refresh()
        Me.Close()
    End Sub

    Private Sub cmbPolybag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPolybag.SelectedIndexChanged
        If cmbPolybag.SelectedItem = "P25" Then
            txtKode3.Text = "025"
        ElseIf cmbPolybag.SelectedItem = "P35" Then
            txtKode3.Text = "035"
        ElseIf cmbPolybag.SelectedItem = "P50" Then
            txtKode3.Text = "050"
        ElseIf cmbPolybag.SelectedItem = "P80" Then
            txtKode3.Text = "080"
        Else
            txtKode3.Text = "150"

        End If
    End Sub

    Private Sub txtHarga_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHarga.KeyPress
        'If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
        e.Handled = MyApplication.ValidNumber(e)
    End Sub

    Private Sub txtKode3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKode3.KeyDown
        txtKode3.ReadOnly = True
        txtKode3.BackColor = Color.White
    End Sub

    Private Sub txtKode3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKode3.KeyPress
        txtKode3.ReadOnly = True
        txtKode3.BackColor = Color.White
    End Sub

    Private Sub cmbPolybag_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbPolybag.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub txtKode_Leave(sender As Object, e As EventArgs) Handles txtKode.Leave
        Dim mmtrid As String = txtKode.Text + txtKode2.Text + txtKode3.Text

        If txtMmtrg.Text = "" Then
            If Not Model.IfKeyExist(mmtrid) Then
                statmsg.Text = "Kode Valid"
                statmsg.ForeColor = Color.Green
            Else
                statmsg.Text = "Kode sudah ada, silahkan masukan kode yang lain."
                statmsg.ForeColor = Color.DarkRed
                txtKode.Focus()
            End If
        End If


    End Sub

    Private Sub txtKode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKode.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtSatuan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSatuan.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
    Private Function DataIsValid() As Boolean
        DataIsValid = True
        Dim mmtrid As String = txtKode.Text + txtKode2.Text + txtKode3.Text

        If txtKeyID.Text <> "" Then
            If txtKeyID.Text <> txtKode.Text + txtKode2.Text + txtKode3.Text + txtMmtrg.Text Then
                If Model.IfKeyExist(mmtrid) Then
                    statmsg.Text = "Kode sudah ada, silahkan masukan Kode yang lain."
                    statmsg.ForeColor = Color.DarkRed
                    txtKode.Focus()
                    DataIsValid = False
                Else
                    statmsg.Text = "Kode Valid"
                    statmsg.ForeColor = Color.Green
                    DataIsValid = True
                End If
            End If
        Else
            If Model.IfKeyExist(mmtrid) Then
                statmsg.Text = "Kode sudah ada, silahkan masukan Kode yang lain."
                statmsg.ForeColor = Color.DarkRed
                txtKode.Focus()
                DataIsValid = False
            Else
                statmsg.Text = "Kode Valid"
                statmsg.ForeColor = Color.Green
                DataIsValid = True
            End If
        End If
        If txtJnsTanaman.Text = "" Then
            'MessageBox.Show("User group cannot be empty")
            statmsg.Text = "Jenis Tanaman tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtJnsTanaman.Focus()
            DataIsValid = False
        ElseIf txtKode.Text = "" Then
            'MessageBox.Show("User group cannot be empty")
            statmsg.Text = "Kode tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtKode.Focus()
            DataIsValid = False
        ElseIf txtKode3.Text = "" Then
            'MessageBox.Show("User group cannot be empty")
            statmsg.Text = "Kode tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtKode3.Focus()
            DataIsValid = False
        ElseIf txtKode.Text <> "" Then
            If Len(txtKode.Text) < 5 Then
                'MessageBox.Show("User group cannot be empty")
                statmsg.Text = "Kode tidak boleh kurang dari 5 digit !"
                statmsg.ForeColor = Color.DarkRed
                txtKode.Focus()
                DataIsValid = False
            ElseIf UBound(Split(txtKode.Text, " ")) > 0 Then
                statmsg.Text = "Kode tidak menggunakan spasi !"
                statmsg.ForeColor = Color.DarkRed
                txtKode.Focus()
                DataIsValid = False
            End If
        End If

        Return DataIsValid
    End Function
End Class