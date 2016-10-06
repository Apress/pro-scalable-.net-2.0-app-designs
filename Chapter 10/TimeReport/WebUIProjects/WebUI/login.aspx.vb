Imports System.Web.Security
Public Class login
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtDomain As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUserName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblDomain As System.Web.UI.WebControls.Label
    Protected WithEvents lblUserName As System.Web.UI.WebControls.Label
    Protected WithEvents lblPassword As System.Web.UI.WebControls.Label
    Protected WithEvents btnLogin As System.Web.UI.WebControls.Button
    Protected WithEvents reqDomain As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents reqUserName As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents reqPassword As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents valSummary As System.Web.UI.WebControls.ValidationSummary

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub


    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim objUser As AuthenticateUserWebService.AuthenticateUser = New AuthenticateUserWebService.AuthenticateUser
        Dim groups As String

        Try
            'try to retireve the users groups. 
            'temporary removed groups = objUser.GetUserGroups(txtDomain.Text, txtUserName.Text, txtPassword.Text)
            groups = "admin|contributor"
            Dim authenticationTicket As FormsAuthenticationTicket = New FormsAuthenticationTicket(1, txtUserName.Text, DateTime.Now, DateTime.Now.AddMinutes(30), False, groups)
            'encrypt ticket 
            Dim encryptedTicket As String = FormsAuthentication.Encrypt(authenticationTicket)
            Dim cookie As HttpCookie = New HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
            
            Response.Cookies.Add(cookie)
            'Response.Redirect(FormsAuthentication.GetRedirectUrl(txtUserName.Text, False))
            FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, False)
        Catch ex As Exception
            Dim lblMessage As New Label
            lblMessage.Text = "Invalid domain,username or password."
            valSummary.Controls.Add(lblMessage)
        Finally
            objUser.Dispose()
            objUser = Nothing
        End Try
    End Sub
End Class
