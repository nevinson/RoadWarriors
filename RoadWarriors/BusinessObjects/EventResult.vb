Public Class EventResult
    ''
    Private strEventTitle As String
    Private strRacerName As String
    Private strRacerSurname As String
    Private intPosition As Integer
    Private dteEventDate As System.DateTime

#Region "Properties"
    Public Property EventTitle() As String
        Get
            Return strEventTitle
        End Get
        Set(ByVal value As String)
            strEventTitle = value
        End Set
    End Property

    Public Property RacerName() As String
        Get
            Return strRacerName
        End Get
        Set(ByVal value As String)
            strRacerName = value
        End Set
    End Property

    Public Property RacerSurname() As String
        Get
            Return strRacerSurname
        End Get
        Set(ByVal value As String)
            strRacerSurname = value
        End Set
    End Property

    Public Property Position() As Integer
        Get
            Return intPosition
        End Get
        Set(ByVal value As Integer)
            intPosition = value
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
#End Region

#Region "CRUD Methods"
    Public Function getEventsResults() As DataTable
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
