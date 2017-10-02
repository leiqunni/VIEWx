Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text =
        "name " & My.Application.Info.Title & vbCrLf &
        "version " & My.Application.Info.Version.ToString() & vbCrLf &
        "author " & My.Application.Info.CompanyName & vbCrLf &
        vbCrLf &
        "contact to leiqunni at yahoo.co.jp"
    End Sub
End Class