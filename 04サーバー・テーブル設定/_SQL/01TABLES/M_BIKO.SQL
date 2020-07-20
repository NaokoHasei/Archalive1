/* =================================================================== */
/* 備考マスタ (M_BIKO)                                                 */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE M_BIKO (                                                  /* 備考マスタ */
    PGKBN               decimal(2,0)    NOT NULL  DEFAULT 0,            /* 使用ＰＧ区分         */
    BIKOKBN             varchar(01)     NOT NULL,                       /* 備考区分             */
    BIKO                varchar(30),                                    /* 備考                 */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日時             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日時             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE M_BIKO ADD CONSTRAINT IDX_M_BIKOU_PK PRIMARY KEY
 (PGKBN,BIKOKBN)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_M_BIKO ON M_BIKO FOR UPDATE AS
 UPDATE M_BIKO SET UDATE = GETDATE()
 FROM M_BIKO, inserted
 WHERE M_BIKO.PGKBN = inserted.PGKBN
   AND M_BIKO.BIKOKBN = inserted.BIKOKBN
GO

