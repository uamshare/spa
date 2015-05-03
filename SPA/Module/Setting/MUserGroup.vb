Public Class MUserGroup
    Inherits CDataAcces

    Public groupid As String
    Public groupname As String ' Field groupname

    Sub New()
        MyBase.New()
        BaseQuery = "SELECT groupid,groupname,groupaktive FROM muserg"
        SelectQuery = "SELECT groupid,groupname,groupaktive FROM muserg"
        TableName = "muserg"
        PrimaryKey = "groupid"
    End Sub

    Function FindData(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "WHERE groupname like '%" & sSearch & "%'"
        Else
            Me.WHERE = ""
        End If
        Return MyBase.GetData
    End Function
    Public Overloads Function InsertData() As Integer
        Me.StringSQL = "INSERT INTO " & TableName + "(groupname,dtcreated) VALUES('" & groupname & "','" & Format(Date.Now, "yyyy/MM/dd H:mm:ss") & "')"
        Return MyBase.InsertData()
    End Function

    Public Overloads Function UpdateData() As Integer
        Me.StringSQL = "UPDATE " & TableName + " SET groupname ='" & groupname & "' WHERE " & PrimaryKey & "=" & groupid
        Return MyBase.UpdateData()
    End Function

    Function MultipleDeleteData(ByVal ids() As String) As Integer

        Try
            BeginTrans("attempting delete data, please wait ... ") 'begin transaction
            cmd.Connection = PCONN
            'cmd.Prepare()
            If IsArray(ids) And ids.Length > 0 Then
                For Each groupid As String In ids
                    If Not String.IsNullOrEmpty(groupid) Then
                        Me.StringSQL = "DELETE FROM " & TableName + " WHERE " & PrimaryKey & " = '" & groupid & "'"
                        cmd.CommandText = Me.StringSQL
                        rowCountAffected += cmd.ExecuteNonQuery()
                    End If
                Next
            End If

            CommitTrans(" data have been deleted ", "delete") 'Commit All Transaction
            'Catch ex As MySql.Data.MySqlClient.MySqlException
            '    MyApplication.ShowStatus("Error " & ex.Number & " has occurred: " & NOTICE_STAT, True, 10000)
        Catch ex As MySql.Data.MySqlClient.MySqlException
            RollbackTrans("Error " & ex.Number & " has occurred: " & ex.Message, "delete")
            Return Nothing
        Catch ex As Exception
            RollbackTrans("Error has occurred: " & ex.Message, "delete")
            Return Nothing
        End Try

        Return rowCountAffected
    End Function

    'Function InsertAll()
    '    Try
    '        BeginTrans() 'begin transaction
    '        cmd.Connection = PCONN
    '        Dim todata As Integer = 100000
    '        For i As Integer = 1 To todata
    '            Me.StringSQL = "INSERT INTO " & TableName + "(groupname) VALUES('Group-" & i & "')"
    '            cmd.CommandText = Me.StringSQL
    '            rowCountAffected += cmd.ExecuteNonQuery() 'returns the number of rows affected. 
    '            MainForm.ToolProgressBar1.Value += 100 / todata
    '        Next
    '        CommitTrans(" data have been saved ") 'Commit All Transaction
    '    Catch ex As MySql.Data.MySqlClient.MySqlException
    '        RollbackTrans("Error " & ex.Number & " has occurred: " & ex.Message)
    '        Return Nothing
    '    End Try

    '    Return rowCountAffected
    'End Function

    'Function trunctaedata()
    '    BeginTrans() 'begin transaction
    '    Try
    '        cmd.Connection = PCONN
    '        Me.StringSQL = "TRUNCATE TABLE " & TableName
    '        cmd.CommandText = Me.StringSQL
    '        rowCountAffected += cmd.ExecuteNonQuery() 'returns the number of rows affected. 
    '        MyApplication.ShowStatus("Done. Process have been completed")
    '    Catch ex As MySql.Data.MySqlClient.MySqlException
    '        RollbackTrans("Error " & ex.Number & " has occurred: " & ex.Message)
    '        Return Nothing
    '    End Try
    '    CommitTrans(" data have been saved ") 'Commit All Transaction
    '    Return rowCountAffected
    'End Function

End Class
