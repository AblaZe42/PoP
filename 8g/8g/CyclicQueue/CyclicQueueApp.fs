open CyclicQueue

[<EntryPoint>]
let main _ =
    printfn "* Test create *"
    create 5
    printfn ""
    printfn "* Test enqueue*"
    enqueue 1
    enqueue 2
    enqueue 3
    enqueue 4
    enqueue 5
    printfn "toString: %A" (toString())
    printfn ""
    printfn "* Test dequeue *"
    printfn "dequeue: %A" (dequeue())
    // printfn "dequeue: %A" (dequeue())
    printfn "toString: %A" (toString())
    // printfn ""
    // printfn "* Test isEmpty *"
    // printfn "isEmpty: %A" (isEmpty())
    // printfn ""
    // printfn "* Test length *"
    // printfn "length: %A" (length())
    // printfn ""
    // printfn "* Test toString *"
    printfn "* enequeue 6 *"
    enqueue 6
    // enqueue 7
    printfn "toString: %A" (toString())
    0