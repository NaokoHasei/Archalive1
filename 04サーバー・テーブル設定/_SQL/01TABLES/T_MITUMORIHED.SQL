/* =================================================================== */
/* ©Ïwb_g (T_MITUMORIHED)                                    */
/* =================================================================== */

/*-----------------------* e[uÌì¬ *----------------------------*/
 CREATE TABLE T_MITUMORIHED (                                           /* ©Ïwb_g */
    MITUMORINO                  decimal(10,0)   NOT NULL  DEFAULT 0,            /* ©Ïm             */
    MITUMORIEDABAN              decimal(2,0)    NOT NULL  DEFAULT 0,            /* ©Ï}Ô             */
    MITUMORIDATE                datetime,                                       /* ©Ïút             */
    TOKUICODE                   varchar(8),                                     /* ¾ÓæR[h         */
    TANTOCODE                   varchar(4),                                     /* SÒR[h         */
    KEISYOUCODE                 varchar(1),                                     /* hÌR[h           */
    KOUJINO                     varchar(20),                                    /* HÔ             */
    KOUJINAME                   varchar(50),                                    /* H¼Ì             */
    KOUJIBASYO                  varchar(50),                                    /* Hê             */
    NOUKI_START                 datetime,                                       /* [úJn             */
    NOUKI_END                   datetime,                                       /* [úI¹             */
    YUKOKIGEN                   varchar(40),                                    /* LøúÀ             */
    SIHARAIJYOKEN               varchar(40),                                    /* x¥ð             */
    OYA_MITUMORINO              decimal(10,0)   NOT NULL  DEFAULT 0,            /* e©Ïm           */
    OYA_MITUMORIEDABAN          decimal(2,0)    NOT NULL  DEFAULT 0,            /* e©Ï}Ô           */
    SAI_MITUMORINO              decimal(10,0)   NOT NULL  DEFAULT 0,            /* Ä©Ïm           */
    SAI_MITUMORIEDABAN          decimal(2,0)    NOT NULL  DEFAULT 0,            /* Ä©Ï}Ô           */
    SAN_MITUMORINO              decimal(10,0)   NOT NULL  DEFAULT 0,            /* QÆ©Ïm         */
    SAN_MITUMORIEDABAN          decimal(2,0)    NOT NULL  DEFAULT 0,            /* QÆ©Ï}Ô         */
    GKGENKAGAKU                 decimal(12,0)   NOT NULL  DEFAULT 0,            /* v´¿àz         */
    GKMITUMORIGAKU_NUKI         decimal(12,0)   NOT NULL  DEFAULT 0,            /* v©Ïàz_Å²    */
    GKTAX                       decimal(12,0)   NOT NULL  DEFAULT 0,            /* vÁïÅ           */
    GKMITUMORIGAKU              decimal(12,0)   NOT NULL  DEFAULT 0,            /* v©Ïàz         */
    GKARARIGAKU                 decimal(12,0)   NOT NULL  DEFAULT 0,            /* veàz         */
    D_BIKO                      varchar(200),                                   /* `[õl             */
    MITUMORI_JOUKEN             varchar(MAX),                                   /* ©Ïð             */
    MITUMORI_JOUKEN_FILE_NAME   varchar(256),                                   /* ©ÏðÎÛt@C */
    KIGYOKBN                    decimal(2,0)    NOT NULL  DEFAULT 0,            /* éÆæª             */
    SYORIKBN                    decimal(2,0)    NOT NULL  DEFAULT 0,            /* æª             */
    SYORISTDATE                 datetime,                                       /* Jnút         */
    FIRST_JYUTYUNO              decimal(10,0)   NOT NULL  DEFAULT 0,            /* ñóm         */
    FIRST_JYUTYUDATE            datetime,                                       /* ñóút         */
    SURYO_SYOSUIKAKETA          decimal(1,0)    NOT NULL  DEFAULT 0,            /* Ê¬_Èº   */
    UPDATEMENT                  datetime        NOT NULL  DEFAULT GETDATE(),    /* ÅVeú       */
    UPDATEPGID                  Varchar(20)     NOT NULL,                       /* XVvOID     */
    UPDATEUSERCODE              Varchar(15)     NOT NULL,                       /* [U[ID           */
    CDATE                       datetime        NOT NULL  DEFAULT GETDATE(),    /* ì¬ú             */
    UDATE                       datetime        NOT NULL  DEFAULT GETDATE()     /* XVú             */
 )
GO

/* PRIMARYKEYì¬ */
 ALTER TABLE T_MITUMORIHED ADD CONSTRAINT IDX_MITUMORIHED_PK PRIMARY KEY
 (MITUMORINO,MITUMORIEDABAN)
GO


/* IDX_MITUMORIHED_TOKUIKEY */
 CREATE INDEX IDX_MITUMORIHED_TOKUIKEY ON
       T_MITUMORIHED(TOKUICODE,MITUMORINO,MITUMORIEDABAN)
GO

/* TRIGGERì¬ */
 CREATE TRIGGER TRI_U_T_MITUMORIHED ON T_MITUMORIHED FOR UPDATE AS
 UPDATE T_MITUMORIHED SET UDATE = GETDATE()
 FROM T_MITUMORIHED, inserted
 WHERE T_MITUMORIHED.MITUMORINO = inserted.MITUMORINO
   AND T_MITUMORIHED.MITUMORIEDABAN = inserted.MITUMORIEDABAN
GO

