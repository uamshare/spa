Public Class Mhpp
    Inherits CDataAcces

    Public noref As String
    Public mhppid As Integer
    Public mmtrid As String
    Public hpp As Decimal = 0
    Public price As Decimal = 0

    Public dtcreated As String

    Sub New()
        MyBase.New()
        BaseQuery = "SELECT * FROM `mhpp`"
        SelectQuery = "SELECT * FROM `mhpp`"
        TableName = "mhpp"
        PrimaryKey = "mhppid"
    End Sub
    Public Overloads Function InsertData() As Integer
        Dim values As String
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)
        values = "('" & noref & "','" & _
                      mmtrid & "','" & _
                      hpp & "','" & _
                      dtcreated & "')"
        Me.StringSQL = "INSERT INTO " & TableName & _
                    "(`noref`,`mmtrid`,`hpp`,`dtcreated`) VALUES " & values
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
                                 dat("hpp").ToString & "','" & _
                                 dat("price").ToString & "','" & _
                                 dtcreated & "'),"
            Next

        Catch ex As Exception
            Dim LogMsg As String = ex.Message & vbCrLf & ex.StackTrace
            MyApplication.ShowStatus(LogMsg, WARNING_STAT)
            ErrorLogger.WriteToErrorLog(LogMsg, "Insert", ERROR_STAT, "Insert")
            Return 0
        End Try
        If multivalue.Length > 1 Then
            multivalue = multivalue.Substring(0, multivalue.Length - 1)
            strsqll = "INSERT INTO " & TableName & _
                   "(`noref`,`mmtrid`,`hpp`,`price`,`dtcreated`) VALUES " & multivalue & ";" & vbCrLf
        End If

        'MsgBox(Me.StringSQL)
        'Return MyBase.InsertData
        Return strsqll
    End Function

    Public Overloads Function getDataList(Currdt As Date, Optional noref As String = "", Optional viewtable As String = "mmtr") As List(Of Dictionary(Of String, Object))
        Dim where As String = ""
        If Not String.IsNullOrEmpty(noref) Then
            where = "WHERE mmtrid='" & noref & "'"
        End If
        Me.StringSQL = "SELECT TA.*,IFNULL(TB.hpp,0) hpp FROM " & _
                       "(SELECT * FROM `" & viewtable & "` " & where & ") TA " & _
                       "LEFT JOIN " & _
                       "(SELECT * FROM (SELECT * FROM mhpp WHERE `dtcreated` < '" & Format(Currdt, "yyyy-MM-dd") & "' ORDER BY 1 DESC) T1 " & _
                       "GROUP BY mmtrid) TB ON TA.mmtrid = TB.mmtrid"
        Return MyBase.GetDataList
    End Function
    Public Function DeleteByNo(ByVal NoHeader As String) As String
        Return "DELETE FROM " & TableName + " WHERE noref='" & NoHeader & "';" & vbCrLf
    End Function
End Class
