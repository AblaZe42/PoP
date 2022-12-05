module CyclicQueue

//Types
type Value = int

//Variables
let mutable q = [||]
let mutable last = -1
let mutable first = 0
let mutable size = 0

//Functions
let create (n: int) : unit =
    last <- -1
    q <- [||]
    q <- Array.append q [|for i in 1 .. n -> None|]
    printfn "array: %A" q

let enqueue (e: Value) : bool =
    if size = q.Length
    then false
    else
        if last = (q.Length-1)
        then
            size <- size + 1
            last <- 0 
            q[last] <- (Some e)
            true
        else 
            size <- size + 1
            last <- last + 1 
            q[last] <- (Some e)
            true
 
let dequeue () : Value option =
    if size = 0
    then None
    else
        if first = (q.Length-1)
        then
            size <- size - 1
            first <- 0
            let h = first
            first  <- first + 1
            q[h]
        else
            size <- size - 1
            let h = first
            first  <- first + 1
            q[h]
        
let isEmpty () : bool =
    if size = 0
    then true
    else false   

let length () : int =
    size

let toString () : string =
    let mutable str = ""
    let mutable h = first
    for i = 0 to (size-1) do
        if h = (q.Length-1)
        then 
            str <- str + (sprintf "%A " q[h])
            h <- 0
        else
            str <- str + (sprintf "%A " q[h])
            h <- h + 1      
    str