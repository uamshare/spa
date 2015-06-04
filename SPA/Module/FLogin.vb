Public Class FLogin
    Dim Model As New MUsers

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cursor.Current = Cursors.WaitCursor
        
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
        ProgressBar1.Value = 50
        ProgressBar1.Style = ProgressBarStyle.Marquee
        If Model.DoLogin(Model.EscapeString(TextBox1.Text), Model.EscapeString(TextBox2.Text)) Then
            MainForm.RestrictUserMenu()
            MainForm.RestrictUserToolButton()
            ShowStatus("Ready")
            MainForm.MenuStrip.Visible = True
            MainForm.ToolStrip.Visible = True
            Dim MsgLog As String = "Login Sukses "
            ErrorLogger.WriteToErrorLog(MsgLog & vbCrLf _
                                        & "Login Info : " & vbCrLf _
                                        & "Username = " & TextBox1.Text & ", Password = " & TextBox2.Text, "Login", "Login")
            MainForm.StatusPengguna.Text = MUsers.UserInfo()("fullname")
            MainForm.ToolUsername.Text = MUsers.UserInfo()("fullname")

            My.Settings.rememberusername = TextBox1.Text
            If CheckBox1.Checked Then
                My.Settings.rememberme = True
                My.Settings.rememberpassword = TextBox2.Text
            Else
                My.Settings.rememberme = False
                My.Settings.rememberpassword = ""
            End If
            My.Settings.Save()
            Me.Close()
        Else
            Dim MsgLog As String = "Id Pengguna dan Sandi tidak cocok "
            ProgressBar1.Value = 0
            ProgressBar1.Style = ProgressBarStyle.Blocks
            'MessageBox.Show(MsgLog, "Sistem Autentifikasi...!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MyApplication.ShowStatus(MsgLog, WARNING_STAT)
            ErrorLogger.WriteToErrorLog(MsgLog & vbCrLf _
                                        & "Login Info : " & vbCrLf _
                                        & "Username = " & TextBox1.Text & ", Password = " & TextBox2.Text, "Failed Login", "Login")
        End If
        MainForm.bw.CancelAsync()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub FLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Panel1.Location.X = 200

        'ProgressBar1.Visible = False
        Panel1.Left = (Me.Width / 2) - (Panel1.Width / 2)
        Panel1.Top = (Me.Height / 2) - (Panel1.Height / 2)
        'If Global.SPA.My.Settings.ENVIRONTMENT = "DEV" Then
        TextBox1.Text = My.Settings.rememberusername
        TextBox2.Text = My.Settings.rememberpassword
        'End If
        Panel2.BackColor = Color.WhiteSmoke
        Panel3.BackColor = Color.WhiteSmoke
        Panel4.BackColor = Color.WhiteSmoke

        If My.Settings.rememberme Then
            CheckBox1.Checked = True
        End If
    End Sub
    Public Sub DoLogout()
        If Not My.Settings.rememberme Then
            'My.Settings.rememberme = False
            My.Settings.rememberpassword = ""
            My.Settings.rememberusername = ""
        End If
        My.Settings.Save()

        MainForm.MenuStrip.Visible = False
        MainForm.ToolStrip.Visible = False
        MainForm.ToolUsername.Text = "Pengguna"
        Dim MsgLog As String = "Logout Sukses "
        ErrorLogger.WriteToErrorLog(MsgLog & vbCrLf _
                                        & "Login Info : " & vbCrLf _
                                        & "Username = " & MUsers.UserInfo()("username"), "Logout", "Logout")
        Model.DoLogout()
    End Sub
End Class