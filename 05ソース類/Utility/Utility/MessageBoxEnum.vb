﻿Public Enum MessageCode_Arg0
    M001登録してもよろしいですか = 1
    M002削除してもよろしいですか = 2
    M003取消してもよろしいですか = 3
    M004実行してもよろしいですか = 4
    M005印刷してもよろしいですか = 5
    M006未発行の伝票があります印字しますか = 6
    M007書き換えてもよろしいですか = 7
    M008画面の登録を行っていませんがよろしいですか = 8
    M009該当データがありません = 9
    M010基本設定マスタ情報が存在しません = 10
    M011該当する区分はありません = 11
    M012指定コードはマスタに登録されていません = 12
    M013メンテナンスで登録後実行して下さい = 13
    M028現在使用できません = 28
    M032訂正できません = 32
    M033削除対象データです = 33
    M034該当する伝票がありません = 34
    M035売上モニタで入力された伝票の為修正削除できません = 35
    M038各数値項目の入力値の桁数を確認して下さい = 38
    M039請求先しか指定できません = 39
    M040同一伝票が存在しますＳＣＢマスタの伝票Ｎｏを変更して下さい = 40
    M041該当日付の月次帳票は出力済みですがよろしいですか = 41
    M042前回の出力年月より離れていますがよろしいですか = 42
    M043該当メッセージなし = 43
    M044該当メッセージなし = 44
    M045該当メッセージなし = 45
    M046このコンピュータは端末マスタに未登録です = 46
    M047該当メッセージなし = 47
    M048日付の訂正はできません = 48
    M050日付が小さすぎます = 50
    M051日付が大きすぎます = 51
    M052この日付で処理できません = 52
    M053現在管理日付より２ヶ月以上先の日付が入力されました = 53
    M054集計処理済みの日付です集計取消後に入力を行って下さい = 54
    M055集計処理済みの日付ですよろしいですか = 55
    M056棚卸初期処理が実行されていません = 56
    M057棚卸対象ではありません = 57
    M058現在棚卸中です処理を実行すると現在の棚卸は中断されます = 58
    M059該当メッセージなし = 59
    M060予期せぬエラーが発生しました = 60
    M061指定されたデータは現在編集中です = 61
    M062しばらくしてから処理を行って下さい = 62
    M063システムが停止または起動途中です = 63
    M064本部システムに接続できません = 64
    M065システムの更新に失敗しました = 65
    M066他ユーザによりデータが変更されています = 66
    M067現在の更新は全て破棄されました = 67
    M068ＩＮＩが見つかりません = 68
    M069ＩＮＩのプリンタの設定が正しくありません = 69
    M070システム管理用コードの為使用できません = 70
    M071他の業務が実行中です終了後実行してください = 71
    M072本店一括請求の請求先です使用できません = 72
    M073返品伝票にプラス値が入力されていますよろしいですか = 73
    M074設定内容が矛盾しています = 74
    M077桁数の大きい数値が入力されましたよろしいですか = 77
    M0781000件以上の商品が選択されています = 78
    M081入荷済みの為削除できません = 81
    M082この発注は入荷が完了している為使用できません = 82
    M083ＢＨＴ情報が存在します使用しますか = 83
    M084訂正後の発注書を印刷しますか = 84
    M085入荷数以下の数量は設定できません = 85
    M086発注数以上の仕入が発生しています = 86
    M087発注停止商品です = 87
    M091当月実績が存在する為削除できません = 91
    M092在庫が存在します削除しますか = 92
    M093３回間違えたので強制終了します = 93
    M094パスワード変更はパスワードが入力されていることが前提です = 94
    M095パスワードの有効期限が過ぎていますパスワードを変更してください = 95
    M096入力されたユーザーコードは現在使用中です = 96
    M099正常終了しました = 99
    M100市区町村名が指定桁数を超えました住所欄下段に表示されている市区町村名をコピーして指定桁数に収まるよう入力して下さい = 100
    M102回線に接続できませんPCまたはサーバーに異常がないか確認してください再接続しますか = 102
    M103現在進行中の作業を破棄し終了してもよろしいですか = 103
    M104現在この端末にログインしているユーザーコードは削除できません = 104
    M105全削除してもよろしいですか = 105
    M106行削除してもよろしいですか = 106
    M107このコードは使用できません = 107
    M110再接続ができました再度処理を行ってください = 110
    M112既に入力されている商品と重複しています = 112
    M113重複データは反映されません = 113
    M114チェックデジットが違いますがよろしいですか = 114
    M115売価金額が入力されている商品が存在します0円に書き換えますか = 115
    M116集計対象内に仮伝が存在しますがよろしいですか = 116
    M117通常商品と委託商品を混在して入力はできません = 117
    M118仕入伝票が存在するため商品区分の変更はできません = 118
    M119委託商品コードが選択されています仕入先コードが一致していません = 119
    M120委託商品コードが選択されています商品区分を確認して下さい = 120
    M121仕入先コードに委託先が設定されています商品区分２_委託商品_ではありませんがよろしいですか = 121
    M131ＦＡＸの送信に失敗した仕入先があります = 131
    M132新ＪＡＮコードの取得に失敗しました_MAX連番を超えました_ = 132
    M133他端末にて同一委託者の商品コードが発番されている可能性があります再度印刷を行って下さい = 133
    M134他端末にて同一委託者のＪＡＮコードが発番されている可能性があります再度印刷を行って下さい = 134
    M135更新反映されていない取込データが存在しますこのまま終了しますか_データは残ります_ = 135
    M136仕入単価に掛率を反映して売単価を計算しますよろしいですか = 136
    M137ＣＳＶデータを取り込みますよろしいですか = 137
    M138エラーデータが存在するため実行できません = 138
    M139原価売価を再取得しますよろしいですか = 139
    M140この仕入先日付では発注できない商品です = 140
    M141この仕入先はＥＯＳ対象ではありません = 141
    M142正常データのみで実行しますよろしいですか_エラーデータは残ります_ = 142
    M143同一請求期間内に既に別の会社コードで伝票入力されています = 143
    M155承認してもよろしいですか = 155
    M156解除してもよろしいですか = 156
    M157該当見積の処理区分を変更してもよろしいですか = 157
    M158指定した見積情報をコピーしますか = 158
    M159コピーする場合は上書きにしますか_はい上書き_いいえ追加 = 159
    M160この階層を削除してもよろしいですか元には戻せません = 160
    M161この階層以降の階層も削除されますが本当に削除してもよろしいですか = 161
    M162引き続き印刷してもよろしいですか = 162
    M163入力された受注Ｎｏは顧客コードが異なります = 163
    M164複数の受注Noが選択されましたすべて同じ場所に出力しますか = 164
    M168見積ｼｽﾃﾑｴﾗｰ168分析表用のExcelﾃﾝﾌﾟﾚｰﾄが見つかりません = 168
    M169該当見積情報は既に承認されています参照はできますが訂正や削除は行なえません訂正削除には承認の解除が必要となります = 169
    M170該当見積情報はまだ承認されていません先に見積承認を行なってください = 170
    M171該当受注情報は既に発注が発生しております参照はできますが訂正や削除は行なえません = 171
    M172該当受注情報には発注先の業者が指定されていません先に発注業者を指定してください = 172
    M173未請求額0以下のデータが存在します = 173
    M176受注済の見積情報が指定されました指定する場合には受注入力での解除が必要となります = 176
    M178科目品目を変更しますか下位の階層との紐付けが外れる可能性がございます = 178
    M179行切取から行貼付を選択されましたこの場合下位の層は移動されませんがよろしいですか = 179
    M201電子ジャーナルのコピーに失敗しました = 201
    M202手作業にてコピー及び削除を行って下さい = 202
    M203電子ジャーナルTEMP情報の削除に失敗しました = 203
    M204手作業にて削除を行って下さい = 204
    M205レジ内に未反映のデータが存在します時間を置いて再度実行して下さい = 205
    M206 = 206
    M207 = 207
    M212 = 212
    M216 = 216
    M217 = 217
    M219 = 219
    M220 = 220
    M222 = 222
    M223 = 223
    M225 = 225
    M226 = 226
    M227 = 227
    M228 = 228
    M229 = 229
    M231 = 231
    M232 = 232
    M233 = 233
    M234 = 234
    M236 = 236
    M237 = 237
    M240 = 240
    M242 = 242
    M244 = 244
    M245 = 245
    M301郵便番号データが存在しませんでした = 301
    M302圧縮ファイルの解凍に失敗しました = 302
    M811バックアップファイルが選択されました = 811
    M812ログファイルを確認して下さい = 812
    M814_CSVは固定長限定_ = 814
    M815バージョンが異なっているか不正なデータが存在します = 815
    M816設定またはテキストを確認後再度実行して下さい = 816
End Enum
Public Enum MessageCode_Arg1
    M005印刷してもよろしいですか = 5
    M014が存在しません = 14
    M015は必ず入力して下さい = 15
    M016の入力範囲を確認して下さい = 16
    M017を確認して下さい = 17
    M018にマイナスが入力されました = 18
    M019には数字を入力して下さい = 19
    M020の桁数が大きすぎます = 20
    M021の桁数が小さすぎます = 21
    M022が登録されていません = 22
    M023既に登録されています = 23
    M024が実行されていません = 24
    M025を実行して下さい = 25
    M026が重複しています = 26
    M027が設定されていません = 27
    M029が異なります = 29
    M030の期間中です = 30
    M031の期間外です = 31
    M036行までしか入力できません = 36
    M037は既に完了しています = 37
    M049入力可能期間以外の日付です = 49
    M075入力禁止文字が含まれています = 75
    M076入力禁止文字が含まれています半角スペースに変換してもよろしいですか = 76
    M111に作成されました = 111
    M144抽出件数が設定件数をオーバーしました表示しますか = 144
    M169扱いの見積情報が選択されました参照はできますが訂正や削除は行えません訂正削除には承認の解除が必要となります = 169
    M174回保存画面が表示されますが本当によろしいですか = 174
    M175扱いの見積情報が選択されました指定する場合には承認の解除が必要になります = 175
    M177扱いの見積情報が指定されました師弟する場合には見積承認にて承認済か受注済にする必要があります = 177
    M208 = 208
    M209 = 209
    M210 = 210
    M213 = 213
    M214 = 214
    M218 = 218
    M221 = 221
    M224 = 224
    M230 = 230
    M235 = 235
    M238 = 238
    M239 = 239
    M241 = 241
    M243 = 243
    M813は権限がないため起動できません = 813
    M997フリーOKONLY = 997
    M998フリーYESNO_デフォルトはい = 998
    M999フリーYESNO_デフォルトいいえ = 999
End Enum
Public Enum MessageCode_Arg2
    M211 = 211
    M215 = 215
    M1002検索結果の一部を表示しています = 1002

End Enum
