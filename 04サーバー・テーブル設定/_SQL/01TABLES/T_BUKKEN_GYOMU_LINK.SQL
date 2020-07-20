/* =================================================================== */
/* 物件業務リンクトラン (T_BUKKEN_GYOMU_LINK)                          */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE T_BUKKEN_GYOMU_LINK (                                     /* 物件業務リンクトラン */
    BUKKENNO            decimal(10,0)   NOT NULL  DEFAULT 0,            /* 物件Ｎｏ             */
    GYOMUKBN            decimal(1,0)    NOT NULL  DEFAULT 0,            /* 業務区分             */
    GYOMUNO             decimal(10,0)   NOT NULL  DEFAULT 0,            /* 業務No               */
    GYOMUEDABAN         decimal(2,0)    NOT NULL  DEFAULT 0,            /* 業務枝番             */
    APPROVALKBN         decimal(1,0)    NOT NULL  DEFAULT 0,            /* 承認区分             */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日時             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日時             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE T_BUKKEN_GYOMU_LINK ADD CONSTRAINT IDX_T_BUKKEN_GYOMU_LINK_PK PRIMARY KEY
 (BUKKENNO,GYOMUKBN,GYOMUNO,GYOMUEDABAN)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_T_BUKKEN_GYOMU_LINK ON T_BUKKEN_GYOMU_LINK FOR UPDATE AS
 UPDATE T_BUKKEN_GYOMU_LINK SET UDATE = GETDATE()
 FROM T_BUKKEN_GYOMU_LINK, inserted
 WHERE T_BUKKEN_GYOMU_LINK.BUKKENNO = inserted.BUKKENNO
   AND T_BUKKEN_GYOMU_LINK.GYOMUKBN = inserted.GYOMUKBN
   AND T_BUKKEN_GYOMU_LINK.GYOMUNO = inserted.GYOMUNO
   AND T_BUKKEN_GYOMU_LINK.GYOMUEDABAN = inserted.GYOMUEDABAN
GO

