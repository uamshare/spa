Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.ComponentModel

Public Interface IDataAccess
    Function GetData() As DataTable
    Function GetRowsCount() As Integer
    Function InsertData() As Integer
    Function UpdateData() As Integer
    Function DeleteData(ByVal id) As Integer
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
    Protected rowCountAffected As Integer

    
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

#Region "ProgresBar"
    ''Protected bgw As BackgroundWorker
    'Protected WithEvents bgw As New BackgroundWorker
    'Protected progressBar As New ProgressBar
    'Protected Sub StartProgress()
    '    'System.Threading.Thread.Sleep(500)
    '    bgw.WorkerReportsProgress = True
    '    bgw.RunWorkerAsync()
    '    'MainForm.ToolProgressBar1.Visible = True
    '    'MainForm.ToolProgressBar1.Value = 0
    'End Sub
    'Protected Sub StopProgress()
    '    'bgw.WorkerReportsProgress = True
    '    mCONN.Close()
    '    If bgw.WorkerSupportsCancellation = True Then
    '        bgw.CancelAsync()
    '    End If
    'End Sub

    'Sub bgw_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgw.DoWork
    '    'put your sql code here
    '    'Try
    '    '    BeginTrans("attempting insert data, please wait ... ") 'begin transaction
    '    '    cmd.Connection = mCONN
    '    '    cmd.CommandText = Me.StringSQL
    '    '    rowCountAffected = cmd.ExecuteNonQuery() 'returns the number of rows affected. 
    '    '    CommitTrans(" data have been saved ") 'Commit All Transaction
    '    'Catch ex As MySqlException
    '    '    RollbackTrans("Error 1 " & ex.Number & " has occurred: " & ex.Message)
    '    '    Return Nothing
    '    '    Exit Sub
    '    'Catch ex As Exception
    '    '    RollbackTrans("Error 2 has occurred: " & ex.Message)
    '    '    Exit Sub
    '    'End Try

    '    ''Return rowCountAffected
    '    Dim i As Integer = 0
    '    Do While rowCountAffected <= 0
    '        If bgw.CancellationPending = True Then
    '            e.Cancel = True
    '            Exit Do
    '        Else
    '            ' Perform a time consuming operation and report progress.
    '            'System.Threading.Thread.Sleep(500)
    '            bgw.ReportProgress(++i)
    '        End If
    '    Loop

    '    'For i As Integer = 0 To 10
    '    '    If bgw.CancellationPending = True Then
    '    '        e.Cancel = True
    '    '        Exit For
    '    '    Else
    '    '         Perform a time consuming operation and report progress.
    '    '        System.Threading.Thread.Sleep(500)
    '    '        bgw.ReportProgress(i * 100)
    '    '    End If
    '    'Next

    'End Sub
    'Sub bgw_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgw.ProgressChanged
    '    MainForm.ToolProgressBar1.Visible = True
    '    'Application.ShowStatus("attempting insert data, please wait ... ", False)
    '    MainForm.ToolProgressBar1.Value = 0
    'End Sub
    'Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles bgw.RunWorkerCompleted
    '    If e.Cancelled = True Then
    '        'MainForm.ToolProgressBar1.Visible = False
    '        MainForm.ToolProgressBar1.Value = 100
    '    ElseIf e.Error IsNot Nothing Then
    '        'Me.tbProgress.Text = "Error: " & e.Error.Message
    '        MainForm.ToolProgressBar1.Value = 100
    '    Else
    '        'Me.tbProgress.Text = "Done!"
    '        MainForm.ToolProgressBar1.Value = 100
    '    End If
    '    MainForm.ToolProgressBar1.Visible = False
    '    'mCONN.Close()
    '    'mCONN.CloseAsync()
    '    MsgBox("Complete")
    'End Sub
#End Region



    Protected Sub BeginTrans(Optional message As String = "attempting process data, please wait ... ")
        'StartProgress()
        Application.ShowStatus(message, False)
        Cursor.Current = Cursors.WaitCursor
        If mCONN.State <> ConnectionState.Closed Then mCONN.Close()
        mCONN.Open()
        Trans = mCONN.BeginTransaction
        cmd.Transaction = Trans
        rowCountAffected = 0
    End Sub
    Protected Sub CommitTrans(Optional message As String = " process have been completed")
        Trans.Commit()
        mCONN.Close()
        'StopProgress()
        Cursor.Current = Cursors.Default
        MainForm.ToolProgressBar1.Visible = True
        MainForm.ToolProgressBar1.Value = 0
        If rowCountAffected > 0 Then
            Application.ShowStatus("Done. " & rowCountAffected & message, Color.MediumSpringGreen)
        End If
        Me.StringSQL = ""
    End Sub
    Protected Sub RollbackTrans(Optional message As String = " process fails")
        MainForm.ToolProgressBar1.Value = 100
        If Trans.Connection.State <> ConnectionState.Closed Then
            Trans.Rollback() 'Rollback All Transaction
            mCONN.Close()
            'StopProgress()
        End If
        Cursor.Current = Cursors.Default
        Application.ShowStatus("Fails. " & message, Color.Red, Global.SPA.My.Resources.icon_warning, True, 10000)
    End Sub

    Function GetData() As DataTable Implements IDataAccess.GetData
        Dim SelectQuery As String
        Dim dt As New DataTable
        Try
            Cursor.Current = Cursors.WaitCursor
            If Me.mCONN.State = ConnectionState.Closed Then Me.mCONN.Open()
            If mlimitrecord > 0 Then
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
        Catch ex As Exception
            Me.mCONN.Close()
            Application.ShowStatus("Error has occurred : " & ex.Message, Color.Red, Global.SPA.My.Resources.icon_warning, True, 10000)
            'MessageBox.Show("Error has occurred : " & ex.Message)
        End Try
        Cursor.Current = Cursors.Default
        Return dt
    End Function

    Public Function GetDataReader() As MySqlDataReader
        If Me.mCONN.State = ConnectionState.Closed Then Me.mCONN.Open()
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
            Application.ShowStatus("Failed to populate database list: " + ex.Message, Color.Red, Global.SPA.My.Resources.icon_warning, True, 10000)
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
            Application.ShowStatus("Failed to populate database list: " + ex.Message, Color.Red, Global.SPA.My.Resources.icon_warning, True, 10000)
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try
        Return result
    End Function
    Function GetRowsCount() As Integer Implements IDataAccess.GetRowsCount
        'BeginTrans("attempting fetch data, please wait ... ") 'begin transaction
        Try
            Me.mCONN.Open()
            cmd.Connection = mCONN
            cmd.CommandText = "SELECT COUNT(*) FROM " & TableName & " " & mWHERE
            rowCountAffected = cmd.ExecuteScalar() 'returns the number of rows affected. 
            Me.mCONN.Close()
        Catch ex As MySqlException
            Application.ShowStatus("Error " & ex.Number & " has occurred: " & ex.Message, Color.Red, Global.SPA.My.Resources.icon_warning, True, 10000)
            Me.mCONN.Close()
            Return Nothing
        Catch ex As Exception
            Application.ShowStatus("Error has occurred: " & ex.Message, Color.Red, Global.SPA.My.Resources.icon_warning, True, 10000)
            Me.mCONN.Close()
            Return Nothing
        End Try
        'CommitTrans(" fetch data have been completed ") 'Commit All Transaction

        Return rowCountAffected
    End Function


    Function InsertData() As Integer Implements IDataAccess.InsertData
        'StartProgress()
        BeginTrans("attempting insert data, please wait ... ") 'begin transaction
        Try
            cmd.Connection = mCONN
            cmd.CommandText = Me.StringSQL
            rowCountAffected = cmd.ExecuteNonQuery() 'returns the number of rows affected. 
        Catch ex As MySqlException
            RollbackTrans("Error " & ex.Number & " has occurred: " & ex.Message)
            Return Nothing
        End Try
        CommitTrans(" data have been saved ") 'Commit All Transaction
        Return rowCountAffected


    End Function
    Function UpdateData() As Integer Implements IDataAccess.UpdateData
        Try
            BeginTrans("attempting update data, please wait ... ") 'begin transaction
            cmd.Connection = mCONN
            cmd.CommandText = Me.StringSQL
            rowCountAffected = cmd.ExecuteNonQuery() 'returns the number of rows affected. 
            CommitTrans(" data have been updated ") 'Commit All Transaction
        Catch ex As MySqlException
            RollbackTrans("Error " & ex.Number & " has occurred: " & ex.Message)
            Return Nothing
        Catch ex As Exception
            RollbackTrans("Error has occurred: " & ex.Message)
            Return Nothing
        End Try
        Return rowCountAffected
    End Function

    Function DeleteData(ByVal id) As Integer Implements IDataAccess.DeleteData

        Try
            BeginTrans("attempting delete data, please wait ... ") 'begin transaction
            cmd.Connection = mCONN
            'cmd.Prepare()
            If String.IsNullOrEmpty(Me.StringSQL) Then
                Me.StringSQL = "DELETE FROM " & TableName + " WHERE " & PrimaryKey & " = '" & id & "'"
            End If
            cmd.CommandText = Me.StringSQL
            rowCountAffected = cmd.ExecuteNonQuery()
            CommitTrans(" data have been deleted ") 'Commit All Transaction
        Catch ex As Exception
            RollbackTrans("Error has occurred: " & ex.Message)
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