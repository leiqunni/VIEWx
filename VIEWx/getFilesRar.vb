Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions

Module getFilesRar

    'DLL の版の取得
    <DllImport("unrar32")> _
    Private Function UnrarGetVersion() As Integer
    End Function
    'DLL の実行状況の取得
    <DllImport("unrar32")> _
    Public Function UnrarGetRunning() As Boolean
    End Function
    '書庫のチェック
    <DllImport("unrar32")> _
    Private Function UnrarCheckArchive(ByVal szFileName As String, ByVal iMode As Integer) As Boolean
    End Function
    '書庫操作一般
    <DllImport("unrar32")> _
    Public Function Unrar(ByVal hwnd As Integer, ByVal szCmdLine As String, ByVal szOutput As System.Text.StringBuilder, ByVal dwSize As Integer) As Integer
    End Function

    Public Sub getFilesRar(ByVal archiveFile As String)
        Dim value As String
        Dim Output As New System.Text.StringBuilder(65536)

        targetFile = archiveFile

        '// DLLのチェック
        Try
            Dim ver As Integer = UnrarGetVersion()
        Catch
            MsgBox("unrar32.dllがインストールされていません")
            Return
        End Try

        '// 動作中かチェック
        If UnrarGetRunning() Then Return

        '展開できるかチェック
        If Not UnrarCheckArchive(archiveFile, 0) Then
            MsgBox("対応書庫ではありません")
            Return
        End If

        '// 書庫内のファイル名を得る
        Dim ret As Integer = Unrar(Nothing, "-v """ & archiveFile & """", Output, 65536)
        'Debug.Print("v """ & archiveFile & """")
        'Debug.Print(Output.ToString)

        '結果
        If ret <> 0 Then
            MsgBox("書庫の展開に失敗しました - " & ret)
            Return
        End If

        fileEntries.Clear()

        For Each value In Output.ToString.Split(vbLf)
            If Regex.IsMatch(value, searchPattern, RegexOptions.IgnoreCase) Then
                'Debug.Print(value)
                'fileEntries.Add(value.Replace("/", "\").Trim)
                fileEntries.Add(value.Trim)
                'Debug.Print(value.Replace("/", "\").Trim)
            End If
        Next value

        FormMain.HScrollBar.Maximum = fileEntries.Count + FormMain.HScrollBar.LargeChange - 2
        FormMain.HScrollBar.Value = 0

        targetType = 4
        FormMain.readPictureFile1(fileEntries(0))
    End Sub
End Module
