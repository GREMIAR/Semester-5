import socket
import sys

morseDict = { 
"А":"*-"   ,"Б":"-***"   ,
"В":"-**"  ,"Г":"--*"    ,
"Д":"-**"  ,"Е":"*"      ,
"Ё":"*"    ,"Ж":"***-"   ,
"З":"--**" ,"И":"**"     ,
"Й":"*---" ,"К":"-*-"    ,
"Л":"*-**" ,"М":"--"     ,
"Н":"-*"   ,"О":"---"    ,
"П":"*--*" ,"Р":"*-*"    ,
"С":"***"  ,"Т":"−"      ,
"У":"**-"  ,"Ф":"**-*"   ,
"Х":"****" ,"Ц":"-*-*"   ,
"Ч":"---*" ,"Ш":"----"   ,
"Щ":"--*-" ,"Ъ":"--*--"  ,
"Ы":"-*--" ,"Ь":"-**-"   ,
"Э":"**-**","Ю":"**--"   ,
"Я":"*-*-" ,"!":"--**--" ,
"A":"*-"   , "B":"-*"    ,
"C":"-*-*" , "D":"-*"    ,
"E":"*"    , "F":"*-*"   , 
"G":"--*"  , "H":"*"     ,
"I":"*"    , "J":"*---"  ,
"K":"-*-"  , "L":"*-*"   ,
"M":"--"   , "N":"-*"    ,
"O":"---"  , "P":"*--*"  ,
"Q":"--*-" , "R":"*-*"   ,
"S":"*"    , "T":"-"     ,
"U":"*-"   , "V":"*-"    ,
"W":"*--"  , "X":"-*-"   , 
"Y":"-*--" , "Z":"--*"   ,
"1":"*----", "2":"*---"  ,
"3":"*--"  , "4":"*-"    , 
"5":"*"    , "6":"-*"    ,
"7":"--*"  , "8":"---*"  ,
"9":"----*", "0":"-----" ,
",":"--*--", "*":"*-*-*-",
"?":"*--*" , "/":"-*-*"  ,
"-":"-*-"  , "(":"-*--*" , 
")":"-*--*-"
} 

def Normal(data):
    str1 = ""
    data=data.upper()
    for letter in data:
        try:
            str1+=morseDict[letter]
        except KeyError:
            str1+=str(letter)
    return(str1)

def Morze(data):
    str1 = ""
    data=data.upper()
    for letter in data:
        try:
            if(letter=="*"):
                str1+="Е"
            elif(letter=="-"):
                str1+="Т"
            else:
            	str1+=str(letter)
        except KeyError:
            str1+=str(letter)
    return(str1)

sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

serverAddress = ('localhost', 8080)
sock.bind(serverAddress)

sock.listen(1)

while True:
    print('Ожидание соединения...')
    connection, client_address = sock.accept()
    try:
        print('Подключён:', client_address)
        while True:
            data = connection.recv(512)
            data = data.decode('utf-8')
            print(data)
            if data:
                if(data[0]=="1"):
                    data = data[1 :]
                    data = Normal(data)
                elif(data[0]=="2"):
                    data = data[1 :]
                    data = Morze(data)
                else:
                    break
                connection.sendall(data.encode())
            else:
                print('Нет данных от:', client_address)
                break
    finally:
        connection.close()


