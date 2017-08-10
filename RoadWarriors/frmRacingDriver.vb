Public Class frmRacingDriver
    ''
    Dim objConstants As New Constants()
    Dim objRacingDriver As New RacingDriver()

#Region "Main Controls"
    Private Sub frmRacingDrivers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''call the generate membershipnumber when the form loads
        txtMembershipNo.Text = objRacingDriver.getMembershipNumber(dteBirthDate:=dteDateofBirth.Value)

        ''load all racing driver records on form load
        dgvRacingDrivers.DataSource = objRacingDriver.getRacingDrivers()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        ''call the getExit method 
        objConstants.getExit(exitProgram:=CStr(True))
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ''

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ''

    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        ''

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ''

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ''

    End Sub


    Private Sub dgvRacingDrivers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRacingDrivers.CellContentClick
        ''

    End Sub

    Private Sub dteDateofBirth_ValueChanged(sender As Object, e As EventArgs) Handles dteDateofBirth.ValueChanged
        ''call the generate membershipnumber when date of birth changes
        txtMembershipNo.Text = objRacingDriver.getMembershipNumber(dteBirthDate:=dteDateofBirth.Value)
    End Sub
#End Region

#Region "File Menu STrip"
    Private Sub LoadAllDriversToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadAllDriversToolStripMenuItem.Click
        ''load all racing driver records
        dgvRacingDrivers.DataSource = objRacingDriver.getRacingDrivers()

    End Sub

    Private Sub ResetFieldsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetFieldsToolStripMenuItem.Click
        ''

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        ''call the getExit method 
        objConstants.getExit(exitProgram:=CStr(True))
    End Sub
#End Region

#Region "Edit Menu Strip"
    Private Sub CreateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateToolStripMenuItem.Click
        ''

    End Sub

    Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateToolStripMenuItem.Click
        ''

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        ''

    End Sub
#End Region

#Region "View Menu Strip"
    Private Sub RacingDriversToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RacingDriversToolStripMenuItem.Click
        ''

    End Sub

    Private Sub RacingEventsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RacingEventsToolStripMenuItem.Click
        ''show the racing events form
        frmRacingEvents.Show()
        Me.Hide()
    End Sub

    Private Sub EventsPerfomanceResultsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EventsPerfomanceResultsToolStripMenuItem.Click
        ''show the events results form
        frmEventsResults.Show()
        Me.Hide()
    End Sub
#End Region

#Region "Help Menu Strip"
    Private Sub ViewHelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewHelpToolStripMenuItem.Click
        '' 

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        ''

    End Sub

#End Region
End Class