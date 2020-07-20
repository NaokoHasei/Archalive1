Imports System.Net
Imports System.IO
Imports System.Xml

Public Class apiMAP0001

    Private reqest As reqestMAP0001
    Public response As responseMAP0001

    ''' <summary>
    ''' リスエストパラメータのクラス
    ''' </summary>
    Public Class reqestMAP0001
        Private paramAddress As String

        ''' <summary>
        ''' 住所
        ''' </summary>
        Public Property ADDRESS() As String
            Get
                Return paramAddress
            End Get
            Set(value As String)
                paramAddress = value
            End Set
        End Property
    End Class

    ''' <summary>
    ''' レスポンスパラメータのクラス
    ''' </summary>
    Public Class responseMAP0001
        Private paramMessageId As String
        Private paramMessageParam As String
        Private paramLat As String
        Private paramLng As String

        ''' <summary>
        ''' メッセージID
        ''' </summary>
        Public Property MESSAGE_ID() As String
            Get
                Return paramMessageId
            End Get
            Set(value As String)
                paramMessageId = value
            End Set
        End Property

        ''' <summary>
        ''' メッセージパラメータ
        ''' </summary>
        Public Property MESSAGE_PARAM() As String
            Get
                Return paramMessageParam
            End Get
            Set(value As String)
                paramMessageParam = value
            End Set
        End Property

        ''' <summary>
        ''' 緯度
        ''' </summary>
        Public Property LAT() As String
            Get
                Return paramLat
            End Get
            Set(value As String)
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
            Set(value As String)
                paramLng = value
            End Set
        End Property
    End Class

    Public Sub New(ByVal req As reqestMAP0001)
        reqest = req
        response = New responseMAP0001
    End Sub

    ''' <summary>
    ''' 緯度・経度の取得API
    ''' </summary>
    Public Sub GetLatLngGeocoder()
        response.MESSAGE_ID = ""

        Try
            Dim S_API_KEY = New BLL.Common.S_API_KEYRead

            'リクエスト
            Dim req As WebRequest = WebRequest.Create($"https://maps.google.com/maps/api/geocode/xml?key=" + S_API_KEY.GetData + "&address=" & reqest.ADDRESS)
            req.Method = "GET"
            Dim resp As WebResponse = req.GetResponse

            If (resp Is Nothing) Then
                response.MESSAGE_ID = "212"
            End If

            'レスポンスの読み取り
            Dim sr As StreamReader = New StreamReader(resp.GetResponseStream)
            Dim doc As XmlDocument = New XmlDocument()
            doc.LoadXml(sr.ReadToEnd.Trim)

            'STUTSの判定
            Dim stuts As String = doc.GetElementsByTagName("status")(0).InnerText
            If stuts = "ZERO_RESULTS" Then
                '結果が0件の場合
                response.MESSAGE_ID = "212"
                Return
            ElseIf stuts <> "OK" Then
                'その他エラーの場合
                response.MESSAGE_ID = "213"
                response.MESSAGE_PARAM = stuts
                Return
            End If

            'レスポンスの作成
            '緯度
            response.LAT = CommonUtility.Utility.NS(Decimal.Parse(doc.SelectNodes("/GeocodeResponse/result/geometry/location/lat")(0).InnerText).ToString("##.#######"))
            '経度
            response.LNG = CommonUtility.Utility.NS(Decimal.Parse(doc.SelectNodes("/GeocodeResponse/result/geometry/location/lng")(0).InnerText).ToString("###.#######"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
