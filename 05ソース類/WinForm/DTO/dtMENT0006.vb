Public Class dtBUK0004
    Public Class dtMENT0006

        '検索メニュー使用変数
        Public Const MENU_VALUE_COUNT As Integer = 10               '最大フィールド数

        '仕入先分類情報登録で登録したか判別
        Public pblnSiiBunUpdFlg As Boolean
        Public Property m_pblnSiiBunUpdFlg() As Boolean
            Get
                Return pblnSiiBunUpdFlg
            End Get
            Set(ByVal value As Boolean)
                pblnSiiBunUpdFlg = value
            End Set
        End Property

        '委託コードが変更されているかチェック(初期値格納)
        Public pstrItakuChk As String
        Public Property m_pstrItakuChk() As String
            Get
                Return pstrItakuChk
            End Get
            Set(ByVal value As String)
                pstrItakuChk = value
            End Set
        End Property

        'マスタ名・戻り値など
        Public sstrMenuValue(MENU_VALUE_COUNT) As String
        Public Property m_sstrMenuValue() As String
            Get
                Return sstrMenuValue(MENU_VALUE_COUNT)
            End Get
            Set(ByVal value As String)
                sstrMenuValue(MENU_VALUE_COUNT) = value
            End Set
        End Property

        Public SlabelUpdateflg As Boolean
        Public Property slabelUpdate_bln() As Boolean
            Get
                Return SlabelUpdateflg
            End Get
            Set(ByVal value As Boolean)
                SlabelUpdateflg = value
            End Set
        End Property

        Public siirecode_label As String
        Public Property KeySiireCode() As String
            Get
                Return siirecode_label
            End Get
            Set(ByVal value As String)
                siirecode_label = value
            End Set
        End Property

        '---マスタ更新用---

        Private m_SIIRECODE As String
        Public Property SIIRECODE() As String
            Get
                Return m_SIIRECODE
            End Get
            Set(ByVal value As String)
                m_SIIRECODE = value
            End Set
        End Property

        Private m_SIIRENAME As String
        Public Property SIIRENAME() As String
            Get
                Return m_SIIRENAME
            End Get
            Set(ByVal value As String)
                m_SIIRENAME = value
            End Set
        End Property

        Private m_RYAKUNAME As String
        Public Property RYAKUNAME() As String
            Get
                Return m_RYAKUNAME
            End Get
            Set(ByVal value As String)
                m_RYAKUNAME = value
            End Set
        End Property

        Private m_MENUKEY As String
        Public Property MENUKEY() As String
            Get
                Return m_MENUKEY
            End Get
            Set(ByVal value As String)
                m_MENUKEY = value
            End Set
        End Property

        Private m_POSTNO As String
        Public Property POSTNO() As String
            Get
                Return m_POSTNO
            End Get
            Set(ByVal value As String)
                m_POSTNO = value
            End Set
        End Property

        Private m_ADDRESS As String
        Public Property ADDRESS() As String
            Get
                Return m_ADDRESS
            End Get
            Set(ByVal value As String)
                m_ADDRESS = value
            End Set
        End Property

        Private m_ADDRESS1 As String
        Public Property ADDRESS1() As String
            Get
                Return m_ADDRESS1
            End Get
            Set(ByVal value As String)
                m_ADDRESS1 = value
            End Set
        End Property

        Private m_ADDRESS2 As String
        Public Property ADDRESS2() As String
            Get
                Return m_ADDRESS2
            End Get
            Set(ByVal value As String)
                m_ADDRESS2 = value
            End Set
        End Property

        Private m_ITAKUCODE As String
        Public Property ITAKUCODE() As String
            Get
                Return m_ITAKUCODE
            End Get
            Set(ByVal value As String)
                m_ITAKUCODE = value
            End Set
        End Property

        Private m_MAILADDRESS As String
        Public Property MAILADDRESS() As String
            Get
                Return m_MAILADDRESS
            End Get
            Set(ByVal value As String)
                m_MAILADDRESS = value
            End Set
        End Property

        Private m_MAILACCOUNT As String
        Public Property MAILACCOUNT() As String
            Get
                Return m_MAILACCOUNT
            End Get
            Set(ByVal value As String)
                m_MAILACCOUNT = value
            End Set
        End Property

        Private m_MAILDOMAINNAME As String
        Public Property MAILDOMAINNAME() As String
            Get
                Return m_MAILDOMAINNAME
            End Get
            Set(ByVal value As String)
                m_MAILDOMAINNAME = value
            End Set
        End Property

        Private m_MAILSENDFLG As String
        Public Property MAILSENDFLG() As String
            Get
                Return m_MAILSENDFLG
            End Get
            Set(ByVal value As String)
                m_MAILSENDFLG = value
            End Set
        End Property

        Private m_MAILADDRESS1 As String
        Public Property MAILADDRESS1() As String
            Get
                Return m_MAILADDRESS1
            End Get
            Set(ByVal value As String)
                m_MAILADDRESS1 = value
            End Set
        End Property

        Private m_MAILACCOUNT1 As String
        Public Property MAILACCOUNT1() As String
            Get
                Return m_MAILACCOUNT1
            End Get
            Set(ByVal value As String)
                m_MAILACCOUNT1 = value
            End Set
        End Property

        Private m_MAILDOMAINNAME1 As String
        Public Property MAILDOMAINNAME1() As String
            Get
                Return m_MAILDOMAINNAME1
            End Get
            Set(ByVal value As String)
                m_MAILDOMAINNAME1 = value
            End Set
        End Property

        Private m_MAILSENDFLG1 As String
        Public Property MAILSENDFLG1() As String
            Get
                Return m_MAILSENDFLG1
            End Get
            Set(ByVal value As String)
                m_MAILSENDFLG1 = value
            End Set
        End Property

        Private m_MAILDISPFLG As String
        Public Property MAILDISPFLG() As String
            Get
                Return m_MAILDISPFLG
            End Get
            Set(ByVal value As String)
                m_MAILDISPFLG = value
            End Set
        End Property

        Private m_MAILTANKADISPFLG As String
        Public Property MAILTANKADISPFLG() As String
            Get
                Return m_MAILTANKADISPFLG
            End Get
            Set(ByVal value As String)
                m_MAILTANKADISPFLG = value
            End Set
        End Property

        Private m_MAILSENDOBJECTKBN As String
        Public Property MAILSENDOBJECTKBN() As String
            Get
                Return m_MAILSENDOBJECTKBN
            End Get
            Set(ByVal value As String)
                m_MAILSENDOBJECTKBN = value
            End Set
        End Property

        Private m_PRICEPRIKBN As String
        Public Property PRICEPRIKBN() As String
            Get
                Return m_PRICEPRIKBN
            End Get
            Set(ByVal value As String)
                m_PRICEPRIKBN = value
            End Set
        End Property

        Private m_LABEL_NAME As String
        Public Property LABEL_NAME() As String
            Get
                Return m_LABEL_NAME
            End Get
            Set(ByVal value As String)
                m_LABEL_NAME = value
            End Set
        End Property

        Private m_LABEL_TELNO As String
        Public Property LABEL_TELNO() As String
            Get
                Return m_LABEL_TELNO
            End Get
            Set(ByVal value As String)
                m_LABEL_TELNO = value
            End Set
        End Property

        Private m_TELNO As String
        Public Property TELNO() As String
            Get
                Return m_TELNO
            End Get
            Set(ByVal value As String)
                m_TELNO = value
            End Set
        End Property

        Private m_FAXNO As String
        Public Property FAXNO() As String
            Get
                Return m_FAXNO
            End Get
            Set(ByVal value As String)
                m_FAXNO = value
            End Set
        End Property

        Private m_TELNO_K As String
        Public Property TELNO_K() As String
            Get
                Return m_TELNO_K
            End Get
            Set(ByVal value As String)
                m_TELNO_K = value
            End Set
        End Property

        Private m_GINKOU As String
        Public Property GINKOU() As String
            Get
                Return m_GINKOU
            End Get
            Set(ByVal value As String)
                m_GINKOU = value
            End Set
        End Property

        Private m_BANKCODE As String
        Public Property BANKCODE() As String
            Get
                Return m_BANKCODE
            End Get
            Set(ByVal value As String)
                m_BANKCODE = value
            End Set
        End Property

        Private m_BANKSUBCODE As String
        Public Property BANKSUBCODE() As String
            Get
                Return m_BANKSUBCODE
            End Get
            Set(ByVal value As String)
                m_BANKSUBCODE = value
            End Set
        End Property

        Private m_BANKKOUZAKBN As String
        Public Property BANKKOUZAKBN() As String
            Get
                Return m_BANKKOUZAKBN
            End Get
            Set(ByVal value As String)
                m_BANKKOUZAKBN = value
            End Set
        End Property

        Private m_KOUZA As String
        Public Property KOUZA() As String
            Get
                Return m_KOUZA
            End Get
            Set(ByVal value As String)
                m_KOUZA = value
            End Set
        End Property

        Private m_BANKMEIGI As String
        Public Property BANKMEIGI() As String
            Get
                Return m_BANKMEIGI
            End Get
            Set(ByVal value As String)
                m_BANKMEIGI = value
            End Set
        End Property

        Private m_BANKMEIGIKANA As String
        Public Property BANKMEIGIKANA() As String
            Get
                Return m_BANKMEIGIKANA
            End Get
            Set(ByVal value As String)
                m_BANKMEIGIKANA = value
            End Set
        End Property

        Private m_LOCALCODE As String
        Public Property LOCALCODE() As String
            Get
                Return m_LOCALCODE
            End Get
            Set(ByVal value As String)
                m_LOCALCODE = value
            End Set
        End Property

        Private m_TANKACODE As String
        Public Property TANKACODE() As String
            Get
                Return m_TANKACODE
            End Get
            Set(ByVal value As String)
                m_TANKACODE = value
            End Set
        End Property

        Private m_TANKANAME As String
        Public Property TANKANAME() As String
            Get
                Return m_TANKANAME
            End Get
            Set(ByVal value As String)
                m_TANKANAME = value
            End Set
        End Property

        Private m_SIHARAICODE As String
        Public Property SIHARAICODE() As String
            Get
                Return m_SIHARAICODE
            End Get
            Set(ByVal value As String)
                m_SIHARAICODE = value
            End Set
        End Property

        Private m_SOSINCODE As String
        Public Property SOSINCODE() As String
            Get
                Return m_SOSINCODE
            End Get
            Set(ByVal value As String)
                m_SOSINCODE = value
            End Set
        End Property

        Private m_TANTOCODE As String
        Public Property TANTOCODE() As String
            Get
                Return m_TANTOCODE
            End Get
            Set(ByVal value As String)
                m_TANTOCODE = value
            End Set
        End Property

        Private m_SIMEBI1 As String
        Public Property SIMEBI1() As String
            Get
                Return m_SIMEBI1
            End Get
            Set(ByVal value As String)
                m_SIMEBI1 = value
            End Set
        End Property

        Private m_SIMEBI2 As String
        Public Property SIMEBI2() As String
            Get
                Return m_SIMEBI2
            End Get
            Set(ByVal value As String)
                m_SIMEBI2 = value
            End Set
        End Property

        Private m_SIMEBI3 As String
        Public Property SIMEBI3() As String
            Get
                Return m_SIMEBI3
            End Get
            Set(ByVal value As String)
                m_SIMEBI3 = value
            End Set
        End Property

        Private m_SIHARAIKBN1 As String
        Public Property SIHARAIKBN1() As String
            Get
                Return m_SIHARAIKBN1
            End Get
            Set(ByVal value As String)
                m_SIHARAIKBN1 = value
            End Set
        End Property

        Private m_SIHARAIKBN2 As String
        Public Property SIHARAIKBN2() As String
            Get
                Return m_SIHARAIKBN2
            End Get
            Set(ByVal value As String)
                m_SIHARAIKBN2 = value
            End Set
        End Property

        Private m_SIHARAIKBN3 As String
        Public Property SIHARAIKBN3() As String
            Get
                Return m_SIHARAIKBN3
            End Get
            Set(ByVal value As String)
                m_SIHARAIKBN3 = value
            End Set
        End Property

        Private m_SIHARAIBI1 As String
        Public Property SIHARAIBI1() As String
            Get
                Return m_SIHARAIBI1
            End Get
            Set(ByVal value As String)
                m_SIHARAIBI1 = value
            End Set
        End Property

        Private m_SIHARAIBI2 As String
        Public Property SIHARAIBI2() As String
            Get
                Return m_SIHARAIBI2
            End Get
            Set(ByVal value As String)
                m_SIHARAIBI2 = value
            End Set
        End Property

        Private m_SIHARAIBI3 As String
        Public Property SIHARAIBI3() As String
            Get
                Return m_SIHARAIBI3
            End Get
            Set(ByVal value As String)
                m_SIHARAIBI3 = value
            End Set
        End Property

        Private m_SEISANTINAME As String
        Public Property SEISANTINAME() As String
            Get
                Return m_SEISANTINAME
            End Get
            Set(ByVal value As String)
                m_SEISANTINAME = value
            End Set
        End Property

        Private m_ZEIROUND As String
        Public Property ZEIROUND() As String
            Get
                Return m_ZEIROUND
            End Get
            Set(ByVal value As String)
                m_ZEIROUND = value
            End Set
        End Property

        Private m_SUROUND As String
        Public Property SUROUND() As String
            Get
                Return m_SUROUND
            End Get
            Set(ByVal value As String)
                m_SUROUND = value
            End Set
        End Property

        Private m_KINROUND As String
        Public Property KINROUND() As String
            Get
                Return m_KINROUND
            End Get
            Set(ByVal value As String)
                m_KINROUND = value
            End Set
        End Property

        Private m_SYOHIZEIKBN As String
        Public Property SYOHIZEIKBN() As String
            Get
                Return m_SYOHIZEIKBN
            End Get
            Set(ByVal value As String)
                m_SYOHIZEIKBN = value
            End Set
        End Property

        Private m_ZANKANRIKBN As String
        Public Property ZANKANRIKBN() As String
            Get
                Return m_ZANKANRIKBN
            End Get
            Set(ByVal value As String)
                m_ZANKANRIKBN = value
            End Set
        End Property

        Private m_GENKAKAKIKAEKBN As String
        Public Property GENKAKAKIKAEKBN() As String
            Get
                Return m_GENKAKAKIKAEKBN
            End Get
            Set(ByVal value As String)
                m_GENKAKAKIKAEKBN = value
            End Set
        End Property

        Private m_ZEIKBN As String
        Public Property ZEIKBN() As String
            Get
                Return m_ZEIKBN
            End Get
            Set(ByVal value As String)
                m_ZEIKBN = value
            End Set
        End Property

        Private m_SOSINFLG As String
        Public Property SOSINFLG() As String
            Get
                Return m_SOSINFLG
            End Get
            Set(ByVal value As String)
                m_SOSINFLG = value
            End Set
        End Property

        Private m_TESURITU_1 As String
        Public Property TESURITU_1() As String
            Get
                Return m_TESURITU_1
            End Get
            Set(ByVal value As String)
                m_TESURITU_1 = value
            End Set
        End Property

        Private m_TESURITU_2 As String
        Public Property TESURITU_2() As String
            Get
                Return m_TESURITU_2
            End Get
            Set(ByVal value As String)
                m_TESURITU_2 = value
            End Set
        End Property

        Private m_YOSAN01 As String
        Public Property YOSAN01() As String
            Get
                Return m_YOSAN01
            End Get
            Set(ByVal value As String)
                m_YOSAN01 = value
            End Set
        End Property

        Private m_YOSAN02 As String
        Public Property YOSAN02() As String
            Get
                Return m_YOSAN02
            End Get
            Set(ByVal value As String)
                m_YOSAN02 = value
            End Set
        End Property

        Private m_YOSAN03 As String
        Public Property YOSAN03() As String
            Get
                Return m_YOSAN03
            End Get
            Set(ByVal value As String)
                m_YOSAN03 = value
            End Set
        End Property

        Private m_YOSAN04 As String
        Public Property YOSAN04() As String
            Get
                Return m_YOSAN04
            End Get
            Set(ByVal value As String)
                m_YOSAN04 = value
            End Set
        End Property

        Private m_YOSAN05 As String
        Public Property YOSAN05() As String
            Get
                Return m_YOSAN05
            End Get
            Set(ByVal value As String)
                m_YOSAN05 = value
            End Set
        End Property

        Private m_YOSAN06 As String
        Public Property YOSAN06() As String
            Get
                Return m_YOSAN06
            End Get
            Set(ByVal value As String)
                m_YOSAN06 = value
            End Set
        End Property

        Private m_YOSAN07 As String
        Public Property YOSAN07() As String
            Get
                Return m_YOSAN07
            End Get
            Set(ByVal value As String)
                m_YOSAN07 = value
            End Set
        End Property

        Private m_YOSAN08 As String
        Public Property YOSAN08() As String
            Get
                Return m_YOSAN08
            End Get
            Set(ByVal value As String)
                m_YOSAN08 = value
            End Set
        End Property

        Private m_YOSAN09 As String
        Public Property YOSAN09() As String
            Get
                Return m_YOSAN09
            End Get
            Set(ByVal value As String)
                m_YOSAN09 = value
            End Set
        End Property

        Private m_YOSAN10 As String
        Public Property YOSAN10() As String
            Get
                Return m_YOSAN10
            End Get
            Set(ByVal value As String)
                m_YOSAN10 = value
            End Set
        End Property

        Private m_YOSAN11 As String
        Public Property YOSAN11() As String
            Get
                Return m_YOSAN11
            End Get
            Set(ByVal value As String)
                m_YOSAN11 = value
            End Set
        End Property

        Private m_YOSAN12 As String
        Public Property YOSAN12() As String
            Get
                Return m_YOSAN12
            End Get
            Set(ByVal value As String)
                m_YOSAN12 = value
            End Set
        End Property

        Private m_ENDSIIDATE As String
        Public Property ENDSIIDATE() As String
            Get
                Return m_ENDSIIDATE
            End Get
            Set(ByVal value As String)
                m_ENDSIIDATE = value
            End Set
        End Property

        Private m_KEIYAKUDATE As String
        Public Property KEIYAKUDATE() As String
            Get
                Return m_KEIYAKUDATE
            End Get
            Set(ByVal value As String)
                m_KEIYAKUDATE = value
            End Set
        End Property

        Private m_UPDATEPGID As String
        Public Property UPDATEPGID() As String
            Get
                Return m_UPDATEPGID
            End Get
            Set(ByVal value As String)
                m_UPDATEPGID = value
            End Set
        End Property

        Private m_UPDATEUSERCODE As String
        Public Property UPDATEUSERCODE() As String
            Get
                Return m_UPDATEUSERCODE
            End Get
            Set(ByVal value As String)
                m_UPDATEUSERCODE = value
            End Set
        End Property

        Private m_KENSYU_DEKIDAKA As String
        Public Property KENSYU_DEKIDAKA() As String
            Get
                Return m_KENSYU_DEKIDAKA
            End Get
            Set(ByVal value As String)
                m_KENSYU_DEKIDAKA = value
            End Set
        End Property

        Private m_SIHARAI_GENKINRITU As String
        Public Property SIHARAI_GENKINRITU() As String
            Get
                Return m_SIHARAI_GENKINRITU
            End Get
            Set(ByVal value As String)
                m_SIHARAI_GENKINRITU = value
            End Set
        End Property

        Private m_SIHARAI_TEGATARITU As String
        Public Property SIHARAI_TEGATARITU() As String
            Get
                Return m_SIHARAI_TEGATARITU
            End Get
            Set(ByVal value As String)
                m_SIHARAI_TEGATARITU = value
            End Set
        End Property

        Private m_DAIHYONAME As String
        Public Property DAIHYONAME() As String
            Get
                Return m_DAIHYONAME
            End Get
            Set(ByVal value As String)
                m_DAIHYONAME = value
            End Set
        End Property

        Private m_SITE As String
        Public Property SITE() As String
            Get
                Return m_SITE
            End Get
            Set(ByVal value As String)
                m_SITE = value
            End Set
        End Property

        Private m_KEISYOUCODE As String
        Public Property KEISYOUCODE() As String
            Get
                Return m_KEISYOUCODE
            End Get
            Set(ByVal value As String)
                m_KEISYOUCODE = value
            End Set
        End Property

    End Class
End Class
