Imports System.IO

Partial Class FormMain

    '// 画像表示
    Public Sub Fn_LoadImage(ByVal fn As String, ByVal pic As PictureBox)
        '// HD Photoの表示
        Try
            If fn.ToLower.EndsWith(".wdp") Or fn.ToLower.EndsWith(".hdp") Then
                'hdp2bmp.hdp2bmp(fileName, 1)
            Else
                pic.Image = System.Drawing.Image.FromStream(New FileStream(fn, FileMode.Open, FileAccess.Read))
            End If

            If mnuViewActual.Checked Then
                pic.Width = pic.Image.Width
                pic.Height = pic.Image.Height
                pic.Left = (pic.Parent.Width - pic.Width) / 2
                pic.Top = (pic.Parent.Height - pic.Height) / 2
            End If
        Catch ex As Exception
            pic.Image = pic.ErrorImage
        End Try

        '// [ウィンドウに収める]の処理
        If mnuViewInWindow.Checked Then mnuViewInWindow_Click(Nothing, Nothing)

        '// 画像によってアイコン変更
        If pic.Image.RawFormat.ToString.ToUpper.Contains("B96B3CAB") Then Me.Icon = My.Resources._1602
        If pic.Image.RawFormat.ToString.ToUpper.Contains("B96B3CB0") Then Me.Icon = My.Resources._1603
        If pic.Image.RawFormat.ToString.ToUpper.Contains("B96B3CAE") Then Me.Icon = My.Resources._1604
        If pic.Image.RawFormat.ToString.ToUpper.Contains("B96B3CAF") Then Me.Icon = My.Resources._1605
        If fn.ToLower.EndsWith(".wdp") Or fn.ToLower.EndsWith(".hdp") Then Me.Icon = My.Resources._1606

        '// タイトルバーにファイル名表示
        Me.Text = Path.GetFileName(fn) & " [" & HScrollBar.Value + 1 & "/" & fileEntries.Count & "] - " & appName
        'Me.Text = fileName & " [" & HScrollBar1.Value + 1 & "/" & fileEntries.Count & "] - " & appName

        '// ステータスバーが表示されてるなら情報表示。
        If tsStatusBar.Visible Then
            Dim fi As New IO.FileInfo(fn)
            ToolStripStatusLabel1.Text = "大きさ: " & pic.Image.Width & " x " & pic.Image.Height & " サイズ: " & (fi.Length / 1024).ToString("#,##0") & " KB"
        End If
    End Sub















    Private Sub Fn_HScrollbar(ByVal value As Boolean)
        tsStatusBar.Visible = value
        mnuViewHScrollBar.Checked = value
    End Sub

    Private Sub Fn_StatusBar(ByVal value As Boolean)
        tsStatusBar.Visible = value
        mnuViewStatusBar.Checked = value
    End Sub

    Private Sub Fn_Bestfit()
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.Dock = DockStyle.Fill

        mnuViewBestfit.Checked = True '// ウィンドウに合わせる
        mnuViewInWindow.Checked = False '// ウィンドウに収める
        mnuViewActual.Checked = False '// 原寸大
        tsbBestfit.Enabled = False '// ウィンドウに合わせる
        tsbInWindow.Enabled = True '// ウィンドウに収める
        tsbActual.Enabled = True '// 原寸大
    End Sub

    Private Sub Fn_Actual()
        Fn_Actual(PictureBox1)

        mnuViewBestfit.Checked = False '// ウィンドウに合わせる
        mnuViewInWindow.Checked = False '// ウィンドウに収める
        mnuViewActual.Checked = True '// 原寸大
        tsbBestfit.Enabled = True '// ウィンドウに合わせる
        tsbInWindow.Enabled = True '// ウィンドウに収める
        tsbActual.Enabled = False '// 原寸大
    End Sub

    Private Sub Fn_Actual(ByVal pic As PictureBox)
        pic.SizeMode = PictureBoxSizeMode.CenterImage
        pic.Dock = DockStyle.None

        Try
            pic.Width = pic.Image.Width
            pic.Height = pic.Image.Height
        Catch ex As Exception
            pic.Width = pic.Parent.Width 'SplitContainer1.Panel1.Width
            pic.Height = pic.Parent.Height 'SplitContainer1.Panel1.Height
        End Try

        pic.Left = (pic.Parent.Width - pic.Width) / 2
        pic.Top = (pic.Parent.Height - pic.Height) / 2
    End Sub

    Private Sub Fn_RotateLeft()
        PictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
        PictureBox1.Refresh()
    End Sub

    Private Sub Fn_RotateRight()
        PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        PictureBox1.Refresh()
    End Sub

End Class
