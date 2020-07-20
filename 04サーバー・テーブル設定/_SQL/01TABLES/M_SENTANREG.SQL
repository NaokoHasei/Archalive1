/* =================================================================== */
/* M_担当者選択登録 (M_SENTANREG)                                      */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE M_SENTANREG (                                             /* M_担当者選択登録 */
    PCNAME              varchar(15)     NOT NULL,                       /* 端末名               */
    PGCODE              varchar(20)     NOT NULL,                       /* プログラムコード     */
    FULINO              decimal(1,0)    NOT NULL  DEFAULT 0,            /* 振り分けＮＯ         */
    TANTOCODE           varchar(4)      NOT NULL,                       /* 担当者コード         */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日付             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日付             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE M_SENTANREG ADD CONSTRAINT IDX_SENTANREG_PK PRIMARY KEY
 (PCNAME,PGCODE,FULINO ,TANTOCODE)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_M_SENTANREG ON M_SENTANREG FOR UPDATE AS
 UPDATE M_SENTANREG SET UDATE = GETDATE()
 FROM M_SENTANREG, inserted
 WHERE M_SENTANREG.PCNAME = inserted.PCNAME
   AND M_SENTANREG.PGCODE = inserted.PGCODE
   AND M_SENTANREG.FULINO  = inserted.FULINO 
   AND M_SENTANREG.TANTOCODE = inserted.TANTOCODE
GO

