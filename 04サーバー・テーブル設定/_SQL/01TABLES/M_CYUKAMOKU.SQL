/* =================================================================== */
/* 中科目マスタ (M_CYUKAMOKU)                                          */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE M_CYUKAMOKU (                                             /* 中科目マスタ */
    CYUKAMOKUCODE       varchar(3)      NOT NULL,                       /* 中科目コード         */
    CYUKAMOKUNAME       varchar(30),                                    /* 中科目名称           */
    CYUKAMOKUNAME2      varchar(30),                                    /* 中科目名称２         */
    MENUKEY             varchar(8),                                     /* メニューキー         */
    DAIKAMOKUCODE       varchar(3),                                     /* 大科目コード         */
    TANI                varchar(10),                                    /* 単位                 */
    GENTANKA            decimal(12,3)   NOT NULL  DEFAULT 0,            /* 原単価               */
    MIT_JYU_TANAKA      decimal(12,3)   NOT NULL  DEFAULT 0,            /* 見積/受注単価        */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日時             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日時             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE M_CYUKAMOKU ADD CONSTRAINT IDX_CYUKAMOKU_PK PRIMARY KEY
 (CYUKAMOKUCODE)
GO


/* IDX_CYUKAMOKU_MENUKEY */
 CREATE INDEX IDX_CYUKAMOKU_MENUKEY ON
       M_CYUKAMOKU(MENUKEY,CYUKAMOKUCODE)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_M_CYUKAMOKU ON M_CYUKAMOKU FOR UPDATE AS
 UPDATE M_CYUKAMOKU SET UDATE = GETDATE()
 FROM M_CYUKAMOKU, inserted
 WHERE M_CYUKAMOKU.CYUKAMOKUCODE = inserted.CYUKAMOKUCODE
GO

