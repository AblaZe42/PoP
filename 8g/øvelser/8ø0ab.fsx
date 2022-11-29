//Highest number is ~ 20
let fac =
    printfn "Enter number to calculate the factorial"
    let a = int64(System.Console.ReadLine ())
    let mutable i = 1L
    let mutable g = 1L
    while i <= a do
        printf "%A " (g)
        i <- i + 1L
        g <- i * g
        printfn ""
fac 
