Public Class MReturPenjualanH
    Inherits CDataAcces

    Public trtrhno As String
    Public trtrhdt As String
    Public tinvhno As String
    Public trtrhnote As String
    Public userid As String

    Public dtcreated As String
    Sub New()
        MyBase.New()
        BaseQuery = "SELECT * FROM trtrh"
        SelectQuery = "SELECT `trtrhno`,`trtrhdt`,`tinvhno`,`trtrhnote`,`userid`,`dtcreated` FROM trtrh ORDER BY trtrhno DESC"
        Me.TableName = "trtrh"
        PrimaryKey = "trtrhno"
        userid = MUsers.UserInfo()("userid")
    End Sub

    Function FindData(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.StringSQL = "SELECT `trtrhno`,`trtrhdt`,`tinvhno`,`trtrhnote`,`userid`,`dtcreated` FROM trtrh "
            Me.WHERE = "WHERE trtrhno like '%" & sSearch & "%' " & _
                        "OR trtrhdt like '%" & sSearch & "%' " & _
                        "OR trtrhnote like '%" & sSearch & "%' " & _
                        "OR tinvhno like '%" & sSearch & "%' "
        Else
            Me.WHERE = ""
        End If
        Return MyBase.GetData
    End Function
    Public Overloads Function InsertData() As Integer
        Dim values As String
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)
        values = "('" & trtrhno & "','" & _
                      trtrhdt & "','" & _
                      tinvhno & "','" & _
                      trtrhnote & "','" & _
                      userid & "','" & _
                      dtcreated & "')"
        'Me.StringSQL = "INSERT INTO " & TableName + "(`trtrhno`,`trtrhdt`,`trtrhnote`,`mcusid`,`supplier`,`userid`,`dtcreated`) VALUES " & values
        Me.StringSQL = IIf(Not String.IsNullOrEmpty(Me.StringSQL), Me.StringSQL,
                           "INSERT INTO " & TableName + "(`trtrhno`,`trtrhdt`,`tinvhno`,`trtrhnote`,`userid`,`dtcreated`) VALUES " & values)
        Return MyBase.InsertData()
    End Function

    Public Function GetSqlInsertData() As String
        Dim values As String
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)
        values = "('" & trtrhno & "','" & _
                      trtrhdt & "','" & _
                      tinvhno & "','" & _
                      trtrhnote & "','" & _
                      userid & "','" & _
                      dtcreated & "')"
        Return "INSERT INTO " & TableName + "(`trtrhno`,`trtrhdt`,`tinvhno`,`trtrhnote`,`userid`,`dtcreated`) VALUES " & values & ";" & vbCrLf
    End Function

    Public Overloads Function UpdateData(Optional ByVal id As String = "") As Integer
        Dim setquery As String
        userid = MUsers.UserInfo()("userid")

        id = IIf(Not String.IsNullOrEmpty(id), id, trtrhno)
        setquery = "SET trtrhdt='" & trtrhdt & "'," & _
                    "tinvhno='" & tinvhno & "'," & _
                    "trtrhnote='" & trtrhnote & "'," & _
                    "userid='" & userid & "' WHERE trtrhno ='" & id & "'"
        Me.StringSQL = IIf(Not String.IsNullOrEmpty(Me.StringSQL), Me.StringSQL, "UPDATE " & TableName + " " & setquery)
        Return MyBase.UpdateData()
    End Function
    Public Function GetSqlUpdateData(Optional ByVal id As String = "") As String
        Dim setquery As String
        userid = MUsers.UserInfo()("userid")
        id = IIf(Not String.IsNullOrEmpty(id), id, trtrhno)
        setquery = "SET trtrhdt='" & trtrhdt & "'," & _
                    "tinvhno='" & tinvhno & "'," & _
                    "trtrhnote='" & trtrhnote & "'," & _
                    "userid='" & userid & "' WHERE trtrhno ='" & id & "'"
        Return "UPDATE " & TableName + " " & setquery & ";" & vbCrLf
    End Function

    Public Function getAutoNo() As String
        Dim autono As String = Nothing
        Dim no As Integer = 0
        Dim curyear As String = Format(Date.Now, "yyyy")
        Me.StringSQL = "SELECT IFNULL(MAX(SUBSTR(trtrhno,7)),0) AS lasnumber FROM trtrh WHERE YEAR(`trtrhdt`) =" & curyear
        no = Me.GetDataScalar() + 1
        autono = My.Settings.CabangID & "RJ" & Format(Date.Now, "yy") & Format(no, "0000000")
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
