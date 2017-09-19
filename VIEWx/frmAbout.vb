Public Class frmAbout
 
    Private Sub dlgAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = appName & " について"

        PictureBox1.Image = My.Resources._1600.ToBitmap
        PictureBox2.Image = My.Resources._1601.ToBitmap
        PictureBox3.Image = My.Resources._1602.ToBitmap
        PictureBox4.Image = My.Resources._1603.ToBitmap
        PictureBox5.Image = My.Resources._1604.ToBitmap
        PictureBox6.Image = My.Resources._1605.ToBitmap
        PictureBox7.Image = My.Resources._1606.ToBitmap

        Label1.Text = appName & " release " & appRelease & " " & appReleaseDate & " by " & appAuthor
        Label2.Text = "最後にアップデートを確認した日時: " & lastUpdateCheckDateTime
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        LinkLabel1.LinkVisited = True
        System.Diagnostics.Process.Start("http://www.geocities.co.jp/SiliconValley/7773/etc/viewx.html")
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        LinkLabel2.LinkVisited = True
        System.Diagnostics.Process.Start("http://www.mayosoft.net")
    End Sub

End Class
