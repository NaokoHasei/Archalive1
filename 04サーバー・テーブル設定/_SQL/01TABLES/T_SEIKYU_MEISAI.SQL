/* =================================================================== */
/* ¿¾×g (T_SEIKYU_MEISAI)                                    */
/* =================================================================== */

/*-----------------------* e[uÌì¬ *----------------------------*/
 CREATE TABLE T_SEIKYU_MEISAI (                                         /* ¿¾×g */
    SEIKYUNO                    decimal(10,0)   NOT NULL  DEFAULT 0,            /* ¿m             */
    SEIKYUEDABAN                decimal(2,0)    NOT NULL  DEFAULT 0,            /* ¿}Ô             */
    JYUTYUEDABAN                decimal(2,0)    NOT NULL  DEFAULT 0,            /* ó}Ô             */
    KAISOCODE                   varchar(30)     NOT NULL,                       /* KwR[h           */
    DELETE_FLG                  decimal(1,0)    NOT NULL  DEFAULT 0,            /* ítO           */
    KAISOCODE_ZENKAI            varchar(30)     NOT NULL,                       /* KwR[hiOñj   */
    JYUTYUEDABAN_DAIKAMOKU      decimal(10,0)   NOT NULL  DEFAULT 0,            /* ó}ÔiåÈÚj   */
    KAISOCODE_DAIKAMOKU         varchar(30)     NOT NULL,                       /* KwR[hiåÈÚj */
    KAMOKU_HINMOKU_DAIKAMOKU    varchar(40),                                    /* ÈÚEiÚiåÈÚj */
    KAMOKU_HINMOKU              varchar(40),                                    /* ÈÚEiÚ           */
    HINSITU_KIKAKU_SIYO         varchar(40),                                    /* i¿EKiEdl     */
    TANI                        varchar(10),                                    /* PÊ                 */
    JYUTYUSUU                   decimal(11,3)   NOT NULL  DEFAULT 0,            /* óÊ             */
    JYUTYUTANKA                 decimal(12,3)   NOT NULL  DEFAULT 0,            /* óP¿             */
    JYUTYUGAKU                  decimal(12,0)   NOT NULL  DEFAULT 0,            /* óàz             */
    JYUTYUSUU_HENKO             decimal(11,3)   NOT NULL  DEFAULT 0,            /* óÊ_ÏX        */
    JYUTYUGAKU_HENKO            decimal(12,0)   NOT NULL  DEFAULT 0,            /* óàz_ÏX        */
    SEIKYUSUU_ZENKAI            decimal(11,3)   NOT NULL  DEFAULT 0,            /* ¿Ê_Oñ        */
    SEIKYUGAKU_ZENKAI           decimal(12,0)   NOT NULL  DEFAULT 0,            /* ¿àz_Oñ        */
    SEIKYUSUU_KONKAI            decimal(11,3)   NOT NULL  DEFAULT 0,            /* ¿Ê_¡ñ        */
    SEIKYUGAKU_KONKAI           decimal(12,0)   NOT NULL  DEFAULT 0,            /* ¿àz_¡ñ        */
    SEIKYUSUU_RUIKEI            decimal(11,3)   NOT NULL  DEFAULT 0,            /* ¿Ê_Ýv        */
    SEIKYUGAKU_RUIKEI           decimal(12,0)   NOT NULL  DEFAULT 0,            /* ¿àz_Ýv        */
    UPDATEMENT                  datetime        NOT NULL  DEFAULT GETDATE(),    /* ÅVeú       */
    UPDATEPGID                  Varchar(20)     NOT NULL,                       /* XVvOID     */
    UPDATEUSERCODE              Varchar(15)     NOT NULL,                       /* [U[ID           */
    CDATE                       datetime        NOT NULL  DEFAULT GETDATE(),    /* ì¬ú             */
    UDATE                       datetime        NOT NULL  DEFAULT GETDATE()     /* XVú             */
 )
GO


/* IDX_SEIKYU_MEISAI */
 CREATE UNIQUE INDEX IDX_SEIKYU_MEISAI ON
       T_SEIKYU_MEISAI(SEIKYUNO,SEIKYUEDABAN,JYUTYUEDABAN,KAISOCODE,DELETE_FLG)
GO

