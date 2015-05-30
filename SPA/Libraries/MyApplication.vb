
'author : uam
Module MyApplication
    'Public Const DONECOLOR As Object = Color.MediumSpringGreen
    Public Const ERROR_STAT As String = "Error"
    Public Const NOTICE_STAT As String = "Notice"
    Public Const WARNING_STAT As String = "Warning"
    Public Const INFO_STAT As String = "Information"

    Public Const DefaultFormatDate = "dd-MM-yyyy"

    'Public PUSERID As Integer = 1
    Sub Main()
        If IsNothing(BaseConnection.GetInstance()) Or BaseConnection.GetInstance().State <= 0 Then
            'ShowStatus("Database is not Connected", ERROR_STAT, False)
            MainForm.MenuStrip.Enabled = False
            SetServer.ShowDialog()
        Else
            MainForm.MenuStrip.Enabled = True
            MainForm.LoadMdiChildForm(FLogin, "")
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
    Function ReportPath() As String
        Dim path As String = ""
        If System.IO.Directory.Exists(Application.StartupPath & "\Reports\") Then
            path = Application.StartupPath & "\Reports\"
        Else
            path = "..\..\Reports\"
        End If
        Return path
    End Function

    Sub InitializeDataGridView(DG As DataGridView)

        With DG
            ' Initialize basic DataGridView properties.
            .Dock = DockStyle.Fill
            .BackgroundColor = Color.LightGray
            .BorderStyle = BorderStyle.Fixed3D

            ' Set property values appropriate for read-only display and  
            ' limited interactivity. 
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = True
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = True
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            .AllowUserToResizeColumns = False
            .ColumnHeadersHeightSizeMode = _
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .AllowUserToResizeRows = False
            .RowHeadersWidthSizeMode = _
                DataGridViewRowHeadersWidthSizeMode.DisableResizing

            ' Set the selection background color for all the cells.
            .DefaultCellStyle.SelectionBackColor = Color.SteelBlue 'Color.CornflowerBlue
            .DefaultCellStyle.SelectionForeColor = Color.AliceBlue
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.True

            ' Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default 
            ' value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
            .RowHeadersDefaultCellStyle.SelectionBackColor = Color.White
            '.RowHeadersDefaultCellStyle.Font = New Font(.Font, FontStyle.Bold)
            .RowHeadersWidth = 100
            ' Set the background color for all rows and for alternating rows.  
            ' The value for alternating rows overrides the value for all rows. 
            .RowsDefaultCellStyle.BackColor = Color.LightSteelBlue 'Color.LightGray
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White 'Color.DarkGray

            ' Set the row and column header styles.
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 35
            .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            .RowHeadersDefaultCellStyle.BackColor = Color.Black

            .EditMode = DataGridViewEditMode.EditOnEnter
        End With
    End Sub
End Module
