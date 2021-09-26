from PyQt5 import QtCore, QtGui, QtWidgets
import pymysql
'''con = pymysql.connect(host='localhost',
    user='root',
    password='1234',
    database='films',
    charset='utf8mb4')'''
countries=list()
class Ui_MainWindow(object):
    def setupUi(self, MainWindow):
        MainWindow.setObjectName("MainWindow")
        MainWindow.resize(232, 505)
        MainWindow.setMaximumSize(QtCore.QSize(16777210, 16777215))
        self.centralwidget = QtWidgets.QWidget(MainWindow)
        self.centralwidget.setObjectName("centralwidget")
        self.lineEdit_2 = QtWidgets.QLineEdit(self.centralwidget)
        self.lineEdit_2.setEnabled(False)
        self.lineEdit_2.setGeometry(QtCore.QRect(10, 10, 211, 160))
        self.lineEdit_2.setObjectName("lineEdit_2")
        self.groupBoxAddFil = QtWidgets.QGroupBox(self.centralwidget)
        self.groupBoxAddFil.setGeometry(QtCore.QRect(10, 220, 211, 280))
        self.groupBoxAddFil.setTitle("")
        self.groupBoxAddFil.setObjectName("groupBoxAddFil")
        self.lineEdit = QtWidgets.QLineEdit(self.groupBoxAddFil)
        self.lineEdit.setGeometry(QtCore.QRect(0, 20, 211, 31))
        self.lineEdit.setObjectName("lineEdit")
        self.dateEdit = QtWidgets.QDateEdit(self.groupBoxAddFil)
        self.dateEdit.setGeometry(QtCore.QRect(0, 70, 211, 31))
        self.dateEdit.setObjectName("dateEdit")
        self.pushButtonAddCountry = QtWidgets.QPushButton(self.groupBoxAddFil)
        self.pushButtonAddCountry.setGeometry(QtCore.QRect(0, 170, 31, 31))
        self.pushButtonAddCountry.setObjectName("pushButtonAddCountry")
        self.pushButtonAddCountry.clicked.connect(self.OnClickAddCountry)
        self.lineEdit_3 = QtWidgets.QLineEdit(self.groupBoxAddFil)
        self.lineEdit_3.setGeometry(QtCore.QRect(0, 210, 211, 21))
        self.lineEdit_3.setObjectName("lineEdit_3")
        self.lineEdit_3.setEnabled(False)
        self.pushButtonDelCountry = QtWidgets.QPushButton(self.groupBoxAddFil)
        self.pushButtonDelCountry.setGeometry(QtCore.QRect(180, 170, 31, 31))
        self.pushButtonDelCountry.setObjectName("pushButtonDelCountry")
        self.pushButtonDelCountry.clicked.connect(self.OnClickDelCountry)
        self.label = QtWidgets.QLabel(self.groupBoxAddFil)
        self.label.setGeometry(QtCore.QRect(70, 0, 71, 21))
        self.label.setAlignment(QtCore.Qt.AlignCenter)
        self.label.setObjectName("label")
        self.label_2 = QtWidgets.QLabel(self.groupBoxAddFil)
        self.label_2.setGeometry(QtCore.QRect(70, 50, 71, 21))
        self.label_2.setAlignment(QtCore.Qt.AlignCenter)
        self.label_2.setObjectName("label_2")
        self.pushButtonAddFilm = QtWidgets.QPushButton(self.groupBoxAddFil)
        self.pushButtonAddFilm.setGeometry(QtCore.QRect(40, 240, 131, 31))
        self.pushButtonAddFilm.setObjectName("pushButtonAddFilm")
        self.label_4 = QtWidgets.QLabel(self.groupBoxAddFil)
        self.label_4.setGeometry(QtCore.QRect(70, 100, 71, 21))
        self.label_4.setAlignment(QtCore.Qt.AlignCenter)
        self.label_4.setObjectName("label_4")
        self.comboBoxDirector = QtWidgets.QComboBox(self.groupBoxAddFil)
        self.comboBoxDirector.setGeometry(QtCore.QRect(0, 120, 211, 31))
        self.comboBoxDirector.setObjectName("comboBoxDirector")
        '''cur.execute("SELECT firstname,lastname FROM director")
        rows = cur.fetchall()
        ''for row in rows:
            self.comboBoxDirector.addItems([row[0]+" "+row[1]])'''
        self.comboBoxDirector.addItems(["Андрей Тарковский", "Кристофер Нолан","Квентин Тарантино", "Уэс Андерсон", "Дени Вильнёв"])
        self.comboBoxCountry = QtWidgets.QComboBox(self.groupBoxAddFil)
        self.comboBoxCountry.setGeometry(QtCore.QRect(40, 170, 131, 31))
        self.comboBoxCountry.setObjectName("comboBoxCountry")
        self.comboBoxCountry.addItems(["Россия","США","Великобритания","Канада"])
        self.label_3 = QtWidgets.QLabel(self.groupBoxAddFil)
        self.label_3.setGeometry(QtCore.QRect(70, 150, 71, 21))
        self.label_3.setAlignment(QtCore.Qt.AlignCenter)
        self.label_3.setObjectName("label_3")
        self.comboBoxFilm = QtWidgets.QComboBox(self.centralwidget)
        self.comboBoxFilm.setGeometry(QtCore.QRect(10, 180, 170, 31))
        self.comboBoxFilm.setObjectName("comboBoxFilm")
        self.pushButtonDelFilm = QtWidgets.QPushButton(self.centralwidget)
        self.pushButtonDelFilm.setGeometry(QtCore.QRect(190, 180, 31, 31))
        self.pushButtonDelFilm.setObjectName("pushButtonDelFilm")
        self.pushButtonDelFilm.clicked.connect(self.OnClickDelFilm)
        self.pushButtonAddFilm.clicked.connect(self.OnClickAddFilm)
        MainWindow.setCentralWidget(self.centralwidget)

        self.retranslateUi(MainWindow)
        QtCore.QMetaObject.connectSlotsByName(MainWindow)

    def retranslateUi(self, MainWindow):
        _translate = QtCore.QCoreApplication.translate
        MainWindow.setWindowTitle(_translate("MainWindow", "База данных фильмов"))
        self.pushButtonAddCountry.setText(_translate("MainWindow", "+"))
        self.pushButtonDelCountry.setText(_translate("MainWindow", "-"))
        self.label.setText(_translate("MainWindow", "Название"))
        self.label_2.setText(_translate("MainWindow", "Дата выхода"))
        self.pushButtonAddFilm.setText(_translate("MainWindow", "Дабавить"))
        self.label_4.setText(_translate("MainWindow", "Режиссёр"))
        self.label_3.setText(_translate("MainWindow", "Страны"))
        self.pushButtonDelFilm.setText(_translate("MainWindow", "-"))

    def OnClickAddFilm(self):
        #cur = con.cursor()
        print("INSERT INTO film(name,director_id) VALUES ('"+self.lineEdit.text()+"','"+str(self.comboBoxDirector.currentIndex()+1)+"')")
        #cur.execute("INSERT INTO film(name,director_id) VALUES ('"+self.lineEdit.text()+"','"+str(self.comboBoxDirector.currentIndex()+1)+"')");

    def OnClickDelFilm(self):
        print("DELETE ")

    def OnClickAddCountry(self):
        textInComboBoxCountry = self.comboBoxCountry.currentText()
        if(countries):
            for country in countries:
                if(textInComboBoxCountry==country):
                    return
            countries.append(textInComboBoxCountry)
            self.lineEdit_3.setText(self.lineEdit_3.text()+textInComboBoxCountry+";") 
        else:
            countries.append(textInComboBoxCountry)
            self.lineEdit_3.setText(self.lineEdit_3.text()+textInComboBoxCountry+";") 

    def OnClickDelCountry(self):
        textInComboBoxCountry = self.comboBoxCountry.currentText()
        self.lineEdit_3.setText("")
        print("!")
        for country in countries:
            print(country)
        print("!")
        for country in countries:
            if(textInComboBoxCountry==country):
                countries.remove(country)
        for country in countries:
            self.lineEdit_3.setText(self.lineEdit_3.text()+country+";")



'''
cur = con.cursor()
    
    cur.execute("INSERT INTO country(name) VALUES ('Россия')");'''