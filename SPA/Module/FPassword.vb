Public Class FPassword
    Dim Model As New MUsers

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cursor.Current = Cursors.WaitCursor

        If TextBox1.Text = "" Then
            MyApplication.ShowStatus("Sandi Lama harus diisi!!!", WARNING_STAT)
            TextBox1.Focus()
            Exit Sub
        End If
        If TextBox2.Text = "" Then
            MyApplication.ShowStatus("Sandi baru harus diisi!!!", WARNING_STAT)
            TextBox2.Focus()
            Exit Sub
        End If
        'Dim 
        If Not Model.DoLogin(MUsers.UserInfo()("username"), Model.EscapeString(TextBox1.Text)) Then
            Dim MsgLog As String = "Sandi lama tidak sesuai"
            ShowStatus(MsgLog, WARNING_STAT)
        Else
            Model.userpassword = TextBox2.Text
            Model.userid = MUsers.UserInfo()("userid")
            If Model.UpdatePassword() > 0 Then
                MyApplication.ShowStatus("Sandi berhasil diubah!!!", INFO_STAT)
            End If
            Me.Close()
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub FLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Left = (Me.Width / 2) - (Panel1.Width / 2)
        Panel1.Top = (Me.Height / 2) - (Panel1.Height / 2)
        TextBox1.Text = ""
        TextBox2.Text = ""
        Panel2.BackColor = Color.WhiteSmoke
        Panel3.BackColor = Color.WhiteSmoke
        Panel4.BackColor = Color.WhiteSmoke
    End Sub
End Class