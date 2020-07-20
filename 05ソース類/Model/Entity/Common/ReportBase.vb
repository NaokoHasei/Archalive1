Partial Class ReportBase
    'Implements IValueState

    Enum dataTableKind
        WT_PRINTBASE_1
        S_PRISET
        S_REPORTSET
    End Enum

    Public ReadOnly Property HasValue(ByVal TableKind As dataTableKind) As Boolean
        Get
            Select Case TableKind
                Case dataTableKind.WT_PRINTBASE_1
                    If Me.WT_PRINTBASE_1.Rows.Count = 0 Then
                        Return False
                    Else
                        Return True
                    End If
                Case dataTableKind.S_REPORTSET
                    If Me.S_REPORTSET.Rows.Count = 0 Then
                        Return False
                    Else
                        Return True
                    End If
                Case dataTableKind.S_PRISET
                    If Me.S_PRISET.Rows.Count = 0 Then
                        Return False
                    Else
                        Return True
                    End If
            End Select
        End Get
    End Property

End Class

Namespace ReportBaseTableAdapters
    
    Partial Public Class S_PRISETTableAdapter
    End Class
End Namespace
