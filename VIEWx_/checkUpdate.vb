Module checkUpdate
    '// �A�b�v�f�[�g�̃`�F�b�N
    Public Sub checkUpdate(ByVal isManual As Boolean)
        '// �Ō�Ƀ`�F�b�N�������������T�Ԍo���Ă邩�蓮�`�F�b�N�Ȃ��
        If lastUpdateCheckDateTime.AddDays(7) < Now Or isManual Then
            'MsgBox("check! " & lastUpdateCheckDateTime.AddDays(7) & "/" & Now)
            Dim parts As String()
            Dim wc As New System.Net.WebClient()
            wc.Headers.Add("user-agent", appName & " " & appRelease)
            'wc.Encoding = System.Text.Encoding.GetEncoding(51932)
            Dim sorce As String = wc.DownloadString("http://www.geocities.co.jp/SiliconValley/7773/etc/viewx.ja.update.html")
            wc.Dispose()

            '//
            parts = Split(sorce, ":")

            '// �V�����o�[�W�����������[�X����Ă�����
            If parts(0) > appRelease Then
                MsgBox(parts(1) & vbCrLf & vbCrLf & "�V�����o�[�W���� " & parts(0) & " / " & "���Ȃ��̃o�[�W���� " & appRelease)
            Else
                MsgBox("�ŐV�o�[�W�����ł�")
            End If

            '// �Ō�Ƀ`���b�N�����������X�V
            lastUpdateCheckDateTime = Now
        End If
    End Sub
End Module
