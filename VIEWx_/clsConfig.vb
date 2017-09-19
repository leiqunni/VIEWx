<Serializable()> _
Public Class clsConfig
    Public Top, Left, Width, Height As Integer
    Public SizeMode As PictureBoxSizeMode
    Public mnuViewHScrollBar, mnuViewToolBar, mnuViewStatusBar, mnuViewSpread, mnuViewSpreadRight, mnuViewSpreadLeft As Boolean
    Public mnuViewOrderName, mnuViewOrderNameNum, mnuViewOrderDate, mnuViewOrderType, mnuViewOrderSize As Boolean
    Public mnuViewOrderAsc, mnuViewOrderDesc As Boolean
    Public keyConfig As New Hashtable
    Public lastUpdateCheckDateTime As DateTime
    Public doUpdateCheck As Boolean
    Public slideShowInterval As Integer
End Class