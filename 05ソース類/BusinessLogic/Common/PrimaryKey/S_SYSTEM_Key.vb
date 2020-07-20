Public Class S_SYSTEM_PrimaryKey

    Private PCNAMEValue As String
    Private SYSTEMFILEValue As String
    Private SECTIONNAMEValue As String
    Private PROPERTYPNAMEValue As String

    Public Property PCNAME() As String
        Get
            Return PCNAMEValue
        End Get
        Set(ByVal value As String)
            PCNAMEValue = value
        End Set
    End Property
    Public Property SYSTEMFILE() As String
        Get
            Return SYSTEMFILEValue
        End Get
        Set(ByVal value As String)
            SYSTEMFILEValue = value
        End Set
    End Property
    Public Property SECTIONNAME() As String
        Get
            Return SECTIONNAMEValue
        End Get
        Set(ByVal value As String)
            SECTIONNAMEValue = value
        End Set
    End Property
    Public Property PROPERTYPNAME() As String
        Get
            Return PROPERTYPNAMEValue
        End Get
        Set(ByVal value As String)
            PROPERTYPNAMEValue = value
        End Set
    End Property

    Public Sub New(ByVal strPCNAME As String, ByVal strSYSTEMFILE As String, ByVal strSECTIONNAME As String, ByVal strPROPERTYPNAME As String)
        PCNAMEValue = strPCNAME
        SYSTEMFILEValue = strSYSTEMFILE
        SECTIONNAMEValue = strSECTIONNAME
        PROPERTYPNAMEValue = strPROPERTYPNAME
    End Sub

End Class

Public Class S_SYSTEM_GetSYSTEMFILEKey

    Private PCNAMEValue As String
    Private SYSTEMFILEValue As String

    Public Property PCNAME() As String
        Get
            Return PCNAMEValue
        End Get
        Set(ByVal value As String)
            PCNAMEValue = value
        End Set
    End Property

    Public Property SYSTEMFILE() As String
        Get
            Return SYSTEMFILEValue
        End Get
        Set(ByVal value As String)
            SYSTEMFILEValue = value
        End Set
    End Property

    Public Sub New(ByVal strPCNAME As String, ByVal strSYSTEMFILE As String)
        PCNAMEValue = strPCNAME
        SYSTEMFILEValue = strSYSTEMFILE
    End Sub

End Class

Public Class S_SYSTEM_GetALLSYSTEMFILEKey

    Private PCNAMEValue As String

    Public Property PCNAME() As String
        Get
            Return PCNAMEValue
        End Get
        Set(ByVal value As String)
            PCNAMEValue = value
        End Set
    End Property

    Public Sub New(ByVal strPCNAME As String)
        PCNAMEValue = strPCNAME
    End Sub

End Class