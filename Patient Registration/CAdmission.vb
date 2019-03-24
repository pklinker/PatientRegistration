Imports System.Data.OleDb

Public Class CAdmission
    Inherits CDbHelper

#Region "Used PV1 Elements"
    Protected mVisitID As Integer
    Protected mPatientClassID As String
    Protected mAdmissionTypeID As String
    Protected mHospitalServiceID As String
    Protected mAdmitSourceID As Integer
    Protected mAmbulatoryStatusID As String
    Protected mAdmitDate As String
    Protected mDischargeDate As String = ""
    Protected mAttendingDoctor As Integer
    Protected mReferringDocLastName As String = ""
    Protected mReferringDocFirstName As String = ""
    Protected mPatientID As Integer
    Protected mReferringDoctor As String
#End Region

#Region "Unused PV1 Elements"
    Protected mAssignedPatientLocation As String = ""
    Protected mPreadmitNumber As String = ""
    Protected mPriorPatientLocation As String = ""
    Protected mConsultingDoctor As String = ""
#End Region

#Region "Constants"
    Public Const VISIT_TABLE As String = "Visit"
    Public Const SELECT_STATEMENT As String = "SELECT * from " & VISIT_TABLE

    Public Const SEGMENT_HEADER As String = "PV1"
    Public Const ADMIT_DATE_COLUMN As String = "AdmitDate"
    Public Const ID_COLUMN As String = "ID"
#End Region

    ''' <summary>
    ''' Constructor 
    ''' </summary>
    ''' <param name="dbconn"></param>
    ''' <remarks></remarks>
    Public Sub New(ByRef dbconn As OleDbConnection)
        MyBase.new(dbconn, SELECT_STATEMENT, VISIT_TABLE)

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dbconn"></param>
    ''' <param name="strSelectStmt"></param>
    ''' <param name="strTable"></param>
    ''' <remarks></remarks>
    Protected Sub New(ByRef dbconn As OleDbConnection, ByVal strSelectStmt As String, ByVal strTable As String, ByVal strKey As String)
        MyBase.New(dbconn, strSelectStmt, strTable, strKey)
    End Sub
    ''' <summary>
    ''' Load the admissions from the database
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadAdmissions() As DataSet
        Dim objAdapter As OleDb.OleDbDataAdapter
        Dim visitDataSet As DataSet = New DataSet()
        Dim strSQL As String = SELECT_STATEMENT
        Try
            objAdapter = New OleDbDataAdapter(strSQL, mDbConn)
            objAdapter.Fill(visitDataSet, VISIT_TABLE)
            With objDataSet.Tables(VISIT_TABLE)
                .PrimaryKey = New DataColumn() {.Columns("ID")}

            End With
        Catch ex As Exception
        Finally

        End Try
        Return visitDataSet

    End Function
    ''' <summary>
    ''' Loads the visit into a data row
    ''' </summary>
    ''' <param name="intVisitId">The ID of the visit that will be retrieved</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadAdmission(ByVal intVisitId As Integer) As DataRow
        Dim drVisitData As DataRow
        drVisitData = objDataSet.Tables(VISIT_TABLE).Rows.Find(intVisitId)
        Populate(drVisitData)
        Return drVisitData
    End Function


    Private Sub Populate(ByRef visitData As DataRow)
        PatientID = CInt(visitData.Item("ID"))
        PatientClassID = CStr(visitData.Item("PatientClassID"))
        AdmissionTypeID = CStr(visitData.Item("AdmissionTypeID"))
        HospitalServiceID = CStr(visitData.Item("HospitalServiceID"))
        AdmitSourceID = CInt(visitData.Item("AdmitSourceID"))
        AmbulatoryStatusID = CStr(visitData.Item("AmbulatoryStatusID"))
        If Not IsDBNull(visitData.Item("AdmitDate")) Then
            AdmitDate = CStr(visitData.Item("AdmitDate"))
        Else
            AdmitDate = ""
        End If

        If Not IsDBNull(visitData.Item("DischargeDate")) Then
            DischargeDate = CStr(visitData.Item("DischargeDate"))
        Else
            DischargeDate = ""
        End If
        If Not IsDBNull(visitData.Item("AttendingDoctor")) Then
            AttendingDoctor = CInt(visitData.Item("AttendingDoctor"))
        Else
            AttendingDoctor = 0
        End If

        If Not IsDBNull(visitData.Item("ReferringDocLastName")) Then
            ReferringDocLastName = CStr(visitData.Item("ReferringDocLastName"))
        Else
            ReferringDocLastName = ""
        End If

        If Not IsDBNull(visitData.Item("ReferringDocFirstName")) Then
            ReferringDocFirstName = CStr(visitData.Item("ReferringDocFirstName"))
        Else
            ReferringDocFirstName = ""
        End If

        If Not IsDBNull(visitData.Item("PatientID")) Then
            PatientID = CInt(visitData.Item("PatientID"))
        Else
            PatientID = 0
        End If

    End Sub



    ''' <summary>
    ''' Returns the PV1 segment
    ''' Sample: PV1||O|||||0148^ADDISON,JAMES|0148^ADDISON,JAMES|0148^ADDISON,JAMES|AMB|||||||0148^ADDISON,JAMES|S|1400|A|||||||||||||||||||GENHOS||||||
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSegment() As String
        Dim docHelper As CDoctor = New CDoctor(mDbConn)
        docHelper.LoadDoctor(AttendingDoctor)

        Dim pv1 As String = SEGMENT_HEADER
        pv1 += HL7.FieldSeparator + HL7.FieldSeparator + PatientClassID + HL7.FieldSeparator + mAssignedPatientLocation + HL7.FieldSeparator
        pv1 += AdmissionTypeID + HL7.FieldSeparator + mPreadmitNumber + HL7.FieldSeparator + mPriorPatientLocation + HL7.FieldSeparator
        pv1 += docHelper.HL7FormmatedDoctorID + HL7.FieldSeparator + ReferringDocLastName + HL7.ComponentSeparator + ReferringDocFirstName + HL7.FieldSeparator + mConsultingDoctor + HL7.FieldSeparator
        pv1 += CStr(HospitalServiceID) + HL7.FieldSeparator + HL7.FieldSeparator + HL7.FieldSeparator + HL7.FieldSeparator + CStr(AdmitSourceID) + HL7.FieldSeparator
        pv1 += AmbulatoryStatusID + HL7.FieldSeparator
        For i As Integer = 0 To 35
            pv1 += HL7.FieldSeparator
        Next

        Return pv1


    End Function
#Region "CRUD Operations"
    ''' <summary>
    ''' Add a visit to the database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Add()
        Dim objAdapter As OleDb.OleDbDataAdapter

        Dim objDR As DataRow
        Dim objBuild As OleDbCommandBuilder
        'create a new data row from teh dataset
        objDR = objDataSet.Tables(VISIT_TABLE).NewRow()
        objDR.BeginEdit()
        'load new record data into the row
        objDR("ID") = 0 '
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
    ''' <param name="intVisitID"></param>
    ''' <remarks></remarks>
    Public Sub Update(ByVal intVisitID As Integer)
        Dim objAdapter As OleDb.OleDbDataAdapter
        Dim objBuild As OleDb.OleDbCommandBuilder
        Dim objDR As DataRow
        ' Find rows to update
        objDR = objDataSet.Tables(VISIT_TABLE).Rows.Find(intVisitID)
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
        objDR("ID") = mVisitID
        objDR("PatientClassID") = PatientClassID
        objDR("AdmissionTypeID") = AdmissionTypeID
        objDR("HospitalServiceID") = HospitalServiceID
        objDR("AdmitSourceID") = AdmitSourceID
        objDR("AmbulatoryStatusID") = AmbulatoryStatusID
        objDR("AdmitDate") = AdmitDate
        If (Not DischargeDate Is Nothing) And (Not DischargeDate = "") Then
            objDR("DischargeDate") = DischargeDate
        End If
        objDR("AttendingDoctor") = AttendingDoctor
        objDR("ReferringDocLastName") = ReferringDocLastName
        objDR("ReferringDocFirstName") = ReferringDocFirstName
        objDR("PatientID") = PatientID
    End Sub
#End Region
#Region "Properties"
    Public Property PatientClassID As String
        Get
            Return mPatientClassID

        End Get
        Set(ByVal value As String)
            mPatientClassID = value
        End Set
    End Property
    Public Property AdmissionTypeID As String
        Get
            Return mAdmissionTypeID
        End Get
        Set(ByVal value As String)
            mAdmissionTypeID = value
        End Set
    End Property
    Public Property HospitalServiceID As String
        Get
            Return mHospitalServiceID

        End Get
        Set(ByVal value As String)
            mHospitalServiceID = value
        End Set
    End Property
    Public Property AdmitSourceID As Integer
        Get
            Return mAdmitSourceID
        End Get
        Set(ByVal value As Integer)
            mAdmitSourceID = value
        End Set
    End Property
    Public Property AmbulatoryStatusID As String
        Get
            Return mAmbulatoryStatusID
        End Get
        Set(ByVal value As String)
            mAmbulatoryStatusID = value
        End Set
    End Property

    Public Property AdmitDate As String
        Get
            Return mAdmitDate
        End Get
        Set(ByVal value As String)
            mAdmitDate = value
        End Set
    End Property
    Public Property DischargeDate As String
        Get
            Return mDischargeDate
        End Get
        Set(ByVal value As String)
            mDischargeDate = value
        End Set
    End Property
    Public Property AttendingDoctor As Integer
        Get
            Return mAttendingDoctor
        End Get
        Set(ByVal value As Integer)
            mAttendingDoctor = value
        End Set
    End Property
    Public Property ReferringDocLastName As String
        Get
            Return mReferringDocLastName
        End Get
        Set(ByVal value As String)
            mReferringDocLastName = value
        End Set
    End Property
    Public Property ReferringDocFirstName As String
        Get
            Return mReferringDocFirstName
        End Get
        Set(ByVal value As String)
            mReferringDocFirstName = value
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
    Public Property AdmissionID As Integer
        Get
            Return mVisitID
        End Get
        Set(ByVal value As Integer)
            mVisitID = value
        End Set
    End Property
#End Region

End Class
