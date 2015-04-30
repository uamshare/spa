Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Public Class ErrorLogger
    Inherits CDataAcces
    Sub New()
        MyBase.New()
        BaseQuery = "SELECT * FROM logapp"
        SelectQuery = "SELECT * FROM logapp"
        TableName = "logapp"
        PrimaryKey = "logdate"
    End Sub
    '*************************************************************
    'NAME:          WriteToErrorLog
    'PURPOSE:       Open or create an error log and submit error message
    'PARAMETERS:    msg - message to be written to error file
    '               stkTrace - stack trace from error message
    '               title - title of the error file entry
    'RETURNS:       Nothing
    '*************************************************************

    Public Shared Sub WriteToErrorLog(ByVal msg As String,
                                      ByVal stkTrace As String,
                                      ByVal title As String,
                                      Optional ByVal logaction As String = "",
                                      Optional ByVal logtype As String = "1")

        ErrorLogger.WriteToErrorLogTxt(msg, stkTrace, title)
        ErrorLogger.WriteToErrorDb(msg, stkTrace, title, logaction, logtype)
    End Sub

    Public Shared Sub WriteToErrorLogTxt(ByVal msg As String, ByVal stkTrace As String, ByVal title As String)
        'check and make the directory if necessary; this is set to look in the application
        'folder, you may wish to place the error log in another location depending upon the
        'the user's role and write access to different areas of the file system
        'MessageBox.Show(Application.StartupPath & "\Errors\")
        If Not System.IO.Directory.Exists(Application.StartupPath & "\Errors\") Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\Errors\")
        End If

        Dim namefile As String = "errlog" & DateTime.Now.ToString("yyyyMMdd") & ".txt"
        'check the file
        Dim fs As FileStream = New FileStream(Application.StartupPath & "\Errors\" & namefile, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim s As StreamWriter = New StreamWriter(fs)
        s.Close()
        fs.Close()
        'log it
        Dim fs1 As FileStream = New FileStream(Application.StartupPath & "\Errors\" & namefile, FileMode.Append, FileAccess.Write)
        Dim s1 As StreamWriter = New StreamWriter(fs1)
        s1.Write("Date/Time: " & DateTime.Now.ToString() & vbCrLf)
        s1.Write("Title: " & title & vbCrLf)
        s1.Write("Message: " & msg & vbCrLf)
        s1.Write("StackTrace: " & stkTrace & vbCrLf)
        s1.Write("===========================================================================================" & vbCrLf)
        s1.Close()
        fs1.Close()
    End Sub


    Public Shared Function WriteToErrorDb(ByVal msg As String, ByVal stkTrace As String, ByVal title As String, Optional ByVal logaction As String = "", Optional ByVal logtype As String = "1") As Integer
        Dim mCONN As New MySql.Data.MySqlClient.MySqlConnection
        mCONN = BaseConnection.GetInstance
        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
        Dim Trans As MySql.Data.MySqlClient.MySqlTransaction
        Dim rowCountAffected As Integer

        Dim values As String = ""
        Dim iplocal = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList().ToString

        'begin transaction
        If mCONN.State <> ConnectionState.Closed Then mCONN.Close()
        mCONN.Open()
        Trans = mCONN.BeginTransaction
        cmd.Transaction = Trans
        rowCountAffected = -1
        Try
            values = "('" & title & "','" & _
                        stkTrace & "','" & _
                        My.Settings.server & "','" & _
                        MUsers.UserInfo()("userid") & "','" & _
                        msg & "','" & _
                        logaction & "','" & _
                        logtype & "')"
            cmd.Connection = BaseConnection.GetInstance
            cmd.CommandText = "INSERT INTO logapp (logapptitle,logappstktrace,logipserver,userid,logdesc,logaction,logtype) VALUES " & values
            rowCountAffected = cmd.ExecuteNonQuery() 'returns the number of rows affected. 
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Trans.Rollback() 'Rollback All Transaction
            'mCONN.Close()
            ErrorLogger.WriteToErrorLogTxt(ex.Message, ex.StackTrace, "Error Write LogDb")
            Return Nothing
        End Try
        Trans.Commit()
        'mCONN.Close()
        Return rowCountAffected
    End Function
End Class
