// Difference lists
module DiffList

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
