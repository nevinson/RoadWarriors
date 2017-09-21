Imports System.Data.OleDb
Imports System.IO

Public Class EventResult
    ''
    ''' <summary>
    ''' 
    ''' </summary>
    Private strEventTitle As String
    Private strRacerName As String
    Private strRacerSurname As String
    Private intPosition As Integer
    Private dteEventDate As System.DateTime

    Dim objConstants As New Constants()

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
        Dim dbCon As New OleDbConnection()
        Dim dbDA As New OleDbDataAdapter()
        Dim dbTable As New DataTable()

        Try
            dbCon.ConnectionString = objConstants.ConnectionString()
            dbCon.Open()

            Dim dbCmd As New OleDbCommand("SELECT * FROM EventResults", dbCon)

            dbTable.Load(dbCmd.ExecuteReader())
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Data Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbCon.Close()
        End Try

        Return dbTable
    End Function

    Public Function getEventsTitles() As DataTable
        ''
        Dim dbCon As New OleDbConnection()
        Dim dbDA As New OleDbDataAdapter()
        Dim dbDS As New DataSet()

        Try
            dbCon.ConnectionString = objConstants.ConnectionString()
            dbCon.Open()

            Dim dbCmd As New OleDbCommand("SELECT EventTitle FROM RacingEvents", dbCon)

            dbDA.SelectCommand = dbCmd
            dbDA.Fill(dbDS)
            dbDA.Dispose()
        Catch ex As Exception
            MessageBox.Show("Cannot access data file:" + ex.Message, "Data Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbCon.Close()
        End Try

        Return dbDS.Tables(0)
    End Function

    Public Function Create() As Boolean
        Dim blnResult As Boolean = False

        Dim dbCon As New OleDbConnection()
        Dim dbDA As New OleDbDataAdapter()
        Dim dbDS As New DataSet()

        Try
            dbCon.ConnectionString = objConstants.ConnectionString()
            dbCon.Open()

            Dim dbCmd As New OleDbCommand("INSERT INTO EventResults (EventTitle, RacerName, RacerSurname, Position, EventDate) VALUES (@title, @name, @surname, @position, @date)", dbCon)

            dbCmd.Parameters.AddWithValue("@title", EventTitle)
            dbCmd.Parameters.AddWithValue("@name", RacerName)
            dbCmd.Parameters.AddWithValue("@surname", RacerSurname)
            dbCmd.Parameters.AddWithValue("@position", Position)
            dbCmd.Parameters.AddWithValue("@date", EventDate)

            Dim res As Integer = dbCmd.ExecuteNonQuery()
            If res = 1 Then
                MessageBox.Show("Record saved successfully!")
                blnResult = True
            Else
                MessageBox.Show("Error: Record not saved!")
                blnResult = False
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.ToString(), "Data Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbCon.Close()
        End Try

        Return blnResult
    End Function

    Public Function Search(ByVal strSearch As String, ByRef strMsg As String) As DataTable
        Dim dbCon As New OleDbConnection()
        Dim dbDA As New OleDbDataAdapter()
        Dim dbDS As New DataSet()

        Try
            dbCon.ConnectionString = objConstants.ConnectionString()
            dbCon.Open()

            Dim dbCmd As New OleDbCommand("SELECT * FROM EventResults WHERE EventTitle=@title OR RacerName=@name", dbCon)
            dbCmd.Parameters.AddWithValue("@title", strSearch)
            dbCmd.Parameters.AddWithValue("@name", strSearch)

            dbDA.SelectCommand = dbCmd
            dbDA.Fill(dbDS)
            dbDA.Dispose()
        Catch ex As Exception
            strMsg = ex.Message
        Finally
            dbCon.Close()
        End Try

        Return dbDS.Tables(0)
    End Function

    Public Function dtEvents() As DataTable
        Dim dbCon As New OleDbConnection(), dbCmd As New OleDbCommand(), dtTable As New DataTable()

        With dbCon
            .ConnectionString = objConstants.ConnectionString()
            .Open()

            With dbCmd
                .Connection = dbCon
                .CommandText = "SELECT ﻿EventTitle FROM RacingEvents"

                dtTable.Load(.ExecuteReader())
            End With

            .Close()
        End With

        Return dtTable
    End Function

    Public Function dtRacerNames() As DataTable
        Dim dbCon As New OleDbConnection(), dbCmd As New OleDbCommand(), dtTable As New DataTable()

        With dbCon
            .ConnectionString = objConstants.ConnectionString()
            .Open()

            With dbCmd
                .Connection = dbCon
                .CommandText = "SELECT Name FROM RacingDrivers"

                dtTable.Load(.ExecuteReader())
            End With

            .Close()
        End With

        Return dtTable
    End Function

    Public Function getSurname(ByVal strName As String) As String
        Dim dbCon As New OleDbConnection(), dbCmd As New OleDbCommand(), dtTable As New DataTable()

        With dbCon
            .ConnectionString = objConstants.ConnectionString()
            .Open()

            With dbCmd
                .Connection = dbCon
                .CommandText = "SELECT Surname FROM RacingDrivers WHERE Name=@name"

                .Parameters.AddWithValue("@name", strName)

                dtTable.Load(.ExecuteReader())
            End With

            .Close()
        End With

        Return dtTable.Rows(0)("Surname").ToString()
    End Function
#End Region
End Class
