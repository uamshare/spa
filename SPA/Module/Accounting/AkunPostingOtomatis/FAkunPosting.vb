Public Class FAkunPosting
    Dim dt As New DataTable
    Dim DGVColumnCheckIndex As Integer

    Private Model As New MAkunPosting
    Private ModelRowCount As Integer = Model.GetRowsCount
    Public Sub init()
        ToolAdd.Enabled = True
        ToolEdit.Enabled = False
        ToolDelete.Enabled = False
        Model.limitrecord = 25
        RetrieveData()
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
    '    DataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect
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
            ModelRowCount = Model.GetRowsCount()
            With DataGridView1
                .Columns.Clear()
                DGVColumnCheckIndex = .Columns.Add(New DataGridViewCheckBoxColumn)
                .Columns(DGVColumnCheckIndex).Name = "rowchecked"
                .Columns(DGVColumnCheckIndex).HeaderText = ".."
                .Columns(DGVColumnCheckIndex).Width = 35

                .DataSource = dt
                .Columns("mapoid").HeaderText = "Kode"
                .Columns("maponame").HeaderText = "Transaksi"
                .Columns("acc_debit").HeaderText = "Debit 1"
                .Columns("acc_credit").HeaderText = "Kredit 1"
                .Columns("acc_debit2").HeaderText = "Debit 2"
                .Columns("acc_credit2").HeaderText = "Kredit 2"
                .Columns("acc_debit3").HeaderText = "Debit 3"
                .Columns("acc_credit3").HeaderText = "Kredit 3"
                .Columns("acc_debit4").HeaderText = "Debit 4"
                .Columns("acc_credit4").HeaderText = "Kredit 4"

                .RowHeadersWidth = 100
                .Columns("mapoid").Width = 100
                .Columns("maponame").Width = 350
                .Columns("acc_debit").Width = 75
                .Columns("acc_credit").Width = 75
                .Columns("acc_debit2").Width = 75
                .Columns("acc_credit2").Width = 75
                .Columns("acc_debit3").Width = 75
                .Columns("acc_credit3").Width = 75
                .Columns("acc_debit4").Width = 75
                .Columns("acc_credit4").Width = 75
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
#End Region

#Region "Pagination"
    Public Sub setButtonPager() ' Set button pagination enable or disable
        Try
            Dim page, CurrentCountRows, endofpage As Integer
            If Model.limitrecord > 0 Then
                endofpage = (ModelRowCount \ Model.limitrecord) '* Model.limitrecord
                endofpage = IIf((endofpage * Model.limitrecord) < ModelRowCount, endofpage, endofpage - 1) + 1
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
                CurrentCountRows = IIf((Model.startRecord + Model.limitrecord) > ModelRowCount, ModelRowCount, (Model.startRecord + Model.limitrecord))
                'lpageinfo.Text = "Page " & page & " of " & (ModelRowCount \ Model.limitrecord) & " as " & ModelRowCount & " Records"

            Else
                ToolFisrt.Enabled = False
                ToolPrev.Enabled = False
                ToolNext.Enabled = False
                ToolLast.Enabled = False
                page = 1
                cmbperPage.Text = "All"
            End If

            'Navigator Info
            lpageInfo.Text = (Model.startRecord + 1) & "-" & CurrentCountRows & " as " & ModelRowCount & " Rows"
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
        If Model.startRecord < ModelRowCount Then
            Model.startRecord = Model.startRecord + Model.limitrecord
            RetrieveData()
        End If
    End Sub
    Sub RetrieveLast()
        Dim totalpage = (ModelRowCount \ Model.limitrecord) * Model.limitrecord
        If totalpage < ModelRowCount Then
            Model.startRecord = totalpage
        Else
            Model.startRecord = totalpage - Model.limitrecord
        End If
        RetrieveData()
    End Sub
#End Region

    'Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        If DGVColumnCheckIndex = e.ColumnIndex Then
            If e.RowIndex > -1 Then
                DataGridView1.Rows(e.RowIndex).Cells(DGVColumnCheckIndex).Value = Not DataGridView1.Rows(e.RowIndex).Cells(DGVColumnCheckIndex).FormattedValue
            Else
                DataGridView1.ClearSelection()
                'DataGridView1.Columns
            End If
        End If
        If getCountSelectedData() = 1 Then
            ToolAdd.Enabled = False
            ToolEdit.Enabled = True
            ToolDelete.Enabled = True
        ElseIf getCountSelectedData() > 1 Then
            ToolAdd.Enabled = False
            ToolEdit.Enabled = False
            ToolDelete.Enabled = True
        Else
            ToolAdd.Enabled = True
            ToolEdit.Enabled = False
            ToolDelete.Enabled = False
        End If
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

    Private Sub ToolAdd_Click(sender As Object, e As EventArgs) Handles ToolAdd.Click
        FAkunPostingAdd.txtKode.Clear()
        FAkunPostingAdd.txtMapoID.Clear()
        FAkunPostingAdd.txtNama.Clear()
        'FAkunPostingAdd.cmbDebit1.SelectedIndex = -1
        'FAkunPostingAdd.cmbKredit1.SelectedIndex = -1
        'FAkunPostingAdd.cmbDebit2.SelectedIndex = -1
        'FAkunPostingAdd.cmbKredit2.SelectedIndex = -1
        'FAkunPostingAdd.cmbDebit3.SelectedIndex = -1
        'FAkunPostingAdd.cmbKredit3.SelectedIndex = -1
        'FAkunPostingAdd.cmbDebit4.SelectedIndex = -1
        'FAkunPostingAdd.cmbKredit4.SelectedIndex = -1
        FAkunPostingAdd.ClearCombobox()
        FAkunPostingAdd.statmsg.Text = ""
        FAkunPostingAdd.ShowDialog()
    End Sub
    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click
        Try
            If getCountSelectedData() > 0 Then
                FAkunPostingAdd.txtKode.Enabled = False
                FAkunPostingAdd.cmbDebit1.SelectedIndex = -1
                FAkunPostingAdd.cmbKredit1.SelectedIndex = -1
                FAkunPostingAdd.cmbDebit2.SelectedIndex = -1
                FAkunPostingAdd.cmbKredit2.SelectedIndex = -1
                FAkunPostingAdd.cmbDebit3.SelectedIndex = -1
                FAkunPostingAdd.cmbKredit3.SelectedIndex = -1
                FAkunPostingAdd.cmbDebit4.SelectedIndex = -1
                FAkunPostingAdd.cmbKredit4.SelectedIndex = -1
                FAkunPostingAdd.txtKode.Text = CStr(DataGridView1.Rows(getRowIndexSelected()).Cells("mapoid").Value)
                FAkunPostingAdd.txtMapoID.Text = CStr(DataGridView1.Rows(getRowIndexSelected()).Cells("mapoid").Value)
                FAkunPostingAdd.txtNama.Text = CStr(DataGridView1.Rows(getRowIndexSelected()).Cells("maponame").Value)
                FAkunPostingAdd.cmbDebit1.Text = CStr(DataGridView1.Rows(getRowIndexSelected()).Cells("acc_debit").Value)
                FAkunPostingAdd.cmbKredit1.Text = CStr(DataGridView1.Rows(getRowIndexSelected()).Cells("acc_credit").Value)
                FAkunPostingAdd.cmbDebit2.Text = CStr(DataGridView1.Rows(getRowIndexSelected()).Cells("acc_debit2").Value)
                FAkunPostingAdd.cmbKredit2.Text = CStr(DataGridView1.Rows(getRowIndexSelected()).Cells("acc_credit2").Value)
                FAkunPostingAdd.cmbDebit3.Text = CStr(DataGridView1.Rows(getRowIndexSelected()).Cells("acc_debit3").Value)
                FAkunPostingAdd.cmbKredit3.Text = CStr(DataGridView1.Rows(getRowIndexSelected()).Cells("acc_credit3").Value)
                FAkunPostingAdd.cmbDebit4.Text = CStr(DataGridView1.Rows(getRowIndexSelected()).Cells("acc_debit4").Value)
                FAkunPostingAdd.cmbKredit4.Text = CStr(DataGridView1.Rows(getRowIndexSelected()).Cells("acc_credit4").Value)
                FAkunPostingAdd.statmsg.Text = ""
                FAkunPostingAdd.ShowDialog()
            Else
                MyApplication.ShowStatus("No data is selected", NOTICE_STAT)
            End If
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message, NOTICE_STAT)
            ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace, "Error", "2")
        End Try
        

    End Sub
    Private Sub ToolDelete_Click(sender As Object, e As EventArgs) Handles ToolDelete.Click
        If DataGridView1.RowCount > 0 Then
            Dim mapoid(DataGridView1.Rows.Count) As String
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                'delete data
                If DataGridView1.Rows(i).Cells(DGVColumnCheckIndex).FormattedValue = True Then
                    mapoid(i) = DataGridView1.Rows(i).Cells("mapoid").Value
                End If

            Next
            If getCountSelectedData() > 0 Then
                Dim dr As DialogResult = MessageBox.Show("Delete " & getCountSelectedData() & " data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If dr = Windows.Forms.DialogResult.Yes Then
                    'For Each groupid In groupids
                    '    If Not String.IsNullOrEmpty(groupid) Then
                    '        Model.DeleteData(groupid)
                    '    End If
                    'Next
                    Model.MultipleDeleteData(mapoid)
                End If
                'MyApplication.ShowStatus("Deleted " & getCountSelectedData() & " data")
                init()
            Else
                MyApplication.ShowStatus("No data is selected", NOTICE_STAT)
            End If

        End If
    End Sub

    Private Sub ToolFind_Click(sender As Object, e As EventArgs) Handles ToolFind.Click
        Model.startRecord = 0
        'If Not String.IsNullOrEmpty(ToolFind.Text) Then
        RetrieveData(ToolTextFind.Text)
        'Else
        '    RetrieveData()
        'End If
    End Sub
    Private Sub ToolRefresh_Click(sender As Object, e As EventArgs) Handles ToolRefresh.Click
        RetrieveData()
        ToolTextFind.Text = ""
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
                countpage = (ModelRowCount \ Model.limitrecord)
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
    Private Sub cmbperpage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbperPage.SelectedIndexChanged
        If IsNumeric(cmbperPage.Text) Then
            Model.limitrecord = Int(cmbperPage.Text)
        Else
            Model.limitrecord = 0
        End If
        RetrieveData()
    End Sub

    Private Sub FAkunPosting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyApplication.ShowStatus(Me.Text & " Loaded")
        'InitializeDataGridView()
        MyApplication.InitializeDataGridView(DataGridView1)
        init()
    End Sub

    Private Sub FAkunPosting_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        FAkunPosting_Load(Nothing, Nothing)
    End Sub
End Class