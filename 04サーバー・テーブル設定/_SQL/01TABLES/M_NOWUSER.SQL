/* =================================================================== */
/* 現在ユーザーマスタ (M_NOWUSER)                                      */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE M_NOWUSER (                                               /* 現在ユーザーマスタ */
    PCNAME              varchar(15)     NOT NULL,                       /* 端末名               */
    TANTOCODE           varchar(4)      NOT NULL,                       /* 担当者コード         */
    PASSWORD            varchar(15)               DEFAULT '',           /* パスワード           */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日付             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日付             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE M_NOWUSER ADD CONSTRAINT IDX_NOWUSER_PK PRIMARY KEY
 (PCNAME,TANTOCODE)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_M_NOWUSER ON M_NOWUSER FOR UPDATE AS
 UPDATE M_NOWUSER SET UDATE = GETDATE()
 FROM M_NOWUSER, inserted
 WHERE M_NOWUSER.PCNAME = inserted.PCNAME
   AND M_NOWUSER.TANTOCODE = inserted.TANTOCODE
GO

