/* =================================================================== */
/* ���}�X�^ (M_KEN)                                                    */
/* =================================================================== */

/* -----------------* �J�����g�f�[�^�x�[�X���̐ݒ� *------------------ */

/*-----------------------* �e�[�u���̍쐬 *----------------------------*/
 CREATE TABLE M_KEN (                                                   /* ���}�X�^ */
    DANTAICODE          varchar(5),                                     /* �c�̃R�[�h           */
    OLDPOSTCODE         varchar(5),                                     /* ���X�֔ԍ�           */
    POSTCODE            varchar(7),                                     /* �X�֔ԍ�             */
    TODOUFUKEN_KANA     varchar(8),                                     /* �s���{���J�i         */
    SIKUTYOUSON_KANA    varchar(32),                                    /* �s�撬���J�i         */
    TYOUIKI_KANA        varchar(128),                                   /* ����J�i             */
    TODOUFUKEN          varchar(8),                                     /* �s���{��             */
    SIKUTYOUSON         varchar(32),                                    /* �s�撬��             */
    TYOUIKI             varchar(128),                                   /* ����                 */
    CDATE               datetime                  DEFAULT GETDATE(),    /* �쐬���t             */
    UDATE               datetime                  DEFAULT GETDATE()     /* �X�V���t             */
 )
GO

