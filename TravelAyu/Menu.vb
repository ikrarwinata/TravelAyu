Imports System.Windows.Forms

Public Class Menu

    Private Sub Menu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not loged Then
            DatabaseToolStripMenuItem.Enabled = False
            TiketToolStripMenuItem.Enabled = False
            ReportToolStripMenuItem.Enabled = False

            Dim l As loginForm = New loginForm
            l.MdiParent = Me
            l.Show()
        End If
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        loged = False
        username = ""
        nama = ""
        With Me
            .DatabaseToolStripMenuItem.Enabled = False
            .TiketToolStripMenuItem.Enabled = False
            .ReportToolStripMenuItem.Enabled = False
        End With
        Dim l As loginForm = New loginForm
        l.MdiParent = Me
        l.Show()
    End Sub

    Private Sub AkunPenggunaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AkunPenggunaToolStripMenuItem.Click
        Dim akun As akunForm = New akunForm
        akun.MdiParent = Me
        akun.Show()
    End Sub

    Private Sub DataPenumpangToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataPenumpangToolStripMenuItem.Click
        Dim pen As penumpangForm = New penumpangForm
        pen.MdiParent = Me
        pen.Show()
    End Sub

    Private Sub DataSupirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataSupirToolStripMenuItem.Click
        Dim s As supirForm = New supirForm
        s.MdiParent = Me
        s.Show()
    End Sub

    Private Sub DataMobilToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataMobilToolStripMenuItem.Click
        Dim m As mobilForm = New mobilForm
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub DataTujuanTarifToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataTujuanTarifToolStripMenuItem.Click
        Dim tuj As tujuanForm = New tujuanForm
        tuj.MdiParent = Me
        tuj.Show()
    End Sub

    Private Sub DataJadwalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataJadwalToolStripMenuItem.Click
        Dim jad As jadwalForm = New jadwalForm
        jad.MdiParent = Me
        jad.Show()
    End Sub

    Private Sub JadwalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JadwalToolStripMenuItem.Click
        Dim re As laporanJadwalViewer = New laporanJadwalViewer
        re.MdiParent = Me
        re.Show()

    End Sub

    Private Sub DataPenjualanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataPenjualanToolStripMenuItem.Click
        Dim lap As laporanTiketViewer = New laporanTiketViewer
        lap.MdiParent = Me
        lap.Show()
    End Sub

    Private Sub StatistikToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatistikToolStripMenuItem.Click
        Dim stat As statistikForm = New statistikForm
        stat.MdiParent = Me
        stat.Show()
    End Sub

    Private Sub PenumpangToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PenumpangToolStripMenuItem.Click
        Dim p As penumpangReportView = New penumpangReportView
        p.MdiParent = Me
        p.Show()
    End Sub

    Private Sub TransaksiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransaksiToolStripMenuItem.Click
        Dim tik As tiketForm = New tiketForm
        tik.MdiParent = Me
        tik.Show()
    End Sub

    Private Sub DataPenjualanToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataPenjualanToolStripMenuItem1.Click
        Dim tik As dataTiketForm = New dataTiketForm
        tik.MdiParent = Me
        tik.Show()
    End Sub

    Private Sub Menu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub
End Class
