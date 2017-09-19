Imports System.IO
Imports System.Text.RegularExpressions

Partial Class Form1

    Private Sub InitWindow()
        Me.Location = My.Settings.WindowLocation
        Me.Size = My.Settings.WindowSize
        Fn_SizeMode(My.Settings.SizeMode)
        Fn_MenuBar(My.Settings.MenuBar)
        Fn_HScrollBar(My.Settings.HScrollBar)
        Fn_StatusBar(My.Settings.StatusBar)
        Fn_SetSortType(My.Settings.SortType)
        Fn_SetSortOrder(My.Settings.SortOrder)
    End Sub

    Private Sub Fn_LoadList(ByVal strs() As String)
        PicList.Clear()

        Dim isOneFile As Boolean = False
        For Each str As String In strs
            If File.Exists(str) Then
                If strs.Length = 1 Then
                    Sub_DirAddList(Path.GetDirectoryName(str))
                    isOneFile = True
                Else
                    If Regex.IsMatch(str, RegExt) Then
                        PicList.Add(New FileInfo(str))
                    End If
                End If
            ElseIf Directory.Exists(str) Then
                Sub_DirAddList(str)
            End If
        Next

        If PicList.Count = 0 Then Return

        HScrollBar1.Minimum = 0
        HScrollBar1.Value = 0

        If PicList.Count > 10 Then
            HScrollBar1.Maximum = PicList.Count - 1 + 10 - 1
            HScrollBar1.LargeChange = 10
        Else
            HScrollBar1.Maximum = PicList.Count - 1
            HScrollBar1.LargeChange = 1
        End If

        '// sort
        Fn_Sort(My.Settings.SortType, My.Settings.SortOrder)

        Dim n As Integer = 0

        If isOneFile Then
            For i As Integer = 0 To PicList.Count - 1
                If PicList(n).FullName = strs(0) Then
                    Exit For
                End If
                n = i
            Next
        End If

        HScrollBar1.Value = n
        Fn_PicLoad(n)
    End Sub

    Private Sub Sub_DirAddList(ByVal dir As String)
        Dim d As New DirectoryInfo(dir)
        If My.Settings.DirRecur Then
            For Each di As DirectoryInfo In d.GetDirectories
                Sub_DirAddList(di.FullName)
            Next
        End If
        For Each fi As FileInfo In d.GetFiles
            If Regex.IsMatch(fi.Extension, RegExt) Then
                PicList.Add(fi)
            End If
        Next
    End Sub

    Private Sub Control_Centered(ByRef rec As Rectangle)
        rec.X = (Panel1.Width - rec.Width) / 2
        rec.Y = (Panel1.Height - rec.Height) / 2
    End Sub

    Private Sub Fn_PicLoad(ByVal n As Integer)
        Try
            Dim buffer() = File.ReadAllBytes(PicList(n).FullName)
            Dim stream As MemoryStream = New MemoryStream(buffer)
            PictureBox1.Image = Image.FromStream(stream)
        Catch ex As Exception
            lblStatus.Text = ex.ToString
        End Try

        If PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize Then
            Control_Centered(PictureBox1.Bounds)
        End If

        Me.Text = Fn_FormatText(My.Settings.TitleText)
        If StatusStrip1.Visible Then
            lblStatus.Text = Fn_FormatText(My.Settings.StatusText)
        End If
    End Sub

    Private Sub Fn_Prev(Optional ByVal n As Integer = 1)
        If HScrollBar1.Value - n >= 0 Then
            HScrollBar1.Value -= n
        Else
            HScrollBar1.Value = PicList.Count - 1
        End If
    End Sub

    Private Sub Fn_Next(Optional ByVal n As Integer = 1)
        If HScrollBar1.Value + n <= PicList.Count - 1 Then
            HScrollBar1.Value += n
        Else
            HScrollBar1.Value = 0
        End If
    End Sub

    Private Sub Fn_OpenFileDialog()
        Dim sb As New System.Text.StringBuilder
        For Each item As String In My.Settings.Extension.Split(" ".ToCharArray, StringSplitOptions.RemoveEmptyEntries)
            sb.Append("*." & item.Trim & ";")
        Next
        OpenFileDialog1.Filter = "All Picture Files|" & sb.ToString & "|" & "All Files|*.*"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Fn_LoadList(OpenFileDialog1.FileNames)
        End If
    End Sub

    Private Sub Fn_SizeMode(ByVal v As PictureBoxSizeMode)
        PictureBox1.SizeMode = v
        Select Case v
            Case PictureBoxSizeMode.AutoSize
                PictureBox1.Dock = DockStyle.None
                Control_Centered(PictureBox1.Bounds)
            Case PictureBoxSizeMode.StretchImage, PictureBoxSizeMode.Zoom
                PictureBox1.Dock = DockStyle.Fill
        End Select
        mnuViewStretch.Checked = (v = PictureBoxSizeMode.StretchImage)
        mnuViewActual.Checked = (v = PictureBoxSizeMode.AutoSize)
        mnuViewZoom.Checked = (v = PictureBoxSizeMode.Zoom)
    End Sub

    Private Sub Fn_MenuBar(ByVal v As Boolean)
        MenuStrip1.Visible = v
        mnuViewMenuBar.Checked = v
        My.Settings.MenuBar = v
    End Sub

    Private Sub Fn_HScrollBar(ByVal v As Boolean)
        HScrollBar1.Visible = v
        mnuViewHScrollBar.Checked = v
        My.Settings.HScrollBar = v
    End Sub

    Private Sub Fn_StatusBar(ByVal v As Boolean)
        StatusStrip1.Visible = v
        mnuViewStatusBar.Checked = v
        My.Settings.StatusBar = v
    End Sub

    Private Function Fn_FormatText(ByVal s As String) As String
        If PictureBox1.Image Is Nothing Then Return ""

        s = s.Replace("%name%", PicList(HScrollBar1.Value).Name)
        s = s.Replace("%current%", HScrollBar1.Value + 1)
        s = s.Replace("%count%", PicList.Count)
        s = s.Replace("%width%", PictureBox1.Image.Size.Width)
        s = s.Replace("%height%", PictureBox1.Image.Size.Height)
        s = s.Replace("%modefied%", PicList(HScrollBar1.Value).LastWriteTime.ToString)
        s = s.Replace("%length_ki%", Math.Floor(PicList(HScrollBar1.Value).Length / 1024))
        Return s
    End Function

    'Private Sub Fn_Zoom(ByVal value As Double, Optional ByVal reset As Boolean = False)
    '    If reset Then
    '    Else
    '    End If
    'End Sub

    Private Sub Fn_NormalZoon()
        If PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize Then
            Fn_SizeMode(PictureBoxSizeMode.Zoom)
        Else
            Fn_SizeMode(PictureBoxSizeMode.AutoSize)
        End If
    End Sub

    Private Sub Fn_LoadKeyConf()
        'KeyConf.Clear()
        For Each line As String In My.Settings.KeyConf.Split(vbCrLf)
            If line.StartsWith("#") Then Continue For
            Dim param() As String = line.Split(" ".ToCharArray, 3, StringSplitOptions.RemoveEmptyEntries)
            Dim key As String = String.Format("{0:0}{1:000}", param(0).Trim, param(1).Trim)
            If param.Length = 3 Then
                KeyConf.Add(key, param(2).ToLower.Trim)
            End If
        Next
    End Sub

End Class
