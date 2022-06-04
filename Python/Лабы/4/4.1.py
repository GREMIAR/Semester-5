from PyQt5 import QtWidgets
import UI
import sys

class ExampleApp(QtWidgets.QMainWindow, UI.Ui_MainWindow):
	def __init__(self):
		super().__init__()
		self.setupUi(self)

def main():
	app = QtWidgets.QApplication(sys.argv)
	window = ExampleApp()
	window.show()
	app.exec_()

if __name__ == '__main__':
	main()

