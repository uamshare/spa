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
End Class
