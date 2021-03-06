/* =================================================================== */
/* ¾Óæ}X^ (M_TOKUI)                                              */
/* =================================================================== */

/*-----------------------* e[uÌì¬ *----------------------------*/
 CREATE TABLE M_TOKUI (                                                 /* ¾Óæ}X^ */
    TOKUICODE           varchar(16)     NOT NULL,                       /* ¾ÓæR[h         */
    TOKUINAME           varchar(40),                                    /* ¾Óæ¼             */
    RYAKUNAME           varchar(10),                                    /* ªÌ¼               */
    MENUKEY             varchar(50),                                    /* j[L[         */
    ADDRESS             varchar(10),                                    /* Zi§¼j         */
    ADDRESS1            varchar(60),                                    /* ZPisæ¬ºj   */
    ADDRESS2            varchar(60),                                    /* ZQiûj       */
    TELNO               varchar(15),                                    /* dbÔ             */
    FAXNO               varchar(15),                                    /* e`wÔ           */
    GINKOU              varchar(30),                                    /* âs¼Ì             */
    KOUZA               varchar(20),                                    /* ûÀÔ             */
    TANKACODE           varchar(16),                                    /* P¿R[h           */
    SEIKYUCODE          varchar(16),                                    /* ¿æR[h         */
    TANTOCODE           varchar(4),                                     /* SÒR[h         */
    SIMEBI1             decimal(2,0)    NOT NULL  DEFAULT 0,            /* ÷úP               */
    SIMEBI2             decimal(2,0)    NOT NULL  DEFAULT 0,            /* ÷úQ               */
    SIMEBI3             decimal(2,0)    NOT NULL  DEFAULT 0,            /* ÷úR               */
    NYUKINKBN1          decimal(1,0)    NOT NULL  DEFAULT 0,            /* üàæªP           */
    NYUKINKBN2          decimal(1,0)    NOT NULL  DEFAULT 0,            /* üàæªQ           */
    NYUKINKBN3          decimal(1,0)    NOT NULL  DEFAULT 0,            /* üàæªR           */
    SYUUKIN1            decimal(2,0)    NOT NULL  DEFAULT 0,            /* WàúP             */
    SYUUKIN2            decimal(2,0)    NOT NULL  DEFAULT 0,            /* WàúQ             */
    SYUUKIN3            decimal(2,0)    NOT NULL  DEFAULT 0,            /* WàúR             */
    ZEIROUND            decimal(1,0)    NOT NULL  DEFAULT 0,            /* ÅÛßæª           */
    SUROUND             decimal(1,0)    NOT NULL  DEFAULT 0,            /* ÊÛßæª         */
    KINROUND            decimal(1,0)    NOT NULL  DEFAULT 0,            /* àzÛßæª         */
    SYOHIZEIKBN         decimal(1,0)    NOT NULL  DEFAULT 0,            /* ÁïÅæª           */
    ZANKANRIKBN         decimal(1,0)    NOT NULL  DEFAULT 0,            /* cÇæª           */
    TANKAKAKIKAEKBN     decimal(1,0)    NOT NULL  DEFAULT 0,            /* P¿·æª         */
    ZEIKBN              decimal(1,0)    NOT NULL  DEFAULT 0,            /* Åæª               */
    DENPYOSYUKBN        decimal(1,0)    NOT NULL  DEFAULT 0,            /* `[íæª           */
    SEIKYUKBN           decimal(1,0)    NOT NULL  DEFAULT 0,            /* ¿æª           */
    YOSAN01             decimal(11,0)   NOT NULL  DEFAULT 0,            /* OPã\Z       */
    YOSAN02             decimal(11,0)   NOT NULL  DEFAULT 0,            /* OQã\Z       */
    YOSAN03             decimal(11,0)   NOT NULL  DEFAULT 0,            /* ORã\Z       */
    YOSAN04             decimal(11,0)   NOT NULL  DEFAULT 0,            /* OSã\Z       */
    YOSAN05             decimal(11,0)   NOT NULL  DEFAULT 0,            /* OTã\Z       */
    YOSAN06             decimal(11,0)   NOT NULL  DEFAULT 0,            /* OUã\Z       */
    YOSAN07             decimal(11,0)   NOT NULL  DEFAULT 0,            /* OVã\Z       */
    YOSAN08             decimal(11,0)   NOT NULL  DEFAULT 0,            /* OWã\Z       */
    YOSAN09             decimal(11,0)   NOT NULL  DEFAULT 0,            /* OXã\Z       */
    YOSAN10             decimal(11,0)   NOT NULL  DEFAULT 0,            /* POã\Z       */
    YOSAN11             decimal(11,0)   NOT NULL  DEFAULT 0,            /* PPã\Z       */
    YOSAN12             decimal(11,0)   NOT NULL  DEFAULT 0,            /* PQã\Z       */
    ENDURIDATE          datetime        NOT NULL  DEFAULT GETDATE(),    /* ÅIãút         */
    POSTNO              varchar(10),                                    /* XÖÔ             */
    ZANINJIKBN          decimal(1,0)    NOT NULL  DEFAULT 0,            /* cóæª         */
    AITE_BUSYONAME      varchar(30),                                    /* è¼           */
    AITE_TANTONAME      varchar(30),                                    /* èSÒ¼         */
    SIHARAIBI           decimal(2,0)    NOT NULL  DEFAULT 0,            /* x¥ú               */
    SIHARAI_GENKINRITU  decimal(3,0)    NOT NULL  DEFAULT 0,            /* x¥»à¦           */
    SIHARAI_TEGATARITU  decimal(3,0)    NOT NULL  DEFAULT 0,            /* x¥è`¦           */
    SITE                decimal(3,0)    NOT NULL  DEFAULT 0,            /* TCg               */
    KEISYOUCODE         varchar(1),                                     /* hÌR[h           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* ì¬út             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* XVút             */
 )
GO

/* PRIMARYKEYì¬ */
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

/* TRIGGERì¬ */
 CREATE TRIGGER TRI_U_M_TOKUI ON M_TOKUI FOR UPDATE AS
 UPDATE M_TOKUI SET UDATE = GETDATE()
 FROM M_TOKUI, inserted
 WHERE M_TOKUI.TOKUICODE = inserted.TOKUICODE
GO

