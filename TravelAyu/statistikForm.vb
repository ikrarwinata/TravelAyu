Imports MySql.Data.MySqlClient

Public Class statistikForm

    Private Sub statistikForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Chart1.Series(0).Points.Clear()
        Dim y As Integer = Date.Now.Year
        Dim tr As String
        For i As Integer = 1 To 12
            tr = 0
            Try
                Dim querys As String = "SELECT COUNT(id) AS c FROM tiket WHERE timestamps BETWEEN " & TimeToString(New Date(y, i, 1, 0, 0, 0)) & " AND " & TimeToString(New Date(y, i, System.DateTime.DaysInMonth(y, i), 17, 0, 0))
                Perintah = New MySqlCommand(querys, Koneksi)
                DataReader = Perintah.ExecuteReader()
                DataReader.Read()
                If DataReader.HasRows Then
                    If Not String.IsNullOrEmpty(DataReader.Item("c").ToString()) Then
                        tr = DataReader.Item("c").ToString()
                    End If
                End If
                Chart1.Series(0).Points.AddXY(StringMonth(i) & " " & Date.Now.Year.ToString().Substring(2), tr)
            Catch ex As Exception
                Dim es As String = ex.Message
                es = ""
            End Try
            DataReader.Close()
        Next
        Chart1.ChartAreas(0).AxisY.Title = "Jumlah"
        Chart1.ChartAreas(0).AxisX.Title = "Tanggal"
        Chart1.ChartAreas(0).AxisX.Interval = 1
    End Sub

    Private Function StringMonth(ByVal i As Integer) As String
        Dim bulan As String() = {"", "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember"}
        Return bulan(i)
    End Function
End Class