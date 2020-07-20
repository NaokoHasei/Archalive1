Imports System.Data.SqlClient

Public Class M_TOKUIread
    Private connectionString As String

    ''' <summary>
    ''' クラス初期化
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    Public Function ReadM_TOKUI(ByVal Key As String) As dsM_TOKUI.M_TOKUIDataTable
        Dim resultDataSet As New dsM_TOKUI.M_TOKUIDataTable
        Using adp As New dsM_TOKUITableAdapters.M_TOKUITableAdapter,
            connection As New SqlConnection(connectionString)
            adp.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(adp)
            adp.Fill(resultDataSet, Key)
        End Using
        Return resultDataSet
    End Function
End Class
