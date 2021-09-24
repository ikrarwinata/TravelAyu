Imports MySql.Data.MySqlClient

Public Class dataTiketForm

    Public Sub BukaDatabase()
        dgv1.DataSource = BukaTabel("penjualan_tiket_view", "SELECT penjualan_tiket_view.id_tiket, penjualan_tiket_view.tanggal,penjualan_tiket_view.Hari, penjualan_tiket_view.Tujuan, penjualan_tiket_view.Mobil,penjualan_tiket_view.NomorPolisi,penjualan_tiket_view.Kapasitas,penjualan_tiket_view.`NIK Supir`,penjualan_tiket_view.Supir,penjualan_tiket_view.TotalPenumpang,penjualan_tiket_view.Total, tiket.bayar AS TerBayar, penjualan_tiket_view.Status FROM penjualan_tiket_view INNER JOIN tiket ON penjualan_tiket_view.id_tiket = tiket.id WHERE penjualan_tiket_view.Status <> 'DIBATALKAN'")
    End Sub

    Private Sub dataTiketForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaDatabase()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try
            If MessageBox.Show("Anda yakin ingin membatalkan " & dgv1.SelectedRows.Count & " data tiket ?", "Konfirmasi hapus", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                For Each ro As DataGridViewRow In dgv1.SelectedRows
                    Perintah = New MySqlCommand("UPDATE tiket SET dibatalkan = 1 WHERE id = '" & ro.Cells("id_tiket").Value & "'", Koneksi)
                    Perintah.ExecuteNonQuery()
                    ''Perintah = New MySqlCommand("DELETE FROM kursi_tiket WHERE id_tiket = '" & ro.Cells("id_tiket").Value & "'", Koneksi)
                    ''Perintah.ExecuteNonQuery()
                Next
            End If
            BukaDatabase()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If sender.Text = "Cari" Then
            Dim k As String = ToolStripTextBox1.Text
            Dim searchq As String = " WHERE (penjualan_tiket_view.id_tiket LIKE '%" & k & "%' OR penjualan_tiket_view.tanggal LIKE '%" & k & "%' OR penjualan_tiket_view.Hari LIKE '%" & k & "%' OR penjualan_tiket_view.Tujuan LIKE '%" & k & "%' OR penjualan_tiket_view.Mobil LIKE '%" & k & "%' OR penjualan_tiket_view.Supir LIKE '%" & k & "%' OR penjualan_tiket_view.NomorPolisi LIKE '%" & k & "%') AND penjualan_tiket_view.Status <> 'DIBATALKAN'"
            dgv1.DataSource = BukaTabel("penumpang", "SELECT penjualan_tiket_view.id_tiket, penjualan_tiket_view.tanggal,penjualan_tiket_view.Hari, penjualan_tiket_view.Tujuan, penjualan_tiket_view.Mobil,penjualan_tiket_view.NomorPolisi,penjualan_tiket_view.Kapasitas,penjualan_tiket_view.`NIK Supir`,penjualan_tiket_view.Supir,penjualan_tiket_view.TotalPenumpang,penjualan_tiket_view.Total, tiket.bayar AS TerBayar, penjualan_tiket_view.Status FROM penjualan_tiket_view INNER JOIN tiket ON penjualan_tiket_view.id_tiket = tiket.id" & searchq)
            sender.Text = "Reset"
        Else
            BukaDatabase()
            sender.Text = "Cari"
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            If MessageBox.Show("Lunasi " & dgv1.SelectedRows.Count & " tiket ?", "Konfirmasi pelunasan", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                For Each ro As DataGridViewRow In dgv1.SelectedRows
                    Perintah = New MySqlCommand("UPDATE tiket SET bayar=" & ro.Cells("Total").Value.ToString() & " WHERE id = '" & ro.Cells("id_tiket").Value & "'", Koneksi)
                    Perintah.ExecuteNonQuery()
                Next
            End If
            BukaDatabase()
        Catch ex As Exception

        End Try
    End Sub
End Class