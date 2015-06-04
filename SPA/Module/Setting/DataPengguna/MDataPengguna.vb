Public Class MDataPengguna
    Inherits CDataAcces

    Public mempid, mempname, mempaddr, memphone1, memphone2, mempemail, memposname, memposid, groupid, userid, username, password As String
    Public dtcreated, dtupdated As String

    Sub New()
        MyBase.New()
        BaseQuery = "SELECT a.mempid,a.mempname,a.mempaddr,a.memphone1,a.memphone2,a.mempemail,IFNULL(d.memposname,'') AS memposname,IFNULL(a.mlctid,'') mlctid,a.userid,b.username,b.userpassword, c.groupname,b.groupid FROM memp AS a LEFT JOIN mempos AS d ON a.memposid=d.memposid INNER JOIN muser AS b ON a.userid=b.userid INNER JOIN muserg AS c ON b.groupid=c.groupid"
        SelectQuery = "SELECT a.mempid,a.mempname,a.mempaddr,a.memphone1,a.memphone2,a.mempemail,IFNULL(d.memposname,'') AS memposname,IFNULL(a.mlctid,'') mlctid,a.userid,b.username,b.userpassword, c.groupname,b.groupid FROM memp AS a LEFT JOIN mempos AS d ON a.memposid=d.memposid INNER JOIN muser AS b ON a.userid=b.userid INNER JOIN muserg AS c ON b.groupid=c.groupid"
        TableName = "memp"
        TableName2 = "muser"
        PrimaryKey = "mempid"
        DuplicateData1 = "username"
    End Sub

    Function FindData(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "WHERE mempname like '%" & sSearch & _
                "%' OR username like '%" & sSearch & _
                "%' OR mempaddr like '%" & sSearch & _
                "%' OR memphone1 like '%" & sSearch & _
                "%' OR memphone2 like '%" & sSearch & _
                "%' OR mempemail like '%" & sSearch & _
                "%' OR username like '%" & sSearch & _
                "%' OR groupname like '%" & sSearch & "%'"
        Else
            Me.WHERE = ""
        End If
        Return MyBase.GetData
    End Function
    Public Overloads Function InsertPengguna() As Integer
        Dim dtcreated As String
        Dim dtupdated As String
        dtcreated = Format(Date.Now, "yyyy/MM/dd hh:m:s")
        dtupdated = Format(Date.Now, "yyyy/MM/dd hh:m:s")

        Me.StringSQL = "INSERT INTO " & TableName + "(mempname,mempaddr,memphone1,memphone2,mempemail,userid,dtcreated,dtupdated) VALUES " & _
                       " ( '" & mempname & "', '" & mempaddr & "', '" & memphone1 & "', '" & memphone2 & "', '" & mempemail & "', " & _
                       " '" & userid & "', '" & dtcreated & "', '" & dtupdated & "')"
        Return MyBase.InsertData()
    End Function
    Public Overloads Function InsertDataUser() As Integer
        Dim dtcreated As String
        Dim dtupdated As String
        dtcreated = Format(Date.Now, "yyyy/MM/dd hh:m:s")
        dtupdated = Format(Date.Now, "yyyy/MM/dd hh:m:s")

        Me.StringSQL = "INSERT INTO muser (username,userpassword,groupid,dtcreated,dtupdated) VALUES " & _
                       " ('" & username & "', SHA1('" & password & "'),  '" & groupid & "', '" & dtcreated & "', '" & dtupdated & "')"
        Return MyBase.InsertData()
    End Function


    Public Overloads Function UpdateDataPengguna() As Integer
        Dim dtupdated As String
        dtupdated = Format(Date.Now, "yyyy/MM/dd hh:m:s")

        Me.StringSQL = "UPDATE " & TableName + " SET mempname ='" & mempname & "',mempaddr ='" & mempaddr & "',memphone1 ='" & memphone1 & "', memphone2 ='" & memphone2 & "', " & _
            " mempemail ='" & mempemail & "',userid ='" & userid & "', dtupdated ='" & dtupdated & "' WHERE " & PrimaryKey & "=" & mempid
        Return MyBase.UpdateData()
    End Function
    Public Overloads Function UpdateDataUser() As Integer
        Dim dtupdated As String
        dtupdated = Format(Date.Now, "yyyy/MM/dd hh:m:s")

        Me.StringSQL = "UPDATE muser SET username ='" & username & "',groupid ='" & groupid & "', dtupdated ='" & dtupdated & "' "
        If Not String.IsNullOrEmpty(Me.password) Then
            Me.StringSQL = Me.StringSQL + ",userpassword = SHA1('" & password & "') "
        End If
        Me.StringSQL = Me.StringSQL + "WHERE userid = " & userid & " "
        Return MyBase.UpdateData()
    End Function
    Function MultipleDeleteData1(ByVal ids() As String) As Integer
        BeginTrans("attempting delete data, please wait ... ") 'begin transaction
        Try
            cmd.Connection = PCONN
            'cmd.Prepare()
            If IsArray(ids) And ids.Length > 0 Then
                For Each mempid As String In ids
                    If Not String.IsNullOrEmpty(mempid) Then
                        Me.StringSQL = "DELETE FROM " & TableName + " WHERE " & PrimaryKey & " = '" & mempid & "'"
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
    Function MultipleDeleteData2(ByVal ids() As String) As Integer
        BeginTrans("attempting delete data, please wait ... ") 'begin transaction
        Try
            cmd.Connection = PCONN
            'cmd.Prepare()
            If IsArray(ids) And ids.Length > 0 Then
                For Each userid As String In ids
                    If Not String.IsNullOrEmpty(userid) Then
                        If userid <> "1" Then
                            Me.StringSQL = "DELETE FROM " & TableName2 + " WHERE userid = '" & userid & "'"
                            cmd.CommandText = Me.StringSQL
                            rowCountAffected += cmd.ExecuteNonQuery()
                        End If
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
