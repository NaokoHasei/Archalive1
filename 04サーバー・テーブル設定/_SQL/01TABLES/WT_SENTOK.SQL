/* =================================================================== */
/* WT_得意先選択 (WT_SENTOK)                                           */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE WT_SENTOK (                                               /* WT_得意先選択 */
    PCNAME              varchar(15)     NOT NULL,               /* 端末名               */
    PGCODE              varchar(20)     NOT NULL,               /* プログラムコード     */
    FULINO              decimal(1,0)    NOT NULL  DEFAULT 0,    /* 振り分けＮＯ         */
    TOKUICODE           varchar(16)     NOT NULL,               /* 得意先コード         */
    MENUKEY             varchar(50),                            /* メニューキー         */
    TOKUINAME           varchar(40),                            /* 得意先名称           */
    CHKARIA             decimal(1,0)    NOT NULL  DEFAULT 0,    /* チェックエリア       */
    SENKBN              decimal(1,0)    NOT NULL  DEFAULT 0     /* 選択区分             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE WT_SENTOK ADD CONSTRAINT IDX_SENTOK_PK PRIMARY KEY
 (PCNAME,PGCODE,FULINO ,TOKUICODE)
GO


/* IDX_SENTOK_EXTRACTKEY */
 CREATE INDEX IDX_SENTOK_EXTRACTKEY ON
       WT_SENTOK(PCNAME,PGCODE,FULINO ,SENKBN,TOKUICODE)
GO


/* IDX_SENTOK_MENUKEY */
 CREATE INDEX IDX_SENTOK_MENUKEY ON
       WT_SENTOK(PCNAME,PGCODE,FULINO ,MENUKEY,TOKUICODE)
GO


/* IDX_SENTOK_NAMEKEY */
 CREATE INDEX IDX_SENTOK_NAMEKEY ON
       WT_SENTOK(PCNAME,PGCODE,FULINO ,TOKUINAME,TOKUICODE)
GO

