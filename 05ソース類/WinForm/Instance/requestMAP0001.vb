Public Class requestMAP0001

    Private paramHaneisakiCheckFlag As Boolean
    Private paramMakerList() As Maker
    Private paramBukkenNoneLatLng As dsBUK0002.dbgMeisaiDataTable

    ''' <summary>
    ''' マーカー
    ''' </summary>
    Public Property MAKER_LIST() As Maker()
        Get
            Return paramMakerList
        End Get
        Set(ByVal value As Maker())
            paramMakerList = value
        End Set
    End Property

    '''' <summary>
    '''' 緯度・経度の未指定一覧
    '''' </summary>
    'Public Property BUKKEN_NONE_LAT_LNG_LIST() As BukkenNoneLatLng()
    '    Get
    '        Return paramBukkenNoneLatLng
    '    End Get
    '    Set(ByVal value As BukkenNoneLatLng())
    '        paramBukkenNoneLatLng = value
    '    End Set
    'End Property

    ''' <summary>
    ''' 緯度・経度の未指定一覧
    ''' </summary>
    Public Property BUKKEN_NONE_LAT_LNG_LIST() As dsBUK0002.dbgMeisaiDataTable
        Get
            Return paramBukkenNoneLatLng
        End Get
        Set(ByVal value As dsBUK0002.dbgMeisaiDataTable)
            paramBukkenNoneLatLng = value
        End Set
    End Property

    Public Class Maker
        Private paramBukkenNo As String
        Private paramBukkenName As String
        Private paramPostNo As String
        Private paramAddress As String
        Private paramLng As String
        Private paramLat As String

        ''' <summary>
        ''' 物件No
        ''' </summary>
        Public Property BUKKEN_NO() As String
            Get
                Return paramBukkenNo
            End Get
            Set(ByVal value As String)
                paramBukkenNo = value
            End Set
        End Property

        ''' <summary>
        ''' 物件名
        ''' </summary>
        Public Property BUKKEN_NAME() As String
            Get
                Return paramBukkenName
            End Get
            Set(ByVal value As String)
                paramBukkenName = value
            End Set
        End Property

        ''' <summary>
        ''' 郵便番号
        ''' </summary>
        Public Property POST_NO() As String
            Get
                Return paramPostNo
            End Get
            Set(ByVal value As String)
                paramPostNo = value
            End Set
        End Property

        ''' <summary>
        ''' 住所
        ''' </summary>
        Public Property ADDRESS() As String
            Get
                Return paramAddress
            End Get
            Set(ByVal value As String)
                paramAddress = value
            End Set
        End Property

        ''' <summary>
        ''' 緯度
        ''' </summary>
        Public Property LAT() As String
            Get
                Return paramLat
            End Get
            Set(ByVal value As String)
                paramLat = value
            End Set
        End Property

        ''' <summary>
        ''' 経度
        ''' </summary>
        Public Property LNG() As String
            Get
                Return paramLng
            End Get
            Set(ByVal value As String)
                paramLng = value
            End Set
        End Property
    End Class

    Public Class BukkenNoneLatLng
        Private paramBukkenNo As String
        Private paramJyotai As String
        Private paramBukkenName As String
        Private paramKoujiBasyo As String
        Private paramMotouke As String
        Private paramChakkouDate As String
        Private paramKankouDate As String
        Private paramTanatoName As String
        Private paramRecodeCount As Decimal
        Private paramRecodeCountJyogen As Decimal

        ''' <summary>
        ''' 物件No
        ''' </summary>
        Public Property BUKKEN_NO() As String
            Get
                Return paramBukkenNo
            End Get
            Set(ByVal value As String)
                paramBukkenNo = value
            End Set
        End Property

        ''' <summary>
        ''' 受注承認
        ''' </summary>
        Public Property SYONIN_JYUTYU() As String
            Get
                Return paramJyotai
            End Get
            Set(ByVal value As String)
                paramJyotai = value
            End Set
        End Property

        ''' <summary>
        ''' 発注承認
        ''' </summary>
        Public Property SYONIN_HATTYU() As String
            Get
                Return paramJyotai
            End Get
            Set(ByVal value As String)
                paramJyotai = value
            End Set
        End Property

        ''' <summary>
        ''' 状態
        ''' </summary>
        Public Property JYOTAI() As String
            Get
                Return paramJyotai
            End Get
            Set(ByVal value As String)
                paramJyotai = value
            End Set
        End Property

        ''' <summary>
        ''' 物件名
        ''' </summary>
        Public Property BUKKEN_NAME() As String
            Get
                Return paramBukkenName
            End Get
            Set(ByVal value As String)
                paramBukkenName = value
            End Set
        End Property

        ''' <summary>
        ''' 工事場所
        ''' </summary>
        Public Property KOUJI_BASYO() As String
            Get
                Return paramKoujiBasyo
            End Get
            Set(ByVal value As String)
                paramKoujiBasyo = value
            End Set
        End Property

        ''' <summary>
        ''' 元請
        ''' </summary>
        Public Property MOTOUKE() As String
            Get
                Return paramMotouke
            End Get
            Set(ByVal value As String)
                paramMotouke = value
            End Set
        End Property

        ''' <summary>
        ''' 着工日
        ''' </summary>
        Public Property CHAKKOU_DATE() As String
            Get
                Return paramChakkouDate
            End Get
            Set(ByVal value As String)
                paramChakkouDate = value
            End Set
        End Property

        ''' <summary>
        ''' 完工日
        ''' </summary>
        Public Property KANKOU_DATE() As String
            Get
                Return paramKankouDate
            End Get
            Set(ByVal value As String)
                paramKankouDate = value
            End Set
        End Property

        ''' <summary>
        ''' 担当者名
        ''' </summary>
        Public Property TANTO_NAME() As String
            Get
                Return paramTanatoName
            End Get
            Set(ByVal value As String)
                paramTanatoName = value
            End Set
        End Property

        ''' <summary>
        ''' 取得件数
        ''' </summary>
        Public Property RECODE_COUNT() As Decimal
            Get
                Return paramRecodeCount
            End Get
            Set(ByVal value As Decimal)
                paramRecodeCount = value
            End Set
        End Property

        ''' <summary>
        ''' 取得件数（上限）
        ''' </summary>
        Public Property RECODE_COUNT_JYOGEN() As Decimal
            Get
                Return paramRecodeCountJyogen
            End Get
            Set(ByVal value As Decimal)
                paramRecodeCountJyogen = value
            End Set
        End Property
    End Class
End Class
