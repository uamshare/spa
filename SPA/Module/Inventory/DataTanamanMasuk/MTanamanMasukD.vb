Public Class MTanamanMasukD
    Inherits MTanamanMasukH

    Public trcvmdid As Integer
    Public mmtrid As String
    Public trcvmdqty As String = "0"
    Public trcvmdprice As String = "0"
    Public dtcreatedforDeatil As String = ""
    Public bookvalue As String 'additional for posting to General Ledger

    Dim ModelHeader As New MTanamanMasukH
    Dim ModelStock As New Rstockm
    Dim ModelHPP As New Mhpp
    Dim ModelGL As New GeneralLedger

    'Private dtcreated As String

    Sub New()
        MyBase.New()
        BaseQuery = "SELECT * FROM trcvmd"
        SelectQuery = "SELECT T1.`trcvmdid`,T1.`trcvmhno`,T1.`mmtrid`,T2.`mmtrname`,T2.`polybag`,T1.`trcvmdqty`,T1.`trcvmdprice`,(T1.`trcvmdqty` * T1.`trcvmdprice`) AS jumlah,dtcreated " & _
                      "FROM trcvmd T1 INNER JOIN mmtr T2 ON T1.`mmtrid` = T2.`mmtrid`"
        TableName = "trcvmd"
        PrimaryKey = "trcvmdid"
    End Sub
    Function FindDataDetail(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "WHERE trcvmdid like '%" & sSearch & "%' " & _
                        "OR trcvmhno like '%" & sSearch & "%' " & _
                        "OR mmtrname like '%" & sSearch & "%' " & _
                        "OR polybag like '%" & sSearch & "%' " & _
                        "OR trcvmdqty like '%" & sSearch & "%' "
        Else
            Me.WHERE = ""
        End If
        Return MyBase.GetData
    End Function
    Public Overloads Function GetDataList(Optional no As String = "") As List(Of Dictionary(Of String, Object))
        Me.StringSQL = "SELECT * FROM trcvmd WHERE trcvmhno ='" & no & "'"
        'MsgBox(Me.StringSQL)
        Return MyBase.GetDataList
    End Function
    Public Overloads Function InsertData() As Integer
        Dim values As String
        Dim trans As Integer = 0
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)

        Me.StringSQL = ""
        ModelHeader.trcvmhno = Me.trcvmhno
        ModelHeader.trcvmhdt = Me.trcvmhdt
        ModelHeader.pono = Me.pono
        ModelHeader.podate = Me.podate
        ModelHeader.supplier = Me.supplier
        ModelHeader.dtcreated = Me.dtcreated
        Me.StringSQL = ModelHeader.GetSqlInsertData()

        If Not String.IsNullOrEmpty(Me.StringSQL) Then 'Insert Header
            values = "('" & MyBase.trcvmhno & "','" & _
                      mmtrid & "','" & _
                      trcvmdqty & "','" & _
                      trcvmdprice & "','" & _
                      dtcreated & "')"
            Me.StringSQL = Me.StringSQL + "INSERT INTO " & TableName + "(`trcvmhno`,`mmtrid`,`trcvmdqty`,`trcvmdprice`,`dtcreated`) VALUES " & values
            trans = MyBase.InsertData() 'MyBase.InsertData() ==> Insert Detail
        End If
        Return trans
    End Function
    Public Overloads Function InsertData(ByVal datadetail As List(Of Dictionary(Of String, Object))) As Integer
        Dim trans As Integer = 0

        Me.StringSQL = ""
        ModelHeader.trcvmhno = Me.trcvmhno
        ModelHeader.trcvmhdt = Me.trcvmhdt
        ModelHeader.pono = Me.pono
        ModelHeader.podate = Me.podate
        ModelHeader.supplier = Me.supplier
        ModelHeader.dtcreated = Me.dtcreated
        Me.StringSQL = ModelHeader.GetSqlInsertData()

        If Not String.IsNullOrEmpty(Me.StringSQL) Then 'Insert Header
            'Do Posting to General Ledger
            ModelGL.rgldt = Me.trcvmhdt
            ModelGL.noref = Me.trcvmhno
            ModelGL.noref2 = Me.trcvmhno
            ModelGL.rgldesc = "Update Data Tanaman Masuk No " & Me.trcvmhno
            ModelGL.dtcreated = Me.dtcreated
            Dim ParamPosting As New Dictionary(Of String, Object)
            ParamPosting.Add("idtrrans", "PB")
            Dim accountlistvalue As New Dictionary(Of String, Object)
            accountlistvalue.Add("acc_debit", Me.bookvalue)
            accountlistvalue.Add("acc_credit", Me.bookvalue)
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
        ModelHeader.trcvmhno = Me.trcvmhno
        ModelHeader.trcvmhdt = Me.trcvmhdt
        ModelHeader.pono = Me.pono
        ModelHeader.podate = Me.podate
        ModelHeader.supplier = Me.supplier
        'ModelHeader.dtcreated = Me.dtcreated
        Me.StringSQL = ModelHeader.GetSqlUpdateData() 'Update Header

        If Not String.IsNullOrEmpty(Me.StringSQL) Then 'Insert Header
            Me.StringSQL = Me.StringSQL + ModelGL.DeleteByNo(Me.trcvmhno) 'Update Header
            'Do Posting to General Ledger
            ModelGL.rgldt = Me.trcvmhdt
            ModelGL.noref = Me.trcvmhno
            ModelGL.noref2 = Me.trcvmhno
            ModelGL.rgldesc = "Update Data Tanaman Masuk No " & Me.trcvmhno
            ModelGL.dtcreated = Me.dtcreated
            Dim ParamPosting As New Dictionary(Of String, Object)
            ParamPosting.Add("idtrrans", "PB")
            Dim accountlistvalue As New Dictionary(Of String, Object)
            accountlistvalue.Add("acc_debit", Me.bookvalue)
            accountlistvalue.Add("acc_credit", Me.bookvalue)
            ParamPosting.Add("accountlistvalue", accountlistvalue)
            Me.StringSQL = Me.StringSQL + ModelGL.doPosting(ParamPosting)

            'MsgBox(Me.StringSQL)

            Me.StringSQL = Me.StringSQL + DeleteByNo(Me.trcvmhno)
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

                multivalue = multivalue & "('" & trcvmhno & "','" & _
                                 dat("mmtrid").ToString & "','" & _
                                 dat("trcvmdqty").ToString & "','" & _
                                 dat("trcvmdprice").ToString & "','" & _
                                 dtcreatedforDeatil & "'),"
                'Prepare data to Stock
                Dim dict As New Dictionary(Of String, Object)
                dict.Add("noref", trcvmhno)
                dict.Add("mmtrid", dat("mmtrid"))
                dict.Add("stockin", CDec(dat("trcvmdqty")))
                dict.Add("stockout", 0)
                dict.Add("rstockmdesc", "Data Tanaman Masuk No " & trcvmhno)
                dict.Add("fk_id", "")
                dict.Add("userid", userid)
                dict.Add("dtcreated", dtcreatedforDeatil)
                datatostock.Add(dict)

                'prepare to hpp
                Dim dicthpp As New Dictionary(Of String, Object)
                dicthpp.Add("noref", trcvmhno)
                dicthpp.Add("mmtrid", dat("mmtrid"))
                dicthpp.Add("hpp", dat("hpp"))
                dicthpp.Add("price", dat("trcvmdprice"))
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
            DeleteByNo(trcvmhno)
            strsql = "INSERT INTO " & TableName + "(`trcvmhno`,`mmtrid`,`trcvmdqty`,`trcvmdprice`,`dtcreated`) VALUES " & multivalue & ";" & vbCrLf
            'trans = MyBase.InsertData() 'MyBase.InsertData() ==> Insert Detail
            'If trans > 0 Then
            strsql = strsql + ModelStock.InsertData(datatostock) 'Insert/Update New Stok
            strsql = strsql + ModelHPP.InsertData(datahpp) 'Insert/Update New HPP
            'End If
        End If
        Return strsql
    End Function
    Public Function DeleteByNo(Optional ByVal NoHeader As String = "") As String
        Dim no As String
        Dim sqlstr = ""
        no = IIf(String.IsNullOrEmpty(NoHeader), trcvmhno, NoHeader)
        sqlstr = "DELETE FROM " & TableName + " WHERE trcvmhno='" & no & "';" & vbCrLf
        'Dim res As Integer = MyBase.DeleteData
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
            trans = MyBase.DeleteData()
        End If
        Return trans
    End Function
End Class
