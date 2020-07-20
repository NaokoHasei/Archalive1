Partial Class dsM_KBN
    Implements IValueState

    Partial Class M_KBNDataTable
    End Class

    Public ReadOnly Property HasValue() As Boolean Implements IValueState.HasValue
        Get
            If Me.M_KBN.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property
End Class
