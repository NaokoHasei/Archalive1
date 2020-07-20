Imports CommonUtility
Imports System.Data.SqlClient
Imports BLL.Common

Public Class daJYU0001

    Private connectionString As String

    ''' <summary>
    ''' クラス初期化
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    ''' <summary>
    ''' 受注ヘッダトラン追加・更新
    ''' </summary>
    ''' <param name="updateData">主キー</param>
    ''' <remarks></remarks>
    Public Sub subUpdateData_T_JYUTYUHED(ByVal updateData As dsJYU0001)

        Dim strSQL As String = ""
        strSQL += "MERGE INTO T_JYUTYUHED AS TARGET"
        strSQL += " USING ("
        strSQL += "   VALUES ("
        strSQL += "       @JYUTYUNO"
        strSQL += "     , @JYUTYUEDABAN"
        strSQL += "     , @JYUTYUDATE"
        strSQL += "     , @TOKUICODE"
        strSQL += "     , @TANTOCODE"
        strSQL += "     , @INP_TANTOCODE"
        strSQL += "     , @KEISYOUCODE"
        strSQL += "     , @KOUJINO"
        strSQL += "     , @KOUJINAME"
        strSQL += "     , @KOUJIBASYO"
        strSQL += "     , @NOUKI_START"
        strSQL += "     , @NOUKI_END"
        strSQL += "     , @AITE_ORDERNO"
        strSQL += "     , @MITUMORINO"
        strSQL += "     , @MITUMORIEDABAN"
        strSQL += "     , @SAN_JYUTYUNO"
        strSQL += "     , @SAN_MITUMORINO"
        strSQL += "     , @SAN_MITUMORIEDABAN"
        strSQL += "     , @JIKKOYOSAN"
        strSQL += "     , @GKGENKAGAKU"
        strSQL += "     , @GKJYUTYUGAKU_NUKI"
        strSQL += "     , @GKTAX"
        strSQL += "     , @GKJYUTYUGAKU"
        strSQL += "     , @GKARARIGAKU"
        strSQL += "     , @D_BIKO"
        strSQL += "     , @KIGYOKBN"
        strSQL += "     , @SYORIKBN"
        strSQL += "     , @SYORISTDATE"
        strSQL += "     , @SURYO_SYOSUIKAKETA"
        strSQL += "     , @UPDATEPGID"
        strSQL += "     , @UPDATEUSERCODE"
        strSQL += "   )"
        strSQL += " )"
        strSQL += " AS SOURCE ("
        strSQL += "     JYUTYUNO"
        strSQL += "   , JYUTYUEDABAN"
        strSQL += "   , JYUTYUDATE"
        strSQL += "   , TOKUICODE"
        strSQL += "   , TANTOCODE"
        strSQL += "   , INP_TANTOCODE"
        strSQL += "   , KEISYOUCODE"
        strSQL += "   , KOUJINO"
        strSQL += "   , KOUJINAME"
        strSQL += "   , KOUJIBASYO"
        strSQL += "   , NOUKI_START"
        strSQL += "   , NOUKI_END"
        strSQL += "   , AITE_ORDERNO"
        strSQL += "   , MITUMORINO"
        strSQL += "   , MITUMORIEDABAN"
        strSQL += "   , SAN_JYUTYUNO"
        strSQL += "   , SAN_MITUMORINO"
        strSQL += "   , SAN_MITUMORIEDABAN"
        strSQL += "   , JIKKOYOSAN"
        strSQL += "   , GKGENKAGAKU"
        strSQL += "   , GKJYUTYUGAKU_NUKI"
        strSQL += "   , GKTAX"
        strSQL += "   , GKJYUTYUGAKU"
        strSQL += "   , GKARARIGAKU"
        strSQL += "   , D_BIKO"
        strSQL += "   , KIGYOKBN"
        strSQL += "   , SYORIKBN"
        strSQL += "   , SYORISTDATE"
        strSQL += "   , SURYO_SYOSUIKAKETA"
        strSQL += "   , UPDATEPGID"
        strSQL += "   , UPDATEUSERCODE"
        strSQL += " )"
        strSQL += " ON  TARGET.JYUTYUNO     = SOURCE.JYUTYUNO"
        strSQL += " AND TARGET.JYUTYUEDABAN = SOURCE.JYUTYUEDABAN"
        strSQL += "	WHEN MATCHED THEN"
        strSQL += "	  UPDATE SET"
        strSQL += "	      TARGET.JYUTYUDATE          = SOURCE.JYUTYUDATE"
        strSQL += "		, TARGET.TOKUICODE           = SOURCE.TOKUICODE"
        strSQL += "		, TARGET.TANTOCODE           = SOURCE.TANTOCODE"
        strSQL += "		, TARGET.INP_TANTOCODE       = SOURCE.INP_TANTOCODE"
        strSQL += "		, TARGET.KEISYOUCODE         = SOURCE.KEISYOUCODE"
        strSQL += "		, TARGET.KOUJINO             = SOURCE.KOUJINO"
        strSQL += "		, TARGET.KOUJINAME           = SOURCE.KOUJINAME"
        strSQL += "		, TARGET.KOUJIBASYO          = SOURCE.KOUJIBASYO"
        strSQL += "		, TARGET.NOUKI_START         = SOURCE.NOUKI_START"
        strSQL += "		, TARGET.NOUKI_END           = SOURCE.NOUKI_END"
        strSQL += "		, TARGET.AITE_ORDERNO        = SOURCE.AITE_ORDERNO"
        strSQL += "		, TARGET.MITUMORINO          = SOURCE.MITUMORINO"
        strSQL += "		, TARGET.MITUMORIEDABAN      = SOURCE.MITUMORIEDABAN"
        strSQL += "		, TARGET.SAN_JYUTYUNO        = SOURCE.SAN_JYUTYUNO"
        strSQL += "		, TARGET.SAN_MITUMORINO      = SOURCE.SAN_MITUMORINO"
        strSQL += "		, TARGET.SAN_MITUMORIEDABAN  = SOURCE.SAN_MITUMORIEDABAN"
        strSQL += "		, TARGET.JIKKOYOSAN          = SOURCE.JIKKOYOSAN"
        strSQL += "		, TARGET.GKGENKAGAKU         = SOURCE.GKGENKAGAKU"
        strSQL += "		, TARGET.GKJYUTYUGAKU_NUKI   = SOURCE.GKJYUTYUGAKU_NUKI"
        strSQL += "		, TARGET.GKTAX               = SOURCE.GKTAX"
        strSQL += "		, TARGET.GKJYUTYUGAKU        = SOURCE.GKJYUTYUGAKU"
        strSQL += "		, TARGET.GKARARIGAKU         = SOURCE.GKARARIGAKU"
        strSQL += "		, TARGET.D_BIKO              = SOURCE.D_BIKO"
        strSQL += "		, TARGET.KIGYOKBN            = SOURCE.KIGYOKBN"
        strSQL += "		, TARGET.SYORIKBN            = SOURCE.SYORIKBN"
        strSQL += "     , TARGET.SYORISTDATE         = SOURCE.SYORISTDATE"
        strSQL += "		, TARGET.SURYO_SYOSUIKAKETA  = SOURCE.SURYO_SYOSUIKAKETA"
        strSQL += "		, TARGET.UPDATEMENT          = getdate()"
        strSQL += "		, TARGET.UPDATEPGID          = SOURCE.UPDATEPGID"
        strSQL += "		, TARGET.UPDATEUSERCODE      = SOURCE.UPDATEUSERCODE"
        strSQL += "	WHEN NOT MATCHED BY TARGET THEN"
        strSQL += "	  INSERT ("
        strSQL += "	      JYUTYUNO"
        strSQL += "	    , JYUTYUEDABAN"
        strSQL += "	    , JYUTYUDATE"
        strSQL += "     , TOKUICODE"
        strSQL += "     , TANTOCODE"
        strSQL += "     , INP_TANTOCODE"
        strSQL += "     , KEISYOUCODE"
        strSQL += "     , KOUJINO"
        strSQL += "     , KOUJINAME"
        strSQL += "     , KOUJIBASYO"
        strSQL += "     , NOUKI_START"
        strSQL += "     , NOUKI_END"
        strSQL += "     , AITE_ORDERNO"
        strSQL += "     , MITUMORINO"
        strSQL += "     , MITUMORIEDABAN"
        strSQL += "     , SAN_JYUTYUNO"
        strSQL += "     , SAN_MITUMORINO"
        strSQL += "     , SAN_MITUMORIEDABAN"
        strSQL += "     , JIKKOYOSAN"
        strSQL += "     , GKGENKAGAKU"
        strSQL += "     , GKJYUTYUGAKU_NUKI"
        strSQL += "     , GKTAX"
        strSQL += "     , GKJYUTYUGAKU"
        strSQL += "     , GKARARIGAKU"
        strSQL += "     , D_BIKO"
        strSQL += "     , KIGYOKBN"
        strSQL += "     , SYORIKBN"
        strSQL += "     , SYORISTDATE"
        strSQL += "     , SURYO_SYOSUIKAKETA"
        strSQL += "	    , UPDATEMENT"
        strSQL += "     , UPDATEPGID"
        strSQL += "     , UPDATEUSERCODE"
        strSQL += "	  ) VALUES ("
        strSQL += "	      JYUTYUNO"
        strSQL += "	    , JYUTYUEDABAN"
        strSQL += "	    , JYUTYUDATE"
        strSQL += "     , TOKUICODE"
        strSQL += "     , TANTOCODE"
        strSQL += "     , INP_TANTOCODE"
        strSQL += "     , KEISYOUCODE"
        strSQL += "     , KOUJINO"
        strSQL += "     , KOUJINAME"
        strSQL += "     , KOUJIBASYO"
        strSQL += "     , NOUKI_START"
        strSQL += "     , NOUKI_END"
        strSQL += "     , AITE_ORDERNO"
        strSQL += "     , MITUMORINO"
        strSQL += "     , MITUMORIEDABAN"
        strSQL += "     , SAN_JYUTYUNO"
        strSQL += "     , SAN_MITUMORINO"
        strSQL += "     , SAN_MITUMORIEDABAN"
        strSQL += "     , JIKKOYOSAN"
        strSQL += "     , GKGENKAGAKU"
        strSQL += "     , GKJYUTYUGAKU_NUKI"
        strSQL += "     , GKTAX"
        strSQL += "     , GKJYUTYUGAKU"
        strSQL += "     , GKARARIGAKU"
        strSQL += "     , D_BIKO"
        strSQL += "     , KIGYOKBN"
        strSQL += "     , SYORIKBN"
        strSQL += "     , SYORISTDATE"
        strSQL += "     , SURYO_SYOSUIKAKETA"
        strSQL += "     , getdate()"
        strSQL += "     , UPDATEPGID"
        strSQL += "     , UPDATEUSERCODE"
        strSQL += "   );"

        Dim param() As SqlParameter
        param = New SqlParameter() {
            New SqlParameter("@JYUTYUNO", updateData.T_JYUTYUHEDUpdate(0).JYUTYUNO),
            New SqlParameter("@JYUTYUEDABAN", updateData.T_JYUTYUHEDUpdate(0).JYUTYUEDABAN),
            New SqlParameter("@JYUTYUDATE", updateData.T_JYUTYUHEDUpdate(0).JYUTYUDATE),
            New SqlParameter("@TOKUICODE", updateData.T_JYUTYUHEDUpdate(0).TOKUICODE),
            New SqlParameter("@TANTOCODE", updateData.T_JYUTYUHEDUpdate(0).TANTOCODE),
            New SqlParameter("@INP_TANTOCODE", updateData.T_JYUTYUHEDUpdate(0).INP_TANTOCODE),
            New SqlParameter("@KEISYOUCODE", updateData.T_JYUTYUHEDUpdate(0).KEISYOUCODE),
            New SqlParameter("@KOUJINO", updateData.T_JYUTYUHEDUpdate(0).KOUJINO),
            New SqlParameter("@KOUJINAME", updateData.T_JYUTYUHEDUpdate(0).KOUJINAME),
            New SqlParameter("@KOUJIBASYO", updateData.T_JYUTYUHEDUpdate(0).KOUJIBASYO),
            New SqlParameter("@NOUKI_START", IIf(updateData.T_JYUTYUHEDUpdate(0).NOUKI_START.Equals(Nothing), Nothing, updateData.T_JYUTYUHEDUpdate(0).NOUKI_START)),
            New SqlParameter("@NOUKI_END", IIf(updateData.T_JYUTYUHEDUpdate(0).NOUKI_END.Equals(Nothing), Nothing, updateData.T_JYUTYUHEDUpdate(0).NOUKI_END)),
            New SqlParameter("@AITE_ORDERNO", updateData.T_JYUTYUHEDUpdate(0).AITE_ORDERNO),
            New SqlParameter("@MITUMORINO", updateData.T_JYUTYUHEDUpdate(0).MITUMORINO),
            New SqlParameter("@MITUMORIEDABAN", updateData.T_JYUTYUHEDUpdate(0).MITUMORIEDABAN),
            New SqlParameter("@SAN_JYUTYUNO", updateData.T_JYUTYUHEDUpdate(0).SAN_JYUTYUNO),
            New SqlParameter("@SAN_MITUMORINO", updateData.T_JYUTYUHEDUpdate(0).SAN_MITUMORINO),
            New SqlParameter("@SAN_MITUMORIEDABAN", updateData.T_JYUTYUHEDUpdate(0).SAN_MITUMORIEDABAN),
            New SqlParameter("@JIKKOYOSAN", updateData.T_JYUTYUHEDUpdate(0).JIKKOYOSAN),
            New SqlParameter("@GKGENKAGAKU", updateData.T_JYUTYUHEDUpdate(0).GKGENKAGAKU),
            New SqlParameter("@GKJYUTYUGAKU_NUKI", updateData.T_JYUTYUHEDUpdate(0).GKJYUTYUGAKU_NUKI),
            New SqlParameter("@GKTAX", updateData.T_JYUTYUHEDUpdate(0).GKTAX),
            New SqlParameter("@GKJYUTYUGAKU", updateData.T_JYUTYUHEDUpdate(0).GKJYUTYUGAKU),
            New SqlParameter("@GKARARIGAKU", updateData.T_JYUTYUHEDUpdate(0).GKARARIGAKU),
            New SqlParameter("@D_BIKO", updateData.T_JYUTYUHEDUpdate(0).D_BIKO),
            New SqlParameter("@KIGYOKBN", updateData.T_JYUTYUHEDUpdate(0).KIGYOKBN),
            New SqlParameter("@SYORIKBN", updateData.T_JYUTYUHEDUpdate(0).SYORIKBN),
            New SqlParameter("@SYORISTDATE", updateData.T_JYUTYUHEDUpdate(0).SYORISTDATE),
            New SqlParameter("@SURYO_SYOSUIKAKETA", updateData.T_JYUTYUHEDUpdate(0).SURYO_SYOSUIKAKETA),
            New SqlParameter("@UPDATEPGID", updateData.T_JYUTYUHEDUpdate(0).UPDATEPGID),
            New SqlParameter("@UPDATEUSERCODE", updateData.T_JYUTYUHEDUpdate(0).UPDATEUSERCODE)}

        Dim logic As New BLL.Common.ExecuteQuery
        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, param)

    End Sub

    ''' <summary>
    ''' 受注トラン追加・更新
    ''' </summary>
    ''' <param name="updateData">主キー</param>
    ''' <remarks></remarks>
    Public Sub subUpdateData_T_JYUTYU(ByVal updateData As dsJYU0001)

        Dim strSQL As String = ""
        strSQL += "	INSERT INTO T_JYUTYU ("
        strSQL += "     JYUTYUNO"
        strSQL += "   , JYUTYUEDABAN"
        strSQL += "   , KAISOCODE"
        strSQL += "   , KAISOCODE_ZENKAI"
        strSQL += "   , DELETE_FLG"
        strSQL += "   , DAIKAMOKUCODE"
        strSQL += "   , CYUKAMOKUCODE"
        strSQL += "   , SYOKAMOKUCODE"
        strSQL += "   , KAMOKU_HINMOKU"
        strSQL += "   , HINSITU_KIKAKU_SIYO"
        strSQL += "   , SIIRECODE"
        strSQL += "   , TANI"
        strSQL += "   , SUU"
        strSQL += "   , KAKERITU"
        strSQL += "   , GENTANKA"
        strSQL += "   , JYUTYUTANKA"
        strSQL += "   , GENKAGAKU"
        strSQL += "   , JYUTYUGAKU"
        strSQL += "   , JYUTYUGAKU_NUKI"
        strSQL += "   , ARARIGAKU"
        strSQL += "   , IKATU_KAKERITU"
        strSQL += "   , G_BIKO"
        strSQL += "   , KAKERITU_UPFLG"
        strSQL += "	  , UPDATEMENT"
        strSQL += "   , UPDATEPGID"
        strSQL += "   , UPDATEUSERCODE"
        strSQL += "	) VALUES ("
        strSQL += "     @JYUTYUNO"
        strSQL += "   , @JYUTYUEDABAN"
        strSQL += "   , @KAISOCODE"
        strSQL += "   , @KAISOCODE_ZENKAI"
        strSQL += "   , @DELETE_FLG"
        strSQL += "   , @DAIKAMOKUCODE"
        strSQL += "   , @CYUKAMOKUCODE"
        strSQL += "   , @SYOKAMOKUCODE"
        strSQL += "   , @KAMOKU_HINMOKU"
        strSQL += "   , @HINSITU_KIKAKU_SIYO"
        strSQL += "   , @SIIRECODE"
        strSQL += "   , @TANI"
        strSQL += "   , @SUU"
        strSQL += "   , @KAKERITU"
        strSQL += "   , @GENTANKA"
        strSQL += "   , @JYUTYUTANKA"
        strSQL += "   , @GENKAGAKU"
        strSQL += "   , @JYUTYUGAKU"
        strSQL += "   , @JYUTYUGAKU_NUKI"
        strSQL += "   , @ARARIGAKU"
        strSQL += "   , @IKATU_KAKERITU"
        strSQL += "   , @G_BIKO"
        strSQL += "   , @KAKERITU_UPFLG"
        strSQL += "   , getdate()"
        strSQL += "   , @UPDATEPGID"
        strSQL += "   , @UPDATEUSERCODE"
        strSQL += " );"

        Dim param() As SqlParameter
        For intI As Integer = 0 To updateData.T_JYUTYUUpdate.Count - 1
            param = New SqlParameter() {
                New SqlParameter("@JYUTYUNO", updateData.T_JYUTYUUpdate(intI).JYUTYUNO),
                New SqlParameter("@JYUTYUEDABAN", updateData.T_JYUTYUUpdate(intI).JYUTYUEDABAN),
                New SqlParameter("@KAISOCODE", updateData.T_JYUTYUUpdate(intI).KAISOCODE),
                New SqlParameter("@KAISOCODE_ZENKAI", updateData.T_JYUTYUUpdate(intI).KAISOCODE_ZENKAI),
                New SqlParameter("@DELETE_FLG", updateData.T_JYUTYUUpdate(intI).DELETE_FLG),
                New SqlParameter("@DAIKAMOKUCODE", updateData.T_JYUTYUUpdate(intI).DAIKAMOKUCODE),
                New SqlParameter("@CYUKAMOKUCODE", updateData.T_JYUTYUUpdate(intI).CYUKAMOKUCODE),
                New SqlParameter("@SYOKAMOKUCODE", updateData.T_JYUTYUUpdate(intI).SYOKAMOKUCODE),
                New SqlParameter("@KAMOKU_HINMOKU", updateData.T_JYUTYUUpdate(intI).KAMOKU_HINMOKU),
                New SqlParameter("@HINSITU_KIKAKU_SIYO", updateData.T_JYUTYUUpdate(intI).HINSITU_KIKAKU_SIYO),
                New SqlParameter("@SIIRECODE", updateData.T_JYUTYUUpdate(intI).SIIRECODE),
                New SqlParameter("@TANI", updateData.T_JYUTYUUpdate(intI).TANI),
                New SqlParameter("@SUU", updateData.T_JYUTYUUpdate(intI).SUU),
                New SqlParameter("@KAKERITU", updateData.T_JYUTYUUpdate(intI).KAKERITU),
                New SqlParameter("@GENTANKA", updateData.T_JYUTYUUpdate(intI).GENTANKA),
                New SqlParameter("@JYUTYUTANKA", updateData.T_JYUTYUUpdate(intI).JYUTYUTANKA),
                New SqlParameter("@GENKAGAKU", updateData.T_JYUTYUUpdate(intI).GENKAGAKU),
                New SqlParameter("@JYUTYUGAKU", updateData.T_JYUTYUUpdate(intI).JYUTYUGAKU),
                New SqlParameter("@JYUTYUGAKU_NUKI", updateData.T_JYUTYUUpdate(intI).JYUTYUGAKU_NUKI),
                New SqlParameter("@ARARIGAKU", updateData.T_JYUTYUUpdate(intI).ARARIGAKU),
                New SqlParameter("@IKATU_KAKERITU", updateData.T_JYUTYUUpdate(intI).IKATU_KAKERITU),
                New SqlParameter("@G_BIKO", updateData.T_JYUTYUUpdate(intI).G_BIKO),
                New SqlParameter("@KAKERITU_UPFLG", updateData.T_JYUTYUUpdate(intI).KAKERITU_UPFLG),
                New SqlParameter("@UPDATEPGID", updateData.T_JYUTYUUpdate(intI).UPDATEPGID),
                New SqlParameter("@UPDATEUSERCODE", updateData.T_JYUTYUUpdate(intI).UPDATEUSERCODE)}

            Dim logic As New BLL.Common.ExecuteQuery

            logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, param)
        Next intI

    End Sub

    ''' <summary>
    ''' 受注ヘッダトラン削除
    ''' </summary>
    ''' <param name="decJYUTYUNO">受注Ｎｏ</param>
    ''' <param name="decJYUTYUEDABAN">受注枝番</param>
    ''' <remarks></remarks>
    Public Sub subDeleteData_T_JYUTYUHED(ByVal decJYUTYUNO As Decimal, ByVal decJYUTYUEDABAN As Decimal)
        Dim logic As New BLL.Common.ExecuteQuery

        logic.ExecuteNonQuery(
              connectionString _
            , CommandType.Text _
            , "DELETE FROM T_JYUTYUHED WHERE JYUTYUNO = @JYUTYUNO AND JYUTYUEDABAN = @JYUTYUEDABAN" _
            , New SqlParameter() {New SqlParameter("@JYUTYUNO", decJYUTYUNO), New SqlParameter("@JYUTYUEDABAN", decJYUTYUEDABAN)}
            )
    End Sub

    ''' <summary>
    ''' 受注トラン削除
    ''' </summary>
    ''' <param name="decJYUTYUNO">受注Ｎｏ</param>
    ''' <param name="decJYUTYUEDABAN">受注枝番</param>
    ''' <remarks></remarks>
    Public Sub subDeleteData_T_JYUTYU(ByVal decJYUTYUNO As Decimal, ByVal decJYUTYUEDABAN As Decimal)
        Dim logic As New BLL.Common.ExecuteQuery

        logic.ExecuteNonQuery(
              connectionString _
            , CommandType.Text _
            , "DELETE FROM T_JYUTYU WHERE JYUTYUNO=@JYUTYUNO AND JYUTYUEDABAN = @JYUTYUEDABAN" _
            , New SqlParameter() {New SqlParameter("@JYUTYUNO", decJYUTYUNO), New SqlParameter("@JYUTYUEDABAN", decJYUTYUEDABAN)}
            )

    End Sub

End Class
