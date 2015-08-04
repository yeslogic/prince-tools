
import java.io.IOException;
import java.io.FileInputStream;
import java.io.FileOutputStream;

//import com.princexml.Prince;
import com.princexml.PrinceControl;

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
	
	PrinceControl prince = new PrinceControl(exePath);

	prince.setInputType("html");

	prince.start();

	for (int i = 0; i < 10000; ++i)
	{
	    FileInputStream fi = new FileInputStream("input.html");
	    FileOutputStream fo = new FileOutputStream("output.pdf");

	    boolean res = prince.convert(fi, fo);

	    fi.close();
	    fo.close();

	    if (!res) throw new RuntimeException("Uh oh");
	}

	prince.stop();

	System.out.println("success!");
    }
}

