/* =================================================================== */
/* 発注ヘッダトラン (T_HATYUHED)                                       */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE T_HATYUHED (                                              /* 発注ヘッダトラン */
    HATYUNO             decimal(10,0)   NOT NULL  DEFAULT 0,            /* 発注Ｎｏ             */
    HATYUEDABAN         decimal(2,0)    NOT NULL  DEFAULT 0,            /* 発注枝番             */
    HATYUEDABAN2        decimal(2,0)    NOT NULL  DEFAULT 0,            /* 発注枝番２           */
    JYUTYUEDABAN        decimal(2,0)    NOT NULL  DEFAULT 0,            /* 受注枝番             */
    HATYUDATE           datetime,                                       /* 発注日付             */
    JYUTYUNO            decimal(10,0)   NOT NULL  DEFAULT 0,            /* 受注Ｎｏ             */
    SIIRECODE           varchar(8),                                     /* 仕入先コード         */
    TANTOCODE           varchar(4),                                     /* 担当者コード         */
    INP_TANTOCODE       varchar(4),                                     /* 入力担当者コード     */
    KEISYOUCODE         varchar(2),                                     /* 敬称コード           */
    SIHARAI_COMMENT_01  varchar(30),                                    /* 支払条件コメント０１ */
    SIHARAI_COMMENT_02  varchar(30),                                    /* 支払条件コメント０２ */
    SIHARAI_COMMENT_03  varchar(30),                                    /* 支払条件コメント０３ */
    SIHARAI_COMMENT_04  varchar(30),                                    /* 支払条件コメント０４ */
    SIHARAI_COMMENT_05  varchar(30),                                    /* 支払条件コメント０５ */
    SIHARAI_COMMENT_06  varchar(30),                                    /* 支払条件コメント０６ */
    AITE_MITUMORINO     varchar(15),                                    /* 相手見積Ｎｏ         */
    KEIYAKUNO           varchar(15),                                    /* 契約Ｎｏ             */
    NOUKI_START         datetime,                                       /* 納期開始             */
    NOUKI_END           datetime,                                       /* 納期終了             */
    AITEDENPYONO        varchar(15),                                    /* 相手伝票Ｎｏ         */
    GKGENKAGAKU_NUKI    decimal(12,0)   NOT NULL  DEFAULT 0,            /* 合計原価金額_税抜    */
    GKTAX               decimal(12,0)   NOT NULL  DEFAULT 0,            /* 合計消費税           */
    GKGENKAGAKU         decimal(12,0)   NOT NULL  DEFAULT 0,            /* 合計原価金額         */
    D_BIKO              varchar(200),                                   /* 伝票備考             */
    SYORIKBN            decimal(2,0)    NOT NULL  DEFAULT 0,            /* 処理区分             */
    SYORISTDATE         datetime,                                       /* 処理開始日付         */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日時             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日時             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE T_HATYUHED ADD CONSTRAINT IDX_HATYUHED_PK PRIMARY KEY
 (HATYUNO,HATYUEDABAN,HATYUEDABAN2)
GO


/* IDX_HATYUHED_DENSEARCHKEY */
 CREATE INDEX IDX_HATYUHED_DENSEARCHKEY ON
       T_HATYUHED(SIIRECODE,HATYUDATE,HATYUNO)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_T_HATYUHED ON T_HATYUHED FOR UPDATE AS
 UPDATE T_HATYUHED SET UDATE = GETDATE()
 FROM T_HATYUHED, inserted
 WHERE T_HATYUHED.HATYUNO = inserted.HATYUNO
   AND T_HATYUHED.HATYUEDABAN = inserted.HATYUEDABAN
   AND T_HATYUHED.HATYUEDABAN2 = inserted.HATYUEDABAN2
GO

