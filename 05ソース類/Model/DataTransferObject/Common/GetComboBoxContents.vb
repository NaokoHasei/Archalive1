
Namespace DTO

    ''' <summary>
    ''' DataSetの列数を指定します
    ''' </summary>
    Public Enum GetComboBoxContentsResultFieldType
        ''' <summary>
        ''' コードと名称を1つのフィールドにセットします(webForm用)
        ''' </summary>
        SingleField
        ''' <summary>
        ''' コードと名称を別々のフィールドにセットします(winForm用)
        ''' </summary>
        MultipleField
    End Enum

    ''' <summary>
    ''' データセット、表示フィールド、コードフィールドを保存します
    ''' </summary>
    <Serializable()> _
    Public Class ResponseGetComboBoxContentsElement
        Private dataTextFieldValue As String()
        Private dataValueFieldValue As String
        Private dataValueFieldExtValue As String
        Private resultDataSetValue As DataSet

        ''' <summary>
        ''' 表示フィールド名を返します
        ''' </summary>
        ''' <value></value>
        ''' <returns>フィールド名</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DataTextFields() As String()
            Get
                Return dataTextFieldValue
            End Get

        End Property

        ''' <summary>
        ''' コードを保持するフィールド名を返します
        ''' </summary>
        ''' <value></value>
        ''' <returns>フィールド名</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DataValueField() As String
            Get
                Return dataValueFieldValue
            End Get

        End Property

        ''' <summary>
        ''' コードを保持するフィールド名を返します(サイズマスタ用PTNO)
        ''' </summary>
        ''' <value></value>
        ''' <returns>フィールド名</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DataValueFieldExt() As String
            Get
                Return dataValueFieldExtValue
            End Get
        End Property

        ''' <summary>
        ''' コンボボックスのドロップダウンに使用するDataSetを返します
        ''' </summary>
        ''' <value></value>
        ''' <returns>ドロップダウンに使用するDataSet</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ResultDataSet() As DataSet
            Get
                Return resultDataSetValue
            End Get

        End Property

        ''' <summary>
        ''' 新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="dataValueField">コードフィールド</param>
        ''' <param name="dataTextFields">表示フィールド</param>
        ''' <param name="resultDataSet">データセット</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal dataValueField As String, ByVal dataTextFields As String(), ByVal resultDataSet As DataSet)
            dataValueFieldValue = dataValueField
            dataTextFieldValue = dataTextFields
            resultDataSetValue = resultDataSet
        End Sub


        ''' <summary>
        ''' データセットを返します
        ''' </summary>
        ''' <param name="resultDataSet"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal resultDataSet As DataSet)
            resultDataSetValue = resultDataSet
        End Sub

        Public Sub New()
        End Sub

    End Class

    ''' <summary>
    ''' テーブル名、フィールド列数を保持します
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class RequestGetComboBoxContentsElement

        Private tableNameValue As ComboBoxTableName
        Private resultFieldTypeValue As GetComboBoxContentsResultFieldType

        Private conditionCodeValue As String
        Private insertBlankValue As Boolean

        ''' <summary>
        ''' 取得するテーブル名
        ''' </summary>
        ''' <value></value>
        ''' <returns>テーブル名</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property TableName() As ComboBoxTableName
            Get
                Return tableNameValue
            End Get
        End Property

        ''' <summary>
        ''' ブランクの有無
        ''' </summary>
        ''' <value></value>
        ''' <returns>ブランクを挿入する場合は true それ以外の場合は false</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property InsertBlank() As Boolean
            Get
                Return insertBlankValue
            End Get
        End Property

        ''' <summary>
        ''' DataSetの列数タイプ
        ''' </summary>
        ''' <value></value>
        ''' <returns>列数のタイプ</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ResultFieldType() As GetComboBoxContentsResultFieldType
            Get
                Return resultFieldTypeValue
            End Get
        End Property

        ''' <summary>
        ''' 条件
        ''' </summary>
        ''' <value></value>
        ''' <returns>条件</returns>
        ''' <remarks>チャネル2マスタ,サイズマスタ,その他絞込み条件が必要なマスタのみ使用します</remarks>
        Public ReadOnly Property ConditionCode() As String
            Get
                Return conditionCodeValue
            End Get
        End Property

        ''' <summary>
        ''' 新しいインスタンスを初期化します
        ''' </summary>
        ''' <param name="tableName">テーブル名</param>
        ''' <param name="resultFieldType">列数タイプ</param>
        ''' <param name="insertBlank">空白を挿入する場合true。それ以外の場合はfalse。</param>
        ''' <param name="conditionCode">条件</param>
        ''' <remarks></remarks>
        Public Sub New(
                  ByVal tableName As ComboBoxTableName _
                , ByVal resultFieldType As GetComboBoxContentsResultFieldType _
                , ByVal insertBlank As Boolean _
                , ByVal conditionCode As String)
            tableNameValue = tableName
            resultFieldTypeValue = resultFieldType
            conditionCodeValue = conditionCode
            insertBlankValue = insertBlank
        End Sub
    End Class

    <Serializable()> _
    Public Class RequestGetComboBoxContents
        Inherits RequestParamBase

        Private requestTableList As List(Of RequestGetComboBoxContentsElement)

        Public ReadOnly Property TableList() As List(Of RequestGetComboBoxContentsElement)
            Get
                Return requestTableList
            End Get
        End Property


        Public Sub New(ByVal tableList As List(Of RequestGetComboBoxContentsElement))
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

    <Serializable()>
    Public Class ResponseGetComboBoxContents
        Inherits ResponseValueBase

        Private responseComboBoxContents As Dictionary(Of ComboBoxTableName, ResponseGetComboBoxContentsElement)

        Public ReadOnly Property Contents() As Dictionary(Of ComboBoxTableName, ResponseGetComboBoxContentsElement)
            Get
                Return responseComboBoxContents
            End Get
        End Property

        Public Sub New(ByVal value As Dictionary(Of ComboBoxTableName, ResponseGetComboBoxContentsElement))
            responseComboBoxContents = value
        End Sub
    End Class

    <Serializable()>
    Public Class ResponseGetComboBoxContents2
        Inherits ResponseValueBase

        Public value As String
        Public name As String

        Public Sub New(ByVal paramValue As String, ByVal paramName As String)
            value = paramValue
            name = paramName
        End Sub
    End Class

End Namespace
