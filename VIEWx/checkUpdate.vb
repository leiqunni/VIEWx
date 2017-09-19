Module checkUpdate
    '// アップデートのチェック
    Public Sub checkUpdate(ByVal isManual As Boolean)
        '// 最後にチェックした日時から一週間経ってるか手動チェックならば
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

            '// 新しいバージョンがリリースされていたら
            If parts(0) > appRelease Then
                MsgBox(parts(1) & vbCrLf & vbCrLf & "新しいバージョン " & parts(0) & " / " & "あなたのバージョン " & appRelease)
            Else
                MsgBox("最新バージョンです")
            End If

            '// 最後にチャックした日時を更新
            lastUpdateCheckDateTime = Now
        End If
    End Sub
End Module
