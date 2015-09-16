using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;


public interface IPrince
{
    void SetEncryptInfo(int keyBits,
                        string userPassword,
                        string ownerPassword,
                        bool disallowPrint,
                        bool disallowModify,
                        bool disallowCopy,
                        bool disallowAnnotate);
    void AddStyleSheet(string cssPath);
    void ClearStyleSheets();
    void AddScript(string jsPath);
    void ClearScripts();
    void AddFileAttachment(string filePath);
    void ClearFileAttachments();
    void SetLicenseFile(string file);
    void SetLicensekey(string key);
    void SetInputType(string inputType);
    void SetHTML(bool html);
    void SetJavaScript(bool js);
    void SetHttpUser(string user);
    void SetHttpPassword(string password);
    void SetHttpProxy(string proxy);
    void SetInsecure(bool insecure);
    void SetLog(string logFile);
    void SetBaseURL(string baseurl);
    void SetFileRoot(string fileroot);
    void SetXInclude(bool xinclude);
    void SetEmbedFonts(bool embed);
    void SetSubsetFonts(bool embedSubset);
    void SetCompress(bool compress);
    void SetEncrypt(bool encrypt);
    void SetOptions(string options);
    bool Convert(Stream xmlInput, Stream pdfOutput);
    bool Convert(Stream xmlInput, string pdfPath);
    bool Convert(string xmlPath, Stream pdfOutput);
    bool Convert(string xmlPath, string pdfPath);
    bool Convert(string xmlPath);
    bool ConvertMemoryStream(MemoryStream xmlInput, Stream pdfOutput);
    bool ConvertMultiple(string[] xmlPaths, string pdfPath);
    bool ConvertString(string xmlInput, Stream pdfOutput);
}

/**
 * The PrinceEvents interface can be used to receive warning and error
 * messages from Prince.
 */
public interface PrinceEvents
{
    /**
     * This method will be called when a warning or error message is received
     * from Prince.
     * @param msgType The type of the message ("inf", "wrn", or "err").
     * @param msgLocation The name of the file that the message refers to.
     * This may be empty if the message does not refer to any particular file.
     * @param msgText The text of the message.
     */
    void onMessage(string msgType, string msgLocation, string msgText);
}


public class PrinceFilter : Stream
{
    private readonly IPrince mPrince;
    private readonly Stream mOldFilter;
    private readonly MemoryStream mMemStream;

    public PrinceFilter(IPrince prince, Stream oldFilter)
    {
        mPrince = prince;
        mOldFilter = oldFilter;
        mMemStream = new MemoryStream();
    }

    public override bool CanSeek
    {
        get { return false; }
    }

    public override bool CanWrite
    {
        get { return true; }
    }

    public override bool CanRead
    {
        get { return false; }
    }

    public override long Position
    {
        get
        {
            return 0;
        }

        set
        {
            /* Do Nothing */
        }
    }

    public override long Length
    {
        get
        {
            return 0;
        }
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        return 0;
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        return 0;
    }

    public override void SetLength(long value)
    {
        /* Do Nothing */
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        mMemStream.Write(buffer, offset, count);
    }

    public override void Flush()
    {
        /* FIXME? */
    }

    public override void Close()
    {
        mPrince.ConvertMemoryStream(mMemStream, mOldFilter);
        mOldFilter.Close();
    }
}


public class Prince : IPrince
{
    private PrinceEvents mEvents;
    private readonly string mPrincePath;
    private string mStyleSheets;
    private string mJavaScripts;
    private string mFileAttachments;
    private string mLicenseFile;
    private string mLicenseKey;
    private string mInputType;
    private bool mJavaScript;
    private string mHttpUser;
    private string mHttpPassword;
    private string mHttpProxy;
    private bool mInsecure;
    private string mLog;
    private string mBaseURL;
    private string mFileRoot;
    private bool mXInclude;
    private bool mEmbedFonts;
    private bool mSubsetFonts;
    private bool mCompress;
    private bool mArtificialFonts;
    private string mPdfTitle;
    private string mPdfSubject;
    private string mPdfAuthor;
    private string mPdfKeywords;
    private string mPdfCreator;
    private bool mEncrypt;
    private string mEncryptInfo;
    private string mOptions;


    public Prince()
    {
        mEvents = null;
        mInputType = "auto";
        mJavaScript = false;
        mInsecure = false;
        mXInclude = true;
        mEmbedFonts = true;
        mSubsetFonts = true;
        mCompress = true;
        mEncrypt = false;           
    }

    public Prince(string princePath) : this()
    {
        mPrincePath = princePath;
    }

    public Prince(string princePath, PrinceEvents events) : this()
    {
        mPrincePath = princePath;
        mEvents = events;
    }

    #region Public methods

    public void AddStyleSheet(string cssPath)
    {
        mStyleSheets += "-s \"" + escape(cssPath) + "\" ";
    }

    public void ClearStyleSheets()
    {
        mStyleSheets = "";
    }

    public void AddScript(string jsPath)
    {
        mJavaScripts += "--script \"" + escape(jsPath) + "\" " ;
    }

    public void ClearScripts()
    {
        mJavaScripts = "";
    }

    public void AddFileAttachment(string filePath)
    {
        mFileAttachments += "--attach=\"" +  escape(filePath) + "\" ";
    }

    public void ClearFileAttachments()
    {
        mFileAttachments = "";
    }
    
    public void SetLicenseFile(string file)
    {
        mLicenseFile = file;
    }

    public void SetLicensekey(string key)
    {
        mLicenseKey = key;
    }

    public void SetInputType(string inputType)
    {
        mInputType = inputType;
    }

    public void SetHTML(bool html)
    {
        mInputType = (html ? "html" : "xml");
    }

    public void SetJavaScript(bool js)
    {
        mJavaScript = js;
    }

    public void SetHttpUser(string user)
    {
        mHttpUser = user;
    }

    public void SetHttpPassword(string password)
    {
        mHttpPassword = password;
    }

    public void SetHttpProxy(string proxy)
    {
        mHttpProxy = proxy;
    }

    public void SetInsecure(bool insecure)
    {
        mInsecure = insecure;
    }

    public void SetLog(string logFile)
    {
        mLog = logFile;
    }

    public void SetBaseURL(string baseURL)
    {
        mBaseURL = baseURL;
    }

    public void SetFileRoot(string fileRoot)
    {
        mFileRoot = fileRoot;
    }

    public void SetXInclude(bool xInclude)
    {
        mXInclude = xInclude;
    }

    public void SetEmbedFonts(bool embed)
    {
        mEmbedFonts = embed;
    }

    public void SetSubsetFonts(bool subset)
    {
        mSubsetFonts = subset;
    }

    public void SetCompress(bool compress)
    {
        mCompress = compress;
    }

    public void SetArtificialFonts(bool artificialFonts)
    {
        mArtificialFonts = artificialFonts;
    }

    public void SetPDFTitle(string pdfTitle)
    {
        mPdfTitle = pdfTitle;
    }

    public void SetPDFSubject(string pdfSubject)
    {
        mPdfSubject = pdfSubject;
    }

    public void SetPDFAuthor(string pdfAuthor)
    {
        mPdfAuthor = pdfAuthor;
    }

    public void SetPDFKeywords(string keywords)
    {
        mPdfKeywords = keywords;
    }

    public void SetPDFCreator(string creator)
    {
        mPdfCreator = creator;
    }

    public void SetEncrypt(bool encrypt)
    {
        mEncrypt = encrypt;
    }

    public void SetEncryptInfo(int keyBits, 
                               string userPassword, 
                               string ownerPassword, 
                               bool disallowPrint, 
                               bool disallowModify, 
                               bool disallowCopy, 
                               bool disallowAnnotate)
    {
        mEncrypt = true;

        if ((keyBits != 40) && (keyBits != 128))
        {
            mEncryptInfo = "";
            throw new ApplicationException("Invalid value for keyBits: must be 40 or 128.");
        }


        mEncryptInfo = "--encrypt --key-bits " +  keyBits.ToString() +
                       " --user-password=\"" + escape(userPassword) +
                       "\" --owner-password=\"" + escape(ownerPassword) + "\" ";
        

        if (disallowPrint) { mEncryptInfo += "--disallow-print "; }
        if (disallowModify) { mEncryptInfo += "--disallow-modify "; }
        if (disallowCopy) { mEncryptInfo += "--disallow-copy "; }
        if (disallowAnnotate) { mEncryptInfo += "--disallow-annotate "; }
    }

    public void SetOptions(string options)
    {
        mOptions = options;
    }



    public bool Convert(string xmlPath)
    {
        string args = getArgs("normal") + "\"" + escape(xmlPath) + "\"";
        return Convert1(args);
    }

    public bool Convert(string xmlPath, string pdfPath)
    {
        string args = getArgs("normal") + "\"" + escape(xmlPath) + "\" -o \"" + escape(pdfPath) + "\"";
        return Convert1(args);
    }

    public bool ConvertMultiple(string[] xmlPaths, string pdfPath)
    {
        string docPaths = "";

        for (int i = 0; i < xmlPaths.Length; i++)
        {
            docPaths +=  "\"" + escape(xmlPaths[i]) + "\" ";
        }

        string args = getArgs("normal") + docPaths + " -o \"" + escape(pdfPath) + "\"";

        return Convert1(args);
    }

    public bool Convert(string xmlPath, Stream pdfOutput)
    {
        if (!pdfOutput.CanWrite)
            throw new ApplicationException("The pdfOutput stream is not writable");

        var buf = new byte[4096];
        string args = getArgs("buffered") + "\"" + escape(xmlPath) + "\" -o -" ;
        Process prs = StartPrince(args);
        prs.StandardInput.Close();

        int bytesRead = prs.StandardOutput.BaseStream.Read(buf, 0, 4096);

        while (bytesRead != 0)
        {
            pdfOutput.Write(buf, 0, bytesRead);
            bytesRead = prs.StandardOutput.BaseStream.Read(buf, 0, 4096);
        }

        prs.StandardOutput.Close();
        return (ReadMessages(prs) == "success");
    }

    public bool Convert(Stream xmlInput, string pdfPath)
    {
        if (!xmlInput.CanRead)
            throw new ApplicationException("The xmlInput stream is not readable");

        var buf = new byte[4096];

        string args = getArgs("buffered") + "- -o \"" + escape(pdfPath) + "\"";
        Process prs = StartPrince(args);

        int bytesRead = xmlInput.Read(buf, 0, 4096);
        while (bytesRead != 0)
        {
            prs.StandardInput.BaseStream.Write(buf, 0, bytesRead);
            bytesRead = xmlInput.Read(buf, 0, 4096);
        }

        prs.StandardInput.Close();
        prs.StandardOutput.Close();

        return (ReadMessages(prs) == "success");
    }

    public bool Convert(Stream xmlInput, Stream pdfOutput)
    {
        if (!xmlInput.CanRead)
            throw new ApplicationException("The xmlInput stream is not readable");

        if (!pdfOutput.CanWrite)
            throw new ApplicationException("The pdfOutput stream is not writable");

        var buf = new byte[4096];

        string args = getArgs("buffered") + "-";
        Process prs = StartPrince(args);

        int bytesRead = xmlInput.Read(buf, 0, 4096);
        while (bytesRead != 0)
        {
            prs.StandardInput.BaseStream.Write(buf, 0, bytesRead);
            bytesRead = xmlInput.Read(buf, 0, 4096);
        }
        prs.StandardInput.Close();

        bytesRead = prs.StandardOutput.BaseStream.Read(buf, 0, 4096);
        while (bytesRead != 0)
        {
            pdfOutput.Write(buf, 0, bytesRead);
            bytesRead = prs.StandardOutput.BaseStream.Read(buf, 0, 4096);
        }
        prs.StandardOutput.Close();

        return (ReadMessages(prs) == "success");
    }

    public bool ConvertMemoryStream(MemoryStream xmlInput, Stream pdfOutput)
    {
        if (!pdfOutput.CanWrite)
            throw new ApplicationException("The pdfOutput stream is not writable");

        var buf = new byte[4096];

        string args = getArgs("buffered") + "-";
        Process prs = StartPrince(args);

        xmlInput.WriteTo(prs.StandardInput.BaseStream);
        prs.StandardInput.Close();

        int bytesRead = prs.StandardOutput.BaseStream.Read(buf, 0, 4096);
        while (bytesRead != 0)
        {
            pdfOutput.Write(buf, 0, bytesRead);
            bytesRead = prs.StandardOutput.BaseStream.Read(buf, 0, 4096);
        }
        prs.StandardOutput.Close();

        return (ReadMessages(prs) == "success");
    }

    public bool ConvertString(string xmlInput, Stream pdfOutput)
    {
        if (!pdfOutput.CanWrite)
            throw new ApplicationException("The pdfOutput stream is not writable");

        var buf = new byte[4096];

        string args = getArgs("buffered") + "-";
        Process prs = StartPrince(args);

        var enc = new UTF8Encoding();
        byte[] stringBytes = enc.GetBytes(xmlInput);
        prs.StandardInput.BaseStream.Write(stringBytes, 0, stringBytes.Length);
        prs.StandardInput.Close();

        int bytesRead = prs.StandardOutput.BaseStream.Read(buf, 0, 4096);
        while (bytesRead != 0)
        {
            pdfOutput.Write(buf, 0, bytesRead);
            bytesRead = prs.StandardOutput.BaseStream.Read(buf, 0, 4096);
        }
        prs.StandardOutput.Close();

        return (ReadMessages(prs) == "success");
    }

    #endregion

    #region Private methods

    private string getArgs(string logType)
    {
        string args = "--structured-log=" + logType + " " + mStyleSheets + mJavaScripts + mFileAttachments;

        if (mEncrypt) { args += mEncryptInfo; }
        if (mInputType != "auto") { args +=  "-i \"" + escape(mInputType) + "\" "; }
        if (mJavaScript) { args += "--javascript "; }
        if (!string.IsNullOrEmpty(mHttpUser)) { args += "--http-user=\"" + escape(mHttpUser) + "\" "; }
        if (!string.IsNullOrEmpty(mHttpPassword)) { args += "--http-password=\"" + escape(mHttpPassword) + "\" "; }
        if (!string.IsNullOrEmpty(mHttpProxy)) { args += "--http-proxy=\"" + escape(mHttpProxy) + "\" "; }
        if (mInsecure) { args += "--insecure "; }
        if (!string.IsNullOrEmpty(mLog)) { args += "--log=\"" + escape(mLog) + "\" "; }
        if (!string.IsNullOrEmpty(mBaseURL)) { args += "--baseurl=\"" + escape(mBaseURL) + "\" "; }
        if (!string.IsNullOrEmpty(mFileRoot)) { args += "--fileroot=\"" + escape(mFileRoot) + "\" "; }
        if (!string.IsNullOrEmpty(mLicenseFile)) { args += "--license-file=\"" + escape(mLicenseFile) + "\" "; }
        if (!string.IsNullOrEmpty(mLicenseKey)) { args += "--license-key=\"" + escape(mLicenseKey) + "\" "; }
        if (!mXInclude) { args += "--no-xinclude "; }
        if (!mEmbedFonts) { args += "--no-embed-fonts "; }
        if (!mSubsetFonts) { args += "--no-subset-fonts "; }
        if (!mCompress) { args += "--no-compress "; }
        if (!mArtificialFonts) { args += "--no-artificial-fonts "; }
        if (!string.IsNullOrEmpty(mPdfTitle)) { args += "--pdf-title=\"" + escape(mPdfTitle) + "\" "; }
        if (!string.IsNullOrEmpty(mPdfSubject)) { args += "--pdf-subject=\"" + escape(mPdfSubject) + "\" "; }
        if (!string.IsNullOrEmpty(mPdfAuthor)) { args += "--pdf-author=\"" + escape(mPdfAuthor) + "\" "; }
        if (!string.IsNullOrEmpty(mPdfKeywords)) { args += "--pdf-keywords=\"" + escape(mPdfKeywords) + "\" "; }
        if (!string.IsNullOrEmpty(mPdfCreator)) { args += "--pdf-creator=\"" + escape(mPdfCreator) + "\" "; }
        if(!string.IsNullOrEmpty(mOptions)) {args += escape(mOptions) + " ";}

        return args;
    }

    private bool Convert1(string args)
    {
        Process pr = StartPrince(args);
        return (pr != null && ReadMessages(pr) == "success");
    }

    private Process StartPrince(string args)
    {
        const int ERROR_FILE_NOT_FOUND = 2;
        const int ERROR_PATH_NOT_FOUND = 3;
        const int ERROR_ACCESS_DENIED = 5;

        var pr = new Process
        {
            StartInfo =
            {
                FileName = mPrincePath,
                Arguments = args,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            }
        };

        try
        {
            pr.Start();

            if (!pr.HasExited)
                return pr;

            throw new ApplicationException("Error starting Prince: " + mPrincePath);
        }
        catch (System.ComponentModel.Win32Exception ex)
        {
            /* By default, use ex.Message */
            string msg = ex.Message;

            switch (ex.NativeErrorCode)
            {
                case ERROR_FILE_NOT_FOUND:
                    msg += " -- Please verify that Prince.exe is in the directory";
                    break;
                case ERROR_ACCESS_DENIED:
                    msg += " -- Please check system permission to run Prince.";
                    break;
                case ERROR_PATH_NOT_FOUND:
                    msg += " -- Please check Prince path.";
                    break;
            }

            throw new ApplicationException(msg);
        }
    }

    private string ReadMessages(Process prs)
    {
        StreamReader stdErrFromPr = prs.StandardError;
        string line = stdErrFromPr.ReadLine();
        string result = "";

        while (line != null)
        {
            if (line.Length >= 4)
            {
                string msgTag = line.Substring(0, 4);
                string msgBody = line.Substring(4);

                if((mEvents != null) && msgTag.Equals("msg|"))
                {
                   handleMessage(msgBody);
                }
                else if (msgTag.Equals("fin|"))
                {
                    result = msgBody;
                }
                else
                {
                    // ignore unknown log messages
                }

                line = stdErrFromPr.ReadLine();
            }
            else
            {
                //ignore too short messages
            }
        }

        stdErrFromPr.Close();
        return result;
    }

    private void handleMessage(string msgBody)
    {
        if (msgBody.Length >= 4)
        {
            string msgType = msgBody.Substring(0, 3);
            string tmpStr = msgBody.Substring(4);

            int locoffset = tmpStr.IndexOf('|');

            if (locoffset != -1)
            {
                string msgLocation = tmpStr.Substring(0, locoffset);
                string msgText = tmpStr.Substring(locoffset + 1);

                mEvents.onMessage(msgType, msgLocation, msgText);
            }
            else
            {
                // ignore incorrectly formatted messages
            }
        }
        else
        {
            // ignore too short messages
        }
    }

    private string cmdline_arg_escape_1(string arg)
    {
        if (arg.Length == 0)
            return arg; /* return empty string */

        //chr(34) is character double quote ( " ), chr(92) is character backslash ( \ )
        for (var pos = arg.Length - 1; pos >= 0; pos--)
        {
            if (arg[pos] == (char)34)
            {
                //if there is a double quote in the arg string
                //find number of backslashes preceding the double quote ( " )
                int numSlashes = 0;

                while ((pos - 1 - numSlashes) >= 0)
                {
                    if (arg[pos - 1 - numSlashes] == (char)92)
                        numSlashes += 1;
                    else
                        break;
                }

                string rightSubstring = arg.Substring(pos + 1);
                string leftSubstring = arg.Substring(0, (pos - numSlashes));
                string middleSubstring = ((char)92).ToString(CultureInfo.InvariantCulture);

                for (var i = 1; i <= numSlashes; i++)
                    middleSubstring = middleSubstring + (char)92 + (char)92;

                middleSubstring = middleSubstring + (char)34;
                return cmdline_arg_escape_1(leftSubstring) + middleSubstring + rightSubstring;
            }
        }

        //no double quote found, return string itself
        return arg;
    }

    private string cmdline_arg_escape_2(string arg)
    {
        int numEndingSlashes = 0;

        for (var pos = arg.Length - 1; pos >= 0; pos--)
        {
            if (arg[pos] == (char)92)
                numEndingSlashes += 1;
            else
                break;
        }

        for (var i = 1; i <= numEndingSlashes; i++)
            arg = arg + (char)92;

        return arg;
    }


    private string escape(string arg)
    {
        return cmdline_arg_escape_2(cmdline_arg_escape_1(arg));
    }

    #endregion

}
