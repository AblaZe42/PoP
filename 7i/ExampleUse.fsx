type 'a dlist = 'a list -> 'a list 

// Difference list ~ cons-list with parameterized tail; dl ~ (xs @ <tail>
let toDiffList xs = List.append xs     // O(1)
// Cons list ~ difference list with tail set to []
let fromDiffList dl = dl []    // O(n)
// nil ~ []
let nil = fun ys -> ys // = toDList [], identity function
// single x ~ [x]
let single x = fun ys -> x :: ys
let append = (<<)
let cons x dl = append (single x) dl // = append (single x) dl
// append dl dl' ~ xs @ xs' if dl ~ xs and dl' ~ xs'

let snoc dl = append dl << single 
let snoc' x dl = snoc dl x // arguments flipped

// performance test

let r1 n = List.length (List.foldBack (fun x xs -> xs @ [x]) [1..n] [])
let r2 n = List.length (fromDiffList (List.foldBack snoc' [1..n] nil))

printfn "toDiffList %A" (toDiffList [1;2] [3;4])

let testfromDiffList (lst: int list) : int list = 
    3 :: lst

printfn "fromDiffList %A" (fromDiffList testfromDiffList)

printfn "nil %A" (nil [])

printfn "single %A" (single 4 [])

let f1 x = x+1
let f2 x = x*(-1)
// f1 << f2 2 ->
// f1 << -2 ->
//f1 -2 ->
// -2 + 1 = -1 
printfn "append %A" (append f1 f2 2)

printfn "cons %A" (cons 4 testfromDiffList [1;2])

printfn "snoc dl %A" (snoc testfromDiffList 4 [1;2])
printfn "snoc' x dl %A" (snoc' 4 testfromDiffList [1;2])
