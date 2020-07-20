--*****************************************************************************
--* �f�[�^�x�[�X�E���[�U�[�̍쐬
--*****************************************************************************

--***** ���[�U�[�̍쐬 ********************************************************
sp_addlogin U_Archalive1, Archalive1
go

--bulkadmin�ݒ�
sp_addsrvrolemember @loginame='U_Archalive1',@rolename='bulkadmin'
go

--***** ���C���c�a ************************************************************

CREATE DATABASE DB_Archalive1
    ON (
        NAME        = Archalive1_dat,
        FILENAME    = 'D:\TYP\Archalive1\DB\Archalive1.mdf',
        SIZE        = 20MB,
        MAXSIZE     = UNLIMITED,
        FILEGROWTH  = 10MB
    )

    LOG ON (
        NAME        = SANKO_log,
        FILENAME    = 'D:\TYP\Archalive1\DB\Archalive1.ldf',
        SIZE        = 20MB,
        MAXSIZE     = UNLIMITED,
        FILEGROWTH  = 10MB
    )
go

--�����I��off
ALTER DATABASE [DB_Archalive1] SET AUTO_CLOSE OFF
GO

--�J�����g�c�a�̐ݒ�
use DB_Archalive1
go

--�w��̃��[�U�[�ɃJ�����g�c�a�̃A�N�Z�X����^����
sp_grantdbaccess U_Archalive1
go

--�w��̃��[�U�[���J�����g�c�a�̃I�[�i�[�ɐݒ�
sp_addrolemember db_owner, U_Archalive1
go