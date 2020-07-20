Partial Class dsM_SYOKAMOKU
    Implements IValueState

    Partial Class M_SYOKAMOKUDataTable
    End Class

    Public ReadOnly Property HasValue() As Boolean Implements IValueState.HasValue
        Get
            If Me.M_SYOKAMOKU.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property
End Class

Namespace dsM_SYOKAMOKUTableAdapters
    
    Partial Public Class M_SYOKAMOKUTableAdapter
    End Class
End Namespace
