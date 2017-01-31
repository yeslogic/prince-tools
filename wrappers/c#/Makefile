
#Test.exe: Test.cs Prince.dll
#	mono-csc -r:Prince.dll Test.cs

CERTPATH = $(HOME)/drop/yeslogic/certificate

# signed + strongnamed
Prince.signed.dll: Prince.dll
	/opt/osslsigncode-1.7.1/bin/osslsigncode sign \
	    -certs $(CERTPATH)/yeslogic.spc \
            -key $(CERTPATH)/yeslogic.pvk \
            -h sha1 \
            -n 'Prince C# Wrapper' \
            -i 'https://www.princexml.com/' \
            -t 'http://timestamp.verisign.com/scripts/timstamp.dll' \
            -in Prince.dll \
            -out Prince.signed.dll

# strongnamed
Prince.dll: Prince.cs
	mono-csc /delaysign /keyfile:$(CERTPATH)/cert.snk /target:library /out:Prince.dll Prince.cs
	sn -R Prince.dll $(CERTPATH)/cert.pfx

