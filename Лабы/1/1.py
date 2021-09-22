import math as m

def InputArgument(argument):
	while True:
		try:
			return int(input("Введите переменную "+argument+": "))
		except:
			print("Что-то при вводе переменной " + argument + " пошло не так")

a = InputArgument("a")
n = InputArgument("n")
x = InputArgument("x")
try:
	answer = 5*m.pow(a,n*x)/(n+x)-(m.sqrt(m.fabs(m.cos(m.pow(x,m.pow(3,n))))))
	print (answer)
except ZeroDivisionError:
	print ("Попытка деления на 0")
