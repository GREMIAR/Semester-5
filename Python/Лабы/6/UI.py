from PyQt5 import QtCore, QtGui, QtWidgets
import socket
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

server_address = ('localhost', 8080)
print('Подключено к {} порт {}'.format(*server_address))
sock.connect(server_address)

class Ui_MainWindow(object):
    def setupUi(self, MainWindow):
        MainWindow.setObjectName("MainWindow")
        MainWindow.resize(570, 478)
        self.centralwidget = QtWidgets.QWidget(MainWindow)
        self.centralwidget.setObjectName("centralwidget")
        self.textEdit1 = QtWidgets.QTextEdit(self.centralwidget)
        self.textEdit1.setGeometry(QtCore.QRect(20, 20, 541, 211))
        self.textEdit1.setObjectName("textEdit1")
        self.textEdit2 = QtWidgets.QTextEdit(self.centralwidget)
        self.textEdit2.setEnabled(False)
        self.textEdit2.setGeometry(QtCore.QRect(20, 250, 541, 211))
        self.textEdit2.setObjectName("textEdit2")
        self.label1 = QtWidgets.QLabel(self.centralwidget)
        self.label1.setGeometry(QtCore.QRect(236, 0, 100, 20))
        font = QtGui.QFont()
        font.setPointSize(12)
        self.label1.setFont(font)
        self.label1.setObjectName("label1")
        self.label2 = QtWidgets.QLabel(self.centralwidget)
        self.label2.setGeometry(QtCore.QRect(260, 230, 51, 20))
        font = QtGui.QFont()
        font.setPointSize(12)
        self.label2.setFont(font)
        self.label2.setObjectName("label2")
        self.radioButton1 = QtWidgets.QRadioButton(self.centralwidget)
        self.radioButton1.setGeometry(QtCore.QRect(5, 110, 21, 20))
        self.radioButton1.setText("")
        self.radioButton1.setChecked(True)
        self.radioButton1.setObjectName("radioButton1")
        self.radioButton2 = QtWidgets.QRadioButton(self.centralwidget)
        self.radioButton2.setGeometry(QtCore.QRect(5, 350, 21, 20))
        self.radioButton2.setText("")
        self.radioButton2.setObjectName("radioButton2")
        self.radioButton1.clicked.connect(self.RadioButton1)
        self.radioButton2.clicked.connect(self.RadioButton2)
        MainWindow.setCentralWidget(self.centralwidget)
        self.textEdit1.textChanged.connect(self.TextChangeNormal)
        self.textEdit2.textChanged.connect(self.TextChangeMorze)
        self.retranslateUi(MainWindow)
        QtCore.QMetaObject.connectSlotsByName(MainWindow)

    def retranslateUi(self, MainWindow):
        _translate = QtCore.QCoreApplication.translate
        MainWindow.setWindowTitle(_translate("MainWindow", "Шифратор"))
        self.label1.setText(_translate("MainWindow", "Естественный"))
        self.label2.setText(_translate("MainWindow", "Морзе"))

    def RadioButton1(self):
        _translate = QtCore.QCoreApplication.translate
        self.textEdit1.setEnabled(True)
        self.textEdit2.setEnabled(False)
        self.setWindowTitle(_translate("MainWindow", "Шифратор"))
        self.TextChangeNormal()

    def RadioButton2(self):
        _translate = QtCore.QCoreApplication.translate
        self.textEdit1.setEnabled(False)
        self.textEdit2.setEnabled(True)
        self.setWindowTitle(_translate("MainWindow", "Дешифратор"))
        self.TextChangeMorze()

    def TextChangeNormal(self):
        mess = self.textEdit1.toPlainText()
        if(mess):
            if(self.textEdit1.isEnabled()):
                message = ("1"+mess).encode()
                sock.sendall(message)
                data = sock.recv(512)
                mess = data.decode()
                self.textEdit2.setText(mess)
        elif(self.textEdit2.toPlainText()):
            self.textEdit2.setText("")

    def TextChangeMorze(self):
        mess = self.textEdit2.toPlainText()
        if(mess):
            if(self.textEdit2.isEnabled()):
                message = ("2"+mess).encode()
                sock.sendall(message)
                data = sock.recv(512)
                mess = data.decode()
                self.textEdit1.setText(mess)
        elif(self.textEdit1.toPlainText()):
            self.textEdit1.setText("")