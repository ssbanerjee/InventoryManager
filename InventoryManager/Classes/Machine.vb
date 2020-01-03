Public Class Machine
    Public Property machineID() As String
    Public Property machineName() As String
    Public Property assetTag() As String
    Public Property serialNumber() As String
    Public Property SIM() As String
    Public Property IMEI() As String
    Public Property category() As String
    Public Property model() As String
    Public Property centerNumber() As String
    Public Property assetState() As String
    Public Property costCenter() As String
    Public Property condition() As String
    Public Property MESD() As String
    Public Property received() As String
    Public Property acquisition() As String
    Public Property employee() As String

    Public Sub New(ByVal machineID As String, ByVal machineName As String, ByVal assetTag As String, ByVal serialNumber As String,
                   ByVal SIM As String, ByVal IMEI As String, ByVal category As String, ByVal model As String, ByVal centerNumber As String,
                   ByVal assetState As String, ByVal costCenter As String, ByVal condition As String, ByVal MESD As String,
                   ByVal received As String, ByVal acquisition As String, ByVal employee As String)
        Me.machineID = machineID
        Me.machineName = machineName
        Me.assetTag = assetTag
        Me.serialNumber = serialNumber
        Me.SIM = SIM
        Me.IMEI = IMEI
        Me.category = category
        Me.model = model
        Me.centerNumber = centerNumber
        Me.assetState = assetState
        Me.costCenter = costCenter
        Me.condition = condition
        Me.MESD = MESD
        Me.received = received
        Me.acquisition = acquisition
        Me.employee = employee
    End Sub
End Class
