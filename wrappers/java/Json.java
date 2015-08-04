// Copyright (C) 2015 YesLogic Pty. Ltd.
// All rights reserved.

package com.princexml;

/**
 * Json utility class.
 */
public class Json
{
    private StringBuilder mStr;
    private boolean mComma;

    public Json()
    {
	mStr = new StringBuilder();
	mComma = false;
    }

    public Json beginObj()
    {
	if (mComma) mStr.append(',');
	mStr.append('{');
	mComma = false;
	return this;
    }

    public Json beginObj(String name)
    {
	if (mComma) mStr.append(',');

	mStr.append('"');
	mStr.append(escape(name));
	mStr.append("\":{");

	mComma = false;

	return this;
    }

    public Json endObj()
    {
	mStr.append('}');
	mComma = true;
	return this;
    }

    public Json beginList(String name)
    {
	if (mComma) mStr.append(',');

	mStr.append('"');
	mStr.append(escape(name));
	mStr.append("\":[");

	mComma = false;

	return this;
    }

    public Json endList()
    {
	mStr.append(']');
	mComma = true;
	return this;
    }

    public Json field(String name)
    {
	if (mComma) mStr.append(',');

	mStr.append('"');
	mStr.append(escape(name));
	mStr.append("\":");

        mComma = false;

	return this;
    }

    public Json field(String name, String v)
    {
	field(name);
	value(v);
	return this;
    }

    public Json field(String name, boolean v)
    {
	field(name);
	value(v);
	return this;
    }

    public Json field(String name, int v)
    {
	field(name);
	value(v);
	return this;
    }

    public Json value(String v)
    {
	if (mComma) mStr.append(',');
	mStr.append('"');
	mStr.append(escape(v));
	mStr.append('"');
	mComma = true;
	return this;
    }

    public Json value(int v)
    {
	if (mComma) mStr.append(',');
	mStr.append(Integer.toString(v));
	mComma = true;
	return this;
    }

    public Json value(boolean v)
    {
	if (mComma) mStr.append(',');
	mStr.append(v ? "true" : "false");
	mComma = true;
	return this;
    }

    public String toString()
    {
	return mStr.toString();
    }

    private String escape(String s)
    {
	return s.replace("\\", "\\\\").replace("\"", "\\\"");
    }
}

