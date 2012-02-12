;;; based on this idea:
;;; http://www.instructables.com/id/%22Drop-Down%22,-Quake-style-command-prompt-for-Window/

#SingleInstance FORCE ; limit to one instance
#Persistent ; will run until quit by user

;; tooltip on run/restart
TrayTip Notice, "QuakeConsole2 running", 10, 1

;; Tray Menu
Menu, tray, NoStandard
Menu, tray, add, QC2 by neurodeamon, MenuHandler
Menu, tray, Disable, QC2 by neurodeamon
Menu, tray, add
Menu, tray, add, Quit, MenuHandler
return

;; If click on tray menu Quit, Close Console.exe Process and exit script
MenuHandler:
If (%A_ThisMenuItem% = Quit) {
    Process, Close, Console.exe
    ExitApp
}
return


; Launch console if needed & hide/show on STRG+^
^^::
DetectHiddenWindows, on
IfWinExist ahk_class Console_2_Main
{
    IfWinActive ahk_class Console_2_Main
    {
        WinHide ahk_class Console_2_Main
        WinActivate ahk_class Shell_TrayWnd
    } else {
        WinShow ahk_class Console_2_Main
        WinActivate ahk_class Console_2_Main
    }
} else {
    Run %A_ScriptDir%\Console.exe -c "%A_ScriptDir%\console-tilda.xml"
}
DetectHiddenWindows, off
return

; hide console on ESCAPE keypress.
#IfWinActive ahk_class Console_2_Main
esc::
 {
   WinHide ahk_class Console_2_Main
   WinActivate ahk_class Shell_TrayWnd
 }
return