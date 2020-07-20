Public Class OperationFile

    Enum Delete
        FileName
        TimeStamp
    End Enum

    ''' <summary>
    ''' ファイル削除
    ''' </summary>
    ''' <param name="path"></param>
    ''' <param name="DelDay"></param>
    ''' <param name="Search"></param>
    ''' <remarks></remarks>
    Public Shared Sub DeleteFile(ByVal path As String, ByVal DelDay As Integer, ByVal Search As OperationFile.Delete)

        If Not System.IO.Directory.Exists(path) Then Return

        If Not path.EndsWith("\") Then path += "\"

        Dim folder As New System.IO.DirectoryInfo(path)
        Dim file As System.IO.FileInfo
        Dim DelDate As String = Now.AddDays(Search * -1).ToString("yyyy/MM/dd")

        Dim FileDate As String = DelDate
        For Each file In folder.GetFiles("*.*", System.IO.SearchOption.TopDirectoryOnly)

            If Search = Delete.FileName Then
                FileDate = CommonUtility.Utility.RightBSA(file.Name.Replace(file.Extension, ""), 8)
            ElseIf Search = Delete.TimeStamp Then
                FileDate = file.LastWriteTime.ToString("yyyy/MM/dd")
            Else

            End If

            If FileDate < DelDate Then
                file.Delete()
            End If

        Next


    End Sub

    ''' <summary>
    ''' ファイル削除
    ''' </summary>
    ''' <param name="path"></param>
    ''' <param name="file"></param>
    ''' <param name="DelDay"></param>
    ''' <remarks></remarks>
    Public Shared Sub DeleteFile(ByVal path As String, ByVal file As String, ByVal DelDay As Integer)

    End Sub

    ''' <summary>
    ''' ディレクトリ削除
    ''' </summary>
    ''' <param name="path"></param>
    ''' <remarks></remarks>
    Public Shared Sub DeleteDirectory(ByVal path As String)
        System.IO.Directory.Delete(path)
    End Sub

    ''' <summary>
    ''' ディレクトリ作成
    ''' </summary>
    ''' <param name="path"></param>
    ''' <remarks></remarks>
    Public Shared Sub CreateDirectory(ByVal path As String)
        If Not path.EndsWith("\") Then path += "\"
        System.IO.Directory.CreateDirectory(path)
    End Sub

    '
    ' 機　能：ディレクトリ作成
    '
    ' 戻り値：なし
    '
    ' 引　数：ディレクトリ名
    '
    Public Shared Sub pMakeDirectory(ByVal strFileName As String)

        '*** 変数宣言 ***
        Dim intWrk As Integer      'ワーク
        Dim strWrk As String       'ワーク

        '*** ファイル名編集 ***
        If Left(Right(strFileName, 4), 1) = "." Then
            'ファイル名
        Else
            'フォルダ名
            If Right(strFileName, 1) <> "\" Then
                strFileName = strFileName & "\"
            End If
        End If

        '*** 初期値 ***
        intWrk = 3   '(strFileName = "C:\XXX\XXX\XXX")

        Do
            '***「\」検索 ***
            intWrk = InStr(intWrk + 1, strFileName, "\")
            If intWrk = 0 Then Exit Do

            '*** フォルダ名取得 ***
            strWrk = Left(strFileName, intWrk)

            If Dir(strWrk, vbDirectory) = vbNullString Then
                '*** フォルダ作成 ***
                MkDir(strWrk)
            End If

        Loop

    End Sub

    Public Sub New()



    End Sub

End Class
