﻿Imports System.IO

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
        If tsToolBar.Visible Then
            Dim p = (tsToolBar.Width - 250) / 2
            Dim pad As Padding = New Padding(p, 0, 1, 0)
            tsToolBar.Padding = pad
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
        My.Computer.FileSystem.DeleteFile(PicList(HScrollBar1.Value).Name, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
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
            tsToolBar.Hide()
            mnuViewToolBar.Checked = False
        Else
            tsToolBar.Show()
            mnuViewToolBar.Checked = True
        End If
    End Sub

    Private Sub mnuViewStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewStatusBar.Click
        Fn_StatusBar(Not StatusStrip1.Visible)
    End Sub

    '--- Pcture PicturroxSizeModeSepalator

    Private Sub mnuViewStretch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewStretch.Click
        Fn_SizeMode(PictureBoxSizeMode.StretchImage)
    End Sub

    Private Sub mnuViewAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewActual.Click
        Fn_SizeMode(PictureBoxSizeMode.AutoSize)
    End Sub

    Private Sub mnuViewZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewZoom.Click
        Fn_SizeMode(PictureBoxSizeMode.Zoom)
    End Sub

    '--- Sepalator

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

#End Region

#Region "--- Tools"

    Private Sub mnuToolsOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsOption.Click
        Form2.ShowDialog()
    End Sub

#End Region

    Private Sub mnuHelpAbout_Click(sender As System.Object, e As System.EventArgs) Handles mnuHelpAbout.Click
        Form3.ShowDialog()
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


#Region "Tool Bar"

    ''' <summary>
    ''' [ToolBar]-[Prev]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub tsbPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrev.Click
        Fn_Prev()
    End Sub

    ''' <summary>
    ''' [ToolBar]-[Next]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub tsbNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNext.Click
        Fn_Next()
    End Sub

    ''' <summary>
    ''' [ToolBar]-[Actual]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub tsbActual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbActual.Click
        Fn_Actual()
    End Sub

    ''' <summary>
    ''' [ToolBar]-[Bestfit]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub tsbBestfitClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbBestfit.Click
        fn_Bestfit()
    End Sub

    ''' <summary>
    ''' [ToolBar]-[Strech]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub tsbStretch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbStretch.Click
        fn_Stretch()
    End Sub

    Private _zoom As Double = 1.0

    Private Sub Fn_Zoom(ByVal value As Double)
        Fn_Actual()
        _zoom += value
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Size = New Size(PictureBox1.Image.Size.Width * _zoom, PictureBox1.Image.Size.Height * _zoom)
    End Sub

    ''' <summary>
    ''' [ToolBar]-[ZoomIn]
    ''' </summary>
    ''' <param name="sender"></param>
    Private Sub tsbZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbZoomIn.Click
        Fn_Zoom(0.1)
    End Sub

    ''' <summary>
    ''' [ToolBar]-[ZoomOut]
    ''' </summary>
    ''' <param name="sender"></param>
    Private Sub tsbZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbZoomOut.Click
        Fn_Zoom(-0.1)
    End Sub

    '// [ツールバー]-[右回りに回転]
    Private Sub tsbRRot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRRot.Click
        Fn_RotateRight()
    End Sub

    '// [ツールバー]-[左りに回転]
    Private Sub tsbLRot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbLRot.Click
        Fn_RotateLeft()
    End Sub

    ''' <summary>
    ''' [ToolBar]-[Delete]
    ''' </summary>
    ''' <param name="sender"></param>
    Private Sub tbsDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbsDel.Click
        mnuFileDelete_Click(Nothing, Nothing)
    End Sub

#End Region






End Class

