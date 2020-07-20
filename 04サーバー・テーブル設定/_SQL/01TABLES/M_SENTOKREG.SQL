/* =================================================================== */
/* M_得意先選択登録 (M_SENTOKREG)                                      */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE M_SENTOKREG (                                             /* M_得意先選択登録 */
    PCNAME              varchar(15)     NOT NULL,                       /* 端末名               */
    PGCODE              varchar(20)     NOT NULL,                       /* プログラムコード     */
    FULINO              decimal(1,0)    NOT NULL  DEFAULT 0,            /* 振り分けＮＯ         */
    TOKUICODE           varchar(16)     NOT NULL,                       /* 得意先コード         */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日付             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日付             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE M_SENTOKREG ADD CONSTRAINT IDX_SENTOKREG_PK PRIMARY KEY
 (PCNAME,PGCODE,FULINO ,TOKUICODE)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_M_SENTOKREG ON M_SENTOKREG FOR UPDATE AS
 UPDATE M_SENTOKREG SET UDATE = GETDATE()
 FROM M_SENTOKREG, inserted
 WHERE M_SENTOKREG.PCNAME = inserted.PCNAME
   AND M_SENTOKREG.PGCODE = inserted.PGCODE
   AND M_SENTOKREG.FULINO  = inserted.FULINO 
   AND M_SENTOKREG.TOKUICODE = inserted.TOKUICODE
GO

