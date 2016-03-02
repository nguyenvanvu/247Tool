#include <GuiMenu.au3>

Run("Notepad")
WinWait("Untitled - Notepad")

$handle = WinGetHandle("Untitled - Notepad")
ConsoleWrite('+ Window Handle: ' & $handle & @CRLF)

DisableButton($handle, $SC_CLOSE)
;~ EnableButton($handle, $SC_CLOSE)

DisableButton($handle, $SC_MAXIMIZE)
DisableButton($handle, $SC_RESTORE)
DisableButton($handle, $SC_MOVE)

Func DisableButton($hWnd, $iButton)
	$hSysMenu = _GUICtrlMenu_GetSystemMenu($hWnd, 0)
	_GUICtrlMenu_RemoveMenu($hSysMenu, $iButton, False)
	_GUICtrlMenu_DrawMenuBar($hWnd)

EndFunc

Func EnableButton($hWnd, $iButton)
	$hSysMenu = _GUICtrlMenu_GetSystemMenu($hWnd, 1)
	_GUICtrlMenu_RemoveMenu($hSysMenu, $iButton, False)
	_GUICtrlMenu_DrawMenuBar($hWnd)
EndFunc