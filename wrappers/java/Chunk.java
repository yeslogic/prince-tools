// Copyright (C) 2015-2016 YesLogic Pty. Ltd.
// All rights reserved.

package com.princexml;

import java.io.BufferedReader;
import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.IOException;
import java.io.OutputStream;

import java.nio.charset.Charset;

/**
 * Chunk is a utility class used by the Prince control interface.
 */
public class Chunk
{
    private String mTag;
    private byte[] mBytes;

    private Chunk(String tag, byte[] bytes)
    {
	mTag = tag;
	mBytes = bytes;
    }

    public String getTag()
    {
	return mTag;
    }

    public byte[] getBytes()
    {
	return mBytes;
    }

    public String getString()
    {
	return new String(mBytes, Charset.forName("UTF-8"));
    }

    public BufferedReader getReader()
    {
	return new BufferedReader(new InputStreamReader(new ByteArrayInputStream(mBytes)));
    }

    public static Chunk readChunk(InputStream input)
	throws IOException
    {
	byte[] tagBytes = new byte[3];

        if (!readBytes(input, tagBytes))
        {
	    throw new IOException("failed to read chunk tag");
        }

	String tag = new String(tagBytes, Charset.forName("ASCII"));

	int b = input.read();
	
	if (b != ' ')
	    throw new IOException("expected space after chunk tag");
	
	int length = 0;
	int max_num_length = 9;
	int num_length = 0;

	for (; num_length < max_num_length+1; ++num_length)
	{
	    b = input.read();

	    if (b == '\n') break;

	    if (b < '0' || b > '9')
		throw new IOException("unexpected character in chunk length");

	    length *= 10;
	    length += b - '0';
	}

	if (num_length < 1 || num_length > max_num_length)
	    throw new IOException("invalid chunk length");
	
	byte[] dataBytes = new byte[length];

        if (!readBytes(input, dataBytes))
        {
	    throw new IOException("failed to read chunk data");
        }

	b = input.read();

	if (b != '\n') throw new IOException("expected newline after chunk data");

	return new Chunk(tag, dataBytes);
    }

    private static boolean readBytes(InputStream input, byte[] buf)
        throws IOException
    {
        int length = buf.length;
	int offset = 0;

	while (length > 0)
	{
	    int count = input.read(buf, offset, length);

	    if (count < 0) return false;

	    if (count > length)
		throw new IOException("unexpected read overrun");

	    length -= count;
	    offset += count;
	}

        return true;
    }

    /* EQUIVALENT TO:
    private static boolean readBytes(InputStream input, byte[] buf)
        throws IOException
    {
        for (int i = 0; i < buf.length; ++i)
        {
            int b = input.read();

            if (b < 0) return false;

            buf[i] = (byte) b;
        }

        return true;
    }
    */

    public static void writeChunk(OutputStream output, String tag, String data)
	throws IOException
    {
	writeChunk(output, tag, data.getBytes(Charset.forName("UTF-8")));
    }

    public static void writeChunk(OutputStream output, String tag, byte[] data)
	throws IOException
    {
	String s = tag + " " + data.length + "\n";

	output.write(s.getBytes(Charset.forName("UTF-8")));
	output.write(data);
	output.write('\n');
    }
}

