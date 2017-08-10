Imports System.Data.OleDb
Imports System.IO

Public Class RacingDriver
    ''
    Private strMembershipNumber As String
    Private strName As String
    Private strSurname As String
    Private dteBirthDate As DateTime
    Private strGender As String
    Private dteJoinDate As DateTime
    Private decOutstandingFee As Decimal

    Private objConstants As New Constants()

#Region "Properties"
    Public Property MembershipNumber() As String
        Get
            Return strMembershipNumber
        End Get
        Set(ByVal value As String)
            strMembershipNumber = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return strName
        End Get
        Set(ByVal value As String)
            strName = value
        End Set
    End Property

    Public Property Surname() As String
        Get
            Return strSurname
        End Get
        Set(ByVal value As String)
            strSurname = value
        End Set
    End Property

    Public Property BirthDate() As System.DateTime
        Get
            Return dteBirthDate
        End Get
        Set(ByVal value As System.DateTime)
            dteBirthDate = value
        End Set
    End Property

    Public Property Gender() As String
        Get
            Return strGender
        End Get
        Set(ByVal value As String)
            strGender = value
        End Set
    End Property

    Public Property JoinDate() As System.DateTime
        Get
            Return dteJoinDate
        End Get
        Set(ByVal value As System.DateTime)
            dteJoinDate = value
        End Set
    End Property

    Public Property MembershipFeeOutstanding() As Decimal
        Get
            Return decOutstandingFee
        End Get
        Set(ByVal value As Decimal)
            decOutstandingFee = value
        End Set
    End Property
#End Region

#Region "Membership Number Methods"
    Private Function MembershipNoExist(ByVal strMembershipNumber As String) As Boolean
        ''
        Dim dbCon As New OleDbConnection()
        Dim dbDA As New OleDbDataAdapter()
        Dim dbDS As New DataSet()
        Dim blResult As Boolean = False

        Try
            dbCon.ConnectionString = objConstants.ConnectionString()
            dbCon.Open()

            Dim dbCmd As New OleDbCommand("SELECT * FROM [RacingDrivers.csv] WHERE MembershipNumber=@memberNumber", dbCon)
            dbCmd.Parameters.AddWithValue("@memberNum", strMembershipNumber)

            dbDA.SelectCommand = dbCmd
            dbDA.Fill(dbDS)

            dbDA.Dispose()

            If dbDS.Tables(0).Rows.Count = 0 Then
                blResult = True
            Else
                blResult = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            dbCon.Close()
        End Try

        Return blResult
    End Function

    Public Function MemebershipNoValid(ByVal strMembershipNumber As String) As Boolean
        ''validate membership number and return a true/false
        Dim intTotal As Integer = 0
        Dim n As Integer = 0
        Dim r As Integer = 0

        For Each num In strMembershipNumber
            If Integer.TryParse(num, n) Then
                intTotal += n
            End If
        Next

        r = intTotal Mod 10

        If r = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function getMembershipNumber(ByVal dteBirthDate As Date) As String
        ''return the membership number
        Dim strNumber As String = Nothing
        Dim strMembershipNumber As String = Nothing

        strNumber = String.Format("{0}{1}{2}", getYear(), getBirthDate(dteBirthDate:=dteBirthDate), getRandom()) ''

        strMembershipNumber = strNumber & getCheckDigit(strNumber)

        Return strMembershipNumber
    End Function

    Private Function getCheckDigit(ByVal strNumber As String) As Integer
        ''calculate and return the check digit
        Dim intTotal As Integer = 0
        Dim n As Integer = 0
        Dim r As Integer = 0

        For Each num In strNumber
            If Integer.TryParse(num, n) Then
                intTotal += n
            End If
        Next

        r = intTotal Mod 10

        If r = 0 Then
            Return 0
        Else
            Return 10 - r
        End If
    End Function

    Private Function getRandom() As String
        ''generate and return a random number between 000 and 999
        Randomize()

        Dim intRandom As Integer = 0
        Dim strRandom As String = Nothing

        intRandom = CInt((999 * Rnd()) + 1)

        If intRandom.ToString().Length = 1 Then
            strRandom = String.Format("00{0}", intRandom.ToString())
        ElseIf intRandom.ToString().Length = 2 Then
            strRandom = String.Format("0{0}", intRandom.ToString())
        ElseIf intRandom.ToString().Length = 3 Then
            strRandom = intRandom.ToString()
        End If

        Return strRandom
    End Function

    Private Function getYear() As String
        ''return the current year's 2 rightmost digits
        Return DateTime.Now.ToString("yy")
    End Function

    Private Function getBirthDate(ByVal dteBirthDate As Date) As String
        ''format and return the birthdate 
        Return dteBirthDate.ToString("yyyyMMdd")
    End Function
#End Region

#Region "CRUD Method"
    Public Function getRacingDrivers() As DataTable
        ''
        Dim dbCon As New OleDbConnection()
        Dim dbDA As New OleDbDataAdapter()
        Dim dbDS As New DataSet()

        Try
            dbCon.ConnectionString = objConstants.ConnectionString()
            dbCon.Open()

            Dim dbCmd As New OleDbCommand("SELECT * FROM [RacingDrivers.csv]", dbCon)

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
        Return Nothing
    End Function

    Public Function Update(ByRef strMsg As String) As Boolean
        ''
        Return Nothing
    End Function

    Public Function Delete(ByRef strMsg As String) As Boolean
        ''
        Return Nothing
    End Function

    Public Function Search(ByVal strSearch As String, ByRef strMsg As String) As DataTable
        ''
        Return Nothing
    End Function
#End Region
End Class
