class film:
	def __init__(self, **kwargs):
		for key in kwargs:
			setattr(self, key, kwargs[key])
	def printElement(self):
		try:
			str1 = self.code
		except AttributeError:
			str1 = "Не указано"
		try:
			str2 = self.name
		except AttributeError:
			str2 = "Не указано"
		try:
			str3 = self.director
		except AttributeError:
			str3 = "Не указано"
		try:
			str4 = self.releaseDate
		except AttributeError:
			str4 = "Не указано"
		try:
			str5 = self.actors
		except AttributeError:
			str5 = "Не указано"
		print("Код: "+ str(str1) +"; Название: "+ str(str2) +"; Режиссёр: "+ str(str3) +"; Дата выхода: "+ str(str4) +"; Главный актёр: "+ str(str5) +";")

def PrintMenuItem(number,menuItem):
	print(str(number) + ") " + menuItem + ": ")
	return number+1

def PrintMenu():
	print("\n\n\nМеню:\n")
	number = 1
	number = PrintMenuItem(number,"Добавление информации в список")
	number = PrintMenuItem(number,"Удаление информации о выбранном объекте списка")
	number = PrintMenuItem(number,"Отображение информации обо всех объектах списка в удобном виде")
	number = PrintMenuItem(number,"Поиск фильмов указанного пользователем года выпуска")

def Input(str=""):
	return input ("Ввод"+str+": ")

def InputInt(str=""):
	while True:
		try:
			return int(Input(str))
		except :
			print("Что-то пошло не так, повторите пожалуйста")

def Question(question):
	print(question)
	answer=InputInt(" Да-1, Нет-2")
	if(answer==1):
		return True
	return False

def Add(mainList):
	mainList.append(film(**Params()))

def Del(mainList):
	Show(mainList)
	print("Какой эллемент удалить?")
	try:
		mainList.remove(mainList[InputInt()])
	except IndexError:
		print("Нет такого элемента")

def FindYear(mainList):
	year = InputInt(" года")
	for llist in mainList:
		try:
			if(llist.releaseDate == year):
				llist.printElement()
		except AttributeError:
			pass

def Show(mainList):
	if(mainList):
		for llist in mainList:
			llist.printElement()
	else:
		print("Список пуст")

def Params():
	print(locals())
	if(Question("Ввести код?")):
		locals()["code"] = InputInt()
	if(Question("Ввести название?")):
		locals()["name"] = Input()
	if(Question("Ввести режисёра?")):
		locals()["director"] = Input()
	if(Question("Ввести год выпуска?")):
		locals()["releaseDate"] = InputInt()
	if(Question("Ввести актёров?")):
		locals()["actors"] = Input()
	return locals()

def MenuItem(menuItem, mainList):
	if(menuItem == "exit"):
		raise SystemExit
	elif(menuItem == "1"):
		Add(mainList)
	elif(menuItem == "2"):
		Del(mainList)
	elif(menuItem == "3"):
		Show(mainList)
	elif(menuItem == "4"):
		FindYear(mainList)
	else:
		print("Нет такого пукнта")

mainList = []
while True:
	PrintMenu()
	MenuItem(Input(), mainList)