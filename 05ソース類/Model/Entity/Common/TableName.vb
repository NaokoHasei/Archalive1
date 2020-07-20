''' <summary>
''' コンボボックス用
''' </summary>
''' <remarks></remarks>
Public Enum ComboBoxTableName
    M_BUKA
    M_KBN
    M_SIIRE
    M_TANTO
    M_TOKUI
    M_DAIKAMOKU
    M_CYUKAMOKU
    T_MITUMORIHED_MITUMORINO
    T_JYUTYUHED_JYUTYUNO
    T_HATYUHED_HATYUNO
    T_SEIKYUHED_SEIKYUNO
    M_KEN_SIKUTYOUSON
    M_KEN_TODOUFUKEN
    M_KEN_TYOUIKI
    S_SCB
End Enum
''' <summary>
''' 検索用
''' </summary>
''' <remarks></remarks>
Public Enum KensakuTableName
    M_KBN
    M_KEN_SIKUTYOUSON
    M_KEN_TODOUFUKEN
    M_KEN_TYOUIKI
    M_TOKUI
    M_USER
End Enum
''' <summary>
''' 個別選択用
''' </summary>
''' <remarks></remarks>
Public Enum KobetuTableName
    M_TOKUI
    M_SIIRE
    M_TANTO
    M_BUMON
    M_CHIKU
    M_NENDAI
    M_SYOHIN
    M_TENPO
End Enum
Public Enum InitializeKind
    初期化_過去データ取得
    初期化_完全初期化
End Enum
Public Enum FinalizeKind
    削除_過去データ登録
    選択区分更新
    削除_完全削除
End Enum