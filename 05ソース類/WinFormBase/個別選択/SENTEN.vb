Public Class SENTEN

    Public Overrides Function PROGRAM_ID() As String
        Return "SENTEN"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "店舗選択"
    End Function

    Protected Overrides Function WorkLoadMethod() As BLL.Common.IBusinessLogic
        Return New BLL.SEN.SENTAKU(Model.KobetuTableName.M_TENPO)
    End Function

    Protected Overrides Function UpdateMethod() As BLL.Common.IBusinessLogic
        Return New BLL.SEN.SENTAKU(Model.KobetuTableName.M_TENPO)
    End Function

    Protected Overrides Function CodeNameField() As String
        Return "TENCODE"
    End Function

    Protected Overrides Function NameField() As String
        Return "TENNAME"
    End Function

    Protected Overrides Function NameStr() As String
        Return "店舗名"
    End Function

End Class