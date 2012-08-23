Imports System.Diagnostics
Imports System.io
Imports System.text
Imports System

Public Interface IPrince
    Sub SetEncryptInfo(ByVal keyBits As Integer, _
                       ByVal userPassword As String, _
                       ByVal ownerPassword As String, _
                       ByVal disallowPrint As Boolean, _
                       ByVal disallowModify As Boolean, _
                       ByVal disallowCopy As Boolean, _
                       ByVal disallowAnnotate As Boolean)
    Sub AddStyleSheet(ByVal cssPath As String)
    Sub ClearStyleSheets()
    Sub AddScript(ByVal jsPath As String)
    Sub ClearScripts()
    Sub SetLicenseFile(ByVal file As String)
    Sub SetLicenseKey(ByVal key As String)
    Sub SetHTML(ByVal html As Boolean)
    Sub SetJavaScript(ByVal js As Boolean)
    Sub SetHttpUser(ByVal user As String)
    Sub SetHttpPassword(ByVal password As String)
    Sub SetHttpProxy(ByVal proxy As String)
    Sub SetInsecure(ByVal insecure As Boolean)
    Sub SetLog(ByVal logFile As String)
    Sub SetBaseURL(ByVal baseurl As String)
    Sub SetFileRoot(ByVal fileroot As String)
    Sub SetXInclude(ByVal xinclude As Boolean)
    Sub SetEmbedFonts(ByVal embed As Boolean)
    Sub SetSubsetFonts(ByVal embedSubset As Boolean)
    Sub SetCompress(ByVal compress As Boolean)
    Sub SetEncrypt(ByVal encrypt As Boolean)
    Function Convert(ByVal xmlPath As String) As Boolean
    Function Convert(ByVal xmlPath As String, ByVal pdfPath As String) As Boolean
    Function Convert(ByVal xmlPath As String, ByVal pdfOutput As Stream) As Boolean
    Function Convert(ByVal xmlInput As Stream, ByVal pdfPath As String) As Boolean
    Function Convert(ByVal xmlInput As Stream, ByVal pdfOutput As Stream) As Boolean
    Function ConvertMemoryStream(ByVal xmlInput As MemoryStream, ByVal pdfOutput As Stream) As Boolean
    Function ConvertString(ByVal xmlInput As String, ByVal pdfOutput As Stream) As Boolean
    Function ConvertMultiple(ByVal xmlPaths As String(), ByVal pdfPath As String) As Boolean

End Interface

Public Class PrinceFilter
    Inherits System.IO.Stream

    Private prince As IPrince
    Private oldFilter As Stream
    Private memStream As MemoryStream

    Public Sub New(ByVal prince As IPrince, ByVal oldFilter As Stream)
        Me.prince = prince
        Me.oldFilter = oldFilter
        Me.memStream = New MemoryStream
    End Sub

    Public Overrides ReadOnly Property CanSeek() As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overrides ReadOnly Property CanWrite() As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides ReadOnly Property CanRead() As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overrides Property Position() As Long
        Get
            Return 0
        End Get
        Set(ByVal Value As Long)
            ' do nothing
        End Set
    End Property

    Public Overrides ReadOnly Property Length() As Long
        Get
            Return 0
        End Get
    End Property

    Public Overrides Function Read(ByVal buffer() As Byte, ByVal offset As Integer, ByVal count As Integer) As Integer
        Return 0
    End Function

    Public Overrides Function Seek(ByVal offset As Long, ByVal origin As SeekOrigin) As Long
        Return 0
    End Function

    Public Overrides Sub SetLength(ByVal value As Long)
        ' do nothing
    End Sub

    Public Overrides Sub Write(ByVal buffer() As Byte, _
                              ByVal offset As Integer, _
                              ByVal count As Integer)
        memStream.Write(buffer, offset, count)
    End Sub

    Public Overrides Sub Flush()
        ' FIXME?
    End Sub

    Public Overrides Sub Close()
        prince.ConvertMemoryStream(memStream, oldFilter)
        oldFilter.Close()
    End Sub

End Class

Public Class Prince
    Implements IPrince

    Private mPrincePath As String
    Private mStyleSheets As String
    Private mJavaScripts As String
    Private mLicenseFile As String
    Private mLicenseKey As String
    Private mHTML As Boolean
    Private mJavaScript As Boolean
    Private mHttpUser As String
    Private mHttpPassword As String
    Private mHttpProxy As String
    Private mInsecure As Boolean
    Private mLog As String
    Private mBaseURL As String
    Private mFileRoot As String
    Private mXInclude As Boolean
    Private mEmbedFonts As Boolean
    Private mSubsetFonts As Boolean
    Private mCompress As Boolean
    Private mEncrypt As Boolean
    Private mEncryptInfo As String
    Public Sub New()
        Me.mPrincePath = ""
        Me.mStyleSheets = ""
        Me.mJavaScripts = ""
        Me.mLicenseFile = ""
        Me.mLicenseKey = ""
        Me.mHTML = False
        Me.mJavaScript = False
        Me.mHttpUser = ""
        Me.mHttpPassword = ""
        Me.mHttpProxy = ""
        Me.mInsecure = False
        Me.mLog = ""
        Me.mBaseURL = ""
        Me.mFileRoot = ""
        Me.mXInclude = True
        Me.mEmbedFonts = True
        Me.mSubsetFonts = True
        Me.mCompress = True
        Me.mEncrypt = False
        Me.mEncryptInfo = ""
    End Sub
    Public Sub New(ByVal princePath As String)
        Me.mPrincePath = princePath
        Me.mStyleSheets = ""
        Me.mJavaScripts = ""
        Me.mHTML = False
        Me.mJavaScript = False
        Me.mHttpUser = ""
        Me.mHttpPassword = ""
        Me.mHttpProxy = ""
        Me.mInsecure = False
        Me.mLog = ""
        Me.mBaseURL = ""
        Me.mFileRoot = ""
        Me.mXInclude = True
        Me.mEmbedFonts = True
        Me.mSubsetFonts = True
        Me.mCompress = True
        Me.mEncrypt = False
        Me.mEncryptInfo = ""
    End Sub
    Public Sub SetLicenseFile(ByVal file As String) _
        Implements IPrince.SetLicenseFile
        mLicenseFile = file
    End Sub
    Public Sub SetLicensekey(ByVal key As String) _
        Implements IPrince.SetLicensekey
        mLicenseKey = key
    End Sub
    Public Sub SetHTML(ByVal html As Boolean) _
        Implements IPrince.SetHTML
        mHTML = html
    End Sub
    Public Sub SetJavaScript(ByVal js As Boolean) _
        Implements IPrince.SetJavaScript
        mJavaScript = js
    End Sub
    Public Sub SetHttpUser(ByVal user As String) _
        Implements IPrince.SetHttpUser
        mHttpUser = user
    End Sub
    Public Sub SetHttpPassword(ByVal password As String) _
        Implements IPrince.SetHttpPassword
        mHttpPassword = password
    End Sub
    Public Sub SetHttpProxy(ByVal proxy As String) _
        Implements IPrince.SetHttpProxy
        mHttpProxy = proxy
    End Sub
    Public Sub SetInsecure(ByVal insecure As Boolean) _
        Implements IPrince.SetInsecure
        mInsecure = insecure
    End Sub
    Public Sub SetLog(ByVal logFile As String) _
        Implements IPrince.SetLog
        mLog = logFile
    End Sub
    Public Sub SetBaseURL(ByVal baseurl As String) _
        Implements IPrince.SetBaseURL
        mBaseURL = baseurl
    End Sub
    Public Sub SetFileRoot(ByVal fileroot As String) _
        Implements IPrince.SetFileRoot
        mFileRoot = fileroot
    End Sub
    Public Sub SetXInclude(ByVal xinclude As Boolean) _
        Implements IPrince.SetXInclude
        mXInclude = xinclude
    End Sub
    Public Sub SetEmbedFonts(ByVal embed As Boolean) _
        Implements IPrince.SetEmbedFonts
        mEmbedFonts = embed
    End Sub
    Public Sub SetSubsetFonts(ByVal subset As Boolean) _
        Implements IPrince.SetSubsetFonts
        mSubsetFonts = subset
    End Sub
    Public Sub SetCompress(ByVal compress As Boolean) _
        Implements IPrince.SetCompress
        mCompress = compress
    End Sub
    Public Sub SetEncrypt(ByVal encrypt As Boolean) _
        Implements IPrince.SetEncrypt
        mEncrypt = encrypt
    End Sub
    Public Sub SetEncryptInfo(ByVal keyBits As Integer, _
                              ByVal userPassword As String, _
                              ByVal ownerPassword As String, _
                              ByVal disallowPrint As Boolean, _
                              ByVal disallowModify As Boolean, _
                              ByVal disallowCopy As Boolean, _
                              ByVal disallowAnnotate As Boolean) _
        Implements IPrince.SetEncryptInfo

        mEncrypt = True

        If (keyBits <> 40) And (keyBits <> 128) Then
            mEncryptInfo = ""
            Throw New ApplicationException("Invalid value for keyBits: must be 40 or 128")
        Else
            mEncryptInfo = "--encrypt " + _
                    " --key-bits " + Str(keyBits) + _
                    " --user-password=" + """" + cmdline_arg_escape_2(cmdline_arg_escape_1(userPassword)) + """" + _
                    " --owner-password=" + """" + cmdline_arg_escape_2(cmdline_arg_escape_1(ownerPassword)) + """" + " "

            If disallowPrint Then
                mEncryptInfo = mEncryptInfo + "--disallow-print "
            End If

            If disallowModify Then
                mEncryptInfo = mEncryptInfo + "--disallow-modify "
            End If

            If disallowCopy Then
                mEncryptInfo = mEncryptInfo + "--disallow-copy "
            End If

            If disallowAnnotate Then
                mEncryptInfo = mEncryptInfo + "--disallow-annotate "
            End If
        End If
    End Sub
    Public Sub AddStyleSheet(ByVal cssPath As String) _
        Implements IPrince.AddStyleSheet
        mStyleSheets = mStyleSheets + "-s " + """" + cssPath + """" + " "
    End Sub
    Public Sub ClearStyleSheets() _
        Implements IPrince.ClearStyleSheets
        mStyleSheets = ""
    End Sub
    Public Sub AddScript(ByVal jsPath As String) _
        Implements IPrince.AddScript
        mJavaScripts = mJavaScripts + "--script " + """" + jsPath + """" + " "
    End Sub
    Public Sub ClearScripts() _
        Implements IPrince.ClearScripts
        mJavaScripts = ""
    End Sub
    Private Function getArgs() As String
        Dim args As String

        args = "--server " + mStyleSheets + mJavaScripts

        If mEncrypt Then
            args = args + mEncryptInfo
        End If

        If mHTML Then
            args = args + "-i html "
        End If

        If mJavaScript Then
            args = args + "--javascript "
        End If

        If mHttpUser <> "" Then
            args = args + "--http-user=""" + cmdline_arg_escape_2(cmdline_arg_escape_1(mHttpUser)) + """ "
        End If

        If mHttpPassword <> "" Then
            args = args + "--http-password=""" + cmdline_arg_escape_2(cmdline_arg_escape_1(mHttpPassword)) + """ "
        End If

        If mHttpProxy <> "" Then
            args = args + "--http-proxy=""" + mHttpProxy + """ "
        End If

        If mInsecure Then
            args = args + "--ssl-blindly-trust-server "
        End If

        If mLog <> "" Then
            args = args + "--log=""" + mLog + """ "
        End If

        If mBaseURL <> "" Then
            args = args + "--baseurl=""" + mBaseURL + """ "
        End If

        If mFileRoot <> "" Then
            args = args + "--fileroot=""" + mFileRoot + """ "
        End If

        If mLicenseFile <> "" Then
            args = args + "--license-file=""" + mLicenseFile + """ "
        End If

        If mLicenseKey <> "" Then
            args = args + "--license-key=""" + mLicenseKey + """ "
        End If

        If Not mXInclude Then
            args = args + "--no-xinclude "
        End If

        If Not mEmbedFonts Then
            args = args + "--no-embed-fonts "
        End If

        If Not mSubsetFonts Then
            args = args + "--no-subset-fonts "
        End If

        If Not mCompress Then
            args = args + "--no-compress "
        End If

        Return args
    End Function
    Public Function Convert(ByVal xmlPath As String) As Boolean _
        Implements IPrince.Convert
        Dim args As String

        args = getArgs() + Chr(34) + xmlPath + Chr(34)

        Return Convert1(args)
    End Function
    Public Function Convert(ByVal xmlPath As String, ByVal pdfPath As String) As Boolean _
        Implements IPrince.convert
        Dim args As String

        args = getArgs() + Chr(34) + xmlPath + Chr(34) + " -o " + Chr(34) + pdfPath + Chr(34)

        Return Convert1(args)
    End Function
    Public Function ConvertMultiple(ByVal xmlPaths As String(), ByVal pdfPath As String) As Boolean _
       Implements IPrince.ConvertMultiple
        Dim args As String
        Dim doc As String
        Dim docPaths As String

        docPaths = ""
        For Each doc In xmlPaths
            docPaths = docPaths + Chr(34) + doc + Chr(34) + " "
        Next

        args = getArgs() + docPaths + " -o " + Chr(34) + pdfPath + Chr(34)

        Return Convert1(args)
    End Function
    Public Function Convert(ByVal xmlPath As String, ByVal pdfOutput As Stream) As Boolean _
        Implements IPrince.Convert

        Dim buf(4096) As Byte
        Dim bytesRead As Integer
        Dim prs As New Process
        Dim args As String

        If Not pdfOutput.CanWrite Then
            Throw New ApplicationException("The pdfOutput stream is not writable")
        Else
            args = getArgs() + "--silent " + """" + xmlPath + """ -o -"
            prs = StartPrince(args)

            prs.StandardInput.Close()

            bytesRead = prs.StandardOutput.BaseStream.Read(buf, 0, 4096)
            Do While bytesRead <> 0
                pdfOutput.Write(buf, 0, bytesRead)
                bytesRead = prs.StandardOutput.BaseStream.Read(buf, 0, 4096)
            Loop
            prs.StandardOutput.Close()

            If ReadMessages(prs) = "success" Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
    Public Function Convert(ByVal xmlInput As Stream, ByVal pdfPath As String) As Boolean _
        Implements IPrince.Convert

        Dim buf(4096) As Byte
        Dim bytesRead As Integer
        Dim prs As New Process
        Dim args As String

        If Not xmlInput.CanRead Then
            Throw New ApplicationException("The xmlInput stream is not readable")
        Else
            args = getArgs() + "--silent - -o """ + pdfPath + """"
            prs = StartPrince(args)

            bytesRead = xmlInput.Read(buf, 0, 4096)
            Do While bytesRead <> 0
                prs.StandardInput.BaseStream.Write(buf, 0, bytesRead)
                bytesRead = xmlInput.Read(buf, 0, 4096)
            Loop
            prs.StandardInput.Close()

            prs.StandardOutput.Close()

            If ReadMessages(prs) = "success" Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
    Public Function Convert(ByVal xmlInput As Stream, ByVal pdfOutput As Stream) As Boolean _
        Implements IPrince.Convert

        Dim buf(4096) As Byte
        Dim bytesRead As Integer
        Dim prs As New Process
        Dim args As String

        If Not xmlInput.CanRead Then
            Throw New ApplicationException("The xmlInput stream is not readable")
        ElseIf Not pdfOutput.CanWrite Then
            Throw New ApplicationException("The pdfOutput stream is not writable")
        Else
            args = getArgs() + "--silent -"
            prs = StartPrince(args)

            bytesRead = xmlInput.Read(buf, 0, 4096)
            Do While bytesRead <> 0
                prs.StandardInput.BaseStream.Write(buf, 0, bytesRead)
                bytesRead = xmlInput.Read(buf, 0, 4096)
            Loop
            prs.StandardInput.Close()

            bytesRead = prs.StandardOutput.BaseStream.Read(buf, 0, 4096)
            Do While bytesRead <> 0
                pdfOutput.Write(buf, 0, bytesRead)
                bytesRead = prs.StandardOutput.BaseStream.Read(buf, 0, 4096)
            Loop
            prs.StandardOutput.Close()

            If ReadMessages(prs) = "success" Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
    Public Function ConvertMemoryStream(ByVal xmlInput As MemoryStream, ByVal pdfOutput As Stream) As Boolean _
        Implements IPrince.ConvertMemoryStream

        Dim buf(4096) As Byte
        Dim bytesRead As Integer
        Dim prs As New Process
        Dim args As String

        If Not pdfOutput.CanWrite Then
            Throw New ApplicationException("The pdfOutput stream is not writable")
        Else
            args = getArgs() + "--silent -"
            prs = StartPrince(args)

            xmlInput.WriteTo(prs.StandardInput.BaseStream)
            prs.StandardInput.Close()

            bytesRead = prs.StandardOutput.BaseStream.Read(buf, 0, 4096)
            Do While bytesRead <> 0
                pdfOutput.Write(buf, 0, bytesRead)
                bytesRead = prs.StandardOutput.BaseStream.Read(buf, 0, 4096)
            Loop
            prs.StandardOutput.Close()

            If ReadMessages(prs) = "success" Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
    Public Function ConvertString(ByVal xmlInput As String, ByVal pdfOutput As Stream) As Boolean _
        Implements IPrince.ConvertString

        Dim buf(4096) As Byte
        Dim bytesRead As Integer
        Dim prs As New Process
        Dim args As String

        If Not pdfOutput.CanWrite Then
            Throw New ApplicationException("The pdfOutput stream is not writable")
        Else
            args = getArgs() + "--silent -"
            prs = StartPrince(args)

            Dim enc As New UTF8Encoding
            Dim stringBytes() As Byte = enc.GetBytes(xmlInput)
            prs.StandardInput.BaseStream.Write(stringBytes, 0, stringBytes.Length)
            prs.StandardInput.Close()

            bytesRead = prs.StandardOutput.BaseStream.Read(buf, 0, 4096)
            Do While bytesRead <> 0
                pdfOutput.Write(buf, 0, bytesRead)
                bytesRead = prs.StandardOutput.BaseStream.Read(buf, 0, 4096)
            Loop
            prs.StandardOutput.Close()

            If ReadMessages(prs) = "success" Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Private Function Convert1(ByVal args As String) As Boolean
        Dim pr As Process = StartPrince(args)

        If Not (pr Is Nothing) Then
            If ReadMessages(pr) = "success" Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If

    End Function
    Private Function StartPrince(ByVal args As String) As Process
        Dim ERROR_FILE_NOT_FOUND As Integer = 2
        Dim ERROR_PATH_NOT_FOUND As Integer = 3
        Dim ERROR_ACCESS_DENIED As Integer = 5

        Dim pr As Process = New Process

        pr.StartInfo.FileName = mPrincePath
        pr.StartInfo.Arguments = args
        pr.StartInfo.UseShellExecute = False
        pr.StartInfo.CreateNoWindow = True
        pr.StartInfo.RedirectStandardInput = True
        pr.StartInfo.RedirectStandardOutput = True
        pr.StartInfo.RedirectStandardError = True

        Try
            pr.Start()

            If Not pr.HasExited Then
                Return pr
            Else
                Throw New ApplicationException("Error starting Prince: " + mPrincePath)
            End If

        Catch ex As System.ComponentModel.Win32Exception
            Dim msg As String
            msg = ex.Message
            If ex.NativeErrorCode = ERROR_FILE_NOT_FOUND Then
                msg = msg + " -- Please verify that Prince.exe is in the directory"
            ElseIf ex.NativeErrorCode = ERROR_ACCESS_DENIED Then
                msg = msg + " -- Please check system permission to run Prince."
            ElseIf ex.NativeErrorCode = ERROR_PATH_NOT_FOUND Then
                msg = msg + " -- Please check Prince path."
            Else
                ' just use ex.Message
            End If

            Throw New ApplicationException(msg)
        End Try
    End Function
    Private Function ReadMessages(ByVal prs As Process) As String
        Dim stdErrFromPr As StreamReader = prs.StandardError
        Dim line As String
        Dim result As String

        line = ""
        result = ""
        line = stdErrFromPr.ReadLine
        Do While (line <> Nothing)
            If line.Substring(0, 4) = "fin|" Then
                result = line.Substring(4, (line.Length - 4))
            End If
            line = stdErrFromPr.ReadLine
        Loop
        stdErrFromPr.Close()
        Return result
    End Function
    Private Function cmdline_arg_escape_1(ByVal arg As String) As String
        Dim pos As Integer
        Dim numSlashes As Integer
        Dim rightSubstring As String
        Dim leftSubstring As String
        Dim middleSubstring As String


        If arg.Length = 0 Then
            'return empty string
            Return arg
        Else

            'chr(34) is character double quote ( " ), chr(92) is character backslash ( \ )
            For pos = (arg.Length - 1) To 0 Step -1

                If arg.Chars(pos) = Chr(34) Then
                    'if there is a double quote in the arg string
                    'find number of backslashes preceding the double quote ( " )
                    numSlashes = 0
                    Do While ((pos - 1 - numSlashes) >= 0)
                        If arg.Chars(pos - 1 - numSlashes) = Chr(92) Then
                            numSlashes += 1
                        Else
                            Exit Do
                        End If
                    Loop

                    rightSubstring = arg.Substring(pos + 1)
                    leftSubstring = arg.Substring(0, (pos - numSlashes))

                    middleSubstring = Chr(92)
                    For i As Integer = 1 To numSlashes Step 1
                        middleSubstring = middleSubstring + Chr(92) + Chr(92)
                    Next

                    middleSubstring = middleSubstring + Chr(34)

                    Return cmdline_arg_escape_1(leftSubstring) + middleSubstring + rightSubstring

                End If
            Next

            'no double quote found, return string itself
            Return arg

        End If
    End Function
    Private Function cmdline_arg_escape_2(ByVal arg As String) As String
        Dim pos As Integer
        Dim numEndingSlashes As Integer

        numEndingSlashes = 0
        For pos = (arg.Length - 1) To 0 Step -1
            If arg.Chars(pos) = Chr(92) Then
                numEndingSlashes += 1
            Else
                Exit For
            End If
        Next

        For i As Integer = 1 To numEndingSlashes Step 1
            arg = arg + Chr(92)
        Next

        Return arg

    End Function
End Class

