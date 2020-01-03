Public Class Center
    Public Property centerNumber() As String
    Public Property name() As String
    Public Property region() As String
    Public Property district() As String
    Public Property address() As String
    Public Property city() As String
    Public Property state() As String
    Public Property zipCode() As String
    Public Property phoneNumber() As String
    Public Property circuitProvider() As String
    Public Property circuitID() As String
    Public Property WAN() As String

    Public Sub New(ByVal centerNumber As String, ByVal name As String, ByVal region As String, ByVal district As String,
                   ByVal address As String, ByVal city As String, ByVal state As String, ByVal zipCode As String,
                   ByVal phoneNumber As String, ByVal circuitProvider As String, ByVal circuitID As String, ByVal WAN As String)
        Me.centerNumber = centerNumber
        Me.name = name
        Me.region = region
        Me.district = district
        Me.address = address
        Me.city = city
        Me.state = state
        Me.zipCode = zipCode
        Me.phoneNumber = phoneNumber
        Me.circuitProvider = circuitProvider
        Me.circuitID = circuitID
        Me.WAN = WAN
    End Sub
End Class
