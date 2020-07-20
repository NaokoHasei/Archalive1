/* =================================================================== */
/* 請求トラン (T_SEIKYU)                                               */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE T_SEIKYU (                                                /* 請求トラン */
    SEIKYUNO            decimal(10,0)   NOT NULL  DEFAULT 0,            /* 請求Ｎｏ             */
    SEIKYUEDABAN        decimal(2,0)    NOT NULL  DEFAULT 0,            /* 請求枝番             */
    GYONO               decimal(4,0)    NOT NULL  DEFAULT 0,            /* 行Ｎｏ               */
    SEIKYUDATE          datetime,                                       /* 請求日付             */
    JYUTYUNO            decimal(10,0)   NOT NULL  DEFAULT 0,            /* 受注Ｎｏ             */
    SEIKYUGAKU          decimal(12,0)   NOT NULL  DEFAULT 0,            /* 請求金額             */
    DEKIDAKARITU        decimal(8,3)    NOT NULL  DEFAULT 0,            /* 出来高率             */
    G_BIKO              varchar(40),                                    /* 行備考               */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日時             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日時             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE T_SEIKYU ADD CONSTRAINT IDX_SEIKYU_PK PRIMARY KEY
 (SEIKYUNO,SEIKYUEDABAN,GYONO)
GO


/* IDX_SEIKYU_SUMI_SEARCHKEY */
 CREATE INDEX IDX_SEIKYU_SUMI_SEARCHKEY ON
       T_SEIKYU(SEIKYUNO,SEIKYUDATE)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_T_SEIKYU ON T_SEIKYU FOR UPDATE AS
 UPDATE T_SEIKYU SET UDATE = GETDATE()
 FROM T_SEIKYU, inserted
 WHERE T_SEIKYU.SEIKYUNO = inserted.SEIKYUNO
   AND T_SEIKYU.SEIKYUEDABAN = inserted.SEIKYUEDABAN
   AND T_SEIKYU.GYONO = inserted.GYONO
GO

