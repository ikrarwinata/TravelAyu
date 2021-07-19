Imports MySql.Data.MySqlClient

Public Class editTarif
    Private id, tujuan As String
    Private mode As String = "Baru"
    Private refAction As Action

    Public Sub TambahBaru(Optional ByVal ref As Action = Nothing)
        refAction = ref
        mode = "Baru"
        Me.Text = "Tambah Tarif"
        Me.Show()
    End Sub

    Public Sub UbahData(ByVal usr As String, Optional ByVal ref As Action = Nothing)
        id = usr
        refAction = ref
        mode = "Ubah"
        Me.Text = "Ubah Tarif"
        Dim ds As DataTable = BukaTabel("tarif", "SELECT * FROM tarif WHERE id = '" & id & "' LIMIT 1 OFFSET 0")
        With ds.Rows(0)
            TextBox2.Text = .Item("tujuan").ToString()
            NumericUpDown1.Value = .Item("tarif").ToString()
        End With

        Me.Show()
    End Sub

    Private Sub editSupir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Function MasihKosong() As Boolean
        If String.IsNullOrEmpty(TextBox2.Text) Then Return True
        Return False
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MasihKosong() Then
            MessageBox.Show("Data tidak boleh kosong")
            Exit Sub
        End If

        If mode = "Baru" Then
            If DataSudahAda("tarif", "tujuan", TextBox2.Text) Then
                MessageBox.Show("Tujuan sudah ada")
                TextBox2.Focus()
                Exit Sub
            End If

            Perintah = New MySqlCommand("INSERT INTO tarif (tujuan, tarif) VALUES ('" & TextBox2.Text & "', '" & NumericUpDown1.Value & "')", Koneksi)
            Perintah.ExecuteNonQuery()
        Else
            If Not TextBox2.Text = tujuan Then
                If DataSudahAda("tarif", "tujuan", TextBox2.Text) Then
                    MessageBox.Show("Tujuan sudah ada")
                    TextBox2.Focus()
                    Exit Sub
                End If
            End If

            Perintah = New MySqlCommand("UPDATE tarif SET tujuan='" & TextBox2.Text & "', tarif='" & NumericUpDown1.Value & "' WHERE id='" & id & "'", Koneksi)
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
End Class