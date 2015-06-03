Public Class FUserGroupAdd
    Private Model As New MUserGroup
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'MessageBox.Show(Model.EscapeString(TextBox1.Text))
        'Exit Sub
        If TextBox1.Text = "" Then
            'MessageBox.Show("User group cannot be empty")
            statmsg.Text = "Group Name cannot be empty !"
            statmsg.ForeColor = Color.DarkRed
            TextBox1.Focus()
        Else
            Dim res As Integer

            Model.groupname = Model.EscapeString(TextBox1.Text)
            Model.groupid = txtid.Text
            If txtid.Text <> "" Then
                res = Model.UpdateData()
                'MyApplication.ShowStatus("Data has been updated")
            Else
                res = Model.InsertData()
                'MyApplication.ShowStatus("Data has been saved")
            End If
            FUserGroup.init()
            'FUserGroup.RetrieveLast()
            Me.Close()
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub FUserGroupAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Focus()
        statmsg.Text = ""
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class