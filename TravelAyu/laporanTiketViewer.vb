Imports MySql.Data.MySqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class laporanTiketViewer

    Private Sub laporanTiketViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = New Date(Date.Now.Year - 1, Date.Now.Month, Date.Now.Day)
        DateTimePicker2.Value = Now
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim startt, endt As String
        startt = TimeToString(New Date(DateTimePicker1.Value.Year, DateTimePicker1.Value.Month, DateTimePicker1.Value.Day, 17, 0, 0))
        endt = TimeToString(New Date(DateTimePicker2.Value.Year, DateTimePicker2.Value.Month, DateTimePicker2.Value.Day, 23, 59, 59))
        Dim status As String = ""
        If (ComboBox1.SelectedIndex = 0) Then
            status = ""
        Else
            status = " AND status = '" & ComboBox1.SelectedItem.ToString() & "'"
        End If

        DataAdapter = New MySqlDataAdapter("SELECT * FROM penjualan_tiket_view WHERE timestamps >='" & startt & "' AND timestamps<='" & endt & "'" & status, Koneksi)
        Dim ds As New DataSet
        DataAdapter.Fill(ds, "penjualan_tiket_view")
        DataAdapter = New MySqlDataAdapter("SELECT * FROM penumpang", Koneksi)
        DataAdapter.Fill(ds, "penumpang")
        Dim r As penjualanTiketRpt = New penjualanTiketRpt
        r.SetDataSource(ds)
        r.Refresh()
        CrystalReportViewer1.ReportSource = r
        CrystalReportViewer1.Refresh()
    End Sub
End Class