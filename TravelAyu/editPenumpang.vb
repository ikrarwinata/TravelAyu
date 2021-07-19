Imports MySql.Data.MySqlClient

Public Class editPenumpang
    Private refAction As Action
    Private mode As String = "Baru"
    Private id As String

    Private Property JK As String
        Get
            If RadioButton1.Checked Then
                Return "Pria"
            Else
                Return "Wanita"
            End If
        End Get
        Set(ByVal value As String)
            If value = "Pria" Then
                RadioButton1.Checked = True
                RadioButton2.Checked = False
            Else
                RadioButton1.Checked = False
                RadioButton2.Checked = True
            End If
        End Set
    End Property

    Public Sub TambahBaru(Optional ByVal ref As Action = Nothing)
        refAction = ref
        Me.Text = "Tambah Penumpang"
        mode = "Baru"
        Me.Show()
    End Sub

    Public Sub UbahData(ByVal nik As String, Optional ByVal ref As Action = Nothing)
        refAction = ref
        id = nik
        Me.Text = "Ubah Data Penumpang"
        mode = "Ubah"

        Dim ds As DataTable = BukaTabel("penumpang", "SELECT * FROM penumpang WHERE NIK = '" & id & "' LIMIT 1 OFFSET 0")
        With ds.Rows(0)
            TextBox2.Text = .Item("NIK").ToString()
            TextBox1.Text = .Item("nama").ToString()
            TextBox3.Text = .Item("tempat_lahir").ToString()
            Dim d, m, y As Integer
            d = .Item("tanggal_lahir").ToString().Split("/")(0)
            m = .Item("tanggal_lahir").ToString().Split("/")(1)
            y = .Item("tanggal_lahir").ToString().Split("/")(2)
            DateTimePicker1.Value = New Date(y, m, d)
            JK = .Item("jenis_kelamin").ToString()
            TextBox5.Text = .Item("hp").ToString()
        End With

        Me.Show()
    End Sub

    Private Sub editPenumpang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = New Date(1997, 1, 1)
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
            If DataSudahAda("penumpang", "NIK", TextBox2.Text) Then
                MessageBox.Show("NIK ini sudah digunakan")
                TextBox2.Focus()
                Exit Sub
            End If

            Dim q As String = "INSERT INTO penumpang (NIK, nama, tempat_lahir, tanggal_lahir, jenis_kelamin, hp) VALUES ('" & TextBox2.Text & "', '" & TextBox1.Text & "', '" & TextBox3.Text & "', '" & DateTimePicker1.Value.ToShortDateString & "', '" & JK & "', '" & TextBox5.Text & "')"
            Perintah = New MySqlCommand(q, Koneksi)
            Perintah.ExecuteNonQuery()
        Else
            If Not TextBox2.Text = id Then
                If DataSudahAda("penumpang", "NIK", TextBox2.Text) Then
                    MessageBox.Show("NIK ini sudah digunakan")
                    TextBox2.Focus()
                    Exit Sub
                End If
            End If

            Dim q As String = "UPDATE penumpang SET NIK='" & TextBox2.Text & "', nama='" & TextBox1.Text & "', tempat_lahir='" & TextBox3.Text & "', tanggal_lahir='" & DateTimePicker1.Value.ToShortDateString & "', jenis_kelamin='" & JK & "', hp='" & TextBox5.Text & "' WHERE NIK = '" & id & "'"
            Perintah = New MySqlCommand(q, Koneksi)
            Perintah.ExecuteNonQuery()
        End If
        Try
            If Not refAction = Nothing Then refAction()
        Catch ex As Exception

        End Try
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class