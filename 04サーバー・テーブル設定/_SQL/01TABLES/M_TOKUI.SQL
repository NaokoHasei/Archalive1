/* =================================================================== */
/* 得意先マスタ (M_TOKUI)                                              */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE M_TOKUI (                                                 /* 得意先マスタ */
    TOKUICODE           varchar(16)     NOT NULL,                       /* 得意先コード         */
    TOKUINAME           varchar(40),                                    /* 得意先名             */
    RYAKUNAME           varchar(10),                                    /* 略称名               */
    MENUKEY             varchar(50),                                    /* メニューキー         */
    ADDRESS             varchar(10),                                    /* 住所（県名）         */
    ADDRESS1            varchar(60),                                    /* 住所１（市区町村）   */
    ADDRESS2            varchar(60),                                    /* 住所２（方処）       */
    TELNO               varchar(15),                                    /* 電話番号             */
    FAXNO               varchar(15),                                    /* ＦＡＸ番号           */
    GINKOU              varchar(30),                                    /* 銀行名称             */
    KOUZA               varchar(20),                                    /* 口座番号             */
    TANKACODE           varchar(16),                                    /* 単価コード           */
    SEIKYUCODE          varchar(16),                                    /* 請求先コード         */
    TANTOCODE           varchar(4),                                     /* 担当者コード         */
    SIMEBI1             decimal(2,0)    NOT NULL  DEFAULT 0,            /* 締日１               */
    SIMEBI2             decimal(2,0)    NOT NULL  DEFAULT 0,            /* 締日２               */
    SIMEBI3             decimal(2,0)    NOT NULL  DEFAULT 0,            /* 締日３               */
    NYUKINKBN1          decimal(1,0)    NOT NULL  DEFAULT 0,            /* 入金区分１           */
    NYUKINKBN2          decimal(1,0)    NOT NULL  DEFAULT 0,            /* 入金区分２           */
    NYUKINKBN3          decimal(1,0)    NOT NULL  DEFAULT 0,            /* 入金区分３           */
    SYUUKIN1            decimal(2,0)    NOT NULL  DEFAULT 0,            /* 集金日１             */
    SYUUKIN2            decimal(2,0)    NOT NULL  DEFAULT 0,            /* 集金日２             */
    SYUUKIN3            decimal(2,0)    NOT NULL  DEFAULT 0,            /* 集金日３             */
    ZEIROUND            decimal(1,0)    NOT NULL  DEFAULT 0,            /* 税丸め区分           */
    SUROUND             decimal(1,0)    NOT NULL  DEFAULT 0,            /* 数量丸め区分         */
    KINROUND            decimal(1,0)    NOT NULL  DEFAULT 0,            /* 金額丸め区分         */
    SYOHIZEIKBN         decimal(1,0)    NOT NULL  DEFAULT 0,            /* 消費税区分           */
    ZANKANRIKBN         decimal(1,0)    NOT NULL  DEFAULT 0,            /* 残管理区分           */
    TANKAKAKIKAEKBN     decimal(1,0)    NOT NULL  DEFAULT 0,            /* 単価書換区分         */
    ZEIKBN              decimal(1,0)    NOT NULL  DEFAULT 0,            /* 税区分               */
    DENPYOSYUKBN        decimal(1,0)    NOT NULL  DEFAULT 0,            /* 伝票種区分           */
    SEIKYUKBN           decimal(1,0)    NOT NULL  DEFAULT 0,            /* 請求書区分           */
    YOSAN01             decimal(11,0)   NOT NULL  DEFAULT 0,            /* ０１月売上予算       */
    YOSAN02             decimal(11,0)   NOT NULL  DEFAULT 0,            /* ０２月売上予算       */
    YOSAN03             decimal(11,0)   NOT NULL  DEFAULT 0,            /* ０３月売上予算       */
    YOSAN04             decimal(11,0)   NOT NULL  DEFAULT 0,            /* ０４月売上予算       */
    YOSAN05             decimal(11,0)   NOT NULL  DEFAULT 0,            /* ０５月売上予算       */
    YOSAN06             decimal(11,0)   NOT NULL  DEFAULT 0,            /* ０６月売上予算       */
    YOSAN07             decimal(11,0)   NOT NULL  DEFAULT 0,            /* ０７月売上予算       */
    YOSAN08             decimal(11,0)   NOT NULL  DEFAULT 0,            /* ０８月売上予算       */
    YOSAN09             decimal(11,0)   NOT NULL  DEFAULT 0,            /* ０９月売上予算       */
    YOSAN10             decimal(11,0)   NOT NULL  DEFAULT 0,            /* １０月売上予算       */
    YOSAN11             decimal(11,0)   NOT NULL  DEFAULT 0,            /* １１月売上予算       */
    YOSAN12             decimal(11,0)   NOT NULL  DEFAULT 0,            /* １２月売上予算       */
    ENDURIDATE          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最終売上日付         */
    POSTNO              varchar(10),                                    /* 郵便番号             */
    ZANINJIKBN          decimal(1,0)    NOT NULL  DEFAULT 0,            /* 残高印字区分         */
    AITE_BUSYONAME      varchar(30),                                    /* 相手部署名           */
    AITE_TANTONAME      varchar(30),                                    /* 相手担当者名         */
    SIHARAIBI           decimal(2,0)    NOT NULL  DEFAULT 0,            /* 支払日               */
    SIHARAI_GENKINRITU  decimal(3,0)    NOT NULL  DEFAULT 0,            /* 支払現金率           */
    SIHARAI_TEGATARITU  decimal(3,0)    NOT NULL  DEFAULT 0,            /* 支払手形率           */
    SITE                decimal(3,0)    NOT NULL  DEFAULT 0,            /* サイト               */
    KEISYOUCODE         varchar(1),                                     /* 敬称コード           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日付             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日付             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE M_TOKUI ADD CONSTRAINT IDX_TOKUI_PK PRIMARY KEY
 (TOKUICODE)
GO


/* IDX_TOKUI_MENUKEY */
 CREATE INDEX IDX_TOKUI_MENUKEY ON
       M_TOKUI(MENUKEY,TOKUICODE)
GO


/* IDX_TOKUI_SEIKYUKEY */
 CREATE INDEX IDX_TOKUI_SEIKYUKEY ON
       M_TOKUI(SEIKYUCODE,TOKUICODE)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_M_TOKUI ON M_TOKUI FOR UPDATE AS
 UPDATE M_TOKUI SET UDATE = GETDATE()
 FROM M_TOKUI, inserted
 WHERE M_TOKUI.TOKUICODE = inserted.TOKUICODE
GO

