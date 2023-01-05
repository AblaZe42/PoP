import csv 

def get_data(): 
    data = []
    with open('tx_deathrow_full.csv','r') as f: 
        reader = csv.DictReader(f) 
        for row in reader: 
            data.append(row)
    return data 

def to_metric(deathrow_data):
    metric_data = []
    for row in deathrow_data:
        metric_row = row.copy()
        height = row['Height']
        feet, inches = height.split("'")
        feet = int(feet)
        inches = int(inches.strip()[:-1])
        total_inches = feet * 12 + inches
        total_cm = total_inches * 2.54
        metric_row['Height'] = total_cm
        weight = row['Weight']
        if weight:
            weight_kg = int(weight) / 2.2046
            metric_row['Weight'] = weight_kg
        metric_data.append(metric_row)
    return metric_data

data = get_data()
print(to_metric(list(data[1])))