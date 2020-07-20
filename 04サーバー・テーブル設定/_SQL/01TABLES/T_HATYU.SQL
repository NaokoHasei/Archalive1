/* =================================================================== */
/* 発注トラン (T_HATYU)                                                */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE T_HATYU (                                                 /* 発注トラン */
    HATYUNO                     decimal(10,0)   NOT NULL  DEFAULT 0,            /* 発注Ｎｏ             */
    HATYUEDABAN                 decimal(2,0)    NOT NULL  DEFAULT 0,            /* 発注枝番             */
    HATYUEDABAN2                decimal(2,0)    NOT NULL  DEFAULT 0,            /* 発注枝番２           */
    JYUTYUEDABAN                decimal(2,0)    NOT NULL  DEFAULT 0,            /* 受注枝番             */
    KAISOCODE                   varchar(30)     NOT NULL,                       /* 階層コード           */
    JYUTYUEDABAN_DAIKAMOKU      decimal(2,0)    NOT NULL  DEFAULT 0,            /* 受注枝番（大科目）   */
    KAISOCODE_DAIKAMOKU         varchar(30)     NOT NULL,                       /* 階層コード（大科目） */
    HATYUDATE                   datetime,                                       /* 発注日付             */
    JYUTYUNO                    decimal(10,0)   NOT NULL  DEFAULT 0,            /* 受注Ｎｏ             */
    DAIKAMOKUCODE               varchar(3),                                     /* 大科目コード         */
    CYUKAMOKUCODE               varchar(3),                                     /* 中科目コード         */
    SYOKAMOKUCODE               varchar(6),                                     /* 小科目コード         */
    KAMOKU_HINMOKU              varchar(40),                                    /* 科目・品目           */
    HINSITU_KIKAKU_SIYO         varchar(40),                                    /* 品質・規格・仕様     */
    TANI                        varchar(10),                                    /* 単位                 */
    SUU                         decimal(11,3)   NOT NULL  DEFAULT 0,            /* 数量                 */
    KAKERITU                    decimal(8,3)    NOT NULL  DEFAULT 0,            /* 掛率                 */
    GENTANKA                    decimal(12,3)   NOT NULL  DEFAULT 0,            /* 原単価               */
    GENKAGAKU                   decimal(12,0)   NOT NULL  DEFAULT 0,            /* 原価金額             */
    IKATU_KAKERITU              decimal(8,3)    NOT NULL  DEFAULT 0,            /* 一括掛率             */
    G_BIKO                      varchar(40),                                    /* 行備考               */
    UPDATEMENT                  datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID                  Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE              Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE                       datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日時             */
    UDATE                       datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日時             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE T_HATYU ADD CONSTRAINT IDX_HATYU_PK PRIMARY KEY
 (HATYUNO,HATYUEDABAN,HATYUEDABAN2,JYUTYUEDABAN,KAISOCODE)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_T_HATYU ON T_HATYU FOR UPDATE AS
 UPDATE T_HATYU SET UDATE = GETDATE()
 FROM T_HATYU, inserted
 WHERE T_HATYU.HATYUNO = inserted.HATYUNO
   AND T_HATYU.HATYUEDABAN = inserted.HATYUEDABAN
   AND T_HATYU.HATYUEDABAN2 = inserted.HATYUEDABAN2
   AND T_HATYU.JYUTYUEDABAN = inserted.JYUTYUEDABAN
   AND T_HATYU.KAISOCODE = inserted.KAISOCODE
GO

