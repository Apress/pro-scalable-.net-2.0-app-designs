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
    Public Function SaveTimeReport(ByVal UserID As String, ByVal ds As dsTimeReport)
        Dim objTimeReport As BusinessRules.ITimeReportAsync = New BusinessRules.TimeReport
        Try
            objTimeReport.SaveTimeReport(UserID, ds)
        Catch exp As Exception
            Throw exp
        Finally
            objTimeReport = Nothing
        End Try
    End Function

    <WebMethod(Description:="Gets a timereport", EnableSession:=False)> _
   Public Function GetTimeReport(ByVal UserID As String, ByVal WeekNo As Integer) As dsTimeReport
        Dim objTimeReport As New BusinessRules.TimeReport
        Try
            'If Not HttpContext.Current.User.Identity.IsAuthenticated Then
            'Throw New Exception("User is not authenticated.")
            'Else
            Return objTimeReport.GetTimeReport(UserID, WeekNo)
            'End If
        Catch exp As Exception
            Throw exp
        Finally

            objTimeReport = Nothing
        End Try
    End Function
    <WebMethod(Description:="Gets all ongoing reports for a specific user", EnableSession:=False)> _
      Public Function GetOngoingReports(ByVal UserID As String) As dsOngoingReports
        Dim objTimeReport As New BusinessRules.TimeReport
        Try
            'If Not HttpContext.Current.User.Identity.IsAuthenticated Then
            'Throw New Exception("User is not authenticated.")
            'Else
            Return objTimeReport.GetOngoingReports(UserID)
            'End If
        Catch exp As Exception
            Throw exp
        Finally

            objTimeReport = Nothing
        End Try
    End Function
    <WebMethod(Description:="Gets all projects for a specific user", EnableSession:=False)> _
  Public Function GetAllProjects(ByVal UserID As String) As dsProjects
        Dim objTimeReport As New BusinessRules.TimeReport
        Try
            Return objTimeReport.GetAllProjects(UserID)
        Catch exp As Exception
            Throw exp
        Finally

            objTimeReport = Nothing
        End Try
    End Function
    <WebMethod(Description:="Gets all available weekreports for a specific user", EnableSession:=False)> _
Public Function GetAvailableWeekReports(ByVal UserID As String) As dsWeekReports
        Dim objTimeReport As New BusinessRules.TimeReport
        Try
            Return objTimeReport.GetAvailableWeekReports(UserID)
        Catch exp As Exception
            Throw exp
        Finally
            objTimeReport = Nothing
        End Try
    End Function
    <WebMethod(Description:="Gets all available weekreports for a specific user", EnableSession:=False)> _
Public Function UpdateUserReport(ByVal UserID As String, ByVal report As dsTimeReport) As dsWeekReports
        Dim objTimeReport As New BusinessRules.TimeReport
        Try
            objTimeReport.SaveTimeReport(UserID, report)
        Catch exp As Exception
            Throw exp
        Finally
            objTimeReport = Nothing
        End Try
    End Function
End Class
