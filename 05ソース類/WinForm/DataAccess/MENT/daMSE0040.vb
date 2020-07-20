Imports System.Data.SqlClient
Imports System.Data
Imports CommonUtility

Public Class daMSE0040

    Private connectionString As String

    ''' <summary>
    ''' クラス初期化
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    ''' <summary>
    ''' データセット取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDataTable() As dsMSE0040.M_KBNDataTable

        Dim resultDataSets As New dsMSE0040.M_KBNDataTable

        Using MasterAdapter As New dsMSE0040TableAdapters.M_KBNTableAdapter,
           connection As New System.Data.SqlClient.SqlConnection(connectionString)

            MasterAdapter.Connection = connection
            CommonUtility.DBUtility.SetCommandTimeout(MasterAdapter)
            MasterAdapter.Fill(resultDataSets)

        End Using

        Return resultDataSets
    End Function

    ''' <summary>
    ''' データセット取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDataTable(ByVal strSIYOUKBN As String) As dsMSE0040.M_KBNDataTable

        Dim resultDataSets As New dsMSE0040.M_KBNDataTable

        Using MasterAdapter As New dsMSE0040TableAdapters.M_KBNTableAdapter,
            connection As New System.Data.SqlClient.SqlConnection(connectionString)

            MasterAdapter.Connection = connection
            CommonUtility.DBUtility.SetCommandTimeout(MasterAdapter)
            MasterAdapter.FillBySIYOUKBN(resultDataSets, strSIYOUKBN)

        End Using

        Return resultDataSets
    End Function

    ''' <summary>
    ''' データセット取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDataTable(ByVal strSIYOUKBN As String, ByVal strKBN As String) As dsMSE0040.M_KBNDataTable

        Dim resultDataSets As New dsMSE0040.M_KBNDataTable

        Using MasterAdapter As New dsMSE0040TableAdapters.M_KBNTableAdapter, _
            connection As New System.Data.SqlClient.SqlConnection(connectionString)

            MasterAdapter.Connection = connection
            CommonUtility.DBUtility.SetCommandTimeout(MasterAdapter)
            MasterAdapter.FillBySIYOUKBNKBN(resultDataSets, strSIYOUKBN, strKBN)

        End Using

        Return resultDataSets
    End Function
    ''' <summary>
    ''' 区分マスタ更新
    ''' </summary>
    ''' <param name="updateData">主キー</param>
    ''' <remarks></remarks>
    Public Sub UpdateData(ByVal updateData As dsMSE0040)

        Dim strSQL As String = ""
        Dim param() As SqlParameter
        Dim logic As New BLL.Common.ExecuteQuery

        Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope
            Dim connection As SqlConnection
            connection = New SqlConnection(connectionString)
            connection.Open()

            '使用区分００の更新
            strSQL = "merge into M_KBN as target"
            strSQL += "	using (values (@SIYOUKBN,@KBN,@KBNNAME, @UPDATEPGID,@UPDATEUSERCODE)) as source"
            strSQL += "		          ( SIYOUKBN, KBN, KBNNAME,  UPDATEPGID, UPDATEUSERCODE) on target.SIYOUKBN=source.SIYOUKBN"
            strSQL += "		                                                                            and target.KBN     =source.KBN"
            strSQL += "	when matched then"
            strSQL += "		update set target.KBNNAME        = source.KBNNAME"
            strSQL += "				  ,target.UPDATEMENT     = getdate()"
            strSQL += "				  ,target.UPDATEPGID     = source.UPDATEPGID"
            strSQL += "				  ,target.UPDATEUSERCODE = source.UPDATEUSERCODE"
            strSQL += "	when not matched by target then"
            strSQL += "		insert (SIYOUKBN ,KBN ,KBNNAME ,UPDATEMENT ,UPDATEPGID ,UPDATEUSERCODE)"
            strSQL += "		values (SIYOUKBN ,KBN ,KBNNAME ,getdate()  ,UPDATEPGID ,UPDATEUSERCODE);"

            param = New SqlParameter() {New SqlParameter("@SIYOUKBN", "00"), _
                                        New SqlParameter("@KBN", updateData.M_KBNUpdate(0).SIYOUKBN), _
                                        New SqlParameter("@KBNNAME", updateData.M_KBNUpdate(0).KBNNAME1), _
                                        New SqlParameter("@UPDATEPGID", updateData.M_KBNUpdate(0).UPDATEPGID), _
                                        New SqlParameter("@UPDATEUSERCODE", updateData.M_KBNUpdate(0).UPDATEUSERCODE)}
            logic.ExecuteNonQuery(connection, CommandType.Text, strSQL, param)

            '使用区分０１以降更新
            strSQL = "merge into M_KBN as target"
            strSQL += "	using (values (@SIYOUKBN,@KBN,@KBNNAME,@BIKO,@ATAI1,@ATAI2,@SYOKIHYOJIKBN,@UPDATEPGID,@UPDATEUSERCODE)) as source"
            strSQL += "		          ( SIYOUKBN, KBN, KBNNAME, BIKO, ATAI1, ATAI2, SYOKIHYOJIKBN, UPDATEPGID, UPDATEUSERCODE) on target.SIYOUKBN=source.SIYOUKBN"
            strSQL += "		                                                                                                  and target.KBN     =source.KBN"
            strSQL += "	when matched then"
            strSQL += "		update set target.KBNNAME        = source.KBNNAME"
            strSQL += "				  ,target.BIKO           = source.BIKO"
            strSQL += "				  ,target.ATAI1          = source.ATAI1"
            strSQL += "				  ,target.ATAI2          = source.ATAI2"
            strSQL += "				  ,target.SYOKIHYOJIKBN  = source.SYOKIHYOJIKBN"
            strSQL += "				  ,target.UPDATEMENT     = getdate()"
            strSQL += "				  ,target.UPDATEPGID     = source.UPDATEPGID"
            strSQL += "				  ,target.UPDATEUSERCODE = source.UPDATEUSERCODE"
            strSQL += "	when not matched by target then"
            strSQL += "		insert (SIYOUKBN ,KBN ,KBNNAME ,BIKO ,ATAI1 ,ATAI2 ,SYOKIHYOJIKBN ,UPDATEMENT ,UPDATEPGID ,UPDATEUSERCODE)"
            strSQL += "		values (SIYOUKBN ,KBN ,KBNNAME ,BIKO ,ATAI1 ,ATAI2 ,SYOKIHYOJIKBN ,getdate()  ,UPDATEPGID ,UPDATEUSERCODE);"

            param = New SqlParameter() {New SqlParameter("@SIYOUKBN", updateData.M_KBNUpdate(0).SIYOUKBN), _
                                        New SqlParameter("@KBN", updateData.M_KBNUpdate(0).KBN), _
                                        New SqlParameter("@KBNNAME", updateData.M_KBNUpdate(0).KBNNAME2), _
                                        New SqlParameter("@BIKO", updateData.M_KBNUpdate(0).BIKO), _
                                        New SqlParameter("@ATAI1", updateData.M_KBNUpdate(0).ATAI1), _
                                        New SqlParameter("@ATAI2", updateData.M_KBNUpdate(0).ATAI2), _
                                        New SqlParameter("@SYOKIHYOJIKBN", updateData.M_KBNUpdate(0).SYOKIHYOJIKBN), _
                                        New SqlParameter("@UPDATEPGID", updateData.M_KBNUpdate(0).UPDATEPGID), _
                                        New SqlParameter("@UPDATEUSERCODE", updateData.M_KBNUpdate(0).UPDATEUSERCODE)}

            logic.ExecuteNonQuery(connection, CommandType.Text, strSQL, param)

            '更新対象の初期表示区分が１の場合は他のレコードを０にする
            If updateData.M_KBNUpdate(0).SYOKIHYOJIKBN = 1 Then
                logic.ExecuteNonQuery(connection, CommandType.Text, "update M_KBN set SYOKIHYOJIKBN=0 where SIYOUKBN=@SIYOUKBN and KBN!=@KBN", _
                                      New SqlParameter() {New SqlParameter("@SIYOUKBN", updateData.M_KBNUpdate(0).SIYOUKBN), _
                                                          New SqlParameter("@KBN", updateData.M_KBNUpdate(0).KBN)})
            End If

            ts.Complete()

        End Using

    End Sub

    Public Sub DeleteData(ByVal strSIYOUKBN As String)

        Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope
            Dim connection As SqlConnection
            connection = New SqlConnection(connectionString)
            connection.Open()

            Dim logic As New BLL.Common.ExecuteQuery
            logic.ExecuteNonQuery(connection, CommandType.Text, "delete from M_KBN where SIYOUKBN=@SIYOUKBN and KBN=@KBN", _
                                  New SqlParameter() {New SqlParameter("@SIYOUKBN", "00"), _
                                                      New SqlParameter("@KBN", strSIYOUKBN)})

            logic.ExecuteNonQuery(connection, CommandType.Text, "delete from M_KBN where SIYOUKBN=@SIYOUKBN", _
                                  New SqlParameter() {New SqlParameter("@SIYOUKBN", strSIYOUKBN)})

            ts.Complete()

        End Using

    End Sub

    Public Sub DeleteData(ByVal strSIYOUKBN As String, ByVal strKBN As String)
        Dim logic As New BLL.Common.ExecuteQuery
        logic.ExecuteNonQuery(connectionString, CommandType.Text, "delete from M_KBN where SIYOUKBN=@SIYOUKBN and KBN=@KBN", _
                              New SqlParameter() {New SqlParameter("@SIYOUKBN", strSIYOUKBN), _
                                                  New SqlParameter("@KBN", strKBN)})
    End Sub


End Class
