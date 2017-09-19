Imports Microsoft.Win32

Module fileAssociate
    '// �t�@�C���̊֘A�t��
    Public Sub fileAssociate(ByVal extension As String, ByVal fileType As String)
        '���s����R�}���h���C��
        Dim commandLine As String = """" & Application.ExecutablePath & """ ""%1"""

        '�t�@�C���^�C�v��
        'Dim fileType As String = Application.ProductName

        '�����i�K�v�Ȃ��j
        Dim description As String = appName

        '����
        Dim verb As String = "open"

        '�����̐����i�G�N�X�v���[���̃R���e�L�X�g���j���[�ɕ\�������j
        '�i�K�v�Ȃ��j
        'Dim verb_description As String = "MyApplication�ŊJ��(&O)"

        '�A�C�R���̃p�X�ƃC���f�b�N�X
        Dim iclPath As String = Application.StartupPath & "\viewx_icon.dll"

        '�t�@�C���^�C�v��o�^
        Dim regKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Classes\" & extension)
        'regkey.DeleteSubKeyTree(extension)
        regKey.SetValue("", fileType)
        regKey.Close()

        '�t�@�C���^�C�v�Ƃ��̐�����o�^
        Dim shellKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Classes\" & filetype)
        'shellkey.DeleteSubKeyTree(filetype)
        'shellKey.SetValue("", extension.ToUpper & " " & description)
        If extension = ".bmp" Then shellKey.SetValue("", "BMP " & description)
        If extension = ".gif" Then shellKey.SetValue("", "GIF " & description)
        If extension = ".jpg" Then shellKey.SetValue("", "JPEG " & description)
        If extension = ".jpe" Then shellKey.SetValue("", "JPEG " & description)
        If extension = ".jpeg" Then shellKey.SetValue("", "JPEG " & description)
        If extension = ".png" Then shellKey.SetValue("", "PNG " & description)
        If extension = ".wdp" Then shellKey.SetValue("", "WDP " & description)
        If extension = ".hdp" Then shellKey.SetValue("", "HDP " & description)

        '�����Ƃ��̐�����o�^
        shellKey = shellKey.CreateSubKey("shell\" & verb)
        'shellkey.SetValue("", verb_description)

        '�R�}���h���C����o�^
        shellKey = shellKey.CreateSubKey("command")
        shellKey.SetValue("", commandLine)
        shellKey.Close()

        '�A�C�R���̓o�^
        Dim iconKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Classes\" & fileType & "\DefaultIcon")

        If extension = ".bmp" Then iconkey.SetValue("", iclPath & ",2")
        If extension = ".gif" Then iconkey.SetValue("", iclPath & ",3")
        If extension = ".jpg" Then iconkey.SetValue("", iclPath & ",4")
        If extension = ".jpe" Then iconkey.SetValue("", iclPath & ",4")
        If extension = ".jpeg" Then iconkey.SetValue("", iclPath & ",4")
        If extension = ".png" Then iconkey.SetValue("", iclPath & ",5")
        If extension = ".wdp" Then iconkey.SetValue("", iclPath & ",6")
        If extension = ".hdp" Then iconkey.SetValue("", iclPath & ",6")

        iconkey.Close()
    End Sub

    Public Sub delFileAssociate(ByVal extension As String, ByVal fileType As String)
        Try
            Registry.ClassesRoot.DeleteSubKey(extension, False)
            Registry.ClassesRoot.DeleteSubKeyTree(fileType)
            Registry.CurrentUser.DeleteSubKey("Software\Classes" & extension, False)
            Registry.CurrentUser.DeleteSubKeyTree("Software\Classes" & fileType)
        Catch
        End Try
    End Sub
End Module
