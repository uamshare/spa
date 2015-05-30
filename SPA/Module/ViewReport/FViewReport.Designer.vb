<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FViewReport
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.NotaInvoiceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.simagro = New SPA.simagro()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.NotaInvoiceTableAdapter = New SPA.simagroTableAdapters.NotaInvoiceTableAdapter()
        CType(Me.NotaInvoiceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.simagro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NotaInvoiceBindingSource
        '
        Me.NotaInvoiceBindingSource.DataMember = "NotaInvoice"
        Me.NotaInvoiceBindingSource.DataSource = Me.simagro
        '
        'simagro
        '
        Me.simagro.DataSetName = "simagro"
        Me.simagro.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ReportViewer1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(545, 369)
        Me.Panel1.TabIndex = 0
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "NotaInvoice"
        ReportDataSource1.Value = Me.NotaInvoiceBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SPA.DRNotaPenjualan.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(35, 27)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(470, 303)
        Me.ReportViewer1.TabIndex = 0
        '
        'NotaInvoiceTableAdapter
        '
        Me.NotaInvoiceTableAdapter.ClearBeforeFill = True
        '
        'FViewReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 369)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FViewReport"
        Me.Text = "FViewReport"
        CType(Me.NotaInvoiceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.simagro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents NotaInvoiceBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents simagro As SPA.simagro
    Friend WithEvents NotaInvoiceTableAdapter As SPA.simagroTableAdapters.NotaInvoiceTableAdapter
End Class
