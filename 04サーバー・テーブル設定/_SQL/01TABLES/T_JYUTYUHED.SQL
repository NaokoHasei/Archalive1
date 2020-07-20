/* =================================================================== */
/* 受注ヘッダトラン (T_JYUTYUHED)                                      */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE T_JYUTYUHED (                                             /* 受注ヘッダトラン */
    JYUTYUNO            decimal(10,0)   NOT NULL  DEFAULT 0,            /* 受注Ｎｏ             */
    JYUTYUEDABAN        decimal(2,0)    NOT NULL  DEFAULT 0,            /* 受注枝番             */
    JYUTYUDATE          datetime,                                       /* 受注日付             */
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
    MITUMORINO          decimal(10,0)   NOT NULL  DEFAULT 0,            /* 見積Ｎｏ             */
    MITUMORIEDABAN      decimal(2,0)    NOT NULL  DEFAULT 0,            /* 見積枝番             */
    SAN_JYUTYUNO        decimal(10,0)   NOT NULL  DEFAULT 0,            /* 参照受注Ｎｏ         */
    SAN_MITUMORINO      decimal(10,0)   NOT NULL  DEFAULT 0,            /* 参照見積Ｎｏ         */
    SAN_MITUMORIEDABAN  decimal(2,0)    NOT NULL  DEFAULT 0,            /* 参照見積枝番         */
    JIKKOYOSAN          decimal(12,0)   NOT NULL  DEFAULT 0,            /* 実行予算             */
    GKGENKAGAKU         decimal(12,0)   NOT NULL  DEFAULT 0,            /* 合計原価金額         */
    GKJYUTYUGAKU_NUKI   decimal(12,0)   NOT NULL  DEFAULT 0,            /* 合計受注金額_税抜    */
    GKTAX               decimal(12,0)   NOT NULL  DEFAULT 0,            /* 合計消費税           */
    GKJYUTYUGAKU        decimal(12,0)   NOT NULL  DEFAULT 0,            /* 合計受注金額         */
    GKARARIGAKU         decimal(12,0)   NOT NULL  DEFAULT 0,            /* 合計粗利金額         */
    D_BIKO              varchar(200),                                   /* 伝票備考             */
    KIGYOKBN            decimal(2,0)    NOT NULL  DEFAULT 0,            /* 企業区分             */
    SYORIKBN            decimal(2,0)    NOT NULL  DEFAULT 0,            /* 処理区分             */
    SYORISTDATE         datetime,                                       /* 処理開始日付         */
    LAST_SEIKYUNO       decimal(10,0)   NOT NULL  DEFAULT 0,            /* 最終請求Ｎｏ         */
    LAST_SEIKYUDATE     datetime,                                       /* 最終請求日付         */
    LAST_HATYUNO        decimal(10,0)   NOT NULL  DEFAULT 0,            /* 最終発注Ｎｏ         */
    LAST_HATYUDATE      datetime,                                       /* 最終発注日付         */
    LAST_NYUKINNO       decimal(10,0)   NOT NULL  DEFAULT 0,            /* 最終入金Ｎｏ         */
    LAST_NYUKINDATE     datetime,                                       /* 最終入金日付         */
    LAST_SIHARAINO      decimal(10,0)   NOT NULL  DEFAULT 0,            /* 最終支払Ｎｏ         */
    LAST_SIHARAIDATE    datetime,                                       /* 最終支払日付         */
    STATUS_SEIKYU       decimal(1,0)    NOT NULL  DEFAULT 0,            /* 請求状況             */
    STATUS_HATYU        decimal(1,0)    NOT NULL  DEFAULT 0,            /* 発注状況             */
    STATUS_NYUKIN       decimal(1,0)    NOT NULL  DEFAULT 0,            /* 入金状況             */
    STATUS_SIHARAI      decimal(1,0)    NOT NULL  DEFAULT 0,            /* 支払状況             */
    SUMI_SEIKYUGAKU     decimal(12,0)   NOT NULL  DEFAULT 0,            /* 請求済金額           */
    SUMI_HATYUGAKU      decimal(12,0)   NOT NULL  DEFAULT 0,            /* 発注済金額           */
    SUMI_NYUKINGAKU     decimal(12,0)   NOT NULL  DEFAULT 0,            /* 入金済金額           */
    SUMI_SIHARAIGAKU    decimal(12,0)   NOT NULL  DEFAULT 0,            /* 支払済金額           */
    SURYO_SYOSUIKAKETA  decimal(1,0)    NOT NULL  DEFAULT 0,            /* 数量小数点以下桁数   */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日時             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日時             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE T_JYUTYUHED ADD CONSTRAINT IDX_JYUTYUHED_PK PRIMARY KEY
 (JYUTYUNO,JYUTYUEDABAN)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_T_JYUTYUHED ON T_JYUTYUHED FOR UPDATE AS
 UPDATE T_JYUTYUHED SET UDATE = GETDATE()
 FROM T_JYUTYUHED, inserted
 WHERE T_JYUTYUHED.JYUTYUNO = inserted.JYUTYUNO
   AND T_JYUTYUHED.JYUTYUEDABAN = inserted.JYUTYUEDABAN
GO

