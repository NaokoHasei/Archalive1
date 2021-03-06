/* =================================================================== */
/* ówb_g (T_JYUTYUHED)                                      */
/* =================================================================== */

/*-----------------------* e[uÌì¬ *----------------------------*/
 CREATE TABLE T_JYUTYUHED (                                             /* ówb_g */
    JYUTYUNO            decimal(10,0)   NOT NULL  DEFAULT 0,            /* óm             */
    JYUTYUEDABAN        decimal(2,0)    NOT NULL  DEFAULT 0,            /* ó}Ô             */
    JYUTYUDATE          datetime,                                       /* óút             */
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
    MITUMORINO          decimal(10,0)   NOT NULL  DEFAULT 0,            /* ©Ïm             */
    MITUMORIEDABAN      decimal(2,0)    NOT NULL  DEFAULT 0,            /* ©Ï}Ô             */
    SAN_JYUTYUNO        decimal(10,0)   NOT NULL  DEFAULT 0,            /* QÆóm         */
    SAN_MITUMORINO      decimal(10,0)   NOT NULL  DEFAULT 0,            /* QÆ©Ïm         */
    SAN_MITUMORIEDABAN  decimal(2,0)    NOT NULL  DEFAULT 0,            /* QÆ©Ï}Ô         */
    JIKKOYOSAN          decimal(12,0)   NOT NULL  DEFAULT 0,            /* Às\Z             */
    GKGENKAGAKU         decimal(12,0)   NOT NULL  DEFAULT 0,            /* v´¿àz         */
    GKJYUTYUGAKU_NUKI   decimal(12,0)   NOT NULL  DEFAULT 0,            /* vóàz_Å²    */
    GKTAX               decimal(12,0)   NOT NULL  DEFAULT 0,            /* vÁïÅ           */
    GKJYUTYUGAKU        decimal(12,0)   NOT NULL  DEFAULT 0,            /* vóàz         */
    GKARARIGAKU         decimal(12,0)   NOT NULL  DEFAULT 0,            /* veàz         */
    D_BIKO              varchar(200),                                   /* `[õl             */
    KIGYOKBN            decimal(2,0)    NOT NULL  DEFAULT 0,            /* éÆæª             */
    SYORIKBN            decimal(2,0)    NOT NULL  DEFAULT 0,            /* æª             */
    SYORISTDATE         datetime,                                       /* Jnút         */
    LAST_SEIKYUNO       decimal(10,0)   NOT NULL  DEFAULT 0,            /* ÅI¿m         */
    LAST_SEIKYUDATE     datetime,                                       /* ÅI¿út         */
    LAST_HATYUNO        decimal(10,0)   NOT NULL  DEFAULT 0,            /* ÅI­m         */
    LAST_HATYUDATE      datetime,                                       /* ÅI­út         */
    LAST_NYUKINNO       decimal(10,0)   NOT NULL  DEFAULT 0,            /* ÅIüàm         */
    LAST_NYUKINDATE     datetime,                                       /* ÅIüàút         */
    LAST_SIHARAINO      decimal(10,0)   NOT NULL  DEFAULT 0,            /* ÅIx¥m         */
    LAST_SIHARAIDATE    datetime,                                       /* ÅIx¥út         */
    STATUS_SEIKYU       decimal(1,0)    NOT NULL  DEFAULT 0,            /* ¿óµ             */
    STATUS_HATYU        decimal(1,0)    NOT NULL  DEFAULT 0,            /* ­óµ             */
    STATUS_NYUKIN       decimal(1,0)    NOT NULL  DEFAULT 0,            /* üàóµ             */
    STATUS_SIHARAI      decimal(1,0)    NOT NULL  DEFAULT 0,            /* x¥óµ             */
    SUMI_SEIKYUGAKU     decimal(12,0)   NOT NULL  DEFAULT 0,            /* ¿Ïàz           */
    SUMI_HATYUGAKU      decimal(12,0)   NOT NULL  DEFAULT 0,            /* ­Ïàz           */
    SUMI_NYUKINGAKU     decimal(12,0)   NOT NULL  DEFAULT 0,            /* üàÏàz           */
    SUMI_SIHARAIGAKU    decimal(12,0)   NOT NULL  DEFAULT 0,            /* x¥Ïàz           */
    SURYO_SYOSUIKAKETA  decimal(1,0)    NOT NULL  DEFAULT 0,            /* Ê¬_Èº   */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* ÅVeú       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* XVvOID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* [U[ID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* ì¬ú             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* XVú             */
 )
GO

/* PRIMARYKEYì¬ */
 ALTER TABLE T_JYUTYUHED ADD CONSTRAINT IDX_JYUTYUHED_PK PRIMARY KEY
 (JYUTYUNO,JYUTYUEDABAN)
GO

/* TRIGGERì¬ */
 CREATE TRIGGER TRI_U_T_JYUTYUHED ON T_JYUTYUHED FOR UPDATE AS
 UPDATE T_JYUTYUHED SET UDATE = GETDATE()
 FROM T_JYUTYUHED, inserted
 WHERE T_JYUTYUHED.JYUTYUNO = inserted.JYUTYUNO
   AND T_JYUTYUHED.JYUTYUEDABAN = inserted.JYUTYUEDABAN
GO

