Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions

Module getFilesRar

    'DLL �̔ł̎擾
    <DllImport("unrar32")> _
    Private Function UnrarGetVersion() As Integer
    End Function
    'DLL �̎��s�󋵂̎擾
    <DllImport("unrar32")> _
    Public Function UnrarGetRunning() As Boolean
    End Function
    '���ɂ̃`�F�b�N
    <DllImport("unrar32")> _
    Private Function UnrarCheckArchive(ByVal szFileName As String, ByVal iMode As Integer) As Boolean
    End Function
    '���ɑ�����
    <DllImport("unrar32")> _
    Public Function Unrar(ByVal hwnd As Integer, ByVal szCmdLine As String, ByVal szOutput As System.Text.StringBuilder, ByVal dwSize As Integer) As Integer
    End Function

    Public Sub getFilesRar(ByVal archiveFile As String)
        Dim value As String
        Dim Output As New System.Text.StringBuilder(65536)

        targetFile = archiveFile

        '// DLL�̃`�F�b�N
        Try
            Dim ver As Integer = UnrarGetVersion()
        Catch
            MsgBox("unrar32.dll���C���X�g�[������Ă��܂���")
            Return
        End Try

        '// ���쒆���`�F�b�N
        If UnrarGetRunning() Then Return

        '�W�J�ł��邩�`�F�b�N
        If Not UnrarCheckArchive(archiveFile, 0) Then
            MsgBox("�Ή����ɂł͂���܂���")
            Return
        End If

        '// ���ɓ��̃t�@�C�����𓾂�
        Dim ret As Integer = Unrar(Nothing, "-v """ & archiveFile & """", Output, 65536)
        'Debug.Print("v """ & archiveFile & """")
        'Debug.Print(Output.ToString)

        '����
        If ret <> 0 Then
            MsgBox("���ɂ̓W�J�Ɏ��s���܂��� - " & ret)
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
