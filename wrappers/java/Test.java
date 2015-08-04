
import java.io.IOException;
import java.io.FileInputStream;
import java.io.FileOutputStream;

import com.princexml.Prince;

public class Test
{
    public static void main(String[] args)
	throws IOException
    {
	speedTest();
    }

    public static void speedTest()
	throws IOException
    {
	String exePath = "/usr/lib/prince/bin/prince";
	
	Prince prince = new Prince(exePath);

	prince.setInputType("html");

	// uncomment this line for speed boost
	prince.prestartProcess();

	for (int i = 0; i < 1000; ++i)
	{
	    boolean res = prince.convertWithPrestart(
		new FileInputStream("input.html"),
		new FileOutputStream("output.pdf"));

	    if (!res) throw new RuntimeException("Uh oh");
	}

	System.out.println("success!");
    }
}

