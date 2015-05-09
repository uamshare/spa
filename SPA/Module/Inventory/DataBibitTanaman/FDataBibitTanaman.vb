'Imports Excel = Microsoft.Office.Interop.Excel
'Imports Microsoft.Office.Core
Public Class FDataBibitTanaman
    Dim dt As New DataTable
    Dim DGVColumnCheckIndex As Integer
    Dim tinggi As Double = 0

    Private Model As New MBibitTanaman
    Public KeyID As String
    Public Sub init()
        ToolAdd.Enabled = True
        ToolEdit.Enabled = False
        ToolDelete.Enabled = False
        Model.limitrecord = 25
        RetrieveData()
    End Sub
#Region "Format DataGridView"
    Private Sub InitializeDataGridView()

        ' Initialize basic DataGridView properties.
        DataGridViewTanaman.Dock = DockStyle.Fill
        DataGridViewTanaman.BackgroundColor = Color.LightGray
        DataGridViewTanaman.BorderStyle = BorderStyle.Fixed3D

        ' Set property values appropriate for read-only display and  
        ' limited interactivity. 
        DataGridViewTanaman.AllowUserToAddRows = False
        DataGridViewTanaman.AllowUserToDeleteRows = False
        DataGridViewTanaman.AllowUserToOrderColumns = True
        DataGridViewTanaman.ReadOnly = True
        DataGridViewTanaman.SelectionMode = DataGridViewSelectionMode.CellSelect
        DataGridViewTanaman.MultiSelect = False
        DataGridViewTanaman.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        DataGridViewTanaman.AllowUserToResizeColumns = False
        DataGridViewTanaman.ColumnHeadersHeightSizeMode = _
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewTanaman.AllowUserToResizeRows = False
        DataGridViewTanaman.RowHeadersWidthSizeMode = _
            DataGridViewRowHeadersWidthSizeMode.DisableResizing

        ' Set the selection background color for all the cells.
        DataGridViewTanaman.DefaultCellStyle.SelectionBackColor = Color.White
        DataGridViewTanaman.DefaultCellStyle.SelectionForeColor = Color.Black

        ' Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default 
        ' value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
        DataGridViewTanaman.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty

        ' Set the background color for all rows and for alternating rows.  
        ' The value for alternating rows overrides the value for all rows. 
        DataGridViewTanaman.RowsDefaultCellStyle.BackColor = Color.LightGray
        DataGridViewTanaman.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray

        ' Set the row and column header styles.
        DataGridViewTanaman.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        DataGridViewTanaman.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        DataGridViewTanaman.RowHeadersDefaultCellStyle.BackColor = Color.Black

    End Sub
    Private Sub RetrieveData(Optional ByVal sSearch As String = "")
        Dim dt As DataTable
        Try
            If Not String.IsNullOrEmpty(sSearch) Then
                dt = Model.FindData(sSearch)
            Else
                dt = Model.GetData()
            End If
            With DataGridViewTanaman
                .Columns.Clear()
                DGVColumnCheckIndex = .Columns.Add(New DataGridViewCheckBoxColumn)
                .Columns(DGVColumnCheckIndex).Name = "rowchecked"
                .Columns(DGVColumnCheckIndex).HeaderText = ".."
                .Columns(DGVColumnCheckIndex).Width = 35

                .DataSource = dt
                .Columns("mmtrhid").Visible = False
                .Columns("mmtrid").HeaderText = "Kode"
                .Columns("mmtrname").HeaderText = "Jenis Tanaman"
                .Columns("polybag").HeaderText = "Polybag"
                .Columns("mmtrunit").HeaderText = "Satuan"
                .Columns("mmtrprice").HeaderText = "Harga"
                .Columns("PrimaryKey").Visible = False
                .Columns("mmtrg").Visible = False

                '.Columns("groupid").Visible = False
                '.Columns("groupname").HeaderText = "Group Name"
                '.Columns("groupaktive").HeaderText = "Status"

                .RowHeadersWidth = 75
                .Columns("mmtrid").Width = 100
                .Columns("mmtrname").Width = 200
                .Columns("polybag").Width = 75
                .Columns("polybag").DefaultCellStyle().Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("mmtrunit").Width = 100
                .Columns("mmtrprice").Width = 100
                .Columns("mmtrprice").DefaultCellStyle().Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("mmtrprice").DefaultCellStyle().Format = "##,##0"
                .Columns("mmtrprice").ValueType = GetType(Decimal)

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
        For i As Integer = 0 To DataGridViewTanaman.Rows.Count - 1
            'delete data
            If DataGridViewTanaman.Rows(i).Cells(DGVColumnCheckIndex).FormattedValue = True Then
                CountSelected = CountSelected + 1
            End If
        Next
        Return CountSelected
    End Function
    Private Function getRowIndexSelected() As Integer
        Dim index As Integer = -1
        If DataGridViewTanaman.RowCount > 0 Then
            For i As Integer = 0 To DataGridViewTanaman.Rows.Count - 1
                'delete data
                If DataGridViewTanaman.Rows(i).Cells(DGVColumnCheckIndex).FormattedValue = True Then
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
#End Region

    Private Sub FDataBibitTanaman_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MessageBox.Show("Form Load")
        MyApplication.ShowStatus(Me.Text & " Loaded")
        InitializeDataGridView()
        init()
    End Sub

    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click
        If getCountSelectedData() > 0 Then
            FDataBibitTanamanAdd.isEdit = True

            FDataBibitTanamanAdd.txtKode2.Text = "1"
            FDataBibitTanamanAdd.Tunique.Text = "1" & Strings.Right(CStr(DataGridViewTanaman.Rows(getRowIndexSelected()).Cells("mmtrid").Value), 3) & _
                                                CStr(DataGridViewTanaman.Rows(getRowIndexSelected()).Cells("mmtrhid").Value)
            FDataBibitTanamanAdd.txtMmtrhid.Text = CStr(DataGridViewTanaman.Rows(getRowIndexSelected()).Cells("mmtrhid").Value)
            FDataBibitTanamanAdd.txtJnsTanaman.Text = CStr(DataGridViewTanaman.Rows(getRowIndexSelected()).Cells("mmtrname").Value)
            FDataBibitTanamanAdd.txtKeyID1.Text = CStr(DataGridViewTanaman.Rows(getRowIndexSelected()).Cells("PrimaryKey").Value)
            FDataBibitTanamanAdd.txtMmtrg1.Text = CStr(DataGridViewTanaman.Rows(getRowIndexSelected()).Cells("mmtrg").Value)
            FDataBibitTanamanAdd.cmbPolybag.Text = CStr(DataGridViewTanaman.Rows(getRowIndexSelected()).Cells("polybag").Value)
            FDataBibitTanamanAdd.txtKode.Text = Strings.Left(CStr(DataGridViewTanaman.Rows(getRowIndexSelected()).Cells("mmtrid").Value), 5)

            FDataBibitTanamanAdd.txtKode3.Text = Strings.Right(CStr(DataGridViewTanaman.Rows(getRowIndexSelected()).Cells("mmtrid").Value), 3)
            FDataBibitTanamanAdd.txtHarga.Text = Format(DataGridViewTanaman.Rows(getRowIndexSelected()).Cells("mmtrprice").Value, "##,##0")
            FDataBibitTanamanAdd.txtSatuan.Text = CStr(DataGridViewTanaman.Rows(getRowIndexSelected()).Cells("mmtrunit").Value)
            FDataBibitTanamanAdd.txtKeyID2.Text = Strings.Left(CStr(DataGridViewTanaman.Rows(getRowIndexSelected()).Cells("mmtrid").Value), 5) + "2" + Strings.Right(CStr(DataGridViewTanaman.Rows(getRowIndexSelected()).Cells("mmtrid").Value), 3) + "2"
            FDataBibitTanamanAdd.ShowDialog()
        Else
            MyApplication.ShowStatus("No data is selected", NOTICE_STAT)
        End If
    End Sub

    Private Sub ToolAdd_Click(sender As Object, e As EventArgs) Handles ToolAdd.Click
        FDataBibitTanamanAdd.txtJnsTanaman.Clear()
        FDataBibitTanamanAdd.cmbPolybag.Text = ""
        FDataBibitTanamanAdd.txtKode.Clear()
        FDataBibitTanamanAdd.txtKode3.Clear()
        FDataBibitTanamanAdd.txtSatuan.Clear()
        FDataBibitTanamanAdd.txtHarga.Clear()
        FDataBibitTanamanAdd.txtKeyID1.Clear()
        FDataBibitTanamanAdd.txtHarga.Text = 0
        FDataBibitTanamanAdd.isEdit = False
        FDataBibitTanamanAdd.cmbPolybag.SelectedIndex = -1
        FDataBibitTanamanAdd.ShowDialog()
    End Sub

    Private Sub ToolDelete_Click(sender As Object, e As EventArgs) Handles ToolDelete.Click
        If DataGridViewTanaman.RowCount > 0 Then
            Dim GetKey1(DataGridViewTanaman.Rows.Count) As String
            Dim GetKey2(DataGridViewTanaman.Rows.Count) As String
            For i As Integer = 0 To DataGridViewTanaman.Rows.Count - 1
                'delete data
                If DataGridViewTanaman.Rows(i).Cells(DGVColumnCheckIndex).FormattedValue = True Then
                    GetKey1(i) = DataGridViewTanaman.Rows(i).Cells("PrimaryKey").Value
                    GetKey2(i) = Strings.Left(CStr(DataGridViewTanaman.Rows(i).Cells("mmtrid").Value), 5) + "2" + _
                                Strings.Right(CStr(DataGridViewTanaman.Rows(i).Cells("mmtrid").Value), 3) + "2"
                End If

            Next
            If getCountSelectedData() > 0 Then
                Dim dr As DialogResult = MessageBox.Show("Delete " & getCountSelectedData() & " data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If dr = Windows.Forms.DialogResult.Yes Then
                    Model.MultipleDeleteData1(GetKey1)
                    Model.MultipleDeleteData1(GetKey2)
                    'Model.MultipleDeleteData2(GetKey2)
                End If
                MyApplication.ShowStatus("Deleted " & getCountSelectedData() & " data")
                init()
            Else
                MyApplication.ShowStatus("No data is selected", NOTICE_STAT)
            End If

        End If
    End Sub

    Private Sub ToolFind_Click(sender As Object, e As EventArgs) Handles ToolFind.Click
        Model.startRecord = 0
        RetrieveData(ToolTextFind.Text)
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

    Private Sub DataGridViewTanaman_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewTanaman.CellContentClick
        If DGVColumnCheckIndex = e.ColumnIndex Then
            If e.RowIndex > -1 Then
                DataGridViewTanaman.Rows(e.RowIndex).Cells(DGVColumnCheckIndex).Value = Not DataGridViewTanaman.Rows(e.RowIndex).Cells(DGVColumnCheckIndex).FormattedValue
            Else
                DataGridViewTanaman.ClearSelection()
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
    Private Sub DataGridViewTanaman_Sorted(sender As Object, e As EventArgs) Handles DataGridViewTanaman.Sorted
        With DataGridViewTanaman
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

    Private Sub FDataBibitTanaman_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        FDataBibitTanaman_Load(Nothing, Nothing)
    End Sub

    Private Sub ToolRefresh_Click(sender As Object, e As EventArgs) Handles ToolRefresh.Click
        RetrieveData()
        ToolTextFind.Text = ""
    End Sub

    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles toolImport.Click
        Try
            Dim xlApp As Microsoft.Office.Interop.Excel.Application
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            Dim i As Integer
            Dim j As Integer

            xlApp = New Microsoft.Office.Interop.Excel.Application
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")


            For i = 1 To DataGridViewTanaman.RowCount - 2
                For j = 1 To DataGridViewTanaman.ColumnCount - 3
                    For k As Integer = 1 To DataGridViewTanaman.Columns.Count - 3
                        xlWorkSheet.Cells(2, k) = DataGridViewTanaman.Columns(k - 0).HeaderText
                        xlWorkSheet.Cells(i + 2, j + 0) = DataGridViewTanaman(j, i).Value.ToString()
                    Next
                Next
            Next

            xlWorkSheet.SaveAs("D:\DataTanaman.xlsx")
            xlWorkBook.Close()
            'xlApp.Quit()

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)

            MsgBox("Hasil export tersimpan di D:\DataTanaman.xlsx")
            Process.Start("D:\DataTanaman.xlsx")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try

    End Sub
End Class