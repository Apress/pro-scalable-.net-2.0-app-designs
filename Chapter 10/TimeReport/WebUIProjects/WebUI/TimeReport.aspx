<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TimeReport.aspx.vb" Inherits="WebUI.TimeReport"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>TimeReport</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:datagrid id="DataGridTimeReport" style="Z-INDEX: 101; LEFT: 22px; POSITION: absolute; TOP: 327px"
				runat="server" Width="552px" Height="228px">
				<Columns>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
					<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
				</Columns>
			</asp:datagrid>
			<asp:Button id="btnAdd" style="Z-INDEX: 102; LEFT: 274px; POSITION: absolute; TOP: 126px" runat="server"
				Text="Administrate projects" Visible="False"></asp:Button>
			<asp:DropDownList id="lstAvailableWeekReports" style="Z-INDEX: 103; LEFT: 123px; POSITION: absolute; TOP: 30px"
				runat="server" Width="185px"></asp:DropDownList>
			<asp:Label id="lblWeekNo" style="Z-INDEX: 104; LEFT: 11px; POSITION: absolute; TOP: 29px" runat="server">New report</asp:Label>
			<asp:Label id="lblOngoing" style="Z-INDEX: 105; LEFT: 14px; POSITION: absolute; TOP: 62px"
				runat="server">Ongoing reports</asp:Label>
			<asp:DropDownList id="lstOngoing" style="Z-INDEX: 106; LEFT: 122px; POSITION: absolute; TOP: 61px"
				runat="server" Width="187px" AutoPostBack="True"></asp:DropDownList>
			<asp:Button id="btnAddProject" style="Z-INDEX: 107; LEFT: 26px; POSITION: absolute; TOP: 126px"
				runat="server" Width="139px" Text="Add project to report"></asp:Button>
			<asp:Button id="btnSave" style="Z-INDEX: 108; LEFT: 172px; POSITION: absolute; TOP: 126px" runat="server"
				Text="Save report"></asp:Button>
			<asp:Button id="btnGetReport" style="Z-INDEX: 109; LEFT: 142px; POSITION: absolute; TOP: 91px"
				runat="server" Text="Get selected report"></asp:Button>
			<asp:DataGrid id="dgrdHeader" style="Z-INDEX: 110; LEFT: 23px; POSITION: absolute; TOP: 189px"
				runat="server" Height="51px" Width="548px"></asp:DataGrid></form>
	</body>
</HTML>
