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
        Me.menu101 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu102 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu103 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu104 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu105 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu106 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu200 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu201 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu202 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu203 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu204 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu205 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu206 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu300 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu301 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu302 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu303 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu304 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu305 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu400 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu401 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu402 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu403 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu404 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu405 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu406 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu407 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu408 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu409 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu410 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu500 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu501 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu502 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu503 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.statusmessageicon = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TimeStat = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.StatusPengguna = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.bw = New System.ComponentModel.BackgroundWorker()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.BackColor = System.Drawing.Color.Gainsboro
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu100, Me.menu200, Me.menu300, Me.menu400, Me.menu500, Me.ExitMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(873, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        Me.MenuStrip.Visible = False
        '
        'menu100
        '
        Me.menu100.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu101, Me.menu102, Me.menu103, Me.menu104, Me.menu105, Me.menu106})
        Me.menu100.Image = Global.SPA.My.Resources.Resources.inventory2
        Me.menu100.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.menu100.Name = "menu100"
        Me.menu100.Size = New System.Drawing.Size(144, 20)
        Me.menu100.Text = "Persediaan Tanaman"
        '
        'menu101
        '
        Me.menu101.Name = "menu101"
        Me.menu101.Size = New System.Drawing.Size(194, 22)
        Me.menu101.Text = "Data Tanaman"
        '
        'menu102
        '
        Me.menu102.Name = "menu102"
        Me.menu102.Size = New System.Drawing.Size(194, 22)
        Me.menu102.Text = "Data Tanaman Masuk"
        '
        'menu103
        '
        Me.menu103.Name = "menu103"
        Me.menu103.Size = New System.Drawing.Size(194, 22)
        Me.menu103.Text = "Transfer Stok Tanaman"
        '
        'menu104
        '
        Me.menu104.Name = "menu104"
        Me.menu104.Size = New System.Drawing.Size(194, 22)
        Me.menu104.Text = "Penyesuaian Stok"
        '
        'menu105
        '
        Me.menu105.Name = "menu105"
        Me.menu105.Size = New System.Drawing.Size(194, 22)
        Me.menu105.Text = "Stok Tanaman"
        '
        'menu106
        '
        Me.menu106.Name = "menu106"
        Me.menu106.Size = New System.Drawing.Size(194, 22)
        Me.menu106.Text = "Kartu Stok Tanaman"
        '
        'menu200
        '
        Me.menu200.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu201, Me.menu202, Me.menu203, Me.menu204, Me.menu205, Me.menu206})
        Me.menu200.Image = Global.SPA.My.Resources.Resources.production
        Me.menu200.Name = "menu200"
        Me.menu200.Size = New System.Drawing.Size(183, 20)
        Me.menu200.Text = "Penangkaran Bibit Tanaman"
        '
        'menu201
        '
        Me.menu201.Name = "menu201"
        Me.menu201.Size = New System.Drawing.Size(319, 22)
        Me.menu201.Text = "Data Bibit Tanaman"
        '
        'menu202
        '
        Me.menu202.Name = "menu202"
        Me.menu202.Size = New System.Drawing.Size(319, 22)
        Me.menu202.Text = "Data Bibit Tanaman Masuk"
        '
        'menu203
        '
        Me.menu203.Name = "menu203"
        Me.menu203.Size = New System.Drawing.Size(319, 22)
        Me.menu203.Text = "Proses Penangkaran"
        '
        'menu204
        '
        Me.menu204.Name = "menu204"
        Me.menu204.Size = New System.Drawing.Size(319, 22)
        Me.menu204.Text = "Proses Bibit Tanaman Siap Jual"
        '
        'menu205
        '
        Me.menu205.Name = "menu205"
        Me.menu205.Size = New System.Drawing.Size(319, 22)
        Me.menu205.Text = "Stok Bibit Tanaman & Proses Penangkaran"
        '
        'menu206
        '
        Me.menu206.Name = "menu206"
        Me.menu206.Size = New System.Drawing.Size(319, 22)
        Me.menu206.Text = "Kartu Stok Bibit Tanaman & Proses Penangkaran"
        '
        'menu300
        '
        Me.menu300.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu301, Me.menu302, Me.menu303, Me.menu304, Me.menu305})
        Me.menu300.Image = Global.SPA.My.Resources.Resources.sales2
        Me.menu300.Name = "menu300"
        Me.menu300.Size = New System.Drawing.Size(139, 20)
        Me.menu300.Text = "Penjualan Tanaman"
        '
        'menu301
        '
        Me.menu301.Name = "menu301"
        Me.menu301.Size = New System.Drawing.Size(204, 22)
        Me.menu301.Text = "Data Pelanggan"
        '
        'menu302
        '
        Me.menu302.Name = "menu302"
        Me.menu302.Size = New System.Drawing.Size(204, 22)
        Me.menu302.Text = "Nota Penjualan / Invoice"
        '
        'menu303
        '
        Me.menu303.Name = "menu303"
        Me.menu303.Size = New System.Drawing.Size(204, 22)
        Me.menu303.Text = "Retur Penjualan"
        '
        'menu304
        '
        Me.menu304.Name = "menu304"
        Me.menu304.Size = New System.Drawing.Size(204, 22)
        Me.menu304.Text = "Rekap Penjualan"
        '
        'menu305
        '
        Me.menu305.Name = "menu305"
        Me.menu305.Size = New System.Drawing.Size(204, 22)
        Me.menu305.Text = "Rinician Penjualan"
        '
        'menu400
        '
        Me.menu400.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu401, Me.menu402, Me.menu403, Me.menu404, Me.menu405, Me.menu406, Me.menu407, Me.menu408, Me.menu409, Me.menu410})
        Me.menu400.Image = Global.SPA.My.Resources.Resources.accounting77
        Me.menu400.Name = "menu400"
        Me.menu400.Size = New System.Drawing.Size(88, 20)
        Me.menu400.Text = "Akuntansi"
        '
        'menu401
        '
        Me.menu401.Name = "menu401"
        Me.menu401.Size = New System.Drawing.Size(208, 22)
        Me.menu401.Text = "COA Header"
        '
        'menu402
        '
        Me.menu402.Name = "menu402"
        Me.menu402.Size = New System.Drawing.Size(208, 22)
        Me.menu402.Text = "COA Detail"
        '
        'menu403
        '
        Me.menu403.Name = "menu403"
        Me.menu403.Size = New System.Drawing.Size(208, 22)
        Me.menu403.Text = "Akun Posting Otomatis"
        '
        'menu404
        '
        Me.menu404.Name = "menu404"
        Me.menu404.Size = New System.Drawing.Size(208, 22)
        Me.menu404.Text = "Jurnal Memorial"
        '
        'menu405
        '
        Me.menu405.Name = "menu405"
        Me.menu405.Size = New System.Drawing.Size(208, 22)
        Me.menu405.Text = "Buku Besar"
        '
        'menu406
        '
        Me.menu406.Name = "menu406"
        Me.menu406.Size = New System.Drawing.Size(208, 22)
        Me.menu406.Text = "Neraca"
        '
        'menu407
        '
        Me.menu407.Name = "menu407"
        Me.menu407.Size = New System.Drawing.Size(208, 22)
        Me.menu407.Text = "Lampiran Neraca"
        '
        'menu408
        '
        Me.menu408.Name = "menu408"
        Me.menu408.Size = New System.Drawing.Size(208, 22)
        Me.menu408.Text = "Rugi Laba"
        '
        'menu409
        '
        Me.menu409.Name = "menu409"
        Me.menu409.Size = New System.Drawing.Size(208, 22)
        Me.menu409.Text = "Arus Kas dan Bank"
        '
        'menu410
        '
        Me.menu410.Name = "menu410"
        Me.menu410.Size = New System.Drawing.Size(208, 22)
        Me.menu410.Text = "Persedian Akhir Tanaman"
        '
        'menu500
        '
        Me.menu500.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu501, Me.menu502, Me.menu503})
        Me.menu500.Image = Global.SPA.My.Resources.Resources.settings77
        Me.menu500.Name = "menu500"
        Me.menu500.Size = New System.Drawing.Size(96, 20)
        Me.menu500.Text = "Pengaturan"
        '
        'menu501
        '
        Me.menu501.Name = "menu501"
        Me.menu501.Size = New System.Drawing.Size(166, 22)
        Me.menu501.Text = "Grup Akses"
        '
        'menu502
        '
        Me.menu502.Name = "menu502"
        Me.menu502.Size = New System.Drawing.Size(166, 22)
        Me.menu502.Text = "Pengguna"
        '
        'menu503
        '
        Me.menu503.Name = "menu503"
        Me.menu503.Size = New System.Drawing.Size(166, 22)
        Me.menu503.Text = "Profil Perusahaan"
        '
        'ExitMenu
        '
        Me.ExitMenu.Image = Global.SPA.My.Resources.Resources.icon_error
        Me.ExitMenu.Name = "ExitMenu"
        Me.ExitMenu.Size = New System.Drawing.Size(68, 20)
        Me.ExitMenu.Text = "Keluar"
        '
        'ToolStrip
        '
        Me.ToolStrip.BackColor = System.Drawing.Color.Gainsboro
        Me.ToolStrip.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(26, 391)
        Me.ToolStrip.TabIndex = 6
        Me.ToolStrip.Text = "ToolStrip"
        '
        'StatusStrip
        '
        Me.StatusStrip.BackColor = System.Drawing.Color.DodgerBlue
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusmessageicon, Me.StatusMessage, Me.ToolProgressBar1})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 391)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(873, 22)
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
        'StatusMessage
        '
        Me.StatusMessage.Margin = New System.Windows.Forms.Padding(5, 3, 0, 2)
        Me.StatusMessage.Name = "StatusMessage"
        Me.StatusMessage.Size = New System.Drawing.Size(645, 17)
        Me.StatusMessage.Spring = True
        Me.StatusMessage.Text = "Please Wait ..."
        Me.StatusMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolProgressBar1
        '
        Me.ToolProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolProgressBar1.Margin = New System.Windows.Forms.Padding(10, 3, 1, 3)
        Me.ToolProgressBar1.Name = "ToolProgressBar1"
        Me.ToolProgressBar1.Size = New System.Drawing.Size(150, 16)
        Me.ToolProgressBar1.Step = 5
        Me.ToolProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ToolProgressBar1.Value = 10
        Me.ToolProgressBar1.Visible = False
        '
        'TimeStat
        '
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusPengguna, Me.ToolStripLabel2})
        Me.ToolStrip1.Location = New System.Drawing.Point(26, 366)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(847, 25)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'StatusPengguna
        '
        Me.StatusPengguna.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StatusPengguna.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusPengguna.Name = "StatusPengguna"
        Me.StatusPengguna.Size = New System.Drawing.Size(39, 22)
        Me.StatusPengguna.Text = "Nama"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(70, 22)
        Me.ToolStripLabel2.Text = "Pengguna : "
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ProgressBar1.ForeColor = System.Drawing.Color.OrangeRed
        Me.ProgressBar1.Location = New System.Drawing.Point(26, 0)
        Me.ProgressBar1.MarqueeAnimationSpeed = 20
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(847, 10)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 11
        Me.ProgressBar1.Value = 10
        Me.ProgressBar1.Visible = False
        '
        'bw
        '
        Me.bw.WorkerReportsProgress = True
        Me.bw.WorkerSupportsCancellation = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(873, 413)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.HelpButton = True
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "MainForm"
        Me.Text = "SPA Aplikasi"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
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
    Friend WithEvents TimeStat As System.Windows.Forms.Timer
    Friend WithEvents ToolProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents menu400 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu502 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu503 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu501 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu102 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu101 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu103 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu104 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu105 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu106 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu201 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu202 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu203 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu204 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu205 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu206 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu301 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu302 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu303 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu304 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu305 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu401 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu402 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu403 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu404 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu405 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu406 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu407 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu408 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu409 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu410 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents StatusPengguna As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents StatusMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents bw As System.ComponentModel.BackgroundWorker

End Class
