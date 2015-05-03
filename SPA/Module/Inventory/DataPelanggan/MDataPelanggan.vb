Public Class MDataPelanggan
    Inherits CDataAcces

    Public mcusid, mcusname, mcusphone1, mcusphone2, mcusfax, mcusaddr1, mcusaddr2, mcusaddr3, mcusaddr4, mcusaddr5, mcusemail, mcustaxcode As String
    Public dtcreated, dtupdated As String ' Field username

    Sub New()
        MyBase.New()
        BaseQuery = "SELECT mcusid,mcusname,mcusphone1,mcusphone2,mcusfax,mcusaddr1,mcusaddr2,mcusaddr3,mcusaddr4,mcusaddr5,mcusemail,mcustaxcode FROM mcus"
        SelectQuery = "SELECT mcusid,mcusname,mcusphone1,mcusphone2,mcusfax,mcusaddr1,mcusaddr2,mcusaddr3,mcusaddr4,mcusaddr5,mcusemail,mcustaxcode FROM mcus"
        TableName = "mcus"
        PrimaryKey = "mcusid"
        DuplicateData1 = "mcusname"
        DuplicateData2 = "mcustaxcode"
    End Sub

    Function FindData(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "WHERE mcusname like '%" & sSearch & "%'"
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

        Me.StringSQL = "INSERT INTO " & TableName + "(mcusname,mcusphone1,mcusphone2,mcusfax,mcusaddr1,mcusaddr2,mcusaddr3,mcusaddr4,mcusaddr5,mcusemail,mcustaxcode,dtcreated,dtupdated) VALUES " & _
                       " ('" & mcusname & "', '" & mcusphone1 & "', '" & mcusphone2 & "', '" & mcusfax & "', '" & mcusaddr1 & "', '" & mcusaddr2 & "', '" & mcusaddr3 & "', " & _
                       " '" & mcusaddr4 & "', '" & mcusaddr5 & "', '" & mcusemail & "', '" & mcustaxcode & "', '" & dtcreated & "', '" & dtupdated & "')"
        Return MyBase.InsertData()
    End Function

    Public Overloads Function UpdateData() As Integer
        Dim dtupdated As String
        dtupdated = Format(Date.Now, "yyyy/MM/dd hh:m:s")

        Me.StringSQL = "UPDATE " & TableName + " SET mcusname ='" & mcusname & "',mcusphone1 ='" & mcusphone1 & "',mcusphone2 ='" & mcusphone2 & "', mcusfax ='" & mcusfax & "', " & _
            " mcusaddr1 ='" & mcusaddr1 & "',mcusaddr2 ='" & mcusaddr2 & "',mcusaddr3 ='" & mcusaddr3 & "',mcusaddr4 ='" & mcusaddr4 & "',mcusaddr5 ='" & mcusaddr5 & "', " & _
            " mcusemail ='" & mcusemail & "',mcustaxcode ='" & mcustaxcode & "', dtupdated ='" & dtupdated & "' WHERE " & PrimaryKey & "=" & mcusid
        Return MyBase.UpdateData()
    End Function

    Function MultipleDeleteData(ByVal ids() As String) As Integer
        BeginTrans("attempting delete data, please wait ... ") 'begin transaction
        Try
            cmd.Connection = PCONN
            'cmd.Prepare()
            If IsArray(ids) And ids.Length > 0 Then
                For Each mcusid As String In ids
                    If Not String.IsNullOrEmpty(mcusid) Then
                        Me.StringSQL = "DELETE FROM " & TableName + " WHERE " & PrimaryKey & " = '" & mcusid & "'"
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
