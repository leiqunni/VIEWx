Public Class Form2

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtKeyConf.Text = My.Settings.KeyConf
        txtTitle.Text = My.Settings.TitleText
        txtStatus.Text = My.Settings.StatusText
        txtExtension.Text = My.Settings.Extension
        chbGlass.Checked = My.Settings.Glass
        chbDirRecur.Checked = My.Settings.DirRecur
    End Sub

    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.KeyConf = txtKeyConf.Text
        My.Settings.TitleText = txtTitle.Text
        My.Settings.StatusText = txtStatus.Text
        My.Settings.Extension = txtExtension.Text
        My.Settings.Glass = chbGlass.Checked
        My.Settings.DirRecur = chbDirRecur.Checked
    End Sub

End Class