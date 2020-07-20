Imports System.IO
Imports System.Text
Imports System.Collections
Imports System.Net
Imports System.Xml

Public Class Main
    Public Overrides Function PROGRAM_ID() As String
        Return "MAP"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "マップ"
    End Function

    Protected Overrides Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WebBrowser1.DocumentText = GoogleMap(0)

        'ファンクションキーの設定
        For intIndex As Integer = 1 To 12
            FunctionKey.SetItem(intIndex, "", "", False, New System.Drawing.Font("メイリオ", 12))
        Next

        FunctionKey.SetItem(1, "表示", "表示", True)
        FunctionKey.SetItem(12, "登録", "登録", True)

        'イベントの定義
        AddHandler btnHanei.Click, AddressOf btnHanei_Click
        AddHandler btnChangeIoction.Click, AddressOf btnChangeIoction_Click
    End Sub

    'GoogleMapの表示
    'mode : （0：初期表示、1：表示ボタン押下）
    Private Function GoogleMap(ByRef mode As Integer) As String

        Dim txtHtml As String = ""
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
        txtHtml = txtHtml & vbCrLf & "          lat: 34.8591225,  // 緯度"
        txtHtml = txtHtml & vbCrLf & "          lng: 134.5299544  // 経度"
        txtHtml = txtHtml & vbCrLf & "        },"
        txtHtml = txtHtml & vbCrLf & "          zoom: 10              // 地図のズームを指定"
        txtHtml = txtHtml & vbCrLf & "      };"
        txtHtml = txtHtml & vbCrLf & "      map = new google.maps.Map(document.getElementById(""map_canvas""), myOptions);"
        txtHtml = txtHtml & vbCrLf & ""
        txtHtml = txtHtml & vbCrLf & "      // クリックイベント"
        txtHtml = txtHtml & vbCrLf & "      map.addListener('click', function(e) {"
        txtHtml = txtHtml & vbCrLf & "        getClickLatLng(e.latLng, map);"
        txtHtml = txtHtml & vbCrLf & ""
        txtHtml = txtHtml & vbCrLf & "        if (marker) {"
        txtHtml = txtHtml & vbCrLf & "          marker.setMap(null);"
        txtHtml = txtHtml & vbCrLf & "        }"
        txtHtml = txtHtml & vbCrLf & "      });"
        If mode = 1 Then
            Dim al As New ArrayList
            Dim line As String = ""
            Dim array() As String
            Dim idx As Integer = 0

            Using sr As StreamReader = New StreamReader("C:\Temp\BUP_TEST_ADDRESS.txt", Encoding.GetEncoding("Shift_JIS"))

                txtHtml = txtHtml & vbCrLf & "        // マーカーを設定"
                txtHtml = txtHtml & vbCrLf & "        var latlng;"

                line = sr.ReadLine()
                Do Until line Is Nothing
                    array = line.Split(CChar(","))

                    txtHtml = txtHtml & vbCrLf & "      // マーカーの表示"
                    txtHtml = txtHtml & vbCrLf & "      latlng = new google.maps.LatLng(" & array(0) & ", " & array(1) & ");"
                    txtHtml = txtHtml & vbCrLf & ""
                    txtHtml = txtHtml & vbCrLf & "      makerView[" & idx & "] = new google.maps.Marker({"
                    txtHtml = txtHtml & vbCrLf & "        position : latlng,"
                    txtHtml = txtHtml & vbCrLf & "        map      : map"
                    txtHtml = txtHtml & vbCrLf & "      });"
                    txtHtml = txtHtml & vbCrLf & "      makerView[" & idx & "].setIcon('https://maps.google.com/mapfiles/ms/icons/red-dot.png');"
                    txtHtml = txtHtml & vbCrLf & ""
                    txtHtml = txtHtml & vbCrLf & "      google.maps.event.addListener(makerView[" & idx & "], 'click', function() {"
                    txtHtml = txtHtml & vbCrLf & "        document.getElementById('name_maker').textContent = """ & array(2) & """;"
                    txtHtml = txtHtml & vbCrLf & "        changeMarkerImage(" & idx & ");"
                    txtHtml = txtHtml & vbCrLf & "      });"
                    txtHtml = txtHtml & vbCrLf & ""
                    txtHtml = txtHtml & vbCrLf & "      infowin[" & idx & "] = new google.maps.InfoWindow({content:""" & array(2) & "<br/>" & array(3) & """});"
                    txtHtml = txtHtml & vbCrLf & ""
                    txtHtml = txtHtml & vbCrLf & "      google.maps.event.addListener(makerView[" & idx & "], 'mouseover', function() {"
                    txtHtml = txtHtml & vbCrLf & "        infowin[" & idx & "].open(map, makerView[" & idx & "]);"
                    txtHtml = txtHtml & vbCrLf & "      });"
                    txtHtml = txtHtml & vbCrLf & ""
                    txtHtml = txtHtml & vbCrLf & "      google.maps.event.addListener(makerView[" & idx & "], 'mouseout', function() {"
                    txtHtml = txtHtml & vbCrLf & "        infowin[" & idx & "].close();"
                    txtHtml = txtHtml & vbCrLf & "      });"

                    idx = idx + 1

                    line = sr.ReadLine()
                Loop
            End Using
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
        txtHtml = txtHtml & vbCrLf & "                content : ""〒"" + postCode + ""<br/>"" + address1 + address2 + address3 + ""<br>経度・緯度"" + latlng"
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
        txtHtml = txtHtml & vbCrLf & "    <!--<table border='1' style=""display:none;"">-->"
        txtHtml = txtHtml & vbCrLf & "    <table border='1'>"
        txtHtml = txtHtml & vbCrLf & "      <th>"
        txtHtml = txtHtml & vbCrLf & "        <td>名称</td>"
        txtHtml = txtHtml & vbCrLf & "        <td>郵便番号</td>"
        txtHtml = txtHtml & vbCrLf & "        <td>住所1</td>"
        txtHtml = txtHtml & vbCrLf & "        <td>住所2</td>"
        txtHtml = txtHtml & vbCrLf & "        <td>住所3</td>"
        txtHtml = txtHtml & vbCrLf & "        <td>経度</td>"
        txtHtml = txtHtml & vbCrLf & "        <td>緯度</td>"
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
        txtHtml = txtHtml & vbCrLf & "        <td><span id=""name_maker""></span></td>"
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

    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)

        Select Case e.Name

            Case "表示"

                WebBrowser1.DocumentText = GoogleMap(1)

            Case "登録"

                Dim sjisEnc As Encoding = Encoding.GetEncoding("Shift_JIS")
                Dim writer As StreamWriter = New StreamWriter("C:\Temp\BUP_TEST_ADDRESS.txt", True, sjisEnc)
                Dim lat As String = WebBrowser1.Document.GetElementById("lat").InnerText
                Dim lng As String = WebBrowser1.Document.GetElementById("lng").InnerText

                writer.WriteLine(txtLat.Text & "," & txtLng.Text & "," & txtName.Text & "," & txtAddress1.Text)
                writer.Close()

        End Select

    End Sub

    Private Sub btnHanei_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtPostCode.Text = WebBrowser1.Document.GetElementById("postCode").InnerText
        txtAddress1.Text = WebBrowser1.Document.GetElementById("address1").InnerText
        txtAddress2.Text = WebBrowser1.Document.GetElementById("address2").InnerText
        txtAddress3.Text = WebBrowser1.Document.GetElementById("address3").InnerText
        txtLat.Text = WebBrowser1.Document.GetElementById("lat").InnerText
        txtLng.Text = WebBrowser1.Document.GetElementById("lng").InnerText
    End Sub

    Private Sub btnChangeIoction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim req As HttpWebRequest
        Dim res As WebResponse
        Dim stream As Stream
        Dim streamRead As StreamReader
        Dim xmlDoc As XmlDocument
        Dim xmlStr As String
        Dim url As String
        Dim S_API_KEY = New BLL.Common.S_API_KEYRead

        If txtAddress1.Text = "" Then
            Exit Sub
        End If

        'Google Geocoding API
        url = ""
        url = url + "https://maps.google.com/maps/api/geocode/xml"
        url = url + "?key=" + S_API_KEY.GetData
        url = url + "&address=" + txtAddress1.Text
        'Request生成
        req = DirectCast(WebRequest.Create(url), System.Net.HttpWebRequest)
        'Response取得
        res = req.GetResponse()
        'Stream取得
        stream = res.GetResponseStream
        'StreamReader生成
        streamRead = New StreamReader(stream)
        '緯度、経度を表示
        xmlStr = streamRead.ReadToEnd()
        xmlDoc = New XmlDocument()
        xmlDoc.LoadXml(xmlStr)
        If xmlDoc.Item("GeocodeResponse").Item("status").InnerText = "OK" Then
            txtLat.Text = xmlDoc.Item("GeocodeResponse").Item("result").Item("geometry").Item("location").Item("lat").InnerText
            txtLng.Text = xmlDoc.Item("GeocodeResponse").Item("result").Item("geometry").Item("location").Item("lng").InnerText
        Else
            MsgBox("経度・緯度が取得できません。")
        End If
        'クローズ
        streamRead.Close()
        stream.Close()
        res.Close()
    End Sub
End Class