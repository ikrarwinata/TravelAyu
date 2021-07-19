Imports MySql.Data.MySqlClient

Public Class editMobil
    Private refAction As Action
    Private stateReady As Boolean = False
    Private mode As String = "Baru"
    Private id As String

    Public Sub TambahBaru(ByVal ref As Action)
        refAction = ref
        mode = "Baru"
        Me.Text = "Tambah Data Mobil"
        Me.Show()
    End Sub

    Public Sub UbahData(ByVal nopol As String, ByVal ref As Action)
        id = nopol
        refAction = ref
        mode = "Ubah"
        Me.Text = "Ubah Data Mobil"
        BukaSupir()
        Dim dt As DataTable = BukaTabel("mobil", "SELECT mobil.*, supir.nama FROM mobil LEFT OUTER JOIN supir ON mobil.NIK_supir=supir.NIK WHERE mobil.nopol = '" & id & "'")
        With dt.Rows(0)
            TextBox2.Text = .Item("nopol")
            TextBox3.Text = .Item("nama_mobil")
            TextBox4.Text = .Item("warna")
            ComboBox1.SelectedItem = .Item("NIK_supir")
            Label5.Text = .Item("nama")
            NumericUpDown1.Value = .Item("kursi_depan")
            SetSeat(NumericUpDown1.Value, TableLayoutPanel3)

            NumericUpDown2.Value = .Item("kursi_2")
            SetSeat(NumericUpDown2.Value, TableLayoutPanel4)

            NumericUpDown3.Value = .Item("kursi_3")
            SetSeat(NumericUpDown3.Value, TableLayoutPanel5)

            NumericUpDown4.Value = .Item("kursi_4")
            SetSeat(NumericUpDown4.Value, TableLayoutPanel6)
        End With

        Me.Show()
    End Sub

    Private Sub BukaSupir()
        Dim dt As DataTable = BukaTabel("supir")
        ComboBox1.Items.Clear()
        For Each ro As DataRow In dt.Rows
            ComboBox1.Items.Add(ro.Item("NIK"))
        Next
    End Sub

    Private Sub editMobil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If ComboBox1.Items.Count = 0 Then BukaSupir()
        stateReady = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub SetSeat(ByVal count As Integer, ByVal layout As TableLayoutPanel)
        If count = 0 Then
            layout.Visible = False
            Exit Sub
        Else
            layout.Visible = True
        End If

        layout.Controls.Clear()

        layout.ColumnCount = count
        layout.RowCount = 1

        For i As Integer = 0 To count - 1
            layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
            Dim img As New PictureBox
            img.Image = My.Resources.seat
            img.SizeMode = PictureBoxSizeMode.StretchImage
            img.Dock = DockStyle.Fill
            layout.Controls.Add(img, i, 0)
        Next
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        If Not stateReady Then Exit Sub
        SetSeat(NumericUpDown1.Value, TableLayoutPanel3)
    End Sub

    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown2.ValueChanged
        If Not stateReady Then Exit Sub
        SetSeat(NumericUpDown2.Value, TableLayoutPanel4)
    End Sub

    Private Sub NumericUpDown3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown3.ValueChanged
        If Not stateReady Then Exit Sub
        SetSeat(NumericUpDown3.Value, TableLayoutPanel5)
    End Sub

    Private Sub NumericUpDown4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown4.ValueChanged
        If Not stateReady Then Exit Sub
        SetSeat(NumericUpDown4.Value, TableLayoutPanel6)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If Not stateReady Then Exit Sub
        Try
            If DataSudahAda("supir", "NIK", ComboBox1.SelectedItem) Then
                Perintah = New MySqlCommand("SELECT nama FROM supir WHERE NIK = '" & ComboBox1.SelectedItem & "'", Koneksi)
                Label5.Text = Perintah.ExecuteScalar()
            Else
                Label5.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function MasihKosong() As Boolean
        For Each o As Object In TableLayoutPanel1.Controls
            If TypeOf (o) Is TextBox Then
                If String.IsNullOrEmpty(CType(o, TextBox).Text) Then
                    CType(o, TextBox).Focus()
                    Return True
                    Exit For
                End If
            End If
        Next
        If String.IsNullOrEmpty(ComboBox1.SelectedItem) Then Return True
        Return False
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MasihKosong() Then
            MessageBox.Show("Data tidak boleh kosong")
            Exit Sub
        End If

        If mode = "Baru" Then
            If DataSudahAda("mobil", "nopol", TextBox2.Text) Then
                MessageBox.Show("Nomor Polisi ini sudah digunakan mobil lain")
                TextBox2.Focus()
                Exit Sub
            End If

            Perintah = New MySqlCommand("INSERT INTO mobil (nopol, nama_mobil, warna, NIK_supir, kursi_depan, kursi_2, kursi_3, kursi_4) VALUES ('" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & ComboBox1.SelectedItem & "', " & NumericUpDown1.Value & ", " & NumericUpDown2.Value & ", " & NumericUpDown3.Value & ", " & NumericUpDown4.Value & ")", Koneksi)
            Perintah.ExecuteNonQuery()
        Else
            If Not TextBox2.Text = id Then
                If DataSudahAda("mobil", "nopol", TextBox2.Text) Then
                    MessageBox.Show("Nomor Polisi ini sudah digunakan mobil lain")
                    TextBox2.Focus()
                    Exit Sub
                End If
            End If

            Perintah = New MySqlCommand("UPDATE mobil SET nopol='" & TextBox2.Text & "', nama_mobil='" & TextBox3.Text & "', warna='" & TextBox4.Text & "', NIK_supir='" & ComboBox1.SelectedItem & "', kursi_depan=" & NumericUpDown1.Value & ", kursi_2=" & NumericUpDown2.Value & ", kursi_3=" & NumericUpDown3.Value & ", kursi_4=" & NumericUpDown4.Value & " WHERE nopol='" & id & "'", Koneksi)
            Perintah.ExecuteNonQuery()
        End If
        Try
            If Not refAction = Nothing Then refAction()
        Catch ex As Exception

        End Try
        Me.Close()
    End Sub
End Class