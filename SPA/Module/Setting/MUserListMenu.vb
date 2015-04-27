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
        Me.StringSQL = "SELECT * FROM muserl WHERE menuparent ='" & parent & "' ORDER BY menuparent,menuid"
        Dim dict As New Dictionary(Of String, Object)
        result = MyBase.GetDataList()
        'If (result.Count > 0) Then
        For Each dat In result
            dict.Add(dat("menuid") & "-" & dat("menuname").ToString, GetListMenu(dat("menuid")))
        Next
        'End If
        ListMenu.Add(dict)
        Return ListMenu
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
            Application.ShowStatus("Error " & ex.Number & " has occurred: " & ex.Message, Color.Red,
                                   Global.SPA.My.Resources.icon_warning, True, 10000)
        End Try
        CommitTrans(" data have been deleted ") 'Commit All Transaction
        Return rowCountAffected
    End Function
End Class
