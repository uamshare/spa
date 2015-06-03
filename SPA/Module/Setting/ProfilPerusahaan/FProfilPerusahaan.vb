Public Class FProfilPerusahaan
    Private Model As New MProfilPerusahaan

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        'MessageBox.Show(Model.EscapeString(TextBox1.Text))
        'Exit Sub
        If DataIsValid() Then
            Dim res As Integer

            Model.mlctid = Model.EscapeString(txtKode.Text)
            Model.mlclname = Model.EscapeString(txtLokasi.Text)
            Model.mcpfname = Model.EscapeString(txtNama.Text)
            Model.mcpfaddr1 = Model.EscapeString(txtJalan.Text)
            Model.mcpfaddr2 = Model.EscapeString(txtKelurahan.Text)
            Model.mcpfaddr3 = Model.EscapeString(txtKecamatan.Text)
            Model.mcpfaddr4 = Model.EscapeString(txtKota.Text)
            Model.mcpfaddr5 = Model.EscapeString(txtProfinsi.Text)
            Model.mcpfphone1 = Model.EscapeString(txtPhone1.Text)
            Model.mcpfphone2 = Model.EscapeString(txtPhone2.Text)
            Model.mcpfax = Model.EscapeString(txtFax.Text)
            Model.mcptaxcode = Model.EscapeString(txtNPWP.Text)
            Model.mcpfemail = Model.EscapeString(txtEmail.Text)
            If kode.Text <> "" Then
                res = Model.UpdateData()
            Else
                res = Model.InsertData()
            End If
            My.Settings.CabangID = txtKode.Text
            My.Settings.Save()
            'Me.Close()
        End If
    End Sub

    Private Function DataIsValid() As Boolean
        DataIsValid = True

        If kode.Text <> "" Then
            If txtKode.Text <> kode.Text Then
                If Model.IfKeyExist(txtKode.Text) Then
                    statmsg.Text = "Kode sudah ada, silahkan masukan Kode yang lain."
                    statmsg.ForeColor = Color.DarkRed
                    txtKode.Focus()
                    DataIsValid = False
                Else
                    statmsg.Text = "Nama Valid"
                    statmsg.ForeColor = Color.Green
                    DataIsValid = True
                End If
            End If
        Else
            If Model.IfDataExist1(txtKode.Text) Then
                statmsg.Text = "Kode sudah ada, silahkan masukan Kode yang lain."
                statmsg.ForeColor = Color.DarkRed
                txtKode.Focus()
                DataIsValid = False
            Else
                statmsg.Text = "Kode Valid"
                statmsg.ForeColor = Color.Green
                DataIsValid = True
            End If
        End If
        If txtNama.Text <> "" Then
            If txtNama.Text <> nama.Text Then
                If Model.IfDataExist2(txtNama.Text) Then
                    statmsg.Text = "Nama Perusahaan sudah ada, silahkan masukan Nama Perusahaan  yang lain."
                    statmsg.ForeColor = Color.DarkRed
                    txtNPWP.Focus()
                    DataIsValid = False
                Else
                    statmsg.Text = "Nama Perusahaan  Valid"
                    statmsg.ForeColor = Color.Green
                    DataIsValid = True
                End If
            End If
        Else
            If Model.IfDataExist2(txtNama.Text) Then
                statmsg.Text = "Nama Perusahaan sudah ada, silahkan masukan Nama Perusahaan yang lain."
                statmsg.ForeColor = Color.DarkRed
                txtNPWP.Focus()
                DataIsValid = False
            Else
                statmsg.Text = "Nama Perusahaan Valid"
                statmsg.ForeColor = Color.Green
                DataIsValid = True
            End If
        End If

        If txtNama.Text = "" Then
            statmsg.Text = "Nama tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtNama.Focus()
            DataIsValid = False
        End If
        If txtKode.Text = "" Then
            statmsg.Text = "kode tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtKode.Focus()
            DataIsValid = False
        End If

        Return DataIsValid
    End Function

    Private Sub txtPhone1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhone1.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtPhone2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhone2.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtFax_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFax.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Me.Close()
    End Sub

    Private Sub FProfilPerusahaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeData()
        txtKode.Enabled = False
        kode.Text = txtKode.Text
        nama.Text = txtNama.Text
        statmsg.Text = ""
    End Sub
    Private Function InitializeData() As Boolean
        Dim dt As DataTable
        Try
            dt = Model.GetData()

            If dt.Rows.Count > 0 Then
                Dim mlctid As String = dt.Rows.Item(0).Item("mlctid")
                Dim mlclname As String = dt.Rows.Item(0).Item("mlclname")
                Dim mcpfname As String = dt.Rows.Item(0).Item("mcpfname")
                Dim mcpfaddr1 As String = dt.Rows.Item(0).Item("mcpfaddr1")
                Dim mcpfaddr2 As String = dt.Rows.Item(0).Item("mcpfaddr2")
                Dim mcpfaddr3 As String = dt.Rows.Item(0).Item("mcpfaddr3")
                Dim mcpfaddr4 As String = dt.Rows.Item(0).Item("mcpfaddr4")
                Dim mcpfaddr5 As String = dt.Rows.Item(0).Item("mcpfaddr5")
                Dim mcpfphone1 As String = dt.Rows.Item(0).Item("mcpfphone1")
                Dim mcpfphone2 As String = dt.Rows.Item(0).Item("mcpfphone2")
                Dim mcpfax As String = dt.Rows.Item(0).Item("mcpfax")
                Dim mcptaxcode As String = dt.Rows.Item(0).Item("mcptaxcode")
                Dim mcpfemail As String = dt.Rows.Item(0).Item("mcpfemail")

                txtKode.Text = Format(CInt(mlctid), "00")
                txtLokasi.Text = mlclname
                txtNama.Text = mcpfname
                txtJalan.Text = mcpfaddr1
                txtKelurahan.Text = mcpfaddr2
                txtKecamatan.Text = mcpfaddr3
                txtKota.Text = mcpfaddr4
                txtProfinsi.Text = mcpfaddr5
                txtPhone1.Text = mcpfphone1
                txtPhone2.Text = mcpfphone2
                txtFax.Text = mcpfax
                txtNPWP.Text = mcptaxcode
                txtEmail.Text = mcpfemail
            Else
                txtKode.Text = My.Settings.CabangID
            End If
        Catch ex As Exception
            ' tampilkan pesan error
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
End Class