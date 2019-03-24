Imports System.Data.OleDb
''' <summary>
''' Holds the patient detail to make writing and updating easier
''' Paul Klinker
''' </summary>
''' <remarks></remarks>
Public Class CPatient
    Inherits CDbHelper

    Private mstrFirstName As String
    Private mstrMiddleName As String
    Private mstrLastName As String
    Private mstrTitle As String
    Private mstrSuffix As String
    Private mstrSsn As String
    Private mstrDob As String
    Private mstrGender As String
    Private mstrMaritalStatusID As String
    Private mstrPatientClassID As String
    Private mstrRaceID As String
    Private mstrReligionID As String
    Private mintPatientID As Integer
    Private mstrPlaceOfBirth As String
    Private mboolMultipleBirth As Boolean
    Private mintBirthOrder As Integer
    Private mPatientAddress As CAddress


#Region "Constants"
    Public Const PATIENT_TABLE As String = "Patient"
    Public Const SELECT_STATEMENT As String = "SELECT * from " + PATIENT_TABLE
    Public Const PATIENT_LAST_NAME_COLUMN As String = "LastName"
    Public Const PATIENT_FIRST_NAME_COLUMN As String = "FirstName"
    Public Const PATIENT_MIDDLE_NAME_COLUMN As String = "MiddleName"
    Public Const SEGMENT_HEADER As String = "PID"
#End Region

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="dbconn">Database connection</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef dbconn As OleDbConnection)
        MyBase.new(dbconn, SELECT_STATEMENT, PATIENT_TABLE)

    End Sub

    ''' <summary>
    ''' Load the patients from the database
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadPatients() As DataSet
        Dim objAdapter As OleDb.OleDbDataAdapter
        Dim patDataSet As DataSet = New DataSet()
        Dim strSQL As String = SELECT_STATEMENT & " ORDER BY " & PATIENT_LAST_NAME_COLUMN & ", " & PATIENT_FIRST_NAME_COLUMN
        Try
            objAdapter = New OleDbDataAdapter(strSQL, mDbConn)
            objAdapter.Fill(patDataSet, PATIENT_TABLE)
            With objDataSet.Tables(PATIENT_TABLE)
                .PrimaryKey = New DataColumn() {.Columns("ID")}

            End With
        Catch ex As Exception
        Finally

        End Try
        Return patDataSet

    End Function

    ''' <summary>
    ''' Loads the patient into a data row
    ''' </summary>
    ''' <param name="patientid">The ID of the patient who will be retrieved</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadPatient(ByVal patientid As Integer) As DataRow
        Dim patientData As DataRow
        patientData = objDataSet.Tables(PATIENT_TABLE).Rows.Find(patientid)
        Populate(patientData)
        Return patientData
    End Function

    Private Sub Populate(ByRef patientData As DataRow)
        PatientID = CInt(patientData.Item("ID")) 'required
        FirstName = CStr(patientData.Item("FirstName")) 'required
        If Not IsDBNull(patientData.Item("MiddleName")) Then
            MiddleName = CStr(patientData.Item("MiddleName"))
        Else
            MiddleName = ""
        End If

        LastName = CStr(patientData.Item("LastName")) 'required
        If Not IsDBNull(patientData.Item("Title")) Then
            Title = CStr(patientData.Item("Title"))
        Else
            Title = ""
        End If
        If Not IsDBNull(patientData.Item("Suffix")) Then
            Suffix = CStr(patientData.Item("Suffix"))
        Else
            Suffix = ""
        End If

        If Not IsDBNull(patientData.Item("DOB")) Then
            Dob = CStr(patientData.Item("DOB"))
        Else
            Dob = ""
        End If

        If Not IsDBNull(patientData.Item("PlaceOfBirth")) Then
            PlaceOfBirth = CStr(patientData.Item("PlaceOfBirth"))
        Else
            PlaceOfBirth = ""
        End If
        If Not IsDBNull(patientData.Item("Ssn")) Then
            Ssn = CStr(patientData.Item("Ssn"))
        Else
            Ssn = ""
        End If

        Dim multibirth As Boolean = CBool(patientData.Item("MultipleBirth"))

        If Not IsDBNull(patientData.Item("BirthOrder")) Then
            BirthOrder = CInt(patientData.Item("BirthOrder"))
        Else
            BirthOrder = 1
        End If
        If Not IsDBNull(patientData.Item("Gender")) Then
            Gender = CStr(patientData.Item("Gender"))
        End If
        If (Not IsDBNull(patientData.Item("MaritalStatusID"))) Then
            MaritalStatusID = CStr(patientData.Item("MaritalStatusID"))
        End If
        If Not IsDBNull(patientData.Item("RaceID")) Then
            RaceID = CStr(patientData.Item("RaceID"))
        End If
        If Not IsDBNull(patientData.Item("ReligionID")) Then
            ReligionID = CStr(patientData.Item("ReligionID"))
        End If
        mPatientAddress = New CAddress(mDbConn)
        mPatientAddress.LoadAddress(PatientID)
    End Sub

    ''' <summary>
    ''' Returns the PID segment
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSegment() As String
        Dim pid As String

        pid = "PID" + HL7.FieldSeparator + CStr(PatientID) + HL7.FieldSeparator + HL7.FieldSeparator + CStr(PatientID) + HL7.ComponentSeparator + HL7.ComponentSeparator
        pid += "HOSPITAL" + HL7.FieldSeparator + "20/" + Ssn + HL7.FieldSeparator + LastName + HL7.ComponentSeparator + FirstName + HL7.ComponentSeparator + MiddleName + HL7.ComponentSeparator + HL7.ComponentSeparator + HL7.ComponentSeparator
        pid += HL7.FieldSeparator + HL7.FieldSeparator + CUtil.GetHL7FormattedDate(Dob) + HL7.FieldSeparator + Gender + HL7.FieldSeparator
        pid += HL7.FieldSeparator + RaceID + HL7.FieldSeparator
        pid += PatientAddress.Address1 + HL7.SubcomponentSeparator + PatientAddress.Address2 + HL7.ComponentSeparator + PatientAddress.City
        pid += HL7.ComponentSeparator + PatientAddress.State + HL7.ComponentSeparator + PatientAddress.Zip
        pid += HL7.FieldSeparator + HL7.FieldSeparator + HL7.FieldSeparator + HL7.FieldSeparator + MaritalStatusID
        pid += HL7.FieldSeparator + ReligionID + HL7.FieldSeparator + HL7.FieldSeparator + Ssn + HL7.FieldSeparator
        pid += HL7.FieldSeparator + HL7.FieldSeparator + PlaceOfBirth + HL7.FieldSeparator
        If MultipleBirth Then
            pid += "Y" + HL7.FieldSeparator + CStr(BirthOrder)
        Else
            pid += "N" + HL7.FieldSeparator
        End If
        pid += HL7.FieldSeparator
        '        Return "PID^557667^^557667\\AHLTA^20/111-11-1102^BTEST\BOB\\\\^^19450101^M^^^\\\\\^^^^^^^^111-11-1102^^^^^^^^\\\\\"
        Return pid
    End Function
#Region "CRUD Operations"
    ''' <summary>
    ''' Add a patient
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Add()
        Dim objAdapter As OleDb.OleDbDataAdapter

        Dim objDR As DataRow
        Dim objBuild As OleDbCommandBuilder
        'create a new data row from teh dataset
        objDR = objDataSet.Tables(PATIENT_TABLE).NewRow()
        objDR.BeginEdit()
        'load new record data into the row
        objDR("ID") = 0 'mPatientID
        FillRow(objDR)
        objDR.EndEdit()
        Try
            objDataSet.Tables(PATIENT_TABLE).Rows.Add(objDR)
            objAdapter = New OleDbDataAdapter(SELECT_STATEMENT, mDbConn)
            objBuild = New OleDbCommandBuilder(objAdapter)
            objAdapter.InsertCommand = objBuild.GetInsertCommand
            'submit insert statment through the addapter
            objAdapter.Update(objDataSet, PATIENT_TABLE)
            objDataSet.AcceptChanges()
            objAdapter.InsertCommand.Connection.Close()
            mDbConn.Open()
            Dim cmdNewID As New OleDbCommand("SELECT max(ID) from " & PATIENT_TABLE, mDbConn)
            PatientID = CInt(cmdNewID.ExecuteScalar)
            objDR("ID") = PatientID

        Catch ex As Exception
        Finally
            mDbConn.Close()
        End Try
    End Sub
    ''' <summary>
    ''' Update patient
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Update()
        Dim objAdapter As OleDb.OleDbDataAdapter
        Dim objBuild As OleDb.OleDbCommandBuilder
        Dim objDR As DataRow
        ' Find rows to update
        objDR = objDataSet.Tables(PATIENT_TABLE).Rows.Find(PatientID)
        ' Begin the editing process
        objDR.BeginEdit()
        objDR("ID") = PatientID
        FillRow(objDR)
        objDR.EndEdit()
        Try
            objAdapter = New OleDb.OleDbDataAdapter(SELECT_STATEMENT, mDbConn)
            objBuild = New OleDb.OleDbCommandBuilder(objAdapter)
            objAdapter.UpdateCommand = objBuild.GetUpdateCommand

            ' submit UPDATE statement through Adapter
            objAdapter.Update(objDataSet, PATIENT_TABLE)
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
    ''' Delete patient
    ''' </summary>
    ''' <param name="objDataSet"></param>
    ''' <remarks></remarks>
    Public Overloads Sub Delete(ByRef objDataSet As DataSet)

        Try
            MyBase.Delete(PATIENT_TABLE, SELECT_STATEMENT, CStr(PatientID))

        Catch ex As Exception
        Finally

        End Try
    End Sub

    ''' <summary>
    ''' Fills the row with the patient information.
    ''' </summary>
    ''' <param name="objDR"></param>
    ''' <remarks></remarks>
    Private Sub FillRow(ByRef objDR As DataRow)
        objDR("FirstName") = FirstName
        objDR("MiddleName") = MiddleName
        objDR("LastName") = LastName
        objDR("Title") = Title
        objDR("Suffix") = Suffix
        objDR("Ssn") = Ssn
        objDR("Dob") = Dob
        objDR("Gender") = Gender
        objDR("PlaceOfBirth") = PlaceOfBirth
        objDR("BirthOrder") = BirthOrder
        If MultipleBirth Then
            objDR("MultipleBirth") = 1
        Else
            objDR("MultipleBirth") = 0
        End If

        objDR("MaritalStatusID") = MaritalStatusID
        objDR("PatientClassID") = PatientClassID
        objDR("RaceID") = RaceID
        objDR("ReligionID") = ReligionID

    End Sub
#End Region
#Region "Properties"
    Public Property FirstName As String
        Get
            Return mstrFirstName

        End Get
        Set(ByVal value As String)
            mstrFirstName = value
        End Set
    End Property
    Public Property MiddleName As String
        Get
            Return mstrMiddleName
        End Get
        Set(ByVal value As String)
            mstrMiddleName = value
        End Set
    End Property
    Public Property LastName As String
        Get
            Return mstrLastName
        End Get
        Set(ByVal value As String)
            mstrLastName = value
        End Set
    End Property
    Public Property Title As String
        Get
            Return mstrTitle
        End Get
        Set(ByVal value As String)
            mstrTitle = value
        End Set
    End Property
    Public Property Suffix As String
        Get
            Return mstrSuffix
        End Get
        Set(ByVal value As String)
            mstrSuffix = value
        End Set
    End Property
    Public Property Ssn As String
        Get
            Return mstrSsn
        End Get
        Set(ByVal value As String)
            mstrSsn = value
        End Set
    End Property
    Public Property Dob As String
        Get
            Return mstrDob
        End Get
        Set(ByVal value As String)
            mstrDob = value
        End Set
    End Property
    Public Property Gender As String
        Get
            Return mstrGender
        End Get
        Set(ByVal value As String)
            mstrGender = value
        End Set
    End Property
    Public Property MaritalStatusID As String
        Get
            Return mstrMaritalStatusID
        End Get
        Set(ByVal value As String)
            mstrMaritalStatusID = value
        End Set
    End Property
    Public Property PatientClassID As String
        Get
            Return mstrPatientClassID
        End Get
        Set(ByVal value As String)
            mstrPatientClassID = value
        End Set
    End Property
    Public Property RaceID As String
        Get
            Return mstrRaceID
        End Get
        Set(ByVal value As String)
            mstrRaceID = value
        End Set
    End Property
    Public Property ReligionID As String
        Get
            Return mstrReligionID
        End Get
        Set(ByVal value As String)
            mstrReligionID = value
        End Set
    End Property
    Public Property PatientID As Integer
        Get
            Return mintPatientID
        End Get
        Set(ByVal value As Integer)
            mintPatientID = value
        End Set
    End Property
    Public Property PlaceOfBirth As String
        Get
            Return mstrPlaceOfBirth
        End Get
        Set(ByVal value As String)
            mstrPlaceOfBirth = value
        End Set
    End Property
    Public Property MultipleBirth As Boolean
        Get
            Return mboolMultipleBirth
        End Get
        Set(ByVal value As Boolean)
            mboolMultipleBirth = value
        End Set
    End Property
    Public Property BirthOrder As Integer
        Get
            Return mintBirthOrder
        End Get
        Set(ByVal value As Integer)
            mintBirthOrder = value
        End Set
    End Property
    Property PatientAddress As CAddress
        Get
            Return mPatientAddress
        End Get
        Set(ByVal value As CAddress)
            mPatientAddress = value
        End Set
    End Property

#End Region
End Class
