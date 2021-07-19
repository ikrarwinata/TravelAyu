Imports MySql.Data.MySqlClient

Module Modul_Database
    Public Koneksi As New MySqlConnection
    Public DataReader As MySqlDataReader
    Public DataAdapter As MySqlDataAdapter
    Public Perintah As MySqlCommand

    Public loged As Boolean
    Public username, nama, level As String

    Public Function Hari(Optional ByVal tgl As Date = Nothing) As String
        Dim d As Date = Now
        If Not tgl = Nothing Then d = tgl
        Dim s As String() = {"Minggu", "Senin", "Selasa", "Rabu", "Kamis", "Jumat", "Sabtu", "Minggu"}
        Return s(d.DayOfWeek)
    End Function

    Public Sub HubungkanDatabase()
        Try
            If Not Koneksi.State = ConnectionState.Open Then
                Koneksi.ConnectionString = "server=127.0.0.1;" _
                           & "user id=root;" _
                           & "password=;" _
                           & "Database=travelayu"
                Koneksi.Open()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function BukaTabel(ByVal NamaTabel As String) As DataTable
        Perintah = New MySqlCommand("SELECT * FROM " & NamaTabel, Koneksi)
        DataAdapter = New MySqlDataAdapter(Perintah)
        Dim ds As New DataSet
        DataAdapter.Fill(ds, NamaTabel)
        Return ds.Tables(NamaTabel)
    End Function

    Public Function BukaTabel(ByVal NamaTabel As String, ByVal query As String) As DataTable
        Perintah = New MySqlCommand(query, Koneksi)
        DataAdapter = New MySqlDataAdapter(Perintah)
        Dim ds As New DataSet
        DataAdapter.Fill(ds, NamaTabel)
        Return ds.Tables(NamaTabel)
    End Function

    Public Function DataSudahAda(ByVal namatabel As String, ByVal kondisi As String)
        Perintah = New MySqlCommand("SELECT * FROM " & namatabel & " WHERE " & kondisi & " LIMIT 1 OFFSET 0", Koneksi)
        DataReader = Perintah.ExecuteReader()
        DataReader.Read()
        Dim res As Boolean = DataReader.HasRows
        DataReader.Close()
        Return res
    End Function

    Public Function DataSudahAda(ByVal namatabel As String, ByVal namafield As String, ByVal kondisifield As String)
        Perintah = New MySqlCommand("SELECT " & namafield & " FROM " & namatabel & " WHERE " & namafield & " = '" & kondisifield & "' LIMIT 1 OFFSET 0", Koneksi)
        DataReader = Perintah.ExecuteReader()
        DataReader.Read()
        Dim res As Boolean = DataReader.HasRows
        DataReader.Close()
        Return res
    End Function

    Public Function AmbilData(ByVal namatabel As String, ByVal namafield As String, ByVal fieldkunci As String, ByVal kondisifield As String)
        Perintah = New MySqlCommand("SELECT " & namafield & " FROM " & namatabel & " WHERE " & fieldkunci & " = '" & kondisifield & "' LIMIT 1 OFFSET 0", Koneksi)
        DataReader = Perintah.ExecuteReader()
        DataReader.Read()

        Dim res As Object = Nothing
        If DataReader.HasRows Then
            res = DataReader.Item(namafield)
        End If
        DataReader.Close()
        Return res
    End Function

    Public Function UCFirst(ByVal st As String) As String
        If String.IsNullOrEmpty(st) Then Return ""
        Return (st.Substring(0, 1).ToUpper() & st.Substring(1))
    End Function

    Public Function SentenceCase(ByVal st As String) As String
        If String.IsNullOrEmpty(st) Then Return ""
        Dim res As String
        If st.Contains(" ") Then
            Dim s As String() = st.Split(" ")
            For Each item As String In s
                item = UCFirst(item)
            Next
            res = String.Join(" ", s)
        Else
            res = UCFirst(st)
        End If

        Return res
    End Function

    Public Function StringToTime(ByVal timestamps As String) As Date
        Dim dt As DateTime = New DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)
        dt = dt.AddMilliseconds(timestamps).ToLocalTime()
        Return dt
    End Function

    Public Function TimeToString(ByVal d As Date) As String
        Return CLng(d.Subtract(New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds)
    End Function
End Module
