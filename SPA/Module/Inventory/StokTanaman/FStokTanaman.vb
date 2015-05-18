Public Class FStokTanaman
    Dim dt As New DataTable
    Dim DGVColumnCheckIndex As Integer

    Private Model As New Rstockm

    Public Sub init()
        Model.limitrecord = 25
        RetrieveData()
    End Sub
#Region "Format DataGridView"
    Private Sub InitializeDataGridView()

        ' Initialize basic DataGridView properties.
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.BackgroundColor = Color.LightGray
        DataGridView1.BorderStyle = BorderStyle.Fixed3D

        ' Set property values appropriate for read-only display and  
        ' limited interactivity. 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToOrderColumns = True
        DataGridView1.ReadOnly = True
        DataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect
        DataGridView1.MultiSelect = False
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        DataGridView1.AllowUserToResizeColumns = False
        DataGridView1.ColumnHeadersHeightSizeMode = _
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.RowHeadersWidthSizeMode = _
            DataGridViewRowHeadersWidthSizeMode.DisableResizing

        ' Set the selection background color for all the cells.
        DataGridView1.DefaultCellStyle.SelectionBackColor = Color.White
        DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black

        ' Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default 
        ' value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
        DataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty

        ' Set the background color for all rows and for alternating rows.  
        ' The value for alternating rows overrides the value for all rows. 
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray

        ' Set the row and column header styles.
        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        DataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Black

    End Sub
    Private Sub RetrieveData(Optional ByVal sSearch As String = "")
        Dim dt As DataTable
        Try
            If Not String.IsNullOrEmpty(sSearch) Then
                dt = Model.FindData(sSearch, Date.Now)
            Else
                dt = Model.GetData(Date.Now, Date.Now)
            End If
            With DataGridView1
                .Columns.Clear()
                DGVColumnCheckIndex = .Columns.Add(New DataGridViewCheckBoxColumn)
                .Columns(DGVColumnCheckIndex).Name = "rowchecked"
                .Columns(DGVColumnCheckIndex).HeaderText = ".."
                .Columns(DGVColumnCheckIndex).Width = 35

                .DataSource = dt

                For Each dgvc As DataGridViewColumn In .Columns
                    dgvc.Visible = False
                Next
                '.Columns("mmtrhid").Visible = False
                .Columns("mmtrid").HeaderText = "Kode"
                .Columns("mmtrid").Visible = True
                .Columns("mmtrname").HeaderText = "Jenis Tanaman"
                .Columns("mmtrname").Visible = True
                .Columns("polybag").HeaderText = "Polybag"
                .Columns("polybag").Visible = True
                .Columns("mmtrunit").HeaderText = "Satuan"
                .Columns("mmtrunit").Visible = True
                .Columns("stockend").HeaderText = "Stok Akhir"
                .Columns("stockend").Visible = True
                .Columns("hpp").HeaderText = "HPP"
                .Columns("hpp").Visible = True
                .Columns("bookvalue").HeaderText = "Nilai HPP"
                .Columns("bookvalue").Visible = True
                '.Columns("mmtrprice").HeaderText = "Harga Jual"
                '.Columns("PrimaryKey").Visible = False
                '.Columns("mmtrg").Visible = False

                .RowHeadersWidth = 75
                .Columns("mmtrid").Width = 100
                .Columns("mmtrname").Width = 200
                .Columns("polybag").Width = 75
                .Columns("polybag").DefaultCellStyle().Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("mmtrunit").Width = 100

                .Columns("stockend").Width = 100
                .Columns("stockend").DefaultCellStyle().Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("stockend").DefaultCellStyle().Format = "##,##0"
                .Columns("stockend").ValueType = GetType(Decimal)

                .Columns("hpp").Width = 100
                .Columns("hpp").DefaultCellStyle().Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("hpp").DefaultCellStyle().Format = "##,##0"
                .Columns("hpp").ValueType = GetType(Decimal)

                .Columns("bookvalue").Width = 100
                .Columns("bookvalue").DefaultCellStyle().Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("bookvalue").DefaultCellStyle().Format = "##,##0"
                .Columns("bookvalue").ValueType = GetType(Decimal)

                .Refresh()
                If .RowCount > 0 Then
                    For i As Integer = 0 To .Rows.Count - 1
                        Dim count As Integer = Model.startRecord
                        .Rows(i).HeaderCell.Value = (i + Model.startRecord + 1).ToString
                    Next
                End If
            End With
            setButtonPager()
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message, ERROR_STAT)
        End Try

    End Sub
    Private Function getCountSelectedData() As Integer
        Dim CountSelected As Integer = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            'delete data
            If DataGridView1.Rows(i).Cells(DGVColumnCheckIndex).FormattedValue = True Then
                CountSelected = CountSelected + 1
            End If
        Next
        Return CountSelected
    End Function
    Private Function getRowIndexSelected() As Integer
        Dim index As Integer = -1
        If DataGridView1.RowCount > 0 Then
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                'delete data
                If DataGridView1.Rows(i).Cells(DGVColumnCheckIndex).FormattedValue = True Then
                    index = i
                End If
            Next
        End If
        Return index
    End Function
    Private Sub ToolFind_Click(sender As Object, e As EventArgs) Handles ToolFind.Click
        Model.startRecord = 0
        RetrieveData(ToolTextFind.Text)
    End Sub
    Private Sub ToolRefresh_Click(sender As Object, e As EventArgs) Handles ToolRefresh.Click
        RetrieveData()
        ToolTextFind.Text = ""
    End Sub
#End Region
#Region "Pagination"
    Public Sub setButtonPager() ' Set button pagination enable or disable
        Try
            Dim page, CurrentCountRows, endofpage As Integer
            If Model.limitrecord > 0 Then
                endofpage = (Model.GetRowsCount() \ Model.limitrecord) '* Model.limitrecord
                endofpage = IIf((endofpage * Model.limitrecord) < Model.GetRowsCount(), endofpage, endofpage - 1) + 1
                page = IIf(Model.startRecord = 0, 0, Model.startRecord / Model.limitrecord) + 1
                'Dim page As Integer = IIf(Model.startRecord = 0, 0, Model.startRecord / Model.limitrecord) + 1

                If page = 1 Then
                    ToolPrev.Enabled = False
                    ToolFisrt.Enabled = False
                    ToolNext.Enabled = True
                    ToolLast.Enabled = True
                Else
                    ToolPrev.Enabled = True
                    ToolNext.Enabled = True
                    ToolLast.Enabled = True
                    ToolFisrt.Enabled = True
                End If

                If page = endofpage Then
                    ToolNext.Enabled = False
                    ToolLast.Enabled = False
                End If
                cmbperPage.Text = Model.limitrecord
                'page = IIf(Model.startRecord = 0, 0, Model.startRecord / Model.limitrecord) + 1
                CurrentCountRows = IIf((Model.startRecord + Model.limitrecord) > Model.GetRowsCount(), Model.GetRowsCount(), (Model.startRecord + Model.limitrecord))
                'lpageinfo.Text = "Page " & page & " of " & (Model.GetRowsCount() \ Model.limitrecord) & " as " & Model.GetRowsCount() & " Records"

            Else
                ToolFisrt.Enabled = False
                ToolPrev.Enabled = False
                ToolNext.Enabled = False
                ToolLast.Enabled = False
                page = 1
                cmbperPage.Text = "All"
            End If

            'Navigator Info
            lpageInfo.Text = (Model.startRecord + 1) & "-" & CurrentCountRows & " as " & Model.GetRowsCount() & " Rows"
            Me.lCountPage.Text = "of " & endofpage
            txtPageCurrent.Text = page
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message, ERROR_STAT)
        End Try
    End Sub
    Public Sub RetrieveFirst()
        Model.startRecord = 0
        RetrieveData()
    End Sub
    Sub RetrievePrev()
        If Model.startRecord > 0 Then
            Model.startRecord = Model.startRecord - Model.limitrecord
            RetrieveData()
        End If
    End Sub
    Sub RetrieveNext()
        If Model.startRecord < Model.GetRowsCount() Then
            Model.startRecord = Model.startRecord + Model.limitrecord
            RetrieveData()
        End If
    End Sub
    Sub RetrieveLast()
        Dim totalpage = (Model.GetRowsCount() \ Model.limitrecord) * Model.limitrecord
        If totalpage < Model.GetRowsCount() Then
            Model.startRecord = totalpage
        Else
            Model.startRecord = totalpage - Model.limitrecord
        End If
        RetrieveData()
    End Sub
    Private Sub ToolFisrt_Click(sender As Object, e As EventArgs) Handles ToolFisrt.Click
        RetrieveFirst()
    End Sub
    Private Sub ToolPrev_Click(sender As Object, e As EventArgs) Handles ToolPrev.Click
        RetrievePrev()
    End Sub
    Private Sub ToolNext_Click(sender As Object, e As EventArgs) Handles ToolNext.Click
        RetrieveNext()
    End Sub
    Private Sub ToolLast_Click(sender As Object, e As EventArgs) Handles ToolLast.Click
        RetrieveLast()
    End Sub
    Private Sub DataGridView1_Sorted(sender As Object, e As EventArgs) Handles DataGridView1.Sorted
        With DataGridView1
            If .RowCount > 0 Then
                For i As Integer = 0 To .Rows.Count - 1
                    Dim count As Integer = Model.startRecord
                    .Rows(i).HeaderCell.Value = (i + Model.startRecord + 1).ToString
                Next
            End If
        End With
    End Sub
    Private Sub txtPageCurrent_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPageCurrent.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'MessageBox.Show(Model.limitrecord)
            Dim countpage As Integer
            Dim pageto As Integer = Val(txtPageCurrent.Text)
            If Model.limitrecord > 0 Then
                countpage = (Model.GetRowsCount() \ Model.limitrecord)
            Else
                countpage = 1
            End If
            If pageto > countpage Then
                pageto = countpage
            ElseIf pageto < 1 Then
                pageto = 1
            End If
            Model.startRecord = ((Model.limitrecord * pageto) - Model.limitrecord) + 1
            RetrieveData() 'Retrieve datagridview
        Else
            If Not IsNumeric(e.KeyChar) And Asc(e.KeyChar) <> 8 Then
                e.KeyChar = Nothing
            End If
        End If
        'MessageBox.Show(Asc(e.KeyChar))
    End Sub
    Private Sub cmbperPage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbperPage.SelectedIndexChanged
        If IsNumeric(cmbperPage.Text) Then
            Model.limitrecord = Int(cmbperPage.Text)
        Else
            Model.limitrecord = 0
        End If
        RetrieveData()
    End Sub
#End Region
    Private Sub FStokTanaman_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyApplication.ShowStatus(Me.Text & " Loaded")
        InitializeDataGridView()
        init()
    End Sub
    Private Sub FDataTanaman_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        FStokTanaman_Load(sender, e)
    End Sub

    Private Sub toolPrint_Click(sender As Object, e As EventArgs) Handles toolPrint.Click
        FRekapStok.WindowState = FormWindowState.Maximized
        FRekapStok.ReportViewer1.Dock = DockStyle.Fill
        Dim ds As DataSet = Model.ReportStockAll(Date.Now, "DataSet1")
        'Dim p As New ReportParameter("programName", "Test")
        FRekapStok.ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
        'If Not System.IO.Directory.Exists(Application.StartupPath & "\Reports\") Then
        '    FReport.ReportViewer1.LocalReport.ReportPath = "..\..\Reports\DRStokTanaman.rdlc"
        'End If
        'MsgBox(MyApplication.ReportPath() & "DRStokTanaman.rdlc")
        FRekapStok.ReportViewer1.LocalReport.ReportPath = MyApplication.ReportPath() & "DRStokTanaman.rdlc"
        'FReport.ReportViewer1.LocalReport.SetParameters(p)
        FRekapStok.ReportViewer1.LocalReport.DataSources.Clear()
        FRekapStok.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables(0)))
        FRekapStok.ReportViewer1.DocumentMapCollapsed = True
        FRekapStok.ReportViewer1.RefreshReport()
        FRekapStok.ReportViewer1.Width = 1024
        FRekapStok.ReportViewer1.Height = 600
        FRekapStok.Show()
    End Sub
End Class