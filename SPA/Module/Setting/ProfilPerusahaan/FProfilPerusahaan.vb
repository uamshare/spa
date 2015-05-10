Public Class FProfilPerusahaan
    Private Model As New MProfilPerusahaan

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        'MessageBox.Show(Model.EscapeString(TextBox1.Text))
        'Exit Sub
        If DataIsValid() Then
            Dim res As Integer

            Model.mlctid = Model.EscapeString(txtKode.Text)
            Model.mlclname = Model.EscapeString(txtLokasi.Text)
            Model.mcpfname = Model.EscapeString(txtNama.Text)
            Model.mcpfaddr1 = Model.EscapeString(txtJalan.Text)
            Model.mcpfaddr2 = Model.EscapeString(txtKelurahan.Text)
            Model.mcpfaddr3 = Model.EscapeString(txtKecamatan.Text)
            Model.mcpfaddr4 = Model.EscapeString(txtKota.Text)
            Model.mcpfaddr5 = Model.EscapeString(txtProfinsi.Text)
            Model.mcpfphone1 = Model.EscapeString(txtPhone1.Text)
            Model.mcpfphone2 = Model.EscapeString(txtPhone2.Text)
            Model.mcpfax = Model.EscapeString(txtFax.Text)
            Model.mcptaxcode = Model.EscapeString(txtNPWP.Text)
            Model.mcpfemail = Model.EscapeString(txtEmail.Text)
            If kode.Text <> "" Then
                res = Model.UpdateData()
            Else
                res = Model.InsertData()
            End If
            Me.Close()
        End If
    End Sub

    Private Function DataIsValid() As Boolean
        DataIsValid = True

        If kode.Text <> "" Then
            If txtKode.Text <> kode.Text Then
                If Model.IfKeyExist(txtKode.Text) Then
                    statmsg.Text = "Kode sudah ada, silahkan masukan Kode yang lain."
                    statmsg.ForeColor = Color.DarkRed
                    txtKode.Focus()
                    DataIsValid = False
                Else
                    statmsg.Text = "Nama Valid"
                    statmsg.ForeColor = Color.Green
                    DataIsValid = True
                End If
            End If
        Else
            If Model.IfDataExist1(txtKode.Text) Then
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
        If txtNama.Text <> "" Then
            If txtNama.Text <> nama.Text Then
                If Model.IfDataExist2(txtNama.Text) Then
                    statmsg.Text = "Nama Perusahaan sudah ada, silahkan masukan Nama Perusahaan  yang lain."
                    statmsg.ForeColor = Color.DarkRed
                    txtNPWP.Focus()
                    DataIsValid = False
                Else
                    statmsg.Text = "Nama Perusahaan  Valid"
                    statmsg.ForeColor = Color.Green
                    DataIsValid = True
                End If
            End If
        Else
            If Model.IfDataExist2(txtNama.Text) Then
                statmsg.Text = "Nama Perusahaan sudah ada, silahkan masukan Nama Perusahaan yang lain."
                statmsg.ForeColor = Color.DarkRed
                txtNPWP.Focus()
                DataIsValid = False
            Else
                statmsg.Text = "Nama Perusahaan Valid"
                statmsg.ForeColor = Color.Green
                DataIsValid = True
            End If
        End If

        If txtNama.Text = "" Then
            statmsg.Text = "Nama tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtNama.Focus()
            DataIsValid = False
        End If
        If txtKode.Text = "" Then
            statmsg.Text = "kode tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtKode.Focus()
            DataIsValid = False
        End If

        Return DataIsValid
    End Function

    Private Sub txtPhone1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhone1.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtPhone2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhone2.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtFax_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFax.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Me.Close()
    End Sub
End Class