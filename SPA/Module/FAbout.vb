Imports System.Deployment.Application
Public Class FAbout

    Private Sub FAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = My.Application.Info.Title
        Else
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        Panel1.Left = (Me.Width / 2) - (Panel1.Width / 2)
        Panel1.Top = (Me.Height / 2) - (Panel1.Height / 2)
        Panel1.BackColor = Color.WhiteSmoke
        Panel1.BackColor = Color.WhiteSmoke
        Panel1.BackColor = Color.WhiteSmoke

    End Sub

    Private Sub InstallUpdateSyncWithInfo()
        Dim info As UpdateCheckInfo = Nothing
        Dim CaptionMsg As String = "SPA Application update"
        If (ApplicationDeployment.IsNetworkDeployed) Then
            Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment
            Try
                info = AD.CheckForDetailedUpdate()
            Catch dde As DeploymentDownloadException
                MessageBox.Show("The new version of the application cannot be downloaded at this time. " + ControlChars.Lf & ControlChars.Lf & "Please check your network connection, or try again later. Error: " + dde.Message, CaptionMsg)
                Return
            Catch ioe As InvalidOperationException
                MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " & ioe.Message)
                Return
            End Try

            If (info.UpdateAvailable) Then
                Dim doUpdate As Boolean = True

                If (Not info.IsUpdateRequired) Then
                    Dim dr As DialogResult = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel)
                    If (Not System.Windows.Forms.DialogResult.OK = dr) Then
                        doUpdate = False
                    End If
                Else
                    ' Display a message that the app MUST reboot. Display the minimum required version.
                    MessageBox.Show("This application has detected a mandatory update from your current " & _
                        "version to version " & info.MinimumRequiredVersion.ToString() & _
                        ". The application will now install the update and restart.", _
                        "Update Available", MessageBoxButtons.OK, _
                        MessageBoxIcon.Information)
                End If

                If (doUpdate) Then
                    Try
                        AD.Update()
                        MessageBox.Show("The application has been upgraded, and will now restart.")
                        Application.Restart()
                    Catch dde As DeploymentDownloadException
                        MessageBox.Show("Cannot install the latest version of the application. " & ControlChars.Lf & ControlChars.Lf & "Please check your network connection, or try again later.", CaptionMsg)
                        Return
                    End Try
                End If
            End If
        Else
            MessageBox.Show("You do not have permision, please contact your administrator.", CaptionMsg)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        InstallUpdateSyncWithInfo()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.LinkLabel1.LinkVisited = True
        System.Diagnostics.Process.Start("http://www.uam.web.id")
    End Sub
End Class