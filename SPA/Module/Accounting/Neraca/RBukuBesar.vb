Public Class RBukuBesar
    Private Model As New GeneralLedger
    Private Sub FReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'simagro.bukubesar' table. You can move, or remove it, as needed.
        'Me.bukubesarTableAdapter.Fill(Me.simagro.bukubesar)

        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = MyApplication.DefaultFormatDate
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = MyApplication.DefaultFormatDate

        Dim Coa1, Coa2 As New MCOADetail
        Dim CoaDT1, CoaDT2 As DataTable

        Coa1.limitrecord = -1
        CoaDT1 = Coa1.GetData
        CoaDT1.Columns.Add("displaymember", GetType(String), "mcoadno + ' - ' + mcoadname")
        ComboBox1.DataSource = CoaDT1 'Coa1.GetData
        ComboBox1.ValueMember = "mcoadno"
        ComboBox1.DisplayMember = "displaymember"
        ComboBox1.SelectedIndex = -1

        Coa2.limitrecord = -1
        CoaDT2 = Coa2.GetData
        CoaDT2.Columns.Add("displaymember", GetType(String), "mcoadno + ' - ' + mcoadname")
        ComboBox2.DataSource = CoaDT2 'Coa2.GetData
        ComboBox2.ValueMember = "mcoadno"
        ComboBox2.DisplayMember = "displaymember"
        ComboBox2.SelectedIndex = -1

        init()
    End Sub
    Public Sub init()
        DateTimePicker1.Value = Format(Today.Date.Date.AddDays(-(Today.Day - 1)))
        DateTimePicker2.Value = Format(Date.Now)
        'ComboBox3.SelectedIndex = 2

        TextAutoComplete(ComboBox1)
        TextAutoComplete(ComboBox2)

        showReport(DateTimePicker1.Value, DateTimePicker2.Value)
        Me.ReportViewer1.RefreshReport()
    End Sub
    Private Sub showReport(datestart As Date, dateend As Date,
                           Optional noref1 As String = "",
                           Optional noref2 As String = "")
        Try
            Dim ds As DataSet = Model.FillRBukuBesar(datestart, dateend, "BukuBesar", noref1, noref2)
            Dim param(2) As Microsoft.Reporting.WinForms.ReportParameter
            param(0) = New Microsoft.Reporting.WinForms.ReportParameter("title", "Buku Besar")
            param(1) = New Microsoft.Reporting.WinForms.ReportParameter("users", MUsers.UserInfo()("fullname"))
            param(2) = New Microsoft.Reporting.WinForms.ReportParameter("datereport",
                                                                        "dr tgl " & Format(datestart, "dd-MM-yyyy") & _
                                                                        " s/d " & Format(dateend, "dd-MM-yyyy"))

            With ReportViewer1
                .ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .LocalReport.ReportPath = MyApplication.ReportPath() & "DRBukuBesar.rdlc"
                .LocalReport.SetParameters(param)
                .LocalReport.DataSources.Clear()
                .LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("BukuBesar", ds.Tables(0)))
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
        showReport(DateTimePicker1.Value, DateTimePicker2.Value, ComboBox1.SelectedValue, ComboBox2.SelectedValue)
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
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message, WARNING_STAT)
        End Try
    End Sub
#End Region
End Class