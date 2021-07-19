Imports MySql.Data.MySqlClient

Public Class akunForm

    Public Sub BukaDatabase()
        dgv1.DataSource = BukaTabel("pengguna", "SELECT username AS Username, nama AS 'Nama Pengguna', hp AS Telepon, level AS LEVEL FROM pengguna")
    End Sub

    Private Sub akunForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaDatabase()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try
            If MessageBox.Show("Anda yakin ingin menghapus " & dgv1.SelectedRows.Count & " akun pengguna ?", "Konfirmasi hapus", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                For Each ro As DataGridViewRow In dgv1.SelectedRows
                    Perintah = New MySqlCommand("DELETE FROM pengguna WHERE username = '" & ro.Cells("Username").Value & "'", Koneksi)
                    Perintah.ExecuteNonQuery()
                Next
                BukaDatabase()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim edit As editAkunPengguna = New editAkunPengguna
        edit.MdiParent = Me.MdiParent
        edit.TambahBaru(AddressOf Me.BukaDatabase)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Try
            Dim edit As editAkunPengguna = New editAkunPengguna
            edit.MdiParent = Me.MdiParent
            edit.UbahData(dgv1.SelectedRows(dgv1.SelectedRows.Count - 1).Cells("Username").Value, AddressOf Me.BukaDatabase)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If sender.Text = "Cari" Then
            Dim k As String = ToolStripTextBox1.Text
            Dim searchq As String = " WHERE username LIKE '%" & k & "%' OR nama LIKE '%" & k & "%' OR hp LIKE '%" & k & "%' OR level LIKE '%" & k & "%'"
            dgv1.DataSource = BukaTabel("penumpang", "SELECT username AS Username, nama AS 'Nama Pengguna', hp AS Telepon, level AS LEVEL FROM pengguna" & searchq)
            sender.Text = "Reset"
        Else
            BukaDatabase()
            sender.Text = "Cari"
        End If
    End Sub
End Class