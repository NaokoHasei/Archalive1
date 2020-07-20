/* =================================================================== */
/* 請求ヘッダトラン (T_SEIKYUHED)                                      */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE T_SEIKYUHED (                                             /* 請求ヘッダトラン */
    SEIKYUNO            decimal(10,0)   NOT NULL  DEFAULT 0,            /* 請求Ｎｏ             */
    SEIKYUEDABAN        decimal(2,0)    NOT NULL  DEFAULT 0,            /* 請求枝番             */
    JYUTYUEDABAN        decimal(2,0)    NOT NULL  DEFAULT 0,            /* 受注枝番             */
    SURYO_SYOSUIKAKETA  decimal(1,0)    NOT NULL  DEFAULT 0,            /* 数量小数点以下桁数   */
    SEIKYUDATE          datetime,                                       /* 請求日付             */
    SEIKYUMETHOD        decimal(1,0)    NOT NULL  DEFAULT 0,            /* 請求方法             */
    TOKUICODE           varchar(8),                                     /* 得意先コード         */
    TANTOCODE           varchar(4),                                     /* 担当者コード         */
    INP_TANTOCODE       varchar(4),                                     /* 入力担当者コード     */
    KEISYOUCODE         varchar(2),                                     /* 敬称コード           */
    KOUJINO             varchar(20),                                    /* 工事番号             */
    KOUJINAME           varchar(50),                                    /* 工事名称             */
    KOUJIBASYO          varchar(50),                                    /* 工事場所             */
    NOUKI_START         datetime,                                       /* 納期開始             */
    NOUKI_END           datetime,                                       /* 納期終了             */
    AITE_ORDERNO        varchar(20),                                    /* 相手注文Ｎｏ         */
    JYUTYUNO            decimal(10,0)   NOT NULL  DEFAULT 0,            /* 受注Ｎｏ             */
    SAN_JYUTYUNO        decimal(10,0)   NOT NULL  DEFAULT 0,            /* 参照受注Ｎｏ         */
    AITEDENPYONO        varchar(15),                                    /* 相手伝票Ｎｏ         */
    GKGENKAGAKU         decimal(12,0)   NOT NULL  DEFAULT 0,            /* 合計原価金額         */
    GKSEIKYUGAKU_NUKI   decimal(12,0)   NOT NULL  DEFAULT 0,            /* 合計請求金額_税抜    */
    GKTAX               decimal(12,0)   NOT NULL  DEFAULT 0,            /* 合計消費税           */
    GKSEIKYUGAKU        decimal(12,0)   NOT NULL  DEFAULT 0,            /* 合計請求金額         */
    GKARARIGAKU         decimal(12,0)   NOT NULL  DEFAULT 0,            /* 合計粗利金額         */
    KONJYURYOKINGAKU    decimal(12,0)   NOT NULL  DEFAULT 0,            /* 今回迄受領金額       */
    D_BIKO              varchar(200),                                   /* 伝票備考             */
    KIGYOKBN            decimal(2,0)    NOT NULL  DEFAULT 0,            /* 企業区分             */
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
 ALTER TABLE T_SEIKYUHED ADD CONSTRAINT IDX_SEIKYUHED_PK PRIMARY KEY
 (SEIKYUNO,SEIKYUEDABAN)
GO


/* IDX_SEIKYUHED_DENSEARCHKEY */
 CREATE INDEX IDX_SEIKYUHED_DENSEARCHKEY ON
       T_SEIKYUHED(TOKUICODE,SEIKYUDATE,SEIKYUNO)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_T_SEIKYUHED ON T_SEIKYUHED FOR UPDATE AS
 UPDATE T_SEIKYUHED SET UDATE = GETDATE()
 FROM T_SEIKYUHED, inserted
 WHERE T_SEIKYUHED.SEIKYUNO = inserted.SEIKYUNO
   AND T_SEIKYUHED.SEIKYUEDABAN = inserted.SEIKYUEDABAN
GO

