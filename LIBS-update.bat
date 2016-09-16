:BuildEnvironment
	@echo off
	pushd "%~dp0"

:Paths
	set SAR="release\sar.exe"

	%SAR% -f.rd ".\Savvy\Http\Views\assets"
	%SAR% -bower
	%SAR% -f.c "libs\*.js" "Savvy\Http\Views\assets"
	%SAR% -f.c "libs\*.map" "Savvy\Http\Views\Assets"
	%SAR% -f.c "libs\*.css" "Savvy\Http\Views\Assets"
	%SAR% -f.c "libs\*.gzip" "Savvy\Http\Views\Assets"
	%SAR% -f.c "libs\*.eot" "Savvy\Http\Views\Assets"
	%SAR% -f.c "libs\*.svg" "Savvy\Http\Views\Assets"
	%SAR% -f.c "libs\*.ttf" "Savvy\Http\Views\Assets"
	%SAR% -f.c "libs\*.woff" "Savvy\Http\Views\Assets"
	%SAR% -f.c "libs\*.woff2" "Savvy\Http\Views\Assets"
	