/* =================================================================== */
/* ¿wb_g (T_SEIKYUHED)                                      */
/* =================================================================== */

/*-----------------------* e[uÌì¬ *----------------------------*/
 CREATE TABLE T_SEIKYUHED (                                             /* ¿wb_g */
    SEIKYUNO            decimal(10,0)   NOT NULL  DEFAULT 0,            /* ¿m             */
    SEIKYUEDABAN        decimal(2,0)    NOT NULL  DEFAULT 0,            /* ¿}Ô             */
    JYUTYUEDABAN        decimal(2,0)    NOT NULL  DEFAULT 0,            /* ó}Ô             */
    SEIKYUDATE          datetime,                                       /* ¿út             */
    SEIKYUMETHOD        decimal(1,0)    NOT NULL  DEFAULT 0,            /* ¿û@             */
    TOKUICODE           varchar(8),                                     /* ¾ÓæR[h         */
    TANTOCODE           varchar(4),                                     /* SÒR[h         */
    INP_TANTOCODE       varchar(4),                                     /* üÍSÒR[h     */
    KEISYOUCODE         varchar(2),                                     /* hÌR[h           */
    KOUJINO             varchar(20),                                    /* HÔ             */
    KOUJINAME           varchar(50),                                    /* H¼Ì             */
    KOUJIBASYO          varchar(50),                                    /* Hê             */
    NOUKI_START         datetime,                                       /* [úJn             */
    NOUKI_END           datetime,                                       /* [úI¹             */
    AITE_ORDERNO        varchar(20),                                    /* è¶m         */
    JYUTYUNO            decimal(10,0)   NOT NULL  DEFAULT 0,            /* óm             */
    SAN_JYUTYUNO        decimal(10,0)   NOT NULL  DEFAULT 0,            /* QÆóm         */
    AITEDENPYONO        varchar(15),                                    /* è`[m         */
    GKGENKAGAKU         decimal(12,0)   NOT NULL  DEFAULT 0,            /* v´¿àz         */
    GKSEIKYUGAKU_NUKI   decimal(12,0)   NOT NULL  DEFAULT 0,            /* v¿àz_Å²    */
    GKTAX               decimal(12,0)   NOT NULL  DEFAULT 0,            /* vÁïÅ           */
    GKSEIKYUGAKU        decimal(12,0)   NOT NULL  DEFAULT 0,            /* v¿àz         */
    GKARARIGAKU         decimal(12,0)   NOT NULL  DEFAULT 0,            /* veàz         */
    KONJYURYOKINGAKU    decimal(12,0)   NOT NULL  DEFAULT 0,            /* ¡ñóÌàz       */
    KURIKOSIZAN         decimal(12,0)   NOT NULL  DEFAULT 0,            /* Jzc               */
    HORYUKIN            decimal(12,0)   NOT NULL  DEFAULT 0,            /* Û¯à               */
    KONHORYUKIN         decimal(12,0)   NOT NULL  DEFAULT 0,            /* ¡ñÛ¯à         */
    D_BIKO              varchar(200),                                   /* `[õl             */
    KIGYOKBN            decimal(2,0)    NOT NULL  DEFAULT 0,            /* éÆæª             */
    SYORIKBN            decimal(2,0)    NOT NULL  DEFAULT 0,            /* æª             */
    SYORISTDATE         datetime,                                       /* Jnút         */
    SURYO_SYOSUIKAKETA  decimal(1,0)    NOT NULL  DEFAULT 0,            /* Ê¬_Èº   */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* ÅVeú       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* XVvOID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* [U[ID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* ì¬ú             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* XVú             */
 )
GO

/* PRIMARYKEYì¬ */
 ALTER TABLE T_SEIKYUHED ADD CONSTRAINT IDX_SEIKYUHED_PK PRIMARY KEY
 (SEIKYUNO,SEIKYUEDABAN)
GO


/* IDX_SEIKYUHED_DENSEARCHKEY */
 CREATE INDEX IDX_SEIKYUHED_DENSEARCHKEY ON
       T_SEIKYUHED(TOKUICODE,SEIKYUDATE,SEIKYUNO)
GO

/* TRIGGERì¬ */
 CREATE TRIGGER TRI_U_T_SEIKYUHED ON T_SEIKYUHED FOR UPDATE AS
 UPDATE T_SEIKYUHED SET UDATE = GETDATE()
 FROM T_SEIKYUHED, inserted
 WHERE T_SEIKYUHED.SEIKYUNO = inserted.SEIKYUNO
   AND T_SEIKYUHED.SEIKYUEDABAN = inserted.SEIKYUEDABAN
GO

