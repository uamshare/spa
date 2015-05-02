Public Class FGroupCoaAdd
    Private Model As New MGroupCOA

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If txtGroupName.Text = "" Then
            'MessageBox.Show("User group cannot be empty")
            statmsg.Text = "Group COA tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtGroupName.Focus()
        Else
            Dim res As Integer

            Model.mcoagid = Model.EscapeString(txtGroupID.Text)
            Model.mcoagroup = txtGroupName.Text
            Model.mcoagid = Model.EscapeString(txtGroupID.Text)
            If txtGroupID.Text <> "" Then
                res = Model.UpdateData()
                'MyApplication.ShowStatus("Data has been updated")
            Else
                res = Model.InsertData()
                'MyApplication.ShowStatus("Data has been saved")
            End If

            FGroupCOA.init()
            Me.Close()
        End If
    End Sub

    Private Sub txtGroupName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGroupName.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Me.Close()
    End Sub
End Class