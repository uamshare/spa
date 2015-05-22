Public Class FKartuStok
    Private Model As New Rstockm
    'Private ModelM As New MTanaman
    Public ListDataTanaman As List(Of Dictionary(Of String, Object)) = New MTanaman().GetDataList
    Private Sub FReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'simagroDataSet1.stock_all' table. You can move, or remove it, as needed.
        'Me.Stock_cardTableAdapter.Fill(Me.simagro.stock_card)

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

        TextBoxAutoComplete(TextBox1)
        TextBoxAutoComplete(TextBox2)

        showReport(DateTimePicker1.Value, DateTimePicker2.Value)
        Me.ReportViewer1.RefreshReport()
    End Sub
    Private Sub showReport(datestart As Date, dateend As Date,
                           Optional viewtable As String = "material_fig",
                           Optional noref1 As String = "",
                           Optional noref2 As String = "")
        Try
            Dim ds As DataSet = Model.ReportStockCard(datestart, dateend, "StockCard", viewtable, noref1, noref2)
            Dim param(1) As Microsoft.Reporting.WinForms.ReportParameter
            param(0) = New Microsoft.Reporting.WinForms.ReportParameter("title", ComboBox3.Text.Substring(4))
            param(1) = New Microsoft.Reporting.WinForms.ReportParameter("users", MUsers.UserInfo()("fullname"))

            With ReportViewer1
                .ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .LocalReport.ReportPath = MyApplication.ReportPath() & "DRKartuStok.rdlc"
                .LocalReport.SetParameters(param)
                .LocalReport.DataSources.Clear()
                .LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("StockCard", ds.Tables(0)))
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
#Region "TextBoxAutoComplete"
    Public Sub addItems(ByVal col As AutoCompleteStringCollection)
        Try
            For Each dat In ListDataTanaman
                col.Add(dat("mmtrid"))
            Next
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
        End Try
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
    Private Sub TextBoxAutoComplete(txt As TextBox)
        Try
            txt.AutoCompleteMode = AutoCompleteMode.Suggest
            txt.AutoCompleteSource = AutoCompleteSource.CustomSource
            Dim DataCollection As New AutoCompleteStringCollection()
            addItems(DataCollection)
            txt.AutoCompleteCustomSource = DataCollection
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message, WARNING_STAT)
        End Try
    End Sub
#End Region
End Class