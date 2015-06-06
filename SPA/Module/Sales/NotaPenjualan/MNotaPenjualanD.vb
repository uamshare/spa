Public Class MNotaPenjualanD
    Inherits MNotaPenjualanH

    Public tinvdid As Integer
    Public mmtrid As String
    Public tinvdqty As String = "0"
    Public tinvdprice As String = "0"
    Public tinvdtype As String = "0"

    Public dtcreatedforDeatil As String = ""
    Public bookvalue As String 'additional for posting to General Ledger
    Public soldvalue As String 'additional for posting to General Ledger

    Dim ModelHeader As New MNotaPenjualanH
    Dim ModelStock As New Rstockm
    'Dim ModelHPP As New Mhpp
    Dim ModelGL As New GeneralLedger

    'Private dtcreated As String

    Sub New()
        MyBase.New()
        BaseQuery = "SELECT * FROM tinvd"
        SelectQuery = "SELECT T1.`tinvdid`,T1.`tinvhno`,T1.`mmtrid`,T2.`mmtrname`,T2.`polybag`,T1.`tinvdqty`,T1.`tinvdprice`,(T1.`tinvdqty` * T1.`tinvdprice`) AS jumlah,T1.dtcreated " & _
                      "FROM tinvd T1 INNER JOIN mmtr T2 ON T1.`mmtrid` = T2.`mmtrid`"
        TableName = "tinvd"
        PrimaryKey = "tinvdid"
    End Sub
    Function FindDataDetail(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "WHERE tinvdid like '%" & sSearch & "%' " & _
                        "OR tinvhno like '%" & sSearch & "%' " & _
                        "OR mmtrname like '%" & sSearch & "%' " & _
                        "OR polybag like '%" & sSearch & "%' " & _
                        "OR tinvdqty like '%" & sSearch & "%' "
        Else
            Me.WHERE = ""
        End If
        Return MyBase.GetData
    End Function
    Public Overloads Function GetDataList(Optional no As String = "") As List(Of Dictionary(Of String, Object))
        Me.StringSQL = "SELECT T1.`tinvdid`,T1.`tinvhno`,T1.`mmtrid`,T2.`mmtrname`,T2.`polybag`,T2.`mmtrunit`,T1.`tinvdqty`,T1.`tinvdprice`,(T1.`tinvdqty` * T1.`tinvdprice`) AS jumlah,T1.tinvdtype,T1.dtcreated " & _
                      "FROM tinvd T1 INNER JOIN material_fig T2 ON T1.`mmtrid` = T2.`mmtrid` WHERE tinvhno ='" & no & "'"
        'MsgBox(Me.StringSQL)
        Return MyBase.GetDataList
    End Function
    Public Overloads Function InsertData() As Integer
        Dim values As String
        Dim trans As Integer = 0
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)

        Me.StringSQL = ""
        ModelHeader.tinvhno = Me.tinvhno
        ModelHeader.tinvhdt = Me.tinvhdt
        ModelHeader.tinvhnote = Me.tinvhnote
        ModelHeader.mcusid = Me.mcusid

        ModelHeader.tinvhdisc1 = Me.tinvhdisc1
        ModelHeader.tinvhdisc2 = Me.tinvhdisc2
        'ModelHeader.tinvhbonus = Me.tinvhbonus
        ModelHeader.tinvhongkir = Me.tinvhongkir
        ModelHeader.tinvhongpack = Me.tinvhongpack
        ModelHeader.dtcreated = Me.dtcreated
        Me.StringSQL = ModelHeader.GetSqlInsertData()

        If Not String.IsNullOrEmpty(Me.StringSQL) Then 'Insert Header
            values = "('" & MyBase.tinvhno & "','" & _
                      mmtrid & "','" & _
                      tinvdqty & "','" & _
                      tinvdprice & "','" & _
                      tinvdtype & "','" & _
                      dtcreated & "')"
            Me.StringSQL = Me.StringSQL + "INSERT INTO " & TableName + "(`tinvhno`,`mmtrid`,`tinvdqty`,`tinvdprice`,`tinvdtype`,`dtcreated`) VALUES " & values
            trans = MyBase.InsertData() 'MyBase.InsertData() ==> Insert Detail
        End If
        Return trans
    End Function
    Public Overloads Function InsertData(ByVal datadetail As List(Of Dictionary(Of String, Object))) As Integer
        Dim trans As Integer = 0

        Me.StringSQL = ""
        ModelHeader.tinvhno = Me.tinvhno
        ModelHeader.tinvhdt = Me.tinvhdt
        ModelHeader.tinvhnote = Me.tinvhnote
        ModelHeader.mcusid = Me.mcusid

        ModelHeader.tinvhdisc1 = Me.tinvhdisc1
        ModelHeader.tinvhdisc2 = Me.tinvhdisc2
        'ModelHeader.tinvhbonus = Me.tinvhbonus
        ModelHeader.tinvhongkir = Me.tinvhongkir
        ModelHeader.tinvhongpack = Me.tinvhongpack

        ModelHeader.dtcreated = Me.dtcreated
        Me.StringSQL = ModelHeader.GetSqlInsertData()

        If Not String.IsNullOrEmpty(Me.StringSQL) Then 'Insert Header
            'Do Posting to General Ledger
            ModelGL.rgldt = Me.tinvhdt
            ModelGL.noref = Me.tinvhno
            ModelGL.noref2 = Me.tinvhno
            ModelGL.rgldesc = "Insert Data Nota Penjualan No " & Me.tinvhno
            ModelGL.dtcreated = Me.dtcreated
            Dim ParamPosting As New Dictionary(Of String, Object)
            ParamPosting.Add("idtrrans", "NP")
            Dim accountlistvalue As New Dictionary(Of String, Object)
            accountlistvalue.Add("acc_debit", Me.soldvalue)
            accountlistvalue.Add("acc_credit", Me.soldvalue)
            accountlistvalue.Add("acc_debit2", Me.bookvalue)
            accountlistvalue.Add("acc_credit2", Me.bookvalue)
            ParamPosting.Add("accountlistvalue", accountlistvalue)
            Me.StringSQL = Me.StringSQL + ModelGL.doPosting(ParamPosting)
            'MsgBox(ModelGL.doPosting(ParamPosting))

            Me.StringSQL = Me.StringSQL + queryInsertDetail(datadetail)

            trans = MyBase.InsertData()
        End If
        Return trans
    End Function
    Public Overloads Function UpdateData(ByVal datadetail As List(Of Dictionary(Of String, Object))) As Integer
        Dim trans As Integer = 0

        Me.StringSQL = ""
        ModelHeader.tinvhno = Me.tinvhno
        ModelHeader.tinvhdt = Me.tinvhdt
        ModelHeader.tinvhnote = Me.tinvhnote
        ModelHeader.mcusid = Me.mcusid
        ModelHeader.tinvhdisc1 = Me.tinvhdisc1
        ModelHeader.tinvhdisc2 = Me.tinvhdisc2
        'ModelHeader.tinvhbonus = Me.tinvhbonus
        ModelHeader.tinvhongkir = Me.tinvhongkir
        ModelHeader.tinvhongpack = Me.tinvhongpack

        'ModelHeader.dtcreated = Me.dtcreated
        Me.StringSQL = ModelHeader.GetSqlUpdateData() 'Update Header

        If Not String.IsNullOrEmpty(Me.StringSQL) Then 'Insert Header
            Me.StringSQL = Me.StringSQL + ModelGL.DeleteByNo(Me.tinvhno) 'Update Header
            'Do Posting to General Ledger
            ModelGL.rgldt = Me.tinvhdt
            ModelGL.noref = Me.tinvhno
            ModelGL.noref2 = Me.tinvhno
            ModelGL.rgldesc = "Update Data Nota Penjualan No " & Me.tinvhno
            ModelGL.dtcreated = Me.dtcreated
            Dim ParamPosting As New Dictionary(Of String, Object)
            ParamPosting.Add("idtrrans", "NP")
            Dim accountlistvalue As New Dictionary(Of String, Object)
            accountlistvalue.Add("acc_debit", Me.soldvalue)
            accountlistvalue.Add("acc_credit", Me.soldvalue)
            accountlistvalue.Add("acc_debit2", Me.bookvalue)
            accountlistvalue.Add("acc_credit2", Me.bookvalue)
            ParamPosting.Add("accountlistvalue", accountlistvalue)
            Me.StringSQL = Me.StringSQL + ModelGL.doPosting(ParamPosting)

            'MsgBox(Me.StringSQL)

            Me.StringSQL = Me.StringSQL + DeleteByNo(Me.tinvhno)
            Me.StringSQL = Me.StringSQL + queryInsertDetail(datadetail)
            trans = MyBase.UpdateData()
            Console.WriteLine(Me.StringSQL)
        End If
        Return trans
    End Function
    Private Function queryInsertDetail(ByVal datadetail As List(Of Dictionary(Of String, Object))) As String
        Dim multivalue As String = ""
        Dim strsql = ""
        Dim trans As Integer = 0
        Dim datatostock, datahpp As New List(Of Dictionary(Of String, Object))

        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)
        Try
            For Each dat In datadetail

                If Not String.IsNullOrEmpty(dat("dtcreated")) And dat("dtcreated") <> "0001/01/01 0:00:00" Then
                    dtcreatedforDeatil = dat("dtcreated")
                Else
                    dtcreatedforDeatil = Format(Date.Now, "yyyy/MM/dd H:mm:ss")
                End If

                multivalue = multivalue & "('" & tinvhno & "','" & _
                                 dat("mmtrid").ToString & "','" & _
                                 dat("tinvdqty").ToString & "','" & _
                                  dat("tinvdprice").ToString & "','" & _
                                 dat("tinvdtype").ToString & "','" & _
                                 dtcreatedforDeatil & "'),"
                'Prepare data to Stock
                Dim dict As New Dictionary(Of String, Object)
                dict.Add("noref", tinvhno)
                dict.Add("mmtrid", dat("mmtrid"))
                dict.Add("rstockmdt", Me.tinvhdt)
                dict.Add("stockin", 0)
                dict.Add("stockout", CDec(dat("tinvdqty")))
                dict.Add("rstockmdesc", "Data Nota Penjualan No " & tinvhno)
                dict.Add("fk_id", "")
                dict.Add("userid", userid)
                dict.Add("dtcreated", dtcreatedforDeatil)
                datatostock.Add(dict)
            Next

        Catch ex As Exception
            Dim LogMsg As String = ex.Message & vbCrLf & ex.StackTrace
            MyApplication.ShowStatus(LogMsg, WARNING_STAT)
            ErrorLogger.WriteToErrorLog(LogMsg, "Insert", ERROR_STAT, "Insert")
            Return 0
        End Try

        If multivalue.Length > 1 Then 'MyBase.InsertData() ==> Insert Header
            multivalue = multivalue.Substring(0, multivalue.Length - 1)
            DeleteByNo(tinvhno)
            strsql = "INSERT INTO " & TableName + "(`tinvhno`,`mmtrid`,`tinvdqty`,`tinvdprice`,`tinvdtype`,`dtcreated`) VALUES " & multivalue & ";" & vbCrLf
            strsql = strsql + ModelStock.InsertData(datatostock) 'Insert/Update New Stok
        End If
        Return strsql
    End Function
    Public Function DeleteByNo(Optional ByVal NoHeader As String = "") As String
        Dim no As String
        Dim sqlstr = ""
        no = IIf(String.IsNullOrEmpty(NoHeader), tinvhno, NoHeader)
        sqlstr = "DELETE FROM " & TableName + " WHERE tinvhno='" & no & "';" & vbCrLf
        'Dim res As Integer = MyBase.DeleteData
        If Not String.IsNullOrEmpty(sqlstr) Then
            sqlstr = sqlstr & ModelStock.DeleteByNo(no)
        End If
        Return sqlstr
    End Function
    Public Overloads Function DeleteData(Optional ByVal id = -1) As Integer
        Dim trans As Integer = 0
        Me.StringSQL = ""
        Me.StringSQL = DeleteByNo(id)
        If Not String.IsNullOrEmpty(Me.StringSQL) Then 'Insert Header
            Me.StringSQL = Me.StringSQL + ModelHeader.GetSqlDeleteData(id)
            Me.StringSQL = Me.StringSQL + ModelGL.DeleteByNo(id)
            trans = MyBase.DeleteData()
        End If
        Return trans
    End Function

    Public Function FillNotaPenjualan(NoTrans As String,Optional NameDataSet As String = "DataSet1") As DataSet
        Dim ds As DataSet = New DataSet(NameDataSet)

        Me.limitrecord = -1
        If Not String.IsNullOrEmpty(NoTrans) And Not String.IsNullOrEmpty(NoTrans) Then
            Me.WHERE = "WHERE `tinvhno` = '" & NoTrans & "'"
        Else
            Me.WHERE = "ORDER BY `tinvhno`"
        End If
        Me.StringSQL = "SELECT " & _
                        "  H.`tinvhno`, " & _
                        "  H.`tinvhdt`, " & _
                        "  H.`tinvhnote`, " & _
                        "  H.`mcusid`, " & _
                        "  P.`mcusname`, " & _
                        "  P.`mcusaddr4`, " & _
                        "  P.`mcusaddr5`, " & _
                        "  P.`mcusphone1`, " & _
                        "  P.`mcusphone2`, " & _
                        "  H.`tinvhdisc1`, " & _
                        "  H.`tinvhdisc2`, " & _
                        "  H.`tinvhbonus`, " & _
                        "  H.`tinvhongkir`, " & _
                        "  H.`tinvhongpack`, " & _
                        "  H.`userid`, " & _
                        "  D.`tinvdid`, " & _
                        "  D.`tinvhno`, " & _
                        "  D.`mmtrid`, " & _
                        "  M.`mmtrname`, " & _
                        "  M.`polybag`, " & _
                        "  M.`mmtrunit`, " & _
                        "  D.`tinvdqty`, " & _
                        "  D.`tinvdprice`, " & _
                        "  D.`tinvdtype` " & _
                        "FROM (SELECT * FROM `tinvh` " & Me.WHERE & ") H " & _
                        "INNER JOIN mcus P ON P.`mcusid` = H.`mcusid` " & _
                        "INNER JOIN `tinvd` D ON H.`tinvhno`=D.`tinvhno` " & _
                        "INNER JOIN material_fig M ON M.mmtrid=D.`mmtrid` "
        Me.WHERE = ""
        'Console.WriteLine(Me.StringSQL)
        ds.Tables.Add(MyBase.GetData)
        Return ds
    End Function
End Class
