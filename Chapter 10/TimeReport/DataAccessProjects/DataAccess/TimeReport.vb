'Imports DataAccess.DataHelper
Imports SystemFrameworks
Imports System.EnterpriseServices
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

<EnterpriseServices.ConstructionEnabled(True), _
ObjectPooling(Enabled:=True, MinPoolSize:=1, MaxPoolSize:=5, CreationTimeOut:=25000)> _
Public Class TimeReport
    Inherits ServicedComponent
    'Private objDataHelper As DataAccess.DataHelper
    Private strConnection As String
#Region " Component Designer generated code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
    End Sub

    'Component overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region
#Region "Public functions"
    Public Function GetTimeReport(ByVal userId As String, ByVal weekNo As Integer) As dsTimeReport
        Dim ds As dsTimeReport = New dsTimeReport

        Try
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim db As Database = DatabaseFactory.CreateDatabase()
            Dim dbCommandWrapper As DBCommandWrapper = db.GetStoredProcCommandWrapper("getTimeReport")
            dbCommandWrapper.AddInParameter("@userId", DbType.Int32, userId)
            dbCommandWrapper.AddInParameter("@weekNo", DbType.Int32, weekNo)
            'DataSet that will hold the returned results		
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture
            db.LoadDataSet(dbCommandWrapper, ds, New String() {"UserReport", "ReportLines"})
            Return ds
        Finally
        End Try
    End Function
    Public Function SaveTimeReport(ByVal ds As dsTimeReport)
        Try
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim db As Database = DatabaseFactory.CreateDatabase()
            Dim dbInsertCommandWrapper As DBCommandWrapper = db.GetStoredProcCommandWrapper("InsertTimeReport")
            Dim dbUpdateCommandWrapper As DBCommandWrapper = db.GetStoredProcCommandWrapper("UpdateTimeReport")
            Dim dbDeleteCommandWrapper As DBCommandWrapper = db.GetStoredProcCommandWrapper("DeleteTimeReport")

            dbInsertCommandWrapper.AddInParameter("@Id", DbType.Int32)
            dbInsertCommandWrapper.AddInParameter("@StartDate", DbType.DateTime)
            dbInsertCommandWrapper.AddInParameter("@EndDate", DbType.DateTime)
            dbInsertCommandWrapper.AddInParameter("@weekNo", DbType.Int32)
            dbInsertCommandWrapper.AddInParameter("@ExpectedHours", DbType.Int32)
            dbInsertCommandWrapper.AddInParameter("@Comment", DbType.String)
            dbInsertCommandWrapper.AddInParameter("@Status", DbType.Int32)

            'DataSet that will hold the returned results		
            db.UpdateDataSet(ds, "Reports", dbInsertCommandWrapper, dbUpdateCommandWrapper, dbDeleteCommandWrapper, UpdateBehavior.Transactional)

        Finally
        End Try
    End Function

    Public Function GetOngoingReports(ByVal userId As String) As dsOngoingReports
        Dim ds As dsOngoingReports = New dsOngoingReports
        Try
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim db As Database = DatabaseFactory.CreateDatabase()
            Dim dbCommandWrapper As DBCommandWrapper = db.GetStoredProcCommandWrapper("getOngoingReports")
            dbCommandWrapper.AddInParameter("@userId", DbType.Int32, userId)
            'DataSet that will hold the returned results		
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture
            db.LoadDataSet(dbCommandWrapper, ds, New String() {"Reports"})
            Return ds
        Finally
        End Try
    End Function
    Public Function GetAllProjects(ByVal userId As String) As dsProjects
        Dim ds As dsProjects = New dsProjects
        Try
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim db As Database = DatabaseFactory.CreateDatabase()
            Dim dbCommandWrapper As DBCommandWrapper = db.GetStoredProcCommandWrapper("getAllProjects")
            dbCommandWrapper.AddInParameter("@userId", DbType.Int32, userId)
            'DataSet that will hold the returned results		
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture
            db.LoadDataSet(dbCommandWrapper, ds, New String() {"Projects"})
            Return ds
        Finally
        End Try
    End Function
    Public Function GetAvailableWeekReports(ByVal userId As String) As dsWeekReports
        Dim ds As dsWeekReports = New dsWeekReports
        Try
            ds.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim db As Database = DatabaseFactory.CreateDatabase()
            Dim dbCommandWrapper As DBCommandWrapper = db.GetStoredProcCommandWrapper("getAvailableWeekReports")
            dbCommandWrapper.AddInParameter("@userId", DbType.Int32, userId)
            'DataSet that will hold the returned results		
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture
            db.LoadDataSet(dbCommandWrapper, ds, New String() {"Reports"})
            Return ds
        Finally
        End Try
    End Function
#End Region
End Class
