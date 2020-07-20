set H_NAME=localhost
set U_NAME=sa
set P_NAME=sa
set PATH_SQL=.\
set PATH_DB=D:\TYP\Archalive1\DB

rem [DBƒtƒHƒ‹ƒ_‚ª‘¶İ‚µ‚È‚¯‚ê‚Îì¬]
if not exist %PATH_DB% mkdir %PATH_DB%

osql -S %H_NAME% -U %U_NAME% -P %P_NAME% < %PATH_SQL%\CreateDataBase.sql

pause
