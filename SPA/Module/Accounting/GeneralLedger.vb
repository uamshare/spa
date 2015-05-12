Public Class GeneralLedger
    Inherits CDataAcces

    Public rglid As Integer
    Public rgldt As String
    Public mcoadno As String
    Public noref As String
    Public noref2 As String
    Public rglin As Decimal = 0
    Public rglout As Decimal = 0
    Public rgldesc As String = ""
    Public fk_id As String = ""
    Public userid As String
    Public dtcreated As String

    Private DefaultParamPosting As New Dictionary(Of String, Object)

    Sub New()
        MyBase.New()
        BaseQuery = "SELECT * FROM `rgl`"
        SelectQuery = "SELECT * FROM `rgl`"
        TableName = "rgl"
        PrimaryKey = "rglid"

        userid = MUsers.UserInfo()("userid")

        DefaultParamPosting.Add("idtrrans", "")
        'DefaultParamPosting.Add("noref", "")
        'DefaultParamPosting.Add("noref2", "")
        DefaultParamPosting.Add("accountlistname", Nothing)
        DefaultParamPosting.Add("accountlistvalue", Nothing)
    End Sub

    Public Overloads Function InsertData() As Integer
        Return 0
    End Function
    Public Overloads Function UpdateData() As Integer
        Return 0
    End Function
    Public Overloads Function DeleteData(Optional ByVal id = -1) As Integer
        Return 0
    End Function

    ''' <summary>
    ''' Do Posting to General Ledger
    ''' ModelGL.rgldt = Me.trcvmhdt
    ''' ModelGL.noref = Me.trcvmhno
    ''' ModelGL.noref2 = Me.trcvmhno
    ''' ModelGL.rgldesc = 'Update Data Tanaman Masuk No '
    ''' ModelGL.dtcreated = Me.dtcreated
    ''' Dim ParamPosting As New Dictionary(Of String, Object)
    ''' ParamPosting.Add("idtrrans", "PB")
    ''' Dim accountlistvalue As New Dictionary(Of String, Object)
    ''' accountlistvalue.Add("acc_debit", Me.bookvalue)
    ''' accountlistvalue.Add("acc_credit", Me.bookvalue)
    ''' ParamPosting.Add("accountlistvalue", accountlistvalue)
    ''' StringSQL=ModelGL.doPosting(ParamPosting)
    ''' </summary>
    ''' <param name="ParamPosting"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function doPosting(ParamPosting As Dictionary(Of String, Object)) As String
        Dim strsqll = ""
        Dim mapo As New MAkunPosting

        Try
            For Each dict As KeyValuePair(Of String, Object) In ParamPosting
                If Me.DefaultParamPosting.ContainsKey(dict.Key) Then
                    Me.DefaultParamPosting(dict.Key) = dict.Value
                End If
            Next

            If Not String.IsNullOrEmpty(Me.DefaultParamPosting("idtrrans")) Then
                Dim ListAccountPosting As List(Of Dictionary(Of String, Object)) = mapo.getListAccountPosting(Me.DefaultParamPosting("idtrrans"))

                For Each dictacc As Dictionary(Of String, Object) In ListAccountPosting
                    For Each dictacckey As KeyValuePair(Of String, Object) In dictacc
                        'MsgBox(dictacckey.Key + " = " + dictacckey.Value)
                        'Me.DefaultParamPosting("accountlistname").add(dictacckey.Key, dictacckey.Value)

                        If dictacckey.Key.Contains("debit") And Not String.IsNullOrEmpty(dictacckey.Value.ToString) Then
                            Me.mcoadno = dictacckey.Value
                            Me.rglin = DefaultParamPosting("accountlistvalue")(dictacckey.Key)
                            Me.rglout = "0"
                            strsqll = strsqll + GetSqlInsertData()
                        ElseIf dictacckey.Key.Contains("credit") And Not String.IsNullOrEmpty(dictacckey.Value.ToString) Then
                            Me.mcoadno = dictacckey.Value
                            Me.rglin = "0"
                            Me.rglout = DefaultParamPosting("accountlistvalue")(dictacckey.Key)
                            strsqll = strsqll + GetSqlInsertData()
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
        End Try
        Return strsqll
    End Function
    Public Function GetSqlInsertData() As String
        Dim values As String = ""
        Dim strsqll = ""
        dtcreated = IIf(String.IsNullOrEmpty(dtcreated), Format(Date.Now, "yyyy/MM/dd H:mm:ss"), dtcreated)
        Try
            values = "('" & rgldt & "','" & _
                      mcoadno & "','" & _
                      noref & "','" & _
                      noref2 & "','" & _
                      rglin & "','" & _
                      rglout & "','" & _
                      rgldesc & "','" & _
                      fk_id & "','" & _
                      userid & "','" & _
                      dtcreated & "')"

        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message & vbCrLf & ex.StackTrace, WARNING_STAT)
            Return 0
        End Try
        If values.Length > 1 Then
            'multivalue = multivalue.Substring(0, multivalue.Length - 1)
            strsqll = "INSERT INTO " & TableName & _
                   "(`rgldt`,`mcoadno`,`noref`,`noref2`,`rglin`,`rglout`,`rgldesc`,`fk_id`,`userid`,`dtcreated`) VALUES " & values & ";" & vbCrLf
        End If

        'MsgBox(Me.StringSQL)
        'Return MyBase.InsertData
        Return strsqll
    End Function

    Public Function DeleteByNo(ByVal NoHeader As String) As String
        Return "DELETE FROM " & TableName + " WHERE noref='" & NoHeader & "';" & vbCrLf
    End Function
End Class
