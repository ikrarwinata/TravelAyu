Imports MySql.Data.MySqlClient

Public Class loginForm

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(TextBox1.Text) Or String.IsNullOrEmpty(TextBox2.Text) Then
            MessageBox.Show("Username atau password masih kosong")
            Exit Sub
        End If

        Perintah = New MySqlCommand("SELECT * FROM pengguna WHERE username = '" & TextBox1.Text & "' AND password = md5('" & TextBox2.Text & "') LIMIT 1 OFFSET 0", Koneksi)
        DataReader = Perintah.ExecuteReader()
        DataReader.Read()

        If DataReader.HasRows Then
            If Not String.IsNullOrEmpty(DataReader.Item("username")) Then
                loged = True
                username = DataReader.Item("username")
                nama = DataReader.Item("password")
                level = DataReader.Item("level")

                Dim a As Menu = MdiParent
                If DataReader.Item("level") = "admin" Then
                    With a
                        .DatabaseToolStripMenuItem.Enabled = True
                        .TiketToolStripMenuItem.Enabled = True
                        .ReportToolStripMenuItem.Enabled = False
                    End With
                Else
                    With a
                        .DatabaseToolStripMenuItem.Enabled = True
                        .TiketToolStripMenuItem.Enabled = True
                        .ReportToolStripMenuItem.Enabled = True
                    End With
                End If
                a.ToolStripStatusLabel.Text = DataReader.Item("nama")
                DataReader.Close()
                Me.Close()
                Exit Sub
            End If
        End If

        DataReader.Close()
        MessageBox.Show("Username atau password yang anda masukan salah")
        TextBox2.Text = ""
        TextBox2.Focus()
    End Sub

    Private Sub loginForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HubungkanDatabase()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub
End Class
