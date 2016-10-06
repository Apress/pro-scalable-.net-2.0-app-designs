Imports System.Web.Services

<System.Web.Services.WebService(Namespace := "http://tempuri.org/WebService/AuthenticateUser")> _
Public Class AuthenticateUser
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
        components = New System.ComponentModel.Container()
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

    <WebMethod(Description:="Get a users's groups", EnableSession:=False)> _
    Public Function GetUserGroups(ByVal domain As String, _
                                  ByVal userName As String, _
                                  ByVal password As String) As String
        Dim objUser As BusinessRules.User = New BusinessRules.User
        Try
            'If Not HttpContext.Current.User.Identity.IsAuthenticated Then
            'Throw New Exception("User is not authenticated.")
            'Else
                Return objUser.GetUserGroups(domain, userName, password)
            'End If
        Catch exp As Exception
            Throw exp
        Finally
            objUser = Nothing
        End Try
    End Function
End Class
