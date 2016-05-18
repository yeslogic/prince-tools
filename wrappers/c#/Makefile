
Test.exe: Test.cs Prince.dll
	mono-csc -r:Prince.dll Test.cs

Prince.dll: Prince.cs
	mono-csc /target:library /out:Prince.dll Prince.cs

