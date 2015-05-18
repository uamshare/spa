<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FListTanamanMasuk
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FListTanamanMasuk))
        Me.ToolCheck = New System.Windows.Forms.ToolStripButton()
        Me.ToolFind = New System.Windows.Forms.ToolStripButton()
        Me.ToolRefresh = New System.Windows.Forms.ToolStripButton()
        Me.Tool1 = New System.Windows.Forms.ToolStrip()
        Me.ToolTextFind = New System.Windows.Forms.ToolStripTextBox()
        Me.lpageinfo = New System.Windows.Forms.ToolStripLabel()
        Me.ToolLast = New System.Windows.Forms.ToolStripButton()
        Me.ToolNext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lCountPage = New System.Windows.Forms.ToolStripLabel()
        Me.txtPageCurrent = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolPrev = New System.Windows.Forms.ToolStripButton()
        Me.ToolFisrt = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.cmbperpage = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Tool1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolCheck
        '
        Me.ToolCheck.Image = Global.SPA.My.Resources.Resources.check
        Me.ToolCheck.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolCheck.Name = "ToolCheck"
        Me.ToolCheck.Size = New System.Drawing.Size(93, 36)
        Me.ToolCheck.Text = "Pilih Data"
        Me.ToolCheck.ToolTipText = "Pilih Data"
        '
        'ToolFind
        '
        Me.ToolFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolFind.Image = CType(resources.GetObject("ToolFind.Image"), System.Drawing.Image)
        Me.ToolFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolFind.Name = "ToolFind"
        Me.ToolFind.Size = New System.Drawing.Size(36, 36)
        Me.ToolFind.Text = "Find"
        '
        'ToolRefresh
        '
        Me.ToolRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolRefresh.Image = Global.SPA.My.Resources.Resources.refresh1
        Me.ToolRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolRefresh.Name = "ToolRefresh"
        Me.ToolRefresh.Size = New System.Drawing.Size(36, 36)
        Me.ToolRefresh.Text = "Refresh"
        '
        'Tool1
        '
        Me.Tool1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Tool1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Tool1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Tool1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolRefresh, Me.ToolFind, Me.ToolTextFind, Me.ToolCheck})
        Me.Tool1.Location = New System.Drawing.Point(0, 0)
        Me.Tool1.Name = "Tool1"
        Me.Tool1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Tool1.Size = New System.Drawing.Size(840, 39)
        Me.Tool1.TabIndex = 9
        Me.Tool1.Text = "Tool1"
        '
        'ToolTextFind
        '
        Me.ToolTextFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolTextFind.Name = "ToolTextFind"
        Me.ToolTextFind.Size = New System.Drawing.Size(250, 39)
        '
        'lpageinfo
        '
        Me.lpageinfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lpageinfo.Name = "lpageinfo"
        Me.lpageinfo.Size = New System.Drawing.Size(102, 22)
        Me.lpageinfo.Text = "1 - 20 as 100 Rows"
        '
        'ToolLast
        '
        Me.ToolLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolLast.Image = Global.SPA.My.Resources.Resources.resultset_last
        Me.ToolLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolLast.Name = "ToolLast"
        Me.ToolLast.Size = New System.Drawing.Size(23, 22)
        Me.ToolLast.Text = "Last"
        '
        'ToolNext
        '
        Me.ToolNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolNext.Image = Global.SPA.My.Resources.Resources.resultset_next
        Me.ToolNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolNext.Name = "ToolNext"
        Me.ToolNext.Size = New System.Drawing.Size(23, 22)
        Me.ToolNext.Text = "Next"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'lCountPage
        '
        Me.lCountPage.Name = "lCountPage"
        Me.lCountPage.Size = New System.Drawing.Size(35, 22)
        Me.lCountPage.Text = "of {0}"
        '
        'txtPageCurrent
        '
        Me.txtPageCurrent.Name = "txtPageCurrent"
        Me.txtPageCurrent.Size = New System.Drawing.Size(50, 25)
        Me.txtPageCurrent.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ToolPrev
        '
        Me.ToolPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolPrev.Image = Global.SPA.My.Resources.Resources.resultset_previous
        Me.ToolPrev.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolPrev.Name = "ToolPrev"
        Me.ToolPrev.Size = New System.Drawing.Size(23, 22)
        Me.ToolPrev.Text = "Previous"
        '
        'ToolFisrt
        '
        Me.ToolFisrt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolFisrt.Image = Global.SPA.My.Resources.Resources.resultset_first
        Me.ToolFisrt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolFisrt.Name = "ToolFisrt"
        Me.ToolFisrt.Size = New System.Drawing.Size(23, 22)
        Me.ToolFisrt.Text = "First"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(53, 22)
        Me.ToolStripLabel1.Text = "per page"
        '
        'cmbperpage
        '
        Me.cmbperpage.Items.AddRange(New Object() {"5", "10", "15", "20", "25", "50", "75", "100", "All"})
        Me.cmbperpage.Name = "cmbperpage"
        Me.cmbperpage.Size = New System.Drawing.Size(75, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripLabel2.Text = "Show"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Cursor = System.Windows.Forms.Cursors.Default
        Me.DataGridView1.Location = New System.Drawing.Point(4, 50)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(821, 399)
        Me.DataGridView1.TabIndex = 20
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.cmbperpage, Me.ToolStripLabel1, Me.ToolStripSeparator3, Me.ToolFisrt, Me.ToolPrev, Me.ToolStripSeparator1, Me.txtPageCurrent, Me.lCountPage, Me.ToolStripSeparator2, Me.ToolNext, Me.ToolLast, Me.lpageinfo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 463)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(840, 25)
        Me.ToolStrip1.TabIndex = 19
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Controls.Add(Me.Tool1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(840, 488)
        Me.Panel1.TabIndex = 9
        '
        'FListTanamanMasuk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(841, 488)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FListTanamanMasuk"
        Me.ShowInTaskbar = False
        Me.Text = "FListTanamanMasuk"
        Me.Tool1.ResumeLayout(False)
        Me.Tool1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolCheck As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolFind As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tool1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolTextFind As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents lpageinfo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lCountPage As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtPageCurrent As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolFisrt As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmbperpage As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
