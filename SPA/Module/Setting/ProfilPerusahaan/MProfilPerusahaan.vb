Public Class MProfilPerusahaan
    Inherits CDataAcces

    Public mlctid, mlclname, mcpfname, mcpfaddr1, mcpfaddr2, mcpfaddr3, mcpfaddr4, mcpfaddr5, mcpfphone1, mcpfphone2, mcpfax, mcptaxcode, mcpfemail As String
    Public dtcreated, dtupdated As String ' Field username

    Sub New()
        MyBase.New()
        BaseQuery = "SELECT mlctid,mlclname,mcpfname,mcpfaddr1,mcpfaddr2,mcpfaddr3,mcpfaddr4,mcpfaddr5,mcpfphone1,mcpfphone2,mcpfax,mcptaxcode, mcpfemail FROM mlct"
        SelectQuery = "SELECT mlctid,mlclname,mcpfname,mcpfaddr1,mcpfaddr2,mcpfaddr3,mcpfaddr4,mcpfaddr5,mcpfphone1,mcpfphone2,mcpfax,mcptaxcode, mcpfemail FROM mlct"
        TableName = "mlct"
        PrimaryKey = "mlctid"
        DuplicateData1 = "mlctid"
        DuplicateData2 = "mcpfname"
    End Sub

    Function FindData(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "WHERE mlclname like '%" & sSearch & "%'"
        Else
            Me.WHERE = ""
        End If
        Return MyBase.GetData
    End Function
    Public Overloads Function InsertData() As Integer
        Dim dtcreated As String
        Dim dtupdated As String
        dtcreated = Format(Date.Now, "yyyy/MM/dd hh:m:s")
        dtupdated = Format(Date.Now, "yyyy/MM/dd hh:m:s")

        Me.StringSQL = "INSERT INTO " & TableName + "(mlctid,mlclname,mcpfname,mcpfaddr1,mcpfaddr2,mcpfaddr3,mcpfaddr4,mcpfaddr5,mcpfphone1,mcpfphone2,mcpfax,mcptaxcode, mcpfemail,dtcreated,dtupdated) VALUES " & _
                       " ('" & mlctid & "', '" & mlclname & "', '" & mcpfname & "', '" & mcpfaddr1 & "', '" & mcpfaddr2 & "', '" & mcpfaddr3 & "', '" & mcpfaddr4 & "', " & _
                       " '" & mcpfaddr5 & "','" & mcpfphone1 & "', '" & mcpfphone2 & "', '" & mcpfax & "', '" & mcptaxcode & "', '" & mcpfemail & "', '" & dtcreated & "', '" & dtupdated & "')"
        Return MyBase.InsertData()
    End Function

    Public Overloads Function UpdateData() As Integer
        Dim dtupdated As String
        dtupdated = Format(Date.Now, "yyyy/MM/dd hh:m:s")

        Me.StringSQL = "UPDATE " & TableName + " SET mlclname ='" & mlclname & "',mcpfname ='" & mcpfname & "', mcpfaddr1 ='" & mcpfaddr1 & "', " & _
            " mcpfaddr2 ='" & mcpfaddr2 & "',mcpfaddr3 ='" & mcpfaddr3 & "',mcpfaddr4 ='" & mcpfaddr4 & "',mcpfaddr5 ='" & mcpfaddr5 & "',mcpfphone1 ='" & mcpfphone1 & "', " & _
            " mcpfphone2 ='" & mcpfphone2 & "',mcpfax ='" & mcpfax & "',mcpfemail ='" & mcpfemail & "', dtupdated ='" & dtupdated & "' WHERE " & PrimaryKey & "=" & mlctid
        Return MyBase.UpdateData()
    End Function

    Function MultipleDeleteData(ByVal ids() As String) As Integer
        BeginTrans("attempting delete data, please wait ... ") 'begin transaction
        Try
            cmd.Connection = PCONN
            'cmd.Prepare()
            If IsArray(ids) And ids.Length > 0 Then
                For Each mlctid As String In ids
                    If Not String.IsNullOrEmpty(mlctid) Then
                        Me.StringSQL = "DELETE FROM " & TableName + " WHERE " & PrimaryKey & " = '" & mlctid & "'"
                        cmd.CommandText = Me.StringSQL
                        rowCountAffected += cmd.ExecuteNonQuery()
                    End If
                Next
            End If
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MyApplication.ShowStatus("Error " & ex.Number & " has occurred: " & NOTICE_STAT, True, 10000)
        End Try
        CommitTrans(" data have been deleted ", "delete") 'Commit All Transaction
        Return rowCountAffected
    End Function

End Class
