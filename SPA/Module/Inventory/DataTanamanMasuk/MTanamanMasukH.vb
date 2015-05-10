Public Class MTanamanMasukH
    Inherits CDataAcces

    Public trcvmhno As String
    Public trcvmhdt As String
    Public pono As String
    Public podate As String
    Public supplier As String
    Public userid As String

    Public dtcreated As String
    Sub New()
        MyBase.New()
        BaseQuery = "SELECT * FROM trcvmh"
        SelectQuery = "SELECT `trcvmhno`,`trcvmhdt`,`pono`,`podate`,`supplier`,`dtcreated`,`userid` FROM trcvmh ORDER BY 1 DESC"
        Me.TableName = "trcvmh"
        PrimaryKey = "trcvmhno"

        userid = MUsers.UserInfo()("userid")

    End Sub

    Function FindData(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "WHERE trcvmhno like '%" & sSearch & "%' " & _
                        "OR trcvmhdt like '%" & sSearch & "%' " & _
                        "OR pono like '%" & sSearch & "%' " & _
                        "OR podate like '%" & sSearch & "%' " & _
                        "OR supplier like '%" & sSearch & "%' "
        Else
            Me.WHERE = ""
        End If
        Return MyBase.GetData
    End Function
    Public Overloads Function InsertData() As Integer
        Dim values As String
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)
        values = "('" & trcvmhno & "','" & _
                      trcvmhdt & "','" & _
                      pono & "','" & _
                      podate & "','" & _
                      supplier & "','" & _
                      userid & "','" & _
                      dtcreated & "')"
        'Me.StringSQL = "INSERT INTO " & TableName + "(`trcvmhno`,`trcvmhdt`,`pono`,`podate`,`supplier`,`userid`,`dtcreated`) VALUES " & values
        Me.StringSQL = IIf(Not String.IsNullOrEmpty(Me.StringSQL), Me.StringSQL, "INSERT INTO " & TableName + "(`trcvmhno`,`trcvmhdt`,`pono`,`podate`,`supplier`,`userid`,`dtcreated`) VALUES " & values)
        Return MyBase.InsertData()
    End Function

    Public Function GetSqlInsertData() As String
        Dim values As String
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)
        values = "('" & trcvmhno & "','" & _
                      trcvmhdt & "','" & _
                      pono & "','" & _
                      podate & "','" & _
                      supplier & "','" & _
                      userid & "','" & _
                      dtcreated & "')"
        Return "INSERT INTO " & TableName + "(`trcvmhno`,`trcvmhdt`,`pono`,`podate`,`supplier`,`userid`,`dtcreated`) VALUES " & values & ";"
    End Function

    Public Overloads Function UpdateData(Optional ByVal id As String = "") As Integer
        Dim setquery As String
        userid = MUsers.UserInfo()("userid")

        id = IIf(Not String.IsNullOrEmpty(id), id, trcvmhno)
        setquery = "SET trcvmhdt='" & trcvmhdt & "'," & _
                    "pono='" & pono & "'," & _
                    "podate='" & podate & "'," & _
                    "supplier='" & supplier & "'," & _
                    "userid='" & userid & "' WHERE trcvmhno ='" & id & "'"
        Me.StringSQL = IIf(Not String.IsNullOrEmpty(Me.StringSQL), Me.StringSQL, "UPDATE " & TableName + " " & setquery)
        Return MyBase.UpdateData()
    End Function
    Public Function GetSqlUpdateData(Optional ByVal id As String = "") As String
        Dim setquery As String
        userid = MUsers.UserInfo()("userid")

        id = IIf(Not String.IsNullOrEmpty(id), id, trcvmhno)
        setquery = "SET trcvmhdt='" & trcvmhdt & "'," & _
                    "pono='" & pono & "'," & _
                    "podate='" & podate & "'," & _
                    "supplier='" & supplier & "'," & _
                    "userid='" & userid & "' WHERE trcvmhno ='" & id & "'"
        Return "UPDATE " & TableName + " " & setquery & ";"
    End Function

    Public Function getAutoNo() As String
        Dim autono As String = Nothing
        Dim no As Integer = 0

        Me.StringSQL = "SELECT IFNULL(MAX(SUBSTR(trcvmhno,7)),0) AS lasnumber FROM trcvmh"
        no = Me.GetDataScalar() + 1
        autono = My.Settings.CabangID & "RC" & Format(Date.Now, "yy") & Format(no, "0000000")
        Return autono
    End Function
    Public Overloads Function DeleteData(Optional ByVal id = -1) As Integer
        If String.IsNullOrEmpty(Me.StringSQL) Then
            Me.StringSQL = "DELETE FROM " & TableName + " WHERE " & PrimaryKey & " = '" & id & "'"
        End If
        Return MyBase.DeleteData()
    End Function
    Public Function GetSqlDeleteData(Optional ByVal id = -1) As String
        Return "DELETE FROM " & TableName + " WHERE " & PrimaryKey & " = '" & id & "'"
    End Function
End Class
