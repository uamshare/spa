Public Class MTransferStokTanamanD
    Inherits MTransferStokTanamanH

    Public ttrfmdid As Integer
    Public mmtrid As String
    Public ttrfmdqty As String = "0"
    Public ttrfmdprice As String = "0"
    Public dtcreatedforDeatil As String = ""
    Public bookvalue As String 'additional for posting to General Ledger

    Dim ModelHeader As New MTransferStokTanamanH
    Dim ModelStock As New Rstockm
    Dim ModelHPP As New Mhpp
    Dim ModelGL As New GeneralLedger

    'Private dtcreated As String
    Sub New()
        MyBase.New()
        BaseQuery = "SELECT * FROM ttrfmd"
        SelectQuery = "SELECT T1.`ttrfmdid`,T1.`ttrfmhno`,T1.`mmtrid`,T2.`mmtrname`,T2.`polybag`,T1.`ttrfmdqty`,T1.`ttrfmdprice`,(T1.`ttrfmdqty` * T1.`ttrfmdprice`) AS jumlah,T1.dtcreated " & _
                      "FROM ttrfmd T1 INNER JOIN mmtr T2 ON T1.`mmtrid` = T2.`mmtrid`"
        TableName = "ttrfmd"
        PrimaryKey = "ttrfmdid"
    End Sub
    Function FindDataDetail(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "WHERE ttrfmdid like '%" & sSearch & "%' " & _
                        "OR ttrfmhno like '%" & sSearch & "%' " & _
                        "OR mmtrname like '%" & sSearch & "%' " & _
                        "OR polybag like '%" & sSearch & "%' " & _
                        "OR ttrfmdqty like '%" & sSearch & "%' "
        Else
            Me.WHERE = ""
        End If
        Return MyBase.GetData
    End Function
    Public Overloads Function GetDataList(Optional no As String = "") As List(Of Dictionary(Of String, Object))
        Me.StringSQL = "SELECT * FROM ttrfmd WHERE ttrfmhno ='" & no & "'"
        'MsgBox(Me.StringSQL)
        Return MyBase.GetDataList
    End Function
    Public Overloads Function InsertData() As Integer
        Dim values As String
        Dim trans As Integer = 0
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)

        Me.StringSQL = ""
        ModelHeader.ttrfmhno = Me.ttrfmhno
        ModelHeader.ttrfmhdt = Me.ttrfmhdt
        ModelHeader.dtcreated = Me.dtcreated
        Me.StringSQL = ModelHeader.GetSqlInsertData()

        If Not String.IsNullOrEmpty(Me.StringSQL) Then 'Insert Header
            values = "('" & MyBase.ttrfmhno & "','" & _
                      mmtrid & "','" & _
                      ttrfmdqty & "','" & _
                      ttrfmdprice & "','" & _
                      dtcreated & "')"
            Me.StringSQL = Me.StringSQL + "INSERT INTO " & TableName + "(`ttrfmhno`,`mmtrid`,`ttrfmdqty`,`ttrfmdprice`,`dtcreated`) VALUES " & values
            trans = MyBase.InsertData() 'MyBase.InsertData() ==> Insert Detail
        End If
        Return trans
    End Function
    Public Overloads Function InsertData(ByVal datadetail As List(Of Dictionary(Of String, Object))) As Integer
        Dim trans As Integer = 0

        Me.StringSQL = ""
        ModelHeader.ttrfmhno = Me.ttrfmhno
        ModelHeader.ttrfmhdt = Me.ttrfmhdt
        ModelHeader.ttrfmhdesc = Me.ttrfmhdesc
        ModelHeader.ttrfmhtype = Me.ttrfmhtype
        ModelHeader.dtcreated = Me.dtcreated
        Me.StringSQL = ModelHeader.GetSqlInsertData()

        If Not String.IsNullOrEmpty(Me.StringSQL) Then 'Insert Header
            'Do Posting to General Ledger
            Dim ParamPosting As New Dictionary(Of String, Object)
            If Me.ttrfmhtype = "in" Then
                ModelGL.rgldt = Me.ttrfmhdt
                ModelGL.noref = Me.ttrfmhno
                ModelGL.noref2 = Me.ttrfmhno
                ModelGL.rgldesc = "Insert Data Transfer Stok Tanaman No " & Me.ttrfmhno
                ModelGL.dtcreated = Me.dtcreated
                ParamPosting.Add("idtrrans", "TI")
                Dim accountlistvalue As New Dictionary(Of String, Object)
                accountlistvalue.Add("acc_debit", Me.bookvalue)
                accountlistvalue.Add("acc_credit", Me.bookvalue)
                ParamPosting.Add("accountlistvalue", accountlistvalue)
            ElseIf Me.ttrfmhtype = "out" Then
                ModelGL.rgldt = Me.ttrfmhdt
                ModelGL.noref = Me.ttrfmhno
                ModelGL.noref2 = Me.ttrfmhno
                ModelGL.rgldesc = "Insert Data Transfer Stok Tanaman No " & Me.ttrfmhno
                ModelGL.dtcreated = Me.dtcreated
                ParamPosting.Add("idtrrans", "TO")
                Dim accountlistvalue As New Dictionary(Of String, Object)
                accountlistvalue.Add("acc_debit", Me.bookvalue)
                accountlistvalue.Add("acc_credit", Me.bookvalue)
                ParamPosting.Add("accountlistvalue", accountlistvalue)
            End If
            
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
        ModelHeader.ttrfmhno = Me.ttrfmhno
        ModelHeader.ttrfmhdt = Me.ttrfmhdt
        ModelHeader.ttrfmhdesc = Me.ttrfmhdesc
        'ModelHeader.dtcreated = Me.dtcreated
        Me.StringSQL = ModelHeader.GetSqlUpdateData() 'Update Header

        If Not String.IsNullOrEmpty(Me.StringSQL) Then 'Insert Header
            Me.StringSQL = Me.StringSQL + ModelGL.DeleteByNo(Me.ttrfmhno) 'Update Header
            'Do Posting to General Ledger
            Dim ParamPosting As New Dictionary(Of String, Object)
            If Me.ttrfmhtype = "in" Then
                ModelGL.rgldt = Me.ttrfmhdt
                ModelGL.noref = Me.ttrfmhno
                ModelGL.noref2 = Me.ttrfmhno
                ModelGL.rgldesc = "Update Data Transfer Stok Tanaman No " & Me.ttrfmhno
                ModelGL.dtcreated = Me.dtcreated
                ParamPosting.Add("idtrrans", "TI")
                Dim accountlistvalue As New Dictionary(Of String, Object)
                accountlistvalue.Add("acc_debit", Me.bookvalue)
                accountlistvalue.Add("acc_credit", Me.bookvalue)
                ParamPosting.Add("accountlistvalue", accountlistvalue)
            ElseIf Me.ttrfmhtype = "out" Then
                ModelGL.rgldt = Me.ttrfmhdt
                ModelGL.noref = Me.ttrfmhno
                ModelGL.noref2 = Me.ttrfmhno
                ModelGL.rgldesc = "Update Data Transfer Stok Tanaman No " & Me.ttrfmhno
                ModelGL.dtcreated = Me.dtcreated
                ParamPosting.Add("idtrrans", "TO")
                Dim accountlistvalue As New Dictionary(Of String, Object)
                accountlistvalue.Add("acc_debit", Me.bookvalue)
                accountlistvalue.Add("acc_credit", Me.bookvalue)
                ParamPosting.Add("accountlistvalue", accountlistvalue)
            End If
            Me.StringSQL = Me.StringSQL + ModelGL.doPosting(ParamPosting)

            'MsgBox(Me.StringSQL)

            Me.StringSQL = Me.StringSQL + DeleteByNo(Me.ttrfmhno)
            Me.StringSQL = Me.StringSQL + queryInsertDetail(datadetail)
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

                multivalue = multivalue & "('" & ttrfmhno & "','" & _
                                 dat("mmtrid").ToString & "','" & _
                                 dat("ttrfmdqty").ToString & "','" & _
                                 dat("ttrfmdprice").ToString & "','" & _
                                 dtcreatedforDeatil & "'),"
                'Prepare data to Stock
                Dim dict As New Dictionary(Of String, Object)
                dict.Add("noref", ttrfmhno)
                dict.Add("mmtrid", dat("mmtrid"))
                dict.Add("rstockmdt", Me.ttrfmhdt)
                If Me.ttrfmhtype = "in" Then
                    dict.Add("stockin", CDec(dat("ttrfmdqty")))
                    dict.Add("stockout", 0)
                ElseIf Me.ttrfmhtype = "out" Then
                    dict.Add("stockin", 0)
                    dict.Add("stockout", CDec(dat("ttrfmdqty")))
                End If
                
                dict.Add("rstockmdesc", "Data Transfer Stok Tanaman No " & ttrfmhno)
                dict.Add("fk_id", "")
                dict.Add("userid", userid)
                dict.Add("dtcreated", dtcreatedforDeatil)
                datatostock.Add(dict)

                'prepare to hpp
                'Dim dicthpp As New Dictionary(Of String, Object)
                'dicthpp.Add("noref", ttrfmhno)
                'dicthpp.Add("mmtrid", dat("mmtrid"))
                'dicthpp.Add("hpp", dat("hpp"))
                'dicthpp.Add("price", dat("ttrfmdprice"))
                'dicthpp.Add("dtcreated", dtcreatedforDeatil)
                'datahpp.Add(dicthpp)
            Next

        Catch ex As Exception
            Dim LogMsg As String = ex.Message & vbCrLf & ex.StackTrace
            MyApplication.ShowStatus(LogMsg, WARNING_STAT)
            ErrorLogger.WriteToErrorLog(LogMsg, "Insert", ERROR_STAT, "Insert")
            Return 0
        End Try

        If multivalue.Length > 1 Then 'MyBase.InsertData() ==> Insert Header
            multivalue = multivalue.Substring(0, multivalue.Length - 1)
            DeleteByNo(ttrfmhno)
            strsql = "INSERT INTO " & TableName + "(`ttrfmhno`,`mmtrid`,`ttrfmdqty`,`ttrfmdprice`,`dtcreated`) VALUES " & multivalue & ";" & vbCrLf
            'trans = MyBase.InsertData() 'MyBase.InsertData() ==> Insert Detail
            'If trans > 0 Then
            strsql = strsql + ModelStock.InsertData(datatostock) 'Insert/Update New Stok
            'strsql = strsql + ModelHPP.InsertData(datahpp) 'Insert/Update New HPP
            'End If
        End If
        Return strsql
    End Function
    Public Function DeleteByNo(Optional ByVal NoHeader As String = "") As String
        Dim no As String
        Dim sqlstr = ""
        no = IIf(String.IsNullOrEmpty(NoHeader), ttrfmhno, NoHeader)
        sqlstr = "DELETE FROM " & TableName + " WHERE ttrfmhno='" & no & "';" & vbCrLf
        'Dim res As Integer = MyBase.DeleteData
        If Not String.IsNullOrEmpty(sqlstr) Then
            sqlstr = sqlstr & ModelStock.DeleteByNo(no)
            'sqlstr = sqlstr & ModelHPP.DeleteByNo(no)
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
