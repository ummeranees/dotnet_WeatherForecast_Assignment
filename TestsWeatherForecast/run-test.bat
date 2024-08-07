rmdir /s /q %~dp0.coverage\
 
del /S /Q %~dp0.coverage-report\*
 
dotnet test --collect:"XPlat Code Coverage" --results-directory:"./.coverage" 
 
reportgenerator "-reports:.coverage/**/*.cobertura.xml" "-targetdir:.coverage-report/" "-reporttypes:HTML;"
 
start .coverage-report\index.html
 
pause