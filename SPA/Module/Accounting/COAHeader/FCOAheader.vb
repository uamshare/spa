Public Class FCOAheader
    Dim dt As New DataTable
    Dim DGVColumnCheckIndex As Integer

    Private Model As New MCOAheader
    Private ModelRowCount As Integer = Model.GetRowsCount()
    Public Sub SetPrivileges()
        Try
            ToolAdd.Visible = MUsers.UserListMenuPrivileges()(MainForm.MenuActive)("pcreate")
            ToolEdit.Visible = MUsers.UserListMenuPrivileges()(MainForm.MenuActive)("pupdate")
            'ToolSaveMenuAkses.Visible = MUsers.UserListMenuPrivileges()(MainForm.MenuActive)("pupdate")
            ToolDelete.Visible = MUsers.UserListMenuPrivileges()(MainForm.MenuActive)("pdelete")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub init()
        SetPrivileges()
        ToolAdd.Enabled = True
        ToolEdit.Enabled = False
        ToolDelete.Enabled = False
        Model.limitrecord = 25
        RetrieveData()
    End Sub
#Region "Format DataGridView"

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
                .Columns("mcoahno").HeaderText = "No Akun"
                .Columns("mcoahname").HeaderText = "Nama Akun"
                .Columns("mcoaclassification").HeaderText = "Klasifikasi"
                .Columns("mcoagroup").HeaderText = "Group"
                .Columns("postbalance").HeaderText = "Posisi Saldo"
                .Columns("postgl").HeaderText = "Posisi Laporan"

                .RowHeadersWidth = 75
                .ColumnHeadersHeight = 50
                .Columns("mcoahno").Width = 100
                .Columns("mcoahname").Width = 360
                .Columns("mcoaclassification").Width = 250
                .Columns("mcoagroup").Width = 130
                .Columns("postbalance").Width = 75
                .Columns("postbalance").DefaultCellStyle().Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("postgl").Width = 75
                .Columns("postgl").DefaultCellStyle().Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("mcoacid").Visible = False
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
        FCOAheaderAdd.KeyID.Clear()
        FCOAheaderAdd.txtNo.Clear()
        FCOAheaderAdd.txtNama.Clear()
        FCOAheaderAdd.txtCoaId.Clear()
        FCOAheaderAdd.txtKlasifikasi.Clear()
        FCOAheaderAdd.cmbSaldo.SelectedIndex = -1
        FCOAheaderAdd.cmbLaporan.SelectedIndex = -1
        FCOAheaderAdd.statmsg.Text = ""
        FCOAheaderAdd.ShowDialog()
    End Sub
    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click
        If getCountSelectedData() > 0 Then
            FCOAheaderAdd.KeyID.Text = CStr(DataGridView1.Rows(getRowIndexSelected()).Cells("mcoahno").Value)
            FCOAheaderAdd.txtNo.Text = CStr(DataGridView1.Rows(getRowIndexSelected()).Cells("mcoahno").Value)
            FCOAheaderAdd.txtNama.Text = CStr(DataGridView1.Rows(getRowIndexSelected()).Cells("mcoahname").Value)
            FCOAheaderAdd.txtKlasifikasi.Text = CStr(DataGridView1.Rows(getRowIndexSelected()).Cells("mcoaclassification").Value)
            FCOAheaderAdd.cmbSaldo.Text = CStr(DataGridView1.Rows(getRowIndexSelected()).Cells("postbalance").Value)
            FCOAheaderAdd.cmbLaporan.Text = CStr(DataGridView1.Rows(getRowIndexSelected()).Cells("postgl").Value)
            FCOAheaderAdd.txtCoaId.Text = CInt(DataGridView1.Rows(getRowIndexSelected()).Cells("mcoacid").Value)
            FCOAheaderAdd.statmsg.Text = ""
            FCOAheaderAdd.ShowDialog()
        Else
            MyApplication.ShowStatus("No data is selected", NOTICE_STAT)
        End If

    End Sub
    Private Sub ToolDelete_Click(sender As Object, e As EventArgs) Handles ToolDelete.Click
        If DataGridView1.RowCount > 0 Then
            Dim mcoahno(DataGridView1.Rows.Count) As String
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                'delete data
                If DataGridView1.Rows(i).Cells(DGVColumnCheckIndex).FormattedValue = True Then
                    mcoahno(i) = DataGridView1.Rows(i).Cells("mcoahno").Value
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
                    Model.MultipleDeleteData(mcoahno)
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
    Private Sub FCOAheader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyApplication.ShowStatus(Me.Text & " Loaded")
        MyApplication.InitializeDataGridView(DataGridView1)
        init()
    End Sub

    Private Sub FCOAheader_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        FCOAheader_Load(Nothing, Nothing)
    End Sub
End Class