Imports CommonUtility
Imports CommonUtility.Utility
Imports CommonUtility.WinForm
Imports BLL.Common

Public Class frmMAP0001
    Public Overrides Function PROGRAM_ID() As String
        Return strProgramId
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return strProgramName
    End Function

    Public Enum emumDispKbn
        PLOT
        BUKKEN_KENSAKU
    End Enum

    Private strProgramId As String                               'プログラムID
    Private strProgramName As String                             'プログラム名
    Private praDispKbn As emumDispKbn                            '画面表示区分

    Public requestBUK0001 As New requestBUK0001
    Public requestMAP0001 As New requestMAP0001
    Public responseMAP0001 As New responseMAP0001

    Public Sub New(ByVal dispKbn As emumDispKbn)
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        responseMAP0001 = New responseMAP0001
        responseMAP0001.RESPONSE_FLAG_POST_NO = False
        responseMAP0001.RESPONSE_FLAG_ADDRESS = False
        responseMAP0001.RESPONSE_FLAG_LAT_LNG = False

        praDispKbn = dispKbn

        If praDispKbn = emumDispKbn.PLOT Then
            strProgramId = "BUK0001"
            strProgramName = "プロット"
        Else
            strProgramId = "BUK0002"
            strProgramName = "物件検索（マップ）"
        End If
    End Sub

    Protected Overrides Sub Form_Load(ByVal sender As Object, ByVal e As EventArgs)

        'ファンクションキーの設定
        FunctionKey.ClearAll()

        FunctionKey.SetItem(1, "終了", "終了", True)
        FunctionKey.SetItem(12, "選択", "選択", True)

        If praDispKbn = emumDispKbn.PLOT Then
            Panel2.Visible = True
            Panel3.Visible = False

            chkPostNo.Checked = True
            chkAddress.Checked = True
            chkLatLng.Checked = True
        Else
            Panel2.Visible = False
            If requestMAP0001.BUKKEN_NONE_LAT_LNG_LIST.Rows.Count <> 0 Then
                Panel3.Visible = True
                Panel3.Left = 19
            Else
                Panel3.Visible = False
            End If
        End If

        Me.Text = strProgramName
        TitleBar.Title = strProgramName

        'ブラウザのエラーを表示しない
        '　※ブラウザが全て表示される前に終了ボタン押下でエラーになったため
        WebBrowser1.ScriptErrorsSuppressed = True

        WebBrowser1.DocumentText = GoogleMap()
    End Sub

    'GoogleMapの表示
    'mode : （0：初期表示、1：表示ボタン押下）
    Public Function GoogleMap() As String
        Dim txtHtml As String = ""

        '初期位置（緯度・経度・ズーム）の設定
        Dim lat As String = "34.8591225"
        Dim lng As String = "134.5299544"
        Dim zoom As String = "10"
        Dim dispKbn As String = "1"

        '初期表示位置／緯度の設定
        Dim S_SCB1 As New S_SCBRead("マップ（初期位置）", "緯度")
        Dim dsS_SCB = S_SCB1.GetS_SCB
        If dsS_SCB.S_SCB.Rows.Count <> 0 Then lat = dsS_SCB.S_SCB(0).DATA.ToString

        '初期表示位置／経度の設定
        Dim S_SCB2 As New S_SCBRead("マップ（初期位置）", "経度")
        dsS_SCB = S_SCB2.GetS_SCB
        If dsS_SCB.S_SCB.Rows.Count <> 0 Then lng = dsS_SCB.S_SCB(0).DATA.ToString

        '初期表示位置／ズームの設定
        Dim S_SCB3 As New S_SCBRead("マップ（初期位置）", "倍率")
        dsS_SCB = S_SCB3.GetS_SCB
        If dsS_SCB.S_SCB.Rows.Count <> 0 Then zoom = dsS_SCB.S_SCB(0).DATA.ToString

        '初期表示位置／表示区分の設定
        Dim S_SCB4 As New S_SCBRead("マップ（初期位置／表示区分）")
        dsS_SCB = S_SCB4.GetS_SCB
        If dsS_SCB.S_SCB.Rows.Count <> 0 Then dispKbn = dsS_SCB.S_SCB(0).DATA.ToString

        '初期表示位置の設定
        If dispKbn = "1" Then
            '基本設定マスタのマップ（初期位置／表示区分）がマーカーの位置の場合
            If requestMAP0001.MAKER_LIST.Length <> 0 Then
                With requestMAP0001.MAKER_LIST(0)
                    If Not NUCheck(.LAT) AndAlso Not NUCheck(.LNG) Then
                        lat = .LAT
                        lng = .LNG
                    End If
                End With
            End If
        End If

        Dim S_API_KEY = New BLL.Common.S_API_KEYRead

        txtHtml = txtHtml & vbCrLf & "<html>"
        txtHtml = txtHtml & vbCrLf & "  <head>"
        txtHtml = txtHtml & vbCrLf & "    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge""/>"
        txtHtml = txtHtml & vbCrLf & "    <meta name=""viewport"" content=""initial-scale=1.0, user-scalable=no"" />"
        txtHtml = txtHtml & vbCrLf & "    <script async defer src=""https://maps.googleapis.com/maps/api/js?key=" + S_API_KEY.GetData + "&callback=initMap""></script>"
        txtHtml = txtHtml & vbCrLf & "    <script type=""text/javascript"">"
        txtHtml = txtHtml & vbCrLf & "    var map;"
        txtHtml = txtHtml & vbCrLf & "    var marker;"
        txtHtml = txtHtml & vbCrLf & "    var CurrentMarkerNo = -1;"
        txtHtml = txtHtml & vbCrLf & "    var points = [];"
        txtHtml = txtHtml & vbCrLf & "    var makerView = [];"
        txtHtml = txtHtml & vbCrLf & "    var infowin = [];"
        txtHtml = txtHtml & vbCrLf & ""
        txtHtml = txtHtml & vbCrLf & "    function initMap() {"
        txtHtml = txtHtml & vbCrLf & ""
        txtHtml = txtHtml & vbCrLf & "      var myOptions = {"
        txtHtml = txtHtml & vbCrLf & "        center: {"
        txtHtml = txtHtml & vbCrLf & "          lat: " & lat & ",       // 緯度"
        txtHtml = txtHtml & vbCrLf & "          lng: " & lng & "        // 経度"
        txtHtml = txtHtml & vbCrLf & "        },"
        txtHtml = txtHtml & vbCrLf & "          zoom: " & zoom & "      // 地図のズームを指定"
        txtHtml = txtHtml & vbCrLf & "      };"
        txtHtml = txtHtml & vbCrLf & "      map = new google.maps.Map(document.getElementById(""map_canvas""), myOptions);"
        txtHtml = txtHtml & vbCrLf & ""

        '地図のクリックイベント
        If praDispKbn = emumDispKbn.PLOT Then
            txtHtml = txtHtml & vbCrLf & "      // クリックイベント"
            txtHtml = txtHtml & vbCrLf & "      map.addListener('click', function(e) {"
            txtHtml = txtHtml & vbCrLf & "        getClickLatLng(e.latLng, map);"
            txtHtml = txtHtml & vbCrLf & ""
            txtHtml = txtHtml & vbCrLf & "        if (marker) {"
            txtHtml = txtHtml & vbCrLf & "          marker.setMap(null);"
            txtHtml = txtHtml & vbCrLf & "        }"
            txtHtml = txtHtml & vbCrLf & "      });"
        End If

        'マーカーの作成
        txtHtml = txtHtml & vbCrLf & "        // マーカーを設定"
        txtHtml = txtHtml & vbCrLf & "        var latlng;"

        If praDispKbn = emumDispKbn.PLOT Then
            With requestMAP0001.MAKER_LIST(0)
                If Not NUCheck(.LAT) AndAlso Not NUCheck(.LNG) Then
                    txtHtml = txtHtml & vbCrLf & CreateMakerRed(0, .BUKKEN_NO, .LAT, .LNG, .BUKKEN_NAME, .POST_NO, .ADDRESS, False)
                End If
            End With

        Else
            Dim idx = 0

            For Each row As requestMAP0001.Maker In requestMAP0001.MAKER_LIST
                With row
                    If Not NUCheck(.LAT) AndAlso Not NUCheck(.LNG) Then
                        txtHtml = txtHtml & vbCrLf & CreateMakerRed(idx, .BUKKEN_NO, .LAT, .LNG, .BUKKEN_NAME, .POST_NO, .ADDRESS, True)

                        idx += 1
                    End If
                End With
            Next
        End If
        txtHtml = txtHtml & vbCrLf & "      function changeMarkerImage(markerNo) {"
        txtHtml = txtHtml & vbCrLf & "        //前回の選択マーカーの画像を元に戻す"
        txtHtml = txtHtml & vbCrLf & "        if (CurrentMarkerNo >= 0 && markerNo != CurrentMarkerNo) {"
        txtHtml = txtHtml & vbCrLf & "          makerView[CurrentMarkerNo].setIcon('https://maps.google.com/mapfiles/ms/icons/red-dot.png');"
        txtHtml = txtHtml & vbCrLf & "        }"
        txtHtml = txtHtml & vbCrLf & ""
        txtHtml = txtHtml & vbCrLf & "        //選択したマーカーの画像を変更"
        txtHtml = txtHtml & vbCrLf & "        makerView[markerNo].setIcon('https://maps.google.com/mapfiles/ms/icons/yellow-dot.png');"
        txtHtml = txtHtml & vbCrLf & "        CurrentMarkerNo = markerNo; //選択したマーカーの配列番号をグローバル変数にセット"
        txtHtml = txtHtml & vbCrLf & "      }"
        txtHtml = txtHtml & vbCrLf & ""
        txtHtml = txtHtml & vbCrLf & "      function getClickLatLng(lat_lng, map) {"
        txtHtml = txtHtml & vbCrLf & "        // 座標を表示"
        txtHtml = txtHtml & vbCrLf & "        document.getElementById('lat').textContent = lat_lng.lat();"
        txtHtml = txtHtml & vbCrLf & "        document.getElementById('lng').textContent = lat_lng.lng();"
        txtHtml = txtHtml & vbCrLf & ""
        txtHtml = txtHtml & vbCrLf & "        getAddress(lat_lng);"
        txtHtml = txtHtml & vbCrLf & "      }"
        txtHtml = txtHtml & vbCrLf & ""
        txtHtml = txtHtml & vbCrLf & "      function getAddress(latlng) {"
        txtHtml = txtHtml & vbCrLf & "        // ジオコーダのコンストラクタ"
        txtHtml = txtHtml & vbCrLf & "        var geocoder = new google.maps.Geocoder();"
        txtHtml = txtHtml & vbCrLf & ""
        txtHtml = txtHtml & vbCrLf & "        // geocodeリクエストを実行。"
        txtHtml = txtHtml & vbCrLf & "        // 第１引数はGeocoderRequest。緯度経度⇒住所の変換時はlatLngプロパティを入れればOK。"
        txtHtml = txtHtml & vbCrLf & "        // 第２引数はコールバック関数。"
        txtHtml = txtHtml & vbCrLf & "        geocoder.geocode({"
        txtHtml = txtHtml & vbCrLf & "          latLng: latlng"
        txtHtml = txtHtml & vbCrLf & "        }, function(results, status) {"
        txtHtml = txtHtml & vbCrLf & "          if (status == google.maps.GeocoderStatus.OK) {"
        txtHtml = txtHtml & vbCrLf & "            // results.length > 1 で返ってくる場合もありますが・・・。"
        txtHtml = txtHtml & vbCrLf & "            if (results[0].geometry) {"
        txtHtml = txtHtml & vbCrLf & ""
        txtHtml = txtHtml & vbCrLf & "              // 住所を取得"
        txtHtml = txtHtml & vbCrLf & "              var postCode = """";"
        txtHtml = txtHtml & vbCrLf & "              var address1 = """";"
        txtHtml = txtHtml & vbCrLf & "              var address2 = """";"
        txtHtml = txtHtml & vbCrLf & "              var address3 = """";"
        txtHtml = txtHtml & vbCrLf & ""
        txtHtml = txtHtml & vbCrLf & "              for(let i = results[0].address_components.length - 1; i >= 0; i--) {"
        txtHtml = txtHtml & vbCrLf & "                var address_components = results[0].address_components[i];"
        txtHtml = txtHtml & vbCrLf & "                if (address_components.types[0] == ""postal_code"") {"
        txtHtml = txtHtml & vbCrLf & "                  postCode = address_components.long_name;"
        txtHtml = txtHtml & vbCrLf & "                } else if (address_components.types[0] == ""administrative_area_level_1"") {"
        txtHtml = txtHtml & vbCrLf & "                  address1 = address1 + address_components.long_name;"
        txtHtml = txtHtml & vbCrLf & "                } else if (address_components.types[0] == ""locality"") {"
        txtHtml = txtHtml & vbCrLf & "                  address2 = address2 + address_components.long_name;"
        txtHtml = txtHtml & vbCrLf & "                } else if (address_components.types[0] == ""political"") {"
        txtHtml = txtHtml & vbCrLf & "                  if (address_components.types[2] == ""sublocality_level_1"") {"
        txtHtml = txtHtml & vbCrLf & "                    address2 = address2 + address_components.long_name;"
        txtHtml = txtHtml & vbCrLf & "                  } else if (address_components.types[2] == ""sublocality_level_2"") {"
        txtHtml = txtHtml & vbCrLf & "                    address2 = address2 + address_components.long_name;"
        txtHtml = txtHtml & vbCrLf & "                  } else if (address_components.types[2] == ""sublocality_level_3"") {"
        txtHtml = txtHtml & vbCrLf & "                    address3 = address3 + address_components.long_name;"
        txtHtml = txtHtml & vbCrLf & "                  } else if (address_components.types[2] == ""sublocality_level_4"") {"
        txtHtml = txtHtml & vbCrLf & "                    address3 = address3 + address_components.long_name;"
        txtHtml = txtHtml & vbCrLf & "                  } else if (address_components.types[2] == ""sublocality_level_5"") {"
        txtHtml = txtHtml & vbCrLf & "                    address3 = address3 + address_components.long_name;"
        txtHtml = txtHtml & vbCrLf & "                  }"
        txtHtml = txtHtml & vbCrLf & "                } else if (address_components.types[0] == ""premise"") {"
        txtHtml = txtHtml & vbCrLf & "                  address3 = address3 + address_components.long_name;"
        txtHtml = txtHtml & vbCrLf & "                }"
        txtHtml = txtHtml & vbCrLf & "              }"
        txtHtml = txtHtml & vbCrLf & ""
        txtHtml = txtHtml & vbCrLf & "              document.getElementById('postCode').textContent = postCode;"
        txtHtml = txtHtml & vbCrLf & "              document.getElementById('address1').textContent = address1;"
        txtHtml = txtHtml & vbCrLf & "              document.getElementById('address2').textContent = address2;"
        txtHtml = txtHtml & vbCrLf & "              document.getElementById('address3').textContent = address3;"
        txtHtml = txtHtml & vbCrLf & ""
        txtHtml = txtHtml & vbCrLf & "              // マーカーの表示"
        txtHtml = txtHtml & vbCrLf & "              new google.maps.InfoWindow({"
        txtHtml = txtHtml & vbCrLf & "                content : ""住所　　　：〒"" + postCode + ""<br/>　　　　　　"" + address1 + address2 + address3 + ""<br>緯度・経度："" + latlng"
        txtHtml = txtHtml & vbCrLf & "              }).open(map, marker = new google.maps.Marker({"
        txtHtml = txtHtml & vbCrLf & "                position : latlng,"
        txtHtml = txtHtml & vbCrLf & "                map      : map,"
        txtHtml = txtHtml & vbCrLf & "                icon     : {"
        txtHtml = txtHtml & vbCrLf & "                  url      : 'https://maps.google.com/mapfiles/ms/icons/blue-dot.png'"
        txtHtml = txtHtml & vbCrLf & "                }"
        txtHtml = txtHtml & vbCrLf & "              }));"
        txtHtml = txtHtml & vbCrLf & "            }"
        txtHtml = txtHtml & vbCrLf & "          } else if (status == google.maps.GeocoderStatus.ERROR) {"
        txtHtml = txtHtml & vbCrLf & "            alert(""サーバとの通信時に何らかのエラーが発生！"");"
        txtHtml = txtHtml & vbCrLf & "          } else if (status == google.maps.GeocoderStatus.INVALID_REQUEST) {"
        txtHtml = txtHtml & vbCrLf & "            alert(""リクエストに問題アリ！geocode()に渡すGeocoderRequestを確認せよ！！"");"
        txtHtml = txtHtml & vbCrLf & "          } else if (status == google.maps.GeocoderStatus.OVER_QUERY_LIMIT) {"
        txtHtml = txtHtml & vbCrLf & "            alert(""短時間にクエリを送りすぎ！落ち着いて！！"");"
        txtHtml = txtHtml & vbCrLf & "          } else if (status == google.maps.GeocoderStatus.REQUEST_DENIED) {"
        txtHtml = txtHtml & vbCrLf & "            alert(""このページではジオコーダの利用が許可されていない！・・・なぜ！？"");"
        txtHtml = txtHtml & vbCrLf & "          } else if (status == google.maps.GeocoderStatus.UNKNOWN_ERROR) {"
        txtHtml = txtHtml & vbCrLf & "            alert(""サーバ側でなんらかのトラブルが発生した模様。再挑戦されたし。"");"
        txtHtml = txtHtml & vbCrLf & "          } else if (status == google.maps.GeocoderStatus.ZERO_RESULTS) {"
        txtHtml = txtHtml & vbCrLf & "            alert(""見つかりません"");"
        txtHtml = txtHtml & vbCrLf & "          } else {"
        txtHtml = txtHtml & vbCrLf & "            alert(""えぇ～っと・・、バージョンアップ？"");"
        txtHtml = txtHtml & vbCrLf & "          }"
        txtHtml = txtHtml & vbCrLf & "        });"
        txtHtml = txtHtml & vbCrLf & "      }"
        txtHtml = txtHtml & vbCrLf & "    }"
        txtHtml = txtHtml & vbCrLf & "  </script>"
        txtHtml = txtHtml & vbCrLf & "  </head>"
        txtHtml = txtHtml & vbCrLf & "  <body onload=""initMap()"">"
        txtHtml = txtHtml & vbCrLf & "    <table border='1' style=""display:none;"">"
        txtHtml = txtHtml & vbCrLf & "    <!--<table border='1'>-->"
        txtHtml = txtHtml & vbCrLf & "      <th>"
        txtHtml = txtHtml & vbCrLf & "        <td>名称</td>"
        txtHtml = txtHtml & vbCrLf & "        <td>郵便番号</td>"
        txtHtml = txtHtml & vbCrLf & "        <td>住所1</td>"
        txtHtml = txtHtml & vbCrLf & "        <td>住所2</td>"
        txtHtml = txtHtml & vbCrLf & "        <td>住所3</td>"
        txtHtml = txtHtml & vbCrLf & "        <td>緯度</td>"
        txtHtml = txtHtml & vbCrLf & "        <td>経度</td>"
        txtHtml = txtHtml & vbCrLf & "      </th>"
        txtHtml = txtHtml & vbCrLf & "      <tr>"
        txtHtml = txtHtml & vbCrLf & "        <td>地図選択</td>"
        txtHtml = txtHtml & vbCrLf & "        <td></span></td>"
        txtHtml = txtHtml & vbCrLf & "        <td><span id=""postCode""></span></td>"
        txtHtml = txtHtml & vbCrLf & "        <td><span id=""address1""></span></td>"
        txtHtml = txtHtml & vbCrLf & "        <td><span id=""address2""></span></td>"
        txtHtml = txtHtml & vbCrLf & "        <td><span id=""address3""></span></td>"
        txtHtml = txtHtml & vbCrLf & "        <td><span id=""lat""></span></td>"
        txtHtml = txtHtml & vbCrLf & "        <td><span id=""lng""></span></td>"
        txtHtml = txtHtml & vbCrLf & "      </tr>"
        txtHtml = txtHtml & vbCrLf & "      <tr>"
        txtHtml = txtHtml & vbCrLf & "        <td>マーカー選択</td>"
        txtHtml = txtHtml & vbCrLf & "        <td><span id=""bukkenNo""></span></td>"
        txtHtml = txtHtml & vbCrLf & "        <td></span></td>"
        txtHtml = txtHtml & vbCrLf & "        <td></span></td>"
        txtHtml = txtHtml & vbCrLf & "        <td></span></td>"
        txtHtml = txtHtml & vbCrLf & "        <td></span></td>"
        txtHtml = txtHtml & vbCrLf & "        <td></span></td>"
        txtHtml = txtHtml & vbCrLf & "        <td></span></td>"
        txtHtml = txtHtml & vbCrLf & "      </tr>"
        txtHtml = txtHtml & vbCrLf & "    </table>"
        txtHtml = txtHtml & vbCrLf & "    <div id=""map_canvas"" style=""width:100%; height:100%""></div>"
        txtHtml = txtHtml & vbCrLf & "  </body>"
        txtHtml = txtHtml & vbCrLf & "</html>"

        GoogleMap = txtHtml
    End Function

    ''' <summary>
    ''' マーカーの作成
    ''' </summary>
    Private Function CreateMakerRed(
              ByVal idx As Integer _
            , ByVal bukkenNo As String _
            , ByVal lat As String _
            , ByVal lng As String _
            , ByVal bukkenName As String _
            , ByVal postNo As String _
            , ByVal address As String _
            , ByVal clickEventFlg As Boolean
            ) As String
        Dim txtHtml As String = ""

        txtHtml = txtHtml & vbCrLf & "        // マーカーの表示"
        txtHtml = txtHtml & vbCrLf & "        latlng = new google.maps.LatLng(" & lat & ", " & lng & ");"
        txtHtml = txtHtml & vbCrLf & ""
        txtHtml = txtHtml & vbCrLf & "        makerView[" & idx & "] = new google.maps.Marker({"
        txtHtml = txtHtml & vbCrLf & "          position : latlng,"
        txtHtml = txtHtml & vbCrLf & "          map      : map"
        txtHtml = txtHtml & vbCrLf & "        });"
        txtHtml = txtHtml & vbCrLf & "        makerView[" & idx & "].setIcon('https://maps.google.com/mapfiles/ms/icons/red-dot.png');"
        txtHtml = txtHtml & vbCrLf & ""
        If clickEventFlg Then
            txtHtml = txtHtml & vbCrLf & "        // マーカー　クリックイベント"
            txtHtml = txtHtml & vbCrLf & "        google.maps.event.addListener(makerView[" & idx & "], 'click', function() {"
            txtHtml = txtHtml & vbCrLf & "          // 選択したマーカーの値を保持"
            txtHtml = txtHtml & vbCrLf & "          document.getElementById('bukkenNo').textContent = """ & bukkenNo & """;"
            txtHtml = txtHtml & vbCrLf & "          // マーカーの色を変える"
            txtHtml = txtHtml & vbCrLf & "          changeMarkerImage(" & idx & ");"
            txtHtml = txtHtml & vbCrLf & "        });"
            txtHtml = txtHtml & vbCrLf & ""
        End If
        txtHtml = txtHtml & vbCrLf & "        // マーカー　情報ウィンドウの作成"
        txtHtml = txtHtml & vbCrLf & "        infowin[" & idx & "] = new google.maps.InfoWindow({"
        txtHtml = txtHtml & vbCrLf & "          content : """
        If NUCheck(bukkenNo) Then
            txtHtml = txtHtml & "物件Ｎｏ　：<br/>"
        Else
            txtHtml = txtHtml & "物件Ｎｏ　：" & ZeroPadding(bukkenNo, 10) & "<br/>"
        End If
        txtHtml = txtHtml & "物件名　　：" & bukkenName & "<br/>"
        txtHtml = txtHtml & "住所　　　：〒" & postNo & "<br/>"
        txtHtml = txtHtml & "　　　　　　" & address & "<br>"
        txtHtml = txtHtml & "緯度・経度：" & lat & ", " & lng & """"
        txtHtml = txtHtml & vbCrLf & "        });"
        txtHtml = txtHtml & vbCrLf & ""
        txtHtml = txtHtml & vbCrLf & "        google.maps.event.addListener(makerView[" & idx & "], 'mouseover', function() {"
        txtHtml = txtHtml & vbCrLf & "          infowin[" & idx & "].open(map, makerView[" & idx & "]);"
        txtHtml = txtHtml & vbCrLf & "        });"
        txtHtml = txtHtml & vbCrLf & ""
        txtHtml = txtHtml & vbCrLf & "        google.maps.event.addListener(makerView[" & idx & "], 'mouseout', function() {"
        txtHtml = txtHtml & vbCrLf & "          infowin[" & idx & "].close();"
        txtHtml = txtHtml & vbCrLf & "        });"

        Return txtHtml
    End Function

    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)

        Select Case e.Name

            Case "終了"

                Me.Close()

                Exit Sub

            Case "選択"

                If praDispKbn = emumDispKbn.PLOT Then
                    'プロットの場合

                    '工事場所の反映先の選択なしの場合
                    If Not chkPostNo.Checked AndAlso Not chkAddress.Checked AndAlso Not chkLatLng.Checked Then
                        MessageBoxEx.Show(MessageCode_Arg0.M219, PROGRAM_NAME)
                        Return
                    End If

                    'マーカーの選択なしの場合
                    If NUCheck(WebBrowser1.Document.GetElementById("lat").InnerText) Then
                        MessageBoxEx.Show(MessageCode_Arg0.M232, PROGRAM_NAME)
                        Return
                    End If

                    '確認メッセージ
                    If MessageBoxEx.Show(MessageCode_Arg0.M231, PROGRAM_NAME) = DialogResult.No Then
                        Return
                    End If

                    '戻り値をセット
                    If chkPostNo.Checked Then
                        responseMAP0001.RESPONSE_FLAG_POST_NO = True
                        responseMAP0001.POST_NO = WebBrowser1.Document.GetElementById("postCode").InnerText
                    End If

                    If chkAddress.Checked Then
                        responseMAP0001.RESPONSE_FLAG_ADDRESS = True
                        responseMAP0001.ADDRESS = WebBrowser1.Document.GetElementById("address1").InnerText
                        responseMAP0001.ADDRESS1 = WebBrowser1.Document.GetElementById("address2").InnerText
                        responseMAP0001.ADDRESS2 = WebBrowser1.Document.GetElementById("address3").InnerText
                    End If

                    If chkLatLng.Checked Then
                        responseMAP0001.RESPONSE_FLAG_LAT_LNG = True
                        responseMAP0001.LAT = Decimal.Parse(WebBrowser1.Document.GetElementById("lat").InnerText).ToString("##.#######")
                        responseMAP0001.LNG = Decimal.Parse(WebBrowser1.Document.GetElementById("lng").InnerText).ToString("##.#######")
                    End If

                    '呼び出し元の再表示
                    CType(ownerForm, frmBUK0001).responseMAP0001 = responseMAP0001
                    CType(ownerForm, frmBUK0001).ShowReDispMAP0001()

                    Me.Close()

                Else
                    '検索の場合

                    'マーカーの選択なしの場合
                    If NUCheck(WebBrowser1.Document.GetElementById("bukkenNo").InnerText) Then
                        MessageBoxEx.Show(MessageCode_Arg0.M220, PROGRAM_NAME)
                        Return
                    End If

                    Dim f = New frmBUK0001()
                    f.requestBUK0001.BUKKEN_NO = WebBrowser1.Document.GetElementById("bukkenNo").InnerText
                    f.ShowDisp(Me)
                End If

                Exit Sub
        End Select

    End Sub

    Private Sub btnSANSYO_Click(sender As Object, e As EventArgs) Handles btnSANSYO.Click

        With requestMAP0001.BUKKEN_NONE_LAT_LNG_LIST(0)
            If .RECODE_COUNT > .RECODE_COUNT_JYOGEN Then
                MessageBoxEx.Show(CommonUtility.MessageCode_Arg2.M211, .RECODE_COUNT.ToString, .RECODE_COUNT_JYOGEN.ToString, "物件検索（マップ）")
            End If
        End With

        '物件検索（経度・緯度未登録一覧）画面の表示
        Dim f As New frmMAP0001_SUB1()
        f.requestMAP0001 = requestMAP0001
        f.ShowDispDialog(Me)
    End Sub
End Class