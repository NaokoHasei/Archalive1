use DB_SANKO_ETC

sp_droprolemember db_owner, U_SANKO
go

sp_revokedbaccess U_SANKO
go

use DB_SANKO_JSK

sp_droprolemember db_owner, U_SANKO
go

sp_revokedbaccess U_SANKO
go

use DB_SANKO_TRN

sp_droprolemember db_owner, U_SANKO
go

sp_revokedbaccess U_SANKO
go

use DB_SANKO_MST

sp_droprolemember db_owner, U_SANKO
go

sp_revokedbaccess U_SANKO
go

use DB_SANKO

sp_droprolemember db_owner, U_SANKO
go

sp_revokedbaccess U_SANKO
go

sp_dropdbaccess U_SANKO
