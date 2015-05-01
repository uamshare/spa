Public Class FTanamanMasuk

    Private Sub FTanamanMasuk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox(MUsers.UserListMenuPrivileges()(MainForm.MenuActive)("menuname"))
    End Sub
End Class