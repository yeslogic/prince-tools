
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

End Interface



Public Class Prince
    Implements IPrince
    
    Public Sub New()
    Public Sub New(ByVal princePath As String)

End Class

