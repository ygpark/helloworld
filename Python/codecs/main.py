# -*- coding: utf-8 -*-

import codecs

f = codecs.open(r"E:\Git\man\markdown\readme.md", "r", "utf-8" )

text = f.read()
print(text)