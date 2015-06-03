Public Class FUserGroup
    Dim dt As New DataTable
    Dim DGVColumnCheckIndex As Integer

    Private Model As New MUserGroup
    Private userid As String

    Public Sub SetPrivileges()
        Try
            ToolAdd.Visible = MUsers.UserListMenuPrivileges()(MainForm.MenuActive)("pcreate")
            ToolEdit.Visible = MUsers.UserListMenuPrivileges()(MainForm.MenuActive)("pupdate")
            ToolSaveMenuAkses.Visible = MUsers.UserListMenuPrivileges()(MainForm.MenuActive)("pupdate")
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
        ToolMenuAkses.Enabled = False
        ToolSaveMenuAkses.Enabled = False
        TreeView1.Enabled = False
        Model.limitrecord = 25
        RetrieveData()
        '-------------
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
            MyApplication.ShowStatus("Failed to RetrieveData = " & ex.Message, WARNING_STAT)
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
        MyApplication.ShowStatus(Me.Text & " Loaded")
        InitializeDataGridView(DataGridView1)
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
            ToolMenuAkses.Enabled = True
            ToolDelete.Enabled = True
        ElseIf getCountSelectedData() > 1 Then
            ToolAdd.Enabled = False
            ToolEdit.Enabled = False
            ToolMenuAkses.Enabled = False
            ToolSaveMenuAkses.Enabled = False
            TreeView1.Enabled = False
            ToolDelete.Enabled = True
            TreeViewCheckUncheckAll(False)
            TreeView1.CollapseAll()
        Else
            ToolAdd.Enabled = True
            ToolEdit.Enabled = False
            ToolMenuAkses.Enabled = False
            ToolSaveMenuAkses.Enabled = False
            TreeView1.Enabled = False
            ToolDelete.Enabled = False
            TreeViewCheckUncheckAll(False)
            TreeView1.CollapseAll()
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
        FUserGroupAdd.TextBox1.Text = ""
        FUserGroupAdd.ShowDialog()
    End Sub
    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click
        If getCountSelectedData() > 0 Then
            FUserGroupAdd.txtid.Text = CStr(DataGridView1.Rows(getRowIndexSelected()).Cells("groupid").Value)
            FUserGroupAdd.TextBox1.Text = DataGridView1.Rows(getRowIndexSelected()).Cells("groupname").Value
            FUserGroupAdd.ShowDialog()
        Else
            MyApplication.ShowStatus("No data is selected", NOTICE_STAT)
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
                Dim dr As DialogResult = MessageBox.Show("Hapus " & getCountSelectedData() & " data terpilih ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If dr = Windows.Forms.DialogResult.Yes Then
                    'For Each groupid In groupids
                    '    If Not String.IsNullOrEmpty(groupid) Then
                    '        Model.DeleteData(groupid)
                    '    End If
                    'Next
                    Model.MultipleDeleteData(groupids)
                End If
                MyApplication.ShowStatus("Deleted " & getCountSelectedData() & " data", INFO_STAT)
                init()
            Else
                MyApplication.ShowStatus("No data is selected", NOTICE_STAT)
            End If

        End If
    End Sub
    Private Sub ToolMenuAkses_Click(sender As Object, e As EventArgs) Handles ToolMenuAkses.Click
        'Cursor.Current = Cursors.WaitCursor
        Dim ModelMenuList As New MUserListMenu
        If getCountSelectedData() > 0 Then
            Me.userid = CStr(DataGridView1.Rows(getRowIndexSelected()).Cells("groupid").Value)
            RemoveHandler TreeView1.AfterCheck, AddressOf TreeView1_AfterCheck
            Dim result As List(Of Dictionary(Of Object, Object)) = ModelMenuList.GetListMenuPrivileges(Me.userid)
            RetrieveTreeNodeActive(result)
            For Each FirstLevelNode As TreeNode In TreeView1.Nodes
                FirstLevelNode.Expand()
            Next
            ToolSaveMenuAkses.Enabled = True
            TreeView1.Enabled = True
            AddHandler TreeView1.AfterCheck, AddressOf TreeView1_AfterCheck
        Else
            MyApplication.ShowStatus("No data is selected", NOTICE_STAT)
        End If
        'Cursor.Current = Cursors.Default
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
        init()
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
        Cursor.Current = Cursors.WaitCursor
        Dim ModelMenuList As New MUserListMenu
        TreeView1.Nodes.Clear()
        TreeView1.CheckBoxes = True

        Dim result As List(Of Dictionary(Of String, Object)) = ModelMenuList.GetListMenu()
        RetrieveTreeNode(result)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub RetrieveTreeNode(result As List(Of Dictionary(Of String, Object)), Optional _TreeNode As TreeNode = Nothing)
        Dim node As TreeNode
        'Cursor.Current = Cursors.WaitCursor
        For Each Dict In result
            For Each keyDict As KeyValuePair(Of String, Object) In Dict
                Dim strArr() As String
                strArr = keyDict.Key.Split("-")
                If _TreeNode Is Nothing Then
                    node = TreeView1.Nodes.Add(strArr(0), strArr(1))
                Else
                    node = _TreeNode.Nodes.Add(strArr(0), strArr(1))
                End If
                If strArr(2) = "1" Then
                    'node.Nodes.Add(strArr(0) & "-pview", "Lihat")
                    node.Nodes.Add(strArr(0) & "-pcreate", "Tambah")
                    node.Nodes.Add(strArr(0) & "-pupdate", "Perbaiki")
                    node.Nodes.Add(strArr(0) & "-pdelete", "Hapus")
                End If
                'MsgBox(keyDict.Value.ToString)
                RetrieveTreeNode(keyDict.Value, node)
            Next keyDict
        Next
        'Cursor.Current = Cursors.Default
    End Sub

    Private Sub RetrieveTreeNodeActive(result As List(Of Dictionary(Of Object, Object)), Optional _TreeNode As TreeNode = Nothing)
        Dim node As TreeNode
        Cursor.Current = Cursors.WaitCursor
        Try
            For Each Dict In result
                For Each keyDict As KeyValuePair(Of Object, Object) In Dict
                    Dim strArr As Object
                    strArr = keyDict.Key
                    If _TreeNode Is Nothing Then
                        node = TreeView1.Nodes(strArr("menuid").ToString)
                    Else
                        node = _TreeNode.Nodes(strArr("menuid").ToString)
                    End If
                    node.Checked = CBool(strArr("checked"))
                    RetrieveTreeNodeActive(keyDict.Value, node)
                    If strArr("isform") = "1" Then
                        'node.Nodes(strArr("menuid").ToString & "-pview").Checked = CBool(strArr("pview"))
                        node.Nodes(strArr("menuid").ToString & "-pcreate").Checked = CBool(strArr("pcreate"))
                        node.Nodes(strArr("menuid").ToString & "-pupdate").Checked = CBool(strArr("pupdate"))
                        node.Nodes(strArr("menuid").ToString & "-pdelete").Checked = CBool(strArr("pdelete"))
                    End If

                Next keyDict
            Next
        Catch ex As Exception
            ErrorLogger.WriteToErrorLog("Error has occurred : " & ex.Message, ex.StackTrace, ERROR_STAT, "select", "2")
            MyApplication.ShowStatus("Error has occurred : " & ex.Message, ERROR_STAT, True, 10000)
        End Try
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub TreeView1_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterCheck
        RemoveHandler TreeView1.AfterCheck, AddressOf TreeView1_AfterCheck

        'MsgBox(e.Node.Name)
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
    Private Sub TreeViewCheckUncheckAll(Optional ByVal CheckAll_YesNo As Boolean = True, Optional ByVal _TreeNode As TreeNode = Nothing)
        Dim mTN As TreeNode
        If _TreeNode Is Nothing Then
            For Each mTN In TreeView1.Nodes
                TreeViewCheckUncheckAll(CheckAll_YesNo, mTN)
                mTN.Checked = CheckAll_YesNo
            Next
        Else
            For Each mTN In _TreeNode.Nodes
                TreeViewCheckUncheckAll(CheckAll_YesNo, mTN)
                mTN.Checked = CheckAll_YesNo
            Next
        End If

    End Sub
    Private Sub CheckAllChildNodes(ByVal parentNode As TreeNode)
        For Each childNode As TreeNode In parentNode.Nodes
            childNode.Checked = parentNode.Checked
            CheckAllChildNodes(childNode)
        Next
    End Sub

    Private Function NodesToArrayNodes() As List(Of Dictionary(Of String, Object))
        Dim arrNodes As New List(Of Dictionary(Of String, Object))
        Dim dict As New Dictionary(Of String, Object)
        GetAllNodes(dict)
        arrNodes.Add(dict)
        Return arrNodes
    End Function
    Private Sub GetAllNodes(ByRef dict As Dictionary(Of String, Object), Optional ByVal _TreeNode As TreeNode = Nothing)
        Dim dat As New Dictionary(Of String, Boolean)
        If _TreeNode Is Nothing Then
            For Each childNode As TreeNode In TreeView1.Nodes
                If childNode.Checked = True And Not childNode.Name.Contains("-") Then
                    For Each childActionNode As TreeNode In childNode.Nodes
                        dat.Add(childActionNode.Name, childActionNode.Checked)
                    Next
                    dict.Add(childNode.Name, dat)
                    GetAllNodes(dict, childNode)
                End If
            Next
        Else
            For Each childNode As TreeNode In _TreeNode.Nodes
                If childNode.Checked = True And Not childNode.Name.Contains("-") Then
                    For Each childActionNode As TreeNode In childNode.Nodes
                        dat.Add(childActionNode.Name, childActionNode.Checked)
                    Next
                    dict.Add(childNode.Name, dat)
                    GetAllNodes(dict, childNode)
                End If
            Next
        End If
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

    Private Sub ToolSaveMenuAkses_Click(sender As Object, e As EventArgs) Handles ToolSaveMenuAkses.Click
        Dim ModelMenuList As New MUserListMenu
        If ModelMenuList.InsertMenuPrivileges(NodesToArrayNodes(), Me.userid) > 0 Then
            MyApplication.ShowStatus("Menu akses tersimpan", INFO_STAT)
        End If
    End Sub
#End Region

    
    
    
    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Model.InsertAll()
    'End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    Model.trunctaedata()
    'End Sub
End Class
