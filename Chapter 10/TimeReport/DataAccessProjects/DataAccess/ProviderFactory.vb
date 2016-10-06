Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Reflection

Namespace DataUtils.ProviderFactory
    Public Enum ProviderType
        OleDb = 0
        Odbc
        SqlClient
    End Enum 'ProviderType
    Public Class ProviderFactory
#Region "private variables"
        Private Shared _connectionTypes() As Type = {GetType(OleDbConnection), GetType(OdbcConnection), GetType(SqlConnection)}
        Private Shared _commandTypes() As Type = {GetType(OleDbCommand), GetType(OdbcCommand), GetType(SqlCommand)}
        Private Shared _dataAdapterTypes() As Type = {GetType(OleDbDataAdapter), GetType(OdbcDataAdapter), GetType(SqlDataAdapter)}
        Private Shared _dataParameterTypes() As Type = {GetType(OleDbParameter), GetType(OdbcParameter), GetType(SqlParameter)}
        Private _provider As ProviderType
#End Region
#Region "Constructors"
        Private Sub New() ' force user to specify provider
        End Sub 'New

        Public Sub New(ByVal provider As ProviderType)
            _provider = provider
        End Sub 'New
#End Region
#Region "Provider property"

        Public Property Provider() As ProviderType
            Get
                Return _provider
            End Get
            Set(ByVal Value As ProviderType)
                _provider = Value
            End Set
        End Property

#End Region
#Region "IDbConnection methods"
        Public Overloads Function CreateConnection() As IDbConnection
            Dim conn As IDbConnection = Nothing

            Try
                conn = CType(Activator.CreateInstance(_connectionTypes(CInt(_provider))), IDbConnection)
            Catch e As TargetInvocationException
                Throw New SystemException(e.InnerException.Message, e.InnerException)
            End Try

            Return conn
        End Function 'CreateConnection

        Public Overloads Function CreateConnection(ByVal connectionString As String) As IDbConnection
            Dim conn As IDbConnection = Nothing
            Dim args() As Object = {connectionString} 'CType(connectionString, Object)

            Try
                conn = CType(Activator.CreateInstance(_connectionTypes(CInt(_provider)), args), IDbConnection)
                'conn = CType(Activator.CreateInstance(_connectionTypes(CInt(_provider))), IDbConnection)
                'conn.ConnectionString = connectionString
            Catch e As TargetInvocationException
                Throw New SystemException(e.InnerException.Message, e.InnerException)
            End Try

            Return conn
        End Function 'CreateConnection

#End Region
#Region "IDbCommand methods"
        Public Overloads Function CreateCommand() As IDbCommand
            Dim cmd As IDbCommand = Nothing

            Try
                cmd = CType(Activator.CreateInstance(_commandTypes(CInt(_provider))), IDbCommand)
            Catch e As TargetInvocationException
                Throw New SystemException(e.InnerException.Message, e.InnerException)
            End Try

            Return cmd
        End Function 'CreateCommand

        Public Overloads Function CreateCommand(ByVal cmdText As String) As IDbCommand
            Dim cmd As IDbCommand = Nothing
            Dim args() As Object = CType(cmdText, Object)

            Try
                cmd = CType(Activator.CreateInstance(_commandTypes(CInt(_provider)), args), IDbCommand)
            Catch e As TargetInvocationException
                Throw New SystemException(e.InnerException.Message, e.InnerException)
            End Try

            Return cmd
        End Function 'CreateCommand

        Public Overloads Function CreateCommand(ByVal cmdText As String, ByVal connection As IDbConnection) As IDbCommand
            Dim cmd As IDbCommand = Nothing
            Dim args() As Object = {cmdText, connection}

            Try
                cmd = CType(Activator.CreateInstance(_commandTypes(CInt(_provider)), args), IDbCommand)
            Catch e As TargetInvocationException
                Throw New SystemException(e.InnerException.Message, e.InnerException)
            End Try

            Return cmd
        End Function 'CreateCommand

        Public Overloads Function CreateCommand(ByVal cmdText As String, ByVal connection As IDbConnection, ByVal transaction As IDbTransaction) As IDbCommand
            Dim cmd As IDbCommand = Nothing
            Dim args() As Object = {cmdText, connection, transaction}

            Try
                cmd = CType(Activator.CreateInstance(_commandTypes(CInt(_provider)), args), IDbCommand)
            Catch e As TargetInvocationException
                Throw New SystemException(e.InnerException.Message, e.InnerException)
            End Try

            Return cmd
        End Function 'CreateCommand

#End Region
#Region "IDbDataAdapter methods"
        Public Overloads Function CreateDataAdapter() As IDbDataAdapter
            Dim da As IDbDataAdapter = Nothing

            Try
                da = CType(Activator.CreateInstance(_dataAdapterTypes(CInt(_provider))), IDbDataAdapter)
            Catch e As TargetInvocationException
                Throw New SystemException(e.InnerException.Message, e.InnerException)
            End Try

            Return da
        End Function 'CreateDataAdapter

        Public Overloads Function CreateDataAdapter(ByVal selectCommand As IDbCommand) As IDbDataAdapter
            Dim da As IDbDataAdapter = Nothing
            Dim args() As Object = {selectCommand}
            Try
                da = CType(Activator.CreateInstance(_dataAdapterTypes(CInt(_provider)), args), IDbDataAdapter)
                'da.SelectCommand = selectCommand

            Catch e As TargetInvocationException
                Throw New SystemException(e.InnerException.Message, e.InnerException)
            End Try

            Return da
        End Function 'CreateDataAdapter

        Public Overloads Function CreateDataAdapter(ByVal selectCommandText As String, ByVal selectConnection As IDbConnection) As IDbDataAdapter
            Dim da As IDbDataAdapter = Nothing
            Dim args() As Object = {selectCommandText, selectConnection}

            Try
                da = CType(Activator.CreateInstance(_dataAdapterTypes(CInt(_provider)), args), IDbDataAdapter)
            Catch e As TargetInvocationException
                Throw New SystemException(e.InnerException.Message, e.InnerException)
            End Try

            Return da
        End Function 'CreateDataAdapter

        Public Overloads Function CreateDataAdapter(ByVal selectCommandText As String, ByVal selectConnectionString As String) As IDbDataAdapter
            Dim da As IDbDataAdapter = Nothing
            Dim args() As Object = {selectCommandText, selectConnectionString}

            Try
                da = CType(Activator.CreateInstance(_dataAdapterTypes(CInt(_provider)), args), IDbDataAdapter)
            Catch e As TargetInvocationException
                Throw New SystemException(e.InnerException.Message, e.InnerException)
            End Try

            Return da
        End Function 'CreateDataAdapter

#End Region
#Region "IDbDataParameter methods"
        Public Overloads Function CreateDataParameter() As IDbDataParameter
            Dim param As IDbDataParameter = Nothing

            Try
                param = CType(Activator.CreateInstance(_dataParameterTypes(CInt(_provider))), IDbDataParameter)
            Catch e As TargetInvocationException
                Throw New SystemException(e.InnerException.Message, e.InnerException)
            End Try

            Return param
        End Function 'CreateDataParameter

        Public Overloads Function CreateDataParameter(ByVal parameterName As String, ByVal value As Object) As IDbDataParameter
            Dim param As IDbDataParameter = Nothing
            Dim args() As Object = {parameterName, value}

            Try
                param = CType(Activator.CreateInstance(_dataParameterTypes(CInt(_provider)), args), IDbDataParameter)
            Catch e As TargetInvocationException
                Throw New SystemException(e.InnerException.Message, e.InnerException)
            End Try

            Return param
        End Function 'CreateDataParameter

        Public Overloads Function CreateDataParameter(ByVal parameterName As String, ByVal dataType As DbType) As IDbDataParameter
            Dim param As IDbDataParameter = CreateDataParameter()

            If Not (param Is Nothing) Then
                param.ParameterName = parameterName
                param.DbType = dataType
            End If

            Return param
        End Function 'CreateDataParameter

        Public Overloads Function CreateDataParameter(ByVal parameterName As String, ByVal dataType As DbType, ByVal size As Integer) As IDbDataParameter
            Dim param As IDbDataParameter = CreateDataParameter()

            If Not (param Is Nothing) Then
                param.ParameterName = parameterName
                param.DbType = dataType
                param.Size = size
            End If

            Return param
        End Function 'CreateDataParameter

        Public Overloads Function CreateDataParameter(ByVal parameterName As String, ByVal dataType As DbType, ByVal size As Integer, ByVal sourceColumn As String) As IDbDataParameter
            Dim param As IDbDataParameter = CreateDataParameter()

            If Not (param Is Nothing) Then
                param.ParameterName = parameterName
                param.DbType = dataType
                param.Size = size
                param.SourceColumn = sourceColumn
            End If

            Return param
        End Function 'CreateDataParameter
#End Region
    End Class 'ProviderFactory 

End Namespace 'DataUtils.ProviderFactory