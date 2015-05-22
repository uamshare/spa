Public Class FNotaPenjualan
    Private ModelH As New MNotaPenjualanH
    Private ModelD As New MNotaPenjualanD
    Private ModelM As New MTanaman

    Public ListDataTanaman As List(Of Dictionary(Of String, Object)) '= ModelM.GetDataList
    Private isEdit As Boolean = False
    Private DtPelanggan As DataTable
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
        For Each ctrl As Control In GroupBoxSum.Controls
            If (ctrl.GetType() Is GetType(TextBox)) Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                txt.Enabled = False
            End If
        Next
        DateTimePicker1.Enabled = False
        ComboBox1.Enabled = False

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
        For Each ctrl As Control In GroupBoxSum.Controls
            If (ctrl.GetType() Is GetType(TextBox)) Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                txt.Enabled = True
            End If
        Next
        DateTimePicker1.Enabled = True
        ComboBox1.Enabled = True
    End Sub
    Private Sub ClearControll(Optional eachcontrol As Control = Nothing)
        For Each ctrl As Control In PanelHeader.Controls
            If (ctrl.GetType() Is GetType(TextBox)) Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                txt.Text = ""
            End If
        Next
        TextBox1.Text = ""
        txtsum1.Text = "0"
        txtsum2.Text = "0"
        TextBox4.Text = "0"
        TextBox5.Text = "0"
        TextBox6.Text = "0"
        TextBox7.Text = "0"
        TextBox8.Text = "0"
        TextBox9.Text = "0"
        ComboBox1.SelectedIndex = -1
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
            .Columns(1).Name = "qty"
            .Columns(1).HeaderText = "Qty"

            .Columns.Add(New DataGridViewTextBoxColumn())
            .Columns(2).Name = "mmtrid"
            .Columns(2).HeaderText = "Kode"

            Dim btn As New DataGridViewButtonColumn()
            DataGridView1.Columns.Add(btn)
            btn.HeaderText = ""
            btn.Text = "..."
            btn.Name = "btnmmtrid"
            btn.UseColumnTextForButtonValue = True
            btn.Width = 35
            btn.ToolTipText = "Press F4"

            .Columns.Add(New DataGridViewTextBoxColumn())
            .Columns(4).Name = "mmtrhname"
            .Columns(4).HeaderText = "Jenis Tanaman"

            .Columns.Add(New DataGridViewTextBoxColumn())
            .Columns(5).Name = "polybag"
            .Columns(5).HeaderText = "Polybag"

            .Columns.Add(New DataGridViewTextBoxColumn())
            .Columns(6).Name = "price"
            .Columns(6).HeaderText = "Harga"

            .Columns.Add(New DataGridViewTextBoxColumn())
            .Columns(7).Name = "subtotal"
            .Columns(7).HeaderText = "Jumlah"

            .Columns.Add(New DataGridViewCheckBoxColumn())
            .Columns(8).Name = "tinvdtype"
            .Columns(8).HeaderText = "Bonus"
            .Columns(8).Visible = True
            .Columns(8).Width = 50

            .Columns.Add(New DataGridViewTextBoxColumn())
            .Columns(9).Name = "hpp"
            .Columns(9).HeaderText = "HPP"

            .Columns.Add(New DataGridViewTextBoxColumn())
            .Columns(10).Name = "dtcreated"
            .Columns(10).HeaderText = "Date Created"
            .Columns("dtcreated").Visible = False

            .Columns.Add(New DataGridViewTextBoxColumn())
            .Columns(11).Name = "oldhpp"
            .Columns(11).HeaderText = "OLDHPP"
            .Columns("oldhpp").Visible = False

            .Columns.Add(New DataGridViewTextBoxColumn())
            .Columns(12).Name = "pricebonus"
            .Columns(12).HeaderText = "Harga Bonus"
            .Columns("pricebonus").Visible = False

            With .Columns("dtcreated")
                .Width = 120
                .DefaultCellStyle().Alignment = 64 'DataGridViewContentAlignment.MiddleRight
                .HeaderCell.Style.Alignment = 64
                .DefaultCellStyle().Format = "yyyy/MM/dd H:mm:ss"
                .ValueType = GetType(Date)
            End With

            .Columns("hpp").HeaderText = "HPP / Unit"
            .Columns("hpp").Visible = False
            With .Columns("hpp")
                .Width = 120
                .DefaultCellStyle().Alignment = 64 'DataGridViewContentAlignment.MiddleRight
                .HeaderCell.Style.Alignment = 64
                .DefaultCellStyle().Format = "##,000"
                .ValueType = GetType(Decimal)
            End With

            With .Columns("mmtrid")
                .Width = 100
                '.ToolTipText = "press F4"
            End With

            .Columns("mmtrhname").Width = 250
            .Columns("polybag").Width = 75
            .Columns("polybag").DefaultCellStyle.Alignment = 32 'DataGridViewContentAlignment.MiddleCenter

            With .Columns("qty")
                .Width = 50
                .DefaultCellStyle().Alignment = 64 'DataGridViewContentAlignment.MiddleRight
                .HeaderCell.Style.Alignment = 64
                .DefaultCellStyle().Format = "##,000"
                .ValueType = GetType(Decimal)
            End With

            With .Columns("price")
                .Width = 100
                .DefaultCellStyle().Alignment = 64 'DataGridViewContentAlignment.MiddleRight
                .HeaderCell.Style.Alignment = 64
                .DefaultCellStyle().Format = "##,000"
                .ValueType = GetType(Decimal)
            End With
            With .Columns("subtotal")
                .Width = 120
                .DefaultCellStyle().Alignment = 64 'DataGridViewContentAlignment.MiddleRight
                .HeaderCell.Style.Alignment = 64
                .DefaultCellStyle().Format = "##,000"
                .ValueType = GetType(Integer)
            End With
        End With
        DataGridView1.ReadOnly = False
        For Each dgvc As DataGridViewColumn In DataGridView1.Columns
            dgvc.ReadOnly = True
        Next
        DataGridView1.Columns("rowchecked").ReadOnly = False
        DataGridView1.Columns("mmtrid").ReadOnly = False
        DataGridView1.Columns("qty").ReadOnly = False
        DataGridView1.Columns("price").ReadOnly = False
        DataGridView1.Columns("tinvdtype").ReadOnly = False
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            If e.RowIndex > -1 And e.ColumnIndex > -1 Then
                If DataGridView1.Columns(e.ColumnIndex).Name = "btnmmtrid" Then
                    If DataGridView1.CurrentRow.IsNewRow Then
                        DataGridView1.Rows.Add()
                        DataGridView1.CurrentCell = DataGridView1(e.ColumnIndex, e.RowIndex)
                    End If
                    FListTanaman.DatagridParent = DataGridView1
                    FListTanaman.ShowDialog(Me)
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
                    DataGridView1.CurrentCell = DataGridView1("btnmmtrid", DataGridView1.CurrentRow.Index - 1)
                End If
                FListTanaman.DatagridParent = DataGridView1
                FListTanaman.ShowDialog(Me)
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
                If {"qty", "price", "subtotal"}.Contains(DataGridView1.Columns(e.ColumnIndex).Name) Then
                    Dim jml, qty, price As Decimal
                    'Dim hpp,oldhpp As Decimal
                    qty = CDec(DataGridView1.Rows(e.RowIndex).Cells("qty").Value)
                    price = CDec(DataGridView1.Rows(e.RowIndex).Cells("price").Value)
                    jml = qty * price

                    Dim cvalue = Format(CDec(DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "##,##0")
                    DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = cvalue
                    DataGridView1.Rows(e.RowIndex).Cells("subtotal").Value = Format(jml, "##,##0")
                    SetSummaryField()
                ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "mmtrid" Then
                    If DataGridView1.Rows(e.RowIndex).Cells("mmtrid").Value = mmtridbefore Then Exit Sub

                    If CekDuplicateID(DataGridView1.Rows(e.RowIndex).Cells("mmtrid").Value, e.RowIndex) Then
                        For Each dat In ListDataTanaman
                            'col.Add(dat("mmtrid"))
                            If dat("mmtrid") = DataGridView1.Rows(e.RowIndex).Cells("mmtrid").Value Then
                                DataGridView1.Rows(e.RowIndex).Cells("mmtrhname").Value = dat("mmtrname") 'ListDataTanaman(1)("mmtrname")
                                DataGridView1.Rows(e.RowIndex).Cells("polybag").Value = dat("polybag") 'ListDataTanaman(1)("mmtrname")
                                DataGridView1.Rows(e.RowIndex).Cells("price").Value = CDec(dat("mmtrprice"))
                                DataGridView1.Rows(e.RowIndex).Cells("pricebonus").Value = CDec(dat("mmtrprice"))
                                'DataGridView1.Rows(e.RowIndex).Cells("qty").Value = IIf(DataGridView1.Rows(e.RowIndex).Cells("qty").Value.ToString.Length > 0, CDec(DataGridView1.Rows(e.RowIndex).Cells("qty").Value), 0)
                                'DataGridView1.Rows(e.RowIndex).Cells("price").Selected = True
                                DataGridView1.Rows(e.RowIndex).Cells("oldhpp").Value = CDec(dat("hpp"))
                                DataGridView1.Rows(e.RowIndex).Cells("hpp").Value = CDec(dat("hpp"))
                            End If
                        Next
                    Else
                        DataGridView1.Rows(e.RowIndex).Cells("mmtrid").Value = ""
                        DataGridView1.Rows(e.RowIndex).Cells("mmtrhname").Value = ""
                        DataGridView1.Rows(e.RowIndex).Cells("polybag").Value = ""
                        DataGridView1.Rows(e.RowIndex).Cells("price").Value = 0
                        DataGridView1.Rows(e.RowIndex).Cells("qty").Value = 0
                        DataGridView1.CurrentCell = DataGridView1("mmtrid", e.RowIndex)
                        DataGridView1.CancelEdit()
                    End If
                ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "tinvdtype" Then
                    If DataGridView1.Rows(e.RowIndex).Cells("tinvdtype").FormattedValue Then
                        DataGridView1.Rows(e.RowIndex).Cells("price").Value = 0
                    Else
                        Dim crmmtrid As String = DataGridView1.Rows(e.RowIndex).Cells("mmtrid").Value
                        DataGridView1.Rows(e.RowIndex).Cells("price").Value = DataGridView1.Rows(e.RowIndex).Cells("pricebonus").Value
                    End If
                End If
            End If
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
        End Try
    End Sub
    Private Sub SetSummaryField()
        Dim sumsubtotal As Decimal = 0
        Dim nilhpp As Decimal = 0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not row.IsNewRow Then
                Dim qty As Decimal = CDec(row.Cells("qty").Value)
                Dim hpp As Decimal = CDec(row.Cells("hpp").Value)
                Dim jmlhpp As Decimal = qty * hpp

                sumsubtotal = sumsubtotal + CDec(row.Cells("subtotal").Value)
                nilhpp = nilhpp + jmlhpp
            End If
        Next
        TextBox4.Text = Format(sumsubtotal, "##,##0")
        txtsum2.Text = Format(nilhpp, "##,##0")
    End Sub
    Private Sub SetSummaryNetto()
        Dim netto As Decimal = 0
        'Dim nilhpp As Decimal = 0
        netto = netto + CDec(IIf(String.IsNullOrEmpty(TextBox4.Text), 0, TextBox4.Text))
        netto = netto - CDec(IIf(String.IsNullOrEmpty(TextBox5.Text), 0, TextBox5.Text))
        netto = netto - CDec(IIf(String.IsNullOrEmpty(TextBox6.Text), 0, TextBox6.Text))
        netto = netto + CDec(IIf(String.IsNullOrEmpty(TextBox7.Text), 0, TextBox7.Text))
        netto = netto + CDec(IIf(String.IsNullOrEmpty(TextBox8.Text), 0, TextBox8.Text))
        txtsum1.Text = Format(netto, "##,##0")
    End Sub
    Private Function CekDuplicateID(mmtrid As String, rowindex As Integer) As Boolean
        Try
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells("mmtrid").Value = mmtrid _
                    And Not String.IsNullOrEmpty(mmtrid) _
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
    Private WithEvents CellText As New DataGridViewTextBoxEditingControl
    'Private WithEvents BtnView As New DataGridViewTextBoxEditingControl

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        Try
            txtNumeric = Nothing
            CellText = Nothing
            'BtnView = Nothing
            If {"qty", "price", "subtotal"}.Contains(DataGridView1.Columns(DataGridView1.CurrentCell.ColumnIndex).Name) Then
                'txtNumeric_KeyPress(Nothing, Nothing)
                'CellText = Nothing
                txtNumeric = CType(DataGridView1.EditingControl, DataGridViewTextBoxEditingControl)
            ElseIf {"mmtrid"}.Contains(DataGridView1.Columns(DataGridView1.CurrentCell.ColumnIndex).Name) Then
                'txtNumeric = Nothing
                CellText = CType(DataGridView1.EditingControl, DataGridViewTextBoxEditingControl)
            End If
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
        End Try
    End Sub
    Private Sub DataGridView1_AutoComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        Dim titleText As String = DataGridView1.Columns("mmtrid").HeaderText
        'MsgBox(titleText)
        If titleText.Equals("Kode") Then
            Dim autoText As TextBox = TryCast(e.Control, TextBox)
            If autoText IsNot Nothing Then
                autoText.AutoCompleteMode = AutoCompleteMode.Suggest
                autoText.AutoCompleteSource = AutoCompleteSource.CustomSource
                Dim DataCollection As New AutoCompleteStringCollection()
                addItems(DataCollection)
                autoText.AutoCompleteCustomSource = DataCollection
            End If
        End If
    End Sub
    Public Sub addItems(ByVal col As AutoCompleteStringCollection)
        Try
            For Each dat In ListDataTanaman
                col.Add(dat("mmtrid"))
            Next
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
        End Try
    End Sub
    Private Sub txtNumeric_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtNumeric.KeyPress
        e.Handled = MyApplication.ValidNumber(e)
    End Sub
    Private Sub CellText_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles CellText.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
    Private rowIndex As Integer = 0
    Private mmtridbefore As String = ""
    Private Sub DataGridView1_CellMouseUp_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseUp
        If e.RowIndex > -1 And e.ColumnIndex > -1 Then
            mmtridbefore = DataGridView1.Rows(e.RowIndex).Cells("mmtrid").Value
            If e.Button = MouseButtons.Right Then
                Me.DataGridView1.Rows(e.RowIndex).Selected = True
                Me.rowIndex = e.RowIndex
                Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(e.RowIndex).Cells(1)
                If DataGridView1.Rows(Me.rowIndex).Cells("tinvdtype").Value Then
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
        DataGridView1.Rows(Me.rowIndex).Cells("tinvdtype").Value = Not DataGridView1.Rows(Me.rowIndex).Cells("tinvdtype").Value
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
    Private Sub FNotaPenjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = MyApplication.DefaultFormatDate

        InitializeDataGridView(DataGridView1)
        DataGridView1.AllowUserToAddRows = True
        DataGridView1.AllowUserToDeleteRows = True
        DataGridView1.AllowUserToOrderColumns = True
        DataGridView1.ReadOnly = False

        Dim ModelP As New MDataPelanggan
        ModelP.limitrecord = -1
        DtPelanggan = ModelP.GetData
        ComboBox1.DataSource = DtPelanggan
        ComboBox1.ValueMember = "mcusid"
        ComboBox1.DisplayMember = "mcusname"
        ComboBox1.SelectedIndex = -1

        Dim discCollection As New AutoCompleteStringCollection()
        For i As Integer = 5 To 50 Step 5
            discCollection.Add(i)
        Next
        TextBox9.Text = ""
        TextBox9.AutoCompleteMode = AutoCompleteMode.Suggest
        TextBox9.AutoCompleteSource = AutoCompleteSource.CustomSource
        TextBox9.AutoCompleteCustomSource = discCollection

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
        ComboBox1.Focus()
        isEdit = False
        'ListDataTanaman = ModelM.GetDataList(DateTimePicker1.Value)
    End Sub
    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        Dim Formvalid As Boolean = True
        'If DateTimePicker1.Value = "" Then
        '    MyApplication.ShowStatus("Tanggal Invoice harus diisi", WARNING_STAT)
        '    DateTimePicker1.Focus()
        '    Formvalid = False
        'End If
        If TxtNo.Text = "" Then
            MyApplication.ShowStatus("No Invoice harus diisi", NOTICE_STAT)
            TxtNo.Focus()
            Formvalid = False
        End If
        If ComboBox1.Text = "" Then
            MyApplication.ShowStatus("Customer harus diisi", NOTICE_STAT)
            ComboBox1.Focus()
            Formvalid = False
        End If
        If DataGridView1.Rows.Count <= 1 Then
            MyApplication.ShowStatus("Data Tanaman belum diisi", NOTICE_STAT)
            DataGridView1.Select()
            DataGridView1.Focus()
            Formvalid = False
        End If
        
        If Formvalid Then
            ModelD.tinvhno = ModelH.EscapeString(TxtNo.Text)
            ModelD.tinvhdt = ModelH.EscapeString(Format(DateTimePicker1.Value, "yyyy/MM/dd"))
            ModelD.mcusid = ModelH.EscapeString(ComboBox1.SelectedValue.ToString)
            ModelD.tinvhnote = ModelH.EscapeString(TextBox1.Text)
            Dim disc1 = TextBox9.Text.Replace("%", "")
            ModelD.tinvhdisc1 = ModelH.EscapeString(CDec(disc1))
            ModelD.tinvhdisc2 = ModelH.EscapeString(CDec(TextBox5.Text))
            'ModelD.tinvhbonus = ModelH.EscapeString(CDec(TextBox6.Text))
            ModelD.tinvhongkir = ModelH.EscapeString(CDec(TextBox7.Text))
            ModelD.tinvhongpack = ModelH.EscapeString(CDec(TextBox8.Text))
            ModelD.soldvalue = ModelH.EscapeString(txtsum1.Text) 'for posting to General Ledger Sold Price
            ModelD.bookvalue = ModelH.EscapeString(txtsum2.Text) 'for posting to General Ledger bookValue

            Dim ListDetail As New List(Of Dictionary(Of String, Object))
            For Each row In DataGridView1.Rows
                Dim dict As New Dictionary(Of String, Object)
                If Not row.IsNewRow Then
                    If Not String.IsNullOrEmpty(row.Cells("mmtrid").Value.ToString) And _
                        (CDec(row.Cells("qty").Value) > 0 And CDec(row.Cells("price").Value) > 0) Then
                        dict.Add("tinvhno", ModelH.tinvhno)
                        dict.Add("mmtrid", row.Cells("mmtrid").Value)
                        dict.Add("tinvdqty", CDec(row.Cells("qty").Value))
                        dict.Add("tinvdprice", CDec(row.Cells("price").Value))
                        dict.Add("tinvdtype", CDec(row.Cells("tinvdtype").Value))
                        dict.Add("dtcreated", row.Cells("dtcreated").FormattedValue)

                        dict.Add("hpp", CDec(row.Cells("hpp").Value)) 'for set HPP Value / unit
                        'MsgBox(row.Cells("dtcreated").FormattedValue)
                        ListDetail.Add(dict)
                    Else
                        MyApplication.ShowStatus("Qty / Harga tidak boleh '0'", NOTICE_STAT)
                        Exit Sub
                    End If
                End If
            Next

            If isEdit Then
                ModelD.UpdateData(ListDetail)
                'ModelD.DeleteByNo(ModelH.tinvhno)
            Else
                'ModelH.InsertData()
                ModelD.InsertData(ListDetail)
            End If
            init()
            txtsum1.Text = ""
            txtsum2.Text = ""
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
        FListNotaPenjualan.ShowDialog()
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
                    DataGridView1.Rows(rowindex).Cells("mmtrid").Value = dat("mmtrid")
                    DataGridView1.Rows(rowindex).Cells("qty").Value = CDec(dat("tinvdqty"))
                    DataGridView1.Rows(rowindex).Cells("price").Value = CDec(dat("tinvdprice"))
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
        ListDataTanaman = ModelM.GetDataList(CDate(DateTimePicker1.Value))
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex > -1 Then
            'MsgBox(ComboBox1.SelectedValue.ToString)
            Dim alamat As String = ""
            If Not String.IsNullOrEmpty(DtPelanggan.Rows(ComboBox1.SelectedIndex).Item("mcusaddr3").ToString) Then
                alamat = DtPelanggan.Rows(ComboBox1.SelectedIndex).Item("mcusaddr3").ToString & ", " & DtPelanggan.Rows(ComboBox1.SelectedIndex).Item("mcusaddr4").ToString
            Else
                alamat = DtPelanggan.Rows(ComboBox1.SelectedIndex).Item("mcusaddr4").ToString
            End If
            TextBox2.Text = alamat
            TextBox3.Text = DtPelanggan.Rows(ComboBox1.SelectedIndex).Item("mcusphone1").ToString
        Else
            TextBox2.Text = ""
            TextBox3.Text = ""
        End If

    End Sub
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        SetSummaryNetto()
    End Sub
    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        SetSummaryNetto()
    End Sub
    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        SetSummaryNetto()
    End Sub

    Private Sub TextBox7_KeyDown1(sender As Object, e As KeyEventArgs) Handles TextBox7.KeyDown
        If e.KeyCode.ToString = Keys.Enter.ToString Then
            TextBox8.Focus()
        End If
    End Sub
    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        SetSummaryNetto()
    End Sub
    Private Sub TextBox8_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox8.KeyDown
        If e.KeyCode.ToString = Keys.Enter.ToString Then
            ButtonSave.Focus()
        End If
    End Sub
    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        SetSummaryNetto()
    End Sub
    Private Sub TextBox7_Validated(sender As Object, e As EventArgs) Handles TextBox7.Validated
        TextBox7.Text = Format(CDec(TextBox7.Text), "##,##0")
    End Sub
    Private Sub TextBox8_Validated(sender As Object, e As EventArgs) Handles TextBox8.Validated
        TextBox8.Text = Format(CDec(TextBox8.Text), "##,##0")
    End Sub
    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        e.Handled = ValidNumber(e)
    End Sub
    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        e.Handled = ValidNumber(e)
    End Sub
    Private Sub TextBox9_GotFocus(sender As Object, e As EventArgs) Handles TextBox9.GotFocus
        TextBox9.Text = TextBox9.Text.Replace("%", "")
    End Sub
    Private Sub TextBox9_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox9.KeyDown
        If e.KeyCode.ToString = Keys.Enter.ToString Then
            TextBox7.Focus()
        End If
    End Sub
    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox9.KeyPress
            e.Handled = ValidNumber(e)
    End Sub
    Private Sub TextBox9_Validated(sender As Object, e As EventArgs) Handles TextBox9.Validated
        Try
            If Not String.IsNullOrEmpty(TextBox9.Text) Then
                Dim subtotal As Integer = CInt(TextBox4.Text)
                Dim disc As Integer = CInt(TextBox9.Text)
                disc = IIf(CInt(disc) > 50, 50, CInt(disc))
                TextBox5.Text = Format(disc / 100 * subtotal, "##,##0")
                TextBox9.Text = disc & "%"
            Else
                TextBox9.Text = 0 & "%"
            End If
        Catch ex As Exception
            ShowStatus(ex.Message, WARNING_STAT)
        End Try
    End Sub

    
    
End Class