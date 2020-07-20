/* =================================================================== */
/* 大科目マスタ (M_DAIKAMOKU)                                          */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE M_DAIKAMOKU (                                             /* 大科目マスタ */
    DAIKAMOKUCODE       varchar(3)      NOT NULL,                       /* 大科目コード         */
    DAIKAMOKUNAME       varchar(30),                                    /* 大科目名称           */
    DAIKAMOKUNAME2      varchar(30),                                    /* 大科目名称２         */
    MENUKEY             varchar(8),                                     /* メニューキー         */
    TANI                varchar(10),                                    /* 単位                 */
    GENTANKA            decimal(12,3)   NOT NULL  DEFAULT 0,            /* 原単価               */
    MIT_JYU_TANAKA      decimal(12,3)   NOT NULL  DEFAULT 0,            /* 見積/受注単価        */
    KOUJISYUKBN         decimal(1,0)    NOT NULL  DEFAULT 0,            /* 工事種区分           */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日時             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日時             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE M_DAIKAMOKU ADD CONSTRAINT IDX_DAIKAMOKU_PK PRIMARY KEY
 (DAIKAMOKUCODE)
GO


/* IDX_DAIKAMOKU_MENUKEY */
 CREATE INDEX IDX_DAIKAMOKU_MENUKEY ON
       M_DAIKAMOKU(MENUKEY,DAIKAMOKUCODE)
GO


/* IDX_DAIKAMOKU_KOUJISYUKBNKEY */
 CREATE INDEX IDX_DAIKAMOKU_KOUJISYUKBNKEY ON
       M_DAIKAMOKU(KOUJISYUKBN,DAIKAMOKUCODE)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_M_DAIKAMOKU ON M_DAIKAMOKU FOR UPDATE AS
 UPDATE M_DAIKAMOKU SET UDATE = GETDATE()
 FROM M_DAIKAMOKU, inserted
 WHERE M_DAIKAMOKU.DAIKAMOKUCODE = inserted.DAIKAMOKUCODE
GO

