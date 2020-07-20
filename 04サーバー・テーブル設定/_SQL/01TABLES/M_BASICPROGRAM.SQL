/* =================================================================== */
/* プログラム基本マスタ (M_BASICPROGRAM)                               */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE M_BASICPROGRAM (                                          /* プログラム基本マスタ */
    PROGRAMCODE         varchar(20)     NOT NULL,                       /* プログラムコード     */
    PROGRAMNAME         varchar(30),                                    /* プログラム名         */
    JIKOUKBN            bit,                                            /* 実行区分             */
    SYUTURYOKUKBN       bit,                                            /* 出力区分             */
    DISPNO              decimal(5,0)    NOT NULL  DEFAULT 0,            /* 表示順番             */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日時             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日時             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE M_BASICPROGRAM ADD CONSTRAINT IDX_BASICPROGRAM_PK PRIMARY KEY
 (PROGRAMCODE)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_M_BASICPROGRAM ON M_BASICPROGRAM FOR UPDATE AS
 UPDATE M_BASICPROGRAM SET UDATE = GETDATE()
 FROM M_BASICPROGRAM, inserted
 WHERE M_BASICPROGRAM.PROGRAMCODE = inserted.PROGRAMCODE
GO

