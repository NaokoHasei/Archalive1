Public Class daMSE0020

    Private connectionString As String

    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    Public Function fncReadS_SCB() As DataSet
        Dim logic As New BLL.Common.ExecuteQuery
        Dim strSQL As String
        Dim ds As System.Data.DataSet

        '初期化

        fncReadS_SCB = Nothing

        strSQL = vbNullString
        strSQL += " SELECT"
        strSQL += " convert(bit,0) as DELETEKEY" & vbCrLf
        strSQL += ",CATEGORYID" & vbCrLf
        strSQL += ",DATAKEY" & vbCrLf
        strSQL += ",DATA" & vbCrLf
        strSQL += ",COMMENT" & vbCrLf
        strSQL += ",convert(bit,0) as INSERTKEY" & vbCrLf
        strSQL += ",convert(bit,0) as UPDATEKEY" & vbCrLf
        strSQL += " FROM S_SCB" & vbCrLf

        ds = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL)

        Return ds
    End Function

    ''' <summary>
    ''' データ追加
    ''' </summary>
    Public Sub InsertData(
              ByVal strCATEGORYID As String _
            , ByVal strDATAKEY As String _
            , ByVal strDATA As String _
            , ByVal strCOMMENT As String _
            , ByVal strPROGRAMID As String _
            , ByVal strUserID As String)

        Dim logic As New BLL.Common.ExecuteQuery

        Dim strSQL As String

        strSQL = "insert into S_SCB"
        strSQL = strSQL & " ("
        strSQL = strSQL & "    CATEGORYID"
        strSQL = strSQL & "  , DATAKEY"
        strSQL = strSQL & "  , DATA"
        strSQL = strSQL & "  , COMMENT"
        strSQL = strSQL & "  , UPDATEPGID"
        strSQL = strSQL & "  , UPDATEUSERID"
        strSQL = strSQL & " ) VALUES ("
        strSQL = strSQL & "    '" & strCATEGORYID & "'"
        strSQL = strSQL & "  , '" & strDATAKEY & "'"
        strSQL = strSQL & "  , '" & strDATA & "'"
        strSQL = strSQL & "  , '" & strCOMMENT & "'"
        strSQL = strSQL & "  , '" & strPROGRAMID & "'"
        strSQL = strSQL & "  , '" & strUserID & "'"
        strSQL = strSQL & " )"

        'データ追加
        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL)
    End Sub

    ''' <summary>
    ''' データ更新
    ''' </summary>
    Public Sub UpdateData(
              ByVal strCATEGORYID As String _
            , ByVal strDATAKEY As String _
            , ByVal strDATA As String _
            , ByVal strCOMMENT As String _
            , ByVal strPROGRAMID As String _
            , ByVal strUserID As String _
            , ByVal strCATEGORYID_Before As String _
            , ByVal strDATAKEY_Before As String _
            , ByVal strDATA_Before As String)

        Dim logic As New BLL.Common.ExecuteQuery

        Dim strSQL As String = ""

        strSQL = strSQL & vbCrLf & "update S_SCB set"
        strSQL = strSQL & vbCrLf & "    CATEGORYID = '" & strCATEGORYID & "'"
        strSQL = strSQL & vbCrLf & "  , DATAKEY   = '" & strDATAKEY & "'"
        strSQL = strSQL & vbCrLf & "  , DATA         = '" & strDATA & "'"
        strSQL = strSQL & vbCrLf & "  , COMMENT      = '" & strCOMMENT & "'"
        strSQL = strSQL & vbCrLf & "  , UPDATEMENT   = '" & System.DateTime.Now & "'"
        strSQL = strSQL & vbCrLf & "  , UPDATEPGID   = '" & strPROGRAMID & "'"
        strSQL = strSQL & vbCrLf & "  , UPDATEUSERID = '" & strUserID & "'"
        strSQL = strSQL & vbCrLf & "where CATEGORYID = '" & strCATEGORYID_Before & "'"
        strSQL = strSQL & vbCrLf & "and DATAKEY      = '" & strDATAKEY_Before & "'"
        strSQL = strSQL & vbCrLf & "and DATA         = '" & strDATA_Before & "'"

        'データ更新
        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL)
    End Sub

    ''' <summary>
    ''' データ削除
    ''' </summary>
    Public Sub DeleteData(ByVal strCATEGORYID As String, ByVal strDATAKEY As String, ByVal strDATA As String)

        Dim logic As New BLL.Common.ExecuteQuery

        Dim strSQL As String

        strSQL = "delete from S_SCB"
        strSQL = strSQL & " where CATEGORYID = '" & strCATEGORYID & "'"
        strSQL = strSQL & " and DATAKEY = '" & strDATAKEY & "'"
        strSQL = strSQL & " and DATA= '" & strDATA & "'"

        'データ削除
        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL)
    End Sub

End Class
