/* =================================================================== */
/* 物件トラン (T_BUKKEN)                                               */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE T_BUKKEN (                                                /* 物件トラン */
    BUKKENNO            decimal(10,0)   NOT NULL  DEFAULT 0,            /* 物件Ｎｏ             */
    BUKKENNAME          varchar(100)    NOT NULL,                       /* 物件名               */
    KOUSHU              varchar(100),                                   /* 工種                 */
    POSTNO              varchar(10),                                    /* 郵便番号             */
    ADDRESS             nvarchar(10),                                   /* 住所（県名）         */
    ADDRESS1            nvarchar(60),                                   /* 住所１（市区町村）   */
    ADDRESS2            nvarchar(60),                                   /* 住所２（方処）       */
    LAT                 varchar(20),                                    /* 緯度                 */
    LNG                 varchar(20),                                    /* 経度                 */
    MOTOUKECODE         varchar(16),                                    /* 元請                 */
    TANTOCODE           varchar(4),                                     /* 担当者コード         */
    CHAKKOUDATE         datetime,                                       /* 着工日               */
    KANKOUDATE          datetime,                                       /* 完工日               */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日時             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日時             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE T_BUKKEN ADD CONSTRAINT IDX_T_BUKKEN_PK PRIMARY KEY
 (BUKKENNO)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_T_BUKKEN ON T_BUKKEN FOR UPDATE AS
 UPDATE T_BUKKEN SET UDATE = GETDATE()
 FROM T_BUKKEN, inserted
 WHERE T_BUKKEN.BUKKENNO = inserted.BUKKENNO
GO

