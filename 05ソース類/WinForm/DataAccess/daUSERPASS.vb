Imports System.Data.SqlClient

Public Class daUSERPASS

    Private connectionString As String

    ''' <summary>
    ''' クラス初期化
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    Public Function LoginCheck(ByVal tantoCode As String, ByVal password As String) As Boolean
        Dim logic As New BLL.Common.ExecuteQuery
        Dim strSQL As String = vbNullString

        strSQL += vbCrLf & "select count(*) as CNT"
        strSQL += vbCrLf & "from M_TANTO"
        strSQL += vbCrLf & "where TANTOCODE            = @TANTOCODE"
        strSQL += vbCrLf & "and   isnull(PASSWORD, '') = @PASSWORD"

        Dim param() As SqlParameter = New SqlParameter() {
            New SqlParameter("@TANTOCODE", tantoCode),
            New SqlParameter("@PASSWORD", password)
        }

        Dim ds As DataSet = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL, param)

        If ds.Tables(0).Rows(0).Item("CNT").ToString = "0" Then
            Return False
        End If

        Return True
    End Function

    Public Sub CreateNowUser(
             ByVal PCNAME As String _
           , ByVal PROGRAM_ID As String _
           , ByVal tantoCode As String)

        Dim logic As New BLL.Common.ExecuteQuery
        Dim strSQL As String = vbNullString

        strSQL += " delete from M_NOWUSER where PCNAME = @PCNAME;"

        strSQL += " insert into M_NOWUSER"
        strSQL += " values ("
        strSQL += "     @PCNAME"
        strSQL += "   , @TANTOCODE"
        strSQL += "   , ''"
        strSQL += "   , getdate()"
        strSQL += "   , @UPDATEPGID"
        strSQL += "   , @TANTOCODE"
        strSQL += "   , getdate()"
        strSQL += "   , getdate()"
        strSQL += " )"

        Dim param() As SqlParameter = New SqlParameter() {
            New SqlParameter("@PCNAME", PCNAME),
            New SqlParameter("@TANTOCODE", tantoCode),
            New SqlParameter("@UPDATEPGID", PROGRAM_ID)
        }

        logic.ExecuteDataset(connectionString, CommandType.Text, strSQL, param)
    End Sub
End Class