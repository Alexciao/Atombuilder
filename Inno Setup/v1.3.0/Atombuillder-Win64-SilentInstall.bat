@echo off
powershell -Command "Invoke-WebRequest https://github.com/Alexciao/Atombuilder/releases/download/v1.3.0/Atombuilder-Win64-Setup.exe -OutFile atombuilder.exe"
echo Installing...
atombuilder.exe /VERYSILENT
echo Finished
del atombuilder.exe