Imports System.EnterpriseServices
Imports SystemFrameworks
<ObjectPooling(Enabled:=True, MinPoolSize:=1, MaxPoolSize:=20, CreationTimeOut:=25000), JustInTimeActivation(True)> _
    Public Class TimeReport
    Inherits ServicedComponent
    'Function that returns the requested timereport.
    Public Function GetTimeReport(ByVal userId As String, ByVal weekNo As Integer) As SystemFrameworks.dsTimeReport
        'Our code goes here...
        Dim objTimeReport As BusinessRules.TimeReport
        Try
            If userId.Length > 0 And WeekNo > 0 And WeekNo < 53 Then
                objTimeReport = New BusinessRules.TimeReport
                Return objTimeReport.GetTimeReport(userId, WeekNo)
            Else
                'not valid input parameters..
                Throw New Exception("Input parameters are invalid. UserId cannot be empty and/or WeekNumber not between 1 and 52)")
            End If
        Catch e As Exception
            'throw it on the caller. .
            Throw e
        Finally
            objTimeReport.Dispose()
            objTimeReport = Nothing
        End Try

    End Function

    Public Function GetAllProjects(ByVal userId As String) As SystemFrameworks.dsProjects
        'Our code goes here...
        Dim objTimeReport As BusinessRules.TimeReport
        Try
            If userId.Length > 0 Then
                objTimeReport = New BusinessRules.TimeReport
                Return objTimeReport.GetAllProjects(userId)
            Else
                'not valid input parameters..
                Throw New Exception("Input parameters are invalid. UserId cannot be empty and/or WeekNumber not between 1 and 52)")
            End If
        Finally
            objTimeReport.Dispose()
            objTimeReport = Nothing
        End Try
    End Function

    Public Function GetAvailableWeekReports(ByVal userId As String) As SystemFrameworks.dsWeekReports
        'Our code goes here...
        Dim objTimeReport As BusinessRules.TimeReport
        Try
            If userId.Length > 0 Then
                objTimeReport = New BusinessRules.TimeReport
                Return objTimeReport.GetAvailableWeekReports(userId)
            Else
                'not valid input parameters..
                Throw New Exception("Input parameters are invalid. UserId cannot be empty and/or WeekNumber not between 1 and 52)")
            End If
        Finally
            objTimeReport.Dispose()
            objTimeReport = Nothing
        End Try
    End Function
    Public Function GetOngoingProjects(ByVal userId As String) As SystemFrameworks.dsOngoingReports
        'Our code goes here...
        Dim objTimeReport As BusinessRules.TimeReport
        Try
            If userId.Length > 0 Then
                objTimeReport = New BusinessRules.TimeReport
                Return objTimeReport.GetOngoingReports(userId)
            Else
                'not valid input parameters..
                Throw New Exception("Input parameters are invalid. UserId cannot be empty and/or WeekNumber not between 1 and 52)")
            End If
        Catch e As Exception
            'throw it on the caller. .
            Throw e
        Finally
            objTimeReport.Dispose()
            objTimeReport = Nothing
        End Try

    End Function

    Public Function SaveTimeReport(ByVal userId As String, ByVal ds As dsTimeReport)
        Dim objTimeReport As BusinessRules.TimeReport
        Try
            objTimeReport.SaveTimeReport(userId, ds)
        Catch ex As Exception
            Throw ex
        Finally
            objTimeReport.Dispose()
            objTimeReport = Nothing
        End Try
    End Function

    Public Function SaveTimeReportAsync(ByVal userId As String, ByVal ds As dsTimeReport)
        Dim objTimeReport As BusinessRules.ITimeReportAsync

        Try
            objTimeReport = New BusinessRules.TimeReport
            objTimeReport.SaveTimeReport(userId, ds)
        Catch ex As Exception
            Throw ex
        Finally
            objTimeReport = Nothing
        End Try
    End Function
End Class
