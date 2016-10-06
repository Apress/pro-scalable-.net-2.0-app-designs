<%@ Page Language="vb" AutoEventWireup="false" Codebehind="login.aspx.vb" Inherits="WebUI.login"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>login</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:TextBox id="txtDomain" style="Z-INDEX: 101; LEFT: 125px; POSITION: absolute; TOP: 17px"
				runat="server" Width="192px" Height="29px"></asp:TextBox>
			<asp:TextBox id="txtUserName" style="Z-INDEX: 102; LEFT: 124px; POSITION: absolute; TOP: 67px"
				runat="server" Width="192px" Height="29px"></asp:TextBox>
			<asp:Button id="btnLogin" style="Z-INDEX: 103; LEFT: 259px; POSITION: absolute; TOP: 149px"
				runat="server" Text="Login"></asp:Button>
			<asp:TextBox id="txtPassword" style="Z-INDEX: 104; LEFT: 125px; POSITION: absolute; TOP: 108px"
				runat="server" TextMode="Password" Width="192" Height="29"></asp:TextBox>
			<asp:Label id="lblDomain" style="Z-INDEX: 105; LEFT: 11px; POSITION: absolute; TOP: 14px" runat="server">Domain:</asp:Label>
			<asp:Label id="lblUserName" style="Z-INDEX: 106; LEFT: 18px; POSITION: absolute; TOP: 67px"
				runat="server">Username:</asp:Label>
			<asp:Label id="lblPassword" style="Z-INDEX: 107; LEFT: 15px; POSITION: absolute; TOP: 111px"
				runat="server">Password</asp:Label>
			<asp:RequiredFieldValidator id="reqDomain" style="Z-INDEX: 108; LEFT: 329px; POSITION: absolute; TOP: 26px"
				runat="server" ErrorMessage="You must specify your domain" ControlToValidate="txtDomain"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="reqUserName" style="Z-INDEX: 109; LEFT: 328px; POSITION: absolute; TOP: 69px"
				runat="server" ErrorMessage="Please , type your username." ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="reqPassword" style="Z-INDEX: 110; LEFT: 328px; POSITION: absolute; TOP: 112px"
				runat="server" ErrorMessage="Password cannot be empty." ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
			<asp:ValidationSummary id="valSummary" style="Z-INDEX: 111; LEFT: 17px; POSITION: absolute; TOP: 190px"
				runat="server" Width="297px"></asp:ValidationSummary>
		</form>
	</body>
</HTML>
