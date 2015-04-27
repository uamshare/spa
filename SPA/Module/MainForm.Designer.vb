<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.menu100 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu200 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu300 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu400 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu500 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu502 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu503 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.statusmessageicon = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.StatusMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TimeStat = New System.Windows.Forms.Timer(Me.components)
        Me.menu501 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.BackColor = System.Drawing.Color.Gainsboro
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu100, Me.menu200, Me.menu300, Me.menu400, Me.menu500, Me.ExitMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(779, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'menu100
        '
        Me.menu100.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.menu100.Name = "menu100"
        Me.menu100.Size = New System.Drawing.Size(128, 20)
        Me.menu100.Text = "Persediaan Tanaman"
        '
        'menu200
        '
        Me.menu200.Name = "menu200"
        Me.menu200.Size = New System.Drawing.Size(167, 20)
        Me.menu200.Text = "Penangkaran Bibit Tanaman"
        '
        'menu300
        '
        Me.menu300.Name = "menu300"
        Me.menu300.Size = New System.Drawing.Size(123, 20)
        Me.menu300.Text = "Penjualan Tanaman"
        '
        'menu400
        '
        Me.menu400.Name = "menu400"
        Me.menu400.Size = New System.Drawing.Size(72, 20)
        Me.menu400.Text = "Akuntansi"
        '
        'menu500
        '
        Me.menu500.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu501, Me.menu502, Me.menu503})
        Me.menu500.Name = "menu500"
        Me.menu500.Size = New System.Drawing.Size(80, 20)
        Me.menu500.Text = "Pengaturan"
        '
        'menu502
        '
        Me.menu502.Name = "menu502"
        Me.menu502.Size = New System.Drawing.Size(226, 22)
        Me.menu502.Text = "Pengguna"
        '
        'menu503
        '
        Me.menu503.Name = "menu503"
        Me.menu503.Size = New System.Drawing.Size(226, 22)
        Me.menu503.Text = "Profil Perusahaan"
        '
        'ExitMenu
        '
        Me.ExitMenu.Name = "ExitMenu"
        Me.ExitMenu.Size = New System.Drawing.Size(52, 20)
        Me.ExitMenu.Text = "Keluar"
        '
        'ToolStrip
        '
        Me.ToolStrip.BackColor = System.Drawing.Color.Gainsboro
        Me.ToolStrip.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(26, 353)
        Me.ToolStrip.TabIndex = 6
        Me.ToolStrip.Text = "ToolStrip"
        '
        'StatusStrip
        '
        Me.StatusStrip.BackColor = System.Drawing.Color.DodgerBlue
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusmessageicon, Me.ToolProgressBar1, Me.StatusMessage})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 377)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(779, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'statusmessageicon
        '
        Me.statusmessageicon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.statusmessageicon.Image = Global.SPA.My.Resources.Resources.icon_info
        Me.statusmessageicon.Name = "statusmessageicon"
        Me.statusmessageicon.Size = New System.Drawing.Size(16, 17)
        Me.statusmessageicon.Text = "::"
        '
        'ToolProgressBar1
        '
        Me.ToolProgressBar1.Margin = New System.Windows.Forms.Padding(10, 3, 1, 3)
        Me.ToolProgressBar1.Name = "ToolProgressBar1"
        Me.ToolProgressBar1.Size = New System.Drawing.Size(100, 16)
        Me.ToolProgressBar1.Step = 5
        Me.ToolProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ToolProgressBar1.Value = 10
        Me.ToolProgressBar1.Visible = False
        '
        'StatusMessage
        '
        Me.StatusMessage.Margin = New System.Windows.Forms.Padding(5, 3, 0, 2)
        Me.StatusMessage.Name = "StatusMessage"
        Me.StatusMessage.Size = New System.Drawing.Size(79, 17)
        Me.StatusMessage.Text = "Please Wait ..."
        '
        'TimeStat
        '
        '
        'menu501
        '
        Me.menu501.Name = "menu501"
        Me.menu501.Size = New System.Drawing.Size(166, 22)
        Me.menu501.Text = "Grup Akses"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(779, 399)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "MainForm"
        Me.Text = "MainForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ExitMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents statusmessageicon As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents menu100 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents menu200 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu300 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu500 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TimeStat As System.Windows.Forms.Timer
    Friend WithEvents ToolProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents menu400 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu502 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu503 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu501 As System.Windows.Forms.ToolStripMenuItem

End Class
