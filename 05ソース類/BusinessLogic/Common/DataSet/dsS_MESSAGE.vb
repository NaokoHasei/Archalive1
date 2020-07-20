Partial Class dsS_MESSAGE
    Implements IValueState

    Public ReadOnly Property HasValue() As Boolean Implements IValueState.HasValue
        Get
            If Me.S_MESSAGEView.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property
End Class