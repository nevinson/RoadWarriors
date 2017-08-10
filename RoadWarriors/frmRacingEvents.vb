Public Class frmRacingEvents
    ''
    Dim objConstants As New Constants()
    Dim objRacingEvent As New RacingEvent()

#Region "Main Controls"
    Private Sub frmRacingEvents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        dgvRacingEvents.DataSource = objRacingEvent.getRacingEvents()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        ''call the getExit method 
        objConstants.getExit(exitProgram:=CStr(True))

    End Sub

    Private Sub dgvRacingEvents_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRacingEvents.CellContentClick
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
        Dim blnResponse As Boolean = False, strMsg As String = ""

        ''
        objRacingEvent.EventTitle = txtTitle.Text
        objRacingEvent.EventDate = dteDateofEvent.Value
        objRacingEvent.RegistrationFee = txtRegistrationFee.Text
        objRacingEvent.EventLocation = txtEventLocation.Text
        objRacingEvent.NumberOfLaps = txtNumberofLaps.Text

        ''
        blnResponse = objRacingEvent.Create(strMsg:=strMsg)
        If blnResponse = True Then
            MessageBox.Show(strMsg, "Racing Event: Create", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show(strMsg, "Racing Event: Create", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ''

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ''

    End Sub
#End Region

#Region "File Menu Strip"
    Private Sub LoadAllEventsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadAllEventsToolStripMenuItem.Click
        ''
        dgvRacingEvents.DataSource = objRacingEvent.getRacingEvents()

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
        ''show the racing driver form
        frmRacingDriver.Show()
        Me.Hide()
    End Sub

    Private Sub RacingEventsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RacingEventsToolStripMenuItem.Click
        ''

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