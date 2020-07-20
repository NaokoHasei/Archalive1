Partial Class dsS_SYSTEM
    Implements IValueState

    Partial Class S_SYSTEMViewDataTable

        Private Sub S_SYSTEMView_DataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            'If (e.Column.ColumnName = Me.SECTIONNAMEINFOColumn.ColumnName) Then
            '    'ユーザー コードをここに追加してください
            'End If

        End Sub

    End Class

    Public ReadOnly Property HasValue() As Boolean Implements IValueState.HasValue
        Get
            If Me.S_SYSTEMView.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property
End Class
