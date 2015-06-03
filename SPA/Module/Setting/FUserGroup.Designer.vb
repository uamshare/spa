<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FUserGroup
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.cmbperpage = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolFisrt = New System.Windows.Forms.ToolStripButton()
        Me.ToolPrev = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtPageCurrent = New System.Windows.Forms.ToolStripTextBox()
        Me.lCountPage = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolNext = New System.Windows.Forms.ToolStripButton()
        Me.ToolLast = New System.Windows.Forms.ToolStripButton()
        Me.lpageinfo = New System.Windows.Forms.ToolStripLabel()
        Me.Tool1 = New System.Windows.Forms.ToolStrip()
        Me.ToolAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolMenuAkses = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolFind = New System.Windows.Forms.ToolStripButton()
        Me.ToolTextFind = New System.Windows.Forms.ToolStripTextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolSaveMenuAkses = New System.Windows.Forms.ToolStripButton()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Tool1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(730, 468)
        Me.Panel1.TabIndex = 7
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(28, 80)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(473, 205)
        Me.DataGridView1.TabIndex = 20
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.cmbperpage, Me.ToolStripLabel1, Me.ToolStripSeparator3, Me.ToolFisrt, Me.ToolPrev, Me.ToolStripSeparator1, Me.txtPageCurrent, Me.lCountPage, Me.ToolStripSeparator2, Me.ToolNext, Me.ToolLast, Me.lpageinfo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 443)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(730, 25)
        Me.ToolStrip1.TabIndex = 19
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripLabel2.Text = "Show"
        '
        'cmbperpage
        '
        Me.cmbperpage.Items.AddRange(New Object() {"5", "10", "15", "20", "25", "50", "75", "100", "All"})
        Me.cmbperpage.Name = "cmbperpage"
        Me.cmbperpage.Size = New System.Drawing.Size(99, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(53, 22)
        Me.ToolStripLabel1.Text = "per page"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'ToolPrev
        '
        Me.ToolPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolPrev.Image = Global.SPA.My.Resources.Resources.resultset_previous
        Me.ToolPrev.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolPrev.Name = "ToolPrev"
        Me.ToolPrev.Size = New System.Drawing.Size(23, 22)
        Me.ToolPrev.Text = "Previous"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'txtPageCurrent
        '
        Me.txtPageCurrent.Name = "txtPageCurrent"
        Me.txtPageCurrent.Size = New System.Drawing.Size(65, 25)
        Me.txtPageCurrent.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lCountPage
        '
        Me.lCountPage.Name = "lCountPage"
        Me.lCountPage.Size = New System.Drawing.Size(35, 22)
        Me.lCountPage.Text = "of {0}"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'ToolLast
        '
        Me.ToolLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolLast.Image = Global.SPA.My.Resources.Resources.resultset_last
        Me.ToolLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolLast.Name = "ToolLast"
        Me.ToolLast.Size = New System.Drawing.Size(23, 22)
        Me.ToolLast.Text = "Last"
        '
        'lpageinfo
        '
        Me.lpageinfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lpageinfo.Name = "lpageinfo"
        Me.lpageinfo.Size = New System.Drawing.Size(102, 22)
        Me.lpageinfo.Text = "1 - 20 as 100 Rows"
        '
        'Tool1
        '
        Me.Tool1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Tool1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Tool1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolAdd, Me.ToolEdit, Me.ToolDelete, Me.ToolPrint, Me.ToolStripSeparator4, Me.ToolMenuAkses, Me.ToolStripSeparator5, Me.ToolRefresh, Me.ToolFind, Me.ToolTextFind})
        Me.Tool1.Location = New System.Drawing.Point(0, 0)
        Me.Tool1.Name = "Tool1"
        Me.Tool1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Tool1.Size = New System.Drawing.Size(730, 31)
        Me.Tool1.TabIndex = 9
        Me.Tool1.Text = "Tool1"
        '
        'ToolAdd
        '
        Me.ToolAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolAdd.Image = Global.SPA.My.Resources.Resources.add3
        Me.ToolAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolAdd.Name = "ToolAdd"
        Me.ToolAdd.Size = New System.Drawing.Size(28, 28)
        Me.ToolAdd.Text = "Add"
        '
        'ToolEdit
        '
        Me.ToolEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolEdit.Image = Global.SPA.My.Resources.Resources.edit2
        Me.ToolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolEdit.Name = "ToolEdit"
        Me.ToolEdit.Size = New System.Drawing.Size(28, 28)
        Me.ToolEdit.Text = "Edit"
        '
        'ToolDelete
        '
        Me.ToolDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolDelete.Image = Global.SPA.My.Resources.Resources.delete1
        Me.ToolDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolDelete.Name = "ToolDelete"
        Me.ToolDelete.Size = New System.Drawing.Size(28, 28)
        Me.ToolDelete.Text = "Del"
        '
        'ToolPrint
        '
        Me.ToolPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolPrint.Image = Global.SPA.My.Resources.Resources.printer
        Me.ToolPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolPrint.Name = "ToolPrint"
        Me.ToolPrint.Size = New System.Drawing.Size(28, 28)
        Me.ToolPrint.Text = "Print"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'ToolMenuAkses
        '
        Me.ToolMenuAkses.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolMenuAkses.Image = Global.SPA.My.Resources.Resources.database
        Me.ToolMenuAkses.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolMenuAkses.Name = "ToolMenuAkses"
        Me.ToolMenuAkses.Size = New System.Drawing.Size(28, 28)
        Me.ToolMenuAkses.Text = "ToolStripButton3"
        Me.ToolMenuAkses.ToolTipText = "Menu Akses"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'ToolRefresh
        '
        Me.ToolRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolRefresh.Image = Global.SPA.My.Resources.Resources.refresh2
        Me.ToolRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolRefresh.Name = "ToolRefresh"
        Me.ToolRefresh.Size = New System.Drawing.Size(28, 28)
        Me.ToolRefresh.Text = "Refresh"
        '
        'ToolFind
        '
        Me.ToolFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolFind.Image = Global.SPA.My.Resources.Resources.find2
        Me.ToolFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolFind.Name = "ToolFind"
        Me.ToolFind.Size = New System.Drawing.Size(28, 28)
        Me.ToolFind.Text = "Find"
        '
        'ToolTextFind
        '
        Me.ToolTextFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolTextFind.Name = "ToolTextFind"
        Me.ToolTextFind.Size = New System.Drawing.Size(332, 31)
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(730, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(47, 468)
        Me.Panel2.TabIndex = 9
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TreeView1)
        Me.Panel3.Controls.Add(Me.ToolStrip2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(777, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(577, 468)
        Me.Panel3.TabIndex = 10
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Location = New System.Drawing.Point(0, 31)
        Me.TreeView1.Margin = New System.Windows.Forms.Padding(4)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(577, 437)
        Me.TreeView1.TabIndex = 12
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel3, Me.ToolStripButton1, Me.ToolSaveMenuAkses})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip2.Size = New System.Drawing.Size(577, 31)
        Me.ToolStrip2.TabIndex = 11
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(71, 28)
        Me.ToolStripLabel3.Text = "Menu Akses"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.SPA.My.Resources.Resources.refresh2
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ToolSaveMenuAkses
        '
        Me.ToolSaveMenuAkses.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolSaveMenuAkses.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolSaveMenuAkses.Image = Global.SPA.My.Resources.Resources.saveall
        Me.ToolSaveMenuAkses.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolSaveMenuAkses.Name = "ToolSaveMenuAkses"
        Me.ToolSaveMenuAkses.Size = New System.Drawing.Size(28, 28)
        Me.ToolSaveMenuAkses.Text = "ToolSaveMenuAkses"
        Me.ToolSaveMenuAkses.ToolTipText = "Simpan Akses Menu"
        '
        'FUserGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1354, 468)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FUserGroup"
        Me.ShowInTaskbar = False
        Me.Text = "Grup Akses"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Tool1.ResumeLayout(False)
        Me.Tool1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Tool1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolFind As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolTextFind As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolFisrt As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbperpage As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtPageCurrent As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents lCountPage As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lpageinfo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ToolRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSaveMenuAkses As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolMenuAkses As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator

End Class
