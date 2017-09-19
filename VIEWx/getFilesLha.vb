Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions

Module getFilesLha

    'DLL の版の取得
    <DllImport("unlha32")> _
    Private Function UnlhaGetVersion() As Integer
    End Function
    'DLL の実行状況の取得
    <DllImport("unlha32")> _
    Public Function UnlhaGetRunning() As Boolean
    End Function
    '書庫のチェック
    <DllImport("unlha32")> _
    Private Function UnlhaCheckArchive(ByVal szFileName As String, ByVal iMode As Integer) As Boolean
    End Function
    '書庫操作一般
    <DllImport("unlha32")> _
    Public Function Unlha(ByVal hwnd As Integer, ByVal szCmdLine As String, ByVal szOutput As System.Text.StringBuilder, ByVal dwSize As Integer) As Integer
    End Function

    '//
    Public Sub getFilesLha(ByVal archiveFile As String)
        Dim value As String
        Dim Output As New System.Text.StringBuilder(65536)

        targetFile = archiveFile

        '// DLLのチェック
        Try
            Dim ver As Integer = UnlhaGetVersion()
        Catch
            MsgBox("unlha32.dllがインストールされていません")
            Return
        End Try

        '// 動作中かチェック
        If UnlhaGetRunning() Then Return

        '展開できるかチェック
        If Not UnlhaCheckArchive(archiveFile, 0) Then
            MsgBox("対応書庫ではありません")
            Return
        End If

        '// 書庫内のファイル名を得る
        'Debug.Print("v """ & archiveFile & """")
        Dim ret As Integer = Unlha(Nothing, "v """ & archiveFile & """", Output, 65536)

        '結果
        If ret <> 0 Then MsgBox("書庫の展開に失敗しました" & ret)

        fileEntries.Clear()
        'fileEntries = Output.ToString.Split(vbCrLf)

        For Each value In Output.ToString.Split(vbCrLf)
            If Regex.IsMatch(value, searchPattern, RegexOptions.IgnoreCase) Then
                fileEntries.Add(value.Replace("/", "\").Trim)
                'Debug.Print(value.Replace("/", "\").Trim)
            End If
        Next value

        FormMain.HScrollBar.Maximum = fileEntries.Count + FormMain.HScrollBar.LargeChange - 2
        FormMain.HScrollBar.Value = 0

        targetType = 2
        FormMain.readPictureFile1(fileEntries(0))
    End Sub
End Module
