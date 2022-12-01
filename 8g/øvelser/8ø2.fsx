//Øvelse a
let mulTable (n:int) =
     let str = "     1  2  3  4  5  6  7  8  9 10"
     str[0 .. n*3]

printfn "a: "
printfn "%s" (mulTable 10)

//øvelse b
let loopMulTable (n:int) =
    let mutable str = "  "
    let mutable int = 1
    for i = 1 to n do
        str <- str + (sprintf "%4d" i) 
        int <- int + 1
    str
printfn "b: "
printfn "%s" (loopMulTable 10)

// let loopMulTable2 (n:int) =
//     let mutable int = 1
//     let mutable lst = []
//     while int <= n do 
//         lst <- lst @ [(loopMulTable 10)]
//         int <- (int + 1)
//         for i in lst do
//             sprintf "%A" i
//     lst

// loopMulTable2 3
// printfn "%A" (loopMulTable2 10)

// let lst = ["cat"; "fish"; "fly"]
// for i in lst do
// printf "%A " i
// printfn ""

// for i in [1..5] do
// printf "%A " i
// printfn ""

// let mulTable (n:int) =
//     let mutable i = 1
//     while i <= 10 do
//         printf "%d " i
//         i <- i + 1
//     printf "\n"

// mulTable (4)