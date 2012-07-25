Prince ActiveX Dll file:	Prince.dll
Object Class:			PrinceCom.Prince
Class Methods:

	Public Sub SetPrincePath(ByVal exePath As String)

	Public Function Convert(ByVal xmlPath As String, _
                                Optional ByVal pdfPath As String = "") As Long

	Public Sub AddStyleSheet(ByVal cssPath As String)
   	
	Public Sub ClearStyleSheets()

	Public Sub SetHTML(ByVal html As Boolean)

	Public Sub SetLog(ByVal logFile As String)

	Public Sub SetBaseURL(ByVal baseurl As String)

	Public Sub SetXInclude(ByVal xinclude As Boolean)

	Public Sub SetEmbedFonts(ByVal embed As Boolean)

	Public Sub SetCompress(ByVal compress As Boolean)

	Public Sub SetEncrypt(ByVal encrypt As Boolean)

	Public Sub SetEncryptInfo(ByVal keyBits As Integer, _
                          	  ByVal userPassword As String, _
                          	  ByVal ownerPassword As String, _
                         	  ByVal disallowPrint As Boolean, _
                          	  ByVal disallowModify As Boolean, _
                          	  ByVal disallowCopy As Boolean, _
                          	  ByVal disallowAnnotate As Boolean)

Note:	

	1) Procedure SetPrincePath takes one string argument: exePath
		
		Argument exePath is the full path of the prince.exe file. if you have Prince installed,
		it should be in the prince\engine\bin directory.
		This procedure should be called to set the Prince path attribute before calling the Convert
		function. Convert will exit with an error if the Prince path attribute is not set correctly.

	
	2) Function Convert takes two arguments:
		
		1. String xmlPath is the full path of the xml file
		2. String pdfPath is optional, and is the full path of the output pdf file. If this argument
		   is omitted, the output pdf file is placed in the same directory as the input xml file

	   	This function returns 1 if conversion is successful, 0 if conversion fails.

	3) Procedure AddStyleSheet takes one string argument: cssPath
	   
		CssPath is the full path of the Cascading Style Sheet css file. 
	   	AddStyleSheet can be called many times to add different style sheets. Style sheets will be
	  	accumulated and will be applied to the conversion. 
	   	This procedure should be called before calling Convert for the style sheet(s) to be applied

	4) Procedure ClearStyleSheets clears all of the accumulated style sheet(s).

	5) Procedure SetEncryptInfo takes seven arguments. They are related to encryption of the output pdf file.
	   This procedure can be called if encryption is required. It should be called before calling
 	   Convert for encryption to be applied.

		1. Integer keyBits can be either 40 or 128.
		2. String userPassword sets the password the user will have to type in to open the pdf file 
		   as a user.
		3. String ownerPassword sets the password the user will have to type in to open the pdf file 
		   as the owner.
		4. Boolean disallowPrint, if set true, printing will be disallowed for the user.
		5. Boolean disallowModify, if set true, modifying will be disallowed for the user.
		6. Boolean disallowCopy, if set true, copying text will be disallowed for the user.
		7. Boolean disallowAnnotate, if set true, Annotation will be disallowed for the user.

	6) Messages from Prince are passed on to the caller as events. An event is raised for each message Prince
	   outputs. The message event is declared as follows:

		Public Event Message(msgType As String, msgLocation As String, msg As String)

	   It has three string arguments representing the message type, its location and the message.

		1. msgType:
				Value    Meaning				

				"inf" -- information
				"wrn" -- warning
				"err" -- error

		2. msgLocation: shows where the message came from or where the error occured (this can be empty).

		3. msg: is the content of the message
				

	   Visual Basic Users wishing to write an event handler to process messages from Prince will need to
	   declare a WithEvents variable, create a Prince class object then assign the the latter to the former.
	   	
		Example:   	
			Dim WithEvents pr As Prince
			...
			Set pr = New Prince