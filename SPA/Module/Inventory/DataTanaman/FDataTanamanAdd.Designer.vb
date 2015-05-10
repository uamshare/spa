<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FDataTanamanAdd
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
        Me.lblName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtJnsTanaman = New System.Windows.Forms.TextBox()
        Me.txtKode = New System.Windows.Forms.TextBox()
        Me.txtKode2 = New System.Windows.Forms.TextBox()
        Me.txtKode3 = New System.Windows.Forms.TextBox()
        Me.txtSatuan = New System.Windows.Forms.TextBox()
        Me.txtHarga = New System.Windows.Forms.TextBox()
        Me.cmbPolybag = New System.Windows.Forms.ComboBox()
        Me.Prompt = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.btnBatal = New System.Windows.Forms.Button()
        Me.statmsg = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.txtKeyID = New System.Windows.Forms.TextBox()
        Me.txtMmtrg = New System.Windows.Forms.TextBox()
        Me.txtMmtrhid = New System.Windows.Forms.TextBox()
        Me.Tunique = New System.Windows.Forms.TextBox()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(8, 10)
        Me.lblName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(101, 16)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Jenis Tanaman"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 38)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Polybag"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 69)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Kode"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 97)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Satuan"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 126)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Harga Jual"
        '
        'txtJnsTanaman
        '
        Me.txtJnsTanaman.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJnsTanaman.Location = New System.Drawing.Point(161, 10)
        Me.txtJnsTanaman.Margin = New System.Windows.Forms.Padding(4)
        Me.txtJnsTanaman.MaxLength = 25
        Me.txtJnsTanaman.Name = "txtJnsTanaman"
        Me.txtJnsTanaman.Size = New System.Drawing.Size(321, 22)
        Me.txtJnsTanaman.TabIndex = 1
        '
        'txtKode
        '
        Me.txtKode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKode.Location = New System.Drawing.Point(161, 69)
        Me.txtKode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtKode.MaxLength = 5
        Me.txtKode.Name = "txtKode"
        Me.txtKode.Size = New System.Drawing.Size(132, 22)
        Me.txtKode.TabIndex = 3
        '
        'txtKode2
        '
        Me.txtKode2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKode2.Location = New System.Drawing.Point(296, 69)
        Me.txtKode2.Margin = New System.Windows.Forms.Padding(4)
        Me.txtKode2.MaxLength = 1
        Me.txtKode2.Name = "txtKode2"
        Me.txtKode2.Size = New System.Drawing.Size(41, 22)
        Me.txtKode2.TabIndex = 7
        '
        'txtKode3
        '
        Me.txtKode3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKode3.Location = New System.Drawing.Point(341, 69)
        Me.txtKode3.Margin = New System.Windows.Forms.Padding(4)
        Me.txtKode3.MaxLength = 3
        Me.txtKode3.Name = "txtKode3"
        Me.txtKode3.Size = New System.Drawing.Size(53, 22)
        Me.txtKode3.TabIndex = 8
        '
        'txtSatuan
        '
        Me.txtSatuan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSatuan.Location = New System.Drawing.Point(161, 97)
        Me.txtSatuan.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSatuan.MaxLength = 10
        Me.txtSatuan.Name = "txtSatuan"
        Me.txtSatuan.Size = New System.Drawing.Size(321, 22)
        Me.txtSatuan.TabIndex = 4
        '
        'txtHarga
        '
        Me.txtHarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHarga.Location = New System.Drawing.Point(161, 126)
        Me.txtHarga.Margin = New System.Windows.Forms.Padding(4)
        Me.txtHarga.MaxLength = 15
        Me.txtHarga.Name = "txtHarga"
        Me.txtHarga.Size = New System.Drawing.Size(321, 22)
        Me.txtHarga.TabIndex = 5
        Me.txtHarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbPolybag
        '
        Me.cmbPolybag.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPolybag.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbPolybag.FormattingEnabled = True
        Me.cmbPolybag.Items.AddRange(New Object() {"P25", "P35", "P50", "P80", "P150"})
        Me.cmbPolybag.Location = New System.Drawing.Point(161, 38)
        Me.cmbPolybag.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPolybag.Name = "cmbPolybag"
        Me.cmbPolybag.Size = New System.Drawing.Size(99, 24)
        Me.cmbPolybag.TabIndex = 2
        '
        'Prompt
        '
        Me.Prompt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Prompt.Location = New System.Drawing.Point(482, 8)
        Me.Prompt.Margin = New System.Windows.Forms.Padding(4)
        Me.Prompt.Name = "Prompt"
        Me.Prompt.Size = New System.Drawing.Size(35, 27)
        Me.Prompt.TabIndex = 12
        Me.Prompt.Text = "..."
        Me.Prompt.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Prompt.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSimpan.Location = New System.Drawing.Point(309, 180)
        Me.btnSimpan.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(100, 39)
        Me.btnSimpan.TabIndex = 6
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'btnBatal
        '
        Me.btnBatal.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnBatal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBatal.Location = New System.Drawing.Point(417, 180)
        Me.btnBatal.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(100, 39)
        Me.btnBatal.TabIndex = 7
        Me.btnBatal.Text = "Batal"
        Me.btnBatal.UseVisualStyleBackColor = True
        '
        'statmsg
        '
        Me.statmsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statmsg.Name = "statmsg"
        Me.statmsg.Size = New System.Drawing.Size(105, 17)
        Me.statmsg.Text = "Status Message"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statmsg})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 227)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(541, 22)
        Me.StatusStrip1.TabIndex = 15
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'txtKeyID
        '
        Me.txtKeyID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKeyID.Location = New System.Drawing.Point(48, 156)
        Me.txtKeyID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtKeyID.Name = "txtKeyID"
        Me.txtKeyID.Size = New System.Drawing.Size(132, 22)
        Me.txtKeyID.TabIndex = 16
        Me.txtKeyID.Visible = False
        '
        'txtMmtrg
        '
        Me.txtMmtrg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMmtrg.Location = New System.Drawing.Point(48, 180)
        Me.txtMmtrg.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMmtrg.Name = "txtMmtrg"
        Me.txtMmtrg.Size = New System.Drawing.Size(132, 22)
        Me.txtMmtrg.TabIndex = 17
        Me.txtMmtrg.Visible = False
        '
        'txtMmtrhid
        '
        Me.txtMmtrhid.Location = New System.Drawing.Point(187, 156)
        Me.txtMmtrhid.Name = "txtMmtrhid"
        Me.txtMmtrhid.Size = New System.Drawing.Size(100, 23)
        Me.txtMmtrhid.TabIndex = 18
        Me.txtMmtrhid.Visible = False
        '
        'Tunique
        '
        Me.Tunique.Location = New System.Drawing.Point(382, 42)
        Me.Tunique.Name = "Tunique"
        Me.Tunique.Size = New System.Drawing.Size(100, 23)
        Me.Tunique.TabIndex = 21
        Me.Tunique.Visible = False
        '
        'FDataTanamanAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnBatal
        Me.ClientSize = New System.Drawing.Size(541, 249)
        Me.Controls.Add(Me.Tunique)
        Me.Controls.Add(Me.txtMmtrhid)
        Me.Controls.Add(Me.txtMmtrg)
        Me.Controls.Add(Me.txtKeyID)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnBatal)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.Prompt)
        Me.Controls.Add(Me.cmbPolybag)
        Me.Controls.Add(Me.txtHarga)
        Me.Controls.Add(Me.txtSatuan)
        Me.Controls.Add(Me.txtKode3)
        Me.Controls.Add(Me.txtKode2)
        Me.Controls.Add(Me.txtKode)
        Me.Controls.Add(Me.txtJnsTanaman)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblName)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FDataTanamanAdd"
        Me.ShowInTaskbar = False
        Me.Text = "Data Tanaman"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtJnsTanaman As System.Windows.Forms.TextBox
    Friend WithEvents txtKode As System.Windows.Forms.TextBox
    Friend WithEvents txtKode2 As System.Windows.Forms.TextBox
    Friend WithEvents txtKode3 As System.Windows.Forms.TextBox
    Friend WithEvents txtSatuan As System.Windows.Forms.TextBox
    Friend WithEvents txtHarga As System.Windows.Forms.TextBox
    Friend WithEvents cmbPolybag As System.Windows.Forms.ComboBox
    Friend WithEvents Prompt As System.Windows.Forms.Button
    Friend WithEvents btnSimpan As System.Windows.Forms.Button
    Friend WithEvents btnBatal As System.Windows.Forms.Button
    Friend WithEvents statmsg As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents txtKeyID As System.Windows.Forms.TextBox
    Friend WithEvents txtMmtrg As System.Windows.Forms.TextBox
    Friend WithEvents txtMmtrhid As System.Windows.Forms.TextBox
    Friend WithEvents Tunique As System.Windows.Forms.TextBox
End Class
