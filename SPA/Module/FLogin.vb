Public Class FLogin
    Dim Model As New MUsers

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cursor.Current = Cursors.WaitCursor
        ProgressBar1.Value = 30
        ProgressBar1.Visible = True
        If TextBox1.Text = "" Then
            MyApplication.ShowStatus("Id Pengguna harus diisi!!!", WARNING_STAT)
            TextBox1.Focus()
            Exit Sub
        End If
        If TextBox2.Text = "" Then
            MyApplication.ShowStatus("Sandi harus diisi!!!", WARNING_STAT)
            TextBox2.Focus()
            Exit Sub
        End If
        'Dim 
        If Model.DoLogin(Model.EscapeString(TextBox1.Text), Model.EscapeString(TextBox2.Text)) Then
            MainForm.RestrictUserMenu()
            ShowStatus("Ready")
            MainForm.MenuStrip.Visible = True
            Dim MsgLog As String = "Login Sukses "
            ErrorLogger.WriteToErrorLog(MsgLog & vbCrLf _
                                        & "Login Info : " & vbCrLf _
                                        & "Username = " & TextBox1.Text & ", Password = " & TextBox2.Text, "Login", "Login")
            MainForm.StatusPengguna.Text = MUsers.UserInfo()("fullname")
            Me.Close()
        Else
            Dim MsgLog As String = "Id Pengguna dan Sandi tidak cocok "
            'MessageBox.Show(MsgLog, "Sistem Autentifikasi...!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MyApplication.ShowStatus(MsgLog, WARNING_STAT)
            ErrorLogger.WriteToErrorLog(MsgLog & vbCrLf _
                                        & "Login Info : " & vbCrLf _
                                        & "Username = " & TextBox1.Text & ", Password = " & TextBox2.Text, "Failed Login", "Login")
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub FLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Panel1.Location.X = 200

        ProgressBar1.Visible = False
        Panel1.Left = (Me.Width / 2) - (Panel1.Width / 2)
        Panel1.Top = (Me.Height / 2) - (Panel1.Height / 2)
        If Global.SPA.My.Settings.ENVIRONTMENT = "DEV" Then
            TextBox1.Text = "admin"
            TextBox2.Text = "admin"
        End If
    End Sub
End Class