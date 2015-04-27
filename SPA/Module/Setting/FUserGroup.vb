Public Class FUserGroup
    Dim dt As New DataTable
    Dim DGVColumnCheckIndex As Integer

    Private Model As New MUserGroup

    Public Sub init()
        ToolAdd.Enabled = True
        ToolEdit.Enabled = False
        ToolDelete.Enabled = False
        Model.limitrecord = 25
        RetrieveData()
        '-------------
    End Sub
#Region "Format DataGridView"
    Private Sub InitializeDataGridView()

        ' Initialize basic DataGridView properties.
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.BackgroundColor = Color.LightGray
        DataGridView1.BorderStyle = BorderStyle.Fixed3D

        ' Set property values appropriate for read-only display and  
        ' limited interactivity. 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToOrderColumns = True
        DataGridView1.ReadOnly = True
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
        DataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty

        ' Set the background color for all rows and for alternating rows.  
        ' The value for alternating rows overrides the value for all rows. 
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray

        ' Set the row and column header styles.
        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        DataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Black

    End Sub
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
                DGVColumnCheckIndex = .Columns.Add(New DataGridViewCheckBoxColumn)
                .Columns(DGVColumnCheckIndex).Name = "rowchecked"
                .Columns(DGVColumnCheckIndex).HeaderText = ".."
                .Columns(DGVColumnCheckIndex).Width = 35

                .DataSource = dt
                .Columns("groupid").Visible = False
                .Columns("groupname").HeaderText = "Group Name"
                .Columns("groupaktive").HeaderText = "Status"

                .Columns("groupid").Visible = False
                .Columns("groupname").HeaderText = "Group Name"
                .Columns("groupaktive").HeaderText = "Status"

                .RowHeadersWidth = 75
                .Columns("groupname").Width = 300
                .Columns("groupaktive").Width = 50
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
            Application.ShowStatus("Failed to RetrieveData = " & ex.Message, Color.Red)
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
            Application.ShowStatus(ex.Message, Color.Red)
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
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MessageBox.Show("Form Load")
        Application.ShowStatus(Me.Text & " Loaded")
        InitializeDataGridView()
        init()
        InitializeTreeView()
    End Sub
    Private Sub FUserGroup_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'MessageBox.Show("Event Show")
        Form1_Load(Nothing, Nothing)
    End Sub

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
        FUserGroupAdd.Show()
    End Sub
    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click
        If getCountSelectedData() > 0 Then
            FUserGroupAdd.txtid.Text = CStr(DataGridView1.Rows(getRowIndexSelected()).Cells("groupid").Value)
            FUserGroupAdd.TextBox1.Text = DataGridView1.Rows(getRowIndexSelected()).Cells("groupname").Value
            FUserGroupAdd.Show()
        Else
            Application.ShowStatus("No data is selected", Color.Yellow)
        End If

    End Sub
    Private Sub ToolDelete_Click(sender As Object, e As EventArgs) Handles ToolDelete.Click
        If DataGridView1.RowCount > 0 Then
            Dim groupids(DataGridView1.Rows.Count) As String
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                'delete data
                If DataGridView1.Rows(i).Cells(DGVColumnCheckIndex).FormattedValue = True Then
                    groupids(i) = DataGridView1.Rows(i).Cells("groupid").Value
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
                    Model.MultipleDeleteData(groupids)
                End If
                'Application.ShowStatus("Deleted " & getCountSelectedData() & " data")
                init()
            Else
                Application.ShowStatus("No data is selected", Color.Yellow)
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
    Private Sub cmbperpage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbperpage.SelectedIndexChanged
        If IsNumeric(cmbperpage.Text) Then
            Model.limitrecord = Int(cmbperpage.Text)
        Else
            Model.limitrecord = 0
        End If
        RetrieveData()
    End Sub

#Region "TreeView"

    Private Sub InitializeTreeView()
        Dim ModelMenuList As New MUserListMenu
        TreeView1.Nodes.Clear()
        TreeView1.CheckBoxes = True

        Dim result As List(Of Dictionary(Of String, Object)) = ModelMenuList.GetListMenu()
        RetrieveTreeNode(result)
        'Dim node, node1, node11, node12 As TreeNode
        'For Each dat In result
        '    For Each keydat As KeyValuePair(Of String, Object) In dat
        '        node = TreeView1.Nodes.Add("Key = {0}", keydat.Key, keydat.Value.ToString)
        '        For Each datnode In keydat.Value
        '            For Each keynode As KeyValuePair(Of String, Object) In datnode
        '                node1 = node.Nodes.Add("Key = {0}", keynode.Key)
        '                For Each datnode1 In keynode.Value
        '                    For Each keynode1 As KeyValuePair(Of String, Object) In datnode1
        '                        node1.Nodes.Add("Key = {0}", keynode1.Key)
        '                    Next keynode1
        '                    'TreeView1.Nodes.Add("Key = {0}", dat)
        '                Next
        '            Next keynode
        '        Next
        '    Next keydat
        'Next
    End Sub

    Private Sub RetrieveTreeNode(result As List(Of Dictionary(Of String, Object)), Optional _TreeNode As TreeNode = Nothing)
        Dim node As TreeNode
        For Each Dict In result
            For Each keyDict As KeyValuePair(Of String, Object) In Dict
                Dim strArr() As String
                strArr = keyDict.Key.Split("-")
                If _TreeNode Is Nothing Then
                    node = TreeView1.Nodes.Add(strArr(0), strArr(1))
                Else
                    node = _TreeNode.Nodes.Add(strArr(0), strArr(1))
                End If
                'MsgBox(keyDict.Value.ToString)
                RetrieveTreeNode(keyDict.Value, node)
            Next keyDict
        Next
    End Sub
    Private Sub TreeView1_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterCheck
        RemoveHandler TreeView1.AfterCheck, AddressOf TreeView1_AfterCheck

        Call CheckAllChildNodes(e.Node)

        If e.Node.Checked Then
            If e.Node.Parent Is Nothing = False Then
                'Dim allChecked As Boolean = True
                'Call IsEveryChildChecked(e.Node.Parent, allChecked)
                'If allChecked Then
                e.Node.Parent.Checked = True
                Call ShouldParentsBeChecked(e.Node.Parent)
                'End If
            End If
        Else
            Dim parentNode As TreeNode = e.Node.Parent
            If parentNode Is Nothing = False Then
                Dim allUnChecked As Boolean = True
                Call IsEveryChildUnChecked(e.Node.Parent, allUnChecked)
                If allUnChecked Then
                    e.Node.Parent.Checked = False
                    Call ShouldParentsBeUnChecked(e.Node.Parent)
                    Call ShouldParentsBeChecked(e.Node.Parent)
                End If
            End If
        End If

        AddHandler TreeView1.AfterCheck, AddressOf TreeView1_AfterCheck
    End Sub

    Private Sub CheckAllChildNodes(ByVal parentNode As TreeNode)
        For Each childNode As TreeNode In parentNode.Nodes
            childNode.Checked = parentNode.Checked
            CheckAllChildNodes(childNode)
        Next
    End Sub

    Private Sub IsEveryChildChecked(ByVal parentNode As TreeNode, ByRef checkValue As Boolean)
        For Each node As TreeNode In parentNode.Nodes
            Call IsEveryChildChecked(node, checkValue)
            If Not node.Checked Then
                checkValue = False
            End If
        Next
    End Sub

    Private Sub IsEveryChildUnChecked(ByVal parentNode As TreeNode, ByRef checkValue As Boolean)
        'MsgBox(parentNode.Nodes.ToString)
        If Not IsNothing(parentNode.Nodes) Then
            For Each node As TreeNode In parentNode.Nodes
                Call IsEveryChildUnChecked(node, checkValue)
                If node.Checked Then
                    checkValue = False
                End If
            Next
        End If
    End Sub

    Private Sub ShouldParentsBeChecked(ByVal startNode As TreeNode)
        If startNode.Parent Is Nothing = False Then
            'Dim allChecked As Boolean = True
            'Call IsEveryChildChecked(startNode.Parent, allChecked)
            'If allChecked Then
            '    startNode.Parent.Checked = True
            '    Call ShouldParentsBeChecked(startNode.Parent)
            'End If
            If startNode.Checked Then
                startNode.Parent.Checked = True
            End If
        End If
    End Sub
    Private Sub ShouldParentsBeUnChecked(ByVal startNode As TreeNode)
        If startNode.Parent Is Nothing = False Then
            Dim allUnChecked As Boolean = True
            Call IsEveryChildUnChecked(startNode.Parent, allUnChecked)
            If allUnChecked Then
                startNode.Parent.Checked = False
                Call ShouldParentsBeUnChecked(startNode.Parent)
            End If
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        'TreeView1.Nodes.
        MsgBox(TreeView1.Nodes(1).Checked)
    End Sub
#End Region

    
End Class
