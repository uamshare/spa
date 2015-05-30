Public Class RRugiLaba
    Private Model As New GeneralLedger
    Private Sub FReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'simagro.rugilaba' table. You can move, or remove it, as needed.
        Me.rugilabaTableAdapter.Fill(Me.simagro.rugilaba)

        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "MMM, yyyy"
        DateTimePicker2.ShowUpDown = True
        init()
    End Sub
    Public Sub init()
        'DateTimePicker1.Value = Format(Today.Date.Date.AddDays(-(Today.Day - 1)))
        DateTimePicker2.Value = Format(Date.Now)
        'MsgBox(DateTimePicker2.Value.Mont)
        showReport(DateTimePicker2.Value)
        Me.ReportViewer1.RefreshReport()
    End Sub
    Private Sub showReport(dateend As Date)
        Try
            Dim ds As DataSet = Model.FillRRugiLaba(dateend, "RugiLaba")
            Dim param(2) As Microsoft.Reporting.WinForms.ReportParameter
            param(0) = New Microsoft.Reporting.WinForms.ReportParameter("title", "Rugi Laba")
            param(1) = New Microsoft.Reporting.WinForms.ReportParameter("users", MUsers.UserInfo()("fullname"))
            param(2) = New Microsoft.Reporting.WinForms.ReportParameter("datereport", Format(dateend, "MMM") & " " & dateend.Year)

            With ReportViewer1
                .ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .LocalReport.ReportPath = MyApplication.ReportPath() & "DRRugiLaba.rdlc"
                .LocalReport.SetParameters(param)
                .LocalReport.DataSources.Clear()
                .LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("RugiLaba", ds.Tables(0)))
                .DocumentMapCollapsed = True
                .Dock = DockStyle.Fill
                .RefreshReport()
                .SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            End With
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
            ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace, "Report Error")
        End Try

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        showReport(DateTimePicker2.Value)
    End Sub

    Private Sub DateTimePicker2_Invalidated(sender As Object, e As InvalidateEventArgs) Handles DateTimePicker2.Invalidated
        'MsgBox(DateTimePicker2.Value)
        'MyApplication.ShowStatus("Invalidate", WARNING_STAT)
        'ErrorLogger.WriteToErrorLog("Invalidate", "Invalidate", "Datetimepicker Error")
    End Sub
    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        DateTimePicker2.Value = Format(DateTimePicker2.Value.Date.Date.AddDays(-(DateTimePicker2.Value.Day - 1))) 'DateTimePicker2.Value.AddDays(1)
    End Sub
End Class