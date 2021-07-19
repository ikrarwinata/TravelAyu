Imports MySql.Data.MySqlClient

Public Class editJadwal
    Private id, mobil, tujuan As String
    Private mode As String = "Baru"
    Private refAction As Action

    Public Sub TambahBaru(Optional ByVal ref As Action = Nothing)
        refAction = ref
        mode = "Baru"
        Me.Text = "Tambah Jadwal"
        Me.Show()
    End Sub

    Public Sub UbahData(ByVal usr As String, Optional ByVal ref As Action = Nothing)
        id = usr
        refAction = ref
        mode = "Ubah"
        Me.Text = "Ubah Jadwal"
        Dim ds As DataTable = BukaTabel("jadwal", "SELECT * FROM jadwal WHERE id = '" & id & "' LIMIT 1 OFFSET 0")
        With ds.Rows(0)
            mobil = .Item("mobil").ToString()
            tujuan = .Item("id_tujuan").ToString()
            ComboBox1.SelectedItem = .Item("hari").ToString()
            NumericUpDown1.Value = .Item("jam").ToString().Split(":")(0)
            NumericUpDown2.Value = .Item("jam").ToString().Split(":")(1)
        End With
        Me.Show()
    End Sub

    Private Sub editSupir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgv1.DataSource = BukaTabel("tarif", "SELECT id as ID, tujuan AS Tujuan, tarif AS Tarif FROM tarif")
        dgv2.DataSource = BukaTabel("mobil", "SELECT a.nopol AS 'Nomor Polisi', CONCAT(a.nama_mobil, ', ', a.warna) AS Mobil, (a.kursi_depan + a.kursi_2 + a.kursi_3 + a.kursi_4) AS Kapasitas, b.nama AS Supir FROM mobil a INNER JOIN supir b ON a.NIK_supir=b.NIK")
        If mode = "Ubah" Then
            dgv1.ClearSelection()
            dgv2.ClearSelection()
            For Each ro As DataGridViewRow In dgv1.Rows
                If ro.Cells("ID").Value = tujuan Then
                    ro.Selected = True
                    dgv1.CurrentCell = ro.Cells(0)
                    Exit For
                End If
            Next
            For Each ro As DataGridViewRow In dgv2.Rows
                If ro.Cells("Nomor Polisi").Value = mobil Then
                    ro.Selected = True
                    dgv2.CurrentCell = ro.Cells(0)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Function MasihKosong() As Boolean
        Try
            If dgv1.SelectedRows(0).Cells(1).Value = "" Or dgv2.SelectedRows(0).Cells(1).Value = "" Then Return True
        Catch ex As Exception
            Return True
        End Try
        For Each o As Object In TableLayoutPanel1.Controls
            If TypeOf (o) Is TextBox Then
                If String.IsNullOrEmpty(CType(o, TextBox).Text) Then
                    CType(o, TextBox).Focus()
                    Return True
                    Exit For
                End If
            End If
        Next
        Return False
    End Function

    Private ReadOnly Property Jam As String
        Get
            Return New String("0", 2 - NumericUpDown1.Value.ToString().Length) & NumericUpDown1.Value & ":" & New String("0", 2 - NumericUpDown2.Value.ToString().Length) & NumericUpDown2.Value
        End Get
    End Property

    Private Function IndexTanggal() As Integer
        Return (ComboBox1.SelectedIndex + 1).ToString() & New String("0", 2 - NumericUpDown1.Value.ToString().Length) & NumericUpDown1.Value.ToString()
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MasihKosong() Then
            MessageBox.Show("Data tidak boleh kosong")
            Exit Sub
        End If

        If mode = "Baru" Then
            If DataSudahAda("jadwal", "hari='" & ComboBox1.SelectedItem & "' AND jam='" & Jam & "' AND mobil='" & dgv2.SelectedRows(0).Cells("Nomor Polisi").Value & "'") Then
                MessageBox.Show("Mobil ini sudah ada jadwal pada jam yang sama")
                Exit Sub
            End If

            Perintah = New MySqlCommand("INSERT INTO jadwal (hari, jam, id_tujuan, mobil, indextanggal) VALUES ('" & ComboBox1.SelectedItem & "', '" & Jam & "', '" & dgv1.SelectedRows(0).Cells("ID").Value & "', '" & dgv2.SelectedRows(0).Cells("Nomor Polisi").Value & "', '" & IndexTanggal() & "')", Koneksi)
            Perintah.ExecuteNonQuery()
        Else
            If Not dgv2.SelectedRows(0).Cells("Nomor Polisi").Value = mobil Then
                If DataSudahAda("jadwal", "hari='" & ComboBox1.SelectedItem & "' AND jam='" & Jam & "' AND mobil='" & dgv2.SelectedRows(0).Cells("Nomor Polisi").Value & "'") Then
                    MessageBox.Show("Mobil ini sudah ada jadwal pada jam yang sama")
                    Exit Sub
                End If
            End If

            Perintah = New MySqlCommand("UPDATE jadwal SET hari='" & ComboBox1.SelectedItem & "', jam='" & Jam & "', id_tujuan='" & dgv1.SelectedRows(0).Cells("ID").Value & "', mobil='" & dgv2.SelectedRows(0).Cells("Nomor Polisi").Value & "', indextanggal='" & IndexTanggal() & "' WHERE id = " & id, Koneksi)
            Perintah.ExecuteNonQuery()
        End If
        Try
            If Not refAction = Nothing Then
                refAction()
            End If
        Catch ex As Exception

        End Try
        Me.Close()
    End Sub

    Private Sub NumericUpDown1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericUpDown1.Click, NumericUpDown2.Click
        Dim t As NumericUpDown = sender
        With t
            If .Value > .Maximum Then
                .Value = .Minimum
            End If
        End With
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged, NumericUpDown2.Click
        Dim t As NumericUpDown = sender
        With t
            If .Value > .Maximum Then
                .Value = .Minimum
            End If
        End With
    End Sub
End Class