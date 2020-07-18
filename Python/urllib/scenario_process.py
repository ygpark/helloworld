# -*- coding: utf-8 -*-

#라이브러리 추가
import os,urllib,re

# 작업 디렉토리 변경
os.chdir('D:\\example\\Desktop\\Evidence')

# 'http://fl0ckfl0ck.info'사이트에서 웹페이지를 다운로드 받아 '.\\webpage.html'에 저장
urllib.urlretrieve('http://fl0ckfl0ck.info','.\\webpage.html')

# 'webpage.html' 파일 핸들을 연다
file_handle = file('webpage.html')

# 'webpage.html' 파일을 모두 읽는다.
text = file_handle.read()

#
p=re.compile('\>([\w]+\.[\w]+\.+[\w]+\.+[\w]+\.zip)\<')
ip_list=p.findall(text)

for file_name in ip_list:
    target_url='http://fl0ckfl0ck.info/'+file_name
    location='.\\'+file_name
    urllib.urlretrieve(target_url, location)
file_handle.close()

