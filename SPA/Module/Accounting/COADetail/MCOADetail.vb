Public Class MCOADetail
    Inherits CDataAcces

    Public mcoadno, mcoadname, mcoahno, mcoaclassification, mcoagroup, postbalance, postgl As String
    Public dtcreated, dtupdated As String ' Field username

    Sub New()
        MyBase.New()
        BaseQuery = "SELECT * FROM coa"
        SelectQuery = "SELECT d.mcoadno, d.mcoadname, d.mcoahno, c.mcoaclassification, g.mcoagroup, h.postbalance, h.postgl FROM mcoad AS d INNER JOIN mcoah AS h ON d.mcoahno=h.mcoahno INNER JOIN mcoac AS c ON h.mcoacid=c.mcoacid INNER JOIN mcoag AS g ON c.mcoagid=g.mcoagid"
        TableName = "mcoad"
        PrimaryKey = "mcoadno"
    End Sub

    Function FindData(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "WHERE mcoadname like '%" & sSearch & "%' OR mcoadno like '%" & sSearch & "%'"
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

        Me.StringSQL = "INSERT INTO " & TableName + "(mcoadno, mcoadname, mcoahno, dtcreated, dtupdated) VALUES " & _
                       " ('" & mcoadno & "', '" & mcoadname & "', '" & mcoahno & "', '" & dtcreated & "', '" & dtupdated & "')"
        Return MyBase.InsertData()
    End Function

    Public Overloads Function UpdateData() As Integer
        Dim dtupdated As String
        dtupdated = Format(Date.Now, "yyyy/MM/dd hh:m:s")

        Me.StringSQL = "UPDATE " & TableName + " SET mcoadname ='" & mcoadname & "',mcoahno ='" & mcoahno & "', dtupdated ='" & dtupdated & "' WHERE mcoadno='" & mcoadno & "'"
        Return MyBase.UpdateData()
    End Function

    Function MultipleDeleteData(ByVal ids() As String) As Integer
        BeginTrans("attempting delete data, please wait ... ") 'begin transaction
        Try
            cmd.Connection = PCONN
            'cmd.Prepare()
            If IsArray(ids) And ids.Length > 0 Then
                For Each mcoadno As String In ids
                    If Not String.IsNullOrEmpty(mcoadno) Then
                        Me.StringSQL = "DELETE FROM " & TableName + " WHERE " & PrimaryKey & " = '" & mcoadno & "'"
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
