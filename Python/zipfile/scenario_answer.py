# -*- coding: cp949 -*-
import os, random, zipfile, glob, shutil
os.chdir('C:\\Users\\fl0ckfl0ck\\Desktop\\KNP')
result_file_handle=file('.\\result.csv','w+')
file_list=glob.glob('*.zip')
num=1;
for file_name in file_list:
    file_handle=file(file_name,'r')
    target_zip=zipfile.ZipFile(file_name)
    target_zip.extractall('.\\unzip\\')
    target_zip.close()
    file_handle.close()
    file_handle_2=file('.\\unzip\\signCert.cert')
    text=file_handle_2.read()
    file_handle_2.close()
    os.remove('.\\unzip\\signCert.cert')
    name=text.split('()')[0][3:]
    account_number=text.split(',ou')[0].split('()')[1]
    bank_name=text.split(',ou=')[1].split(',ou=')[0]
    line=str(num) + ',' + name+',' + bank_name + ',' + account_number + '\n'
    num+=1
    result_file_handle.write(line)
    print line    
result_file_handle.close()
