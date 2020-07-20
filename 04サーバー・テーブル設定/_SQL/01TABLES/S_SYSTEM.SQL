/* =================================================================== */
/* システム設定マスタ (S_SYSTEM)                                       */
/* =================================================================== */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE S_SYSTEM (                                                /* システム設定マスタ */
    PCNAME              varchar(15)     NOT NULL,                       /* 端末名               */
    SYSTEMFILE          varchar(20)     NOT NULL,                       /* ファイルの種類       */
    SYSTEMFILEINFO      varchar(100)              DEFAULT '',           /* ファイルの種類（説明） */
    SECTIONNAME         varchar(20)     NOT NULL,                       /* セクション名称       */
    SECTIONNAMEINFO     varchar(100)              DEFAULT '',           /* セクション名称（説明） */
    PROPERTYNAME        varchar(30)     NOT NULL,                       /* プロパティ名称       */
    PROPERTYNAMEINFO    varchar(100)              DEFAULT '',           /* プロパティ名称（説明） */
    VALUE               varchar(100)              DEFAULT '',           /* 値                   */
    UPDATEPGID          Varchar(20)     NOT NULL,                       /* 更新プログラムID     */
    UPDATEUSERCODE      Varchar(15)     NOT NULL,                       /* ユーザーID           */
    CDATE               datetime        NOT NULL  DEFAULT GETDATE(),    /* 作成日付             */
    UDATE               datetime        NOT NULL  DEFAULT GETDATE()     /* 更新日付             */
 )
GO

/* PRIMARYKEY作成 */
 ALTER TABLE S_SYSTEM ADD CONSTRAINT IDX_S_SYSTEM_PK PRIMARY KEY
 (PCNAME,SYSTEMFILE,SECTIONNAME,PROPERTYNAME)
GO

/* TRIGGER作成 */
 CREATE TRIGGER TRI_U_S_SYSTEM ON S_SYSTEM FOR UPDATE AS
 UPDATE S_SYSTEM SET UDATE = GETDATE()
 FROM S_SYSTEM, inserted
 WHERE S_SYSTEM.PCNAME = inserted.PCNAME
   AND S_SYSTEM.SYSTEMFILE = inserted.SYSTEMFILE
   AND S_SYSTEM.SECTIONNAME = inserted.SECTIONNAME
   AND S_SYSTEM.PROPERTYNAME = inserted.PROPERTYNAME
GO

