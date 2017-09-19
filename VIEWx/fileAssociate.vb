Imports Microsoft.Win32

Module fileAssociate
    '// ファイルの関連付け
    Public Sub fileAssociate(ByVal extension As String, ByVal fileType As String)
        '実行するコマンドライン
        Dim commandLine As String = """" & Application.ExecutablePath & """ ""%1"""

        'ファイルタイプ名
        'Dim fileType As String = Application.ProductName

        '説明（必要なし）
        Dim description As String = appName

        '動詞
        Dim verb As String = "open"

        '動詞の説明（エクスプローラのコンテキストメニューに表示される）
        '（必要なし）
        'Dim verb_description As String = "MyApplicationで開く(&O)"

        'アイコンのパスとインデックス
        Dim iclPath As String = Application.StartupPath & "\viewx_icon.dll"

        'ファイルタイプを登録
        Dim regKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Classes\" & extension)
        'regkey.DeleteSubKeyTree(extension)
        regKey.SetValue("", fileType)
        regKey.Close()

        'ファイルタイプとその説明を登録
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

        '動詞とその説明を登録
        shellKey = shellKey.CreateSubKey("shell\" & verb)
        'shellkey.SetValue("", verb_description)

        'コマンドラインを登録
        shellKey = shellKey.CreateSubKey("command")
        shellKey.SetValue("", commandLine)
        shellKey.Close()

        'アイコンの登録
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
