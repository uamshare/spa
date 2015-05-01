Public Class MJenisBibitTanaman
    Inherits CDataAcces

    Public mmtrhid As String
    Public mmtrhname As String ' Field groupname
    Public dtcreated As Date
    Public dtupdated As Date

    Sub New()
        MyBase.New()
        BaseQuery = "SELECT mmtrhid,mmtrhname FROM mmtrh"
        SelectQuery = "SELECT mmtrhid,mmtrhname FROM mmtrh"
        TableName = "mmtrh"
        PrimaryKey = "mmtrhid"
    End Sub

    Function FindData(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "WHERE mmtrhname like '%" & sSearch & "%'"
        Else
            Me.WHERE = ""
        End If
        Return MyBase.GetData
    End Function
    Public Overloads Function InsertData() As Integer
        dtcreated = Format(Date.Now, "yyyy/MM/dd")
        dtupdated = Format(Date.Now, "yyyy/MM/dd")

        Me.StringSQL = "INSERT INTO " & TableName + "(mmtrhname,dtcreated,dtupdated) VALUES('" & mmtrhname & "','" & dtcreated & "','" & dtupdated & "')"
        Return MyBase.InsertData()
    End Function

    Public Overloads Function UpdateData() As Integer
        dtupdated = Format(Date.Now, "yyyy/MM/dd")

        Me.StringSQL = "UPDATE " & TableName + " SET mmtrhname ='" & mmtrhname & "',dtcreated ='" & dtcreated & "',dtupdated ='" & dtupdated & "' WHERE " & PrimaryKey & "=" & mmtrhid
        Return MyBase.UpdateData()
    End Function

    Function MultipleDeleteData(ByVal ids() As String) As Integer
        BeginTrans("attempting delete data, please wait ... ") 'begin transaction
        Try
            cmd.Connection = PCONN
            'cmd.Prepare()
            If IsArray(ids) And ids.Length > 0 Then
                For Each mmtrhid As String In ids
                    If Not String.IsNullOrEmpty(mmtrhid) Then
                        Me.StringSQL = "DELETE FROM " & TableName + " WHERE " & PrimaryKey & " = '" & mmtrhid & "'"
                        cmd.CommandText = Me.StringSQL
                        rowCountAffected += cmd.ExecuteNonQuery()
                    End If
                Next
            End If
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Application.ShowStatus("Error " & ex.Number & " has occurred: " & ex.Message, Color.Red,
                                   Global.SPA.My.Resources.icon_warning, True, 10000)
        End Try
        CommitTrans(" data have been deleted ") 'Commit All Transaction
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
    '        Application.ShowStatus("Done. Process have been completed")
    '    Catch ex As MySql.Data.MySqlClient.MySqlException
    '        RollbackTrans("Error " & ex.Number & " has occurred: " & ex.Message)
    '        Return Nothing
    '    End Try
    '    CommitTrans(" data have been saved ") 'Commit All Transaction
    '    Return rowCountAffected
    'End Function

End Class
