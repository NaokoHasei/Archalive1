Partial Class dsM_SIIRE
    Implements IValueState

    Partial Class M_SIIREDataTable
    End Class

    Public ReadOnly Property HasValue() As Boolean Implements IValueState.HasValue
        Get
            If Me.M_SIIRE.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property
End Class
