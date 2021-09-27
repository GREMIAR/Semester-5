def PrintMenuItem(number,menuItem):
	print(str(number) + ") " + menuItem + ": ")
	return number+1

def PrintMenu():
	print("\n\n\nМеню:\n")
	number = 1
	number = PrintMenuItem(number,"Показать значение списка")
	number = PrintMenuItem(number,"Добавить новый элемент в конец списка")
	number = PrintMenuItem(number,"Удаление указанного элемента")
	number = PrintMenuItem(number,"Сформировать кортеж, сотроящий из вещественных чисел меньших 100")
	number = PrintMenuItem(number,"Найти произведение всех целочисленных отрицательных элементов списка")
	number = PrintMenuItem(number,"Из сформировать строки (значений элементов списка), посчитать сколько раз встречается в строке указанное слово")
	number = PrintMenuItem(number,"Задать с клавиатуры множество M1, сформировать множество M2 из списка; вывести на экран симметричную разницу множеств M1 и M2")
	number = PrintMenuItem(number,"Получить из списка словарь, ключом каждого элемента сделать позицию элемента в словаре; построчно отобразить на экране элементы словаря с нечетными значениями ключа")

def Input(str=""):
	return input ("Ввод"+str+": ")

def InputInt(str=""):
	while True:
		try:
			return int(Input(str))
		except :
			print("Что-то пошло не так, повторите пожалуйста")

def MenuItem(menuItem, mainList):
	if(menuItem == "exit"):
		raise SystemExit
	elif(menuItem == "1"):
		ShowTheList(mainList)
	elif(menuItem == "2"):
		AddToEndOfList(mainList, Input(" элемента для добавления"))
	elif(menuItem == "3"):
		ShowTheList(mainList)
		answer = Input(", по индексу - 1, по значению - 2")
		if(answer=="1"):
			DelByIndexList(mainList, InputInt(" индекса"))
		elif(answer=="2"):
			DelByValueList(mainList, Input(" значания переменной"))
		else:
			print("Почему?")
	elif(menuItem == "4"):
		OnlyNumbersLess100(mainList)
	elif(menuItem == "5"):
		FindProductNumbers(mainList)
	elif(menuItem == "6"):
		CountSubstringInString(mainList)
	elif(menuItem == "7"):
		DifferenceOfSets(mainList)
	elif(menuItem == "8"):
		ShowOddNumbers(mainList)
	else:
		print("Нет такого пукнта")
	
def ShowTheList(mainList):
	print(mainList)	

def AddToEndOfList(mainList, item):
	mainList.append(item)

def DelByIndexList(mainList, index):
	try:
		mainList.pop(index)
	except IndexError:
		print("Такого индекса нет в списке")
	ShowTheList(mainList)

def DelByValueList(mainList, value):
	try:
		mainList.remove(value)
	except ValueError:
		print("Элемент не найден")
	ShowTheList(mainList)

def OnlyNumbersLess100(mainList):
	numbersLess100 = tuple()
	for n in mainList:
		if(IsNumberLess100(n)):
			numbersLess100 += (n,)
	print("Числа меньше 100:", numbersLess100)

def IsNumberLess100(number):
    try:
    	if(number<100):
    		return True
    	else:
    		return False
    except TypeError:
    	return False

def FindProductNumbers(mainList):
	productNumbers = 1;
	count = 0;
	for n in mainList:
		if(NegativeInteger(n)):
			count+=1
			productNumbers*=n
	if(count > 0):
		print(productNumbers)
	else:
		print("В списке нет орицательных челых чисел")

def NegativeInteger(number):
	try:
		if(number % 1 == 0 and number<0):
			return True
		return False
	except TypeError:
		return False

def CountSubstringInString(mainList):
	string = ""
	for n in mainList:
		string+=str(n)
	substring = Input(" подстроки")
	print("Всего подстрока ("+ substring +") встречается " + str(FindSubstring(string,substring,0)) + " раз(а) в строке ("+ string +")")

def FindSubstring(string,substring,count):
	index = string.find(substring)
	while (index !=-1):
		count+=1
		index+=1
		index = string.find(substring,index)
	return count

def DifferenceOfSets(mainList):
	set1 = {1,2,4,5}
	set2 = set()
	for n in mainList:
		if(isinstance(n, list)):
			n=str(n)
		set2.add(n)
	print(set1)
	print(set2)
	print(set1.symmetric_difference(set2))

def ShowOddNumbers(mainList):
	myDict = {}
	for idx,value in enumerate(mainList):
		myDict[idx] = value
	for idx, value in myDict.items():
		if(idx%2==1):
			print(value)

#mainList = ['1', "123", ['243'], "fsf", 23, -1]
mainList = ['1', "123", ['243'], "fsf"]
#mainList = [1, "123", ['243'], "fsf"]
while True:
	PrintMenu()
	MenuItem(Input(), mainList)
