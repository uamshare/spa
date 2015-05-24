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
    Public Overloads Function getdata(strsql As String) As DataTable
        Me.StringSQL = strsql
        Return MyBase.GetData
    End Function
    Function FindData(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.StringSQL = "SELECT T1.* FROM (SELECT T1.`tinvhno`,`tinvhdt`,`tinvhnote`,T1.`mcusid`,`mcusname`,SUM(T2.`tinvdprice`) AS subtotal,`tinvhdisc1`,`tinvhdisc2`, " & _
                        "`tinvhongkir`,`tinvhongpack`,(SUM(T2.`tinvdprice`) - tinvhdisc2 + tinvhongkir + tinvhongpack)  AS total, " & _
                        "T1.`dtcreated`,`userid` FROM tinvh T1 " & _
                        "INNER JOIN tinvd T2 ON T1.`tinvhno` = T2.`tinvhno` " & _
                        "INNER JOIN mcus T3 ON T1.`mcusid`=T3.`mcusid` " & _
                        "GROUP BY T1.`tinvhno`) T1 "
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

    Public Function FillRinvoice(datestart As Date, dateend As Date,
                                   Optional NameDataSet As String = "DataSet1",
                                   Optional noref1 As String = "",
                                   Optional noref2 As String = "") As DataSet
        Dim ds As DataSet = New DataSet(NameDataSet)

        Me.limitrecord = -1
        If Not String.IsNullOrEmpty(noref1) And Not String.IsNullOrEmpty(noref2) Then
            Me.WHERE = "WHERE T1.mcusid BETWEEN '" & noref1 & "' AND '" & noref2 & "' GROUP BY T1.`mcusid` ORDER BY T2.total DESC,T1.mcusname"
        Else
            Me.WHERE = "GROUP BY T1.`mcusid` ORDER BY T2.total DESC,T1.mcusname"
        End If
        Me.StringSQL = "SELECT T1.`mcusid`, " & _
                        "  T1.`mcusname`," & _
                        "  T1.`mcusphone1`," & _
                        "  T1.`mcusphone2`, " & _
                        "  T1.`mcusfax`, " & _
                        "  T1.`mcusaddr1`, " & _
                        "  T1.`mcusaddr2`," & _
                        "  T1.`mcusaddr3`," & _
                        "  T1.`mcusaddr4`, " & _
                        "  T1.`mcusaddr5`, " & _
                        "  T1.`mcusemail`, " & _
                        "  T1.`mcustaxcode`, " & _
                        "IFNULL(T2.`tinvhdt`,0) AS tinvhdt, " & _
                        "IFNULL(T2.`tinvhnote`,0) AS tinvhnote, " & _
                        "SUM(IFNULL(T2.subtotal,0)) AS subtotal, " & _
                        "SUM(IFNULL(T2.`tinvhdisc1`,0)) AS tinvhdisc1, " & _
                        "SUM(IFNULL(T2.`tinvhdisc2`,0)) AS tinvhdisc2, " & _
                        "SUM(IFNULL(T2.`tinvhongkir`,0)) AS tinvhongkir, " & _
                        "SUM(IFNULL(T2.`tinvhongpack`,0)) AS tinvhongpack, " & _
                        "SUM(IFNULL(T2.total,0)) AS total " & _
                        "FROM mcus T1 " & _
                        "LEFT JOIN (SELECT T1.`tinvhno`,`tinvhdt`,`tinvhnote`,T1.`mcusid`,SUM(T2.`tinvdqty` * T2.`tinvdprice`) AS subtotal,`tinvhdisc1`,`tinvhdisc2`, " & _
                        "`tinvhongkir`,`tinvhongpack`,(SUM(T2.`tinvdqty` * T2.`tinvdprice`) - tinvhdisc2 + tinvhongkir + tinvhongpack)  AS total, " & _
                        "T1.`dtcreated`,`userid` FROM tinvh  T1 " & _
                        "INNER JOIN tinvd T2 ON T1.`tinvhno` = T2.`tinvhno` WHERE DATE_FORMAT(T1.`tinvhdt`,'%Y-%m-%d') BETWEEN '" & Format(datestart, "yyyy-MM-dd") & "' AND '" & Format(dateend, "yyyy-MM-dd") & "' " & _
                        "GROUP BY T1.`tinvhno`)T2 ON T1.`mcusid` = T2.mcusid "

        ds.Tables.Add(MyBase.GetData)
        Return ds
    End Function
    Public Function FillRDetailinvoice(datestart As Date, dateend As Date,
                                   Optional NameDataSet As String = "DataSet1",
                                   Optional noref1 As String = "",
                                   Optional noref2 As String = "") As DataSet
        Dim ds As DataSet = New DataSet(NameDataSet)

        Me.limitrecord = -1
        If Not String.IsNullOrEmpty(noref1) And Not String.IsNullOrEmpty(noref2) Then
            Me.WHERE = "WHERE T1.mcusid BETWEEN '" & noref1 & "' AND '" & noref2 & "' ORDER BY T1.mcusname"
        Else
            Me.WHERE = "ORDER BY T1.mcusname"
        End If
        Me.StringSQL = "SELECT T1.`mcusid`," & _
                        "  T1.`mcusname`, " & _
                        "  T1.`mcusphone1`, " & _
                        "  T1.`mcusphone2`, " & _
                        "  T1.`mcusfax`, " & _
                        "  T1.`mcusaddr1`, " & _
                        "  T1.`mcusaddr2`, " & _
                        "  T1.`mcusaddr3`, " & _
                        "  T1.`mcusaddr4`, " & _
                        "  T1.`mcusaddr5`, " & _
                        "  T1.`mcusemail`, " & _
                        "  T1.`mcustaxcode`, " & _
                        "IFNULL(T2.`tinvhno`,'') AS tinvhno, " & _
                        "IFNULL(T2.`tinvhdt`,0) AS tinvhdt, " & _
                        "IFNULL(T2.`tinvhnote`,0) AS tinvhnote, " & _
                        "IFNULL(T2.`tinvhdisc1`,0) AS tinvhdisc1, " & _
                        "IFNULL(T2.`tinvhdisc2`,0) AS tinvhdisc2, " & _
                        "IFNULL(T2.`tinvhongkir`,0) AS tinvhongkir, " & _
                        "IFNULL(T2.`tinvhongpack`,0) AS tinvhongpack, " & _
                        "IFNULL(T2.tinvdid   ,0) AS tinvdid, " & _
                        "IFNULL(T2.mmtrid    ,'') AS mmtrid, " & _
                        "IFNULL(CONCAT(T2.mmtrname,CONCAT(' ',T2.polybag)),'') AS mmtrname, " & _
                        "IFNULL(T2.tinvdqty  ,0) AS tinvdqty, " & _
                        "IFNULL(T2.tinvdprice,0) AS tinvdprice, " & _
                        "IFNULL(T2.tinvdtype ,'0') AS tinvdtype " & _
                        "FROM mcus T1 " & _
                        "LEFT JOIN (SELECT T1.`tinvhno`,`tinvhdt`,`tinvhnote`,T1.`mcusid`,`tinvhdisc1`,`tinvhdisc2`, " & _
                        "`tinvhongkir`,`tinvhongpack`,T1.`dtcreated`,`userid` ,T2.`tinvdid`,T2.`mmtrid`,T3.mmtrname,T3.polybag,T3.mmtrunit,T2.`tinvdqty`," & _
                        "T2.`tinvdprice`,T2.`tinvdtype` FROM (SELECT * FROM tinvh WHERE DATE_FORMAT(`tinvhdt`,'%Y-%m-%d') BETWEEN '" & _
                        Format(datestart, "yyyy-MM-dd") & "' AND '" & Format(dateend, "yyyy-MM-dd") & "') T1 " & _
                        "INNER JOIN tinvd T2 ON T1.`tinvhno` = T2.`tinvhno` INNER JOIN material_fig T3 ON T3.`mmtrid`=T2.`mmtrid`)T2 " & _
                        "ON T1.`mcusid` = T2.mcusid"
        ds.Tables.Add(MyBase.GetData)
        Return ds
    End Function
End Class
