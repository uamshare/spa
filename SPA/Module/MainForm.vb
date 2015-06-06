Imports System.Windows.Forms

Public Class MainForm
    Public ChildForm As Form = Nothing
    Public MenuActive As String

    Private hideToolStripButton As Boolean = False
    Private formcolor As Color = Color.DarkSlateBlue 'ColorTranslator.FromHtml("#7CC3D2")
    
    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            Dim MsgLog As String = "Exit Application "
            ErrorLogger.WriteToErrorLog(MsgLog & vbCrLf _
                                            & "Login Info : " & vbCrLf _
                                            & "Username = " & MUsers.UserInfo()("username"), "Logout", "Logout")
        Catch ex As Exception
            ErrorLogger.WriteToErrorLogTxt(ex.Message, ex.StackTrace, "Error Exit Application")
        End Try
        End
    End Sub
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        Dim ctl As Control
        For Each ctl In Me.Controls
            If TypeOf (ctl) Is MdiClient Then CType(ctl, MdiClient).BackColor = formcolor 'Me.BackColor
        Next
    End Sub
    Private Sub TimeStat_Tick(sender As Object, e As EventArgs) Handles TimeStat.Tick
        TimeStat.Stop()
        'ToolProgressBar1.Visible = False
        StatusMessage.Text = ""
        StatusStrip.BackColor = Color.DodgerBlue
        StatusMessage.Text = "Application Ready"

        'MainForm.ProgressBar1.Visible = True

    End Sub
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'RestrictUserMenu()
        ToolStrip.Visible = False
        Main() ' Call Sub Main Application
    End Sub
    Public Sub LoadMdiChildForm(CForm As Form, menuname As String)
        Try
            If Not ChildForm Is Nothing Then
                If ChildForm.Name <> CForm.Name Then
                    ChildForm.Close()
                End If
            End If
            ChildForm = CForm
            MenuActive = menuname
            ChildForm.WindowState = FormWindowState.Maximized
            ChildForm.BackColor = formcolor 'Me.BackColor
            ChildForm.MdiParent = Me
            FormatChildForm(ChildForm)
            ChildForm.Padding = New System.Windows.Forms.Padding(5)
            ChildForm.Show()
            'Dim ctl As Control

        Catch ex As ObjectDisposedException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FormatChildForm(controll As Object)
        For Each ctl As Control In controll.Controls
            If TypeOf (ctl) Is Panel Then
                With CType(ctl, Panel)
                    .BackColor = Color.LightSteelBlue 'ColorTranslator.FromHtml("#107A91") 'Me.BackColor
                    .BorderStyle = BorderStyle.None
                End With
                FormatChildForm(ctl)
            End If
            
        Next
        '#107A91
    End Sub

#Region "Menu Akses"
    Private Sub ExitMenu_Click(sender As Object, e As EventArgs) Handles ExitMenu.Click
        Me.Close()
    End Sub
    Private Sub ToolPassword_Click(sender As Object, e As EventArgs) Handles ToolPassword.Click
        LoadMdiChildForm(FPassword, "")
    End Sub
    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripNav.Click
        'ToolStrip.ImageScalingSize = New System.Drawing.Size(16, 16)
        RestrictUserToolButton(Not hideToolStripButton)
        ToolStrip.Refresh()
    End Sub
    Private Sub ToolKeluar_Click(sender As Object, e As EventArgs) Handles ToolKeluar.Click
        FLogin.DoLogout()
        LoadMdiChildForm(FLogin, "")
    End Sub
    Private Sub menu501_Click(sender As Object, e As EventArgs) Handles menu501.Click
        'FUserGroup.WindowState = FormWindowState.Maximized
        'FUserGroup.MdiParent = Me
        'FUserGroup.Show()
        'ChildForm.Close()
        LoadMdiChildForm(FUserGroup, "menu501")
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
    Public Sub RestrictUserToolButton(Optional hide As Boolean = False)
        Try
            For Each btn As ToolStripButton In ToolStrip.Items
                Dim btnname As String = btn.Name.Remove(0, 2)
                If hide And btn.Name <> "ToolStripNav" Then
                    btn.Visible = False
                    hideToolStripButton = True
                    Me.ToolStripNav.Image = Global.SPA.My.Resources.Resources.resultset_next
                Else
                    'Console.WriteLine(btnname)
                    If MUsers.UserListMenuPrivileges().ContainsKey(btnname) Then
                        btn.Visible = MUsers.UserListMenuPrivileges()(btnname)("checked")
                        hideToolStripButton = False
                        Me.ToolStripNav.Image = Global.SPA.My.Resources.Resources.resultset_previous
                    End If
                End If
            Next
        Catch ex As Exception
            ErrorLogger.WriteToErrorLog("Error has occurred : " & ex.Message, ex.StackTrace, ERROR_STAT, "select", "2")
            MyApplication.ShowStatus("Error has occurred : " & ex.Message, ERROR_STAT, True, 10000)
        End Try
    End Sub
    Private Sub DataTanamanMasukToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles menu102.Click
        LoadMdiChildForm(FTanamanMasuk, "menu102")
    End Sub
    Private Sub menu101_Click(sender As Object, e As EventArgs) Handles menu101.Click
        'FDataTanaman.WindowState = FormWindowState.Maximized
        'FDataTanaman.MdiParent = Me
        'FDataTanaman.Show()
        LoadMdiChildForm(FDataTanaman, "menu101")
    End Sub
    Private Sub menu102_Click(sender As Object, e As EventArgs) Handles menu102.Click
        'FDataBibitTanaman.WindowState = FormWindowState.Maximized
        'FDataBibitTanaman.MdiParent = Me
        'FDataBibitTanaman.Show()
    End Sub
    Private Sub menu201_Click(sender As Object, e As EventArgs) Handles menu201.Click
        LoadMdiChildForm(FDataBibitTanaman, "menu201")
    End Sub
    Private Sub menu301_Click(sender As Object, e As EventArgs) Handles menu301.Click
        LoadMdiChildForm(FDataPelanggan, "menu301")
    End Sub
    Private Sub menu401_Click(sender As Object, e As EventArgs) Handles menu401.Click
        LoadMdiChildForm(FCOAheader, "menu401")
    End Sub
    Private Sub menu402_Click(sender As Object, e As EventArgs) Handles menu402.Click
        LoadMdiChildForm(FCOADetail, "menu402")
    End Sub
    Private Sub menu403_Click(sender As Object, e As EventArgs) Handles menu403.Click
        LoadMdiChildForm(FAkunPosting, "menu403")
    End Sub
    Private Sub menu502_Click(sender As Object, e As EventArgs) Handles menu502.Click
        LoadMdiChildForm(FDataPengguna, "menu502")
    End Sub
    Private Sub menu503_Click(sender As Object, e As EventArgs) Handles menu503.Click
        LoadMdiChildForm(FProfilPerusahaan, "menu503")
    End Sub
    Private Sub menu103_Click(sender As Object, e As EventArgs) Handles menu103.Click
        LoadMdiChildForm(FTransferStokTanaman, "menu103")
    End Sub
    Private Sub menu104_Click(sender As Object, e As EventArgs) Handles menu104.Click
        LoadMdiChildForm(FPenyesuaianStok, "menu104")
    End Sub
    Private Sub menu105_Click(sender As Object, e As EventArgs) Handles menu105.Click
        LoadMdiChildForm(FRekapStok, "menu105")
    End Sub
    Private Sub menu106_Click(sender As Object, e As EventArgs) Handles menu106.Click
        LoadMdiChildForm(FKartuStok, "menu106")
    End Sub
    Private Sub menu302_Click(sender As Object, e As EventArgs) Handles menu302.Click
        LoadMdiChildForm(FNotaPenjualan, "menu302")
    End Sub
    Private Sub menu202_Click(sender As Object, e As EventArgs) Handles menu202.Click
        LoadMdiChildForm(FDataBibitTanamanMasuk, "menu202")
    End Sub
    Private Sub menu303_Click(sender As Object, e As EventArgs) Handles menu303.Click
        LoadMdiChildForm(FReturPenjualan, "menu303")
    End Sub
    Private Sub menu304_Click(sender As Object, e As EventArgs) Handles menu304.Click
        LoadMdiChildForm(RInvoice, "menu304")
    End Sub
    Private Sub menu305_Click(sender As Object, e As EventArgs) Handles menu305.Click
        LoadMdiChildForm(RDetailInvoice, "menu305")
    End Sub
    Private Sub menu406_Click(sender As Object, e As EventArgs) Handles menu406.Click
        LoadMdiChildForm(RNeraca, "menu406")
    End Sub
    Private Sub menu407_Click(sender As Object, e As EventArgs) Handles menu407.Click
        LoadMdiChildForm(RLNeraca, "menu407")
    End Sub
    Private Sub menu408_Click(sender As Object, e As EventArgs) Handles menu408.Click
        LoadMdiChildForm(RRugiLaba, "menu408")
    End Sub
    Private Sub menu405_Click(sender As Object, e As EventArgs) Handles menu405.Click
        LoadMdiChildForm(RBukuBesar, "menu405")
    End Sub
    Private Sub menu409_Click(sender As Object, e As EventArgs) Handles menu409.Click
        LoadMdiChildForm(RArusKas, "menu409")
    End Sub
    Private Sub menu404_Click(sender As Object, e As EventArgs) Handles menu404.Click
        LoadMdiChildForm(FJurnalMemo, "menu404")
    End Sub
    Private Sub menu410_Click(sender As Object, e As EventArgs) Handles menu410.Click
        LoadMdiChildForm(RPersedianAkhir, "menu410")
    End Sub
    Private Sub tsmenu102_Click(sender As Object, e As EventArgs) Handles tsmenu102.Click
        'MessageBox.Show("menu102_click")
        DataTanamanMasukToolStripMenuItem_Click(sender, e)
    End Sub
    Private Sub tsmenu202_Click(sender As Object, e As EventArgs) Handles tsmenu202.Click
        menu202_Click(sender, e)
    End Sub
    Private Sub tsmenu203_Click(sender As Object, e As EventArgs) Handles tsmenu203.Click
        menu203_Click(sender, e)
    End Sub
    Private Sub tsmenu302_Click(sender As Object, e As EventArgs) Handles tsmenu302.Click
        menu302_Click(sender, e)
    End Sub
    Private Sub tsmenu404_Click(sender As Object, e As EventArgs) Handles tsmenu404.Click
        menu404_Click(sender, e)
    End Sub
    Private Sub menu203_Click(sender As Object, e As EventArgs) Handles menu203.Click

    End Sub
#End Region
    
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bw.DoWork
        'Try
        For i = 1 To 11
            If bw.CancellationPending = True Then
                e.Cancel = True
                'MsgBox("Canceled", "BackgroundWorker")
            Else
                'Me.ProgressBar1.Visible = True
                System.Threading.Thread.Sleep(10)
                If i = 11 Then
                    bw.ReportProgress(0)
                    i = 0
                Else
                    bw.ReportProgress(i * 10)
                End If
            End If
        Next
        'Catch ex As Exception
        '    MsgBox(ex.Message & vbCr & ex.StackTrace, "Error BackgroundWorker")
        '    bw.CancelAsync()
        'End Try
    End Sub
    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bw.ProgressChanged
        Me.ProgressBar1.Value = e.ProgressPercentage
        Console.WriteLine(e.ProgressPercentage.ToString)
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw.RunWorkerCompleted
        'Me.ProgressBar1.Visible = False
        ProgressBar1.Value = 0
        ProgressBar1.Style = ProgressBarStyle.Blocks
    End Sub
    
    Private Sub menuabout01_Click(sender As Object, e As EventArgs) Handles menuabout01.Click
        LoadMdiChildForm(FAbout, "")
    End Sub
End Class
