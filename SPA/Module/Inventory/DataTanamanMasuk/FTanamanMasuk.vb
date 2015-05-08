Public Class FTanamanMasuk
    Private ModelH As New MTanamanMasukH
    Private ModelD As New MTanamanMasukD
    Private ModelM As New MTanaman

    Private ListDataTanaman As List(Of Dictionary(Of String, Object)) = ModelM.GetDataList
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
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
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
        DateTimePicker1.Enabled = True
        DateTimePicker2.Enabled = True

    End Sub
    Private Sub ClearControll(Optional eachcontrol As Control = Nothing)
        For Each ctrl As Control In PanelHeader.Controls
            If (ctrl.GetType() Is GetType(TextBox)) Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                txt.Text = ""
            End If
        Next
        DateTimePicker1.Value = Format(Date.Now)
        DateTimePicker2.Value = Format(Date.Now)
    End Sub

#Region "Format DataGridView"
    Private Sub InitializeDataGridView()

        ' Initialize basic DataGridView properties.
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.BackgroundColor = Color.LightGray
        DataGridView1.BorderStyle = BorderStyle.Fixed3D

        ' Set property values appropriate for read-only display and  
        ' limited interactivity. 
        DataGridView1.AllowUserToAddRows = True
        DataGridView1.AllowUserToDeleteRows = True
        DataGridView1.AllowUserToOrderColumns = True
        DataGridView1.ReadOnly = False
        DataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect 'DataGridViewSelectionMode.CellSelect
        DataGridView1.MultiSelect = False
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        DataGridView1.AllowUserToResizeColumns = True
        DataGridView1.ColumnHeadersHeightSizeMode = _
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.RowHeadersWidthSizeMode = _
            DataGridViewRowHeadersWidthSizeMode.DisableResizing

        ' Set the selection background color for all the cells.
        DataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGray
        DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black

        ' Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default 
        ' value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
        DataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.White

        ' Set the background color for all rows and for alternating rows.  
        ' The value for alternating rows overrides the value for all rows. 
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.White 'Color.LightGray
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

        ' Set the row and column header styles.
        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        DataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Black

    End Sub
    Private Sub RetriveDataGrid()
        With DataGridView1
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
            DataGridView1.Columns.Add(btn)
            btn.HeaderText = ""
            btn.Text = "..."
            btn.Name = "btnmmtrid"
            btn.UseColumnTextForButtonValue = True
            btn.Width = 35

            .ColumnCount = 9
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
                .ValueType = GetType(Integer)
            End With

            With .Columns("price")
                .Width = 100
                .DefaultCellStyle().Alignment = 64 'DataGridViewContentAlignment.MiddleRight
                .HeaderCell.Style.Alignment = 64
                .DefaultCellStyle().Format = "##,000"
                .ValueType = GetType(Integer)
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
                    qty = CDec(DataGridView1.Rows(e.RowIndex).Cells("qty").Value)
                    price = CDec(DataGridView1.Rows(e.RowIndex).Cells("price").Value)
                    jml = qty * price

                    Dim cvalue = Format(CDec(DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "##,##0")
                    DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = cvalue
                    DataGridView1.Rows(e.RowIndex).Cells("subtotal").Value = Format(jml, "##,##0")
                    'MsgBox(jml)
                End If
                If DataGridView1.Columns(e.ColumnIndex).Name = "mmtrid" Then
                    If CekDuplicateID(DataGridView1.Rows(e.RowIndex).Cells("mmtrid").Value, e.RowIndex) Then
                        For Each dat In ListDataTanaman
                            'col.Add(dat("mmtrid"))
                            If dat("mmtrid") = DataGridView1.Rows(e.RowIndex).Cells("mmtrid").Value Then
                                DataGridView1.Rows(e.RowIndex).Cells("mmtrhname").Value = dat("mmtrname") 'ListDataTanaman(1)("mmtrname")
                                DataGridView1.Rows(e.RowIndex).Cells("polybag").Value = dat("polybag") 'ListDataTanaman(1)("mmtrname")
                                DataGridView1.Rows(e.RowIndex).Cells("price").Value = 0
                                'DataGridView1.Rows(e.RowIndex).Cells("qty").Value = IIf(DataGridView1.Rows(e.RowIndex).Cells("qty").Value.ToString.Length > 0, CDec(DataGridView1.Rows(e.RowIndex).Cells("qty").Value), 0)
                                'DataGridView1.Rows(e.RowIndex).Cells("price").Selected = True
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
    Private Sub DataGridView1_CellMouseUp_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Me.DataGridView1.Rows(e.RowIndex).Selected = True
            Me.rowIndex = e.RowIndex
            Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(e.RowIndex).Cells(1)
            Me.ContextMenuStrip1.Show(Me.DataGridView1, e.Location)
            ContextMenuStrip1.Show(Cursor.Position)
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
#End Region
    Private Sub FTanamanMasuk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "dd-MM-yyyy"
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "dd-MM-yyyy"

        InitializeDataGridView()
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
    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        Dim Formvalid As Boolean = True
        If TxtNo.Text = "" Then
            MyApplication.ShowStatus("No Masuk harus diisi", WARNING_STAT)
            TxtNo.Focus()
            Formvalid = False
        End If
        'If TextBox1.Text = "" Then
        '    MyApplication.ShowStatus("No PO harus diisi", WARNING_STAT)
        '    TextBox1.Focus()
        '    Formvalid = False
        'End If

        If Formvalid Then
            ModelD.trcvmhno = ModelH.EscapeString(TxtNo.Text)
            ModelD.trcvmhdt = ModelH.EscapeString(Format(DateTimePicker1.Value, "yyyy/MM/dd"))
            ModelD.pono = ModelH.EscapeString(TextBox1.Text)
            ModelD.podate = ModelH.EscapeString(Format(DateTimePicker2.Value, "yyyy/MM/dd"))
            ModelD.supplier = ModelH.EscapeString(TextBox3.Text)

            Dim ListDetail As New List(Of Dictionary(Of String, Object))
            For Each row In DataGridView1.Rows
                Dim dict As New Dictionary(Of String, Object)
                If Not row.IsNewRow Then
                    dict.Add("trcvmhno", ModelH.trcvmhno)
                    dict.Add("mmtrid", row.Cells("mmtrid").Value)
                    dict.Add("trcvmdqty", CDec(row.Cells("qty").Value))
                    dict.Add("trcvmdprice", CDec(row.Cells("price").Value))
                    dict.Add("dtcreated", row.Cells("dtcreated").FormattedValue)
                    'MsgBox(row.Cells("dtcreated").FormattedValue)
                    ListDetail.Add(dict)
                End If
            Next

            If isEdit Then
                ModelD.UpdateData(ListDetail)
                'ModelD.DeleteByNo(ModelH.trcvmhno)
            Else
                'ModelH.InsertData()
                ModelD.InsertData(ListDetail)
            End If
            init()
        End If
    End Sub

    Private Sub ButtonDel_Click(sender As Object, e As EventArgs) Handles ButtonDel.Click

    End Sub

    Private Sub ButtonPrint_Click(sender As Object, e As EventArgs) Handles ButtonPrint.Click

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        init()
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
    Private Sub ButtonH_Click(sender As Object, e As EventArgs) Handles ButtonH.Click
        Me.isEdit = True
        FListTanamanMasuk.ShowDialog()
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
                    DataGridView1.Rows(rowindex).Cells("qty").Value = CDec(dat("trcvmdqty"))
                    DataGridView1.Rows(rowindex).Cells("price").Value = CDec(dat("trcvmdprice"))
                    DataGridView1.Rows(rowindex).Cells("dtcreated").Value = dat("dtcreated")
                    'DataGridView1.EndEdit()
                    rowindex = rowindex + 1
                Next
                DataGridView1.EndEdit()
                DataGridView1.Refresh()
            End If
        End If
    End Sub
End Class