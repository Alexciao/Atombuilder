@echo off
powershell -Command "Invoke-WebRequest https://github.com/Alexciao/Atombuilder/releases/download/v1.3.0/Atombuilder-Win64-Setup.exe -OutFile atombuilder.exe"
atombuilder.exe /silent
del atombuilder.exe