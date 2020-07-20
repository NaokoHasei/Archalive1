/* =================================================================== */
/* 仕入先マスタ (M_SIIRE)                                              */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE M_SIIRE (                                                 /* 仕入先マスタ */
    SIIRECODE           varchar(8)      NOT NULL,                       /* 仕入先コード         */
    SIIRENAME           varchar(40),                                    /* 仕入先名称           */
    RYAKUNAME           varchar(10),                                    /* 略称名               */
    MENUKEY             varchar(50),                                    /* メニューキー         */
    POSTNO              varchar(10),                                    /* 郵便番号             */
    ADDRESS             varchar(10),                                    /* 住所（県名）         */
    ADDRESS1            varchar(60),                                    /* 住所１（市区町村）   */
    ADDRESS2            varchar(60),                                    /* 住所２（方処）       */
    MAILADDRESS         varchar(100),                                   /* メールアドレス       */
    MAILACCOUNT         varchar(70),                                    /* メールアカウント     */
    MAILDOMAINNAME      varchar(30),                                    /* メールドメイン名     */
    MAILSENDFLG         int             NOT NULL  DEFAULT 0,            /* メール送信フラグ     */
    MAILADDRESS1        varchar(100),                                   /* メールアドレス1      */
    MAILACCOUNT1        varchar(70),                                    /* メールアカウント1    */
    MAILDOMAINNAME1     varchar(30),                                    /* メールドメイン名1    */
    MAILSENDFLG1        int             NOT NULL  DEFAULT 0,            /* メール送信フラグ1    */
    MAILDISPFLG         int             NOT NULL  DEFAULT 0,            /* メール金額表示区分   */
    MAILTANKADISPFLG    int             NOT NULL  DEFAULT 0,            /* メール単価表示区分   */
    MAILSENDOBJECTKBN   int             NOT NULL  DEFAULT 0,            /* メール送信対象区分   */
    PRICEPRIKBN         int             NOT NULL  DEFAULT 0,            /* 価格印字区分         */
    LABEL_NAME          varchar(24),                                    /* ラベル用自社名       */
    LABEL_TELNO         varchar(15),                                    /* ラベル用電話番号     */
    TELNO               varchar(15),                                    /* 電話番号             */
    FAXNO               varchar(15),                                    /* ＦＡＸ番号           */
    TELNO_K             varchar(15),                                    /* 携帯番号             */
    GINKOU              varchar(30),                                    /* 銀行名称             */
    BANKCODE            varchar(4),                                     /* 銀行コード           */
    BANKSUBCODE         varchar(4),                                     /* 支店コード           */
    BANKKOUZAKBN        decimal(1,0)    NOT NULL  DEFAULT 0,            /* 口座区分             */
    KOUZA               varchar(15),                                    /* 口座番号             */
    BANKMEIGI           varchar(60),                                    /* 名義漢字             */
    BANKMEIGIKANA       varchar(60),                                    /* 名義カナ             */
    LOCALCODE           varchar(4),                                     /* 地区コード           */
    TANKACODE           varchar(8),                                     /* 単価コード           */
    SIHARAICODE         varchar(8),                                     /* 支払先コード         */
    SOSINCODE           varchar(8),                                     /* 送信先コード         */
    TANTOCODE           varchar(4),                                     /* 担当者コード         */
    ITAKUCODE           varchar(5),                                     /* 委託コード           */
    SIMEBI1             decimal(2,0)    NOT NULL  DEFAULT 0,            /* 締日１               */
    SIMEBI2             decimal(2,0)    NOT NULL  DEFAULT 0,            /* 締日２               */
    SIMEBI3             decimal(2,0)    NOT NULL  DEFAULT 0,            /* 締日３               */
    SIHARAIKBN1         decimal(1,0)    NOT NULL  DEFAULT 0,            /* 支払区分１           */
    SIHARAIKBN2         decimal(1,0)    NOT NULL  DEFAULT 0,            /* 支払区分２           */
    SIHARAIKBN3         decimal(1,0)    NOT NULL  DEFAULT 0,            /* 支払区分３           */
    SIHARAIBI1          decimal(2,0)    NOT NULL  DEFAULT 0,            /* 支払日１             */
    SIHARAIBI2          decimal(2,0)    NOT NULL  DEFAULT 0,            /* 支払日２             */
    SIHARAIBI3          decimal(2,0)    NOT NULL  DEFAULT 0,            /* 支払日３             */
    SEISANTINAME        varchar(20),                                    /* 生産地名             */
    ZEIROUND            decimal(1,0)    NOT NULL  DEFAULT 0,            /* 税丸め区分           */
    SUROUND             decimal(1,0)    NOT NULL  DEFAULT 0,            /* 数量丸め区分         */
    KINROUND            decimal(1,0)    NOT NULL  DEFAULT 0,            /* 金額丸め区分         */
    SYOHIZEIKBN         decimal(1,0)    NOT NULL  DEFAULT 0,            /* 消費税区分           */
    ZANKANRIKBN         decimal(1,0)    NOT NULL  DEFAULT 0,            /* 残管理区分           */
    GENKAKAKIKAEKBN     decimal(1,0)    NOT NULL  DEFAULT 0,            /* 原価書換区分         */
    ZEIKBN              decimal(1,0)    NOT NULL  DEFAULT 0,            /* 税区分               */
    SOSINFLG            decimal(1,0)    NOT NULL  DEFAULT 0,            /* 送信フラグ           */
    TESURITU_1          decimal(5,2)    NOT NULL  DEFAULT 0,            /* 手数料率１           */
    TESURITU_2          decimal(5,2)    NOT NULL  DEFAULT 0,            /* 手数料率２           */
    YOSAN01             decimal(11,0)   NOT NULL  DEFAULT 0,            /* ０１月仕入予算       */
    YOSAN02             decimal(11,0)   NOT NULL  DEFAULT 0,            /* ０２月仕入予算       */
    YOSAN03             decimal(11,0)   NOT NULL  DEFAULT 0,            /* ０３月仕入予算       */
    YOSAN04             decimal(11,0)   NOT NULL  DEFAULT 0,            /* ０４月仕入予算       */
    YOSAN05             decimal(11,0)   NOT NULL  DEFAULT 0,            /* ０５月仕入予算       */
    YOSAN06             decimal(11,0)   NOT NULL  DEFAULT 0,            /* ０６月仕入予算       */
    YOSAN07             decimal(11,0)   NOT NULL  DEFAULT 0,            /* ０７月仕入予算       */
    YOSAN08             decimal(11,0)   NOT NULL  DEFAULT 0,            /* ０８月仕入予算       */
    YOSAN09             decimal(11,0)   NOT NULL  DEFAULT 0,            /* ０９月仕入予算       */
    YOSAN10             decimal(11,0)   NOT NULL  DEFAULT 0,            /* １０月仕入予算       */
    YOSAN11             decimal(11,0)   NOT NULL  DEFAULT 0,            /* １１月仕入予算       */
    YOSAN12             decimal(11,0)   NOT NULL  DEFAULT 0,            /* １２月仕入予算       */
    ENDSIIDATE          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最終仕入日付         */
    KEIYAKUDATE         datetime,                                       /* 契約日付             */
    KENSYU_DEKIDAKA     decimal(2,0)    NOT NULL  DEFAULT 0,            /* 検収出来高           */
    SIHARAI_GENKINRITU  decimal(3,0)    NOT NULL  DEFAULT 0,            /* 支払現金率           */
    SIHARAI_TEGATARITU  decimal(3,0)    NOT NULL  DEFAULT 0,            /* 支払手形率           */
    SITE                decimal(3,0)    NOT NULL  DEFAULT 0,            /* サイト               */
    DAIHYONAME          varchar(30),                                    /* 代表者名             */
    KEISYOUCODE         varchar(2),                                     /* 敬称コード           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日付             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日付             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE M_SIIRE ADD CONSTRAINT IDX_SIIRE_PK PRIMARY KEY
 (SIIRECODE)
GO


/* IDX_SIIRE_MENUKEY */
 CREATE INDEX IDX_SIIRE_MENUKEY ON
       M_SIIRE(MENUKEY,SIIRECODE)
GO


/* IDX_SIIRE_SEIKYUKEY */
 CREATE INDEX IDX_SIIRE_SEIKYUKEY ON
       M_SIIRE(SIHARAICODE,SIIRECODE)
GO


/* IDX_SIIRE_ITAKUKEY */
 CREATE INDEX IDX_SIIRE_ITAKUKEY ON
       M_SIIRE(ITAKUCODE)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_M_SIIRE ON M_SIIRE FOR UPDATE AS
 UPDATE M_SIIRE SET UDATE = GETDATE()
 FROM M_SIIRE, inserted
 WHERE M_SIIRE.SIIRECODE = inserted.SIIRECODE
GO

