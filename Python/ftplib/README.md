from ftplib import FTP

def upload()
ftp = FTP('172.16.187.102')
ftp.login()
ftp.storlines("STOR //share/h1.py", open("D:\src\helloworld_py3\h.py", "rb"))
ftp.quit()
ftp.close()

