
Public Class TimeReport
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents DataGridTimeReport As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnGetTimeReport As System.Web.UI.WebControls.Button
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents lstAvailableWeekReports As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblWeekNo As System.Web.UI.WebControls.Label
    Protected WithEvents lblOngoing As System.Web.UI.WebControls.Label
    Protected WithEvents lstOngoing As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnAddProject As System.Web.UI.WebControls.Button
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object
    Private dsMyAvailableWeeks As TimeReportWebService.dsWeekReports
    Private dsMyOngoingReports As TimeReportWebService.dsOngoingReports
    Protected WithEvents btnGetReport As System.Web.UI.WebControls.Button
    Protected WithEvents dgrdHeader As System.Web.UI.WebControls.DataGrid
    Private dsTimeReport As TimeReportWebService.dsTimeReport
    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not IsPostBack Then
            'this is the first time the page is loaded. fill the datagrid.

            Dim objWS As TimeReportWebService.TimeReportWS = New TimeReportWebService.TimeReportWS
            dsMyAvailableWeeks = objWS.GetAvailableWeekReports(HttpContext.Current.User.Identity.Name)
            dsMyOngoingReports = objWS.GetOngoingReports(HttpContext.Current.User.Identity.Name)
            objWS.Dispose()
            'Bind them to the controls.
            With lstOngoing
                .DataSource = dsMyOngoingReports
                .DataMember = "Reports"
                .DataTextField = "WeekNumber"
                .DataValueField = "UserReportsID"
                .DataBind()
            End With
            With lstAvailableWeekReports
                .DataSource = dsMyAvailableWeeks
                .DataTextField = "WeekNumber"
                .DataValueField = "WeekReportID"
                .DataMember = "Reports"
                .DataBind()
            End With
            If context.User.IsInRole("Admin") Then
                btnAdd.Visible = True
            Else
                btnAdd.Visible = False
            End If
        End If
    End Sub
    Private Sub retrieveTimeReport(ByVal WeekNo As Integer)
        Dim objWS As TimeReportWebService.TimeReportWS = New TimeReportWebService.TimeReportWS
        dsTimeReport = objWS.GetTimeReport(HttpContext.Current.User.Identity.Name, WeekNo)
        'do databinding..
        bindReportHeaderToGrid()
        bindReportLinesToGrid()

    End Sub
    Private Sub bindReportHeaderToGrid()
        With dgrdHeader
            .DataSource = dsTimeReport
            .DataMember = "UserReport"
            .DataKeyField = "UserReportsID"
            .DataBind()
        End With
    End Sub
    Private Sub bindReportLinesToGrid()
        With DataGridTimeReport
            .DataSource = dsTimeReport
            .DataMember = "ReportLines"
            .DataKeyField = "ReportLIneID"
            .DataBind()
        End With

    End Sub
    Private Sub lstOngoing_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstOngoing.SelectedIndexChanged
        If lstOngoing.SelectedValue.Length > 0 Then
            retrieveTimeReport(lstOngoing.SelectedValue)
        End If
    End Sub

    Private Sub lstAvailableWeekReports_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAvailableWeekReports.SelectedIndexChanged
        If lstAvailableWeekReports.SelectedValue.Length > 0 Then
            retrieveTimeReport(lstAvailableWeekReports.SelectedValue)
        End If
    End Sub

    Private Sub DataGridTimeReport_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGridTimeReport.EditCommand
        DataGridTimeReport.EditItemIndex = e.Item.ItemIndex
         bindReportLinesToGrid()
    End Sub

    Private Sub DataGridTimeReport_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGridTimeReport.CancelCommand
        DataGridTimeReport.EditItemIndex = -1
        bindReportLinesToGrid()
    End Sub

    Private Sub DataGridTimeReport_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGridTimeReport.UpdateCommand
        Dim key As String = DataGridTimeReport.DataKeys(e.Item.ItemIndex).ToString()
        Dim numberOfHours, typeOfTime As String
        Dim tb As TextBox
        Dim lst As DropDownList
        tb = CType(e.Item.Cells(8).Controls(0), TextBox)
        numberOfHours = tb.Text
        lst = CType(e.Item.Cells(6).Controls(0), DropDownList)
        typeOfTime = lst.SelectedValue
        'update ds
        Dim r As TimeReportWebService.dsTimeReport.ReportLineRow

        r = dsTimeReport.ReportLine.Rows.Find(key)
        If Not r Is Nothing Then
            r.ReportedHours = numberOfHours
            r.TimeTypeID = typeOfTime

            'update db
            Dim objWS As TimeReportWebService.TimeReportWS = New TimeReportWebService.TimeReportWS
            'objWS.UpdateTimeReport(HttpContext.Current.User.Identity.Name,dsTimeReport)
            objWS.Dispose()
        End If
        bindReportLinesToGrid()
    End Sub

    Private Sub btnGetReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetReport.Click
        If lstOngoing.SelectedValue.Length > 0 Then
            retrieveTimeReport(lstOngoing.SelectedValue)
        End If
    End Sub

    Private Sub DataGridTimeReport_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGridTimeReport.ItemDataBound
        If (e.Item.ItemType = ListItemType.EditItem) Then
            Dim i As Integer
            For i = 0 To e.Item.Controls.Count - 1
                If (e.Item.Controls(i).Controls(0).GetType().ToString() = "System.Web.UI.WebControls.TextBox") Then
                    Dim tb As TextBox
                    tb = e.Item.Controls(i).Controls(0)
                    tb.Text = Server.HtmlDecode(tb.Text)
                End If
            Next
        End If

    End Sub
End Class
