Imports System.Windows.Forms

Public Class MainForm
    Private ChildForm As Form = Nothing
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
        'FUserGroup.WindowState = FormWindowState.Maximized
        'FUserGroup.MdiParent = Me
        'FUserGroup.Show()
        'ChildForm.Close()
        LoadMdiChildForm(New FUserGroup)
    End Sub

    Sub LoadMdiChildForm(CForm As Form)
        If Not ChildForm Is Nothing Then ChildForm.Close()
        ChildForm = CForm
        ChildForm.WindowState = FormWindowState.Maximized
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub RestrictUserMenu()

    End Sub

    Private Sub DataTanamanMasukToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataTanamanMasukToolStripMenuItem.Click
        'FTanamanMasuk.WindowState = FormWindowState.Maximized
        'FTanamanMasuk.MdiParent = Me
        'FTanamanMasuk.Show()
        LoadMdiChildForm(New FTanamanMasuk)
    End Sub
End Class
