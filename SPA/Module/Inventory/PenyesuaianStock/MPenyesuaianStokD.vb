Public Class MPenyesuaianStokD
    Inherits MPenyesuaianStokH

    Public tajsmdid As Integer
    Public mmtrid As String
    Public tajsmdqty1 As String = "0"
    Public tajsmdqty2 As String = "0"
    Public tajsmdqty3 As String = "0"
    Public tajsmhpp As String = "0"
    Public dtcreatedforDeatil As String = ""
    Public bookvalue As String 'additional for posting to General Ledger

    Dim ModelHeader As New MPenyesuaianStokH
    Dim ModelStock As New Rstockm
    Dim ModelHPP As New Mhpp
    Dim ModelGL As New GeneralLedger

    'Private dtcreated As String
    Sub New()
        MyBase.New()
        BaseQuery = "SELECT * FROM tajsmd"
        SelectQuery = "SELECT T1.`tajsmdid`,T1.`tajsmhno`,T1.`mmtrid`,T2.`mmtrname`,T2.`polybag`,T1.`tajsmdqty`,T1.`tajsmdprice`,(T1.`tajsmdqty` * T1.`tajsmdprice`) AS jumlah,T1.dtcreated " & _
                      "FROM tajsmd T1 INNER JOIN mmtr T2 ON T1.`mmtrid` = T2.`mmtrid`"
        TableName = "tajsmd"
        PrimaryKey = "tajsmdid"
    End Sub
    Function FindDataDetail(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "WHERE tajsmdid like '%" & sSearch & "%' " & _
                        "OR tajsmhno like '%" & sSearch & "%' " & _
                        "OR mmtrname like '%" & sSearch & "%' " & _
                        "OR polybag like '%" & sSearch & "%' " & _
                        "OR tajsmdqty like '%" & sSearch & "%' "
        Else
            Me.WHERE = ""
        End If
        Return MyBase.GetData
    End Function
    Public Overloads Function GetDataList(Optional no As String = "") As List(Of Dictionary(Of String, Object))
        Me.StringSQL = "SELECT * FROM tajsmd WHERE tajsmhno ='" & no & "'"
        'MsgBox(Me.StringSQL)
        Return MyBase.GetDataList
    End Function
    Public Overloads Function InsertData() As Integer
        Dim values As String
        Dim trans As Integer = 0
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)

        Me.StringSQL = ""
        ModelHeader.tajsmhno = Me.tajsmhno
        ModelHeader.tajsmhdt = Me.tajsmhdt
        ModelHeader.mmtrg = Me.mmtrg
        ModelHeader.dtcreated = Me.dtcreated
        Me.StringSQL = ModelHeader.GetSqlInsertData()

        If Not String.IsNullOrEmpty(Me.StringSQL) Then 'Insert Header
            values = "('" & MyBase.tajsmhno & "','" & _
                      mmtrid & "','" & _
                      tajsmdqty1 & "','" & _
                      tajsmdqty2 & "','" & _
                      tajsmdqty3 & "','" & _
                      tajsmhpp & "','" & _
                      dtcreated & "')"
            Me.StringSQL = Me.StringSQL + "INSERT INTO " & TableName + "(`tajsmhno`,`mmtrid`,`tajsmdqty1`,`tajsmdqty2`,`tajsmdqty3`,`tajsmhpp`,`dtcreated`) VALUES " & values
            trans = MyBase.InsertData() 'MyBase.InsertData() ==> Insert Detail
        End If
        Return trans
    End Function
    Public Overloads Function InsertData(ByVal datadetail As List(Of Dictionary(Of String, Object))) As Integer
        Dim trans As Integer = 0

        Me.StringSQL = ""
        ModelHeader.tajsmhno = Me.tajsmhno
        ModelHeader.tajsmhdt = Me.tajsmhdt
        ModelHeader.tajsmhinf = Me.tajsmhinf
        ModelHeader.mmtrg = Me.mmtrg
        ModelHeader.dtcreated = Me.dtcreated
        Me.StringSQL = ModelHeader.GetSqlInsertData()

        If Not String.IsNullOrEmpty(Me.StringSQL) Then 'Insert Header
            'Do Posting to General Ledger
            Dim ParamPosting As New Dictionary(Of String, Object)
            ModelGL.rgldt = Me.tajsmhdt
            ModelGL.noref = Me.tajsmhno
            ModelGL.noref2 = Me.tajsmhno
            ModelGL.dtcreated = Me.dtcreated
            Select Case mmtrg
                Case "1"
                    ModelGL.rgldesc = "Insert Data Penyesuaian Stok Bibit Tanaman No " & Me.tajsmhno
                    ParamPosting.Add("idtrrans", "AH")
                Case "2"
                    ModelGL.rgldesc = "Insert Data Penyesuaian Stok Bibit Tanaman dalam proses No " & Me.tajsmhno
                    ParamPosting.Add("idtrrans", "AI")
                Case "3"
                    ModelGL.rgldesc = "Insert Data Penyesuaian Stok Tanaman No " & Me.tajsmhno
                    ParamPosting.Add("idtrrans", "AJ")
            End Select
            Dim accountlistvalue As New Dictionary(Of String, Object)
            accountlistvalue.Add("acc_debit", Me.bookvalue)
            accountlistvalue.Add("acc_credit", Me.bookvalue)
            ParamPosting.Add("accountlistvalue", accountlistvalue)
            Me.StringSQL = Me.StringSQL + ModelGL.doPosting(ParamPosting)
            'MsgBox(Me.bookvalue)

            Me.StringSQL = Me.StringSQL + queryInsertDetail(datadetail)
            'MsgBox(StringSQL)
            trans = MyBase.InsertData()
        End If
        Return trans
    End Function
    Public Overloads Function UpdateData(ByVal datadetail As List(Of Dictionary(Of String, Object))) As Integer
        Dim trans As Integer = 0

        Me.StringSQL = ""
        ModelHeader.tajsmhno = Me.tajsmhno
        ModelHeader.tajsmhdt = Me.tajsmhdt
        ModelHeader.tajsmhinf = Me.tajsmhinf
        ModelHeader.mmtrg = Me.mmtrg
        'ModelHeader.dtcreated = Me.dtcreated
        Me.StringSQL = ModelHeader.GetSqlUpdateData() 'Update Header

        If Not String.IsNullOrEmpty(Me.StringSQL) Then 'Insert Header
            Me.StringSQL = Me.StringSQL + ModelGL.DeleteByNo(Me.tajsmhno) 'Update Header
            'Do Posting to General Ledger
            Dim ParamPosting As New Dictionary(Of String, Object)
            ModelGL.rgldt = Me.tajsmhdt
            ModelGL.noref = Me.tajsmhno
            ModelGL.noref2 = Me.tajsmhno
            ModelGL.dtcreated = Me.dtcreated
            Select Case mmtrg
                Case "1"
                    ModelGL.rgldesc = "Insert Data Penyesuaian Stok Bibit Tanaman No " & Me.tajsmhno
                    ParamPosting.Add("idtrrans", "AH")
                Case "2"
                    ModelGL.rgldesc = "Insert Data Penyesuaian Stok Bibit Tanaman dalam proses No " & Me.tajsmhno
                    ParamPosting.Add("idtrrans", "AI")
                Case "3"
                    ModelGL.rgldesc = "Insert Data Penyesuaian Stok Tanaman No " & Me.tajsmhno
                    ParamPosting.Add("idtrrans", "AJ")
            End Select
            Dim accountlistvalue As New Dictionary(Of String, Object)
            accountlistvalue.Add("acc_debit", Me.bookvalue)
            accountlistvalue.Add("acc_credit", Me.bookvalue)
            ParamPosting.Add("accountlistvalue", accountlistvalue)
            Me.StringSQL = Me.StringSQL + ModelGL.doPosting(ParamPosting)

            Me.StringSQL = Me.StringSQL + DeleteByNo(Me.tajsmhno)
            Me.StringSQL = Me.StringSQL + queryInsertDetail(datadetail)
            'MsgBox(StringSQL)
            trans = MyBase.UpdateData()
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

                multivalue = multivalue & "('" & tajsmhno & "','" & _
                                 dat("mmtrid").ToString & "','" & _
                                 dat("tajsmdqty1").ToString & "','" & _
                                 dat("tajsmdqty2").ToString & "','" & _
                                 dat("tajsmdqty3").ToString & "','" & _
                                 dat("hpp").ToString & "','" & _
                                 dtcreatedforDeatil & "'),"
                'Prepare data to Stock
                Dim dict As New Dictionary(Of String, Object)
                dict.Add("noref", tajsmhno)
                dict.Add("mmtrid", dat("mmtrid"))
                dict.Add("rstockmdt", Me.tajsmhdt)
                dict.Add("stockin", CDec(dat("tajsmdqty3")))
                dict.Add("stockout", 0)
                dict.Add("rstockmdesc", "Data Penyesuaian Stok Tanaman No " & tajsmhno)
                dict.Add("fk_id", "")
                dict.Add("userid", userid)
                dict.Add("dtcreated", dtcreatedforDeatil)
                datatostock.Add(dict)

                'prepare to hpp
                Dim dicthpp As New Dictionary(Of String, Object)
                dicthpp.Add("noref", tajsmhno)
                dicthpp.Add("mmtrid", dat("mmtrid"))
                dicthpp.Add("mhppdt", Me.tajsmhdt)
                dicthpp.Add("hpp", dat("hpp"))
                dicthpp.Add("price", dat("hpp"))
                dicthpp.Add("dtcreated", dtcreatedforDeatil)
                datahpp.Add(dicthpp)

            Next

        Catch ex As Exception
            Dim LogMsg As String = ex.Message & vbCrLf & ex.StackTrace
            MyApplication.ShowStatus(LogMsg, WARNING_STAT)
            ErrorLogger.WriteToErrorLog(LogMsg, "Insert", ERROR_STAT, "Insert")
            Return 0
        End Try

        If multivalue.Length > 1 Then 'MyBase.InsertData() ==> Insert Header
            multivalue = multivalue.Substring(0, multivalue.Length - 1)
            DeleteByNo(tajsmhno)
            strsql = "INSERT INTO " & TableName + "(`tajsmhno`,`mmtrid`,`tajsmdqty1`,`tajsmdqty2`,`tajsmdqty3`,`tajsmhpp`,`dtcreated`) VALUES " & multivalue & ";" & vbCrLf
            strsql = strsql + ModelStock.InsertData(datatostock) 'Insert/Update New Stok
            strsql = strsql + ModelHPP.InsertData(datahpp) 'Insert/Update New HPP
        End If
        Return strsql
    End Function
    Public Function DeleteByNo(Optional ByVal NoHeader As String = "") As String
        Dim no As String
        Dim sqlstr = ""
        no = IIf(String.IsNullOrEmpty(NoHeader), tajsmhno, NoHeader)
        sqlstr = "DELETE FROM " & TableName + " WHERE tajsmhno='" & no & "';" & vbCrLf
        If Not String.IsNullOrEmpty(sqlstr) Then
            sqlstr = sqlstr & ModelStock.DeleteByNo(no)
            sqlstr = sqlstr & ModelHPP.DeleteByNo(no)
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
End Class
