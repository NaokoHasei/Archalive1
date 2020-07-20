Public Class KobetuSentakuUtility

    ''' <summary>
    ''' 個別選択のチェック更新用データテーブルを作成します。
    ''' </summary>
    ''' <param name="codeFieldName">CLASSCODE,TENCODE等を指定します。</param>
    ''' <param name="srcDataTable">コピー元のデータテーブルを指定します。</param>
    ''' <param name="AlwaysChecked">コピー元のCHKARIAにかかわらず-1に設定します。</param>
    ''' <returns>Updateの引数に指定可能なデータテーブル</returns>
    ''' <remarks>codeFieldNameで指定されたフィールド名でソースデータテーブルのアクセスと作成されるフィールド名を決定します。</remarks>
    Public Shared Function MakeSentakuUpdateDataTable(ByVal codeFieldName As String, ByVal srcDataTable As DataTable, ByVal AlwaysChecked As Boolean) As DataTable
        Dim dt As New System.Data.DataTable
        Dim dr As System.Data.DataRow

        dt.Columns.Add("CHKARIA", Type.GetType("System.Int32"))
        dt.Columns.Add(codeFieldName, Type.GetType("System.String"))

        For Each row As DataRow In srcDataTable.Rows

            If row.RowState <> DataRowState.Deleted Then
                dr = Nothing
                dr = dt.NewRow()
                dr.BeginEdit()
                If AlwaysChecked = False Then
                    dr.Item("CHKARIA") = row("CHKARIA")
                Else
                    dr.Item("CHKARIA") = -1
                End If
                dr.Item(codeFieldName) = row(codeFieldName)
                dr.EndEdit()
                dt.Rows.Add(dr)
            End If

        Next

        Return dt

    End Function

End Class
