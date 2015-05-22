Public Class MTransferStokTanamanH
    Inherits CDataAcces

    Public ttrfmhno As String
    Public ttrfmhdt As String
    Public ttrfmhdesc As String
    Public ttrfmhtype As String
    Public userid As String
    Public dtcreated As String
    Sub New()
        MyBase.New()
        BaseQuery = "SELECT * FROM ttrfmh"
        SelectQuery = "SELECT `ttrfmhno`,`ttrfmhdt`,`ttrfmhdesc`,`dtcreated`,`userid` FROM ttrfmh WHERE ttrfmhtype ='in' ORDER BY 1 DESC"
        Me.TableName = "ttrfmh"
        PrimaryKey = "ttrfmhno"

        userid = MUsers.UserInfo()("userid")

    End Sub

    Public Overloads Function GetData(ByVal TransferType As String) As DataTable
        If String.IsNullOrEmpty(Me.StringSQL) Then
            Me.StringSQL = "SELECT `ttrfmhno`,`ttrfmhdt`,`ttrfmhdesc`,`dtcreated`,`userid` FROM ttrfmh WHERE ttrfmhtype ='" & TransferType & _
                "' ORDER BY 1 DESC"
        End If

        Return MyBase.GetData
    End Function
    Function FindData(sSearch As String, ByVal TransferType As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "AND ttrfmhno like '%" & sSearch & "%' " & _
                        "OR ttrfmhdt like '%" & sSearch & "%' "
        Else
            Me.WHERE = ""
        End If
        Me.StringSQL = "SELECT `ttrfmhno`,`ttrfmhdt`,`ttrfmhdesc`,`dtcreated`,`userid` FROM ttrfmh WHERE ttrfmhtype ='" & TransferType & "'"
        Return MyBase.GetData
    End Function
    Public Overloads Function InsertData() As Integer
        Dim values As String
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)
        values = "('" & ttrfmhno & "','" & _
                      ttrfmhdt & "','" & _
                      ttrfmhdesc & "','" & _
                      ttrfmhtype & "','" & _
                      userid & "','" & _
                      dtcreated & "')"
        'Me.StringSQL = "INSERT INTO " & TableName + "(`ttrfmhno`,`ttrfmhdt`,`pono`,`podate`,`supplier`,`userid`,`dtcreated`) VALUES " & values
        Me.StringSQL = IIf(Not String.IsNullOrEmpty(Me.StringSQL), Me.StringSQL, "INSERT INTO " & TableName + _
                           "(`ttrfmhno`,`ttrfmhdt`,`ttrfmhdesc`,`ttrfmhtype`,`userid`,`dtcreated`) VALUES " & values)
        Return MyBase.InsertData()
    End Function

    Public Function GetSqlInsertData() As String
        Dim values As String
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)
        values = "('" & ttrfmhno & "','" & _
                      ttrfmhdt & "','" & _
                      ttrfmhdesc & "','" & _
                      ttrfmhtype & "','" & _
                      userid & "','" & _
                      dtcreated & "')"
        Return "INSERT INTO " & TableName + "(`ttrfmhno`,`ttrfmhdt`,`ttrfmhdesc`,`ttrfmhtype`,`userid`,`dtcreated`) VALUES " & values & ";" & vbCrLf
    End Function

    Public Overloads Function UpdateData(Optional ByVal id As String = "") As Integer
        Dim setquery As String
        userid = MUsers.UserInfo()("userid")

        id = IIf(Not String.IsNullOrEmpty(id), id, ttrfmhno)
        setquery = "SET ttrfmhdt='" & ttrfmhdt & "'," & _
                    "ttrfmhdesc='" & ttrfmhdesc & "'," & _
                    "userid='" & userid & "' WHERE ttrfmhno ='" & id & "'"
        Me.StringSQL = IIf(Not String.IsNullOrEmpty(Me.StringSQL), Me.StringSQL, "UPDATE " & TableName + " " & setquery)
        Return MyBase.UpdateData()
    End Function
    Public Function GetSqlUpdateData(Optional ByVal id As String = "") As String
        Dim setquery As String
        userid = MUsers.UserInfo()("userid")

        id = IIf(Not String.IsNullOrEmpty(id), id, ttrfmhno)
        setquery = "SET ttrfmhdt='" & ttrfmhdt & "'," & _
                    "ttrfmhdesc='" & ttrfmhdesc & "'," & _
                    "userid='" & userid & "' WHERE ttrfmhno ='" & id & "'"
        Return "UPDATE " & TableName + " " & setquery & ";" & vbCrLf
    End Function
    Public Function getAutoNo(ByVal TransferType As String) As String
        Dim autono As String = Nothing
        Dim no As Integer = 0
        Dim curyear As String = Format(Date.Now, "yyyy")

        Me.StringSQL = "SELECT IFNULL(MAX(SUBSTR(ttrfmhno,7)),0) AS lasnumber FROM ttrfmh WHERE ttrfmhtype = '" & TransferType & _
                    "' AND YEAR(`ttrfmhdt`) =" & curyear
        no = Me.GetDataScalar() + 1
        If TransferType = "in" Then
            autono = My.Settings.CabangID & "TI" & Format(Date.Now, "yy") & Format(no, "0000000")
        ElseIf TransferType = "out" Then
            autono = My.Settings.CabangID & "TO" & Format(Date.Now, "yy") & Format(no, "0000000")
        End If
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
