#Create empty queue
def emptyQueue():
    queue = []
    return queue

q0 = emptyQueue()
print(q0)

#Check if queue is empty
def isEmpty(q):
    if q == []:
        return True
    else:
        return False

print(isEmpty(q0))

#Add element to end of queue
def enqueue (e, q) =
    