Imports System.Data.SqlClient
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Public Class MTanaman
    Inherits CDataAcces

    Public mmtrid As String
    Public mmtrhid As String
    Public mmtrname As String
    Public polybag As String
    Public mmtrunit As String
    Public mmtrprice As Double
    Public mmtrg As String
    Public GetKey As String
    Private Key As String



    Sub New()
        MyBase.New()

        BaseQuery = "SELECT mmtrhid,mmtrid,mmtrname,polybag,mmtrunit,mmtrprice,mmtrg, CONCAT(mmtrid, CONVERT(mmtrg, CHAR)) AS PrimaryKey FROM material_fig"
        SelectQuery = "SELECT mmtrhid,mmtrid,mmtrname,polybag,mmtrunit,mmtrprice,mmtrg, CONCAT(mmtrid, CONVERT(mmtrg, CHAR)) AS PrimaryKey FROM material_fig"
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
        Dim dtcreated As Date = Date.Now
        Dim dtupdated As Date = Date.Now

        Me.StringSQL = "INSERT INTO " & TableName + "(mmtrhid,mmtrid,mmtrname,polybag,mmtrunit,mmtrprice,dtcreated,dtupdated) VALUES('" & mmtrhid & "','" & mmtrid & "','" & mmtrname & "','" & polybag & "','" & mmtrunit & "','" & mmtrprice & "','" & dtcreated & "','" & dtupdated & "')"
            Return MyBase.InsertData()

    End Function

    Public Overloads Function UpdateData() As Integer
        Dim dtupdated As Date = Date.Now

        Me.StringSQL = "UPDATE " & TableName + " SET mmtrid ='" & mmtrid & "', mmtrname ='" & mmtrname & "',polybag='" & polybag & "',mmtrunit='" & mmtrunit & "',mmtrprice='" & mmtrprice & "',mmtrg='" & mmtrg & "',dtupdated ='" & dtupdated & "' WHERE  CONCAT(mmtrid, CONVERT(mmtrg, CHAR)) = '" & GetKey & "'"
        Return MyBase.UpdateData()
    End Function

    Function MultipleDeleteData(ByVal ids() As String) As Integer
        BeginTrans("attempting delete data, please wait ... ") 'begin transaction
        Try
            cmd.Connection = PCONN
            'cmd.Prepare()
            If IsArray(ids) And ids.Length > 0 Then
                For Each GetKey As String In ids
                    If Not String.IsNullOrEmpty(GetKey) Then
                        Me.StringSQL = "DELETE FROM " & TableName + " WHERE CONCAT(mmtrid, CONVERT(mmtrg, CHAR)) = '" & GetKey & "'"
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
