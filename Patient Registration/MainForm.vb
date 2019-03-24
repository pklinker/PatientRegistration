Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO

''' <summary>
''' Main window form.
''' Paul Klinker
''' </summary>
''' <remarks></remarks>
Public Class MainForm
    Public Const OTHER_RACE As String = "2131-1"

    Public Const UNKNOWN_ID As String = "U"

    Public Const OTHER_RELIGION As String = "OTH"

    Public Const NO_STATE As String = "NO"

    Private odb As OleDbConnection
    Private sqlDataRdr As OleDbDataReader
    Private currentPatient As CPatient
    Private fileChooser As SaveFileDialog
    Private docHelper As CDoctor
    Private addMode As Boolean

    ''' <summary>
    ''' Create the database connection
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CreateDbObjects()
        ' This is a function to create the the database objects to pull
        ' the lookup and event data from a Microsoft Access database
        Dim ConnectionString As String

        ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|PatientRegistration.accdb;Persist Security Info=False;"
        odb = New OleDbConnection(ConnectionString)
    End Sub

    ''' <summary>
    ''' Load a patient onto the patient screen
    ''' </summary>
    ''' <param name="patientid"></param>
    ''' <remarks></remarks>
    Public Sub LoadPatientIntoForm(ByVal patientid As Integer)
        Clear()
        Dim patientData As DataRow
        currentPatient = New CPatient(odb)
        patientData = currentPatient.LoadPatient(patientid)
        tbFirstName.Text = currentPatient.FirstName
        tbMiddleName.Text = currentPatient.MiddleName
        tbLastName.Text = currentPatient.LastName
        cbTitle.SelectedItem = patientData.Item("Title")
        cbSuffix.SelectedItem = patientData.Item("Suffix")
        tbDOB.Text = currentPatient.Dob
        tbPlaceOfBirth.Text = currentPatient.PlaceOfBirth
        tbSsn.Text = currentPatient.Ssn

        Dim multibirth As Boolean = CBool(patientData.Item("MultipleBirth"))
        If multibirth = True Then
            rbMultiBirthYes.Checked = True
        Else
            rbMultiBirthNo.Checked = True
        End If

        cbBirthOrder.SelectedIndex = currentPatient.BirthOrder - 1

        If Not IsDBNull(patientData.Item("Gender")) Then
            cbGender.SelectedIndex = FindGenderComboBoxIndex(cbGender, CStr(patientData.Item("Gender")))
        End If
        If (IsDBNull(patientData.Item("MaritalStatusID"))) Then
            cbMaritalStatus.SelectedIndex = -1
        Else
            cbMaritalStatus.SelectedIndex = FindSelectedComboBoxIndex(cbMaritalStatus, CStr(patientData.Item("MaritalStatusID")))
        End If
        If (IsDBNull(patientData.Item("RaceID"))) Then
            cbRace.SelectedIndex = -1
        Else
            cbRace.SelectedIndex = FindSelectedComboBoxIndex(cbRace, CStr(patientData.Item("RaceID")))
        End If
        If (IsDBNull(patientData.Item("ReligionID"))) Then
            cbReligion.SelectedIndex = -1
        Else
            cbReligion.SelectedIndex = FindSelectedComboBoxIndex(cbReligion, CStr(patientData.Item("ReligionID")))

        End If

        Dim patAddress As CAddress = New CAddress(odb)
        patAddress.LoadAddress(patientid)
        tbCity.Text = patAddress.City
        tbAddress1.Text = patAddress.Address1
        tbAddress2.Text = patAddress.Address2
        tbZipCode.Text = patAddress.Zip
        tbHomePhone.Text = patAddress.HomePhoneNumber
        If (IsDBNull(patAddress.State)) Then
            cbState.SelectedIndex = -1
        Else
            cbState.SelectedIndex = FindSelectedComboBoxIndex(cbState, patAddress.State)
        End If
        currentPatient.PatientAddress = patAddress
    End Sub
    ''' <summary>
    ''' Clear the patient screen.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        tbFirstName.Text = ""
        tbMiddleName.Text = ""
        tbLastName.Text = ""
        cbTitle.SelectedIndex = -1
        cbSuffix.SelectedIndex = -1
        tbDOB.Text = ""
        tbPlaceOfBirth.Text = ""
        tbSsn.Text = ""
        rbMultiBirthNo.Checked = True
        cbBirthOrder.SelectedIndex = -1
        cbTitle.SelectedIndex = -1
        cbSuffix.SelectedIndex = -1
        cbBirthOrder.SelectedIndex = -1
        cbGender.SelectedIndex = -1
        cbMaritalStatus.SelectedIndex = -1
        cbRace.SelectedIndex = -1
        cbReligion.SelectedIndex = -1
        tbAddress1.Text = ""
        tbAddress2.Text = ""
        tbCity.Text = ""
        cbState.SelectedIndex = -1
        tbZipCode.Text = ""
        tbHomePhone.Text = ""
    End Sub

    ''' <summary>
    ''' Load the main form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CreateDbObjects()
        addMode = True
        fileChooser = New SaveFileDialog()
        docHelper = New CDoctor(odb)
        docHelper.LoadDoctorsIntoComboBox(cbAttendingDoctor)
        btnDischarge.Enabled = False
        'Assume always a gender to reduce the amount of data input.
        LoadLookupData(cbMaritalStatus, "Status", "ID", "MaritalStatus")
        LoadLookupData(cbRace, "Race", "ID", "Race")
        LoadLookupData(cbReligion, "ReligionName", "ID", "Religion")
        LoadLookupData(cbState, "State", "Code", "State")
        LoadLookupData(cbAdmissionType, "AdmitReason", "ID", "AdmissionType")
        LoadLookupData(cbAdmitSource, "AdmitSource", "ID", "AdmitSource")
        LoadLookupData(cbPatientClass, "Class", "ID", "PatientClass")
        LoadLookupData(cbHospitalService, "Service", "ID", "HospitalService")
        LoadLookupData(cbAmbulatoryStatus, "Status", "ID", "AmbulatoryStatus")
        LoadGenderCB()
        LoadPatientList()
        lbPatient.SelectedIndex = 0
        Dim curPatItem As VTListItemNumeric = CType(lbPatient.SelectedItem, VTListItemNumeric)
        LoadPatientIntoForm(CInt(curPatItem.ItemID))

    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadGenderCB()
        Dim objItem1 As VTListItemString = New VTListItemString()
        objItem1.ItemID = "F"
        objItem1.ItemValue = "Female"
        cbGender.Items.Add(objItem1)
        Dim objItem2 As VTListItemString = New VTListItemString()
        objItem2.ItemID = "M"
        objItem2.ItemValue = "Male"
        cbGender.Items.Add(objItem2)

    End Sub
    ''' <summary>
    ''' </summary>
    ''' <param name="theControl"></param>
    ''' <param name="namefield"></param>
    ''' <param name="idfield"></param>
    ''' <param name="tablename"></param>
    ''' <remarks></remarks>
    Private Sub LoadLookupData(ByRef theControl As ComboBox, ByVal namefield As String, ByVal idfield As String, ByVal tablename As String)

        'Dim oCmd As New OleDbCommand("SELECT " + idfield + ", " + namefield + " from " + tablename + " ORDER BY " + namefield, odb)
        '''       Dim oCmd As New OleDbCommand("SELECT ?,? from ? ORDER BY ?", odb)
        '''       oCmd.Parameters.AddWithValue("@idfied", idfield)
        '''       oCmd.Parameters.AddWithValue("@namefield", namefield)
        '''       oCmd.Parameters.AddWithValue("@tablename", tablename)
        '''        oCmd.Parameters.AddWithValue("@namefield", namefield)

        Dim statusDataTable As DataTable
        statusDataTable = New DataTable
        statusDataTable.Columns.Add(namefield, GetType(System.String))
        statusDataTable.Columns.Add(idfield, GetType(System.String))

        Dim drNewRow As DataRow
        Try

            odb.Open()

            sqlDataRdr = oCmd.ExecuteReader()


            While sqlDataRdr.Read()
                drNewRow = statusDataTable.NewRow()
                drNewRow(idfield) = sqlDataRdr.GetValue(0)
                drNewRow(namefield) = sqlDataRdr.GetValue(1)
                statusDataTable.Rows.Add(drNewRow)
            End While
        Catch ex As OleDbException
            MessageBox.Show("Error retrieving records from the database.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Finally
            odb.Close()

        End Try

        With (theControl)
            .DataSource = statusDataTable
            .DisplayMember = namefield
            .ValueMember = idfield
            .SelectedIndex = -1
        End With

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="cbComboBox"></param>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FindSelectedComboBoxIndex(ByRef cbComboBox As ComboBox, ByVal value As String) As Integer
        Dim i As Integer
        For i = 0 To cbComboBox.Items.Count - 1
            Dim testval As String
            testval = CStr(cbComboBox.Items(i).Item(1))
            If value = testval Then
                'found it
                Return i
            End If
        Next
        ' not found 
        Return -1
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="cbComboBox"></param>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FindGenderComboBoxIndex(ByRef cbComboBox As ComboBox, ByVal value As String) As Integer
        Dim i As Integer
        For i = 0 To cbComboBox.Items.Count - 1
            Dim vstr As VTListItemString = CType(cbComboBox.Items(i), VTListItemString)
            If value = vstr.ItemID Then
                'found it
                Return i
            End If
        Next
        ' not found 
        Return -1
    End Function

    ''' <summary>
    ''' Load the patients into the patient list box.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadPatientList()

        lbPatient.Items.Clear()
        lbPatientAdmission.Items.Clear()
        Dim patient As CPatient = New CPatient(odb)
        Dim objRow As DataRow
        Dim patDataSet As DataSet
        patDataSet = patient.LoadPatients()

        For Each objRow In patDataSet.Tables(CPatient.PATIENT_TABLE).Rows
            Dim objItem As VTListItemNumeric = New VTListItemNumeric()
            With objItem
                .ItemID = CInt(objRow.Item("ID"))
                .ItemValue = objRow.Item(CPatient.PATIENT_LAST_NAME_COLUMN).ToString & ", " & objRow.Item(CPatient.PATIENT_FIRST_NAME_COLUMN).ToString
            End With
            lbPatient.Items.Add(objItem)
            lbPatientAdmission.Items.Add(objItem)
        Next
        lbPatient.SetSelected(0, True)
        lbPatientAdmission.SetSelected(0, True)
    End Sub

    ''' <summary>
    ''' Load the patients into the patient list box.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadVisitList()

        lbAdmissions.Items.Clear()
        tbAmbulatoryStatus.Text = ""
        tbAdmissionType.Text = ""
        tbAttendingDoctor.Text = ""
        tbVisitAdmissionDate.Text = ""
        tbVisitDischargeDate.Text = ""
        tbPatientClass.Text = ""
        tbHospitalService.Text = ""
        Dim visit As CVisit = New CVisit(odb)
        Dim objRow As DataRow
        Dim visitDataSet As DataSet
        Dim thevisit As VTListItemNumeric = CType(lbPatientAdmission.SelectedItem, VTListItemNumeric)
        visitDataSet = visit.LoadVisits(CInt(thevisit.ItemID))

        For Each objRow In visitDataSet.Tables(CVisit.VISIT_TABLE).Rows
            Dim objItem As VTListItemNumeric = New VTListItemNumeric()
            With objItem
                .ItemID = CInt(objRow.Item(CVisit.ID_COLUMN))
                .ItemValue = objRow.Item(CVisit.ADMIT_DATE_COLUMN).ToString
            End With
            lbAdmissions.Items.Add(objItem)
        Next
        lbPatient.SetSelected(0, True)
    End Sub

    ''' <summary>
    ''' Save the patient into the database.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSavePatient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavePatient.Click
        If tbFirstName Is Nothing Or tbFirstName.Text = "" Or
           tbLastName Is Nothing Or tbLastName.Text = "" Or
           tbSsn Is Nothing Or tbSsn.Text = "" Then
            MessageBox.Show("First name, last name and SSN are required.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return

        End If

        If cbGender.SelectedIndex = -1 Then
            'error
            MessageBox.Show("Gender is required.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return

        End If

        Dim strAddr1 As String = tbAddress1.Text
        Dim strAddr2 As String = tbAddress2.Text
        Dim strFirstName As String = tbFirstName.Text
        Dim strMiddleName As String = tbMiddleName.Text
        Dim strLastName As String = tbLastName.Text
        Dim strPlaceOfBirth As String = tbPlaceOfBirth.Text

        Dim strDOB As String = tbDOB.Text
        ' Check date format
        If strDOB <> "" Then
            If Not CUtil.VerifyDate(strDOB) Then
                MessageBox.Show("Invalid date of birth. Date format is MM/DD/YYYY.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End If
        Dim strHomePhone As String = tbHomePhone.Text
        If (strHomePhone <> "") Then
            If Not CUtil.VerifyPhoneNumber(strHomePhone) Then
                MessageBox.Show("Invalid home phone format. Format is xxx-xxx-xxxx.", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End If

        Dim strSsn As String = tbSsn.Text

        'Default to no suffix
        Dim strSuffix As String = ""
        If (cbSuffix.SelectedIndex <> -1) Then
            strSuffix = cbSuffix.Text
        End If

        'Default to no title.
        Dim strTitle As String = ""
        If (cbTitle.SelectedIndex <> -1) Then
            strTitle = cbTitle.Text
        End If

        ' default to unknown marital status
        Dim strMaritalStatusID As String = UNKNOWN_ID

        If (cbMaritalStatus.SelectedIndex <> -1) Then
            strMaritalStatusID = CStr(cbMaritalStatus.SelectedValue)
        End If

        Dim strRaceID As String = OTHER_RACE
        If (cbRace.SelectedIndex <> -1) Then
            strRaceID = CStr(cbRace.SelectedValue)
        End If

        Dim strReligionID As String = OTHER_RELIGION
        If (cbReligion.SelectedIndex <> -1) Then
            strReligionID = CStr(cbReligion.SelectedValue)
        End If
        Dim strStateCode As String = NO_STATE
        If (cbState.SelectedIndex <> -1) Then
            strStateCode = CStr(cbState.SelectedValue)

        End If
        Dim strGender As String
        Dim vGen As VTListItemString = CType(cbGender.SelectedItem(), VTListItemString)
        strGender = vGen.ItemID
        Dim boolMultiBirth = False
        Dim intBirthOrder As Integer = 1
        If rbMultiBirthYes.Checked Then
            boolMultiBirth = True
            intBirthOrder = CInt(cbBirthOrder.SelectedValue)
        End If
        Dim strZip As String = tbZipCode.Text
        Dim strCity As String = tbCity.Text

        Dim cpNewPatient As CPatient = currentPatient
        If addMode Then
            cpNewPatient = New CPatient(odb)
        End If
        'set patient demographics
        cpNewPatient.FirstName = strFirstName
        cpNewPatient.MiddleName = strMiddleName
        cpNewPatient.LastName = strLastName
        cpNewPatient.Suffix = strSuffix
        cpNewPatient.Title = strTitle
        cpNewPatient.Dob = strDOB
        cpNewPatient.Gender = strGender
        cpNewPatient.ReligionID = strReligionID
        cpNewPatient.Ssn = strSsn
        cpNewPatient.MaritalStatusID = strMaritalStatusID
        cpNewPatient.PatientClassID = CStr(0)
        cpNewPatient.RaceID = strRaceID
        cpNewPatient.PlaceOfBirth = strPlaceOfBirth
        cpNewPatient.MultipleBirth = boolMultiBirth
        cpNewPatient.BirthOrder = intBirthOrder

        If addMode Then
            cpNewPatient.Add()
        Else
            cpNewPatient.Update()
        End If
        Dim caNewAddress As CAddress = cpNewPatient.PatientAddress
        If addMode Then
            caNewAddress = New CAddress(odb)
        End If

        'set address
        caNewAddress.Address1 = strAddr1
        caNewAddress.Address2 = strAddr2
        caNewAddress.City = strCity
        caNewAddress.State = strStateCode
        caNewAddress.Zip = strZip
        caNewAddress.HomePhoneNumber = strHomePhone
        caNewAddress.PatientID = cpNewPatient.PatientID
        If addMode Then
            caNewAddress.Add()
        Else
            caNewAddress.Update()
        End If
        RegTabControl.SelectedTab = tpCurrentVisit
        If addMode Then
            currentPatient = cpNewPatient
            currentPatient.PatientAddress = caNewAddress
        End If
        LoadPatientList()
    End Sub

    Private Sub btnPatientRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPatientRefresh.Click
        LoadPatientList()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAddPatient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPatient.Click
        addMode = True

        Clear()
        RegTabControl.SelectedTab = tpNewPatient
    End Sub

    ''' <summary>
    ''' New patient clicked.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub NewPatientToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewPatientToolStripMenuItem.Click
        Clear()
        RegTabControl.SelectedTab = tpNewPatient
    End Sub

    ''' <summary>
    ''' Edit button was pushed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnEditPatient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditPatient.Click

        If lbPatient.SelectedIndex = -1 Then
            MessageBox.Show("Please select a patient to edit.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        addMode = False

        Dim itemdata As VTListItemNumeric = CType(lbPatient.SelectedItem, VTListItemNumeric)
        LoadPatientIntoForm(itemdata.ItemID)
        RegTabControl.SelectedTab = tpNewPatient
    End Sub

    ''' <summary>
    ''' User selected the export HL7 menu option
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ExportHL7ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportHL7ToolStripMenuItem.Click
        If lbAdmissions.SelectedIndex = -1 Then
            MessageBox.Show("Please select an admission to export to HL7.", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim filename As String = CreateHL7File()
        If filename <> "" Then
            writeRecord(filename)
        End If
    End Sub

    ''' <summary>
    ''' Creates a dialog to pick the HL7 filename so we can export the HL7 record.
    ''' </summary>
    ''' <remarks></remarks>
    Private Function CreateHL7File() As String

        Dim result As DialogResult
        Dim fileName As String

        Using fileChooser
            fileChooser.FileName = "patientADT"
            fileChooser.DefaultExt = "dat"
            fileChooser.Filter = "Data files (*.dat)|*.dat|All files (*.*)|*.*"
            fileChooser.InitialDirectory = Application.StartupPath
            result = fileChooser.ShowDialog()
            If result = DialogResult.Cancel Then
                Return ""
            End If
            fileName = fileChooser.FileName
        End Using
        Return fileName
    End Function
    Private Sub writeRecord(ByVal filename As String)
        Try

            ' get the visit
            Dim thevisit As VTListItemNumeric = CType(lbAdmissions.SelectedItem, VTListItemNumeric)
            Dim printAdmission As CAdmission = New CAdmission(odb)
            Dim drOldVisit As DataRow = printAdmission.LoadAdmission(thevisit.ItemID)
            'From the Admission get the patient ID and then the patient

            Dim printPatient As CPatient = New CPatient(odb)
            printPatient.LoadPatient(printAdmission.PatientID)

            HL7.WriteA01Event(filename, printAdmission, printPatient)
        Catch ex As Exception
            MessageBox.Show("Could not export the Admin/Visit Notification HL7.", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub


    Private Sub lbPatientAdmission_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbPatientAdmission.SelectedIndexChanged

        ExportHL7ToolStripMenuItem.Enabled = True
        LoadVisitList()
    End Sub

    ''' <summary>
    ''' A new item on the admission list was selected
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lbAdmissions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbAdmissions.SelectedIndexChanged
        If lbAdmissions.SelectedIndex = -1 Then
            Return 'no visit selected
        End If
        Dim thevisit As VTListItemNumeric = CType(lbAdmissions.SelectedItem, VTListItemNumeric)
        '        visitDataSet = visit.LoadVisits(CInt(thevisit.ItemID))
        Dim oldVisit As CVisit = New CVisit(odb)
        oldVisit.LoadVisit(CInt(thevisit.ItemID))
        docHelper.LoadDoctor(oldVisit.AttendingDoctor)
        tbAttendingDoctor.Text = docHelper.FormattedDoctorName
        tbAdmissionType.Text = oldVisit.AdmissionType
        tbVisitAdmissionDate.Text = oldVisit.AdmitDate
        tbVisitDischargeDate.Text = oldVisit.DischargeDate
        tbAmbulatoryStatus.Text = oldVisit.AmbulatoryStatus
        tbPatientClass.Text = oldVisit.PatientClass
        tbHospitalService.Text = oldVisit.HospitalService
        If (oldVisit.DischargeDate = "") Then
            btnDischarge.Enabled = True
        Else
            btnDischarge.Enabled = False
        End If
    End Sub

    Private Sub btnAdmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdmit.Click
        If cbAdmissionType.SelectedIndex = -1 Then
            'error
            MessageBox.Show("Admission type is required.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return

        End If

        If cbAttendingDoctor.SelectedIndex = -1 Then
            'error
            MessageBox.Show("Attending doctor is required.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return

        End If
        If cbPatientClass.SelectedIndex = -1 Then
            'error
            MessageBox.Show("Patient class is required.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return

        End If
        If cbAmbulatoryStatus.SelectedIndex = -1 Then
            'error
            MessageBox.Show("Ambulatory status is required.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return

        End If
        If cbHospitalService.SelectedIndex = -1 Then
            'error
            MessageBox.Show("Hospital service is required.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return

        End If
        If cbAdmitSource.SelectedIndex = -1 Then
            'error
            MessageBox.Show("Admission source is required.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return

        End If


        Dim newAdmit As CAdmission = New CAdmission(odb)
        newAdmit.PatientID = currentPatient.PatientID

        newAdmit.PatientClassID = CStr(cbPatientClass.SelectedValue)
        newAdmit.ReferringDocFirstName = tbReferDocFirst.Text
        newAdmit.ReferringDocLastName = tbReferDocLast.Text
        newAdmit.AdmissionTypeID = CStr(cbAdmissionType.SelectedValue)
        newAdmit.AdmitSourceID = CInt(cbAdmitSource.SelectedValue)
        newAdmit.AmbulatoryStatusID = CStr(cbAmbulatoryStatus.SelectedValue)
        newAdmit.AttendingDoctor = CInt(cbAttendingDoctor.SelectedValue)
        newAdmit.HospitalServiceID = CStr(cbHospitalService.SelectedValue)
        newAdmit.AdmitDate = System.DateTime.Now.ToString("MM/dd/yyyy HH:m")
        newAdmit.Add()
        MessageBox.Show("Patient has been admitted.", "Admitted",
            MessageBoxButtons.OK, MessageBoxIcon.Information
            )

        'Clear the entry
        cbPatientClass.SelectedIndex = -1
        tbReferDocFirst.Text = ""
        tbReferDocLast.Text = ""
        cbAdmissionType.SelectedIndex = -1
        cbAdmitSource.SelectedIndex = -1
        cbAmbulatoryStatus.SelectedIndex = -1
        cbAttendingDoctor.SelectedIndex = -1
        cbHospitalService.SelectedIndex = -1
    End Sub
    ''' <summary>
    ''' Discharge button pressed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDischarge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDischarge.Click
        If lbAdmissions.SelectedIndex = -1 Then
            Return ' no admission/visit event was selected
        End If
        Dim thevisit As VTListItemNumeric = CType(lbAdmissions.SelectedItem, VTListItemNumeric)
        Dim oldVisit As CAdmission = New CAdmission(odb)
        Dim drOldVisit As DataRow = oldVisit.LoadAdmission(thevisit.ItemID)
        oldVisit.DischargeDate = System.DateTime.Now.ToString("MM/dd/yyyy HH:m")
        oldVisit.Update(thevisit.ItemID)
        'reload from the database to verify it was saved correctly
        oldVisit = New CAdmission(odb)
        drOldVisit = oldVisit.LoadAdmission(thevisit.ItemID)
        tbVisitDischargeDate.Text = oldVisit.DischargeDate
        btnDischarge.Enabled = False
        MessageBox.Show("Patient has been discharged.", "Discharged",
    MessageBoxButtons.OK, MessageBoxIcon.Information
    )

    End Sub
    ''' <summary>
    ''' User selected the about menu item.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim afAboutForm As AboutForm = New AboutForm
        afAboutForm.Show()

    End Sub

    ''' <summary>
    ''' Exit program
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()

    End Sub

End Class
