Attribute VB_Name = "Module1"
Option Explicit

'----------------------API functions declarations----------------

Public Declare Function CreatePipe Lib "kernel32" ( _
    phReadPipe As Long, _
    phWritePipe As Long, _
    lpPipeAttributes As Any, _
    ByVal nSize As Long) As Long
Public Declare Function PeekNamedPipe Lib "kernel32" ( _
    ByVal hNamedPipe As Long, lpBuffer As Any, _
    ByVal nBufferSize As Long, lpBytesRead As Long, _
    lpTotalBytesAvail As Long, lpBytesLeftThisMessage As Long) As Long
Public Declare Function ReadFile Lib "kernel32" ( _
    ByVal hFile As Long, _
    ByVal lpBuffer As String, _
    ByVal nNumberOfBytesToRead As Long, _
    lpNumberOfBytesRead As Long, _
    ByVal lpOverlapped As Any) As Long
Public Declare Function WriteFile Lib "kernel32" ( _
    ByVal hFile As Long, _
    lpBuffer As Any, _
    ByVal nNumberOfBytesToWrite As Long, _
    lpNumberOfBytesWritten As Long, _
    ByVal lpOverlapped As Any) As Long
Public Declare Function CreateProcessA Lib "kernel32" (ByVal _
    lpApplicationName As Long, ByVal lpCommandLine As String, _
    lpProcessAttributes As Any, lpThreadAttributes As Any, _
    ByVal bInheritHandles As Long, ByVal dwCreationFlags As Long, _
    ByVal lpEnvironment As Long, ByVal lpCurrentDirectory As Long, _
    lpStartupInfo As Any, lpProcessInformation As Any) As Long
Public Declare Function CloseHandle Lib "kernel32" ( _
    ByVal hObject As Long) As Long
Public Declare Function TerminateProcess Lib "kernel32" ( _
                            ByVal hProcess As Long, _
                            ByVal uExitCode As Long) As Long
'---------------------type declarations-------------------

Public Type SECURITY_ATTRIBUTES
    nLength As Long
    lpSecurityDescriptor As Long
    bInheritHandle As Long
End Type
Public Type STARTUPINFO
    cb As Long
    lpReserved As Long
    lpDesktop As Long
    lpTitle As Long
    dwX As Long
    dwY As Long
    dwXSize As Long
    dwYSize As Long
    dwXCountChars As Long
    dwYCountChars As Long
    dwFillAttribute As Long
    dwFlags As Long
    wShowWindow As Integer
    cbReserved2 As Integer
    lpReserved2 As Long
    hStdInput As Long
    hStdOutput As Long
    hStdError As Long
End Type
Public Type PROCESS_INFORMATION
    hProcess As Long
    hThread As Long
    dwProcessId As Long
    dwThreadID As Long
End Type

'-----------------------constant declarations---------------------

Public Const NORMAL_PRIORITY_CLASS = &H20&
Public Const CREATE_NEW_PROCESS_GROUP = &H200
Public Const CREATE_NEW_CONSOLE = &H10
Public Const CTRL_BREAK_EVENT = 1
Public Const CTRL_C_EVENT = 0
Public Const STARTF_USESTDHANDLES = &H100&
Public Const STARTF_USESHOWWINDOW = &H1
Public Const SW_HIDE = 0




