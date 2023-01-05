import csv 

'''
Returns a list of rows from tx_deathrow_full.csv
    Returns:
        List of dictionaries
'''
def get_data(): 
    lst = []
    with open('tx_deathrow_full.csv','r') as csvfile: 
        deathrow_reader = csv.DictReader(csvfile) 
        for row in deathrow_reader: 
            lst.append(row)
    return lst 

'''
Returns a list of rows from tx_deathrow_full.csv, but height is converted 
to cm and weight is converted to kg
    Parameters:
        deathrow_data: Data set containing list of dictionaries

    Returns:
        List of dictionaries
'''
def to_metric(deathrow_data):
    lst = []
    for row in deathrow_data:
        #Height
        height = (row['Height'])
        if height != '':
            feet, inches = height.split("'")
            totalCM = (int(feet) * 12 + int(inches.strip()[:-1])) * 2.54
            totalCM = round(totalCM, 2)
        #Weight
        weight = row['Weight']
        if weight != '':
            weightKg = round((int(weight)/2.2046), 2)
        #addToList
        row['Height'] = totalCM
        row['Weight'] = weightKg
        lst.append(row)
    return (lst)

'''
Creates a dictinary where key = County 
and there is one attribute 'Number of people from given County'
    Parameters:
        deathrow_data: Data set containing list of dictionaries

    Returns:
        Dictionary
'''
def county_statistics(deathrow_data):
    countyDic = {}
    for row in deathrow_data:
        county = row['County']
        if county in countyDic: 
            countyDic[county] += 1
        else: 
            countyDic[county] = 1
    return countyDic

'''
Creates a dictinary where key = Native County 
and there is one attribute 'Number of people from given Native County'
    Parameters:
        deathrow_data: Data set containing list of dictionaries

    Returns:
        Dictionary
'''
def native_statistics(deathrow_data):
    nativeDic = {}
    for row in deathrow_data:
        native = row['Native County']
        if native in nativeDic: 
            nativeDic[native] += 1
        else: 
            nativeDic[native] = 1
    return nativeDic

'''
beskrivelse
    Parameters:
        deathrow_data: Data set containing list of dictionaries
        words: The list of word that we want to search after

    Returns:
        list of tuples
'''
def last_words_search(deathrow_data, words):
    lst = []
    for row in deathrow_data:
        LastWords = row['Last Statement']
        for word in words:
            if word in LastWords:
                info = "Name: " + row['First Name'] + " " + row['Last Name'] +  " Age: " + row['Age at Execution']          
                lst.append((info, LastWords))
    return lst