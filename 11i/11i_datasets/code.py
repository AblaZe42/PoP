import csv 

def get_data(): 
    data = []
    with open('tx_deathrow_full.csv','r') as f: 
        reader = csv.DictReader(f) 
        for row in reader: 
            data.append(row)
    return data 

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

data = get_data() 
testTo_metric = to_metric(data)

print(*testTo_metric, sep = "\n")
