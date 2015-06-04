Public Class FDataPenggunaAdd
    Private Model As New MDataPengguna
    Private Model2 As New MUserGroup
    Private Model3 As New MUsers
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        'MessageBox.Show(Model.EscapeString(TextBox1.Text))
        'Exit Sub
        If DataIsValid() Then
            Dim res As Integer

            Model.mempid = Model.EscapeString(txtKode.Text)
            Model.mempname = Model.EscapeString(txtNama.Text)
            Model.memphone1 = Model.EscapeString(txtPhon1.Text)
            Model.memphone2 = Model.EscapeString(txtPhon2.Text)
            Model.mempemail = Model.EscapeString(txtEmail.Text)
            Model.groupid = Model.EscapeString(txtGroupID.Text)
            Model.username = Model.EscapeString(txtUser.Text)
            Model.password = ""
            If txtPass.Text <> txtpassold.Text Then
                Dim dr As DialogResult = MessageBox.Show("Apakah password pengguna akan dirubah ?  " & vbCrLf & _
                                                         "[Yes] Simpan dan ubah password" & vbCrLf & _
                                                         "[No] Simpan tanpa mengubah password" & vbCrLf & _
                                                         "[Cancel] Batal menyimpan" & vbCrLf _
                                                         , "Konfirmasi" _
                                                         , MessageBoxButtons.YesNoCancel _
                                                         , MessageBoxIcon.Question)
                If dr = Windows.Forms.DialogResult.Yes Then
                    Model.password = Model.EscapeString(txtPass.Text)
                ElseIf dr = Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                End If
            End If

            Model.userid = Model.EscapeString(txtUserID.Text)
            If txtKode.Text <> "" Then
                res = Model.UpdateDataPengguna() And Model.UpdateDataUser()
            Else
                res = Model.InsertDataUser()
                If InitializeUser() Then
                    Model.userid = Model.EscapeString(txtUserID.Text)
                    res = Model.InsertPengguna()
                End If
            End If
            FDataPengguna.init()
            Me.Close()
        End If
    End Sub

    Private Function DataIsValid() As Boolean
        DataIsValid = True

        If UserName.Text <> "" Then
            If txtUser.Text <> UserName.Text Then
                If Model.IfDataExist3(txtUser.Text) Then
                    statmsg.Text = "UserName sudah ada, silahkan masukan UserName yang lain."
                    statmsg.ForeColor = Color.DarkRed
                    txtUser.Focus()
                    DataIsValid = False
                Else
                    statmsg.Text = "UserName Valid"
                    statmsg.ForeColor = Color.Green
                    DataIsValid = True
                End If
            End If
        Else
            If Model.IfDataExist3(txtUser.Text) Then
                statmsg.Text = "UserName sudah ada, silahkan masukan UserName yang lain."
                statmsg.ForeColor = Color.DarkRed
                txtNama.Focus()
                DataIsValid = False
            Else
                statmsg.Text = "UserName Valid"
                statmsg.ForeColor = Color.Green
                DataIsValid = True
            End If
        End If

        If txtNama.Text = "" Then
            statmsg.Text = "Nama tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtNama.Focus()
            DataIsValid = False

        ElseIf cmbGroup.Text = "" Then
            statmsg.Text = "Group Aksess tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            cmbGroup.Focus()
            DataIsValid = False

        ElseIf txtUser.Text = "" Then
            statmsg.Text = "UserName tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtUser.Focus()
            DataIsValid = False
        ElseIf txtPass.Text = "" Then
            statmsg.Text = "Password tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtPass.Focus()
            DataIsValid = False
        ElseIf txtGroupID.Text = "" Then
            statmsg.Text = "Group Aksess harus di Pilih !"
            statmsg.ForeColor = Color.DarkRed
            cmbGroup.Focus()
            DataIsValid = False
        End If

        Return DataIsValid

    End Function

    Private Sub txtPhon1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhon1.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtPhon2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhon2.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Me.Close()
    End Sub
    Private Sub InitializeCmbGroup()
        Dim dt As DataTable
        Try
            dt = Model2.GetData()
            'Isi Combo Debit 1
            cmbGroup.DataSource = dt
            cmbGroup.ValueMember = "groupid"
            cmbGroup.DisplayMember = "groupname"
            cmbGroup.SelectedIndex = -1

        Catch ex As Exception
            ' tampilkan pesan error
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function InitializeUser() As Boolean
        InitializeUser = True
        Dim dt As DataTable
        Try
            dt = Model3.GetData()
            'Isi Combo Debit 1
            Dim useridLast As String = dt.Rows.Item(1).Item("LAST_INSERT_ID()")
            txtUserID.Text = useridLast
            InitializeUser = True

        Catch ex As Exception
            ' tampilkan pesan error
            MessageBox.Show(ex.Message)
            InitializeUser = False
        End Try
    End Function
    Private Sub cmbGroup_Click(sender As Object, e As EventArgs) Handles cmbGroup.Click
        InitializeCmbGroup()
    End Sub

    Private Sub cmbGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGroup.SelectedIndexChanged
        txtGroupID.Text = Convert.ToString(cmbGroup.SelectedValue)
    End Sub
End Class