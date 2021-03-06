/* =================================================================== */
/* Ώg (T_SEIKYU)                                               */
/* =================================================================== */

/*-----------------------* e[uΜμ¬ *----------------------------*/
 CREATE TABLE T_SEIKYU (                                                /* Ώg */
    SEIKYUNO            decimal(10,0)   NOT NULL  DEFAULT 0,            /* Ώm             */
    SEIKYUEDABAN        decimal(2,0)    NOT NULL  DEFAULT 0,            /* Ώ}Τ             */
    GYONO               decimal(4,0)    NOT NULL  DEFAULT 0,            /* sm               */
    SEIKYUDATE          datetime,                                       /* Ώϊt             */
    JYUTYUNO            decimal(10,0)   NOT NULL  DEFAULT 0,            /* σm             */
    SEIKYUGAKU          decimal(12,0)   NOT NULL  DEFAULT 0,            /* Ώΰz             */
    DEKIDAKARITU        decimal(8,3)    NOT NULL  DEFAULT 0,            /* o¦             */
    G_BIKO              varchar(40),                                    /* sυl               */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* ΕVeϊ       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* XVvOID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* [U[ID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* μ¬ϊ             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* XVϊ             */
 )
GO

/* PRIMARYKEYμ¬ */
 ALTER TABLE T_SEIKYU ADD CONSTRAINT IDX_SEIKYU_PK PRIMARY KEY
 (SEIKYUNO,SEIKYUEDABAN,GYONO)
GO


/* IDX_SEIKYU_SUMI_SEARCHKEY */
 CREATE INDEX IDX_SEIKYU_SUMI_SEARCHKEY ON
       T_SEIKYU(SEIKYUNO,SEIKYUDATE)
GO

/* TRIGGERμ¬ */
 CREATE TRIGGER TRI_U_T_SEIKYU ON T_SEIKYU FOR UPDATE AS
 UPDATE T_SEIKYU SET UDATE = GETDATE()
 FROM T_SEIKYU, inserted
 WHERE T_SEIKYU.SEIKYUNO = inserted.SEIKYUNO
   AND T_SEIKYU.SEIKYUEDABAN = inserted.SEIKYUEDABAN
   AND T_SEIKYU.GYONO = inserted.GYONO
GO

