Imports MySql.Data.MySqlClient

Public Class editSupir
    Private id As String
    Private mode As String = "Baru"
    Private refAction As Action

    Public Sub TambahBaru(Optional ByVal ref As Action = Nothing)
        refAction = ref
        mode = "Baru"
        Me.Text = "Tambah Data Supir"
        Me.Show()
    End Sub

    Public Sub UbahData(ByVal usr As String, Optional ByVal ref As Action = Nothing)
        id = usr
        refAction = ref
        mode = "Ubah"
        Me.Text = "Ubah Data Supir"
        Dim ds As DataTable = BukaTabel("supir", "SELECT * FROM supir WHERE NIK = '" & id & "' LIMIT 1 OFFSET 0")
        With ds.Rows(0)
            TextBox2.Text = .Item("NIK").ToString()
            TextBox3.Text = .Item("nama").ToString()
            TextBox4.Text = .Item("hp").ToString()
        End With

        Me.Show()
    End Sub

    Private Sub editSupir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Function MasihKosong() As Boolean
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MasihKosong() Then
            MessageBox.Show("Data tidak boleh kosong")
            Exit Sub
        End If

        If mode = "Baru" Then
            If DataSudahAda("supir", "NIK", TextBox3.Text) Then
                MessageBox.Show("NIK ini sudah digunakan")
                TextBox2.Focus()
                Exit Sub
            End If

            Perintah = New MySqlCommand("INSERT INTO supir (NIK, nama, hp) VALUES ('" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "')", Koneksi)
            Perintah.ExecuteNonQuery()
        Else
            If Not TextBox2.Text = id Then
                If DataSudahAda("supir", "NIK", TextBox3.Text) Then
                    MessageBox.Show("NIK ini sudah digunakan")
                    TextBox2.Focus()
                    Exit Sub
                End If
            End If

            Perintah = New MySqlCommand("UPDATE supir SET NIK='" & TextBox2.Text & "', nama='" & TextBox3.Text & "', hp='" & TextBox4.Text & "' WHERE NIK='" & id & "'", Koneksi)
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