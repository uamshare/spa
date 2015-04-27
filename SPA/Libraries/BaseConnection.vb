Public Class BaseConnection
    Private Shared CONN As New MySql.Data.MySqlClient.MySqlConnection
    Private Shared ObjConnection As BaseConnection

    Protected Sub New(ByVal id As Integer)
        Dim myConnectionString As String = "server=localhost;" _
                & "uid=root;" _
                & "pwd=;" _
                & "database=simagro;"
        CONN.ConnectionString = myConnectionString
        Try
            CONN.Open()
            'MessageBox.Show("Connection Success")
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Select Case ex.Number
                Case 0
                    MessageBox.Show("Cannot connect to database server. Please contact your administrator")
                    'End
                Case 1045
                    MessageBox.Show("Invalid username/password, please try again")
                Case 1042
                    MessageBox.Show("Unable to connect to any of the specified MySQL host")
                    'End
                Case Else
                    MessageBox.Show("Error No : " & ex.Number & ". " & ex.Message)
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
