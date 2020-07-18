#!/bin/bash
prefix=composition
ext=xml
fname=$prefix.$ext

text=NOUSCO

for i in {1..10000};
do
    newfname="$prefix-$i.$ext"
    cp $fname $newfname
    sed -i "s/\($text\)/\1-$i/" $newfname
done

