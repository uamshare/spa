<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FCOADetailAdd
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.statmsg = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCoaHeader = New System.Windows.Forms.TextBox()
        Me.txtCoaDetail = New System.Windows.Forms.TextBox()
        Me.txtNamaAkun = New System.Windows.Forms.TextBox()
        Me.btnPrompt = New System.Windows.Forms.Button()
        Me.btbSimpan = New System.Windows.Forms.Button()
        Me.btnBatal = New System.Windows.Forms.Button()
        Me.txtDetail = New System.Windows.Forms.TextBox()
        Me.txtHeader = New System.Windows.Forms.TextBox()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statmsg})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 146)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(450, 22)
        Me.StatusStrip1.TabIndex = 18
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'statmsg
        '
        Me.statmsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statmsg.Name = "statmsg"
        Me.statmsg.Size = New System.Drawing.Size(105, 17)
        Me.statmsg.Text = "Status Message"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 16)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "COA Header"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(25, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 16)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "No Akun"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 16)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Nama Akun"
        '
        'txtCoaHeader
        '
        Me.txtCoaHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoaHeader.Location = New System.Drawing.Point(127, 10)
        Me.txtCoaHeader.MaxLength = 35
        Me.txtCoaHeader.Name = "txtCoaHeader"
        Me.txtCoaHeader.Size = New System.Drawing.Size(287, 22)
        Me.txtCoaHeader.TabIndex = 1
        '
        'txtCoaDetail
        '
        Me.txtCoaDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoaDetail.Location = New System.Drawing.Point(127, 34)
        Me.txtCoaDetail.MaxLength = 6
        Me.txtCoaDetail.Name = "txtCoaDetail"
        Me.txtCoaDetail.Size = New System.Drawing.Size(100, 22)
        Me.txtCoaDetail.TabIndex = 2
        '
        'txtNamaAkun
        '
        Me.txtNamaAkun.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaAkun.Location = New System.Drawing.Point(127, 58)
        Me.txtNamaAkun.MaxLength = 35
        Me.txtNamaAkun.Name = "txtNamaAkun"
        Me.txtNamaAkun.Size = New System.Drawing.Size(318, 22)
        Me.txtNamaAkun.TabIndex = 3
        '
        'btnPrompt
        '
        Me.btnPrompt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrompt.Location = New System.Drawing.Point(412, 9)
        Me.btnPrompt.Name = "btnPrompt"
        Me.btnPrompt.Size = New System.Drawing.Size(33, 23)
        Me.btnPrompt.TabIndex = 25
        Me.btnPrompt.Text = "..."
        Me.btnPrompt.UseVisualStyleBackColor = True
        '
        'btbSimpan
        '
        Me.btbSimpan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btbSimpan.Location = New System.Drawing.Point(284, 107)
        Me.btbSimpan.Name = "btbSimpan"
        Me.btbSimpan.Size = New System.Drawing.Size(76, 31)
        Me.btbSimpan.TabIndex = 4
        Me.btbSimpan.Text = "Simpan"
        Me.btbSimpan.UseVisualStyleBackColor = True
        '
        'btnBatal
        '
        Me.btnBatal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBatal.Location = New System.Drawing.Point(366, 107)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(77, 31)
        Me.btnBatal.TabIndex = 5
        Me.btnBatal.Text = "Batal"
        Me.btnBatal.UseVisualStyleBackColor = True
        '
        'txtDetail
        '
        Me.txtDetail.Location = New System.Drawing.Point(28, 113)
        Me.txtDetail.Name = "txtDetail"
        Me.txtDetail.Size = New System.Drawing.Size(75, 20)
        Me.txtDetail.TabIndex = 28
        Me.txtDetail.Visible = False
        '
        'txtHeader
        '
        Me.txtHeader.Location = New System.Drawing.Point(109, 113)
        Me.txtHeader.Name = "txtHeader"
        Me.txtHeader.Size = New System.Drawing.Size(73, 20)
        Me.txtHeader.TabIndex = 29
        Me.txtHeader.Visible = False
        '
        'FCOADetailAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 168)
        Me.Controls.Add(Me.txtHeader)
        Me.Controls.Add(Me.txtDetail)
        Me.Controls.Add(Me.btnBatal)
        Me.Controls.Add(Me.btbSimpan)
        Me.Controls.Add(Me.btnPrompt)
        Me.Controls.Add(Me.txtNamaAkun)
        Me.Controls.Add(Me.txtCoaDetail)
        Me.Controls.Add(Me.txtCoaHeader)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FCOADetailAdd"
        Me.ShowInTaskbar = False
        Me.Text = "COA Detail"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents statmsg As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCoaHeader As System.Windows.Forms.TextBox
    Friend WithEvents txtCoaDetail As System.Windows.Forms.TextBox
    Friend WithEvents txtNamaAkun As System.Windows.Forms.TextBox
    Friend WithEvents btnPrompt As System.Windows.Forms.Button
    Friend WithEvents btbSimpan As System.Windows.Forms.Button
    Friend WithEvents btnBatal As System.Windows.Forms.Button
    Friend WithEvents txtDetail As System.Windows.Forms.TextBox
    Friend WithEvents txtHeader As System.Windows.Forms.TextBox
End Class
