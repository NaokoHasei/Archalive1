/* =================================================================== */
/* düæ}X^ (M_SIIRE)                                              */
/* =================================================================== */

/*-----------------------* e[uÌì¬ *----------------------------*/
 CREATE TABLE M_SIIRE (                                                 /* düæ}X^ */
    SIIRECODE           varchar(8)      NOT NULL,                       /* düæR[h         */
    SIIRENAME           varchar(40),                                    /* düæ¼Ì           */
    RYAKUNAME           varchar(10),                                    /* ªÌ¼               */
    MENUKEY             varchar(50),                                    /* j[L[         */
    POSTNO              varchar(10),                                    /* XÖÔ             */
    ADDRESS             varchar(10),                                    /* Zi§¼j         */
    ADDRESS1            varchar(60),                                    /* ZPisæ¬ºj   */
    ADDRESS2            varchar(60),                                    /* ZQiûj       */
    MAILADDRESS         varchar(100),                                   /* [AhX       */
    MAILACCOUNT         varchar(70),                                    /* [AJEg     */
    MAILDOMAINNAME      varchar(30),                                    /* [hC¼     */
    MAILSENDFLG         int             NOT NULL  DEFAULT 0,            /* [MtO     */
    MAILADDRESS1        varchar(100),                                   /* [AhX1      */
    MAILACCOUNT1        varchar(70),                                    /* [AJEg1    */
    MAILDOMAINNAME1     varchar(30),                                    /* [hC¼1    */
    MAILSENDFLG1        int             NOT NULL  DEFAULT 0,            /* [MtO1    */
    MAILDISPFLG         int             NOT NULL  DEFAULT 0,            /* [àz\¦æª   */
    MAILTANKADISPFLG    int             NOT NULL  DEFAULT 0,            /* [P¿\¦æª   */
    MAILSENDOBJECTKBN   int             NOT NULL  DEFAULT 0,            /* [MÎÛæª   */
    PRICEPRIKBN         int             NOT NULL  DEFAULT 0,            /* ¿ióæª         */
    LABEL_NAME          varchar(24),                                    /* xp©Ð¼       */
    LABEL_TELNO         varchar(15),                                    /* xpdbÔ     */
    TELNO               varchar(15),                                    /* dbÔ             */
    FAXNO               varchar(15),                                    /* e`wÔ           */
    TELNO_K             varchar(15),                                    /* gÑÔ             */
    GINKOU              varchar(30),                                    /* âs¼Ì             */
    BANKCODE            varchar(4),                                     /* âsR[h           */
    BANKSUBCODE         varchar(4),                                     /* xXR[h           */
    BANKKOUZAKBN        decimal(1,0)    NOT NULL  DEFAULT 0,            /* ûÀæª             */
    KOUZA               varchar(15),                                    /* ûÀÔ             */
    BANKMEIGI           varchar(60),                                    /* ¼`¿             */
    BANKMEIGIKANA       varchar(60),                                    /* ¼`Ji             */
    LOCALCODE           varchar(4),                                     /* næR[h           */
    TANKACODE           varchar(8),                                     /* P¿R[h           */
    SIHARAICODE         varchar(8),                                     /* x¥æR[h         */
    SOSINCODE           varchar(8),                                     /* MæR[h         */
    TANTOCODE           varchar(4),                                     /* SÒR[h         */
    ITAKUCODE           varchar(5),                                     /* ÏõR[h           */
    SIMEBI1             decimal(2,0)    NOT NULL  DEFAULT 0,            /* ÷úP               */
    SIMEBI2             decimal(2,0)    NOT NULL  DEFAULT 0,            /* ÷úQ               */
    SIMEBI3             decimal(2,0)    NOT NULL  DEFAULT 0,            /* ÷úR               */
    SIHARAIKBN1         decimal(1,0)    NOT NULL  DEFAULT 0,            /* x¥æªP           */
    SIHARAIKBN2         decimal(1,0)    NOT NULL  DEFAULT 0,            /* x¥æªQ           */
    SIHARAIKBN3         decimal(1,0)    NOT NULL  DEFAULT 0,            /* x¥æªR           */
    SIHARAIBI1          decimal(2,0)    NOT NULL  DEFAULT 0,            /* x¥úP             */
    SIHARAIBI2          decimal(2,0)    NOT NULL  DEFAULT 0,            /* x¥úQ             */
    SIHARAIBI3          decimal(2,0)    NOT NULL  DEFAULT 0,            /* x¥úR             */
    SEISANTINAME        varchar(20),                                    /* ¶Yn¼             */
    ZEIROUND            decimal(1,0)    NOT NULL  DEFAULT 0,            /* ÅÛßæª           */
    SUROUND             decimal(1,0)    NOT NULL  DEFAULT 0,            /* ÊÛßæª         */
    KINROUND            decimal(1,0)    NOT NULL  DEFAULT 0,            /* àzÛßæª         */
    SYOHIZEIKBN         decimal(1,0)    NOT NULL  DEFAULT 0,            /* ÁïÅæª           */
    ZANKANRIKBN         decimal(1,0)    NOT NULL  DEFAULT 0,            /* cÇæª           */
    GENKAKAKIKAEKBN     decimal(1,0)    NOT NULL  DEFAULT 0,            /* ´¿·æª         */
    ZEIKBN              decimal(1,0)    NOT NULL  DEFAULT 0,            /* Åæª               */
    SOSINFLG            decimal(1,0)    NOT NULL  DEFAULT 0,            /* MtO           */
    TESURITU_1          decimal(5,2)    NOT NULL  DEFAULT 0,            /* è¿¦P           */
    TESURITU_2          decimal(5,2)    NOT NULL  DEFAULT 0,            /* è¿¦Q           */
    YOSAN01             decimal(11,0)   NOT NULL  DEFAULT 0,            /* OPdü\Z       */
    YOSAN02             decimal(11,0)   NOT NULL  DEFAULT 0,            /* OQdü\Z       */
    YOSAN03             decimal(11,0)   NOT NULL  DEFAULT 0,            /* ORdü\Z       */
    YOSAN04             decimal(11,0)   NOT NULL  DEFAULT 0,            /* OSdü\Z       */
    YOSAN05             decimal(11,0)   NOT NULL  DEFAULT 0,            /* OTdü\Z       */
    YOSAN06             decimal(11,0)   NOT NULL  DEFAULT 0,            /* OUdü\Z       */
    YOSAN07             decimal(11,0)   NOT NULL  DEFAULT 0,            /* OVdü\Z       */
    YOSAN08             decimal(11,0)   NOT NULL  DEFAULT 0,            /* OWdü\Z       */
    YOSAN09             decimal(11,0)   NOT NULL  DEFAULT 0,            /* OXdü\Z       */
    YOSAN10             decimal(11,0)   NOT NULL  DEFAULT 0,            /* POdü\Z       */
    YOSAN11             decimal(11,0)   NOT NULL  DEFAULT 0,            /* PPdü\Z       */
    YOSAN12             decimal(11,0)   NOT NULL  DEFAULT 0,            /* PQdü\Z       */
    ENDSIIDATE          datetime        NOT NULL  DEFAULT GETDATE(),    /* ÅIdüút         */
    KEIYAKUDATE         datetime,                                       /* _ñút             */
    KENSYU_DEKIDAKA     decimal(2,0)    NOT NULL  DEFAULT 0,            /* ûo           */
    SIHARAI_GENKINRITU  decimal(3,0)    NOT NULL  DEFAULT 0,            /* x¥»à¦           */
    SIHARAI_TEGATARITU  decimal(3,0)    NOT NULL  DEFAULT 0,            /* x¥è`¦           */
    SITE                decimal(3,0)    NOT NULL  DEFAULT 0,            /* TCg               */
    DAIHYONAME          varchar(30),                                    /* ã\Ò¼             */
    KEISYOUCODE         varchar(2),                                     /* hÌR[h           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* ì¬út             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* XVút             */
 )
GO

/* PRIMARYKEYì¬ */
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

/* TRIGGERì¬ */
 CREATE TRIGGER TRI_U_M_SIIRE ON M_SIIRE FOR UPDATE AS
 UPDATE M_SIIRE SET UDATE = GETDATE()
 FROM M_SIIRE, inserted
 WHERE M_SIIRE.SIIRECODE = inserted.SIIRECODE
GO

