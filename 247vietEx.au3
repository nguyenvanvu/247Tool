#cs ----------------------------------------------------------------------------

 AutoIt Version: 3.3.14.2
 Author:         myName

 Script Function:
	Template AutoIt script.

#ce ----------------------------------------------------------------------------

; Script Start - Add your code below here
#include <Array.au3>
#include <Misc.au3>
Local $hDLL = DllOpen("user32.dll")

Global $hwndActive
Opt("MouseCoordMode", 0)

While 1
     If _IsPressed("01", $hDLL) Then
		 $hwndActive = WinGetHandle("[ACTIVE]")
		 $titleActive = WinGetTitle("[ACTIVE]")
		 $jPos = MouseGetPos()

		 If $titleActive = "12BET - Google Chrome" Then
			Local $aList = WinList("12BET - Google Chrome")
			For $i = 1 To $aList[0][0]
			   If $aList[$i][0] <> "" And BitAND(WinGetState($aList[$i][1]), 2) And $hwndActive <> $aList[$i][1] Then
			   ControlClick($aList[$i][1] , "", "", "Left", 1,  $jPos[0] -  ,  $jPos[1])
			   ; MsgBox($MB_SYSTEMMODAL, "", "Title: " & $aList[$i][0] & @CRLF & "Handle: " & $aList[$i][1] &  @CRLF & "Mouse :" &  $jPos[0] & "," & $jPos[1])
			   EndIf
			Next
		 EndIf
		Sleep(50)
	  EndIf
   Sleep(100)
WEnd




Func Example()
    ; Retrieve a list of window handles using a regular expression. The regular expression looks for titles that contain the word SciTE or Internet Explorer.
    Local $aList = WinList("[REGEXPTITLE:(?i)(.*12BET - Google Chrome.*)]")
	 For $i = 1 To $aList[0][0]
        If $aList[$i][0] <> "" And BitAND(WinGetState($aList[$i][1]), 2) Then

            MsgBox($MB_SYSTEMMODAL, "", "Title: " & $aList[$i][0] & @CRLF & "Handle: " & $aList[$i][1])
        EndIf
	 Next

    _ArrayDisplay($aList)
EndFunc   ;==>Example
