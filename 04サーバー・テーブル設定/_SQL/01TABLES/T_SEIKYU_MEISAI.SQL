/* =================================================================== */
/* 請求明細トラン (T_SEIKYU_MEISAI)                                    */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE T_SEIKYU_MEISAI (                                         /* 請求明細トラン */
    SEIKYUNO                    decimal(10,0)   NOT NULL  DEFAULT 0,            /* 請求Ｎｏ             */
    SEIKYUEDABAN                decimal(2,0)    NOT NULL  DEFAULT 0,            /* 請求枝番             */
    JYUTYUEDABAN                decimal(2,0)    NOT NULL  DEFAULT 0,            /* 受注枝番             */
    KAISOCODE                   varchar(30)     NOT NULL,                       /* 階層コード           */
    DELETE_FLG                  decimal(1,0)    NOT NULL  DEFAULT 0,            /* 削除フラグ           */
    KAISOCODE_ZENKAI            varchar(30)     NOT NULL,                       /* 階層コード（前回）   */
    JYUTYUEDABAN_DAIKAMOKU      decimal(10,0)   NOT NULL  DEFAULT 0,            /* 受注枝番（大科目）   */
    KAISOCODE_DAIKAMOKU         varchar(30)     NOT NULL,                       /* 階層コード（大科目） */
    KAMOKU_HINMOKU_DAIKAMOKU    varchar(40),                                    /* 科目・品目（大科目） */
    KAMOKU_HINMOKU              varchar(40),                                    /* 科目・品目           */
    HINSITU_KIKAKU_SIYO         varchar(40),                                    /* 品質・規格・仕様     */
    TANI                        varchar(10),                                    /* 単位                 */
    JYUTYUSUU                   decimal(11,3)   NOT NULL  DEFAULT 0,            /* 受注数量             */
    JYUTYUTANKA                 decimal(12,3)   NOT NULL  DEFAULT 0,            /* 受注単価             */
    JYUTYUGAKU                  decimal(12,0)   NOT NULL  DEFAULT 0,            /* 受注金額             */
    JYUTYUSUU_HENKO             decimal(11,3)   NOT NULL  DEFAULT 0,            /* 受注数量_変更        */
    JYUTYUGAKU_HENKO            decimal(12,0)   NOT NULL  DEFAULT 0,            /* 受注金額_変更        */
    SEIKYUSUU_ZENKAI            decimal(11,3)   NOT NULL  DEFAULT 0,            /* 請求数量_前回        */
    SEIKYUGAKU_ZENKAI           decimal(12,0)   NOT NULL  DEFAULT 0,            /* 請求金額_前回        */
    SEIKYUSUU_KONKAI            decimal(11,3)   NOT NULL  DEFAULT 0,            /* 請求数量_今回        */
    SEIKYUGAKU_KONKAI           decimal(12,0)   NOT NULL  DEFAULT 0,            /* 請求金額_今回        */
    SEIKYUSUU_RUIKEI            decimal(11,3)   NOT NULL  DEFAULT 0,            /* 請求数量_累計        */
    SEIKYUGAKU_RUIKEI           decimal(12,0)   NOT NULL  DEFAULT 0,            /* 請求金額_累計        */
    UPDATEMENT                  datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID                  Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE              Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE                       datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日時             */
    UDATE                       datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日時             */
 )
GO


/* IDX_SEIKYU_MEISAI */
 CREATE UNIQUE INDEX IDX_SEIKYU_MEISAI ON
       T_SEIKYU_MEISAI(SEIKYUNO,SEIKYUEDABAN,JYUTYUEDABAN,KAISOCODE,DELETE_FLG)
GO

