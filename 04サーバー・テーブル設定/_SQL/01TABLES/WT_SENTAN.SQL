/* =================================================================== */
/* WT_担当者選択 (WT_SENTAN)                                           */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE WT_SENTAN (                                               /* WT_担当者選択 */
    PCNAME              varchar(15)     NOT NULL,               /* 端末名               */
    PGCODE              varchar(20)     NOT NULL,               /* プログラムコード     */
    FULINO              decimal(1,0)    NOT NULL  DEFAULT 0,    /* 振り分けＮＯ         */
    TANTOCODE           varchar(4)      NOT NULL,               /* 担当者コード         */
    MENUKEY             varchar(20),                            /* メニューキー         */
    TANTONAME           varchar(20),                            /* 担当者名称           */
    CHKARIA             decimal(1,0)    NOT NULL  DEFAULT 0,    /* チェックエリア       */
    SENKBN              decimal(1,0)    NOT NULL  DEFAULT 0     /* 選択区分             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE WT_SENTAN ADD CONSTRAINT IDX_SENTAN_PK PRIMARY KEY
 (PCNAME,PGCODE,FULINO ,TANTOCODE)
GO


/* IDX_SENTAN_EXTRACTKEY */
 CREATE INDEX IDX_SENTAN_EXTRACTKEY ON
       WT_SENTAN(PCNAME,PGCODE,FULINO ,SENKBN,TANTOCODE)
GO


/* IDX_SENTAN_MENUKEY */
 CREATE INDEX IDX_SENTAN_MENUKEY ON
       WT_SENTAN(PCNAME,PGCODE,FULINO ,MENUKEY,TANTOCODE)
GO


/* IDX_SENTAN_NAMEKEY */
 CREATE INDEX IDX_SENTAN_NAMEKEY ON
       WT_SENTAN(PCNAME,PGCODE,FULINO ,TANTONAME,TANTOCODE)
GO

