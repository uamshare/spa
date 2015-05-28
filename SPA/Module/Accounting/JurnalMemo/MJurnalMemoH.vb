Public Class MJurnalMemoH
    Inherits CDataAcces

    Public tjmhno As String
    Public tjmhdt As String
    Public tjmhdesc As String
    Public userid As String

    Public dtcreated As String
    Sub New()
        MyBase.New()
        BaseQuery = "SELECT * FROM tjmh"
        SelectQuery = "SELECT * FROM tjmh ORDER BY tjmhno DESC"
        Me.TableName = "tjmh"
        PrimaryKey = "tjmhno"
        userid = MUsers.UserInfo()("userid")
    End Sub
    Public Overloads Function getdata(strsql As String) As DataTable
        Me.StringSQL = strsql
        Return MyBase.GetData
    End Function
    Function FindData(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "WHERE tjmhno like '%" & sSearch & "%' " & _
                        "OR tjmhdt like '%" & sSearch & "%' " & _
                        "OR tjmhdesc like '%" & sSearch & "%' "
        Else
            Me.WHERE = ""
        End If
        Return MyBase.GetData
    End Function
    Public Overloads Function InsertData() As Integer
        Dim values As String
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)
        values = "('" & tjmhno & "','" & _
                      tjmhdt & "','" & _
                      tjmhdesc & "','" & _
                      userid & "','" & _
                      dtcreated & "')"
        'Me.StringSQL = "INSERT INTO " & TableName + "(`tjmhno`,`tjmhdt`,`tjmhdesc`,`mcusid`,`supplier`,`userid`,`dtcreated`) VALUES " & values
        Me.StringSQL = IIf(Not String.IsNullOrEmpty(Me.StringSQL), Me.StringSQL,
                           "INSERT INTO " & TableName + "(`tjmhno`,`tjmhdt`,`tjmhdesc`,`userid`,`dtcreated`) VALUES " & values)
        Return MyBase.InsertData()
    End Function
    Public Function GetSqlInsertData() As String
        Dim values As String
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)
        values = "('" & tjmhno & "','" & _
                      tjmhdt & "','" & _
                      tjmhdesc & "','" & _
                      userid & "','" & _
                      dtcreated & "')"
        Return "INSERT INTO " & TableName + "(`tjmhno`,`tjmhdt`,`tjmhdesc`,`userid`,`dtcreated`) VALUES " & values & ";" & vbCrLf
    End Function
    Public Overloads Function UpdateData(Optional ByVal id As String = "") As Integer
        Dim setquery As String
        userid = MUsers.UserInfo()("userid")

        id = IIf(Not String.IsNullOrEmpty(id), id, tjmhno)
        setquery = "SET tjmhdt='" & tjmhdt & "'," & _
                    "tjmhdesc='" & tjmhdesc & "'," & _
                    "userid='" & userid & "' WHERE tjmhno ='" & id & "'"
        Me.StringSQL = IIf(Not String.IsNullOrEmpty(Me.StringSQL), Me.StringSQL, "UPDATE " & TableName + " " & setquery)
        Return MyBase.UpdateData()
    End Function
    Public Function GetSqlUpdateData(Optional ByVal id As String = "") As String
        Dim setquery As String
        userid = MUsers.UserInfo()("userid")
        id = IIf(Not String.IsNullOrEmpty(id), id, tjmhno)
        setquery = "SET tjmhdt='" & tjmhdt & "'," & _
                    "tjmhdesc='" & tjmhdesc & "'," & _
                    "userid='" & userid & "' WHERE tjmhno ='" & id & "'"
        Return "UPDATE " & TableName + " " & setquery & ";" & vbCrLf
    End Function
    Public Function getAutoNo() As String
        Dim autono As String = Nothing
        Dim no As Integer = 0
        Dim curyear As String = Format(Date.Now, "yyyy")
        Me.StringSQL = "SELECT IFNULL(MAX(SUBSTR(tjmhno,7)),0) AS lasnumber FROM tjmh WHERE YEAR(`tjmhdt`) =" & curyear
        no = Me.GetDataScalar() + 1
        autono = My.Settings.CabangID & "JM" & Format(Date.Now, "yy") & Format(no, "0000000")
        Return autono
    End Function
    Public Overloads Function DeleteData(Optional ByVal id = -1) As Integer
        If String.IsNullOrEmpty(Me.StringSQL) Then
            Me.StringSQL = "DELETE FROM " & TableName + " WHERE " & PrimaryKey & " = '" & id & "';" & vbCrLf
        End If
        Return MyBase.DeleteData()
    End Function
    Public Function GetSqlDeleteData(Optional ByVal id = -1) As String
        Return "DELETE FROM " & TableName + " WHERE " & PrimaryKey & " = '" & id & "';" & vbCrLf
    End Function
    
End Class
