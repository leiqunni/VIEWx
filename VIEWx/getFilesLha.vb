Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions

Module getFilesLha

    'DLL �̔ł̎擾
    <DllImport("unlha32")> _
    Private Function UnlhaGetVersion() As Integer
    End Function
    'DLL �̎��s�󋵂̎擾
    <DllImport("unlha32")> _
    Public Function UnlhaGetRunning() As Boolean
    End Function
    '���ɂ̃`�F�b�N
    <DllImport("unlha32")> _
    Private Function UnlhaCheckArchive(ByVal szFileName As String, ByVal iMode As Integer) As Boolean
    End Function
    '���ɑ�����
    <DllImport("unlha32")> _
    Public Function Unlha(ByVal hwnd As Integer, ByVal szCmdLine As String, ByVal szOutput As System.Text.StringBuilder, ByVal dwSize As Integer) As Integer
    End Function

    '//
    Public Sub getFilesLha(ByVal archiveFile As String)
        Dim value As String
        Dim Output As New System.Text.StringBuilder(65536)

        targetFile = archiveFile

        '// DLL�̃`�F�b�N
        Try
            Dim ver As Integer = UnlhaGetVersion()
        Catch
            MsgBox("unlha32.dll���C���X�g�[������Ă��܂���")
            Return
        End Try

        '// ���쒆���`�F�b�N
        If UnlhaGetRunning() Then Return

        '�W�J�ł��邩�`�F�b�N
        If Not UnlhaCheckArchive(archiveFile, 0) Then
            MsgBox("�Ή����ɂł͂���܂���")
            Return
        End If

        '// ���ɓ��̃t�@�C�����𓾂�
        'Debug.Print("v """ & archiveFile & """")
        Dim ret As Integer = Unlha(Nothing, "v """ & archiveFile & """", Output, 65536)

        '����
        If ret <> 0 Then MsgBox("���ɂ̓W�J�Ɏ��s���܂���" & ret)

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
