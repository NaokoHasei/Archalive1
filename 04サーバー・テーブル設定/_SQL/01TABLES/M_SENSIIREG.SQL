/* =================================================================== */
/* M_仕入先選択登録 (M_SENSIIREG)                                      */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE M_SENSIIREG (                                             /* M_仕入先選択登録 */
    PCNAME              varchar(15)     NOT NULL,                       /* 端末名               */
    PGCODE              varchar(20)     NOT NULL,                       /* プログラムコード     */
    FULINO              decimal(1,0)    NOT NULL  DEFAULT 0,            /* 振り分けＮＯ         */
    SIIRECODE           varchar(8)      NOT NULL,                       /* 仕入先コード         */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日付             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日付             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE M_SENSIIREG ADD CONSTRAINT IDX_SENSIIREG_PK PRIMARY KEY
 (PCNAME,PGCODE,FULINO ,SIIRECODE)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_M_SENSIIREG ON M_SENSIIREG FOR UPDATE AS
 UPDATE M_SENSIIREG SET UDATE = GETDATE()
 FROM M_SENSIIREG, inserted
 WHERE M_SENSIIREG.PCNAME = inserted.PCNAME
   AND M_SENSIIREG.PGCODE = inserted.PGCODE
   AND M_SENSIIREG.FULINO  = inserted.FULINO 
   AND M_SENSIIREG.SIIRECODE = inserted.SIIRECODE
GO

