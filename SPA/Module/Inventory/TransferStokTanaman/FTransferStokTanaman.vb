Public Class FTransferStokTanaman
    Private ModelH As New MTransferStokTanamanH
    Private ModelD As New MTransferStokTanamanD
    Private ModelM As New MTanaman

    Public ListDataTanaman As List(Of Dictionary(Of String, Object)) '= ModelM.GetDataList
    Private isEdit As Boolean = False
    Public Sub init()
        Me.isEdit = False
        ClearControll()
        NonActiveControll()
        RetriveDataGrid(DataGridView1)
        RetriveDataGrid(DataGridView2)
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

        For Each ctrl As Control In PanelHeader2.Controls
            If (ctrl.GetType() Is GetType(TextBox)) Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                txt.Enabled = False
            End If
        Next
        For Each ctrl As Control In PanelFooter2.Controls
            If (ctrl.GetType() Is GetType(TextBox)) Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                txt.Enabled = False
            End If
        Next
        DateTimePicker2.Enabled = False
        ButtonAdd2.Enabled = True
        ButtonSave2.Enabled = False
        ButtonDel2.Enabled = False
        ButtonPrint2.Enabled = False
        ButtonCancel2.Enabled = False
        ButtonH2.Enabled = True
        DataGridView2.EndEdit()
        DataGridView2.Rows.Clear()
        DataGridView2.Enabled = False
        ToolDelete2.Enabled = False
        
    End Sub
    Private Sub ActiveControll(Optional eachcontrol As Control = Nothing)
        For Each ctrl As Control In PanelHeader.Controls
            If (ctrl.GetType() Is GetType(TextBox)) Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                txt.Enabled = True
            End If
        Next
        DateTimePicker1.Enabled = True

        For Each ctrl As Control In PanelHeader2.Controls
            If (ctrl.GetType() Is GetType(TextBox)) Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                txt.Enabled = True
            End If
        Next
        DateTimePicker2.Enabled = True

    End Sub
    Private Sub ClearControll(Optional eachcontrol As Control = Nothing)
        For Each ctrl As Control In PanelHeader.Controls
            If (ctrl.GetType() Is GetType(TextBox)) Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                txt.Text = ""
            End If
        Next
        For Each ctrl As Control In PanelFooter.Controls
            If (ctrl.GetType() Is GetType(TextBox)) Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                txt.Text = ""
            End If
        Next
        DateTimePicker1.Value = Format(Date.Now)
        For Each ctrl As Control In PanelHeader2.Controls
            If (ctrl.GetType() Is GetType(TextBox)) Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                txt.Text = ""
            End If
        Next
        For Each ctrl As Control In PanelFooter2.Controls
            If (ctrl.GetType() Is GetType(TextBox)) Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                txt.Text = ""
            End If
        Next
        DateTimePicker2.Value = Format(Date.Now)
    End Sub

#Region "Format DataGridView"
    'Private Sub InitializeDataGridView(DG As DataGridView)
    '    With DG
    '        ' Initialize basic DataGridView properties.
    '        .Dock = DockStyle.Fill
    '        .BackgroundColor = Color.LightGray
    '        .BorderStyle = BorderStyle.Fixed3D

    '        ' Set property values appropriate for read-only display and  
    '        ' limited interactivity. 
    '        .AllowUserToAddRows = True
    '        .AllowUserToDeleteRows = True
    '        .AllowUserToOrderColumns = True
    '        .ReadOnly = False
    '        .SelectionMode = DataGridViewSelectionMode.RowHeaderSelect 'DataGridViewSelectionMode.CellSelect
    '        .MultiSelect = False
    '        .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
    '        .AllowUserToResizeColumns = True
    '        .ColumnHeadersHeightSizeMode = _
    '            DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    '        .AllowUserToResizeRows = False
    '        .RowHeadersWidthSizeMode = _
    '            DataGridViewRowHeadersWidthSizeMode.DisableResizing

    '        ' Set the selection background color for all the cells.
    '        .DefaultCellStyle.SelectionBackColor = Color.LightGray
    '        .DefaultCellStyle.SelectionForeColor = Color.Black

    '        ' Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default 
    '        ' value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
    '        .RowHeadersDefaultCellStyle.SelectionBackColor = Color.White

    '        ' Set the background color for all rows and for alternating rows.  
    '        ' The value for alternating rows overrides the value for all rows. 
    '        .RowsDefaultCellStyle.BackColor = Color.White 'Color.LightGray
    '        .AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

    '        ' Set the row and column header styles.
    '        .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
    '        .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
    '        .RowHeadersDefaultCellStyle.BackColor = Color.Black
    '    End With
    'End Sub
    Private Sub RetriveDataGrid(DG As DataGridView)
        With DG
            .ColumnHeadersHeight = 35
            .RowHeadersWidth = 50
            .Columns.Add(New DataGridViewCheckBoxColumn)
            .Columns(0).Name = "rowchecked"
            .Columns(0).HeaderText = ".."
            .Columns(0).Width = 35

            .Columns.Add(New DataGridViewTextBoxColumn())
            .Columns(1).Name = "mmtrid"
            .Columns(1).HeaderText = "Kode"
            .Columns(1).Width = 75

            Dim btn As New DataGridViewButtonColumn()
            .Columns.Add(btn)
            btn.HeaderText = ""
            btn.Text = "..."
            btn.Name = "btnmmtrid"
            btn.UseColumnTextForButtonValue = True
            btn.Width = 35

            .ColumnCount = 11
            '.Columns(1).Name = "mmtrid"
            '.Columns("mmtrid").HeaderText = "Kode"
            .Columns(3).Name = "mmtrhname"
            .Columns("mmtrhname").HeaderText = "Jenis Tanaman"
            .Columns(4).Name = "polybag"
            .Columns("polybag").HeaderText = "Polybag"
            .Columns(5).Name = "qty"
            .Columns("qty").HeaderText = "Qty"
            .Columns(6).Name = "price"
            .Columns("price").HeaderText = "Harga"
            .Columns(7).Name = "subtotal"
            .Columns("subtotal").HeaderText = "Jumlah"
            .Columns(8).Name = "dtcreated"
            .Columns("dtcreated").HeaderText = "Date Created"
            .Columns("dtcreated").Visible = False
            With .Columns("dtcreated")
                .Width = 120
                .DefaultCellStyle().Alignment = 64 'DataGridViewContentAlignment.MiddleRight
                .HeaderCell.Style.Alignment = 64
                .DefaultCellStyle().Format = "yyyy/MM/dd H:mm:ss"
                .ValueType = GetType(Date)
            End With
            .Columns(9).Name = "oldhpp"
            .Columns("oldhpp").HeaderText = "OLD HPP"
            .Columns("oldhpp").Visible = False
            With .Columns("oldhpp")
                .Width = 120
                .DefaultCellStyle().Alignment = 64 'DataGridViewContentAlignment.MiddleRight
                .HeaderCell.Style.Alignment = 64
                .DefaultCellStyle().Format = "##,000"
                .ValueType = GetType(Decimal)
            End With
            .Columns(10).Name = "hpp"
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
                .ToolTipText = "press F4"
            End With

            .Columns("mmtrhname").Width = 250
            .Columns("polybag").Width = 75
            .Columns("polybag").DefaultCellStyle.Alignment = 32 'DataGridViewContentAlignment.MiddleCenter

            With .Columns("qty")
                .Width = 75
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
        DG.ReadOnly = False
        For Each dgvc As DataGridViewColumn In DG.Columns
            dgvc.ReadOnly = True
        Next
        DG.Columns("rowchecked").ReadOnly = False
        DG.Columns("mmtrid").ReadOnly = False
        DG.Columns("qty").ReadOnly = False
        DG.Columns("price").ReadOnly = True
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
    
    Private Function CekDuplicateID(mmtrid As String, rowindex As Integer, DG As DataGridView) As Boolean
        Try
            For Each row As DataGridViewRow In DG.Rows

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
#End Region
    Private Sub FTransferStokTanaman_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.Dock = DockStyle.Left
        'TabControl1.SelectTab("TabPage2")
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = MyApplication.DefaultFormatDate
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = MyApplication.DefaultFormatDate

        'InitializeDataGridView(DataGridView1)
        'InitializeDataGridView(DataGridView2)
        MyApplication.InitializeDataGridView(DataGridView1)
        MyApplication.InitializeDataGridView(DataGridView2)
        DataGridView1.AllowUserToAddRows = True
        DataGridView1.AllowUserToDeleteRows = True
        DataGridView1.AllowUserToOrderColumns = True
        DataGridView1.ReadOnly = False
        DataGridView2.AllowUserToAddRows = True
        DataGridView2.AllowUserToDeleteRows = True
        DataGridView2.AllowUserToOrderColumns = True
        DataGridView2.ReadOnly = False

        init()
        'MessageBox.Show(Format(Date.Now, "yyyy/MM/dd H:mm:ss"))
    End Sub
#Region "Transfer Masuk"
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
        TxtNoMasuk.Text = ModelH.getAutoNo("in")
        ttrfmhdesc1.Focus()
        isEdit = False
        'ListDataTanaman = ModelM.GetDataList(DateTimePicker1.Value)
    End Sub
    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        Dim Formvalid As Boolean = True
        If TxtNoMasuk.Text = "" Then
            MyApplication.ShowStatus("No Transfer Masuk harus diisi", WARNING_STAT)
            TxtNoMasuk.Focus()
            Formvalid = False
        End If
        If DataGridView1.Rows.Count <= 1 Then
            MyApplication.ShowStatus("Data Tanaman belum diisi", NOTICE_STAT)
            DataGridView1.Select()
            DataGridView1.Focus()
            Formvalid = False
        End If

        If Formvalid Then
            ModelD.ttrfmhno = ModelH.EscapeString(TxtNoMasuk.Text)
            ModelD.ttrfmhdt = ModelH.EscapeString(Format(DateTimePicker1.Value, "yyyy/MM/dd"))
            ModelD.ttrfmhdesc = ttrfmhdesc1.Text
            ModelD.ttrfmhtype = "in"
            ModelD.bookvalue = ModelH.EscapeString(txtsum2tab1.Text) 'for posting to General Ledger

            Dim ListDetail As New List(Of Dictionary(Of String, Object))
            For Each row In DataGridView1.Rows
                Dim dict As New Dictionary(Of String, Object)
                If Not row.IsNewRow Then
                    If Not String.IsNullOrEmpty(row.Cells("mmtrid").Value.ToString) And _
                        (CDec(row.Cells("qty").Value) > 0 And CDec(row.Cells("price").Value) > 0) Then
                        dict.Add("ttrfmhno", ModelH.ttrfmhno)
                        dict.Add("mmtrid", row.Cells("mmtrid").Value)
                        dict.Add("ttrfmdqty", CDec(row.Cells("qty").Value))
                        dict.Add("ttrfmdprice", CDec(row.Cells("price").Value))
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
                'ModelD.DeleteByNo(ModelH.ttrfmhno)
            Else
                'ModelH.InsertData()
                ModelD.InsertData(ListDetail)
            End If
            init()
            txtsum1tab1.Text = ""
            txtsum2tab1.Text = ""
        End If
    End Sub
    Private Sub ButtonDel_Click(sender As Object, e As EventArgs) Handles ButtonDel.Click
        Dim dr As DialogResult = MessageBox.Show("Anda yakin akan menghpuas data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dr = Windows.Forms.DialogResult.Yes Then
            ModelD.DeleteData(ModelH.EscapeString(TxtNoMasuk.Text))
            init()
        End If
    End Sub
    Private Sub ButtonPrint_Click(sender As Object, e As EventArgs) Handles ButtonPrint.Click

    End Sub
    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        init()
    End Sub
    Private Sub ButtonH_Click(sender As Object, e As EventArgs) Handles ButtonH.Click
        Me.isEdit = True
        FListTransferStokTanaman.TransferType = "in"
        FListTransferStokTanaman.ShowDialog()
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
    Private Sub DataGridView1_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellLeave
        DataGridView1_CellValueChanged(sender, e)
    End Sub
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Try
            If e.RowIndex > -1 And e.ColumnIndex > -1 Then
                If {"qty", "price", "subtotal"}.Contains(DataGridView1.Columns(e.ColumnIndex).Name) Then
                    Dim jml, qty, price As Decimal
                    Dim hpp, oldhpp As Decimal
                    qty = CDec(DataGridView1.Rows(e.RowIndex).Cells("qty").Value)
                    price = CDec(DataGridView1.Rows(e.RowIndex).Cells("price").Value)
                    oldhpp = CDec(DataGridView1.Rows(e.RowIndex).Cells("oldhpp").Value)
                    jml = qty * price
                    If oldhpp > 0 And price > 0 Then
                        hpp = (price + oldhpp) / 2
                    Else
                        hpp = IIf(price > 0, price, oldhpp)
                    End If

                    Dim cvalue = Format(CDec(DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "##,##0")
                    DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = cvalue
                    DataGridView1.Rows(e.RowIndex).Cells("subtotal").Value = Format(jml, "##,##0")
                    DataGridView1.Rows(e.RowIndex).Cells("hpp").Value = hpp
                    'MsgBox(jml)
                    SetSummaryField()
                End If
                If DataGridView1.Columns(e.ColumnIndex).Name = "mmtrid" Then
                    If DataGridView1.Rows(e.RowIndex).Cells("mmtrid").Value = mmtridbefore Then Exit Sub
                    If CekDuplicateID(DataGridView1.Rows(e.RowIndex).Cells("mmtrid").Value, e.RowIndex, DataGridView1) Then
                        For Each dat In ListDataTanaman
                            'col.Add(dat("mmtrid"))
                            If dat("mmtrid") = DataGridView1.Rows(e.RowIndex).Cells("mmtrid").Value Then
                                DataGridView1.Rows(e.RowIndex).Cells("mmtrhname").Value = dat("mmtrname") 'ListDataTanaman(1)("mmtrname")
                                DataGridView1.Rows(e.RowIndex).Cells("polybag").Value = dat("polybag") 'ListDataTanaman(1)("mmtrname")
                                DataGridView1.Rows(e.RowIndex).Cells("price").Value = CDec(dat("hpp"))
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
                End If
            End If
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
        End Try
    End Sub
    Private Sub DataGridView1_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        MyApplication.ShowStatus("Silahkan masukan angka.", WARNING_STAT)
    End Sub

    Private WithEvents txtNumeric As New DataGridViewTextBoxEditingControl
    Private WithEvents CellText As New DataGridViewTextBoxEditingControl
    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        Try
            If {"qty", "price", "subtotal"}.Contains(DataGridView1.Columns(DataGridView1.CurrentCell.ColumnIndex).Name) Then
                'txtNumeric_KeyPress(Nothing, Nothing)
                CellText = Nothing
                txtNumeric = CType(DataGridView1.EditingControl, DataGridViewTextBoxEditingControl)
            Else
                txtNumeric = Nothing
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
                Me.ContextMenuStrip1.Show(Me.DataGridView1, e.Location)
                ContextMenuStrip1.Show(Cursor.Position)
            End If
        End If
    End Sub
    Private Sub ContextMenuStrip1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuStrip1.Click
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
    Private Sub SetSummaryField()
        Dim nilpembelian As Decimal = 0
        Dim nilhpp As Decimal = 0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not row.IsNewRow Then
                Dim qty As Decimal = CDec(row.Cells("qty").Value)
                Dim hpp As Decimal = CDec(row.Cells("hpp").Value)
                Dim jmlhpp As Decimal = qty * hpp

                nilpembelian = nilpembelian + CDec(row.Cells("subtotal").Value)
                nilhpp = nilhpp + jmlhpp
            End If
        Next
        Console.WriteLine(nilhpp)
        txtsum1tab1.Text = Format(nilpembelian, "##,##0")
        txtsum2tab1.Text = Format(nilpembelian, "##,##0")
    End Sub
#End Region
#Region "Transfer Keluar"
    Private Sub ButtonAdd2_Click(sender As Object, e As EventArgs) Handles ButtonAdd2.Click
        ClearControll()
        ActiveControll()
        ButtonAdd2.Enabled = False
        ButtonSave2.Enabled = True
        ButtonDel2.Enabled = False
        ButtonPrint2.Enabled = False
        ButtonCancel2.Enabled = True
        ButtonH2.Enabled = False

        DataGridView2.Enabled = True
        ToolDelete2.Enabled = True
        TxtNoKeluar.Text = ModelH.getAutoNo("out")
        ttrfmhdesc2.Focus()
        isEdit = False
        'ListDataTanaman = ModelM.GetDataList(DateTimePicker1.Value)
    End Sub
    Private Sub ButtonSave2_Click(sender As Object, e As EventArgs) Handles ButtonSave2.Click
        Dim Formvalid As Boolean = True
        If TxtNoKeluar.Text = "" Then
            MyApplication.ShowStatus("No Transfer Masuk harus diisi", WARNING_STAT)
            TxtNoKeluar.Focus()
            Formvalid = False
        End If
        If DataGridView2.Rows.Count <= 1 Then
            MyApplication.ShowStatus("Data Tanaman belum diisi", NOTICE_STAT)
            DataGridView2.Select()
            DataGridView2.Focus()
            Formvalid = False
        End If

        If Formvalid Then
            ModelD.ttrfmhno = ModelH.EscapeString(TxtNoKeluar.Text)
            ModelD.ttrfmhdt = ModelH.EscapeString(Format(DateTimePicker1.Value, "yyyy/MM/dd"))
            ModelD.ttrfmhdesc = ttrfmhdesc2.Text
            ModelD.ttrfmhtype = "out"
            ModelD.bookvalue = ModelH.EscapeString(txtsum2tab2.Text) 'for posting to General Ledger

            Dim ListDetail As New List(Of Dictionary(Of String, Object))
            For Each row In DataGridView2.Rows
                Dim dict As New Dictionary(Of String, Object)
                If Not row.IsNewRow Then
                    If Not String.IsNullOrEmpty(row.Cells("mmtrid").Value.ToString) And _
                        (CDec(row.Cells("qty").Value) > 0 And CDec(row.Cells("price").Value) > 0) Then
                        dict.Add("ttrfmhno", ModelH.ttrfmhno)
                        dict.Add("mmtrid", row.Cells("mmtrid").Value)
                        dict.Add("ttrfmdqty", CDec(row.Cells("qty").Value))
                        dict.Add("ttrfmdprice", CDec(row.Cells("price").Value))
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
                'ModelD.DeleteByNo(ModelH.ttrfmhno)
            Else
                'ModelH.InsertData()
                ModelD.InsertData(ListDetail)
            End If
            init()
            txtsum1tab1.Text = ""
            txtsum2tab1.Text = ""
        End If
    End Sub
    Private Sub ButtonDel2_Click(sender As Object, e As EventArgs) Handles ButtonDel2.Click
        Dim dr As DialogResult = MessageBox.Show("Anda yakin akan menghpuas data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dr = Windows.Forms.DialogResult.Yes Then
            ModelD.DeleteData(ModelH.EscapeString(TxtNoKeluar.Text))
            init()
        End If
    End Sub
    Private Sub ButtonPrint2_Click(sender As Object, e As EventArgs) Handles ButtonPrint2.Click

    End Sub
    Private Sub ButtonCancel2_Click(sender As Object, e As EventArgs) Handles ButtonCancel2.Click
        init()
    End Sub
    Private Sub ButtonH2_Click(sender As Object, e As EventArgs) Handles ButtonH2.Click
        Me.isEdit = True
        FListTransferStokTanaman.TransferType = "out"
        FListTransferStokTanaman.ShowDialog()
    End Sub
    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Try
            If e.RowIndex > -1 And e.ColumnIndex > -1 Then
                If DataGridView2.Columns(e.ColumnIndex).Name = "btnmmtrid" Then
                    If DataGridView2.CurrentRow.IsNewRow Then
                        DataGridView2.Rows.Add()
                        DataGridView2.CurrentCell = DataGridView2(e.ColumnIndex, e.rowIndex)
                    End If
                    FListTanaman.DatagridParent = DataGridView2
                    FListTanaman.ShowDialog(Me)
                End If
            End If
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
        End Try

    End Sub
    Private Sub DataGridView2_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellLeave
        DataGridView2_CellValueChanged(sender, e)
    End Sub
    Private Sub DataGridView2_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellValueChanged
        Try
            If e.RowIndex > -1 And e.ColumnIndex > -1 Then
                If {"qty", "price", "subtotal"}.Contains(DataGridView2.Columns(e.ColumnIndex).Name) Then
                    Dim jml, qty, price As Decimal
                    Dim hpp, oldhpp As Decimal
                    qty = CDec(DataGridView2.Rows(e.rowIndex).Cells("qty").Value)
                    price = CDec(DataGridView2.Rows(e.rowIndex).Cells("price").Value)
                    oldhpp = CDec(DataGridView2.Rows(e.rowIndex).Cells("oldhpp").Value)
                    jml = qty * price
                    If oldhpp > 0 And price > 0 Then
                        hpp = (price + oldhpp) / 2
                    Else
                        hpp = IIf(price > 0, price, oldhpp)
                    End If

                    Dim cvalue = Format(CDec(DataGridView2.Rows(e.rowIndex).Cells(e.ColumnIndex).Value), "##,##0")
                    DataGridView2.Rows(e.rowIndex).Cells(e.ColumnIndex).Value = cvalue
                    DataGridView2.Rows(e.rowIndex).Cells("subtotal").Value = Format(jml, "##,##0")
                    DataGridView2.Rows(e.rowIndex).Cells("hpp").Value = hpp
                    'MsgBox(jml)
                    SetSummaryField2()
                End If
                If DataGridView2.Columns(e.ColumnIndex).Name = "mmtrid" Then
                    If DataGridView2.Rows(e.RowIndex).Cells("mmtrid").Value = mmtridbefore2 Then Exit Sub
                    If CekDuplicateID(DataGridView2.Rows(e.RowIndex).Cells("mmtrid").Value, e.RowIndex, DataGridView2) Then
                        For Each dat In ListDataTanaman
                            'col.Add(dat("mmtrid"))
                            If dat("mmtrid") = DataGridView2.Rows(e.RowIndex).Cells("mmtrid").Value Then
                                DataGridView2.Rows(e.RowIndex).Cells("mmtrhname").Value = dat("mmtrname") 'ListDataTanaman(1)("mmtrname")
                                DataGridView2.Rows(e.RowIndex).Cells("polybag").Value = dat("polybag") 'ListDataTanaman(1)("mmtrname")
                                DataGridView2.Rows(e.RowIndex).Cells("price").Value = CDec(dat("hpp"))
                                'DataGridView2.Rows(e.rowIndex).Cells("qty").Value = IIf(DataGridView2.Rows(e.rowIndex).Cells("qty").Value.ToString.Length > 0, CDec(DataGridView2.Rows(e.rowIndex).Cells("qty").Value), 0)
                                'DataGridView2.Rows(e.rowIndex).Cells("price").Selected = True
                                DataGridView2.Rows(e.RowIndex).Cells("oldhpp").Value = CDec(dat("hpp"))
                                DataGridView2.Rows(e.RowIndex).Cells("hpp").Value = CDec(dat("hpp"))
                            End If
                        Next
                    Else
                        DataGridView2.Rows(e.RowIndex).Cells("mmtrid").Value = ""
                        DataGridView2.Rows(e.RowIndex).Cells("mmtrhname").Value = ""
                        DataGridView2.Rows(e.RowIndex).Cells("polybag").Value = ""
                        DataGridView2.Rows(e.RowIndex).Cells("price").Value = 0
                        DataGridView2.Rows(e.RowIndex).Cells("qty").Value = 0
                        DataGridView2.CurrentCell = DataGridView2("mmtrid", e.RowIndex)
                        DataGridView2.CancelEdit()
                    End If
                End If
            End If
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
        End Try
    End Sub
    Private Sub DataGridView2_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView2.DataError
        MyApplication.ShowStatus("Silahkan masukan angka.", WARNING_STAT)
    End Sub

    Private WithEvents txtNumeric2 As New DataGridViewTextBoxEditingControl
    Private WithEvents CellText2 As New DataGridViewTextBoxEditingControl
    Private Sub DataGridView2_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView2.EditingControlShowing
        Try
            If {"qty", "price", "subtotal"}.Contains(DataGridView2.Columns(DataGridView2.CurrentCell.ColumnIndex).Name) Then
                'txtNumeric2_KeyPress(Nothing, Nothing)
                CellText2 = Nothing
                txtNumeric2 = CType(DataGridView2.EditingControl, DataGridViewTextBoxEditingControl)
            Else
                txtNumeric2 = Nothing
                CellText2 = CType(DataGridView2.EditingControl, DataGridViewTextBoxEditingControl)
            End If
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
        End Try
    End Sub
    Private Sub DataGridView2_AutoComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView2.EditingControlShowing
        Dim titleText As String = DataGridView2.Columns("mmtrid").HeaderText
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

    Private Sub txtNumeric2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtNumeric2.KeyPress
        e.Handled = MyApplication.ValidNumber(e)
    End Sub
    Private Sub CellText2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles CellText2.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private rowIndex2 As Integer = 0
    Private mmtridbefore2 As String = ""
    Private Sub DataGridView2_CellMouseUp_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseUp
        If e.RowIndex > -1 And e.ColumnIndex > -1 Then
            mmtridbefore2 = DataGridView2.Rows(e.RowIndex).Cells("mmtrid").Value
            If e.Button = MouseButtons.Right Then
                Me.DataGridView2.Rows(e.RowIndex).Selected = True
                Me.rowIndex = e.RowIndex
                Me.DataGridView2.CurrentCell = Me.DataGridView2.Rows(e.RowIndex).Cells(1)
                Me.ContextMenuStrip1.Show(Me.DataGridView2, e.Location)
                ContextMenuStrip1.Show(Cursor.Position)
            End If
        End If
    End Sub
    Private Sub ContextMenuStrip2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuStrip2.Click
        If Not Me.DataGridView2.Rows(Me.rowIndex).IsNewRow Then
            Me.DataGridView2.Rows.RemoveAt(Me.rowIndex)
        End If
    End Sub
    Private Sub ToolDelete2_Click(sender As Object, e As EventArgs) Handles ToolDelete2.Click
        Try
            DataGridView2.EndEdit()
            Dim indexrow As Integer = 0
            For i As Integer = 0 To (DataGridView2.Rows.Count - 1)
                'delete data
                If Not DataGridView2.Rows(indexrow).IsNewRow Then
                    If DataGridView2.Rows(indexrow).Cells("rowchecked").FormattedValue = True Then
                        DataGridView2.Rows.RemoveAt(DataGridView2.Rows(indexrow).Index)
                    Else
                        indexrow = indexrow + 1
                    End If
                End If

            Next
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
        End Try
    End Sub
    Private Sub DataGridView2_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.RowValidated
        If Not DataGridView2.Rows(e.RowIndex).IsNewRow Then
            DataGridView2.Rows(e.RowIndex).HeaderCell.Value = (e.RowIndex + 1).ToString '(e.rowIndex + ModelH.startRecord + 1).ToString
        End If
    End Sub
    Private Sub DataGridView2_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DataGridView2.RowsRemoved
        For Each row In DataGridView2.Rows
            If Not row.IsNewRow Then
                row.HeaderCell.Value = (row.index + 1).ToString '(e.rowIndex + ModelH.startRecord + 1).ToString
            End If
        Next
    End Sub
    Private Sub SetSummaryField2()
        Dim nilpembelian As Decimal = 0
        Dim nilhpp As Decimal = 0
        For Each row As DataGridViewRow In DataGridView2.Rows
            If Not row.IsNewRow Then
                Dim qty As Decimal = CDec(row.Cells("qty").Value)
                Dim hpp As Decimal = CDec(row.Cells("hpp").Value)
                Dim jmlhpp As Decimal = qty * hpp

                nilpembelian = nilpembelian + CDec(row.Cells("subtotal").Value)
                nilhpp = nilhpp + jmlhpp
            End If
        Next
        txtsum1tab2.Text = Format(nilpembelian, "##,##0")
        txtsum2tab2.Text = Format(nilpembelian, "##,##0")
    End Sub
#End Region
    Private Sub TxtNoMasuk_TextChanged(sender As Object, e As EventArgs) Handles TxtNoMasuk.TextChanged
        If isEdit Then
            ActiveControll()
            Dim ListDetail As List(Of Dictionary(Of String, Object)) = ModelD.GetDataList(TxtNoMasuk.Text)
            DataGridView1.Rows.Clear()
            'MsgBox(ListDetail.Count)
            If ListDetail.Count > 0 Then
                Dim rowindex As Integer = DataGridView1.NewRowIndex
                For Each dat In ListDetail
                    DataGridView1.Rows.Add()
                    DataGridView1.Rows(rowindex).Cells("mmtrid").Value = dat("mmtrid")
                    DataGridView1.Rows(rowindex).Cells("qty").Value = CDec(dat("ttrfmdqty"))
                    DataGridView1.Rows(rowindex).Cells("price").Value = CDec(dat("ttrfmdprice"))
                    DataGridView1.Rows(rowindex).Cells("dtcreated").Value = dat("dtcreated")
                    'DataGridView1.EndEdit()
                    rowindex = rowindex + 1
                Next
                DataGridView1.EndEdit()
                DataGridView1.Refresh()
            End If
        End If
    End Sub
    Private Sub TxtNoKeluar_TextChanged(sender As Object, e As EventArgs) Handles TxtNoKeluar.TextChanged
        If isEdit Then
            ActiveControll()
            Dim ListDetail As List(Of Dictionary(Of String, Object)) = ModelD.GetDataList(TxtNoKeluar.Text)
            DataGridView2.Rows.Clear()
            'MsgBox(ListDetail.Count)
            If ListDetail.Count > 0 Then
                Dim rowindex As Integer = DataGridView2.NewRowIndex
                For Each dat In ListDetail
                    DataGridView2.Rows.Add()
                    DataGridView2.Rows(rowindex).Cells("mmtrid").Value = dat("mmtrid")
                    DataGridView2.Rows(rowindex).Cells("qty").Value = CDec(dat("ttrfmdqty"))
                    DataGridView2.Rows(rowindex).Cells("price").Value = CDec(dat("ttrfmdprice"))
                    DataGridView2.Rows(rowindex).Cells("dtcreated").Value = dat("dtcreated")
                    'DataGridView1.EndEdit()
                    rowindex = rowindex + 1
                Next
                DataGridView2.EndEdit()
                DataGridView2.Refresh()
            End If
        End If
    End Sub
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        ListDataTanaman = ModelM.GetDataList(CDate(DateTimePicker1.Value))
    End Sub
    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        ListDataTanaman = ModelM.GetDataList(CDate(DateTimePicker2.Value))
    End Sub

End Class