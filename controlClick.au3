#include <Array.au3>
#include <WinAPI.au3>
#include <Misc.au3>
#include <Constants.au3>
#include <WindowsConstants.au3>
#include <MsgBoxConstants.au3>
Local $hDLL = DllOpen("user32.dll")
Opt("MouseCoordMode",2)
$hHandle = WinGetHandle("12BET - Google Chrome")
ConsoleWrite("[Debug] log: " & $hHandle & @CRLF)

ControlClick( $hHandle, "", "Chrome_RenderWidgetHostHWND1", "Left", 1,  657 ,  372)

