Public Interface IKobetuSentakuKey
    Property PCNAMEKey() As String
    Property PGCODEKey() As String
    Property FULINOKey() As Integer
End Interface

Public Interface IKobetuSentakuResult
    Property ItemSelected() As Boolean
End Interface

Public Interface ISearchMenu(Of TResultType)
    Property ItemSelected() As Boolean
    Property SelectedItem() As TResultType
End Interface
