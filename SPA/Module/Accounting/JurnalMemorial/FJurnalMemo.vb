Public Class FJurnalMemo
    Private ModelH As New MJurnalMemoH
    Private ModelD As New MJurnalMemoD
    Private ModelM As New MCOADetail

    Public ListDataCOA As List(Of Dictionary(Of String, Object)) = ModelM.GetDataList
    Private isEdit As Boolean = False
    Public Sub init()
        Me.isEdit = False
        ClearControll()
        NonActiveControll()
        RetriveDataGrid()
    End Sub
    Private Sub NonActiveControll(Optional eachcontrol As Control = Nothing)
        For Each ctrl As Control In PanelHeader.Controls
            If (ctrl.GetType() Is GetType(TextBox)) Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                txt.Enabled = False
            End If
        Next
        For Each ctrl As Control In PanelFooter.Controls
            If (ctrl.GetType() Is GetType(TextBox)) Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                txt.Enabled = False
            End If
        Next
        DateTimePicker1.Enabled = False
        ButtonAdd.Enabled = True
        ButtonSave.Enabled = False
        ButtonDel.Enabled = False
        ButtonPrint.Enabled = False
        ButtonCancel.Enabled = False
        ButtonH.Enabled = True
        DataGridView1.EndEdit()
        DataGridView1.Rows.Clear()
        DataGridView1.Enabled = False
        ToolDelete.Enabled = False
    End Sub
    Private Sub ActiveControll(Optional eachcontrol As Control = Nothing)
        For Each ctrl As Control In PanelHeader.Controls
            If (ctrl.GetType() Is GetType(TextBox)) Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                txt.Enabled = True
            End If
        Next
        For Each ctrl As Control In PanelFooter.Controls
            If (ctrl.GetType() Is GetType(TextBox)) Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                txt.Enabled = True
            End If
        Next
        DateTimePicker1.Enabled = True
    End Sub
    Private Sub ClearControll(Optional eachcontrol As Control = Nothing)
        For Each ctrl As Control In PanelHeader.Controls
            If (ctrl.GetType() Is GetType(TextBox)) Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                txt.Text = ""
            End If
        Next
        TextBox1.Text = ""
        txtsumdebet.Text = "0"
        txtsumcredit.Text = "0"
        txtsumdebet.Text = "0"
        DateTimePicker1.Value = Format(Date.Now)
    End Sub

#Region "Format DataGridView"
    Private Sub RetriveDataGrid()
        With DataGridView1
            .Columns.Clear()
            .ColumnHeadersHeight = 35
            .RowHeadersWidth = 50
            .Columns.Add(New DataGridViewCheckBoxColumn)
            .Columns(0).Name = "rowchecked"
            .Columns(0).HeaderText = ".."
            .Columns(0).Width = 35

            .Columns.Add(New DataGridViewTextBoxColumn())
            .Columns(1).Name = "tjmdid"
            .Columns(1).HeaderText = "ID"
            .Columns(1).Visible = False

            Dim txtcode = New DataGridViewTextBoxColumn()
            txtcode.Name = "txtcode"
            .Columns.Add(txtcode)
            .Columns(2).Name = "mcoadno"
            .Columns(2).HeaderText = "No Akun"

            Dim btn As New DataGridViewButtonColumn()
            DataGridView1.Columns.Add(btn)
            btn.HeaderText = ""
            btn.Text = "..."
            btn.Name = "btnmcoadno"
            btn.UseColumnTextForButtonValue = True
            btn.Width = 35
            btn.ToolTipText = "Press F4"

            .Columns.Add(New DataGridViewTextBoxColumn())
            .Columns(4).Name = "mcoadname"
            .Columns(4).HeaderText = "Nama Akun"

            .Columns.Add(New DataGridViewTextBoxColumn())
            .Columns(5).Name = "tjmddesc"
            .Columns(5).HeaderText = "keterangan"
            .Columns(5).Visible = False

            .Columns.Add(New DataGridViewTextBoxColumn())
            .Columns(6).Name = "debet"
            .Columns(6).HeaderText = "Debet"

            .Columns.Add(New DataGridViewTextBoxColumn())
            .Columns(7).Name = "kredit"
            .Columns(7).HeaderText = "Kredit"

            .Columns.Add(New DataGridViewTextBoxColumn())
            .Columns(8).Name = "dtcreated"
            .Columns(8).HeaderText = "Date Created"
            .Columns("dtcreated").Visible = False

            With .Columns("dtcreated")
                .Width = 120
                .DefaultCellStyle().Alignment = 64 'DataGridViewContentAlignment.MiddleRight
                .HeaderCell.Style.Alignment = 64
                .DefaultCellStyle().Format = "yyyy/MM/dd H:mm:ss"
                .ValueType = GetType(Date)
            End With

            With .Columns("mcoadno")
                .Width = 100
                '.ToolTipText = "press F4"
            End With

            .Columns("mcoadname").Width = 350
            .Columns("tjmddesc").Width = 75
            .Columns("tjmddesc").DefaultCellStyle.Alignment = 32 'DataGridViewContentAlignment.MiddleCenter

            With .Columns("debet")
                .Width = 100
                .DefaultCellStyle().Alignment = 64 'DataGridViewContentAlignment.MiddleRight
                .HeaderCell.Style.Alignment = 64
                .DefaultCellStyle().Format = "##,000"
                .ValueType = GetType(Decimal)
            End With

            With .Columns("kredit")
                .Width = 100
                .DefaultCellStyle().Alignment = 64 'DataGridViewContentAlignment.MiddleRight
                .HeaderCell.Style.Alignment = 64
                .DefaultCellStyle().Format = "##,000"
                .ValueType = GetType(Decimal)
            End With
        End With
        DataGridView1.ReadOnly = False
        For Each dgvc As DataGridViewColumn In DataGridView1.Columns
            dgvc.ReadOnly = True
        Next
        DataGridView1.Columns("rowchecked").ReadOnly = False
        DataGridView1.Columns("mcoadno").ReadOnly = False
        DataGridView1.Columns("debet").ReadOnly = False
        DataGridView1.Columns("kredit").ReadOnly = False
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            If e.RowIndex > -1 And e.ColumnIndex > -1 Then
                If DataGridView1.Columns(e.ColumnIndex).Name = "btnmcoadno" Then
                    If DataGridView1.CurrentRow.IsNewRow Then
                        DataGridView1.Rows.Add()
                        DataGridView1.CurrentCell = DataGridView1(e.ColumnIndex, e.RowIndex)
                    End If
                    FlistCoa.DatagridParent = DataGridView1
                    FlistCoa.ShowDialog(Me)
                End If
            End If
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
        End Try
    End Sub
    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        Try
            Dim showdata As Boolean = False
            If e.KeyCode = Keys.F4 Then
                showdata = True
            End If
            If showdata Then
                If DataGridView1.CurrentRow.IsNewRow Then
                    DataGridView1.Rows.Add()
                    DataGridView1.CurrentCell = DataGridView1("btnmcoadno", DataGridView1.CurrentRow.Index - 1)
                End If
                FlistCoa.DatagridParent = DataGridView1
                FlistCoa.ShowDialog(Me)
            End If
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
        End Try
    End Sub
    Private Sub DataGridView1_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellLeave
        DataGridView1_CellValueChanged(sender, e)
    End Sub
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Try
            If e.RowIndex > -1 And e.ColumnIndex > -1 Then
                If {"debet", "kredit"}.Contains(DataGridView1.Columns(e.ColumnIndex).Name) Then
                    Dim jml, debet, kredit As Decimal
                    'Dim hpp,oldhpp As Decimal
                    debet = CDec(DataGridView1.Rows(e.RowIndex).Cells("debet").Value)
                    kredit = CDec(DataGridView1.Rows(e.RowIndex).Cells("kredit").Value)
                    jml = debet * kredit

                    Dim cvalue = Format(CDec(DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "##,##0")
                    DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = cvalue
                    'DataGridView1.Rows(e.RowIndex).Cells("subtotal").Value = Format(jml, "##,##0")
                    SetSummaryField()
                ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "mcoadno" Then
                    If DataGridView1.Rows(e.RowIndex).Cells("mcoadno").Value = mcoadnobefore Then Exit Sub

                    If CekDuplicateID(DataGridView1.Rows(e.RowIndex).Cells("mcoadno").Value, e.RowIndex) Then
                        For Each dat In ListDataCOA
                            If dat("mcoadno") = DataGridView1.Rows(e.RowIndex).Cells("mcoadno").Value Then
                                DataGridView1.Rows(e.RowIndex).Cells("mcoadname").Value = dat("mcoadname") 'ListDataCOA(1)("mmtrname")
                            End If
                        Next
                    Else
                        DataGridView1.Rows(e.RowIndex).Cells("mcoadno").Value = ""
                        DataGridView1.Rows(e.RowIndex).Cells("mcoadname").Value = ""
                        DataGridView1.Rows(e.RowIndex).Cells("tjmddesc").Value = ""
                        DataGridView1.Rows(e.RowIndex).Cells("kredit").Value = 0
                        DataGridView1.Rows(e.RowIndex).Cells("debet").Value = 0
                        DataGridView1.CurrentCell = DataGridView1("mcoadno", e.RowIndex)
                        DataGridView1.CancelEdit()
                    End If
                End If
            End If
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
        End Try
    End Sub
    Private Sub SetSummaryField()
        Dim sumdebit As Decimal = 0
        Dim sumcredit As Decimal = 0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not row.IsNewRow Then
                Dim debet As Decimal = CDec(row.Cells("debet").Value)
                Dim credit As Decimal = CDec(row.Cells("kredit").Value)

                sumdebit = sumdebit + debet
                sumcredit = sumcredit + credit
            End If
        Next
        txtsumdebet.Text = Format(sumdebit, "##,##0")
        txtsumcredit.Text = Format(sumcredit, "##,##0")
    End Sub
    Private Function CekDuplicateID(mcoadno As String, rowindex As Integer) As Boolean
        Try
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells("mcoadno").Value = mcoadno _
                    And Not String.IsNullOrEmpty(mcoadno) _
                    And row.Index <> rowindex _
                    And Not row.IsNewRow Then

                    MyApplication.ShowStatus("Kode sudah ada, silahkan pilih kode yang lain.", NOTICE_STAT)
                    Return False
                End If
            Next
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
        End Try

        Return True
    End Function
    Private Sub DataGridView1_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        MyApplication.ShowStatus("Silahkan masukan angka.", WARNING_STAT)
    End Sub

    Private WithEvents txtNumeric As New DataGridViewTextBoxEditingControl
    'Private WithEvents CellText As New DataGridViewTextBoxEditingControl
    'Private WithEvents BtnView As New DataGridViewTextBoxEditingControl

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        Try
            txtNumeric = Nothing
            If {"debet", "kredit", "mcoadno"}.Contains(DataGridView1.Columns(DataGridView1.CurrentCell.ColumnIndex).Name) Then
                txtNumeric = CType(DataGridView1.EditingControl, DataGridViewTextBoxEditingControl)
            End If
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
        End Try
    End Sub
    Private Sub DataGridView1_AutoComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        Dim titleText As String = DataGridView1.Columns(DataGridView1.CurrentCell.ColumnIndex).HeaderText
        Dim autoText As TextBox = TryCast(e.Control, TextBox)
        
        If titleText.Equals("No Akun") Then
            If autoText IsNot Nothing Then
                autoText.AutoCompleteMode = AutoCompleteMode.Suggest
                autoText.AutoCompleteSource = AutoCompleteSource.CustomSource
                Dim DataCollection As New AutoCompleteStringCollection()
                addItems(DataCollection)
                autoText.AutoCompleteCustomSource = DataCollection
            End If
        Else
            autoText.AutoCompleteMode = AutoCompleteMode.None
        End If
    End Sub
    Public Sub addItems(ByRef col As AutoCompleteStringCollection)
        Try
            For Each dat In ListDataCOA
                col.Add(dat("mcoadno"))
            Next
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
        End Try
    End Sub
    Private Sub txtNumeric_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtNumeric.KeyPress
        e.Handled = MyApplication.ValidNumber(e)
    End Sub
 
    Private rowIndex As Integer = 0
    Private mcoadnobefore As String = ""
    Private Sub DataGridView1_CellMouseUp_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseUp
        If e.RowIndex > -1 And e.ColumnIndex > -1 Then
            mcoadnobefore = DataGridView1.Rows(e.RowIndex).Cells("mcoadno").Value
            If e.Button = MouseButtons.Right Then
                Me.DataGridView1.Rows(e.RowIndex).Selected = True
                Me.rowIndex = e.RowIndex
                Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(e.RowIndex).Cells(1)
                If DataGridView1.Rows(Me.rowIndex).Cells("tjmdtype").Value Then
                    BonusToolStripMenuItem.Text = "Urungkan Bonus"
                Else
                    BonusToolStripMenuItem.Text = "Tandai Bonus"
                End If

                Me.ContextMenuStrip1.Show(Me.DataGridView1, e.Location)
                ContextMenuStrip1.Show(Cursor.Position)
            End If
        End If
    End Sub
    Private Sub BonusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BonusToolStripMenuItem.Click
        DataGridView1.Rows(Me.rowIndex).Cells("tjmdtype").Value = Not DataGridView1.Rows(Me.rowIndex).Cells("tjmdtype").Value
    End Sub
    Private Sub HapusDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HapusDataToolStripMenuItem.Click
        If Not Me.DataGridView1.Rows(Me.rowIndex).IsNewRow Then
            Me.DataGridView1.Rows.RemoveAt(Me.rowIndex)
        End If
    End Sub
    Private Sub ToolDelete_Click(sender As Object, e As EventArgs) Handles ToolDelete.Click
        Try
            DataGridView1.EndEdit()
            Dim indexrow As Integer = 0
            For i As Integer = 0 To (DataGridView1.Rows.Count - 1)
                'delete data
                If Not DataGridView1.Rows(indexrow).IsNewRow Then
                    If DataGridView1.Rows(indexrow).Cells("rowchecked").FormattedValue = True Then
                        DataGridView1.Rows.RemoveAt(DataGridView1.Rows(indexrow).Index)
                    Else
                        indexrow = indexrow + 1
                    End If
                End If

            Next
            SetSummaryField()
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
        End Try
    End Sub
    Private Sub DataGridView1_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.RowValidated
        If Not DataGridView1.Rows(e.RowIndex).IsNewRow Then
            DataGridView1.Rows(e.RowIndex).HeaderCell.Value = (e.RowIndex + 1).ToString '(e.RowIndex + ModelH.startRecord + 1).ToString
        End If
    End Sub
    Private Sub DataGridView1_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        For Each row In DataGridView1.Rows
            If Not row.IsNewRow Then
                row.HeaderCell.Value = (row.index + 1).ToString '(e.RowIndex + ModelH.startRecord + 1).ToString
            End If
        Next
    End Sub
#End Region
    Private Sub FJurnalMemo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = MyApplication.DefaultFormatDate

        InitializeDataGridView(DataGridView1)
        DataGridView1.AllowUserToAddRows = True
        DataGridView1.AllowUserToDeleteRows = True
        DataGridView1.AllowUserToOrderColumns = True
        DataGridView1.ReadOnly = False

        Dim ModelP As New MDataPelanggan
        ModelP.limitrecord = -1


        Dim discCollection As New AutoCompleteStringCollection()
        For i As Integer = 5 To 50 Step 5
            discCollection.Add(i)
        Next
        init()
        'MessageBox.Show(Format(Date.Now, "yyyy/MM/dd H:mm:ss"))
    End Sub
    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        ClearControll()
        ActiveControll()
        ButtonAdd.Enabled = False
        ButtonSave.Enabled = True
        ButtonDel.Enabled = False
        ButtonPrint.Enabled = False
        ButtonCancel.Enabled = True
        ButtonH.Enabled = False

        DataGridView1.Enabled = True
        ToolDelete.Enabled = True
        TxtNo.Text = ModelH.getAutoNo
        TextBox1.Focus()
        isEdit = False
        'ListDataCOA = ModelM.GetDataList(DateTimePicker1.Value)
    End Sub
    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        Dim Formvalid As Boolean = True
        'If DateTimePicker1.Value = "" Then
        '    MyApplication.ShowStatus("Tanggal Invoice harus diisi", WARNING_STAT)
        '    DateTimePicker1.Focus()
        '    Formvalid = False
        'End If
        If TxtNo.Text = "" Then
            MyApplication.ShowStatus("No Jurnal harus diisi", NOTICE_STAT)
            TxtNo.Focus()
            Formvalid = False
        End If
        If TextBox1.Text = "" Then
            MyApplication.ShowStatus("Keterangan harus diisi", NOTICE_STAT)
            TxtNo.Focus()
            Formvalid = False
        End If
        If DataGridView1.Rows.Count <= 1 Then
            MyApplication.ShowStatus("Data Jurnal belum diisi", NOTICE_STAT)
            DataGridView1.Select()
            DataGridView1.Focus()
            Formvalid = False
        End If
        If CDec(txtsumdebet.Text) <> CDec(txtsumcredit.Text) Then
            MyApplication.ShowStatus("Jumlah debet dan kredit harus sama", NOTICE_STAT)
            DataGridView1.Select()
            DataGridView1.Focus()
            Formvalid = False
        End If

        If Formvalid Then
            ModelD.tjmhno = ModelH.EscapeString(TxtNo.Text)
            ModelD.tjmhdt = ModelH.EscapeString(Format(DateTimePicker1.Value, "yyyy/MM/dd"))
            ModelD.tjmhdesc = ModelH.EscapeString(TextBox1.Text)

            'ModelD.soldvalue = ModelH.EscapeString(txtsumdebet.Text) 'for posting to General Ledger Sold kredit
            'ModelD.bookvalue = ModelH.EscapeString(txtsumcredit.Text) 'for posting to General Ledger bookValue

            Dim ListDetail As New List(Of Dictionary(Of String, Object))
            For Each row In DataGridView1.Rows
                Dim dict As New Dictionary(Of String, Object)
                If Not row.IsNewRow Then
                    Dim FormDvalid = True

                    If Not String.IsNullOrEmpty(row.Cells("mcoadno").Value.ToString) And _
                        CDec(row.Cells("debet").Value) <= 0 And _
                        (CDec(row.Cells("kredit").Value) <= 0) Then
                        FormDvalid = False
                        MyApplication.ShowStatus("Kombinasi debet dan kredit tidak boleh '0', silahkan isi salah satu kolom debet/kredit", NOTICE_STAT)
                        Exit Sub
                    End If

                    If FormDvalid Then
                        dict.Add("tjmhno", ModelH.tjmhno)
                        dict.Add("mcoadno", row.Cells("mcoadno").Value)
                        dict.Add("debet", CDec(row.Cells("debet").Value))
                        dict.Add("kredit", CDec(row.Cells("kredit").Value))
                        'dict.Add("tjmddesc", row.Cells("tjmddesc").Value.ToString)
                        dict.Add("dtcreated", row.Cells("dtcreated").FormattedValue)
                        ListDetail.Add(dict)
                    End If

                End If
            Next

            If isEdit Then
                ModelD.UpdateData(ListDetail)
                'ModelD.DeleteByNo(ModelH.tjmhno)
            Else
                'ModelH.InsertData()
                ModelD.InsertData(ListDetail)
            End If
            init()
            txtsumdebet.Text = ""
            txtsumcredit.Text = ""
        End If
    End Sub
    Private Sub ButtonDel_Click(sender As Object, e As EventArgs) Handles ButtonDel.Click
        Dim dr As DialogResult = MessageBox.Show("Anda yakin akan menghpuas data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dr = Windows.Forms.DialogResult.Yes Then
            ModelD.DeleteData(ModelH.EscapeString(TxtNo.Text))
            init()
        End If
    End Sub
    Private Sub ButtonPrint_Click(sender As Object, e As EventArgs) Handles ButtonPrint.Click

    End Sub
    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        init()
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
    End Sub
    Private Sub ButtonH_Click(sender As Object, e As EventArgs) Handles ButtonH.Click
        Me.isEdit = True
        FListJurnalMemo.ShowDialog()
    End Sub
    Private Sub TxtNo_TextChanged(sender As Object, e As EventArgs) Handles TxtNo.TextChanged
        If isEdit Then
            ActiveControll()
            Dim ListDetail As List(Of Dictionary(Of String, Object)) = ModelD.GetDataList(TxtNo.Text)
            DataGridView1.Rows.Clear()
            'MsgBox(ListDetail.Count)
            If ListDetail.Count > 0 Then
                Dim rowindex As Integer = DataGridView1.NewRowIndex
                For Each dat In ListDetail
                    DataGridView1.Rows.Add()
                    DataGridView1.Rows(rowindex).Cells("debet").Value = CDec(dat("debet"))
                    DataGridView1.Rows(rowindex).Cells("kredit").Value = CDec(dat("kredit"))
                    DataGridView1.Rows(rowindex).Cells("mcoadno").Value = dat("mcoadno")
                    DataGridView1.Rows(rowindex).Cells("mcoadname").Value = dat("mcoadname")
                    'DataGridView1.Rows(rowindex).Cells("tjmddesc").Value = dat("tjmddesc").ToString
                    DataGridView1.Rows(rowindex).Cells("dtcreated").Value = dat("dtcreated")
                    'DataGridView1.EndEdit()
                    rowindex = rowindex + 1
                Next
                DataGridView1.EndEdit()
                DataGridView1.Refresh()
            End If
        End If
    End Sub
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        'ListDataCOA = ModelM.GetDataList(CDate(DateTimePicker1.Value))
    End Sub


End Class