Partial Class dsM_CYUKAMOKU
    Implements IValueState

    Partial Class M_CYUKAMOKUDataTable
    End Class

    Public ReadOnly Property HasValue() As Boolean Implements IValueState.HasValue
        Get
            If Me.M_CYUKAMOKU.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property
End Class
