module CyclicQueue

//Types
type Value = int

//Variables
let mutable q = [||]
let mutable tail = -1
let mutable head = 0
let mutable size = 0

//Functions
/// <summary>Create or clear the cyclic queue</summary>
/// <param name="n">The maximum number of elements</param>
let create (n: int) : unit =
    tail <- -1
    q <- [||]
    q <- Array.append q [|for i in 1 .. n -> None|]
    printfn "array: %A" q

/// <summary>Add an element to the end of a queue</summary>
/// <param name="e">an element</param>
/// <returns>True if the queue had space for the element</returns>
let enqueue (e: Value) : bool =
    if size = q.Length
    then false
    else
        if tail = (q.Length-1)
        then
            size <- size + 1
            tail <- 0 
            q[tail] <- (Some e)
            true
        else 
            size <- size + 1
            tail <- tail + 1 
            q[tail] <- (Some e)
            true
 
/// <summary>Remove the element in the front position of the queue</summary>
/// <returns>The first element in q or None if the queue is empty</returns>
let dequeue () : Value option =
    if size = 0
    then None
    else
        if head = (q.Length-1)
        then
            size <- size - 1
            head <- 0
            let h = head
            head  <- head + 1
            q[h]
        else
            size <- size - 1
            let h = head
            head  <- head + 1
            q[h]
        
/// <summary>Check if the queue is empty</summary>
/// <returns>True if the queue is empty</returns>
let isEmpty () : bool =
    if size = 0
    then true
    else false   

/// <summary>Get the length of the queue</summary>
/// <returns>The number of elements in the queue</returns>
let length () : int =
    size

/// <summary>The queue on string form</summary>
/// <returns>A string representing the queue's elements</returns>
let toString () : string =
    let mutable str = ""
    let mutable h = head
    for i = 0 to (size-1) do
        if h = (q.Length-1)
        then 
            str <- str + (sprintf "%A " q[h])
            h <- 0
        else
            str <- str + (sprintf "%A " q[h])
            h <- h + 1      
    str