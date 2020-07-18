-----------------------------------------------
노트
-----------------------------------------------
- Python v3.5 사용 권장 : pyinstaller 가 Python v3.2 ~ v3.5를 지원하기 때문


-----------------------------------------------
설치
-----------------------------------------------
pip install pyqt5
pip install pyqt5-tools


-----------------------------------------------
경로
-----------------------------------------------
C:\Python36\Lib\site-packages\pyqt5-tools\designer.exe 	# Qt 디자이너
C:\Python36\Scripts\pyuic5.exe     						# qtdesigner로 만든 (*.ui) 파일 컴파일러



-----------------------------------------------
디자이너 파일 컴파일하기
-----------------------------------------------
pyuic5 design.ui -o design.py
pyuic5 path/to/design.ui -o output/path/to/design.py


-----------------------------------------------
코드 작성 순서
-----------------------------------------------
- qt designer로 *.ui 파일 작성 ex) MainWindow.ui
- pyuic5.exe로 .ui파일 컴파일  ex) pyuic5 MainWindow.ui -o MainWindow_ui.py
- ui를 담을 클래스 작성

			ex) 
			
			import MainWindow_ui

			from PyQt5.QtWidgets import QMainWindow

			class MainWindow(QMainWindow, MainWindow_ui.Ui_MainWindow):
				def __init__(self, parent=None):
					super(MainWindow, self).__init__(parent)
					self.setupUi(self)

- 폼 호출
	
			ex)
			
			form = MainWindow()
			form.show()

			
-----------------------------------------------
시그널 슬럿 예제
-----------------------------------------------
			import MainWindow_ui

			from PyQt5.QtWidgets import QMainWindow

			class MainWindow(QMainWindow, MainWindow_ui.Ui_MainWindow):
				def __init__(self, parent=None):
					super(MainWindow, self).__init__(parent)
					self.setupUi(self)
					# 시그널, 슬럿 연결
					self.pushButton.clicked.connect(self.pushbutton_clicked)  
			   
			    # 슬럿
				def pushbutton_clicked(self):
					self.label.setText("첫번째 버튼aaaaaaaaaaaaaa")

-----------------------------------------------
참고
-----------------------------------------------
- https://nikolak.com/pyqt-qt-designer-getting-started/
  - /참고자료/PyQt_PySide and QtDesigner tutorial.pdf
  
- https://opentutorials.org/module/544/9494