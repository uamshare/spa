Public Class MAkunPosting
    Inherits CDataAcces

    Public mapoid, maponame, acc_debit, acc_credit, acc_debit2, acc_credit2, acc_debit3, acc_credit3, acc_debit4, acc_credit4 As String
    Public dtcreated, dtupdated As String ' Field username

    Sub New()
        MyBase.New()
        BaseQuery = "SELECT mapoid, maponame, acc_debit, acc_credit, acc_debit2, acc_credit2, acc_debit3, acc_credit3, acc_debit4, acc_credit4 FROM mapo "
        SelectQuery = "SELECT mapoid, maponame, acc_debit, acc_credit, acc_debit2, acc_credit2, acc_debit3, acc_credit3, acc_debit4, acc_credit4 FROM mapo "
        TableName = "mapo"
        PrimaryKey = "mapoid"
    End Sub

    Function FindData(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "WHERE maponame like '%" & sSearch & "%' OR mapoid like '%" & sSearch & "%'"
        Else
            Me.WHERE = ""
        End If
        Return MyBase.GetData
    End Function
    Public Overloads Function InsertData() As Integer
        dtcreated = Format(Date.Now, "yyyy/MM/dd hh:m:s")
        dtupdated = Format(Date.Now, "yyyy/MM/dd hh:m:s")

        Me.StringSQL = "INSERT INTO " & TableName + "(mapoid, maponame, acc_debit, acc_credit, acc_debit2, acc_credit2, acc_debit3, acc_credit3, acc_debit4, acc_credit4 , dtcreated, dtupdated) VALUES " & _
                       " ('" & mapoid & "', '" & maponame & "', '" & acc_debit & "', '" & acc_credit & "', '" & acc_debit2 & "', '" & acc_credit3 & "', '" & acc_debit3 & "', '" & acc_credit3 & "', '" & acc_debit4 & "', '" & acc_credit4 & "', '" & dtcreated & "', '" & dtupdated & "')"
        Return MyBase.InsertData()
    End Function

    Public Overloads Function UpdateData() As Integer
        dtupdated = Format(Date.Now, "yyyy/MM/dd hh:m:s")

        Me.StringSQL = "UPDATE " & TableName + " SET maponame ='" & maponame & "',acc_debit ='" & acc_debit & "',acc_credit ='" & acc_credit & "',acc_debit2 ='" & acc_debit2 & "',acc_credit2 ='" & acc_credit2 & "'," & _
                     " acc_debit3 ='" & acc_debit3 & "',acc_credit3 ='" & acc_credit3 & "', acc_debit4 ='" & acc_debit4 & "',acc_credit4 ='" & acc_credit4 & "', dtupdated ='" & dtupdated & "' WHERE " & PrimaryKey & "='" & mapoid & "'"
        Return MyBase.UpdateData()
    End Function

    Function MultipleDeleteData(ByVal ids() As String) As Integer
        BeginTrans("attempting delete data, please wait ... ") 'begin transaction
        Try
            cmd.Connection = PCONN
            'cmd.Prepare()
            If IsArray(ids) And ids.Length > 0 Then
                For Each mapoid As String In ids
                    If Not String.IsNullOrEmpty(mapoid) Then
                        Me.StringSQL = "DELETE FROM " & TableName + " WHERE " & PrimaryKey & " = '" & mapoid & "'"
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

    Public Function getListAccountPosting(ByVal idtrans As String) As List(Of Dictionary(Of String, Object))
        Me.StringSQL = "SELECT * FROM mapo WHERE mapoid = '" & idtrans & "'"
        Return MyBase.GetDataList
    End Function
End Class
