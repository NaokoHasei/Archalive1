/* =================================================================== */
/* 基本設定マスタ (S_SCB)                                              */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE S_SCB (                                                   /* 基本設定マスタ */
    CATEGORYID          varchar(100)    NOT NULL,                       /* カテゴリID           */
    DATAKEY             varchar(100)    NOT NULL,                       /* データキー           */
    DATA                varchar(256)    NOT NULL  DEFAULT '',           /* データ               */
    CATEGORYNAME        varchar(30)     NOT NULL  DEFAULT '',           /* カテゴリ名           */
    DATANAME            varchar(30)     NOT NULL  DEFAULT '',           /* データ名             */
    COMMENT             varchar(256)    NOT NULL  DEFAULT '',           /* コメント             */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERID        varchar(15)     NOT NULL,                       /* 更新ユーザーID       */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日付             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日付             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE S_SCB ADD CONSTRAINT IDX_S_SCB_PK PRIMARY KEY
 (CATEGORYID,DATAKEY,DATA)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_S_SCB ON S_SCB FOR UPDATE AS
 UPDATE S_SCB SET UDATE = GETDATE()
 FROM S_SCB, inserted
 WHERE S_SCB.CATEGORYID = inserted.CATEGORYID
   AND S_SCB.DATAKEY = inserted.DATAKEY
   AND S_SCB.DATA = inserted.DATA
GO

