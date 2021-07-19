Public Class penumpangReportView

    Private Sub penumpangReporForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim re As penumpangRpt = New penumpangRpt
        re.Refresh()
        Me.CrystalReportViewer1.ReportSource = re
        Me.CrystalReportViewer1.Refresh()
    End Sub
End Class