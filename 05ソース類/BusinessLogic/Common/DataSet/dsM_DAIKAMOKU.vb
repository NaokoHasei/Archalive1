Partial Class dsM_DAIKAMOKU
    Implements IValueState

    Partial Class M_DAIKAMOKUDataTable
    End Class

    Public ReadOnly Property HasValue() As Boolean Implements IValueState.HasValue
        Get
            If Me.M_DAIKAMOKU.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property
End Class

Namespace dsM_DAIKAMOKUTableAdapters
    
    Partial Public Class M_DAIKAMOKUTableAdapter
    End Class
End Namespace
