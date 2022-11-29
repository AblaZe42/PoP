let fac (n:int) =
    let mutable i = 1
    let mutable g = 1
    while i <= n do
        printf "%A " (g)
        i <- i + 1
        g <- i * g
        printfn ""
fac (5)