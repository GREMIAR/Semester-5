import math as m

L = [['R','r','M','T','T','E'],[1,2,5],[1,23],[5,5,5],[1,1,1],[2,2,2],[1]]

PrintMenuItem = lambda letter,menuItem: print("«" + letter + "» - " + menuItem)

PrintMenu = lambda: [print("\n\nМеню:\n"), PrintMenuItem("R","Площадь прямоугольника"),PrintMenuItem("T","Площадь треугольника"),PrintMenuItem("M","Площадь многоугольника"),PrintMenuItem("E","Выход из программы")]

RectangleArea = lambda height,width:print(height,"x",width," = ", height*width) 

P = lambda first, second, third:(first+second+third)/2

St = lambda first,second,third,p: m.sqrt(p*(p-first)*(p-second)*(p-third))

TriangleArea = lambda first, second, third,p,s: [print("(",first,"+",second,"+",third,")/2 =",p),print("√("+str(p)+Pminus(p,first)+Pminus(p,second)+Pminus(p,third)+") =",s)]

Pminus = lambda p,arg: ("*("+str(p)+"-"+str(arg)+")")

Sp = lambda a,n: n*m.pow(a,2)/(4*(m.tan(m.radians(180/n))))

PolygonArea = lambda a,n,s: [print("("+str(n)+"*"+str(a) + "^(2))"+"/(4*tg(180/"+str(n)+")) = " + str(s))]

Area = {
   'R' : (lambda sides:print(sides[0],"x",sides[1]," = ", sides[0]*sides[1])) ,
   'E' : (lambda: os._exit),
   'T' : (lambda sides: TriangleArea(sides[0], sides[1], sides[2],P(sides[0], sides[1], sides[2]),St(sides[0], sides[1], sides[2],P(sides[0], sides[1], sides[2])))),
   'M' : (lambda data: PolygonArea(data[0],data[1],Sp(data[0],data[1])))
    }

def MenuItem(im,li):
	print("\nПункт: "+im)
	try:
		Area[im](li)
	except:
		print("Нет такого пукнта")

PrintMenu()
for index, item in enumerate(L[0]):
	MenuItem(L[0][index],L[index+1])
