<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.tsToolBar = New System.Windows.Forms.ToolStrip()
        Me.tsbPrev = New System.Windows.Forms.ToolStripButton()
        Me.tsbNext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbActual = New System.Windows.Forms.ToolStripButton()
        Me.tsbBestfit = New System.Windows.Forms.ToolStripButton()
        Me.tsbInWindow = New System.Windows.Forms.ToolStripButton()
        Me.tsbSlideShow = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbZoomIn = New System.Windows.Forms.ToolStripButton()
        Me.tsbZoomOut = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbLRot = New System.Windows.Forms.ToolStripButton()
        Me.tsbRRot = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbsDel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbHelp = New System.Windows.Forms.ToolStripButton()
        Me.tsStatusBar = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsHScroolBar = New System.Windows.Forms.ToolStrip()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFile_0 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileSlideShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFile_1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFile_2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewHScrollBar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewToolBar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewStatusBar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewBestfit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewInWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewActual = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewSpread = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewSpreadRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewSpreadLeft = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewOrder = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewOrderName = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewOrderNameNum = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewOrderDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewOrderType = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewOrderSize = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewOrderAsc = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewOrderDesc = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewFullScreen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuToolsOption = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuHelpCheckUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrev = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNext = New System.Windows.Forms.ToolStripMenuItem()
        Me.HScrollBar = New System.Windows.Forms.HScrollBar()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.tsToolBar.SuspendLayout()
        Me.tsStatusBar.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Window
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(340, 134)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.tsToolBar)
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.tsStatusBar)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.PictureBox1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(340, 134)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        '
        'ToolStripContainer1.LeftToolStripPanel
        '
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 40)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(390, 231)
        Me.ToolStripContainer1.TabIndex = 7
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.tsHScroolBar)
        '
        'tsToolBar
        '
        Me.tsToolBar.Dock = System.Windows.Forms.DockStyle.None
        Me.tsToolBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbPrev, Me.tsbNext, Me.ToolStripSeparator6, Me.tsbActual, Me.tsbBestfit, Me.tsbInWindow, Me.tsbSlideShow, Me.ToolStripSeparator3, Me.tsbZoomIn, Me.tsbZoomOut, Me.ToolStripSeparator7, Me.tsbLRot, Me.tsbRRot, Me.ToolStripSeparator4, Me.tbsDel, Me.ToolStripSeparator5, Me.tsbHelp})
        Me.tsToolBar.Location = New System.Drawing.Point(0, 25)
        Me.tsToolBar.Name = "tsToolBar"
        Me.tsToolBar.Size = New System.Drawing.Size(390, 25)
        Me.tsToolBar.Stretch = True
        Me.tsToolBar.TabIndex = 0
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
        Me.tsbBestfit.Text = "ウィンドウに合わせる"
        '
        'tsbInWindow
        '
        Me.tsbInWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbInWindow.Image = CType(resources.GetObject("tsbInWindow.Image"), System.Drawing.Image)
        Me.tsbInWindow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbInWindow.Name = "tsbInWindow"
        Me.tsbInWindow.Size = New System.Drawing.Size(23, 22)
        Me.tsbInWindow.Text = "ウィンドウに収める"
        '
        'tsbSlideShow
        '
        Me.tsbSlideShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSlideShow.Image = CType(resources.GetObject("tsbSlideShow.Image"), System.Drawing.Image)
        Me.tsbSlideShow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSlideShow.Name = "tsbSlideShow"
        Me.tsbSlideShow.Size = New System.Drawing.Size(23, 22)
        Me.tsbSlideShow.Text = "ToolStripButton1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'tsbHelp
        '
        Me.tsbHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbHelp.Image = CType(resources.GetObject("tsbHelp.Image"), System.Drawing.Image)
        Me.tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbHelp.Name = "tsbHelp"
        Me.tsbHelp.Size = New System.Drawing.Size(23, 22)
        Me.tsbHelp.Text = "ヘルプ"
        '
        'tsStatusBar
        '
        Me.tsStatusBar.Dock = System.Windows.Forms.DockStyle.None
        Me.tsStatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.tsStatusBar.Location = New System.Drawing.Point(0, 50)
        Me.tsStatusBar.Name = "tsStatusBar"
        Me.tsStatusBar.Size = New System.Drawing.Size(390, 22)
        Me.tsStatusBar.TabIndex = 7
        Me.tsStatusBar.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'tsHScroolBar
        '
        Me.tsHScroolBar.Dock = System.Windows.Forms.DockStyle.None
        Me.tsHScroolBar.Location = New System.Drawing.Point(3, 0)
        Me.tsHScroolBar.Name = "tsHScroolBar"
        Me.tsHScroolBar.Size = New System.Drawing.Size(43, 25)
        Me.tsHScroolBar.Stretch = True
        Me.tsHScroolBar.TabIndex = 0
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuEdit, Me.mnuView, Me.mnuTools, Me.mnuHelp, Me.mnuPrev, Me.mnuNext})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(390, 24)
        Me.MenuStrip.TabIndex = 1
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileOpen, Me.mnuFile_0, Me.mnuFileSlideShow, Me.mnuFile_1, Me.mnuFileDelete, Me.mnuFile_2, Me.mnuFileExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(66, 20)
        Me.mnuFile.Text = "ファイル(&F)"
        '
        'mnuFileOpen
        '
        Me.mnuFileOpen.Name = "mnuFileOpen"
        Me.mnuFileOpen.Size = New System.Drawing.Size(170, 22)
        Me.mnuFileOpen.Text = "開く(&O)..."
        '
        'mnuFile_0
        '
        Me.mnuFile_0.Name = "mnuFile_0"
        Me.mnuFile_0.Size = New System.Drawing.Size(167, 6)
        '
        'mnuFileSlideShow
        '
        Me.mnuFileSlideShow.Name = "mnuFileSlideShow"
        Me.mnuFileSlideShow.Size = New System.Drawing.Size(170, 22)
        Me.mnuFileSlideShow.Text = "スライド ショーの開始"
        '
        'mnuFile_1
        '
        Me.mnuFile_1.Name = "mnuFile_1"
        Me.mnuFile_1.Size = New System.Drawing.Size(167, 6)
        '
        'mnuFileDelete
        '
        Me.mnuFileDelete.Name = "mnuFileDelete"
        Me.mnuFileDelete.Size = New System.Drawing.Size(170, 22)
        Me.mnuFileDelete.Text = "削除(&D)"
        '
        'mnuFile_2
        '
        Me.mnuFile_2.Name = "mnuFile_2"
        Me.mnuFile_2.Size = New System.Drawing.Size(167, 6)
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Name = "mnuFileExit"
        Me.mnuFileExit.Size = New System.Drawing.Size(170, 22)
        Me.mnuFileExit.Text = "終了(&X)"
        '
        'mnuEdit
        '
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(57, 20)
        Me.mnuEdit.Text = "編集(&E)"
        '
        'mnuView
        '
        Me.mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewHScrollBar, Me.mnuViewToolBar, Me.mnuViewStatusBar, Me.ToolStripSeparator1, Me.mnuViewBestfit, Me.mnuViewInWindow, Me.mnuViewActual, Me.ToolStripSeparator9, Me.mnuViewSpread, Me.mnuViewOrder, Me.mnuViewFullScreen})
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Size = New System.Drawing.Size(58, 20)
        Me.mnuView.Text = "表示(&V)"
        '
        'mnuViewHScrollBar
        '
        Me.mnuViewHScrollBar.Name = "mnuViewHScrollBar"
        Me.mnuViewHScrollBar.Size = New System.Drawing.Size(180, 22)
        Me.mnuViewHScrollBar.Text = "スクロール バー(&R)"
        '
        'mnuViewToolBar
        '
        Me.mnuViewToolBar.Name = "mnuViewToolBar"
        Me.mnuViewToolBar.Size = New System.Drawing.Size(180, 22)
        Me.mnuViewToolBar.Text = "ツール バー(&T)"
        '
        'mnuViewStatusBar
        '
        Me.mnuViewStatusBar.Name = "mnuViewStatusBar"
        Me.mnuViewStatusBar.Size = New System.Drawing.Size(180, 22)
        Me.mnuViewStatusBar.Text = "ステータス バー(&S)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(177, 6)
        '
        'mnuViewBestfit
        '
        Me.mnuViewBestfit.Name = "mnuViewBestfit"
        Me.mnuViewBestfit.Size = New System.Drawing.Size(180, 22)
        Me.mnuViewBestfit.Text = "ウィンドウに合わせる(&B)"
        '
        'mnuViewInWindow
        '
        Me.mnuViewInWindow.Name = "mnuViewInWindow"
        Me.mnuViewInWindow.Size = New System.Drawing.Size(180, 22)
        Me.mnuViewInWindow.Text = "ウィンドウに収める(&I)"
        '
        'mnuViewActual
        '
        Me.mnuViewActual.Name = "mnuViewActual"
        Me.mnuViewActual.Size = New System.Drawing.Size(180, 22)
        Me.mnuViewActual.Text = "原寸大(&A)"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(177, 6)
        '
        'mnuViewSpread
        '
        Me.mnuViewSpread.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewSpreadRight, Me.mnuViewSpreadLeft})
        Me.mnuViewSpread.Name = "mnuViewSpread"
        Me.mnuViewSpread.Size = New System.Drawing.Size(180, 22)
        Me.mnuViewSpread.Text = "見開き表示(&S)"
        '
        'mnuViewSpreadRight
        '
        Me.mnuViewSpreadRight.Name = "mnuViewSpreadRight"
        Me.mnuViewSpreadRight.Size = New System.Drawing.Size(107, 22)
        Me.mnuViewSpreadRight.Text = "右開き"
        '
        'mnuViewSpreadLeft
        '
        Me.mnuViewSpreadLeft.Name = "mnuViewSpreadLeft"
        Me.mnuViewSpreadLeft.Size = New System.Drawing.Size(107, 22)
        Me.mnuViewSpreadLeft.Text = "左開き"
        '
        'mnuViewOrder
        '
        Me.mnuViewOrder.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewOrderName, Me.mnuViewOrderNameNum, Me.mnuViewOrderDate, Me.mnuViewOrderType, Me.mnuViewOrderSize, Me.ToolStripSeparator2, Me.mnuViewOrderAsc, Me.mnuViewOrderDesc})
        Me.mnuViewOrder.Name = "mnuViewOrder"
        Me.mnuViewOrder.Size = New System.Drawing.Size(180, 22)
        Me.mnuViewOrder.Text = "並べ替え(&O)"
        '
        'mnuViewOrderName
        '
        Me.mnuViewOrderName.Name = "mnuViewOrderName"
        Me.mnuViewOrderName.Size = New System.Drawing.Size(158, 22)
        Me.mnuViewOrderName.Text = "名前"
        '
        'mnuViewOrderNameNum
        '
        Me.mnuViewOrderNameNum.Name = "mnuViewOrderNameNum"
        Me.mnuViewOrderNameNum.Size = New System.Drawing.Size(158, 22)
        Me.mnuViewOrderNameNum.Text = "名前（数字順）"
        '
        'mnuViewOrderDate
        '
        Me.mnuViewOrderDate.Enabled = False
        Me.mnuViewOrderDate.Name = "mnuViewOrderDate"
        Me.mnuViewOrderDate.Size = New System.Drawing.Size(158, 22)
        Me.mnuViewOrderDate.Text = "更新日時"
        '
        'mnuViewOrderType
        '
        Me.mnuViewOrderType.Name = "mnuViewOrderType"
        Me.mnuViewOrderType.Size = New System.Drawing.Size(158, 22)
        Me.mnuViewOrderType.Text = "種類"
        '
        'mnuViewOrderSize
        '
        Me.mnuViewOrderSize.Enabled = False
        Me.mnuViewOrderSize.Name = "mnuViewOrderSize"
        Me.mnuViewOrderSize.Size = New System.Drawing.Size(158, 22)
        Me.mnuViewOrderSize.Text = "サイズ"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(155, 6)
        '
        'mnuViewOrderAsc
        '
        Me.mnuViewOrderAsc.Name = "mnuViewOrderAsc"
        Me.mnuViewOrderAsc.Size = New System.Drawing.Size(158, 22)
        Me.mnuViewOrderAsc.Text = "昇順(&A)"
        '
        'mnuViewOrderDesc
        '
        Me.mnuViewOrderDesc.Name = "mnuViewOrderDesc"
        Me.mnuViewOrderDesc.Size = New System.Drawing.Size(158, 22)
        Me.mnuViewOrderDesc.Text = "降順(&D)"
        '
        'mnuViewFullScreen
        '
        Me.mnuViewFullScreen.Name = "mnuViewFullScreen"
        Me.mnuViewFullScreen.ShortcutKeyDisplayString = "F11"
        Me.mnuViewFullScreen.ShortcutKeys = System.Windows.Forms.Keys.F11
        Me.mnuViewFullScreen.Size = New System.Drawing.Size(180, 22)
        Me.mnuViewFullScreen.Text = "全画面表示(&F)"
        '
        'mnuTools
        '
        Me.mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuToolsOption})
        Me.mnuTools.Name = "mnuTools"
        Me.mnuTools.Size = New System.Drawing.Size(60, 20)
        Me.mnuTools.Text = "ツール(&T)"
        '
        'mnuToolsOption
        '
        Me.mnuToolsOption.Name = "mnuToolsOption"
        Me.mnuToolsOption.Size = New System.Drawing.Size(134, 22)
        Me.mnuToolsOption.Text = "オプション(&O)"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpHelp, Me.ToolStripSeparator11, Me.mnuHelpCheckUpdate, Me.mnuHelpAbout})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(65, 20)
        Me.mnuHelp.Text = "ヘルプ(&H)"
        '
        'mnuHelpHelp
        '
        Me.mnuHelpHelp.Name = "mnuHelpHelp"
        Me.mnuHelpHelp.Size = New System.Drawing.Size(158, 22)
        Me.mnuHelpHelp.Text = "ヘルプ(&H)"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(155, 6)
        '
        'mnuHelpCheckUpdate
        '
        Me.mnuHelpCheckUpdate.Name = "mnuHelpCheckUpdate"
        Me.mnuHelpCheckUpdate.Size = New System.Drawing.Size(158, 22)
        Me.mnuHelpCheckUpdate.Text = "最新版をチェック"
        '
        'mnuHelpAbout
        '
        Me.mnuHelpAbout.Name = "mnuHelpAbout"
        Me.mnuHelpAbout.Size = New System.Drawing.Size(158, 22)
        Me.mnuHelpAbout.Text = "バージョン情報(&A)"
        '
        'mnuPrev
        '
        Me.mnuPrev.Name = "mnuPrev"
        Me.mnuPrev.Size = New System.Drawing.Size(56, 20)
        Me.mnuPrev.Text = "前へ(&P)"
        '
        'mnuNext
        '
        Me.mnuNext.Name = "mnuNext"
        Me.mnuNext.Size = New System.Drawing.Size(58, 20)
        Me.mnuNext.Text = "次へ(&N)"
        '
        'HScrollBar
        '
        Me.HScrollBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.HScrollBar.Location = New System.Drawing.Point(0, 24)
        Me.HScrollBar.Maximum = 9
        Me.HScrollBar.Name = "HScrollBar"
        Me.HScrollBar.Size = New System.Drawing.Size(390, 16)
        Me.HScrollBar.TabIndex = 8
        '
        'FormMain
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(390, 271)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Controls.Add(Me.HScrollBar)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "VIEWx"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.tsToolBar.ResumeLayout(False)
        Me.tsToolBar.PerformLayout()
        Me.tsStatusBar.ResumeLayout(False)
        Me.tsStatusBar.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewBestfit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewActual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrev As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNext As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelpHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelpAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewSpread As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewFullScreen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents mnuViewHScrollBar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewSpreadRight As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewSpreadLeft As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewOrder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewOrderName As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewOrderSize As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewOrderType As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewOrderDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuViewOrderAsc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewOrderDesc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewOrderNameNum As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuToolsOption As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents mnuViewStatusBar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelpCheckUpdate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents tsToolBar As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuViewToolBar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbBestfit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbActual As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbZoomIn As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbZoomOut As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbHelp As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbRRot As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbLRot As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuViewInWindow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbsDel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFileDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFile_2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbInWindow As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFile_0 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFileSlideShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFile_1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents tsbSlideShow As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsStatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents HScrollBar As HScrollBar
    Friend WithEvents tsHScroolBar As ToolStrip
End Class
