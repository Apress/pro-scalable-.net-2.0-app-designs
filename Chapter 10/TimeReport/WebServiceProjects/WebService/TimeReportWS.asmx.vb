Imports System.Web.Services
Imports SystemFrameworks

<System.Web.Services.WebService(Namespace:="http://msdotnet.nu/WebService/TimeReport/TimeReportService")> _
Public Class TimeReportWS
    Inherits System.Web.Services.WebService

#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()

        'Add your own initialization code after the InitializeComponent() call

    End Sub

    'Required by the Web Services Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: This procedure is required by the Web Services Designer
        'Do not modify it using the code editor.
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

    <WebMethod(Description:="Saves a timereport", EnableSession:=False)> _
    Public Function SaveTimeReport(ByVal ds As dsTimeReport)
        Dim objTimeReport As SystemFrameworks.ITimeReportAsync = New BusinessRules.TimeReport
        Try
            If Not HttpContext.Current.User.Identity.IsAuthenticated Then
                Throw New Exception("User is not authenticated.")
            Else
                objTimeReport.SaveTimeReport(ds)
            End If
        Catch exp As Exception
            Throw exp
        Finally
            objTimeReport = Nothing
        End Try
    End Function

    <WebMethod(Description:="Gets a timereport", EnableSession:=False)> _
   Public Function GetTimeReport(ByVal WeekNo As Integer) As dsTimeReport
        Dim objTimeReport As New BusinessRules.TimeReport
        Try
            If Not HttpContext.Current.User.Identity.IsAuthenticated Then
                Throw New Exception("User is not authenticated.")
            Else
                Return objTimeReport.GetTimeReport(HttpContext.Current.User.Identity.Name, WeekNo)
            End If
        Catch exp As Exception
            Throw exp
        Finally
            objTimeReport = Nothing
        End Try
    End Function

End Class
