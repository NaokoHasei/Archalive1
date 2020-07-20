/* =================================================================== */
/* プログラム情報マスタ (M_PROGRAMCONDISION)                           */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE M_PROGRAMCONDISION (                                      /* プログラム情報マスタ */
    USERCODE            varchar(15)     NOT NULL,                       /* ユーザーコード       */
    PROGRAMCODE         varchar(20)     NOT NULL,                       /* プログラムコード     */
    PROGRAMNAME         varchar(30),                                    /* プログラム名         */
    JIKOUKBN            bit,                                            /* 実行区分             */
    SYUTURYOKUKBN       bit,                                            /* 出力区分             */
    DISPNO              decimal(5,0)    NOT NULL  DEFAULT 0,            /* 表示順番             */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日付             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日付             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE M_PROGRAMCONDISION ADD CONSTRAINT IDX_PROGRAMCONDISION_PK PRIMARY KEY
 (USERCODE,PROGRAMCODE)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_M_PROGRAMCONDISION ON M_PROGRAMCONDISION FOR UPDATE AS
 UPDATE M_PROGRAMCONDISION SET UDATE = GETDATE()
 FROM M_PROGRAMCONDISION, inserted
 WHERE M_PROGRAMCONDISION.USERCODE = inserted.USERCODE
   AND M_PROGRAMCONDISION.PROGRAMCODE = inserted.PROGRAMCODE
GO

