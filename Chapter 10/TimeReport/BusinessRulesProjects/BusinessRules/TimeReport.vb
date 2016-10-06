Imports System.EnterpriseServices
Imports SystemFrameworks
<InterfaceQueuing(Interface:="ITimeReportAsync"), _
ObjectPooling(Enabled:=True, MinPoolSize:=1, MaxPoolSize:=10, CreationTimeOut:=25000), _
JustInTimeActivation(True)> _
    Public Class TimeReport
    Inherits ServicedComponent
    Implements ITimeReportAsync

    Public Function GetTimeReport(ByVal userId As String, _
                                  ByVal weekNo As Integer) As dsTimeReport
        'Our code goes here...
        Dim objTimeReport As DataAccess.TimeReport
        Try
            objTimeReport = New DataAccess.TimeReport
            Return objTimeReport.GetTimeReport(userId, WeekNo)
        Finally
            objTimeReport.Dispose()
            objTimeReport = Nothing
        End Try

    End Function
    Public Function GetOngoingReports(ByVal userId As String) As dsOngoingReports
        'Our code goes here...
        Dim objTimeReport As DataAccess.TimeReport
        Try
            objTimeReport = New DataAccess.TimeReport
            Return objTimeReport.GetOngoingReports(userId)
        Finally
            objTimeReport.Dispose()
            objTimeReport = Nothing
        End Try

    End Function
    Public Function GetAllProjects(ByVal userId As String) As dsProjects
        'Our code goes here...
        Dim objTimeReport As DataAccess.TimeReport
        Try
            objTimeReport = New DataAccess.TimeReport
            Return objTimeReport.GetAllProjects(userId)
        Finally
            objTimeReport.Dispose()
            objTimeReport = Nothing
        End Try

    End Function
    Public Function GetAvailableWeekReports(ByVal userId As String) As dsWeekReports
        'Our code goes here...
        Dim objTimeReport As DataAccess.TimeReport
        Try
            objTimeReport = New DataAccess.TimeReport
            Return objTimeReport.GetAvailableWeekReports(userId)
        Finally
            objTimeReport.Dispose()
            objTimeReport = Nothing
        End Try

    End Function
    Public Sub SaveTimeReport(ByVal userId As String, ByVal ds As dsTimeReport) Implements ITimeReportAsync.SaveTimeReport
        Dim objTimeReport As DataAccess.TimeReport
        Try
            objTimeReport = New DataAccess.TimeReport
            objTimeReport.SaveTimeReport(ds)
        Finally
            objTimeReport.Dispose()
            objTimeReport = Nothing
        End Try
    End Sub
End Class
