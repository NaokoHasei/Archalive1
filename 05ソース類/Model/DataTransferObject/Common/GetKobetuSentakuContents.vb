Namespace DTO

    <Serializable()> _
    Public Class RequestGetKobetuSentakuContents
        Inherits RequestParamBase

        Private requestTableList As List(Of RequestGetKobetuSENTAKUElement)

        Public ReadOnly Property TableList() As List(Of RequestGetKobetuSENTAKUElement)
            Get
                Return requestTableList
            End Get
        End Property


        Public Sub New(ByVal tableList As List(Of RequestGetKobetuSENTAKUElement))
            requestTableList = tableList
        End Sub

        Public Overrides ReadOnly Property HasValue() As Boolean
            Get
                If requestTableList Is Nothing Then
                    Return False
                End If
                If requestTableList.Count = 0 Then
                    Return False
                End If
                Return True
            End Get
        End Property
    End Class

    <Serializable()> _
    Public Class RequestSentakuKey
        Inherits RequestParamBase
        Implements IKobetuSentakuKey

        Private requestPCNAMEKey As String
        Private requestPGCODEKey As String
        Private requestFULINOKey As Integer

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

    <Serializable()> _
    Public Class RequestGetKobetuSENTAKUElement
        Inherits RequestSentakuKey

        Private requestTABLEKey As KobetuTableName
        Private requestInitializeKindValue As InitializeKind

        Public ReadOnly Property TABLEKey() As KobetuTableName
            Get
                Return requestTABLEKey
            End Get
        End Property

        Public ReadOnly Property InitialKindValue() As InitializeKind
            Get
                Return requestInitializeKindValue
            End Get
        End Property

        Public Sub New(ByVal PCNAMEKey As String, ByVal PGCODEKey As String, ByVal FULINOKey As Integer, ByVal TABLEKey As KobetuTableName, ByVal requestInitialKind As InitializeKind)
            MyBase.New(PCNAMEKey, PGCODEKey, FULINOKey)
            requestTABLEKey = TABLEKey
            requestInitializeKindValue = requestInitialKind
        End Sub

    End Class

    <Serializable()> _
    Public Class RequestSentakuUpdate
        Inherits RequestSentakuKey

        Private requestDataTable As DataTable

        Public ReadOnly Property Datatable() As DataTable
            Get
                Return requestDataTable
            End Get
        End Property

        Public Sub New(ByVal PCNAMEKey As String, ByVal PGCODEKey As String, ByVal FULINO As Integer, ByVal Datatable As DataTable)
            MyBase.New(PCNAMEKey, PGCODEKey, FULINO)
            requestDataTable = Datatable
        End Sub

        Public Overrides ReadOnly Property HasValue() As Boolean
            Get
                Return True
            End Get
        End Property
    End Class

End Namespace
