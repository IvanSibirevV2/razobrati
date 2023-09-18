cls
echo Speed Stapler
@set assembly=%date% %time% %username%
::@set assembly=Assembled in %date% %time% by %username%
::@call "EchoColor.BAT" 96 "%assembly%" 
@set assembly=%assembly::=,%
@set assembly=%assembly: =_%
@set assembly=%assembly:.=,%
@set assembly=%assembly:,=,%
::@set assembly= AssembledIn"
@call "EchoColor.BAT" 97 "%assembly%" 
@set FileWrite="%assembly%.html"
::---------------------------------------------------------------------------------------------------------------------
@set FileRead="bin\Lib_BootStrap.htm"
for /f "usebackq tokens=*" %%a in (%FileRead%) do (echo %%~a >> %FileWrite%)
echo %FileRead%

@set FileRead="bin\Form_DataInput.htm"
for /f "usebackq tokens=*" %%a in (%FileRead%) do (echo %%~a >> %FileWrite%)
echo %FileRead%

@set FileRead="bin\Action_DataInput5-6,onclick.htm"
for /f "usebackq tokens=*" %%a in (%FileRead%) do (echo %%~a >> %FileWrite%)
echo %FileRead%


@set FileRead="bin\Fun_ConvertToNumber.htm"
for /f "usebackq tokens=*" %%a in (%FileRead%) do (echo %%~a >> %FileWrite%)
echo %FileRead%

@set FileRead="bin\Unit_List.htm"
for /f "usebackq tokens=*" %%a in (%FileRead%) do (echo %%~a >> %FileWrite%)
echo %FileRead%

@set FileRead="bin\Fun_Displayer.htm"
for /f "usebackq tokens=*" %%a in (%FileRead%) do (echo %%~a >> %FileWrite%)
echo %FileRead%

@set FileRead="bin\Unit_DataConvert.htm"
for /f "usebackq tokens=*" %%a in (%FileRead%) do (echo %%~a >> %FileWrite%)
echo %FileRead%

@set FileRead="bin\Action_DataInput4,onclick.htm"
for /f "usebackq tokens=*" %%a in (%FileRead%) do (echo %%~a >> %FileWrite%)
echo %FileRead%

@set FileRead="bin\Unit_CC_m2.htm"
for /f "usebackq tokens=*" %%a in (%FileRead%) do (echo %%~a >> %FileWrite%)
echo %FileRead%

@set FileRead="bin\Form_DataOutput.htm"
for /f "usebackq tokens=*" %%a in (%FileRead%) do (echo %%~a >> %FileWrite%)
echo %FileRead%

@set FileRead="bin\Action_DataInput1,onclick.htm"
for /f "usebackq tokens=*" %%a in (%FileRead%) do (echo %%~a >> %FileWrite%)
echo %FileRead%

@set FileRead="bin\Action_AutoStart.htm"
for /f "usebackq tokens=*" %%a in (%FileRead%) do (echo %%~a >> %FileWrite%)
echo %FileRead%

::TIMEOUT /T 2