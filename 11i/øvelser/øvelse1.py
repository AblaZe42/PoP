##### -- Øvelse 1 -- #####
lst1 = ["Napoleon", "Wellington", "Bonaparte", "Wellington"]
lst2 = [1,2,3,4,5,1,5,4,3,2,1]

def forekomster (lst, x) :
    a = lst.count(x)
    print(a)

print("Øvelse 1 ")
forekomster(lst1, "Wellington")
forekomster(lst2, 1)

##### -- Øvelse 2 -- #####
print()
print("Øvelse 2 ")
def palindrom (word):
    txt = word [::-1]
    if word == txt:
        return True
    else:
        return False

print (palindrom("ebbe"))
print (palindrom("jens"))

##### -- Øvelse 3 -- #####
print()
print("Øvelse 3 ")
