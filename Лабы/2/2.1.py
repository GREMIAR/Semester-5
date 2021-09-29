import math as m

def InputArgument(argument):
	while True:
		try:
			return int(input("Введите переменную "+argument+": "))
		except:
			print("Что-то при вводе переменной " + argument + " пошло не так")

Answer = lambda a,n,x: 5*m.pow(a,n*x)/(n+x)-(m.sqrt(m.fabs(m.cos(m.pow(x,m.pow(3,n))))))

a = InputArgument("a")
n = InputArgument("n")
x = InputArgument("x")
try:
	print (Answer(a,n,x))
except ZeroDivisionError:
	print ("Попытка деления на 0")