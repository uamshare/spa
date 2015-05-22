Public Class FAkunPostingAdd
    Private Model As New MAkunPosting
    Private Model2 As New MCOADetail
    Dim dt As DataTable = Model2.GetData(-1)

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If DataIsValid() Then
            Dim res As Integer

            Model.mapoid = Model.EscapeString(txtKode.Text)
            Model.maponame = Model.EscapeString(txtNama.Text)
            Model.acc_debit = Model.EscapeString(cmbDebit1.Text)
            Model.acc_credit = Model.EscapeString(cmbKredit1.Text)
            Model.acc_debit2 = Model.EscapeString(cmbDebit2.Text)
            Model.acc_credit2 = Model.EscapeString(cmbKredit2.Text)
            Model.acc_debit3 = Model.EscapeString(cmbDebit3.Text)
            Model.acc_credit3 = Model.EscapeString(cmbKredit3.Text)
            Model.acc_debit4 = Model.EscapeString(cmbDebit4.Text)
            Model.acc_credit4 = Model.EscapeString(cmbKredit4.Text)
            If txtMapoID.Text <> "" Then
                res = Model.UpdateData()
            Else
                res = Model.InsertData()
            End If
            FAkunPosting.init()
            Me.Close()
        End If
    End Sub
    Private Function DataIsValid() As Boolean
        DataIsValid = True
        If txtMapoID.Text <> "" Then
            If txtKode.Text <> txtMapoID.Text Then
                If Model.IfKeyExist(txtKode.Text) Then
                    statmsg.Text = "No Akun sudah ada, silahkan masukan No Akun yang lain."
                    statmsg.ForeColor = Color.DarkRed
                    txtKode.Focus()
                    DataIsValid = False
                Else
                    statmsg.Text = "No Akum Valid"
                    statmsg.ForeColor = Color.Green
                    DataIsValid = True
                End If
            End If
        Else
            If Model.IfKeyExist(txtKode.Text) Then
                statmsg.Text = "No Akun sudah ada, silahkan masukan No Akun yang lain."
                statmsg.ForeColor = Color.DarkRed
                txtKode.Focus()
                DataIsValid = False
            Else
                statmsg.Text = "No Akun Valid"
                statmsg.ForeColor = Color.Green
                DataIsValid = True
            End If
        End If
        If txtKode.Text = "" Then
            statmsg.Text = "No Akun tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtKode.Focus()
            DataIsValid = False
        ElseIf txtNama.Text = "" Then
            statmsg.Text = "No Akun tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtNama.Focus()
            DataIsValid = False
        End If

        Return DataIsValid
    End Function

    Private Sub txtNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtKode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKode.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Me.Close()
    End Sub
    Public Sub ClearCombobox(Optional eachcontrol As Control = Nothing)
        For Each ctrl As Control In GroupBox1.Controls
            If (ctrl.GetType() Is GetType(ComboBox)) Then
                Dim cmb As ComboBox = CType(ctrl, ComboBox)
                cmb.Text = ""
            End If
        Next
    End Sub
    Private Sub InitializeCmbDebit(ByRef cmb As ComboBox)
        Try
            'Isi Combo Debit 1
            'cmb.DataSource = dt
            'cmb.ValueMember = "mcoadno"
            'cmb.SelectedIndex = -1
            'MessageBox.Show(dt.Rows(0).Item("mcoadno").ToString)

            For Each rowdt As DataRow In dt.Rows
                cmb.Items.Add(rowdt.Item("mcoadno"))
            Next
            cmb.SelectedIndex = -1
        Catch ex As Exception
            MyApplication.ShowStatus(ex.Message, WARNING_STAT)
        End Try
    End Sub
    'Private Sub InitializeCmbDebit2()
    '    Dim dt As DataTable
    '    Try
    '        dt = Model2.GetData()
    '        'Isi Combo Debit 2
    '        cmbDebit2.DataSource = dt
    '        cmbDebit2.ValueMember = "mcoadno"
    '        cmbDebit2.SelectedIndex = -1
    '    Catch ex As Exception
    '        ' tampilkan pesan error
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    'Private Sub InitializeCmbDebit3()
    '    Dim dt As DataTable
    '    Try
    '        dt = Model2.GetData()
    '        'Isi Combo Debit 2
    '        cmbDebit3.DataSource = dt
    '        cmbDebit3.ValueMember = "mcoadno"
    '        cmbDebit3.SelectedIndex = -1
    '    Catch ex As Exception
    '        ' tampilkan pesan error
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    'Private Sub InitializeCmbDebit4()
    '    Dim dt As DataTable
    '    Try
    '        dt = Model2.GetData()
    '        'Isi Combo Debit 2
    '        cmbDebit4.DataSource = dt
    '        cmbDebit4.ValueMember = "mcoadno"
    '        cmbDebit4.SelectedIndex = -1
    '    Catch ex As Exception
    '        ' tampilkan pesan error
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    'Private Sub InitializeCmbKredit1()
    '    Dim dt As DataTable
    '    Try
    '        dt = Model2.GetData()
    '        'Isi Combo Debit 2
    '        cmbKredit1.DataSource = dt
    '        cmbKredit1.ValueMember = "mcoadno"
    '        cmbKredit1.SelectedIndex = -1
    '    Catch ex As Exception
    '        ' tampilkan pesan error
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    'Private Sub InitializeCmbKredit4()
    '    Dim dt As DataTable
    '    Try
    '        dt = Model2.GetData()
    '        'Isi Combo Debit 2
    '        cmbKredit4.DataSource = dt
    '        cmbKredit4.ValueMember = "mcoadno"
    '        cmbKredit4.SelectedIndex = -1
    '    Catch ex As Exception
    '        ' tampilkan pesan error
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    'Private Sub InitializeCmbKredit2()
    '    Dim dt As DataTable
    '    Try
    '        dt = Model2.GetData()
    '        'Isi Combo Debit 2
    '        cmbKredit2.DataSource = dt
    '        cmbKredit2.ValueMember = "mcoadno"
    '        cmbKredit2.SelectedIndex = -1
    '    Catch ex As Exception
    '        ' tampilkan pesan error
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    'Private Sub InitializeCmbKredit3()
    '    Dim dt As DataTable
    '    Try
    '        dt = Model2.GetData()
    '        'Isi Combo Debit 2
    '        cmbKredit3.DataSource = dt
    '        cmbKredit3.ValueMember = "mcoadno"
    '        cmbKredit3.SelectedIndex = -1
    '    Catch ex As Exception
    '        ' tampilkan pesan error
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    Private Sub cmbDebit1_Click(sender As Object, e As EventArgs) Handles cmbDebit1.Click
        InitializeCmbDebit(cmbDebit1)
    End Sub

    Private Sub cmbKredit1_Click(sender As Object, e As EventArgs) Handles cmbKredit1.Click
        InitializeCmbDebit(cmbKredit1)
    End Sub

    Private Sub cmbKredit2_Click(sender As Object, e As EventArgs) Handles cmbKredit2.Click
        InitializeCmbDebit(cmbKredit2)
    End Sub
    Private Sub cmbDebit2_Click(sender As Object, e As EventArgs) Handles cmbDebit2.Click
        InitializeCmbDebit(cmbDebit2)
    End Sub
    Private Sub cmbDebit3_Click(sender As Object, e As EventArgs) Handles cmbDebit3.Click
        InitializeCmbDebit(cmbDebit3)
    End Sub
    Private Sub cmbKredit3_Click(sender As Object, e As EventArgs) Handles cmbKredit3.Click
        InitializeCmbDebit(cmbKredit3)
    End Sub

    Private Sub cmbKredit4_Click(sender As Object, e As EventArgs) Handles cmbKredit4.Click
        InitializeCmbDebit(cmbKredit4)
    End Sub

    Private Sub cmbDebit4_Click(sender As Object, e As EventArgs) Handles cmbDebit4.Click
        InitializeCmbDebit(cmbDebit4)
    End Sub
    Private Sub FAkunPostingAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'InitializeCmbDebit1()
        For Each ctrl As Control In GroupBox1.Controls
            If (ctrl.GetType() Is GetType(ComboBox)) Then
                Dim cmb As ComboBox = CType(ctrl, ComboBox)
                cmb.AutoCompleteMode = AutoCompleteMode.Suggest
                cmb.AutoCompleteSource = AutoCompleteSource.ListItems
            End If
        Next
    End Sub

    Private Sub cmbDebit1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbDebit1.KeyPress
        e.Handled = ValidNumber(e)
    End Sub
    Private Sub cmbKredit1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbKredit1.KeyPress
        e.Handled = ValidNumber(e)
    End Sub
    Private Sub cmbDebit2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbDebit2.KeyPress
        e.Handled = ValidNumber(e)
    End Sub
    Private Sub cmbKredit2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbKredit2.KeyPress
        e.Handled = ValidNumber(e)
    End Sub
    Private Sub cmbDebit3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbDebit3.KeyPress
        e.Handled = ValidNumber(e)
    End Sub
    Private Sub cmbKredit3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbKredit3.KeyPress
        e.Handled = ValidNumber(e)
    End Sub
    Private Sub cmbDebit4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbDebit4.KeyPress
        e.Handled = ValidNumber(e)
    End Sub
    Private Sub cmbKredit4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbKredit4.KeyPress
        e.Handled = ValidNumber(e)
    End Sub
End Class