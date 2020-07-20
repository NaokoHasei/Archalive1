

Partial Public Class dsSEI0001

    Partial Class ReportDataDataTable

        Private Sub ReportDataDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.TokuiNameColumn.ColumnName) Then
                'ユーザー コードをここに追加してください
            End If

        End Sub

    End Class

End Class

Namespace dsSEI0001TableAdapters
    Partial Public Class S_SCBTableAdapter
    End Class
End Namespace
