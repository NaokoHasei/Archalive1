Imports System.Diagnostics

Public Class Main
    Public Overrides Function PROGRAM_ID() As String
        Return "SAMPLE0001"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "サンプル"
    End Function

    Friend Enum 登録処理
        新規
        編集
        削除
    End Enum

    Private dt As BLL.Common.dsS_MESSAGE.S_MESSAGEViewDataTable
    Private adp As New BLL.Common.dsS_MESSAGETableAdapters.S_MESSAGEViewTableAdapter

    Private WithEvents 個別選択業者 As WinFormBase.KobetuControl
    Private WithEvents 個別選択担当者 As WinFormBase.KobetuControl
    Private WithEvents 個別選択顧客 As WinFormBase.KobetuControl

    Private WithEvents 個別選択業者REG As WinFormBase.KobetuControl
    Private WithEvents 個別選択担当者REG As WinFormBase.KobetuControl
    Private WithEvents 個別選択顧客REG As WinFormBase.KobetuControl

    Protected Overrides Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        Call InitializeFunctionKeys()

        Call 画面初期化()

        Call コンボボックス初期化()

        Call メッセージ情報取得()

        TextBoxEx1.AllowDrop = True

        個別選択顧客REG = New WinFormBase.KobetuControl(SENTAKU_TOKUIREG, Model.KobetuTableName.M_TOKUI, PCNAME, PROGRAM_ID, 0, TANTO_CODE, Model.InitializeKind.初期化_過去データ取得, Model.FinalizeKind.削除_過去データ登録)
        個別選択担当者REG = New WinFormBase.KobetuControl(SENTAKU_TANTOREG, Model.KobetuTableName.M_TANTO, PCNAME, PROGRAM_ID, 0, TANTO_CODE, Model.InitializeKind.初期化_過去データ取得, Model.FinalizeKind.削除_過去データ登録)
        個別選択業者REG = New WinFormBase.KobetuControl(SENTAKU_SIIREREG, Model.KobetuTableName.M_SIIRE, PCNAME, PROGRAM_ID, 0, TANTO_CODE, Model.InitializeKind.初期化_過去データ取得, Model.FinalizeKind.削除_過去データ登録)

        個別選択顧客 = New WinFormBase.KobetuControl(SENTAKU_TOKUI, Model.KobetuTableName.M_TOKUI, PCNAME, PROGRAM_ID, 1, TANTO_CODE, Model.InitializeKind.初期化_完全初期化, Model.FinalizeKind.削除_完全削除)
        個別選択担当者 = New WinFormBase.KobetuControl(SENTAKU_TANTO, Model.KobetuTableName.M_TANTO, PCNAME, PROGRAM_ID, 1, TANTO_CODE, Model.InitializeKind.初期化_完全初期化, Model.FinalizeKind.削除_完全削除)
        個別選択業者 = New WinFormBase.KobetuControl(SENTAKU_SIIRE, Model.KobetuTableName.M_SIIRE, PCNAME, PROGRAM_ID, 1, TANTO_CODE, Model.InitializeKind.初期化_完全初期化, Model.FinalizeKind.削除_完全削除)

    End Sub

    Private Sub メッセージ情報取得()

        Dim mi As New WinFormBase.MessageBase

        dt = mi.MessageInfo.S_MESSAGEView

        With DataGridView1
            .DataSource = dt
            .ReadOnly = False
            .AllowUserToAddRows = True
            .AllowUserToDeleteRows = True
            .AllowUserToOrderColumns = False
        End With


        With DataGridView2
            '.AutoGenerateColumns = False
            'Dim ColumnType As DataGridViewComboBoxColumn
            'ColumnType = New DataGridViewComboBoxColumn
            'With ColumnType
            '    .Name = "MESSAGE"
            'End With
            '.Columns.Add(ColumnType)

            'Dim ColumnTypet = New DataGridViewTextBoxColumn
            'With ColumnTypet
            '    .Name = "MSGCODE"
            'End With
            '.Columns.Add(ColumnType)


            '.DataSource = dt
            '.ReadOnly = False
            '.AllowUserToAddRows = True
            '.AllowUserToDeleteRows = True
            '.AllowUserToOrderColumns = False

            'Dim cbc As New DataGridViewComboBoxColumn
            'cbc = CType(DataGridView2.Columns(0), DataGridViewComboBoxColumn)

            'cbc.DataSource = dt
            'cbc.ValueMember = "MESSAGE"
            'cbc.DisplayMember = "MSGCODE"

        End With



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        adp.Update(dt)

    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError


        MsgBox(e.Exception.Message)
    End Sub

    Private Sub InitializeFunctionKeys()

        For intIndex As Integer = 1 To 12
            FunctionKey.SetItem(intIndex, "", "", False)
        Next

        FunctionKey.SetItem(1, "終了", "終了", True)

    End Sub

    Private Sub 画面初期化()

        With TreeView1

            'TreeView1へのドラッグを受け入れる
            .AllowDrop = True

            'ノードを追加する
            .Nodes.Add("いち")
            .Nodes(0).Nodes.Add("よん")
            .Nodes(0).Nodes(0).Nodes.Add("ご")
            .Nodes.Add("に")
            .Nodes.Add("さん")

            'イベントハンドラを追加する
            AddHandler .ItemDrag, AddressOf TreeView1_ItemDrag
            AddHandler .DragOver, AddressOf TreeView1_DragOver
            AddHandler .DragDrop, AddressOf TreeView1_DragDrop

        End With

    End Sub

    Private Sub コンボボックス初期化()

    End Sub

    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)

        Select Case e.Name

            Case "終了"

                Me.Close()

                Exit Sub
        End Select

        LastFocusedControl.Focus()

    End Sub

    Private Sub TextBoxEx1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TextBoxEx1.DragDrop
        Dim fileName As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())

        If fileName.Length > 1 Then
            MsgBox("ファイルが" + fileName.Length.ToString + "つあります。", MsgBoxStyle.Exclamation, PROGRAM_NAME)
            Return
        End If

        TextBoxEx1.Text = fileName(0).ToString
    End Sub


    Private Sub TextBoxEx1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TextBoxEx1.DragEnter

        'データ形式の確認
        If e.Data.GetDataPresent(DataFormats.FileDrop) = False Then
            Return
        End If

        'ドラッグしているファイル／フォルダの取得
        Dim FilePath() As String = _
         CType(e.Data.GetData(DataFormats.FileDrop), String())

        For idx As Integer = 0 To FilePath.Length - 1
            If Not System.IO.File.Exists(FilePath(idx)) Then
                Return
            End If
        Next idx

        'ドロップ可能な場合は、エフェクトを変える
        e.Effect = DragDropEffects.Copy

    End Sub

    'ノードがドラッグされた時
    Private Sub TreeView1_ItemDrag(ByVal sender As Object, _
            ByVal e As ItemDragEventArgs)
        Dim tv As TreeView = CType(sender, TreeView)
        tv.SelectedNode = CType(e.Item, TreeNode)
        tv.Focus()

        'ノードのドラッグを開始する
        Dim dde As DragDropEffects = _
            tv.DoDragDrop(e.Item, DragDropEffects.All)

        '移動した時は、ドラッグしたノードを削除する
        If (dde And DragDropEffects.Move) = DragDropEffects.Move Then
            tv.Nodes.Remove(CType(e.Item, TreeNode))
        End If
    End Sub

    'ドラッグしている時
    Private Sub TreeView1_DragOver(ByVal sender As Object, _
            ByVal e As DragEventArgs)
        'ドラッグされているデータがTreeNodeか調べる
        If e.Data.GetDataPresent(GetType(TreeNode)) Then
            If (e.KeyState And 8) = 8 And _
                (e.AllowedEffect And DragDropEffects.Copy) = _
                    DragDropEffects.Copy Then
                'Ctrlキーが押されていればCopy
                '"8"はCtrlキーを表す
                e.Effect = DragDropEffects.Copy
            ElseIf (e.AllowedEffect And DragDropEffects.Move) = _
                DragDropEffects.Move Then
                '何も押されていなければMove
                e.Effect = DragDropEffects.Move
            Else
                e.Effect = DragDropEffects.None
            End If
        Else
            'TreeNodeでなければ受け入れない
            e.Effect = DragDropEffects.None
        End If

        'マウス下のNodeを選択する
        If e.Effect <> DragDropEffects.None Then
            Dim tv As TreeView = CType(sender, TreeView)
            'マウスのあるNodeを取得する
            Dim target As TreeNode = _
                tv.GetNodeAt(tv.PointToClient(New System.Drawing.Point(e.X, e.Y)))
            'ドラッグされているNodeを取得する
            Dim [source] As TreeNode = _
                CType(e.Data.GetData(GetType(TreeNode)), TreeNode)
            'マウス下のNodeがドロップ先として適切か調べる
            If Not target Is Nothing AndAlso _
                Not target Is [source] AndAlso _
                Not IsChildNode([source], target) Then
                'Nodeを選択する
                If target.IsSelected = False Then
                    tv.SelectedNode = target
                End If
            Else
                e.Effect = DragDropEffects.None
            End If
        End If
    End Sub

    'ドロップされたとき
    Private Sub TreeView1_DragDrop(ByVal sender As Object, _
            ByVal e As DragEventArgs)
        'ドロップされたデータがTreeNodeか調べる
        If e.Data.GetDataPresent(GetType(TreeNode)) Then
            Dim tv As TreeView = CType(sender, TreeView)
            'ドロップされたデータ(TreeNode)を取得
            Dim [source] As TreeNode = _
                CType(e.Data.GetData(GetType(TreeNode)), TreeNode)
            'ドロップ先のTreeNodeを取得する
            Dim target As TreeNode = _
                tv.GetNodeAt(tv.PointToClient(New System.Drawing.Point(e.X, e.Y)))
            'マウス下のNodeがドロップ先として適切か調べる
            If Not target Is Nothing AndAlso _
                Not target Is [source] AndAlso _
                Not IsChildNode([source], target) Then
                'ドロップされたNodeのコピーを作成
                Dim cln As TreeNode = CType([source].Clone(), TreeNode)
                'Nodeを追加
                target.Nodes.Add(cln)
                'ドロップ先のNodeを展開
                target.Expand()
                '追加されたNodeを選択
                tv.SelectedNode = cln
            Else
                e.Effect = DragDropEffects.None
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    ''' <summary>
    ''' あるTreeNodeが別のTreeNodeの子ノードか調べる
    ''' </summary>
    ''' <param name="parentNode">親ノードか調べるTreeNode</param>
    ''' <param name="childNode">子ノードか調べるTreeNode</param>
    ''' <returns>子ノードの時はTrue</returns>
    Private Shared Function IsChildNode( _
            ByVal parentNode As TreeNode, _
            ByVal childNode As TreeNode) As Boolean
        If childNode.Parent Is parentNode Then
            Return True
        ElseIf Not childNode.Parent Is Nothing Then
            Return IsChildNode(parentNode, childNode.Parent)
        Else
            Return False
        End If
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Try
            'http://www.moonmile.net/blog/archives/2669
            Dim root As New System.DirectoryServices.DirectoryEntry("LDAP://171.2.1.1/OU=employee,DC=typical,DC=local", "kosaka", "kosaka03")
            Dim obj = root.NativeObject
            Dim se As New System.DirectoryServices.DirectorySearcher(root)
            Dim de2 As System.DirectoryServices.DirectoryEntry = Nothing
            ListBox1.Items.Clear()
            Dim de As New System.DirectoryServices.DirectoryEntry()
            For Each res As System.DirectoryServices.SearchResult In se.FindAll
                de = res.GetDirectoryEntry

                'ListBox1.Items.Add(de.Path + " " + CommonUtility.Utility.NS(de.Properties("cn").Value))
                'MsgBox(de.Properties("displayName").Value)
                'If de.Path.IndexOf("TKOSAKA") >= 0 Then
                de2 = de
                'End If
                ListBox1.Items.Add(CommonUtility.Utility.NS(de.Properties("displayName").Value))
            Next

            If de2 IsNot Nothing Then
                For Each nm As String In de2.Properties.PropertyNames
                    'ListBox2.Items.Add(nm)
                    'ListBox1.Items.Add(CommonUtility.Utility.NS(de.Properties("displayName").Value))
                Next
            End If
        Catch ex As System.DirectoryServices.DirectoryServicesCOMException

            MsgBox(ex.Message)

        Catch ex As System.Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Using f As New SubForm1
            f.ShowDialog()
        End Using
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Process.Start("JYU0002.exe", "1")
    End Sub

 

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Panel1.Enabled = Not Panel1.Enabled
    End Sub

End Class