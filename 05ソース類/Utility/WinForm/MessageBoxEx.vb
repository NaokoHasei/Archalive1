Imports System.Windows.Forms
Imports System.Collections.Specialized

Public Class MessageBoxEx

    Public Shared nvcMessage As NameValueCollection

    Public Shared Function GetMessage(ByVal messageCode As MessageCode_Arg0) As String
        Dim s As String = nvcMessage(Utility.ZeroPadding(CType(messageCode, Integer).ToString, 3))
        Dim messageStr As String = Split(s, ",")(1)

        Return messageStr
    End Function

    Public Shared Function GetMessage(ByVal messageCode As MessageCode_Arg1, ByVal arg1 As String) As String
        Dim s As String = nvcMessage(Utility.ZeroPadding(CType(messageCode, Integer).ToString, 3))
        Dim messageStr As String = Split(s, ",")(1)
        messageStr = String.Format(messageStr, arg1)

        Return messageStr
    End Function

    Public Shared Function GetMessage(ByVal messageCode As MessageCode_Arg2, ByVal arg1 As String, ByVal arg2 As String) As String
        Dim s As String = nvcMessage(Utility.ZeroPadding(CType(messageCode, Integer).ToString, 3))
        Dim messageStr As String = Split(s, ",")(1)
        messageStr = String.Format(messageStr, arg1, arg2)

        Return messageStr
    End Function

    Public Shared Function Show(ByVal messageCode As MessageCode_Arg0, ByVal caption As String) As DialogResult
        Select Case messageCode
            Case MessageCode_Arg0.M001登録してもよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M002削除してもよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M003取消してもよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M004実行してもよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M005印刷してもよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M006未発行の伝票があります印字しますか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M007書き換えてもよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M008画面の登録を行っていませんがよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M009該当データがありません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M010基本設定マスタ情報が存在しません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M011該当する区分はありません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M012指定コードはマスタに登録されていません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M013メンテナンスで登録後実行して下さい
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M028現在使用できません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M032訂正できません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M033削除対象データです
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M034該当する伝票がありません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M035売上モニタで入力された伝票の為修正削除できません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M038各数値項目の入力値の桁数を確認して下さい
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M039請求先しか指定できません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M040同一伝票が存在しますＳＣＢマスタの伝票Ｎｏを変更して下さい
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M041該当日付の月次帳票は出力済みですがよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M042前回の出力年月より離れていますがよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M043該当メッセージなし
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M044該当メッセージなし
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M045該当メッセージなし
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M046このコンピュータは端末マスタに未登録です
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M047該当メッセージなし
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M048日付の訂正はできません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M050日付が小さすぎます
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M051日付が大きすぎます
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M052この日付で処理できません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M053現在管理日付より２ヶ月以上先の日付が入力されました
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M054集計処理済みの日付です集計取消後に入力を行って下さい
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M055集計処理済みの日付ですよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M056棚卸初期処理が実行されていません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M057棚卸対象ではありません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M058現在棚卸中です処理を実行すると現在の棚卸は中断されます
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M059該当メッセージなし
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M060予期せぬエラーが発生しました
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M061指定されたデータは現在編集中です
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M062しばらくしてから処理を行って下さい
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M063システムが停止または起動途中です
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M064本部システムに接続できません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M065システムの更新に失敗しました
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M066他ユーザによりデータが変更されています
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M067現在の更新は全て破棄されました
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M068ＩＮＩが見つかりません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M069ＩＮＩのプリンタの設定が正しくありません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M070システム管理用コードの為使用できません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M071他の業務が実行中です終了後実行してください
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M072本店一括請求の請求先です使用できません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M073返品伝票にプラス値が入力されていますよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M074設定内容が矛盾しています
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M077桁数の大きい数値が入力されましたよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M0781000件以上の商品が選択されています
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M081入荷済みの為削除できません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M082この発注は入荷が完了している為使用できません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M083ＢＨＴ情報が存在します使用しますか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M084訂正後の発注書を印刷しますか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M085入荷数以下の数量は設定できません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M086発注数以上の仕入が発生しています
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M087発注停止商品です
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M091当月実績が存在する為削除できません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M092在庫が存在します削除しますか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M093３回間違えたので強制終了します
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M094パスワード変更はパスワードが入力されていることが前提です
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M095パスワードの有効期限が過ぎていますパスワードを変更してください
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M096入力されたユーザーコードは現在使用中です
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M099正常終了しました
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M100市区町村名が指定桁数を超えました住所欄下段に表示されている市区町村名をコピーして指定桁数に収まるよう入力して下さい
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M102回線に接続できませんPCまたはサーバーに異常がないか確認してください再接続しますか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M103現在進行中の作業を破棄し終了してもよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M104現在この端末にログインしているユーザーコードは削除できません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M105全削除してもよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M106行削除してもよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M107このコードは使用できません
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M110再接続ができました再度処理を行ってください
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M112既に入力されている商品と重複しています
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M113重複データは反映されません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M114チェックデジットが違いますがよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M115売価金額が入力されている商品が存在します0円に書き換えますか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M116集計対象内に仮伝が存在しますがよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M117通常商品と委託商品を混在して入力はできません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M118仕入伝票が存在するため商品区分の変更はできません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M119委託商品コードが選択されています仕入先コードが一致していません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M120委託商品コードが選択されています商品区分を確認して下さい
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M121仕入先コードに委託先が設定されています商品区分２_委託商品_ではありませんがよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M131ＦＡＸの送信に失敗した仕入先があります
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M132新ＪＡＮコードの取得に失敗しました_MAX連番を超えました_
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M133他端末にて同一委託者の商品コードが発番されている可能性があります再度印刷を行って下さい
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M134他端末にて同一委託者のＪＡＮコードが発番されている可能性があります再度印刷を行って下さい
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M135更新反映されていない取込データが存在しますこのまま終了しますか_データは残ります_
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M136仕入単価に掛率を反映して売単価を計算しますよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M137ＣＳＶデータを取り込みますよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M138エラーデータが存在するため実行できません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M139原価売価を再取得しますよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M140この仕入先日付では発注できない商品です
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M141この仕入先はＥＯＳ対象ではありません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M142正常データのみで実行しますよろしいですか_エラーデータは残ります_
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M143同一請求期間内に既に別の会社コードで伝票入力されています
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M155承認してもよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M156解除してもよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M157該当見積の処理区分を変更してもよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M158指定した見積情報をコピーしますか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M159コピーする場合は上書きにしますか_はい上書き_いいえ追加
                Return Show(messageCode, caption, MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M160この階層を削除してもよろしいですか元には戻せません
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M161この階層以降の階層も削除されますが本当に削除してもよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M162引き続き印刷してもよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M163入力された受注Ｎｏは顧客コードが異なります
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M164複数の受注Noが選択されましたすべて同じ場所に出力しますか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M168見積ｼｽﾃﾑｴﾗｰ168分析表用のExcelﾃﾝﾌﾟﾚｰﾄが見つかりません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M169該当見積情報は既に承認されています参照はできますが訂正や削除は行なえません訂正削除には承認の解除が必要となります
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M170該当見積情報はまだ承認されていません先に見積承認を行なってください
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M171該当受注情報は既に発注が発生しております参照はできますが訂正や削除は行なえません
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M172該当受注情報には発注先の業者が指定されていません先に発注業者を指定してください
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M173未請求額0以下のデータが存在します
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M176受注済の見積情報が指定されました指定する場合には受注入力での解除が必要となります
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M178科目品目を変更しますか下位の階層との紐付けが外れる可能性がございます
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M179行切取から行貼付を選択されましたこの場合下位の層は移動されませんがよろしいですか
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M201電子ジャーナルのコピーに失敗しました
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M202手作業にてコピー及び削除を行って下さい
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M203電子ジャーナルTEMP情報の削除に失敗しました
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M204手作業にて削除を行って下さい
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M205レジ内に未反映のデータが存在します時間を置いて再度実行して下さい
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M206
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M207
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M212
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M216
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M217
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M219
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M220
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M222
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M223
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M225
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M226
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M227
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M228
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M229
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M231
                Return Show(messageCode, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg0.M232
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M233
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M234
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M236
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M237
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M240
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M242
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M301郵便番号データが存在しませんでした
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M302圧縮ファイルの解凍に失敗しました
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M811バックアップファイルが選択されました
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M812ログファイルを確認して下さい
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M814_CSVは固定長限定_
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M815バージョンが異なっているか不正なデータが存在します
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg0.M816設定またはテキストを確認後再度実行して下さい
                Return Show(messageCode, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case Else
                Throw New ApplicationException("対応していないメッセージです")
        End Select
    End Function

    Public Shared Function Show(ByVal messageCode As MessageCode_Arg1, ByVal arg1 As String, ByVal caption As String) As DialogResult
        Select Case messageCode
            Case MessageCode_Arg1.M005印刷してもよろしいですか
                Return Show(messageCode, arg1, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M014が存在しません
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M015は必ず入力して下さい
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M016の入力範囲を確認して下さい
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M017を確認して下さい
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M018にマイナスが入力されました
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M019には数字を入力して下さい
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M020の桁数が大きすぎます
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M021の桁数が小さすぎます
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M022が登録されていません
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M023既に登録されています
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M024が実行されていません
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M025を実行して下さい
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M026が重複しています
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M027が設定されていません
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M029が異なります
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M030の期間中です
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M031の期間外です
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M036行までしか入力できません
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M037は既に完了しています
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M049入力可能期間以外の日付です
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M075入力禁止文字が含まれています
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M076入力禁止文字が含まれています半角スペースに変換してもよろしいですか
                Return Show(messageCode, arg1, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M111に作成されました
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M144抽出件数が設定件数をオーバーしました表示しますか
                Return Show(messageCode, arg1, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M169扱いの見積情報が選択されました参照はできますが訂正や削除は行えません訂正削除には承認の解除が必要となります
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M174回保存画面が表示されますが本当によろしいですか
                Return Show(messageCode, arg1, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg1.M175扱いの見積情報が選択されました指定する場合には承認の解除が必要になります
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M177扱いの見積情報が指定されました師弟する場合には見積承認にて承認済か受注済にする必要があります
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M208
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M209
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M210
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M213
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M214
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M218
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M221
                Return Show(messageCode, arg1, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg1.M224
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M230
                Return Show(messageCode, arg1, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2)
            Case MessageCode_Arg1.M235
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M238
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M239
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M241
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg1.M813は権限がないため起動できません
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case Else
                Throw New ApplicationException("対応していないメッセージです")
        End Select

    End Function

    Public Shared Function Show(ByVal messageCode As MessageCode_Arg1, ByVal arg1 As String, ByVal caption As String, ByVal icon As MessageBoxIcon) As DialogResult
        Select Case messageCode
            Case MessageCode_Arg1.M997フリーOKONLY
                Return Show(messageCode, arg1, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1, icon)
            Case MessageCode_Arg1.M998フリーYESNO_デフォルトはい
                Return Show(messageCode, arg1, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1, icon)
            Case MessageCode_Arg1.M999フリーYESNO_デフォルトいいえ
                Return Show(messageCode, arg1, caption, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2, icon)
            Case Else
                Throw New ApplicationException("対応していないメッセージです")
        End Select

    End Function

    Public Shared Function Show(ByVal messageCode As MessageCode_Arg2, ByVal arg1 As String, ByVal arg2 As String, ByVal caption As String) As DialogResult
        Select Case messageCode
            Case MessageCode_Arg2.M211
                Return Show(messageCode, arg1, arg2, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg2.M215
                Return Show(messageCode, arg1, arg2, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case MessageCode_Arg2.M1002検索結果の一部を表示しています
                Return Show(messageCode, arg1, arg2, caption, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
            Case Else
                Throw New ApplicationException("対応していないメッセージです")
        End Select
    End Function

    Protected Shared Function Show(ByVal messageCode As MessageCode_Arg0, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal defaultButton As MessageBoxDefaultButton, Optional ByRef arg1 As String = "") As DialogResult
        Dim s As String = nvcMessage(Utility.ZeroPadding(CType(messageCode, Integer).ToString, 3))
        Dim messageCodeStr As String = Split(s, ",")(1)
        messageCodeStr = String.Format(messageCodeStr, arg1)
        Dim messageStr As String = Split(s, ",")(0)

        messageCodeStr = fncChangeCode(messageCodeStr)

        Return ShowMessageBox(messageCodeStr, caption, buttons, messageStr, defaultButton)
    End Function

    Protected Shared Function Show(ByVal messageCode As MessageCode_Arg1, ByVal arg1 As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal defaultButton As MessageBoxDefaultButton, ByVal icon As MessageBoxIcon) As DialogResult
        Dim s As String = nvcMessage(Utility.ZeroPadding(CType(messageCode, Integer).ToString, 3))
        Dim messageCodeStr As String = Split(s, ",")(1)
        messageCodeStr = String.Format(messageCodeStr, arg1)

        messageCodeStr = fncChangeCode(messageCodeStr)

        Return System.Windows.Forms.MessageBox.Show(messageCodeStr, caption, buttons, icon, defaultButton)
    End Function

    Protected Shared Function Show(ByVal messageCode As MessageCode_Arg1, ByVal arg1 As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal defaultButton As MessageBoxDefaultButton) As DialogResult
        Dim s As String = nvcMessage(Utility.ZeroPadding(CType(messageCode, Integer).ToString, 3))
        Dim messageCodeStr As String = Split(s, ",")(1)
        messageCodeStr = String.Format(messageCodeStr, arg1)
        Dim messageStr As String = Split(s, ",")(0)

        messageCodeStr = fncChangeCode(messageCodeStr)

        Return ShowMessageBox(messageCodeStr, caption, buttons, messageStr, defaultButton)
    End Function

    Protected Shared Function Show(ByVal messageCode As MessageCode_Arg2, ByVal arg1 As String, ByVal arg2 As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal defaultButton As MessageBoxDefaultButton) As DialogResult
        Dim s As String = nvcMessage(Utility.ZeroPadding(CType(messageCode, Integer).ToString, 3))
        Dim messageCodeStr As String = Split(s, ",")(1)
        Dim messageStr As String = Split(s, ",")(0)
        messageCodeStr = String.Format(messageCodeStr, arg1, arg2)

        messageCodeStr = fncChangeCode(messageCodeStr)

        Return ShowMessageBox(messageCodeStr, caption, buttons, messageStr, defaultButton)
    End Function

    Private Shared Function fncChangeCode(ByVal strMessage As String) As String
        strMessage = strMessage.Replace("&#xD;&#xA;", "" & vbCrLf & "")
        Return strMessage
    End Function

    Public Shared Function GetIcon(ByVal messageCodeString As String) As MessageBoxIcon
        Dim iconStr As String = messageCodeString
        Dim icon As MessageBoxIcon
        icon = MessageBoxIcon.None
        Select Case iconStr
            Case "Q"
                icon = MessageBoxIcon.Question
            Case "E"
                icon = MessageBoxIcon.Exclamation
            Case "I"
                icon = MessageBoxIcon.Information
            Case "W"
                icon = MessageBoxIcon.Warning
            Case Else
                Throw New ApplicationException("不正なICONです")
        End Select
        Return icon
    End Function

    Private Shared Function ShowMessageBox(ByVal messageCodeString As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal messageStr As String, ByVal defaultButton As MessageBoxDefaultButton) As DialogResult
        Dim icon As MessageBoxIcon = GetIcon(messageStr)

        Return System.Windows.Forms.MessageBox.Show(messageCodeString, caption, buttons, icon, defaultButton)
    End Function

    Public Sub New()
        nvcMessage = New NameValueCollection()
    End Sub
    Public Sub New(ByVal s1 As String, ByVal s2 As String, ByVal s3 As String)
        nvcMessage.Add(s1, s2)
        nvcMessage.Add(s1, s3)
    End Sub

End Class
