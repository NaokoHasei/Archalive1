/* =================================================================== */
/* メッセージマスタ (S_MESSAGE)                                        */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE S_MESSAGE (                                               /* メッセージマスタ */
    MSGCODE             Varchar(3)      NOT NULL  DEFAULT 0,            /* メッセージコード     */
    BUTTONS             Varchar(1)      NOT NULL,                       /* ＩＣＯＮ種類         */
    MESSAGE             varchar(200),                                   /* メッセージ           */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日付             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日付             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE S_MESSAGE ADD CONSTRAINT IDX_MESSAGE_PK PRIMARY KEY
 (MSGCODE)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_S_MESSAGE ON S_MESSAGE FOR UPDATE AS
 UPDATE S_MESSAGE SET UDATE = GETDATE()
 FROM S_MESSAGE, inserted
 WHERE S_MESSAGE.MSGCODE = inserted.MSGCODE
GO

