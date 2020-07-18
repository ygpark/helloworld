import urllib.request

response = urllib.request.urlopen('http://www.naver.com')
data = response.read()
text = data.decode('utf8')
print(text)