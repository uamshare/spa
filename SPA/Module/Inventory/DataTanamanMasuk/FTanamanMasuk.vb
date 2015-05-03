Public Class FTanamanMasuk
    Private Model As New MTanamanMasukH
    Private isEdit As Boolean = False
    Public Sub init()
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
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToOrderColumns = True
        DataGridView1.ReadOnly = False
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
        DataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.White

        ' Set the background color for all rows and for alternating rows.  
        ' The value for alternating rows overrides the value for all rows. 
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White

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

            Dim cmb As New DataGridViewComboBoxColumn()
            cmb.HeaderText = "Select Data"
            cmb.Name = "cmb"
            cmb.MaxDropDownItems = 4
            cmb.Items.Add("True")
            cmb.Items.Add("False")
            .Columns.Add(cmb)
            .Columns(1).Name = "mmtrid"
            .Columns(1).HeaderText = "Kode"
            .Columns(1).Width = 75

            .ColumnCount = 7
            '.Columns(1).Name = "mmtrid"
            '.Columns("mmtrid").HeaderText = "Kode"
            .Columns(2).Name = "mmtrhname"
            .Columns("mmtrhname").HeaderText = "Jenis Tanaman"
            .Columns(3).Name = "polybag"
            .Columns("polybag").HeaderText = "Polybag"
            .Columns(4).Name = "qty"
            .Columns("qty").HeaderText = "Qty"
            .Columns(5).Name = "price"
            .Columns("price").HeaderText = "Harga"
            .Columns(6).Name = "subtotal"
            .Columns("subtotal").HeaderText = "Jumlah"


            .Columns("mmtrid").Width = 100
            .Columns("mmtrhname").Width = 250
            .Columns("polybag").Width = 75
            .Columns("qty").Width = 100
            .Columns("price").Width = 100
            .Columns("subtotal").Width = 100
        End With
        'DGADDRows()
    End Sub

    Private Sub DGADDRows()
        With DataGridView1
            Dim row As Object() = New Object() {New DataGridViewCheckBoxColumn, "1", "Product 1", "1000", "", ""}
            .Rows.Add(New DataGridViewCheckBoxColumn, "1", "Product 1", "1000", "", "")
            'row = New String() {"2", "Product 2", "2000", "", ""}
            '.Rows.Add(row)
            'row = New String() {"3", "Product 3", "3000", "", ""}
            '.Rows.Add(row)
            'row = New String() {"4", "Product 4", "4000", "", ""}
            '.Rows.Add(row)
        End With
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
        TxtNo.Text = Model.getAutoNo
    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        Dim Formvalid As Boolean = True
        If TxtNo.Text = "" Then
            MyApplication.ShowStatus("No Masuk harus diisi", WARNING_STAT)
            TxtNo.Focus()
            Formvalid = False
        End If
        If TextBox1.Text = "" Then
            MyApplication.ShowStatus("No PO harus diisi", WARNING_STAT)
            TextBox1.Focus()
            Formvalid = False
        End If

        If Formvalid Then
            Model.trcvmhno = Model.EscapeString(TxtNo.Text)
            Model.trcvmhdt = Model.EscapeString(Format(DateTimePicker1.Value, "yyyy/MM/dd"))
            Model.pono = Model.EscapeString(TextBox1.Text)
            Model.podate = Model.EscapeString(Format(DateTimePicker2.Value, "yyyy/MM/dd"))
            Model.supplier = Model.EscapeString(TextBox3.Text)

            'MessageBox.Show(Model.trcvmhdt)
            If isEdit Then
                Model.UpdateData()
            Else
                Model.InsertData()
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
End Class