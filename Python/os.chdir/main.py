# -*- coding: utf-8 -*-

import os


current_path1 = os.getcwd()

temp_path = os.environ['TEMP']
os.chdir(temp_path)

current_path2 = os.getcwd()

print(current_path1)
print(current_path2)
