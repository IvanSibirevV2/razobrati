@Echo Off
SetLocal EnableDelayedExpansion
:: Inquisitor, 2013
:: Использованы следующие материалы:
:: Быстрое получение длины строки: CyberMuesli, http://forum.oszone.net/showpost.php?p=2164186
:: Получение 0x08: jeb, http://www.dostips.com/forum/viewtopic.php?p=6827#p6827
:: Идея передачи нескольких параметров: Diskretor, http://forum.oszone.net/post-2201046-7.html

:: И всё это в свою очередь позаимствовано из http://forum.oszone.net/post-2214015-8.html

::Call :EchoColor %1 %2
::for /l %%i in (1,1,0xf) do  @Call :EchoColor %%i * 0xf "%%i ----------------------" 
::for /l %%i in (1,1,0xf) do  @Call :EchoColor %%i "%%i ----------------------" 

::EchoColor [%1=Color %2="Text" %3=/n (CRLF, optional)] (Support multiple arguments at once)
::@call "CyberBat/EchoColor.BAT" %TextColor% "  * Узнать версию Rybi          00*" 
:: Вывод цветного текста. Ограничения - не выводится восклицательный знак, остальные спецсимволы разрешены.
:: Работа с более, чем одним набором параметров
If Not Defined multiple If Not "%~4"=="" (
	Call :EchoWrapper %*
	Set multiple=
	Exit /B
)
SetLocal EnableDelayedExpansion
If Not Defined BkSpace Call :EchoColorInit
:: Экранирование входящего текста от обратных и прямых слэшей, чистка некоторых символов.
Set "$Text=%~2"
Set "$Text=.%BkSpace%!$Text:\=.%BkSpace%\..\%BkSpace%%BkSpace%%BkSpace%!"
Set "$Text=!$Text:/=.%BkSpace%/..\%BkSpace%%BkSpace%%BkSpace%!"
Set "$Text=!$Text:"=\"!"
Set "$Text=!$Text:^^=^!"
:: Если XP, выводим обычный текст.
If "%isXP%"=="true" (
	<nul Set /P "=.!BkSpace!%~2"
	GoTo :unsupported
)
:: Подаем текст на stdout, не создавая временных файлов и используя трюк с путём.
:: В случае неудачи (проблемный\слишком длинный путь?) выводим текст as is, без расцветки.
:: Если результирующая длина строки (плюс уже имеющиеся там символы) превышает ширину консоли, то вывод тоже будет неудачным. Но получить текущую позицию каретки программно нельзя.
PushD "%~dp0"
2>nul FindStr /R /P /A:%~1 "^-" "%$Text%\..\%~nx0" nul
If !ErrorLevel! GTR 0 <nul Set /P "=.!BkSpace!%~2"
PopD
:: Убираем путь, имя файла и дефис с помощью рассчитаного ранее количества символов.
For /L %%A In (1,1,!BkSpaces!) Do <nul Set /P "=!BkSpace!"

:unsupported
:: Выводим CRLF, если указан третий аргумент.
If /I "%~3"=="/n" Echo.
EndLocal
GoTo :EOF

:EchoWrapper
:: Обработка аргументов поочерёдно
SetLocal EnableDelayedExpansion
:NextArg
Set multiple=true
:: Ох уж это удвоение "^" при передаче аргументов...
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
:: Отрабатывающая при первом запуске родительской функции инициализация нужных переменных
:: Важно! Под XP, в силу реализации тамошнего findstr, 0x08 в путях не работает, заменяясь на точку. Отключаем цветной вывод для XP.
For /F "tokens=2 delims=[]" %%A In ('Ver') Do (For /F "tokens=2,3 delims=. " %%B In ("%%A") Do (If "%%B"=="5" Set isXP=true))
:: Получаем комбинацию "0x08 0x20 0x08" с помощью prompt
For /F "tokens=1 delims=#" %%A In ('"Prompt #$H# & Echo On & For %%B In (1) Do rem"') Do Set "BkSpace=%%A"
:: Рассчитываем требуемое количество символов для подавления всего, кроме выводимого текста
Set ScriptFileName=%~nx0
::Call :StrLen ScriptFileName
Call :StrLen qwe
Set /A "BkSpaces=!strLen!+6"
GoTo :EOF

:StrLen [%1=VarName (not VALUE), ret !strLen!]
:: Получение длины строки
Set StrLen.S=A!%~1!
Set StrLen=0
For /L %%P In (12,-1,0) Do (
	Set /A "StrLen|=1<<%%P"
	For %%I In (!StrLen!) Do If "!StrLen.S:~%%I,1!"=="" Set /A "StrLen&=~1<<%%P"
)
GoTo :EOF

:: Эта строка должна быть последней и не оканчиваться на CRLF.
-
