#AutoIt3Wrapper_Icon=as.ico                      ;Filename of the Ico file to use
#AutoIt3Wrapper_OutFile=Starter.exe                        ;Target exe/a3x filename.
#AutoIt3Wrapper_OutFile_Type=exe                   ;a3x=small AutoIt3 file;  exe=Standalone executable (Default)
#AutoIt3Wrapper_OutFile_X64=Starter64.exe                   ;Target exe filename for X64 compile.
#AutoIt3Wrapper_Compression=4                    ;Compression parameter 0-4  0=Low 2=normal 4=High. Default=2
#AutoIt3Wrapper_UseUpx=Y 						;(Y/N) Compress output program.  Default=Y

TraySetToolTip("ApplicationStarter")

; catch parameter (i.e. for another config.ini)
If($CmdLine[0] > 0) Then
    $OtherInis = StringSplit($CmdLine[1],"=");
EndIf
If($CmdLine[0] > 0 AND $OtherInis[1] = "config") Then
    ; check if defined file exists
    $IsConfigThere = FileExists(@ScriptDir & "\" & $OtherInis[2]);
    If $IsConfigThere Then
        ; Get settings
        $AppPath = IniRead(@ScriptDir & "\" & $OtherInis[2], "Application", "AppPath", "")
        $AppParams = IniRead(@ScriptDir & "\" &  $OtherInis[2], "Application", "Parameter", "")
        $Splash = IniRead(@ScriptDir & "\" &  $OtherInis[2], "Application", "Splash", "")
        $SplashText = IniRead(@ScriptDir & "\" &  $OtherInis[2], "Application", "SplashText", "")
        $SplashTime = IniRead(@ScriptDir & "\" &  $OtherInis[2], "Application", "SplashTime", "")
        $SplashWidth = IniRead(@ScriptDir & "\" &  $OtherInis[2], "Application", "SplashWidth", "")
        $SplashHeight = IniRead(@ScriptDir & "\" &  $OtherInis[2], "Application", "SplashHeight", "")

    Else
        Error("Error","Alternate config not found!");
        Exit
    EndIf
Else
    ; Get settings
    $AppPath = IniRead(@ScriptDir & "\settings.ini", "Application", "AppPath", "")
    $AppParams = IniRead(@ScriptDir & "\settings.ini", "Application", "Parameter", "")
    $Splash = IniRead(@ScriptDir & "\settings.ini", "Application", "Splash", "")
    $SplashText = IniRead(@ScriptDir & "\settings.ini", "Application", "SplashText", "")
    $SplashTime = IniRead(@ScriptDir & "\settings.ini", "Application", "SplashTime", "")
    $SplashWidth = IniRead(@ScriptDir & "\settings.ini", "Application", "SplashWidth", "")
    $SplashHeight = IniRead(@ScriptDir & "\settings.ini", "Application", "SplashHeight", "")
EndIf

; check if default file exists
$IsFileThere = FileExists(@ScriptDir & "\" & $AppPath);

; check if application path has been set or if the configured application exists
If ($AppPath = '') Then
    Error("Error","No Application configured!");
    Exit
ElseIf ($IsFileThere = 0) Then
    Error("Error","Configured Application does not exist!");
    Exit
Else
    ; show splash if set and run application
    Splash()
    Run(@ScriptDir & "\" & $AppPath & $AppParams);
EndIf


; splash text function
Func Splash()
    If ($Splash = true) Then
        SplashTextOn('', $SplashText, $SplashWidth, $SplashHeight, -1, -1, 1, "", 14)
        Sleep($SplashTime)
        SplashOff()
    EndIf
EndFunc

; output error function
Func Error($title,$message)
    MsgBox(16,$title,$message);
EndFunc