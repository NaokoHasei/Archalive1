/* =================================================================== */
/* 部課マスタ (M_BUKA)                                                 */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE M_BUKA (                                                  /* 部課マスタ */
    BUKACODE            varchar(4)      NOT NULL,                       /* 部課コード           */
    BUKANAME            varchar(30),                                    /* 部課名称             */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日時             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日時             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE M_BUKA ADD CONSTRAINT IDX_BUKA_PK PRIMARY KEY
 (BUKACODE)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_M_BUKA ON M_BUKA FOR UPDATE AS
 UPDATE M_BUKA SET UDATE = GETDATE()
 FROM M_BUKA, inserted
 WHERE M_BUKA.BUKACODE = inserted.BUKACODE
GO

