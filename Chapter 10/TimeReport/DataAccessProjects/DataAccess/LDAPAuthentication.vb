Imports System.EnterpriseServices
Imports SystemFrameworks
Imports System.DirectoryServices
<EnterpriseServices.ConstructionEnabled(True), _
ObjectPooling(Enabled:=True, MinPoolSize:=1, MaxPoolSize:=10, CreationTimeOut:=25000), JustInTimeActivation(True)> _
Public Class LdapAuthentication
    Inherits EnterpriseServices.ServicedComponent
    Private activeDirectoryPath As String
    Private path As String
    Private filterAttribute As String

    Public Function IsAuthenticated(ByVal domain As String, _
                                    ByVal userName As String, _
                                    ByVal password As String) As Boolean
        Dim domainAndUserName As String = domain & "\" & UserName
        Dim objEntry As DirectoryEntry
        Dim objSearcher As DirectorySearcher
        Dim obj As Object
        Dim objSearchResult As SearchResult
        Try
            If activeDirectoryPath.Length = 0 Then
                Throw New Exception("Not a valid Active Directory Path. " & _
                "Add a path to the constructor of this class in Component Services.")
            End If
            objEntry = New DirectoryEntry(activeDirectoryPath, UserName, password)
            'Bind to the AdsObject to force authentication of the user.. 
            obj = objEntry.NativeObject
            'no exception so far- go ahead and create a directory searcher object to search for the user.. 
            objSearcher = New DirectorySearcher(objEntry)
            With objSearcher
                .Filter = "(SAMAccountName=" & UserName & ")"
                .PropertiesToLoad.Add("cn")
                objSearchResult = .FindOne
                If objSearchResult Is Nothing Then
                    path = String.Empty
                    filterAttribute = String.Empty
                    Return False

                Else
                    path = objSearchResult.Path
                    filterAttribute = objSearchResult.Properties("cn")(0)
                    Return True
                End If
            End With
        Catch exp As Exception
            Throw exp
        Finally

        End Try

    End Function

    Public Function GetUserGroups(ByVal domain As String, _
                                  ByVal username As String, _
                                  ByVal password As String) As String
        'returns the groups the user belongs to.
        'all functions are working separately -eg. a call to a function should not depend on that other calls 
        'have already been maid to other functions to initalize private variables.
        Dim objSearcher As DirectorySearcher
        Dim objSearchResult As SearchResult
        Dim intCounter, propertyCount, equalIndex, commaIndex As Integer
        Dim group As String
        Dim groupNames As System.Text.StringBuilder
        Dim enumerator As IEnumerator
        Const DELIMITER As String = "|"
        Try
            If IsAuthenticated(domain, username, password) Then
                'valid user credentials. retrieve the groups for the user.
                objSearcher = New DirectorySearcher(path)
                With objSearcher
                    .Filter = "(cn=" & filterAttribute & ")"
                    .PropertiesToLoad.Add("memberOf")
                    objSearchResult = .FindOne()
                End With
                enumerator = objSearchResult.Properties("memberOf").GetEnumerator
                While enumerator.MoveNext
                    group = enumerator.Current
                    groupNames.Append(group.Substring((equalIndex + 1), (commaIndex - equalIndex) - 1))
                    groupNames.Append(DELIMITER)
                End While
                Return groupNames.ToString
            Else
                Throw New Exception("User " & username & " is not authenticated. Invalid domain, username or password.")
            End If
        Catch exp As Exception
            Throw New Exception("Error in retireving groups for user:" & username & "error message:" & exp.Message, exp.InnerException)
        End Try
    End Function
    Protected Overrides Sub Construct(ByVal s As String)
        activeDirectoryPath = s 'the activedirectory path to use..
    End Sub
End Class
