<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FAkunPosting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FAkunPosting))
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabelbarang = New System.Windows.Forms.ToolStripLabel()
        Me.cmbperPage = New System.Windows.Forms.ToolStripComboBox()
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
        Me.lpageInfo = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.Toolbarang = New System.Windows.Forms.ToolStrip()
        Me.ToolAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolDelete = New System.Windows.Forms.ToolStripButton()
        Me.TollPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolFind = New System.Windows.Forms.ToolStripButton()
        Me.ToolTextFind = New System.Windows.Forms.ToolStripTextBox()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.Panelbarang = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1.SuspendLayout()
        Me.Toolbarang.SuspendLayout()
        Me.Panelbarang.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabelbarang, Me.cmbperPage, Me.ToolStripLabel1, Me.ToolStripSeparator3, Me.ToolFisrt, Me.ToolPrev, Me.ToolStripSeparator1, Me.txtPageCurrent, Me.lCountPage, Me.ToolStripSeparator2, Me.ToolNext, Me.ToolLast, Me.lpageInfo, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 352)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(692, 25)
        Me.ToolStrip1.TabIndex = 19
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabelbarang
        '
        Me.ToolStripLabelbarang.Name = "ToolStripLabelbarang"
        Me.ToolStripLabelbarang.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripLabelbarang.Text = "Show"
        '
        'cmbperPage
        '
        Me.cmbperPage.Items.AddRange(New Object() {"5", "10", "15", "20", "25", "50", "75", "100", "All"})
        Me.cmbperPage.Name = "cmbperPage"
        Me.cmbperPage.Size = New System.Drawing.Size(75, 25)
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
        Me.txtPageCurrent.Size = New System.Drawing.Size(50, 25)
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
        'lpageInfo
        '
        Me.lpageInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lpageInfo.Name = "lpageInfo"
        Me.lpageInfo.Size = New System.Drawing.Size(102, 22)
        Me.lpageInfo.Text = "1 - 20 as 100 Rows"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'Toolbarang
        '
        Me.Toolbarang.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Toolbarang.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Toolbarang.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Toolbarang.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolAdd, Me.ToolEdit, Me.ToolDelete, Me.TollPrint, Me.ToolRefresh, Me.ToolFind, Me.ToolTextFind})
        Me.Toolbarang.Location = New System.Drawing.Point(0, 0)
        Me.Toolbarang.Name = "Toolbarang"
        Me.Toolbarang.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Toolbarang.Size = New System.Drawing.Size(692, 39)
        Me.Toolbarang.TabIndex = 9
        Me.Toolbarang.Text = "Tool1"
        '
        'ToolAdd
        '
        Me.ToolAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolAdd.Image = Global.SPA.My.Resources.Resources.add1
        Me.ToolAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolAdd.Name = "ToolAdd"
        Me.ToolAdd.Size = New System.Drawing.Size(36, 36)
        Me.ToolAdd.Text = "Add"
        Me.ToolAdd.Visible = False
        '
        'ToolEdit
        '
        Me.ToolEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolEdit.Image = Global.SPA.My.Resources.Resources.edit1
        Me.ToolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolEdit.Name = "ToolEdit"
        Me.ToolEdit.Size = New System.Drawing.Size(36, 36)
        Me.ToolEdit.Text = "Edit"
        '
        'ToolDelete
        '
        Me.ToolDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolDelete.Image = Global.SPA.My.Resources.Resources.trush
        Me.ToolDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolDelete.Name = "ToolDelete"
        Me.ToolDelete.Size = New System.Drawing.Size(36, 36)
        Me.ToolDelete.Text = "Del"
        '
        'TollPrint
        '
        Me.TollPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TollPrint.Image = Global.SPA.My.Resources.Resources.print2
        Me.TollPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TollPrint.Name = "TollPrint"
        Me.TollPrint.Size = New System.Drawing.Size(36, 36)
        Me.TollPrint.Text = "ToolStripButton2"
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
        'ToolTextFind
        '
        Me.ToolTextFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolTextFind.Name = "ToolTextFind"
        Me.ToolTextFind.Size = New System.Drawing.Size(250, 39)
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'Panelbarang
        '
        Me.Panelbarang.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panelbarang.Controls.Add(Me.DataGridView1)
        Me.Panelbarang.Controls.Add(Me.ToolStrip1)
        Me.Panelbarang.Controls.Add(Me.Toolbarang)
        Me.Panelbarang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panelbarang.Location = New System.Drawing.Point(0, 0)
        Me.Panelbarang.Margin = New System.Windows.Forms.Padding(4)
        Me.Panelbarang.Name = "Panelbarang"
        Me.Panelbarang.Size = New System.Drawing.Size(692, 377)
        Me.Panelbarang.TabIndex = 14
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(0, 47)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(691, 297)
        Me.DataGridView1.TabIndex = 20
        '
        'FAkunPosting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 377)
        Me.Controls.Add(Me.Panelbarang)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FAkunPosting"
        Me.ShowInTaskbar = False
        Me.Text = "Akun Posting Otomatis"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Toolbarang.ResumeLayout(False)
        Me.Toolbarang.PerformLayout()
        Me.Panelbarang.ResumeLayout(False)
        Me.Panelbarang.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabelbarang As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmbperPage As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolFisrt As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtPageCurrent As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents lCountPage As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents lpageInfo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Toolbarang As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents TollPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolFind As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolTextFind As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents Panelbarang As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
