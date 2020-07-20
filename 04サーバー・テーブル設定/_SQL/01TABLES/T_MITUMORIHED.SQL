/* =================================================================== */
/* 見積ヘッダトラン (T_MITUMORIHED)                                    */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE T_MITUMORIHED (                                           /* 見積ヘッダトラン */
    MITUMORINO                  decimal(10,0)   NOT NULL  DEFAULT 0,            /* 見積Ｎｏ             */
    MITUMORIEDABAN              decimal(2,0)    NOT NULL  DEFAULT 0,            /* 見積枝番             */
    MITUMORIDATE                datetime,                                       /* 見積日付             */
    TOKUICODE                   varchar(8),                                     /* 得意先コード         */
    TANTOCODE                   varchar(4),                                     /* 担当者コード         */
    KEISYOUCODE                 varchar(1),                                     /* 敬称コード           */
    KOUJINO                     varchar(20),                                    /* 工事番号             */
    KOUJINAME                   varchar(50),                                    /* 工事名称             */
    KOUJIBASYO                  varchar(50),                                    /* 工事場所             */
    NOUKI_START                 datetime,                                       /* 納期開始             */
    NOUKI_END                   datetime,                                       /* 納期終了             */
    YUKOKIGEN                   varchar(40),                                    /* 有効期限             */
    SIHARAIJYOKEN               varchar(40),                                    /* 支払条件             */
    OYA_MITUMORINO              decimal(10,0)   NOT NULL  DEFAULT 0,            /* 親見積Ｎｏ           */
    OYA_MITUMORIEDABAN          decimal(2,0)    NOT NULL  DEFAULT 0,            /* 親見積枝番           */
    SAI_MITUMORINO              decimal(10,0)   NOT NULL  DEFAULT 0,            /* 再見積Ｎｏ           */
    SAI_MITUMORIEDABAN          decimal(2,0)    NOT NULL  DEFAULT 0,            /* 再見積枝番           */
    SAN_MITUMORINO              decimal(10,0)   NOT NULL  DEFAULT 0,            /* 参照見積Ｎｏ         */
    SAN_MITUMORIEDABAN          decimal(2,0)    NOT NULL  DEFAULT 0,            /* 参照見積枝番         */
    GKGENKAGAKU                 decimal(12,0)   NOT NULL  DEFAULT 0,            /* 合計原価金額         */
    GKMITUMORIGAKU_NUKI         decimal(12,0)   NOT NULL  DEFAULT 0,            /* 合計見積金額_税抜    */
    GKTAX                       decimal(12,0)   NOT NULL  DEFAULT 0,            /* 合計消費税           */
    GKMITUMORIGAKU              decimal(12,0)   NOT NULL  DEFAULT 0,            /* 合計見積金額         */
    GKARARIGAKU                 decimal(12,0)   NOT NULL  DEFAULT 0,            /* 合計粗利金額         */
    D_BIKO                      varchar(200),                                   /* 伝票備考             */
    MITUMORI_JOUKEN             varchar(MAX),                                   /* 見積条件             */
    MITUMORI_JOUKEN_FILE_NAME   varchar(256),                                   /* 見積条件対象ファイル */
    KIGYOKBN                    decimal(2,0)    NOT NULL  DEFAULT 0,            /* 企業区分             */
    SYORIKBN                    decimal(2,0)    NOT NULL  DEFAULT 0,            /* 処理区分             */
    SYORISTDATE                 datetime,                                       /* 処理開始日付         */
    FIRST_JYUTYUNO              decimal(10,0)   NOT NULL  DEFAULT 0,            /* 初回受注Ｎｏ         */
    FIRST_JYUTYUDATE            datetime,                                       /* 初回受注日付         */
    SURYO_SYOSUIKAKETA          decimal(1,0)    NOT NULL  DEFAULT 0,            /* 数量小数点以下桁数   */
    UPDATEMENT                  datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID                  Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE              Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE                       datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日時             */
    UDATE                       datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日時             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE T_MITUMORIHED ADD CONSTRAINT IDX_MITUMORIHED_PK PRIMARY KEY
 (MITUMORINO,MITUMORIEDABAN)
GO


/* IDX_MITUMORIHED_TOKUIKEY */
 CREATE INDEX IDX_MITUMORIHED_TOKUIKEY ON
       T_MITUMORIHED(TOKUICODE,MITUMORINO,MITUMORIEDABAN)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_T_MITUMORIHED ON T_MITUMORIHED FOR UPDATE AS
 UPDATE T_MITUMORIHED SET UDATE = GETDATE()
 FROM T_MITUMORIHED, inserted
 WHERE T_MITUMORIHED.MITUMORINO = inserted.MITUMORINO
   AND T_MITUMORIHED.MITUMORIEDABAN = inserted.MITUMORIEDABAN
GO

