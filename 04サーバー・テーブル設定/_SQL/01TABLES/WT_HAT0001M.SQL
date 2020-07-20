/* =================================================================== */
/* 発注入力ワーク (WT_HAT0001M)                                        */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE WT_HAT0001M (                                             /* 発注入力ワーク */
    PCNAME              varchar(15)     NOT NULL,               /* 端末名               */
    PAGE                decimal(3,0)    NOT NULL  DEFAULT 0,    /* 頁                   */
    KBN                 decimal(1,0)    NOT NULL  DEFAULT 0,    /* 区分                 */
    GYONO               decimal(3,0)    NOT NULL  DEFAULT 0,    /* 行番号               */
    NAME                varchar(40)               DEFAULT '',   /* 名称・仕様           */
    SURYO               varchar(40)               DEFAULT '',   /* 数量                 */
    TANI                varchar(40)               DEFAULT '',   /* 単位                 */
    TANKA               varchar(40)               DEFAULT '',   /* 単価                 */
    KINGAKU             varchar(40)               DEFAULT ''    /* 金額                 */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE WT_HAT0001M ADD CONSTRAINT IDX_HAT0001M_PK PRIMARY KEY
 (PCNAME,PAGE,KBN,GYONO)
GO

