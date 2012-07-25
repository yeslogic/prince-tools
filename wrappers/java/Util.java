// Copyright (C) 2005-2006 YesLogic Pty. Ltd.
// All rights reserved.

package com.princexml;

import java.io.InputStream;
import java.io.IOException;
import java.io.OutputStream;

import java.util.List;

/**
 * Util contains static utility methods.
 */
public class Util
{
    /**
     * Invoke a process from a List of command line arguments.
     * @param cmdline A list of command line arguments (Strings).
     * @return The new Process.
     */
    public static Process invokeProcess(List cmdline)
	throws IOException
    {
	String[] dummy = { };
	String[] cmdlineArray = (String[]) cmdline.toArray(dummy);

	return Runtime.getRuntime().exec(cmdlineArray);
    }

    /**
     * Read all the available data from an InputStream and write it to an
     * OutputStream. The data is copied in chunks of 4096 bytes. There is no
     * return value, as an IOException will be thrown if a read or write
     * operation fails.
     * @param input The InputStream to read data from.
     * @param output The OutputStream to write data to.
     */
    public static void copyInputToOutput(InputStream input, OutputStream output)
	throws IOException
    {
	final int BUFSIZE = 4096;
        byte buf[] = new byte[BUFSIZE];
	int bytesRead;
	
	do
	{
	    bytesRead = input.read(buf, 0, BUFSIZE);
	    
            if (bytesRead > 0)
	    {
                output.write(buf, 0, bytesRead);
	    }
        }
	while (bytesRead != -1);
    }
}

