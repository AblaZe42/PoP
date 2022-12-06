type incr() =
    let mutable counter = 0
    member this.get 
        with get () = counter
    member this.increase =
        counter <- counter + 1

let test = 
    let something = incr()
    printfn "%A" (something.get)
    something.increase
    printfn "%A" (something.get)
    something.increase
    printfn "%A" (something.get)
    something.increase
    printfn "%A" (something.get)
test