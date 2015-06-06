Public Class FListBibitTanaman
    Dim dt As New DataTable
    Dim DGVColumnCheckIndex As Integer

    Private Model As New MBibitTanaman
    Public DatagridParent As DataGridView

    Public Sub init()
        Model.limitrecord = 25
        RetrieveData()
        DataGridView1.ClearSelection()
    End Sub
    Private Sub FListTanaman_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeDataGridView(DataGridView1)
        init()
    End Sub
    Private Sub FListTanaman_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        init()
    End Sub
#Region "Format DataGridView"
    'Private Sub InitializeDataGridView()

    '    ' Initialize basic DataGridView properties.
    '    DataGridView1.Dock = DockStyle.Fill
    '    DataGridView1.BackgroundColor = Color.LightGray
    '    DataGridView1.BorderStyle = BorderStyle.Fixed3D

    '    ' Set property values appropriate for read-only display and  
    '    ' limited interactivity. 
    '    DataGridView1.AllowUserToAddRows = False
    '    DataGridView1.AllowUserToDeleteRows = False
    '    DataGridView1.AllowUserToOrderColumns = True
    '    DataGridView1.ReadOnly = True
    '    DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '    DataGridView1.MultiSelect = False
    '    DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
    '    DataGridView1.AllowUserToResizeColumns = False
    '    DataGridView1.ColumnHeadersHeightSizeMode = _
    '        DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    '    DataGridView1.AllowUserToResizeRows = False
    '    DataGridView1.RowHeadersWidthSizeMode = _
    '        DataGridViewRowHeadersWidthSizeMode.DisableResizing

    '    ' Set the selection background color for all the cells.
    '    DataGridView1.DefaultCellStyle.SelectionBackColor = Color.White
    '    DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black

    '    ' Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default 
    '    ' value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
    '    DataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty

    '    ' Set the background color for all rows and for alternating rows.  
    '    ' The value for alternating rows overrides the value for all rows. 
    '    DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray
    '    DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray

    '    ' Set the row and column header styles.
    '    DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
    '    DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
    '    DataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Black

    'End Sub
    Private Sub RetrieveData(Optional ByVal sSearch As String = "")
        Dim dt As DataTable

        Try
            If Not String.IsNullOrEmpty(sSearch) Then
                dt = Model.FindData(sSearch)
            Else
                dt = Model.GetData()
            End If

            With DataGridView1
                .Columns.Clear()

                .DataSource = dt
                .Columns("mmtrhid").Visible = False
                .Columns("mmtrid").HeaderText = "Kode"
                .Columns("mmtrname").HeaderText = "Jenis Tanaman"
                .Columns("polybag").HeaderText = "Polybag"
                .Columns("mmtrunit").HeaderText = "Satuan"
                .Columns("mmtrprice").HeaderText = "Harga Jual"
                .Columns("PrimaryKey").Visible = False
                .Columns("mmtrg").Visible = False

                .RowHeadersWidth = 50
                .Columns("mmtrid").Width = 100
                .Columns("mmtrname").Width = 200
                .Columns("polybag").Width = 75
                .Columns("polybag").DefaultCellStyle().Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("mmtrunit").Width = 100
                .Columns("mmtrprice").Width = 100
                .Columns("mmtrprice").DefaultCellStyle().Format = "##,##0"
                .Columns("mmtrprice").DefaultCellStyle().Alignment = DataGridViewContentAlignment.MiddleRight
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
            MyApplication.ShowStatus("Failed to RetrieveData = " & ex.Message, WARNING_STAT)
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
    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        Try
            If (DataGridView1.SelectedRows.Count > 0) Then
                DatagridParent.CurrentRow.Cells("mmtrid").Value = DataGridView1.CurrentRow.Cells("mmtrid").Value()
                DatagridParent.EndEdit()
                Me.Close()
            Else
                MyApplication.ShowStatus("Tidak ada data terpilih", NOTICE_STAT)
            End If
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
        End Try
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
                cmbperpage.Text = Model.limitrecord
                'page = IIf(Model.startRecord = 0, 0, Model.startRecord / Model.limitrecord) + 1
                CurrentCountRows = IIf((Model.startRecord + Model.limitrecord) > Model.GetRowsCount(), Model.GetRowsCount(), (Model.startRecord + Model.limitrecord))
                'lpageinfo.Text = "Page " & page & " of " & (Model.GetRowsCount() \ Model.limitrecord) & " as " & Model.GetRowsCount() & " Records"

            Else
                ToolFisrt.Enabled = False
                ToolPrev.Enabled = False
                ToolNext.Enabled = False
                ToolLast.Enabled = False
                page = 1
                cmbperpage.Text = "All"
            End If

            'Navigator Info
            lpageinfo.Text = (Model.startRecord + 1) & "-" & CurrentCountRows & " as " & Model.GetRowsCount() & " Rows"
            Me.lCountPage.Text = "of " & endofpage
            txtPageCurrent.Text = page
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message, WARNING_STAT)
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

    Private Sub cmbperPage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbperpage.SelectedIndexChanged
        If IsNumeric(cmbperPage.Text) Then
            Model.limitrecord = Int(cmbperPage.Text)
        Else
            Model.limitrecord = 0
        End If
        RetrieveData()
    End Sub
    Private Sub ToolRefresh_Click(sender As Object, e As EventArgs) Handles ToolRefresh.Click
        RetrieveData()
        ToolTextFind.Text = ""
    End Sub
    Private Sub ToolFind_Click(sender As Object, e As EventArgs) Handles ToolFind.Click
        Model.startRecord = 0
        'If Not String.IsNullOrEmpty(ToolFind.Text) Then
        RetrieveData(ToolTextFind.Text)
        'Else
        '    RetrieveData()
        'End If
    End Sub
#End Region

    Private Sub ToolCheck_Click(sender As Object, e As EventArgs) Handles ToolCheck.Click
        DataGridView1_CellContentDoubleClick(sender, Nothing)
    End Sub
End Class