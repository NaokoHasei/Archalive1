Namespace DTO

    <Serializable()> _
    Public Class GetDbValueElement
        Private tableNameValue As String
        Private fieldNameValue As String
        Private filterValue As String
        Public Property TableName() As String
            Get
                Return tableNameValue
            End Get
            Set(ByVal value As String)
                tableNameValue = value
            End Set
        End Property
        Public Property FieldName() As String
            Get
                Return fieldNameValue
            End Get
            Set(ByVal value As String)
                fieldNameValue = value
            End Set
        End Property
        Public Property Filter() As String
            Get
                Return filterValue
            End Get
            Set(ByVal value As String)
                filterValue = value
            End Set
        End Property


        Public Sub New(ByVal tableName As String, ByVal fieldName As String, ByVal filter As String)
            Me.TableName = tableName
            Me.FieldName = fieldName
            Me.Filter = filter
        End Sub

        Public Sub New()

        End Sub
    End Class

    <Serializable()> _
    Public Class RequestGetDbValue
        Inherits RequestParamBase

        Private requestParams As List(Of GetDbValueElement)

        Public Overrides ReadOnly Property HasValue() As Boolean
            Get
                If requestParams Is Nothing Then
                    Return False
                End If
                If requestParams.Count = 0 Then
                    Return False
                End If
                Return True

            End Get
        End Property

        Public ReadOnly Property Params() As List(Of GetDbValueElement)
            Get
                Return requestParams
            End Get
        End Property


        Public Sub New(ByVal params As List(Of GetDbValueElement))
            requestParams = params
        End Sub
    End Class

End Namespace
