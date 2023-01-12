##### -- 2ø0 -- #####
print("2ø0")
def nul() :
    firstName = "Jon"
    lastName = "Sporring"
    print(firstName, lastName)
nul()

##### -- 2ø1 -- #####
print( )
print("2ø1")
def en (x):
    a = 3
    b = 4
    fx = a * x + b
    print( fx )
en(2)

##### -- 2ø3 -- #####
print( )
print("2ø2")
# Input #
# toVal = input("Input value \n ")
# toVal = int(toVal)
toVal = 5
def to (i) :
    if i == 1:
        return 1
    else:
        return(i * to(i-1) )

toTest = to(toVal)
print (toTest)

##### -- 2ø4 -- #####
print( )
print("2ø3")
def tre1 (x, n):
    return x ** n

tre1Test = tre1(2, 4)
print (tre1Test)

##### -- 3ø0 -- #####
print( )
print("3ø0")
def fire ():
    lst = []
    lst2 = ["python"]
    lst3 = ["Hello"] * 1
    lst4 = lst2 + lst3
    lst5 = list(range(1, 4))
    return lst5

def fireF (i):
    if i == 0:
        return []
    else:
        return (fireF(i-1)) + [i]

def fireG (i):
    if i == 1:
        return [1]
    else:
        return [i] + (fireG(i-1))

fireFtest = fireF(10)
fireGTest = fireG(5)
fireTest = fire()
print(fireTest)
print(fireFtest)
print(fireGTest)

##### -- 3ø1 -- #####
print( )
print("3ø1")
def fem():
    lst = [1, 2, 3]
    result = list(map(lambda n: n / 2, lst))
    return result 

femTest = fem()
print(femTest)

#3ø2
print( )
print("3ø2")
def seks(n):
    
    return n[0]
testSeks = seks(fireFtest)
print (testSeks)
