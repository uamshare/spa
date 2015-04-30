Imports System.Windows.Forms

Public Class MainForm
    Private ChildForm As Form = Nothing
    Private Sub ExitMenu_Click(sender As Object, e As EventArgs) Handles ExitMenu.Click
        Me.Close()
    End Sub
    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'RestrictUserMenu()
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
        LoadMdiChildForm(New FUserGroup, "menu501")
    End Sub

    Sub LoadMdiChildForm(CForm As Form, menuname As String)
        If Not ChildForm Is Nothing Then ChildForm.Close()
        ChildForm = CForm
        ChildForm.Name = menuname
        ChildForm.WindowState = FormWindowState.Maximized
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Public Sub RestrictUserMenu(Optional MenuItems As ToolStripMenuItem = Nothing)
        Try
            If MenuItems Is Nothing Then
                For Each toolmenu As ToolStripMenuItem In MenuStrip.Items
                    If MUsers.UserListMenuPrivileges().ContainsKey(toolmenu.Name) Then
                        toolmenu.Visible = MUsers.UserListMenuPrivileges()(toolmenu.Name)("checked")
                    End If
                    RestrictUserMenu(toolmenu)
                Next
            Else
                For Each toolmenu In MenuItems.DropDownItems
                    If MUsers.UserListMenuPrivileges().ContainsKey(toolmenu.Name) Then
                        toolmenu.Visible = MUsers.UserListMenuPrivileges()(toolmenu.Name)("checked")
                    End If
                    RestrictUserMenu(toolmenu)
                Next
            End If

        Catch ex As Exception
            ErrorLogger.WriteToErrorLog("Error has occurred : " & ex.Message, ex.StackTrace, ERROR_STAT, "select", "2")
            MyApplication.ShowStatus("Error has occurred : " & ex.Message, ERROR_STAT, True, 10000)
        End Try
    End Sub

    Private Sub DataTanamanMasukToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles menu102.Click
        LoadMdiChildForm(New FTanamanMasuk, "menu102")
    End Sub

End Class
