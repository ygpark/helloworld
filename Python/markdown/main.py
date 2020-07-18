# -*- coding: utf-8 -*-

import codecs
import markdown

f = codecs.open(r"sample.md", "r", "utf-8" )
text = f.read()
html = markdown.markdown(text)
f.close()

f2 = codecs.open(r"output.html", "w", "utf-8" )
f2.write("""
<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="https://stackedit.io/res-min/themes/base.css" />
</head>
""")

f2.write("""
<body>
<div style="position: fixed; top:0; left:0; width:220px; height:100%; background-color:black; color:white;">
    hello
    
</div>

<div class="container" style="left:240px; height:100%; margin-left:240; ">""")

f2.write(html)

f2.write("""</div></div></body>""")

f2.close()