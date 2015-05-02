Public Class FKlasifikasiAdd
    Private Model As New MKlasifikasiCOA
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        'MessageBox.Show(Model.EscapeString(TextBox1.Text))
        'Exit Sub
        If txtGroupName.Text = "" Then
            'MessageBox.Show("User group cannot be empty")
            statmsg.Text = "Group COA tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtGroupName.Focus()
        ElseIf txtKlasifikasiName.Text = "" Then
            'MessageBox.Show("User group cannot be empty")
            statmsg.Text = "Klasifikasi COA tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtKlasifikasiName.Focus()
        Else
            Dim res As Integer

            Model.mcoacid = Model.EscapeString(txtKlasifikasiID.Text)
            Model.mcoaclassification = txtKlasifikasiName.Text
            Model.mcoagid = Model.EscapeString(txtGroupID.Text)
            If txtKlasifikasiID.Text <> "" Then
                res = Model.UpdateData()
                'MyApplication.ShowStatus("Data has been updated")
            Else
                res = Model.InsertData()
                'MyApplication.ShowStatus("Data has been saved")
            End If

            FKlasifikasiCOA.init()
            Me.Close()
        End If
    End Sub

    Private Sub txtGroupName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGroupName.KeyPress
        txtGroupName.ReadOnly = True
        txtGroupName.BackColor = Color.White
    End Sub

    Private Sub txtKlasifikasiName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKlasifikasiName.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub FKlasifikasiAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        statmsg.Text = ""
        txtGroupName.Focus()
    End Sub

    Private Sub btnPrompt_Click(sender As Object, e As EventArgs) Handles btnPrompt.Click
        FGroupCOA.ShowDialog()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Me.Close()
    End Sub
End Class