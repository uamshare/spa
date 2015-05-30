<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FJurnalMemo
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Tool1 = New System.Windows.Forms.ToolStrip()
        Me.ToolDelete = New System.Windows.Forms.ToolStripButton()
        Me.PanelHeader = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ButtonH = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.TxtNo = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.PanelFooter = New System.Windows.Forms.Panel()
        Me.txtsumdebet = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtsumcredit = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ButtonPrint = New System.Windows.Forms.Button()
        Me.ButtonDel = New System.Windows.Forms.Button()
        Me.ButtonAdd = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonSave = New System.Windows.Forms.Button()
        Me.HapusDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BonusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Tool1.SuspendLayout()
        Me.PanelHeader.SuspendLayout()
        Me.PanelFooter.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.Silver
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(16, 52)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(836, 134)
        Me.DataGridView1.StandardTab = True
        Me.DataGridView1.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.PanelHeader)
        Me.Panel1.Controls.Add(Me.PanelFooter)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(864, 400)
        Me.Panel1.TabIndex = 10
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Controls.Add(Me.Tool1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 87)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(864, 208)
        Me.Panel2.TabIndex = 7
        '
        'Tool1
        '
        Me.Tool1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Tool1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Tool1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Tool1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolDelete})
        Me.Tool1.Location = New System.Drawing.Point(0, 0)
        Me.Tool1.Name = "Tool1"
        Me.Tool1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Tool1.Size = New System.Drawing.Size(864, 39)
        Me.Tool1.TabIndex = 24
        Me.Tool1.Text = "Tool1"
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
        'PanelHeader
        '
        Me.PanelHeader.BackColor = System.Drawing.Color.LightGray
        Me.PanelHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelHeader.Controls.Add(Me.Label7)
        Me.PanelHeader.Controls.Add(Me.TextBox1)
        Me.PanelHeader.Controls.Add(Me.ButtonH)
        Me.PanelHeader.Controls.Add(Me.Label1)
        Me.PanelHeader.Controls.Add(Me.DateTimePicker1)
        Me.PanelHeader.Controls.Add(Me.TxtNo)
        Me.PanelHeader.Controls.Add(Me.lblName)
        Me.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelHeader.Location = New System.Drawing.Point(0, 0)
        Me.PanelHeader.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelHeader.Name = "PanelHeader"
        Me.PanelHeader.Size = New System.Drawing.Size(864, 87)
        Me.PanelHeader.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(324, 11)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 16)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Keterangan"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(327, 32)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBox1.MaxLength = 255
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(524, 49)
        Me.TextBox1.TabIndex = 39
        '
        'ButtonH
        '
        Me.ButtonH.Location = New System.Drawing.Point(236, 33)
        Me.ButtonH.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonH.Name = "ButtonH"
        Me.ButtonH.Size = New System.Drawing.Size(24, 24)
        Me.ButtonH.TabIndex = 2
        Me.ButtonH.Text = "..."
        Me.ButtonH.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonH.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Tanggal"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(93, 11)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(167, 22)
        Me.DateTimePicker1.TabIndex = 1
        '
        'TxtNo
        '
        Me.TxtNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNo.Location = New System.Drawing.Point(93, 34)
        Me.TxtNo.Margin = New System.Windows.Forms.Padding(5)
        Me.TxtNo.MaxLength = 13
        Me.TxtNo.Name = "TxtNo"
        Me.TxtNo.Size = New System.Drawing.Size(145, 22)
        Me.TxtNo.TabIndex = 2
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(5, 38)
        Me.lblName.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(65, 16)
        Me.lblName.TabIndex = 10
        Me.lblName.Text = "No Jurnal"
        '
        'PanelFooter
        '
        Me.PanelFooter.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.PanelFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelFooter.Controls.Add(Me.txtsumdebet)
        Me.PanelFooter.Controls.Add(Me.Label8)
        Me.PanelFooter.Controls.Add(Me.txtsumcredit)
        Me.PanelFooter.Controls.Add(Me.Label6)
        Me.PanelFooter.Controls.Add(Me.ButtonPrint)
        Me.PanelFooter.Controls.Add(Me.ButtonDel)
        Me.PanelFooter.Controls.Add(Me.ButtonAdd)
        Me.PanelFooter.Controls.Add(Me.ButtonCancel)
        Me.PanelFooter.Controls.Add(Me.ButtonSave)
        Me.PanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelFooter.Location = New System.Drawing.Point(0, 295)
        Me.PanelFooter.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelFooter.Name = "PanelFooter"
        Me.PanelFooter.Size = New System.Drawing.Size(864, 105)
        Me.PanelFooter.TabIndex = 11
        '
        'txtsumdebet
        '
        Me.txtsumdebet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsumdebet.Location = New System.Drawing.Point(662, 8)
        Me.txtsumdebet.Margin = New System.Windows.Forms.Padding(5)
        Me.txtsumdebet.MaxLength = 13
        Me.txtsumdebet.Name = "txtsumdebet"
        Me.txtsumdebet.ReadOnly = True
        Me.txtsumdebet.Size = New System.Drawing.Size(188, 22)
        Me.txtsumdebet.TabIndex = 53
        Me.txtsumdebet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(570, 11)
        Me.Label8.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 16)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "Nilai Debet"
        '
        'txtsumcredit
        '
        Me.txtsumcredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsumcredit.Location = New System.Drawing.Point(662, 31)
        Me.txtsumcredit.Margin = New System.Windows.Forms.Padding(5)
        Me.txtsumcredit.MaxLength = 13
        Me.txtsumcredit.Name = "txtsumcredit"
        Me.txtsumcredit.ReadOnly = True
        Me.txtsumcredit.Size = New System.Drawing.Size(188, 22)
        Me.txtsumcredit.TabIndex = 35
        Me.txtsumcredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(570, 37)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Nilai Kredit"
        '
        'ButtonPrint
        '
        Me.ButtonPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonPrint.Location = New System.Drawing.Point(267, 65)
        Me.ButtonPrint.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonPrint.Name = "ButtonPrint"
        Me.ButtonPrint.Size = New System.Drawing.Size(77, 31)
        Me.ButtonPrint.TabIndex = 14
        Me.ButtonPrint.Text = "Cetak"
        Me.ButtonPrint.UseVisualStyleBackColor = True
        '
        'ButtonDel
        '
        Me.ButtonDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDel.Location = New System.Drawing.Point(182, 65)
        Me.ButtonDel.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonDel.Name = "ButtonDel"
        Me.ButtonDel.Size = New System.Drawing.Size(77, 31)
        Me.ButtonDel.TabIndex = 13
        Me.ButtonDel.Text = "Hapus"
        Me.ButtonDel.UseVisualStyleBackColor = True
        '
        'ButtonAdd
        '
        Me.ButtonAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdd.Location = New System.Drawing.Point(16, 63)
        Me.ButtonAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonAdd.Name = "ButtonAdd"
        Me.ButtonAdd.Size = New System.Drawing.Size(77, 31)
        Me.ButtonAdd.TabIndex = 1
        Me.ButtonAdd.Text = "Tambah"
        Me.ButtonAdd.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(774, 65)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(77, 31)
        Me.ButtonCancel.TabIndex = 15
        Me.ButtonCancel.Text = "Batal"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonSave
        '
        Me.ButtonSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSave.Location = New System.Drawing.Point(97, 64)
        Me.ButtonSave.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(77, 31)
        Me.ButtonSave.TabIndex = 12
        Me.ButtonSave.Text = "Simpan"
        Me.ButtonSave.UseVisualStyleBackColor = True
        '
        'HapusDataToolStripMenuItem
        '
        Me.HapusDataToolStripMenuItem.Name = "HapusDataToolStripMenuItem"
        Me.HapusDataToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.HapusDataToolStripMenuItem.Text = "Hapus Data"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BonusToolStripMenuItem, Me.ToolStripSeparator1, Me.HapusDataToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(136, 54)
        '
        'BonusToolStripMenuItem
        '
        Me.BonusToolStripMenuItem.Name = "BonusToolStripMenuItem"
        Me.BonusToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.BonusToolStripMenuItem.Text = "Bonus"
        Me.BonusToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(132, 6)
        Me.ToolStripSeparator1.Visible = False
        '
        'FJurnalMemo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(866, 400)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FJurnalMemo"
        Me.ShowInTaskbar = False
        Me.Text = "Jurnal Memorial"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Tool1.ResumeLayout(False)
        Me.Tool1.PerformLayout()
        Me.PanelHeader.ResumeLayout(False)
        Me.PanelHeader.PerformLayout()
        Me.PanelFooter.ResumeLayout(False)
        Me.PanelFooter.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Tool1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelHeader As System.Windows.Forms.Panel
    Friend WithEvents ButtonH As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtNo As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents PanelFooter As System.Windows.Forms.Panel
    Friend WithEvents txtsumcredit As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ButtonPrint As System.Windows.Forms.Button
    Friend WithEvents ButtonDel As System.Windows.Forms.Button
    Friend WithEvents ButtonAdd As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonSave As System.Windows.Forms.Button
    Friend WithEvents HapusDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BonusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtsumdebet As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
