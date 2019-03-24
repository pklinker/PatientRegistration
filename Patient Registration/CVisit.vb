Imports System.Data.OleDb
''' <summary>
''' Patient visit.
''' 
''' The PV1 segment is used by Registration/Patient Administration 
''' applications to communicate information on an account or 
''' visit-specific basis.  The default is to send account level data. To use 
''' this segment for visit level data PV1-51 - Visit Indicator must be valued 
''' to “V”. The value of PV-51 affects the level of data be-ing sent on the 
''' PV1, PV2, and any other segments that are part of the associated PV1 
''' hierarchy (e.g. ROL, DG1, or OBX).
'''
''' The facility ID, the optional fourth component of each patient location 
''' field, is a HD data type that is uni-quely associated with the healthcare 
''' facility containing the location.  A given institution, or group of 
''' inter-communicating institutions, should establish a list of facilities
''' that may be potential assignors of patient lo-cations.  The list will be 
''' one of the institution’s master dictionary lists.  Since third parties other
'''  than the as-signors of patient locations may send or receive HL7 messages 
''' containing patient locations, the facility ID in the patient location may 
''' not be the same as that implied by the sending and receiving systems 
''' identified in the MSH.  The facility ID must be unique across facilities 
''' at a given site.  This field is required for HL7 implementations that have 
''' more than a single healthcare facility with bed locations, since the same 
''' 'point of care' ^ 'room' ^ 'bed' combination may exist at more than one 
''' facility.
''' </summary>
''' <remarks></remarks>
Public Class CVisit
    Inherits CAdmission

#Region "Used PV1 Elements"
    Private mPatientClass As String
    Private mAdmissionType As String
    Private mHospitalService As String
    Private mAdmitSource As String
    Private mAmbulatoryStatus As String
#End Region


#Region "Constants"
    Public Const JOINED_SELECT_STATEMENT As String =
    "SELECT Visit.*, AdmissionType.*, AdmitSource.*, AmbulatoryStatus.*, HospitalService.*, PatientClass.* " &
"FROM PatientClass INNER JOIN (HospitalService INNER JOIN (AmbulatoryStatus INNER JOIN (AdmitSource INNER JOIN (AdmissionType INNER JOIN " &
    "Visit ON AdmissionType.ID = Visit.AdmissionTypeID) ON AdmitSource.ID = Visit.AdmitSourceID) ON AmbulatoryStatus.ID = " &
    "Visit.AmbulatoryStatusID) ON HospitalService.ID = Visit.HospitalServiceID) ON PatientClass.ID = Visit.PatientClassID"

#End Region

    ''' <summary>
    ''' Constructor 
    ''' </summary>
    ''' <param name="dbconn"></param>
    ''' <remarks></remarks>
    Public Sub New(ByRef dbconn As OleDbConnection)
        MyBase.new(dbconn, JOINED_SELECT_STATEMENT, VISIT_TABLE, "Visit.ID")

    End Sub

    ''' <summary>
    ''' Load the visits from the database
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadVisits(ByVal patientid As Integer) As DataSet
        Dim objAdapter As OleDb.OleDbDataAdapter
        Dim visitDataSet As DataSet = New DataSet()
        Dim strSQL As String = SELECT_STATEMENT & " WHERE (((Visit.PatientID)=" & patientid & "))"
        Try
            objAdapter = New OleDbDataAdapter(strSQL, mDbConn)
            objAdapter.Fill(visitDataSet, VISIT_TABLE)
            With objDataSet.Tables(VISIT_TABLE)
                .PrimaryKey = New DataColumn() {.Columns("Visit.ID")}

            End With
        Catch ex As Exception
        Finally

        End Try
        Return visitDataSet

    End Function

    ''' <summary>
    ''' Loads the visit into a data row
    ''' </summary>
    ''' <param name="visitid">The ID of the visit that will be retrieved</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadVisit(ByVal visitid As Integer) As DataRow
        Dim visitData As DataRow
        Dim keys(1) As DataColumn
        Dim column As DataColumn = New DataColumn()
        column.ColumnName = "Visit.ID"
        keys(0) = objDataSet.Tables(VISIT_TABLE).Columns("Visit.ID")
        objDataSet.Tables(VISIT_TABLE).PrimaryKey = keys
        visitData = objDataSet.Tables(VISIT_TABLE).Rows.Find(visitid)
        Populate(visitData)
        Return visitData
    End Function

    Private Sub Populate(ByRef visitData As DataRow)
        mPatientID = CInt(visitData.Item("Visit.ID"))
        mPatientClassID = CStr(visitData.Item("PatientClassID"))
        mAdmissionTypeID = CStr(visitData.Item("AdmissionTypeID"))
        mHospitalServiceID = CStr(visitData.Item("HospitalServiceID"))
        mAdmitSourceID = CInt(visitData.Item("AdmitSourceID"))
        mAmbulatoryStatusID = CStr(visitData.Item("AmbulatoryStatusID"))
        mPatientClass = CStr(visitData.Item("Class"))
        mAdmissionType = CStr(visitData.Item("AdmitReason"))
        mHospitalService = CStr(visitData.Item("Service"))
        mAdmitSource = CStr(visitData.Item("AdmitSource"))
        mAmbulatoryStatus = CStr(visitData.Item("Status"))
        If Not IsDBNull(visitData.Item("AdmitDate")) Then
            mAdmitDate = CStr(visitData.Item("AdmitDate"))
        Else
            mAdmitDate = ""
        End If

        If Not IsDBNull(visitData.Item("DischargeDate")) Then
            mDischargeDate = CStr(visitData.Item("DischargeDate"))
        Else
            mDischargeDate = ""
        End If
        If Not IsDBNull(visitData.Item("AttendingDoctor")) Then
            mAttendingDoctor = CInt(visitData.Item("AttendingDoctor"))
        Else
            mAttendingDoctor = 0
        End If

        If Not IsDBNull(visitData.Item("ReferringDocLastName")) Then
            mReferringDocLastName = CStr(visitData.Item("ReferringDocLastName"))
        Else
            mReferringDocLastName = ""
        End If

        If Not IsDBNull(visitData.Item("ReferringDocFirstName")) Then
            mReferringDocFirstName = CStr(visitData.Item("ReferringDocFirstName"))
        Else
            mReferringDocFirstName = ""
        End If

        If Not IsDBNull(visitData.Item("PatientID")) Then
            mPatientID = CInt(visitData.Item("PatientID"))
        Else
            mPatientID = 0
        End If

    End Sub

#Region "CRUD Operations"
    ''' <summary>
    ''' Add a visit to the database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Add2()
        Dim objAdapter As OleDb.OleDbDataAdapter

        Dim objDR As DataRow
        Dim objBuild As OleDbCommandBuilder
        'create a new data row from teh dataset
        objDR = objDataSet.Tables(VISIT_TABLE).NewRow()
        objDR.BeginEdit()
        'load new record data into the row
        objDR("Visit.ID") = 0 '
        FillRow(objDR)
        objDR.EndEdit()
        Try
            objDataSet.Tables(VISIT_TABLE).Rows.Add(objDR)
            objAdapter = New OleDbDataAdapter(SELECT_STATEMENT, mDbConn)
            objBuild = New OleDbCommandBuilder(objAdapter)
            objAdapter.InsertCommand = objBuild.GetInsertCommand
            'submit insert statment through the addapter
            objAdapter.Update(objDataSet, VISIT_TABLE)
            objDataSet.AcceptChanges()
            objAdapter.InsertCommand.Connection.Close()

        Catch ex As Exception
        Finally

        End Try
    End Sub

    ''' <summary>
    ''' Update the visit to the database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Sub Update()
        Dim objAdapter As OleDb.OleDbDataAdapter
        Dim objBuild As OleDb.OleDbCommandBuilder
        Dim objDR As DataRow
        Dim intId As Integer
        ' Find rows to update
        objDR = objDataSet.Tables(VISIT_TABLE).Rows.Find(intId)
        ' Begin the editing process
        objDR.BeginEdit()
        objDR("ID") = mVisitID
        FillRow(objDR)
        objDR.EndEdit()
        Try
            objAdapter = New OleDb.OleDbDataAdapter(SELECT_STATEMENT, mDbConn)
            objBuild = New OleDb.OleDbCommandBuilder(objAdapter)
            objAdapter.UpdateCommand = objBuild.GetUpdateCommand

            ' submit UPDATE statement through Adapter
            objAdapter.Update(objDataSet, VISIT_TABLE)
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
    ''' Delete the visit from the database.
    ''' </summary>
    ''' <param name="objDataSet"></param>
    ''' <remarks></remarks>
    Public Overloads Sub Delete(ByRef objDataSet As DataSet)

        Try
            MyBase.Delete(VISIT_TABLE, SELECT_STATEMENT, CStr(mVisitID))

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

    End Sub
#End Region
#Region "Properties"
    Public Property PatientClass As String
        Get
            Return mPatientClass

        End Get
        Set(ByVal value As String)
            mPatientClass = value
        End Set
    End Property
    Public Property AdmissionType As String
        Get
            Return mAdmissionType
        End Get
        Set(ByVal value As String)
            mAdmissionType = value
        End Set
    End Property
    Public Property HospitalService As String
        Get
            Return mHospitalService

        End Get
        Set(ByVal value As String)
            mHospitalService = value
        End Set
    End Property
    Public Property AdmitSource As String
        Get
            Return mAdmitSource
        End Get
        Set(ByVal value As String)
            mAdmitSource = value
        End Set
    End Property
    Public Property AmbulatoryStatus As String
        Get
            Return mAmbulatoryStatus
        End Get
        Set(ByVal value As String)
            mAmbulatoryStatus = value
        End Set
    End Property
#End Region
End Class
