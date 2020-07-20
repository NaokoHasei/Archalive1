@set SERVER_NAME=localhost
@set DB_NAME=DB_Archalive1
@set U_NAME=U_Archalive1
@set P_NAME=Archalive1
@set FILEPATH=.\

echo off
echo ************************************************************
echo                     テーブルを削除します
echo ************************************************************
pause
cd /d %~d0%~p0
for %%P in (*.sql) do (
  echo %%P
  sqlcmd -d %DB_NAME% -S %SERVER_NAME% -U %U_NAME% -P %P_NAME% -Q "drop table %%~nP "
)

echo off
echo ************************************************************
echo                     テーブルを作成します
echo ************************************************************
pause
for %%P in (*.sql) do (
  echo %%P
  sqlcmd -d %DB_NAME% -U %U_NAME% -P %P_NAME% -S %SERVER_NAME% -i %%P
)

pause
