/* =================================================================== */
/* 物件資料トラン (T_BUKKEN_FILE)                                      */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE T_BUKKEN_FILE (                                           /* 物件資料トラン */
    BUKKENNO            decimal(10,0)   NOT NULL  DEFAULT 0,            /* 物件Ｎｏ             */
    FILENO              decimal(10,0)   NOT NULL  DEFAULT 0,            /* ファイルNo           */
    FILEPATH            Varchar(260)    NOT NULL,                       /* ファイルパス         */
    FILENNAME           Varchar(255)    NOT NULL,                       /* ファイル名           */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日時             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日時             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE T_BUKKEN_FILE ADD CONSTRAINT IDX_T_BUKKEN_FILE_PK PRIMARY KEY
 (BUKKENNO,FILENO)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_T_BUKKEN_FILE ON T_BUKKEN_FILE FOR UPDATE AS
 UPDATE T_BUKKEN_FILE SET UDATE = GETDATE()
 FROM T_BUKKEN_FILE, inserted
 WHERE T_BUKKEN_FILE.BUKKENNO = inserted.BUKKENNO
   AND T_BUKKEN_FILE.FILENO = inserted.FILENO
GO

