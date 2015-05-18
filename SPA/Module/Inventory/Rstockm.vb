Public Class Rstockm
    Inherits CDataAcces

    Public rstockmid As Integer
    Public noref As String
    Public mmtrid As String
    Public stockin As Decimal = 0
    Public stockout As Decimal = 0
    Public rstockmdesc As String = ""
    Public fk_id As String = ""
    Public userid As String

    Public dtcreated As String

    Sub New()
        MyBase.New()
        BaseQuery = "SELECT * FROM `rstockm`"
        SelectQuery = "SELECT * FROM `rstockm`"
        TableName = "rstockm"
        PrimaryKey = "rstockmid"

        userid = MUsers.UserInfo()("userid")
    End Sub
    Public Overloads Function GetData(datestart As Date, dateend As Date,
                                      Optional viewtable As String = "material_fig",
                                      Optional noref1 As String = "",
                                      Optional noref2 As String = "") As DataTable
        Dim where As String = ""

        If Not String.IsNullOrEmpty(noref1) And Not String.IsNullOrEmpty(noref2) Then
            where = "WHERE T1.mmtrid BETWEEN '" & noref1 & "' AND '" & noref2 & "'"
        End If
        Me.StringSQL = "SELECT T1.* " & _
                        ",IFNULL(T3.stockstart,0) 	AS stockstart " & _
                        ",IFNULL(T2.stockin,0) 		AS stockin" & _
                        ",IFNULL(T2.stockout,0) 		AS stockout " & _
                        ",(IFNULL(T3.stockstart,0) + (IFNULL(T2.stockin,0)-IFNULL(T2.stockout,0))) AS stockend " & _
                        ",(IFNULL(T3.stockstart,0) + (IFNULL(T2.stockin,0)-IFNULL(T2.stockout,0))) * T1.hpp AS bookvalue " & _
                        "        FROM " & _
                        "(SELECT " & _
                        "	TA.* " & _
                        "	,IFNULL(TB.hpp,0) AS hpp " & _
                        "FROM `" & viewtable & "` TA " & _
                        "LEFT OUTER JOIN " & _
                        "(SELECT * FROM (SELECT mmtrid,hpp,price FROM mhpp WHERE DATE_FORMAT(`dtcreated`,'%Y-%m-%d') <= '" & Format(dateend, "yyyy-MM-dd") & "' ORDER BY 1 DESC) " & _
                        "			    T1 GROUP BY mmtrid) TB " & _
                        "	ON TA.mmtrid = TB.mmtrid) T1 " & _
                        "LEFT OUTER JOIN  " & _
                        "(SELECT mmtrid " & _
                        "            ,SUM(stockin) AS stockin " & _
                        "            ,SUM(stockout) AS stockout " & _
                        "    FROM `rstockm` WHERE DATE_FORMAT(`dtcreated`,'%Y-%m-%d') BETWEEN '" & Format(datestart, "yyyy-MM-dd") & "' AND '" & Format(dateend, "yyyy-MM-dd") & "' GROUP BY mmtrid) T2 " & _
                        "ON T1.mmtrid = T2.mmtrid " & _
                        "LEFT OUTER JOIN  " & _
                        "(SELECT mmtrid " & _
                        "            ,(SUM(stockin) - SUM(stockout)) AS stockstart " & _
                        "    FROM `rstockm` WHERE DATE_FORMAT(`dtcreated`,'%Y-%m-%d') < '" & Format(datestart, "yyyy-MM-dd") & "' GROUP BY mmtrid) T3 " & _
                        "ON T1.mmtrid = T3.mmtrid " & where
        Return MyBase.GetData
    End Function

    Public Function ReportStockAll(datestart As Date, dateend As Date,
                                   Optional NameDataSet As String = "DataSet1",
                                   Optional viewtable As String = "material_fig",
                                   Optional noref1 As String = "",
                                   Optional noref2 As String = "") As DataSet
        Dim ds As DataSet = New DataSet(NameDataSet)
        Me.WHERE = ""
        Me.limitrecord = -1
        ds.Tables.Add(GetData(datestart, dateend, viewtable, noref1, noref2))
        Return ds
    End Function
    Public Overloads Function GetRowsCount(Optional viewtable As String = "material_fig") As Integer
        Me.StringSQL = "SELECT COUNT(*) FROM " & viewtable & " " & mWHERE
        Return MyBase.GetRowsCount()
    End Function
    Function FindData(sSearch As String, Currdt As Date, Optional viewtable As String = "material_fig") As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "WHERE mmtrname like '%" & sSearch & "%'" & _
                        " OR T1.mmtrid like '%" & sSearch & "%'" & _
                        " OR polybag like '%" & sSearch & "%'" & _
                        " OR mmtrunit like '%" & sSearch & "%'" & _
                        " OR stockend like '%" & sSearch & "%'" & _
                        " OR bookvalue like '%" & sSearch & "%'"
        Else
            Me.WHERE = ""
        End If
        Me.StringSQL = "SELECT " & _
                        "   T1.* " & _
                        "   ,IFNULL(T2.stockin,0) 	AS stockin " & _
                        "   ,IFNULL(T2.stockout,0)	AS stockout " & _
                        "   ,IFNULL(T2.stockend,0)	AS stockend " & _
                        "   ,IFNULL(T2.hpp,0)	AS hpp " & _
                        "   ,IFNULL(T2.bookvalue,0)	AS bookvalue " & _
                        "FROM `" & viewtable & "` T1 " & _
                        "LEFT OUTER JOIN  " & _
                        "   (SELECT stock.* " & _
                        "           ,hpp.hpp " & _
                        "           ,(stockend * hpp.hpp) AS bookvalue " & _
                        "   FROM " & _
                        "       (SELECT mmtrid " & _
                        "               ,SUM(stockin) AS stockin " & _
                        "               ,SUM(stockout) AS stockout " & _
                        "               ,SUM(stockin) - SUM(stockout) AS stockend " & _
                        "       FROM `rstockm` WHERE `dtcreated` <= '" & Format(Currdt, "yyyy-MM-dd") & "' GROUP BY mmtrid) stock " & _
                        "       INNER JOIN " & _
                        "       (SELECT * FROM (SELECT mmtrid,hpp,price FROM mhpp WHERE `dtcreated` <= '" & Format(Currdt, "yyyy-MM-dd") & "' ORDER BY 1 DESC)  " & _
                        "                       T1 GROUP BY mmtrid) hpp ON stock.`mmtrid` = hpp.mmtrid) T2 " & _
                        "ON T1.mmtrid = T2.mmtrid "
        Return MyBase.GetData
    End Function
    Public Overloads Function InsertData() As Integer
        Dim values As String
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)
        values = "('" & noref & "','" & _
                      mmtrid & "','" & _
                      stockin & "','" & _
                      stockout & "','" & _
                      rstockmdesc & "','" & _
                      fk_id & "','" & _
                      userid & "','" & _
                      dtcreated & "')"
        Me.StringSQL = "INSERT INTO " & TableName & _
                    "(`noref`,`mmtrid`,`stockin`,`stockout`,`rstockmdesc`,`fk_id`,`userid`,`dtcreated`) VALUES " & values
        Return MyBase.InsertData()
    End Function
    Public Overloads Function InsertData(ByVal multidata As List(Of Dictionary(Of String, Object))) As String
        Dim multivalue As String = ""
        Dim strsqll = ""
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)
        Try
            For Each dat In multidata
                dtcreated = IIf(Not String.IsNullOrEmpty(dat("dtcreated")), dat("dtcreated"), dtcreated)
                multivalue = multivalue & _
                                "('" & dat("noref").ToString & "','" & _
                                 dat("mmtrid").ToString & "','" & _
                                 dat("stockin").ToString & "','" & _
                                 dat("stockout").ToString & "','" & _
                                 dat("rstockmdesc").ToString & "','" & _
                                 dat("fk_id").ToString & "','" & _
                                 dat("userid").ToString & "','" & _
                                 dtcreated & "'),"
            Next

        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
            Return 0
        End Try
        If multivalue.Length > 1 Then
            multivalue = multivalue.Substring(0, multivalue.Length - 1)
            strsqll = "INSERT INTO " & TableName & _
                   "(`noref`,`mmtrid`,`stockin`,`stockout`,`rstockmdesc`,`fk_id`,`userid`,`dtcreated`) VALUES " & multivalue & ";" & vbCrLf
        End If

        'MsgBox(Me.StringSQL)
        'Return MyBase.InsertData
        Return strsqll
    End Function
    Public Function DeleteByNo(ByVal NoHeader As String) As String
        Return "DELETE FROM " & TableName + " WHERE noref='" & NoHeader & "';" & vbCrLf
    End Function
    Public Function getStockCard(Optional noref As String = "", Optional viewtable As String = "material_fig") As List(Of Dictionary(Of String, Object))
        Dim where As String = ""
        If Not String.IsNullOrEmpty(noref) Then
            where = "WHERE T1.mmtrid='" & noref & "'"
        End If
        Me.StringSQL = "SELECT	 `t1`.`rstockmid`   AS `rstockmid`," & _
                            "`t1`.`noref`       AS `noref`,         " & _
                            "`t1`.`mmtrid`      AS `mmtrid`,        " & _
                            "T3.`mmtrname`      AS `mmtrname`,      " & _
                            "T3.`mmtrunit`      AS `mmtrunit`,      " & _
                            "T3.`polybag`       AS `polybag`,       " & _
                            "`t1`.`stockin`     AS `stockin`,       " & _
                            "`t1`.`stockout`    AS `stockout`,      " & _
                            "`t1`.`rstockmdesc` AS `rstockmdesc`,   " & _
                            "`t1`.`fk_id`       AS `fk_id`,         " & _
                            "`t1`.`userid`      AS `userid`,        " & _
                            "`t1`.`dtcreated`   AS `dtcreated`,     " & _
                            "`t1`.`dtupdate`    AS `dtupdate`,      " & _
                            "`t2`.`hpp`         AS `hpp`,           " & _
                            "`t2`.`price`       AS `price`          " & _
                        "FROM `rstockm` T1 " & _
                        "INNER JOIN mhpp T2 ON T1.`noref`=T2.`noref` AND T1.`mmtrid` = T2.`mmtrid` " & _
                        "INNER JOIN " & viewtable & " T3 ON T3.`mmtrid` = T1.`mmtrid`" & where
        Return MyBase.GetDataList
    End Function
    Public Overloads Function getStockAll(Currdt As Date,
                                          Optional noref As String = "",
                                          Optional viewtable As String = "material_fig") As List(Of Dictionary(Of String, Object))
        Dim where As String = ""
        If Not String.IsNullOrEmpty(noref) Then
            where = "WHERE mmtrid='" & noref & "'"
        End If
        Me.StringSQL = "SELECT " & _
                        "   T1.* " & _
                        "   ,IFNULL(T2.stockin,0) 	AS stockin " & _
                        "   ,IFNULL(T2.stockout,0)	AS stockout " & _
                        "   ,IFNULL(T2.stockend,0)	AS stockend " & _
                        "   ,IFNULL(T2.hpp,0)	AS hpp " & _
                        "   ,IFNULL(T2.bookvalue,0)	AS bookvalue " & _
                        "FROM `" & viewtable & "` T1 " & _
                        "LEFT OUTER JOIN  " & _
                        "   (SELECT stock.* " & _
                        "           ,hpp.hpp " & _
                        "           ,(stockend * hpp.hpp) AS bookvalue " & _
                        "   FROM " & _
                        "       (SELECT mmtrid " & _
                        "               ,SUM(stockin) AS stockin " & _
                        "               ,SUM(stockout) AS stockout " & _
                        "               ,SUM(stockin) - SUM(stockout) AS stockend " & _
                        "       FROM `rstockm` WHERE `dtcreated` <= '" & Format(Currdt, "yyyy-MM-dd") & "' GROUP BY mmtrid) stock " & _
                        "       INNER JOIN " & _
                        "       (SELECT * FROM (SELECT mmtrid,hpp,price FROM mhpp WHERE `dtcreated` <= '" & Format(Currdt, "yyyy-MM-dd") & "' ORDER BY 1 DESC)  " & _
                        "                       T1 GROUP BY mmtrid) hpp ON stock.`mmtrid` = hpp.mmtrid) T2 " & _
                        "ON T1.mmtrid = T2.mmtrid " & where
        Return MyBase.GetDataList
    End Function
End Class
