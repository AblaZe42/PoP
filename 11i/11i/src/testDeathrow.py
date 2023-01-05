import unittest
import deathrow
a = deathrow

print("test to_metric")
data = a.get_data() 
testTo_metric = a.to_metric(data)
print(*testTo_metric, sep = "\n")

print( "\n \n \n \n \n \n \n \n \n \n" )
print("Test county_statistics(deathrow_data)")
test_county_statistics = a.county_statistics(data)
print(test_county_statistics)

print( "\n \n \n \n \n \n \n \n \n \n" )
print("Test native_statistics(deathrow_data)")
test_native_statistics = a.native_statistics(data)
print(test_native_statistics)

print( )
print("Test last_words_search(deathrow_data, words)")
test_last_words_search = a.last_words_search(data, ["oneself", "god"])
print(*test_last_words_search, sep= "\n" )