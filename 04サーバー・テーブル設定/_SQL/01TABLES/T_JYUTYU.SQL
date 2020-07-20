/* =================================================================== */
/* 受注トラン (T_JYUTYU)                                               */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE T_JYUTYU (                                                /* 受注トラン */
    JYUTYUNO            decimal(10,0)   NOT NULL  DEFAULT 0,            /* 受注Ｎｏ             */
    JYUTYUEDABAN        decimal(2,0)    NOT NULL  DEFAULT 0,            /* 受注枝番             */
    KAISOCODE           varchar(30)     NOT NULL,                       /* 階層コード           */
    KAISOCODE_ZENKAI    varchar(30)     NOT NULL,                       /* 階層コード（前回）   */
    DELETE_FLG          decimal(1,0)    NOT NULL  DEFAULT 0,            /* 削除フラグ           */
    DAIKAMOKUCODE       varchar(3),                                     /* 大科目コード         */
    CYUKAMOKUCODE       varchar(3),                                     /* 中科目コード         */
    SYOKAMOKUCODE       varchar(6),                                     /* 小科目コード         */
    KAMOKU_HINMOKU      varchar(40),                                    /* 科目・品目           */
    HINSITU_KIKAKU_SIYO varchar(40),                                    /* 品質・規格・仕様     */
    SIIRECODE           varchar(8),                                     /* 仕入先コード         */
    TANI                varchar(10),                                    /* 単位                 */
    SUU                 decimal(11,3)   NOT NULL  DEFAULT 0,            /* 数量                 */
    KAKERITU            decimal(8,3)    NOT NULL  DEFAULT 0,            /* 掛率                 */
    GENTANKA            decimal(12,3)   NOT NULL  DEFAULT 0,            /* 原単価               */
    JYUTYUTANKA         decimal(12,3)   NOT NULL  DEFAULT 0,            /* 受注単価             */
    GENKAGAKU           decimal(12,0)   NOT NULL  DEFAULT 0,            /* 原価金額             */
    JYUTYUGAKU          decimal(12,0)   NOT NULL  DEFAULT 0,            /* 受注金額             */
    JYUTYUGAKU_NUKI     decimal(12,0)   NOT NULL  DEFAULT 0,            /* 受注金額_税抜        */
    ARARIGAKU           decimal(12,0)   NOT NULL  DEFAULT 0,            /* 粗利金額             */
    IKATU_KAKERITU      decimal(8,3)    NOT NULL  DEFAULT 0,            /* 一括掛率             */
    G_BIKO              varchar(40),                                    /* 行備考               */
    KAKERITU_UPFLG      decimal(1,0)    NOT NULL  DEFAULT 0,            /* 掛率更新フラグ       */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日時             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日時             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE T_JYUTYU ADD CONSTRAINT IDX_JYUTYU_PK PRIMARY KEY
 (JYUTYUNO,JYUTYUEDABAN,KAISOCODE)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_T_JYUTYU ON T_JYUTYU FOR UPDATE AS
 UPDATE T_JYUTYU SET UDATE = GETDATE()
 FROM T_JYUTYU, inserted
 WHERE T_JYUTYU.JYUTYUNO = inserted.JYUTYUNO
   AND T_JYUTYU.JYUTYUEDABAN = inserted.JYUTYUEDABAN
   AND T_JYUTYU.KAISOCODE = inserted.KAISOCODE
GO

