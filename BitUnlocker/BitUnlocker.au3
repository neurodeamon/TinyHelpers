#requireadmin   ; We want UAC to ask if it is okay to have higher rights

; AutoIt3Wrapper Code (automated compilation of AutoIt code)
#Region AutoIt3Wrapper directives section
#AutoIt3Wrapper_Autoit3Dir=D:\Programme\Autoit
#AutoIt3Wrapper_Aut2exe=D:\Programme\Autoit\Aut2Exe\Aut2exe.exe
#AutoIt3Wrapper_Icon=BitUnlocker.ico                      ;Filename of the Ico file to use
#AutoIt3Wrapper_OutFile=BitUnlocker.exe                        ;Target exe/a3x filename.
#AutoIt3Wrapper_OutFile_X64=BitUnlocker_64.exe                   ;Target exe filename for X64 compile.
#AutoIt3Wrapper_OutFile_Type=exe                   ;a3x=small AutoIt3 file;  exe=Standalone executable (Default)
#AutoIt3Wrapper_Compile_both=Y
#AutoIt3Wrapper_Compression=4                    ;Compression parameter 0-4  0=Low 2=normal 4=High. Default=2
#AutoIt3Wrapper_UseUpx=Y 						;(Y/N) Compress output program.  Default=Y
#AutoIt3Wrapper_Res_Comment=www.copyforfree.de                    ;Comment field
#AutoIt3Wrapper_Res_Description=BitUnlocker                ;Description field
#AutoIt3Wrapper_Res_Fileversion=1.0.0.8
#AutoIt3Wrapper_Res_FileVersion_AutoIncrement=P     ;(Y/N/P) AutoIncrement FileVersion After Aut2EXE is finished. default=N (P=Prompt, Will ask at Compilation time if you want to increase the versionnumber)
#AutoIt3Wrapper_Res_Field=Productname|BitUnlocker
;#AutoIt3Wrapper_Res_Productversion=1             ;Product Version. Default is the AutoIt3 version used.
#AutoIt3Wrapper_Res_Language=1031                   ;Resource Language code . default 2057=English (United Kingdom)
#AutoIt3Wrapper_Res_LegalCopyright=www.copyforfree.de             ;Copyright field
#AutoIt3Wrapper_res_requestedExecutionLevel=None    ;None, asInvoker, highestAvailable or requireAdministrator   (default=None)
#AutoIt3Wrapper_res_Compatibility=None              ;Vista,Windows7        Both allowed separated by a comma     (default=None)
#AutoIt3Wrapper_Res_SaveSource=N                 ;(Y/N) Save a copy of the Scriptsource in the EXE resources. default=N
#EndRegion AutoIt3Wrapper directives section


#include <ButtonConstants.au3> ; default inclusions
#include <EditConstants.au3>
#include <GUIConstantsEx.au3>
#include <GuiStatusBar.au3>
#include <WindowsConstants.au3>
#include <BitUnlocker_i8n.au3> ; our languagefile

Opt("GUIOnEventMode", 1) ; set autoit eventmode

; Set some default variables
Dim $PASS = "";
Dim $MANAGEBDE = "";
Dim $UNLOCKRBDE = "";

; We're starting our GUI magic
$BDU = GUICreate("BitUnlocker", 401, 101, 195, 127)
; Set button events
GUISetOnEvent($GUI_EVENT_CLOSE, "BDUClose")
GUISetOnEvent($GUI_EVENT_MINIMIZE, "BDUMinimize")
GUISetOnEvent($GUI_EVENT_MAXIMIZE, "BDUMaximize")
GUISetOnEvent($GUI_EVENT_RESTORE, "BDURestore")
; Create GUI
$BitLockerPass = GUICtrlCreateInput("", 8, 8, 380, 21, BitOR($ES_PASSWORD, $ES_AUTOHSCROLL))
$Unlock = GUICtrlCreateButton($Unlock, 8, 32, 180, 33, 0)
GUICtrlSetOnEvent($Unlock, "UnlockClick")
$StatusBar1 = _GUICtrlStatusBar_Create($BDU)
$Lock = GUICtrlCreateButton($Lock, 208, 32, 180, 33, 0)
GUICtrlSetOnEvent($Lock, "LockClick")
GUISetState(@SW_SHOW)
_GUICtrlStatusBar_SetText($StatusBar1, $waiting)

; set variables with paths to windows locking and unlocking applications
$MANAGEBDE = @SystemDir & "\manage-bde.exe";
$UNLOCKBDE = @SystemDir & "\BdeUnlockWizard.exe";

While 1
	Sleep(1000)
WEnd

Func BDUClose()
	Exit
EndFunc   ;==>BDUClose
Func BDUMaximize()

EndFunc   ;==>BDUMaximize
Func BDUMinimize()

EndFunc   ;==>BDUMinimize
Func BDURestore()

EndFunc   ;==>BDURestore
Func LockClick() ; lock drives
	_GUICtrlStatusBar_SetText($StatusBar1, "")
	$drives = DriveGetDrive("fixed") ; get list of fixed hard drives
	If NOT @error Then                   ; if there's no issue then go through list of drives
		For $i = 1 to $drives[0]
			_GUICtrlStatusBar_SetText($StatusBar1, $locking & $drives[$i])
			Dim $Lockdrive = ShellExecuteWait($MANAGEBDE, "-lock " & $drives[$i])            ; lock drive
			If $Lockdrive = 0 Then ShellExecuteWait($MANAGEBDE, "-lock " & $drives[$i])      ; due to an unknown reason first attempt sometimes fails, so do it a second time if it fails the first time
		Next
	EndIf
	_GUICtrlStatusBar_SetText($StatusBar1, $waiting)
EndFunc   ;==>LockClick
Func UnlockClick()
	If StringLen(GUICtrlRead($BitLockerPass)) > 0 Then
		$PASS = GUICtrlRead($BitLockerPass)          ; read the password from our input field
		_GUICtrlStatusBar_SetText($StatusBar1, "")
		_GUICtrlStatusBar_SetText($StatusBar1, $searching)
		$drives = DriveGetDrive("fixed")      ; get list of fixed hard drives
		If NOT @error Then                ; if there's no issue then go through list of drives
			For $i = 1 to $drives[0]
				$driveformat = DriveGetFileSystem($drives[$i])         ; sadly the locked drive format is 'unknown'
				If $driveformat == "" Then                             ; so let's try to unlock it if format is empty (because unknown)
					_GUICtrlStatusBar_SetText($StatusBar1, $found & $drives[$i]);
					ShellExecute($UNLOCKBDE, $drives[$i]);              ; start bitlocker unlock window
					ProcessWait("BdeUnlockWizard.exe");                 ; wait until the process is up and running
					Sleep(500)                                          ; wait some more time (just to be sure)
					EnterPass($PASS);                                   ; call function to enter password
					ProcessWaitClose("BdeUnlockWizard.exe");            ; close the M$ unlock wizard
				EndIF
			Next
		EndIf
		_GUICtrlStatusBar_SetText($StatusBar1, $waiting)
	Else
		_GUICtrlStatusBar_SetText($StatusBar1, $abort)
	EndIf
EndFunc   ;==>UnlockClick
Func EnterPass($PASS)
	$handle = WinGetHandle($BDE_Windowname, $BDE_Textstring);             ; get the window handle of the unlock wizard
	If @error Then
		_GUICtrlStatusBar_SetText($StatusBar1, $handleError);             ; doh! something went wrong, we didn't find the window
	Else
		; Send some text directly to this window's edit control
		WinActivate($handle);
		ControlSend($handle, "", "Edit1", $PASS);
		ControlSend($handle, "", "Button2", "{ENTER}");
	EndIf
EndFunc   ;==>EnterPass
