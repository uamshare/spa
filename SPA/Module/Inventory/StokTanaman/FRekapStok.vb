Public Class FRekapStok
    Private Model As New Rstockm
    Private Sub FReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'simagroDataSet1.stock_all' table. You can move, or remove it, as needed.
        'Me.stock_allTableAdapter.Fill(Me.simagroDataSet1.stock_all)

        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = MyApplication.DefaultFormatDate
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = MyApplication.DefaultFormatDate

        init()
    End Sub

    Public Sub init()
        DateTimePicker1.Value = Format(Today.Date.Date.AddDays(-(Today.Day - 1)))
        DateTimePicker2.Value = Format(Date.Now)
        ComboBox3.SelectedIndex = 2
        showReport(DateTimePicker1.Value, DateTimePicker2.Value)
        Me.ReportViewer1.RefreshReport()
    End Sub
    Private Sub showReport(datestart As Date, dateend As Date,
                           Optional viewtable As String = "material_fig",
                           Optional noref1 As String = "",
                           Optional noref2 As String = "")

        Dim ds As DataSet = Model.ReportStockAll(datestart, dateend, "RstockAll", viewtable, noref1, noref2)
        Dim param(1) As Microsoft.Reporting.WinForms.ReportParameter
        param(0) = New Microsoft.Reporting.WinForms.ReportParameter("paramtitle", ComboBox3.Text.Substring(4))
        param(1) = New Microsoft.Reporting.WinForms.ReportParameter("paramuser", MUsers.UserInfo()("fullname"))

        With ReportViewer1
            .ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
            .LocalReport.ReportPath = MyApplication.ReportPath() & "DRStokTanaman.rdlc"
            .LocalReport.SetParameters(param)
            .LocalReport.DataSources.Clear()
            .LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("RstockAll", ds.Tables(0)))
            .DocumentMapCollapsed = True
            .Dock = DockStyle.Fill
            .RefreshReport()
            .SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Select Case ComboBox3.SelectedIndex
            Case 0
                showReport(DateTimePicker1.Value, DateTimePicker2.Value, "material_raw", TextBox1.Text, TextBox2.Text)
            Case 1
                showReport(DateTimePicker1.Value, DateTimePicker2.Value, "material_gip", TextBox1.Text, TextBox2.Text)
            Case 2
                showReport(DateTimePicker1.Value, DateTimePicker2.Value, "material_fig", TextBox1.Text, TextBox2.Text)
            Case Else
                MyApplication.ShowStatus("Tipe Stok belum dipilih", NOTICE_STAT)
                ComboBox3.Focus()
        End Select

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
End Class