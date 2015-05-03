Public Class MKlasifikasiCOA
    Inherits CDataAcces

    Public mcoacid As String
    Public mcoaclassification As String ' Field groupname
    Public mcoagid As String

    Sub New()
        MyBase.New()
        BaseQuery = "SELECT c.mcoacid,c.mcoaclassification,g.mcoagroup FROM mcoac AS c INNER JOIN mcoag AS g ON c.mcoagid=g.mcoagid"
        SelectQuery = "SELECT c.mcoacid,c.mcoaclassification,g.mcoagroup FROM mcoac AS c INNER JOIN mcoag AS g ON c.mcoagid=g.mcoagid"
        TableName = "mcoac"
        PrimaryKey = "mcoacid"
    End Sub

    Function FindData(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "WHERE mcoaclassification like '%" & sSearch & "%'"
        Else
            Me.WHERE = ""
        End If
        Return MyBase.GetData
    End Function
    Public Overloads Function InsertData() As Integer

        Me.StringSQL = "INSERT INTO " & TableName + "(mcoacid,mcoaclassification,mcoagid) VALUES('" & mcoacid & "','" & mcoaclassification & "','" & mcoagid & "')"
        Return MyBase.InsertData()
    End Function

    Public Overloads Function UpdateData() As Integer

        Me.StringSQL = "UPDATE " & TableName + " SET mcoaclassification ='" & mcoaclassification & "',mcoagid ='" & mcoagid & "' WHERE " & PrimaryKey & "=" & mcoacid
        Return MyBase.UpdateData()
    End Function

    Function MultipleDeleteData(ByVal ids() As String) As Integer
        BeginTrans("attempting delete data, please wait ... ") 'begin transaction
        Try
            cmd.Connection = PCONN
            'cmd.Prepare()
            If IsArray(ids) And ids.Length > 0 Then
                For Each mcoacid As String In ids
                    If Not String.IsNullOrEmpty(mcoacid) Then
                        Me.StringSQL = "DELETE FROM " & TableName + " WHERE " & PrimaryKey & " = '" & mcoacid & "'"
                        cmd.CommandText = Me.StringSQL
                        rowCountAffected += cmd.ExecuteNonQuery()
                    End If
                Next
            End If
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MyApplication.ShowStatus("Error " & ex.Number & " has occurred: " & ex.Message, ERROR_STAT, True, 10000)
        End Try
        CommitTrans(" data have been deleted ") 'Commit All Transaction
        Return rowCountAffected
    End Function
End Class
