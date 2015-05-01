Public Class MUserListMenu
    Inherits CDataAcces

    Public menuid As String
    Public order, menuname, menuparent, keymenu, controller, menuicon, menuactive As String

    Sub New()
        MyBase.New()
        BaseQuery = "SELECT * FROM muserl"
        SelectQuery = "SELECT * FROM muserl"
        TableName = "muserl"
        PrimaryKey = "menuid"
    End Sub

    Public Function GetListMenu(Optional parent As Integer = 0) As List(Of Dictionary(Of String, Object))
        Dim result As New List(Of Dictionary(Of String, Object))
        Dim ListMenu As New List(Of Dictionary(Of String, Object))
        Me.StringSQL = "SELECT * FROM muserl WHERE menuparent ='" & parent & "' ORDER BY menuparent,`order`"
        Dim dict As New Dictionary(Of String, Object)
        result = MyBase.GetDataList()
        'If (result.Count > 0) Then
        For Each dat In result
            dict.Add(dat("menuid") & "-" & dat("menuname").ToString & "-" & dat("isform").ToString, GetListMenu(dat("menuid")))
        Next
        'End If
        ListMenu.Add(dict)
        Return ListMenu
    End Function
    Public Function GetListMenuPrivileges(userid As String, Optional parent As Integer = 0) As List(Of Dictionary(Of Object, Object))
        Dim result As New List(Of Dictionary(Of String, Object))
        Dim ListMenu As New List(Of Dictionary(Of Object, Object))
        Me.StringSQL = "SELECT T1.`menuid`,T1.`isform`,IF(ISNULL(T2.`menuid`),0,1) AS checked,IF(ISNULL(T2.`pcreate`),0,T2.`pcreate`) AS pcreate,IF(ISNULL(T2.`pcreate`),0,T2.`pupdate`) AS pupdate,IF(ISNULL(T2.`pcreate`),0,T2.`pdelete`) AS pdelete,IF(ISNULL(T2.`pcreate`),0,T2.`pview`) AS pview " & _
                       "FROM muserl T1 LEFT JOIN (SELECT * FROM muserp WHERE `groupid`='" & userid & "') T2 ON T1.`menuid` = T2.`menuid` WHERE menuparent ='" & parent & "' ORDER BY menuparent,`order`"
        Dim dict As New Dictionary(Of Object, Object)
        result = MyBase.GetDataList()
        For Each dat In result
            dict.Add(dat, GetListMenuPrivileges(userid, dat("menuid")))
        Next
        'End If
        ListMenu.Add(dict)
        Return ListMenu
    End Function
    Public Overloads Function InsertMenuPrivileges(menulist As List(Of Dictionary(Of String, Object)), userid As String) As Integer
        Dim values As String = ""
        Dim pcreate As String = "1"
        Dim pupdate As String = "1"
        Dim pdelete As String = "1"
        Dim pview As String = "1"
        For Each dat In menulist
            For Each keyDict As KeyValuePair(Of String, Object) In dat
                'MsgBox(keyDict.Value.ToString())
                For Each datAction In keyDict.Value
                    If datAction.key = keyDict.Key.ToString & "-pcreate" Then pcreate = IIf(datAction.Value, "1", "0")
                    If datAction.key = keyDict.Key.ToString & "-pupdate" Then pupdate = IIf(datAction.Value, "1", "0")
                    If datAction.key = keyDict.Key.ToString & "-pdelete" Then pdelete = IIf(datAction.Value, "1", "0")
                    If datAction.key = keyDict.Key.ToString & "-pview" Then pview = IIf(datAction.Value, "1", "0")
                Next
                values = values & "('" & keyDict.Key.ToString & "','" & userid & "','" & pcreate & "','" & pupdate & "','" & pdelete & "','" & pview & "'),"
            Next keyDict
        Next
        values = values.Substring(0, values.Length - 1)

        Me.StringSQL = "DELETE FROM muserp WHERE groupid='" & userid & "'"
        If MyBase.DeleteData() > -1 Then
            Me.StringSQL = "INSERT INTO muserp (menuid,groupid,pcreate,pupdate,pdelete,pview) VALUES " & values
            Return MyBase.InsertData()
        End If
        Return 0
    End Function
    Function FindData(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "WHERE menuname like '%" & sSearch & "%'"
        Else
            Me.WHERE = ""
        End If
        Return MyBase.GetData
    End Function
    Public Overloads Function InsertData() As Integer
        Me.StringSQL = "INSERT INTO " & TableName + "(menuname) VALUES('" & menuname & "')"
        Return MyBase.InsertData()
    End Function
    Public Overloads Function UpdateData() As Integer
        Me.StringSQL = "UPDATE " & TableName + " SET menuname ='" & menuname & "' WHERE " & PrimaryKey & "=" & menuid
        Return MyBase.UpdateData()
    End Function

    Function MultipleDeleteData(ByVal ids() As String) As Integer
        BeginTrans("attempting delete data, please wait ... ") 'begin transaction
        Try
            cmd.Connection = PCONN
            'cmd.Prepare()
            If IsArray(ids) And ids.Length > 0 Then
                For Each menuid As String In ids
                    If Not String.IsNullOrEmpty(menuid) Then
                        Me.StringSQL = "DELETE FROM " & TableName + " WHERE " & PrimaryKey & " = '" & menuid & "'"
                        cmd.CommandText = Me.StringSQL
                        rowCountAffected += cmd.ExecuteNonQuery()
                    End If
                Next
            End If
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MyApplication.ShowStatus("Error " & ex.Number & " has occurred: " & ex.Message, NOTICE_STAT, True, 10000)
        End Try
        CommitTrans(" data have been deleted ", "delete") 'Commit All Transaction
        Return rowCountAffected
    End Function
End Class
