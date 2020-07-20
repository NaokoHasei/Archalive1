/* =================================================================== */
/* WT_仕入先選択 (WT_SENSII)                                           */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE WT_SENSII (                                               /* WT_仕入先選択 */
    PCNAME              varchar(15)     NOT NULL,               /* 端末名               */
    PGCODE              varchar(20)     NOT NULL,               /* プログラムコード     */
    FULINO              decimal(1,0)    NOT NULL  DEFAULT 0,    /* 振り分けＮＯ         */
    SIIRECODE           varchar(8)      NOT NULL,               /* 仕入先コード         */
    MENUKEY             varchar(50),                            /* メニューキー         */
    SIIRENAME           varchar(40),                            /* 仕入先名称           */
    CHKARIA             decimal(1,0)    NOT NULL  DEFAULT 0,    /* チェックエリア       */
    SENKBN              decimal(1,0)    NOT NULL  DEFAULT 0     /* 選択区分             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE WT_SENSII ADD CONSTRAINT IDX_SENSII_PK PRIMARY KEY
 (PCNAME,PGCODE,FULINO ,SIIRECODE)
GO


/* IDX_SENSII_EXTRACTKEY */
 CREATE INDEX IDX_SENSII_EXTRACTKEY ON
       WT_SENSII(PCNAME,PGCODE,FULINO ,SENKBN,SIIRECODE)
GO


/* IDX_SENSII_MENUKEY */
 CREATE INDEX IDX_SENSII_MENUKEY ON
       WT_SENSII(PCNAME,PGCODE,FULINO ,MENUKEY,SIIRECODE)
GO


/* IDX_SENSII_NAMEKEY */
 CREATE INDEX IDX_SENSII_NAMEKEY ON
       WT_SENSII(PCNAME,PGCODE,FULINO ,SIIRENAME,SIIRECODE)
GO

