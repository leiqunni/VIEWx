Partial Class Form1

    'Declare Unicode Function StrCmpLogicalW Lib "shlwapi.dll" (ByVal s1 As String, ByVal s2 As String) As Int32

    Enum SortType
        [None]
        [Name]
        [NameNum]
        [Date]
        [Type]
        [Size]
    End Enum

    Private Sub Fn_Sort(ByVal st As SortType, ByVal so As SortOrder)
        Fn_SetSortType(st)
        Fn_SetSortOrder(so)

        If PicList.Count = 0 Then Return
        If st = SortType.None Then Return

        Select Case st
            Case SortType.Name
                PicList.Sort(New OrderByName(My.Settings.SortOrder))
            Case SortType.NameNum
                PicList.Sort(New OrderByNameNum(My.Settings.SortOrder))
            Case SortType.Date
                PicList.Sort(New OrderByDate(My.Settings.SortOrder))
            Case SortType.Type
                PicList.Sort(New OrderByType(My.Settings.SortOrder))
            Case SortType.Size
                PicList.Sort(New OrderBySize(My.Settings.SortOrder))
        End Select
    End Sub

    Private Sub Fn_SetSortType(ByVal st As SortType)
        My.Settings.SortType = st
        mnuViewSortNone.Checked = (st = SortType.None)
        mnuViewSortName.Checked = (st = SortType.Name)
        mnuViewSortNameNum.Checked = (st = SortType.NameNum)
        mnuViewSortDate.Checked = (st = SortType.Date)
        mnuViewSortType.Checked = (st = SortType.Type)
        mnuViewSortSize.Checked = (st = SortType.Size)
    End Sub

    Private Sub Fn_SetSortOrder(ByVal so As SortOrder)
        My.Settings.SortOrder = so
        mnuViewSortAsc.Checked = (so = SortOrder.Ascending)
        mnuViewSortDesc.Checked = (so = SortOrder.Descending)
    End Sub

#Region "--- Sort Class"

    Public Class OrderByName
        Implements System.Collections.Generic.IComparer(Of IO.FileInfo)
        Private order As Integer
        Public Sub New(ByVal so As SortOrder)
            order = If(so = SortOrder.Ascending, 1, -1)
        End Sub
        Public Function Compare(ByVal x As IO.FileInfo, ByVal y As IO.FileInfo) As Integer _
            Implements System.Collections.Generic.IComparer(Of IO.FileInfo).Compare
            Return String.Compare(x.FullName, y.FullName) * order
        End Function
    End Class

    Public Class OrderByNameNum
        Implements System.Collections.Generic.IComparer(Of IO.FileInfo)
        Private order As Integer
        <System.Runtime.InteropServices.DllImport("shlwapi.dll", CharSet:=System.Runtime.InteropServices.CharSet.Unicode, ExactSpelling:=True)>
        Private Shared Function StrCmpLogicalW(x As String, y As String) As Integer
        End Function
        Public Sub New(ByVal so As SortOrder)
            order = If(so = SortOrder.Ascending, 1, -1)
        End Sub
        Public Function Compare(ByVal x As IO.FileInfo, ByVal y As IO.FileInfo) As Integer _
            Implements System.Collections.Generic.IComparer(Of IO.FileInfo).Compare
            Return StrCmpLogicalW(x.FullName, y.FullName)
        End Function
    End Class

    Public Class OrderByDate
        Implements System.Collections.Generic.IComparer(Of IO.FileInfo)
        Private order As Integer
        Public Sub New(ByVal so As SortOrder)
            order = If(so = SortOrder.Ascending, 1, -1)
        End Sub
        Public Function Compare(ByVal x As IO.FileInfo, ByVal y As IO.FileInfo) As Integer _
            Implements System.Collections.Generic.IComparer(Of IO.FileInfo).Compare
            Return DateTime.Compare(x.LastWriteTime, y.LastWriteTime)
        End Function
    End Class

    Public Class OrderByType
        Implements System.Collections.Generic.IComparer(Of IO.FileInfo)
        Private order As Integer
        Public Sub New(ByVal so As SortOrder)
            order = If(so = SortOrder.Ascending, 1, -1)
        End Sub
        Public Function Compare(ByVal x As IO.FileInfo, ByVal y As IO.FileInfo) As Integer _
            Implements System.Collections.Generic.IComparer(Of IO.FileInfo).Compare
            Return String.Compare(x.Extension, y.Extension)
        End Function
    End Class

    Public Class OrderBySize
        Implements System.Collections.Generic.IComparer(Of IO.FileInfo)
        Private order As Integer
        Public Sub New(ByVal so As SortOrder)
            order = If(so = SortOrder.Ascending, 1, -1)
        End Sub

        Public Function Compare(ByVal x As IO.FileInfo, ByVal y As IO.FileInfo) As Integer _
            Implements System.Collections.Generic.IComparer(Of IO.FileInfo).Compare
            Return x.Length - y.Length
        End Function
    End Class

#End Region

End Class
