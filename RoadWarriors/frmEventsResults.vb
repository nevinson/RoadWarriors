Public Class frmEventsResults
    ''
    Dim objConstants As New Constants()
    Dim objEventResults As New EventResult()

#Region "Main Controls"
    Private Sub frmEventsResults_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        dgvEventResults.DataSource = objEventResults.getEventsResults()

        ''
        cmbEventTitle.ValueMember = "﻿EventTitle"
        cmbEventTitle.DataSource = objEventResults.dtEvents
        cmbEventTitle.SelectedIndex = -1

        cmbRacerName.ValueMember = "Name"
        cmbRacerName.DataSource = objEventResults.dtRacerNames
        cmbRacerName.SelectedIndex = 0
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        ''call the getExit method 
        objConstants.getExit(exitProgram:=CStr(True))
    End Sub

    Private Sub cmbRacerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRacerName.SelectedIndexChanged
        ''
        txtRacerSurname.Text = objEventResults.getSurname(cmbRacerName.SelectedValue)

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
        dtResult = objEventResults.Search(strSearch:=strSearch, strMsg:=strMsg)

        ''
        If dtResult.Rows.Count > 0 Then
            MessageBox.Show(dtResult.Rows.Count & " record(s) found.", "Event Results: Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvEventResults.DataSource = dtResult
        Else
            MessageBox.Show("Error: No racing driver exists of that name.", "Event Results: Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        ''
        Dim blnResponse As Boolean = False, strMsg As String = ""

        ''
        objEventResults.EventTitle = cmbEventTitle.SelectedValue
        objEventResults.RacerName = cmbRacerName.SelectedValue
        objEventResults.RacerSurname = txtRacerSurname.Text
        objEventResults.Position = txtPosition.Text
        objEventResults.EventDate = dteEventDate.Value

        blnResponse = objEventResults.Create()
        If blnResponse = True Then
            MessageBox.Show(strMsg, "Event Results: Create", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show(strMsg, "Event Results: Create", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
#End Region

#Region "File Menu Strip"
    Private Sub ReloadResultsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReloadResultsToolStripMenuItem.Click
        ''
        dgvEventResults.DataSource = objEventResults.getEventsResults()
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