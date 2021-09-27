from PyQt5 import QtCore, QtGui, QtWidgets
import pymysql
con = pymysql.connect(host='localhost',
    user='root',
    password='1234',
    database='films',
    charset='utf8mb4')

countryDict = {"Россия":"1", "США":"2", "Великобритания":"3", "Канада":"4"}
cur = con.cursor()
countries=list()
id_film = 1
class Ui_MainWindow(object):
    def setupUi(self, MainWindow):
        MainWindow.setObjectName("MainWindow")
        MainWindow.resize(230, 505)
        MainWindow.setMaximumSize(QtCore.QSize(16777210, 16777215))
        self.centralwidget = QtWidgets.QWidget(MainWindow)
        self.centralwidget.setObjectName("centralwidget")
        self.groupBoxAddFil = QtWidgets.QGroupBox(self.centralwidget)
        self.groupBoxAddFil.setGeometry(QtCore.QRect(10, 220, 211, 280))
        self.groupBoxAddFil.setTitle("")
        self.groupBoxAddFil.setObjectName("groupBoxAddFil")
        self.textEditFilms = QtWidgets.QTextEdit(self.centralwidget)
        self.textEditFilms.setGeometry(QtCore.QRect(10, 10, 211, 160))
        self.textEditFilms.setObjectName("textEditFilms")
        self.textEditFilms.setLineWrapMode(QtWidgets.QTextEdit.NoWrap)
        self.lineEditName = QtWidgets.QLineEdit(self.groupBoxAddFil)
        self.lineEditName.setGeometry(QtCore.QRect(0, 20, 211, 31))
        self.lineEditName.setObjectName("lineEditName")
        self.dateEdit = QtWidgets.QDateEdit(self.groupBoxAddFil)
        self.dateEdit.setGeometry(QtCore.QRect(0, 70, 211, 31))
        self.dateEdit.setObjectName("dateEdit")
        self.pushButtonAddCountry = QtWidgets.QPushButton(self.groupBoxAddFil)
        self.pushButtonAddCountry.setGeometry(QtCore.QRect(0, 170, 31, 31))
        self.pushButtonAddCountry.setObjectName("pushButtonAddCountry")
        self.pushButtonAddCountry.clicked.connect(self.OnClickAddCountry)
        self.lineEditCountry = QtWidgets.QLineEdit(self.groupBoxAddFil)
        self.lineEditCountry.setGeometry(QtCore.QRect(0, 210, 211, 21))
        self.lineEditCountry.setObjectName("lineEditCountry")
        self.lineEditCountry.setEnabled(False)
        self.pushButtonDelCountry = QtWidgets.QPushButton(self.groupBoxAddFil)
        self.pushButtonDelCountry.setGeometry(QtCore.QRect(180, 170, 31, 31))
        self.pushButtonDelCountry.setObjectName("pushButtonDelCountry")
        self.pushButtonDelCountry.clicked.connect(self.OnClickDelCountry)
        self.label = QtWidgets.QLabel(self.groupBoxAddFil)
        self.label.setGeometry(QtCore.QRect(0, 0, 211, 21))
        self.label.setAlignment(QtCore.Qt.AlignCenter)
        self.label.setObjectName("label")
        self.label_2 = QtWidgets.QLabel(self.groupBoxAddFil)
        self.label_2.setGeometry(QtCore.QRect(0, 50, 211, 21))
        self.label_2.setAlignment(QtCore.Qt.AlignCenter)
        self.label_2.setObjectName("label_2")
        self.pushButtonAddFilm = QtWidgets.QPushButton(self.groupBoxAddFil)
        self.pushButtonAddFilm.setGeometry(QtCore.QRect(40, 240, 131, 31))
        self.pushButtonAddFilm.setObjectName("pushButtonAddFilm")
        self.label_4 = QtWidgets.QLabel(self.groupBoxAddFil)
        self.label_4.setGeometry(QtCore.QRect(0, 100, 211, 21))
        self.label_4.setAlignment(QtCore.Qt.AlignCenter)
        self.label_4.setObjectName("label_4")
        self.comboBoxDirector = QtWidgets.QComboBox(self.groupBoxAddFil)
        self.comboBoxDirector.setGeometry(QtCore.QRect(0, 120, 211, 31))
        self.comboBoxDirector.setObjectName("comboBoxDirector")
        cur.execute("SELECT firstname,lastname FROM director")
        rows = cur.fetchall()
        for row in rows:
            self.comboBoxDirector.addItems([row[0]+" "+row[1]])
        self.comboBoxCountry = QtWidgets.QComboBox(self.groupBoxAddFil)
        self.comboBoxCountry.setGeometry(QtCore.QRect(40, 170, 131, 31))
        self.comboBoxCountry.setObjectName("comboBoxCountry")
        cur.execute("SELECT name FROM country")
        rows = cur.fetchall()
        for row in rows:
            self.comboBoxCountry.addItems([row[0]])
        self.label_3 = QtWidgets.QLabel(self.groupBoxAddFil)
        self.label_3.setGeometry(QtCore.QRect(0, 150, 211, 21))
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
        global id_film
        cur.execute("INSERT INTO film(film_id,name,director_id) VALUES ('"+str(id_film)+"','"+self.lineEditName.text()+"','"+str(self.comboBoxDirector.currentIndex()+1)+"')");
        for country in countries:
            cur.execute("INSERT INTO film_country(film_id,country_id) VALUES ('"+str(id_film)+"','"+ countryDict[country] +"')");
        self.ShowFilms()
        id_film+=1

    def ShowFilms(self):
        cur.execute("SELECT film_id,f.name,release_date,firstname,lastname,c.name FROM film f JOIN director d USING(director_id) JOIN country c USING(country_id)")
        rows = cur.fetchall()
        self.textEditFilms.setText("")
        for row in rows:
            cur.execute("SELECT c.name FROM film_country fc JOIN film f USING(film_id) JOIN country c USING(country_id) WHERE f.film_id="+str(row[0]))
            rows1 = cur.fetchall()
            str1=""
            for row1 in rows1:
                for r in row1:
                    str1+=str(r)+";"
            self.textEditFilms.setText(self.textEditFilms.toPlainText()+"Название: "+row[1]+"; Дата выхода: "+str(row[2])+"; Режиссёр: "+ row[3]+" "+row[4] +" из " + row[5] + "; Страны которые участвоаали в создании: " +str1+"\n")
            print("Название: "+row[1]+"; Дата выхода: "+str(row[2])+"; Режиссёр: "+ row[3]+" "+row[4] +" из " + row[5] + "; Страны которые участвоаали в создании: " +str1)
        cur.execute("SELECT name FROM film")
        rows = cur.fetchall()
        self.comboBoxFilm.clear()
        for row in rows:
            self.comboBoxFilm.addItems([row[0]])
        self.lineEditCountry.setText("")
        self.lineEditName.setText("")
        countries.clear()


    def OnClickDelFilm(self):
        global id_film
        print("DELETE FROM film_country WHERE film_id=(SELECT film_id FROM film WHERE name='"+self.comboBoxFilm.currentText()+"' LIMIT 1);")
        cur.execute("DELETE FROM film_country WHERE film_id=(SELECT film_id FROM film WHERE name='"+self.comboBoxFilm.currentText()+"' LIMIT 1);")
        cur.execute("DELETE FROM film WHERE name='"+self.comboBoxFilm.currentText()+"';")
        id_film-=1
        self.ShowFilms()

    def OnClickAddCountry(self):
        textInComboBoxCountry = self.comboBoxCountry.currentText()
        if(countries):
            for country in countries:
                if(textInComboBoxCountry==country):
                    return
            countries.append(textInComboBoxCountry)
            self.lineEditCountry.setText(self.lineEditCountry.text()+textInComboBoxCountry+";") 
        else:
            countries.append(textInComboBoxCountry)
            self.lineEditCountry.setText(self.lineEditCountry.text()+textInComboBoxCountry+";") 

    def OnClickDelCountry(self):
        textInComboBoxCountry = self.comboBoxCountry.currentText()
        self.lineEditCountry.setText("")
        for country in countries:
            if(textInComboBoxCountry==country):
                countries.remove(country)
        for country in countries:
            self.lineEditCountry.setText(self.lineEditCountry.text()+country+";")