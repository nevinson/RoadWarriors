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
        Dim i As Integer = 0
        Try
            i = dgvRacingEvents.CurrentRow.Index

            txtTitle.Text = CStr(dgvRacingEvents.Item(1, i).Value)
            dteDateofEvent.Value = CDate(dgvRacingEvents.Item(2, i).Value)
            txtRegistrationFee.Text = CStr(dgvRacingEvents.Item(3, i).Value)
            txtEventLocation.Text = CStr(dgvRacingEvents.Item(4, i).Value)
            txtNumberofLaps.Text = CStr(dgvRacingEvents.Item(5, i).Value)

            ''
            btnDelete.Enabled = True
            btnUpdate.Enabled = True
        Catch ex As Exception

        End Try
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
        dtResult = objRacingEvent.Search(strSearch:=strSearch, strMsg:=strMsg)

        ''
        If dtResult.Rows.Count > 0 Then
            MessageBox.Show(dtResult.Rows.Count & " record(s) found.", "Racing Driver: Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvRacingEvents.DataSource = dtResult
        Else
            MessageBox.Show(String.Format("Error: {0}", strMsg), "Racing Driver: Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
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
        Dim blnResponse As Boolean = False, strMsg As String = ""

        ''
        objRacingEvent.EventTitle = txtTitle.Text
        objRacingEvent.EventDate = dteDateofEvent.Value
        objRacingEvent.RegistrationFee = txtRegistrationFee.Text
        objRacingEvent.EventLocation = txtEventLocation.Text
        objRacingEvent.NumberOfLaps = txtNumberofLaps.Text

        ''
        blnResponse = objRacingEvent.Update(strMsg:=strMsg)
        If blnResponse = True Then
            MessageBox.Show(strMsg, "Racing Event: Create", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show(strMsg, "Racing Event: Create", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ''
        Dim blnResponse As Boolean = False, strMsg As String = ""

        ''
        objRacingEvent.EventTitle = txtTitle.Text

        ''
        blnResponse = objRacingEvent.Update(strMsg:=strMsg)
        If blnResponse = True Then
            MessageBox.Show(strMsg, "Racing Event: Create", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show(strMsg, "Racing Event: Create", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
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