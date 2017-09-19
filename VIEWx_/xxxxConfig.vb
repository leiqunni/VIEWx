Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Soap

Module xxxxConfig
    '// 設定ファイル読み込み
    Public Sub loadConfig()
        Dim formatter As SoapFormatter = New SoapFormatter

        Try
            Using fs As FileStream = New FileStream(Application.StartupPath & "\\viewx.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                Dim cls As clsConfig = CType(formatter.Deserialize(fs), clsConfig)

                FormMain.Top = cls.Top
                FormMain.Left = cls.Left
                FormMain.Width = cls.Width
                FormMain.Height = cls.Height

                Select Case cls.SizeMode
                    Case PictureBoxSizeMode.Zoom '// ウィンドウに合わせる
                        FormMain.mnuViewBestfit_Click("", Nothing)
                    Case PictureBoxSizeMode.AutoSize '// ウィンドウに収める
                        FormMain.mnuViewInWindow_Click("", Nothing)
                    Case PictureBoxSizeMode.CenterImage '// 原寸大
                        FormMain.mnuViewActual_Click("", Nothing)
                End Select

                FormMain.mnuViewHScrollBar.Checked = cls.mnuViewHScrollBar
                FormMain.mnuViewToolBar.Checked = cls.mnuViewToolBar
                FormMain.mnuViewStatusBar.Checked = cls.mnuViewStatusBar

                FormMain.mnuViewSpread.Checked = cls.mnuViewSpread
                FormMain.mnuViewSpreadRight.Checked = cls.mnuViewSpreadRight
                FormMain.mnuViewSpreadLeft.Checked = cls.mnuViewSpreadLeft

                '              If FormMain.mnuViewHScrollBar.Checked Then FormMain.Panel1.Show() Else FormMain.Panel1.Hide()
                If FormMain.mnuViewToolBar.Checked Then FormMain.ToolStripContainer1.Show() Else FormMain.ToolStripContainer1.BottomToolStripPanel.Hide()
                If FormMain.mnuViewStatusBar.Checked Then FormMain.tsStatusBar.Show() Else FormMain.tsStatusBar.Hide()

                '// 並べ替え
                FormMain.mnuViewOrderName.Checked = cls.mnuViewOrderName
                FormMain.mnuViewOrderNameNum.Checked = cls.mnuViewOrderNameNum
                FormMain.mnuViewOrderType.Checked = cls.mnuViewOrderType

                FormMain.mnuViewOrderAsc.Checked = cls.mnuViewOrderAsc
                FormMain.mnuViewOrderDesc.Checked = cls.mnuViewOrderDesc

                '// キー設定
                keyConfig = cls.KeyConfig

                '// 最終起動時間
                lastUpdateCheckDateTime = cls.lastUpdateCheckDateTime

                '// 自動アップデートチェックをするかどうか
                doUpdateCheck = cls.doUpdateCheck

                '// スライド ショーの間隔（ミリ秒）
                slideShowInterval = cls.slideShowInterval
            End Using
        Catch ex As Exception
            '設定フィルが読み込めなければデフォルトの設定
            'MsgBox("設定ファイルを読み込めませんでした。デフォルトの値を使用します。")

            FormMain.Top = (SystemInformation.WorkingArea.Height - FormMain.Height) / 2
            FormMain.Left = (SystemInformation.WorkingArea.Width - FormMain.Width) / 2

            '// スクロールバー非表示
            'FormMain.Panel1.Hide()
            FormMain.mnuViewHScrollBar.Checked = False

            '// ツールバー非表示
            FormMain.ToolStripContainer1.BottomToolStripPanel.Hide()
            FormMain.mnuViewToolBar.Checked = False

            '// ステータスバー非表示
            FormMain.tsStatusBar.Hide()
            FormMain.mnuViewStatusBar.Checked = False

            '// ウィンドウに合わせる
            FormMain.mnuViewBestfit_Click("", Nothing)

            '// 見開き表示じゃない
            'FormMain.SplitContainer1.Panel2Collapsed = True
            FormMain.mnuViewSpread.Checked = False

            '// 右開き
            FormMain.mnuViewSpreadRight.Checked = True
            FormMain.mnuViewSpreadLeft.Checked = False

            '// 並べ替え
            FormMain.mnuViewOrderName.Checked = True
            FormMain.mnuViewOrderType.Checked = False

            FormMain.mnuViewOrderAsc.Checked = True
            FormMain.mnuViewOrderDesc.Checked = False

            '// 最低限のキー設定
            keyConfig.Add(8, 1)
            keyConfig.Add(13, 2)
            keyConfig.Add(32, 2)

            '// 自動アップデートチェック
            doUpdateCheck = True

            '// スライド ショーの間隔（ミリ秒）
            slideShowInterval = 3000
        End Try
    End Sub

    '// 設定ファイル保存
    Public Sub saveConfig()
        Dim cls As New clsConfig
        Dim formatter As SoapFormatter = New SoapFormatter

        If FormMain.WindowState = FormWindowState.Maximized Then
            cls.Top = FormMain.Top + 4
            cls.Left = FormMain.Left + 4
            cls.Width = FormMain.Width - 8
            cls.Height = FormMain.Height - 8
        Else
            cls.Top = FormMain.Top
            cls.Left = FormMain.Left
            cls.Width = FormMain.Width
            cls.Height = FormMain.Height
        End If

        cls.mnuViewHScrollBar = FormMain.mnuViewHScrollBar.Checked
        cls.mnuViewToolBar = FormMain.mnuViewToolBar.Checked
        cls.mnuViewStatusBar = FormMain.mnuViewStatusBar.Checked

        If FormMain.mnuViewBestfit.Checked Then cls.SizeMode = PictureBoxSizeMode.Zoom
        If FormMain.mnuViewInWindow.Checked Then cls.SizeMode = PictureBoxSizeMode.AutoSize
        If FormMain.mnuViewActual.Checked Then cls.SizeMode = PictureBoxSizeMode.CenterImage

        cls.mnuViewSpread = FormMain.mnuViewSpread.Checked

        cls.mnuViewSpreadRight = FormMain.mnuViewSpreadRight.Checked
        cls.mnuViewSpreadLeft = FormMain.mnuViewSpreadLeft.Checked

        cls.mnuViewOrderName = FormMain.mnuViewOrderName.Checked
        cls.mnuViewOrderNameNum = FormMain.mnuViewOrderNameNum.Checked
        cls.mnuViewOrderType = FormMain.mnuViewOrderType.Checked

        cls.mnuViewOrderAsc = FormMain.mnuViewOrderAsc.Checked
        cls.mnuViewOrderDesc = FormMain.mnuViewOrderDesc.Checked

        cls.keyConfig = keyConfig

        cls.lastUpdateCheckDateTime = lastUpdateCheckDateTime
        cls.doUpdateCheck = doUpdateCheck

        cls.slideShowInterval = slideShowInterval

        Try
            Using fs As New FileStream(Application.StartupPath & "\\viewx.xml", FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
                formatter.Serialize(fs, cls)
            End Using
        Catch ex As Exception
            MsgBox("設定ファイルを書き込めませんでした")
        End Try

    End Sub
End Module
