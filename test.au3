#include <Array.au3>
#include <WinAPI.au3>
#include <Misc.au3>
#include <Constants.au3>
#include <WindowsConstants.au3>
#include <MsgBoxConstants.au3>
#include <AutoItConstants.au3>
Local $hDLL = DllOpen("user32.dll")
Global $hwndActive
Global $accChinh = 0
Opt("MouseCoordMode", 2)

DisableResizeWindow()


$logCount = 0;
$controlClickCount = 0;
While 1
   If _IsPressed("01", $hDLL) Then


		 Local $aList = WinList("12BET - Google Chrome")


		 $accChinh = WinGetHandle("12BET - Tai Khoan Chinh - Google Chrome")




		 $hwndActive = WinGetHandle("[ACTIVE]")
		 $titleActive = WinGetTitle("[ACTIVE]")
		 While _IsPressed("01", $hDLL)
            Sleep(250)
		 WEnd

		 If   $hwndActive == $accChinh And $accChinh <> 0 AND $aList[0][0] > 0    Then
			$logCount = $logCount + 1;
			ConsoleWrite("[Debug] Click " & $logCount & @CRLF)
			$jPos = MouseGetPos()
			;WinSetState($hwndActive, "",  @SW_DISABLE )
			$controlPos = ControlGetPos($hwndActive, "", "Chrome_RenderWidgetHostHWND1")
			$controlCoordsX = $jPos[0] -  $controlPos[0]
			$controlCoordsY = $jPos[1] -  $controlPos[1]
			;MsgBox($MB_SYSTEMMODAL, "", "Mouse :" &  $jPos[0] & "," & $jPos[1])
			;MsgBox($MB_SYSTEMMODAL, "", "ControlPos :" &  $controlPos[0] & "," & $controlPos[1])

			For $i = 1 To $aList[0][0]
			   If $aList[$i][0] <> "" And BitAND(WinGetState($aList[$i][1]), 2)  and $aList[$i][1] <> $accChinh Then
				  ControlClick( $aList[$i][1], "", "Chrome_RenderWidgetHostHWND1", "Left", 1,  $controlCoordsX ,  $controlCoordsY)
				  $controlClickCount = $controlClickCount + 1
				  ConsoleWrite("[Debug] ControlClick: " & $controlClickCount & @CRLF)
				  Sleep(100)
				  ;MsgBox($MB_SYSTEMMODAL, "", "ControlCoords :" &  $controlCoordsX & "," & $controlCoordsY)
				  ;MsgBox($MB_SYSTEMMODAL, "", "Title: " & $aList[$i][0] & @CRLF & "Handle: " & $aList[$i][1] &  @CRLF & "Mouse :" &  $jPos[0] & "," & $jPos[1])
			   EndIf
			Next
			Sleep(20)
		 EndIf
   EndIf
   Sleep(50)
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

Func DisableResizeWindow()
   Local $aList = WinList("12BET - Google Chrome")
			For $i = 1 To $aList[0][0]
			   If $aList[$i][0] <> "" And BitAND(WinGetState($aList[$i][1]), 2)  Then
				  _WinAPI_SetWindowLong($aList[$i][1], $GWL_STYLE, BitXOR(_WinAPI_GetWindowLong($aList[$i][1], $GWL_STYLE), $WS_SIZEBOX)) ; disable resize windows
			   EndIf
			Next
	 Local $accChinh = WinGetHandle("12BET - Tai Khoan Chinh - Google Chrome")
	  _WinAPI_SetWindowLong($accChinh , $GWL_STYLE, BitXOR(_WinAPI_GetWindowLong($accChinh , $GWL_STYLE), $WS_SIZEBOX)) ; disable resize windows

EndFunc
