Imports System.EnterpriseServices
Imports SystemFrameworks
<ObjectPooling(Enabled:=True, MinPoolSize:=1, MaxPoolSize:=10, CreationTimeOut:=25000), JustInTimeActivation(True)> _
Public Class User
    Inherits EnterpriseServices.ServicedComponent

    Public Function GetUserGroups(ByVal domain As String, _
                                      ByVal username As String, _
                                      ByVal password As String) As String

        Dim objData As DataAccess.LdapAuthentication = New DataAccess.LdapAuthentication
        Try
            Return objData.GetUserGroups(domain, username, password)
        Catch exp As Exception
            Throw exp
        Finally
            objData.Dispose()
            objData = Nothing
        End Try

    End Function

End Class
