<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewPatientToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportHL7ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tpAdmissions = New System.Windows.Forms.TabPage()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.btnDischarge = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.tbAmbulatoryStatus = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.tbAttendingDoctor = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.tbVisitDischargeDate = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.tbVisitAdmissionDate = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.tbAdmissionType = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lbAdmissions = New System.Windows.Forms.ListBox()
        Me.lbPatientAdmission = New System.Windows.Forms.ListBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.tpNewPatient = New System.Windows.Forms.TabPage()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.tbHomePhone = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.tbAddress1 = New System.Windows.Forms.TextBox()
        Me.tbZipCode = New System.Windows.Forms.TextBox()
        Me.tbAddress2 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cbState = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tbCity = New System.Windows.Forms.TextBox()
        Me.btnSavePatient = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.tbSsn = New System.Windows.Forms.TextBox()
        Me.cbBirthOrder = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.rbMultiBirthNo = New System.Windows.Forms.RadioButton()
        Me.rbMultiBirthYes = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbPlaceOfBirth = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbReligion = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbMaritalStatus = New System.Windows.Forms.ComboBox()
        Me.cbRace = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbGender = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbDOB = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbSuffix = New System.Windows.Forms.ComboBox()
        Me.tbLastName = New System.Windows.Forms.TextBox()
        Me.tbMiddleName = New System.Windows.Forms.TextBox()
        Me.cbTitle = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbFirstName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tpCurrentVisit = New System.Windows.Forms.TabPage()
        Me.btnAdmit = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.tbReferDocLast = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.tbReferDocFirst = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbAttendingDoctor = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cbAdmissionType = New System.Windows.Forms.ComboBox()
        Me.btnEditPatient = New System.Windows.Forms.Button()
        Me.btnAddPatient = New System.Windows.Forms.Button()
        Me.btnPatientRefresh = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lbPatient = New System.Windows.Forms.ListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbAmbulatoryStatus = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cbAdmitSource = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cbHospitalService = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cbPatientClass = New System.Windows.Forms.ComboBox()
        Me.RegTabControl = New System.Windows.Forms.TabControl()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.tbPatientClass = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.tbHospitalService = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.tpAdmissions.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.tpNewPatient.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tpCurrentVisit.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.RegTabControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1017, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewPatientToolStripMenuItem, Me.ExportHL7ToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'NewPatientToolStripMenuItem
        '
        Me.NewPatientToolStripMenuItem.Name = "NewPatientToolStripMenuItem"
        Me.NewPatientToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.NewPatientToolStripMenuItem.Text = "&New Patient"
        '
        'ExportHL7ToolStripMenuItem
        '
        Me.ExportHL7ToolStripMenuItem.Name = "ExportHL7ToolStripMenuItem"
        Me.ExportHL7ToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.ExportHL7ToolStripMenuItem.Text = "&Export Admit Notification HL7"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'HelToolStripMenuItem
        '
        Me.HelToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelToolStripMenuItem.Name = "HelToolStripMenuItem"
        Me.HelToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 470)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1017, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tpAdmissions
        '
        Me.tpAdmissions.Controls.Add(Me.Label36)
        Me.tpAdmissions.Controls.Add(Me.btnDischarge)
        Me.tpAdmissions.Controls.Add(Me.GroupBox6)
        Me.tpAdmissions.Controls.Add(Me.Label30)
        Me.tpAdmissions.Controls.Add(Me.lbAdmissions)
        Me.tpAdmissions.Controls.Add(Me.lbPatientAdmission)
        Me.tpAdmissions.Controls.Add(Me.Label29)
        Me.tpAdmissions.Location = New System.Drawing.Point(4, 22)
        Me.tpAdmissions.Name = "tpAdmissions"
        Me.tpAdmissions.Size = New System.Drawing.Size(1009, 420)
        Me.tpAdmissions.TabIndex = 2
        Me.tpAdmissions.Text = "Admissions"
        Me.tpAdmissions.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(8, 34)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(48, 13)
        Me.Label36.TabIndex = 8
        Me.Label36.Text = "Patients:"
        '
        'btnDischarge
        '
        Me.btnDischarge.Location = New System.Drawing.Point(887, 358)
        Me.btnDischarge.Name = "btnDischarge"
        Me.btnDischarge.Size = New System.Drawing.Size(75, 23)
        Me.btnDischarge.TabIndex = 7
        Me.btnDischarge.Text = "Discharge"
        Me.btnDischarge.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.tbHospitalService)
        Me.GroupBox6.Controls.Add(Me.Label39)
        Me.GroupBox6.Controls.Add(Me.tbPatientClass)
        Me.GroupBox6.Controls.Add(Me.Label38)
        Me.GroupBox6.Controls.Add(Me.tbAmbulatoryStatus)
        Me.GroupBox6.Controls.Add(Me.Label37)
        Me.GroupBox6.Controls.Add(Me.tbAttendingDoctor)
        Me.GroupBox6.Controls.Add(Me.Label34)
        Me.GroupBox6.Controls.Add(Me.tbVisitDischargeDate)
        Me.GroupBox6.Controls.Add(Me.Label33)
        Me.GroupBox6.Controls.Add(Me.tbVisitAdmissionDate)
        Me.GroupBox6.Controls.Add(Me.Label32)
        Me.GroupBox6.Controls.Add(Me.Label31)
        Me.GroupBox6.Controls.Add(Me.tbAdmissionType)
        Me.GroupBox6.Location = New System.Drawing.Point(620, 17)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(372, 303)
        Me.GroupBox6.TabIndex = 6
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Visit Detail"
        '
        'tbAmbulatoryStatus
        '
        Me.tbAmbulatoryStatus.Location = New System.Drawing.Point(123, 143)
        Me.tbAmbulatoryStatus.Name = "tbAmbulatoryStatus"
        Me.tbAmbulatoryStatus.ReadOnly = True
        Me.tbAmbulatoryStatus.Size = New System.Drawing.Size(219, 20)
        Me.tbAmbulatoryStatus.TabIndex = 13
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(9, 146)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(95, 13)
        Me.Label37.TabIndex = 12
        Me.Label37.Text = "Ambulatory Status:"
        '
        'tbAttendingDoctor
        '
        Me.tbAttendingDoctor.Location = New System.Drawing.Point(123, 111)
        Me.tbAttendingDoctor.Name = "tbAttendingDoctor"
        Me.tbAttendingDoctor.ReadOnly = True
        Me.tbAttendingDoctor.Size = New System.Drawing.Size(219, 20)
        Me.tbAttendingDoctor.TabIndex = 11
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(9, 114)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(90, 13)
        Me.Label34.TabIndex = 10
        Me.Label34.Text = "Attending Doctor:"
        '
        'tbVisitDischargeDate
        '
        Me.tbVisitDischargeDate.Location = New System.Drawing.Point(123, 49)
        Me.tbVisitDischargeDate.Name = "tbVisitDischargeDate"
        Me.tbVisitDischargeDate.ReadOnly = True
        Me.tbVisitDischargeDate.Size = New System.Drawing.Size(141, 20)
        Me.tbVisitDischargeDate.TabIndex = 9
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(9, 52)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(84, 13)
        Me.Label33.TabIndex = 8
        Me.Label33.Text = "Discharge Date:"
        '
        'tbVisitAdmissionDate
        '
        Me.tbVisitAdmissionDate.Location = New System.Drawing.Point(123, 17)
        Me.tbVisitAdmissionDate.Name = "tbVisitAdmissionDate"
        Me.tbVisitAdmissionDate.ReadOnly = True
        Me.tbVisitAdmissionDate.Size = New System.Drawing.Size(141, 20)
        Me.tbVisitAdmissionDate.TabIndex = 7
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(9, 20)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(83, 13)
        Me.Label32.TabIndex = 6
        Me.Label32.Text = "Admission Date:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(9, 83)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(81, 13)
        Me.Label31.TabIndex = 4
        Me.Label31.Text = "AdmissionType:"
        '
        'tbAdmissionType
        '
        Me.tbAdmissionType.Location = New System.Drawing.Point(123, 80)
        Me.tbAdmissionType.Name = "tbAdmissionType"
        Me.tbAdmissionType.ReadOnly = True
        Me.tbAdmissionType.Size = New System.Drawing.Size(219, 20)
        Me.tbAdmissionType.TabIndex = 5
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(311, 17)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(34, 13)
        Me.Label30.TabIndex = 3
        Me.Label30.Text = "Visits:"
        '
        'lbAdmissions
        '
        Me.lbAdmissions.FormattingEnabled = True
        Me.lbAdmissions.Location = New System.Drawing.Point(365, 17)
        Me.lbAdmissions.Name = "lbAdmissions"
        Me.lbAdmissions.Size = New System.Drawing.Size(202, 303)
        Me.lbAdmissions.TabIndex = 2
        '
        'lbPatientAdmission
        '
        Me.lbPatientAdmission.FormattingEnabled = True
        Me.lbPatientAdmission.Location = New System.Drawing.Point(69, 17)
        Me.lbPatientAdmission.Name = "lbPatientAdmission"
        Me.lbPatientAdmission.Size = New System.Drawing.Size(216, 303)
        Me.lbPatientAdmission.TabIndex = 1
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(8, 17)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(48, 13)
        Me.Label29.TabIndex = 0
        Me.Label29.Text = "Admitted"
        '
        'tpNewPatient
        '
        Me.tpNewPatient.Controls.Add(Me.GroupBox7)
        Me.tpNewPatient.Controls.Add(Me.btnSavePatient)
        Me.tpNewPatient.Controls.Add(Me.GroupBox1)
        Me.tpNewPatient.Location = New System.Drawing.Point(4, 22)
        Me.tpNewPatient.Name = "tpNewPatient"
        Me.tpNewPatient.Padding = New System.Windows.Forms.Padding(3)
        Me.tpNewPatient.Size = New System.Drawing.Size(1009, 420)
        Me.tpNewPatient.TabIndex = 0
        Me.tpNewPatient.Text = "Patient"
        Me.tpNewPatient.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.tbHomePhone)
        Me.GroupBox7.Controls.Add(Me.Label14)
        Me.GroupBox7.Controls.Add(Me.Label35)
        Me.GroupBox7.Controls.Add(Me.tbAddress1)
        Me.GroupBox7.Controls.Add(Me.tbZipCode)
        Me.GroupBox7.Controls.Add(Me.tbAddress2)
        Me.GroupBox7.Controls.Add(Me.Label17)
        Me.GroupBox7.Controls.Add(Me.Label18)
        Me.GroupBox7.Controls.Add(Me.cbState)
        Me.GroupBox7.Controls.Add(Me.Label15)
        Me.GroupBox7.Controls.Add(Me.Label16)
        Me.GroupBox7.Controls.Add(Me.tbCity)
        Me.GroupBox7.Location = New System.Drawing.Point(8, 218)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(993, 149)
        Me.GroupBox7.TabIndex = 41
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Patient Address"
        '
        'tbHomePhone
        '
        Me.tbHomePhone.Location = New System.Drawing.Point(85, 95)
        Me.tbHomePhone.MaxLength = 16
        Me.tbHomePhone.Name = "tbHomePhone"
        Me.tbHomePhone.Size = New System.Drawing.Size(117, 20)
        Me.tbHomePhone.TabIndex = 40
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 31)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 13)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Address 1:"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(6, 98)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(72, 13)
        Me.Label35.TabIndex = 39
        Me.Label35.Text = "Home Phone:"
        '
        'tbAddress1
        '
        Me.tbAddress1.Location = New System.Drawing.Point(85, 28)
        Me.tbAddress1.MaxLength = 255
        Me.tbAddress1.Name = "tbAddress1"
        Me.tbAddress1.Size = New System.Drawing.Size(294, 20)
        Me.tbAddress1.TabIndex = 22
        '
        'tbZipCode
        '
        Me.tbZipCode.Location = New System.Drawing.Point(616, 62)
        Me.tbZipCode.MaxLength = 10
        Me.tbZipCode.Name = "tbZipCode"
        Me.tbZipCode.Size = New System.Drawing.Size(100, 20)
        Me.tbZipCode.TabIndex = 26
        '
        'tbAddress2
        '
        Me.tbAddress2.Location = New System.Drawing.Point(498, 28)
        Me.tbAddress2.MaxLength = 255
        Me.tbAddress2.Name = "tbAddress2"
        Me.tbAddress2.Size = New System.Drawing.Size(251, 20)
        Me.tbAddress2.TabIndex = 23
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(557, 65)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 13)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "Zip Code:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(435, 31)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(57, 13)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "Address 2:"
        '
        'cbState
        '
        Me.cbState.FormattingEnabled = True
        Me.cbState.ItemHeight = 13
        Me.cbState.Location = New System.Drawing.Point(316, 62)
        Me.cbState.Name = "cbState"
        Me.cbState.Size = New System.Drawing.Size(219, 21)
        Me.cbState.TabIndex = 25
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 65)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(27, 13)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "City:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(275, 65)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(35, 13)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "State:"
        '
        'tbCity
        '
        Me.tbCity.Location = New System.Drawing.Point(85, 62)
        Me.tbCity.MaxLength = 100
        Me.tbCity.Name = "tbCity"
        Me.tbCity.Size = New System.Drawing.Size(166, 20)
        Me.tbCity.TabIndex = 24
        '
        'btnSavePatient
        '
        Me.btnSavePatient.Location = New System.Drawing.Point(906, 373)
        Me.btnSavePatient.Name = "btnSavePatient"
        Me.btnSavePatient.Size = New System.Drawing.Size(75, 23)
        Me.btnSavePatient.TabIndex = 40
        Me.btnSavePatient.Text = "Save"
        Me.btnSavePatient.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.tbSsn)
        Me.GroupBox1.Controls.Add(Me.cbBirthOrder)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.rbMultiBirthNo)
        Me.GroupBox1.Controls.Add(Me.rbMultiBirthYes)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.tbPlaceOfBirth)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cbReligion)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cbMaritalStatus)
        Me.GroupBox1.Controls.Add(Me.cbRace)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cbGender)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.tbDOB)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbSuffix)
        Me.GroupBox1.Controls.Add(Me.tbLastName)
        Me.GroupBox1.Controls.Add(Me.tbMiddleName)
        Me.GroupBox1.Controls.Add(Me.cbTitle)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbFirstName)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(993, 188)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Patient Information"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(557, 97)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(32, 13)
        Me.Label20.TabIndex = 38
        Me.Label20.Text = "SSN:"
        '
        'tbSsn
        '
        Me.tbSsn.Location = New System.Drawing.Point(598, 94)
        Me.tbSsn.Name = "tbSsn"
        Me.tbSsn.Size = New System.Drawing.Size(127, 20)
        Me.tbSsn.TabIndex = 17
        '
        'cbBirthOrder
        '
        Me.cbBirthOrder.FormattingEnabled = True
        Me.cbBirthOrder.ItemHeight = 13
        Me.cbBirthOrder.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cbBirthOrder.Location = New System.Drawing.Point(765, 58)
        Me.cbBirthOrder.Name = "cbBirthOrder"
        Me.cbBirthOrder.Size = New System.Drawing.Size(40, 21)
        Me.cbBirthOrder.TabIndex = 14
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(699, 64)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Birth Order:"
        '
        'rbMultiBirthNo
        '
        Me.rbMultiBirthNo.AutoSize = True
        Me.rbMultiBirthNo.Checked = True
        Me.rbMultiBirthNo.Location = New System.Drawing.Point(647, 62)
        Me.rbMultiBirthNo.Name = "rbMultiBirthNo"
        Me.rbMultiBirthNo.Size = New System.Drawing.Size(39, 17)
        Me.rbMultiBirthNo.TabIndex = 13
        Me.rbMultiBirthNo.TabStop = True
        Me.rbMultiBirthNo.Text = "No"
        Me.rbMultiBirthNo.UseVisualStyleBackColor = True
        '
        'rbMultiBirthYes
        '
        Me.rbMultiBirthYes.AutoSize = True
        Me.rbMultiBirthYes.Location = New System.Drawing.Point(598, 62)
        Me.rbMultiBirthYes.Name = "rbMultiBirthYes"
        Me.rbMultiBirthYes.Size = New System.Drawing.Size(43, 17)
        Me.rbMultiBirthYes.TabIndex = 12
        Me.rbMultiBirthYes.Text = "Yes"
        Me.rbMultiBirthYes.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(506, 64)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Multiple Birth:"
        '
        'tbPlaceOfBirth
        '
        Me.tbPlaceOfBirth.Location = New System.Drawing.Point(299, 60)
        Me.tbPlaceOfBirth.MaxLength = 100
        Me.tbPlaceOfBirth.Name = "tbPlaceOfBirth"
        Me.tbPlaceOfBirth.Size = New System.Drawing.Size(185, 20)
        Me.tbPlaceOfBirth.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(219, 63)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Place of Birth:"
        '
        'cbReligion
        '
        Me.cbReligion.FormattingEnabled = True
        Me.cbReligion.ItemHeight = 13
        Me.cbReligion.Location = New System.Drawing.Point(85, 132)
        Me.cbReligion.Name = "cbReligion"
        Me.cbReligion.Size = New System.Drawing.Size(270, 21)
        Me.cbReligion.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 135)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Religion:"
        '
        'cbMaritalStatus
        '
        Me.cbMaritalStatus.FormattingEnabled = True
        Me.cbMaritalStatus.ItemHeight = 13
        Me.cbMaritalStatus.Location = New System.Drawing.Point(299, 94)
        Me.cbMaritalStatus.Name = "cbMaritalStatus"
        Me.cbMaritalStatus.Size = New System.Drawing.Size(185, 21)
        Me.cbMaritalStatus.TabIndex = 16
        '
        'cbRace
        '
        Me.cbRace.FormattingEnabled = True
        Me.cbRace.Location = New System.Drawing.Point(473, 132)
        Me.cbRace.Name = "cbRace"
        Me.cbRace.Size = New System.Drawing.Size(223, 21)
        Me.cbRace.TabIndex = 21
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(218, 97)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Marital Status:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(421, 135)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Race:"
        '
        'cbGender
        '
        Me.cbGender.FormattingEnabled = True
        Me.cbGender.ItemHeight = 13
        Me.cbGender.Location = New System.Drawing.Point(85, 94)
        Me.cbGender.Name = "cbGender"
        Me.cbGender.Size = New System.Drawing.Size(64, 21)
        Me.cbGender.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Gender:"
        '
        'tbDOB
        '
        Me.tbDOB.Location = New System.Drawing.Point(85, 60)
        Me.tbDOB.MaxLength = 10
        Me.tbDOB.Name = "tbDOB"
        Me.tbDOB.Size = New System.Drawing.Size(100, 20)
        Me.tbDOB.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Date of Birth:"
        '
        'cbSuffix
        '
        Me.cbSuffix.FormattingEnabled = True
        Me.cbSuffix.ItemHeight = 13
        Me.cbSuffix.Items.AddRange(New Object() {"", "Sr.", "Jr.", "III", "IV", "V"})
        Me.cbSuffix.Location = New System.Drawing.Point(898, 23)
        Me.cbSuffix.Name = "cbSuffix"
        Me.cbSuffix.Size = New System.Drawing.Size(48, 21)
        Me.cbSuffix.TabIndex = 9
        '
        'tbLastName
        '
        Me.tbLastName.Location = New System.Drawing.Point(647, 24)
        Me.tbLastName.MaxLength = 100
        Me.tbLastName.Name = "tbLastName"
        Me.tbLastName.Size = New System.Drawing.Size(191, 20)
        Me.tbLastName.TabIndex = 4
        '
        'tbMiddleName
        '
        Me.tbMiddleName.Location = New System.Drawing.Point(434, 24)
        Me.tbMiddleName.MaxLength = 100
        Me.tbMiddleName.Name = "tbMiddleName"
        Me.tbMiddleName.Size = New System.Drawing.Size(120, 20)
        Me.tbMiddleName.TabIndex = 3
        '
        'cbTitle
        '
        Me.cbTitle.FormattingEnabled = True
        Me.cbTitle.Items.AddRange(New Object() {"", "Miss", "Mr.", "Mrs.", "Ms.", "Dr."})
        Me.cbTitle.Location = New System.Drawing.Point(85, 24)
        Me.cbTitle.Name = "cbTitle"
        Me.cbTitle.Size = New System.Drawing.Size(51, 21)
        Me.cbTitle.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(856, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Suffix:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Title:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(580, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Last Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(353, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Middle Name:"
        '
        'tbFirstName
        '
        Me.tbFirstName.Location = New System.Drawing.Point(217, 24)
        Me.tbFirstName.MaxLength = 100
        Me.tbFirstName.Name = "tbFirstName"
        Me.tbFirstName.Size = New System.Drawing.Size(120, 20)
        Me.tbFirstName.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(151, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "First Name:"
        '
        'tpCurrentVisit
        '
        Me.tpCurrentVisit.Controls.Add(Me.btnAdmit)
        Me.tpCurrentVisit.Controls.Add(Me.GroupBox4)
        Me.tpCurrentVisit.Controls.Add(Me.GroupBox2)
        Me.tpCurrentVisit.Controls.Add(Me.btnEditPatient)
        Me.tpCurrentVisit.Controls.Add(Me.btnAddPatient)
        Me.tpCurrentVisit.Controls.Add(Me.btnPatientRefresh)
        Me.tpCurrentVisit.Controls.Add(Me.Label19)
        Me.tpCurrentVisit.Controls.Add(Me.lbPatient)
        Me.tpCurrentVisit.Controls.Add(Me.GroupBox3)
        Me.tpCurrentVisit.Location = New System.Drawing.Point(4, 22)
        Me.tpCurrentVisit.Name = "tpCurrentVisit"
        Me.tpCurrentVisit.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCurrentVisit.Size = New System.Drawing.Size(1009, 420)
        Me.tpCurrentVisit.TabIndex = 1
        Me.tpCurrentVisit.Text = "Check In"
        Me.tpCurrentVisit.UseVisualStyleBackColor = True
        '
        'btnAdmit
        '
        Me.btnAdmit.Location = New System.Drawing.Point(709, 356)
        Me.btnAdmit.Name = "btnAdmit"
        Me.btnAdmit.Size = New System.Drawing.Size(75, 23)
        Me.btnAdmit.TabIndex = 11
        Me.btnAdmit.Text = "Admit"
        Me.btnAdmit.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Location = New System.Drawing.Point(694, 176)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(283, 160)
        Me.GroupBox4.TabIndex = 10
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Background"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.tbReferDocLast)
        Me.GroupBox5.Controls.Add(Me.Label22)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Controls.Add(Me.tbReferDocFirst)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 18)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(271, 100)
        Me.GroupBox5.TabIndex = 15
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Referring Doctor Name"
        '
        'tbReferDocLast
        '
        Me.tbReferDocLast.AcceptsReturn = True
        Me.tbReferDocLast.Location = New System.Drawing.Point(61, 56)
        Me.tbReferDocLast.Name = "tbReferDocLast"
        Me.tbReferDocLast.Size = New System.Drawing.Size(148, 20)
        Me.tbReferDocLast.TabIndex = 16
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(19, 58)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(30, 13)
        Me.Label22.TabIndex = 15
        Me.Label22.Text = "Last:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(20, 26)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(29, 13)
        Me.Label23.TabIndex = 14
        Me.Label23.Text = "First:"
        '
        'tbReferDocFirst
        '
        Me.tbReferDocFirst.Location = New System.Drawing.Point(61, 23)
        Me.tbReferDocFirst.Name = "tbReferDocFirst"
        Me.tbReferDocFirst.Size = New System.Drawing.Size(148, 20)
        Me.tbReferDocFirst.TabIndex = 13
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbAttendingDoctor)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.cbAdmissionType)
        Me.GroupBox2.Location = New System.Drawing.Point(309, 20)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(668, 144)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Required Admission Data"
        '
        'cbAttendingDoctor
        '
        Me.cbAttendingDoctor.FormattingEnabled = True
        Me.cbAttendingDoctor.Location = New System.Drawing.Point(134, 59)
        Me.cbAttendingDoctor.Name = "cbAttendingDoctor"
        Me.cbAttendingDoctor.Size = New System.Drawing.Size(236, 21)
        Me.cbAttendingDoctor.TabIndex = 11
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(14, 62)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(90, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Attending Doctor:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(14, 27)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(84, 13)
        Me.Label27.TabIndex = 2
        Me.Label27.Text = "Admission Type:"
        '
        'cbAdmissionType
        '
        Me.cbAdmissionType.FormattingEnabled = True
        Me.cbAdmissionType.Location = New System.Drawing.Point(134, 24)
        Me.cbAdmissionType.Name = "cbAdmissionType"
        Me.cbAdmissionType.Size = New System.Drawing.Size(236, 21)
        Me.cbAdmissionType.TabIndex = 10
        '
        'btnEditPatient
        '
        Me.btnEditPatient.Location = New System.Drawing.Point(139, 356)
        Me.btnEditPatient.Name = "btnEditPatient"
        Me.btnEditPatient.Size = New System.Drawing.Size(75, 23)
        Me.btnEditPatient.TabIndex = 8
        Me.btnEditPatient.Text = "Edit"
        Me.btnEditPatient.UseVisualStyleBackColor = True
        '
        'btnAddPatient
        '
        Me.btnAddPatient.Location = New System.Drawing.Point(58, 356)
        Me.btnAddPatient.Name = "btnAddPatient"
        Me.btnAddPatient.Size = New System.Drawing.Size(75, 23)
        Me.btnAddPatient.TabIndex = 7
        Me.btnAddPatient.Text = "Add Patient"
        Me.btnAddPatient.UseVisualStyleBackColor = True
        '
        'btnPatientRefresh
        '
        Me.btnPatientRefresh.Location = New System.Drawing.Point(228, 356)
        Me.btnPatientRefresh.Name = "btnPatientRefresh"
        Me.btnPatientRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnPatientRefresh.TabIndex = 6
        Me.btnPatientRefresh.Text = "Refresh"
        Me.btnPatientRefresh.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(9, 20)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(48, 13)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "Patients:"
        '
        'lbPatient
        '
        Me.lbPatient.FormattingEnabled = True
        Me.lbPatient.Location = New System.Drawing.Point(58, 20)
        Me.lbPatient.Name = "lbPatient"
        Me.lbPatient.Size = New System.Drawing.Size(232, 316)
        Me.lbPatient.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbAmbulatoryStatus)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.cbAdmitSource)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.cbHospitalService)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.cbPatientClass)
        Me.GroupBox3.Location = New System.Drawing.Point(309, 175)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(367, 161)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Visit Information"
        '
        'cbAmbulatoryStatus
        '
        Me.cbAmbulatoryStatus.FormattingEnabled = True
        Me.cbAmbulatoryStatus.Location = New System.Drawing.Point(109, 53)
        Me.cbAmbulatoryStatus.Name = "cbAmbulatoryStatus"
        Me.cbAmbulatoryStatus.Size = New System.Drawing.Size(236, 21)
        Me.cbAmbulatoryStatus.TabIndex = 12
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(10, 56)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(95, 13)
        Me.Label24.TabIndex = 8
        Me.Label24.Text = "Ambulatory Status:"
        '
        'cbAdmitSource
        '
        Me.cbAdmitSource.FormattingEnabled = True
        Me.cbAdmitSource.Location = New System.Drawing.Point(109, 124)
        Me.cbAdmitSource.Name = "cbAdmitSource"
        Me.cbAdmitSource.Size = New System.Drawing.Size(236, 21)
        Me.cbAdmitSource.TabIndex = 14
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(10, 124)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(73, 13)
        Me.Label25.TabIndex = 6
        Me.Label25.Text = "Admit Source:"
        '
        'cbHospitalService
        '
        Me.cbHospitalService.FormattingEnabled = True
        Me.cbHospitalService.Location = New System.Drawing.Point(109, 87)
        Me.cbHospitalService.Name = "cbHospitalService"
        Me.cbHospitalService.Size = New System.Drawing.Size(236, 21)
        Me.cbHospitalService.TabIndex = 13
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(10, 87)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(87, 13)
        Me.Label26.TabIndex = 4
        Me.Label26.Text = "Hospital Service:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(10, 22)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(71, 13)
        Me.Label28.TabIndex = 1
        Me.Label28.Text = "Patient Class:"
        '
        'cbPatientClass
        '
        Me.cbPatientClass.FormattingEnabled = True
        Me.cbPatientClass.Location = New System.Drawing.Point(109, 19)
        Me.cbPatientClass.Name = "cbPatientClass"
        Me.cbPatientClass.Size = New System.Drawing.Size(236, 21)
        Me.cbPatientClass.TabIndex = 11
        '
        'RegTabControl
        '
        Me.RegTabControl.Controls.Add(Me.tpCurrentVisit)
        Me.RegTabControl.Controls.Add(Me.tpNewPatient)
        Me.RegTabControl.Controls.Add(Me.tpAdmissions)
        Me.RegTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RegTabControl.Location = New System.Drawing.Point(0, 24)
        Me.RegTabControl.Name = "RegTabControl"
        Me.RegTabControl.SelectedIndex = 0
        Me.RegTabControl.Size = New System.Drawing.Size(1017, 446)
        Me.RegTabControl.TabIndex = 2
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(9, 180)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(71, 13)
        Me.Label38.TabIndex = 14
        Me.Label38.Text = "Patient Class:"
        '
        'tbPatientClass
        '
        Me.tbPatientClass.Location = New System.Drawing.Point(123, 177)
        Me.tbPatientClass.Name = "tbPatientClass"
        Me.tbPatientClass.ReadOnly = True
        Me.tbPatientClass.Size = New System.Drawing.Size(219, 20)
        Me.tbPatientClass.TabIndex = 15
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(9, 214)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(87, 13)
        Me.Label39.TabIndex = 16
        Me.Label39.Text = "Hospital Service:"
        '
        'tbHospitalService
        '
        Me.tbHospitalService.Location = New System.Drawing.Point(123, 211)
        Me.tbHospitalService.Name = "tbHospitalService"
        Me.tbHospitalService.ReadOnly = True
        Me.tbHospitalService.Size = New System.Drawing.Size(219, 20)
        Me.tbHospitalService.TabIndex = 17
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1017, 492)
        Me.Controls.Add(Me.RegTabControl)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.Text = "Patient Registration"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.tpAdmissions.ResumeLayout(False)
        Me.tpAdmissions.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.tpNewPatient.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tpCurrentVisit.ResumeLayout(False)
        Me.tpCurrentVisit.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.RegTabControl.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewPatientToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportHL7ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tpAdmissions As System.Windows.Forms.TabPage
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents lbAdmissions As System.Windows.Forms.ListBox
    Friend WithEvents lbPatientAdmission As System.Windows.Forms.ListBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents tpNewPatient As System.Windows.Forms.TabPage
    Friend WithEvents btnSavePatient As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tbSsn As System.Windows.Forms.TextBox
    Friend WithEvents tbAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents tbZipCode As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cbState As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tbCity As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tbAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbBirthOrder As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents rbMultiBirthNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbMultiBirthYes As System.Windows.Forms.RadioButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbPlaceOfBirth As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbReligion As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbMaritalStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cbRace As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbGender As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbDOB As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbSuffix As System.Windows.Forms.ComboBox
    Friend WithEvents tbLastName As System.Windows.Forms.TextBox
    Friend WithEvents tbMiddleName As System.Windows.Forms.TextBox
    Friend WithEvents cbTitle As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbFirstName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tpCurrentVisit As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents tbReferDocLast As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents tbReferDocFirst As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbAttendingDoctor As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cbAdmissionType As System.Windows.Forms.ComboBox
    Friend WithEvents btnEditPatient As System.Windows.Forms.Button
    Friend WithEvents btnAddPatient As System.Windows.Forms.Button
    Friend WithEvents btnPatientRefresh As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lbPatient As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbAmbulatoryStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cbAdmitSource As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cbHospitalService As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cbPatientClass As System.Windows.Forms.ComboBox
    Friend WithEvents RegTabControl As System.Windows.Forms.TabControl
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents tbAttendingDoctor As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents tbVisitDischargeDate As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents tbVisitAdmissionDate As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents tbAdmissionType As System.Windows.Forms.TextBox
    Friend WithEvents btnAdmit As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents tbHomePhone As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents btnDischarge As System.Windows.Forms.Button
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents HelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbAmbulatoryStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents tbPatientClass As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents tbHospitalService As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label

End Class
