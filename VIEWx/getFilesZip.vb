Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions

Module getFilesZip

    'DLL �̔ł̎擾
    <DllImport("unzip32")> _
    Private Function UnZipGetVersion() As Integer
    End Function
    'DLL �̎��s�󋵂̎擾
    <DllImport("unzip32")> _
    Public Function UnZipGetRunning() As Boolean
    End Function
    '���ɂ̃`�F�b�N
    <DllImport("unzip32")> _
    Private Function UnZipCheckArchive(ByVal szFileName As String, ByVal iMode As Integer) As Boolean
    End Function
    '���ɑ�����
    <DllImport("unzip32")> _
    Public Function UnZip(ByVal hwnd As Integer, ByVal szCmdLine As String, ByVal szOutput As System.Text.StringBuilder, ByVal dwSize As Integer) As Integer
    End Function

    '//
    Public Sub getFilesZip(ByVal archiveFile As String)
        Dim value As String
        Dim Output As New System.Text.StringBuilder(65536)

        targetFile = archiveFile

        '// DLL�̃`�F�b�N
        Try
            Dim ver As Integer = UnZipGetVersion()
        Catch
            MsgBox("unzip32.dll���C���X�g�[������Ă��܂���")
            Return
        End Try

        '// ���쒆���`�F�b�N
        If UnZipGetRunning() Then Return

        '�W�J�ł��邩�`�F�b�N
        If Not UnZipCheckArchive(archiveFile, 0) Then
            MsgBox("�Ή����ɂł͂���܂���")
            Return
        End If

        '// ���ɓ��̃t�@�C�����𓾂�
        Dim ret As Integer = UnZip(Nothing, "-v """ & archiveFile & """", Output, 65536)
        'Debug.Print("v """ & archiveFile & """")
        'Debug.Print(Output.ToString)

        '����
        If ret <> 0 Then
            MsgBox("���ɂ̓W�J�Ɏ��s���܂��� - " & ret)
            Return
        End If

        fileEntries.Clear()
        'fileEntries = Output.ToString.Split(vbCrLf)
        'fileEntries = Output.ToString.Split(vbLf)
        'Debug.Print("fileEntries: " & fileEntries.Length)
        For Each value In Output.ToString.Split(vbLf)
            If Regex.IsMatch(value, searchPattern, RegexOptions.IgnoreCase) Then
                value = value.Remove(0, 58)
                'Debug.Print(value)
                fileEntries.Add(value.Replace("/", "\").Trim)
                'Debug.Print(value.Replace("/", "\").Trim)
            End If
        Next value

        FormMain.HScrollBar.Maximum = fileEntries.Count + FormMain.HScrollBar.LargeChange - 2
        FormMain.HScrollBar.Value = 0

        targetType = 3
        FormMain.readPictureFile1(fileEntries(0))
    End Sub
End Module
