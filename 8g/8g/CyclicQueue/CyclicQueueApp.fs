open CyclicQueue

[<EntryPoint>]
let main _ =
    create 5
    create 10
    create 3
    printfn "%A" (length())
    enqueue 5
    enqueue 6
    enqueue 7

    // Write your tests here
    // (or organize your tests into functions and call them from here)
    // Exit status; consider making it the number of failed tests
    0