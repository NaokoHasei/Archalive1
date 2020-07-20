Imports System.Windows.Forms

Public Class FlatTabIndex

    Private TabIndices As Dictionary(Of Control, Integer)

    Private Function SortByTabOrder(ByVal l As Control, ByVal r As Control) As Integer
        If l.TabIndex < r.TabIndex Then
            Return -1
        End If
        If l.TabIndex > r.TabIndex Then
            Return 1
        End If
        Return 0
    End Function

    Private Function MakeList(ByVal parentControl As Control, ByVal index As Integer) As Integer
        Dim controlList As List(Of Control) = New List(Of Control)

        For Each c As Control In parentControl.Controls
            controlList.Add(c)
        Next

        controlList.Sort(AddressOf SortByTabOrder)


        For Each c As Control In controlList
            index += 1
            TabIndices.Add(c, index)

            index = MakeList(c, index)
        Next

        Return index

    End Function

    Public Sub New(ByVal parentControl As Control)
        TabIndices = New Dictionary(Of Control, Integer)

        TabIndices.Add(parentControl, 0)
        MakeList(parentControl, 1)
    End Sub

    Public Function GetTabIndex(ByVal control As Control) As Integer
        Return TabIndices(control)
    End Function

End Class
