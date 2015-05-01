Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
<CLSCompliant(True)> _
Public Interface IDataAccess
    Function GetData() As DataTable
    Function GetRowsCount() As Integer
    Function InsertData() As Integer
    Function UpdateData() As Integer
    Function DeleteData(Optional ByVal id = -1) As Integer
End Interface

Public Class CDataAcces 'Name dari Class yang dibuat.
    Implements IDataAccess

    Private mstartRecord As Integer = 0 'Deklarasi record dimulai
    Private mlimitrecord As Integer = 25
    Private mCONN As New MySql.Data.MySqlClient.MySqlConnection

    Protected TableName = "MyTable"
    Protected BaseQuery = "SELECT * FROM " & TableName
    Protected SelectQuery = "SELECT * FROM " & TableName
    Protected PrimaryKey As String
    'Protected myConnectionString As String
    Protected StringSQL As String = ""
    Protected mLIMIT As String = ""
    Protected mWHERE As String = ""
    Protected cmd As New MySqlCommand
    Protected Trans As MySqlTransaction
    Protected rowCountAffected As Integer = -1

    Sub New()
        mCONN = BaseConnection.GetInstance
    End Sub

    Public ReadOnly Property PCONN As MySql.Data.MySqlClient.MySqlConnection
        Get
            Return mCONN
        End Get
    End Property
    Public Property startRecord As Integer
        Get
            Return mstartRecord
        End Get
        Set(value As Integer)
            mstartRecord = value
        End Set
    End Property
    Public Property limitrecord As Integer
        Get
            Return mlimitrecord
        End Get
        Set(value As Integer)
            mlimitrecord = value
        End Set
    End Property
    Public Property LIMIT As String
        Get
            Return mLIMIT
        End Get
        Set(value As String)
            mLIMIT = value
        End Set
    End Property
    Public Property WHERE As String
        Get
            Return mWHERE
        End Get
        Set(value As String)
            mWHERE = value
        End Set
    End Property

    Protected Sub BeginTrans(Optional message As String = "attempting process data, please wait ... ")
        'StartProgress()
        MainForm.ToolProgressBar1.Visible = True
        MainForm.ToolProgressBar1.Value = 0
        MainForm.ToolProgressBar1.Style = ProgressBarStyle.Marquee
        MyApplication.ShowStatus(message, INFO_STAT, False)
        Cursor.Current = Cursors.WaitCursor
        If mCONN.State <> ConnectionState.Closed Then mCONN.Close()
        mCONN.Open()
        Trans = mCONN.BeginTransaction
        cmd.Transaction = Trans
        rowCountAffected = -1
    End Sub
    Protected Sub CommitTrans(Optional message As String = " process have been completed", Optional actlog As String = "")
        Trans.Commit()
        mCONN.Close()
        'MainForm.ToolProgressBar1.Visible = True
        MainForm.ToolProgressBar1.Value = 100
        MainForm.ToolProgressBar1.Style = ProgressBarStyle.Blocks

        If rowCountAffected > 0 And actlog <> "delete" Then
            Dim LogMsg As String = "Done. " & rowCountAffected & message
            ErrorLogger.WriteToErrorLog(LogMsg, actlog, INFO_STAT, actlog, "2")
            MyApplication.ShowStatus(LogMsg, INFO_STAT)
        ElseIf rowCountAffected > -1 And actlog = "delete" Then
            Dim LogMsg As String = "Done. " & rowCountAffected & message
            ErrorLogger.WriteToErrorLog(LogMsg, actlog, INFO_STAT, actlog, "2")
            MyApplication.ShowStatus(LogMsg, INFO_STAT)
        End If
        Me.StringSQL = ""
        Cursor.Current = Cursors.Default
    End Sub
    Protected Sub RollbackTrans(Optional message As String = " process fails", Optional actlog As String = "")
        MainForm.ToolProgressBar1.Value = 100
        MainForm.ToolProgressBar1.Style = ProgressBarStyle.Blocks
        If Trans.Connection.State <> ConnectionState.Closed Then
            Trans.Rollback() 'Rollback All Transaction
            mCONN.Close()
            'StopProgress()
        End If

        Dim LogMsg As String = "Fails. " & message
        ErrorLogger.WriteToErrorLog(LogMsg, actlog, ERROR_STAT, actlog, "2")
        MyApplication.ShowStatus(LogMsg, WARNING_STAT, True, 10000)
        Cursor.Current = Cursors.Default
    End Sub
    Function GetData() As DataTable Implements IDataAccess.GetData
        Dim SelectQuery As String
        Dim dt As New DataTable
        Try
            Cursor.Current = Cursors.WaitCursor
            If Me.mCONN.State <> ConnectionState.Closed Then Me.mCONN.Close()
            Me.mCONN.Open()
            If mlimitrecord > 0 Then
                If mstartRecord < 0 Then mstartRecord = 0
                mLIMIT = "LIMIT " & mstartRecord & "," & mlimitrecord
            Else
                mLIMIT = ""
            End If
            SelectQuery = Me.SelectQuery & " " & mWHERE & " " & mLIMIT
            Dim da As New MySqlDataAdapter(SelectQuery, Me.mCONN)
            da.Fill(dt)
            mLIMIT = ""
            mWHERE = ""
            Me.mCONN.Close()
        Catch ex As MySqlException
            Dim errMsg As String = "Failed to populate database list: " + ex.Message
            ErrorLogger.WriteToErrorLog(errMsg, ex.StackTrace, ERROR_STAT, "select", "2")
            MyApplication.ShowStatus(errMsg, ERROR_STAT, True, 10000)
        Catch ex As Exception
            'Me.mCONN.Close()
            ErrorLogger.WriteToErrorLog("Error has occurred : " & ex.Message, ex.StackTrace, ERROR_STAT, "select", "2")
            MyApplication.ShowStatus("Error has occurred : " & ex.Message, ERROR_STAT, True, 10000)
        End Try
        Cursor.Current = Cursors.Default
        Return dt
    End Function
    Public Function GetDataReader() As MySqlDataReader
        If Me.mCONN.State <> ConnectionState.Closed Then Me.mCONN.Close()
        Me.mCONN.Open()
        'Dim cmd As New MySqlCommand(SelectQuery, mCONN)
        Dim reader As MySqlDataReader
        reader = Nothing
        Try
            cmd.Connection = mCONN
            If String.IsNullOrEmpty(Me.StringSQL) Then Me.StringSQL = Me.SelectQuery
            cmd.CommandText = Me.StringSQL
            reader = cmd.ExecuteReader()
            'While (reader.Read())
            '    'ComboBox1.Items.Add(reader.GetString(1) + " (" + reader.GetString(0) + ")")
            'End While
        Catch ex As MySqlException
            Dim errMsg As String = "Failed to populate database list: " + ex.Message
            ErrorLogger.WriteToErrorLog(errMsg, ex.StackTrace, ERROR_STAT, "select", "2")
            MyApplication.ShowStatus(errMsg, ERROR_STAT, True, 10000)
        Catch ex As Exception
            Dim errMsg As String = ex.Message
            ErrorLogger.WriteToErrorLog(errMsg, ex.StackTrace, ERROR_STAT, "select", "2")
            MyApplication.ShowStatus(errMsg, ERROR_STAT, True, 10000)
        End Try
        Return reader
    End Function
    Protected Shared Function GetDataReader(StringSQL As String) As MySqlDataReader
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = Nothing 'for reader data
        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand 'for command sql
        'Dim StringSQL As String

        If BaseConnection.GetInstance.State = ConnectionState.Closed Then BaseConnection.GetInstance.Open()
        Try
            cmd.Connection = BaseConnection.GetInstance
            cmd.CommandText = StringSQL
            reader = cmd.ExecuteReader()
            'While (reader.Read())
            '    'ComboBox1.Items.Add(reader.GetString(1) + " (" + reader.GetString(0) + ")")
            'End While
        Catch ex As MySqlException
            Dim errMsg As String = "Kesalahan " & ex.Number & " Pesan kesalahan : " & ex.Message
            ErrorLogger.WriteToErrorLog(errMsg, ex.StackTrace, ERROR_STAT, "select", "2")
            MyApplication.ShowStatus(errMsg, ERROR_STAT, True, 10000)
        Catch ex As Exception
            Dim errMsg As String = "Terjadi kesalahan : " & ex.Message
            ErrorLogger.WriteToErrorLog(errMsg, ex.StackTrace, ERROR_STAT, "select", "2")
            MyApplication.ShowStatus(errMsg, ERROR_STAT, True, 10000)
        End Try
        Return reader
    End Function
    Public Function GetDataList() As List(Of Dictionary(Of String, Object))
        Dim result As New List(Of Dictionary(Of String, Object))
        Dim reader As MySqlDataReader

        ' Add each entry to array list
        reader = Me.GetDataReader()
        Try
            While reader.Read()
                ' Insert each column into a dictionary
                Dim dict As New Dictionary(Of String, Object)
                For count As Integer = 0 To (reader.FieldCount - 1)
                    dict.Add(reader.GetName(count), reader(count))
                Next
                ' Add the dictionary to the ArrayList
                result.Add(dict)
            End While
        Catch ex As MySqlException
            Dim errMsg As String = "Kesalahan " & ex.Number & " Pesan kesalahan : " & ex.Message
            ErrorLogger.WriteToErrorLog(errMsg, ex.StackTrace, ERROR_STAT, "select", "2")
            MyApplication.ShowStatus(errMsg, ERROR_STAT, True, 10000)
        Catch ex As Exception
            Dim errMsg As String = "Terjadi kesalahan : " & ex.Message
            ErrorLogger.WriteToErrorLog(errMsg, ex.StackTrace, ERROR_STAT, "select", "2")
            MyApplication.ShowStatus(errMsg, ERROR_STAT, True, 10000)
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try
        Return result
    End Function
    Function GetRowsCount() As Integer Implements IDataAccess.GetRowsCount
        'BeginTrans("attempting fetch data, please wait ... ") 'begin transaction
        Try
            If Me.mCONN.State <> ConnectionState.Closed Then Me.mCONN.Close()
            Me.mCONN.Open()
            cmd.Connection = mCONN
            cmd.CommandText = "SELECT COUNT(*) FROM " & TableName & " " & mWHERE
            rowCountAffected = cmd.ExecuteScalar() 'returns the number of rows affected. 
            Me.mCONN.Close()
        Catch ex As MySqlException
            Dim errMsg As String = "Kesalahan " & ex.Number & " Pesan kesalahan : " & ex.Message
            ErrorLogger.WriteToErrorLog(errMsg, ex.StackTrace, ERROR_STAT, "select", "2")
            MyApplication.ShowStatus(errMsg, ERROR_STAT, True, 10000)
            Me.mCONN.Close()
            Return Nothing
        Catch ex As Exception
            Dim errMsg As String = "Terjadi kesalahan : " & ex.Message
            ErrorLogger.WriteToErrorLog(errMsg, ex.StackTrace, ERROR_STAT, "select", "2")
            MyApplication.ShowStatus(errMsg, ERROR_STAT, True, 10000)
            Me.mCONN.Close()
            Return Nothing
        End Try
        'CommitTrans(" fetch data have been completed ") 'Commit All Transaction

        Return rowCountAffected
    End Function

    Public Function IfKeyExist(Optional keyvalue As String = "") As Boolean
        'BeginTrans("attempting fetch data, please wait ... ") 'begin transaction
        Try
            If Me.mCONN.State = ConnectionState.Closed Then Me.mCONN.Open()
            cmd.Connection = mCONN
            cmd.CommandText = IIf(String.IsNullOrEmpty(StringSQL), "SELECT COUNT(*) FROM " & TableName & " WHERE " & PrimaryKey & "='" & keyvalue & "'", StringSQL)
            rowCountAffected = cmd.ExecuteScalar() 'returns the number of rows affected. 
            'Me.mCONN.Close()

        Catch ex As MySqlException
            Dim errMsg As String = "Kesalahan " & ex.Number & " Pesan kesalahan : " & ex.Message
            ErrorLogger.WriteToErrorLog(errMsg, ex.StackTrace, ERROR_STAT, "select", "2")
            MyApplication.ShowStatus(errMsg, ERROR_STAT, True, 10000)
            Me.mCONN.Close()
            Return Nothing
        Catch ex As Exception
            Dim errMsg As String = "Terjadi kesalahan : " & ex.Message
            ErrorLogger.WriteToErrorLog(errMsg, ex.StackTrace, ERROR_STAT, "select", "2")
            MyApplication.ShowStatus(errMsg, ERROR_STAT, True, 10000)
            Me.mCONN.Close()
            Return Nothing
        End Try
        'CommitTrans(" fetch data have been completed ") 'Commit All Transaction
        Return IIf(rowCountAffected <= 0, False, True)
    End Function


    Function InsertData() As Integer Implements IDataAccess.InsertData
        Try
            BeginTrans("Persiapan untuk perbaikan data, silahkan tunggu sebentar ... ") 'begin transaction
            cmd.Connection = mCONN
            cmd.CommandText = Me.StringSQL
            rowCountAffected = cmd.ExecuteNonQuery() 'returns the number of rows affected. 
            CommitTrans(" Data telah tersimpan ", "insert") 'Commit All Transaction
        Catch ex As MySqlException
            RollbackTrans("Terjadi kesalahan saat penyimpanan data. No : " & ex.Number & " Pesan Kesalahan : " & ex.Message, "insert")
            Return Nothing
        Catch ex As Exception
            RollbackTrans("Terjadi kesalahan saat penyimpanan data : " & ex.Message, "insert")
            Return Nothing
        End Try
        Return rowCountAffected
    End Function
    Function UpdateData() As Integer Implements IDataAccess.UpdateData
        Try
            BeginTrans("Persiapan untuk perbaikan data, silahkan tunggu sebentar ... ") 'begin transaction
            cmd.Connection = mCONN
            cmd.CommandText = Me.StringSQL
            rowCountAffected = cmd.ExecuteNonQuery() 'returns the number of rows affected. 
            CommitTrans(" Data telah diperbaiki ", "update") 'Commit All Transaction
        Catch ex As MySqlException
            RollbackTrans("Terjadi kesalahan saat perbaikan data. No : " & ex.Number & " Pesan Kesalahan : " & ex.Message, "update")
            Return Nothing
        Catch ex As Exception
            RollbackTrans("Terjadi kesalahan saat perbaikan data: " & ex.Message, "update")
            Return Nothing
        End Try
        Return rowCountAffected
    End Function
    Function DeleteData(Optional ByVal id = -1) As Integer Implements IDataAccess.DeleteData
        Try
            BeginTrans("Persiapan untuk menghapus data, silahkan tunggu sebentar ... ") 'begin transaction
            cmd.Connection = mCONN
            If String.IsNullOrEmpty(Me.StringSQL) Then
                Me.StringSQL = "DELETE FROM " & TableName + " WHERE " & PrimaryKey & " = '" & id & "'"
            End If
            cmd.CommandText = Me.StringSQL
            rowCountAffected = cmd.ExecuteNonQuery()
            CommitTrans("Data telah terhapus ", "delete") 'Commit All Transaction
        Catch ex As MySqlException
            RollbackTrans("Terjadi kesalahan saat menghapus data. No : " & ex.Number & " Pesan Kesalahan : " & ex.Message, "delete")
            Return Nothing
        Catch ex As Exception
            RollbackTrans("Terjadi kesalahan saat menghapus data : " & ex.Message, "delete")
            Return Nothing
        End Try
        Return rowCountAffected
    End Function
    Function EscapeString(ByVal Input As String) As String
        Dim ReplaceString As String
        Dim FindChars = {"'", "#", """"}

        ReplaceString = Input
        For Each fchar In FindChars
            ReplaceString = Replace(ReplaceString, fchar, "\" & fchar)
        Next
        Return ReplaceString
    End Function
End Class