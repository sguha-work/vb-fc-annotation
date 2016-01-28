Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Namespace Cal_

    Public Module Cal_Module
        Public SQL As String
        Public sb As New StringBuilder
        Public com As New SqlCommand
        'Public Sql As String
        Public sqlStr As String
        Public ddlTable As DataTable
        Public dTable As DataTable
        Public Conn As New SqlConnection
        Public Constr As String




        Public Sub Connect()


            Constr = ConfigurationManager.ConnectionStrings("MyMindConnectionString").ConnectionString

            If Conn.State = ConnectionState.Connecting Then Conn.Close()
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.ConnectionString = Constr
            Conn.Open()
        End Sub
       
      
        'Public Sub Connect()
        '    Dim strConn As String
        '    strConn = WebConfigurationManager.ConnectionStrings("CalConnectionString").ConnectionString
        '    Dim Conn As New SqlConnection(strConn)  'เชื่อมตัวฐานข้อมูลด้วย oopject SqlConnection โดยอาศัยข้อความที่เก็บไว้ใน strConn
        '    Conn.Open()
        'End Sub
        Public ReadOnly Property ConnectionString() As String
            Get
                Dim connStr As String = ""

                If Not ConfigurationManager.ConnectionStrings("MyMindConnectionString") Is Nothing Then
                    connStr = ConfigurationManager.ConnectionStrings("MyMindConnectionString").ConnectionString
                End If

                If String.IsNullOrEmpty(connStr) Then
                    Throw New NullReferenceException("ConnectionString configuration is missing from you web.config. It should contain  <connectionStrings> <add key=""aspnet_staterKits_TimeTracker"" value=""Server=(local);Integrated Security=True;Database=Issue_Tracker"" </connectionStrings>")
                Else
                    Return connStr
                End If

            End Get

        End Property

        Public Sub ExecuteScalarCmd(ByVal sqlCmd As SqlCommand)
            If ConnectionString = String.Empty Then
                Throw New ArgumentOutOfRangeException("MyMindConnectionString")
            End If
            If sqlCmd Is Nothing Then
                Throw New ArgumentNullException("sqlCmd")
            End If
            Using cn As SqlConnection = New SqlConnection(ConnectionString)
                sqlCmd.Connection = cn
                cn.Open()
                sqlCmd.ExecuteScalar()
            End Using
        End Sub
        Public Function ExecuteNonQ(ByVal SQL As String) As Integer

            If Conn.State = ConnectionState.Closed Then Conn.Open()

            Dim FCommand As New SqlCommand

            FCommand.Connection = Conn
            FCommand.CommandText = SQL
            FCommand.ExecuteNonQuery()
            Return SQL
        End Function

        Public Function GetDs(ByVal SQL As String) As DataSet
            Dim cn As SqlConnection = New SqlConnection(ConnectionString)
            Dim FDa As New SqlDataAdapter(SQL, cn)
            Dim FDs As New DataSet("q")
            Try
                FDa.Fill(FDs, "q")
                Return FDs
            Catch ex As Exception
                Return FDs
            End Try


        End Function
        ' Get Month name 3 character
        Public Function getMonth(ByVal dt As DateTime) As String
            Dim month As Integer = CInt(dt.Month)

            Select Case month
                Case 1
                    getMonth = "Jan"
                Case 2
                    getMonth = "Feb"
                Case 3
                    getMonth = "Mar"
                Case 4
                    getMonth = "Apr"
                Case 5
                    getMonth = "May"
                Case 6
                    getMonth = "Jun"
                Case 7
                    getMonth = "Jul"
                Case 8
                    getMonth = "Aug"
                Case 9
                    getMonth = "Sep"
                Case 10
                    getMonth = "Oct"
                Case 11
                    getMonth = "Nov"
                Case 12
                    getMonth = "Dec"
            End Select

        End Function
        ' Get String of Date such as "10 Dec '10"
        Public Function getStrDate(ByVal dt As Date) As String
            getStrDate = dt.Day.ToString("00") + " " + getMonth(dt) + " '" + dt.Year.ToString.Substring(2, 2)
        End Function
        ' Convert string to date time
        Public Function ConvertToDateTime(ByVal dt As String) As DateTime
            Return New DateTime(CInt(dt.Substring(6, 4)), CInt(dt.Substring(3, 2)), CInt(dt.Substring(0, 2)), _
                                CInt(dt.Substring(11, 2)), CInt(dt.Substring(14, 2)), CInt(dt.Substring(17, 2)))
        End Function
        Public Function GetDateStart(ByVal dt As String) As DateTime
            Return New DateTime(CInt(dt.Substring(6, 4)), CInt(dt.Substring(3, 2)), CInt(dt.Substring(0, 2)), _
                              0, 0, 0)
        End Function
        ' Get Month full name by date time
        Public Function getMonthFull(ByVal dt As DateTime) As String
            Dim month As Integer = CInt(dt.Month)

            Select Case month
                Case 1
                    getMonthFull = "JANUARY"
                Case 2
                    getMonthFull = "FEBRUARY"
                Case 3
                    getMonthFull = "MARCH"
                Case 4
                    getMonthFull = "APRIL"
                Case 5
                    getMonthFull = "MAY"
                Case 6
                    getMonthFull = "JUNE"
                Case 7
                    getMonthFull = "JULY"
                Case 8
                    getMonthFull = "AUGUST"
                Case 9
                    getMonthFull = "SEPTEMBER"
                Case 10
                    getMonthFull = "OCTOBER"
                Case 11
                    getMonthFull = "NOVEMBER"
                Case 12
                    getMonthFull = "DECEMBER"
            End Select
        End Function
        ' Get End Date from String
        Public Function GetDateEnd(ByVal dt As String) As DateTime
            Return New DateTime(CInt(dt.Substring(6, 4)), CInt(dt.Substring(3, 2)), CInt(dt.Substring(0, 2)), _
                              23, 59, 59)
        End Function
      
        ' Get Present Date By Date.Now
        Public Function getDate() As DateTime
            Dim dt As DateTime = Date.Now
            Dim StrDate1 As DateTime = New Date(dt.Year, dt.Month, dt.Day, 8, 0, 0)

            If Not (dt.TimeOfDay.Hours >= 8 And dt.TimeOfDay.Hours <= 23) Then
                StrDate1 = StrDate1.AddDays(-1)
            End If
            Return StrDate1
        End Function
        Public Function GetColor(ByVal i As Integer) As String
            Dim color As String = ""
            i = i Mod 65

            Select Case i
                Case 0
                    color = "008000"    'Green
                Case 1
                    color = "008080"    'Teal
                Case 2

                    color = "800080"    'Purple
                Case 3
                    color = "FF0000"    'Red
                Case 4
                    color = "FFFF00"    'Yellow
                Case 5

                    color = "0000FF"    'Blue
                Case 6
                    color = "808000"    'Olive
                Case 7
                    color = "FFA500"    'Orange
                Case 8
                    color = "00FFFF"    'Aqua
                Case 9
                    color = "00FF00"    'Lime
                Case 10
                    color = "FF00FF"    'Fuchsia
                Case 11
                    color = "808080"    'Gray
                Case 12
                    color = "C0C0C0"    'Silver
                Case 13
                    color = "000080"    'Navy
                Case 14
                    color = "006400"    'DarkGreen
                Case 15
                    color = "FA8072"    'Salmon
                Case 16
                    color = "D3D3D3"
                Case 17
                    color = "8E468E"    'Violet
                Case 18
                    color = "00BFFF"    'DeepSkyBlue
                Case 19
                    color = "A0522D"    'Sienna
                Case 20
                    color = "D2691E"    'Chocolate
                Case 21
                    color = "BDB76B"    'DarkKhaki
                Case 22
                    color = "BC8F8F"    'RosyBrown
                Case 23
                    color = "8FBC8F"    'DarkSeaGreen
                Case 24
                    color = "9D080D"
                Case 25
                    color = "FFFFFF"    'White
                Case 26
                    color = "FF1493"
                Case 27
                    color = "BF3EFF"
                Case 28
                    color = "A1D8E5"
                Case 29
                    color = "FCFDF2"
                Case 30
                    color = "333333"
                Case 31
                    color = "FA334F"
                Case 32
                    color = "1C2129"
                Case 33
                    color = "242523"
                Case 34
                    color = "2E2F32"
                Case 35
                    color = "B2950B"
                Case 36
                    color = "FF8484"
                Case 37
                    color = "FF4C4C"
                Case 38
                    color = "B413EC"
                Case 39
                    color = "98F5FF"
                Case 40
                    color = "86458D"
                Case 41
                    color = "70018B"
                Case 42
                    color = "193117"
                Case 43
                    color = "CB9CD4"
                Case 44
                    color = "7D6199"
                Case 45
                    color = "96D72D"
                Case 46
                    color = "FFAAA9"
                Case 47
                    color = "D9DAF2"
                Case 48
                    color = "FE9A76"
                Case 49
                    color = "802C96"
                Case 50
                    color = "37007E"
                Case 51
                    color = "6666FF"
                Case 52
                    color = "323299"
                Case 53
                    color = "FFE1FF"
                Case 54
                    color = "FFDAB9"
                Case 55
                    color = "9AFF9A"
                Case 56
                    color = "DB7093"
                Case 57
                    color = "FFE4B5"
                Case 58
                    color = "FFE4E1"
                Case 59
                    color = "B03060"
                Case 60
                    color = "FFA07A"
                Case 61
                    color = "FFEC8B"
                Case 62
                    color = "FF6A6A"
                Case 63
                    color = "FFD700"
                Case 64
                    color = "FFFAF0"
                Case Else
                    color = "000000"    'Black
            End Select

            GetColor = color
        End Function
    End Module
End Namespace
