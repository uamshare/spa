'Author : Uti
'Date : 2015-04-27
'<CLSCompliant(True)> _
Public Class BaseConnection
    Private Shared CONN As New MySql.Data.MySqlClient.MySqlConnection
    Private Shared ObjConnection As BaseConnection

    Protected Sub New(ByVal id As Integer)
        Dim msgerror As String = ""
        Dim myConnectionString As String = "server=" & My.Settings.server & ";" _
                & "uid=" & My.Settings.uid & ";" _
                & "pwd=" & My.Settings.pwd & ";" _
                & "database=" & My.Settings.database & ";"
        'Dim myConnectionString As String = "server=103.8.79.229;" _
        '        & "uid=tjeloacl;" _
        '        & "pwd=tjelocal123;" _
        '        & "database=simagro;"
        CONN.ConnectionString = myConnectionString
        'MsgBox(myConnectionString)
        Try
            CONN.Open()
            'MessageBox.Show("Connection Success")
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Select Case ex.Number
                Case 0
                    msgerror = "Error Number : " & ex.Number & " Error Message : " & ex.Message & ".Cannot connect to database server. Please contact your administrator"
                    ErrorLogger.WriteToErrorLogTxt(msgerror, ex.StackTrace, "Error Connection Database")
                    MessageBox.Show(msgerror)
                    'End
                Case 1045
                    msgerror = "Error Number : " & ex.Number & " Error Message : " & ex.Message & ".Invalid username/password, please try again"
                    ErrorLogger.WriteToErrorLogTxt(msgerror, ex.StackTrace, "Error Connection Database")
                    MessageBox.Show(msgerror)
                Case 1042
                    msgerror = "Error Number : " & ex.Number & " Error Message : " & ex.Message & ".Unable to connect to any of the specified MySQL host"
                    ErrorLogger.WriteToErrorLogTxt(msgerror, ex.StackTrace, "Error Connection Database")
                    MessageBox.Show(msgerror)
                    'End
                Case Else
                    msgerror = "Error Number : " & ex.Number & " Error Message : " & ex.Message
                    ErrorLogger.WriteToErrorLogTxt(msgerror, ex.StackTrace, "Error Connection Database")
                    MessageBox.Show(msgerror)
            End Select
            'End ' End Aplication 
            'CONN = Nothing
        End Try
    End Sub

    Public Shared Function GetInstance(Optional ByVal id As Integer = 1) As MySql.Data.MySqlClient.MySqlConnection
        'Dim Obj As BaseConnection
        If ObjConnection Is Nothing Then
            ObjConnection = New BaseConnection(id)
            'MessageBox.Show("Connection " & id)
        End If
        Return CONN
    End Function

    Public ReadOnly Property GetConnection
        Get
            Return CONN
        End Get
    End Property
End Class
