Imports MySql.Data.MySqlClient

Public Class jadwalForm
    Private stateReady As Boolean = False

    Private Const defaultquery As String = "SELECT a.id AS ID, a.hari AS Hari, a.jam AS Jam, b.tujuan AS Tujuan, CONCAT(c.nama_mobil, ', ', c.warna) AS Mobil, c.nopol AS 'Nomor Polisi', d.nama AS 'Nama Supir' FROM jadwal a INNER JOIN tarif b ON a.id_tujuan = b.id INNER JOIN mobil c ON a.mobil = c.nopol INNER JOIN supir d ON c.NIK_supir = d.NIK"

    Private Function BuildQueryFilter() As String
        Dim res As String = "("

        If ToolStripComboBox1.SelectedIndex > 0 Then
            res &= "a.hari = '" & ToolStripComboBox1.SelectedItem & "'"
        Else
            Return ""
        End If

        Return res & ")"
    End Function

    Public Sub BukaDatabase()
        Dim f As String = BuildQueryFilter()
        Dim filter As String = If(String.IsNullOrEmpty(f), "", " WHERE " & f)

        dgv1.DataSource = BukaTabel("supir", defaultquery & filter)
    End Sub

    Private Sub jadwalForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaDatabase()
        ToolStripComboBox1.SelectedIndex = 0
        stateReady = True
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If sender.Text = "Cari" Then
            Dim k As String = ToolStripTextBox1.Text
            Dim searchq As String = " WHERE a.hari LIKE '%" & k & "%' OR a.jam LIKE '%" & k & "%' OR b.tujuan LIKE '%" & k & "%' OR c.nama_mobil LIKE '%" & k & "%' OR c.nopol LIKE '%" & k & "%' OR d.NIK LIKE '%" & k & "%' OR d.nama LIKE '%" & k & "%'"
            dgv1.DataSource = BukaTabel("supir", defaultquery & searchq)
            sender.Text = "Reset"
        Else
            BukaDatabase()
            sender.Text = "Cari"
        End If
    End Sub

    Private Sub TambahToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TambahToolStripMenuItem.Click
        Try
            Dim es As editJadwal = New editJadwal
            es.MdiParent = Me.MdiParent
            es.TambahBaru(AddressOf Me.BukaDatabase)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub HapusTerpilihToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HapusTerpilihToolStripMenuItem.Click
        Try
            If MessageBox.Show("Anda yakin ingin menghapus " & dgv1.SelectedRows.Count & " jadwal ?", "Konfirmasi hapus", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                For Each ro As DataGridViewRow In dgv1.SelectedRows
                    Perintah = New MySqlCommand("DELETE FROM jadwal WHERE id = '" & ro.Cells("ID").Value & "'", Koneksi)
                    Perintah.ExecuteNonQuery()
                Next
                BukaDatabase()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UbahToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UbahToolStripMenuItem.Click
        Try
            Dim es As editJadwal = New editJadwal
            es.MdiParent = Me.MdiParent
            es.UbahData(dgv1.SelectedRows(dgv1.SelectedRows.Count - 1).Cells("ID").Value, AddressOf Me.BukaDatabase)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BersihkanFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BersihkanFilterToolStripMenuItem.Click
        stateReady = False
        UrutkanToolStripMenuItem.Checked = False
        ToolStripComboBox1.SelectedIndex = 0
        stateReady = True
        BukaDatabase()
    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        If Not stateReady Then Exit Sub
        If ToolStripComboBox1.SelectedIndex > 0 Then
            UrutkanToolStripMenuItem.Checked = True
            BukaDatabase()
        Else
            UrutkanToolStripMenuItem.Checked = False
        End If
    End Sub
End Class