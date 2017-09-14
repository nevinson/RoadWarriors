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
        If txtSearch.Text.Length > 13 And IsNumeric(txtSearch.Text) Then
            btnSearch.Enabled = True
        Else
            btnSearch.Enabled = False
        End If

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ''
        Dim dtResult As DataTable = Nothing
        Dim strSearch As String = txtSearch.Text
        Dim strMsg As String = Nothing

        ''
        dtResult = objRacingDriver.Search(strSearch:=strSearch, strMsg:=strMsg)

        ''
        If dtResult.Rows.Count > 0 Then
            MessageBox.Show(dtResult.Rows.Count & " record(s) found.", "Racing Driver: Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvRacingDrivers.DataSource = dtResult
        Else
            MessageBox.Show("Error: No racing driver exists of that name.", "Racing Driver: Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        ''
        Dim blnResponse As Boolean = False, strMsg As String = ""

        ''
        objRacingDriver.MembershipNumber = txtMembershipNo.Text
        objRacingDriver.Name = txtName.Text
        objRacingDriver.Surname = txtSurname.Text
        objRacingDriver.BirthDate = dteDateofBirth.Value
        If radFemale.Checked = True Then
            objRacingDriver.Gender = "Female"
        ElseIf radMale.Checked = True Then
            objRacingDriver.Gender = "Male"
        End If
        objRacingDriver.JoinDate = dteDateJoined.Value
        objRacingDriver.MembershipFeeOutstanding = txtOutstandingFee.Text

        ''
        blnResponse = objRacingDriver.Create(strMsg:=strMsg)
        If blnResponse = True Then
            MessageBox.Show(strMsg, "Racing Driver: Create", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show(strMsg, "Racing Driver: Create", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ''
        Dim blnResponse As Boolean = False, strMsg As String = ""

        ''
        objRacingDriver.MembershipNumber = txtMembershipNo.Text
        objRacingDriver.Name = txtName.Text
        objRacingDriver.Surname = txtSurname.Text
        objRacingDriver.BirthDate = dteDateofBirth.Value
        If radFemale.Checked = True Then
            objRacingDriver.Gender = "Female"
        ElseIf radMale.Checked = True Then
            objRacingDriver.Gender = "Male"
        End If
        objRacingDriver.JoinDate = dteDateJoined.Value
        objRacingDriver.MembershipFeeOutstanding = txtOutstandingFee.Text

        ''calling the create method
        blnResponse = objRacingDriver.Update(strMsg:=strMsg)
        If blnResponse = True Then
            MessageBox.Show(strMsg, "Racing Driver: Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show(strMsg, "Racing Driver: Update", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ''

    End Sub


    Private Sub dgvRacingDrivers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRacingDrivers.CellContentClick
        ''
        Dim i As Integer = 0

        i = dgvRacingDrivers.CurrentRow.Index

        txtMembershipNo.Text = CStr(dgvRacingDrivers.Item(1, i).Value)
        txtName.Text = CStr(dgvRacingDrivers.Item(2, i).Value)
        txtSurname.Text = CStr(dgvRacingDrivers.Item(3, i).Value)
        dteDateofBirth.Value = CDate(dgvRacingDrivers.Item(4, i).Value)
        If CStr(dgvRacingDrivers.Item(5, i).Value) = "Female" Then
            radFemale.Checked = True
        ElseIf CStr(dgvRacingDrivers.Item(5, i).Value) = "Male" Then
            radMale.Checked = True
        End If
        dteDateJoined.Value = CDate(dgvRacingDrivers.Item(6, i).Value)
        txtOutstandingFee.Text = CStr(dgvRacingDrivers.Item(7, i).Value)

        ''
        btnDelete.Enabled = True
        btnUpdate.Enabled = True
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