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

    '// �I������
    Private Sub FormMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        '// �ݒ�t�@�C����������
        saveConfig()

        '// �e���|�����f�B���N�g���̍폜
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

    '// �h���b�O���h���b�v
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

        '// �摜�t�@�C���̊g���q�����t�@�C��������}��
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

    '// �摜�\��
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

    '// ������\���̎��̂��肮�菈�� ��������
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

    '// [�t�@�C��]-[�J��]
    Private Sub mnuFileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileOpen.Click
        'OpenFileDialog1.Filter = searchPattern
        OpenFileDialog.ShowDialog()
        If OpenFileDialog.FileName <> "" Then getFiles(OpenFileDialog.FileName)
    End Sub

    '// [�t�@�C��]-[�X���C�h �V���[]
    Private Sub mnuFileSlideShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileSlideShow.Click
        Timer.Interval = slideShowInterval
        If Timer.Enabled Then
            mnuFileSlideShow.Text = "�X���C�h �V���[�̊J�n"
            Timer.Enabled = False
        Else
            mnuFileSlideShow.Text = "�X���C�h �V���[�̒�~"
            Timer.Enabled = True
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        nextPicture()
    End Sub

    '// [�t�@�C��]-[�폜]
    Private Sub mnuFileDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileDelete.Click
        fs1.Close()
        fs1.Dispose()
        My.Computer.FileSystem.DeleteFile(fileEntries(HScrollBar.Value), FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
    End Sub

    '// [�t�@�C��]-[�I��]
    Private Sub mnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
        End
    End Sub

    '// [�\��]-[�X�N���[�� �o�[]
    Private Sub mnuViewHScrollbar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewHScrollBar.Click
        Fn_HScrollbar(Not tsHScroolBar.Visible)
    End Sub

    '// [�\��]-[�c�[�� �o�[]
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


    '// [�\��]-[�X�e�[�^�X �o�[]
    Private Sub mnuViewStatusBar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuViewStatusBar.Click
        Fn_StatusBar(Not tsStatusBar.Visible)
    End Sub



    '// [�\��]-[�E�B���h�E�ɍ��킹��]
    Public Sub mnuViewBestfit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewBestfit.Click
        Fn_Bestfit()
    End Sub

    '// [�\��]-[�E�B���h�E�Ɏ��߂�]
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
            mnuViewBestfit.Checked = False '// �E�B���h�E�ɍ��킹��
            mnuViewInWindow.Checked = True '// �E�B���h�E�Ɏ��߂�
            mnuViewActual.Checked = False '// ������

            tsbBestfit.Enabled = True '// �E�B���h�E�ɍ��킹��
            tsbInWindow.Enabled = False '// �E�B���h�E�Ɏ��߂�
            tsbActual.Enabled = True '// ������
        End If
    End Sub

    '// [�\��]-[������]
    Public Sub mnuViewActual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewActual.Click
        Fn_Actual()
    End Sub

    '// [�\��]-[���J���\��]-[�E�J��]
    Private Sub mnuViewSpreadRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewSpreadRight.Click
        mnuViewSpreadRight.Checked = True
        mnuViewSpreadLeft.Checked = False
    End Sub

    '// [�\��]-[���J���\��]-[���J��]
    Private Sub mnuViewSpreadLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewSpreadLeft.Click
        mnuViewSpreadRight.Checked = False
        mnuViewSpreadLeft.Checked = True
    End Sub

    '// [�\��]-[�S��ʕ\��]
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

    '// [�I�v�V����]
    Private Sub mnuToolsOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsOption.Click
        frmConfig.Show()
    End Sub

    '// [�w���v]-[�w���v]
    Private Sub mnuHelpHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHelpHelp.Click
        Process.Start(Application.StartupPath & "\help.html")
    End Sub

    '// [�w���v]-[�ŐV�ł��`�F�b�N]
    Private Sub mnuHelpCheckUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHelpCheckUpdate.Click
        checkUpdate.checkUpdate(True)
    End Sub

    '// [�w���v]-[�o�[�W�������]
    Private Sub mnuHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHelpAbout.Click
        frmAbout.ShowDialog()
    End Sub

    '// [�O��]
    Private Sub mnuPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrev.Click
        prevPicture()
    End Sub

    '// [����]
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

    '// ���בւ�
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

    '// �}�E�X�z�C�[��
    Private Sub FormMain_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        If e.Delta > 0 Then prevPicture() Else nextPicture()
    End Sub

    '// �}�E�X�W�F�X�`��
    Private Sub FormMain_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown, PictureBox1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
        End If
    End Sub

    Private Sub FormMain_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp, PictureBox1.MouseUp
    End Sub

    Private Sub FormMain_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove, PictureBox1.MouseMove
    End Sub

    '// [�c�[���o�[]-[�O�̃C���[�W]
    Private Sub tsbPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrev.Click
        prevPicture()
    End Sub

    '// [�c�[���o�[]-[���̃C���[�W]
    Private Sub tsbNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNext.Click
        nextPicture()
    End Sub

    '// [�c�[�� �o�[]-[�E�B���h�E�ɍ��킹��]
    Private Sub tsbBestfit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbBestfit.Click
        Fn_Bestfit()
    End Sub

    '// [�c�[�� �o�[]-[�E�B���h�E�Ɏ��߂�]
    Private Sub tsbInWindow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbInWindow.Click
        mnuViewInWindow_Click(sender, e)
    End Sub

    '// [�c�[�� �o�[]-[������]
    Private Sub tsbActual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbActual.Click
        Fn_Actual()
    End Sub

    '// [�c�[���o�[]-[�X���C�h �V���[]
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

    '// [�c�[���o�[]-[�g��]
    Private Sub tsbZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbZoomIn.Click
        Fn_Zoom(0.1)
    End Sub

    '// [�c�[���o�[]-[�k��]
    Private Sub tsbZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbZoomOut.Click
        Fn_Zoom(-0.1)
    End Sub

    Private Sub ToolStripContainer1_LeftToolStripPanel_Click(sender As Object, e As EventArgs) Handles ToolStripContainer1.LeftToolStripPanel.Click

    End Sub

    '// [�c�[���o�[]-[�E���ɉ�]]
    Private Sub tsbRRot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRRot.Click
        Fn_RotateRight()
    End Sub

    '// [�c�[���o�[]-[����ɉ�]]
    Private Sub tsbLRot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbLRot.Click
        Fn_RotateLeft()
    End Sub

    '// [�c�[���o�[]-[�폜]
    Private Sub tbsDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbsDel.Click
        mnuFileDelete_Click(Nothing, Nothing)
    End Sub

    '// [�c�[���o�[]-[�w���v]
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
