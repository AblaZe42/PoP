import csv

class DoNothing:
    """Do nothing"""
    def apply(self, inp):
        return inp
    def description(self) -> str:
        return self.__doc__.lower()

a = DoNothing()
print(a.description())

class addConst:
    ''' add value and input ''' 
    def __init__(self, value):
        self.value = value    # instance variable unique to each instance
    
    def apply (self, inp):
        return inp + self.value

    def description(self) -> str:
        return self.__doc__.lower()


class repeater:
    ''' Repeate num times, as a list ''' 
    def __init__(self, num):
            self.num = num   

    def apply (self, inp):
        lst = []
        for x in range (self.num):
            lst.insert(True, inp)
        return lst

    def description(self) -> str:
        return self.__doc__.lower()

class GeneralSum:
    ''' add all elements together  '''
    def apply (self, inp):
        n = 0
        for x in range(False, len(inp)):
            n = n + inp[x]
        return n
    def description(self) -> str:
        return self.__doc__.lower()

class ProductNum:
    ''' multiply all elements '''
    def apply (self, inp):
        n = 1
        for x in range(False, len(inp)):
            n = n * inp[x]
        return n
    def description(self) -> str:
        return self.__doc__.lower()

quintiplyer = repeater(5)
quintiplyer.apply(42)

summer = GeneralSum()
summer.apply([1,2,3,4,5,6,7,8,9,10])

proder = (ProductNum())
proder.apply([1,2,3,4,5])

class Map:
    ''' Something '''
    def __init__(self, step):
        self.step = step 

    def apply (self, inp):
        lst = []
        for x in range (len(inp)):
            value = self.step.apply(inp[x])
            lst.append(value)
        return lst
    def description(self) -> str:
        return self.__doc__.lower()

adderOne = Map(addConst(2))
print (adderOne.apply([1, 2, 3, 4 ,5]))

class Pipeline:
    def __init__(self, step):
        self.step = step 
    
    def apply(self, inp):
        value = inp
        for x in range (len(self.step)):
            value = self.step[x].apply(value)
        return value 

    def description(self) -> str:
        lst = []
        for x in range (len(self.step)):
            value = self.step[x].description()
            lst.append(value)
        s = ' --> '.join(lst)
        return s 

testPipeline = Pipeline([
    addConst(45),
    repeater(3),
    Map(addConst(-3)),
    DoNothing(),
    ProductNum()])

print (testPipeline.apply(0))
print (testPipeline.description())

class CsvReader:
    def apply(inp): 
        lst = []
        with open(inp,'r') as csvfile: 
            deathrow_reader = csv.DictReader(csvfile) 
            for row in deathrow_reader: 
                lst.append(row)
        return lst 

data = CsvReader.apply('critters.csv') 

class critterStats:
    def apply(self, inp):
        colorDic = {}
        for row in inp:
            Colour = row['Colour']
            if Colour in colorDic: 
                colorDic[Colour] += 1
            else: 
                colorDic[Colour] = 1
        return colorDic

testStats = critterStats()
print (testStats.apply(data))
