@Echo Off
SetLocal EnableDelayedExpansion
:: Inquisitor, 2013
:: ������������ ��������� ���������:
:: ������� ��������� ����� ������: CyberMuesli, http://forum.oszone.net/showpost.php?p=2164186
:: ��������� 0x08: jeb, http://www.dostips.com/forum/viewtopic.php?p=6827#p6827
:: ���� �������� ���������� ����������: Diskretor, http://forum.oszone.net/post-2201046-7.html

:: � �� ��� � ���� ������� �������������� �� http://forum.oszone.net/post-2214015-8.html

::Call :EchoColor %1 %2
::for /l %%i in (1,1,0xf) do  @Call :EchoColor %%i * 0xf "%%i ----------------------" 
::for /l %%i in (1,1,0xf) do  @Call :EchoColor %%i "%%i ----------------------" 

::EchoColor [%1=Color %2="Text" %3=/n (CRLF, optional)] (Support multiple arguments at once)
::@call "CyberBat/EchoColor.BAT" %TextColor% "  * ������ ������ Rybi          00*" 
:: ����� �������� ������. ����������� - �� ��������� ��������������� ����, ��������� ����������� ���������.
:: ������ � �����, ��� ����� ������� ����������
If Not Defined multiple If Not "%~4"=="" (
	Call :EchoWrapper %*
	Set multiple=
	Exit /B
)
SetLocal EnableDelayedExpansion
If Not Defined BkSpace Call :EchoColorInit
:: ������������� ��������� ������ �� �������� � ������ ������, ������ ��������� ��������.
Set "$Text=%~2"
Set "$Text=.%BkSpace%!$Text:\=.%BkSpace%\..\%BkSpace%%BkSpace%%BkSpace%!"
Set "$Text=!$Text:/=.%BkSpace%/..\%BkSpace%%BkSpace%%BkSpace%!"
Set "$Text=!$Text:"=\"!"
Set "$Text=!$Text:^^=^!"
:: ���� XP, ������� ������� �����.
If "%isXP%"=="true" (
	<nul Set /P "=.!BkSpace!%~2"
	GoTo :unsupported
)
:: ������ ����� �� stdout, �� �������� ��������� ������ � ��������� ���� � ����.
:: � ������ ������� (����������\������� ������� ����?) ������� ����� as is, ��� ���������.
:: ���� �������������� ����� ������ (���� ��� ��������� ��� �������) ��������� ������ �������, �� ����� ���� ����� ���������. �� �������� ������� ������� ������� ���������� ������.
PushD "%~dp0"
2>nul FindStr /R /P /A:%~1 "^-" "%$Text%\..\%~nx0" nul
If !ErrorLevel! GTR 0 <nul Set /P "=.!BkSpace!%~2"
PopD
:: ������� ����, ��� ����� � ����� � ������� ������������ ����� ���������� ��������.
For /L %%A In (1,1,!BkSpaces!) Do <nul Set /P "=!BkSpace!"

:unsupported
:: ������� CRLF, ���� ������ ������ ��������.
If /I "%~3"=="/n" Echo.
EndLocal
GoTo :EOF

:EchoWrapper
:: ��������� ���������� ���������
SetLocal EnableDelayedExpansion
:NextArg
Set multiple=true
:: �� �� ��� �������� "^" ��� �������� ����������...
Set $Text=
Set $Text=%2
Set "$Text=!$Text:^^^^=^!"
If Not "%~3"=="" If /I Not "%~3"=="/n" (
	Shift&Shift
	Call :EchoColor %1 !$Text!
	GoTo :NextArg
) Else (
	Shift&Shift&Shift
	Call :EchoColor %1 !$Text! %3
	GoTo :NextArg
)
If "%~3"=="" Call :EchoColor %1 !$Text!
EndLocal
GoTo :EOF


:EchoColorInit
:: �������������� ��� ������ ������� ������������ ������� ������������� ������ ����������
:: �����! ��� XP, � ���� ���������� ��������� findstr, 0x08 � ����� �� ��������, ��������� �� �����. ��������� ������� ����� ��� XP.
For /F "tokens=2 delims=[]" %%A In ('Ver') Do (For /F "tokens=2,3 delims=. " %%B In ("%%A") Do (If "%%B"=="5" Set isXP=true))
:: �������� ���������� "0x08 0x20 0x08" � ������� prompt
For /F "tokens=1 delims=#" %%A In ('"Prompt #$H# & Echo On & For %%B In (1) Do rem"') Do Set "BkSpace=%%A"
:: ������������ ��������� ���������� �������� ��� ���������� �����, ����� ���������� ������
Set ScriptFileName=%~nx0
::Call :StrLen ScriptFileName
Call :StrLen qwe
Set /A "BkSpaces=!strLen!+6"
GoTo :EOF

:StrLen [%1=VarName (not VALUE), ret !strLen!]
:: ��������� ����� ������
Set StrLen.S=A!%~1!
Set StrLen=0
For /L %%P In (12,-1,0) Do (
	Set /A "StrLen|=1<<%%P"
	For %%I In (!StrLen!) Do If "!StrLen.S:~%%I,1!"=="" Set /A "StrLen&=~1<<%%P"
)
GoTo :EOF

:: ��� ������ ������ ���� ��������� � �� ������������ �� CRLF.
-
