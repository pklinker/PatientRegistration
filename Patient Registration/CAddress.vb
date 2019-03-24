Imports System.Data.OleDb

''' <summary>
''' Holds an address.
''' Paul Klinker
''' </summary>
''' <remarks></remarks>
Public Class CAddress
    Inherits CDbHelper
    Private mAddress1 As String
    Private mAddress2 As String
    Private mCity As String
    Private mState As String
    Private mZip As String
    Private mstrCellPhone As String
    Private mstrHomePhone As String
    Private mPatientID As Integer
    Private mAddressID As Integer
    Public Const ADDRESS_TABLE As String = "Address"
    Public Const SELECT_STATEMENT As String = "SELECT * from " + ADDRESS_TABLE

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="dbconn"></param>
    ''' <remarks></remarks>
    Public Sub New(ByRef dbconn As OleDbConnection)
        MyBase.New(dbconn, SELECT_STATEMENT, ADDRESS_TABLE)
        mAddress1 = ""
        mAddress2 = ""
        mCity = ""
        mState = ""
        mZip = ""
    End Sub

    ''' <summary>
    ''' Load the addresses from the database
    ''' </summary>
    ''' <param name="intPatientId">The ID of the patient whose addresses will be retrieved</param>
    ''' <remarks></remarks>
    Public Sub LoadAddress(ByVal intPatientId As Integer)
        mPatientID = intPatientId
        Dim cmd As New OleDbCommand("Select ID, Address1, Address2, City, Zip, State, HomePhone, CellPhone FROM " & ADDRESS_TABLE & " WHERE PatientID=" & intPatientId, mDbConn)
        mDbConn.Open()
        Dim myReader As OleDbDataReader = cmd.ExecuteReader()
        Try

            ' assume only one row
            While myReader.Read()
                mAddressID = myReader.GetInt32(0)
                If Not IsDBNull(myReader.Item(1)) Then
                    Address1 = myReader.GetString(1)

                End If
                If Not IsDBNull(myReader.Item(2)) Then
                    Address2 = myReader.GetString(2)
                End If

                If Not IsDBNull(myReader.Item(3)) Then
                    City = myReader.GetString(3)
                End If
                If Not IsDBNull(myReader.Item(4)) Then
                    Zip = myReader.GetString(4)
                End If
                If Not IsDBNull(myReader.Item(5)) Then
                    State = myReader.GetString(5)
                End If
                If Not IsDBNull(myReader.Item(6)) Then
                    HomePhoneNumber = myReader.GetString(6)
                End If
                If Not IsDBNull(myReader.Item(7)) Then
                    CellPhoneNumber = myReader.GetString(7)
                End If

            End While
        Catch ex As Exception
        Finally
            myReader.Close()
            mDbConn.Close()

        End Try

    End Sub

#Region "CRUD Operations"
    ''' <summary>
    ''' Add an address to the database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Add()
        Dim objAdapter As OleDb.OleDbDataAdapter

        Dim objDR As DataRow
        Dim objBuild As OleDbCommandBuilder
        'create a new data row from teh dataset
        objDR = objDataSet.Tables(ADDRESS_TABLE).NewRow()
        objDR.BeginEdit()
        'load new record data into the row
        objDR("ID") = 0
        FillRow(objDR)
        objDR.EndEdit()
        Try
            objDataSet.Tables(ADDRESS_TABLE).Rows.Add(objDR)
            objAdapter = New OleDbDataAdapter(SELECT_STATEMENT, mDbConn)
            objBuild = New OleDbCommandBuilder(objAdapter)
            objAdapter.InsertCommand = objBuild.GetInsertCommand
            'submit insert statment through the addapter
            objAdapter.Update(objDataSet, ADDRESS_TABLE)
            objDataSet.AcceptChanges()
            objAdapter.InsertCommand.Connection.Close()

        Catch ex As Exception
        Finally

        End Try
    End Sub

    ''' <summary>
    ''' Update an address in the database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Update()
        Dim objAdapter As OleDb.OleDbDataAdapter
        Dim objBuild As OleDb.OleDbCommandBuilder
        Dim objDR As DataRow
        ' Find rows to update
        objDR = objDataSet.Tables(ADDRESS_TABLE).Rows.Find(mAddressID)
        ' Begin the editing process
        objDR.BeginEdit()
        objDR("ID") = mAddressID
        FillRow(objDR)
        objDR.EndEdit()
        Try
            objAdapter = New OleDb.OleDbDataAdapter(SELECT_STATEMENT, mDbConn)
            objBuild = New OleDb.OleDbCommandBuilder(objAdapter)
            objAdapter.UpdateCommand = objBuild.GetUpdateCommand

            ' submit UPDATE statement through Adapter
            objAdapter.Update(objDataSet, ADDRESS_TABLE)
            ' Tell DataSet changes to data source are complete
            objDataSet.AcceptChanges()
            ' Close the connection
            objAdapter.UpdateCommand.Connection.Close()


        Catch ex As Exception
            MsgBox(ex)
        Finally


        End Try

    End Sub

    ''' <summary>
    ''' Delete address from the database.
    ''' </summary>
    ''' <param name="objDataSet"></param>
    ''' <remarks></remarks>
    Public Overloads Sub Delete(ByRef objDataSet As DataSet)

        Try
            MyBase.Delete(ADDRESS_TABLE, SELECT_STATEMENT, CStr(mAddressID))

        Catch ex As Exception
        Finally

        End Try
    End Sub

    ''' <summary>
    ''' Fills the object row with the address information.
    ''' </summary>
    ''' <param name="objDR"></param>
    ''' <remarks></remarks>
    Private Sub FillRow(ByRef objDR As DataRow)
        objDR("Address1") = Address1
        objDR("Address2") = Address2
        objDR("City") = City
        objDR("State") = State
        objDR("Zip") = Zip
        objDR("PatientID") = mPatientID
        objDR("HomePhone") = HomePhoneNumber
        objDR("CellPhone") = CellPhoneNumber
    End Sub
#End Region

#Region "Properties"
    Public Property Address1 As String
        Get
            Return mAddress1
        End Get
        Set(ByVal value As String)
            mAddress1 = value
        End Set
    End Property
    Public Property Address2 As String
        Get
            Return mAddress2
        End Get
        Set(ByVal value As String)
            mAddress2 = value
        End Set
    End Property
    Public Property City As String
        Get
            Return mCity
        End Get
        Set(ByVal value As String)
            mCity = value
        End Set
    End Property
    Public Property State As String
        Get
            Return mState
        End Get
        Set(ByVal value As String)
            mState = value
        End Set
    End Property
    Public Property Zip As String
        Get
            Return mZip
        End Get
        Set(ByVal value As String)
            mZip = value
        End Set
    End Property
    Property HomePhoneNumber As String
        Get
            Return mstrHomePhone
        End Get
        Set(ByVal value As String)
            mstrHomePhone = value
        End Set
    End Property
    Property CellPhoneNumber As String
        Get
            Return mstrCellPhone
        End Get
        Set(ByVal value As String)
            mstrCellPhone = value
        End Set
    End Property
    Public Property PatientID As Integer
        Get
            Return mPatientID
        End Get
        Set(ByVal value As Integer)
            mPatientID = value
        End Set
    End Property
#End Region
End Class
