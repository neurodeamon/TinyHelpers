Global $unlock, $lock, $locking, $waiting, $searching, $found, $abort, $BDE_Windowname, $BDE_Textstring
_Language();

Func _Language()
Select
    Case StringInStr("0409 0809 0c09 1009 1409 1809 1c09 2009 2409 2809 2c09 3009 3409", @OSLang)
        ; English
		$unlock = "Unlock all Bitlocker drives";
		$lock = "Lock all Bitlocker drives";
		$locking = "Locking ";
		$waiting = "Waiting for user interaction...";
		$searching = "Searching fixed drives...";
		$found = "Found possible Bitlocker drive, trying to unlock ";
		$abort = "Aborting ... no password entered!";
		$BDE_Windowname = "BitLocker Drive Encryption";
		$BDE_Textstring = "Type your password to unlock this drive";
        $handleError = "Could not find window...";
    Case StringInStr("0407 0807 0c07 1007 1407", @OSLang)
        ; German
		$unlock = "Entsperre Bitlocker Laufwerke";
		$lock = "Sperre Bitlocker Laufwerke";
		$locking = "Sperre ";
		$waiting = "Warte auf Benutzereingabe...";
		$searching = "Suche Festplatten...";
		$found = "Mögliches Bitlockerlaufwerk gefunden, versuche zu entsperren: ";
		$abort = "Abbruch ... Kein Passwort eingegeben";
		$BDE_Windowname = "BitLocker-Laufwerkverschlüsselung";
		$BDE_Textstring = "Geben Sie zum Entsperren des Laufwerks Ihr Kennwort ein.";
        $handleError = "Konnte Fenster nicht finden...";
    Case Else
        ; Language not supported (yet), reverting to default
		$unlock = "Unlock all Bitlocker drives";
		$lock = "Lock all Bitlocker drives";
		$locking = "Locking ";
		$waiting = "Waiting for user interaction...";
		$searching = "Searching fixed drives...";
		$found = "Found possible Bitlocker drive, trying to unlock ";
		$abort = "Aborting ... no password entered!";
		$BDE_Windowname = "BitLocker Drive Encryption";
		$BDE_Textstring = "Type your password to unlock this drive";
        $handleError = "Could not find window...";
    EndSelect
EndFunc