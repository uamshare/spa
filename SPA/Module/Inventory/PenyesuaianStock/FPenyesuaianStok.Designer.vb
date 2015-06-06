<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FPenyesuaianStok
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
        Me.txtsum2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtsum1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ButtonH = New System.Windows.Forms.Button()
        Me.ButtonDel = New System.Windows.Forms.Button()
        Me.ButtonAdd = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonPrint = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonSave = New System.Windows.Forms.Button()
        Me.HapusDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.TxtNo = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PanelHeader = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.mmtrg = New System.Windows.Forms.ComboBox()
        Me.tajsmhinf = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolDelete = New System.Windows.Forms.ToolStripButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Tool1 = New System.Windows.Forms.ToolStrip()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PanelFooter = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.PanelHeader.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tool1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.PanelFooter.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtsum2
        '
        Me.txtsum2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsum2.Location = New System.Drawing.Point(692, 33)
        Me.txtsum2.Margin = New System.Windows.Forms.Padding(5)
        Me.txtsum2.MaxLength = 13
        Me.txtsum2.Name = "txtsum2"
        Me.txtsum2.ReadOnly = True
        Me.txtsum2.Size = New System.Drawing.Size(188, 22)
        Me.txtsum2.TabIndex = 35
        Me.txtsum2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(581, 38)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 16)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Nilai HPP"
        '
        'txtsum1
        '
        Me.txtsum1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsum1.Location = New System.Drawing.Point(692, 7)
        Me.txtsum1.Margin = New System.Windows.Forms.Padding(5)
        Me.txtsum1.MaxLength = 13
        Me.txtsum1.Name = "txtsum1"
        Me.txtsum1.ReadOnly = True
        Me.txtsum1.Size = New System.Drawing.Size(188, 22)
        Me.txtsum1.TabIndex = 33
        Me.txtsum1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtsum1.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(581, 12)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 16)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Nilai Pembelian"
        Me.Label5.Visible = False
        '
        'ButtonH
        '
        Me.ButtonH.Location = New System.Drawing.Point(274, 54)
        Me.ButtonH.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonH.Name = "ButtonH"
        Me.ButtonH.Size = New System.Drawing.Size(24, 24)
        Me.ButtonH.TabIndex = 19
        Me.ButtonH.Text = "..."
        Me.ButtonH.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonH.UseVisualStyleBackColor = True
        '
        'ButtonDel
        '
        Me.ButtonDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDel.Location = New System.Drawing.Point(172, 65)
        Me.ButtonDel.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonDel.Name = "ButtonDel"
        Me.ButtonDel.Size = New System.Drawing.Size(76, 31)
        Me.ButtonDel.TabIndex = 7
        Me.ButtonDel.Text = "Hapus"
        Me.ButtonDel.UseVisualStyleBackColor = True
        '
        'ButtonAdd
        '
        Me.ButtonAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdd.Location = New System.Drawing.Point(4, 65)
        Me.ButtonAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonAdd.Name = "ButtonAdd"
        Me.ButtonAdd.Size = New System.Drawing.Size(76, 31)
        Me.ButtonAdd.TabIndex = 5
        Me.ButtonAdd.Text = "Tambah"
        Me.ButtonAdd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 36)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Tanggal"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonPrint
        '
        Me.ButtonPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonPrint.Location = New System.Drawing.Point(256, 65)
        Me.ButtonPrint.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonPrint.Name = "ButtonPrint"
        Me.ButtonPrint.Size = New System.Drawing.Size(76, 31)
        Me.ButtonPrint.TabIndex = 8
        Me.ButtonPrint.Text = "Cetak"
        Me.ButtonPrint.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(803, 65)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(76, 31)
        Me.ButtonCancel.TabIndex = 8
        Me.ButtonCancel.Text = "Batal"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonSave
        '
        Me.ButtonSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSave.Location = New System.Drawing.Point(88, 65)
        Me.ButtonSave.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(76, 31)
        Me.ButtonSave.TabIndex = 6
        Me.ButtonSave.Text = "Simpan"
        Me.ButtonSave.UseVisualStyleBackColor = True
        '
        'HapusDataToolStripMenuItem
        '
        Me.HapusDataToolStripMenuItem.Name = "HapusDataToolStripMenuItem"
        Me.HapusDataToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.HapusDataToolStripMenuItem.Text = "Hapus Data"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(130, 32)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(167, 22)
        Me.DateTimePicker1.TabIndex = 1
        '
        'TxtNo
        '
        Me.TxtNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNo.Location = New System.Drawing.Point(130, 55)
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
        Me.lblName.Location = New System.Drawing.Point(5, 59)
        Me.lblName.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(116, 16)
        Me.lblName.TabIndex = 10
        Me.lblName.Text = "No Penyeseuaian"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HapusDataToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(136, 26)
        '
        'PanelHeader
        '
        Me.PanelHeader.BackColor = System.Drawing.Color.LightGray
        Me.PanelHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelHeader.Controls.Add(Me.Label3)
        Me.PanelHeader.Controls.Add(Me.mmtrg)
        Me.PanelHeader.Controls.Add(Me.tajsmhinf)
        Me.PanelHeader.Controls.Add(Me.Label2)
        Me.PanelHeader.Controls.Add(Me.ButtonH)
        Me.PanelHeader.Controls.Add(Me.Label1)
        Me.PanelHeader.Controls.Add(Me.DateTimePicker1)
        Me.PanelHeader.Controls.Add(Me.TxtNo)
        Me.PanelHeader.Controls.Add(Me.lblName)
        Me.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelHeader.Location = New System.Drawing.Point(0, 0)
        Me.PanelHeader.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelHeader.Name = "PanelHeader"
        Me.PanelHeader.Size = New System.Drawing.Size(904, 86)
        Me.PanelHeader.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 12)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 16)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Grup"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mmtrg
        '
        Me.mmtrg.FormattingEnabled = True
        Me.mmtrg.Items.AddRange(New Object() {"Bibit Tanaman", "Bibit Tanaman dalam Proses", "Data Tanaman"})
        Me.mmtrg.Location = New System.Drawing.Point(130, 7)
        Me.mmtrg.Name = "mmtrg"
        Me.mmtrg.Size = New System.Drawing.Size(202, 24)
        Me.mmtrg.TabIndex = 1
        '
        'tajsmhinf
        '
        Me.tajsmhinf.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tajsmhinf.Location = New System.Drawing.Point(516, 33)
        Me.tajsmhinf.Margin = New System.Windows.Forms.Padding(5)
        Me.tajsmhinf.MaxLength = 254
        Me.tajsmhinf.Multiline = True
        Me.tajsmhinf.Name = "tajsmhinf"
        Me.tajsmhinf.Size = New System.Drawing.Size(363, 44)
        Me.tajsmhinf.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(514, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 16)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Keterangan"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.Silver
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(28, 65)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(766, 148)
        Me.DataGridView1.TabIndex = 4
        '
        'Tool1
        '
        Me.Tool1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Tool1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Tool1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolDelete})
        Me.Tool1.Location = New System.Drawing.Point(0, 0)
        Me.Tool1.Name = "Tool1"
        Me.Tool1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Tool1.Size = New System.Drawing.Size(904, 31)
        Me.Tool1.TabIndex = 24
        Me.Tool1.Text = "Tool1"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Controls.Add(Me.Tool1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 86)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(904, 231)
        Me.Panel2.TabIndex = 23
        '
        'PanelFooter
        '
        Me.PanelFooter.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.PanelFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelFooter.Controls.Add(Me.txtsum2)
        Me.PanelFooter.Controls.Add(Me.Label6)
        Me.PanelFooter.Controls.Add(Me.txtsum1)
        Me.PanelFooter.Controls.Add(Me.Label5)
        Me.PanelFooter.Controls.Add(Me.ButtonPrint)
        Me.PanelFooter.Controls.Add(Me.ButtonDel)
        Me.PanelFooter.Controls.Add(Me.ButtonAdd)
        Me.PanelFooter.Controls.Add(Me.ButtonCancel)
        Me.PanelFooter.Controls.Add(Me.ButtonSave)
        Me.PanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelFooter.Location = New System.Drawing.Point(0, 317)
        Me.PanelFooter.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelFooter.Name = "PanelFooter"
        Me.PanelFooter.Size = New System.Drawing.Size(904, 104)
        Me.PanelFooter.TabIndex = 11
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
        Me.Panel1.Size = New System.Drawing.Size(904, 421)
        Me.Panel1.TabIndex = 9
        '
        'FPenyesuaianStok
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(905, 421)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FPenyesuaianStok"
        Me.Text = "FPenyesuaianStok"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.PanelHeader.ResumeLayout(False)
        Me.PanelHeader.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tool1.ResumeLayout(False)
        Me.Tool1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PanelFooter.ResumeLayout(False)
        Me.PanelFooter.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtsum2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtsum1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ButtonH As System.Windows.Forms.Button
    Friend WithEvents ButtonDel As System.Windows.Forms.Button
    Friend WithEvents ButtonAdd As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonPrint As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonSave As System.Windows.Forms.Button
    Friend WithEvents HapusDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtNo As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PanelHeader As System.Windows.Forms.Panel
    Friend WithEvents ToolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Tool1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PanelFooter As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tajsmhinf As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents mmtrg As System.Windows.Forms.ComboBox
End Class
