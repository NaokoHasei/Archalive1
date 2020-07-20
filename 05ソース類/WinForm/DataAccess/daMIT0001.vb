Imports CommonUtility
Imports System.Data.SqlClient
Imports BLL.Common

Public Class daMIT0001

    Private connectionString As String

    ''' <summary>
    ''' クラス初期化
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    ''' <summary>
    ''' 見積ヘッダトラン追加・更新
    ''' </summary>
    ''' <param name="updateData">主キー</param>
    ''' <remarks></remarks>
    Public Sub UpdateData_T_MITUMORIHED(ByVal updateData As dsMIT0001)

        Dim strSQL As String = ""
        strSQL += "MERGE INTO T_MITUMORIHED AS TARGET"
        strSQL += " USING (VALUES ("
        strSQL += "                @MITUMORINO"
        strSQL += "               ,@MITUMORIEDABAN"
        strSQL += "               ,@MITUMORIDATE"
        strSQL += "               ,@TOKUICODE"
        strSQL += "               ,@TANTOCODE"
        strSQL += "               ,@KEISYOUCODE"
        strSQL += "               ,@KOUJINO"
        strSQL += "               ,@KOUJINAME"
        strSQL += "               ,@KOUJIBASYO"
        strSQL += "               ,@NOUKI_START"
        strSQL += "               ,@NOUKI_END"
        strSQL += "               ,@YUKOKIGEN"
        strSQL += "               ,@SIHARAIJYOKEN"
        strSQL += "               ,@OYA_MITUMORINO"
        strSQL += "               ,@OYA_MITUMORIEDABAN"
        strSQL += "               ,@SAI_MITUMORINO"
        strSQL += "               ,@SAI_MITUMORIEDABAN"
        strSQL += "               ,@SAN_MITUMORINO"
        strSQL += "               ,@SAN_MITUMORIEDABAN"
        strSQL += "               ,@GKGENKAGAKU"
        strSQL += "               ,@GKMITUMORIGAKU_NUKI"
        strSQL += "               ,@GKTAX"
        strSQL += "               ,@GKMITUMORIGAKU"
        strSQL += "               ,@GKARARIGAKU"
        strSQL += "               ,@D_BIKO"
        strSQL += "               ,@MITUMORI_JOUKEN"
        strSQL += "               ,@MITUMORI_JOUKEN_FILE_NAME"
        strSQL += "               ,@KIGYOKBN"
        strSQL += "               ,@SYORIKBN"
        strSQL += "               ,@SURYO_SYOSUIKAKETA"
        strSQL += "               ,@UPDATEPGID"
        strSQL += "               ,@UPDATEUSERCODE"
        strSQL += "               ))"
        strSQL += "                AS SOURCE"
        strSQL += "               ("
        strSQL += "                MITUMORINO"
        strSQL += "               ,MITUMORIEDABAN"
        strSQL += "               ,MITUMORIDATE"
        strSQL += "               ,TOKUICODE"
        strSQL += "               ,TANTOCODE"
        strSQL += "               ,KEISYOUCODE"
        strSQL += "               ,KOUJINO"
        strSQL += "               ,KOUJINAME"
        strSQL += "               ,KOUJIBASYO"
        strSQL += "               ,NOUKI_START"
        strSQL += "               ,NOUKI_END"
        strSQL += "               ,YUKOKIGEN"
        strSQL += "               ,SIHARAIJYOKEN"
        strSQL += "               ,OYA_MITUMORINO"
        strSQL += "               ,OYA_MITUMORIEDABAN"
        strSQL += "               ,SAI_MITUMORINO"
        strSQL += "               ,SAI_MITUMORIEDABAN"
        strSQL += "               ,SAN_MITUMORINO"
        strSQL += "               ,SAN_MITUMORIEDABAN"
        strSQL += "               ,GKGENKAGAKU"
        strSQL += "               ,GKMITUMORIGAKU_NUKI"
        strSQL += "               ,GKTAX"
        strSQL += "               ,GKMITUMORIGAKU"
        strSQL += "               ,GKARARIGAKU"
        strSQL += "               ,D_BIKO"
        strSQL += "               ,MITUMORI_JOUKEN"
        strSQL += "               ,MITUMORI_JOUKEN_FILE_NAME"
        strSQL += "               ,KIGYOKBN"
        strSQL += "               ,SYORIKBN"
        strSQL += "               ,SURYO_SYOSUIKAKETA"
        strSQL += "               ,UPDATEPGID"
        strSQL += "               ,UPDATEUSERCODE"
        strSQL += "               ) ON  TARGET.MITUMORINO     = SOURCE.MITUMORINO"
        strSQL += "                 AND TARGET.MITUMORIEDABAN = SOURCE.MITUMORIEDABAN"
        strSQL += "	WHEN MATCHED THEN"
        strSQL += "		UPDATE SET TARGET.MITUMORIDATE        = SOURCE.MITUMORIDATE"
        strSQL += "				  ,TARGET.TOKUICODE           = SOURCE.TOKUICODE"
        strSQL += "				  ,TARGET.TANTOCODE           = SOURCE.TANTOCODE"
        strSQL += "				  ,TARGET.KEISYOUCODE         = SOURCE.KEISYOUCODE"
        strSQL += "				  ,TARGET.KOUJINO             = SOURCE.KOUJINO"
        strSQL += "				  ,TARGET.KOUJINAME           = SOURCE.KOUJINAME"
        strSQL += "				  ,TARGET.KOUJIBASYO          = SOURCE.KOUJIBASYO"
        strSQL += "				  ,TARGET.NOUKI_START         = SOURCE.NOUKI_START"
        strSQL += "				  ,TARGET.NOUKI_END           = SOURCE.NOUKI_END"
        strSQL += "				  ,TARGET.YUKOKIGEN           = SOURCE.YUKOKIGEN"
        strSQL += "				  ,TARGET.SIHARAIJYOKEN       = SOURCE.SIHARAIJYOKEN"
        strSQL += "				  ,TARGET.OYA_MITUMORINO      = SOURCE.OYA_MITUMORINO"
        strSQL += "				  ,TARGET.OYA_MITUMORIEDABAN  = SOURCE.OYA_MITUMORIEDABAN"
        strSQL += "				  ,TARGET.SAI_MITUMORINO      = SOURCE.SAI_MITUMORINO"
        strSQL += "				  ,TARGET.SAI_MITUMORIEDABAN  = SOURCE.SAI_MITUMORIEDABAN"
        strSQL += "				  ,TARGET.SAN_MITUMORINO      = SOURCE.SAN_MITUMORINO"
        strSQL += "				  ,TARGET.SAN_MITUMORIEDABAN  = SOURCE.SAN_MITUMORIEDABAN"
        strSQL += "				  ,TARGET.GKGENKAGAKU         = SOURCE.GKGENKAGAKU"
        strSQL += "				  ,TARGET.GKMITUMORIGAKU_NUKI = SOURCE.GKMITUMORIGAKU_NUKI"
        strSQL += "				  ,TARGET.GKTAX               = SOURCE.GKTAX"
        strSQL += "				  ,TARGET.GKMITUMORIGAKU      = SOURCE.GKMITUMORIGAKU"
        strSQL += "				  ,TARGET.GKARARIGAKU         = SOURCE.GKARARIGAKU"
        strSQL += "				  ,TARGET.D_BIKO              = SOURCE.D_BIKO"
        strSQL += "				  ,TARGET.MITUMORI_JOUKEN     = SOURCE.MITUMORI_JOUKEN"
        strSQL += "				  ,TARGET.MITUMORI_JOUKEN_FILE_NAME     = SOURCE.MITUMORI_JOUKEN_FILE_NAME"
        strSQL += "				  ,TARGET.KIGYOKBN            = SOURCE.KIGYOKBN"
        strSQL += "				  ,TARGET.SYORIKBN            = SOURCE.SYORIKBN"
        strSQL += "				  ,TARGET.SURYO_SYOSUIKAKETA  = SOURCE.SURYO_SYOSUIKAKETA"
        strSQL += "				  ,TARGET.UPDATEMENT          = getdate()"
        strSQL += "				  ,TARGET.UPDATEPGID          = SOURCE.UPDATEPGID"
        strSQL += "				  ,TARGET.UPDATEUSERCODE      = SOURCE.UPDATEUSERCODE"
        strSQL += "	WHEN NOT MATCHED BY TARGET THEN"
        strSQL += "		INSERT ("
        strSQL += "	            MITUMORINO"
        strSQL += "	           ,MITUMORIEDABAN"
        strSQL += "	           ,MITUMORIDATE"
        strSQL += "            ,TOKUICODE"
        strSQL += "            ,TANTOCODE"
        strSQL += "            ,KEISYOUCODE"
        strSQL += "            ,KOUJINO"
        strSQL += "            ,KOUJINAME"
        strSQL += "            ,KOUJIBASYO"
        strSQL += "            ,NOUKI_START"
        strSQL += "            ,NOUKI_END"
        strSQL += "            ,YUKOKIGEN"
        strSQL += "            ,SIHARAIJYOKEN"
        strSQL += "            ,OYA_MITUMORINO"
        strSQL += "            ,OYA_MITUMORIEDABAN"
        strSQL += "            ,SAI_MITUMORINO"
        strSQL += "            ,SAI_MITUMORIEDABAN"
        strSQL += "            ,SAN_MITUMORINO"
        strSQL += "            ,SAN_MITUMORIEDABAN"
        strSQL += "            ,GKGENKAGAKU"
        strSQL += "            ,GKMITUMORIGAKU_NUKI"
        strSQL += "            ,GKTAX"
        strSQL += "            ,GKMITUMORIGAKU"
        strSQL += "            ,GKARARIGAKU"
        strSQL += "            ,D_BIKO"
        strSQL += "            ,MITUMORI_JOUKEN"
        strSQL += "            ,MITUMORI_JOUKEN_FILE_NAME"
        strSQL += "            ,KIGYOKBN"
        strSQL += "            ,SYORIKBN"
        strSQL += "            ,SYORISTDATE"
        strSQL += "            ,SURYO_SYOSUIKAKETA"
        strSQL += "	           ,UPDATEMENT"
        strSQL += "            ,UPDATEPGID"
        strSQL += "            ,UPDATEUSERCODE"
        strSQL += "	           )"
        strSQL += "		VALUES "
        strSQL += "            ("
        strSQL += "	            MITUMORINO"
        strSQL += "            ,MITUMORIEDABAN"
        strSQL += "            ,MITUMORIDATE"
        strSQL += "            ,TOKUICODE"
        strSQL += "            ,TANTOCODE"
        strSQL += "            ,KEISYOUCODE"
        strSQL += "            ,KOUJINO"
        strSQL += "            ,KOUJINAME"
        strSQL += "            ,KOUJIBASYO"
        strSQL += "            ,NOUKI_START"
        strSQL += "            ,NOUKI_END"
        strSQL += "            ,YUKOKIGEN"
        strSQL += "            ,SIHARAIJYOKEN"
        strSQL += "            ,OYA_MITUMORINO"
        strSQL += "            ,OYA_MITUMORIEDABAN"
        strSQL += "            ,SAI_MITUMORINO"
        strSQL += "            ,SAI_MITUMORIEDABAN"
        strSQL += "            ,SAN_MITUMORINO"
        strSQL += "            ,SAN_MITUMORIEDABAN"
        strSQL += "            ,GKGENKAGAKU"
        strSQL += "            ,GKMITUMORIGAKU_NUKI"
        strSQL += "            ,GKTAX"
        strSQL += "            ,GKMITUMORIGAKU"
        strSQL += "            ,GKARARIGAKU"
        strSQL += "            ,D_BIKO"
        strSQL += "            ,MITUMORI_JOUKEN"
        strSQL += "            ,MITUMORI_JOUKEN_FILE_NAME"
        strSQL += "            ,KIGYOKBN"
        strSQL += "            ,SYORIKBN"
        strSQL += "            ,getdate()"
        strSQL += "            ,SURYO_SYOSUIKAKETA"
        strSQL += "            ,getdate()"
        strSQL += "            ,UPDATEPGID"
        strSQL += "            ,UPDATEUSERCODE"
        strSQL += "            );"

        Dim param() As SqlParameter
        param = New SqlParameter() {New SqlParameter("@MITUMORINO", updateData.T_MITUMORIHEDUpdate(0).MITUMORINO),
                                    New SqlParameter("@MITUMORIEDABAN", updateData.T_MITUMORIHEDUpdate(0).MITUMORIEDABAN),
                                    New SqlParameter("@MITUMORIDATE", updateData.T_MITUMORIHEDUpdate(0).MITUMORIDATE),
                                    New SqlParameter("@TOKUICODE", updateData.T_MITUMORIHEDUpdate(0).TOKUICODE),
                                    New SqlParameter("@TANTOCODE", updateData.T_MITUMORIHEDUpdate(0).TANTOCODE),
                                    New SqlParameter("@KEISYOUCODE", updateData.T_MITUMORIHEDUpdate(0).KEISYOUCODE),
                                    New SqlParameter("@KOUJINO", updateData.T_MITUMORIHEDUpdate(0).KOUJINO),
                                    New SqlParameter("@KOUJINAME", updateData.T_MITUMORIHEDUpdate(0).KOUJINAME),
                                    New SqlParameter("@KOUJIBASYO", updateData.T_MITUMORIHEDUpdate(0).KOUJIBASYO),
                                    New SqlParameter("@NOUKI_START", IIf(updateData.T_MITUMORIHEDUpdate(0).NOUKI_START.Equals(Nothing), Nothing, updateData.T_MITUMORIHEDUpdate(0).NOUKI_START)),
                                    New SqlParameter("@NOUKI_END", IIf(updateData.T_MITUMORIHEDUpdate(0).NOUKI_END.Equals(Nothing), Nothing, updateData.T_MITUMORIHEDUpdate(0).NOUKI_END)),
                                    New SqlParameter("@YUKOKIGEN", updateData.T_MITUMORIHEDUpdate(0).YUKOKIGEN),
                                    New SqlParameter("@SIHARAIJYOKEN", updateData.T_MITUMORIHEDUpdate(0).SIHARAIJYOKEN),
                                    New SqlParameter("@OYA_MITUMORINO", updateData.T_MITUMORIHEDUpdate(0).OYA_MITUMORINO),
                                    New SqlParameter("@OYA_MITUMORIEDABAN", updateData.T_MITUMORIHEDUpdate(0).OYA_MITUMORIEDABAN),
                                    New SqlParameter("@SAI_MITUMORINO", updateData.T_MITUMORIHEDUpdate(0).SAI_MITUMORINO),
                                    New SqlParameter("@SAI_MITUMORIEDABAN", updateData.T_MITUMORIHEDUpdate(0).SAI_MITUMORIEDABAN),
                                    New SqlParameter("@SAN_MITUMORINO", updateData.T_MITUMORIHEDUpdate(0).SAN_MITUMORINO),
                                    New SqlParameter("@SAN_MITUMORIEDABAN", updateData.T_MITUMORIHEDUpdate(0).SAN_MITUMORIEDABAN),
                                    New SqlParameter("@GKGENKAGAKU", updateData.T_MITUMORIHEDUpdate(0).GKGENKAGAKU),
                                    New SqlParameter("@GKMITUMORIGAKU_NUKI", updateData.T_MITUMORIHEDUpdate(0).GKMITUMORIGAKU_NUKI),
                                    New SqlParameter("@GKTAX", updateData.T_MITUMORIHEDUpdate(0).GKTAX),
                                    New SqlParameter("@GKMITUMORIGAKU", updateData.T_MITUMORIHEDUpdate(0).GKMITUMORIGAKU),
                                    New SqlParameter("@GKARARIGAKU", updateData.T_MITUMORIHEDUpdate(0).GKARARIGAKU),
                                    New SqlParameter("@D_BIKO", updateData.T_MITUMORIHEDUpdate(0).D_BIKO),
                                    New SqlParameter("@MITUMORI_JOUKEN", updateData.T_MITUMORIHEDUpdate(0).MITUMORI_JOUKEN),
                                    New SqlParameter("@MITUMORI_JOUKEN_FILE_NAME", updateData.T_MITUMORIHEDUpdate(0).MITUMORI_JOUKEN_FILE_NAME),
                                    New SqlParameter("@KIGYOKBN", updateData.T_MITUMORIHEDUpdate(0).KIGYOKBN),
                                    New SqlParameter("@SYORIKBN", updateData.T_MITUMORIHEDUpdate(0).SYORIKBN),
                                    New SqlParameter("@SURYO_SYOSUIKAKETA", updateData.T_MITUMORIHEDUpdate(0).SURYO_SYOSUIKAKETA),
                                    New SqlParameter("@UPDATEPGID", updateData.T_MITUMORIHEDUpdate(0).UPDATEPGID),
                                    New SqlParameter("@UPDATEUSERCODE", updateData.T_MITUMORIHEDUpdate(0).UPDATEUSERCODE)}

        Dim logic As New ExecuteQuery

        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, param)
    End Sub

    ''' <summary>
    ''' 見積ヘッダトラン削除
    ''' </summary>
    ''' <param name="decMITUMORINO">見積Ｎｏ</param>
    ''' <param name="decMITUMORIEDABAN">見積枝番</param>
    ''' <remarks></remarks>
    Public Sub DeleteData_T_MITUMORIHED(ByVal decMITUMORINO As Decimal, ByVal decMITUMORIEDABAN As Decimal)
        Dim logic As New ExecuteQuery

        Dim strSQL As String = "DELETE FROM T_MITUMORIHED WHERE MITUMORINO=@MITUMORINO AND MITUMORIEDABAN=@MITUMORIEDABAN"

        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, New SqlParameter() {New SqlParameter("@MITUMORINO", decMITUMORINO), New SqlParameter("@MITUMORIEDABAN", decMITUMORIEDABAN)})
    End Sub

    ''' <summary>
    ''' 見積トラン追加・更新
    ''' </summary>
    ''' <param name="updateData">主キー</param>
    ''' <remarks></remarks>
    Public Sub UpdateData_T_MITUMORI(ByVal updateData As dsMIT0001)
        Dim strSQL As String = ""

        strSQL += "	INSERT INTO T_MITUMORI ("
        strSQL += "         MITUMORINO"
        strSQL += "        ,MITUMORIEDABAN"
        strSQL += "        ,KAISOCODE"
        strSQL += "        ,DAIKAMOKUCODE"
        strSQL += "        ,CYUKAMOKUCODE"
        strSQL += "        ,SYOKAMOKUCODE"
        strSQL += "        ,KAMOKU_HINMOKU"
        strSQL += "        ,HINSITU_KIKAKU_SIYO"
        strSQL += "        ,SIIRECODE"
        strSQL += "        ,TANI"
        strSQL += "        ,SUU"
        strSQL += "        ,KAKERITU"
        strSQL += "        ,GENTANKA"
        strSQL += "        ,MITUMORITANKA"
        strSQL += "        ,GENKAGAKU"
        strSQL += "        ,MITUMORIGAKU"
        strSQL += "        ,MITUMORIGAKU_NUKI"
        strSQL += "        ,ARARIGAKU"
        strSQL += "        ,IKATU_KAKERITU"
        strSQL += "        ,G_BIKO"
        strSQL += "        ,KAKERITU_UPFLG"
        strSQL += "	       ,UPDATEMENT"
        strSQL += "        ,UPDATEPGID"
        strSQL += "        ,UPDATEUSERCODE"
        strSQL += "	       )"
        strSQL += "	VALUES "
        strSQL += "        ("
        strSQL += "         @MITUMORINO"
        strSQL += "        ,@MITUMORIEDABAN"
        strSQL += "        ,@KAISOCODE"
        strSQL += "        ,@DAIKAMOKUCODE"
        strSQL += "        ,@CYUKAMOKUCODE"
        strSQL += "        ,@SYOKAMOKUCODE"
        strSQL += "        ,@KAMOKU_HINMOKU"
        strSQL += "        ,@HINSITU_KIKAKU_SIYO"
        strSQL += "        ,@SIIRECODE"
        strSQL += "        ,@TANI"
        strSQL += "        ,@SUU"
        strSQL += "        ,@KAKERITU"
        strSQL += "        ,@GENTANKA"
        strSQL += "        ,@MITUMORITANKA"
        strSQL += "        ,@GENKAGAKU"
        strSQL += "        ,@MITUMORIGAKU"
        strSQL += "        ,@MITUMORIGAKU_NUKI"
        strSQL += "        ,@ARARIGAKU"
        strSQL += "        ,@IKATU_KAKERITU"
        strSQL += "        ,@G_BIKO"
        strSQL += "        ,@KAKERITU_UPFLG"
        strSQL += "        ,getdate()"
        strSQL += "        ,@UPDATEPGID"
        strSQL += "        ,@UPDATEUSERCODE"
        strSQL += "        );"

        Dim param() As SqlParameter
        For intI As Integer = 0 To updateData.T_MITUMORIUpdate.Count - 1
            param = New SqlParameter() {New SqlParameter("@MITUMORINO", updateData.T_MITUMORIUpdate(intI).MITUMORINO),
                                        New SqlParameter("@MITUMORIEDABAN", updateData.T_MITUMORIUpdate(intI).MITUMORIEDABAN),
                                        New SqlParameter("@KAISOCODE", updateData.T_MITUMORIUpdate(intI).KAISOCODE),
                                        New SqlParameter("@DAIKAMOKUCODE", updateData.T_MITUMORIUpdate(intI).DAIKAMOKUCODE),
                                        New SqlParameter("@CYUKAMOKUCODE", updateData.T_MITUMORIUpdate(intI).CYUKAMOKUCODE),
                                        New SqlParameter("@SYOKAMOKUCODE", updateData.T_MITUMORIUpdate(intI).SYOKAMOKUCODE),
                                        New SqlParameter("@KAMOKU_HINMOKU", updateData.T_MITUMORIUpdate(intI).KAMOKU_HINMOKU),
                                        New SqlParameter("@HINSITU_KIKAKU_SIYO", updateData.T_MITUMORIUpdate(intI).HINSITU_KIKAKU_SIYO),
                                        New SqlParameter("@SIIRECODE", updateData.T_MITUMORIUpdate(intI).SIIRECODE),
                                        New SqlParameter("@TANI", updateData.T_MITUMORIUpdate(intI).TANI),
                                        New SqlParameter("@SUU", updateData.T_MITUMORIUpdate(intI).SUU),
                                        New SqlParameter("@KAKERITU", updateData.T_MITUMORIUpdate(intI).KAKERITU),
                                        New SqlParameter("@GENTANKA", updateData.T_MITUMORIUpdate(intI).GENTANKA),
                                        New SqlParameter("@MITUMORITANKA", updateData.T_MITUMORIUpdate(intI).MITUMORITANKA),
                                        New SqlParameter("@GENKAGAKU", updateData.T_MITUMORIUpdate(intI).GENKAGAKU),
                                        New SqlParameter("@MITUMORIGAKU", updateData.T_MITUMORIUpdate(intI).MITUMORIGAKU),
                                        New SqlParameter("@MITUMORIGAKU_NUKI", updateData.T_MITUMORIUpdate(intI).MITUMORIGAKU_NUKI),
                                        New SqlParameter("@ARARIGAKU", updateData.T_MITUMORIUpdate(intI).ARARIGAKU),
                                        New SqlParameter("@IKATU_KAKERITU", updateData.T_MITUMORIUpdate(intI).IKATU_KAKERITU),
                                        New SqlParameter("@G_BIKO", updateData.T_MITUMORIUpdate(intI).G_BIKO),
                                        New SqlParameter("@KAKERITU_UPFLG", updateData.T_MITUMORIUpdate(intI).KAKERITU_UPFLG),
                                        New SqlParameter("@UPDATEPGID", updateData.T_MITUMORIUpdate(intI).UPDATEPGID),
                                        New SqlParameter("@UPDATEUSERCODE", updateData.T_MITUMORIUpdate(intI).UPDATEUSERCODE)}

            Dim logic As New ExecuteQuery

            logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, param)
        Next intI

    End Sub

    ''' <summary>
    ''' 見積枝番取得
    ''' </summary>
    ''' <param name="strMITUMORINO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Function GetMITUMORIRENBAN(ByVal strMITUMORINO As String) As String
        Dim logic As New ExecuteQuery

        Dim result = logic.ExecuteDataset(
              CommonUtility.DBUtility.GetConnectionString _
            , CommandType.Text _
            , "select max(isnull(MITUMORIEDABAN,0)) + 1 from T_MITUMORIHED where MITUMORINO=@MITUMORINO" _
            , New SqlParameter("@MITUMORINO", CType(strMITUMORINO, Decimal))
            ).Tables(0).Rows(0).Item(0).ToString

        Return IIf(result <> "", result, 0)
    End Function

    ''' <summary>
    ''' 見積トラン削除
    ''' </summary>
    ''' <param name="decMITUMORINO">見積Ｎｏ</param>
    ''' <param name="decMITUMORIEDABAN">見積枝番</param>
    ''' <remarks></remarks>
    Public Sub DeleteData_T_MITUMORI(ByVal decMITUMORINO As Decimal, ByVal decMITUMORIEDABAN As Decimal, Optional ByVal strKAISOCODE As String = vbNullString)
        Dim logic As New ExecuteQuery

        Dim strSQL As String = " DELETE FROM T_MITUMORI WHERE MITUMORINO=@MITUMORINO AND MITUMORIEDABAN=@MITUMORIEDABAN"

        If Not Utility.NUCheck(strKAISOCODE) Then
            strSQL += " AND KAISOCODE=@KAISOCODE"
        End If

        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, New SqlParameter() {New SqlParameter("@MITUMORINO", decMITUMORINO),
                                                                                              New SqlParameter("@MITUMORIEDABAN", decMITUMORIEDABAN),
                                                                                              New SqlParameter("@KAISOCODE", strKAISOCODE)})

    End Sub

End Class
