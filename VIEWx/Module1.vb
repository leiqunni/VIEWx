Module Module1
    Public Declare Unicode Function StrCmpLogicalW Lib "shlwapi" (ByVal s1 As String, ByVal s2 As String) As Integer

    Public appName As String = "viewx"
    Public appRelease As String = "42"
    Public appReleaseDate As String = "2008/7/3 22:34"
    Public appAuthor As String = "793 Åü7BJkZFw08A" '// #oreo

    Public targetType As Integer '// 0:file 1:Dir 2:.lzh 3: .zip 4:.rar
    Public targetFile, tmpDirectory As String
    Public fileEntries As New ArrayList

    Public searchPattern As String = "\.jpg$|\.gif$|\.png$|\.tif$|\.bmp$|\.jpe$|\.jpeg$|\.ico$|\.wdp$|\.hdp$"
    Public keyConfig As New Hashtable
    Public lastUpdateCheckDateTime As DateTime
    Public doUpdateCheck As Boolean
    Public slideShowInterval As Integer
End Module
