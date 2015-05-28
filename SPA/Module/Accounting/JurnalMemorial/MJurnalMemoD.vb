Public Class MJurnalMemoD
    Inherits MJurnalMemoH

    Public tjmdid As Integer
    Public mcoadno As String
    Public debet As String = "0"
    Public kredit As String = "0"
    Public tjmddesc As String = ""


    Public dtcreatedforDeatil As String = ""
    Public bookvalue As String 'additional for posting to General Ledger
    Public soldvalue As String 'additional for posting to General Ledger

    Dim ModelHeader As New MJurnalMemoH
    Dim ModelGL As New GeneralLedger

    Sub New()
        MyBase.New()
        BaseQuery = "SELECT * FROM tjmd"
        SelectQuery = "SELECT T1.`tjmdid`,T1.`tjmhno`,T1.`mcoadno`,T2.`mcoadname`,T1.`debet`,T1.`kredit`,(T1.`debet` * T1.`kredit`) AS jumlah,T1.dtcreated " & _
                      "FROM tjmd T1 INNER JOIN mcoad T2 ON T1.`mcoadno` = T2.`mcoadno`"
        TableName = "tjmd"
        PrimaryKey = "tjmdid"
    End Sub
    Function FindDataDetail(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "WHERE tjmdid like '%" & sSearch & "%' " & _
                        "OR tjmhno like '%" & sSearch & "%' " & _
                        "OR mcoadno like '%" & sSearch & "%' " & _
                        "OR mcoadname like '%" & sSearch & "%' " & _
                        "OR debet like '%" & sSearch & "%' " & _
                        "OR kredit like '%" & sSearch & "%' "
        Else
            Me.WHERE = ""
        End If
        Return MyBase.GetData
    End Function
    Public Overloads Function GetDataList(Optional no As String = "") As List(Of Dictionary(Of String, Object))
        Me.StringSQL = "SELECT T1.`tjmdid`,T1.`tjmhno`,T1.`mcoadno`,T2.`mcoadname`,T1.`debet`,T1.`kredit`,(T1.`debet` * T1.`kredit`) AS jumlah,T1.dtcreated " & _
                      "FROM tjmd T1 INNER JOIN mcoad T2 ON T1.`mcoadno` = T2.`mcoadno` WHERE tjmhno ='" & no & "'"
        'MsgBox(Me.StringSQL)
        Return MyBase.GetDataList
    End Function
    Public Overloads Function InsertData() As Integer
        Dim values As String
        Dim trans As Integer = 0
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)

        Me.StringSQL = ""
        ModelHeader.tjmhno = Me.tjmhno
        ModelHeader.tjmhdt = Me.tjmhdt
        ModelHeader.tjmhdesc = Me.tjmhdesc

        ModelHeader.dtcreated = Me.dtcreated
        Me.StringSQL = ModelHeader.GetSqlInsertData()

        If Not String.IsNullOrEmpty(Me.StringSQL) Then 'Insert Header
            values = "('" & MyBase.tjmhno & "','" & _
                      mcoadno & "','" & _
                      debet & "','" & _
                      kredit & "','" & _
                      tjmddesc & "','" & _
                      userid & "','" & _
                      dtcreated & "')"
            Me.StringSQL = Me.StringSQL + "INSERT INTO " & TableName + "(`tjmhno`,`mcoadno`,`debet`,`kredit`,`tjmddesc`,`userid`,`dtcreated`) VALUES " & values
            trans = MyBase.InsertData() 'MyBase.InsertData() ==> Insert Detail
        End If
        Return trans
    End Function
    Public Overloads Function InsertData(ByVal datadetail As List(Of Dictionary(Of String, Object))) As Integer
        Dim trans As Integer = 0

        Me.StringSQL = ""
        ModelHeader.tjmhno = Me.tjmhno
        ModelHeader.tjmhdt = Me.tjmhdt
        ModelHeader.tjmhdesc = Me.tjmhdesc

        ModelHeader.dtcreated = Me.dtcreated
        Me.StringSQL = ModelHeader.GetSqlInsertData()

        If Not String.IsNullOrEmpty(Me.StringSQL) Then 'Insert Header
            Me.StringSQL = Me.StringSQL + queryInsertDetail(datadetail)
            trans = MyBase.InsertData()
        End If
        Return trans
    End Function
    Public Overloads Function UpdateData(ByVal datadetail As List(Of Dictionary(Of String, Object))) As Integer
        Dim trans As Integer = 0

        Me.StringSQL = ""
        ModelHeader.tjmhno = Me.tjmhno
        ModelHeader.tjmhdt = Me.tjmhdt
        ModelHeader.tjmhdesc = Me.tjmhdesc

        Me.StringSQL = ModelHeader.GetSqlUpdateData() 'Update Header

        If Not String.IsNullOrEmpty(Me.StringSQL) Then 'Insert Header
            Me.StringSQL = Me.StringSQL + DeleteByNo(Me.tjmhno)
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
        'Dim datatostock, datahpp As New List(Of Dictionary(Of String, Object))

        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)
        Try
            For Each dat In datadetail

                If Not String.IsNullOrEmpty(dat("dtcreated")) And dat("dtcreated") <> "0001/01/01 0:00:00" Then
                    dtcreatedforDeatil = dat("dtcreated")
                Else
                    dtcreatedforDeatil = Format(Date.Now, "yyyy/MM/dd H:mm:ss")
                End If

                multivalue = multivalue & "('" & Me.tjmhno & "','" & _
                                 dat("mcoadno").ToString & "','" & _
                                 dat("debet").ToString & "','" & _
                                 dat("kredit").ToString & "','" & _
                                 tjmhdesc & "','" & _
                                 userid & "','" & _
                                 dtcreatedforDeatil & "'),"
                'Prepare data to GL
                ModelGL.rgldt = tjmhdt
                ModelGL.mcoadno = dat("mcoadno").ToString
                ModelGL.noref = tjmhno
                ModelGL.noref2 = tjmhno
                ModelGL.rglin = dat("debet").ToString
                ModelGL.rglout = dat("kredit").ToString
                ModelGL.rgldesc = tjmhdesc 'IIf(String.IsNullOrEmpty(dat("tjmddesc").ToString), tjmhdesc, dat("tjmddesc").ToString)
                'ModelGL.fk_id = tjmdid
                ModelGL.userid = userid
                ModelGL.dtcreated = dtcreatedforDeatil

                strsql = strsql + ModelGL.GetSqlInsertData
            Next

        Catch ex As Exception
            Dim LogMsg As String = ex.Message & vbCrLf & ex.StackTrace
            MyApplication.ShowStatus(LogMsg, WARNING_STAT)
            ErrorLogger.WriteToErrorLog(LogMsg, "Insert", ERROR_STAT, "Insert")
            Return 0
        End Try

        If multivalue.Length > 1 Then 'MyBase.InsertData() ==> Insert Header
            multivalue = multivalue.Substring(0, multivalue.Length - 1)
            DeleteByNo(tjmhno)
            strsql = strsql + "INSERT INTO " & TableName + "(`tjmhno`,`mcoadno`,`debet`,`kredit`,`tjmddesc`,`userid`,`dtcreated`) VALUES " & multivalue & ";" & vbCrLf
        End If
        Return strsql
    End Function
    Public Function DeleteByNo(Optional ByVal NoHeader As String = "") As String
        Dim no As String
        Dim sqlstr = ""
        no = IIf(String.IsNullOrEmpty(NoHeader), tjmhno, NoHeader)
        sqlstr = "DELETE FROM " & TableName + " WHERE tjmhno='" & no & "';" & vbCrLf
        'Dim res As Integer = MyBase.DeleteData
        If Not String.IsNullOrEmpty(sqlstr) Then
            sqlstr = sqlstr & ModelGL.DeleteByNo(no)
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
