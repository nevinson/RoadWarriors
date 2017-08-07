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

    Public Sub getExit(ByRef exitProgram As String)
        ''A messagebox will be displayed, before the program closes
        exitProgram = CStr(MessageBox.Show("Are you sure you want to terminate the program?", "Terminate Program", MessageBoxButtons.YesNo, MessageBoxIcon.Question))

        If CDbl(exitProgram) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub
End Class
