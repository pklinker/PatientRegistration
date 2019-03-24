''' <summary>
''' This class is from the BIT5495 lecture notes
'''
''' </summary>
''' <remarks></remarks>
Public Class VTListItemNumeric
    Private mstrIVal As String
    Private mintIDNum As Integer

    Public Sub New()  ' Default constructor
    End Sub

    Public Sub New(ByVal strIVal As String, ByVal intIDNum As Integer)
        ItemValue = strIVal
        ItemID = intIDNum
    End Sub
    Property ItemValue() As String
        Get
            Return mstrIVal
        End Get
        Set(ByVal Value As String)
            mstrIVal = Value
        End Set
    End Property
    Public Property ItemID() As Integer
        Get
            Return mintIDNum
        End Get
        Set(ByVal Value As Integer)
            mintIDNum = Value
        End Set
    End Property
    Public Overrides Function ToString() As String
        Return mstrIVal
    End Function

End Class
