Partial Class dsS_SCB
    Implements IValueState

    Partial Class S_SCB＿DataTable
    End Class

    Public ReadOnly Property HasValue() As Boolean Implements IValueState.HasValue
        Get
            If Me.S_SCB.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property
End Class
