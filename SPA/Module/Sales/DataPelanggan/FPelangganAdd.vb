Public Class FPelangganAdd
    Private Model As New MDataPelanggan

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        'MessageBox.Show(Model.EscapeString(TextBox1.Text))
        'Exit Sub
        If DataIsValid() Then
            Dim res As Integer

            Model.mcusname = Model.EscapeString(txtNama.Text)
            Model.mcusphone1 = Model.EscapeString(txtPhone1.Text)
            Model.mcusphone2 = Model.EscapeString(txtPhone2.Text)
            Model.mcusfax = Model.EscapeString(txtFax.Text)
            Model.mcusemail = Model.EscapeString(txtEmail.Text)
            Model.mcustaxcode = Model.EscapeString(txtNPWP.Text)
            Model.mcusaddr1 = Model.EscapeString(txtAddr1.Text)
            Model.mcusaddr2 = Model.EscapeString(txtAddr2.Text)
            Model.mcusaddr3 = Model.EscapeString(txtAddr3.Text)
            Model.mcusaddr4 = Model.EscapeString(txtAddr4.Text)
            Model.mcusaddr5 = Model.EscapeString(txtAddr5.Text)
            Model.mcusid = Model.EscapeString(txtMcusID.Text)
            If nama.Text <> "" Then
               res = Model.UpdateData()
            Else
                res = Model.InsertData()
            End If
            FDataPelanggan.init()
            Me.Close()
        End If
    End Sub

    Private Function DataIsValid() As Boolean
        DataIsValid = True

        If nama.Text <> "" Then
            If txtNama.Text <> nama.Text Then
                If Model.IfDataExist1(txtNama.Text) Then
                    statmsg.Text = "Nama sudah ada, silahkan masukan Nama yang lain."
                    statmsg.ForeColor = Color.DarkRed
                    txtNama.Focus()
                    DataIsValid = False
                Else
                    statmsg.Text = "Nama Valid"
                    statmsg.ForeColor = Color.Green
                    DataIsValid = True
                End If
            End If
        Else
            If Model.IfDataExist1(txtNama.Text) Then
                statmsg.Text = "Nama sudah ada, silahkan masukan Nama yang lain."
                statmsg.ForeColor = Color.DarkRed
                txtNama.Focus()
                DataIsValid = False
            Else
                statmsg.Text = "Nama Valid"
                statmsg.ForeColor = Color.Green
                DataIsValid = True
            End If
        End If
        If NPWP.Text <> "" Then
            If txtNPWP.Text <> NPWP.Text Then
                If Model.IfDataExist2(txtNPWP.Text) Then
                    statmsg.Text = "NPWP sudah ada, silahkan masukan NPWP yang lain."
                    statmsg.ForeColor = Color.DarkRed
                    txtNPWP.Focus()
                    DataIsValid = False
                Else
                    statmsg.Text = "NPWP Valid"
                    statmsg.ForeColor = Color.Green
                    DataIsValid = True
                End If
            End If
        Else
            If Model.IfDataExist2(txtNPWP.Text) Then
                statmsg.Text = "NPWP sudah ada, silahkan masukan NPWP yang lain."
                statmsg.ForeColor = Color.DarkRed
                txtNPWP.Focus()
                DataIsValid = False
            Else
                statmsg.Text = "NPWP Valid"
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

    Private Sub FPelangganAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNama.Focus()
    End Sub

    Private Sub txtNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtNPWP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNPWP.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub FPelangganAdd_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtNama.Focus()
    End Sub
End Class