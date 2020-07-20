Public Class SENBUM

    Public Overrides Function PROGRAM_ID() As String
        Return "BUMTEN"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "部門選択"
    End Function

    Protected Overrides Function WorkLoadMethod() As BLL.Common.IBusinessLogic
        Return New BLL.SEN.SENTAKU(Model.KobetuTableName.M_BUMON)
    End Function

    Protected Overrides Function UpdateMethod() As BLL.Common.IBusinessLogic
        Return New BLL.SEN.SENTAKU(Model.KobetuTableName.M_BUMON)
    End Function

    Protected Overrides Function CodeNameField() As String
        Return "BUMONCODE"
    End Function

    Protected Overrides Function NameField() As String
        Return "BUMONNAME"
    End Function

    Protected Overrides Function NameStr() As String
        Return "部門名"
    End Function

End Class