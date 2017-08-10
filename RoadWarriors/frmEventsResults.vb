Public Class frmEventsResults
    ''
    Dim objConstants As New Constants()
    Dim objEventResult As New EventResult()

#Region "Main Controls"
    Private Sub frmEventsResults_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        dgvEventResults.DataSource = objEventResult.getEventsResults()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        ''call the getExit method 
        objConstants.getExit(exitProgram:=CStr(True))
    End Sub

    Private Sub cmbRacerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRacerName.SelectedIndexChanged
        ''

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
#End Region

#Region "File Menu Strip"
    Private Sub ReloadResultsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReloadResultsToolStripMenuItem.Click
        ''

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        ''call the getExit method 
        objConstants.getExit(exitProgram:=CStr(True))
    End Sub
#End Region

#Region "Edit Menu Strip"

#End Region

#Region "View Menu Strip"
    Private Sub RacingDriversToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RacingDriversToolStripMenuItem.Click
        ''show the racing driver form
        frmRacingDriver.Show()
        Me.Hide()
    End Sub

    Private Sub RacingEventsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RacingEventsToolStripMenuItem.Click
        ''show the racing events form
        frmRacingEvents.Show()
        Me.Hide()
    End Sub

    Private Sub EventsPerfomanceResultsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EventsPerfomanceResultsToolStripMenuItem.Click
        ''

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