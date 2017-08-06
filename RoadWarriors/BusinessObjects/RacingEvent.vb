Public Class RacingEvent
    ''
    Private strEventTitle As String
    Private dteEventDate As System.DateTime
    Private decRegistrationFee As Decimal
    Private strEventLocation As String
    Private intNumberOfLaps As Integer

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
        Return Nothing
    End Function

    Public Function Create(ByRef strMsg As String) As Boolean
        ''
        Return Nothing
    End Function

    Public Function Search(ByVal strSearch As String, ByRef strMsg As String) As DataTable
        ''
        Return Nothing
    End Function
#End Region
End Class
