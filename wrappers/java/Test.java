
import java.io.IOException;
import java.io.FileInputStream;
import java.io.FileOutputStream;

import com.princexml.Prince;
import com.princexml.PrinceEvents;

public class Test implements PrinceEvents
{
    public static void main(String[] args)
	throws IOException
    {
	Test test = new Test();

	test.runTests();
    }

    public void runTests()
	throws IOException
    {
	boolean res;

	String exePath = "/home/mikeday/rep/prince-core/bin/prince";
	
	Prince prince = new Prince(exePath);

	// test 1
	prince.convert("tests/out/test1.xml");

	// test 2
	prince.addStyleSheet("tests/input/style1.css");
	prince.addStyleSheet("tests/input/style2.css");
	prince.convert("tests/out/test2.html");

	// test 3
	prince.clearStyleSheets();
	prince.addStyleSheet("tests/input/style3.css");
	prince.convert("tests/out/test3.html", "tests/out/output3.pdf");

	// test 4
	prince.clearStyleSheets();
	prince.setEmbedFonts(false);
	prince.setCompress(false);
	prince.convert("tests/out/test4.html");

	// test 5
	prince.setEmbedFonts(true);
	prince.setCompress(true);
	prince.setLog("tests/out/test5.log");
	prince.convert("tests/out/test5.html");

	// test 6
	prince.setLog(null);
	prince.setEncrypt(true);
	prince.convert("tests/out/test6.html");

	// test 7
	prince.setEncrypt(false);
	prince.setEncryptInfo(128, "userpass", "ownerpass",
		    true, true, true, true);
	prince.convert("tests/out/test7.html");

	// test 8
	prince.setEncrypt(false);
	prince.convert(
	    new FileInputStream("tests/input/test8.html"),
	    new FileOutputStream("tests/out/test8.pdf"));

	// test 9
	res = prince.convert(
	    new FileInputStream("tests/input/test9.html"),
	    new FileOutputStream("tests/out/test9.pdf"));
	System.out.println("test9 = "+res);

	// test A
	prince.setHTML(true);
	res = prince.convert(
	    new FileInputStream("tests/input/testA.html"),
	    new FileOutputStream("tests/out/testA.pdf"));
	System.out.println("testA = "+res);

	// test B
	prince.setHTML(false);
	prince.convert("tests/input/testB.html", "tests/out/testB1.pdf");
	prince.setXInclude(false);
	prince.convert("tests/input/testB.html", "tests/out/testB2.pdf");

	// test C
	prince = new Prince(exePath, this);
	prince.setXInclude(true);
	prince.convert("tests/input/testC.html", "tests/out/testC.pdf");

	// test D
	prince = new Prince(exePath);
	prince.addStyleSheet("tests/input/style 4.css");
	res = prince.convert("tests/input/test D.html", "tests/out/test D.pdf");
	System.out.println("testD = "+res);

	// test E
	prince = new Prince(exePath);
	prince.setBaseURL("http://www.princexml.com/docs/foo.html");
	res = prince.convert("tests/input/testE.html", "tests/out/testE.pdf");
    }

    public void onMessage(String msgType, String msgLocation, String msgText)
    {
	System.out.println(msgType+":"+msgLocation+":"+msgText);
    }
}

