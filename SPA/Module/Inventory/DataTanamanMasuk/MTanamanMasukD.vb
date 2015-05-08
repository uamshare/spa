Public Class MTanamanMasukD
    Inherits MTanamanMasukH

    Public trcvmdid As Integer
    Public mmtrid As String
    Public trcvmdqty As String = "0"
    Public trcvmdprice As String = "0"
    Public dtcreatedforDeatil As String = ""
    Dim ModelStock As New Rstockm

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

        Dim ModelHeader As New MTanamanMasukH
        ModelHeader.trcvmhno = Me.trcvmhno
        ModelHeader.trcvmhdt = Me.trcvmhdt
        ModelHeader.pono = Me.pono
        ModelHeader.podate = Me.podate
        ModelHeader.supplier = Me.supplier
        ModelHeader.dtcreated = Me.dtcreated
        trans = ModelHeader.InsertData()

        If trans > 0 Then 'MyBase.InsertData() ==> Insert Header
            values = "('" & MyBase.trcvmhno & "','" & _
                      mmtrid & "','" & _
                      trcvmdqty & "','" & _
                      trcvmdprice & "','" & _
                      dtcreated & "')"
            Me.StringSQL = "INSERT INTO " & TableName + "(`trcvmhno`,`mmtrid`,`trcvmdqty`,`trcvmdprice`,`dtcreated`) VALUES " & values
            trans = MyBase.InsertData() 'MyBase.InsertData() ==> Insert Detail
        End If
        Return trans
    End Function
    Public Overloads Function InsertData(ByVal datadetail As List(Of Dictionary(Of String, Object))) As Integer
        Dim multivalue As String = ""
        Dim datatostock As New List(Of Dictionary(Of String, Object))
        Dim trans As Integer = 0
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)
        Try
            For Each dat In datadetail

                multivalue = multivalue & "('" & MyBase.trcvmhno & "','" & _
                                 dat("mmtrid").ToString & "','" & _
                                 dat("trcvmdqty").ToString & "','" & _
                                 dat("trcvmdprice").ToString & "','" & _
                                 dtcreated & "'),"
                Dim dict As New Dictionary(Of String, Object)
                
                dict.Add("noref", trcvmhno)
                dict.Add("mmtrid", dat("mmtrid"))
                dict.Add("stockin", CDec(dat("trcvmdqty")))
                dict.Add("stockout", 0)
                dict.Add("rstockmdesc", "Data Tanaman Masuk No " & trcvmhno)
                dict.Add("fk_id", "")
                dict.Add("userid", userid)
                datatostock.Add(dict)
            Next

        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
            Return 0
        End Try

        Dim ModelHeader As New MTanamanMasukH
        ModelHeader.trcvmhno = Me.trcvmhno
        ModelHeader.trcvmhdt = Me.trcvmhdt
        ModelHeader.pono = Me.pono
        ModelHeader.podate = Me.podate
        ModelHeader.supplier = Me.supplier
        ModelHeader.dtcreated = Me.dtcreated
        trans = ModelHeader.InsertData()

        If trans > 0 And multivalue.Length > 1 Then 'MyBase.InsertData() ==> Insert Header
            multivalue = multivalue.Substring(0, multivalue.Length - 1)
            Me.StringSQL = "INSERT INTO " & TableName + "(`trcvmhno`,`mmtrid`,`trcvmdqty`,`trcvmdprice`,`dtcreated`) VALUES " & multivalue
            trans = MyBase.InsertData() 'MyBase.InsertData() ==> Insert Detail
            If trans > 0 Then
                ModelStock.InsertData(datatostock)
            End If
        End If
        Return trans
    End Function
    Public Overloads Function UpdateData(ByVal datadetail As List(Of Dictionary(Of String, Object))) As Integer
        Dim multivalue As String = ""
        Dim trans As Integer = 0
        Dim datatostock As New List(Of Dictionary(Of String, Object))

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
            Next

        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
            Return 0
        End Try

        Dim ModelHeader As New MTanamanMasukH
        ModelHeader.trcvmhno = Me.trcvmhno
        ModelHeader.trcvmhdt = Me.trcvmhdt
        ModelHeader.pono = Me.pono
        ModelHeader.podate = Me.podate
        ModelHeader.supplier = Me.supplier
        'ModelHeader.dtcreated = Me.dtcreated
        trans = ModelHeader.UpdateData()

        If trans > 0 And multivalue.Length > 1 Then 'MyBase.InsertData() ==> Insert Header
            multivalue = multivalue.Substring(0, multivalue.Length - 1)
            'MsgBox(multivalue)
            DeleteByNo(trcvmhno)
            Me.StringSQL = "INSERT INTO " & TableName + "(`trcvmhno`,`mmtrid`,`trcvmdqty`,`trcvmdprice`,`dtcreated`) VALUES " & multivalue
            trans = MyBase.InsertData() 'MyBase.InsertData() ==> Insert Detail
            If trans > 0 Then
                ModelStock.InsertData(datatostock)
            End If
        End If
        Return trans
    End Function
    Public Function DeleteByNo(Optional ByVal NoHeader As String = "") As Integer
        Dim no As String
        no = IIf(String.IsNullOrEmpty(NoHeader), trcvmhno, NoHeader)
        Me.StringSQL = "DELETE FROM " & TableName + " WHERE trcvmhno='" & no & "'"


        Dim res As Integer = MyBase.DeleteData
        If res > -1 Then
            ModelStock.DeleteByNo(no)
        End If

        Return res
    End Function
End Class
