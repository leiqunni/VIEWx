Imports System
Imports System.IO
Imports System.Text.RegularExpressions

Public Class FormMain

    Dim picIsDragged As Boolean
    Dim xx, yy, pxx, pyy As Integer

    Dim fs1, fs2 As FileStream
    Public nn As String

    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cmds As String() = System.Environment.GetCommandLineArgs()

        loadConfig()

        If cmds.Length > 1 Then getFiles(cmds(1))

    End Sub

    '// 終了処理
    Private Sub FormMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        '// 設定ファイル書き込み
        saveConfig()

        '// テンポラリディレクトリの削除
        Try
            Directory.Delete(tmpDirectory, True)
        Catch ex As Exception
        End Try

        End
    End Sub

    Private Sub FormMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If mnuViewActual.Checked Or mnuViewInWindow.Checked Then
            PictureBox1.Left = (PictureBox1.Width - PictureBox1.Width) / 2
            PictureBox1.Top = (PictureBox1.Height - PictureBox1.Height) / 2
        End If
    End Sub

    '// ドラッグ＆ドロップ
    Private Sub FormMain_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub FormMain_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        getFiles(e.Data.GetData(DataFormats.FileDrop)(0))
    End Sub

    '//
    Private Sub getFiles(ByVal target As String)
        Dim fileName, value As String

        If File.Exists(target) Then '// is file
            readPictureFile1(target)
            fileName = target
            target = Path.GetDirectoryName(target)
            targetType = 0
        Else '// is directory
            targetType = 1
        End If

        '// 画像ファイルの拡張子を持つファイルだけを挿入
        fileEntries.Clear()
        For Each value In Directory.GetFiles(target)
            If Regex.IsMatch(value, searchPattern, RegexOptions.IgnoreCase) Then
                fileEntries.Add(value)
            End If
        Next value

        '// sort
        If mnuViewOrderName.Checked Then mnuViewOrderName_Click(Nothing, Nothing)
        If mnuViewOrderNameNum.Checked Then mnuViewOrderNameNum_Click(Nothing, Nothing)
        If mnuViewOrderType.Checked Then mnuViewOrderType_Click(Nothing, Nothing)

        HScrollBar.Maximum = fileEntries.Count + HScrollBar.LargeChange - 2

        If targetType = 1 Then
            HScrollBar.Value = 0
            readPictureFile1(fileEntries(0))
        Else
            HScrollBar.Value = fileEntries.IndexOf(fileName)
        End If
    End Sub

    Private Sub FormMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case CType(keyConfig(CType(e.KeyCode, Integer)), Integer)
            Case 1
                prevPicture()
            Case 2
                nextPicture()
            Case 3
                FormMain_FormClosed(Nothing, Nothing)
            Case 4
                tsbLRot_Click(Nothing, Nothing)
            Case 5
                tsbRRot_Click(Nothing, Nothing)
        End Select
    End Sub

    '// 画像表示
    Public Sub readPictureFile1(ByVal fn As String)
        Fn_LoadImage(fn, PictureBox1)
    End Sub

    Private Sub nextPicture()
        Try
            If HScrollBar.Value >= fileEntries.Count - 1 Then HScrollBar.Value = 0 Else HScrollBar.Value += 1
            readPictureFile1(fileEntries(HScrollBar.Value))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub prevPicture()
        Try
            If HScrollBar.Value <= 0 Then HScrollBar.Value = fileEntries.Count - 1 Else HScrollBar.Value -= 1
            readPictureFile1(fileEntries(HScrollBar.Value))
        Catch ex As Exception
        End Try
    End Sub

    '// 原寸大表示の時のぐりぐり処理 ここから
    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            xx = Control.MousePosition.X
            yy = Control.MousePosition.Y
            pxx = PictureBox1.Left
            pyy = PictureBox1.Top
            picIsDragged = True
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            picIsDragged = False
        End If
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If picIsDragged And mnuViewActual.Checked Then
            PictureBox1.Left = pxx + Control.MousePosition.X - xx
            PictureBox1.Top = pyy + Control.MousePosition.Y - yy
        End If
    End Sub

    '// [ファイル]-[開く]
    Private Sub mnuFileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileOpen.Click
        'OpenFileDialog1.Filter = searchPattern
        OpenFileDialog.ShowDialog()
        If OpenFileDialog.FileName <> "" Then getFiles(OpenFileDialog.FileName)
    End Sub

    '// [ファイル]-[スライド ショー]
    Private Sub mnuFileSlideShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileSlideShow.Click
        Timer.Interval = slideShowInterval
        If Timer.Enabled Then
            mnuFileSlideShow.Text = "スライド ショーの開始"
            Timer.Enabled = False
        Else
            mnuFileSlideShow.Text = "スライド ショーの停止"
            Timer.Enabled = True
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        nextPicture()
    End Sub

    '// [ファイル]-[削除]
    Private Sub mnuFileDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileDelete.Click
        fs1.Close()
        fs1.Dispose()
        My.Computer.FileSystem.DeleteFile(fileEntries(HScrollBar.Value), FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
    End Sub

    '// [ファイル]-[終了]
    Private Sub mnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
        End
    End Sub

    '// [表示]-[スクロール バー]
    Private Sub mnuViewHScrollbar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewHScrollBar.Click
        Fn_HScrollbar(Not tsHScroolBar.Visible)
    End Sub

    '// [表示]-[ツール バー]
    Private Sub mnuViewToolBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewToolBar.Click
        If mnuViewToolBar.Checked Then
            'ToolStripContainer1.TopToolStripPanel.Hide()
            'ToolStripContainer1.LeftToolStripPanel.Hide()
            'ToolStripContainer1.RightToolStripPanel.Hide()
            ToolStripContainer1.BottomToolStripPanel.Hide()
            mnuViewToolBar.Checked = False
        Else
            'ToolStripContainer1.TopToolStripPanel.Show()
            'ToolStripContainer1.LeftToolStripPanel.Show()
            'ToolStripContainer1.RightToolStripPanel.Show()
            'ToolStripContainer1.BottomToolStripPanel.Location(New System.Drawing.Point(12, 9))
            ToolStripContainer1.BottomToolStripPanel.Show()
            mnuViewToolBar.Checked = True
        End If
    End Sub


    '// [表示]-[ステータス バー]
    Private Sub mnuViewStatusBar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuViewStatusBar.Click
        Fn_StatusBar(Not tsStatusBar.Visible)
    End Sub



    '// [表示]-[ウィンドウに合わせる]
    Public Sub mnuViewBestfit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewBestfit.Click
        Fn_Bestfit()
    End Sub

    '// [表示]-[ウィンドウに収める]
    Public Sub mnuViewInWindow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewInWindow.Click
        Try
            If PictureBox1.Width > PictureBox1.Image.Width And PictureBox1.Height > PictureBox1.Image.Height Then
                Fn_Actual()
            Else
                Fn_Bestfit()
            End If
        Catch
        End Try

        If IsNothing(sender) = False Then
            mnuViewBestfit.Checked = False '// ウィンドウに合わせる
            mnuViewInWindow.Checked = True '// ウィンドウに収める
            mnuViewActual.Checked = False '// 原寸大

            tsbBestfit.Enabled = True '// ウィンドウに合わせる
            tsbInWindow.Enabled = False '// ウィンドウに収める
            tsbActual.Enabled = True '// 原寸大
        End If
    End Sub

    '// [表示]-[原寸大]
    Public Sub mnuViewActual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewActual.Click
        Fn_Actual()
    End Sub

    '// [表示]-[見開き表示]-[右開き]
    Private Sub mnuViewSpreadRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewSpreadRight.Click
        mnuViewSpreadRight.Checked = True
        mnuViewSpreadLeft.Checked = False
    End Sub

    '// [表示]-[見開き表示]-[左開き]
    Private Sub mnuViewSpreadLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewSpreadLeft.Click
        mnuViewSpreadRight.Checked = False
        mnuViewSpreadLeft.Checked = True
    End Sub

    '// [表示]-[全画面表示]
    Private Sub mnuViewFullScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewFullScreen.Click
        If mnuViewFullScreen.Checked Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            Me.WindowState = FormWindowState.Normal
            mnuViewFullScreen.Checked = False
        Else
            Me.WindowState = FormWindowState.Normal
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized
            mnuViewFullScreen.Checked = True
        End If
    End Sub

    '// [オプション]
    Private Sub mnuToolsOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsOption.Click
        frmConfig.Show()
    End Sub

    '// [ヘルプ]-[ヘルプ]
    Private Sub mnuHelpHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHelpHelp.Click
        Process.Start(Application.StartupPath & "\help.html")
    End Sub

    '// [ヘルプ]-[最新版をチェック]
    Private Sub mnuHelpCheckUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHelpCheckUpdate.Click
        checkUpdate.checkUpdate(True)
    End Sub

    '// [ヘルプ]-[バージョン情報]
    Private Sub mnuHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHelpAbout.Click
        frmAbout.ShowDialog()
    End Sub

    '// [前へ]
    Private Sub mnuPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrev.Click
        prevPicture()
    End Sub

    '// [次へ]
    Private Sub mnuNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNext.Click
        nextPicture()
    End Sub

    Private Sub HScrollBar1_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
        MsgBox("#")
        Try
            readPictureFile1(fileEntries(HScrollBar.Value))
        Catch ex As Exception
        End Try
    End Sub

    Private Enum SortDirection
        Ascending
        Descending
    End Enum

    Private _direction As SortDirection

    Private Sub SortByName()
        Dim compDesc As New OrderByNameDesc()

        If _direction = SortDirection.Ascending Then
            fileEntries.Sort()
        Else
            fileEntries.Sort(compDesc)
        End If

        mnuViewOrderName.Checked = True
        mnuViewOrderNameNum.Checked = False
        mnuViewOrderDate.Checked = False
        mnuViewOrderType.Checked = False
        mnuViewOrderSize.Checked = False
    End Sub

    '// 並べ替え
    Private Sub mnuViewOrderName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewOrderName.Click
        SortByName()
    End Sub

    Private Sub mnuViewOrderNameNum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewOrderNameNum.Click
        Dim compAsc As New OrderByNameNumAsc()
        Dim compDesc As New OrderByNameNumDesc()

        If mnuViewOrderAsc.Checked Then fileEntries.Sort(compAsc) Else fileEntries.Sort(compDesc)

        'HScrollBar1.Value = 0

        'Try
        '    readPictureFile1(fileEntries(HScrollBar1.Value))
        'Catch ex As Exception
        'End Try

        mnuViewOrderName.Checked = False
        mnuViewOrderNameNum.Checked = True
        mnuViewOrderDate.Checked = False
        mnuViewOrderType.Checked = False
        mnuViewOrderSize.Checked = False
    End Sub

    'Private Sub mnuViewOrderSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewOrderSize.Click
    '    fileEntries.Sort()
    '    HScrollBar1.Value = 0
    '    Try
    '        ReadPictureFile1(fileEntries(HScrollBar1.Value))
    '    Catch ex As Exception
    '    End Try
    '    mnuViewOrderName.Checked = False
    '    mnuViewOrderNameNum.Checked = False
    '    mnuViewOrderDate.Checked = True
    '    mnuViewOrderType.Checked = False
    '    mnuViewOrderSize.Checked = False
    'End Sub

    Private Sub mnuViewOrderType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewOrderType.Click
        Dim compAsc As New OrderByTypeAsc()
        Dim compDesc As New OrderByTypeDesc()

        If mnuViewOrderAsc.Checked Then fileEntries.Sort(compAsc) Else fileEntries.Sort(compDesc)

        'HScrollBar1.Value = 0

        'Try
        '    readPictureFile1(fileEntries(HScrollBar1.Value))
        'Catch ex As Exception
        'End Try

        mnuViewOrderName.Checked = False
        mnuViewOrderNameNum.Checked = False
        mnuViewOrderDate.Checked = False
        mnuViewOrderType.Checked = True
        mnuViewOrderSize.Checked = False
    End Sub

    'Private Sub mnuViewOrderDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewOrderDate.Click
    '    fileEntries.Sort()
    '    HScrollBar1.Value = 0
    '    Try
    '        ReadPictureFile1(fileEntries(HScrollBar1.Value))
    '    Catch ex As Exception
    '    End Try
    '    mnuViewOrderName.Checked = False
    '    mnuViewOrderNameNum.Checked = False
    '    mnuViewOrderDate.Checked = False
    '    mnuViewOrderType.Checked = False
    '    mnuViewOrderSize.Checked = True
    'End Sub

    Private Sub Fn_SortDirection(ByVal value As SortDirection)
        _direction = value
        Select Case value
            Case SortDirection.Ascending
                mnuViewOrderAsc.Checked = True
                mnuViewOrderDesc.Checked = False
            Case SortDirection.Descending
                mnuViewOrderAsc.Checked = False
                mnuViewOrderDesc.Checked = True
        End Select
    End Sub

    Private Sub mnuViewOrderAsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewOrderAsc.Click
        Fn_SortDirection(SortDirection.Ascending)
    End Sub

    Private Sub mnuViewOrderDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewOrderDesc.Click
        Fn_SortDirection(SortDirection.Descending)
    End Sub

    Public Class OrderByNameAsc
        Implements System.Collections.IComparer
        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Return String.Compare(CType(x, String), CType(y, String))
        End Function
    End Class

    Public Class OrderByNameDesc
        Implements System.Collections.IComparer
        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Return -String.Compare(CType(x, String), CType(y, String))
        End Function
    End Class

    Public Class OrderByTypeAsc
        Implements System.Collections.IComparer
        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            x = Path.GetExtension(x)
            y = Path.GetExtension(y)
            Return String.Compare(CType(x, String), CType(y, String))
        End Function
    End Class

    Public Class OrderByTypeDesc
        Implements System.Collections.IComparer
        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            x = Path.GetExtension(x)
            y = Path.GetExtension(y)
            Return -String.Compare(CType(x, String), CType(y, String))
        End Function
    End Class

    Public Class OrderByNameNumAsc
        Implements System.Collections.IComparer
        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Return Module1.StrCmpLogicalW(x, y)
        End Function
    End Class

    Public Class OrderByNameNumDesc
        Implements System.Collections.IComparer
        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Return -Module1.StrCmpLogicalW(x, y)
        End Function
    End Class

    '// マウスホイール
    Private Sub FormMain_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        If e.Delta > 0 Then prevPicture() Else nextPicture()
    End Sub

    '// マウスジェスチャ
    Private Sub FormMain_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown, PictureBox1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
        End If
    End Sub

    Private Sub FormMain_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp, PictureBox1.MouseUp
    End Sub

    Private Sub FormMain_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove, PictureBox1.MouseMove
    End Sub

    '// [ツールバー]-[前のイメージ]
    Private Sub tsbPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrev.Click
        prevPicture()
    End Sub

    '// [ツールバー]-[次のイメージ]
    Private Sub tsbNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNext.Click
        nextPicture()
    End Sub

    '// [ツール バー]-[ウィンドウに合わせる]
    Private Sub tsbBestfit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbBestfit.Click
        Fn_Bestfit()
    End Sub

    '// [ツール バー]-[ウィンドウに収める]
    Private Sub tsbInWindow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbInWindow.Click
        mnuViewInWindow_Click(sender, e)
    End Sub

    '// [ツール バー]-[原寸大]
    Private Sub tsbActual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbActual.Click
        Fn_Actual()
    End Sub

    '// [ツールバー]-[スライド ショー]
    Private Sub tsbSlideShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSlideShow.Click
        mnuFileSlideShow_Click(Nothing, Nothing)
    End Sub

    Private _zoom As Double = 1.0

    Private Sub Fn_Zoom(ByVal value As Double)
        Fn_Actual()
        _zoom += value
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Size = New Size(PictureBox1.Image.Size.Width * _zoom, PictureBox1.Image.Size.Height * _zoom)
    End Sub

    '// [ツールバー]-[拡大]
    Private Sub tsbZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbZoomIn.Click
        Fn_Zoom(0.1)
    End Sub

    '// [ツールバー]-[縮小]
    Private Sub tsbZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbZoomOut.Click
        Fn_Zoom(-0.1)
    End Sub

    Private Sub ToolStripContainer1_LeftToolStripPanel_Click(sender As Object, e As EventArgs) Handles ToolStripContainer1.LeftToolStripPanel.Click

    End Sub

    '// [ツールバー]-[右回りに回転]
    Private Sub tsbRRot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRRot.Click
        Fn_RotateRight()
    End Sub

    '// [ツールバー]-[左りに回転]
    Private Sub tsbLRot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbLRot.Click
        Fn_RotateLeft()
    End Sub

    '// [ツールバー]-[削除]
    Private Sub tbsDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbsDel.Click
        mnuFileDelete_Click(Nothing, Nothing)
    End Sub

    '// [ツールバー]-[ヘルプ]
    Private Sub tsbHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbHelp.Click
        mnuHelpHelp_Click(Nothing, Nothing)
    End Sub

    Private Sub PictureBox_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        If mnuViewBestfit.Checked Then
            mnuViewActual_Click(sender, e)
        Else
            If mnuViewActual.Checked Then mnuViewBestfit_Click(sender, e)
        End If
    End Sub



End Class
