/* =================================================================== */
/* WT_JYU0003 (WT_JYU0003)                                             */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE WT_JYU0003 (                                              /* WT_JYU0003 */
    PCNAME              varchar(15)     NOT NULL,               /* 端末名               */
    PGCODE              varchar(20)     NOT NULL,               /* プログラムコード     */
    FULINO              decimal(1,0)    NOT NULL  DEFAULT 0,    /* 振り分けＮＯ         */
    JYUTYUNO            varchar(10)     NOT NULL,               /* 受注No               */
    SENKBN              decimal(1,0)    NOT NULL  DEFAULT 0     /* 選択区分             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE WT_JYU0003 ADD CONSTRAINT IDX_JYU0003_PK PRIMARY KEY
 (PCNAME,PGCODE,FULINO ,JYUTYUNO)
GO


/* IDX_JYU0003_EXTRACTKEY */
 CREATE INDEX IDX_JYU0003_EXTRACTKEY ON
       WT_JYU0003(PCNAME,PGCODE,SENKBN,JYUTYUNO)
GO

