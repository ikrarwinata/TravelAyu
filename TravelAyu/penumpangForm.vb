Imports MySql.Data.MySqlClient

Public Class penumpangForm
    Public Sub BukaDatabase()
        dgv1.DataSource = BukaTabel("penumpang", "SELECT NIK, nama AS 'Nama Penumpang', CONCAT(tempat_lahir, ', ', tanggal_lahir) AS TTL, hp AS Telepon FROM penumpang")
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try
            If MessageBox.Show("Anda yakin ingin menghapus " & dgv1.SelectedRows.Count & " data penumpang ?", "Konfirmasi hapus", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                For Each ro As DataGridViewRow In dgv1.SelectedRows
                    Perintah = New MySqlCommand("DELETE FROM penumpang WHERE NIK = '" & ro.Cells("NIK").Value & "'", Koneksi)
                    Perintah.ExecuteNonQuery()
                Next
            End If
            BukaDatabase()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim ed As editPenumpang = New editPenumpang
        ed.MdiParent = Me.MdiParent
        ed.TambahBaru(AddressOf Me.BukaDatabase)
    End Sub

    Private Sub penumpangForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BukaDatabase()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Try
            Dim ed As editPenumpang = New editPenumpang
            ed.MdiParent = Me.MdiParent
            ed.UbahData(dgv1.SelectedRows(dgv1.SelectedRows.Count - 1).Cells("NIK").Value, AddressOf Me.BukaDatabase)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If sender.Text = "Cari" Then
            Dim k As String = ToolStripTextBox1.Text
            Dim searchq As String = " WHERE NIK LIKE '%" & k & "%' OR nama LIKE '%" & k & "%' OR tempat_lahir LIKE '%" & k & "%' OR tanggal_lahir LIKE '%" & k & "%' OR hp LIKE '%" & k & "%' OR email LIKE '%" & k & "%'"
            dgv1.DataSource = BukaTabel("penumpang", "SELECT NIK, nama AS 'Nama Penumpang', CONCAT(tempat_lahir, ', ', tanggal_lahir) AS TTL, hp AS Telepon FROM penumpang" & searchq)
            sender.Text = "Reset"
        Else
            BukaDatabase()
            sender.Text = "Cari"
        End If
    End Sub
End Class