Public Class SetServer
    Dim cserver As String = My.Settings.server
    Dim cuid As String = My.Settings.uid
    Dim cpwd As String = My.Settings.pwd
    Dim cdatabase As String = My.Settings.database
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.server = TextBox1.Text
        My.Settings.uid = TextBox2.Text
        TextBox5.Text = TextBox3.Text
        My.Settings.pwd = TextBox5.Text
        My.Settings.database = TextBox4.Text

        If BaseConnection.GetInstance().State <= 0 Then
            ShowStatus("Database is not Connected", ERROR_STAT, False)
        Else
            My.Settings.Save()
            Me.Close()
            Main()
        End If
    End Sub

    Private Sub SetServer_Load(sender As Object, e As EventArgs) Handles Me.Load
        'database()
        TextBox1.Text = cserver
        TextBox2.Text = cuid
        TextBox3.Text = "pasworduntukdatabaseserver123242"
        TextBox4.Text = cdatabase
        TextBox5.Text = cpwd
    End Sub
End Class