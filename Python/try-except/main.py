# -*- coding: utf-8 -*-

import subprocess

rst = ''

try:
	rst = subprocess.check_output("netsh wlan show networks", shell=True, universal_newlines=True)
except  subprocess.CalledProcessError as exc:
	rst = exc.output
return rst


print(result)