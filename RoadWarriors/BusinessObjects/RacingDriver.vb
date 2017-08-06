Public Class RacingDriver
    ''
    Private strMembershipNumber As String
    Private strName As String
    Private strSurname As String
    Private dteBirthDate As System.DateTime
    Private strGender As String
    Private dteJoinDate As System.DateTime
    Private decOutstandingFee As Decimal

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
        Return Nothing
    End Function

    Public Function MemebershipNoValid(ByVal strMembershipNumber As String) As Boolean
        ''
        Return Nothing
    End Function

    Public Function getMembershipNumber(ByVal dteBirthDate As Date) As String
        ''
        Return Nothing
    End Function

    Private Function getCheckDigit(ByVal strNumber As String) As Integer
        ''
        Return Nothing
    End Function

    Private Function getRandom() As String
        ''
        Return Nothing
    End Function

    Private Function getYear() As String
        ''
        Return Nothing
    End Function

    Private Function getBirthDate(ByVal dteBirthDate As Date) As String
        ''
        Return Nothing
    End Function
#End Region

#Region "CRUD Method"
    Public Function getRacingDrivers() As DataTable
        ''
        Return Nothing
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
