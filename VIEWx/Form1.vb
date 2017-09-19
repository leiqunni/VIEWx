Imports System.IO

Public Class Form1

    Private RegExt As String
    Private KeyConf As New Dictionary(Of String, String)
    Private PicList As New List(Of FileInfo)

#Region "--- Form"

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim ext As New System.Text.StringBuilder
        For Each item As String In My.Settings.Extension.Split(" ".ToCharArray)
            ext.Append("\." & item.Trim & "$|")
        Next
        RegExt = ext.ToString & "^$"

        InitWindow()

        Fn_LoadKeyConf()

        If My.Application.CommandLineArgs.Count > 0 Then
            Dim args(My.Application.CommandLineArgs.Count - 1) As String
            My.Application.CommandLineArgs.CopyTo(args, 0)
            Fn_LoadList(args)
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.WindowState = FormWindowState.Normal Then
            My.Settings.WindowLocation = Me.Location
            My.Settings.WindowSize = Me.Size
        End If
        My.Settings.SizeMode = PictureBox1.SizeMode
        'My.Settings.MenuBar = MenuStrip1.Visible
        'My.Settings.HScrollBar = HScrollBar1.Visible
        'My.Settings.StatusBar = StatusStrip1.Visible
    End Sub

    Private Sub Form1_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        If PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize Then
            Control_Centered(PictureBox1.Bounds)
        End If
    End Sub

    Private Sub Form1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Fn_LoadList(DirectCast(e.Data.GetData(Windows.Forms.DataFormats.FileDrop), String()))
    End Sub

    Private Sub Form1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(Windows.Forms.DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Form1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        If PicList.Count = 0 Then Return
        If e.Delta < 0 Then
            Fn_Next()
        Else
            Fn_Prev()
        End If
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        ' "# Mod(%1d)    KeyCodes(%03d)  Actions "
        Dim key As String = String.Format("{0:0}{1:000}", If(e.Shift, 4, 0) + If(e.Control, 2, 0) + If(e.Alt, 1, 0), CInt(e.KeyCode))
        If KeyConf.ContainsKey(key) Then
            Select Case KeyConf(key)
                Case "prev"
                    Fn_Prev()
                Case "next"
                    Fn_Next()
                Case "lprv"
                    Fn_Prev(HScrollBar1.LargeChange)
                Case "lnxt"
                    Fn_Next(HScrollBar1.LargeChange)
                Case "mini"
                Case "maxi"
                Case "sbar"
                    Fn_StatusBar(Not StatusStrip1.Visible)
                Case "actu"
                    Fn_SizeMode(PictureBoxSizeMode.AutoSize)
                Case "stre"
                    Fn_SizeMode(PictureBoxSizeMode.StretchImage)
                Case "zoom"
                    Fn_SizeMode(PictureBoxSizeMode.Zoom)
                Case "aczo"
                    Fn_NormalZoon()
                Case "mbar"
                    Debug.Print("mbar")
                    Fn_MenuBar(Not MenuStrip1.Visible)
                Case "rbar"
                    Fn_HScrollBar(Not HScrollBar1.Visible)
                Case "exit"
                    End
            End Select
        End If
    End Sub

#End Region

#Region "--- Menu"

#Region "--- File"

    Private Sub mnuFileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileOpen.Click
        Fn_OpenFileDialog()
    End Sub

    '// [ファイル]-[削除]
    Private Sub mnuFileDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileDelete.Click
        fs1.Close()
        fs1.Dispose()
        My.Computer.FileSystem.DeleteFile(fileEntries(HScrollBar.Value), FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
    End Sub

    Private Sub mnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
        End
    End Sub

#End Region

#Region "--- Edit"

    Private Sub mnuEditCopyPath_Click(sender As System.Object, e As System.EventArgs) Handles mnuEditCopyPath.Click
        Clipboard.SetText(PicList(HScrollBar1.Value).FullName)
    End Sub

    Private Sub mnuEditCopyImage_Click(sender As System.Object, e As System.EventArgs) Handles mnuEditCopyImage.Click
        Clipboard.SetImage(PictureBox1.Image)
    End Sub

#End Region

#Region "--- View"

    Private Sub mnuViewMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewMenuBar.Click
        Fn_MenuBar(Not MenuStrip1.Visible)
    End Sub

    Private Sub mnuViewHScrollBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewHScrollBar.Click
        Fn_HScrollBar(Not HScrollBar1.Visible)
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

    Private Sub mnuViewStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewStatusBar.Click
        Fn_StatusBar(Not StatusStrip1.Visible)
    End Sub

    Private Sub mnuViewStretch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewStretch.Click
        Fn_SizeMode(PictureBoxSizeMode.StretchImage)
    End Sub

    Private Sub mnuViewAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewActual.Click
        Fn_SizeMode(PictureBoxSizeMode.AutoSize)
    End Sub

    Private Sub mnuViewZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewZoom.Click
        Fn_SizeMode(PictureBoxSizeMode.Zoom)
    End Sub

    Private Sub mnuViewSortNone_Click(sender As Object, e As System.EventArgs) Handles mnuViewSortNone.Click
        Fn_Sort(SortType.None, My.Settings.SortOrder)
    End Sub

    Private Sub mnuViewSortName_Click(sender As System.Object, e As System.EventArgs) Handles mnuViewSortName.Click
        Fn_Sort(SortType.Name, My.Settings.SortOrder)
    End Sub

    Private Sub mnuViewSortNameNum_Click(sender As System.Object, e As System.EventArgs) Handles mnuViewSortNameNum.Click
        Fn_Sort(SortType.NameNum, My.Settings.SortOrder)
    End Sub

    Private Sub mnuViewSortDate_Click(sender As System.Object, e As System.EventArgs) Handles mnuViewSortDate.Click
        Fn_Sort(SortType.Date, My.Settings.SortOrder)
    End Sub

    Private Sub mnuViewSortType_Click(sender As System.Object, e As System.EventArgs) Handles mnuViewSortType.Click
        Fn_Sort(SortType.Type, My.Settings.SortOrder)
    End Sub

    Private Sub mnuViewSortSize_Click(sender As System.Object, e As System.EventArgs) Handles mnuViewSortSize.Click
        Fn_Sort(SortType.Size, My.Settings.SortOrder)
    End Sub

    Private Sub mnuViewSortAsc_Click(sender As System.Object, e As System.EventArgs) Handles mnuViewSortAsc.Click
        Fn_Sort(My.Settings.SortType, SortOrder.Ascending)
    End Sub

    Private Sub mnuViewSortDesc_Click(sender As System.Object, e As System.EventArgs) Handles mnuViewSortDesc.Click
        Fn_Sort(My.Settings.SortType, SortOrder.Descending)
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

#End Region

#Region "--- Tools"

    Private Sub mnuToolsOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsOption.Click
        Form2.ShowDialog()
    End Sub

#End Region

    Private Sub mnuHelpAbout_Click(sender As System.Object, e As System.EventArgs) Handles mnuHelpAbout.Click
        Me.Text = "About dePic"
        lblStatus.Text = ""
    End Sub

#End Region

    Private Sub HScrollBar1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HScrollBar1.ValueChanged
        Fn_PicLoad(HScrollBar1.Value)
    End Sub

#Region "PictureBox"

    Private onDrag As Boolean
    Private ex, ey As Integer

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left And PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize Then
            onDrag = True
            ex = e.X
            ey = e.Y
        End If
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If onDrag Then
            PictureBox1.Left += e.X - ex
            PictureBox1.Top += e.Y - ey
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        onDrag = False
    End Sub

    Private Sub PictureBox1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDoubleClick
        Fn_NormalZoon()
    End Sub

#End Region



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










End Class

