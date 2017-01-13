@echo off
:: -------------------------------------------------
:: GameCanvas for Unity [Android: Debug Build]
:: 
:: Copyright (c) 2015-2016 Seibe TAKAHASHI
:: This software is released under the MIT License.
:: http://opensource.org/licenses/mit-license.php
:: -------------------------------------------------

call %~dp0Config.bat
pushd %PROJECT_DIR%

echo �r���h���J�n���܂�

%UNITY_EXE% -batchmode -quit -logFile "Build\Build.log" -projectPath "%PROJECT_DIR%" -executeMethod GameCanvas.Editor.Builder.BuildApk

if %errorlevel% == 1 (
    echo �r���h�Ɏ��s���܂���
    pause
) else (
    echo �r���h�ɐ������܂���
    start "" "%PROJECT_DIR%Build\"
)
popd

exit /b 0
