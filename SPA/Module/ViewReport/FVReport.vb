Public Class FVReport
    Public reportname As String
    Public notrans As String
    Public noteTrans As String = ""

    Private model As New MNotaPenjualanD
    Private Sub FViewReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showReportNotaPenjualan()
    End Sub
    Private Sub showReportNotaPenjualan()
        Try
            Dim ds As DataSet = model.FillNotaPenjualan(Me.notrans, "NotaInvoice")
            Dim param(2) As Microsoft.Reporting.WinForms.ReportParameter
            param(0) = New Microsoft.Reporting.WinForms.ReportParameter("title", "Nota Penjualan")
            param(1) = New Microsoft.Reporting.WinForms.ReportParameter("users", MUsers.UserInfo()("fullname"))
            param(2) = New Microsoft.Reporting.WinForms.ReportParameter("note", noteTrans)

            With ReportViewer1
                .ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .LocalReport.ReportPath = MyApplication.ReportPath() & reportname
                .LocalReport.SetParameters(param)
                .LocalReport.DataSources.Clear()
                .LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("NotaInvoice", ds.Tables(0)))
                .DocumentMapCollapsed = True
                .Dock = DockStyle.Fill
                .RefreshReport()
                .SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            End With
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
        End Try

    End Sub
End Class