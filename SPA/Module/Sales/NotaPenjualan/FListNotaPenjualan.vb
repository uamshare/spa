Public Class FListNotaPenjualan
    Dim dt As New DataTable
    Dim DGVColumnCheckIndex As Integer

    Private Model As New MNotaPenjualanH
    'Public DatagridParent As DataGridView
    Private ModelRowCount As Integer = Model.GetRowsCount()
    Public Sub init()
        Model.limitrecord = 25
        RetrieveData()
        'DataGridView1.ClearSelection()
    End Sub
    Private Sub FListTanaman_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = 900
        Me.Height = 500
        MyApplication.InitializeDataGridView(DataGridView1)

        init()
    End Sub
    Private Sub FListTanaman_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        init()
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

                .DataSource = dt
                .Columns("userid").Visible = False
                .Columns("dtcreated").Visible = False
                .Columns("tinvhno").HeaderText = "No Invoice"
                .Columns("tinvhdt").HeaderText = "Tanggal"
                .Columns("mcusid").HeaderText = "Customer ID"
                .Columns("mcusid").Visible = False
                .Columns("mcusname").HeaderText = "Customer"
                .Columns("tinvhnote").HeaderText = "Keterangan"
                .Columns("subtotal").HeaderText = "Subtotal"
                .Columns("tinvhdisc1").HeaderText = "Disc%"
                .Columns("tinvhdisc2").HeaderText = "Diskon"
                '.Columns("tinvhbonus").HeaderText = "Bonus"
                .Columns("tinvhongkir").HeaderText = "Kirim"
                .Columns("tinvhongpack").HeaderText = "Pascking"
                .Columns("total").HeaderText = "Bonus"
                .Columns("tinvhdisc1").Visible = False
                .Columns("tinvhnote").Visible = False


                .RowHeadersWidth = 75
                .Columns("tinvhno").Width = 110
                .Columns("tinvhdt").Width = 100
                .Columns("tinvhdt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("tinvhdt").DefaultCellStyle.Format = MyApplication.DefaultFormatDate
                .Columns("mcusname").Width = 200
                .Columns("subtotal").Width = 100
                .Columns("tinvhdisc1").Width = 50
                .Columns("tinvhdisc2").Width = 80
                '.Columns("tinvhbonus").Width = 80
                .Columns("tinvhongkir").Width = 80
                .Columns("tinvhongpack").Width = 80
                .Columns("total").Width = 100
                .Columns("subtotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("subtotal").DefaultCellStyle.Format = "##,##0"
                .Columns("tinvhdisc1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("tinvhdisc1").DefaultCellStyle.Format = "##,##0"
                .Columns("tinvhdisc2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("tinvhdisc2").DefaultCellStyle.Format = "##,##0"
                '.Columns("tinvhbonus").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.Columns("tinvhbonus").DefaultCellStyle.Format = "##,##0"
                .Columns("tinvhongkir").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("tinvhongkir").DefaultCellStyle.Format = "##,##0"
                .Columns("tinvhongpack").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("tinvhongpack").DefaultCellStyle.Format = "##,##0"
                .Columns("total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("total").DefaultCellStyle.Format = "##,##0"
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
            MyApplication.ShowStatus("Gagal menampilkan data = " & ex.Message, WARNING_STAT)
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
            If DataGridView1.SelectedRows.Count > 0 Then
                FNotaPenjualan.TxtNo.Text = DataGridView1.CurrentRow.Cells("tinvhno").Value().ToString
                FNotaPenjualan.DateTimePicker1.Value = DataGridView1.CurrentRow.Cells("tinvhdt").Value().ToString
                FNotaPenjualan.TextBox1.Text = DataGridView1.CurrentRow.Cells("tinvhnote").Value().ToString
                FNotaPenjualan.ComboBox1.Text = DataGridView1.CurrentRow.Cells("mcusname").Value().ToString

                FNotaPenjualan.TextBox9.Text = CInt(DataGridView1.CurrentRow.Cells("tinvhdisc1").Value().ToString) & "%"
                FNotaPenjualan.TextBox5.Text = Format(CDec(DataGridView1.CurrentRow.Cells("tinvhdisc2").Value().ToString), "##,##0")
                'FNotaPenjualan.TextBox6.Text = Format(CDec(DataGridView1.CurrentRow.Cells("tinvhbonus").Value().ToString), "##,##0")
                FNotaPenjualan.TextBox7.Text = Format(CDec(DataGridView1.CurrentRow.Cells("tinvhongkir").Value().ToString), "##,##0")
                FNotaPenjualan.TextBox8.Text = Format(CDec(DataGridView1.CurrentRow.Cells("tinvhongpack").Value().ToString), "##,##0")

                FNotaPenjualan.ButtonAdd.Enabled = False
                FNotaPenjualan.ButtonSave.Enabled = True
                FNotaPenjualan.ButtonDel.Enabled = True
                FNotaPenjualan.ButtonPrint.Enabled = False
                FNotaPenjualan.ButtonCancel.Enabled = True
                FNotaPenjualan.ButtonH.Enabled = True

                FNotaPenjualan.DataGridView1.Enabled = True
                FNotaPenjualan.ToolDelete.Enabled = True
                FNotaPenjualan.TextBox1.Focus()
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
                cmbperpage.Text = Model.limitrecord
                'page = IIf(Model.startRecord = 0, 0, Model.startRecord / Model.limitrecord) + 1
                CurrentCountRows = IIf((Model.startRecord + Model.limitrecord) > ModelRowCount, ModelRowCount, (Model.startRecord + Model.limitrecord))
                'lpageinfo.Text = "Page " & page & " of " & (ModelRowCount \ Model.limitrecord) & " as " & ModelRowCount & " Records"

            Else
                ToolFisrt.Enabled = False
                ToolPrev.Enabled = False
                ToolNext.Enabled = False
                ToolLast.Enabled = False
                page = 1
                cmbperpage.Text = "All"
            End If

            'Navigator Info
            lpageinfo.Text = (Model.startRecord + 1) & "-" & CurrentCountRows & " as " & ModelRowCount & " Rows"
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
    End Sub

    Private Sub cmbperPage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbperpage.SelectedIndexChanged
        If IsNumeric(cmbperpage.Text) Then
            Model.limitrecord = Int(cmbperpage.Text)
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
        RetrieveData(ToolTextFind.Text)
    End Sub
#End Region
    Private Sub ToolCheck_Click(sender As Object, e As EventArgs) Handles ToolCheck.Click
        DataGridView1_CellContentDoubleClick(sender, Nothing)
    End Sub
End Class