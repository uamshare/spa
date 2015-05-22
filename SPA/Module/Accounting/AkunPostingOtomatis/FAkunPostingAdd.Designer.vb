<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FAkunPostingAdd
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtKode = New System.Windows.Forms.TextBox()
        Me.txtNama = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbKredit4 = New System.Windows.Forms.ComboBox()
        Me.cmbDebit4 = New System.Windows.Forms.ComboBox()
        Me.cmbKredit3 = New System.Windows.Forms.ComboBox()
        Me.cmbDebit3 = New System.Windows.Forms.ComboBox()
        Me.cmbKredit2 = New System.Windows.Forms.ComboBox()
        Me.cmbDebit2 = New System.Windows.Forms.ComboBox()
        Me.cmbKredit1 = New System.Windows.Forms.ComboBox()
        Me.cmbDebit1 = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.btnBatal = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.statmsg = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtMapoID = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Kode Transaksi"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nama transaksi"
        '
        'txtKode
        '
        Me.txtKode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKode.Location = New System.Drawing.Point(139, 13)
        Me.txtKode.MaxLength = 4
        Me.txtKode.Name = "txtKode"
        Me.txtKode.Size = New System.Drawing.Size(87, 22)
        Me.txtKode.TabIndex = 2
        '
        'txtNama
        '
        Me.txtNama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNama.Location = New System.Drawing.Point(139, 40)
        Me.txtNama.MaxLength = 100
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(350, 22)
        Me.txtNama.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbKredit4)
        Me.GroupBox1.Controls.Add(Me.cmbDebit4)
        Me.GroupBox1.Controls.Add(Me.cmbKredit3)
        Me.GroupBox1.Controls.Add(Me.cmbDebit3)
        Me.GroupBox1.Controls.Add(Me.cmbKredit2)
        Me.GroupBox1.Controls.Add(Me.cmbDebit2)
        Me.GroupBox1.Controls.Add(Me.cmbKredit1)
        Me.GroupBox1.Controls.Add(Me.cmbDebit1)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(473, 184)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pengaturan Akun Otomatis"
        '
        'cmbKredit4
        '
        Me.cmbKredit4.FormattingEnabled = True
        Me.cmbKredit4.Location = New System.Drawing.Point(339, 127)
        Me.cmbKredit4.MaxLength = 6
        Me.cmbKredit4.Name = "cmbKredit4"
        Me.cmbKredit4.Size = New System.Drawing.Size(121, 24)
        Me.cmbKredit4.TabIndex = 15
        '
        'cmbDebit4
        '
        Me.cmbDebit4.FormattingEnabled = True
        Me.cmbDebit4.Location = New System.Drawing.Point(339, 99)
        Me.cmbDebit4.MaxLength = 6
        Me.cmbDebit4.Name = "cmbDebit4"
        Me.cmbDebit4.Size = New System.Drawing.Size(121, 24)
        Me.cmbDebit4.TabIndex = 14
        '
        'cmbKredit3
        '
        Me.cmbKredit3.FormattingEnabled = True
        Me.cmbKredit3.Location = New System.Drawing.Point(339, 63)
        Me.cmbKredit3.MaxLength = 6
        Me.cmbKredit3.Name = "cmbKredit3"
        Me.cmbKredit3.Size = New System.Drawing.Size(121, 24)
        Me.cmbKredit3.TabIndex = 13
        '
        'cmbDebit3
        '
        Me.cmbDebit3.FormattingEnabled = True
        Me.cmbDebit3.Location = New System.Drawing.Point(339, 31)
        Me.cmbDebit3.MaxLength = 6
        Me.cmbDebit3.Name = "cmbDebit3"
        Me.cmbDebit3.Size = New System.Drawing.Size(121, 24)
        Me.cmbDebit3.TabIndex = 12
        '
        'cmbKredit2
        '
        Me.cmbKredit2.FormattingEnabled = True
        Me.cmbKredit2.Location = New System.Drawing.Point(104, 129)
        Me.cmbKredit2.MaxLength = 6
        Me.cmbKredit2.Name = "cmbKredit2"
        Me.cmbKredit2.Size = New System.Drawing.Size(121, 24)
        Me.cmbKredit2.TabIndex = 11
        '
        'cmbDebit2
        '
        Me.cmbDebit2.FormattingEnabled = True
        Me.cmbDebit2.Location = New System.Drawing.Point(104, 99)
        Me.cmbDebit2.MaxLength = 6
        Me.cmbDebit2.Name = "cmbDebit2"
        Me.cmbDebit2.Size = New System.Drawing.Size(121, 24)
        Me.cmbDebit2.TabIndex = 10
        '
        'cmbKredit1
        '
        Me.cmbKredit1.FormattingEnabled = True
        Me.cmbKredit1.Location = New System.Drawing.Point(104, 63)
        Me.cmbKredit1.MaxLength = 6
        Me.cmbKredit1.Name = "cmbKredit1"
        Me.cmbKredit1.Size = New System.Drawing.Size(121, 24)
        Me.cmbKredit1.TabIndex = 9
        '
        'cmbDebit1
        '
        Me.cmbDebit1.FormattingEnabled = True
        Me.cmbDebit1.Location = New System.Drawing.Point(104, 31)
        Me.cmbDebit1.MaxLength = 6
        Me.cmbDebit1.Name = "cmbDebit1"
        Me.cmbDebit1.Size = New System.Drawing.Size(121, 24)
        Me.cmbDebit1.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(254, 129)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 16)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Kredit 4"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(254, 99)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 16)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Debit 4"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(254, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 16)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Kredit 3"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(254, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Debit 3"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 16)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Kredit 2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Debit 2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Kredit 1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Debit 1"
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSimpan.Location = New System.Drawing.Point(297, 256)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(82, 34)
        Me.btnSimpan.TabIndex = 5
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'btnBatal
        '
        Me.btnBatal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBatal.Location = New System.Drawing.Point(385, 256)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(91, 34)
        Me.btnBatal.TabIndex = 6
        Me.btnBatal.Text = "Batal"
        Me.btnBatal.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statmsg})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 298)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(501, 22)
        Me.StatusStrip1.TabIndex = 19
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'statmsg
        '
        Me.statmsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statmsg.Name = "statmsg"
        Me.statmsg.Size = New System.Drawing.Size(0, 17)
        '
        'txtMapoID
        '
        Me.txtMapoID.Location = New System.Drawing.Point(37, 257)
        Me.txtMapoID.Name = "txtMapoID"
        Me.txtMapoID.Size = New System.Drawing.Size(100, 20)
        Me.txtMapoID.TabIndex = 20
        Me.txtMapoID.Visible = False
        '
        'FAkunPostingAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 320)
        Me.Controls.Add(Me.txtMapoID)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnBatal)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtNama)
        Me.Controls.Add(Me.txtKode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FAkunPostingAdd"
        Me.ShowInTaskbar = False
        Me.Text = "Akun Posting Otomatis"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtKode As System.Windows.Forms.TextBox
    Friend WithEvents txtNama As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbKredit4 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDebit4 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbKredit3 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDebit3 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbKredit2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDebit2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbKredit1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDebit1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSimpan As System.Windows.Forms.Button
    Friend WithEvents btnBatal As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents statmsg As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtMapoID As System.Windows.Forms.TextBox
End Class
