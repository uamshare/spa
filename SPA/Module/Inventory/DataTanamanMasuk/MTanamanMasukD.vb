Public Class MTanamanMasukD
    Inherits CDataAcces

    Public trcvmdid As Integer
    Public trcvhno As String
    Public mmtrid As String
    Public trcvmdqty As String
    Public trcvmdprice As String

    Private dtcreated As String

    Sub New()
        MyBase.New()
        BaseQuery = "SELECT * FROM trcvmd"
        SelectQuery = "SELECT T1.`trcvmdid`,T1.`trcvmhno`,T1.`mmtrid`,T2.`mmtrname`,T2.`polybag`,T1.`trcvmdqty`,T1.`trcvmdprice`,(T1.`trcvmdqty` * T1.`trcvmdprice`) AS jumlah " & _
                      "FROM trcvmd T1 INNER JOIN mmtr T2 ON T1.`mmtrid` = T2.`mmtrid`"
        TableName = "trcvmd"
        PrimaryKey = "trcvmdid"
    End Sub
    Function FindData(sSearch As String) As DataTable
        If Not String.IsNullOrEmpty(sSearch) Then
            Me.WHERE = "WHERE trcvmdid like '%" & sSearch & "%' " & _
                        "OR trcvhno like '%" & sSearch & "%' " & _
                        "OR mmtrname like '%" & sSearch & "%' " & _
                        "OR polybag like '%" & sSearch & "%' " & _
                        "OR trcvmdqty like '%" & sSearch & "%' "
        Else
            Me.WHERE = ""
        End If
        Return MyBase.GetData
    End Function
    Public Overloads Function InsertData() As Integer
        Dim values As String
        dtcreated = Format(Date.Now, "yyyy/MM/dd H:mm:ss")
        'userid = MUsers.UserInfo()("userid")

        values = "('" & trcvmdid & "','" & _
                      trcvhno & "','" & _
                      mmtrid & "','" & _
                      trcvmdqty & "','" & _
                      trcvmdprice & "','" & _
                      dtcreated & "')"
        Me.StringSQL = "INSERT INTO " & TableName + "(`trcvmdid`,`trcvhno`,`mmtrid`,`trcvmdqty`,`trcvmdprice`,`dtcreated`) VALUES " & values
        Return MyBase.InsertData()
    End Function

    Public Overloads Function UpdateData() As Integer
        Dim setquery As String
        'userid = MUsers.UserInfo()("userid")

        setquery = "SET trcvmdid='" & trcvmdid & "','" & _
                    "trcvhno='" & trcvhno & "','" & _
                    "mmtrid='" & mmtrid & "','" & _
                    "trcvmdqty='" & trcvmdqty & "','" & _
                    "trcvmdprice='" & trcvmdprice & "'"
        Me.StringSQL = "UPDATE " & TableName + " " & setquery
        Return MyBase.UpdateData()
    End Function
End Class
