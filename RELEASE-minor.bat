:Required Software
	:: Microsoft.NET v2.0						http://www.filehippo.com/download_dotnet_framework_2/
	:: Microsoft.NET v3.5						http://www.filehippo.com/download_dotnet_framework_3/
	:: TortoiseSVN (+command line tools)		http://www.filehippo.com/download_tortoisesvn/
	:: 7zip 32bit								http://www.filehippo.com/download_7zip_32/
	:: 7zip 64bit								http://www.filehippo.com/download_7-zip_64/
	:: SharpDevelop v4x							http://www.icsharpcode.net/OpenSource/SD/Download/#SharpDevelop4x

:BuildEnvironment
	@echo off
	pushd "%~dp0"
	set SOLUTION=Savvy.sln
	set REPO=https://github.com/kboronka/win-service-launcher/
	set CONFIG=Release
	set BASEPATH=%~dp0

:Paths
	set SAR="release\sar.exe"
	set ZIP="%PROGRAMFILES%\7-Zip\7zG.exe" a -tzip

	
:Build
	echo "VERSION.MAJOR.MINOR.BUILD".
	set /p VERSION="> "
	
	call UpdateExternals.bat
	
	svn cleanup
	svn update
	svn revert -R .
	
	%SAR% -assy.ver \Savvy\AssemblyInfo.* %VERSION%
	%SAR% -f.del Savvy\bin\%CONFIG%\*.* /q /svn
	
	echo building binaries
	%SAR% -b.net 3.5 %SOLUTION% /p:Configuration=%CONFIG% /p:Platform=\"x86\"
	if errorlevel 1 goto BuildFailed
	
	svn cleanup
	svn revert -R .
	
:BuildComplete
	svn revert
	copy Savvy\bin\%CONFIG%\*.exe release\*.exe
	copy Savvy\bin\%CONFIG%\*.dll release\*.dll	
	copy Savvy\bin\%CONFIG%\*.pdb release\*.pdb
	copy LICENSE release\LICENSE
	
	svn commit -m "new binaries v%VERSION%"
	%ZIP% "Savvy %VERSION%.zip" .\release\*.*
	svn update

	%SAR% -f.bsd \Savvy\*.cs "Kevin Boronka"
	%SAR% -f.bsd \Savvy\*.cs "Kevin Boronka"
	
	echo build completed
	popd
	exit /b 0

:BuildFailed
	echo build failed
	pause
	popd
	exit /b 1	
