/* =================================================================== */
/* 元号マスタ (M_GENGO)                                                */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE M_GENGO (                                                 /* 元号マスタ */
    GENGOCODE           varchar(1)      NOT NULL,                       /* 元号コード           */
    GENGONAME           varchar(50)               DEFAULT '',           /* 元号名称             */
    KAISISEIREKI        datetime,                                       /* 開始西暦             */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE      varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日時             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日時             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE M_GENGO ADD CONSTRAINT IDX_GENGO_PK PRIMARY KEY
 (GENGOCODE)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_M_GENGO ON M_GENGO FOR UPDATE AS
 UPDATE M_GENGO SET UDATE = GETDATE()
 FROM M_GENGO, inserted
 WHERE M_GENGO.GENGOCODE = inserted.GENGOCODE
GO

