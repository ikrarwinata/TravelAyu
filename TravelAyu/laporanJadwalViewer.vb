Imports CrystalDecisions.CrystalReports

Public Class laporanJadwalViewer

    Private Sub laporanJadwalViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim crc As jadwalRpt = New jadwalRpt
        CrystalReportViewer1.ReportSource = crc
        crc.Refresh()
        CrystalReportViewer1.Refresh()
    End Sub
End Class