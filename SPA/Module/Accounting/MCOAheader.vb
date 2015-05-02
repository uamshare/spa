Public Class MCOAheader
    Inherits CDataAcces

    Public mcoahno, mcoahname, mcoacid, postbalance, postgl, active As String
    Public dtcreated, dtupdated As String ' Field username

    Sub New()
        MyBase.New()
        BaseQuery = "SELECT h.mcoahno, h.mcoahname, c.mcoaclassification, g.mcoagroup, h.postbalance, h.postgl FROM mcoah AS h INNER JOIN mcoac AS c ON h.mcoacid=c.mcoacid INNER JOIN mcoag AS g ON c.mcoagid=g.mcoagid"
        SelectQuery = "SELECT h.mcoahno, h.mcoahname, c.mcoaclassification, g.mcoagroup, h.postbalance, h.postgl FROM mcoah AS h INNER JOIN mcoac AS c ON h.mcoacid=c.mcoacid INNER JOIN mcoag AS g ON c.mcoagid=g.mcoagid"
        TableName = "mcoah"
        PrimaryKey = "mcoahno"
    End Sub

    Function FindData(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "WHERE mcoahname like '%" & sSearch & "%' OR mcoahno like '%" & sSearch & "%'"
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

        Me.StringSQL = "INSERT INTO " & TableName + "(mcoahno,mcoahname,mcoacid,postbalance,postgl,active,dtcreated,dtupdated) VALUES " & _
                       " ('" & mcoahno & "', '" & mcoahname & "', '" & mcoacid & "', '" & postbalance & "', '" & postgl & "', '" & active & "', '" & dtcreated & "', '" & dtupdated & "')"
        Return MyBase.InsertData()
    End Function

    Public Overloads Function UpdateData() As Integer
        Dim dtupdated As String
        dtupdated = Format(Date.Now, "yyyy/MM/dd hh:m:s")

        Me.StringSQL = "UPDATE " & TableName + " SET mcoahname ='" & mcoahname & "',mcoacid ='" & mcoacid & "',postbalance ='" & postbalance & "', postgl ='" & postgl & "', active ='" & active & "', dtupdated ='" & dtupdated & "' WHERE mcoahno='" & mcoahno & "'"
        Return MyBase.UpdateData()
    End Function

    Function MultipleDeleteData(ByVal ids() As String) As Integer
        BeginTrans("attempting delete data, please wait ... ") 'begin transaction
        Try
            cmd.Connection = PCONN
            'cmd.Prepare()
            If IsArray(ids) And ids.Length > 0 Then
                For Each mcoahno As String In ids
                    If Not String.IsNullOrEmpty(mcoahno) Then
                        Me.StringSQL = "DELETE FROM " & TableName + " WHERE " & PrimaryKey & " = '" & mcoahno & "'"
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
