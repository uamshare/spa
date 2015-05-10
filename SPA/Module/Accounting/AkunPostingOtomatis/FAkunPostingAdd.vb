Public Class FAkunPostingAdd
    Private Model As New MAkunPosting
    Private Model2 As New MCOADetail

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If DataIsValid() Then
            Dim res As Integer

            Model.mapoid = Model.EscapeString(txtKode.Text)
            Model.maponame = Model.EscapeString(txtNama.Text)
            Model.acc_debit = Model.EscapeString(cmbDebit1.Text)
            Model.acc_credit = Model.EscapeString(cmbKredit1.Text)
            Model.acc_debit2 = Model.EscapeString(cmbDebit2.Text)
            Model.acc_credit2 = Model.EscapeString(cmbKredit2.Text)
            Model.acc_debit3 = Model.EscapeString(cmbDebit3.Text)
            Model.acc_credit3 = Model.EscapeString(cmbKredit3.Text)
            Model.acc_debit4 = Model.EscapeString(cmbDebit4.Text)
            Model.acc_credit4 = Model.EscapeString(cmbKredit4.Text)
            If txtMapoID.Text <> "" Then
                res = Model.UpdateData()
            Else
                res = Model.InsertData()
            End If
            FAkunPosting.init()
            Me.Close()
        End If
    End Sub
    Private Function DataIsValid() As Boolean
        DataIsValid = True
        If txtMapoID.Text <> "" Then
            If txtKode.Text <> txtMapoID.Text Then
                If Model.IfKeyExist(txtKode.Text) Then
                    statmsg.Text = "No Akun sudah ada, silahkan masukan No Akun yang lain."
                    statmsg.ForeColor = Color.DarkRed
                    txtKode.Focus()
                    DataIsValid = False
                Else
                    statmsg.Text = "No Akum Valid"
                    statmsg.ForeColor = Color.Green
                    DataIsValid = True
                End If
            End If
        Else
            If Model.IfKeyExist(txtKode.Text) Then
                statmsg.Text = "No Akun sudah ada, silahkan masukan No Akun yang lain."
                statmsg.ForeColor = Color.DarkRed
                txtKode.Focus()
                DataIsValid = False
            Else
                statmsg.Text = "No Akun Valid"
                statmsg.ForeColor = Color.Green
                DataIsValid = True
            End If
        End If
        If txtKode.Text = "" Then
            statmsg.Text = "No Akun tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtKode.Focus()
            DataIsValid = False
        ElseIf txtNama.Text = "" Then
            statmsg.Text = "No Akun tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtNama.Focus()
            DataIsValid = False
        End If

        Return DataIsValid
    End Function

    Private Sub txtNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtKode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKode.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Me.Close()
    End Sub
    Private Sub InitializeCmbDebit1()
        Dim dt As DataTable
        Try
            dt = Model2.GetData()
            'Isi Combo Debit 1
            cmbDebit1.DataSource = dt
            cmbDebit1.ValueMember = "mcoadno"
            cmbDebit1.SelectedIndex = -1

        Catch ex As Exception
            ' tampilkan pesan error
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub InitializeCmbDebit2()
        Dim dt As DataTable
        Try
            dt = Model2.GetData()
            'Isi Combo Debit 2
            cmbDebit2.DataSource = dt
            cmbDebit2.ValueMember = "mcoadno"
            cmbDebit2.SelectedIndex = -1
        Catch ex As Exception
            ' tampilkan pesan error
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub InitializeCmbDebit3()
        Dim dt As DataTable
        Try
            dt = Model2.GetData()
            'Isi Combo Debit 2
            cmbDebit3.DataSource = dt
            cmbDebit3.ValueMember = "mcoadno"
            cmbDebit3.SelectedIndex = -1
        Catch ex As Exception
            ' tampilkan pesan error
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub InitializeCmbDebit4()
        Dim dt As DataTable
        Try
            dt = Model2.GetData()
            'Isi Combo Debit 2
            cmbDebit4.DataSource = dt
            cmbDebit4.ValueMember = "mcoadno"
            cmbDebit4.SelectedIndex = -1
        Catch ex As Exception
            ' tampilkan pesan error
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub InitializeCmbKredit1()
        Dim dt As DataTable
        Try
            dt = Model2.GetData()
            'Isi Combo Debit 2
            cmbKredit1.DataSource = dt
            cmbKredit1.ValueMember = "mcoadno"
            cmbKredit1.SelectedIndex = -1
        Catch ex As Exception
            ' tampilkan pesan error
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub InitializeCmbKredit4()
        Dim dt As DataTable
        Try
            dt = Model2.GetData()
            'Isi Combo Debit 2
            cmbKredit4.DataSource = dt
            cmbKredit4.ValueMember = "mcoadno"
            cmbKredit4.SelectedIndex = -1
        Catch ex As Exception
            ' tampilkan pesan error
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub InitializeCmbKredit2()
        Dim dt As DataTable
        Try
            dt = Model2.GetData()
            'Isi Combo Debit 2
            cmbKredit2.DataSource = dt
            cmbKredit2.ValueMember = "mcoadno"
            cmbKredit2.SelectedIndex = -1
        Catch ex As Exception
            ' tampilkan pesan error
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub InitializeCmbKredit3()
        Dim dt As DataTable
        Try
            dt = Model2.GetData()
            'Isi Combo Debit 2
            cmbKredit3.DataSource = dt
            cmbKredit3.ValueMember = "mcoadno"
            cmbKredit3.SelectedIndex = -1
        Catch ex As Exception
            ' tampilkan pesan error
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmbDebit1_Click(sender As Object, e As EventArgs) Handles cmbDebit1.Click
        InitializeCmbDebit1()
    End Sub

    Private Sub cmbKredit1_Click(sender As Object, e As EventArgs) Handles cmbKredit1.Click
        InitializeCmbKredit1()
    End Sub

    Private Sub cmbKredit2_Click(sender As Object, e As EventArgs) Handles cmbKredit2.Click
        InitializeCmbKredit2()
    End Sub

    Private Sub cmbKredit3_Click(sender As Object, e As EventArgs) Handles cmbKredit3.Click
        InitializeCmbKredit3()
    End Sub

    Private Sub cmbKredit4_Click(sender As Object, e As EventArgs) Handles cmbKredit4.Click
        InitializeCmbKredit4()
    End Sub

    Private Sub cmbDebit4_Click(sender As Object, e As EventArgs) Handles cmbDebit4.Click
        InitializeCmbDebit4()
    End Sub

    Private Sub cmbDebit3_Click(sender As Object, e As EventArgs) Handles cmbDebit3.Click
        InitializeCmbDebit3()
    End Sub

    Private Sub cmbDebit2_Click(sender As Object, e As EventArgs) Handles cmbDebit2.Click
        InitializeCmbDebit2()
    End Sub
End Class