--*****************************************************************************
--* データベース・ユーザーの作成
--*****************************************************************************

--***** ユーザーの作成 ********************************************************
sp_addlogin U_Archalive1, Archalive1
go

--bulkadmin設定
sp_addsrvrolemember @loginame='U_Archalive1',@rolename='bulkadmin'
go

--***** メインＤＢ ************************************************************

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

--自動終了off
ALTER DATABASE [DB_Archalive1] SET AUTO_CLOSE OFF
GO

--カレントＤＢの設定
use DB_Archalive1
go

--指定のユーザーにカレントＤＢのアクセス権を与える
sp_grantdbaccess U_Archalive1
go

--指定のユーザーをカレントＤＢのオーナーに設定
sp_addrolemember db_owner, U_Archalive1
go