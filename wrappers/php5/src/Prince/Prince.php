<?php
/**
 * Prince - PHP interface
 *
 * @copyright 2005-2014 YesLogic Pty. Ltd.
 * @link      http://www.princexml.com
 */

namespace Prince;

use Exception;

/**
 * Prince Wrapper Class
 *
 * @package Prince
 */
class Prince
{
    /**
     * @var string Path to Prince executable
     */
    private $exePath;

    /**
     * @var array CSS stylesheets
     */
    private $styleSheets;

    /**
     * @var array JavaScript files
     */
    private $scripts;

    /**
     * @var array File attachments
     */
    private $fileAttachments;

    /**
     * @var string Path to PDF license file
     */
    private $licenseFile;

    /**
     * @var string Path to PDF license key
     */
    private $licenseKey;

    /**
     * @var string Input type
     */
    private $inputType;

    /**
     * @var boolean Load javascript?
     */
    private $javascript;

    /**
     * @var string Base URL for links
     */
    private $baseURL;

    /**
     * @var boolean Parse XML Includes?
     */
    private $doXInclude;

    /**
     * @var string HTTP BasicAuth username
     */
    private $httpUser;

    /**
     * @var string HTTP BasicAuth password
     */
    private $httpPassword;

    /**
     * @var string HTTP proxy server URL
     */
    private $httpProxy;

    /**
     * @var boolean Verify SSL connection?
     */
    private $insecure;

    /**
     * @var boolean Enable verbose logging?
     */
    private $verbose;

    /**
     * @var string Path to log file
     */
    private $logFile;

    /**
     * @var string File root
     */
    private $fileRoot;

    /**
     * @var boolean Embed fonts?
     */
    private $embedFonts;

    /**
     * @var boolean Embed subset fonts?
     */
    private $subsetFonts;

    /**
     * @var boolean Embed artificial fonts?
     */
    private $artificialFonts;

    /**
     * @var string Compress file?
     */
    private $compress;

    /**
     * @var string Title attribute for PDF
     */
    private $pdfTitle;

    /**
     * @var string Subject attribute for PDF
     */
    private $pdfSubject;

    /**
     * @var string Author attribute for PDF
     */
    private $pdfAuthor;

    /**
     * @var string Author attribute for PDF
     */
    private $pdfKeywords;

    /**
     * @var string Creator (program) attribute for PDF
     */
    private $pdfCreator;

    /**
     * @var boolean Encrypt file?
     */
    private $encrypt;

    /**
     * @var string Encryption settings.
     */
    private $encryptInfo;

    /**
     * Constructor
     *
     * @param string $exePath Path to Prince executable
     */
    public function __construct($exePath)
    {
        $this->exePath = $this->addDoubleQuotes(ltrim($exePath));
        $this->styleSheets = '';
        $this->scripts = '';
        $this->fileAttachments = '';
        $this->licenseFile = '';
        $this->licenseKey = '';
        $this->inputType = 'auto';
        $this->javascript = false;
        $this->baseURL = '';
        $this->doXInclude = true;
        $this->httpUser = '';
        $this->httpPassword = '';
        $this->httpProxy = '';
        $this->insecure = false;
        $this->verbose = false;
        $this->logFile = '';
        $this->fileRoot = '';
        $this->embedFonts = true;
        $this->subsetFonts = true;
        $this->artificialFonts = true;
        $this->compress = true;
        $this->pdfTitle = '';
        $this->pdfSubject = '';
        $this->pdfAuthor = '';
        $this->pdfKeywords = '';
        $this->pdfCreator = '';
        $this->encrypt = false;
        $this->encryptInfo = '';
    }

    /**
     * Add Stylesheet
     *
     * Add a CSS style sheet that will be applied to each document.
     *
     * @param  string $cssPath The filename of the CSS style sheet.
     * @return void
     */
    public function addStyleSheet($cssPath)
    {
        $this->styleSheets .= '-s "' . $cssPath . '" ';
    }

    /**
     * Clear Stylesheets
     *
     * Clear all of the CSS style sheets.
     *
     * @return void
     */
    public function clearStyleSheets()
    {
        $this->styleSheets = '';
    }

    /**
     * Add Script
     *
     * Add a JavaScript script that will be run before conversion.
     *
     * @param  string $jsPath The filename of the script.
     * @return void
     */
    public function addScript($jsPath)
    {
        $this->scripts .= '--script "' . $jsPath . '" ';
    }

    /**
     * Clear Scripts
     *
     * Clear all of the scripts
     *
     * @return void
     */
    public function clearScripts()
    {
        $this->scripts = '';
    }

    /**
     * Add File Attachment
     *
     * Add a file attachment that will be attached to the PDF file
     *
     * @param  string $filePath The filename of the file attachment.
     * @return void
     */
    public function addFileAttachment($filePath)
    {
        $this->fileAttachments .= '--attach=' . '"' . $filePath .  '" ';
    }

    /**
     * Clear File Attachments
     *
     * Clear all of the file attachments.
     *
     * @return void
     */
    public function clearFileAttachments()
    {
        $this->fileAttachments = '';
    }

    /**
     * Set License File
     *
     * Specify the license file.
     *
     * @param  string $file The filename of the license file.
     * @return void
     */
    public function setLicenseFile($file)
    {
        $this->licenseFile = $file;
    }

    /**
     * Set License Key
     *
     * Specify the license key.
     *
     * @param  string $key The license key
     * @return void
     */
    public function setLicenseKey($key)
    {
        $this->licenseKey = $key;
    }

    /**
     * Set Input Type
     *
     * Specify the input type of the document.
     *
     * @param  string $inputType Can take a value of : "xml", "html" or "auto".
     * @return void
     */
    public function setInputType($inputType)
    {
        $this->inputType = $inputType;
    }

    /**
     * Set JavaScript
     *
     * Specify whether JavaScript found in documents should be run.
     *
     * @param  boolean $js True if document scripts should be run.
     * @return void
     */
    public function setJavaScript($js)
    {
        $this->javascript = $js;
    }

    /**
     * Set HTML
     *
     * Specify whether documents should be parsed as HTML or XML/XHTML.
     *
     * @param  boolean $html True if all documents should be treated as HTML.
     * @return void
     */
    public function setHTML($html)
    {
        if($html) {
            $this->inputType = "html";
        }
        else
        {
            $this->inputType = "xml";
        }
    }

    /**
     * Set Verbose
     *
     * Specify whether to use verbose logging
     *
     * @param  boolean $verbose True to use verbose logging.
     * @return void
     */
    public function setVerbose($verbose)
    {
        $this->verbose = $verbose;
    }

    /**
     * Set Log
     *
     * Specify a file that Prince should use to log error/warning messages.
     *
     * @param  string $logFile The filename that Prince should use to log error/warning
     *                         messages, or '' to disable logging.
     * @return void
     */
    public function setLog($logFile)
    {
        $this->logFile = $logFile;
    }

    /**
     * Set Base URL
     *
     * Specify the base URL of the input document.
     *
     * @param  string $baseURL The base URL or path of the input document, or ''.
     * @return void
     */
    public function setBaseURL($baseURL)
    {
        $this->baseURL = $baseURL;
    }

    /**
     * Set XInclude
     *
     * Specify whether XML Inclusions (XInclude) processing should be applied
     * to input documents. XInclude processing will be performed by default
     * unless explicitly disabled.
     *
     * @param  boolean $xinclude False to disable XInclude processing.
     * @return void
     */
    public function setXInclude($xinclude)
    {
        $this->doXInclude = $xinclude;
    }

    /**
     * Set HTTP User
     *
     * Specify a username to use when fetching remote resources over HTTP.
     *
     * @param  string $user The username to use for basic HTTP authentication.
     * @return void
     */
    public function setHttpUser($user)
    {
        $this->httpUser = $this->cmdlineArgEscape($user);
    }

    /**
     * Set HTTP Password
     *
     * Specify a password to use when fetching remote resources over HTTP.
     *
     * @param  string $password The password to use for basic HTTP authentication.
     * @return void
     */
    public function setHttpPassword($password)
    {
        $this->httpPassword = $this->cmdlineArgEscape($password);
    }

    /**
     * Add Script
     *
     * Specify the URL for the HTTP proxy server, if needed.
     *
     * @param  string $proxy - The URL for the HTTP proxy server.
     * @return void
     */
    public function setHttpProxy($proxy)
    {
        $this->httpProxy = $proxy;
    }

    /**
     * Set Insecure
     *
     * Specify whether to disable SSL verification.
     *
     * @param  boolean $insecure - If set to true, SSL verification is disabled. (not recommended)
     * @return void
     */
    public function setInsecure($insecure)
    {
        $this->insecure = $insecure;
    }

    /**
     * Set File Root
     *
     * Specify the root directory for absolute filenames. This can be used
     * when converting a local file that uses absolute paths to refer to web
     * resources. For example, /images/logo.jpg can be
     * rewritten to /usr/share/images/logo.jpg by specifying "/usr/share" as the root.
     *
     * @param  string $fileRoot - The path to prepend to absolute filenames.
     * @return void
     */
    public function setFileRoot($fileRoot)
    {
        $this->fileRoot = $fileRoot;
    }

    /**
     * Set Embed Fonts
     *
     * Specify whether fonts should be embedded in the output PDF file. Fonts
     * will be embedded by default unless explicitly disabled.
     *
     * @param  boolean $embedFonts - False to disable PDF font embedding.
     * @return void
     */
    public function setEmbedFonts($embedFonts)
    {
        $this->embedFonts = $embedFonts;
    }

    /**
     * Set Subset Fonts
     *
     * Specify whether embedded fonts should be subset.
     * Fonts will be subset by default unless explicitly disabled.
     *
     * @param  boolean $subsetFonts - False to disable PDF font subsetting
     * @return void
     */
    public function setSubsetFonts($subsetFonts)
    {
        $this->subsetFonts = $subsetFonts;
    }

    /**
     * Set Artificial Fonts
     *
     * Specify whether artificial bold/italic fonts should be generated if
     * necessary. Artificial fonts are enabled by default.
     *
     * @param  boolean $artificialFonts - False to disable artificial bold/italic fonts.
     * @return void
     */
    public function setArtificialFonts($artificialFonts)
    {
        $this->artificialFonts = $artificialFonts;
    }

    /**
     * Set Compress
     *
     * Specify whether compression should be applied to the output PDF file.
     * Compression will be applied by default unless explicitly disabled.
     *
     * @param  boolean $compress - False to disable PDF compression.
     * @return void
     */
    public function setCompress($compress)
    {
        $this->compress = $compress;
    }

    /**
     * Set PDF Title
     *
     * Specify the document title for PDF metadata.
     *
     * @param  string $pdfTitle
     * @return void
     */
    public function setPDFTitle($pdfTitle)
    {
        $this->pdfTitle = $pdfTitle;
    }

    /**
     * Set PDF Subject
     *
     * Specify the document subject for PDF metadata.
     *
     * @param  string $pdfSubject
     * @return void
     */
    public function setPDFSubject($pdfSubject)
    {
        $this->pdfSubject = $pdfSubject;
    }

    /**
     * Set PDF Author
     *
     * Specify the document author for PDF metadata.
     *
     * @param  string $pdfAuthor
     * @return void
     */
    public function setPDFAuthor($pdfAuthor)
    {
        $this->pdfAuthor = $pdfAuthor;
    }

    /**
     * Set PDF Keywords
     *
     * Specify the document keywords for PDF metadata.
     *
     * @param  string $pdfKeywords
     * @return void
     */
    public function setPDFKeywords($pdfKeywords)
    {
        $this->pdfKeywords = $pdfKeywords;
    }

    /**
     * Set PDF Creator
     *
     * Specify the document creator for PDF metadata.
     *
     * @param  string $pdfCreator
     * @return void
     */
    public function setPDFCreator($pdfCreator)
    {
        $this->pdfCreator = $pdfCreator;
    }

    /**
     * Set Encrypt
     *
     * Specify whether encryption should be applied to the output PDF file.
     * Encryption will not be applied by default unless explicitly enabled.
     *
     * @param  boolean $encrypt True to enable PDF encryption.
     * @return void
     */
    public function setEncrypt($encrypt)
    {
        $this->encrypt = $encrypt;
    }

    /**
     * Set Encryption Info
     *
     * Set the parameters used for PDF encryption. Calling this method will
     * also enable PDF encryption, equivalent to calling setEncrypt(true).
     *
     * @param  integer $keyBits          The size of the encryption key in bits (must be 40 or 128)
     * @param  string  $userPassword     The user password for the PDF file.
     * @param  string  $ownerPassword    The owner password for the PDF file.
     * @param  boolean $disallowPrint    True to disallow printing of the PDF file.
     * @param  boolean $disallowModify   True to disallow modification of the PDF file.
     * @param  boolean $disallowCopy     True to disallow copying from the PDF file.
     * @param  boolean $disallowAnnotate True to disallow annotation of the PDF file.
     * @return void
     */
    public function setEncryptInfo($keyBits,
        $userPassword,
        $ownerPassword,
        $disallowPrint = false,
        $disallowModify = false,
        $disallowCopy = false,
        $disallowAnnotate = false
    ) {
        if ($keyBits != 40 && $keyBits != 128) {
            throw new Exception(
                "Invalid value for keyBits: $keyBits" .
                " (must be 40 or 128)"
            );
        }

        $this->encrypt = true;

            $this->encryptInfo =
            ' --key-bits ' . $keyBits .
            ' --user-password="' . $this->cmdlineArgEscape($userPassword) .
            '" --owner-password="' . $this->cmdlineArgEscape($ownerPassword) . '" ';

        if ($disallowPrint) {
            $this->encryptInfo .= '--disallow-print ';
        }

        if ($disallowModify) {
            $this->encryptInfo .= '--disallow-modify ';
        }

        if ($disallowCopy) {
            $this->encryptInfo .= '--disallow-copy ';
        }

        if ($disallowAnnotate) {
            $this->encryptInfo .= '--disallow-annotate ';
        }
    }

    /**
     * Convert File
     *
     * @param  array $xmlPath The filename of the input XML or HTML document.
     * @param  array $msgs    An optional array in which to return error and warning messages.
     * @return boolean
     */
    public function convert_file($xmlPath, &$msgs = array())
    {
        $pathAndArgs = $this->getCommandLine();
        $pathAndArgs .= '--structured-log=normal ';
        $pathAndArgs .= '"' . $xmlPath . '"';

        return $this->convert_internal_file_to_file($pathAndArgs, $msgs);
    }

    /**
     * Convert File to FIle
     *
     * @param  array  $xmlPath The filename of the input XML or HTML document.
     * @param  string $pdfPath The filename of the output PDF file.
     * @param  array  $msgs    An optional array in which to return error and warning messages.
     * @return boolean
     */
    public function convert_file_to_file($xmlPath, $pdfPath, &$msgs = array())
    {
        $pathAndArgs = $this->getCommandLine();
        $pathAndArgs .= '--structured-log=normal ';
        $pathAndArgs .= '"' . $xmlPath . '" -o "' . $pdfPath . '"';

        return $this->convert_internal_file_to_file($pathAndArgs, $msgs);
    }

    /**
     * Convert Multiple Files
     *
     * @param  array  $xmlPaths An array of the input XML or HTML documents.
     * @param  string $pdfPath  The filename of the output PDF file.
     * @param  array  $msgs     An optional array in which to return error and warning messages.
     * @return boolean
     */
    public function convert_multiple_files($xmlPaths, $pdfPath, &$msgs = array())
    {
        $pathAndArgs = $this->getCommandLine();
        $pathAndArgs .= '--structured-log=normal ';

        foreach($xmlPaths as $xmlPath)
        {
            $pathAndArgs .= '"' . $xmlPath . '" ';
        }
        $pathAndArgs .= '-o "' . $pdfPath . '"';

        return $this->convert_internal_file_to_file($pathAndArgs, $msgs);
    }

    /**
     * Convert Multiple Files to Passthru
     *
     * @param  array $xmlPaths An array of the input XML or HTML documents.
     * @param  array $msgs     An optional array in which to return error and warning messages.
     * @return boolean
     */
    public function convert_multiple_files_to_passthru($xmlPaths, &$msgs = array())
    {
        $pathAndArgs = $this->getCommandLine();
        $pathAndArgs .= '--structured-log=buffered ';

        foreach($xmlPaths as $xmlPath)
        {
            $pathAndArgs .= '"' . $xmlPath . '" ';
        }
        $pathAndArgs .= '-o -';

         return $this->convert_internal_file_to_passthru($pathAndArgs, $msgs);
    }

    /**
     * Convert File to Passthru
     *
     * @param  string $xmlPath The filename of the input XML or HTML document.
     * @param  array  $msgs    An optional array in which to return error and warning messages.
     * @return boolean
     */
    public function convert_file_to_passthru($xmlPath, &$msgs = array())
    {
        $pathAndArgs = $this->getCommandLine();
        $pathAndArgs .= '--structured-log=buffered "' . $xmlPath . '" -o -';

        return $this->convert_internal_file_to_passthru($pathAndArgs, $msgs);
    }

    /**
     * Convert String to Passthru
     *
     * @param  string $xmlString A string containing an XML or HTML document.
     * @param  array  $msgs      An optional array in which to return error and warning messages.
     * @return boolean
     */
    public function convert_string_to_passthru($xmlString, &$msgs = array())
    {
        $pathAndArgs = $this->getCommandLine();
        $pathAndArgs .= '--structured-log=buffered -';

        return $this->convert_internal_string_to_passthru($pathAndArgs, $xmlString, $msgs);
    }

    /**
     * Convert String to File
     *
     * @param  string $xmlString A string containing an XML or HTML document.
     * @param  string $pdfPath   The filename of the output PDF file.
     * @param  array  $msgs      An optional array in which to return error and warning messages.
     * @return boolean
     */
    public function convert_string_to_file($xmlString, $pdfPath, &$msgs = array())
    {
        $pathAndArgs = $this->getCommandLine();
        $pathAndArgs .= '--structured-log=normal ';
        $pathAndArgs .= ' - -o "' . $pdfPath . '"';

        return $this->convert_internal_string_to_file($pathAndArgs, $xmlString, $msgs);
    }

    /**
     * Get Command Line
     *
     * @return string
     */
    private function getCommandLine()
    {
        $cmdline = $this->exePath . ' ' . $this->styleSheets . $this->scripts . $this->fileAttachments;

        if ($this->inputType == "auto") {
        }
        else
        {
            $cmdline .=  '-i "' . $this->inputType . '" ';
        }

        if ($this->javascript) {
            $cmdline .= '--javascript ';
        }

        if ($this->baseURL != '') {
            $cmdline .= '--baseurl="' . $this->baseURL . '" ';
        }

        if ($this->doXInclude == false) {
            $cmdline .= '--no-xinclude ';
        }

        if ($this->httpUser != '') {
            $cmdline .= '--http-user="' . $this->httpUser . '" ';
        }

        if ($this->httpPassword != '') {
            $cmdline .= '--http-password="' . $this->httpPassword . '" ';
        }

        if($this->httpProxy != '') {
            $cmdline .= '--http-proxy="' . $this->httpProxy . '" ';
        }

        if($this->insecure) {
            $cmdline .= '--insecure ';
        }

        if ($this->verbose) {
            $cmdline .= '--verbose ';
        }

        if ($this->logFile != '') {
            $cmdline .= '--log="' . $this->logFile . '" ';
        }

        if($this->fileRoot != '') {
             $cmdline .= '--fileroot="' . $this->fileRoot . '" ';
        }

        if($this->licenseFile != '') {
            $cmdline .= '--license-file="' . $this->licenseFile . '" ';
        }

        if($this->licenseKey != '') {
            $cmdline .= '--license-key="' . $this->licenseKey . '" ';
        }

        if ($this->embedFonts == false) {
            $cmdline .= '--no-embed-fonts ';
        }

        if ($this->subsetFonts == false) {
            $cmdline .= '--no-subset-fonts ';
        }

        if ($this->artificialFonts == false) {
            $cmdline .= '--no-artificial-fonts ';
        }

        if ($this->compress == false) {
            $cmdline .= '--no-compress ';
        }

        if ($this->pdfTitle != '') {
            $cmdline .= '--pdf-title="' . $this->cmdlineArgEscape($this->pdfTitle) . '" ';
        }

        if ($this->pdfSubject != '') {
            $cmdline .= '--pdf-subject="' . $this->cmdlineArgEscape($this->pdfSubject) . '" ';
        }

        if ($this->pdfAuthor != '') {
            $cmdline .= '--pdf-author="' . $this->cmdlineArgEscape($this->pdfAuthor) . '" ';
        }

        if ($this->pdfKeywords != '') {
            $cmdline .= '--pdf-keywords="' . $this->cmdlineArgEscape($this->pdfKeywords) . '" ';
        }

        if ($this->pdfCreator != '') {
            $cmdline .= '--pdf-creator="' . $this->cmdlineArgEscape($this->pdfCreator) . '" ';
        }

        if ($this->encrypt) {
            $cmdline .= '--encrypt ' . $this->encryptInfo;
        }

        return $cmdline;
    }

    /**
     * Convert Internal File to File
     *
     * @param  string $pathAndArgs Path and arguments to execute.
     * @param  array  $msgs        An optional array in which to return error and warning messages.
     * @return string
     */
    private function convert_internal_file_to_file($pathAndArgs, &$msgs)
    {
        $descriptorspec = array(
                0 => array("pipe", "r"),
                1 => array("pipe", "w"),
                2 => array("pipe", "w")
                );

        $process = proc_open($pathAndArgs, $descriptorspec, $pipes, null, null, array('bypass_shell' => true));

        if (is_resource($process)) {
            $result = $this->readMessages($pipes[2], $msgs);

            fclose($pipes[0]);
            fclose($pipes[1]);
            fclose($pipes[2]);

            proc_close($process);

            return ($result == 'success');
        }
        else
        {
            throw new Exception("Failed to execute $pathAndArgs");
        }
    }

    /**
     * Convert Internal String to File
     *
     * @param  string $pathAndArgs Path and arguments to execute.
     * @param  string $xmlString   Contents of the XML file.
     * @param  array  $msgs        An optional array in which to return error and warning messages.
     * @return string
     */
    private function convert_internal_string_to_file($pathAndArgs, $xmlString, &$msgs)
    {
        $descriptorspec = array(
                0 => array("pipe", "r"),
                1 => array("pipe", "w"),
                2 => array("pipe", "w")
                );

        $process = proc_open($pathAndArgs, $descriptorspec, $pipes, null, null, array('bypass_shell' => true));

        if (is_resource($process)) {
            fwrite($pipes[0], $xmlString);
            fclose($pipes[0]);
            fclose($pipes[1]);

            $result = $this->readMessages($pipes[2], $msgs);

            fclose($pipes[2]);

            proc_close($process);

            return ($result == 'success');
        }
        else
        {
            throw new Exception("Failed to execute $pathAndArgs");
        }
    }

    /**
     * Convert Internal File to Passthru
     *
     * @param  string $pathAndArgs Path and arguments to execute.
     * @param  array  $msgs        An optional array in which to return error and warning messages.
     */
    private function convert_internal_file_to_passthru($pathAndArgs, &$msgs)
    {
        $descriptorspec = array(
                0 => array("pipe", "r"),
                1 => array("pipe", "w"),
                2 => array("pipe", "w")
                );

        $process = proc_open($pathAndArgs, $descriptorspec, $pipes, null, null, array('bypass_shell' => true));

        if (is_resource($process)) {
            fclose($pipes[0]);
            fpassthru($pipes[1]);
            fclose($pipes[1]);

            $result = $this->readMessages($pipes[2], $msgs);

            fclose($pipes[2]);

            proc_close($process);

            return ($result == 'success');
        }
        else
        {
            throw new Exception("Failed to execute $pathAndArgs");
        }
    }

    /**
     * Convert Internal String to Passthru
     *
     * @param  string $pathAndArgs Path and arguments to execute.
     * @param  string $xmlString   Contents of the XML file.
     * @param  array  $msgs        An optional array in which to return error and warning messages.
     * @return string
     */
    private function convert_internal_string_to_passthru($pathAndArgs, $xmlString, &$msgs)
    {
        $descriptorspec = array(
                0 => array("pipe", "r"),
                1 => array("pipe", "w"),
                2 => array("pipe", "w")
                );

        $process = proc_open($pathAndArgs, $descriptorspec, $pipes, null, null, array('bypass_shell' => true));

        if (is_resource($process)) {
            fwrite($pipes[0], $xmlString);
            fclose($pipes[0]);
            fpassthru($pipes[1]);
            fclose($pipes[1]);

            $result = $this->readMessages($pipes[2], $msgs);

            fclose($pipes[2]);

            proc_close($process);

            return ($result == 'success');
        }
        else
        {
            throw new Exception("Failed to execute $pathAndArgs");
        }
    }

    /**
     * Read Messages
     *
     * @param  resource $pipe File hanndle.
     * @param  array    $msgs An optional array in which to return error and warning messages.
     * @return string
     */
    private function readMessages($pipe, &$msgs)
    {
        while (!feof($pipe))
        {
            $line = fgets($pipe);

            if ($line != false) {
                $msgtag = substr($line, 0, 4);
                $msgbody = rtrim(substr($line, 4));

                if ($msgtag == 'fin|') {
                    return $msgbody;
                }
                else if ($msgtag == 'msg|') {
                    $msg = explode('|', $msgbody, 4);

                    // $msg[0] = 'err' | 'wrn' | 'inf'
                    // $msg[1] = filename / line number
                    // $msg[2] = message text, trailing newline stripped

                    $msgs[] = $msg;
                }
                else
                {
                    // ignore other messages
                }
            }
        }

        return '';
    }

    /**
     * Add Double Quotes
     *
     * Puts double-quotes around space(s) in file path,
     * and also around semicolon(;), comma(,), ampersand(&), up-arrow(^) and parentheses.
     * This is needed if the file path is used in a command line.
     *
     * @param  string $str
     * @return string
     */
    private function addDoubleQuotes($str)
    {
        $len = strlen($str);

        $outputStr = '';
        $numWeirdChars = 0;
        $subStrStart = 0;
        for ($i = 0; $i < $len; $i++)
        {
            if(($str[$i] == ' ')
                || ($str[$i] == ';')
                || ($str[$i] == ',')
                || ($str[$i] == '&')
                || ($str[$i] == '^')
                || ($str[$i] == '(')
                || ($str[$i] == ')')
            ) {
                if($numWeirdChars == 0) {
                    $outputStr .= substr($str, $subStrStart, ($i - $subStrStart));
                    $weirdCharsStart = $i;
                }
                $numWeirdChars += 1;
            }
            else
            {
                if($numWeirdChars > 0) {
                    $outputStr .=  chr(34) . substr($str, $weirdCharsStart, $numWeirdChars) . chr(34);

                    $subStrStart = $i;
                    $numWeirdChars = 0;
                }
            }
        }
        $outputStr .= substr($str, $subStrStart, ($i - $subStrStart));

        return $outputStr;
    }

    /**
     * Command Line Argument Escape
     *
     * @param  string $argStr
     * @return string
     */
    private function cmdlineArgEscape($argStr)
    {
        return $this->cmdlineArgEscape2($this->cmdlineArgEscape1($argStr));
    }

    /**
     * Command Line Argument Escape (1)
     *
     * In the input string $argStr, a double quote with zero or more preceding backslash(es)
     * will be replaced with: n*backslash + doublequote => (2*n+1)*backslash + doublequote
     *
     * @param  string $argStr
     * @return string
     */
    private function cmdlineArgEscape1($argStr)
    {
        //chr(34) is character double quote ( " ), chr(92) is character backslash ( \ ).
        $len = strlen($argStr);

        $outputStr = '';
        $numSlashes = 0;
        $subStrStart = 0;

        for($i = 0; $i < $len; $i++)
        {
            if($argStr[$i] == chr(34)) {
                $numSlashes = 0;
                $j = $i - 1;
                while($j >= 0)
                {
                    if($argStr[$j] == chr(92)) {
                        $numSlashes += 1;
                        $j -= 1;
                    }
                    else
                    {
                        break;
                    }
                }

                $outputStr .= substr($argStr, $subStrStart, ($i - $numSlashes - $subStrStart));

                for($k = 0; $k < $numSlashes; $k++)
                {
                    $outputStr .= chr(92) . chr(92);
                }
                $outputStr  .= chr(92) . chr(34);

                $subStrStart = $i + 1;
            }
        }
        $outputStr .= substr($argStr, $subStrStart, ($i - $subStrStart));

        return $outputStr;
    }

    /**
     * Command Line Argument Escape (2)
     *
     * Double the number of trailing backslash(es): n*trailing backslash => (2*n)*trailing backslash.
     *
     * @param  string $argStr
     * @return string
     */
    private function cmdlineArgEscape2($argStr)
    {
        //chr(92) is character backslash ( \ ).
        $len = strlen($argStr);

        $numTrailingSlashes = 0;
        for($i = ($len - 1); $i  >= 0; $i--)
        {
            if($argStr[$i] == chr(92)) {
                $numTrailingSlashes += 1;
            }
            else
            {
                break;
            }
        }

        while($numTrailingSlashes > 0)
        {
            $argStr .= chr(92);
            $numTrailingSlashes -= 1;
        }

        return $argStr;
    }

}
