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

    Private ViewTableName As String
    Private ModelHpp As New Mhpp

    Sub New(Optional ViewTableName As String = "material_raw")
        MyBase.New()
        Me.ViewTableName = ViewTableName
        BaseQuery = "SELECT mmtrhid,mmtrid,mmtrname,polybag,ifnull(mmtrunit,'') as mmtrunit,mmtrprice,mmtrg, CONCAT(mmtrid, CONVERT(mmtrg, CHAR)) AS PrimaryKey FROM material_raw"
        SelectQuery = "SELECT mmtrhid,mmtrid,mmtrname,polybag,ifnull(mmtrunit,'') as mmtrunit,mmtrprice,mmtrg, CONCAT(mmtrid, CONVERT(mmtrg, CHAR)) AS PrimaryKey FROM material_raw"
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
        Try
            BeginTrans("Persiapan untuk menghapus data, silahkan tunggu sebentar ... ") 'begin transaction
            cmd.Connection = PCONN
            'cmd.Prepare()
            Me.StringSQL = ""
            If IsArray(ids) And ids.Length > 0 Then
                For Each GetKey1 As String In ids
                    If Not String.IsNullOrEmpty(GetKey1) Then
                        Me.StringSQL = Me.StringSQL & "DELETE FROM " & TableName + " WHERE CONCAT(mmtrid, CONVERT(mmtrg, CHAR)) = '" & GetKey1 & "';"
                    End If
                Next
                'If Not String.IsNullOrEmpty(Me.StringSQL) Then
                '    Me.StringSQL = Me.StringSQL.Substring(0, Me.StringSQL.Length - 1)
                'End If
            End If

            'Console.WriteLine(Me.StringSQL)
            cmd.CommandText = Me.StringSQL
            rowCountAffected += cmd.ExecuteNonQuery()
            CommitTrans("Data telah terhapus ", "delete") 'Commit All Transaction
        Catch ex As MySql.Data.MySqlClient.MySqlException
            RollbackTrans("Terjadi kesalahan saat menghapus data. No : " & ex.Number & " Pesan Kesalahan : " & ex.Message, "delete")
            Return Nothing
        Catch ex As Exception
            RollbackTrans("Terjadi kesalahan saat menghapus data : " & ex.Message, "delete")
            Return Nothing
        End Try
        Return rowCountAffected
    End Function
    Public Overloads Function GetRowsCount() As Integer
        Me.StringSQL = "SELECT COUNT(*) FROM " & ViewTableName & " " & mWHERE
        Return MyBase.GetRowsCount()
    End Function
    Public Overrides Function IfKeyExist(Optional keyvalue As String = "") As Boolean
        Me.StringSQL = "SELECT COUNT(*) FROM " & TableName & _
            " WHERE (CONCAT(SUBSTRING(mmtrid,6), CONVERT(mmtrhid, CHAR)) ='" & keyvalue & "') " & _
            "OR " & PrimaryKey & "='" & keyvalue & "'"
        Return MyBase.IfKeyExist()
    End Function
    Public Function GetListData() As List(Of Dictionary(Of String, Object))
        Me.StringSQL = "SELECT * FROM material_raw"
        Return MyBase.GetDataList()
    End Function
    Public Overloads Function getDataList(Currdt As Date, Optional noref As String = "") As List(Of Dictionary(Of String, Object))
        'MsgBox(Currdt.ToString)
        Return ModelHpp.GetDataList(Currdt, "", "material_raw")
    End Function
End Class
