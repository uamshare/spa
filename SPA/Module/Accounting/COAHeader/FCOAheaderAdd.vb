Public Class FCOAheaderAdd
    Private Model As New MCOAheader

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If DataIsValid() Then
            Dim res As Integer

            Model.mcoahno = Model.EscapeString(txtNo.Text)
            Model.mcoahname = Model.EscapeString(txtNama.Text)
            Model.mcoacid = Model.EscapeString(txtCoaId.Text)
            Model.postbalance = Model.EscapeString(cmbSaldo.Text)
            Model.postgl = Model.EscapeString(cmbLaporan.Text)
            If KeyID.Text <> "" Then
                res = Model.UpdateData(KeyID.Text)
            Else
                res = Model.InsertData()
            End If
            FCOAheader.init()
            Me.Close()
        End If
    End Sub
    Private Function DataIsValid() As Boolean
        DataIsValid = True
        If txtKlasifikasi.Text = "" Then
            statmsg.Text = "Klasifikasi tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtKlasifikasi.Focus()
            DataIsValid = False
            Return DataIsValid
        End If

        If KeyID.Text <> "" Then
            If txtNo.Text <> KeyID.Text Then
                If Model.IfKeyExist(txtNo.Text) Then
                    statmsg.Text = "No Akun sudah ada, silahkan masukan No Akun yang lain."
                    statmsg.ForeColor = Color.DarkRed
                    txtNo.Focus()
                    DataIsValid = False
                    Return DataIsValid
                End If
            End If
        Else
            If Model.IfKeyExist(txtNo.Text) Then
                statmsg.Text = "No Akun sudah ada, silahkan masukan No Akun yang lain."
                statmsg.ForeColor = Color.DarkRed
                txtNo.Focus()
                DataIsValid = False
                Return DataIsValid
            End If
        End If

        If txtNo.Text = "" Then
            statmsg.Text = "No Akun tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtNo.Focus()
            DataIsValid = False
            Return DataIsValid
        Else
            If Len(txtNo.Text) < 6 Then
                'MessageBox.Show("User group cannot be empty")
                statmsg.Text = "No Akun tidak boleh kurang dari 6 digit !"
                statmsg.ForeColor = Color.DarkRed
                txtNo.Focus()
                DataIsValid = False
                Return DataIsValid
            ElseIf UBound(Split(txtNo.Text, " ")) > 0 Then
                statmsg.Text = "No Akun tidak boleh menggunakan spasi !"
                statmsg.ForeColor = Color.DarkRed
                txtNo.Focus()
                DataIsValid = False
                Return DataIsValid
            ElseIf Strings.Right(txtNo.Text, 2) <> "00" Then
                statmsg.Text = "No Akun harus diakhiri 00 !"
                statmsg.ForeColor = Color.DarkRed
                txtNo.Focus()
                DataIsValid = False
                Return DataIsValid
            End If
        End If
        
        If txtNama.Text = "" Then
            statmsg.Text = "Nama Akun Header tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtNama.Focus()
            DataIsValid = False
            Return DataIsValid
        End If
        If cmbSaldo.Text = "" Then
            statmsg.Text = "Posisi Saldo tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            cmbSaldo.Focus()
            DataIsValid = False
            Return DataIsValid
        End If
        If cmbLaporan.Text = "" Then
            statmsg.Text = "Posisi Laporan tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            cmbLaporan.Focus()
            DataIsValid = False
            Return DataIsValid
        End If

        Return DataIsValid
    End Function

    Private Sub txtNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtKlasifikasi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKlasifikasi.KeyPress
        txtKlasifikasi.ReadOnly = True
        txtKlasifikasi.BackColor = Color.White
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Me.Close()
    End Sub

    Private Sub btnPrompt_Click(sender As Object, e As EventArgs) Handles btnPrompt.Click
        FKlasifikasiCOA.ShowDialog()
    End Sub

    Private Sub FCOAheaderAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtKlasifikasi.Focus()
    End Sub

    Private Sub txtNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNo.KeyPress
        e.Handled = MyApplication.ValidNumber(e)
    End Sub
End Class