Module Application
    'Public Const DONECOLOR As Object = Color.MediumSpringGreen
    Sub Main()
        Try
            If IsNothing(BaseConnection.GetInstance()) Or BaseConnection.GetInstance().State <= 0 Then
                ShowStatus("Database is not Connected", Color.Red, Global.SPA.My.Resources.Resources.icon_warning, False)
                MainForm.MenuStrip.Enabled = False
            Else
                ShowStatus("Ready")
            End If

        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message)
            MainForm.MenuStrip.Enabled = False
        End Try
    End Sub
    Public Sub ShowStatus(ByVal Message As String, Optional refresh As Boolean = True, Optional TimeStatus As Integer = 1000)
        Try
            MainForm.TimeStat.Stop()
            MainForm.StatusMessage.Text = Message
            'MainForm.StatusMessage.BackColor = Color.White
            If refresh Then
                StatusMessageRefresh(TimeStatus)
            End If
        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message)
        End Try

    End Sub

    Public Sub ShowStatus(ByVal Message As String, ByVal color As System.Drawing.Color,
                          Optional ByVal icon As System.Drawing.Bitmap = Nothing,
                          Optional refresh As Boolean = True, Optional TimeStatus As Integer = 3000)
        Try
            MainForm.TimeStat.Stop()
            MainForm.StatusMessage.Text = Message
            'MainForm.StatusMessage.BackColor = color
            MainForm.StatusStrip.BackColor = color
            MainForm.statusmessageicon.Image = IIf(IsNothing(icon), Global.SPA.My.Resources.Resources.icon_info, icon)
            If refresh Then
                StatusMessageRefresh(TimeStatus)
            End If
            If Global.SPA.My.Settings.ENVIRONTMENT = "DEV" And Not IsNothing(icon) Then
                MessageBox.Show(Message)
            End If
        Catch ex As Exception
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
End Module
