Public Class WaitCursor
    Implements System.IDisposable

    Private prevCursor As System.Windows.Forms.Cursor

    Public Sub New()
        prevCursor = System.Windows.Forms.Cursor.Current
        System.Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
    End Sub


    Private disposedValue As Boolean = False        ' 重複する呼び出しを検出するには

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: 明示的に呼び出されたときにマネージ リソースを解放します
            End If

            ' TODO: 共有のアンマネージ リソースを解放します
            System.Windows.Forms.Cursor.Current = prevCursor
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(ByVal disposing As Boolean) に記述します。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
