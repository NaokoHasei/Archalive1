Imports System.Windows.Forms
Imports C1.Win.C1TrueDBGrid

Public Class WinFormUtility

    Public Shared Function GridPointAtCell(ByVal grid As C1TrueDBGrid) As Boolean
        Dim r As Integer
        Dim c As Integer
        Dim p As System.Drawing.Point = grid.PointToClient(System.Windows.Forms.Control.MousePosition)
        grid.CellContaining(p.X, p.Y, r, c)

        If r <> -1 And c <> -1 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Shared Function GetAllControl(ByVal form As Form) As List(Of Control)
        Dim controlList As List(Of Control) = New List(Of Control)
        Dim utilityObjct As New WinFormUtility

        utilityObjct.GetAllControl_loop(form, controlList)

        Return controlList
    End Function

    Private Sub GetAllControl_loop(ByVal parentControl As Control, ByVal controlList As List(Of Control))

        For Each c As Control In parentControl.Controls
            GetAllControl_loop(c, controlList)

            controlList.Add(c)
        Next

    End Sub

    Public Shared Function OpenFileDialog(ByVal Title As String, _
                                   ByVal InitialDirectory As String, _
                                   ByVal FileName As String, _
                                   ByVal Filter_ As String, _
                                   Optional ByVal FilterIndex As Integer = 1, _
                                   Optional ByVal RestoreDirectory As Boolean = False, _
                                   Optional ByVal Multiselect As Boolean = False, _
                                   Optional ByVal ShowHelp As Boolean = False, _
                                   Optional ByVal ShowReadOnly As Boolean = False, _
                                   Optional ByVal ReadOnlyChecked As Boolean = False, _
                                   Optional ByVal CheckFileExists As Boolean = True, _
                                   Optional ByVal CheckPathExists As Boolean = True, _
                                   Optional ByVal AddExtension As Boolean = True, _
                                   Optional ByVal ValidateNames As Boolean = True) As String()

        Dim intIndex As Integer
        Dim strReturn() As String
        ReDim strReturn(0)

        ' OpenFileDialog の新しいインスタンスを生成する (デザイナから追加している場合は必要ない)
        Using OpenFileDialog1 As New OpenFileDialog()

            OpenFileDialog1.Title = Title                       'ダイアログのタイトルを設定する
            OpenFileDialog1.InitialDirectory = InitialDirectory '初期表示するディレクトリを設定する
            OpenFileDialog1.FileName = FileName                 '初期表示するファイル名を設定する
            OpenFileDialog1.Filter = Filter_                    'ファイルのフィルタを設定する
            OpenFileDialog1.FilterIndex = FilterIndex           'ファイルの種類 の初期設定を 2 番目に設定する (初期値 1)
            OpenFileDialog1.RestoreDirectory = RestoreDirectory 'ダイアログボックスを閉じる前に現在のディレクトリを復元する (初期値 False)
            OpenFileDialog1.Multiselect = Multiselect           '複数のファイルを選択可能にする (初期値 False)
            OpenFileDialog1.ShowHelp = ShowHelp                 '[ヘルプ] ボタンを表示する (初期値 False)
            OpenFileDialog1.ShowReadOnly = ShowReadOnly         '[読み取り専用] チェックボックスを表示する (初期値 False)
            OpenFileDialog1.ReadOnlyChecked = ReadOnlyChecked   '[読み取り専用] チェックボックスをオンにする (初期値 False)
            OpenFileDialog1.CheckFileExists = CheckFileExists   '存在しないファイルを指定した場合は警告を表示する (初期値 True)
            OpenFileDialog1.CheckPathExists = CheckPathExists   '存在しないパスを指定した場合は警告を表示する (初期値 True)
            OpenFileDialog1.AddExtension = AddExtension         '拡張子を指定しない場合は自動的に拡張子を付加する (初期値 True)
            OpenFileDialog1.ValidateNames = ValidateNames       '有効な Win32 ファイル名だけを受け入れるようにする (初期値 True)

            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then ' ダイアログを表示し、戻り値が [OK] の場合は、選択したファイルを表示する
                If Multiselect Then
                    intIndex = 0
                    For Each nFileName As String In OpenFileDialog1.FileNames
                        ReDim Preserve strReturn(intIndex)
                        strReturn(intIndex) = nFileName
                        intIndex += 1
                    Next nFileName
                Else
                    strReturn(0) = OpenFileDialog1.FileName
                End If
            End If

            ' 不要になった時点で破棄する (正しくは オブジェクトの破棄を保証する を参照)
            OpenFileDialog1.Dispose()

        End Using

        Return strReturn

    End Function

End Class
