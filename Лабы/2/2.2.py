import math as m

L = [['R','r','M','T','T','E'],[1,2,5],[1,23],[5,5,5],[1,1,1],[2,2,2],[1]]#[3,3],[1,1,1],[2,4],[1,1,1],[1,1,1],[1]]


idx = 1

PrintMenuItem = lambda letter,menuItem: print("«" + letter + "» - " + menuItem)

PrintMenu = lambda: [print("\n\nМеню:\n"), PrintMenuItem("R","Площадь прямоугольника"),PrintMenuItem("T","Площадь треугольника"),PrintMenuItem("M","Площадь многоугольника"),PrintMenuItem("E","Выход из программы")]

Input = lambda str="": input ("Ввод"+str+": ")

def InputInt(str=""):
	while True:
		try:
			return int(Input(str))
		except :
			print("Что-то пошло не так, повторите пожалуйста")

def MenuItem(Li):
	print("Пункт: "+Li)
	global idx
	if(Li[0] == "E"):
		raise SystemExit
	elif(Li[0] == "R"):
		print(L[idx][1])
		print(L[idx][0])
		RectangleArea(L[idx][0],L[idx][1])
		idx+=1
	elif(Li[0] == "T"):
		first = L[idx][0]
		second = L[idx][1]
		third = L[idx][2]
		p = P(first,second,third)
		s = St(first,second,third,p)
		TriangleArea(first,second,third,p,s)
		idx+=1
	elif(Li[0] == "M"):
		a = L[idx][0]
		n = L[idx][1]
		s = Sp(a,n)
		PolygonArea(a,n,s)
		idx+=1
	else:
		print("Нет такого пукнта")
		idx+=1

RectangleArea = lambda height,width:print(height,"x",width," = ", height*width) 

P = lambda first, second, third:(first+second+third)/2

St = lambda first,second,third,p: m.sqrt(p*(p-first)*(p-second)*(p-third))

TriangleArea = lambda first, second, third,p,s: [print("(",first,"+",second,"+",third,")/2 =",p),print("√("+str(p)+Pminus(p,first)+Pminus(p,second)+Pminus(p,third)+") =",s)]

Pminus = lambda p,arg: ("*("+str(p)+"-"+str(arg)+")")

Sp = lambda a,n: n*m.pow(a,2)/(4*(m.tan(m.radians(180/n))))

PolygonArea = lambda a,n,s: [print("("+str(n)+"*"+str(a) + "^(2))"+"/(4*tg(180/"+str(n)+")) = " + str(s))]

while True:
	PrintMenu()
	fdsfsd = list(map(MenuItem,L[0]))

