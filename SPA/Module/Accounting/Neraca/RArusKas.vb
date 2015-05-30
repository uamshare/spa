Public Class RArusKas
    Private Model As New GeneralLedger
    Private Sub FReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'simagro.cashflow' table. You can move, or remove it, as needed.
        'Me.cashflowTableAdapter.Fill(Me.simagro.cashflow)

        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = MyApplication.DefaultFormatDate
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = MyApplication.DefaultFormatDate
        init()
    End Sub
    Public Sub init()
        DateTimePicker1.Value = Format(Today.Date.Date.AddDays(-(Today.Day - 1)))
        DateTimePicker2.Value = Format(Date.Now)
        'ComboBox3.SelectedIndex = 2
        showReport(DateTimePicker1.Value, DateTimePicker2.Value)
        Me.ReportViewer1.RefreshReport()
    End Sub
    Private Sub showReport(datestart As Date, dateend As Date,
                           Optional noref1 As String = "",
                           Optional noref2 As String = "")
        Try
            Dim ds As DataSet = Model.FillRArusKas(datestart, dateend, "ArusKas", noref1, noref2)
            Dim param(2) As Microsoft.Reporting.WinForms.ReportParameter
            param(0) = New Microsoft.Reporting.WinForms.ReportParameter("title", "Arus Kas & Bank")
            param(1) = New Microsoft.Reporting.WinForms.ReportParameter("users", MUsers.UserInfo()("fullname"))
            param(2) = New Microsoft.Reporting.WinForms.ReportParameter("datereport",
                                                                        "dr tgl " & Format(datestart, "dd-MM-yyyy") & _
                                                                        " s/d " & Format(dateend, "dd-MM-yyyy"))

            With ReportViewer1
                .ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .LocalReport.ReportPath = MyApplication.ReportPath() & "DRArusKas.rdlc"
                .LocalReport.SetParameters(param)
                .LocalReport.DataSources.Clear()
                .LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ArusKas", ds.Tables(0)))
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
        showReport(DateTimePicker1.Value, DateTimePicker2.Value)
    End Sub
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If DateTimePicker1.Value >= DateTimePicker2.Value Then
            DateTimePicker2.Value = DateTimePicker1.Value.AddDays(+1)
        End If
    End Sub
    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        If DateTimePicker2.Value <= DateTimePicker1.Value Then
            DateTimePicker1.Value = DateTimePicker2.Value.AddDays(-1)
        End If
    End Sub
#Region "TextAutoComplete"
    'Public Sub addItems(ByVal col As AutoCompleteStringCollection)
    '    Try
    '        For Each dat In ListDataTanaman
    '            col.Add(dat("mmtrid"))
    '        Next
    '    Catch ex As Exception
    '        MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
    '    End Try
    'End Sub
    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
    End Sub
    Private Sub ComboBox2_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
    End Sub
    Private Sub TextAutoComplete(cmb As ComboBox)
        Try
            cmb.AutoCompleteMode = AutoCompleteMode.Suggest
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message, WARNING_STAT)
        End Try
    End Sub
#End Region
End Class