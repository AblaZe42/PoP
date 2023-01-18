import unittest
import pipeLine

n = pipeLine

def opgaveA():
    print(" ---------- Opgave A ---------- ")

    testDoNothing = n.DoNothing()
    print("Do nothing: " + str(testDoNothing.apply(42)) )

    testAddConst = n.addConst(1)
    print("addConst:   " + str(testAddConst.apply(41)))

    testRepeater = n.repeater(5)
    print("repeater:   " + str(testRepeater.apply(42)))

    testGeneralSum = n.GeneralSum()
    print("GeneralSum: " + str(testGeneralSum.apply([1, 2, 3, 4, 5, 6, 7, 8, 9, 10])))

    ProductNum = n.ProductNum()
    print("ProductNum: " + str(ProductNum.apply([1, 2, 3, 4, 5])))

def opgaveB():
    print()
    print(" ---------- Opgave B ---------- ")
    adderOne = n.Map(n.addConst(2))
    print ("Map:        " + str(adderOne.apply([1, 2, 3, 4 ,5])))

def opgaveC():
    print()
    print(" ---------- Opgave C ---------- ")
    testPipeline = n.Pipeline([
        n.addConst(45),
        n.repeater(3),
        n.Map(n.addConst(-3)),
        n.DoNothing(),
        n.ProductNum()])
    print("Pipeline:   " + str(testPipeline.apply(0)))
    print (testPipeline.description())

def opgaveD():
    print()
    print(" ---------- Opgave D ---------- ")
    import csv
    data = n.CsvReader.apply('critters.csv') 
    testStats = n.critterStats()
    testStats.apply(data)
    testBar2 = n.ShowAsciiBarchart()
    print (testBar2.apply(testStats.apply(data)))

def opgaveE():
    print()
    print(" ---------- Opgave E ---------- ")
    testCal = n.cal(2)
    testAverage = n.average()
    print("square:     " + str(testCal.square()))
    print("cube:       " + str(testCal.cube()))
    print("average:    " + str(testAverage.apply(([5, 5, 5, 5]))))

opgaveA()
opgaveB()
opgaveC()
opgaveD()
opgaveE()