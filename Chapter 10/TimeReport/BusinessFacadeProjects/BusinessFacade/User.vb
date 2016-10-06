Imports System.EnterpriseServices
Imports SystemFrameworks
<ObjectPooling(Enabled:=True, MinPoolSize:=1, MaxPoolSize:=20, CreationTimeOut:=25000), JustInTimeActivation(True)> _
Public Class User
    Public Function GetUserGroups(ByVal domain As String, _
                                ByVal username As String, _
                                ByVal password As String) As String

        Dim objBusiness As New BusinessRules.User
        Try
            Return objBusiness.GetUserGroups(domain, username, password)
        Catch exp As Exception
            Throw exp
        Finally
            objBusiness.Dispose()
            objBusiness = Nothing
        End Try

    End Function

End Class
