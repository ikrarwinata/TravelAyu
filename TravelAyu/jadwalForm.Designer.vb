﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class jadwalForm
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.TambahToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UbahToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HapusTerpilihToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.UrutkanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.BersihkanFilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.ToolStrip1)
        Me.GroupBox1.Controls.Add(Me.dgv1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(697, 394)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.LightGray
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.ToolStripSeparator3, Me.ToolStripButton4, Me.ToolStripTextBox1, Me.ToolStripDropDownButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 16)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(691, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TambahToolStripMenuItem, Me.UbahToolStripMenuItem, Me.HapusTerpilihToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = Global.TravelAyu.My.Resources.Resources.rinse
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(60, 22)
        Me.ToolStripDropDownButton1.Text = "Data"
        '
        'TambahToolStripMenuItem
        '
        Me.TambahToolStripMenuItem.Name = "TambahToolStripMenuItem"
        Me.TambahToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TambahToolStripMenuItem.Text = "Tambah"
        '
        'UbahToolStripMenuItem
        '
        Me.UbahToolStripMenuItem.Name = "UbahToolStripMenuItem"
        Me.UbahToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.UbahToolStripMenuItem.Text = "Ubah"
        '
        'HapusTerpilihToolStripMenuItem
        '
        Me.HapusTerpilihToolStripMenuItem.Name = "HapusTerpilihToolStripMenuItem"
        Me.HapusTerpilihToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.HapusTerpilihToolStripMenuItem.Text = "Hapus Terpilih"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(32, 22)
        Me.ToolStripButton4.Text = "Cari"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripTextBox1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UrutkanToolStripMenuItem, Me.BersihkanFilterToolStripMenuItem})
        Me.ToolStripDropDownButton2.Image = Global.TravelAyu.My.Resources.Resources.filter
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripDropDownButton2.Text = "Filter"
        '
        'UrutkanToolStripMenuItem
        '
        Me.UrutkanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox1})
        Me.UrutkanToolStripMenuItem.Name = "UrutkanToolStripMenuItem"
        Me.UrutkanToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.UrutkanToolStripMenuItem.Text = "Hari"
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBox1.Items.AddRange(New Object() {"-", "Senin", "Selasa", "Rabu", "Kamis", "Jum'at", "Sabtu", "Minggu"})
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(121, 23)
        '
        'BersihkanFilterToolStripMenuItem
        '
        Me.BersihkanFilterToolStripMenuItem.Name = "BersihkanFilterToolStripMenuItem"
        Me.BersihkanFilterToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.BersihkanFilterToolStripMenuItem.Text = "Bersihkan Filter"
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.AllowUserToOrderColumns = True
        Me.dgv1.AllowUserToResizeRows = False
        Me.dgv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv1.BackgroundColor = System.Drawing.Color.White
        Me.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Location = New System.Drawing.Point(6, 44)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.RowHeadersVisible = False
        Me.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv1.ShowEditingIcon = False
        Me.dgv1.Size = New System.Drawing.Size(685, 350)
        Me.dgv1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Goudy Old Style", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(721, 47)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Jadwal Keberangkatan"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'jadwalForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 456)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "jadwalForm"
        Me.Text = "Jadwal"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents TambahToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UbahToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HapusTerpilihToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents ToolStripTextBox1 As ToolStripTextBox
    Friend WithEvents ToolStripDropDownButton2 As ToolStripDropDownButton
    Friend WithEvents UrutkanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripComboBox1 As ToolStripComboBox
    Friend WithEvents BersihkanFilterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents Label1 As Label
End Class
