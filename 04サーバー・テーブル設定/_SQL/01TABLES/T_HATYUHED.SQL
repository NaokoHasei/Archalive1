/* =================================================================== */
/* ­wb_g (T_HATYUHED)                                       */
/* =================================================================== */

/*-----------------------* e[uÌì¬ *----------------------------*/
 CREATE TABLE T_HATYUHED (                                              /* ­wb_g */
    HATYUNO             decimal(10,0)   NOT NULL  DEFAULT 0,            /* ­m             */
    HATYUEDABAN         decimal(2,0)    NOT NULL  DEFAULT 0,            /* ­}Ô             */
    HATYUEDABAN2        decimal(2,0)    NOT NULL  DEFAULT 0,            /* ­}ÔQ           */
    JYUTYUEDABAN        decimal(2,0)    NOT NULL  DEFAULT 0,            /* ó}Ô             */
    HATYUDATE           datetime,                                       /* ­út             */
    JYUTYUNO            decimal(10,0)   NOT NULL  DEFAULT 0,            /* óm             */
    SIIRECODE           varchar(8),                                     /* düæR[h         */
    TANTOCODE           varchar(4),                                     /* SÒR[h         */
    INP_TANTOCODE       varchar(4),                                     /* üÍSÒR[h     */
    KEISYOUCODE         varchar(2),                                     /* hÌR[h           */
    SIHARAI_COMMENT_01  varchar(30),                                    /* x¥ðRgOP */
    SIHARAI_COMMENT_02  varchar(30),                                    /* x¥ðRgOQ */
    SIHARAI_COMMENT_03  varchar(30),                                    /* x¥ðRgOR */
    SIHARAI_COMMENT_04  varchar(30),                                    /* x¥ðRgOS */
    SIHARAI_COMMENT_05  varchar(30),                                    /* x¥ðRgOT */
    SIHARAI_COMMENT_06  varchar(30),                                    /* x¥ðRgOU */
    AITE_MITUMORINO     varchar(15),                                    /* è©Ïm         */
    KEIYAKUNO           varchar(15),                                    /* _ñm             */
    NOUKI_START         datetime,                                       /* [úJn             */
    NOUKI_END           datetime,                                       /* [úI¹             */
    AITEDENPYONO        varchar(15),                                    /* è`[m         */
    GKGENKAGAKU_NUKI    decimal(12,0)   NOT NULL  DEFAULT 0,            /* v´¿àz_Å²    */
    GKTAX               decimal(12,0)   NOT NULL  DEFAULT 0,            /* vÁïÅ           */
    GKGENKAGAKU         decimal(12,0)   NOT NULL  DEFAULT 0,            /* v´¿àz         */
    D_BIKO              varchar(200),                                   /* `[õl             */
    SYORIKBN            decimal(2,0)    NOT NULL  DEFAULT 0,            /* æª             */
    SYORISTDATE         datetime,                                       /* Jnút         */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* ÅVeú       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* XVvOID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* [U[ID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* ì¬ú             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* XVú             */
 )
GO

/* PRIMARYKEYì¬ */
 ALTER TABLE T_HATYUHED ADD CONSTRAINT IDX_HATYUHED_PK PRIMARY KEY
 (HATYUNO,HATYUEDABAN,HATYUEDABAN2)
GO


/* IDX_HATYUHED_DENSEARCHKEY */
 CREATE INDEX IDX_HATYUHED_DENSEARCHKEY ON
       T_HATYUHED(SIIRECODE,HATYUDATE,HATYUNO)
GO

/* TRIGGERì¬ */
 CREATE TRIGGER TRI_U_T_HATYUHED ON T_HATYUHED FOR UPDATE AS
 UPDATE T_HATYUHED SET UDATE = GETDATE()
 FROM T_HATYUHED, inserted
 WHERE T_HATYUHED.HATYUNO = inserted.HATYUNO
   AND T_HATYUHED.HATYUEDABAN = inserted.HATYUEDABAN
   AND T_HATYUHED.HATYUEDABAN2 = inserted.HATYUEDABAN2
GO

