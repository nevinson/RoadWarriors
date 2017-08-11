﻿Imports System.Data.OleDb
Imports System.IO

Public Class EventResult
    ''
    Private strEventTitle As String
    Private strRacerName As String
    Private strRacerSurname As String
    Private intPosition As Integer
    Private dteEventDate As System.DateTime

    Private objConstants As New Constants()

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
        ''
        Dim dbCon As New OleDbConnection()
        Dim dbDA As New OleDbDataAdapter()
        Dim dbDS As New DataSet()

        Try
            dbCon.ConnectionString = objConstants.ConnectionString()
            dbCon.Open()

            Dim dbCmd As New OleDbCommand("SELECT * FROM [EventResults.csv]", dbCon)

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

    Public Function getEventsTitles() As DataTable
        ''
        Dim dbCon As New OleDbConnection()
        Dim dbDA As New OleDbDataAdapter()
        Dim dbDS As New DataSet()

        Try
            dbCon.ConnectionString = objConstants.ConnectionString()
            dbCon.Open()

            Dim dbCmd As New OleDbCommand("SELECT EventTitle FROM [RacingEvents.csv]", dbCon)

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

    Public Function Create(ByRef strMsg As String) As Boolean
        ''
        Return Nothing
    End Function

    Public Function Search(ByVal strSearch As String, ByRef strMsg As String) As DataTable
        ''
        Return Nothing
    End Function
#End Region
End Class
