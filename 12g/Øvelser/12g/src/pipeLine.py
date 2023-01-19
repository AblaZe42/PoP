import csv

class DoNothing:
    """Do nothing
    >>> DoNothing().apply('Filippa69')
    'Filippa70'
    """
    def apply(self, inp):
        return inp
    def description(self) -> str:
        return self.__doc__.lower()

class addConst:
    ''' Ddd value and input together
    >>> addConst(1).apply(41)
    42
    ''' 
    def __init__(self, value):
        self.value = value 
    
    def apply (self, inp):
        return inp + self.value

    def description(self) -> str:
        return self.__doc__.lower()


class repeater:
    ''' Create a list of inp with num length 
    >>> repeater(5).apply(42)
    [42, 42, 42, 42, 42] 

    '''


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
    ''' Uses given operater on list 
    >>> General(1, lambda x,y: x*y).apply([22, 13, 3])
    858
    '''
    def __init__(self,ne,op):
        self._neutral = ne #neutralt element dvs + = 0, * = 1
        self.operator = op #operator dvs funktion
    def apply(self,input):
        startAcc = self._neutral
        function = self.operator
        for i in input:
            startAcc = function(i,startAcc)
        return startAcc
    def description(self,):
        return self.__doc__.lower()

class SumNum:
    ''' add all elements together 
    >>> SumNum().apply([1, 2, 3, 4, 5, 6, 7, 8, 9, 10])
    55
    '''

    def apply (self, inp):
        n = GeneralSum(0, lambda x,y: x+y)
        return n.apply(inp)
        
    def description(self) -> str:
        return self.__doc__.lower()

class ProductNum:
    ''' Multiplies all elements together 
    >>> Product().apply([1, 2, 3, 4, 5])
    120
    '''

    def apply (self, inp):
        n = GeneralSum(1, lambda x,y: x*y)
        return n.apply(inp)
        
    def description(self) -> str:
        return self.__doc__.lower()

class Map:
    ''' Adds self.step to all elements in list
    >>> Map(addConst(2)).apply([1, 2, 3, 4, 5])
    [3, 4, 5, 6, 7]
    '''
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

class Pipeline:
    ''' Applies all elements in list on inp
    >>> Pipeline([
        n.addConst(45),
        n.repeater(3),
        n.Map(n.addConst(-3)),
        n.DoNothing(),
        n.ProductNum()]).apply(0)
    74088
    '''
    def __init__(self, step):
        self.step = step 
    
    def addSteps(self, inp):
        self.step += [inp]

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

class CsvReader:
    ''' Reads data from file one row at a time
    >>> CsvReader.apply('critters.csv')
    Returns a list of dictionaries 
    
    
    '''
    def apply(inp): 
        lst = []
        with open(inp,'r') as csvfile: 
            deathrow_reader = csv.DictReader(csvfile) 
            for row in deathrow_reader: 
                lst.append(row)
        return lst 

class critterStats:
    ''' Creates a list of dictionaries containing a color 
    and a int representing how many times the color is in the dataFile.
    >>> critterStats().apply(data)
    returns list of dictonaries
    '''
    
    def apply(self, inp):
        colorDic = {}
        for row in inp:
            Colour = row['Colour']
            if Colour in colorDic: 
                colorDic[Colour] += 1
            else: 
                colorDic[Colour] = 1
        return colorDic

class ShowAsciiBarchart:
    ''' Creates a barchart in a string
    >>> showAsciiBarchart().apply(critterstats().apply(CsvReader.apply('critters.csv')))
    Returns a string containing a barchart
    '''
    def maxLength(self, inp):
        n = max(len(key) for key in inp)
        return n

    def apply(self, inp):
        n = ""
        for key, value in inp.items():
            n = n + "\n" + ("{}: {}".format(key.ljust(self.maxLength(inp)), "*" * value)).capitalize()
        return n

class cal:
    ''' .square squares self.value
    >>> cal(2).square()
    4    

    .cube squares self.value
    >>> cal(2).cube()
    8

    '''
    def __init__(self, value):
        self.value = value

    def square(self):
        return self.value * self.value

    def cube(self):
        return self.value * self.value * self.value

class average:
    ''' Takes the average of inp
    >>> average().apply([5, 5, 5, 5])
    5
    '''
    def apply(self, inp):
        sum = SumNum()
        n = sum.apply(inp)
        return n / len(inp)