Imports System.Drawing
Imports System.IO
Imports System.Windows.Media.Imaging

Module hdp2bmp

    'Public Sub hdp2bmp(ByVal fileName As String, ByVal pictureBox As Integer)
    '    Try
    '        Dim imageStreamSource As Stream = New FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read)
    '        Dim decoder As WmpBitmapDecoder = New WmpBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default)
    '        Dim bitmapSource As BitmapSource = decoder.Frames(0)

    '        Dim imageMemoryStreamSource As New MemoryStream(1024 * 1024 * 10)
    '        Dim encoder As BmpBitmapEncoder = New BmpBitmapEncoder()

    '        encoder.Frames.Add(BitmapFrame.Create(bitmapSource))
    '        encoder.Save(imageMemoryStreamSource)

    '        If pictureBox = 1 Then
    '            FormMain.PictureBox1.Image = Image.FromStream(imageMemoryStreamSource)
    '        Else
    '            FormMain.PictureBox2.Image = Image.FromStream(imageMemoryStreamSource)
    '        End If

    '        'imageMemoryStreamSource.Close()
    '        imageMemoryStreamSource.Dispose()
    '    Catch ex As Exception
    '    End Try
    'End Sub

End Module
