Public Class imgButton
    Inherits Button
    Private isChecked As Boolean
    Private colID As Integer

    Public Property ColumnID As Integer
        Get
            Return colID
        End Get
        Set(ByVal value As Integer)
            colID = value
        End Set
    End Property

    Public Property Checked
        Get
            Return isChecked
        End Get
        Set(ByVal value)
            If value Then
                Me.FlatAppearance.BorderColor = Color.CadetBlue
                Me.Text = "OK"
            Else
                Me.FlatAppearance.BorderColor = Color.Black
                Me.Text = ""
            End If
            isChecked = value
        End Set
    End Property

    Public Sub New(ByVal col As Integer, ByVal init As String)
        colID = col
        Me.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
        Me.FlatStyle = FlatStyle.Flat
        Me.BackgroundImage = My.Resources.seat
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Me.Dock = DockStyle.Fill
        Me.Name = init
    End Sub

    Private Sub imgButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Me.Checked = Not isChecked
    End Sub

    Private Sub imgButton_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.EnabledChanged
        If Me.Enabled Then
            Me.BackgroundImage = My.Resources.seat
        Else
            Me.BackgroundImage = My.Resources.seat_full
        End If
    End Sub
End Class
