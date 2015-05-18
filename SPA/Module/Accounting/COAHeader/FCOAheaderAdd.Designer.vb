<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FCOAheaderAdd
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtKlasifikasi = New System.Windows.Forms.TextBox()
        Me.txtNo = New System.Windows.Forms.TextBox()
        Me.txtNama = New System.Windows.Forms.TextBox()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.btnBatal = New System.Windows.Forms.Button()
        Me.btnPrompt = New System.Windows.Forms.Button()
        Me.cmbLaporan = New System.Windows.Forms.ComboBox()
        Me.cmbSaldo = New System.Windows.Forms.ComboBox()
        Me.txtCoaId = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.statmsg = New System.Windows.Forms.ToolStripStatusLabel()
        Me.KeyID = New System.Windows.Forms.TextBox()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Klasifikasi"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "No Akun"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nama Akun"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Posisi Saldo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Posisi Laporan"
        '
        'txtKlasifikasi
        '
        Me.txtKlasifikasi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKlasifikasi.Location = New System.Drawing.Point(153, 11)
        Me.txtKlasifikasi.Name = "txtKlasifikasi"
        Me.txtKlasifikasi.Size = New System.Drawing.Size(258, 22)
        Me.txtKlasifikasi.TabIndex = 1
        '
        'txtNo
        '
        Me.txtNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNo.Location = New System.Drawing.Point(153, 39)
        Me.txtNo.MaxLength = 6
        Me.txtNo.Name = "txtNo"
        Me.txtNo.Size = New System.Drawing.Size(100, 22)
        Me.txtNo.TabIndex = 2
        '
        'txtNama
        '
        Me.txtNama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNama.Location = New System.Drawing.Point(153, 68)
        Me.txtNama.MaxLength = 50
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(291, 22)
        Me.txtNama.TabIndex = 3
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSimpan.Location = New System.Drawing.Point(263, 149)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(88, 36)
        Me.btnSimpan.TabIndex = 6
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'btnBatal
        '
        Me.btnBatal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBatal.Location = New System.Drawing.Point(357, 149)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(86, 36)
        Me.btnBatal.TabIndex = 7
        Me.btnBatal.Text = "Batal"
        Me.btnBatal.UseVisualStyleBackColor = True
        '
        'btnPrompt
        '
        Me.btnPrompt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrompt.Location = New System.Drawing.Point(412, 11)
        Me.btnPrompt.Name = "btnPrompt"
        Me.btnPrompt.Size = New System.Drawing.Size(32, 23)
        Me.btnPrompt.TabIndex = 12
        Me.btnPrompt.Text = "..."
        Me.btnPrompt.UseVisualStyleBackColor = True
        '
        'cmbLaporan
        '
        Me.cmbLaporan.FormattingEnabled = True
        Me.cmbLaporan.ItemHeight = 13
        Me.cmbLaporan.Items.AddRange(New Object() {"NRC", "LR"})
        Me.cmbLaporan.Location = New System.Drawing.Point(153, 122)
        Me.cmbLaporan.Name = "cmbLaporan"
        Me.cmbLaporan.Size = New System.Drawing.Size(121, 21)
        Me.cmbLaporan.TabIndex = 13
        '
        'cmbSaldo
        '
        Me.cmbSaldo.FormattingEnabled = True
        Me.cmbSaldo.ItemHeight = 13
        Me.cmbSaldo.Items.AddRange(New Object() {"D", "K"})
        Me.cmbSaldo.Location = New System.Drawing.Point(153, 97)
        Me.cmbSaldo.Name = "cmbSaldo"
        Me.cmbSaldo.Size = New System.Drawing.Size(121, 21)
        Me.cmbSaldo.TabIndex = 14
        '
        'txtCoaId
        '
        Me.txtCoaId.Location = New System.Drawing.Point(11, 149)
        Me.txtCoaId.Name = "txtCoaId"
        Me.txtCoaId.Size = New System.Drawing.Size(100, 20)
        Me.txtCoaId.TabIndex = 15
        Me.txtCoaId.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statmsg})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 186)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(449, 22)
        Me.StatusStrip1.TabIndex = 17
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'statmsg
        '
        Me.statmsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statmsg.Name = "statmsg"
        Me.statmsg.Size = New System.Drawing.Size(105, 17)
        Me.statmsg.Text = "Status Message"
        '
        'KeyID
        '
        Me.KeyID.Location = New System.Drawing.Point(137, 148)
        Me.KeyID.Name = "KeyID"
        Me.KeyID.Size = New System.Drawing.Size(100, 20)
        Me.KeyID.TabIndex = 18
        Me.KeyID.Visible = False
        '
        'FCOAheaderAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 208)
        Me.Controls.Add(Me.KeyID)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.txtCoaId)
        Me.Controls.Add(Me.cmbSaldo)
        Me.Controls.Add(Me.cmbLaporan)
        Me.Controls.Add(Me.btnPrompt)
        Me.Controls.Add(Me.btnBatal)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.txtNama)
        Me.Controls.Add(Me.txtNo)
        Me.Controls.Add(Me.txtKlasifikasi)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FCOAheaderAdd"
        Me.Text = "Master COA"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtKlasifikasi As System.Windows.Forms.TextBox
    Friend WithEvents txtNo As System.Windows.Forms.TextBox
    Friend WithEvents txtNama As System.Windows.Forms.TextBox
    Friend WithEvents btnSimpan As System.Windows.Forms.Button
    Friend WithEvents btnBatal As System.Windows.Forms.Button
    Friend WithEvents btnPrompt As System.Windows.Forms.Button
    Friend WithEvents cmbLaporan As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSaldo As System.Windows.Forms.ComboBox
    Friend WithEvents txtCoaId As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents statmsg As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents KeyID As System.Windows.Forms.TextBox
End Class
