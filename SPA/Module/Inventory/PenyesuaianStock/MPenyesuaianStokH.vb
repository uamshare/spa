Public Class MPenyesuaianStokH
    Inherits CDataAcces

    Public tajsmhno As String
    Public tajsmhdt As String
    Public tajsmhinf As String
    Public mmtrg As String
    Public userid As String
    Public dtcreated As String

    Sub New()
        MyBase.New()
        BaseQuery = "SELECT * FROM tajsmh"
        SelectQuery = "SELECT `tajsmhno`,`tajsmhdt`,`tajsmhinf`,`dtcreated`,`userid` FROM tajsmh WHERE mmtrg = '3' ORDER BY 1 DESC"
        Me.TableName = "tajsmh"
        PrimaryKey = "tajsmhno"

        userid = MUsers.UserInfo()("userid")

    End Sub
    Public Overloads Function GetData(ByVal mmtrg As String) As DataTable
        If String.IsNullOrEmpty(Me.StringSQL) Then
            Me.StringSQL = "SELECT `tajsmhno`,`tajsmhdt`,`tajsmhinf`,`dtcreated`,`userid` FROM tajsmh WHERE mmtrg = '" & mmtrg & "'  ORDER BY 1 DESC"
        End If
        Return MyBase.GetData
    End Function
    Function FindData(sSearch As String, mmtrg As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "AND tajsmhno like '%" & sSearch & "%' " & _
                        "OR tajsmhinf like '%" & sSearch & "%' " & _
                        "OR tajsmhdt like '%" & sSearch & "%' "
        Else
            Me.WHERE = ""
        End If
        Me.StringSQL = "SELECT `tajsmhno`,`tajsmhdt`,`tajsmhinf`,`dtcreated`,`userid` FROM tajsmh WHERE mmtrg = '" & mmtrg & "' "
        Return MyBase.GetData
    End Function
    Public Overloads Function InsertData() As Integer
        Dim values As String
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)
        values = "('" & tajsmhno & "','" & _
                      tajsmhdt & "','" & _
                      tajsmhinf & "','" & _
                      mmtrg & "','" & _
                      userid & "','" & _
                      dtcreated & "')"
        'Me.StringSQL = "INSERT INTO " & TableName + "(`tajsmhno`,`tajsmhdt`,`pono`,`podate`,`supplier`,`userid`,`dtcreated`) VALUES " & values
        Me.StringSQL = IIf(Not String.IsNullOrEmpty(Me.StringSQL), Me.StringSQL, "INSERT INTO " & TableName + _
                           "(`tajsmhno`,`tajsmhdt`,`tajsmhinf`,`mmtrg`,`userid`,`dtcreated`) VALUES " & values)
        Return MyBase.InsertData()
    End Function

    Public Function GetSqlInsertData() As String
        Dim values As String
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)
        values = "('" & tajsmhno & "','" & _
                      tajsmhdt & "','" & _
                      tajsmhinf & "','" & _
                      mmtrg & "','" & _
                      userid & "','" & _
                      dtcreated & "')"
        Return "INSERT INTO " & TableName + "(`tajsmhno`,`tajsmhdt`,`tajsmhinf`,`mmtrg`,`userid`,`dtcreated`) VALUES " & values & ";" & vbCrLf
    End Function

    Public Overloads Function UpdateData(Optional ByVal id As String = "") As Integer
        Dim setquery As String
        userid = MUsers.UserInfo()("userid")

        id = IIf(Not String.IsNullOrEmpty(id), id, tajsmhno)
        setquery = "SET tajsmhdt='" & tajsmhdt & "'," & _
                    "tajsmhinf='" & tajsmhinf & "'," & _
                    "userid='" & userid & "' WHERE tajsmhno ='" & id & "'"
        Me.StringSQL = IIf(Not String.IsNullOrEmpty(Me.StringSQL), Me.StringSQL, "UPDATE " & TableName + " " & setquery)
        Return MyBase.UpdateData()
    End Function
    Public Function GetSqlUpdateData(Optional ByVal id As String = "") As String
        Dim setquery As String
        userid = MUsers.UserInfo()("userid")

        id = IIf(Not String.IsNullOrEmpty(id), id, tajsmhno)
        setquery = "SET tajsmhdt='" & tajsmhdt & "'," & _
                    "tajsmhinf='" & tajsmhinf & "'," & _
                    "userid='" & userid & "' WHERE tajsmhno ='" & id & "'"
        Return "UPDATE " & TableName + " " & setquery & ";" & vbCrLf
    End Function
    Public Function getAutoNo(ByVal mmtrg As String) As String
        Dim autono As String = Nothing
        Dim no As Integer = 0
        Dim curyear As String = Format(Date.Now, "yyyy")

        Me.StringSQL = "SELECT IFNULL(MAX(SUBSTR(tajsmhno,7)),0) AS lasnumber FROM tajsmh WHERE mmtrg ='" & mmtrg & "' AND YEAR(`tajsmhdt`) =" & curyear
        no = Me.GetDataScalar() + 1

        Select Case mmtrg
            Case "1"
                autono = My.Settings.CabangID & "AH" & Format(Date.Now, "yy") & Format(no, "0000000")
            Case "2"
                autono = My.Settings.CabangID & "AI" & Format(Date.Now, "yy") & Format(no, "0000000")
            Case "3"
                autono = My.Settings.CabangID & "AJ" & Format(Date.Now, "yy") & Format(no, "0000000")
        End Select

        Return autono
    End Function
    Public Overloads Function DeleteData(Optional ByVal id = -1) As Integer
        If String.IsNullOrEmpty(Me.StringSQL) Then
            Me.StringSQL = "DELETE FROM " & TableName + " WHERE " & PrimaryKey & " = '" & id & "'"
        End If
        Return MyBase.DeleteData()
    End Function
    Public Function GetSqlDeleteData(Optional ByVal id = -1) As String
        Return "DELETE FROM " & TableName + " WHERE " & PrimaryKey & " = '" & id & "';" & vbCrLf
    End Function
End Class
