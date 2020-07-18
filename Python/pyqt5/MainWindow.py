# -*- coding: utf-8 -*-

from MainWindow_ui import Ui_MainWindow
from PyQt5.QtWidgets import QMainWindow

class MainWindow(QMainWindow, Ui_MainWindow):
    def __init__(self, parent=None):
        super(MainWindow, self).__init__(parent)
        self.setupUi(self)
        self.pushButton.clicked.connect(self.pushbutton_clicked)
   
    def pushbutton_clicked(self):
        self.label.setText("첫번째 버튼aaaaaaaaaaaaaa")
