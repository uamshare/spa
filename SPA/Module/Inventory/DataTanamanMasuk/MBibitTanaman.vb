Imports System.Data.SqlClient
Public Class MBibitTanaman
    Inherits CDataAcces

    Public mmtrid1 As String
    Public mmtrid2 As String
    Public mmtrhid As String
    Public mmtrname As String
    Public polybag As String
    Public mmtrunit As String
    Public mmtrprice As Double
    Public mmtrg1 As String
    Public mmtrg2 As String
    Public GetKey1 As String
    Public GetKey2 As String
    Private Key As String



    Sub New()
        MyBase.New()

        BaseQuery = "SELECT mmtrhid,mmtrid,mmtrname,polybag,mmtrunit,mmtrprice,mmtrg, CONCAT(mmtrid, CONVERT(mmtrg, CHAR)) AS PrimaryKey FROM material_raw"
        SelectQuery = "SELECT mmtrhid,mmtrid,mmtrname,polybag,mmtrunit,mmtrprice,mmtrg, CONCAT(mmtrid, CONVERT(mmtrg, CHAR)) AS PrimaryKey FROM material_raw"
        TableName = "mmtr"

        PrimaryKey = "mmtrid"
    End Sub

    Function FindData(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "WHERE mmtrid like '%" & sSearch & "%' OR mmtrname like '%" & sSearch & "%' OR mmtrunit like '%" & sSearch & "%' OR polybag like '%" & sSearch & "%' "
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

        Me.StringSQL = "INSERT INTO " & TableName + "(mmtrhid,mmtrid,mmtrname,polybag,mmtrunit,mmtrprice,mmtrg,dtcreated,dtupdated) VALUES('" & mmtrhid & "','" & mmtrid1 & "','" & mmtrname & "','" & polybag & "','" & mmtrunit & "','" & mmtrprice & "','" & mmtrg1 & "','" & dtcreated & "','" & dtupdated & "')"
        Return MyBase.InsertData()

    End Function
    Public Overloads Function InsertData1() As Integer
        Dim dtcreated As String
        Dim dtupdated As String
        dtcreated = Format(Date.Now, "yyyy/MM/dd hh:m:s")
        dtupdated = Format(Date.Now, "yyyy/MM/dd hh:m:s")

        Me.StringSQL = "INSERT INTO " & TableName + "(mmtrhid,mmtrid,mmtrname,polybag,mmtrunit,mmtrprice,mmtrg,dtcreated,dtupdated) VALUES('" & mmtrhid & "','" & mmtrid2 & "','" & mmtrname & "','" & polybag & "','" & mmtrunit & "','" & mmtrprice & "','" & mmtrg2 & "','" & dtcreated & "','" & dtupdated & "')"
        Return MyBase.InsertData()
    End Function

    Public Overloads Function UpdateData() As Integer
        Dim dtupdated As String
        dtupdated = Format(Date.Now, "yyyy/MM/dd hh:m:s")

        Me.StringSQL = "UPDATE " & TableName + " SET mmtrhid ='" & mmtrhid & "',mmtrid ='" & mmtrid1 & "', mmtrname ='" & mmtrname & "',polybag='" & polybag & "',mmtrunit='" & mmtrunit & "',mmtrprice='" & mmtrprice & "',mmtrg='" & mmtrg1 & "',dtupdated ='" & dtupdated & "' WHERE  CONCAT(mmtrid, CONVERT(mmtrg, CHAR)) = '" & GetKey1 & "'"
        Return MyBase.UpdateData()

    End Function
    Public Overloads Function UpdateData1() As Integer
        Dim dtupdated As String
        dtupdated = Format(Date.Now, "yyyy/MM/dd hh:m:s")

        Me.StringSQL = "UPDATE " & TableName + " SET mmtrhid ='" & mmtrhid & "',mmtrid ='" & mmtrid2 & "', mmtrname ='" & mmtrname & "',polybag='" & polybag & "',mmtrunit='" & mmtrunit & "',mmtrprice='" & mmtrprice & "',mmtrg='" & mmtrg2 & "',dtupdated ='" & dtupdated & "' WHERE  CONCAT(mmtrid, CONVERT(mmtrg, CHAR)) = '" & GetKey2 & "'"
        Return MyBase.UpdateData()
    End Function

    Function MultipleDeleteData1(ByVal ids() As String) As Integer
        BeginTrans("attempting delete data, please wait ... ") 'begin transaction
        Try
            cmd.Connection = PCONN
            'cmd.Prepare()
            If IsArray(ids) And ids.Length > 0 Then
                For Each GetKey1 As String In ids
                    If Not String.IsNullOrEmpty(GetKey1) Then
                        Me.StringSQL = "DELETE FROM " & TableName + " WHERE CONCAT(mmtrid, CONVERT(mmtrg, CHAR)) = '" & GetKey1 & "' "
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
    Function MultipleDeleteData2(ByVal ids2() As String) As Integer
        BeginTrans("attempting delete data, please wait ... ") 'begin transaction
        Try
            cmd.Connection = PCONN
            'cmd.Prepare()
            If IsArray(ids2) And ids2.Length > 0 Then
                For Each GetKey2 As String In ids2
                    If Not String.IsNullOrEmpty(GetKey2) Then
                        Me.StringSQL = "DELETE FROM " & TableName + " WHERE CONCAT(mmtrid, CONVERT(mmtrg, CHAR)) = '" & GetKey2 & "'"
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
