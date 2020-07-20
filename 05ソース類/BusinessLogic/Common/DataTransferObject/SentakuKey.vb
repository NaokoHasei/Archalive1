Imports Model

Namespace DTO

    <Serializable()> _
     Public Class RequestSentakuKey
        Inherits DTO.parambase.RequestParamBase
        Implements IKobetuSentakuKey

        Private requestPCNAMEKey As String
        Private requestPGCODEKey As String
        Private requestFULINOKey As Integer
        Private TableNameValue As Model.KobetuTableName

        Public Property PCNAMEKey() As String Implements IKobetuSentakuKey.PCNAMEKey
            Get
                Return requestPCNAMEKey
            End Get
            Set(ByVal value As String)
                requestPCNAMEKey = value
            End Set
        End Property

        Public Property PGCODEKey() As String Implements IKobetuSentakuKey.PGCODEKey
            Get
                Return requestPGCODEKey
            End Get
            Set(ByVal value As String)
                requestPGCODEKey = value
            End Set
        End Property

        Public Property FULINOKey() As Integer Implements IKobetuSentakuKey.FULINOKey
            Get
                Return requestFULINOKey
            End Get
            Set(ByVal value As Integer)
                requestFULINOKey = value
            End Set
        End Property

        'Public Property TableName() As Model.KobetuTableName
        '    Get
        '        Return TableNameValue
        '    End Get
        '    Set(ByVal value As Model.KobetuTableName)
        '        TableNameValue = value
        '    End Set
        'End Property
        Public Sub New(ByVal PCNAMEKey As String, ByVal PGCODEKey As String, ByVal FULINO As Integer)
            requestPCNAMEKey = PCNAMEKey
            requestPGCODEKey = PGCODEKey
            requestFULINOKey = FULINO
        End Sub

        Public Overrides ReadOnly Property HasValue() As Boolean
            Get
                Return True
            End Get
        End Property

    End Class

End Namespace
