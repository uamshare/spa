Public Class GeneralLedger
    Inherits CDataAcces

    Public rglid As Integer
    Public rgldt As String
    Public mcoadno As String
    Public noref As String
    Public noref2 As String
    Public rglin As Decimal = 0
    Public rglout As Decimal = 0
    Public rgldesc As String = ""
    Public fk_id As String = ""
    Public userid As String
    Public dtcreated As String

    Private DefaultParamPosting As New Dictionary(Of String, Object)

    Sub New()
        MyBase.New()
        BaseQuery = "SELECT * FROM `rgl`"
        SelectQuery = "SELECT * FROM `rgl`"
        TableName = "rgl"
        PrimaryKey = "rglid"

        userid = MUsers.UserInfo()("userid")

        DefaultParamPosting.Add("idtrrans", "")
        'DefaultParamPosting.Add("noref", "")
        'DefaultParamPosting.Add("noref2", "")
        DefaultParamPosting.Add("accountlistname", Nothing)
        DefaultParamPosting.Add("accountlistvalue", Nothing)
    End Sub

    Public Overloads Function InsertData() As Integer
        Return 0
    End Function
    Public Overloads Function UpdateData() As Integer
        Return 0
    End Function
    Public Overloads Function DeleteData(Optional ByVal id = -1) As Integer
        Return 0
    End Function

    ''' <summary>
    ''' Do Posting to General Ledger
    ''' ModelGL.rgldt = Me.trcvmhdt
    ''' ModelGL.noref = Me.trcvmhno
    ''' ModelGL.noref2 = Me.trcvmhno
    ''' ModelGL.rgldesc = 'Update Data Tanaman Masuk No '
    ''' ModelGL.dtcreated = Me.dtcreated
    ''' Dim ParamPosting As New Dictionary(Of String, Object)
    ''' ParamPosting.Add("idtrrans", "PB")
    ''' Dim accountlistvalue As New Dictionary(Of String, Object)
    ''' accountlistvalue.Add("acc_debit", Me.bookvalue)
    ''' accountlistvalue.Add("acc_credit", Me.bookvalue)
    ''' ParamPosting.Add("accountlistvalue", accountlistvalue)
    ''' StringSQL=ModelGL.doPosting(ParamPosting)
    ''' </summary>
    ''' <param name="ParamPosting"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function doPosting(ParamPosting As Dictionary(Of String, Object)) As String
        Dim strsqll = ""
        Dim mapo As New MAkunPosting

        Try
            For Each dict As KeyValuePair(Of String, Object) In ParamPosting
                If Me.DefaultParamPosting.ContainsKey(dict.Key) Then
                    Me.DefaultParamPosting(dict.Key) = dict.Value
                End If
            Next

            If Not String.IsNullOrEmpty(Me.DefaultParamPosting("idtrrans")) Then
                Dim ListAccountPosting As List(Of Dictionary(Of String, Object)) = mapo.getListAccountPosting(Me.DefaultParamPosting("idtrrans"))

                For Each dictacc As Dictionary(Of String, Object) In ListAccountPosting
                    For Each dictacckey As KeyValuePair(Of String, Object) In dictacc
                        'MsgBox(dictacckey.Key + " = " + dictacckey.Value)
                        'Me.DefaultParamPosting("accountlistname").add(dictacckey.Key, dictacckey.Value)

                        If dictacckey.Key.Contains("debit") And Not String.IsNullOrEmpty(dictacckey.Value.ToString) Then
                            Me.mcoadno = dictacckey.Value
                            Me.rglin = DefaultParamPosting("accountlistvalue")(dictacckey.Key)
                            Me.rglout = "0"
                            strsqll = strsqll + GetSqlInsertData()
                        ElseIf dictacckey.Key.Contains("credit") And Not String.IsNullOrEmpty(dictacckey.Value.ToString) Then
                            Me.mcoadno = dictacckey.Value
                            Me.rglin = "0"
                            Me.rglout = DefaultParamPosting("accountlistvalue")(dictacckey.Key)
                            strsqll = strsqll + GetSqlInsertData()
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
        End Try
        Return strsqll
    End Function
    Public Function GetSqlInsertData() As String
        Dim values As String = ""
        Dim strsqll = ""
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)
        Try
            values = "('" & rgldt & "','" & _
                      mcoadno & "','" & _
                      noref & "','" & _
                      noref2 & "','" & _
                      rglin & "','" & _
                      rglout & "','" & _
                      rgldesc & "','" & _
                      fk_id & "','" & _
                      userid & "','" & _
                      dtcreated & "')"

        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
            Return 0
        End Try
        If values.Length > 1 Then
            'multivalue = multivalue.Substring(0, multivalue.Length - 1)
            strsqll = "INSERT INTO " & TableName & _
                   "(`rgldt`,`mcoadno`,`noref`,`noref2`,`rglin`,`rglout`,`rgldesc`,`fk_id`,`userid`,`dtcreated`) VALUES " & values & ";" & vbCrLf
        End If

        'MsgBox(Me.StringSQL)
        'Return MyBase.InsertData
        Return strsqll
    End Function
    Public Function DeleteByNo(ByVal NoHeader As String) As String
        Return "DELETE FROM " & TableName + " WHERE noref='" & NoHeader & "';" & vbCrLf
    End Function
    Public Function FillRNeraca(dateend As Date,Optional NameDataSet As String = "DataSet1") As DataSet
        Dim ds As DataSet = New DataSet(NameDataSet)
        Me.limitrecord = -1
        Me.WHERE = ""
        Me.StringSQL = "SELECT " & _
                        "  `coaall`.`classification`    AS `classification`, " & _
                        "  `coaall`.`mcoahno` AS `mcoahno`, " & _
                        "  `coaall`.`mcoahname`    AS `mcoahname`, " & _
                        "  IF(ISNULL(IF((`coaall`.`postbalance` = 'D'),SUM((`bb`.`rglin` - `bb`.`rglout`)),SUM((`bb`.`rglout` - `bb`.`rglin`)))),0,IF((`coaall`.`postbalance` = 'D'),SUM((`bb`.`rglin` - `bb`.`rglout`)),SUM((`bb`.`rglout` - `bb`.`rglin`)))) AS `nilai`,IF((`coaall`.`postbalance` = 'D'),'AKTIVA','PASSIVA') AS `kelompok` " & _
                        "FROM (`coaall` LEFT JOIN (SELECT * FROM gledger WHERE DATE_FORMAT(gledger.`rgldt`,'%Y-%m-%d') <='" & Format(dateend, "yyyy-MM-dd") & "') AS bb ON ((`bb`.`mcoadno` = `coaall`.`mcoadno`))) " & _
                        "WHERE (`coaall`.`postgl` = 'NRC') AND `coaall`.`active`=1 GROUP BY `coaall`.`mcoahno` " & _
                        "UNION " & _
                        "SELECT " & _
                        "                'LABA '    AS `classification`, " & _
                        "                '330100' AS `mcoahno`, " & _
                        "                'LABA " & Format(dateend, "dd MMM yyyy") & "' AS `mcoahname`, " & _
                        "  IF(ISNULL(SUM((`bb`.`rglout` - `bb`.`rglin`))),0,SUM((`bb`.`rglout` - `bb`.`rglin`))) AS `nilai`, " & _
                        "                    'PASSIVA'    AS `kelompok` " & _
                        "FROM (`coaall` LEFT JOIN (SELECT * FROM gledger WHERE DATE_FORMAT(gledger.`rgldt`,'%Y-%m-%d') <='" & Format(dateend, "yyyy-MM-dd") & "') AS bb ON ((`bb`.`mcoadno` = `coaall`.`mcoadno`))) " & _
                        "WHERE (`coaall`.`postgl` = 'LR') AND `coaall`.`active`=1 "
        ds.Tables.Add(MyBase.GetData)
        Return ds
    End Function
    Public Function FillRLNeraca(dateend As Date, Optional NameDataSet As String = "DataSet1") As DataSet
        Dim ds As DataSet = New DataSet(NameDataSet)
        Me.limitrecord = -1
        Me.WHERE = ""
        Me.StringSQL = "SELECT " & _
                        "  `coaall`.`classification`    AS `classification`," & _
                        "  `coaall`.`mcoahno` AS `mcoahno`," & _
                        "  `coaall`.`mcoahname`    AS `mcoahname`," & _
                        "  `coaall`.`mcoadno` AS `mcoadno`," & _
                        "  `coaall`.`mcoadname`    AS `mcoadname`," & _
                        "  IF(ISNULL(IF((`coaall`.`postbalance` = 'D'),SUM((`bb`.`rglin` - `bb`.`rglout`)),SUM((`bb`.`rglout` - `bb`.`rglin`)))),0,IF((`coaall`.`postbalance` = 'D'),SUM((`bb`.`rglin` - `bb`.`rglout`)),SUM((`bb`.`rglout` - `bb`.`rglin`)))) AS `nilai`,IF((`coaall`.`postbalance` = 'D'),'AKTIVA','PASSIVA') AS `kelompok` " & _
                        "FROM (`coaall` LEFT JOIN (SELECT * FROM gledger WHERE DATE_FORMAT(gledger.`rgldt`,'%Y-%m-%d') <='" & Format(dateend, "yyyy-MM-dd") & "') AS bb ON ((`bb`.`mcoadno` = `coaall`.`mcoadno`))) WHERE (`coaall`.`postgl` = 'NRC') AND `coaall`.`active`=1 " & _
                        "GROUP BY `coaall`.`mcoadno` " & _
                        " UNION " & _
                        "SELECT " & _
                        "            'LABA'    AS `classification`," & _
                        "            '330100' AS `mcoahno`," & _
                        "            'LABA DITAHAN'    AS `mcoahname`," & _
                        "            '330101' AS `mcoadno`," & _
                        "            'LABA " & Format(dateend, "dd MMM yyyy") & "'    AS `mcoadname`," & _
                        "  IF(ISNULL(SUM((`bb`.`rglout` - `bb`.`rglin`))),0,SUM((`bb`.`rglout` - `bb`.`rglin`))) AS `nilai`," & _
                        "                'PASSIVA'    AS `kelompok` " & _
                        "FROM (`coaall` LEFT JOIN (SELECT * FROM gledger WHERE DATE_FORMAT(gledger.`rgldt`,'%Y-%m-%d') <='" & Format(dateend, "yyyy-MM-dd") & "') AS bb ON ((`bb`.`mcoadno` = `coaall`.`mcoadno`))) WHERE (`coaall`.`postgl` = 'LR') AND `coaall`.`active`=1;"
        ds.Tables.Add(MyBase.GetData)
        Return ds
    End Function
    Public Function FillRRugiLaba(dateend As Date, Optional NameDataSet As String = "DataSet1") As DataSet
        Dim ds As DataSet = New DataSet(NameDataSet)
        Me.limitrecord = -1
        Me.WHERE = ""
        Dim filter As String = dateend.Month + (dateend.Year * 12)
        Me.StringSQL = "SELECT " & _
                        "  UPPER(`ytd`.`classification` )   AS `classification`," & _
                        "  `ytd`.`mcoahno` AS `mcoahno`," & _
                        "  `ytd`.`mcoahname`    AS `mcoahname`," & _
                        "  `ytd`.`mcoadno` AS `mcoadno`," & _
                        "  `ytd`.`mcoadname`    AS `mcoadname`," & _
                        "  `lr`.`nilai`    AS `nilai_lr`," & _
                        "  IF(ISNULL(`lr`.`laba`),0,`lr`.`laba`)    AS `laba_lr`," & _
                        "  `ytd`.`nilai`    AS `nilai_ytd`," & _
                        "  IF(ISNULL(`ytd`.`laba`),0,`ytd`.`laba`)    AS `laba_ytd` " & _
                        "FROM " & _
                        "(SELECT " & _
                        "  `coaall`.`classification`    AS `classification`, " & _
                        "  `coaall`.`mcoahno` AS `mcoahno`, " & _
                        "  `coaall`.`mcoahname`    AS `mcoahname`, " & _
                        "  `coaall`.`mcoadno` AS `mcoadno`, " & _
                        "  `coaall`.`mcoadname`    AS `mcoadname`, " & _
                        "  IF(ISNULL(IF((`coaall`.`postbalance` = 'D'),SUM((`bb`.`rglin` - `bb`.`rglout`)),SUM((`bb`.`rglout` - `bb`.`rglin`)))),0, " & _
                        "  IF((`coaall`.`postbalance` = 'D'),SUM((`bb`.`rglin` - `bb`.`rglout`)),SUM((`bb`.`rglout` - `bb`.`rglin`)))) AS `nilai`, " & _
                        "  SUM((`bb`.`rglout` - `bb`.`rglin`))    AS `laba`,  " & _
                        "  `coaall`.`mcoagroup`    AS `mcoagroup` " & _
                        "FROM (`coaall` " & _
                        "   LEFT JOIN (SELECT * FROM gledger WHERE (MONTH(gledger.`rgldt`) + YEAR(gledger.`rgldt`)*12) <= " & filter & ") AS bb " & _
                        "	 ON ((`bb`.`mcoadno` = `coaall`.`mcoadno`))) " & _
                        "WHERE (`coaall`.`postgl` = 'LR') AND `coaall`.`active`=1 " & _
                        "GROUP BY `coaall`.`mcoadno` ORDER BY mcoahno ASC) AS ytd " & _
                        "LEFT JOIN " & _
                        "(SELECT " & _
                        "  `coaall`.`classification`    AS `classification`, " & _
                        "  `coaall`.`mcoahno` AS `mcoahno`, " & _
                        "  `coaall`.`mcoahname`    AS `mcoahname`, " & _
                        "  `coaall`.`mcoadno` AS `mcoadno`, " & _
                        "  `coaall`.`mcoadname`    AS `mcoadname`, " & _
                        "  IF(ISNULL(IF((`coaall`.`postbalance` = 'D'),SUM((`bb`.`rglin` - `bb`.`rglout`)),SUM((`bb`.`rglout` - `bb`.`rglin`)))),0, " & _
                        "  IF((`coaall`.`postbalance` = 'D'),SUM((`bb`.`rglin` - `bb`.`rglout`)),SUM((`bb`.`rglout` - `bb`.`rglin`)))) AS `nilai`, " & _
                        "  SUM((`bb`.`rglout` - `bb`.`rglin`))    AS `laba`,  " & _
                        "  `coaall`.`mcoagroup`    AS `mcoagroup` " & _
                        "FROM (`coaall` " & _
                        "   LEFT JOIN (SELECT * FROM gledger WHERE (MONTH(gledger.`rgldt`) + YEAR(gledger.`rgldt`)*12) = " & filter & ") AS bb " & _
                        "	 ON ((`bb`.`mcoadno` = `coaall`.`mcoadno`))) " & _
                        "WHERE (`coaall`.`postgl` = 'LR') AND `coaall`.`active`=1 " & _
                        "GROUP BY `coaall`.`mcoadno` ORDER BY mcoahno ASC) AS lr " & _
                        "ON ytd.mcoadno=lr.mcoadno;"
        ds.Tables.Add(MyBase.GetData)
        Return ds
    End Function
    Public Function FillRArusKas(datestart As Date, dateend As Date,
                                 Optional NameDataSet As String = "DataSet1",
                                 Optional accno1 As String = "",
                                 Optional accno2 As String = "") As DataSet
        Dim ds As DataSet = New DataSet(NameDataSet)
        Me.limitrecord = -1
        If Not String.IsNullOrEmpty(accno1) And Not String.IsNullOrEmpty(accno2) Then
            Me.WHERE = "WHERE cfcurrent.`mcoadno` BETWEEN '" & accno1 & "' AND '" & accno2 & "' ORDER BY cfcurrent.`mcoadno`"
        Else
            Me.WHERE = ""
        End If
        Me.StringSQL = "SELECT cfcurrent.*,cfawal.awal FROM " & _
                        "(SELECT m_cf.*," & _
                        "	IF(ISNULL(SUM(da.debet)),0,SUM(da.debet)) debet," & _
                        "	IF(ISNULL(SUM(da.kredit)),0,SUM(da.kredit)) kredit," & _
                        "	IF(ISNULL(SUM(da.debet)-SUM(da.kredit)),0,SUM(da.debet)-SUM(da.kredit)) nilai," & _
                        "	IF(ISNULL(da.rgldt),0,da.rgldt) tanggal " & _
                        "FROM `cashflow` AS m_cf " & _
                        "Left Join  " & _
                        "(SELECT cs.*,aktivitas.no_reff,aktivitas.nama_reff FROM " & _
                        "	(SELECT " & _
                        "		bb.`rgldt`," & _
                        "		bb.noref," & _
                        "		c.`mcoadno`," & _
                        "		c.`mcoadname`," & _
                        "		bb.rglin debet," & _
                        "		bb.rglout kredit " & _
                        "	FROM `coa` AS c LEFT JOIN `gledger` AS bb " & _
                        "	ON c.`mcoadno`=bb.mcoadno WHERE c.`mcoahno` IN (SELECT mcoahno FROM mcashflowacc) AND " & _
                        "	(DATE_FORMAT(bb.`rgldt`,'%Y-%m-%d') BETWEEN '" & Format(datestart, "yyyy-MM-dd") & "'  AND '" & Format(dateend, "yyyy-MM-dd") & "')) cs " & _
                        "   INNER Join " & _
                        "	(SELECT  * FROM " & _
                        "		(SELECT " & _
                        "			bb.noref," & _
                        "			bb.mcoadno AS no_reff," & _
                        "			bb.mcoadname AS nama_reff " & _
                        "		FROM `coa` AS c INNER JOIN `gledger` AS bb " & _
                        "		ON c.`mcoadno`=bb.mcoadno WHERE c.`mcoahno` NOT IN (SELECT mcoahno FROM mcashflowacc ) GROUP BY bb.noref ) AS referensi " & _
                        "	WHERE noref IN (SELECT bb.noref FROM `coa` AS c INNER JOIN `gledger` AS bb ON c.`mcoadno`=bb.mcoadno WHERE c.`mcoahno` IN (SELECT mcoahno FROM mcashflowacc)) " & _
                        "	ORDER BY `referensi`.`noref`) aktivitas " & _
                        "	ON cs.noref=aktivitas.noref) AS da " & _
                        "ON m_cf.`mcoadno` = da.no_reff GROUP BY m_cf.`classification` ORDER BY m_cf.`id_aktivitas`,m_cf.`mcoadno`) AS cfcurrent " & _
                        "INNER Join " & _
                        "(SELECT m_cf.`classification`," & _
                        "	IF(ISNULL(SUM(da.debet)-SUM(da.kredit)),0,SUM(da.debet)-SUM(da.kredit)) awal " & _
                        "FROM `cashflow` AS m_cf " & _
                        "Left Join " & _
                        "(SELECT cs.*,aktivitas.no_reff,aktivitas.nama_reff FROM " & _
                        "	(SELECT " & _
                        "		bb.`rgldt`, " & _
                        "		bb.noref, " & _
                        "		c.`mcoadno`, " & _
                        "		c.`mcoadname`, " & _
                        "		bb.rglin debet, " & _
                        "		bb.rglout kredit " & _
                        "	FROM `coa` AS c LEFT JOIN `gledger` AS bb " & _
                        "	ON c.`mcoadno`=bb.mcoadno WHERE c.`mcoahno` IN (SELECT mcoahno FROM mcashflowacc) AND (DATE_FORMAT(bb.`rgldt`,'%Y-%m-%d') <'" & Format(datestart, "yyyy-MM-dd") & "')) cs " & _
                        "   INNER Join " & _
                        "	(SELECT  * FROM " & _
                        "	(SELECT " & _
                        "		bb.noref, " & _
                        "		bb.mcoadno AS no_reff, " & _
                        "		bb.mcoadname AS nama_reff " & _
                        "	FROM `coa` AS c INNER JOIN `gledger` AS bb " & _
                        "	ON c.`mcoadno`=bb.mcoadno WHERE c.`mcoahno` NOT IN (SELECT mcoahno FROM mcashflowacc) GROUP BY bb.noref ) AS referensi " & _
                        "	WHERE noref IN " & _
                        "	(SELECT bb.noref FROM `coa` AS c INNER JOIN `gledger` AS bb ON c.`mcoadno`=bb.mcoadno WHERE c.`mcoahno` IN (SELECT mcoahno FROM mcashflowacc)) ORDER BY `referensi`.`noref`) aktivitas " & _
                        "	ON cs.noref=aktivitas.noref) AS da " & _
                        "ON m_cf.`mcoadno` = da.no_reff GROUP BY m_cf.`classification` ORDER BY m_cf.`id_aktivitas`,m_cf.`mcoadno`) AS cfawal " & _
                        "ON cfcurrent.classification=cfawal.classification;"
        ds.Tables.Add(MyBase.GetData)
        Return ds
    End Function
    Public Function FillRBukuBesar(datestart As Date, dateend As Date,
                                   Optional NameDataSet As String = "DataSet1",
                                   Optional accno1 As String = "",
                                   Optional accno2 As String = "") As DataSet
        Dim ds As DataSet = New DataSet(NameDataSet)

        Me.limitrecord = -1
        If Not String.IsNullOrEmpty(accno1) And Not String.IsNullOrEmpty(accno2) Then
            Me.WHERE = "WHERE c.`mcoadno` BETWEEN '" & accno1 & "' AND '" & accno2 & "' ORDER BY c.`mcoadno`,bb.rgldt"
        Else
            Me.WHERE = "ORDER BY c.`mcoadno`,bb.rgldt"
        End If
        Me.StringSQL = "SELECT " & _
                        "	c.mcoadno," & _
                        "	c.mcoadname," & _
                        "	IF(ISNULL(bb.rgldt),'0',bb.rgldt) rgldt," & _
                        "	IF(ISNULL(bb.noref),'',bb.noref) noref," & _
                        "	IF(ISNULL(bb.rgldesc),'',bb.rgldesc) rgldesc," & _
                        "	IF(ISNULL(bb.noref2),'',bb.noref2) noref2," & _
                        "	IF(ISNULL(bb.rglin),0,bb.rglin) rglin," & _
                        "	IF(ISNULL(bb.rglout),0,bb.rglout) rglout," & _
                        "	IF(ISNULL(ss.saldo_awal),0,ss.saldo_awal) saldo_awal " & _
                        "FROM coa c " & _
                        "Left Join " & _
                        "(SELECT * FROM gledger WHERE DATE_FORMAT(`rgldt`,'%Y-%m-%d') BETWEEN '" & Format(datestart, "yyyy-MM-dd") & "' AND '" & Format(dateend, "yyyy-MM-dd") & "' ORDER BY `mcoadno`) bb ON c.`mcoadno`=bb.`mcoadno` " & _
                        "Left Join " & _
                        "(SELECT mcoadno,mcoadname,SUM(rglin-rglout) AS saldo_awal FROM `gledger` WHERE rgldt < '" & Format(datestart, "yyyy-MM-dd") & "' GROUP BY mcoadno) ss ON c.`mcoadno`=ss.mcoadno "
        ds.Tables.Add(MyBase.GetData)
        Return ds
    End Function
End Class
