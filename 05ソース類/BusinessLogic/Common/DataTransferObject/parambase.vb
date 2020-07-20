Imports Model

Namespace DTO

    Public Class parambase

        <Serializable()> _
        Public MustInherit Class RequestKobetuParamBase

            Private requestPCNAMEValue As String
            Private requestPGIDValue As String
            Private requestFULINOValue As Integer
            Private transactionObject As System.Transactions.Transaction

            Public Property Transaction() As System.Transactions.Transaction
                Get
                    Return transactionObject
                End Get
                Set(ByVal value As System.Transactions.Transaction)
                    transactionObject = value
                End Set
            End Property

            Public Property PCNAME() As String
                Get
                    Return requestPCNAMEValue
                End Get
                Set(ByVal value As String)
                    requestPCNAMEValue = value
                End Set
            End Property

            Public Property PGID() As String
                Get
                    Return requestPGIDValue
                End Get
                Set(ByVal value As String)
                    requestPGIDValue = value
                End Set
            End Property

            Public Property FULINO() As Integer
                Get
                    Return requestFULINOValue
                End Get
                Set(ByVal value As Integer)
                    requestFULINOValue = value
                End Set
            End Property

        End Class

        <Serializable()> _
        Public MustInherit Class RequestParamBase
            Implements IValueState

            Private requestPgID As String
            Private requestUserCode As String
            Private transactionObject As System.Transactions.Transaction
            Private requestPcNameValue As String

            Public Property Transaction() As System.Transactions.Transaction
                Get
                    Return transactionObject
                End Get
                Set(ByVal value As System.Transactions.Transaction)
                    transactionObject = value
                End Set
            End Property

            Public Property PgID() As String
                Get
                    Return requestPgID
                End Get
                Set(ByVal value As String)
                    requestPgID = value
                End Set
            End Property

            Public Property UserCode() As String
                Get
                    Return requestUserCode
                End Get
                Set(ByVal value As String)
                    requestUserCode = value
                End Set
            End Property

            Public Property LoginPCName() As String
                Get
                    Return requestPcNameValue
                End Get
                Set(ByVal value As String)
                    requestPcNameValue = value
                End Set
            End Property

            Public MustOverride ReadOnly Property HasValue() As Boolean Implements IValueState.HasValue

            Public Overrides Function ToString() As String
                Dim output As String = ""
                Dim count_ary As Integer = 0
                Dim count_all As Integer = 0

                Dim obj As Object = Me
                Dim objtyp As Type = obj.GetType

                While Not (IsNothing(objtyp))

                    For Each tmp As Reflection.FieldInfo In objtyp.GetFields(Reflection.BindingFlags.Instance Or _
                                                                             Reflection.BindingFlags.NonPublic Or _
                                                                             Reflection.BindingFlags.FlattenHierarchy Or _
                                                                             Reflection.BindingFlags.Static Or _
                                                                             Reflection.BindingFlags.Public)
                        output += tmp.Name + " : "

                        If tmp.FieldType.IsArray Then
                            Dim ary As Array = CType(tmp.GetValue(obj), Array)
                            count_ary = 0
                            output += "["

                            For i As Integer = 0 To ary.Length - 1
                                Try
                                    output += "'" & ary.GetValue(i).ToString() & "'"
                                Catch ex As Exception
                                    output += ex.Message()
                                End Try
                                If i <> ary.Length - 1 Then
                                    output += ","
                                End If
                                count_ary += 1
                                If count_ary > 20 Then
                                    count_ary = 0
                                    output += "…"
                                    Exit For
                                End If
                            Next i
                            output += "]"
                        Else

                            If IsNothing(tmp.GetValue(obj)) Then
                                output += "Nothing"
                            Else
                                Try
                                    output += "'" & tmp.GetValue(obj).ToString & "'"
                                Catch ex As Exception
                                    output += ex.Message()
                                End Try
                            End If
                        End If

                        count_all += 1
                        output += ", "

                        If count_all > 20 Then
                            output += "…"
                            Exit For
                        End If
                    Next

                    If objtyp.FullName = "TEC.Postation.Model.DTO.RequestParamBase" Then
                        Exit While
                    End If
                    objtyp = objtyp.BaseType

                End While

                Return output
            End Function
        End Class

        <Serializable()> _
        Public MustInherit Class ResponseValueBase

        End Class

        <Serializable()> _
        Public Class RequestNoParam
            Inherits RequestParamBase

            Public Overrides ReadOnly Property HasValue() As Boolean
                Get
                    Return True
                End Get
            End Property
        End Class

        <Serializable()> _
        Public Class ResponseNoValue
            Inherits ResponseValueBase
            Implements IValueState

            Public ReadOnly Property HasValue() As Boolean Implements IValueState.HasValue
                Get
                    Return True
                End Get
            End Property
        End Class

        <Serializable()> _
        Public Class ResponseDataSet
            Inherits ResponseValueBase
            Implements IValueState
            Implements IItem(Of System.Data.DataSet)

            Private _hasValue As Boolean
            Private responseList As System.Data.DataSet

            Public ReadOnly Property Item() As System.Data.DataSet
                Get
                    Return responseList
                End Get
            End Property

            Public Sub New(ByVal value As System.Data.DataSet)
                responseList = value
                If value.Tables(0).Rows.Count = 0 Then
                    _hasValue = False
                Else
                    _hasValue = True
                End If

            End Sub

            Public ReadOnly Property HasValue() As Boolean Implements IValueState.HasValue
                Get
                    Return _hasValue
                End Get
            End Property

            Public ReadOnly Property IITem_Item() As System.Data.DataSet Implements IItem(Of System.Data.DataSet).Item
                Get
                    Return responseList
                End Get
            End Property

        End Class


        <Serializable()> _
        Public Class ResponseTypedDataSet(Of TDataSet As {System.Data.DataSet, IValueState})
            Inherits ResponseValueBase
            Implements IValueState
            Implements IItem(Of System.Data.DataSet)

            Private _hasValue As Boolean
            Private responseList As TDataSet

            Public ReadOnly Property Item() As TDataSet
                Get
                    Return responseList
                End Get
            End Property

            Public Sub New(ByVal value As TDataSet)
                responseList = value
                If value.HasValue = False Then
                    _hasValue = False
                Else
                    _hasValue = True
                End If

            End Sub

            Public ReadOnly Property HasValue() As Boolean Implements IValueState.HasValue
                Get
                    Return _hasValue
                End Get
            End Property

            Public ReadOnly Property IITem_Item() As System.Data.DataSet Implements IItem(Of System.Data.DataSet).Item
                Get
                    Return responseList
                End Get
            End Property

        End Class

        <Serializable()> _
        Public Class ResponseReportBase(Of TDataSet As {System.Data.DataSet})
            Inherits ResponseValueBase
            Implements IValueState
            Implements IItem(Of System.Data.DataSet)

            Private serverDateValue As Date
            Private responseDataSet As TDataSet
            Private pageOverFlowValue As Boolean

            Public Property ServerDate() As Date
                Get
                    Return serverDateValue
                End Get
                Set(ByVal value As Date)
                    serverDateValue = value
                End Set
            End Property

            Public ReadOnly Property ReportDataSet() As TDataSet
                Get
                    Return responseDataSet
                End Get
            End Property

            Public Property PageOverFlow() As Boolean
                Get
                    Return pageOverFlowValue
                End Get
                Set(ByVal value As Boolean)
                    pageOverFlowValue = value
                End Set
            End Property

            Public Sub New(ByVal value As TDataSet, ByVal ServerDate As Date)
                responseDataSet = value
                serverDateValue = ServerDate

            End Sub

            Public Overridable ReadOnly Property HasValue() As Boolean Implements IValueState.HasValue
                Get
                    If Item Is Nothing Then
                        Return False
                    End If
                    If Item.Tables.Count = 0 Then
                        Return False
                    End If
                    If Item.Tables(0).Rows.Count = 0 Then
                        Return False
                    End If
                    Return True
                End Get
            End Property

            Public ReadOnly Property Item() As System.Data.DataSet Implements IItem(Of System.Data.DataSet).Item
                Get
                    Return ReportDataSet
                End Get
            End Property
        End Class

        <Serializable()> _
        Public Class RequestPcName
            Inherits RequestParamBase

            Private strPcName As String

            Public ReadOnly Property PcName() As String
                Get
                    Return strPcName
                End Get
            End Property

            Public Sub New(ByVal pcName As String)

                strPcName = pcName

            End Sub

            Public Overrides ReadOnly Property HasValue() As Boolean
                Get
                    Return True
                End Get
            End Property
        End Class

        <Serializable()> _
        Public Class RequestReportData
            Inherits RequestPcName

            Private indexValue As Integer
            Private tableNameValue As String

            Public ReadOnly Property TableName() As String
                Get
                    Return tableNameValue
                End Get
            End Property

            Public ReadOnly Property Index() As Integer
                Get
                    Return indexValue
                End Get
            End Property

            Public Sub New(ByVal pcName As String, ByVal tableName As String, ByVal index As Integer)
                MyBase.New(pcName)

                tableNameValue = tableName
                indexValue = index

            End Sub

        End Class

        <Serializable()> _
        Public Class RequestPrimaryKey(Of TPrimaryKey)
            Inherits RequestParamBase

            Protected requestKey As TPrimaryKey

            Public ReadOnly Property Key() As TPrimaryKey
                Get
                    Return requestKey
                End Get
            End Property

            Public Sub New(ByVal key As TPrimaryKey)
                requestKey = key
            End Sub

            Public Overrides ReadOnly Property HasValue() As Boolean
                Get
                    Return True
                End Get
            End Property
        End Class


        <Serializable()> _
        Public Class RequestKeyValueSet(Of TKey, TValue)
            Inherits RequestParamBase

            Public keyValueSet As IEnumerable(Of KeyValuePair(Of TKey, TValue))

            Public Overrides ReadOnly Property HasValue() As Boolean
                Get
                    If keyValueSet Is Nothing OrElse keyValueSet.GetEnumerator.MoveNext = False Then
                        Return False
                    Else
                        Return True
                    End If
                End Get
            End Property
        End Class

    End Class

End Namespace

