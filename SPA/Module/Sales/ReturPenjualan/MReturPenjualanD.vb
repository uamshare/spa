Public Class MReturPenjualanD
    Inherits MReturPenjualanH

    Public trtrdid As Integer
    Public mmtrid As String
    Public trtrdqty As String = "0"
    Public trtrdprice As String = "0"
    Public trtrdtype As String = "0"
    Public tinvdid As Integer

    Public dtcreatedforDeatil As String = ""
    Public bookvalue As String 'additional for posting to General Ledger
    Public soldvalue As String 'additional for posting to General Ledger

    Dim ModelHeader As New MReturPenjualanH
    Dim ModelStock As New Rstockm
    'Dim ModelHPP As New Mhpp
    Dim ModelGL As New GeneralLedger

    'Private dtcreated As String

    Sub New()
        MyBase.New()
        BaseQuery = "SELECT * FROM trtrd"
        SelectQuery = "SELECT T1.`trtrdid`,T1.`trtrhno`,T1.`mmtrid`,T2.`mmtrname`,T2.`polybag`,T1.`trtrdqty`,T1.`trtrdprice`,(T1.`trtrdqty` * T1.`trtrdprice`) AS jumlah,T1.dtcreated " & _
                      "FROM trtrd T1 INNER JOIN mmtr T2 ON T1.`mmtrid` = T2.`mmtrid`"
        TableName = "trtrd"
        PrimaryKey = "trtrdid"
    End Sub
    Function FindDataDetail(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "WHERE trtrdid like '%" & sSearch & "%' " & _
                        "OR trtrhno like '%" & sSearch & "%' " & _
                        "OR mmtrname like '%" & sSearch & "%' " & _
                        "OR polybag like '%" & sSearch & "%' " & _
                        "OR trtrdqty like '%" & sSearch & "%' "
        Else
            Me.WHERE = ""
        End If
        Return MyBase.GetData
    End Function
    Public Overloads Function GetDataList(Optional no As String = "") As List(Of Dictionary(Of String, Object))
        Me.StringSQL = "SELECT * FROM trtrd WHERE trtrhno ='" & no & "'"
        'MsgBox(Me.StringSQL)
        Return MyBase.GetDataList
    End Function
    Public Overloads Function InsertData() As Integer
        Dim values As String
        Dim trans As Integer = 0
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)

        Me.StringSQL = ""
        ModelHeader.trtrhno = Me.trtrhno
        ModelHeader.trtrhdt = Me.trtrhdt
        ModelHeader.tinvhno = Me.tinvhno
        ModelHeader.trtrhnote = Me.trtrhnote

        ModelHeader.dtcreated = Me.dtcreated
        Me.StringSQL = ModelHeader.GetSqlInsertData()

        If Not String.IsNullOrEmpty(Me.StringSQL) Then 'Insert Header
            values = "('" & MyBase.trtrhno & "','" & _
                      mmtrid & "','" & _
                      trtrdqty & "','" & _
                      trtrdprice & "','" & _
                      tinvdid & "','" & _
                      dtcreated & "')"
            Me.StringSQL = Me.StringSQL + "INSERT INTO " & TableName + "(`trtrhno`,`mmtrid`,`trtrdqty`,`trtrdprice`,`tinvdid`,`dtcreated`) VALUES " & values
            trans = MyBase.InsertData() 'MyBase.InsertData() ==> Insert Detail
        End If
        Return trans
    End Function
    Public Overloads Function InsertData(ByVal datadetail As List(Of Dictionary(Of String, Object))) As Integer
        Dim trans As Integer = 0

        Me.StringSQL = ""
        ModelHeader.trtrhno = Me.trtrhno
        ModelHeader.trtrhdt = Me.trtrhdt
        ModelHeader.tinvhno = Me.tinvhno
        ModelHeader.trtrhnote = Me.trtrhnote

        ModelHeader.dtcreated = Me.dtcreated
        Me.StringSQL = ModelHeader.GetSqlInsertData()

        If Not String.IsNullOrEmpty(Me.StringSQL) Then 'Insert Header
            'Do Posting to General Ledger
            ModelGL.rgldt = Me.trtrhdt
            ModelGL.noref = Me.trtrhno
            ModelGL.noref2 = Me.tinvhno
            ModelGL.rgldesc = "Insert Data Nota Penjualan No " & Me.trtrhno
            ModelGL.dtcreated = Me.dtcreated
            Dim ParamPosting As New Dictionary(Of String, Object)
            ParamPosting.Add("idtrrans", "RJ")
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
        ModelHeader.trtrhno = Me.trtrhno
        ModelHeader.trtrhdt = Me.trtrhdt
        ModelHeader.tinvhno = Me.tinvhno
        ModelHeader.trtrhnote = Me.trtrhnote

        Me.StringSQL = ModelHeader.GetSqlUpdateData() 'Update Header

        If Not String.IsNullOrEmpty(Me.StringSQL) Then 'Insert Header
            Me.StringSQL = Me.StringSQL + ModelGL.DeleteByNo(Me.trtrhno) 'Update Header
            'Do Posting to General Ledger
            ModelGL.rgldt = Me.trtrhdt
            ModelGL.noref = Me.trtrhno
            ModelGL.noref2 = Me.tinvhno
            ModelGL.rgldesc = "Update Data Nota Penjualan No " & Me.trtrhno
            ModelGL.dtcreated = Me.dtcreated
            Dim ParamPosting As New Dictionary(Of String, Object)
            ParamPosting.Add("idtrrans", "PB")
            Dim accountlistvalue As New Dictionary(Of String, Object)
            accountlistvalue.Add("acc_debit", Me.soldvalue)
            accountlistvalue.Add("acc_credit", Me.soldvalue)
            accountlistvalue.Add("acc_debit2", Me.bookvalue)
            accountlistvalue.Add("acc_credit2", Me.bookvalue)
            ParamPosting.Add("accountlistvalue", accountlistvalue)
            Me.StringSQL = Me.StringSQL + ModelGL.doPosting(ParamPosting)

            'MsgBox(Me.StringSQL)

            Me.StringSQL = Me.StringSQL + DeleteByNo(Me.trtrhno)
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

                multivalue = multivalue & "('" & trtrhno & "','" & _
                                 dat("mmtrid").ToString & "','" & _
                                 dat("trtrdqty").ToString & "','" & _
                                 dat("trtrdprice").ToString & "','" & _
                                 dat("tinvdid").ToString & "','" & _
                                 dtcreatedforDeatil & "'),"
                'Prepare data to Stock
                Dim dict As New Dictionary(Of String, Object)
                dict.Add("noref", trtrhno)
                dict.Add("mmtrid", dat("mmtrid"))
                dict.Add("stockin", CDec(dat("trtrdqty")))
                dict.Add("stockout", 0)
                dict.Add("rstockmdesc", "Data Nota Penjualan No " & trtrhno)
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
            DeleteByNo(trtrhno)
            strsql = "INSERT INTO " & TableName + "(`trtrhno`,`mmtrid`,`trtrdqty`,`trtrdprice`,`tinvdid`,`dtcreated`) VALUES " & multivalue & ";" & vbCrLf
            strsql = strsql + ModelStock.InsertData(datatostock) 'Insert/Update New Stok
        End If
        Return strsql
    End Function
    Public Function DeleteByNo(Optional ByVal NoHeader As String = "") As String
        Dim no As String
        Dim sqlstr = ""
        no = IIf(String.IsNullOrEmpty(NoHeader), trtrhno, NoHeader)
        sqlstr = "DELETE FROM " & TableName + " WHERE trtrhno='" & no & "';" & vbCrLf
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
End Class
