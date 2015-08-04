#! /bin/sh

src="Chunk.java Json.java Prince.java PrinceControl.java PrinceEvents.java Util.java"
out="prince-java-control1"

./build.sh
./docs.sh

# remove old package

rm -rf $out

# build package

mkdir $out
mkdir $out/lib
mkdir $out/src

cp prince.jar $out/lib

cp -r api $out/doc

cp $src $out/src

zip -r $out.zip $out
