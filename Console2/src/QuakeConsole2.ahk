#SingleInstance FORCE
#Persistent  ; Keep the script running until the user exits it.
Menu, tray, NoStandard
Menu, tray, add, neurodeamon, MenuHandler ; Creates a new menu item.
Menu, tray, Disable, neurodeamon
Menu, tray, add  ; Creates a separator line.
Menu, tray, add, Quit, MenuHandler  ; Creates a new menu item.
return

MenuHandler:
If (%A_ThisMenuItem% = Quit) {
    ExitApp
}
return

Process, Exist, %A_ScriptName%
If (ErrorLevel <> 0)
{
 TrayTip Notice, "QuakeConsole2 running", 10, 1
}


; Launch console if necessary; hide/show on Win+`
^^::
DetectHiddenWindows, on
IfWinExist ahk_class Console_2_Main
{
	IfWinActive ahk_class Console_2_Main
	  {
			WinHide ahk_class Console_2_Main
			; need to move the focus somewhere else.
			WinActivate ahk_class Shell_TrayWnd
		}
	else
	  {
	    WinShow ahk_class Console_2_Main
	    WinActivate ahk_class Console_2_Main
	  }
}
else
	Run D:\VistaProfile\Programme\Console2\Console.exe -c "%A_ScriptDir%\console-tilda.xml"
; the above assumes a shortcut in the c:\windows folder to console.exe.
; also assumes console is using the default console.xml file, or
; that the desired config file is set in the shortcut.

DetectHiddenWindows, off
return

; hide console on "esc".
#IfWinActive ahk_class Console_2_Main
esc::
 {
   WinHide ahk_class Console_2_Main
   WinActivate ahk_class Shell_TrayWnd
 }
return