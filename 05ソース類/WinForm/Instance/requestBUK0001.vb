Public Class requestBUK0001
    Private paramBukkenNo As Decimal

    ''' <summary>
    ''' 物件No
    ''' </summary>
    Public Property BUKKEN_NO() As Decimal
        Get
            Return paramBukkenNo
        End Get
        Set(ByVal value As Decimal)
            paramBukkenNo = value
        End Set
    End Property

End Class
