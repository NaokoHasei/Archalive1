/* =================================================================== */
/* 小科目マスタ (M_SYOKAMOKU)                                          */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE M_SYOKAMOKU (                                             /* 小科目マスタ */
    SYOKAMOKUCODE       varchar(6)      NOT NULL,                       /* 小科目コード         */
    SYOKAMOKUNAME       varchar(30),                                    /* 小科目名称           */
    SYOKAMOKUNAME2      varchar(30),                                    /* 小科目名称２         */
    MENUKEY             varchar(8),                                     /* メニューキー         */
    CYUKAMOKUCODE       varchar(3),                                     /* 中科目コード         */
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
 ALTER TABLE M_SYOKAMOKU ADD CONSTRAINT IDX_SYOKAMOKU_PK PRIMARY KEY
 (SYOKAMOKUCODE)
GO


/* IDX_SYOKAMOKU_MENUKEY */
 CREATE INDEX IDX_SYOKAMOKU_MENUKEY ON
       M_SYOKAMOKU(MENUKEY,SYOKAMOKUCODE)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_M_SYOKAMOKU ON M_SYOKAMOKU FOR UPDATE AS
 UPDATE M_SYOKAMOKU SET UDATE = GETDATE()
 FROM M_SYOKAMOKU, inserted
 WHERE M_SYOKAMOKU.SYOKAMOKUCODE = inserted.SYOKAMOKUCODE
GO

