<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditCopyPath = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditCopyImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewMenuBar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewHScrollBar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewToolBar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewStatusBar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView_0 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewActual = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewZoom = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewStretch = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView_1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewSort = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewSortNone = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewSortName = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewSortNameNum = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewSortDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewSortType = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewSortSize = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewSort_0 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewSortAsc = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewSortDesc = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuToolsOption = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.tsToolBar = New System.Windows.Forms.ToolStrip()
        Me.tsbPrev = New System.Windows.Forms.ToolStripButton()
        Me.tsbNext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbActual = New System.Windows.Forms.ToolStripButton()
        Me.tsbBestfit = New System.Windows.Forms.ToolStripButton()
        Me.tsbStretch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbZoomIn = New System.Windows.Forms.ToolStripButton()
        Me.tsbZoomOut = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbLRot = New System.Windows.Forms.ToolStripButton()
        Me.tsbRRot = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbsDel = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsToolBar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuEdit, Me.mnuView, Me.mnuTools, Me.mnuHelp})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(472, 24)
        Me.MenuStrip1.TabIndex = 0
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileOpen, Me.mnuFileDelete, Me.tsSeparator1, Me.mnuFileExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(39, 20)
        Me.mnuFile.Text = "&File"
        '
        'mnuFileOpen
        '
        Me.mnuFileOpen.Name = "mnuFileOpen"
        Me.mnuFileOpen.Size = New System.Drawing.Size(148, 22)
        Me.mnuFileOpen.Text = "&Open..."
        '
        'mnuFileDelete
        '
        Me.mnuFileDelete.Name = "mnuFileDelete"
        Me.mnuFileDelete.Size = New System.Drawing.Size(148, 22)
        Me.mnuFileDelete.Text = "&Delete File..."
        '
        'tsSeparator1
        '
        Me.tsSeparator1.Name = "tsSeparator1"
        Me.tsSeparator1.Size = New System.Drawing.Size(145, 6)
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Name = "mnuFileExit"
        Me.mnuFileExit.Size = New System.Drawing.Size(148, 22)
        Me.mnuFileExit.Text = "&Exit"
        '
        'mnuEdit
        '
        Me.mnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditCopyPath, Me.mnuEditCopyImage})
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(41, 20)
        Me.mnuEdit.Text = "&Edit"
        '
        'mnuEditCopyPath
        '
        Me.mnuEditCopyPath.Name = "mnuEditCopyPath"
        Me.mnuEditCopyPath.Size = New System.Drawing.Size(145, 22)
        Me.mnuEditCopyPath.Text = "Copy &Path"
        '
        'mnuEditCopyImage
        '
        Me.mnuEditCopyImage.Name = "mnuEditCopyImage"
        Me.mnuEditCopyImage.Size = New System.Drawing.Size(145, 22)
        Me.mnuEditCopyImage.Text = "Copy &Image"
        '
        'mnuView
        '
        Me.mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewMenuBar, Me.mnuViewHScrollBar, Me.mnuViewToolBar, Me.mnuViewStatusBar, Me.mnuView_0, Me.mnuViewActual, Me.mnuViewZoom, Me.mnuViewStretch, Me.mnuView_1, Me.mnuViewSort})
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Size = New System.Drawing.Size(47, 20)
        Me.mnuView.Text = "&View"
        '
        'mnuViewMenuBar
        '
        Me.mnuViewMenuBar.CheckOnClick = True
        Me.mnuViewMenuBar.Name = "mnuViewMenuBar"
        Me.mnuViewMenuBar.Size = New System.Drawing.Size(136, 22)
        Me.mnuViewMenuBar.Text = "&Menu Bar"
        '
        'mnuViewHScrollBar
        '
        Me.mnuViewHScrollBar.CheckOnClick = True
        Me.mnuViewHScrollBar.Name = "mnuViewHScrollBar"
        Me.mnuViewHScrollBar.Size = New System.Drawing.Size(136, 22)
        Me.mnuViewHScrollBar.Text = "Sc&roll Bar"
        '
        'mnuViewToolBar
        '
        Me.mnuViewToolBar.Name = "mnuViewToolBar"
        Me.mnuViewToolBar.Size = New System.Drawing.Size(136, 22)
        Me.mnuViewToolBar.Text = "&Tool Bar"
        '
        'mnuViewStatusBar
        '
        Me.mnuViewStatusBar.CheckOnClick = True
        Me.mnuViewStatusBar.Name = "mnuViewStatusBar"
        Me.mnuViewStatusBar.Size = New System.Drawing.Size(136, 22)
        Me.mnuViewStatusBar.Text = "Sta&tus Bar"
        '
        'mnuView_0
        '
        Me.mnuView_0.Name = "mnuView_0"
        Me.mnuView_0.Size = New System.Drawing.Size(133, 6)
        '
        'mnuViewActual
        '
        Me.mnuViewActual.CheckOnClick = True
        Me.mnuViewActual.Name = "mnuViewActual"
        Me.mnuViewActual.Size = New System.Drawing.Size(136, 22)
        Me.mnuViewActual.Text = "&Actual"
        '
        'mnuViewZoom
        '
        Me.mnuViewZoom.CheckOnClick = True
        Me.mnuViewZoom.Name = "mnuViewZoom"
        Me.mnuViewZoom.Size = New System.Drawing.Size(136, 22)
        Me.mnuViewZoom.Text = "&Zoom"
        '
        'mnuViewStretch
        '
        Me.mnuViewStretch.CheckOnClick = True
        Me.mnuViewStretch.Name = "mnuViewStretch"
        Me.mnuViewStretch.Size = New System.Drawing.Size(136, 22)
        Me.mnuViewStretch.Text = "&Stretch"
        '
        'mnuView_1
        '
        Me.mnuView_1.Name = "mnuView_1"
        Me.mnuView_1.Size = New System.Drawing.Size(133, 6)
        '
        'mnuViewSort
        '
        Me.mnuViewSort.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewSortNone, Me.mnuViewSortName, Me.mnuViewSortNameNum, Me.mnuViewSortDate, Me.mnuViewSortType, Me.mnuViewSortSize, Me.mnuViewSort_0, Me.mnuViewSortAsc, Me.mnuViewSortDesc})
        Me.mnuViewSort.Name = "mnuViewSort"
        Me.mnuViewSort.Size = New System.Drawing.Size(136, 22)
        Me.mnuViewSort.Text = "Sort by"
        '
        'mnuViewSortNone
        '
        Me.mnuViewSortNone.Name = "mnuViewSortNone"
        Me.mnuViewSortNone.Size = New System.Drawing.Size(117, 22)
        Me.mnuViewSortNone.Text = "N&one"
        '
        'mnuViewSortName
        '
        Me.mnuViewSortName.Name = "mnuViewSortName"
        Me.mnuViewSortName.Size = New System.Drawing.Size(117, 22)
        Me.mnuViewSortName.Text = "&Name"
        '
        'mnuViewSortNameNum
        '
        Me.mnuViewSortNameNum.Name = "mnuViewSortNameNum"
        Me.mnuViewSortNameNum.Size = New System.Drawing.Size(117, 22)
        Me.mnuViewSortNameNum.Text = "Nat&ural"
        '
        'mnuViewSortDate
        '
        Me.mnuViewSortDate.Name = "mnuViewSortDate"
        Me.mnuViewSortDate.Size = New System.Drawing.Size(117, 22)
        Me.mnuViewSortDate.Text = "&Date"
        Me.mnuViewSortDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mnuViewSortType
        '
        Me.mnuViewSortType.Name = "mnuViewSortType"
        Me.mnuViewSortType.Size = New System.Drawing.Size(117, 22)
        Me.mnuViewSortType.Text = "&Type"
        '
        'mnuViewSortSize
        '
        Me.mnuViewSortSize.Name = "mnuViewSortSize"
        Me.mnuViewSortSize.Size = New System.Drawing.Size(117, 22)
        Me.mnuViewSortSize.Text = "&Size"
        '
        'mnuViewSort_0
        '
        Me.mnuViewSort_0.Name = "mnuViewSort_0"
        Me.mnuViewSort_0.Size = New System.Drawing.Size(114, 6)
        '
        'mnuViewSortAsc
        '
        Me.mnuViewSortAsc.Name = "mnuViewSortAsc"
        Me.mnuViewSortAsc.Size = New System.Drawing.Size(117, 22)
        Me.mnuViewSortAsc.Text = "&Asc"
        '
        'mnuViewSortDesc
        '
        Me.mnuViewSortDesc.Name = "mnuViewSortDesc"
        Me.mnuViewSortDesc.Size = New System.Drawing.Size(117, 22)
        Me.mnuViewSortDesc.Text = "D&esc"
        '
        'mnuTools
        '
        Me.mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuToolsOption})
        Me.mnuTools.Name = "mnuTools"
        Me.mnuTools.Size = New System.Drawing.Size(49, 20)
        Me.mnuTools.Text = "&Tools"
        '
        'mnuToolsOption
        '
        Me.mnuToolsOption.Name = "mnuToolsOption"
        Me.mnuToolsOption.Size = New System.Drawing.Size(124, 22)
        Me.mnuToolsOption.Text = "&Option..."
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpAbout})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(45, 20)
        Me.mnuHelp.Text = "&Help"
        '
        'mnuHelpAbout
        '
        Me.mnuHelpAbout.Name = "mnuHelpAbout"
        Me.mnuHelpAbout.Size = New System.Drawing.Size(108, 22)
        Me.mnuHelpAbout.Text = "&About"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 218)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(472, 22)
        Me.StatusStrip1.TabIndex = 1
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'HScrollBar1
        '
        Me.HScrollBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.HScrollBar1.LargeChange = 1
        Me.HScrollBar1.Location = New System.Drawing.Point(0, 24)
        Me.HScrollBar1.Maximum = 1
        Me.HScrollBar1.Minimum = 1
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New System.Drawing.Size(472, 20)
        Me.HScrollBar1.TabIndex = 3
        Me.HScrollBar1.Value = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(472, 149)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'tsToolBar
        '
        Me.tsToolBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tsToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsToolBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbPrev, Me.tsbNext, Me.ToolStripSeparator6, Me.tsbActual, Me.tsbBestfit, Me.tsbStretch, Me.ToolStripSeparator2, Me.tsbZoomIn, Me.tsbZoomOut, Me.ToolStripSeparator7, Me.tsbLRot, Me.tsbRRot, Me.ToolStripSeparator4, Me.tbsDel})
        Me.tsToolBar.Location = New System.Drawing.Point(0, 193)
        Me.tsToolBar.Name = "tsToolBar"
        Me.tsToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tsToolBar.Size = New System.Drawing.Size(472, 25)
        Me.tsToolBar.Stretch = True
        Me.tsToolBar.TabIndex = 6
        '
        'tsbPrev
        '
        Me.tsbPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPrev.Image = CType(resources.GetObject("tsbPrev.Image"), System.Drawing.Image)
        Me.tsbPrev.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPrev.Name = "tsbPrev"
        Me.tsbPrev.Size = New System.Drawing.Size(23, 22)
        Me.tsbPrev.Text = "前のイメージ"
        '
        'tsbNext
        '
        Me.tsbNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbNext.Image = CType(resources.GetObject("tsbNext.Image"), System.Drawing.Image)
        Me.tsbNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNext.Name = "tsbNext"
        Me.tsbNext.Size = New System.Drawing.Size(23, 22)
        Me.tsbNext.Text = "次のイメージ"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'tsbActual
        '
        Me.tsbActual.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbActual.Image = CType(resources.GetObject("tsbActual.Image"), System.Drawing.Image)
        Me.tsbActual.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbActual.Name = "tsbActual"
        Me.tsbActual.Size = New System.Drawing.Size(23, 22)
        Me.tsbActual.Text = "原寸大"
        '
        'tsbBestfit
        '
        Me.tsbBestfit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbBestfit.Image = CType(resources.GetObject("tsbBestfit.Image"), System.Drawing.Image)
        Me.tsbBestfit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbBestfit.Name = "tsbBestfit"
        Me.tsbBestfit.Size = New System.Drawing.Size(23, 22)
        Me.tsbBestfit.Text = "ウィンドウに収める"
        '
        'tsbStretch
        '
        Me.tsbStretch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbStretch.Image = CType(resources.GetObject("tsbStretch.Image"), System.Drawing.Image)
        Me.tsbStretch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbStretch.Name = "tsbStretch"
        Me.tsbStretch.Size = New System.Drawing.Size(23, 22)
        Me.tsbStretch.Text = "ウィンドウに合わせる"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbZoomIn
        '
        Me.tsbZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbZoomIn.Image = CType(resources.GetObject("tsbZoomIn.Image"), System.Drawing.Image)
        Me.tsbZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbZoomIn.Name = "tsbZoomIn"
        Me.tsbZoomIn.Size = New System.Drawing.Size(23, 22)
        Me.tsbZoomIn.Text = "拡大"
        '
        'tsbZoomOut
        '
        Me.tsbZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbZoomOut.Image = CType(resources.GetObject("tsbZoomOut.Image"), System.Drawing.Image)
        Me.tsbZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbZoomOut.Name = "tsbZoomOut"
        Me.tsbZoomOut.Size = New System.Drawing.Size(23, 22)
        Me.tsbZoomOut.Text = "縮小"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'tsbLRot
        '
        Me.tsbLRot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbLRot.Image = CType(resources.GetObject("tsbLRot.Image"), System.Drawing.Image)
        Me.tsbLRot.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbLRot.Name = "tsbLRot"
        Me.tsbLRot.Size = New System.Drawing.Size(23, 22)
        Me.tsbLRot.Text = "左回りに回転"
        '
        'tsbRRot
        '
        Me.tsbRRot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRRot.Image = CType(resources.GetObject("tsbRRot.Image"), System.Drawing.Image)
        Me.tsbRRot.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRRot.Name = "tsbRRot"
        Me.tsbRRot.Size = New System.Drawing.Size(23, 22)
        Me.tsbRRot.Text = "右回りに回転"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tbsDel
        '
        Me.tbsDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbsDel.Image = CType(resources.GetObject("tbsDel.Image"), System.Drawing.Image)
        Me.tbsDel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbsDel.Name = "tbsDel"
        Me.tbsDel.Size = New System.Drawing.Size(23, 22)
        Me.tbsDel.Text = "削除"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 44)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(472, 149)
        Me.Panel1.TabIndex = 7
        '
        'Form1
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 240)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tsToolBar)
        Me.Controls.Add(Me.HScrollBar1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "VIEWx"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsToolBar.ResumeLayout(False)
        Me.tsToolBar.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents mnuView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewStretch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewActual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewZoom As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HScrollBar1 As System.Windows.Forms.HScrollBar
    Friend WithEvents mnuViewStatusBar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuView_0 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFileExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mnuViewMenuBar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuToolsOption As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewHScrollBar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelpAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuView_1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuViewSort As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewSortName As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewSortNameNum As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewSortDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewSortType As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewSortSize As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewSort_0 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuViewSortAsc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewSortDesc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditCopyPath As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditCopyImage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents mnuViewSortNone As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsToolBar As ToolStrip
    Friend WithEvents tsbPrev As ToolStripButton
    Friend WithEvents tsbNext As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents tsbActual As ToolStripButton
    Friend WithEvents tsbStretch As ToolStripButton
    Friend WithEvents tsbZoomIn As ToolStripButton
    Friend WithEvents tsbZoomOut As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents tsbLRot As ToolStripButton
    Friend WithEvents tsbRRot As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tbsDel As ToolStripButton
    Friend WithEvents mnuFileDelete As ToolStripMenuItem
    Friend WithEvents tsSeparator1 As ToolStripSeparator
    Friend WithEvents Panel1 As Panel
    Friend WithEvents mnuViewToolBar As ToolStripMenuItem
    Friend WithEvents tsbBestfit As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
End Class
