/* =================================================================== */
/* 区分マスタ (M_KBN)                                                  */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE M_KBN (                                                   /* 区分マスタ */
    SIYOUKBN            varchar(2)      NOT NULL,                       /* 使用区分             */
    KBN                 varchar(4)      NOT NULL,                       /* 区分                 */
    KBNNAME             varchar(20)               DEFAULT '',           /* 名称                 */
    BIKO                varchar(80)               DEFAULT '',           /* 備考                 */
    ATAI1               varchar(20)               DEFAULT '',           /* 値１                 */
    ATAI2               varchar(20)               DEFAULT '',           /* 値２                 */
    SYOKIHYOJIKBN       tinyint         NOT NULL  DEFAULT 0,            /* 初期表示区分         */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          Varchar(20)     NOT NULL  DEFAULT '',           /* 更新プログラムID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL  DEFAULT '',           /* ユーザーID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日時             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日時             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE M_KBN ADD CONSTRAINT IDX_M_KBN_PK PRIMARY KEY
 (SIYOUKBN,KBN)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_M_KBN ON M_KBN FOR UPDATE AS
 UPDATE M_KBN SET UDATE = GETDATE()
 FROM M_KBN, inserted
 WHERE M_KBN.SIYOUKBN = inserted.SIYOUKBN
   AND M_KBN.KBN = inserted.KBN
GO

