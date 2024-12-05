Imports System.IO
Imports System.Security.AccessControl
Imports System.Security.Principal

Public Class Form1
    ' Dim cr As String = "C:\Users\rytho\source"      '{Reflection.Assembly.GetExecutingAssembly().Location}

    Private ReadOnly userHome = "C:\Users\"
    Private ReadOnly hostEnvironment = Environment.UserName
    Private ReadOnly unity As String = userHome + hostEnvironment
    Private ReadOnly crawl As String = "\Music\"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetAccess()


        'Dim FilePath As String = "C:\Users\rytho\source\repos\CryptLok"
        'Dim UserAccount As String = "Everyone"
        'Dim FileAcl As New FileSecurity
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Change to:>> AccessControlType.Deny << to remove priviledges
        'FileAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.Modify, AccessControlType.Allow))
        'Dim FileInfo As New FileInfo(FilePath)
        'FileInfo.SetAccessControl(FileAcl)

    End Sub

    Public Sub SetAccess()
        If unity = True Then
            For Each daw In unity
                GetFiles(crawl, daw, 1, 0)
            Next

        ElseIf unity Then

        End If


    End Sub
    ' Recursive function which keeps moving down the directory tree until a given depth.
    Public Sub GetFiles(strFileFilter As String, strDirectory As String, intDepthLimit As Integer, intCurrentDepth As Integer)

        Dim folderInfo As New DirectoryInfo(strDirectory)
        ' Is the current depth on this recursion less than our limit?
        ' If so, find any directories and get into them by calling GetFiles recursively (incrementing depth count)
        If intCurrentDepth < intDepthLimit Then
            Dim directories() As DirectoryInfo
            directories = folderInfo.GetDirectories(unity) ' calls to user & environment
            For Each fDirectory In directories
                ' Recursively call ourselves incrementing the depth using the given folder path.
                GetFiles(strFileFilter, fDirectory.FullName, intDepthLimit, intCurrentDepth + 1)
            Next
        End If
        ' After we can't go further down, add any files which match our filter to listbox (in this case lstFiles)
        Dim files() As FileInfo
        files = folderInfo.GetFiles(strFileFilter)
        For Each fFile In files
            'lstFiles.Items.Add(fFile.FullName)
        Next
    End Sub




End Class
