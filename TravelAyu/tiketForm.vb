Imports MySql.Data.MySqlClient

Public Class tiketForm
    Private tarif, penumpang As Long

    Private Property JK As String
        Get
            If RadioButton1.Checked Then
                Return "Pria"
            Else
                Return "Wanita"
            End If
        End Get
        Set(ByVal value As String)
            If value = "Pria" Then
                RadioButton1.Checked = True
                RadioButton2.Checked = False
            Else
                RadioButton1.Checked = False
                RadioButton2.Checked = True
            End If
        End Set
    End Property

    Private Sub BukaDatabase()
        Dim q As String = "SELECT * FROM tiket_view WHERE Hari='" & Hari() & "'"
        dgv1.DataSource = BukaTabel("tiket_view", q)
    End Sub

    Private Sub BukaPenumpang()
        ComboBox1.Items.Clear()
        Dim dt As DataTable = BukaTabel("penumpang", "SELECT NIK FROM penumpang")
        For Each ro As DataRow In dt.Rows
            ComboBox1.Items.Add(ro.Item("NIK"))
        Next
    End Sub

    Private Sub SetSeat(ByVal count As Integer, ByVal initial As String, ByVal layout As TableLayoutPanel)
        layout.Controls.Clear()
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
            Dim img As New imgButton(i, initial & i)
            layout.Controls.Add(img, i, 0)
            AddHandler img.Click, AddressOf img_OnCLick
        Next
    End Sub

    Private Sub img_OnCLick(ByVal sender As Object, ByVal e As EventArgs)
        If CType(sender, imgButton).Checked Then
            penumpang += 1
        Else
            penumpang -= 1
        End If

        Label20.Text = "Rp." & FormatNumber(tarif * penumpang, 0)
    End Sub

    Private Sub tiketForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaDatabase()
        BukaPenumpang()
        DateTimePicker1.Value = New Date(1997, 1, 1)
        penumpang = 0
    End Sub

    Private Sub dgv1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv1.CellMouseDoubleClick
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            Try
                penumpang = 0
                Dim dtJadwal As DataTable = BukaTabel("jadwal", "SELECT * FROM jadwal a INNER JOIN tarif b ON a.id_tujuan=b.id INNER JOIN mobil c ON a.mobil=c.nopol INNER JOIN supir d ON c.NIK_supir=d.NIK WHERE a.id = " & dgv1.SelectedRows(0).Cells("ID").Value & " LIMIT 1 OFFSET 0")
                With dtJadwal.Rows(0)
                    Label24.Text = "0"
                    Label8.Text = .Item("nopol")
                    Label9.Text = (.Item("kursi_depan") + .Item("kursi_2") + .Item("kursi_3") + .Item("kursi_4"))
                    Label11.Text = .Item("nama_mobil") & ", " & .Item("warna")
                    Label13.Text = .Item("NIK")
                    Label15.Text = .Item("nama")
                    Label17.Text = .Item("tujuan")
                    SetSeat(.Item("kursi_depan"), "R0", TableLayoutPanel7)
                    SetSeat(.Item("kursi_2"), "R1", TableLayoutPanel4)
                    SetSeat(.Item("kursi_3"), "R2", TableLayoutPanel5)
                    SetSeat(.Item("kursi_4"), "R3", TableLayoutPanel6)
                    Label20.Text = "Rp." & FormatNumber(.Item("tarif"), 0)
                    tarif = .Item("tarif")
                End With
                Perintah = New MySqlCommand("SELECT COUNT(seats) FROM kursi_tiket INNER JOIN tiket ON kursi_tiket.id_tiket=tiket.id WHERE tiket.tanggal='" & Date.Now.ToShortDateString & "' AND tiket.id_jadwal=" & dgv1.SelectedRows(0).Cells("ID").Value, Koneksi)
                Label24.Text = Perintah.ExecuteScalar()

                Dim ndt As DataTable = BukaTabel("kursi_tiket", "SELECT seats FROM kursi_tiket INNER JOIN tiket ON kursi_tiket.id_tiket=tiket.id WHERE tiket.tanggal='" & Date.Now.ToShortDateString & "' AND tiket.id_jadwal=" & dgv1.SelectedRows(0).Cells("ID").Value)
                With ndt
                    Dim l, r, sr As String
                    For Each ro As DataRow In .Rows
                        l = ro.Item("seats").ToString().Split(";")(0)
                        r = ro.Item("seats").ToString().Split(";")(1)
                        sr = r.Substring(1)
                        Dim tbl As TableLayoutPanel

                        Select Case l
                            Case "R0"
                                tbl = TableLayoutPanel7
                            Case "R1"
                                tbl = TableLayoutPanel4
                            Case "R2"
                                tbl = TableLayoutPanel5
                            Case "R3"
                                tbl = TableLayoutPanel6
                            Case Else
                                tbl = TableLayoutPanel7
                        End Select
                        CType(tbl.Controls.Find(l & sr, False)(0), imgButton).Enabled = False
                    Next
                End With
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If sender.Text = "Cari" Then
            Dim k As String = ToolStripTextBox1.Text
            Dim searchq As String = " AND (a.id LIKE '%" & k & "%' OR a.hari LIKE '%" & k & "%' OR a.jam LIKE '%" & k & "%' OR b.tujuan LIKE '%" & k & "%' OR c.nama_mobil LIKE '%" & k & "%' OR c.nopol LIKE '%" & k & "%' OR d.NIK LIKE '%" & k & "%' OR d.nama LIKE '%" & k & "%')"
            dgv1.DataSource = BukaTabel("tiket_view", "select `a`.`id` AS `ID`,`a`.`hari` AS `Hari`,`a`.`jam` AS `Jam`,`b`.`tujuan` AS `Tujuan`,concat(`c`.`nama_mobil`,', ',`c`.`warna`) AS `Mobil`,`c`.`nopol` AS `Nomor Polisi`,(((`c`.`kursi_depan` + `c`.`kursi_2`) + `c`.`kursi_3`) + `c`.`kursi_4`) AS `Kapasitas`,`d`.`NIK` AS `NIK Supir`,`d`.`nama` AS `Supir` from (((`travel`.`jadwal` `a` join `travel`.`tarif` `b` on((`a`.`id_tujuan` = `b`.`id`))) join `travel`.`mobil` `c` on((`a`.`mobil` = `c`.`nopol`))) join `travel`.`supir` `d` on((`c`.`NIK_supir` = `d`.`NIK`))) WHERE a.hari = '" & Hari() & "'" & searchq & " order by `a`.`indextanggal` ASC")
            sender.Text = "Reset"
        Else
            BukaDatabase()
            sender.Text = "Cari"
        End If
    End Sub

    Private Function MasihKosong() As Boolean
        For Each o As Object In GroupBox5.Controls
            If TypeOf (o) Is TextBox Then
                If String.IsNullOrEmpty(CType(o, TextBox).Text) Then
                    Return True
                End If
            End If
        Next
        For Each o As Object In GroupBox9.Controls
            If TypeOf (o) Is TextBox Then
                If String.IsNullOrEmpty(CType(o, TextBox).Text) Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Private Function SimpanTransaksi() As Boolean
        If MasihKosong() Then
            MessageBox.Show("Data masih kosong")
            Return False
        End If
        Try
            Dim f As Long = NumericUpDown1.Value - (tarif * penumpang)
        Catch ex As Exception
        End Try

        Dim id As Integer
        Perintah = New MySqlCommand("SELECT MAX(id) FROM tiket", Koneksi)
        Try
            id = Perintah.ExecuteScalar()
        Catch ex As Exception
            id = 0
        End Try
        id += 1

        Dim kosong As Boolean = True
        Perintah = New MySqlCommand("DELETE FROM kursi_tiket WHERE id_tiket=" & id, Koneksi)
        Perintah.ExecuteNonQuery()
        For Each b As imgButton In TableLayoutPanel7.Controls
            If Not b.Enabled Then Continue For
            If b.Checked Then
                Perintah = New MySqlCommand("INSERT INTO kursi_tiket (id_tiket, seats) VALUES ('" & id & "', 'R0;C" & b.ColumnID & "')", Koneksi)
                Perintah.ExecuteNonQuery()
                kosong = False
            End If
        Next
        For Each b As imgButton In TableLayoutPanel4.Controls
            If Not b.Enabled Then Continue For
            If b.Checked Then
                Perintah = New MySqlCommand("INSERT INTO kursi_tiket (id_tiket, seats) VALUES ('" & id & "', 'R1;C" & b.ColumnID & "')", Koneksi)
                Perintah.ExecuteNonQuery()
                kosong = False
            End If
        Next
        For Each b As imgButton In TableLayoutPanel5.Controls
            If Not b.Enabled Then Continue For
            If b.Checked Then
                Perintah = New MySqlCommand("INSERT INTO kursi_tiket (id_tiket, seats) VALUES ('" & id & "', 'R2;C" & b.ColumnID & "')", Koneksi)
                Perintah.ExecuteNonQuery()
                kosong = False
            End If
        Next
        For Each b As imgButton In TableLayoutPanel6.Controls
            If Not b.Enabled Then Continue For
            If b.Checked Then
                Perintah = New MySqlCommand("INSERT INTO kursi_tiket (id_tiket, seats) VALUES ('" & id & "', 'R3;C" & b.ColumnID & "')", Koneksi)
                Perintah.ExecuteNonQuery()
                kosong = False
            End If
        Next

        If kosong Then
            MessageBox.Show("Silahkan klik kursi pada gambar mobil untuk memilih tempat duduk")
            Return False
        End If

        Dim nik As String = ComboBox1.Text
        If Not DataSudahAda("penumpang", "NIK", nik) Then
            Dim q As String = "INSERT INTO penumpang (NIK, nama, tempat_lahir, tanggal_lahir, jenis_kelamin, hp) VALUES ('" & nik & "', '" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & DateTimePicker1.Value.ToShortDateString & "', '" & JK & "', '" & TextBox4.Text & "')"
            Perintah = New MySqlCommand(q, Koneksi)
            Perintah.ExecuteNonQuery()
        End If

        Perintah = New MySqlCommand("INSERT INTO tiket (id, penumpang, id_jadwal, tanggal, timestamps, total, bayar) VALUES (" & id & ", '" & nik & "', '" & dgv1.SelectedRows(0).Cells("ID").Value & "', '" & Date.Now.ToShortDateString & "', '" & TimeToString(Now) & "', " & (tarif) & ", " & NumericUpDown1.Value & ")", Koneksi)
        Perintah.ExecuteNonQuery()
        Return True
    End Function

    Private Sub Bersihkan()
        penumpang = 0
        tarif = 0
        Label8.Text = ""
        Label24.Text = ""
        Label9.Text = ""
        Label11.Text = ""
        Label13.Text = ""
        Label15.Text = ""
        Label17.Text = ""
        SetSeat(0, "R0", TableLayoutPanel7)
        SetSeat(0, "R1", TableLayoutPanel4)
        SetSeat(0, "R2", TableLayoutPanel5)
        SetSeat(0, "R3", TableLayoutPanel6)
        ComboBox1.SelectedItem = ""
        ComboBox1.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""
        Label21.Text = "Rp.0"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Bersihkan()
    End Sub

    Private Sub NumericUpDown1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NumericUpDown1.KeyUp
        If penumpang <= 0 Then
            Label21.Text = "Rp.0"
            Exit Sub
        End If
        Try
            Dim f As Long = NumericUpDown1.Value - (tarif * penumpang)
            If f >= 0 Then
                Label21.Text = "Rp." & FormatNumber(f, 0)
                Label5.Text = "Rp.0"
            Else
                Label5.Text = "Rp." & FormatNumber((tarif * penumpang) - NumericUpDown1.Value, 0)
            End If
        Catch ex As Exception
            Label21.Text = "Rp.0"
            Label5.Text = "Rp.0"
        End Try
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        If penumpang <= 0 Then
            Label21.Text = "Rp.0"
            Exit Sub
        End If
        Try
            Dim f As Long = NumericUpDown1.Value - (tarif * penumpang)
            If f >= 0 Then
                Label21.Text = "Rp." & FormatNumber(f, 0)
                Label5.Text = "Rp.0"
            Else
                Label5.Text = "Rp." & FormatNumber((tarif * penumpang) - NumericUpDown1.Value, 0)
            End If
        Catch ex As Exception
            Label21.Text = "Rp.0"
            Label5.Text = "Rp.0"
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Dim ds As DataTable = BukaTabel("penumpang", "SELECT * FROM penumpang WHERE NIK ='" & ComboBox1.SelectedItem & "' LIMIT 1 OFFSET 0")
            With ds.Rows(0)
                TextBox1.Text = .Item("nama")
                TextBox2.Text = .Item("tempat_lahir")
                Dim d, m, y As Integer
                d = .Item("tanggal_lahir").ToString().Split("/")(0)
                m = .Item("tanggal_lahir").ToString().Split("/")(1)
                y = .Item("tanggal_lahir").ToString().Split("/")(2)
                DateTimePicker1.Value = New Date(y, m, d)
                JK = .Item("jenis_kelamin")
                TextBox4.Text = .Item("hp")
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Not SimpanTransaksi() Then Exit Sub
        MsgBox("Transaksi Berhasil Disimpan")
        Bersihkan()
    End Sub
End Class