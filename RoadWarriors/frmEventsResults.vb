Public Class frmEventsResults
    ''
    Dim objConstants As New Constants()
    Dim objEventResult As New EventResult()

#Region "Main Controls"
    Private Sub frmEventsResults_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        dgvEventResults.DataSource = objEventResult.getEventsResults()

        ''
        cmbEventTitle.DataSource = objEventResult.getEventsTitles()
        cmbEventTitle.ValueMember = "EventTitle"
        cmbEventTitle.DisplayMember = "EventTitle"

        ''
        cmbRacerName.DataSource = objEventResult.getRacerName()
        cmbRacerName.ValueMember = "Name"
        cmbRacerName.DisplayMember = "Name"
        MsgBox(objEventResult.getRacerNumber("Lerato"))
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
        If txtSearch.Text.Length < 3 Then
            btnSearch.Enabled = False
        Else
            btnSearch.Enabled = True
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ''
        Dim dtResult As DataTable = Nothing
        Dim strSearch As String = txtSearch.Text
        Dim strMsg As String = Nothing

        ''
        dtResult = objEventResult.Search(strSearch:=strSearch, strMsg:=strMsg)

        ''
        If dtResult.Rows.Count > 0 Then
            MessageBox.Show(dtResult.Rows.Count & " record(s) found.", "Racing Driver: Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvEventResults.DataSource = dtResult
        Else
            MessageBox.Show("Error: No racing driver exists of that name.", "Racing Driver: Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        ''
        Dim blnResponse As Boolean = False, strMsg As String = ""

        ''
        objEventResult.EventTitle = cmbEventTitle.SelectedValue
        objEventResult.RacerName = cmbRacerName.SelectedValue
        objEventResult.RacerSurname = txtRacerSurname.Text
        objEventResult.Position = txtPosition.Text
        objEventResult.EventDate = dteEventDate.Value

        blnResponse = objEventResult.Create(strMsg:=strMsg)
        If blnResponse = True Then
            MessageBox.Show(strMsg, "Events Results: Create", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show(strMsg, "Events Results: Create", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
#End Region

#Region "File Menu Strip"
    Private Sub ReloadResultsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReloadResultsToolStripMenuItem.Click
        ''
        dgvEventResults.DataSource = objEventResult.getEventsResults()
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