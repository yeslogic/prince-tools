VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Prince"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Private princePath As String
Private styleSheets As String
Private optionHTML As Boolean
Private optionLog As String
Private optionBaseURL As String
Private optionXInclude As Boolean
Private optionEmbedFonts As Boolean
Private optionCompress As Boolean
Private optionEncrypt As Boolean
Private encryptInfo As String

Public Event Message(msgType As String, msgLocation As String, msg As String)
Private Sub Class_Initialize()
    princePath = ""
    styleSheets = ""
    optionHTML = False
    optionLog = ""
    optionBaseURL = ""
    optionXInclude = True
    optionEmbedFonts = True
    optionCompress = True
    optionEncrypt = False
    encryptInfo = ""
End Sub
Private Sub Class_Terminate()
   On Error Resume Next
End Sub
Public Function Convert(ByVal xmlPath As String, _
                        Optional ByVal pdfPath As String = "") As Long
    Dim inputFile As String
    Dim outputFile As String
    Dim pathAndArguments As String
    Dim outputMessage As String
    
    pathAndArguments = princePath + " --server " + styleSheets
    
    If optionEncrypt Then
        pathAndArguments = pathAndArguments + encryptInfo
    End If
    
    If optionHTML Then
        pathAndArguments = pathAndArguments + "-i html "
    End If
    
    If optionLog <> "" Then
        pathAndArguments = pathAndArguments + "--log=""" + optionLog + """ "
    End If
    
    If optionBaseURL <> "" Then
        pathAndArguments = pathAndArguments + "--baseurl=""" + optionBaseURL + """ "
    End If
    
    If Not optionXInclude Then
        pathAndArguments = pathAndArguments + "--no-xinclude "
    End If
    
    If Not optionEmbedFonts Then
        pathAndArguments = pathAndArguments + "--no-embed-fonts "
    End If
    
    If Not optionCompress Then
        pathAndArguments = pathAndArguments + "--no-compress "
    End If
    
    inputFile = """" + xmlPath + """"
    
    If pdfPath = "" Then
        pathAndArguments = pathAndArguments + inputFile
    Else
        outputFile = """" + pdfPath + """"
        pathAndArguments = pathAndArguments + inputFile + " " + outputFile
    End If
    
    outputMessage = ReadOutputMessage(pathAndArguments)

    If outputMessage = "success" Then
        Convert = 1
    ElseIf outputMessage = "failure" Then
        Convert = 0
    Else
        Convert = 0
    End If

End Function
Private Function ReadOutputMessage(ByVal fName As String) As String
    Dim retVal As Long
    Dim ourReadPipe As Long
    Dim appReadPipe As Long
    Dim appWritePipe As Long
    Dim sa As SECURITY_ATTRIBUTES
    Dim startInfo As STARTUPINFO
    Dim procInfo As PROCESS_INFORMATION
    
    Dim tmpRead As String * 256
    Dim readData As String
    Dim bytesRead As Long
    Dim totalBytesAvail As Long
    Dim bytesLeft As Long
    Dim retV As Long
    Dim prgrsData As String
    Dim dataRead As String
    Dim tmpData As String
    Dim lastLineIncomplete As String
    Dim fin As String
  
    sa.bInheritHandle = True
    sa.nLength = Len(sa)

    'create the pipe for reading from StdOutput of the prince.exe process
    
    retVal = CreatePipe(ourReadPipe, appWritePipe, sa, 0)
    If retVal = 0 Then
        'MsgBox "Could not create pipe!", vbCritical
        Exit Function
    End If
    
    'create the pipe for StdInput of the prince.exe process to stop it complaining.
    Dim DummyWritePipe As Long
    retVal = CreatePipe(appReadPipe, DummyWritePipe, sa, 0)
    If retVal = 0 Then
        'MsgBox "Could not create pipe for prince!", vbCritical
        Exit Function
    End If
       
    startInfo.cb = Len(startInfo)
    startInfo.dwFlags = STARTF_USESTDHANDLES Or STARTF_USESHOWWINDOW
    startInfo.wShowWindow = SW_HIDE
    
    ' connect the standard output and standard error pipes to the write
    ' handles of the pipe
    startInfo.hStdInput = appReadPipe
    startInfo.hStdOutput = appWritePipe
    startInfo.hStdError = appWritePipe
    
    'create the process
    retVal = CreateProcessA(0&, fName, _
                        sa, sa, True, NORMAL_PRIORITY_CLASS, _
                        0&, 0&, startInfo, procInfo)
   
    If retVal = 0 Then
        'MsgBox "Could not start the prince.exe program: " + fName, vbCritical
        'MsgBox "CreateProcessA failed. Error: " & Err.LastDllError, vbCritical
        Exit Function
    End If

    'ProcHandle = procInfo.hProcess
    
    'close the write handle from the calling application.
    '(the called application still has the write handle)
    CloseHandle appWritePipe
    CloseHandle appReadPipe
    CloseHandle DummyWritePipe
    
    fin = ""
    tmpData = ""
    Do
        retV = PeekNamedPipe(ourReadPipe, 0&, 0&, 0&, totalBytesAvail, bytesLeft)
        If retV = 0 Then
            'MsgBox "retV = 0"
            'MsgBox "PeekNamedPipe failed. Error: " & Err.LastDllError, vbCritical
            Exit Do
        End If
        
        If totalBytesAvail > 0 Then
            retVal = ReadFile(ourReadPipe, tmpRead, 256, bytesRead, 0&)
        
            dataRead = Left(tmpRead, bytesRead)
            
            dataRead = tmpData + dataRead
            If AtLeastOneLine(ByVal dataRead) Then
                lastLineIncomplete = AnalyseData(dataRead, fin)
                If fin = "" Then
                    tmpData = lastLineIncomplete
                ElseIf fin = "success" Or fin = "failure" Then
                    Exit Do
                Else
                    'MsgBox "unknown Fin value!", vbCritical
                    Exit Function
                End If
            Else
                tmpData = dataRead
            End If
    
        End If
        
        DoEvents    ' to keep the calling application responsive.
        'If Not ContinueConverting Then
            'Exit Do
        'End If
  
    Loop While fin = "" And retVal > 0
    
    CloseHandle ourReadPipe
    
    ReadOutputMessage = fin
  
End Function
Private Function AtLeastOneLine(ByVal data As String) As Boolean
    Dim tmpPos As Long
    
    AtLeastOneLine = False
    For tmpPos = Len(data) To 1 Step -1
        If (Mid$(data, tmpPos, 2) = Chr(13) + Chr(10)) Then
            AtLeastOneLine = True
            Exit For
        End If
    Next
End Function
'Pre-condition No vbNewLine can be immediately after another vbNewLine
Private Function AnalyseData(ByVal data As String, ByRef fin As String) As String
    Dim tmpPos As Long
    Dim temStr As String
    Dim tmpData As String
    Dim lineToProcess As String
    
    tmpData = data
    
    Do While InStr(tmpData, Chr(13) + Chr(10)) <> 0
        tmpPos = InStr(tmpData, Chr(13) + Chr(10))
        lineToProcess = Left$(tmpData, (tmpPos + 1))
        ProcessLine lineToProcess, fin
        tmpData = Right$(tmpData, (Len(tmpData) - tmpPos - 1))
    Loop
    
    'returns the last line if it is incomplete or returns "" if the it is complete
    If (Mid$(data, (Len(data) - 1), 2) = Chr(13) + Chr(10)) Then
        AnalyseData = ""
    Else
        For tmpPos = Len(data) To 1 Step -1
            If (Mid$(data, tmpPos, 2) = Chr(13) + Chr(10)) Then
                AnalyseData = Right$(data, (Len(data) - tmpPos - 1))
                Exit For
            End If
        Next
    End If
End Function
Private Sub ProcessLine(ByVal line As String, ByRef fin As String)
    Dim ID As String
    'Dim Prgrs As String
    'Dim Msg As String
    'Dim Stat As String
    'Dim Lic As String
    Dim content As String
    
    ID = Left(line, 4)
    content = Mid$(line, 5, (Len(line) - 6))
    
    'If ID = "prg|" Then
        'Prgrs = Content
        'ShowProgress Prgrs
    'ElseIf ID = "msg|" Then
        'Msg = Content
        'ShowMsg Msg
    'ElseIf ID = "sta|" Then
        'Stat = Content
        'ShowStatus Stat
    'ElseIf ID = "lic|" Then
        'Lic = Content
        'ShowLicDetails Lic
    'ElseIf ID = "fin|" Then
        'Fin = Content
    'Else
        'MsgBox "Unknown Data Read From Pipe!", vbCritical
        'Exit Sub
    'End If
    
    If ID = "msg|" Then
        PassMsgOn content
    ElseIf ID = "fin|" Then
        fin = content
    End If
End Sub
Private Sub PassMsgOn(msg As String)
    Dim msgLocation As String
    Dim msgType As String
    Dim tmpStr As String
    Dim msgBody As String
    
    msgType = Left$(msg, 3)
    tmpStr = Right$(msg, (Len(msg) - 4))
    
    If InStr(tmpStr, "|") = 0 Then
        'MsgBox "Incorrect Error Format From Prince", vbCritical
        Exit Sub
    Else
        msgLocation = Left$(tmpStr, (InStr(tmpStr, "|") - 1))
        msgBody = Right$(tmpStr, (Len(tmpStr) - InStr(tmpStr, "|")))
    End If
    
    RaiseEvent Message(msgType, msgLocation, msgBody)
End Sub
Public Sub SetPrincePath(ByVal exePath As String)
    princePath = exePath
End Sub
Public Sub AddStyleSheet(ByVal cssPath As String)
    styleSheets = styleSheets + "-s " + """" + cssPath + """" + " "
End Sub
Public Sub ClearStyleSheets()
    styleSheets = ""
End Sub
Public Sub SetHTML(ByVal html As Boolean)
    optionHTML = html
End Sub
Public Sub SetLog(ByVal logFile As String)
    optionLog = logFile
End Sub
Public Sub SetBaseURL(ByVal baseurl As String)
    optionBaseURL = baseurl
End Sub
Public Sub SetXInclude(ByVal xinclude As Boolean)
    optionXInclude = xinclude
End Sub
Public Sub SetEmbedFonts(ByVal embed As Boolean)
    optionEmbedFonts = embed
End Sub
Public Sub SetCompress(ByVal compress As Boolean)
    optionCompress = compress
End Sub
Public Sub SetEncrypt(ByVal encrypt As Boolean)
    optionEncrypt = encrypt
End Sub
Public Sub SetEncryptInfo(ByVal keyBits As Integer, _
                          ByVal userPassword As String, _
                          ByVal ownerPassword As String, _
                          ByVal disallowPrint As Boolean, _
                          ByVal disallowModify As Boolean, _
                          ByVal disallowCopy As Boolean, _
                          ByVal disallowAnnotate As Boolean)
    optionEncrypt = True
    encryptInfo = "--encrypt " + _
                    " --key-bits " + Str(keyBits) + _
                    " --user-password=" + """" + userPassword + """" + _
                    " --owner-password=" + """" + ownerPassword + """" + " " _

    If disallowPrint Then
        encryptInfo = encryptInfo + "--disallow-print "
    End If
                    
    If disallowModify Then
        encryptInfo = encryptInfo + "--disallow-modify "
    End If
    
    If disallowCopy Then
        encryptInfo = encryptInfo + "--disallow-copy "
    End If
    
    If disallowAnnotate Then
        encryptInfo = encryptInfo + "--disallow-annotate "
    End If
End Sub
