#! /bin/sh

prince=$HOME/rep/prince-core/bin/prince

rm -rf tests/exp
rm -rf tests/out

mkdir tests/exp
mkdir tests/out

# test 1

cp tests/input/test1.xml tests/exp
cp tests/input/test1.xml tests/out

$prince tests/exp/test1.xml

# test 2

cp tests/input/test2.html tests/exp
cp tests/input/test2.html tests/out

$prince --style tests/input/style1.css --style tests/input/style2.css \
    tests/exp/test2.html

# test 3

cp tests/input/test3.html tests/exp
cp tests/input/test3.html tests/out

$prince --style tests/input/style3.css tests/exp/test3.html \
    tests/exp/output3.pdf

# test 4

cp tests/input/test4.html tests/exp
cp tests/input/test4.html tests/out

$prince --no-embed-fonts --no-compress tests/exp/test4.html

# test 5

cp tests/input/test5.html tests/exp
cp tests/input/test5.html tests/out

$prince --log tests/exp/test5.log tests/exp/test5.html

# test 6

cp tests/input/test6.html tests/exp
cp tests/input/test6.html tests/out

$prince --encrypt tests/exp/test6.html

# test 7

cp tests/input/test7.html tests/exp
cp tests/input/test7.html tests/out

$prince --key-bits=128 --user-password=userpass --owner-password=ownerpass \
    --disallow-print --disallow-modify --disallow-annotate --disallow-copy \
    tests/exp/test7.html

# test 8

$prince - < tests/input/test8.html > tests/exp/test8.pdf

# test 9

$prince --silent - < tests/input/test9.html > tests/exp/test9.pdf

# test A

$prince -i html - < tests/input/testA.html > tests/exp/testA.pdf

# test B

$prince tests/input/testB.html tests/exp/testB1.pdf
$prince --no-xinclude tests/input/testB.html tests/exp/testB2.pdf

# test C

$prince tests/input/testC.html tests/exp/testC.pdf 2>/dev/null

# test D

$prince --style="tests/input/style 4.css" \
    "tests/input/test D.html" "tests/exp/test D.pdf"

#tests/input/dummy\ dir/prince\ engine.sh --style="tests/input/style 4.css"

# test E

$prince --baseurl=http://www.princexml.com/docs/foo.html \
    "tests/input/testE.html" "tests/exp/testE.pdf"

# output

cat > tests/exp/tests.err <<EOF
test9 = false
testA = true
wrn:/does/not/exist.png:|can't open input file: No such file or directory
testD = true
EOF

# java

java -classpath prince.jar:. Test > tests/out/tests.err

# check output

diff -r --brief -x "*.log" tests/out tests/exp

for i in tests/exp/*.log ; do
    base=`basename $i`

    if [ ! -f tests/out/$base ] ; then
	echo "Missing log file: tests/out/$base"
    fi
done

for i in tests/out/*.log ; do
    base=`basename $i`

    if [ ! -f tests/exp/$base ] ; then
	echo "Spurious log file: tests/out/$base"
    fi
done

