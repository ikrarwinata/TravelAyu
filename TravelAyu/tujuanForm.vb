Imports MySql.Data.MySqlClient

Public Class tujuanForm
    Public Sub BukaDatabase()
        dgv1.DataSource = BukaTabel("tarif", "SELECT id AS ID, tujuan AS Tujuan, tarif AS Tarif FROM tarif")
    End Sub

    Private Sub tujuanForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaDatabase()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If sender.Text = "Cari" Then
            Dim k As String = ToolStripTextBox1.Text
            Dim searchq As String = " WHERE tujuan LIKE '%" & k & "%'"
            dgv1.DataSource = BukaTabel("tarif", "SELECT id AS ID, tujuan AS Tujuan, tarif AS Tarif FROM tarif" & searchq)
            sender.Text = "Reset"
        Else
            BukaDatabase()
            sender.Text = "Cari"
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try
            If MessageBox.Show("Anda yakin ingin menghapus " & dgv1.SelectedRows.Count & " data tujuan ?", "Konfirmasi hapus", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                For Each ro As DataGridViewRow In dgv1.SelectedRows
                    Perintah = New MySqlCommand("DELETE FROM tarif WHERE id = '" & ro.Cells("ID").Value & "'", Koneksi)
                    Perintah.ExecuteNonQuery()
                Next
                BukaDatabase()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim et As editTarif = New editTarif
        et.MdiParent = Me.MdiParent
        et.TambahBaru(AddressOf Me.BukaDatabase)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Try
            Dim et As editTarif = New editTarif
            et.MdiParent = Me.MdiParent
            et.UbahData(dgv1.SelectedRows(dgv1.SelectedRows.Count - 1).Cells("ID").Value, AddressOf Me.BukaDatabase)
        Catch ex As Exception

        End Try
    End Sub
End Class