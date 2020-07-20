Partial Class dsM_NOWUSER
    Implements IValueState

    Public ReadOnly Property HasValue() As Boolean Implements IValueState.HasValue
        Get
            If Me.M_NOWUSER.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property

End Class
