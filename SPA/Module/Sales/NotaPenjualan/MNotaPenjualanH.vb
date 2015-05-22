Public Class MNotaPenjualanH
    Inherits CDataAcces

    Public tinvhno As String
    Public tinvhdt As String
    Public tinvhnote As String
    Public mcusid As String
    Public userid As String

    Public tinvhdisc1 As String
    Public tinvhdisc2 As String
    'Public tinvhbonus As String
    Public tinvhongpack As String
    Public tinvhongkir As String

    Public dtcreated As String
    Sub New()
        MyBase.New()
        BaseQuery = "SELECT * FROM tinvh"
        SelectQuery = "SELECT T1.`tinvhno`,`tinvhdt`,`tinvhnote`,T1.`mcusid`,`mcusname`,SUM(T2.`tinvdprice`) AS subtotal,`tinvhdisc1`,`tinvhdisc2`, " & _
                        "`tinvhongkir`,`tinvhongpack`,(SUM(T2.`tinvdprice`) - tinvhdisc2 + tinvhongkir + tinvhongpack)  AS total, " & _
                        "T1.`dtcreated`,`userid` FROM tinvh T1 " & _
                        "INNER JOIN tinvd T2 ON T1.`tinvhno` = T2.`tinvhno` " & _
                        "INNER JOIN mcus T3 ON T1.`mcusid`=T3.`mcusid` " & _
                        "GROUP BY T1.`tinvhno` ORDER BY tinvhno DESC"
        Me.TableName = "tinvh"
        PrimaryKey = "tinvhno"
        userid = MUsers.UserInfo()("userid")
    End Sub

    Function FindData(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.StringSQL = "SELECT `tinvhno`,`tinvhdt`,`tinvhnote`,T1.`mcusid`,`mcusname`,T1.`dtcreated`,`userid` FROM tinvh T1 INNER JOIN mcus T2 ON T1.`mcusid`=T2.`mcusid`"
            Me.WHERE = "WHERE tinvhno like '%" & sSearch & "%' " & _
                        "OR tinvhdt like '%" & sSearch & "%' " & _
                        "OR tinvhnote like '%" & sSearch & "%' " & _
                        "OR mcusid like '%" & sSearch & "%' " & _
                        "OR tinvhdisc1 like '%" & sSearch & "%' " & _
                        "OR tinvhdisc2 like '%" & sSearch & "%' " & _
                        "OR subtotal like '%" & sSearch & "%' " & _
                        "OR tinvhongkir like '%" & sSearch & "%' " & _
                        "OR tinvhongpack like '%" & sSearch & "%' " & _
                        "OR total like '%" & sSearch & "%' " & _
                        "OR mcusname like '%" & sSearch & "%' "
        Else
            Me.WHERE = ""
        End If
        Return MyBase.GetData
    End Function
    Public Overloads Function InsertData() As Integer
        Dim values As String
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)
        values = "('" & tinvhno & "','" & _
                      tinvhdt & "','" & _
                      tinvhnote & "','" & _
                      mcusid & "','" & _
                      tinvhdisc1 & "','" & _
                      tinvhdisc2 & "','" & _
                      tinvhongkir & "','" & _
                      tinvhongpack & "','" & _
                      userid & "','" & _
                      dtcreated & "')"
        'Me.StringSQL = "INSERT INTO " & TableName + "(`tinvhno`,`tinvhdt`,`tinvhnote`,`mcusid`,`supplier`,`userid`,`dtcreated`) VALUES " & values
        Me.StringSQL = IIf(Not String.IsNullOrEmpty(Me.StringSQL), Me.StringSQL,
                           "INSERT INTO " & TableName + "(`tinvhno`,`tinvhdt`,`tinvhnote`,`mcusid`,`tinvhdisc1`,`tinvhdisc2`,`tinvhongkir`,`tinvhongpack`,`userid`,`dtcreated`) VALUES " & values)
        Return MyBase.InsertData()
    End Function

    Public Function GetSqlInsertData() As String
        Dim values As String
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)
        values = "('" & tinvhno & "','" & _
                      tinvhdt & "','" & _
                      tinvhnote & "','" & _
                      mcusid & "','" & _
                      tinvhdisc1 & "','" & _
                      tinvhdisc2 & "','" & _
                      tinvhongkir & "','" & _
                      tinvhongpack & "','" & _
                      userid & "','" & _
                      dtcreated & "')"
        Return "INSERT INTO " & TableName + "(`tinvhno`,`tinvhdt`,`tinvhnote`,`mcusid`,`tinvhdisc1`,`tinvhdisc2`,`tinvhongkir`,`tinvhongpack`,`userid`,`dtcreated`) VALUES " & values & ";" & vbCrLf
    End Function

    Public Overloads Function UpdateData(Optional ByVal id As String = "") As Integer
        Dim setquery As String
        userid = MUsers.UserInfo()("userid")

        id = IIf(Not String.IsNullOrEmpty(id), id, tinvhno)
        setquery = "SET tinvhdt='" & tinvhdt & "'," & _
                    "tinvhnote='" & tinvhnote & "'," & _
                    "mcusid='" & mcusid & "'," & _
                    "tinvhdisc1='" & tinvhdisc1 & "'," & _
                    "tinvhdisc2='" & tinvhdisc2 & "'," & _
                    "tinvhongkir='" & tinvhongkir & "'," & _
                    "tinvhongpack='" & tinvhongpack & "'," & _
                    "userid='" & userid & "' WHERE tinvhno ='" & id & "'"
        Me.StringSQL = IIf(Not String.IsNullOrEmpty(Me.StringSQL), Me.StringSQL, "UPDATE " & TableName + " " & setquery)
        Return MyBase.UpdateData()
    End Function
    Public Function GetSqlUpdateData(Optional ByVal id As String = "") As String
        Dim setquery As String
        userid = MUsers.UserInfo()("userid")
        id = IIf(Not String.IsNullOrEmpty(id), id, tinvhno)
        setquery = "SET tinvhdt='" & tinvhdt & "'," & _
                    "tinvhnote='" & tinvhnote & "'," & _
                    "mcusid='" & mcusid & "'," & _
                    "tinvhdisc1='" & tinvhdisc1 & "'," & _
                    "tinvhdisc2='" & tinvhdisc2 & "'," & _
                    "tinvhongkir='" & tinvhongkir & "'," & _
                    "tinvhongpack='" & tinvhongpack & "'," & _
                    "userid='" & userid & "' WHERE tinvhno ='" & id & "'"
        Return "UPDATE " & TableName + " " & setquery & ";" & vbCrLf
    End Function

    Public Function getAutoNo() As String
        Dim autono As String = Nothing
        Dim no As Integer = 0
        Dim curyear As String = Format(Date.Now, "yyyy")
        Me.StringSQL = "SELECT IFNULL(MAX(SUBSTR(tinvhno,7)),0) AS lasnumber FROM tinvh WHERE YEAR(`tinvhdt`) =" & curyear
        no = Me.GetDataScalar() + 1
        autono = My.Settings.CabangID & "NP" & Format(Date.Now, "yy") & Format(no, "0000000")
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
