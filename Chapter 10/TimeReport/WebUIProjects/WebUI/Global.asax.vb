Imports System.Web
Imports System.Web.SessionState
Imports System.Security.Principal
Imports System.Web.Security

Public Class Global
    Inherits System.Web.HttpApplication

#Region " Component Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the user
        Dim cookieName As String = FormsAuthentication.FormsCookieName
        Dim aCookie As HttpCookie = Context.Request.Cookies(cookieName)
        Dim DELIMITER As Char = "|"

        If cookieName = "" Or aCookie Is Nothing Then
            'there is no authentication cookie, proceed to the login.. 
        Else
            'There is an authentication cookie.
            Dim authTicket As FormsAuthenticationTicket

            Try
                If aCookie.Value.Length > 0 Then
                    authTicket = FormsAuthentication.Decrypt(aCookie.Value)
                    If Not authTicket Is Nothing Then
                        Dim roles() As String = authTicket.UserData.Split(DELIMITER)
                        Dim id As FormsIdentity = New FormsIdentity(authTicket)
                        Dim principal As GenericPrincipal = New GenericPrincipal(id, roles)
                        Context.User = principal
                    End If
                End If
            Catch ex As Exception
                'log error

            End Try
        End If
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class
