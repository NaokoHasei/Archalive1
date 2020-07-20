Imports C1.Win.C1TrueDBGrid
Imports System.ComponentModel
Imports Model

Public Class DropdownEx

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'カスタム描画コードをここに追加します。
    End Sub

    Public Sub SetWidth(ByVal tableName As ComboBoxTableName)

        '見出し文字数か内容文字数のどちらか大きいほう*6 + 6(微妙に足りないため調整)
        With Me
            Select Case tableName
                Case ComboBoxTableName.M_BUKA
                    .DisplayColumns(0).Width = 6 * 6 + 6    'コード桁数は４バイト。カラムヘッダーが６バイトの為６と設定
                    .DisplayColumns(1).Width = 30 * 6 + 6
                Case ComboBoxTableName.M_KBN
                    .DisplayColumns(0).Width = 6 * 6 + 6    'コード桁数は４バイト。カラムヘッダーが６バイトの為６と設定
                    .DisplayColumns(1).Width = 30 * 6 + 6
                Case ComboBoxTableName.M_TANTO
                    .DisplayColumns(0).Width = 6 * 6 + 6    'コード桁数は４バイト。カラムヘッダーが６バイトの為６と設定
                    .DisplayColumns(1).Width = 30 * 6 + 6
                Case ComboBoxTableName.M_TOKUI
                    .DisplayColumns(0).Width = 10 * 6 + 6    'コード桁数は４バイト。カラムヘッダーが６バイトの為６と設定
                    .DisplayColumns(1).Width = 48 * 6 + 6
                Case ComboBoxTableName.M_SIIRE
                    .DisplayColumns(0).Width = 10 * 6 + 6    'コード桁数は４バイト。カラムヘッダーが６バイトの為６と設定
                    .DisplayColumns(1).Width = 48 * 6 + 6
                Case ComboBoxTableName.T_MITUMORIHED_MITUMORINO
                    .DisplayColumns(0).Width = 15 * 6 + 6    'コード桁数は４バイト。カラムヘッダーが６バイトの為６と設定
                    .DisplayColumns(1).Width = 17 * 6 + 6
                    .DisplayColumns(2).Width = 28 * 6 + 6
                    .DisplayColumns(3).Width = 28 * 6 + 6
                    .DisplayColumns(4).Width = 19 * 6 + 6
                    .DisplayColumns(5).Width = 28 * 6 + 6
                Case ComboBoxTableName.T_JYUTYUHED_JYUTYUNO
                    .DisplayColumns(0).Width = 15 * 6 + 6    'コード桁数は４バイト。カラムヘッダーが６バイトの為６と設定
                    .DisplayColumns(1).Width = 17 * 6 + 6
                Case ComboBoxTableName.T_HATYUHED_HATYUNO
                    .DisplayColumns(0).Width = 18 * 6 + 6    'コード桁数は４バイト。カラムヘッダーが６バイトの為６と設定
                    .DisplayColumns(1).Width = 5 * 6 + 6
                    .DisplayColumns(2).Width = 40 * 6 + 6
                    .DisplayColumns(3).Width = 12 * 6 + 6
                    .DisplayColumns(4).Width = 15 * 6 + 6
                    .DisplayColumns(5).Width = 12 * 6 + 6
                Case ComboBoxTableName.T_SEIKYUHED_SEIKYUNO
                    .DisplayColumns(0).Width = 16 * 6 + 6    'コード桁数は４バイト。カラムヘッダーが６バイトの為６と設定
                    .DisplayColumns(1).Width = 12 * 6 + 6
                    .DisplayColumns(2).Width = 16 * 6 + 6    'コード桁数は４バイト。カラムヘッダーが６バイトの為６と設定
                    .DisplayColumns(3).Width = 12 * 6 + 6
                    .DisplayColumns(4).Width = 12 * 6 + 6
                    .DisplayColumns(5).Width = 12 * 6 + 6
                    .DisplayColumns(6).Width = 12 * 6 + 6
                Case ComboBoxTableName.M_DAIKAMOKU
                    .DisplayColumns(0).Width = 6 * 6 + 6    'コード桁数は３バイト。カラムヘッダーが６バイトの為６と設定
                    .DisplayColumns(1).Width = 30 * 6 + 6
                Case ComboBoxTableName.M_CYUKAMOKU
                    .DisplayColumns(0).Width = 6 * 6 + 6    'コード桁数は３バイト。カラムヘッダーが６バイトの為６と設定
                    .DisplayColumns(1).Width = 30 * 6 + 6
                Case ComboBoxTableName.M_DAIKAMOKU
                    .DisplayColumns(0).Width = 8 * 6 + 6
                Case ComboBoxTableName.M_CYUKAMOKU
                    .DisplayColumns(0).Width = 18 * 6 + 6
                Case ComboBoxTableName.S_SCB
                    .DisplayColumns(0).Width = 6 * 6 + 6    'コード桁数は４バイト。カラムヘッダーが６バイトの為６と設定
                    .DisplayColumns(1).Width = 30 * 6 + 6
                Case Else
                    Throw New ApplicationException("対応していないコンボボックス種別です。")
            End Select
            .DisplayColumns(0).ColumnDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.None

        End With
    End Sub

End Class
