Public Class Constants

    Public Function RacingDriverFileLocation() As String
        ''
        Return Application.StartupPath & "/DataStorage/RacingDrivers.csv"
    End Function

    Public Function RacingEventsFileLocation() As String
        ''
        Return Application.StartupPath & "/DataStorage/RacingEvents.csv"
    End Function

    Public Function EventsResultsFileLocation() As String
        ''
        Return Application.StartupPath & "/DataStorage/EventsResults.csv"
    End Function

    Public Function ConnectionString() As String
        ''
        Return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "/DataStorage;Extended Properties='text;HDR=Yes;FMT=Delimited;CharacterSet=65001;'"
    End Function
End Class
