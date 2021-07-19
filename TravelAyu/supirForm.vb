Imports MySql.Data.MySqlClient

Public Class supirForm
    Public Sub BukaDatabase()
        dgv1.DataSource = BukaTabel("supir", "SELECT NIK as NIK, nama AS 'Nama Supir', hp AS Telepon FROM supir")
    End Sub

    Private Sub supirForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaDatabase()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If sender.Text = "Cari" Then
            Dim k As String = ToolStripTextBox1.Text
            Dim searchq As String = " WHERE NIK LIKE '%" & k & "%' OR nama LIKE '%" & k & "%' OR hp LIKE '%" & k & "%'"
            dgv1.DataSource = BukaTabel("supir", "SELECT NIK as NIK, nama AS 'Nama Supir', hp AS Telepon FROM supir" & searchq)
            sender.Text = "Reset"
        Else
            BukaDatabase()
            sender.Text = "Cari"
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try
            If MessageBox.Show("Anda yakin ingin menghapus " & dgv1.SelectedRows.Count & " data supir ?", "Konfirmasi hapus", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                For Each ro As DataGridViewRow In dgv1.SelectedRows
                    Perintah = New MySqlCommand("DELETE FROM supir WHERE NIK = '" & ro.Cells("NIK").Value & "'", Koneksi)
                    Perintah.ExecuteNonQuery()
                Next
                BukaDatabase()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim es As editSupir = New editSupir
        es.MdiParent = Me.MdiParent
        es.TambahBaru(AddressOf Me.BukaDatabase)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Try
            Dim es As editSupir = New editSupir
            es.MdiParent = Me.MdiParent
            es.UbahData(dgv1.SelectedRows(dgv1.SelectedRows.Count - 1).Cells("NIK").Value, AddressOf Me.BukaDatabase)
        Catch ex As Exception

        End Try
    End Sub
End Class