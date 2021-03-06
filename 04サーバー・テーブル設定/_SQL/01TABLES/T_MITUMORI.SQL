/* =================================================================== */
/* ©Οg (T_MITUMORI)                                             */
/* =================================================================== */

/*-----------------------* e[uΜμ¬ *----------------------------*/
 CREATE TABLE T_MITUMORI (                                              /* ©Οg */
    MITUMORINO          decimal(10,0)   NOT NULL  DEFAULT 0,            /* ©Οm             */
    MITUMORIEDABAN      decimal(2,0)    NOT NULL  DEFAULT 0,            /* ©Ο}Τ             */
    KAISOCODE           varchar(30)     NOT NULL,                       /* KwR[h           */
    DAIKAMOKUCODE       varchar(3),                                     /* εΘΪR[h         */
    CYUKAMOKUCODE       varchar(3),                                     /* ΘΪR[h         */
    SYOKAMOKUCODE       varchar(6),                                     /* ¬ΘΪR[h         */
    KAMOKU_HINMOKU      varchar(40),                                    /* ΘΪEiΪ           */
    HINSITU_KIKAKU_SIYO varchar(40),                                    /* iΏEKiEdl     */
    SIIRECODE           varchar(8),                                     /* dόζR[h         */
    TANI                varchar(10),                                    /* PΚ                 */
    SUU                 decimal(11,3)   NOT NULL  DEFAULT 0,            /* Κ                 */
    KAKERITU            decimal(8,3)    NOT NULL  DEFAULT 0,            /* |¦                 */
    GENTANKA            decimal(12,3)   NOT NULL  DEFAULT 0,            /* ΄PΏ               */
    MITUMORITANKA       decimal(12,3)   NOT NULL  DEFAULT 0,            /* ©ΟPΏ             */
    GENKAGAKU           decimal(12,0)   NOT NULL  DEFAULT 0,            /* ΄Ώΰz             */
    MITUMORIGAKU        decimal(12,0)   NOT NULL  DEFAULT 0,            /* ©Οΰz             */
    MITUMORIGAKU_NUKI   decimal(12,0)   NOT NULL  DEFAULT 0,            /* ©Οΰz_Ε²        */
    ARARIGAKU           decimal(12,0)   NOT NULL  DEFAULT 0,            /* eΰz             */
    IKATU_KAKERITU      decimal(8,3)    NOT NULL  DEFAULT 0,            /* κ|¦             */
    G_BIKO              varchar(40),                                    /* sυl               */
    KAKERITU_UPFLG      decimal(1,0)    NOT NULL  DEFAULT 0,            /* |¦XVtO       */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* ΕVeϊ       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* XVvOID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* [U[ID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* μ¬ϊ             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* XVϊ             */
 )
GO

/* PRIMARYKEYμ¬ */
 ALTER TABLE T_MITUMORI ADD CONSTRAINT IDX_MITUMORI_PK PRIMARY KEY
 (MITUMORINO,MITUMORIEDABAN,KAISOCODE)
GO

/* TRIGGERμ¬ */
 CREATE TRIGGER TRI_U_T_MITUMORI ON T_MITUMORI FOR UPDATE AS
 UPDATE T_MITUMORI SET UDATE = GETDATE()
 FROM T_MITUMORI, inserted
 WHERE T_MITUMORI.MITUMORINO = inserted.MITUMORINO
   AND T_MITUMORI.MITUMORIEDABAN = inserted.MITUMORIEDABAN
   AND T_MITUMORI.KAISOCODE = inserted.KAISOCODE
GO

