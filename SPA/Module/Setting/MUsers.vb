﻿Public Class MUsers
    Inherits CDataAcces

    Public userid As String
    Public username As String ' Field username
    Public userpassword As String ' Field username
    Public Shared GRUOPUSERID As String

    Sub New()
        MyBase.New()
        BaseQuery = "SELECT a.userid,a.username,a.userstatus, a.groupid, b.groupname, LAST_INSERT_ID() FROM muser AS a INNER JOIN muserg AS b ON a.groupid=b.groupid"
        SelectQuery = "SELECT a.userid,a.username,a.userstatus, a.groupid, b.groupname, LAST_INSERT_ID() FROM muser AS a INNER JOIN muserg AS b ON a.groupid=b.groupid"
        TableName = "muser"
        PrimaryKey = "userid"
    End Sub

    Function FindData(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "WHERE username like '%" & sSearch & "%'"
        Else
            Me.WHERE = ""
        End If
        Return MyBase.GetData
    End Function
    Public Overloads Function InsertData() As Integer
        Me.StringSQL = "INSERT INTO " & TableName + "(username,userpassword) VALUES('" & username & "',md5('" & userpassword & "'))"
        Return MyBase.InsertData()
    End Function

    Public Overloads Function UpdateData() As Integer
        Me.StringSQL = "UPDATE " & TableName + " SET username ='" & username & "' WHERE " & PrimaryKey & "=" & userid
        Return MyBase.UpdateData()
    End Function
    Public Overloads Function UpdatePassword() As Integer
        Me.StringSQL = "UPDATE " & TableName + " SET userpassword =SHA1('" & userpassword & "') WHERE " & PrimaryKey & "=" & userid
        Return MyBase.UpdateData()
    End Function

    Function MultipleDeleteData(ByVal ids() As String) As Integer
        BeginTrans("attempting delete data, please wait ... ") 'begin transaction
        Try
            cmd.Connection = PCONN
            'cmd.Prepare()
            If IsArray(ids) And ids.Length > 0 Then
                For Each userid As String In ids
                    If Not String.IsNullOrEmpty(userid) Then
                        Me.StringSQL = "DELETE FROM " & TableName + " WHERE " & PrimaryKey & " = '" & userid & "'"
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
    Private Shared _UserInfo As New Dictionary(Of String, String)
    Public Shared Function UserInfo() As Dictionary(Of String, String)
        'Dim result As New List(Of Dictionary(Of String, Object)) 'for result function

        Dim result As New Dictionary(Of String, String) 'for result function
        If Not MUsers._UserInfo.ContainsKey("userid") Then
            MUsers._UserInfo.Add("userid", "Empty")
            MUsers._UserInfo.Add("username", "Empty")
            MUsers._UserInfo.Add("groupid", "Empty")
        End If
        'MsgBox(_UserInfo.Count)
        Return MUsers._UserInfo
    End Function
    ''' <summary>
    ''' Author : UAM
    ''' </summary>
    ''' <returns>Dictionary of List Menu Akser</returns>
    ''' <remarks>
    ''' Get the All Listmenu with priveleges
    ''' below example to get menu name 
    ''' MUsers.UserListMenuPrivileges()("menu501")("menuname").ToString  
    ''' 
    ''' </remarks>
    Public Shared Function UserListMenuPrivileges() As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object) 'for result function
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = Nothing 'for reader data
        Dim StringSQL As String

        Try
            StringSQL = "SELECT " & _
                        "T1.`menuid`,T1.`menuname`,T1.`keymenu`,T1.`isform`,IF(ISNULL(T2.`menuid`),0,1) AS checked," & _
                        "IF(ISNULL(T2.`pcreate`),0,T2.`pcreate`) AS pcreate," & _
                        "IF(ISNULL(T2.`pcreate`),0,T2.`pupdate`) AS pupdate," & _
                        "IF(ISNULL(T2.`pcreate`),0,T2.`pdelete`) AS pdelete," & _
                        "IF(ISNULL(T2.`pcreate`),0,T2.`pview`) AS pview " & _
                       "FROM muserl T1 LEFT OUTER JOIN (SELECT * FROM muserp WHERE `groupid`='" & UserInfo()("groupid") & "') T2 ON T1.`menuid` = T2.`menuid`"
            reader = GetDataReader(StringSQL)
            While reader.Read()
                ' Insert each column into a dictionary
                Dim columns As New Dictionary(Of String, Object)
                For count As Integer = 0 To (reader.FieldCount - 1)
                    columns.Add(reader.GetName(count), reader(count))
                Next
                'Console.WriteLine(reader.GetString("keymenu"))
                'Add the dictionary to the ArrayList
                result.Add(reader.GetString("keymenu"), columns)
            End While
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Dim errMsg As String = "Failed to populate database list: " + ex.Message
            ErrorLogger.WriteToErrorLog(errMsg, ex.StackTrace, ERROR_STAT, "select", "2")
            MyApplication.ShowStatus(errMsg, ERROR_STAT, True, 10000)
        Catch ex As Exception
            Dim errMsg As String = ex.Message
            ErrorLogger.WriteToErrorLog(errMsg, ex.StackTrace, ERROR_STAT, "select", "2")
            MyApplication.ShowStatus(errMsg, ERROR_STAT, True, 10000)
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try
        Return result
    End Function

    Public Function DoLogin(ByVal Username As String, ByVal Password As String) As Boolean
        Dim IsValidUser As Boolean = False
        Dim ObjUsers As List(Of Dictionary(Of String, Object))
        Me.StringSQL = "SELECT T1.*,IFNULL(T2.`mempname`,'') mempname FROM muser T1 LEFT JOIN memp T2 ON T1.`userid` = T2.`userid` WHERE username = '" & Username & _
                        "' AND userpassword = SHA1('" & Password & "')"
        ObjUsers = MyBase.GetDataList

        Try
            If ObjUsers.Count > 0 Then
                MUsers._UserInfo.Clear()
                For Each dat In ObjUsers
                    MUsers._UserInfo.Add("userid", dat("userid").ToString)
                    MUsers._UserInfo.Add("username", dat("username").ToString)
                    MUsers._UserInfo.Add("fullname", dat("mempname").ToString)
                    MUsers._UserInfo.Add("groupid", dat("groupid").ToString)
                    'MUsers._UserInfo.Add("userid") = dat("userid").ToString
                    'MUsers._UserInfo("username") = dat("username").ToString
                    'MUsers._UserInfo("groupid") = dat("groupid").ToString
                Next

                IsValidUser = True
            End If
        Catch ex As Exception
            Dim errMsg As String = ex.Message
            ErrorLogger.WriteToErrorLog(errMsg, ex.StackTrace, ERROR_STAT, "login", "1")
            MyApplication.ShowStatus(errMsg, ERROR_STAT, True, 10000)
        End Try
        
        Return IsValidUser
    End Function
    Public Sub DoLogout()
        MUsers._UserInfo.Clear()
    End Sub
End Class
