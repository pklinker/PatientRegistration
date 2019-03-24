Imports System.Data.OleDb

Public Class CDoctor
    Inherits CDbHelper

    Dim sqlDataRdr As OleDbDataReader
    Private mstrFirstName As String
    Private mstrLastName As String
    Private mintDoctorID As Integer

#Region "Constants"
    Public Const ID_FIELD As String = "ID"
    Public Const NAME_FIELD As String = "Name"
    Public Const DOCTOR_TABLE As String = "Doctor"
    Public Const SELECT_STATEMENT As String = "SELECT * from " + DOCTOR_TABLE
#End Region

    Public Sub New(ByRef dbconn As OleDbConnection)
        MyBase.new(dbconn, SELECT_STATEMENT, DOCTOR_TABLE)
    End Sub


    ''' <summary>
    ''' Loads the doctor into a data row
    ''' </summary>
    ''' <param name="docid">The ID of the doctor that will be retrieved</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadDoctor(ByVal docid As Integer) As DataRow
        Dim docData As DataRow
        docData = objDataSet.Tables(DOCTOR_TABLE).Rows.Find(docid)
        Populate(docData)
        Return docData
    End Function

    Private Sub Populate(ByRef patientData As DataRow)
        mintDoctorID = CInt(patientData.Item("ID"))
        mstrFirstName = CStr(patientData.Item("FirstName"))
        mstrLastName = CStr(patientData.Item("LastName"))
    End Sub


    ''' <summary>
    ''' Loads the doctors into the combo box
    ''' </summary>
    ''' <param name="theControl"></param>
    ''' <remarks></remarks>
    Public Sub LoadDoctorsIntoComboBox(ByRef theControl As ComboBox)

        Dim oCmd As New OleDbCommand("SELECT ID, LastName, FirstName FROM " & DOCTOR_TABLE &
                                     " ORDER BY LastName, Firstname", mDbConn)
        Dim statusDataTable As DataTable
        statusDataTable = New DataTable
        statusDataTable.Columns.Add(NAME_FIELD, GetType(System.String))
        statusDataTable.Columns.Add(ID_FIELD, GetType(System.String))

        Dim drNewRow As DataRow
        Try

            mDbConn.Open()

            sqlDataRdr = oCmd.ExecuteReader()
            While sqlDataRdr.Read()
                drNewRow = statusDataTable.NewRow()
                drNewRow(ID_FIELD) = sqlDataRdr.GetValue(0)
                drNewRow(NAME_FIELD) = CStr(sqlDataRdr.GetValue(1)) & ", " & CStr(sqlDataRdr.GetValue(2))
                statusDataTable.Rows.Add(drNewRow)
            End While
        Catch ex As OleDbException
            MessageBox.Show("Error retrieving records from the database.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            mDbConn.Close()

        End Try

        With (theControl)
            .DataSource = statusDataTable
            .DisplayMember = NAME_FIELD
            .ValueMember = ID_FIELD
            .SelectedIndex = -1
        End With

    End Sub
    ''' <summary>
    ''' Comma formatted doctor name
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FormattedDoctorName As String
        Get
            Return mstrLastName & ", " + mstrFirstName
        End Get
    End Property

    Public ReadOnly Property HL7FormmatedDoctorID As String
        Get
            Return CStr(mintDoctorID) + HL7.ComponentSeparator + mstrLastName + HL7.ComponentSeparator + mstrFirstName
        End Get
    End Property
End Class
