module CyclicQueue

type Value = int

let mutable array = [||]

let create (n: int) : unit =
    array <- [||]
    array <- Array.append array [|for i in 1 .. n -> None|]
    printfn "array: %A" array

let enqueue (e: Value) : bool =
    failwith "Not implemented yet: dequeue"    

let dequeue () : Value option =
    failwith "Not implemented yet: dequeue"    

let isEmpty () : bool =
    failwith "Not implemented yet: isEmpty"    

let length () : int =
    let a = [|1; 2; 3|]
    a.Length

let toString () : string =
    failwith "Not implemented yet: toString"    
