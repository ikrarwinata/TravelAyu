Imports MySql.Data.MySqlClient

Public Class mobilForm
    Private Const defaultquery As String = "SELECT a.nopol as 'Nomor Polisi', CONCAT(a.nama_mobil,', ',a.warna) AS Mobil, (kursi_depan + kursi_2 + kursi_3 + kursi_4) AS Kapasitas, b.nama AS 'Nama Supir' FROM mobil a LEFT OUTER JOIN supir b ON a.NIK_supir = b.NIK"

    Public Sub BukaDatabase()
        dgv1.DataSource = BukaTabel("supir", defaultquery)
    End Sub

    Private Sub supirForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaDatabase()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If sender.Text = "Cari" Then
            Dim k As String = ToolStripTextBox1.Text
            Dim searchq As String = " WHERE b.NIK LIKE '%" & k & "%' OR b.nama LIKE '%" & k & "%' OR a.nopol LIKE '%" & k & "%' OR a.nama_mobil LIKE '%" & k & "%' OR a.warna LIKE '%" & k & "%'"
            dgv1.DataSource = BukaTabel("penumpang", defaultquery & searchq)
            sender.Text = "Reset"
        Else
            BukaDatabase()
            sender.Text = "Cari"
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try
            If MessageBox.Show("Anda yakin ingin menghapus " & dgv1.SelectedRows.Count & " data kendaraan ?", "Konfirmasi hapus", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                For Each ro As DataGridViewRow In dgv1.SelectedRows
                    Perintah = New MySqlCommand("DELETE FROM mobil WHERE nopol = '" & ro.Cells("Nomor Polisi").Value & "'", Koneksi)
                    Perintah.ExecuteNonQuery()
                Next
                BukaDatabase()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim es As editMobil = New editMobil
        es.MdiParent = Me.MdiParent
        es.TambahBaru(AddressOf Me.BukaDatabase)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Try
            Dim es As editMobil = New editMobil
            es.MdiParent = Me.MdiParent
            es.UbahData(dgv1.SelectedRows(0).Cells("Nomor Polisi").Value, AddressOf Me.BukaDatabase)
        Catch ex As Exception

        End Try
    End Sub
End Class