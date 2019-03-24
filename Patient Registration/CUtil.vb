Imports System.Globalization

''' <summary>
''' Utility classes
''' </summary>
''' <remarks></remarks>
Public Class CUtil
    ''' <summary>
    ''' Verify a string is a date in the proper format.  The expected format is MM/DD/YYYY.
    ''' </summary>
    ''' <param name="strDate">Date (hopefully) in standard format: MM/dd/yyyy HH:mm:ss</param>
    ''' <returns>true if date is in proper format; false otherwise</returns>
    ''' <remarks></remarks>
    Public Shared Function VerifyDate(ByVal strDate As String) As Boolean
        If strDate Is Nothing Or strDate = "" Then
            Return False
        End If
        Dim charSeparator(0) As Char
        charSeparator(0) = CChar("/")
        Dim strSubStrings() = strDate.Split(charSeparator)
        If strSubStrings.Length <> 3 Then
            Return False ' need 3 fields: month day year
        End If
        Dim testDate As Date
        Try
            'If conversion fails it will throw an exception so it isn't a date.
            'Date constructor is year, month, day order
            testDate = New Date(Convert.ToInt16(strSubStrings(2)), Convert.ToInt16(strSubStrings(0)), Convert.ToInt16(strSubStrings(1)))

        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    ''' <summary>
    ''' REturns the date in HL7 format: yyyyMMddHHmmss
    ''' </summary>
    ''' <param name="strDate">Date in standard format: MM/dd/yyyy HH:mm:ss</param>
    ''' <returns>Formatted date.</returns>
    ''' <remarks></remarks>
    Public Shared Function GetHL7FormattedDate(ByVal strDate As String) As String
        Dim strNewDate As String = strDate
        Try

            Dim dtOrigDate As DateTime = New DateTime
            dtOrigDate = Convert.ToDateTime(strDate)
            strNewDate = dtOrigDate.ToString("yyyyMMddHHmmss")
        Catch ex As FormatException

        End Try

        Return strNewDate
    End Function

    ''' <summary>
    ''' Verifies phone number is in xxx-xxx-xxxx format
    ''' </summary>
    ''' <param name="strPhoneNum"></param>
    ''' <returns>true if the phone number is the correct format.</returns>
    ''' <remarks></remarks>
    Public Shared Function VerifyPhoneNumber(ByVal strPhoneNum As String) As Boolean
        If strPhoneNum Is Nothing Or strPhoneNum = "" Then
            Return False
        End If
        Dim charSeparator(0) As Char
        charSeparator(0) = CChar("-")
        Dim strSubStrings() = strPhoneNum.Split(charSeparator)
        If strSubStrings.Length <> 3 Then
            Return False ' need 3 fields: area code, exchange, and extension
        End If
        If IsNumeric(strSubStrings(0)) And IsNumeric(strSubStrings(1)) And IsNumeric(strSubStrings(2)) Then
            Return True
        End If
        Return False
    End Function
End Class
