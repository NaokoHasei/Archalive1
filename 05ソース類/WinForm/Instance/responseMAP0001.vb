Public Class responseMAP0001

    Private paramResponseFlagPostNo As Boolean
    Private paramResponseFlagAddress As Boolean
    Private paramResponseFlagLatLng As Boolean
    Private paramPostNo As String
    Private paramAddress As String
    Private paramAddress1 As String
    Private paramAddress2 As String
    Private paramLat As String
    Private paramLng As String

    ''' <summary>
    ''' 返却フラグ（郵便番号）
    ''' </summary>
    Public Property RESPONSE_FLAG_POST_NO() As Boolean
        Get
            Return paramResponseFlagPostNo
        End Get
        Set(ByVal value As Boolean)
            paramResponseFlagPostNo = value
        End Set
    End Property

    ''' <summary>
    ''' 返却フラグ（住所）
    ''' </summary>
    Public Property RESPONSE_FLAG_ADDRESS() As Boolean
        Get
            Return paramResponseFlagAddress
        End Get
        Set(ByVal value As Boolean)
            paramResponseFlagAddress = value
        End Set
    End Property

    ''' <summary>
    ''' 返却フラグ（緯度・経度）
    ''' </summary>
    Public Property RESPONSE_FLAG_LAT_LNG() As Boolean
        Get
            Return paramResponseFlagLatLng
        End Get
        Set(ByVal value As Boolean)
            paramResponseFlagLatLng = value
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
    ''' 住所1
    ''' </summary>
    Public Property ADDRESS1() As String
        Get
            Return paramAddress1
        End Get
        Set(ByVal value As String)
            paramAddress1 = value
        End Set
    End Property

    ''' <summary>
    ''' 住所2
    ''' </summary>
    Public Property ADDRESS2() As String
        Get
            Return paramAddress2
        End Get
        Set(ByVal value As String)
            paramAddress2 = value
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
