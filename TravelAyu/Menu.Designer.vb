<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JadwalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PenumpangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataPenjualanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.StatistikToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TiketToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataPenjualanToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransaksiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TiketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AkunPenggunaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DataPenumpangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DataJadwalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataTujuanTarifToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataMobilToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataSupirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 395)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(740, 22)
        Me.StatusStrip.TabIndex = 10
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LogoutToolStripMenuItem.Image = Global.TravelAyu.My.Resources.Resources.logout
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'JadwalToolStripMenuItem
        '
        Me.JadwalToolStripMenuItem.Name = "JadwalToolStripMenuItem"
        Me.JadwalToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.JadwalToolStripMenuItem.Text = "Jadwal"
        '
        'PenumpangToolStripMenuItem
        '
        Me.PenumpangToolStripMenuItem.Name = "PenumpangToolStripMenuItem"
        Me.PenumpangToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.PenumpangToolStripMenuItem.Text = "Penumpang"
        '
        'DataPenjualanToolStripMenuItem
        '
        Me.DataPenjualanToolStripMenuItem.Name = "DataPenjualanToolStripMenuItem"
        Me.DataPenjualanToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.DataPenjualanToolStripMenuItem.Text = "Data Penjualan"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(150, 6)
        '
        'StatistikToolStripMenuItem
        '
        Me.StatistikToolStripMenuItem.Name = "StatistikToolStripMenuItem"
        Me.StatistikToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.StatistikToolStripMenuItem.Text = "Statistik"
        '
        'TiketToolStripMenuItem1
        '
        Me.TiketToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatistikToolStripMenuItem, Me.ToolStripSeparator3, Me.DataPenjualanToolStripMenuItem})
        Me.TiketToolStripMenuItem1.Name = "TiketToolStripMenuItem1"
        Me.TiketToolStripMenuItem1.Size = New System.Drawing.Size(139, 22)
        Me.TiketToolStripMenuItem1.Text = "Tiket"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TiketToolStripMenuItem1, Me.PenumpangToolStripMenuItem, Me.JadwalToolStripMenuItem})
        Me.ReportToolStripMenuItem.Image = Global.TravelAyu.My.Resources.Resources.report
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.ReportToolStripMenuItem.Text = "Report"
        '
        'DataPenjualanToolStripMenuItem1
        '
        Me.DataPenjualanToolStripMenuItem1.Name = "DataPenjualanToolStripMenuItem1"
        Me.DataPenjualanToolStripMenuItem1.Size = New System.Drawing.Size(153, 22)
        Me.DataPenjualanToolStripMenuItem1.Text = "Data Penjualan"
        '
        'TransaksiToolStripMenuItem
        '
        Me.TransaksiToolStripMenuItem.Name = "TransaksiToolStripMenuItem"
        Me.TransaksiToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.TransaksiToolStripMenuItem.Text = "Transaksi"
        '
        'TiketToolStripMenuItem
        '
        Me.TiketToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TransaksiToolStripMenuItem, Me.DataPenjualanToolStripMenuItem1})
        Me.TiketToolStripMenuItem.Image = Global.TravelAyu.My.Resources.Resources.tickets
        Me.TiketToolStripMenuItem.Name = "TiketToolStripMenuItem"
        Me.TiketToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.TiketToolStripMenuItem.Text = "Tiket"
        '
        'AkunPenggunaToolStripMenuItem
        '
        Me.AkunPenggunaToolStripMenuItem.Name = "AkunPenggunaToolStripMenuItem"
        Me.AkunPenggunaToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.AkunPenggunaToolStripMenuItem.Text = "Akun Pengguna"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(172, 6)
        '
        'DataPenumpangToolStripMenuItem
        '
        Me.DataPenumpangToolStripMenuItem.Name = "DataPenumpangToolStripMenuItem"
        Me.DataPenumpangToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.DataPenumpangToolStripMenuItem.Text = "Data Penumpang"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(172, 6)
        '
        'DataJadwalToolStripMenuItem
        '
        Me.DataJadwalToolStripMenuItem.Name = "DataJadwalToolStripMenuItem"
        Me.DataJadwalToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.DataJadwalToolStripMenuItem.Text = "Data Jadwal"
        '
        'DataTujuanTarifToolStripMenuItem
        '
        Me.DataTujuanTarifToolStripMenuItem.Name = "DataTujuanTarifToolStripMenuItem"
        Me.DataTujuanTarifToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.DataTujuanTarifToolStripMenuItem.Text = "Data Tujuan && Tarif"
        '
        'DataMobilToolStripMenuItem
        '
        Me.DataMobilToolStripMenuItem.Name = "DataMobilToolStripMenuItem"
        Me.DataMobilToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.DataMobilToolStripMenuItem.Text = "Data Mobil"
        '
        'DataSupirToolStripMenuItem
        '
        Me.DataSupirToolStripMenuItem.Name = "DataSupirToolStripMenuItem"
        Me.DataSupirToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.DataSupirToolStripMenuItem.Text = "Data Supir"
        '
        'DatabaseToolStripMenuItem
        '
        Me.DatabaseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataSupirToolStripMenuItem, Me.DataMobilToolStripMenuItem, Me.DataTujuanTarifToolStripMenuItem, Me.DataJadwalToolStripMenuItem, Me.ToolStripSeparator1, Me.DataPenumpangToolStripMenuItem, Me.ToolStripSeparator2, Me.AkunPenggunaToolStripMenuItem})
        Me.DatabaseToolStripMenuItem.Image = Global.TravelAyu.My.Resources.Resources.databases
        Me.DatabaseToolStripMenuItem.Name = "DatabaseToolStripMenuItem"
        Me.DatabaseToolStripMenuItem.Size = New System.Drawing.Size(83, 20)
        Me.DatabaseToolStripMenuItem.Text = "Database"
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DatabaseToolStripMenuItem, Me.TiketToolStripMenuItem, Me.ReportToolStripMenuItem, Me.LogoutToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(740, 24)
        Me.MenuStrip.TabIndex = 9
        Me.MenuStrip.Text = "MenuStrip"
        '
        'Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.TravelAyu.My.Resources.Resources.logos
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(740, 417)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.IsMdiContainer = True
        Me.Name = "Menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents LogoutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents JadwalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PenumpangToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataPenjualanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatistikToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TiketToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataPenjualanToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents TransaksiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TiketToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AkunPenggunaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataPenumpangToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataJadwalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataTujuanTarifToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataMobilToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataSupirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripStatusLabel As ToolStripStatusLabel
    Friend WithEvents StatusStrip As StatusStrip
End Class
