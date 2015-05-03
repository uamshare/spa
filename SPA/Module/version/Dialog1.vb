Imports System.Windows.Forms

Public Class Dialog1
    Dim Client As New Net.WebClient()

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim DR As DialogResult = FolderBrowserDialog1.ShowDialog
        If DR = Windows.Forms.DialogResult.OK Then
            Client.DownloadFile(Web_update.Downuri, _
            FolderBrowserDialog1.SelectedPath.ToString & _
            "\Program_update" & Date.Today.ToShortDateString.ToString & ".zip")
        End If
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Client.DownloadFile(Web_update.Downuri, _
                            My.Computer.FileSystem.SpecialDirectories.Temp.ToString & "\Program_update.zip")
        Process.Start(My.Computer.FileSystem.SpecialDirectories.Temp.ToString & "\Program_Update.zip")
        Application.Exit()
    End Sub

    Private Sub Dialog1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class