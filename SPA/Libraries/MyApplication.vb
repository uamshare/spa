
'author : uam
Module MyApplication
    'Public Const DONECOLOR As Object = Color.MediumSpringGreen
    Public Const ERROR_STAT As String = "Error"
    Public Const NOTICE_STAT As String = "Notice"
    Public Const WARNING_STAT As String = "Warning"
    Public Const INFO_STAT As String = "Information"


    'Public PUSERID As Integer = 1
    Sub Main()
        'MsgBox(CInt(Application.ProductVersion.Replace(".", "")))
        'Web_update.Main()
        If IsNothing(BaseConnection.GetInstance()) Or BaseConnection.GetInstance().State <= 0 Then
            ShowStatus("Database is not Connected", ERROR_STAT, False)
            MainForm.MenuStrip.Enabled = False
        Else
            'MsgBox(MUsers.UserListMenuPrivileges()("menu501")("menuname").ToString)
            MainForm.RestrictUserMenu()
            ShowStatus("Ready")
            MainForm.MenuStrip.Visible = True
        End If
        'MainForm.Show()
    End Sub
    'Public Sub ShowStatus(ByVal Message As String,
    '                      Optional refresh As Boolean = True,
    '                      Optional TimeStatus As Integer = 1000)
    '    Try
    '        MainForm.TimeStat.Stop()
    '        MainForm.StatusMessage.Text = Message
    '        'MainForm.StatusMessage.BackColor = Color.White
    '        If refresh Then
    '            StatusMessageRefresh(TimeStatus)
    '        End If
    '    Catch ex As Exception
    '        ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace, "Error Connection Database")
    '        MessageBox.Show("Error : " & ex.Message)
    '    End Try

    'End Sub

    Public Sub ShowStatus(ByVal Message As String,
                          Optional ByVal StatusType As String = INFO_STAT,
                          Optional refresh As Boolean = True,
                          Optional TimeStatus As Integer = 3000)

        Dim colorstatus As System.Drawing.Color = Nothing
        Dim icon As System.Drawing.Bitmap = Nothing

        Select Case StatusType
            Case INFO_STAT
                colorstatus = Color.MediumSpringGreen
                icon = Global.SPA.My.Resources.Resources.icon_info
            Case NOTICE_STAT
                colorstatus = Color.Yellow
                icon = Global.SPA.My.Resources.Resources.icon_info
            Case WARNING_STAT
                colorstatus = Color.Red
                icon = Global.SPA.My.Resources.Resources.icon_warning
                'ErrorLogger.WriteToErrorLog(Message, "Warning", "Warning")
            Case ERROR_STAT
                colorstatus = Color.Red
                icon = Global.SPA.My.Resources.Resources.icon_error
            Case Else
                colorstatus = Color.DodgerBlue
                icon = Global.SPA.My.Resources.Resources.icon_info
        End Select

        Try
            MainForm.TimeStat.Stop()
            MainForm.StatusMessage.Text = Message
            MainForm.StatusStrip.BackColor = colorstatus
            MainForm.statusmessageicon.Image = icon
            If refresh Then
                StatusMessageRefresh(TimeStatus)
            End If
            'MsgBox(StatusType)
            If Global.SPA.My.Settings.ENVIRONTMENT = "DEV" And StatusType <> INFO_STAT Then
                MessageBox.Show(Message, StatusType)
            End If
        Catch ex As Exception
            ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace, ERROR_STAT)
            MessageBox.Show("Error : " & ex.Message)
        End Try

    End Sub

    Private Sub StatusMessageRefresh(TimeStatus As Integer)
        Try
            MainForm.TimeStat.Interval = TimeStatus 'ms
            MainForm.TimeStat.Start()
        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message)
        End Try
        'Threading.Thread.Sleep(100) 'ms
        'MainForm.ToolProgressBar1.Visible = False
        'MainForm.StatusMessage.Text = ""
        'MainForm.StatusStrip.BackColor = Color.DodgerBlue
        'MainForm.StatusMessage.Text = "Application Ready"
    End Sub

    Public Function ValidNumber(e As KeyPressEventArgs) As Boolean
        Dim res As Boolean
        'Dim chr As Char
        Try
            'If Not e Is Nothing Then
            '    chr = e.KeyChar
            'End If
            If (Not e.KeyChar = ChrW(Keys.Back) And ("0123456789.").IndexOf(e.KeyChar) = -1) Then 'Or (chr = "." And Data.Text.ToCharArray().Count(Function(c) c = ".") > 0) Then
                res = True
                'If Not e Is Nothing Then e.Handled = True
            Else
                res = False
                'If Not e Is Nothing Then e.Handled = False
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return res
    End Function
End Module
