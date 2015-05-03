Public Class FCOADetailAdd
    Private Model As New MCOADetail

    Private Sub btbSimpan_Click(sender As Object, e As EventArgs) Handles btbSimpan.Click
        If DataIsValid() Then
            Dim res As Integer

            Model.mcoadno = Model.EscapeString(txtCoaDetail.Text)
            Model.mcoadname = Model.EscapeString(txtNamaAkun.Text)
            Model.mcoahno = Model.EscapeString(txtHeader.Text)
            If txtDetail.Text <> "" Then
                res = Model.UpdateData()
            Else
                res = Model.InsertData()
            End If
            FCOAheader.init()
            Me.Close()
        End If
    End Sub
    Private Function DataIsValid() As Boolean
        DataIsValid = True
        If txtDetail.Text <> "" Then
            If txtCoaDetail.Text <> txtDetail.Text Then
                If Model.IfKeyExist(txtCoaDetail.Text) Then
                    statmsg.Text = "No Akun sudah ada, silahkan masukan No Akun yang lain."
                    statmsg.ForeColor = Color.DarkRed
                    txtCoaDetail.Focus()
                    DataIsValid = False
                Else
                    statmsg.Text = "No Akum Valid"
                    statmsg.ForeColor = Color.Green
                    DataIsValid = True
                End If
            End If
        Else
            If Model.IfKeyExist(txtCoaDetail.Text) Then
                statmsg.Text = "No Akun sudah ada, silahkan masukan No Akun yang lain."
                statmsg.ForeColor = Color.DarkRed
                txtCoaDetail.Focus()
                DataIsValid = False
            Else
                statmsg.Text = "No Akun Valid"
                statmsg.ForeColor = Color.Green
                DataIsValid = True
            End If
        End If
        If txtCoaDetail.Text = "" Then
            statmsg.Text = "No Akun tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtCoaDetail.Focus()
            DataIsValid = False
        Else
            If Len(txtCoaDetail.Text) < 6 Then
                'MessageBox.Show("User group cannot be empty")
                statmsg.Text = "No Akun tidak boleh kurang dari 6 digit !"
                statmsg.ForeColor = Color.DarkRed
                txtCoaDetail.Focus()
                DataIsValid = False
            ElseIf UBound(Split(txtCoaDetail.Text, " ")) > 0 Then
                statmsg.Text = "No Akun tidak boleh menggunakan spasi !"
                statmsg.ForeColor = Color.DarkRed
                txtCoaDetail.Focus()
                DataIsValid = False
            ElseIf Strings.Right(txtCoaDetail.Text, 2) = "00" Then
                statmsg.Text = "No Akun tidak boleh diakhiri 00 !"
                statmsg.ForeColor = Color.DarkRed
                txtCoaDetail.Focus()
                DataIsValid = False
            End If
        End If
        If txtCoaHeader.Text = "" Then
            statmsg.Text = "COC Header tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtCoaHeader.Focus()
            DataIsValid = False
        End If

        Return DataIsValid
    End Function

    Private Sub btnPrompt_Click(sender As Object, e As EventArgs) Handles btnPrompt.Click
        FHeader.ShowDialog()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Me.Close()
    End Sub

    Private Sub txtNamaAkun_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNamaAkun.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtCoaDetail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCoaDetail.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
End Class