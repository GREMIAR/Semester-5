import math as m
def PrintMenuItem(letter,menuItem):
	print("«" + letter + "» - " + menuItem)

def PrintMenu():
	print("\n\nМеню:\n")
	PrintMenuItem("R","Площадь прямоугольника")
	PrintMenuItem("T","Площадь треугольника")
	PrintMenuItem("M","Площадь многоугольника")
	PrintMenuItem("E","Выход из программы")

def Input(str=""):
	return input ("Ввод"+str+": ")

def InputInt(str=""):
	while True:
		try:
			return int(Input(str))
		except :
			print("Что-то пошло не так, повторите пожалуйста")

def MenuItem(menuItem):
	if(menuItem == "E"):
		raise SystemExit
	elif(menuItem == "R"):
		RectangleArea(InputInt(" высоты фигуры"),InputInt(" ширины фигуры"))
	elif(menuItem == "T"):
		TriangleArea(InputInt(" первой стороны фигуры"), InputInt(" второй стороны фигуры"), InputInt(" третей стороны фигуры"))
	elif(menuItem == "M"):
		PolygonArea(InputInt(" длины сторон многоугольника"), InputInt(" количества сторон многоугольника"))
	else:
		print("Нет такого пукнта")

def RectangleArea(height, width):
	print(height,"x",width," = ", height*width) 

def TriangleArea(first, second, third):
	p = (first+second+third)/2
	print("(",first,"+",second,"+",third,")/2 =",p)
	s = m.sqrt(p*(p-first)*(p-second)*(p-third))
	print("√("+str(p)+Pminus(p,first)+Pminus(p,second)+Pminus(p,third)+") =",s)

def Pminus(p,arg):
	return ("*("+str(p)+"-"+str(arg)+")")

def PolygonArea(a,n):
	s=n*m.pow(a,2)/(4*(m.tan(m.radians(180/n))))
	print("("+str(n)+"*"+str(a) + "^(2))"+"/(4*tg(180/"+str(n)+")) = " + str(s))

while True:
	PrintMenu()
	MenuItem(Input())