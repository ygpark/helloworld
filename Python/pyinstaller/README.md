# 버전

파이썬 3.2 ~ 3.5 지원

# 설치

py -m pip install pyinstaller


# 사용법

pyinstaller 000.py




#
# pyinstaller 에러.
#

Traceback (most recent call last):
  File "site-packages\PyInstaller\loader\rthooks\pyi_rth_qt5plugins.py", line 46, in <module>
  File "C:\Users\사이버실2\AppData\Local\Programs\Python\Python35\lib\site-packages\PyInstaller\loader\pyimod03_importers.py", line 714, in load_module
    module = loader.load_module(fullname)
ImportError: DLL load failed: 지정된 모듈을 찾을 수 없습니다.
Failed to execute script pyi_rth_qt5plugins




pyinstaller --onefile --windowed --clean -p C:\Python35\Lib\site-packages\PyQt5\Qt\bin main.py
pyinstaller --onefile --windowed --clean -p C:\Python35\Lib\site-packages\PyQt5\Qt\bin -p C:\Python35\Lib\site-packages\pyqt5-tools\platforms main.py

pyinstaller --onefile --windowed --clean -p %USERPROFILE%\AppData\Local\Programs\Python\Python35-32\Lib\site-packages\PyQt5\Qt\bin main.py
pyinstaller --onefile --windowed --clean -p D:\dll main.py

"%USERPROFILE%\AppData\Local\Programs\Python\Python35-32\Scripts\pyinstaller.exe" --onefile --windowed --clean -p C:\Users\test\AppData\Local\Programs\Python\Python35-32\Lib\site-packages\PyQt5\Qt\bin main.py
