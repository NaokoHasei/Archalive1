Public Class MessageBase

    Private MessageInfoValue As BLL.Common.dsS_MESSAGE

    Public ReadOnly Property MessageInfo() As BLL.Common.dsS_MESSAGE
        Get
            Return MessageInfoValue
        End Get
    End Property

    Public Sub New()
        Dim logic As New BLL.Common.MessageInfo
        MessageInfoValue = logic.GetS_MESSAGE
    End Sub

End Class
