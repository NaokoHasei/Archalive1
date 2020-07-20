/* =================================================================== */
/* 県マスタ (M_KEN)                                                    */
/* =================================================================== */

/* -----------------* カレントデータベース名の設定 *------------------ */

/*-----------------------* テーブルの作成 *----------------------------*/
 CREATE TABLE M_KEN (                                                   /* 県マスタ */
    DANTAICODE          varchar(5),                                     /* 団体コード           */
    OLDPOSTCODE         varchar(5),                                     /* 旧郵便番号           */
    POSTCODE            varchar(7),                                     /* 郵便番号             */
    TODOUFUKEN_KANA     varchar(8),                                     /* 都道府県カナ         */
    SIKUTYOUSON_KANA    varchar(32),                                    /* 市区町村カナ         */
    TYOUIKI_KANA        varchar(128),                                   /* 町域カナ             */
    TODOUFUKEN          varchar(8),                                     /* 都道府県             */
    SIKUTYOUSON         varchar(32),                                    /* 市区町村             */
    TYOUIKI             varchar(128),                                   /* 町域                 */
    CDATE               datetime                  DEFAULT GETDATE(),    /* 作成日付             */
    UDATE               datetime                  DEFAULT GETDATE()     /* 更新日付             */
 )
GO

