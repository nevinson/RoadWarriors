Imports System.Data.OleDb
Imports System.IO

Public Class RacingEvent
    ''
    Private strEventTitle As String
    Private dteEventDate As DateTime
    Private decRegistrationFee As Decimal
    Private strEventLocation As String
    Private intNumberOfLaps As Integer

    Private objConstants As New Constants()

#Region "Properties"
    Public Property EventTitle() As String
        Get
            Return strEventTitle
        End Get
        Set(ByVal value As String)
            strEventTitle = value
        End Set
    End Property

    Public Property EventDate() As System.DateTime
        Get
            Return dteEventDate
        End Get
        Set(ByVal value As System.DateTime)
            dteEventDate = value
        End Set
    End Property

    Public Property RegistrationFee() As Decimal
        Get
            Return decRegistrationFee
        End Get
        Set(ByVal value As Decimal)
            decRegistrationFee = value
        End Set
    End Property

    Public Property EventLocation() As String
        Get
            Return strEventLocation
        End Get
        Set(ByVal value As String)
            strEventLocation = value
        End Set
    End Property

    Public Property NumberOfLaps() As Integer
        Get
            Return intNumberOfLaps
        End Get
        Set(ByVal value As Integer)
            intNumberOfLaps = value
        End Set
    End Property
#End Region

#Region "CRUD Methods"
    Public Function getRacingEvents() As DataTable
        ''
        Dim dbCon As New OleDbConnection()
        Dim dbDA As New OleDbDataAdapter()
        Dim dbDS As New DataSet()

        Try
            dbCon.ConnectionString = objConstants.ConnectionString()

            dbCon.Open()

            Dim dbCmd As New OleDbCommand("SELECT * FROM [RacingEvents.csv]", dbCon)

            dbDA.SelectCommand = dbCmd
            dbDA.Fill(dbDS)
            dbDA.Dispose()
        Catch ex As Exception
            MessageBox.Show("Cannot access data file:" + ex.Message, "Data Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbCon.Close()
        End Try

        Return dbDS.Tables(0)
    End Function

    Public Function Create(ByRef strMsg As String) As Boolean
        ''
        Dim blnResult As Boolean = False
        Dim strLine As String = ""

        If File.Exists(objConstants.RacingEventsFileLocation()) Then
            Try
                Dim objWriter As StreamWriter = File.AppendText(objConstants.RacingEventsFileLocation())

                strLine = String.Format("{0}, {1}, {2}, {3}, {4}", EventTitle, EventDate, RegistrationFee, EventLocation, NumberOfLaps)

                objWriter.Write(strLine)
                objWriter.Write(Environment.NewLine)
                objWriter.Close()

                strMsg = "Record saved successfully!"
                blnResult = True

            Catch ex As Exception
                strMsg = ex.Message
                blnResult = False
            End Try
        Else
            strMsg = "Racing events data file does not exist."
            blnResult = False
        End If

        Return blnResult
    End Function

    Public Function Update(ByRef strMsg As String) As Boolean
        ''
        Dim blnResult As Boolean = False
        Dim dbCon As New OleDbConnection()
        Dim dbDA As New OleDbDataAdapter()
        Dim dbDS As New DataSet()

        Try
            dbCon.ConnectionString = objConstants.ConnectionString()
            dbCon.Open()

            Dim dbCmd As New OleDbCommand("UPDATE [RacingDrivers.csv] SET EventDate=@date, RegistrationFee=@fee, EventLocation=@location, NumberOfLaps=@laps WHERE EventTitle=@title", dbCon)

            dbCmd.Parameters.AddWithValue("@date", EventDate)
            dbCmd.Parameters.AddWithValue("@fee", RegistrationFee)
            dbCmd.Parameters.AddWithValue("@location", EventLocation)
            dbCmd.Parameters.AddWithValue("@laps", NumberOfLaps)
            dbCmd.Parameters.AddWithValue("@title", EventTitle)

            Dim res As Integer = dbCmd.ExecuteNonQuery()
            If res = 1 Then
                strMsg = "Record updated successfully!"
                blnResult = True
            Else
                strMsg = "Error: Record not updated!"
                blnResult = False
            End If
        Catch ex As Exception
            MessageBox.Show("Cannot access data file:" + ex.Message, "Data Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbCon.Close()
        End Try

        Return blnResult
    End Function

    Public Function Search(ByVal strSearch As String, ByRef strMsg As String) As DataTable
        ''
        Dim dbCon As New OleDbConnection()
        Dim dbDA As New OleDbDataAdapter()
        Dim dbDS As New DataSet()

        Try
            dbCon.ConnectionString = objConstants.ConnectionString()
            dbCon.Open()

            Dim dbCmd As New OleDbCommand("SELECT * FROM [RacingEvents.csv] WHERE EventTitle=@title", dbCon)
            dbCmd.Parameters.AddWithValue("@title", strSearch)

            dbDA.SelectCommand = dbCmd
            dbDA.Fill(dbDS)
            dbDA.Dispose()
        Catch ex As Exception
            strMsg = ex.Message
        Finally
            dbCon.Close()
        End Try

        Return dbDS.Tables(0)
    End Function
#End Region
End Class
