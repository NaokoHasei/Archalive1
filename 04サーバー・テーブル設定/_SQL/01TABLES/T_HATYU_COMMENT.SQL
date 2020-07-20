/* =================================================================== */
/* 発注コメントトラン (T_HATYU_COMMENT)                                */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE T_HATYU_COMMENT (                                         /* 発注コメントトラン */
    HATYUNO             decimal(10,0)   NOT NULL  DEFAULT 0,            /* 発注Ｎｏ             */
    HATYUEDABAN         decimal(2,0)    NOT NULL  DEFAULT 0,            /* 発注枝番             */
    HATYUEDABAN2        decimal(2,0)    NOT NULL  DEFAULT 0,            /* 発注枝番２           */
    CATEGORYID          varchar(16)     NOT NULL,                       /* カテゴリID           */
    DATAKEY             varchar(16)     NOT NULL,                       /* データキー           */
    DATA                varchar(MAX)    NOT NULL  DEFAULT '',           /* データ               */
    UPDATEMENT          datetime        NOT NULL  DEFAULT GETDATE(),    /* 最新メンテ日時       */
    UPDATEPGID          varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERID        varchar(15)     NOT NULL,                       /* 更新ユーザーID       */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日付             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日付             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE T_HATYU_COMMENT ADD CONSTRAINT IDX_HATYU_COMMENT_PK PRIMARY KEY
 (HATYUNO,HATYUEDABAN,HATYUEDABAN2,CATEGORYID,DATAKEY)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_T_HATYU_COMMENT ON T_HATYU_COMMENT FOR UPDATE AS
 UPDATE T_HATYU_COMMENT SET UDATE = GETDATE()
 FROM T_HATYU_COMMENT, inserted
 WHERE T_HATYU_COMMENT.HATYUNO = inserted.HATYUNO
   AND T_HATYU_COMMENT.HATYUEDABAN = inserted.HATYUEDABAN
   AND T_HATYU_COMMENT.HATYUEDABAN2 = inserted.HATYUEDABAN2
   AND T_HATYU_COMMENT.CATEGORYID = inserted.CATEGORYID
   AND T_HATYU_COMMENT.DATAKEY = inserted.DATAKEY
GO

