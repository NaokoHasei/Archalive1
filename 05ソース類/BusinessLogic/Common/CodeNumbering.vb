Imports System.Data.SqlClient

Public Class CodeNumbering
    Inherits DAL.DALBase

    Enum enumKbn
        M_BUKA
        M_TANTO
        M_TOKUI
        M_SIIRE
        M_DAIKAMOKU
        M_CYUKAMOKU
        M_SYOKAMOKU
    End Enum

    Public Function GetNumer(ByVal kbn As Decimal) As Decimal
        Dim logic As New ExecuteQuery
        Dim tableName As String = vbNullString
        Dim code As String = vbNullString

        Select Case kbn
            Case enumKbn.M_TANTO
                tableName = "M_TANTO"
                code = "TANTOCODE"

            Case enumKbn.M_TOKUI
                tableName = "M_TOKUI"
                code = "TOKUICODE"

            Case enumKbn.M_SIIRE
                tableName = "M_SIIRE"
                code = "SIIRECODE"

            Case enumKbn.M_BUKA
                tableName = "M_BUKA"
                code = "BUKACODE"

            Case enumKbn.M_DAIKAMOKU
                tableName = "M_DAIKAMOKU"
                code = "DAIKAMOKUCODE"

            Case enumKbn.M_CYUKAMOKU
                tableName = "M_CYUKAMOKU"
                code = "CYUKAMOKUCODE"

            Case enumKbn.M_SYOKAMOKU
                tableName = "M_SYOKAMOKU"
                code = "SYOKAMOKUCODE"
        End Select

        Dim strSQL As String = vbNullString
        strSQL += " select isnull(min(" + code + " + 1), 1) as RESULT"
        strSQL += " from " + tableName
        strSQL += " where (" + code + " + 1) not in (select " + code + " from " + tableName + ")"

        Dim ds As DataSet = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL)

        Return CDec(ds.Tables(0).Rows(0).Item("RESULT"))
    End Function

End Class
