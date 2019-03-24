Imports System.IO

''' <summary>
''' Generates HL7 messages and holds HL7 constants.
''' </summary>
''' <remarks></remarks>
Public Class HL7

    Private Shared mstrSiteName As String = "BIT5494" ' Normally the clinic name.
    Private Shared mstrDestName As String = "LABADT" ' Destination site is a lab for this project.


    Public Shared Sub WriteA01Event(ByVal strFilename As String, ByRef objAdmission As CAdmission, ByRef objPatient As CPatient)

        Dim fileWriter As StreamWriter = Nothing
        Try
            fileWriter = New StreamWriter(strFilename, False)
            fileWriter.WriteLine(GetMSHSegmentForADTA01(CStr(objAdmission.AdmissionID)))
            fileWriter.WriteLine(GetEVNSegment(objAdmission.AdmitDate))
            fileWriter.WriteLine(objPatient.GetSegment())
            fileWriter.WriteLine(objAdmission.GetSegment)

        Catch ex As Exception
            Throw ex
        Finally
            If Not fileWriter Is Nothing Then
                fileWriter.Close()
            End If

        End Try

    End Sub

    Public Shared Function GetMSHSegmentForADTA01(ByVal msgcontrolid As String) As String
        Dim strNow As String = System.DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")
        Dim theMSH As String = GetSeparators()
        theMSH += FieldSeparator + "REGADT" + FieldSeparator + mstrSiteName + FieldSeparator + mstrDestName
        theMSH += FieldSeparator + FieldSeparator + CUtil.GetHL7FormattedDate(strNow) + FieldSeparator + FieldSeparator + "ADT" + ComponentSeparator
        theMSH += "A04" + ComponentSeparator + "ADT_A01" + FieldSeparator + msgcontrolid + FieldSeparator + "P" + FieldSeparator
        theMSH += VERSION + FieldSeparator + FieldSeparator + FieldSeparator
        Return theMSH
    End Function

    Public Shared Function GetEVNSegment(ByVal strAdmitDate As String) As String
        Dim strEVN As String = "EVN" + HL7.FieldSeparator + HL7.FieldSeparator + CUtil.GetHL7FormattedDate(strAdmitDate) + HL7.FieldSeparator + EventReasonCode
        strEVN += HL7.FieldSeparator + HL7.FieldSeparator + HL7.FieldSeparator
        Return strEVN
    End Function
    Public Shared Function GetMSHSegmentForADTA04(ByVal msgcontrolid As String) As String
        Dim theMSH As String = GetSeparators()
        theMSH += FieldSeparator + "REGADT" + FieldSeparator + mstrSiteName + FieldSeparator + mstrDestName
        theMSH += FieldSeparator + FieldSeparator + "199112311501" + FieldSeparator + FieldSeparator + "ADT" + ComponentSeparator
        theMSH += "A04" + ComponentSeparator + "ADT_A01" + FieldSeparator + msgcontrolid + FieldSeparator + "P" + FieldSeparator
        theMSH += VERSION + FieldSeparator + FieldSeparator + FieldSeparator
        Return theMSH
    End Function

    Private Shared Function GetSeparators() As String
        Return MSH_HEADER + FieldSeparator + ComponentSeparator + RepetitionSeparator + EscapeCharacter + SubcomponentSeparator
    End Function

    ''' <summary>
    ''' Message header
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property MSH_HEADER As String
        Get
            Return "MSH"
        End Get
    End Property
    ''' <summary>
    ''' HL7 version
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property VERSION As String
        Get
            Return "2.5"
        End Get
    End Property
    ''' <summary>
    ''' Returns the HL7 field separator
    ''' </summary>
    ''' <value></value>
    ''' <returns>The HL7 field separator</returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property FieldSeparator As String
        Get
            Return "|"
        End Get
    End Property
    ''' <summary>
    ''' Returns the HL7 Component separator
    ''' </summary>
    ''' <value></value>
    ''' <returns>The HL7 Component separator</returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property ComponentSeparator As String
        Get
            Return "^"
        End Get
    End Property
    ''' <summary>
    ''' Returns the HL7 Repetition separator
    ''' </summary>
    ''' <value></value>
    ''' <returns>The HL7 Repetition separator</returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property RepetitionSeparator As String
        Get
            Return "~"
        End Get
    End Property
    ''' <summary>
    ''' Returns the HL7 Escape Character
    ''' </summary>
    ''' <value></value>
    ''' <returns>The HL7 Escape Character</returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property EscapeCharacter As String
        Get
            Return "\"
        End Get
    End Property
    ''' <summary>
    ''' Returns the HL7 Subcomponent separator
    ''' </summary>
    ''' <value></value>
    ''' <returns>The HL7 Subcomponent separator</returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property SubcomponentSeparator As String
        Get
            Return "&"
        End Get
    End Property
    ''' <summary>
    ''' Currently only "02" Physician/health practioner order
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property EventReasonCode As String
        Get
            Return "02"
        End Get
    End Property

End Class
