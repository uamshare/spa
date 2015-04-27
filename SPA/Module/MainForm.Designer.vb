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
        Me.InventoryMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.PenjualanMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccountingMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.PenggunaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrupAksesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DaftarPenggunaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.statusmessageicon = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.StatusMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TimeStat = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.BackColor = System.Drawing.Color.Gainsboro
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InventoryMenu, Me.PenjualanMenu, Me.AccountingMenu, Me.ToolsMenu, Me.ExitMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(634, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'InventoryMenu
        '
        Me.InventoryMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.InventoryMenu.Name = "InventoryMenu"
        Me.InventoryMenu.Size = New System.Drawing.Size(76, 20)
        Me.InventoryMenu.Text = "Persediaan"
        '
        'PenjualanMenu
        '
        Me.PenjualanMenu.Name = "PenjualanMenu"
        Me.PenjualanMenu.Size = New System.Drawing.Size(71, 20)
        Me.PenjualanMenu.Text = "Penjualan"
        '
        'AccountingMenu
        '
        Me.AccountingMenu.Name = "AccountingMenu"
        Me.AccountingMenu.Size = New System.Drawing.Size(81, 20)
        Me.AccountingMenu.Text = "Accounting"
        '
        'ToolsMenu
        '
        Me.ToolsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PenggunaToolStripMenuItem})
        Me.ToolsMenu.Name = "ToolsMenu"
        Me.ToolsMenu.Size = New System.Drawing.Size(80, 20)
        Me.ToolsMenu.Text = "Pengaturan"
        '
        'PenggunaToolStripMenuItem
        '
        Me.PenggunaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GrupAksesToolStripMenuItem, Me.DaftarPenggunaToolStripMenuItem})
        Me.PenggunaToolStripMenuItem.Name = "PenggunaToolStripMenuItem"
        Me.PenggunaToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.PenggunaToolStripMenuItem.Text = "Pengguna"
        '
        'GrupAksesToolStripMenuItem
        '
        Me.GrupAksesToolStripMenuItem.Name = "GrupAksesToolStripMenuItem"
        Me.GrupAksesToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.GrupAksesToolStripMenuItem.Text = "Grup Akses"
        '
        'DaftarPenggunaToolStripMenuItem
        '
        Me.DaftarPenggunaToolStripMenuItem.Name = "DaftarPenggunaToolStripMenuItem"
        Me.DaftarPenggunaToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.DaftarPenggunaToolStripMenuItem.Text = "Daftar Pengguna"
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
        Me.ToolStrip.Size = New System.Drawing.Size(26, 224)
        Me.ToolStrip.TabIndex = 6
        Me.ToolStrip.Text = "ToolStrip"
        '
        'StatusStrip
        '
        Me.StatusStrip.BackColor = System.Drawing.Color.DodgerBlue
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusmessageicon, Me.ToolProgressBar1, Me.StatusMessage})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 248)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(634, 22)
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
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(634, 270)
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
    Friend WithEvents InventoryMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents PenjualanMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccountingMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TimeStat As System.Windows.Forms.Timer
    Friend WithEvents PenggunaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrupAksesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DaftarPenggunaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolProgressBar1 As System.Windows.Forms.ToolStripProgressBar

End Class
