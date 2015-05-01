Imports System.Windows.Forms

Public Class MainForm
    Private Sub ExitMenu_Click(sender As Object, e As EventArgs) Handles ExitMenu.Click
        Me.Close()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Main() ' Call Sub Main Application
    End Sub

    Private Sub TimeStat_Tick(sender As Object, e As EventArgs) Handles TimeStat.Tick
        TimeStat.Stop()
        ToolProgressBar1.Visible = False
        StatusMessage.Text = ""
        StatusStrip.BackColor = Color.DodgerBlue
        StatusMessage.Text = "Application Ready"

    End Sub


    Private Sub menu501_Click(sender As Object, e As EventArgs) Handles menu501.Click
        FUserGroup.WindowState = FormWindowState.Maximized
        FUserGroup.MdiParent = Me
        FUserGroup.Show()
    End Sub

    Private Sub menu101_Click(sender As Object, e As EventArgs) Handles menu101.Click
        FDataTanaman.WindowState = FormWindowState.Maximized
        FDataTanaman.MdiParent = Me
        FDataTanaman.Show()
    End Sub
End Class
