''' <summary>
''' This class is based on the numeric class from the BIT5495 lecture notes
'''
''' </summary>
''' <remarks></remarks>
Public Class VTListItemString
    Private mstrIVal As String
    Private mstrID As String

    Public Sub New()  ' Default constructor
    End Sub

    Public Sub New(ByVal strIVal As String, ByVal strID As String)
        ItemValue = strIVal
        ItemID = strID
    End Sub
    Property ItemValue() As String
        Get
            Return mstrIVal
        End Get
        Set(ByVal Value As String)
            mstrIVal = Value
        End Set
    End Property
    Public Property ItemID() As String
        Get
            Return mstrID
        End Get
        Set(ByVal Value As String)
            mstrID = Value
        End Set
    End Property
    Public Overrides Function ToString() As String
        Return mstrIVal
    End Function
    Public Function Item(ByVal intIndex As Integer) As String
        If intIndex = 0 Then
            Return mstrID
        End If
        Return mstrIVal
    End Function

End Class
