#! /bin/sh

SRC="Prince.java PrinceEvents.java"
NO_QUALIFY="java.lang:java.io:java.util"
OUTPUT="api"

rm -rf $OUTPUT

javadoc -d $OUTPUT $SRC -noqualifier $NO_QUALIFY
