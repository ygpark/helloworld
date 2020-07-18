# -*- coding: utf-8 -*-

import urllib.request

for i in range(1, 82):
    req = urllib.request.Request('http://www.insecam.org/cam/bycountry/KR/?page='+str(i), headers={'User-Agent': 'Mozilla/5.0'})
    webpage = urllib.request.urlopen(req).read()
    print(webpage.decode('utf8'))
    f = open('page'+str(i)+'.html', 'wb')
    f.write(webpage)
    f.close()
    
