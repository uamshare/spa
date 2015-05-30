Public Class RNeraca
    Private Model As New GeneralLedger
    Private Sub FReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
         'TODO: This line of code loads data into the 'simagro.neraca' table. You can move, or remove it, as needed.
        'Me.neracaTableAdapter.Fill(Me.simagro.neraca)

        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = MyApplication.DefaultFormatDate
        init()
    End Sub
    Public Sub init()
        'DateTimePicker1.Value = Format(Today.Date.Date.AddDays(-(Today.Day - 1)))
        DateTimePicker2.Value = Format(Date.Now)

        showReport(DateTimePicker2.Value)
        Me.ReportViewer1.RefreshReport()
    End Sub
    Private Sub showReport(dateend As Date)
        Try
            Dim ds As DataSet = Model.FillRNeraca(dateend, "Neraca")
            Dim param(2) As Microsoft.Reporting.WinForms.ReportParameter
            param(0) = New Microsoft.Reporting.WinForms.ReportParameter("title", "Neraca")
            param(1) = New Microsoft.Reporting.WinForms.ReportParameter("users", MUsers.UserInfo()("fullname"))
            param(2) = New Microsoft.Reporting.WinForms.ReportParameter("datereport", "Per : " & Format(dateend, "dd MMM yyyy"))

            With ReportViewer1
                .ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .LocalReport.ReportPath = MyApplication.ReportPath() & "DRNeraca.rdlc"
                .LocalReport.SetParameters(param)
                .LocalReport.DataSources.Clear()
                .LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("Neraca", ds.Tables(0)))
                .DocumentMapCollapsed = True
                .Dock = DockStyle.Fill
                .RefreshReport()
                .SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            End With
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
        End Try

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        showReport(DateTimePicker2.Value)
    End Sub
    'Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs)
    '    If DateTimePicker1.Value >= DateTimePicker2.Value Then
    '        DateTimePicker2.Value = DateTimePicker1.Value.AddDays(+1)
    '    End If
    'End Sub
    'Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
    '    If DateTimePicker2.Value <= DateTimePicker1.Value Then
    '        DateTimePicker1.Value = DateTimePicker2.Value.AddDays(-1)
    '    End If
    'End Sub
End Class