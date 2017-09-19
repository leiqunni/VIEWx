Imports System
Imports System.IO

Public Class frmConfig

    Dim KeyTable As New Hashtable

    Private Sub frmConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetKeyTable()
        SetConfig()
    End Sub

    Private Sub SetConfig()
        Dim n As Integer
        Dim key(16) As Integer
        Dim value(16) As Integer
        Dim m As New System.Collections.DictionaryEntry

        nudSlideShowInterval.Value = slideShowInterval
        chkDoUpdateCheck.Checked = doUpdateCheck

        For Each m In KeyConfig
            key(n) = m.Key
            value(n) = m.Value
            n += 1
        Next

        TextBox1.Text = KeyTable(key(0))
        TextBox11.Text = key(0)
        ComboBox1.SelectedIndex = value(0)

        TextBox2.Text = KeyTable(key(1))
        TextBox12.Text = key(1)
        ComboBox2.SelectedIndex = value(1)

        TextBox3.Text = KeyTable(key(2))
        TextBox13.Text = key(2)
        ComboBox3.SelectedIndex = value(2)

        TextBox4.Text = KeyTable(key(3))
        TextBox14.Text = key(3)
        ComboBox4.SelectedIndex = value(3)

        TextBox5.Text = KeyTable(key(4))
        TextBox15.Text = key(4)
        ComboBox5.SelectedIndex = value(4)

        TextBox6.Text = KeyTable(key(5))
        TextBox16.Text = key(5)
        ComboBox6.SelectedIndex = value(5)

        TextBox7.Text = KeyTable(key(6))
        TextBox17.Text = key(6)
        ComboBox7.SelectedIndex = value(6)

        TextBox8.Text = KeyTable(key(7))
        TextBox18.Text = key(7)
        ComboBox8.SelectedIndex = value(7)

        TextBox9.Text = KeyTable(key(8))
        TextBox19.Text = key(8)
        ComboBox9.SelectedIndex = value(8)

        TextBox10.Text = KeyTable(key(9))
        TextBox20.Text = key(9)
        ComboBox10.SelectedIndex = value(9)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim n As Integer
        'Dim strmsg As String

        slideShowInterval = nudSlideShowInterval.Value
        doUpdateCheck = chkDoUpdateCheck.Checked

        KeyConfig.Clear()
        Try
            If TextBox11.Text <> 0 Then KeyConfig.Add(CType(TextBox11.Text, Integer), ComboBox1.SelectedIndex)
            If TextBox12.Text <> 0 Then KeyConfig.Add(CType(TextBox12.Text, Integer), ComboBox2.SelectedIndex)
            If TextBox13.Text <> 0 Then KeyConfig.Add(CType(TextBox13.Text, Integer), ComboBox3.SelectedIndex)
            If TextBox14.Text <> 0 Then KeyConfig.Add(CType(TextBox14.Text, Integer), ComboBox4.SelectedIndex)
            If TextBox15.Text <> 0 Then KeyConfig.Add(CType(TextBox15.Text, Integer), ComboBox5.SelectedIndex)
            If TextBox16.Text <> 0 Then KeyConfig.Add(CType(TextBox16.Text, Integer), ComboBox6.SelectedIndex)
            If TextBox17.Text <> 0 Then KeyConfig.Add(CType(TextBox17.Text, Integer), ComboBox7.SelectedIndex)
            If TextBox18.Text <> 0 Then KeyConfig.Add(CType(TextBox18.Text, Integer), ComboBox8.SelectedIndex)
            If TextBox19.Text <> 0 Then KeyConfig.Add(CType(TextBox19.Text, Integer), ComboBox9.SelectedIndex)
            If TextBox20.Text <> 0 Then KeyConfig.Add(CType(TextBox20.Text, Integer), ComboBox10.SelectedIndex)
            Me.Close()
        Catch ex As Exception
            MsgBox("キー設定に間違いがあります（キーが重複しているとか）")
        End Try

        For n = 0 To ListBox1.SelectedIndices.Count - 1
            Select Case ListBox1.SelectedIndices(n)
                Case 0
                    fileAssociate.fileAssociate(".bmp", "viewx.bmpfile")
                Case 1
                    fileAssociate.fileAssociate(".gif", "viewx.giffile")
                Case 2
                    fileAssociate.fileAssociate(".ico", "viewx.iconfile")
                Case 3
                    fileAssociate.fileAssociate(".jpg", "viewx.jpegfile")
                    fileAssociate.fileAssociate(".jpeg", "viewx.jpegfile")
                    fileAssociate.fileAssociate(".jpe", "viewx.jpegfile")
                Case 4
                    fileAssociate.fileAssociate(".png", "viewx.pngfile")
                Case 5
                    fileAssociate.fileAssociate(".tif", "viewx.tifffile")
                    fileAssociate.fileAssociate(".tiff", "viewx.tifffile")
                Case 6
                    fileAssociate.fileAssociate(".wdp", "viewx.wdpfile")
                Case 7
                    fileAssociate.fileAssociate(".hdp", "viewx.hdpfile")
            End Select
        Next

        If CheckBox1.Checked Then
            Dim objShell As Object = CreateObject("WScript.Shell")
            Dim strPath As String   'ショートカットパス
            Dim objLink As Object   'リンクオブジェクト

            'デスクトップに作成するので、デスクトップのパスを取得しています
            strPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.SendTo)

            'ショートカットの場所です
            objLink = objShell.CreateShortcut(strPath & "\\" & appName & ".lnk")

            'ショートカットを作成しています
            'この場合は、メモ帳を作成しています
            With objLink
                .targetpath = Application.ExecutablePath
                '.description = "ウィザードで作成したメモ帳へのショートカット"
                '.iconlocation = "notepad.exe"
                '.workingdirectory = strPath
                .save()
            End With
        End If

    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        TextBox1.Text = e.KeyCode.ToString
        TextBox11.Text = e.KeyCode
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        TextBox12.Text = e.KeyCode
        TextBox2.Text = e.KeyCode.ToString
    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown
        TextBox13.Text = e.KeyCode
        TextBox3.Text = e.KeyCode.ToString
    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown
        TextBox14.Text = e.KeyCode
        TextBox4.Text = e.KeyCode.ToString
    End Sub

    Private Sub TextBox5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox5.KeyDown
        TextBox15.Text = e.KeyCode
        TextBox5.Text = e.KeyCode.ToString
    End Sub

    Private Sub TextBox6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox6.KeyDown
        TextBox16.Text = e.KeyCode
        TextBox6.Text = e.KeyCode.ToString
    End Sub

    Private Sub TextBox7_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox7.KeyDown
        TextBox17.Text = e.KeyCode
        TextBox7.Text = e.KeyCode.ToString
    End Sub

    Private Sub TextBox8_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox8.KeyDown
        TextBox18.Text = e.KeyCode
        TextBox8.Text = e.KeyCode.ToString
    End Sub

    Private Sub TextBox9_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox9.KeyDown
        TextBox19.Text = e.KeyCode
        TextBox9.Text = e.KeyCode.ToString
    End Sub

    Private Sub TextBox10_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox10.KeyDown
        TextBox20.Text = e.KeyCode
        TextBox10.Text = e.KeyCode.ToString
    End Sub

    Private Sub SetKeyTable()
        Dim Value As Integer
        Dim Name As String

        For Each Value In [Enum].GetValues(GetType(Keys))
            Name = [Enum].GetName(GetType(Keys), Value)

            Try
                keyTable.Add(Value, Name)
            Catch ex As Exception
            End Try
        Next Value
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        fileAssociate.delFileAssociate(".bmp", "viewx.bmpfile")
        fileAssociate.delFileAssociate(".gif", "viewx.giffile")
        fileAssociate.delFileAssociate(".ico", "viewx.iconfile")
        fileAssociate.delFileAssociate(".jpg", "viewx.jpegfile")
        fileAssociate.delFileAssociate(".jpeg", "viewx.jpegfile")
        fileAssociate.delFileAssociate(".jpe", "viewx.jpegfile")
        fileAssociate.delFileAssociate(".png", "viewx.pngfile")
        fileAssociate.delFileAssociate(".tif", "viewx.tifffile")
        fileAssociate.delFileAssociate(".tiff", "viewx.tifffile")
        fileAssociate.delFileAssociate(".wdp", "viewx.wdpfile")
        fileAssociate.delFileAssociate(".hdp", "viewx.hdpfile")
    End Sub

End Class