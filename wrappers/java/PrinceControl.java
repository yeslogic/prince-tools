// Copyright (C) 2015 YesLogic Pty. Ltd.
// All rights reserved.

package com.princexml;

import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import java.io.IOException;
import java.io.OutputStream;

import java.util.List;

/**
 * Class for creating persistent Prince control processes that can be used for
 * multiple consecutive document conversions.
 */
public class PrinceControl extends Prince
{
    private Process mProcess;
    private String mVersion;
    
    /** Constructor for PrinceControl.
     * @param exePath The path of the Prince executable. (For example, this
     * may be <code>C:\Program&#xA0;Files\Prince\engine\bin\prince.exe</code>
     * on Windows or <code>/usr/bin/prince</code> on Linux).
     */
    public PrinceControl(String exePath)
    {
	super(exePath);
    }
    
    /** Constructor for PrinceControl.
     * @param exePath The path of the Prince executable. (For example, this
     * may be <code>C:\Program&#xA0;Files\Prince\engine\bin\prince.exe</code>
     * on Windows or <code>/usr/bin/prince</code> on Linux).
     * @param events An instance of the PrinceEvents interface that will
     * receive error/warning messages returned from Prince.
     */
    public PrinceControl(String exePath, PrinceEvents events)
    {
	super(exePath, events);
    }

    /** Get the version string for the running Prince process.
     */
    public String getVersion()
    {
	return mVersion;
    }

    /**
     * Start a Prince control process that can be used for multiple
     * consecutive document conversions.
     */
    public void start()
	throws IOException
    {
	if (mProcess != null)
	{
	    throw new RuntimeException("control process has already been started");
	}

	List<String> cmdline = getBaseCommandLine();

	cmdline.add("--control");

	mProcess = Util.invokeProcess(cmdline);
	
	InputStream outputFromPrince = mProcess.getInputStream();

	Chunk chunk = Chunk.readChunk(outputFromPrince);

	if (chunk.getTag().equals("ver"))
	{
	    mVersion = chunk.getString();
	}
	else if (chunk.getTag().equals("err"))
	{
	    throw new IOException("error: "+chunk.getString());
	}
	else
	{
	    throw new IOException("unknown chunk: "+chunk.getTag());
	}
    }

    public void stop()
	throws IOException
    {
	if (mProcess == null)
	{
	    throw new RuntimeException("control process has not been started");
	}

	OutputStream inputToPrince = mProcess.getOutputStream();
	InputStream outputFromPrince = mProcess.getInputStream();

	mProcess = null;

	Chunk.writeChunk(inputToPrince, "end", "");

	inputToPrince.close();
	outputFromPrince.close();
    }
    
    /**
     * Convert an XML or HTML file to a PDF file. This method is useful for
     * servlets as it allows Prince to write the PDF output directly to the
     * OutputStream of the servlet response.
     * <p>
     * Note that it may be helpful to specify a base URL or path for the input
     * document using the setBaseURL() method. This allows relative URLs and
     * paths in the document (eg. for images) to be resolved correctly.
     * @param xmlInput The InputStream from which Prince will read the XML or
     * HTML document.
     * @param pdfOutput The OutputStream to which Prince will write the PDF
     * output.
     * @return True if a PDF file was generated successfully.
     */
    public boolean convert(InputStream xmlInput, OutputStream pdfOutput)
	throws IOException
    {
	ByteArrayOutputStream bs = new ByteArrayOutputStream();

	Util.copyInputToOutput(xmlInput, bs);

	return convert(bs.toByteArray(), pdfOutput);
    }
    
    /**
     * Convert an XML or HTML file to a PDF file. This method is useful for
     * servlets as it allows Prince to write the PDF output directly to the
     * OutputStream of the servlet response.
     * <p>
     * Note that it may be helpful to specify a base URL or path for the input
     * document using the setBaseURL() method. This allows relative URLs and
     * paths in the document (eg. for images) to be resolved correctly.
     * @param xmlInput The byte array from which Prince will read the XML or
     * HTML document.
     * @param pdfOutput The OutputStream to which Prince will write the PDF
     * output.
     * @return True if a PDF file was generated successfully.
     */
    public boolean convert(byte[] xmlInput, OutputStream pdfOutput)
	throws IOException
    {
	if (mProcess == null)
	{
	    throw new RuntimeException("control process has not been started");
	}

	OutputStream inputToPrince = mProcess.getOutputStream();
	InputStream outputFromPrince = mProcess.getInputStream();

	Chunk.writeChunk(inputToPrince, "job", getJobJSON());
	Chunk.writeChunk(inputToPrince, "dat", xmlInput);

	inputToPrince.flush();

	Chunk chunk = Chunk.readChunk(outputFromPrince);

	if (chunk.getTag().equals("pdf"))
	{
	    pdfOutput.write(chunk.getBytes());

	    chunk = Chunk.readChunk(outputFromPrince);
	}

	if (chunk.getTag().equals("log"))
	{
	    return readMessages(chunk.getReader());
	}
	else if (chunk.getTag().equals("err"))
	{
	    throw new IOException("error: "+chunk.getString());
	}
	else
	{
	    throw new IOException("unknown chunk: "+chunk.getTag());
	}
    }

    private String getJobJSON()
    {
	Json json = new Json();

	json.beginObj();
	json.beginObj("input");
	    if (mInputType != null) json.field("type", mInputType);
	    if (mBaseURL != null) json.field("base", mBaseURL);
	    json.field("javascript", mJavaScript);
	    json.field("xinclude", mXInclude);
	    json.beginList("styles");
	    for (String style : mStyleSheets)
	    {
		json.value(style);
	    }
	    json.endList();
	    json.beginList("scripts");
	    for (String script : mScripts)
	    {
		json.value(script);
	    }
	    json.endList();
	json.endObj();
	json.beginObj("pdf");
	    json.field("embed-fonts", mEmbedFonts);
	    json.field("subset-fonts", mSubsetFonts);
            json.field("force-identity-encoding", mForceIdentityEncoding);
	    json.field("compress", mCompress);
	    if (mEncrypt)
	    {
		json.beginObj("encrypt");
		json.field("key-bits", mKeyBits);
		if (mUserPassword != null) json.field("user-password", mUserPassword);
		if (mOwnerPassword != null) json.field("owner-password", mOwnerPassword);
		json.field("disallow-print", mDisallowPrint);
		json.field("disallow-modify", mDisallowModify);
		json.field("disallow-copy", mDisallowCopy);
		json.field("disallow-annotate", mDisallowAnnotate);
		json.endObj();
	    }
	json.endObj();
	json.endObj();

	return json.toString();
    }
}
