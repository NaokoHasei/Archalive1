/* =================================================================== */
/* 担当者マスタ (M_TANTO)                                              */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE M_TANTO (                                                 /* 担当者マスタ */
    TANTOCODE           varchar(4)      NOT NULL,                       /* 担当者コード         */
    TANTONAME           varchar(20),                                    /* 担当者名称           */
    TANTOKANA           varchar(20),                                    /* 担当者かな名称       */
    BUKACODE            varchar(4),                                     /* 部課コード           */
    PASSWORD            varchar(30),                                    /* パスワード           */
    SIYOKINOU_AUTHORITY varchar(16)     NOT NULL,                       /* 使用機能の権限       */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日時             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日時             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE M_TANTO ADD CONSTRAINT IDX_TANTO_PK PRIMARY KEY
 (TANTOCODE)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_M_TANTO ON M_TANTO FOR UPDATE AS
 UPDATE M_TANTO SET UDATE = GETDATE()
 FROM M_TANTO, inserted
 WHERE M_TANTO.TANTOCODE = inserted.TANTOCODE
GO

