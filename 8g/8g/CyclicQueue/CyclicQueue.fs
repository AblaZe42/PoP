module CyclicQueue

type Value = int

let mutable array = [||]
let mutable tail = -1
let mutable head = 0
let mutable size = 0

let create (n: int) : unit =
    array <- [||]
    array <- Array.append array [|for i in 1 .. n -> None|]
    printfn "array: %A" array

let enqueue (e: Value) : bool =
    if tail = (array.Length-1)
    then
        size <- size + 1
        tail <- 0 
        array[tail] <- (Some e)
        printfn "%A" array
        true
    else 
        size <- size + 1
        tail <- (tail + 1) 
        array[tail] <- (Some e)
        printfn "%A" array
        true

let dequeue () : Value option =
    failwith "Not implemented yet: dequeue"    

let isEmpty () : bool =
    failwith "Not implemented yet: isEmpty"    

let length () : int =
    array.Length

let toString () : string =
    failwith "Not implemented yet: toString"    
