import math as m

def InputArgument(argument):
	return int(input("Введите переменную "+argument+": "))

while True:
	try:
		a = InputArgument("a")
		n = InputArgument("n")
		x = InputArgument("x")
		break
	except :
		print("Что-то пошло не так, повторите пожалуйста")
answer = 5*m.pow(a,n*x)/(n+x)-(m.sqrt(m.fabs(m.cos(m.pow(x,m.pow(3,n))))))
print (answer)
