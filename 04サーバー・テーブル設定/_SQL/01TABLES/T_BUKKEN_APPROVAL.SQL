/* =================================================================== */
/* 物件承認トラン (T_BUKKEN_APPROVAL)                                  */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE T_BUKKEN_APPROVAL (                                       /* 物件承認トラン */
    BUKKENNO            decimal(10,0)   NOT NULL  DEFAULT 0,            /* 物件Ｎｏ             */
    GYOMUKBN            decimal(1,0)    NOT NULL  DEFAULT 0,            /* 業務区分             */
    EDABAN              decimal(2,0)    NOT NULL  DEFAULT 0,            /* 枝番                 */
    APPROVALKBN         decimal(1,0)    NOT NULL  DEFAULT 0,            /* 承認区分             */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日時             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日時             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE T_BUKKEN_APPROVAL ADD CONSTRAINT IDX_T_BUKKEN_GYOMU_LINK_PK PRIMARY KEY
 (BUKKENNO,GYOMUKBN,EDABAN)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_T_BUKKEN_APPROVAL ON T_BUKKEN_APPROVAL FOR UPDATE AS
 UPDATE T_BUKKEN_APPROVAL SET UDATE = GETDATE()
 FROM T_BUKKEN_APPROVAL, inserted
 WHERE T_BUKKEN_APPROVAL.BUKKENNO = inserted.BUKKENNO
   AND T_BUKKEN_APPROVAL.GYOMUKBN = inserted.GYOMUKBN
   AND T_BUKKEN_APPROVAL.EDABAN = inserted.EDABAN
GO

