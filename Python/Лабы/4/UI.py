from PyQt5 import QtCore, QtGui, QtWidgets
from PyQt5.QtWidgets import QMessageBox

class Ui_MainWindow(object):
    mainList = []
    def setupUi(self, MainWindow):
        MainWindow.setObjectName("MainWindow")
        MainWindow.resize(989, 607)
        self.centralwidget = QtWidgets.QWidget(MainWindow)
        self.centralwidget.setObjectName("centralwidget")
        self.lineEdit = QtWidgets.QLineEdit(self.centralwidget)
        self.lineEdit.setGeometry(QtCore.QRect(50, 30, 171, 31))
        self.lineEdit.setObjectName("lineEdit")
        self.label = QtWidgets.QLabel(self.centralwidget)
        self.label.setGeometry(QtCore.QRect(50, 10, 171, 20))
        self.label.setAlignment(QtCore.Qt.AlignCenter)
        self.label.setObjectName("label")
        self.lineEdit_2 = QtWidgets.QLineEdit(self.centralwidget)
        self.lineEdit_2.setGeometry(QtCore.QRect(230, 30, 171, 31))
        self.lineEdit_2.setObjectName("lineEdit_2")
        self.label_2 = QtWidgets.QLabel(self.centralwidget)
        self.label_2.setGeometry(QtCore.QRect(230, 10, 171, 20))
        self.label_2.setAlignment(QtCore.Qt.AlignCenter)
        self.label_2.setObjectName("label_2")
        self.label_3 = QtWidgets.QLabel(self.centralwidget)
        self.label_3.setGeometry(QtCore.QRect(410, 10, 171, 20))
        self.label_3.setAlignment(QtCore.Qt.AlignCenter)
        self.label_3.setObjectName("label_3")
        self.lineEdit_4 = QtWidgets.QLineEdit(self.centralwidget)
        self.lineEdit_4.setGeometry(QtCore.QRect(590, 30, 171, 31))
        self.lineEdit_4.setObjectName("lineEdit_4")
        self.label_4 = QtWidgets.QLabel(self.centralwidget)
        self.label_4.setGeometry(QtCore.QRect(590, 10, 171, 20))
        self.label_4.setAlignment(QtCore.Qt.AlignCenter)
        self.label_4.setObjectName("label_4")
        self.label_5 = QtWidgets.QLabel(self.centralwidget)
        self.label_5.setGeometry(QtCore.QRect(770, 10, 211, 20))
        self.label_5.setAlignment(QtCore.Qt.AlignCenter)
        self.label_5.setObjectName("label_5")
        self.pushButtonAddFilm = QtWidgets.QPushButton(self.centralwidget)
        self.pushButtonAddFilm.setGeometry(QtCore.QRect(10, 30, 31, 31))
        self.pushButtonAddFilm.setObjectName("pushButton_3")
        self.pushButtonAddFilm.clicked.connect(self.OnClickAddFilm)
        self.comboBox = QtWidgets.QComboBox(self.centralwidget)
        self.comboBox.setGeometry(QtCore.QRect(410, 30, 171, 31))
        self.comboBox.setObjectName("comboBox")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox_2 = QtWidgets.QComboBox(self.centralwidget)
        self.comboBox_2.setGeometry(QtCore.QRect(770, 30, 211, 31))
        self.comboBox_2.setObjectName("comboBox_2")
        self.comboBox_2.addItem("")
        self.comboBox_2.addItem("")
        self.pushButtonDelFilm = QtWidgets.QPushButton(self.centralwidget)
        self.pushButtonDelFilm.setGeometry(QtCore.QRect(760, 570, 221, 31))
        self.pushButtonDelFilm.setObjectName("pushButton_4")
        self.pushButtonDelFilm.clicked.connect(self.OnClickDelFilm)
        self.tableWidget = QtWidgets.QTableWidget(self.centralwidget)
        self.tableWidget.setGeometry(QtCore.QRect(10, 70, 971, 491))
        self.tableWidget.setObjectName("tableWidget")
        self.tableWidget.setColumnCount(5)
        self.tableWidget.setRowCount(0)
        item = QtWidgets.QTableWidgetItem()
        self.tableWidget.setHorizontalHeaderItem(0, item)
        item = QtWidgets.QTableWidgetItem()
        self.tableWidget.setHorizontalHeaderItem(1, item)
        item = QtWidgets.QTableWidgetItem()
        self.tableWidget.setHorizontalHeaderItem(2, item)
        item = QtWidgets.QTableWidgetItem()
        self.tableWidget.setHorizontalHeaderItem(3, item)
        item = QtWidgets.QTableWidgetItem()
        self.tableWidget.setHorizontalHeaderItem(4, item)
        self.tableWidget.horizontalHeader().setCascadingSectionResizes(True)
        self.tableWidget.horizontalHeader().setDefaultSectionSize(192)
        self.tableWidget.horizontalHeader().setSortIndicatorShown(True)
        self.tableWidget.horizontalHeader().setStretchLastSection(True)
        self.pushButtonShowFilm = QtWidgets.QPushButton(self.centralwidget)
        self.pushButtonShowFilm.setGeometry(QtCore.QRect(450, 570, 221, 31))
        self.pushButtonShowFilm.setObjectName("pushButton")
        self.pushButtonShowFilm.clicked.connect(self.OnClickShowFilm)
        self.lineEdit_3 = QtWidgets.QLineEdit(self.centralwidget)
        self.lineEdit_3.setGeometry(QtCore.QRect(10, 570, 221, 31))
        self.lineEdit_3.setObjectName("lineEdit_3")
        self.pushButtonFindYearFilm = QtWidgets.QPushButton(self.centralwidget)
        self.pushButtonFindYearFilm.setGeometry(QtCore.QRect(240, 570, 111, 31))
        self.pushButtonFindYearFilm.setObjectName("pushButton_2")
        self.pushButtonFindYearFilm.clicked.connect(self.OnClickFindYearFilm)
        MainWindow.setCentralWidget(self.centralwidget)

        self.retranslateUi(MainWindow)
        QtCore.QMetaObject.connectSlotsByName(MainWindow)

    def retranslateUi(self, MainWindow):
        _translate = QtCore.QCoreApplication.translate
        MainWindow.setWindowTitle(_translate("MainWindow", "MainWindow"))
        self.label.setText(_translate("MainWindow", "Код"))
        self.label_2.setText(_translate("MainWindow", "Название"))
        self.label_3.setText(_translate("MainWindow", "Режисёр"))
        self.label_4.setText(_translate("MainWindow", "Год"))
        self.label_5.setText(_translate("MainWindow", "Актёры"))
        self.pushButtonAddFilm.setText(_translate("MainWindow", "+"))
        self.comboBox.setItemText(0, _translate("MainWindow", "Андрей Тарковский"))
        self.comboBox.setItemText(1, _translate("MainWindow", "Кристофер Нолан"))
        self.comboBox.setItemText(2, _translate("MainWindow", "Квентин Тарантино"))
        self.comboBox.setItemText(3, _translate("MainWindow", "Уэс Андерсон"))
        self.comboBox.setItemText(4, _translate("MainWindow", "Дени Вильнёв"))
        self.comboBox_2.setItemText(0, _translate("MainWindow", "Леонардо ДиКаприо"))
        self.comboBox_2.setItemText(1, _translate("MainWindow", "Кевин Спейси"))
        self.pushButtonDelFilm.setText(_translate("MainWindow", "Удалить выбранный элемент"))
        item = self.tableWidget.horizontalHeaderItem(0)
        item.setText(_translate("MainWindow", "Код"))
        item = self.tableWidget.horizontalHeaderItem(1)
        item.setText(_translate("MainWindow", "Название"))
        item = self.tableWidget.horizontalHeaderItem(2)
        item.setText(_translate("MainWindow", "Режиссёр"))
        item = self.tableWidget.horizontalHeaderItem(3)
        item.setText(_translate("MainWindow", "Год выхода"))
        item = self.tableWidget.horizontalHeaderItem(4)
        item.setText(_translate("MainWindow", "Актёры"))
        self.pushButtonShowFilm.setText(_translate("MainWindow", "Отобразить весь список"))
        self.pushButtonFindYearFilm.setText(_translate("MainWindow", "Поиск"))

    def OnClickAddFilm(self):
        lerr = self.Params()
        del lerr['self']
        self.mainList.append(film(**lerr))
        self.OnClickShowFilm()

    def OnClickDelFilm(self):
        print(self.tableWidget.currentRow())
        try:
            self.mainList.pop(self.tableWidget.currentRow())
        except IndexError:
            QMessageBox.critical(self, "Ошибка ", "Выделенно не то что нужно", QMessageBox.Ok)
            return
        self.OnClickShowFilm()

    def OnClickShowFilm(self):
        self.tableWidget.setRowCount(0)
        for llist in self.mainList:
            self.ShowElementList(llist)

    def ShowElementList(self,llist):
        try:
            str1 = llist.code
        except AttributeError:
            str1 = "Не указано"
        try:
            str2 = llist.name
        except AttributeError:
            str2 = "Не указано"
        try:
            str3 = llist.director
        except AttributeError:
            str3 = "Не указано"
        try:
            str4 = llist.releaseDate
        except AttributeError:
            str4 = "Не указано"
        try:
            str5 = llist.actors
        except AttributeError:
            str5 = "Не указано"
        rowPosition = self.tableWidget.rowCount()
        self.tableWidget.insertRow(rowPosition)

        self.tableWidget.setItem(rowPosition, 0, QtWidgets.QTableWidgetItem(str1)) 
        self.tableWidget.setItem(rowPosition, 1, QtWidgets.QTableWidgetItem(str2))
        self.tableWidget.setItem(rowPosition, 2, QtWidgets.QTableWidgetItem(str3))
        self.tableWidget.setItem(rowPosition, 3, QtWidgets.QTableWidgetItem(str4))
        self.tableWidget.setItem(rowPosition, 4, QtWidgets.QTableWidgetItem(str5))

    def OnClickFindYearFilm(self):
        self.tableWidget.setRowCount(0)
        year = self.lineEdit_3.text()
        for llist in self.mainList:
            try:
                if(llist.releaseDate == year):
                    self.ShowElementList(llist)
            except AttributeError:
                pass

    def Params(self):
        print(locals())
        code = self.lineEdit.text()
        if(code==""):
            locals()["code"] = code
        name = self.lineEdit_2.text()
        if(name==""):
            locals()["name"] = name
        director = self.comboBox.currentText()
        if(director == ""):
            locals()["director"] = director
        releaseDate = self.lineEdit_4.text()
        if(releaseDate == ""):
            locals()["releaseDate"] = releaseDate
        actors = self.comboBox_2.currentText()
        if(actors == ""):
            locals()["actors"] = actors
        print(locals())
        return locals()

class film:
    def __init__(self, **kwargs):
        for key in kwargs:
            setattr(self, key, kwargs[key])