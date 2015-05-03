
Imports System.IO
Imports System.Net
Imports System.Text
Class Web_update
    Dim version As String
    Public Shared Downuri As String

    Public Shared Sub Main()
        Dim URI As String
        'REMEMBER TO EDIT FILEVERSION IN ASSEMBLY INFORMATION
        '
        '
        'Edit URI to your version.html-file. 
        URI = "http://localhost:82/updatespa/SMTE_version.html"
        'Edit URI to your Program.zip-file. 
        Downuri = "http://localhost:82/updatespa/spa.zip"

        Try
            Dim wr As HttpWebRequest = CType(WebRequest.Create(URI.ToString), HttpWebRequest)
            Dim ws As HttpWebResponse = CType(wr.GetResponse(), HttpWebResponse)
            Dim str As Stream = ws.GetResponseStream()
            Dim inBuf(100000) As Byte
            Dim bytesToRead As Integer = CInt(inBuf.Length)
            Dim bytesRead As Integer = 0
            While bytesToRead > 0
                Dim n As Integer = str.Read(inBuf, bytesRead, bytesToRead)
                If n = 0 Then
                    Exit While
                End If
                bytesRead += n
                bytesToRead -= n
            End While
            Dim fstr As New FileStream("version.txt", FileMode.OpenOrCreate, FileAccess.Write)
            fstr.Write(inBuf, 0, bytesRead)
            str.Close()
            fstr.Close()
            Dim sr As StreamReader = New System.IO.StreamReader("version.txt")
            Dim version As Integer = CInt(sr.ReadToEnd.Replace(".", "").Substring(0, 4))
            sr.Close()
            If version > CInt(Application.ProductVersion.Replace(".", "")) Then
                MessageBox.Show("Versi Aplikasi : " & CInt(Application.ProductVersion.Replace(".", "")).ToString & Environment.NewLine _
                           & "Version Terbaru : " & version.ToString, "Update", MessageBoxButtons.OK)

                Dialog1.ShowDialog()
            Else
                MessageBox.Show("Belum tersedia Versi terbaru" & Environment.NewLine & "Versi Aplikasi : " & _
                                CInt(Application.ProductVersion.Replace(".", "")).ToString _
                                & Environment.NewLine & "Version Terbaru : " & _
                                version.ToString, "Penbaruan Aplikasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox("Update Version Error" & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
            ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace, "Update Version Error")
        End Try
        
    End Sub 'Main
End Class 'Web_update